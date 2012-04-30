// This is based on the Android API sample
// http://developer.android.com/resources/samples/ApiDemos/src/com/example/android/apis/graphics/Vertices.html
using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Vertices")]
	public class Vertices : TestView
	{
		static readonly Paint mPaint = new Paint ();
		static readonly float[] mVerts = new float[10];
		static readonly float[] mTexs = new float[10];
		static readonly short[] mIndices = { 0, 1, 2, 3, 4, 1 };
		static readonly Matrix mMatrix = new Matrix ();
		static readonly Matrix mInverse = new Matrix ();

		private static void setXY (float[] array, int index, float x, float y)
		{
			array [index * 2 + 0] = x;
			array [index * 2 + 1] = y;
		}

		public Vertices (Context context)
			: base (context)
		{
			Bitmap bm = GetResourceBitmap (R.drawable.beach);
			Shader s = new BitmapShader (bm, Shader.TileMode.CLAMP, Shader.TileMode.CLAMP);
			mPaint.setShader (s);

			float w = bm.getWidth ();
			float h = bm.getHeight ();
			// construct our mesh
			setXY (mTexs, 0, w / 2, h / 2);
			setXY (mTexs, 1, 0, 0);
			setXY (mTexs, 2, w, 0);
			setXY (mTexs, 3, w, h);
			setXY (mTexs, 4, 0, h);

			setXY (mVerts, 0, w / 2, h / 2);
			setXY (mVerts, 1, 0, 0);
			setXY (mVerts, 2, w, 0);
			setXY (mVerts, 3, w, h);
			setXY (mVerts, 4, 0, h);

			mMatrix.setScale (0.8f, 0.8f);
			mMatrix.preTranslate (20, 20);
			mMatrix.invert (mInverse);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFCCCCCC));
			canvas.save ();
			canvas.concat (mMatrix);

			canvas.drawVertices (Canvas.VertexMode.TRIANGLE_FAN, 10, mVerts, 0,
                                mTexs, 0, null, 0, null, 0, 0, mPaint);

			canvas.translate (0, 240);
			canvas.drawVertices (Canvas.VertexMode.TRIANGLE_FAN, 10, mVerts, 0,
                                mTexs, 0, null, 0, mIndices, 0, 6, mPaint);

			canvas.restore ();
		}

		protected void OnTouchEvent (System.Windows.Forms.MouseEventArgs e)
		{
			float[] pt = { e.X, e.Y };
			mInverse.mapPoints (pt);
			setXY (mVerts, 0, pt [0], pt [1]);
			invalidate ();
		}
	}
}

