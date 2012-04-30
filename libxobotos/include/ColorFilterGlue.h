#ifndef COLOR_FILTER_GLUE_H
#define COLOR_FILTER_GLUE_H

#include <libxobotos.h>
#include <SkColorFilter.h>
#include <SkColorMatrixFilter.h>
#include <SkPorterDuff.h>
 
class ColorFilterGlue
{
public:
	static SkColorFilter* ColorMatrixFilter_create(const NativeArray<float>& array);
	static void* ColorMatrixFilter_postCreate(SkColorFilter* filter, const NativeArray<float>& array);

	static SkColorFilter* LightingFilter_create(int mul, int add);
	static void* LightingFilter_postCreate(SkColorFilter* filter, int mul, int add);

	static SkColorFilter* PorterDuffFilter_create(int srcColor, SkPorterDuff::Mode mode);
	static void* PorterDuffFilter_postCreate(SkColorFilter* filter, int srcColor,
						 SkPorterDuff::Mode mode);

private:
	ColorFilterGlue() { }
};

#endif
