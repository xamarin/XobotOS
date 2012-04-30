using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Regions")]
	public class Regions : TestView
	{
		readonly Paint mPaint = new Paint ();
		readonly Rect  mRect1 = new Rect ();
		readonly Rect  mRect2 = new Rect ();

		public Regions (Context context)
			: base (context)
		{
			mPaint.setAntiAlias (true);
			mPaint.setTextSize (16);
			mPaint.setTextAlign (Paint.Align.CENTER);

			mRect1.set (10, 10, 100, 80);
			mRect2.set (50, 50, 130, 110);
		}

		void drawOriginalRects (Canvas canvas, int alpha)
		{
			mPaint.setStyle (Paint.Style.STROKE);
			mPaint.setColor (Color.RED);
			mPaint.setAlpha (alpha);
			drawCentered (canvas, mRect1, mPaint);
			mPaint.setColor (Color.BLUE);
			mPaint.setAlpha (alpha);
			drawCentered (canvas, mRect2, mPaint);

			// restore style
			mPaint.setStyle (Paint.Style.FILL);
		}

		void drawRgn (Canvas canvas, int color, String str, Region.Op op)
		{
			if (str != null) {
				mPaint.setColor (Color.BLACK);
				canvas.drawText (str, 80, 24, mPaint);
			}

			Region rgn = new Region ();
			rgn.set (mRect1);
			rgn.op (mRect2, op);

			mPaint.setColor (color);
			RegionIterator iter = new RegionIterator (rgn);
			Rect r = new Rect ();

			canvas.translate (0, 30);
			mPaint.setColor (color);
			while (iter.next(r)) {
				canvas.drawRect (r, mPaint);
			}
			drawOriginalRects (canvas, 0x80);
		}

		static void drawCentered (Canvas c, Rect r, Paint p)
		{
			float inset = p.getStrokeWidth () * 0.5f;
			if (inset == 0) {   // catch hairlines
				inset = 0.5f;
			}
			c.drawRect (r.left + inset, r.top + inset,
                	r.right - inset, r.bottom - inset, p);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.GRAY);

			canvas.save ();
			canvas.translate (80, 5);
			drawOriginalRects (canvas, 0xFF);
			canvas.restore ();

			mPaint.setStyle (Paint.Style.FILL);

			canvas.save ();
			canvas.translate (0, 140);
			drawRgn (canvas, Color.RED, "Union", Region.Op.UNION);
			canvas.restore ();

			canvas.save ();
			canvas.translate (0, 280);
			drawRgn (canvas, Color.BLUE, "Xor", Region.Op.XOR);
			canvas.restore ();

			canvas.save ();
			canvas.translate (160, 140);
			drawRgn (canvas, Color.GREEN, "Difference", Region.Op.DIFFERENCE);
			canvas.restore ();

			canvas.save ();
			canvas.translate (160, 280);
			drawRgn (canvas, Color.WHITE, "Intersect", Region.Op.INTERSECT);
			canvas.restore ();
		}
	}
}
