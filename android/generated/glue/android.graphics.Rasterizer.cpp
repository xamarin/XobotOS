#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RasterizerGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Rasterizer_destructor(SkRasterizer* ptr)
{
	SkSafeUnref(ptr);
}


