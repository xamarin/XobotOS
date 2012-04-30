#ifndef RASTERIZER_GLUE_H
#define RASTERIZER_GLUE_H

#include <libxobotos.h>
#include <PaintGlue.h>
#include <SkRasterizer.h>
#include <SkLayerRasterizer.h>
 
class RasterizerGlue
{
public:
	static SkRasterizer* LayerRasterizer_create();
	static void LayerRasterizer_addLayer(SkRasterizer* rasterizer, const PaintGlue& paint,
					     float dx, float dy);

private:
	RasterizerGlue() { }
};

#endif
