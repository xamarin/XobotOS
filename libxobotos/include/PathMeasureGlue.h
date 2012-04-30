#ifndef PATH_MEASURE_GLUE_H
#define PATH_MEASURE_GLUE_H

#include <libxobotos.h>
#include <PathGlue.h>
#include <SkPathMeasure.h>
 
/*  We declare an explicit pair, so that we don't have to rely on the java
    client to be sure not to edit the path while we have an active measure
    object associated with it.
 
    This costs us the copy of the path, for the sake of not allowing a bad
    java client to randomly crash (since we can't detect the case where the
    native path has been modified).
 
    The C side does have this risk, but it chooses for speed over safety. If it
    later changes this, and is internally safe from changes to the path, then
    we can remove this explicit copy from our JNI code.
 
    Note that we do not have a reference on the java side to the java path.
    Were we to not need the native copy here, we would want to add a java
    reference, so that the java path would not get GD'd while the measure object
    was still alive.
*/
class PathMeasureGlue : public SkPathMeasure
{
public:
	static PathMeasureGlue* create(const PathGlue* path, bool forceClosed);
	void setPath(const PathGlue* path, bool forceClosed);
	bool getPosTan(float dist, NativeArray<float>* posArray, NativeArray<float>* tanArray);

private:
	PathMeasureGlue() { };
	SkPath fPath;
};

#endif
