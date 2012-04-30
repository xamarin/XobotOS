#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <SkCornerPathEffect.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_CornerPathEffect_destructor(SkCornerPathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkCornerPathEffect*
libxobotos_CornerPathEffect_create(float radius)
{
	SkCornerPathEffect* _retval = new SkCornerPathEffect(radius);
	return _retval;
}

