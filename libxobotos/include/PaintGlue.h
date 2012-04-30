#ifndef PAINT_GLUE_H
#define PAINT_GLUE_H

#include <libxobotos.h>
#include <SkPaint.h>
#include <PathGlue.h>
 
class PaintGlue : public SkPaint
{
public:
	PaintGlue();
	PaintGlue(const PaintGlue& paint);

	void setShadowLayer(float radius, float dx, float dy, SkColor color);
	float ascent(void);
	float descent(void);
	void set(const PaintGlue src);

	struct FontMetricsInt {
		int top;
		int ascent;
		int descent;
		int bottom;
		int leading;
	};

	enum MoveOpt {
		AFTER, AT_OR_AFTER, BEFORE, AT_OR_BEFORE, AT
	};

	int getFontMetricsInt(FontMetricsInt* fmi);
	int breakTextC(const NativeArray<char16_t>& chars, int index, int count, float maxWidth,
		       NativeArray<float>* measuredWidth);
	int breakTextS(const NativeString& text, bool measureForwards, float maxWidth,
		       NativeArray<float>* measuredWidth);
	float measureTextC(const NativeArray<char16_t>& chars, int index, int count);
	float measureTextS(const NativeString& text, int start, int end);
	float measureTextS2(const NativeString& text);
	void getStringBounds(const NativeString& text, int start, int end, SkIRect* bounds);
	void getCharArrayBounds(const NativeArray<char16_t>& text, int index, int count, SkIRect* bounds);
	int getTextWidthsC(const NativeArray<char16_t>& text, int index, int count,
			   NativeArray<float>& widths);
	int getTextWidthsS(const NativeString& text, int start, int end,
			   NativeArray<float>& widths);
	void getTextPathC(int, const NativeArray<char16_t>& chars, int index, int count,
			  float x, float y, PathGlue* path);
	void getTextPathS(int, const NativeString& text, int start, int end,
			  float x, float y, PathGlue* path);

	float getTextRunAdvancesC(const NativeArray<char16_t>& text, int index, int count,
				  int context_idx, int context_count, int flags,
				  NativeArray<float>* advances, int advances_idx, int reserved);
	float getTextRunAdvancesS(const NativeString& text, int start, int end,
				  int context_start, int context_end, int flags,
				  NativeArray<float>* advances, int advances_idx, int reserved);

	int getTextRunCursorC(const NativeArray<char16_t>& text, int context_start, int context_count,
			      int flags, int offset, int opt);
	int getTextRunCursorS(const NativeString& text, int context_start, int context_end,
			      int flags, int offset, int opt);

	/*
	 * We override these and return void, so we don't have to increase the refcount on the parameter.
	 */
	void setShader(SkShader* shader);
	void setColorFilter(SkColorFilter* filter);
	void setXfermode(SkXfermode* xfermode);
	void setPathEffect(SkPathEffect* effect);
	void setMaskFilter(SkMaskFilter* maskfilter);
	void setTypeface(SkTypeface* typeface);
	void setRasterizer(SkRasterizer* rasterizer);

private:
	int breakText(const NativeArray<char16_t>& text, int index, int count, float maxWidth,
		      NativeArray<float>* measuredWidth, SkPaint::TextBufferDirection tbd);
	SkIRect doTextBounds(const NativeArray<char16_t>& text, int start, int count);
	int dotextwidths(const NativeArray<char16_t>& text, int index, int count, NativeArray<float>& widths);
	float TextLayout_computeAdvancesWithICU(const NativeArray<char16_t>& text, size_t index, size_t count,
						float* out_advances);
	float doTextRunAdvances(const NativeArray<char16_t>& text, int text_index, int text_count,
				int context_idx, int context_count, int flags,
				int advances_idx, NativeArray<float>* advances);
	int doTextRunCursor(const NativeArray<char16_t>& text, int start, int count, int offset, MoveOpt opt);
};

#endif
