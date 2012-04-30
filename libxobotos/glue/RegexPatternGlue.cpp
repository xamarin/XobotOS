#include <RegexPatternGlue.h>

RegexPattern*
RegexPatternGlue::compile(const NativeString& regex, int flags)
{
	flags |= UREGEX_ERROR_ON_UNKNOWN_ESCAPES;

	UErrorCode status = U_ZERO_ERROR;
	UParseError error;
	error.offset = -1;

	UnicodeString regexString;
	regexString.setTo(false, regex.ptr(0, regex.length()), regex.length());

	RegexPattern* result = RegexPattern::compile(regexString, flags, error, status);
	if (!U_SUCCESS(status))
		return NULL;

	return result;
}
