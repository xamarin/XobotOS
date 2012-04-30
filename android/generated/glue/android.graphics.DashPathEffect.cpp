#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <PathEffectGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_DashPathEffect_destructor(SkDashPathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkDashPathEffect*
libxobotos_DashPathEffect_Dash_constructor(Array_float_Struct* intervals_ptr, float
	 phase)
{
	const NativeArray<float>* intervals = Array_float_Helper::wrapConst(intervals_ptr);
	SkDashPathEffect* _retval = PathEffectGlue::Dash_constructor(*intervals, phase);
	delete intervals;
	return _retval;
}

