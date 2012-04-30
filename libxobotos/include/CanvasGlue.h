#ifndef CANVAS_GLUE_H
#define CANVAS_GLUE_H

#include <libxobotos.h>
#include <PaintGlue.h>
#include <BitmapGlue.h>
#include <PictureGlue.h>
#include <SkCanvas.h>
#include <SkBitmap.h>
#include <SkRegion.h>
 
using namespace XobotOS;

class CanvasGlue : public SkCanvas
{
public:
	static SkCanvas* create(const SkBitmap* bitmap);

	static void freeCaches();

	static bool isOpaque(SkCanvas& canvas);
	static int getWidth(SkCanvas& canvas);
	static int getHeight(SkCanvas& canvas);
	static void setBitmap(SkCanvas& canvas, const SkBitmap* bitmap);
	static bool clipIRect(SkCanvas& canvas, SkIRect rect);
	static bool clipIRect(SkCanvas& canvas, int left, int top, int right, int bottom);
	static bool clipRect(SkCanvas& canvas, float left, float top, float right, float bottom);
	static bool clipRectValues(SkCanvas& canvas, float left, float top, float right, float bottom,
				   SkRegion::Op regionOp);
	static bool getClipBoundsIRect(SkCanvas& canvas, SkIRect& bounds);
	static void getCTM(SkCanvas& canvas, SkMatrix* matrix);
	static void drawBitmap(SkCanvas& canvas, SkBitmap bitmap, float left, float top,
			       const SkPaint* paint, int canvasDensity, int screenDensity, int bitmapDensity);
	static void drawBitmapRect(SkCanvas& canvas, SkBitmap bitmap, const SkIRect* src, const SkRect &dst,
				   const SkPaint* paint, int screenDensity, int bitmapDensity);
	static void drawBitmapRect(SkCanvas& canvas, SkBitmap bitmap, const SkIRect* src, const SkIRect &idst,
				   const SkPaint* paint, int screenDensity, int bitmapDensity);
	static void drawBitmapColors(SkCanvas& canvas, const NativeArray<int>& colors,
				     int offset, int stride,float x, float y, int width, int height,
				     bool hasAlpha, const PaintGlue* paint);
	static void drawBitmapMesh(SkCanvas& canvas, const BitmapGlue& bitmap, int meshWidth, int meshHeight,
				   const NativeArray<float>& vertArray, int vertIndex,
				   const NativeArray<int>* colorArray, int colorIndex,
				   const PaintGlue* paint);
	static void drawVertices(SkCanvas& canvas, SkCanvas::VertexMode mode, int vertexCount,
				 const NativeArray<float>& vertArray, int vertIndex,
				 const NativeArray<float>* texArray, int texIndex,
				 const NativeArray<int>* colorArray, int colorIndex,
				 const NativeArray<short>* indexArray, int indexIndex,
				 int indexCount, const PaintGlue& paint);
	static void drawRGB(SkCanvas& canvas, int r, int g, int b);
	static int saveLayerValues(SkCanvas& canvas, float l, float t, float r, float b, const SkPaint* paint, SaveFlags layerFlags);
	static int saveLayerAlphaValues(SkCanvas& canvas, float l, float t, float r, float b, int alpha, SaveFlags layerFlags);

	static void drawRect(SkCanvas& canvas, float left, float top, float right, float bottom, const PaintGlue& paint);
	static bool quickReject(SkCanvas& canvas, float left, float top, float right, float bottom, SkCanvas::EdgeType edgeType);

	static void drawTextC(SkCanvas& canvas, const NativeArray<char16_t>& text, int index, int count, float x, float y,
			      int flags, const PaintGlue& paint);
	static void drawTextS(SkCanvas& canvas, const NativeString& text, int start, int end, float x, float y,
			      int flags, const PaintGlue& paint);

	static void drawPoints(SkCanvas& canvas, const NativeArray<float>& pts, int offset, int count, const PaintGlue& paint);
	static void drawLines(SkCanvas& canvas, const NativeArray<float>& pts, int offset, int count, const PaintGlue& paint);

	static void drawTextRunC(SkCanvas& canvas, const NativeArray<char16_t>& text, int index, int count,
				 int context_index, int context_count, float x, float y, int flags, const PaintGlue& paint);
	static void drawTextRunS(SkCanvas& canvas, const NativeString& text, int start, int end,
				 int context_start, int context_end, float x, float y, int flags, const PaintGlue& paint);

private:
	static void doPoints(SkCanvas& canvas, const NativeArray<float>& floats, int offset, int count,
			     const PaintGlue& paint, SkCanvas::PointMode mode);
	static void drawTextRun(SkCanvas& canvas, const NativeArray<char16_t>& chars, int start, int count,
				float x, float y, const PaintGlue& paint);
	CanvasGlue() { }
};

#endif
