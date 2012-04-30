#include <RasterizerGlue.h>

SkRasterizer*
RasterizerGlue::LayerRasterizer_create()
{
	return new SkLayerRasterizer();
}

void
RasterizerGlue::LayerRasterizer_addLayer(SkRasterizer* rasterizer, const PaintGlue& paint,
					 float dx, float dy)
{
	SkLayerRasterizer* layer = (SkLayerRasterizer*)rasterizer;
	layer->addLayer(paint, dx, dy);
}
