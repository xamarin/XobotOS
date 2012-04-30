#include <TypefaceGlue.h>

SkTypeface*
TypefaceGlue::createFromFile(const NativeString& path)
{
	return SkTypeface::CreateFromFile(android::String8(path));
}

SkTypeface*
TypefaceGlue::createFromName(const NativeString* familyName, SkTypeface::Style style)
{
	return SkTypeface::CreateFromName(familyName ? android::String8(*familyName).string() : NULL, style);
}
