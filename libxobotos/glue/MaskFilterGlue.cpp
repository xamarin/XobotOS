#include <MaskFilterGlue.h>

SkMaskFilter*
MaskFilterGlue::Table_create(const NativeArray<uint8_t>& table)
{
	SkASSERT(table.length() >= 256);
	return new SkTableMaskFilter(table.ptr(0,256));
}

SkMaskFilter*
MaskFilterGlue::Table_createClip(int min, int max)
{
	return SkTableMaskFilter::CreateClip(min, max);
}

SkMaskFilter*
MaskFilterGlue::Table_createGamma(float gamma)
{
	return SkTableMaskFilter::CreateGamma(gamma);
}

SkMaskFilter*
MaskFilterGlue::Emboss_create(const NativeArray<float>& direction, float ambient,
			      float specular, float blurRadius)
{
	return SkBlurMaskFilter::CreateEmboss(direction.ptr(0,3), ambient, specular, blurRadius);
}

