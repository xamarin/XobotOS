#include <ColorFilterGlue.h>
#include <SkTemplates.h>

SkColorFilter*
ColorFilterGlue::ColorMatrixFilter_create(const NativeArray<float>& array)
{
	SkASSERT(array.length() >= 20);
        return new SkColorMatrixFilter(array.ptr(0,20));
}

void*
ColorFilterGlue::ColorMatrixFilter_postCreate(SkColorFilter* filter, const NativeArray<float>& array)
{
	return NULL;
}

SkColorFilter*
ColorFilterGlue::LightingFilter_create(int mul, int add)
{
        return SkColorFilter::CreateLightingFilter(mul, add);
}

void*
ColorFilterGlue::LightingFilter_postCreate(SkColorFilter* filter, int mul, int add)
{
        return NULL;
}

SkColorFilter*
ColorFilterGlue::PorterDuffFilter_create(int srcColor, SkPorterDuff::Mode mode)
{
        return SkColorFilter::CreateModeFilter(srcColor, SkPorterDuff::ToXfermodeMode(mode));
}

void*
ColorFilterGlue::PorterDuffFilter_postCreate(SkColorFilter* filter, int srcColor, SkPorterDuff::Mode mode)
{
        return NULL;
}
