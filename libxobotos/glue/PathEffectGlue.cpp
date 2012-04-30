#include <PathEffectGlue.h>
#include <SkTemplates.h>

SkDashPathEffect*
PathEffectGlue::Dash_constructor(const NativeArray<float>& interval, float phase)
{
	int count = interval.length() & ~1;  // even number

	return new SkDashPathEffect(interval.ptr(0,count), count, SkFloatToScalar(phase));
}

