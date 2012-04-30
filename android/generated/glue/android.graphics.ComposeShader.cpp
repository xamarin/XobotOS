#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>
#include <XfermodeGlue.h>


extern "C" DLL_EXPORT const void*
libxobotos_ComposeShader_ComposeShader_postCreate(SkShader* native_shader, const void*
	 native_skiaShaderA, const void* native_skiaShaderB, SkXfermode* native_mode)
{
	const void* _retval = ShaderGlue::ComposeShader_postCreate(native_shader, native_skiaShaderA,
		native_skiaShaderB, native_mode);
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_ComposeShader_ComposeShader_create_0(SkShader* native_shaderA, SkShader*
	 native_shaderB, int porterDuffMode)
{
	SkShader* _retval = ShaderGlue::ComposeShader_create(native_shaderA, native_shaderB,
		(SkPorterDuff::Mode)porterDuffMode);
	return _retval;
}

extern "C" DLL_EXPORT const void*
libxobotos_ComposeShader_ComposeShader_postCreate_0(SkShader* native_shader, const void*
	 native_skiaShaderA, const void* native_skiaShaderB, int porterDuffMode)
{
	const void* _retval = ShaderGlue::ComposeShader_postCreate(native_shader, native_skiaShaderA,
		native_skiaShaderB, (SkPorterDuff::Mode)porterDuffMode);
	return _retval;
}

extern "C" DLL_EXPORT SkShader*
libxobotos_ComposeShader_ComposeShader_create(SkShader* native_shaderA, SkShader*
	 native_shaderB, SkXfermode* native_mode)
{
	SkShader* _retval = ShaderGlue::ComposeShader_create(native_shaderA, native_shaderB,
		native_mode);
	return _retval;
}

