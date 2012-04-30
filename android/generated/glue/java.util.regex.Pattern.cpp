#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RegexPatternGlue.h>

extern "C" DLL_EXPORT void
libxobotos_java_util_regex_Pattern_destructor(icu_46::RegexPattern* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT icu_46::RegexPattern*
libxobotos_Pattern_compile(String_Struct* regex_ptr, int flags)
{
	const NativeString* regex = String_Helper::wrapConst(regex_ptr);
	icu_46::RegexPattern* _retval = RegexPatternGlue::compile(*regex, flags);
	delete regex;
	return _retval;
}

