using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

using android.view;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Xobot Monkey")]
	public class XobotMonkey : TestView
	{
		public XobotMonkey (Context context)
			: base (context)
		{ }

		protected override void onDraw(Canvas canvas)
		{
			canvas.drawColor(Color.YELLOW);
			int width = canvas.getWidth();
			int height = canvas.getHeight();

			Paint paint = new Paint();
			paint.setColor(Color.RED);
			paint.setStyle(Paint.Style.STROKE);
			paint.setStrokeWidth(10);
			canvas.drawCircle(width / 2, height / 2, height / 3, paint);

			Paint inner = new Paint();
			paint.setColor(Color.GREEN);
			paint.setStyle(Paint.Style.FILL);
			canvas.drawCircle(width / 2, height / 2, height / 3 - 10, inner);

			Paint text = new Paint();
			text.setTextSize(20);
			canvas.drawText("I am a Xobot Monkey!", width / 8, height / 8, text);
		}
	}
}
