#ifndef DRAW_FILTER_GLUE_H
#define DRAW_FILTER_GLUE_H

#include <libxobotos.h>
#include <SkDrawFilter.h>
#include <SkPaintFlagsDrawFilter.h>
 
class DrawFilterGlue
{
public:
	static SkDrawFilter* PaintFlagsDrawFilter_create(int clearFlags, int setFlags);

private:
	DrawFilterGlue() { }
};

#endif
