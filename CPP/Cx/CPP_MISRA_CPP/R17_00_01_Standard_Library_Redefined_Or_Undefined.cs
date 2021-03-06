/*
 MISRA CPP RULE 17-0-1
 ------------------
  Reserved identifiers, macros and functions in the standard library shall 
  not be defined, redefined  or undefined.
 
  The Example below shows code with vulnerability: 

 				#define __TIME__ 111111 //Non-compliant

*/

//  Macros from http://msdn.microsoft.com/en-us/library/b0084kay%28v=vs.80%29.aspx :
result = All.FindByRegex(@"#\s*undef\s+__DATE__\s+", null) + 
	All.FindByRegex(@"#\s*define\s+__DATE__\s+", null)+
	
	All.FindByRegex(@"#\s*undef\s+__FILE__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__FILE__\s+", null) +
	
	All.FindByRegex(@"#\s*undef\s+__LINE__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__LINE__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__STDC__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__STDC__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__TIME__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__TIME__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__TIMESTAMP__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__TIMESTAMP__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_ATL_VER\s+", null) +
	All.FindByRegex(@"#\s*define\s+_ATL_VER\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_CHAR_UNSIGNED\s+", null) +
	All.FindByRegex(@"#\s*define\s+_CHAR_UNSIGNED\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__CLR_VER\s+", null) +
	All.FindByRegex(@"#\s*define\s+__CLR_VER\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__cplusplus_cli\s+", null) +
	All.FindByRegex(@"#\s*define\s+__cplusplus_cli\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__COUNTER__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__COUNTER__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__cplusplus\s+", null) +
	All.FindByRegex(@"#\s*define\s+__cplusplus\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_CPPLIB_VER\s+", null) +
	All.FindByRegex(@"#\s*define\s+_CPPLIB_VER\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_CPPRTTI\s+", null) +
	All.FindByRegex(@"#\s*define\s+_CPPRTTI\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_CPPUNWIND\s+", null) +
	All.FindByRegex(@"#\s*define\s+_CPPUNWIND\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_DEBUG\s+", null) +
	All.FindByRegex(@"#\s*define\s+_DEBUG\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_DLL\s+", null) +
	All.FindByRegex(@"#\s*define\s+_DLL\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__FUNCDNAME__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__FUNCDNAME__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__FUNCSIG__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__FUNCSIG__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__FUNCTION__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__FUNCTION__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_INTEGRAL_MAX_BITS\s+", null) +
	All.FindByRegex(@"#\s*define\s+_INTEGRAL_MAX_BITS\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_ALPHA\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_ALPHA\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_CEE\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_CEE\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_CEE_PURE\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_CEE_PURE\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_CEE_SAFE\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_CEE_SAFE\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_IX86\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_IX86\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_IA64\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_IA64\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_IX86_FP\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_IX86_FP\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_MPPC\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_MPPC\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_MRX000\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_MRX000\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_PPC\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_PPC\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_M_X64\s+", null) +
	All.FindByRegex(@"#\s*define\s+_M_X64\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_MANAGED\s+", null) +
	All.FindByRegex(@"#\s*define\s+_MANAGED\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_MFC_VER\s+", null) +
	All.FindByRegex(@"#\s*define\s+_MFC_VER\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_MSC_EXTENSIONS\s+", null) +
	All.FindByRegex(@"#\s*define\s+_MSC_EXTENSIONS\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_MSC_VER\s+", null) +
	All.FindByRegex(@"#\s*define\s+_MSC_VER\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__MSVC_RUNTIME_CHECKS\s+", null) +
	All.FindByRegex(@"#\s*define\s+__MSVC_RUNTIME_CHECKS\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_MT\s+", null) +
	All.FindByRegex(@"#\s*define\s+_MT\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_NATIVE_WCHAR_T_DEFINED\s+", null) +
	All.FindByRegex(@"#\s*define\s+_NATIVE_WCHAR_T_DEFINED\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_OPENMP\s+", null) +
	All.FindByRegex(@"#\s*define\s+_OPENMP\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_VC_NODEFAULTLIB\s+", null) +
	All.FindByRegex(@"#\s*define\s+_VC_NODEFAULTLIB\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_WCHAR_T_DEFINED\s+", null) +
	All.FindByRegex(@"#\s*define\s+_WCHAR_T_DEFINED\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_WIN32\s+", null) +
	All.FindByRegex(@"#\s*define\s+_WIN32\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_WIN64\s+", null) +
	All.FindByRegex(@"#\s*define\s+_WIN64\s+", null) +

	All.FindByRegex(@"#\s*undef\s+_Wp64\s+", null) +
	All.FindByRegex(@"#\s*define\s+_Wp64\s+", null) +

//Macros from http://gcc.gnu.org/onlinedocs/cpp/Standard-Predefined-Macros.html :		
	All.FindByRegex(@"#\s*undef\s+__STDC_VERSION__\s+", null) + 
	All.FindByRegex(@"#\s*define\s+__STDC_VERSION__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__STDC_HOSTED__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__STDC_HOSTED__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__OBJC__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__OBJC__\s+", null) +

	All.FindByRegex(@"#\s*undef\s+__ASSEMBLER__\s+", null) +
	All.FindByRegex(@"#\s*define\s+__ASSEMBLER__\s+", null);