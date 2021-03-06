CxList methods = Find_Methods();

List < String > sanitizeStrings = new List<String> {
	"intval",
	"floatval",
	"doubleval",
	"filter_input",
	"urlencode",
	"rawurlencode",
	"round",
	"floor",
	"strlen",
	"hexdec",
	"strrpos",
	"strpos",
	"md5",
	"sha1",
	"crypt",
	"crc32",
	"hash",
	"base64_encode",
	"ord",
	"sizeof",
	"count",
	"bin2hex",
	"levenshtein",
	"abs",
	"bindec",
	"decbin",
	"hexdec",
	"rand",
	"max",
	"min"};

result.Add(methods.FindByShortNames(sanitizeStrings));

//result.Add(methods.FindByShortName("intval"));
//result.Add(methods.FindByShortName("floatval"));
//result.Add(methods.FindByShortName("doubleval"));
//result.Add(methods.FindByShortName("filter_input"));
//result.Add(methods.FindByShortName("urlencode"));
//result.Add(methods.FindByShortName("rawurlencode"));
//result.Add(methods.FindByShortName("round"));
//result.Add(methods.FindByShortName("floor"));
//result.Add(methods.FindByShortName("strlen"));
//result.Add(methods.FindByShortName("hexdec"));
//result.Add(methods.FindByShortName("strrpos"));
//result.Add(methods.FindByShortName("strpos"));
//result.Add(methods.FindByShortName("md5"));
//result.Add(methods.FindByShortName("sha1"));
//result.Add(methods.FindByShortName("crypt"));
//result.Add(methods.FindByShortName("crc32"));
//result.Add(methods.FindByShortName("hash"));
//result.Add(methods.FindByShortName("base64_encode"));
//result.Add(methods.FindByShortName("ord"));
//result.Add(methods.FindByShortName("sizeof"));
//result.Add(methods.FindByShortName("count"));
//result.Add(methods.FindByShortName("bin2hex"));
//result.Add(methods.FindByShortName("levenshtein"));
//result.Add(methods.FindByShortName("abs"));
//result.Add(methods.FindByShortName("bindec"));
//result.Add(methods.FindByShortName("decbin"));
//result.Add(methods.FindByShortName("hexdec"));
//result.Add(methods.FindByShortName("rand"));
//result.Add(methods.FindByShortName("max"));
//result.Add(methods.FindByShortName("min"));