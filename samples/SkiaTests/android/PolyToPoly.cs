using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Poly2Poly")]
	public class PolyToPoly : TestView
	{
		Paint   mPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
		Matrix  mMatrix = new Matrix ();
		Paint.FontMetrics mFontMetrics;

		void doDraw (Canvas canvas, float[] src, float[] dst)
		{
			canvas.save ();
			mMatrix.setPolyToPoly (src, 0, dst, 0, src.Length >> 1);
			canvas.concat (mMatrix);

			mPaint.setColor (Color.GRAY);
			mPaint.setStyle (Paint.Style.STROKE);
			canvas.drawRect (0, 0, 64, 64, mPaint);
			canvas.drawLine (0, 0, 64, 64, mPaint);
			canvas.drawLine (0, 64, 64, 0, mPaint);

			mPaint.setColor (Color.RED);
			mPaint.setStyle (Paint.Style.FILL);
			// how to draw the text center on our square
			// centering in X is easy... use alignment (and X at midpoint)
			float x = 64 / 2;
			// centering in Y, we need to measure ascent/descent first
			float y = 64 / 2 - (mFontMetrics.ascent + mFontMetrics.descent) / 2;
			canvas.drawText (src.Length / 2 + "", x, y, mPaint);

			canvas.restore ();
		}

		public PolyToPoly (Context context)
			: base (context)
		{
			// for when the style is STROKE
			mPaint.setStrokeWidth (4);
			// for when we draw text
			mPaint.setTextSize (40);
			mPaint.setTextAlign (Paint.Align.CENTER);
			mFontMetrics = mPaint.getFontMetrics ();
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			canvas.save ();
			canvas.translate (10, 10);
			// translate (1 point)
			doDraw (canvas, new float[] { 0, 0 }, new float[] { 5, 5 });
			canvas.restore ();

			canvas.save ();
			canvas.translate (160, 10);
			// rotate/uniform-scale (2 points)
			doDraw (canvas, new float[] { 32, 32, 64, 32 },
                           new float[] { 32, 32, 64, 48 });
			canvas.restore ();

			canvas.save ();
			canvas.translate (10, 110);
			// rotate/skew (3 points)
			doDraw (canvas, new float[] { 0, 0, 64, 0, 0, 64 },
                           new float[] { 0, 0, 96, 0, 24, 64 });
			canvas.restore ();

			canvas.save ();
			canvas.translate (160, 110);
			// perspective (4 points)
			doDraw (canvas, new float[] { 0, 0, 64, 0, 64, 64, 0, 64 },
                           new float[] { 0, 0, 96, 0, 64, 96, 0, 64 });
			canvas.restore ();
		}
	}
}
