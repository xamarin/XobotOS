#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <DrawFilterGlue.h>


extern "C" DLL_EXPORT SkDrawFilter*
libxobotos_PaintFlagsDrawFilter_PaintFlagsDrawFilter_create(int clearBits, int setBits)
{
	SkDrawFilter* _retval = DrawFilterGlue::PaintFlagsDrawFilter_create(clearBits, setBits);
	return _retval;
}

