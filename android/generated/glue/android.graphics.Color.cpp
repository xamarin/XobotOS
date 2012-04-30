#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>


extern "C" DLL_EXPORT void
libxobotos_Color_Color_RGBToHSV(int red, int greed, int blue, Array_float_Struct*
	 hsv_ptr)
{
	NativeArray<float>* hsv = Array_float_Helper::wrap(hsv_ptr);
	ShaderGlue::Color_RGBToHSV(red, greed, blue, *hsv);
	delete hsv;
}

extern "C" DLL_EXPORT int
libxobotos_Color_Color_HSVToColor(int alpha, Array_float_Struct* hsv_ptr)
{
	const NativeArray<float>* hsv = Array_float_Helper::wrapConst(hsv_ptr);
	int _retval = ShaderGlue::Color_HSVToColor(alpha, *hsv);
	delete hsv;
	return _retval;
}

