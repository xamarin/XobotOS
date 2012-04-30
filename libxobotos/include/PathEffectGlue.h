#ifndef PATH_EFFECT_GLUE_H
#define PATH_EFFECT_GLUE_H

#include <libxobotos.h>
#include <SkDashPathEffect.h>
 
class PathEffectGlue
{
public:
	static SkDashPathEffect* Dash_constructor(const NativeArray<float>& interval, float phase);

private:
	PathEffectGlue() { }
};

#endif
