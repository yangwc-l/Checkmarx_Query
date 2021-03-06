// Find Sensitive data field (non boolean)
CxList sensitiveData = Find_Personal_Info();
sensitiveData = sensitiveData.FindByType(typeof(FieldDecl));
sensitiveData -= sensitiveData.FindByType("boolean");
sensitiveData -= sensitiveData.FindByType("bool");
// Find their classes
CxList sensitiveClasses = sensitiveData.GetAncOfType(typeof(ClassDecl));

// The problematic classes are the ones that are serializable
CxList problematicClasses = sensitiveClasses.InheritsFrom("Serializable");

// For each problematic class connect the class with the sensitive data inside it
foreach (CxList problematicClass in problematicClasses)
{
	CxList sensitive = sensitiveData.GetByAncs(problematicClass);
	result.Add(sensitive.ConcatenateAllSources(problematicClass));
}