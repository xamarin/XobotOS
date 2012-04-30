#include <XfermodeGlue.h>

SkXfermode*
XfermodeGlue::Avoid_create(SkColor color, int tolerance, SkAvoidXfermode::Mode mode)
{
	return new SkAvoidXfermode(color, tolerance, mode);
}

SkXfermode*
XfermodeGlue::PixelXor_create(SkColor color)
{
        return new SkPixelXorXfermode(color);
}

SkXfermode*
XfermodeGlue::PorterDuff_create(SkPorterDuff::Mode mode)
{
        return SkPorterDuff::CreateXfermode(mode);
}
