CxList methods = Find_Methods();

CxList xml_parse_mthds = methods.FindByMemberAccess("DocumentBuilder.parse", false);
CxList sanitizers = Find_XXE_Sanitize();
CxList UNsanitizers = Find_XXE_UNSanitize();

result = xml_parse_mthds - (xml_parse_mthds.InfluencedBy(sanitizers)) + (xml_parse_mthds.InfluencedBy(UNsanitizers));