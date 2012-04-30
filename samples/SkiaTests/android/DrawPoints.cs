using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Draw Points")]
	public class DrawPoints : TestView
	{
		float[] mPts;
		const float SIZE = 300;
		const int SEGS = 32;
		new const int X = 0;
		new const int Y = 1;
		const int ptCount = (SEGS + 1) * 2;
		const float delta = SIZE / SEGS;

		void buildPoints ()
		{
			mPts = new float[ptCount * 2];

			float value = 0;
			for (int i = 0; i <= SEGS; i++) {
				mPts [i * 4 + X] = SIZE - value;
				mPts [i * 4 + Y] = 0;
				mPts [i * 4 + X + 2] = 0;
				mPts [i * 4 + Y + 2] = value;
				value += delta;
			}
		}

		public DrawPoints (Context context)
			: base (context)
		{
			buildPoints ();
		}

		protected override void onDraw (Canvas canvas)
		{
			Paint paint = new Paint ();

			canvas.translate (10, 10);

			canvas.drawColor (Color.WHITE);

			paint.setColor (Color.RED);
			paint.setStrokeWidth (0);
			canvas.drawLines (mPts, paint);

			paint.setColor (Color.BLUE);
			paint.setStrokeWidth (3);
			canvas.drawPoints (mPts, paint);
		}
	}
}
