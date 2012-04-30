#include <RegionGlue.h>

#ifdef WINDOWS
// http://www.gamedev.net/topic/436496-mathh-round-and-windows-vs2005-pro/
inline float roundf(float x) { return (x-floor(x))>0.5 ? ceil(x) : floor(x); }
#endif

bool
RegionGlue::quickRejectRect(int left, int top, int right, int bottom)
{
	SkIRect rect = SkIRect::MakeLTRB(left, top, right, bottom);
	return SkRegion::quickReject(rect);
}

bool
RegionGlue::equals(const RegionGlue& other)
{
	return *this == other;
}

void
RegionGlue::set(const RegionGlue& src)
{
	*this = src;
}

bool
RegionGlue::getBounds(SkIRect& irect)
{
	irect = SkRegion::getBounds();
	return !isEmpty();
}

void
RegionGlue::translate(int x, int y, RegionGlue* dst)
{
	if (dst)
		SkRegion::translate(x, y, dst);
	else
		SkRegion::translate(x, y);
}

void
RegionGlue::scale_rect(SkIRect* dst, const SkIRect& src, float scale)
{
	dst->fLeft = (int)::roundf(src.fLeft * scale);
	dst->fTop = (int)::roundf(src.fTop * scale);
	dst->fRight = (int)::roundf(src.fRight * scale);
	dst->fBottom = (int)::roundf(src.fBottom * scale);
}

void
RegionGlue::scale_rgn(RegionGlue* dst, const RegionGlue& src, float scale)
{
	SkRegion tmp;
	SkRegion::Iterator iter(src);

	for (; !iter.done(); iter.next()) {
		SkIRect r;
		scale_rect(&r, iter.rect(), scale);
		tmp.op(r, SkRegion::kUnion_Op);
	}
	dst->swap(tmp);
}

void
RegionGlue::scale(float scale, RegionGlue* dst)
{
	if (dst)
		scale_rgn(dst,* this, scale);
	else
		scale_rgn(this,* this, scale);
}

RegionIteratorGlue::RegionIteratorGlue(const RegionGlue& orig_region)
	: region(orig_region)
{
	reset(region);
}

bool
RegionIteratorGlue::next(SkIRect* r)
{
	if (!done()) {
		*r = rect();
		SkRegion::Iterator::next();
		return true;
	}

	return false;
}
