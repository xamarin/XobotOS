#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <ShaderGlue.h>
#include <MatrixGlue.h>

extern "C" DLL_EXPORT void
libxobotos_android_graphics_Shader_destructor(SkShader* ptr)
{
	SkSafeUnref(ptr);
}


extern "C" DLL_EXPORT void
libxobotos_Shader_setLocalMatrix(SkShader* native_shader, MatrixGlue* matrix_instance)
{
	ShaderGlue::setLocalMatrix(native_shader, matrix_instance);
}

