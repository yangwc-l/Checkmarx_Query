/*
 MISRA CPP RULE 17-0-3
 ------------------
  The names of standard library functions shall not be overridden

  The Example below shows code with vulnerability: 

  		int printf(int a, int b) //Non-compliant
 			{
   			return ((a > b) ? a : b);
 			}

*/

// Functions from http://www.cplusplus.com/reference/ :

CxList methodsDecl = All.FindByType(typeof(MethodDecl));
result = methodsDecl.FindByShortName("assert") + 
	methodsDecl.FindByShortName("isalnum") +
	methodsDecl.FindByShortName("isalpha") +
	methodsDecl.FindByShortName("iscntrl") +
	methodsDecl.FindByShortName("isdigit") +
	methodsDecl.FindByShortName("isgraph") +
	methodsDecl.FindByShortName("islower") +
	methodsDecl.FindByShortName("isprint") +
	methodsDecl.FindByShortName("ispunct") +
	methodsDecl.FindByShortName("isspace") +
	methodsDecl.FindByShortName("isupper") +
	methodsDecl.FindByShortName("isxdigit") +
	methodsDecl.FindByShortName("tolower") +
	methodsDecl.FindByShortName("toupper") +
	methodsDecl.FindByShortName("errno") +
	methodsDecl.FindByShortName("setlocalev") +
	methodsDecl.FindByShortName("localeconv") +
	methodsDecl.FindByShortName("cos") +
	methodsDecl.FindByShortName("sin") +
	methodsDecl.FindByShortName("tan") +
	methodsDecl.FindByShortName("acos") +
	methodsDecl.FindByShortName("asin") +
	methodsDecl.FindByShortName("atan") +
	methodsDecl.FindByShortName("atan2") +
	methodsDecl.FindByShortName("cosh") +
	methodsDecl.FindByShortName("sinh") +
	methodsDecl.FindByShortName("tanh") +
	methodsDecl.FindByShortName("exp") +
	methodsDecl.FindByShortName("frexp") +
	methodsDecl.FindByShortName("ldexp") +
	methodsDecl.FindByShortName("log") +
	methodsDecl.FindByShortName("log10") +
	methodsDecl.FindByShortName("modf") +
	methodsDecl.FindByShortName("pow") +
	methodsDecl.FindByShortName("sqrt") +
	methodsDecl.FindByShortName("ceil") +
	methodsDecl.FindByShortName("fabs") +
	methodsDecl.FindByShortName("floor") +
	methodsDecl.FindByShortName("fmod") +
	methodsDecl.FindByShortName("longjmp") +
	methodsDecl.FindByShortName("setjmp") +
	methodsDecl.FindByShortName("jmp_buf") +
	methodsDecl.FindByShortName("signal") +
	methodsDecl.FindByShortName("raise") +
	methodsDecl.FindByShortName("va_start") +
	methodsDecl.FindByShortName("va_arg") +
	methodsDecl.FindByShortName("va_end") +
	methodsDecl.FindByShortName("remove") +
	methodsDecl.FindByShortName("rename") +
	methodsDecl.FindByShortName("tmpfile") +
	methodsDecl.FindByShortName("tmpnam") +
	methodsDecl.FindByShortName("fclose") +
	methodsDecl.FindByShortName("fflush") +
	methodsDecl.FindByShortName("fopen") +
	methodsDecl.FindByShortName("freopen") +
	methodsDecl.FindByShortName("setbuf") +
	methodsDecl.FindByShortName("setvbuf") +
	methodsDecl.FindByShortName("fprintf") +
	methodsDecl.FindByShortName("fscanf") +
	methodsDecl.FindByShortName("printf") +
	methodsDecl.FindByShortName("scanf") +
	methodsDecl.FindByShortName("sprintf") +
	methodsDecl.FindByShortName("sscanf") +
	methodsDecl.FindByShortName("vfprintf") +
	methodsDecl.FindByShortName("vprintf") +
	methodsDecl.FindByShortName("vsprintf") +
	methodsDecl.FindByShortName("fgetc") +
	methodsDecl.FindByShortName("fgets") +
	methodsDecl.FindByShortName("fputc") +
	methodsDecl.FindByShortName("fputs") +
	methodsDecl.FindByShortName("getc") +
	methodsDecl.FindByShortName("getchar") +
	methodsDecl.FindByShortName("gets") +
	methodsDecl.FindByShortName("putc") +
	methodsDecl.FindByShortName("putchar") +
	methodsDecl.FindByShortName("puts") +
	methodsDecl.FindByShortName("ungetc") +
	methodsDecl.FindByShortName("fread") +
	methodsDecl.FindByShortName("fwrite") +
	methodsDecl.FindByShortName("fgetpos") +
	methodsDecl.FindByShortName("fseek") +
	methodsDecl.FindByShortName("fsetpos") +
	methodsDecl.FindByShortName("ftell") +
	methodsDecl.FindByShortName("rewind") +
	methodsDecl.FindByShortName("clearerr") +
	methodsDecl.FindByShortName("feof") +
	methodsDecl.FindByShortName("ferror") +
	methodsDecl.FindByShortName("perror") +
	methodsDecl.FindByShortName("atof") +
	methodsDecl.FindByShortName("atoi") +
	methodsDecl.FindByShortName("atol") +
	methodsDecl.FindByShortName("strtod") +
	methodsDecl.FindByShortName("strtol") +
	methodsDecl.FindByShortName("strtoul") +
	methodsDecl.FindByShortName("rand") +
	methodsDecl.FindByShortName("srand") +
	methodsDecl.FindByShortName("calloc") +
	methodsDecl.FindByShortName("free") +
	methodsDecl.FindByShortName("malloc") +
	methodsDecl.FindByShortName("realloc") +
	methodsDecl.FindByShortName("abort") +
	methodsDecl.FindByShortName("atexit") +
	methodsDecl.FindByShortName("exit") +
	methodsDecl.FindByShortName("getenv") +
	methodsDecl.FindByShortName("system") +
	methodsDecl.FindByShortName("bsearch") +
	methodsDecl.FindByShortName("qsort") +
	methodsDecl.FindByShortName("abs") +
	methodsDecl.FindByShortName("div") +
	methodsDecl.FindByShortName("labs") +
	methodsDecl.FindByShortName("ldiv") +
	methodsDecl.FindByShortName("mblen") +
	methodsDecl.FindByShortName("mbtowc") +
	methodsDecl.FindByShortName("wctomb") +
	methodsDecl.FindByShortName("mbstowcs") +
	methodsDecl.FindByShortName("wcstombs") +
	methodsDecl.FindByShortName("memcpy") +
	methodsDecl.FindByShortName("memmove") +
	methodsDecl.FindByShortName("strcpy") +
	methodsDecl.FindByShortName("strncpy") +
	methodsDecl.FindByShortName("strcat") +
	methodsDecl.FindByShortName("strncat") +
	methodsDecl.FindByShortName("memcmp") +
	methodsDecl.FindByShortName("strcmp") +
	methodsDecl.FindByShortName("strcoll") +
	methodsDecl.FindByShortName("strncmp") +
	methodsDecl.FindByShortName("strxfrm") +
	methodsDecl.FindByShortName("memchr") +
	methodsDecl.FindByShortName("strchr") +
	methodsDecl.FindByShortName("strcspn") +
	methodsDecl.FindByShortName("strpbrk") +
	methodsDecl.FindByShortName("strrchr") +
	methodsDecl.FindByShortName("strspn") +
	methodsDecl.FindByShortName("strstr") +
	methodsDecl.FindByShortName("strtok") +
	methodsDecl.FindByShortName("memset") +
	methodsDecl.FindByShortName("strerror") +
	methodsDecl.FindByShortName("strlen") +
	methodsDecl.FindByShortName("clock") +
	methodsDecl.FindByShortName("difftime") +
	methodsDecl.FindByShortName("mktime") +
	methodsDecl.FindByShortName("time") +
	methodsDecl.FindByShortName("asctime") +
	methodsDecl.FindByShortName("ctime") +
	methodsDecl.FindByShortName("gmtime") +
	methodsDecl.FindByShortName("localtime") +
	methodsDecl.FindByShortName("strftime") +
	methodsDecl.FindByShortName("getline") + //IOstream Library
	methodsDecl.FindByShortName("swap");