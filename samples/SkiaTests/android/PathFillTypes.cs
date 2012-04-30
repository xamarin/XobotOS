using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Path Fill Types")]
	public class PathFillTypes : TestView
	{
		Path mPath;

		public PathFillTypes (Context context)
			: base (context)
		{
			mPath = new Path ();
			mPath.addCircle (40, 40, 45, Path.Direction.CCW);
			mPath.addCircle (80, 80, 45, Path.Direction.CCW);
		}

		void showPath (Canvas canvas, int x, int y, Path.FillType ft, Paint paint)
		{
			canvas.save ();
			canvas.translate (x, y);
			canvas.clipRect (0, 0, 120, 120);
			canvas.drawColor (Color.WHITE);
			mPath.setFillType (ft);
			canvas.drawPath (mPath, paint);
			canvas.restore ();
		}

		protected override void onDraw (Canvas canvas)
		{
			Paint paint = new Paint (Paint.ANTI_ALIAS_FLAG);

			canvas.drawColor (unchecked((int)0xFFCCCCCC));

			canvas.translate (20, 20);

			paint.setAntiAlias (true);

			showPath (canvas, 0, 0, Path.FillType.WINDING, paint);
			showPath (canvas, 160, 0, Path.FillType.EVEN_ODD, paint);
			showPath (canvas, 0, 160, Path.FillType.INVERSE_WINDING, paint);
			showPath (canvas, 160, 160, Path.FillType.INVERSE_EVEN_ODD, paint);
		}
	}
}
