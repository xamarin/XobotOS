#ifndef ANDROID_GRAPHICS_PAINT_GLUE_H
#define ANDROID_GRAPHICS_PAINT_GLUE_H 1

#include <libxobotos.h>
#include "XobotOS.MarshalGlue.h"
#include <PaintGlue.h>
#include <PathGlue.h>
#include <XfermodeGlue.h>
#include <RasterizerGlue.h>
#include <MaskFilterGlue.h>
#include "android.graphics.Rect.h"
#include <SkPathEffect.h>
#include <ShaderGlue.h>
#include <ColorFilterGlue.h>
#include <TypefaceGlue.h>

struct FontMetrics_Struct;

class FontMetrics_Helper
{
public:
	static void unwrap(SkPaint::FontMetrics& from, FontMetrics_Struct* to);
	static FontMetrics_Struct* unwrap(SkPaint::FontMetrics* src);
	static void marshalOut(const SkPaint::FontMetrics& from, FontMetrics_Struct* to);
	static void wrap(const FontMetrics_Struct& from, SkPaint::FontMetrics* to);
	static SkPaint::FontMetrics* wrap(const FontMetrics_Struct* src);
	static const SkPaint::FontMetrics* wrapConst(const FontMetrics_Struct* src);
	static void freeMembers(FontMetrics_Struct& obj);
	static void destructor(FontMetrics_Struct* obj);

private:
	FontMetrics_Helper();

};

struct FontMetricsInt_Struct;

class FontMetricsInt_Helper
{
public:
	static void unwrap(PaintGlue::FontMetricsInt& from, FontMetricsInt_Struct* to);
	static FontMetricsInt_Struct* unwrap(PaintGlue::FontMetricsInt* src);
	static void marshalOut(const PaintGlue::FontMetricsInt& from, FontMetricsInt_Struct*
		 to);
	static void wrap(const FontMetricsInt_Struct& from, PaintGlue::FontMetricsInt* to);
	static PaintGlue::FontMetricsInt* wrap(const FontMetricsInt_Struct* src);
	static const PaintGlue::FontMetricsInt* wrapConst(const FontMetricsInt_Struct* src);
	static void freeMembers(FontMetricsInt_Struct& obj);
	static void destructor(FontMetricsInt_Struct* obj);

private:
	FontMetricsInt_Helper();

};



#endif
