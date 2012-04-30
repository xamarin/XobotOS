using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Emboss")]
	public class Emboss : TestView
	{
		public Emboss (Context context)
			: base (context)
		{
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFDDDDDD));

			Paint paint = new Paint ();
			paint.setAntiAlias (true);
			paint.setStyle (Paint.Style.STROKE);
			paint.setStrokeWidth (10);

			EmbossMaskFilter mf = new EmbossMaskFilter (new float[] { 1, 1, 1 }, 128, 16 * 2, 4);
			paint.setMaskFilter (mf);
			mf.Dispose ();

			// paint.setMaskFilter(new SkEmbossMaskFilter(fLight, SkIntToScalar(4)))->unref();
			// paint.setShader(new SkColorShader(SK_ColorBLUE))->unref();

			paint.setDither (true);

			canvas.drawCircle (50, 50, 30, paint);

			paint.Dispose ();
		}
	}
}
