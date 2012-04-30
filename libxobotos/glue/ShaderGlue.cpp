#include <ShaderGlue.h>
#include <SkGradientShader.h>
#include <SkTemplates.h>

void
ShaderGlue::setLocalMatrix(SkShader* shader, const MatrixGlue* matrix)
{
	if (!shader)
		return;

	if (matrix)
		shader->setLocalMatrix(*matrix);
	else
		shader->resetLocalMatrix();
}

SkShader*
ShaderGlue::BitmapShader_create(const BitmapGlue& bitmap,
				SkShader::TileMode tileModeX, SkShader::TileMode tileModeY)
{
	return SkShader::CreateBitmapShader(bitmap, tileModeX, tileModeY);
}

void*
ShaderGlue::BitmapShader_postCreate(SkShader* shader, const SkBitmap& bitmap,
				    SkShader::TileMode tileModeX, SkShader::TileMode tileModeY)
{
	return NULL;
}

SkShader*
ShaderGlue::ComposeShader_create(SkShader* shaderA, SkShader* shaderB, SkXfermode* mode)
{
	return new SkComposeShader(shaderA, shaderB, mode);
}

SkShader*
ShaderGlue::ComposeShader_create(SkShader* shaderA, SkShader* shaderB,
				 SkPorterDuff::Mode porterDuffMode)
{
	SkAutoUnref au(SkPorterDuff::CreateXfermode(porterDuffMode));
	SkXfermode* mode = (SkXfermode*) au.get();
	return new SkComposeShader(shaderA, shaderB, mode);
}

const void*
ShaderGlue::ComposeShader_postCreate(SkShader* shader, const void* shaderA, const void* shaderB,
				     SkXfermode* mode)
{
	return NULL;
}

const void*
ShaderGlue::ComposeShader_postCreate(SkShader* shader, const void* shaderA, const void* shaderB,
				     SkPorterDuff::Mode porterDuffMode)
{
	return NULL;
}

SkShader*
ShaderGlue::LinearGradient_create(float x0, float y0, float x1, float y1, const NativeArray<int>& colorArray,
				  const NativeArray<float>* posArray, SkShader::TileMode tileMode)
{
	SkPoint pts[2];
	pts[0].set(x0, y0);
	pts[1].set(x1, y1);

	return SkGradientShader::CreateLinear(pts,
					      reinterpret_cast<const SkColor*>(colorArray.ptr(0,colorArray.length())),
					      posArray ? posArray->ptr(0, colorArray.length()) : NULL, colorArray.length(),
					      tileMode);
}

SkShader*
ShaderGlue::LinearGradient_create(float x0, float y0, float x1, float y1,
				  int color0, int color1, SkShader::TileMode tileMode)
{
	SkPoint pts[2];
	pts[0].set(x0, y0);
	pts[1].set(x1, y1);

	SkColor colors[2];
	colors[0] = color0;
	colors[1] = color1;

	return SkGradientShader::CreateLinear(pts, colors, NULL, 2, tileMode);
}

const void*
ShaderGlue::LinearGradient_postCreate(SkShader* shader, float x0, float y0, float x1, float y1,
				      const NativeArray<int>& colorArray, const NativeArray<float>* posArray, 
				      SkShader::TileMode tileMode)
{
	return NULL;
}

const void*
ShaderGlue::LinearGradient_postCreate(SkShader* shader, float x0, float y0, float x1, float y1,
				      int color0, int color1, SkShader::TileMode tileMode)
{
	return NULL;
}

SkShader*
ShaderGlue::RadialGradient_create(float x, float y, float radius, const NativeArray<int>& colorArray,
				  const NativeArray<float>* posArray, SkShader::TileMode tileMode)
{
	SkPoint center;
	center.set(x, y);

	return SkGradientShader::CreateRadial(center, SkFloatToScalar(radius),
					      reinterpret_cast<const SkColor*>(colorArray.ptr(0, colorArray.length())),
					      posArray ? posArray->ptr(0, colorArray.length()) : NULL,
					      colorArray.length(), tileMode);
}

SkShader*
ShaderGlue::RadialGradient_create(float x, float y, float radius,
				  int color0, int color1, SkShader::TileMode tileMode)
{
	SkPoint center;
	center.set(x, y);

	SkColor colors[2];
	colors[0] = color0;
	colors[1] = color1;

	return SkGradientShader::CreateRadial(center, radius, colors, NULL, 2, tileMode);
}

const void*
ShaderGlue::RadialGradient_postCreate(SkShader* shader, float x, float y, float radius,
				      const NativeArray<int>& colorArray, const NativeArray<float>* posArray,
				      SkShader::TileMode tileMode)
{
	return NULL;
}

const void*
ShaderGlue::RadialGradient_postCreate(SkShader* shader, float x, float y, float radius,
				      int color0, int color1, SkShader::TileMode tileMode)
{
	return NULL;
}

SkShader*
ShaderGlue::SweepGradient_create(float x, float y, const NativeArray<int>& colorArray,
				 const NativeArray<float>* positions)
{
	return SkGradientShader::CreateSweep(x, y,
					     reinterpret_cast<const SkColor*>(colorArray.ptr(0, colorArray.length())),
					     positions ? positions->ptr(0, colorArray.length()) : NULL,
					     colorArray.length());
}

SkShader*
ShaderGlue::SweepGradient_create(float x, float y, int color0, int color1)
{
	SkColor colors[2];
	colors[0] = color0;
	colors[1] = color1;
	return SkGradientShader::CreateSweep(SkFloatToScalar(x), SkFloatToScalar(y), colors, NULL, 2);
}

const void*
ShaderGlue::SweepGradient_postCreate(SkShader* shader, float x, float y, const NativeArray<int>& colorArray,
				     const NativeArray<float>* positions)
{
	return NULL;
}

const void*
ShaderGlue::SweepGradient_postCreate(SkShader* shader, float x, float y, int color0, int color1)
{
	return NULL;
}

void
ShaderGlue::Color_RGBToHSV(int red, int green, int blue, NativeArray<float>& hsvArray)
{
	SkScalar hsv[3];
	SkRGBToHSV(red, green, blue, hsv);

	SkASSERT(hsvArray.length() == 3);

	for (int i = 0; i < 3; i++) {
		hsvArray.item(i) = hsv[i];
	}
}

int
ShaderGlue::Color_HSVToColor(int alpha, const NativeArray<float>& hsvArray)
{
	SkScalar    hsv[3];

	SkASSERT(hsvArray.length() == 3);

	for (int i = 0; i < 3; i++) {
		hsv[i] = hsvArray[i];
	}

	return SkHSVToColor(alpha, hsv);
}
