#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RegexMatcherGlue.h>
#include <RegexPatternGlue.h>

extern "C" DLL_EXPORT void
libxobotos_java_util_regex_Matcher_destructor(icu_46::RegexMatcher* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT bool
libxobotos_Matcher_find(icu_46::RegexMatcher* addr, String_Struct* s_ptr, int startIndex,
	Array_int_Struct* offsets_ptr)
{
	const NativeString* s = String_Helper::wrapConst(s_ptr);
	NativeArray<int>* offsets = Array_int_Helper::wrap(offsets_ptr);
	bool _retval = RegexMatcherGlue::find(*addr, s, startIndex, offsets);
	delete s;
	delete offsets;
	return _retval;
}

extern "C" DLL_EXPORT icu_46::RegexMatcher*
libxobotos_Matcher_open(icu_46::RegexPattern* patternAddr)
{
	icu_46::RegexMatcher* _retval = RegexMatcherGlue::open(*patternAddr);
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matcher_useTransparentBounds(icu_46::RegexMatcher* addr, bool value)
{
	addr->useTransparentBounds(value);
}

extern "C" DLL_EXPORT void
libxobotos_Matcher_useAnchoringBounds(icu_46::RegexMatcher* addr, bool value)
{
	addr->useAnchoringBounds(value);
}

extern "C" DLL_EXPORT int
libxobotos_Matcher_groupCount(icu_46::RegexMatcher* addr)
{
	int _retval = addr->groupCount();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matcher_requireEnd(icu_46::RegexMatcher* addr)
{
	bool _retval = addr->requireEnd();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matcher_lookingAt(icu_46::RegexMatcher* addr, String_Struct* s_ptr, Array_int_Struct*
	 offsets_ptr)
{
	const NativeString* s = String_Helper::wrapConst(s_ptr);
	NativeArray<int>* offsets = Array_int_Helper::wrap(offsets_ptr);
	bool _retval = RegexMatcherGlue::lookingAt(*addr, s, offsets);
	delete s;
	delete offsets;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Matcher_setInput(icu_46::RegexMatcher* addr, String_Struct* s_ptr, int
	 start, int end)
{
	const NativeString* s = String_Helper::wrapConst(s_ptr);
	RegexMatcherGlue::setInput(*addr, s, start, end);
	delete s;
}

extern "C" DLL_EXPORT bool
libxobotos_Matcher_matches(icu_46::RegexMatcher* addr, String_Struct* s_ptr, Array_int_Struct*
	 offsets_ptr)
{
	const NativeString* s = String_Helper::wrapConst(s_ptr);
	NativeArray<int>* offsets = Array_int_Helper::wrap(offsets_ptr);
	bool _retval = RegexMatcherGlue::matches(*addr, s, offsets);
	delete s;
	delete offsets;
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matcher_hitEnd(icu_46::RegexMatcher* addr)
{
	bool _retval = addr->hitEnd();
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_Matcher_findNext(icu_46::RegexMatcher* addr, String_Struct* s_ptr, Array_int_Struct*
	 offsets_ptr)
{
	const NativeString* s = String_Helper::wrapConst(s_ptr);
	NativeArray<int>* offsets = Array_int_Helper::wrap(offsets_ptr);
	bool _retval = RegexMatcherGlue::findNext(*addr, s, offsets);
	delete s;
	delete offsets;
	return _retval;
}

