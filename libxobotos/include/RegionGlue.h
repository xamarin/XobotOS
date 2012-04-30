#ifndef REGION_GLUE_H
#define REGION_GLUE_H

#include <libxobotos.h>
#include <SkRegion.h>
#include <SkRect.h>
 
class RegionGlue : public SkRegion
{
public:
	bool quickRejectRect(int left, int top, int right, int bottom);
	bool equals(const RegionGlue& other);
	void set(const RegionGlue& src);
	bool getBounds(SkIRect& irect);
	void translate(int x, int y, RegionGlue* dst);
	void scale(float scale, RegionGlue* dst);

private:
	static void scale_rect(SkIRect* dst, const SkIRect& src, float scale);
	static void scale_rgn(RegionGlue* dst, const RegionGlue& src, float scale);
};

class RegionIteratorGlue : public SkRegion::Iterator
{
public:
	RegionIteratorGlue(const RegionGlue& region);
	bool next(SkIRect* r);
private:
	RegionGlue region;
};

#endif
