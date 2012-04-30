#ifndef SHADER_GLUE_H
#define SHADER_GLUE_H

#include <libxobotos.h>
#include <BitmapGlue.h>
#include <MatrixGlue.h>
#include <SkShader.h>
#include <SkComposeShader.h>
#include <SkPorterDuff.h>
 
class ShaderGlue
{
public:
	static void setLocalMatrix(SkShader* shader, const MatrixGlue* matrix);
	static SkShader* BitmapShader_create(const BitmapGlue& bitmap,
					     SkShader::TileMode tileModeX, SkShader::TileMode tileModeY);
	static void* BitmapShader_postCreate(SkShader* shader, const SkBitmap& bitmap,
					     SkShader::TileMode tileModeX, SkShader::TileMode tileModeY);

	static SkShader* ComposeShader_create(SkShader* shaderA, SkShader* shaderB,
					      SkXfermode* mode);
	static SkShader* ComposeShader_create(SkShader* shaderA, SkShader* shaderB,
					      SkPorterDuff::Mode porterDuffMode);

	static const void* ComposeShader_postCreate(SkShader* shader, const void* shaderA, const void* shaderB,
						    SkXfermode* mode);
	static const void* ComposeShader_postCreate(SkShader* shader, const void* shaderA, const void* shaderB,
						    SkPorterDuff::Mode porterDuffMode);

	static SkShader* LinearGradient_create(float x0, float y0, float x1, float y1, const NativeArray<int>& color,
					       const NativeArray<float>* pos, SkShader::TileMode tileMode);
	static SkShader* LinearGradient_create(float x0, float y0, float x1, float y1,
					       int color0, int color1, SkShader::TileMode tileMode);

	static const void* LinearGradient_postCreate(SkShader* shader, float x0, float y0, float x1, float y1,
						     const NativeArray<int>& colorArray, const NativeArray<float>* posArray,
						     SkShader::TileMode tileMode);
	static const void* LinearGradient_postCreate(SkShader* shader, float x0, float y0, float x1, float y1,
						     int color0, int color1, SkShader::TileMode tileMode);

	static SkShader* RadialGradient_create(float x, float y, float radius, const NativeArray<int>& colorArray,
					       const NativeArray<float>* posArray, SkShader::TileMode tileMode);
	static SkShader* RadialGradient_create(float x, float y, float radius, int color0, int color1,
					       SkShader::TileMode tileMode);

	static const void* RadialGradient_postCreate(SkShader* shader, float x, float y, float radius,
						     const NativeArray<int>& colorArray, const NativeArray<float>* posArray,
						     SkShader::TileMode tileMode);
	static const void* RadialGradient_postCreate(SkShader* shader, float x, float y, float radius,
						     int color0, int color1, SkShader::TileMode tileMode);

	static SkShader* SweepGradient_create(float x, float y, const NativeArray<int>& colorArray,
					      const NativeArray<float>* positions);
	static SkShader* SweepGradient_create(float x, float y, int color0, int color1);

	static const void* SweepGradient_postCreate(SkShader* shader, float x, float y, const NativeArray<int>& colorArray,
						    const NativeArray<float>* positions);
	static const void* SweepGradient_postCreate(SkShader* shader, float x, float y, int color0, int color1);

	static void Color_RGBToHSV(int red, int green, int blue, NativeArray<float>& hsvArray);
	static int Color_HSVToColor(int alpha, const NativeArray<float>& hsvArray);

private:
	ShaderGlue() { }
};

#endif
