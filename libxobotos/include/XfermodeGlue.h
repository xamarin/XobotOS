#ifndef XFERMODE_GLUE_H
#define XFERMODE_GLUE_H

#include <libxobotos.h>
#include <SkXfermode.h>
#include <SkAvoidXfermode.h>
#include <SkPixelXorXfermode.h>
#include <SkPorterDuff.h>

class XfermodeGlue
{
public:
	static SkXfermode* Avoid_create(SkColor color, int tolerance, SkAvoidXfermode::Mode mode);
	static SkXfermode* PixelXor_create(SkColor color);
	static SkXfermode* PorterDuff_create(SkPorterDuff::Mode mode);

private:
	XfermodeGlue() { }
};

#endif
