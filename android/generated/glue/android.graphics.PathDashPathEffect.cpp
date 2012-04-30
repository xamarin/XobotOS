#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <Sk1DPathEffect.h>
#include <PathGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_PathDashPathEffect_destructor(SkPath1DPathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkPath1DPathEffect*
libxobotos_PathDashPathEffect_create(PathGlue* native_path, float advance, float 
	phase, int native_style)
{
	SkPath1DPathEffect* _retval = new SkPath1DPathEffect(*native_path, advance, phase,
		(SkPath1DPathEffect::Style)native_style);
	return _retval;
}

