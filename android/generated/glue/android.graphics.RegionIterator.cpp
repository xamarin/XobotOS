#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RegionGlue.h>
#include "android.graphics.Rect.h"

extern "C" DLL_EXPORT void
libxobotos_android_graphics_RegionIterator_destructor(RegionIteratorGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT RegionIteratorGlue*
libxobotos_RegionIterator_constructor(RegionGlue* native_region)
{
	RegionIteratorGlue* _retval = new RegionIteratorGlue(*native_region);
	return _retval;
}

extern "C" DLL_EXPORT bool
libxobotos_RegionIterator_next(RegionIteratorGlue* native_iter, Rect_Struct** r_ptr)
{
	SkIRect r;
	bool _retval = native_iter->next(&r);
	*r_ptr = Rect_Helper::unwrap(&r);
	return _retval;
}

