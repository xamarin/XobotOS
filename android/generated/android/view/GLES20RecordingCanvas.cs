using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	internal class GLES20RecordingCanvas : android.view.GLES20Canvas, android.util.Poolable
		<android.view.GLES20RecordingCanvas>
	{
		internal const int POOL_LIMIT = 25;

		private sealed class _PoolableManager_44 : android.util.PoolableManager<android.view.GLES20RecordingCanvas
			>
		{
			public _PoolableManager_44()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public android.view.GLES20RecordingCanvas newInstance()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public void onAcquired(android.view.GLES20RecordingCanvas element)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public void onReleased(android.view.GLES20RecordingCanvas element)
			{
				throw new System.NotImplementedException();
			}
		}

		private static readonly android.util.Pool<android.view.GLES20RecordingCanvas> sPool
			 = null;

		private android.view.GLES20RecordingCanvas mNextPoolable;

		private bool mIsPooled;

		private android.view.GLES20DisplayList mDisplayList;

		[Sharpen.Stub]
		private GLES20RecordingCanvas() : base(true, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.view.GLES20RecordingCanvas obtain(android.view.GLES20DisplayList
			 displayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int end(int nativeDisplayList)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void recordShaderBitmap(android.graphics.Paint paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawBitmap(android.graphics.Bitmap bitmap, float left, float
			 top, android.graphics.Paint paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawCircle(float cx, float cy, float radius, android.graphics.Paint
			 paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPoint(float x, float y, android.graphics.Paint paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawPoints(float[] pts, android.graphics.Paint paint)
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
		public override void drawRoundRect(android.graphics.RectF rect, float rx, float ry
			, android.graphics.Paint paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(java.lang.CharSequence text, int start_1, int end_1
			, float x, float y, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawText(string text, int start_1, int end_1, float x, float
			 y, android.graphics.Paint paint)
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
		[Sharpen.OverridesMethod(@"android.graphics.Canvas")]
		public override void drawTextRun(java.lang.CharSequence text, int start_1, int end_1
			, int contextStart, int contextEnd, float x, float y, int dir, android.graphics.Paint
			 paint)
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
		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public virtual android.view.GLES20RecordingCanvas getNextPoolable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public virtual void setNextPoolable(android.view.GLES20RecordingCanvas element)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public virtual bool isPooled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public virtual void setPooled(bool isPooled_1)
		{
			throw new System.NotImplementedException();
		}
	}
}
