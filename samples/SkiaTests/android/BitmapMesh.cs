using System;
using System.Windows.Forms;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Bitmap Mesh")]
	public class BitmapMesh : TestView
	{
		const int WIDTH = 20;
		const int HEIGHT = 20;
		const int COUNT = (WIDTH + 1) * (HEIGHT + 1);
		readonly Bitmap mBitmap;
		readonly float[] mVerts = new float[COUNT * 2];
		readonly float[] mOrig = new float[COUNT * 2];
		readonly Matrix mMatrix = new Matrix ();
		readonly Matrix mInverse = new Matrix ();

		static void setXY (float[] array, int index, float x, float y)
		{
			array [index * 2 + 0] = x;
			array [index * 2 + 1] = y;
		}

		public BitmapMesh (Context context)
			: base (context)
		{
			mBitmap = GetResourceBitmap (R.drawable.beach);

			float w = mBitmap.getWidth ();
			float h = mBitmap.getHeight ();
			// construct our mesh
			int index = 0;
			for (int y = 0; y <= HEIGHT; y++) {
				float fy = h * y / HEIGHT;
				for (int x = 0; x <= WIDTH; x++) {
					float fx = w * x / WIDTH;
					setXY (mVerts, index, fx, fy);
					setXY (mOrig, index, fx, fy);
					index += 1;
				}
			}

			mMatrix.setTranslate (10, 10);
			mMatrix.invert (mInverse);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFCCCCCC));

			canvas.concat (mMatrix);
			canvas.drawBitmapMesh (mBitmap, WIDTH, HEIGHT, mVerts, 0, null, 0, null);
		}

		const float K = 10000;

		void warp (float cx, float cy)
		{
			float[] src = mOrig;
			float[] dst = mVerts;
			for (int i = 0; i < COUNT*2; i += 2) {
				float x = src [i + 0];
				float y = src [i + 1];
				float dx = cx - x;
				float dy = cy - y;
				float dd = dx * dx + dy * dy;
				float d = (float)Math.Sqrt (dd);
				float pull = K / (dd + 0.000001f);

				pull /= (d + 0.000001f);
				//   android.util.Log.d("skia", "index " + i + " dist=" + d + " pull=" + pull);

				if (pull >= 1) {
					dst [i + 0] = cx;
					dst [i + 1] = cy;
				} else {
					dst [i + 0] = x + dx * pull;
					dst [i + 1] = y + dy * pull;
				}
			}
		}

		int mLastWarpX = -9999; // don't match a touch coordinate
		int mLastWarpY;

		protected void OnTouchEvent (MouseEventArgs e)
		{
			float[] pt = { e.X, e.Y };
			mInverse.mapPoints (pt);

			int x = (int)pt [0];
			int y = (int)pt [1];
			if (mLastWarpX != x || mLastWarpY != y) {
				mLastWarpX = x;
				mLastWarpY = y;
				warp (pt [0], pt [1]);
				invalidate ();
			}
		}
	}
}
