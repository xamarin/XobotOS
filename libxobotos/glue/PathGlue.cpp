#include <PathGlue.h>

void
PathGlue::set(const PathGlue& src)
{
	*this = src;
}

void
PathGlue::getBounds(SkRect* rect)
{
	*rect = SkPath::getBounds();
}

void
PathGlue::addRoundRect(const SkRect& rect, float rx, float ry, SkPath::Direction dir)
{
	SkPath::addRoundRect(rect, rx, ry, dir);
}

void
PathGlue::addRoundRect(const SkRect& rect, const NativeArray<float>& radii, SkPath::Direction dir)
{
	SkPath::addRoundRect(rect, radii.ptr(0,8), dir);
}
