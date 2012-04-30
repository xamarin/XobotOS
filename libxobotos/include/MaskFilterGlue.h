#ifndef MASK_FILTER_GLUE_H
#define MASK_FILTER_GLUE_H

#include <libxobotos.h>
#include <SkMaskFilter.h>
#include <SkBlurMaskFilter.h>
#include <SkTableMaskFilter.h>
 
class MaskFilterGlue
{
public:
	static SkMaskFilter* Table_create(const NativeArray<uint8_t>& table);
	static SkMaskFilter* Table_createClip(int min, int max);
	static SkMaskFilter* Table_createGamma(float gamma);

	static SkMaskFilter* Emboss_create(const NativeArray<float>& direction,
					   float ambient, float specular, float blurRadius);

private:
	MaskFilterGlue() { }
};

#endif
