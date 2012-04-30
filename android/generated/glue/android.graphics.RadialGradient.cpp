#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>


extern "C" DLL_EXPORT SkShader*
libxobotos_RadialGradient_RadialGradient_create_0(float x, float y, float radius,
	int color0, int color1, int tileMode)
{
	SkShader* _retval = ShaderGlue::RadialGradient_create(x, y, radius, color0, color1,
		(SkShader::TileMode)tileMode);
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_RadialGradient_RadialGradient_postCreate(SkShader* native_shader, float
	 x, float y, float radius, Array_int_Struct* colors_ptr, Array_float_Struct* positions_ptr,
	int tileMode)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	const void* _retval = ShaderGlue::RadialGradient_postCreate(native_shader, x, y, 
		radius, *colors, positions, (SkShader::TileMode)tileMode);
	delete colors;
	delete positions;
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_RadialGradient_RadialGradient_create(float x, float y, float radius, Array_int_Struct*
	 colors_ptr, Array_float_Struct* positions_ptr, int tileMode)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	SkShader* _retval = ShaderGlue::RadialGradient_create(x, y, radius, *colors, positions,
		(SkShader::TileMode)tileMode);
	delete colors;
	delete positions;
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_RadialGradient_RadialGradient_postCreate_0(SkShader* native_shader, float
	 x, float y, float radius, int color0, int color1, int tileMode)
{
	const void* _retval = ShaderGlue::RadialGradient_postCreate(native_shader, x, y, 
		radius, color0, color1, (SkShader::TileMode)tileMode);
	return _retval;
}

