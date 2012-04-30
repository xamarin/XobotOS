using System;
using android.content;
using android.graphics;
using android.graphics.drawable;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Round Rects")]
	public class RoundRects : TestView
	{
		Rect    mRect;
		GradientDrawable mDrawable;

		public RoundRects (Context context)
			: base (context)
		{
			mRect = new Rect (0, 0, 120, 120);

			int[] colors = {
				unchecked((int)0xFFFF0000), unchecked((int)0xFF00FF00), unchecked((int)0xFF0000FF)
			};

			mDrawable = new GradientDrawable (GradientDrawable.Orientation.TL_BR, colors);
			mDrawable.setShape (GradientDrawable.RECTANGLE);
			mDrawable.setGradientRadius ((float)(Math.Sqrt (2) * 60));
		}

		static void setCornerRadii (GradientDrawable drawable, float r0, float r1, float r2, float r3)
		{
			drawable.setCornerRadii (new float[] { r0, r0, r1, r1, r2, r2, r3, r3 });
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			mDrawable.setBounds (mRect);

			float r = 16;

			canvas.save ();
			canvas.translate (10, 10);
			mDrawable.setGradientType (GradientDrawable.LINEAR_GRADIENT);
			setCornerRadii (mDrawable, r, r, 0, 0);
			mDrawable.draw (canvas);
			canvas.restore ();

			canvas.save ();
			canvas.translate (10 + mRect.width () + 10, 10);
			mDrawable.setGradientType (GradientDrawable.RADIAL_GRADIENT);
			setCornerRadii (mDrawable, 0, 0, r, r);
			mDrawable.draw (canvas);
			canvas.restore ();

			canvas.translate (0, mRect.height () + 10);

			canvas.save ();
			canvas.translate (10, 10);
			mDrawable.setGradientType (GradientDrawable.SWEEP_GRADIENT);
			setCornerRadii (mDrawable, 0, r, r, 0);
			mDrawable.draw (canvas);
			canvas.restore ();

			canvas.save ();
			canvas.translate (10 + mRect.width () + 10, 10);
			mDrawable.setGradientType (GradientDrawable.LINEAR_GRADIENT);
			setCornerRadii (mDrawable, r, 0, 0, r);
			mDrawable.draw (canvas);
			canvas.restore ();

			canvas.translate (0, mRect.height () + 10);

			canvas.save ();
			canvas.translate (10, 10);
			mDrawable.setGradientType (GradientDrawable.RADIAL_GRADIENT);
			setCornerRadii (mDrawable, r, 0, r, 0);
			mDrawable.draw (canvas);
			canvas.restore ();

			canvas.save ();
			canvas.translate (10 + mRect.width () + 10, 10);
			mDrawable.setGradientType (GradientDrawable.SWEEP_GRADIENT);
			setCornerRadii (mDrawable, 0, r, 0, r);
			mDrawable.draw (canvas);
			canvas.restore ();
		}
	}
}
