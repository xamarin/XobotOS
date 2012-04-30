#ifndef INTERPOLATOR_GLUE_H
#define INTERPOLATOR_GLUE_H

#include <libxobotos.h>
#include <SkInterpolator.h>
 
class InterpolatorGlue : public SkInterpolator
{
public:
	InterpolatorGlue(int value_count, int frame_count);
	void setKeyFrame(int index, int msec, const NativeArray<float>& valueArray,
			 const NativeArray<float>* blendArray);
	void setRepeatMirror(float repeat_count, bool mirror);
	int timeToValues(int msec, NativeArray<float>* values);
};

#endif
