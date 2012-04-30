#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <SkPathEffect.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_PathEffect_destructor(SkPathEffect* ptr)
{
	SkSafeUnref(ptr);
}


