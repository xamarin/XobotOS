#ifndef MATRIX_GLUE_H
#define MATRIX_GLUE_H

#include <libxobotos.h>
#include <SkMatrix.h>

class MatrixGlue : public SkMatrix
{
public:
	MatrixGlue(const MatrixGlue* src);
	void set(const MatrixGlue& src);
	bool mapRect(SkRect& dst, const SkRect& src);
	bool setPolyToPoly(const NativeArray<float>& src, int srcIndex, const NativeArray<float>& dst,
			   int dstIndex, int ptCount);
	void mapPoints(NativeArray<float>& dst, int dstIndex, const NativeArray<float>& src, int srcIndex,
		       int ptCount, bool isPts);
	void getValues(NativeArray<float>& dst);
	void setValues(const NativeArray<float>& src);
	static bool equals(const MatrixGlue& a, const MatrixGlue& b);
};

#endif
