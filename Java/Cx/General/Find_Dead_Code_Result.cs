/*
We deal with different cases:
1. A block of if/while that is always false (or an "else" of an if stmt which is always true)
2. Private methods that are never called
3. A return/break/continue statement with code afterwards
4. A default in a switch-case where the switch value and the case value are the same
5. Switch-case where the switch is integer and the case is another integer
6. Iterations where the initialization and the condition cause that the iteration will never start
7. Catch block of an empty try
*/

/// Part 1 - A block of if/while that is always false (or an "else" of an if stmt which is always true)

// Find all true statements
CxList True = Find_Always_True();

// Loop over all "always true" if statements, and add their "else" blocks to the dead code list
CxList falseBlocks = All.NewCxList();
foreach (CxList t in True)
{
	try
	{
		CxList cond = t.GetFathers();
		if (cond.FindByType(typeof(IfStmt)).Count > 0)
		{
			IfStmt ifStmt = cond.TryGetCSharpGraph<IfStmt>();
			falseBlocks.Add(ifStmt.FalseStatements.NodeId, ifStmt.FalseStatements);
		}
	}
	catch (Exception ex)
	{
		cxLog.WriteDebugMessage(ex);
	}
}

// Loop over all "always false" if and loop statements, and add their blocks to the dead code list
CxList False = Find_Always_False();
foreach (CxList t in False)
{
	try
	{
		CxList cond = t.GetFathers();
		if (cond.FindByType(typeof(IfStmt)).Count > 0)
		{
			IfStmt ifStmt = cond.TryGetCSharpGraph<IfStmt>();
			falseBlocks.Add(ifStmt.TrueStatements.NodeId, ifStmt.TrueStatements);
		}
		else if (cond.FindByType(typeof(IterationStmt)).Count > 0)
		{
			IterationStmt iter = cond.TryGetCSharpGraph<IterationStmt>();
			falseBlocks.Add(iter.Statements.NodeId, iter.Statements);
		}

	}
	catch (Exception ex)
	{
		cxLog.WriteDebugMessage(ex);
	}
}


/// Part 2 - Private methods that are never called

// Find all private methods
CxList privateMethods = Find_MethodDeclaration().FindByFieldAttributes(Modifiers.Private);
// Remove java.io.serializable interface
privateMethods = privateMethods - privateMethods.FindByShortName("writeObject");
privateMethods = privateMethods - privateMethods.FindByShortName("readObject");
// Get all their references
CxList privateReferences = All.FindAllReferences(privateMethods) - privateMethods;
// And leave only the ones that are never called
CxList unusedPrivateMethods = privateMethods - privateMethods.FindDefinition(privateReferences);


/// Part 3 - A return/break/continue statement with code afterwards

/*
In this part we look for commands that follow a return commands.
For every return command we will look at the containing block and make sure that the return is the last
command in the block, by comparing Id's.
There might be (very) extreme cases where we fail to find a result - for example when there is a return
at the end of both "if" blocks (if and else), but there are additional commands after the if statement. For
now we prefer this then a more complex algorithm and/or false positives.
*/

// Find all the relevant breakStmts/ return stmts and continue statements
CxList returnCommand = Find_ReturnStmt();
returnCommand.Add(base.Find_BreakStmt());
returnCommand.Add(base.Find_ContinueStmt());

// Add the (unlikely to exist) case of if(true) return;
CxList alwaysTrueReturn = True.GetByAncs(returnCommand.GetAncOfType(typeof(IfStmt))).GetFathers();
alwaysTrueReturn = All.GetByAncs(alwaysTrueReturn) - returnCommand;
alwaysTrueReturn -= alwaysTrueReturn.GetByAncs(Find_Conditions());
alwaysTrueReturn -= alwaysTrueReturn.FindByType(typeof(ExprStmt));
alwaysTrueReturn -= alwaysTrueReturn.FindByType(typeof(BreakStmt));
alwaysTrueReturn -= alwaysTrueReturn.FindByType(typeof(StatementCollection));

foreach (CxList alwaysTrue in alwaysTrueReturn)
{
	if (alwaysTrueReturn.GetByAncs(alwaysTrue).Count == 1)
	{
		returnCommand.Add(alwaysTrue);
	}
}

CxList codeAfterReturn = All.NewCxList();
foreach (CxList breakStmt in returnCommand)
{
	try
	{
		CxList stmt = breakStmt.GetFathers().FindByType(typeof(StatementCollection));
		if (stmt.Count > 0)
		{
			StatementCollection stmtCol = stmt.TryGetCSharpGraph<StatementCollection>();
			for (int i = 0; i < stmtCol.Count; i++)
			{
				if ((stmtCol[i] == breakStmt.GetFirstGraph()) && (i < stmtCol.Count - 1))
				{
					codeAfterReturn.Add(((CSharpGraph) stmtCol[i + 1]).NodeId, stmtCol[i + 1]);
					break;
				}
			}
		}	
	}
	catch (Exception ex)
	{
		cxLog.WriteDebugMessage(ex);
	}
}


/// Part 4 - A default in a switch-case where the switch value and the case value are the same

CxList Case = base.Find_Cases();

CxList relevantSwitch = Find_Same_Switch_And_Case().GetFathers();
CxList relevantCase = Case.GetByAncs(relevantSwitch);

CxList deadDefault = All.NewCxList();
foreach(CxList oneCase in relevantCase)
{
	Case c = oneCase.TryGetCSharpGraph<Case>();
	
	if(c.IsDefault)
	{
		deadDefault.Add(c.NodeId, c);
	}
}

deadDefault = All.FindByFathers(deadDefault);


/// Part 5 - Switch-case where the switch is integer and the case is another integer

CxList Switch = base.Find_SwitchStmt();
CxList caseValues = All.FindByFathers(Case);
caseValues -= caseValues.FindByType(typeof(StatementCollection));
CxList switchValues = All.FindByFathers(Switch) - Case;
CxList wrongCase = All.NewCxList();
foreach (CxList caseValue in caseValues)
{
	if (caseValue.GetFirstGraph() is IntegerLiteral)
	{
		CxList switchValue = switchValues.GetByAncs(caseValue.GetFathers().GetFathers());		
		if (switchValue.GetFirstGraph() is IntegerLiteral)
		{
			if (switchValue.FindByShortName(caseValue).Count == 0)
			{
				wrongCase.Add(All.FindByFathers(caseValue.GetFathers()) - caseValue);
			}
		}
	}
}


/// Part 6 - Iterations where the initialization and the condition cause that the iteration will never start

CxList iterations = base.Find_IterationStmt();
CxList inIterations = All.GetByAncs(iterations);
CxList allIterationConditions = inIterations.FindByFathers(iterations).FindByType(typeof(BinaryExpr));
CxList iterationConditions = allIterationConditions.FindByShortName("<");
iterationConditions.Add(allIterationConditions.FindByShortName(">"));
// Leave only the relevant iterations
iterations = iterationConditions.GetFathers();
inIterations = inIterations.GetByAncs(iterations);
CxList iterationStatements = inIterations.FindByFathers(iterations).FindByType(typeof(StatementCollection));
CxList inIterationConditions = All.GetByAncs(iterationConditions);

CxList ints = Find_Integers();
ints.Add(Find_IntegerLiterals());

CxList unreachableIterations = All.NewCxList();
foreach (CxList iteration in iterations)
{
	try
	{
		IterationStmt iter = iteration.TryGetCSharpGraph<IterationStmt>();
		StatementCollection init = iter.Init;
		if (init != null && init.Count > 0)
		{
			// Look at all the initialized variables
			foreach (Statement initStmt in init)
			{
				CxList decl = inIterations.GetByAncs(inIterations.FindById(initStmt.NodeId));
				CxList condition = iterationConditions.FindByFathers(iteration);
				CxList inCondition = inIterationConditions.GetByAncs(condition);
				//if an integer literal is a parameter of a function in the condition, remove it from the list
				//for example for ( int i = 0; i < rows.get( 0 ).size(); i++ ) is not dead code, because the 0 that is
				//the parameter of the get is not being compared to the value of i
				CxList toRemove = (inCondition * ints).GetFathers().FindByType(typeof(Param));
				
				CxList toRemoveCondition = inCondition.FindByFathers(toRemove);
				toRemoveCondition.Add(toRemove);				
				inCondition -= toRemoveCondition.FindByFathers(toRemove);
						
				CxList problematicCondition = (inCondition - condition).FindByType(typeof(BinaryExpr));
				problematicCondition.Add((inCondition - condition).FindByType(typeof(UnaryExpr)));
				if (problematicCondition.Count == 0)
				{
					// Init values
					CxList initName = decl.FindByType(typeof(Declarator));
					CxList initValue = decl.FindByType(typeof(IntegerLiteral));
					// Condition Values
					CxList conditionName = inCondition.FindByType(typeof(UnknownReference));
					CxList conditionValue = inCondition.FindByType(typeof(IntegerLiteral));
					// Compare them values
					if ((conditionName.FindByShortName(initName).Count > 0) &&
						(conditionValue.FindByShortName(initValue).Count > 0))
					{
						unreachableIterations.Add(iterationStatements.FindByFathers(iteration));
					}
				}
			}
		}
	}
	catch (Exception ex)
	{
		// Just in case some operation returns null
		cxLog.WriteDebugMessage(ex.ToString());		
	}
}

/// Part 7 - Catch block of an empty try
CxList emptyTry = Find_Empty_TryBlock();
CxList catchEmptyTry = All.FindByFathers(emptyTry).FindByType(typeof(Catch));

/// The result - all cases
result = falseBlocks;
result.Add(unusedPrivateMethods);
result.Add(codeAfterReturn);
result.Add(deadDefault);
result.Add(wrongCase);
result.Add(unreachableIterations);
result.Add(catchEmptyTry);