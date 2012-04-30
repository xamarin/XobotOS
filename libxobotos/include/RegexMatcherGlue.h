#ifndef REGEX_MATCHER_GLUE_H
#define REGEX_PATTERN_H

#include <RegexPatternGlue.h>

class RegexMatcherGlue
{
public:
	static RegexMatcher* open(const RegexPattern& pattern);
	static bool find(RegexMatcher& matcher, const NativeString* text, int start_idx,
			 NativeArray<int>* offsets);
	static int findNext(RegexMatcher& matcher, const NativeString* text,
			    NativeArray<int>* offsets);
	static int lookingAt(RegexMatcher& matcher, const NativeString* text,
			     NativeArray<int>* offsets);
	static int matches(RegexMatcher& matcher, const NativeString* text,
			   NativeArray<int>* offsets);
	static void setInput(RegexMatcher& matcher, const NativeString* text, int start, int end);

private:
	RegexMatcherGlue() { }
};

#endif
