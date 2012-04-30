#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>


extern "C" DLL_EXPORT const void*
libxobotos_LinearGradient_LinearGradient_postCreate(SkShader* native_shader, float
	 x0, float y0, float x1, float y1, Array_int_Struct* colors_ptr, Array_float_Struct*
	 positions_ptr, int tileMode)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	const void* _retval = ShaderGlue::LinearGradient_postCreate(native_shader, x0, y0,
		x1, y1, *colors, positions, (SkShader::TileMode)tileMode);
	delete colors;
	delete positions;
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_LinearGradient_LinearGradient_create(float x0, float y0, float x1, float
	 y1, Array_int_Struct* colors_ptr, Array_float_Struct* positions_ptr, int tileMode)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	SkShader* _retval = ShaderGlue::LinearGradient_create(x0, y0, x1, y1, *colors, positions,
		(SkShader::TileMode)tileMode);
	delete colors;
	delete positions;
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_LinearGradient_LinearGradient_postCreate_0(SkShader* native_shader, float
	 x0, float y0, float x1, float y1, int color0, int color1, int tileMode)
{
	const void* _retval = ShaderGlue::LinearGradient_postCreate(native_shader, x0, y0,
		x1, y1, color0, color1, (SkShader::TileMode)tileMode);
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_LinearGradient_LinearGradient_create_0(float x0, float y0, float x1, float
	 y1, int color0, int color1, int tileMode)
{
	SkShader* _retval = ShaderGlue::LinearGradient_create(x0, y0, x1, y1, color0, color1,
		(SkShader::TileMode)tileMode);
	return _retval;
}

