#ifndef PICTURE_GLUE_H
#define PICTURE_GLUE_H

#include <libxobotos.h>
#include <SkPicture.h>
 
class PictureGlue : public SkPicture
{
public:
	static PictureGlue* create(const PictureGlue* src);
	static void draw(SkCanvas* canvas, PictureGlue* picture);
	SkCanvas* beginRecording(int width, int height);

private:
	PictureGlue() : SkPicture() { }
	PictureGlue(const PictureGlue& src) : SkPicture(src) { }
};

#endif
