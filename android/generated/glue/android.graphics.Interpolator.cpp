#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <InterpolatorGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Interpolator_destructor(InterpolatorGlue* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT InterpolatorGlue*
libxobotos_Interpolator_constructor(int valueCount, int frameCount)
{
	InterpolatorGlue* _retval = new InterpolatorGlue(valueCount, frameCount);
	return _retval;
}

extern "C" DLL_EXPORT int
libxobotos_Interpolator_timeToValues(InterpolatorGlue* native_instance, int msec,
	Array_float_Struct* values_ptr)
{
	NativeArray<float>* values = Array_float_Helper::wrap(values_ptr);
	int _retval = native_instance->timeToValues(msec, values);
	delete values;
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_Interpolator_setRepeatMirror(InterpolatorGlue* native_instance, float 
	repeatCount, bool mirror)
{
	native_instance->setRepeatMirror(repeatCount, mirror);
}

extern "C" DLL_EXPORT void
libxobotos_Interpolator_reset(InterpolatorGlue* native_instance, int valueCount, 
	int frameCount)
{
	native_instance->reset(valueCount, frameCount);
}

extern "C" DLL_EXPORT void
libxobotos_Interpolator_setKeyFrame(InterpolatorGlue* native_instance, int index,
	int msec, Array_float_Struct* values_ptr, Array_float_Struct* blend_ptr)
{
	const NativeArray<float>* values = Array_float_Helper::wrapConst(values_ptr);
	const NativeArray<float>* blend = Array_float_Helper::wrapConst(blend_ptr);
	native_instance->setKeyFrame(index, msec, *values, blend);
	delete values;
	delete blend;
}

