#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>


extern "C" DLL_EXPORT const void*
libxobotos_SweepGradient_SweepGradient_postCreate_0(SkShader* native_shader, float
	 cx, float cy, int color0, int color1)
{
	const void* _retval = ShaderGlue::SweepGradient_postCreate(native_shader, cx, cy,
		color0, color1);
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_SweepGradient_SweepGradient_create_0(float x, float y, int color0, int
	 color1)
{
	SkShader* _retval = ShaderGlue::SweepGradient_create(x, y, color0, color1);
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_SweepGradient_SweepGradient_create(float x, float y, Array_int_Struct*
	 colors_ptr, Array_float_Struct* positions_ptr)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	SkShader* _retval = ShaderGlue::SweepGradient_create(x, y, *colors, positions);
	delete colors;
	delete positions;
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_SweepGradient_SweepGradient_postCreate(SkShader* native_shader, float 
	cx, float cy, Array_int_Struct* colors_ptr, Array_float_Struct* positions_ptr)
{
	const NativeArray<int>* colors = Array_int_Helper::wrapConst(colors_ptr);
	const NativeArray<float>* positions = Array_float_Helper::wrapConst(positions_ptr);
	const void* _retval = ShaderGlue::SweepGradient_postCreate(native_shader, cx, cy,
		*colors, positions);
	delete colors;
	delete positions;
	return _retval;
}

