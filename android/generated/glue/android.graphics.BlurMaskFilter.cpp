#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MaskFilterGlue.h>


extern "C" DLL_EXPORT SkMaskFilter*
libxobotos_BlurMaskFilter_constructor(float radius, int style)
{
	SkMaskFilter* _retval = SkBlurMaskFilter::Create(radius, (SkBlurMaskFilter::BlurStyle)
		style);
	return _retval;
}

