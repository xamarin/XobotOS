#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ColorFilterGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_ColorFilter_destructor(SkColorFilter* ptr)
{
	SkSafeUnref(ptr);
}


