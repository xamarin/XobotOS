using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	public class Spiral : TestView
	{
		public Spiral (Context context, int interval)
			: base (context)
		{
			// AddTimer (interval);
		}

		static DateTime start_time = DateTime.Now;

		// From SampleApp.cpp
		static float GetAnimScalar (double speed, double period)
		{
			double gAnimTime = (DateTime.Now - start_time).TotalMilliseconds;

			// since gAnimTime can be up to 32 bits, we can't convert it to a float
			// or we'll lose the low bits. Hence we use doubles for the intermediate
			// calculations
			double seconds = (double)gAnimTime / 1000.0;
			double value = speed * seconds;
			if (period != 0) {
				value = Math.IEEERemainder (value, period);
			}
			return (float)value;
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFDDDDDD));

			Paint paint = new Paint ();
			paint.setAntiAlias (true);
			paint.setStyle (Paint.Style.STROKE);
			paint.setStrokeWidth (3);
			paint.setStyle (Paint.Style.FILL);

			RectF r = new RectF ();
			float t, x, y;

			t = GetAnimScalar (25, 500);

			canvas.translate (320, 240);

			for (int i = 0; i < 35; i++) {
				paint.setColor (unchecked((int)0xFFF00FF0 - i * 0x04000000));
				double step = Math.PI / (55 - i);
				double angle = t * step;
				x = (20 + i * 5) * (float)Math.Sin (angle);
				y = (20 + i * 5) * (float)Math.Cos (angle);
				r.set (x, y, x + 10, y + 10);
				canvas.drawRect (r, paint);
			}
		}
	}
}
