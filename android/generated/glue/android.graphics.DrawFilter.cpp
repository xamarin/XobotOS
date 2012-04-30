#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <DrawFilterGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_DrawFilter_destructor(SkDrawFilter* ptr)
{
	SkSafeUnref(ptr);
}


