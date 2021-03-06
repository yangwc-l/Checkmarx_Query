CxList methods = Find_Methods();

CxList db = All.NewCxList();
db.Add(methods.FindByMemberAccess("Statement.execute*"));
db.Add(methods.FindByMemberAccess("PreparedStatement.execute*"));
db.Add(methods.FindByMemberAccess("CallableStatement.execute*"));
db.Add(methods.FindByMemberAccess("JdbcTemplate.query*"));
db.Add(methods.FindByMemberAccess("JdbcTemplate.insert"));
db.Add(methods.FindByMemberAccess("JdbcTemplate.update"));
db.Add(methods.FindByMemberAccess("JdbcTemplate.delete"));
db.Add(methods.FindByMemberAccess("JdbcTemplate.execute"));

db.Add(methods.FindByMemberAccess("SoapBindingStub.query"));
db.Add(methods.FindByMemberAccess("SoapBindingStub.queryAll"));
db.Add(methods.FindByMemberAccess("SoapBindingStub.search"));
// qSql
db.Add(methods.FindByMemberAccess("QSqlQuery.exec"));
db.Add(methods.FindByMemberAccess("QSqlQuery.execBatch"));
// Query
db.Add(methods.FindByMemberAccess("Query.getSingleResult"));
db.Add(methods.FindByMemberAccess("Query.getResultList"));
db.Add(methods.FindByMemberAccess("Query.executeUpdate"));

// Salesforce 	
db.Add(methods.FindByMemberAccess("SforceService.query"));
db.Add(methods.FindByMemberAccess("SforceService.queryAll"));
db.Add(methods.FindByMemberAccess("SforceService.search"));
	
//Oracle DB out
db.Add(methods.FindByMemberAccess("CallableStatement.get*"));

// spring Hibernate
db.Add(methods.FindByShortName("executeFind"));
// Hibernate Query
db.Add(methods.FindByMemberAccess("Query.iterate"));
db.Add(methods.FindByMemberAccess("Query.list"));
db.Add(methods.FindByMemberAccess("Query.scroll"));
db.Add(methods.FindByMemberAccess("Query.uniqueResult"));


/* start JDO */
CxList newquery = All.FindByMemberAccess("PersistenceManager.newQuery");
CxList sqlType = Find_Strings().FindByName("*javax.jdo.query.SQL*");
sqlType.Add(Find_UnknownReference().FindByShortName("Query").GetMembersOfTarget().FindByShortName("SQL"));
newquery = All.FindByParameters(sqlType) * newquery;
CxList sqlParam = All.GetParameters(newquery, 1);
CxList queryexecute = All.FindByMemberAccess("Query.execute");
CxList jdo = sqlParam.DataInfluencingOn(queryexecute) * sqlParam; //sql expression parameter which is inserted into query and executed later
/* end JDO*/

/*start SimpleDB*/
CxList obj = Find_ObjectCreations(); 
CxList selectExp = All.GetByAncs(obj).FindByShortName("SelectRequest");
selectExp.Add(All.FindByMemberAccess("SelectRequest.setSelectExpression"));
selectExp.Add(All.FindByMemberAccess("SelectRequest.withSelectExpression"));
CxList sdbc = All.FindByMemberAccess("AmazonSimpleDBClient.select");

CxList simpleDb = selectExp.DataInfluencingOn(sdbc) * selectExp;
/*end SimpleDB*/

result = db;
result.Add(Find_DAL_DB());
result.Add(jdo);
result.Add(simpleDb);