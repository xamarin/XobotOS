#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <XfermodeGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Xfermode_destructor(SkXfermode* ptr)
{
	SkSafeUnref(ptr);
}


