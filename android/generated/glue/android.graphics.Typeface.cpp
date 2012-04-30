#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <TypefaceGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Typeface_destructor(SkTypeface* ptr)
{
	SkSafeUnref(ptr);
}


extern "C" DLL_EXPORT SkTypeface*
libxobotos_Typeface_createFromTypeface(SkTypeface* native_instance, int style)
{
	SkTypeface* _retval = SkTypeface::CreateFromTypeface(native_instance, (SkTypeface::Style)
		style);
	return _retval;
}

extern "C" DLL_EXPORT SkTypeface*
libxobotos_Typeface_createFromFile(String_Struct* path_ptr)
{
	const NativeString* path = String_Helper::wrapConst(path_ptr);
	SkTypeface* _retval = TypefaceGlue::createFromFile(*path);
	delete path;
	return _retval;
}

extern "C" DLL_EXPORT SkTypeface*
libxobotos_Typeface_createFromName(String_Struct* familyName_ptr, int style)
{
	const NativeString* familyName = String_Helper::wrapConst(familyName_ptr);
	SkTypeface* _retval = TypefaceGlue::createFromName(familyName, (SkTypeface::Style)
		style);
	delete familyName;
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Typeface_style(SkTypeface* native_instance)
{
	int _retval = native_instance->style();
	return _retval;
}

