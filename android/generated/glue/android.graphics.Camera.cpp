#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <CanvasGlue.h>


extern "C" DLL_EXPORT void
libxobotos_Camera_nativeApplyToCanvas(SkCanvas* native_canvas)
{
	native_canvas->nativeApplyToCanvas();
}

