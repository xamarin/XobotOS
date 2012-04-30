using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	internal class GLES20Canvas : android.view.HardwareCanvas
	{
		internal const int MODIFIER_NONE = 0;

		internal const int MODIFIER_SHADOW = 1;

		internal const int MODIFIER_SHADER = 2;

		internal const int MODIFIER_COLOR_FILTER = 4;

		private readonly bool mOpaque;

		private int mRenderer;

		private android.view.GLES20Canvas.CanvasFinalizer mFinalizer;

		private int mWidth;

		private int mHeight;

		private readonly float[] mPoint = new float[2];

		private readonly float[] mLine = new float[4];

		private readonly android.graphics.Rect mClipBounds = new android.graphics.Rect();

		private android.graphics.DrawFilter mFilter;

		[Sharpen.Stub]
		private static bool nIsAvailable()
		{
			throw new System.NotImplementedException();
		}

		private static bool sIsAvailable = nIsAvailable();

		[Sharpen.Stub]
		internal static bool isAvailable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal GLES20Canvas(bool translucent) : this(false, translucent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal GLES20Canvas(int layer, bool translucent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal GLES20Canvas(bool record, bool translucent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setupFinalizer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void resetDisplayListRenderer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nCreateRenderer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nCreateLayerRenderer(int layer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nCreateDisplayListRenderer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nResetDisplayListRenderer(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDestroyRenderer(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class CanvasFinalizer
		{
			internal readonly int mRenderer;

			[Sharpen.Stub]
			public CanvasFinalizer(int renderer)
			{
				throw new System.NotImplementedException();
			}

			~CanvasFinalizer()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal static int nCreateTextureLayer(bool opaque, int[] layerInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static int nCreateLayer(int width, int height, bool isOpaque_1, int[] layerInfo
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void nResizeLayer(int layerId, int width, int height, int[] layerInfo
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void nUpdateTextureLayer(int layerId, int width, int height, bool
			 opaque, android.graphics.SurfaceTexture surface)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void nSetTextureLayerTransform(int layerId, int matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void nDestroyLayer(int layerId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void nDestroyLayerDeferred(int layerId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static bool nCopyLayer(int layerId, int bitmap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool isOpaque()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int getWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int getHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int getMaximumBitmapWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int getMaximumBitmapHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetMaximumTextureWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetMaximumTextureHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void setViewport(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSetViewport(int renderer, int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool preserveBackBuffer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nPreserveBackBuffer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool isBackBufferPreserved()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nIsBackBufferPreserved()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void disableVsync()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDisableVsync()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		internal override void onPreDraw(android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nPrepare(int renderer, bool opaque)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nPrepareDirty(int renderer, int left, int top, int right, int
			 bottom, bool opaque)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		internal override void onPostDraw()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nFinish(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		public override bool callDrawGLFunction(int drawGLFunction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nCallDrawGLFunction(int renderer, int drawGLFunction)
		{
			throw new System.NotImplementedException();
		}

		public const int FLUSH_CACHES_LAYERS = 0;

		public const int FLUSH_CACHES_MODERATE = 1;

		public const int FLUSH_CACHES_FULL = 2;

		[Sharpen.Stub]
		public static void flushCaches(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nFlushCaches(int level)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getDisplayList(int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetDisplayList(int renderer, int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void destroyDisplayList(int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDestroyDisplayList(int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static int getDisplayListSize(int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetDisplayListSize(int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		internal override bool drawDisplayList(android.view.DisplayList displayList, int 
			width, int height, android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nDrawDisplayList(int renderer, int displayList, int width, int
			 height, android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		internal override void outputDisplayList(android.view.DisplayList displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nOutputDisplayList(int renderer, int displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareCanvas")]
		internal override void drawHardwareLayer(android.view.HardwareLayer layer, float 
			x, float y, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawLayer(int renderer, int layer, float x, float y, int paint
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void interrupt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void resume()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nInterrupt(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nResume(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipPath(android.graphics.Path path)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipPath(android.graphics.Path path, android.graphics.Region
			.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(float left, float top, float right, float bottom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nClipRect(int renderer, float left, float top, float right, float
			 bottom, int op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(float left, float top, float right, float bottom, android.graphics.Region
			.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(int left, int top, int right, int bottom)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nClipRect(int renderer, int left, int top, int right, int bottom
			, int op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(android.graphics.Rect rect)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(android.graphics.Rect rect, android.graphics.Region
			.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(android.graphics.RectF rect)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRect(android.graphics.RectF rect, android.graphics.Region
			.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRegion(android.graphics.Region region)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool clipRegion(android.graphics.Region region, android.graphics.Region
			.Op op)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool getClipBounds(android.graphics.Rect bounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nGetClipBounds(int renderer, android.graphics.Rect bounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool quickReject(float left, float top, float right, float bottom
			, android.graphics.Canvas.EdgeType type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool nQuickReject(int renderer, float left, float top, float right
			, float bottom, int edge)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool quickReject(android.graphics.Path path, android.graphics.Canvas
			.EdgeType type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override bool quickReject(android.graphics.RectF rect, android.graphics.Canvas
			.EdgeType type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void translate(float dx, float dy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nTranslate(int renderer, float dx, float dy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void skew(float sx, float sy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSkew(int renderer, float sx, float sy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void rotate(float degrees)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nRotate(int renderer, float degrees)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void scale(float sx, float sy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nScale(int renderer, float sx, float sy)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void setMatrix(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSetMatrix(int renderer, int matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void getMatrix(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nGetMatrix(int renderer, int matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void concat(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nConcatMatrix(int renderer, int matrix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int save()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int save(int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nSave(int renderer, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int saveLayer(android.graphics.RectF bounds, android.graphics.Paint
			 paint, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nSaveLayer(int renderer, int paint, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int saveLayer(float left, float top, float right, float bottom, android.graphics.Paint
			 paint, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nSaveLayer(int renderer, float left, float top, float right, float
			 bottom, int paint, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int saveLayerAlpha(android.graphics.RectF bounds, int alpha, int 
			saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nSaveLayerAlpha(int renderer, int alpha, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int saveLayerAlpha(float left, float top, float right, float bottom
			, int alpha, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nSaveLayerAlpha(int renderer, float left, float top, float right
			, float bottom, int alpha, int saveFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void restore()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nRestore(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void restoreToCount(int saveCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nRestoreToCount(int renderer, int saveCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override int getSaveCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nGetSaveCount(int renderer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void setDrawFilter(android.graphics.DrawFilter filter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override android.graphics.DrawFilter getDrawFilter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawArc(android.graphics.RectF oval, float startAngle, float
			 sweepAngle, bool useCenter, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawArc(int renderer, float left, float top, float right, float
			 bottom, float startAngle, float sweepAngle, bool useCenter, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawARGB(int a, int r, int g, int b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPatch(android.graphics.Bitmap bitmap, byte[] chunks, android.graphics.RectF
			 dst, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawPatch(int renderer, int bitmap, byte[] buffer, byte[] chunks
			, float left, float top, float right, float bottom, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(android.graphics.Bitmap bitmap, float left, float
			 top, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawBitmap(int renderer, int bitmap, byte[] buffer, float left
			, float top, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Matrix
			 matrix, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawBitmap(int renderer, int bitmap, byte[] buff, int matrix
			, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Rect
			 src, android.graphics.Rect dst, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Rect
			 src, android.graphics.RectF dst, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawBitmap(int renderer, int bitmap, byte[] buffer, float srcLeft
			, float srcTop, float srcRight, float srcBottom, float left, float top, float right
			, float bottom, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(int[] colors, int offset, int stride, float x, float
			 y, int width, int height, bool hasAlpha, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(int[] colors, int offset, int stride, int x, int 
			y, int width, int height, bool hasAlpha, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmapMesh(android.graphics.Bitmap bitmap, int meshWidth
			, int meshHeight, float[] verts, int vertOffset, int[] colors, int colorOffset, 
			android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawBitmapMesh(int renderer, int bitmap, byte[] buffer, int 
			meshWidth, int meshHeight, float[] verts, int vertOffset, int[] colors, int colorOffset
			, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawCircle(float cx, float cy, float radius, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawCircle(int renderer, float cx, float cy, float radius, int
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawColor(int color)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawColor(int color, android.graphics.PorterDuff.Mode mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawColor(int renderer, int color, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawLine(float startX, float startY, float stopX, float stopY
			, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawLines(float[] pts, int offset, int count, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawLines(int renderer, float[] points, int offset, int count
			, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawLines(float[] pts, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawOval(android.graphics.RectF oval, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawOval(int renderer, float left, float top, float right, float
			 bottom, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPaint(android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPath(android.graphics.Path path, android.graphics.Paint 
			paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawPath(int renderer, int path, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawRects(int renderer, int region, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPicture(android.graphics.Picture picture)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPicture(android.graphics.Picture picture, android.graphics.Rect
			 dst)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPicture(android.graphics.Picture picture, android.graphics.RectF
			 dst)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPoint(float x, float y, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPoints(float[] pts, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPoints(float[] pts, int offset, int count, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawPoints(int renderer, float[] points, int offset, int count
			, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPosText(char[] text, int index, int count, float[] pos, 
			android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPosText(string text, float[] pos, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawRect(float left, float top, float right, float bottom, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawRect(int renderer, float left, float top, float right, float
			 bottom, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawRect(android.graphics.Rect r, android.graphics.Paint paint
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawRect(android.graphics.RectF r, android.graphics.Paint paint
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawRGB(int r, int g, int b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawRoundRect(android.graphics.RectF rect, float rx, float ry
			, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawRoundRect(int renderer, float left, float top, float right
			, float bottom, float rx, float y, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(char[] text, int index, int count, float x, float y
			, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawText(int renderer, char[] text, int index, int count, float
			 x, float y, int bidiFlags, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(java.lang.CharSequence text, int start, int end, float
			 x, float y, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(string text, int start, int end, float x, float y, 
			android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawText(int renderer, string text, int start, int end, float
			 x, float y, int bidiFlags, int paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(string text, float x, float y, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawTextOnPath(char[] text, int index, int count, android.graphics.Path
			 path, float hOffset, float vOffset, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawTextOnPath(string text, android.graphics.Path path, float
			 hOffset, float vOffset, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawTextRun(char[] text, int index, int count, int contextIndex
			, int contextCount, float x, float y, int dir, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawTextRun(int renderer, char[] text, int index, int count, 
			int contextIndex, int contextCount, float x, float y, int dir, int nativePaint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawTextRun(java.lang.CharSequence text, int start, int end, 
			int contextStart, int contextEnd, float x, float y, int dir, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nDrawTextRun(int renderer, string text, int start, int end, int
			 contextStart, int contextEnd, float x, float y, int flags, int nativePaint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawVertices(android.graphics.Canvas.VertexMode mode, int vertexCount
			, float[] verts, int vertOffset, float[] texs, int texOffset, int[] colors, int 
			colorOffset, short[] indices, int indexOffset, int indexCount, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int setupModifiers(android.graphics.Bitmap b, android.graphics.Paint paint
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int setupModifiers(android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int setupColorFilter(android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSetupShader(int renderer, int shader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSetupColorFilter(int renderer, int colorFilter)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nSetupShadow(int renderer, float radius, float dx, float dy, 
			int color)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nResetModifiers(int renderer, int modifiers)
		{
			throw new System.NotImplementedException();
		}
	}
}
