using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Big Blur")]
	public class BigBlur : TestView
	{
		public BigBlur (Context context)
			: base (context)
		{
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFDDDDDD));

			canvas.save ();

			Paint paint = new Paint ();
			paint.setColor (Color.BLUE);

			MaskFilter mf = new BlurMaskFilter (128, BlurMaskFilter.Blur.NORMAL);
			paint.setMaskFilter (mf);
			mf.Dispose ();

			canvas.translate (200, 200);
			canvas.drawCircle (100, 100, 200, paint);

			canvas.restore ();

			paint.Dispose ();
		}
	}
}
