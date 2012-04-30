#include <PathMeasureGlue.h>

PathMeasureGlue*
PathMeasureGlue::create(const PathGlue* path, bool forceClosed)
{
	PathMeasureGlue* glue = new PathMeasureGlue;
	glue->setPath(path, forceClosed);
	return glue;
}

void
PathMeasureGlue::setPath(const PathGlue* path, bool forceClosed)
{
        if (path)
		fPath = *path;
	else
		fPath.reset();
	SkPathMeasure::setPath(&fPath, forceClosed);
}
 
bool
PathMeasureGlue::getPosTan(float dist, NativeArray<float>* posArray, NativeArray<float>* tanArray)
{
	SkPoint pos;
	SkVector tan;

        if (!SkPathMeasure::getPosTan(dist, &pos, &tan))
		return false;
    
        if (posArray) {
		posArray->item(0) = pos.fX;
		posArray->item(1) = pos.fY;
	}
        if (tanArray) {
		tanArray->item(0) = tan.fX;
		tanArray->item(1) = tan.fY;
	}
        return true;
}
