#ifndef REGEX_PATTERN_GLUE_H
#define REGEX_PATTERN_GLUE_H

#include <libxobotos.h>
#include <unicode/parseerr.h>
#include <unicode/regex.h>

class RegexPatternGlue
{
public:
	static RegexPattern* compile(const NativeString& regex, int flags);

private:
	RegexPatternGlue() { }
};

#endif
