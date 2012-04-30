using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Box")]
	public class Box : TestView
	{
		public Box (Context context)
			: base (context)
		{
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFDDDDDD));

			Paint paint = new Paint ();
			paint.setAntiAlias (true);
			paint.setStyle (Paint.Style.STROKE);
			paint.setStrokeWidth (3);
			paint.setStyle (Paint.Style.FILL);

			RectF r = new RectF (10, 10, 110, 110);

			for (int i = 0; i < 256; ++i) {
				canvas.translate (1, 1);
				paint.setColor ((int)(0xFF000000 + i * 0x00010000));
				canvas.drawRect (r, paint);
			}
		}
	}
}
