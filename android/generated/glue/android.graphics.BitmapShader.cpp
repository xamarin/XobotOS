#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <BitmapGlue.h>
#include <ShaderGlue.h>


extern "C" DLL_EXPORT SkShader*
libxobotos_BitmapShader_BitmapShader_create(BitmapGlue* native_bitmap, int shaderTileModeX,
	int shaderTileModeY)
{
	SkShader* _retval = ShaderGlue::BitmapShader_create(*native_bitmap, (SkShader::TileMode)
		shaderTileModeX, (SkShader::TileMode)shaderTileModeY);
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_BitmapShader_BitmapShader_postCreate(SkShader* native_shader, BitmapGlue*
	 native_bitmap, int shaderTileModeX, int shaderTileModeY)
{
	const void* _retval = ShaderGlue::BitmapShader_postCreate(native_shader, *native_bitmap,
		(SkShader::TileMode)shaderTileModeX, (SkShader::TileMode)shaderTileModeY);
	return _retval;
}

