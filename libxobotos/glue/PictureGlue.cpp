#include <PictureGlue.h>

PictureGlue*
PictureGlue::create(const PictureGlue* src)
{
	if (src)
		return new PictureGlue(*src);
	else
		return new PictureGlue;
}

void
PictureGlue::draw(SkCanvas* canvas, PictureGlue* picture)
{
	((SkPicture*)picture)->draw(canvas);
}

SkCanvas*
PictureGlue::beginRecording(int width, int height)
{
	SkCanvas* canvas = SkPicture::beginRecording(width, height);
	if (canvas)
		canvas->ref();
	return canvas;
}
