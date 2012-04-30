// This is based on the Android API sample
// http://developer.android.com/resources/samples/ApiDemos/src/com/example/android/apis/graphics/Arcs.html
using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	public class Arcs : TestView
	{
		Paint[] mPaints;
		Paint mFramePaint;
		bool[] mUseCenters;
		RectF[] mOvals;
		RectF mBigOval;
		float mStart;
		float mSweep;
		int mBigIndex;
		const float SWEEP_INC = 2;
		const float START_INC = 15;

		public Arcs (Context context)
			: base (context)
		{
			mPaints = new Paint[4];
			mUseCenters = new bool[4];
			mOvals = new RectF[4];

			mPaints [0] = new Paint ();
			mPaints [0].setAntiAlias (true);
			mPaints [0].setStyle (Paint.Style.FILL);
			mPaints [0].setColor (unchecked((int)0x88FF0000));
			mUseCenters [0] = false;

			mPaints [1] = new Paint (mPaints [0]);
			mPaints [1].setColor (unchecked((int)0x8800FF00));
			mUseCenters [1] = true;

			mPaints [2] = new Paint (mPaints [0]);
			mPaints [2].setStyle (Paint.Style.STROKE);
			mPaints [2].setStrokeWidth (4);
			mPaints [2].setColor (unchecked((int)0x880000FF));
			mUseCenters [2] = false;

			mPaints [3] = new Paint (mPaints [2]);
			mPaints [3].setColor (unchecked((int)0x88888888));
			mUseCenters [3] = true;

			mBigOval = new RectF (40, 10, 280, 250);

			mOvals [0] = new RectF (10, 270, 70, 330);
			mOvals [1] = new RectF (90, 270, 150, 330);
			mOvals [2] = new RectF (170, 270, 230, 330);
			mOvals [3] = new RectF (250, 270, 310, 330);

			mFramePaint = new Paint ();
			mFramePaint.setAntiAlias (true);
			mFramePaint.setStyle (Paint.Style.STROKE);
			mFramePaint.setStrokeWidth (0);

			// AddTimer (50);
		}

		void drawArcs (Canvas canvas, RectF oval, bool useCenter, Paint paint)
		{
			canvas.drawRect (oval, mFramePaint);
			canvas.drawArc (oval, mStart, mSweep, useCenter, paint);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			drawArcs (canvas, mBigOval, mUseCenters [mBigIndex], mPaints [mBigIndex]);

			for (int i = 0; i < 4; i++) {
				drawArcs (canvas, mOvals [i], mUseCenters [i], mPaints [i]);
			}

			mSweep += SWEEP_INC;
			if (mSweep > 360) {
				mSweep -= 360;
				mStart += START_INC;
				if (mStart >= 360) {
					mStart -= 360;
				}
				mBigIndex = (mBigIndex + 1) % mOvals.Length;
			}
		}
	}
}

