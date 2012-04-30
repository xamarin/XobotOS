#include <DrawFilterGlue.h>
#include <SkTemplates.h>

SkDrawFilter*
DrawFilterGlue::PaintFlagsDrawFilter_create(int clearFlags, int setFlags)
{
	// trim off any out-of-range bits
        clearFlags &= SkPaint::kAllFlags;
        setFlags &= SkPaint::kAllFlags;

        if (clearFlags | setFlags)
		return new SkPaintFlagsDrawFilter(clearFlags, setFlags);
	else
		return NULL;
}
