result = All.NewCxList();
result.Add(All.FindByMemberAccess("String.contains"));
result.Add(All.FindByMemberAccess("String.startsWith"));
result.Add(All.FindByMemberAccess("String.endsWith"));
result.Add(All.FindByMemberAccess("String.compareTo*"));
result.Add(All.FindByMemberAccess("String.equals*"));
result.Add(All.FindByMemberAccess("String.contentEquals"));
result.Add(All.FindByMemberAccess("String.regionMatches"));
result.Add(All.FindByMemberAccess("String.matches"));
result.Add(All.FindByMemberAccess("Matcher.find"));
result.Add(All.FindByMemberAccess("Matcher.matches"));
result.Add(All.FindByMemberAccess("Matcher.equals"));
result.Add(All.FindByMemberAccess("Matcher.group*"));