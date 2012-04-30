#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <XfermodeGlue.h>


extern "C" DLL_EXPORT SkXfermode*
libxobotos_PorterDuffXfermode_PorterDuff_create(int mode)
{
	SkXfermode* _retval = XfermodeGlue::PorterDuff_create((SkPorterDuff::Mode)mode);
	return _retval;
}

