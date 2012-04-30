#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <XfermodeGlue.h>


extern "C" DLL_EXPORT SkXfermode*
libxobotos_AvoidXfermode_Avoid_create(int opColor, int tolerance, int nativeMode)
{
	SkXfermode* _retval = XfermodeGlue::Avoid_create((SkColor)opColor, tolerance, (SkAvoidXfermode::Mode)
		nativeMode);
	return _retval;
}

