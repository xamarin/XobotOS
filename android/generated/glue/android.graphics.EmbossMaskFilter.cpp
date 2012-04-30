#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <MaskFilterGlue.h>


extern "C" DLL_EXPORT SkMaskFilter*
libxobotos_EmbossMaskFilter_constructor(Array_float_Struct* direction_ptr, float 
	ambient, float specular, float blurRadius)
{
	const NativeArray<float>* direction = Array_float_Helper::wrapConst(direction_ptr);
	SkMaskFilter* _retval = MaskFilterGlue::Emboss_create(*direction, ambient, specular,
		blurRadius);
	delete direction;
	return _retval;
}

