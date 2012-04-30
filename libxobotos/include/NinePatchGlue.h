#ifndef NINE_PATCH_GLUE_H
#define NINE_PATCH_GLUE_H

#include <libxobotos.h>
#include <SkNinePatch.h>
#include <CanvasGlue.h>
#include <BitmapGlue.h>
#include <RegionGlue.h>
#include <utils/ResourceTypes.h>

class NinePatchGlue : public SkNinePatch
{
public:
	static bool isNinePatchChunk(const NativeArray<uint8_t>* objArray);
	static void validateNinePatchChunk(const BitmapGlue& bitmap,
					   const NativeArray<uint8_t>& objArray);
	static void draw(SkCanvas& canvas, SkIRect& ibounds, const BitmapGlue& bitmap,
			 const NativeArray<uint8_t>& chunkArray, const PaintGlue* paint,
			 int dest_density, int src_density);
	static void draw(SkCanvas& canvas, SkRect& bounds, const BitmapGlue& bitmap,
			 const NativeArray<uint8_t>& chunkArray, const PaintGlue* paint,
			 int dest_density, int src_density);
	static RegionGlue* getTransparentRegion(const BitmapGlue& bitmap,
						const NativeArray<uint8_t>& chunkArray,
						const SkIRect& bounds);

private:
	static bool getColor(const BitmapGlue& bitmap, int x, int y, SkColor* c);
	static SkColor modAlpha(SkColor c, int alpha);
	static void drawStretchyPatch(SkCanvas& canvas, SkIRect& src, const SkRect& dst,
				      const BitmapGlue& bitmap, const PaintGlue& paint,
				      SkColor initColor, uint32_t colorHint,
				      bool hasXfer);
	static SkScalar calculateStretch(SkScalar boundsLimit, SkScalar startingPoint,
					 int srcSpace, int numStrechyPixelsRemaining,
					 int numFixedPixelsRemaining);
	static void NinePatch_Draw(SkCanvas* canvas, const SkRect& bounds,
				   const BitmapGlue& bitmap, const android::Res_png_9patch& chunk,
				   const PaintGlue* paint, RegionGlue* *outRegion);

	NinePatchGlue() { }
};

#endif
