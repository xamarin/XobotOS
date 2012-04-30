#ifndef PATH_GLUE_H
#define PATH_GLUE_H

#include <libxobotos.h>
#include <SkPath.h>
 
class PathGlue : public SkPath
{
public:
	void set(const PathGlue& src);
	void getBounds(SkRect* rect);
	void addRoundRect(const SkRect& rect, float rx, float ry, SkPath::Direction dir);
	void addRoundRect(const SkRect& rect, const NativeArray<float>& radii, SkPath::Direction dir);
};

#endif
