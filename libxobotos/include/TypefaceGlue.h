#ifndef TYPEFACE_GLUE_H
#define TYEPFACE_GLUE_H

#include <libxobotos.h>
#include <SkTypeface.h>
 
class TypefaceGlue
{
public:
	static SkTypeface* createFromFile(const NativeString& path);
	static SkTypeface* createFromName(const NativeString* familyName, SkTypeface::Style stype);

private:
	TypefaceGlue() { }
};

#endif
