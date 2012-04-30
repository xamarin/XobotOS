#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <RasterizerGlue.h>
#include <PaintGlue.h>


extern "C" DLL_EXPORT SkRasterizer*
libxobotos_LayerRasterizer_LayerRasterizer_create()
{
	SkRasterizer* _retval = RasterizerGlue::LayerRasterizer_create();
	return _retval;
}

extern "C" DLL_EXPORT void
libxobotos_LayerRasterizer_LayerRasterizer_addLayer(SkRasterizer* native_layer, PaintGlue*
	 native_paint, float dx, float dy)
{
	RasterizerGlue::LayerRasterizer_addLayer(native_layer, *native_paint, dx, dy);
}

