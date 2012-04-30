#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <XfermodeGlue.h>


extern "C" DLL_EXPORT SkXfermode*
libxobotos_PixelXorXfermode_PixelXor_create(int opColor)
{
	SkXfermode* _retval = XfermodeGlue::PixelXor_create((SkColor)opColor);
	return _retval;
}

