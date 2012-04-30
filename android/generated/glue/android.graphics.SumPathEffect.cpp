#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <SkPathEffect.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_SumPathEffect_destructor(SkSumPathEffect* ptr)
{
	delete ptr;
}


extern "C" DLL_EXPORT SkSumPathEffect*
libxobotos_SumPathEffect_create(SkPathEffect* first, SkPathEffect* second)
{
	SkSumPathEffect* _retval = new SkSumPathEffect(first, second);
	return _retval;
}

