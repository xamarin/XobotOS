using System;
using System.Windows.Forms;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Path Effects")]
	public class PathEffects : TestView
	{
		Paint mPaint;
		Path mPath;
		PathEffect[] mEffects;
		int[] mColors;
		float mPhase;

		static PathEffect makeDash (float phase)
		{
			return new DashPathEffect (new float[] { 15, 5, 8, 5 }, phase);
		}

		private static void makeEffects (PathEffect[] e, float phase)
		{
			e [0] = null;     // no effect
			e [1] = new CornerPathEffect (10);
			e [2] = new DashPathEffect (new float[] {10, 5, 5, 5}, phase);
			e [3] = new PathDashPathEffect (makePathDash (), 12, phase,
                                          PathDashPathEffect.Style.ROTATE);
			e [4] = new ComposePathEffect (e [2], e [1]);
			e [5] = new ComposePathEffect (e [3], e [1]);
		}

		public PathEffects (Context context)
			: base (context)
		{
			mPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
			mPaint.setStyle (Paint.Style.STROKE);
			mPaint.setStrokeWidth (6);

			mPath = makeFollowPath ();

			mEffects = new PathEffect[6];

			mColors = new int[] {
				Color.BLACK, Color.RED, Color.BLUE,
				Color.GREEN, Color.MAGENTA, Color.BLACK
			};
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			RectF bounds = new RectF ();
			mPath.computeBounds (bounds, false);
			canvas.translate (10 - bounds.left, 10 - bounds.top);

			makeEffects (mEffects, mPhase);
			mPhase += 1;

			for (int i = 0; i < mEffects.Length; i++) {
				mPaint.setPathEffect (mEffects [i]);
				mPaint.setColor (mColors [i]);
				canvas.drawPath (mPath, mPaint);
				canvas.translate (0, 28);
			}
		}

		protected void OnKeyPressEvent (KeyPressEventArgs e)
		{
			if (e.KeyChar == 'f') {
				mPath = makeFollowPath ();
				invalidate ();
			}
		}

		static Path makeFollowPath ()
		{
			Path p = new Path ();
			p.moveTo (0, 0);
			Random random = new Random ();
			for (int i = 1; i <= 15; i++) {
				p.lineTo (i * 20, (float)random.NextDouble () * 35);
			}
			return p;
		}

		static Path makePathDash ()
		{
			Path p = new Path ();
			p.moveTo (4, 0);
			p.lineTo (0, -4);
			p.lineTo (8, -4);
			p.lineTo (12, 0);
			p.lineTo (8, 4);
			p.lineTo (0, 4);
			return p;
		}
	}
}
