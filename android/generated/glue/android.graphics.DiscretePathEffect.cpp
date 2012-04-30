#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <SkDiscretePathEffect.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_DiscretePathEffect_destructor(SkDiscretePathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkDiscretePathEffect*
libxobotos_DiscretePathEffect_create(float length, float deviation)
{
	SkDiscretePathEffect* _retval = new SkDiscretePathEffect(length, deviation);
	return _retval;
}

