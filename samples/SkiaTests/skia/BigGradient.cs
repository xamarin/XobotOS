using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Big Gradient")]
	public class BigGradient : TestView
	{
		public BigGradient (Context context)
			: base (context)
		{
		}

		static Shader make_grad (float w, float h)
		{
			int[] colors = { unchecked((int)0xFF000000), unchecked((int)0xFF333333) };
			return new LinearGradient (0, 0, w, h, colors, null, Shader.TileMode.CLAMP);
		}

		protected override void onDraw (Canvas canvas)
		{

			Console.WriteLine ("DRAW: {0} {1}", canvas.getWidth (), canvas.getHeight ());

			RectF r = new RectF (0, 0, canvas.getWidth (), canvas.getHeight ());
			Paint paint = new Paint ();

			using (Shader shader = make_grad (canvas.getWidth(), canvas.getHeight()))
				paint.setShader (shader);
			canvas.drawRect (r, paint);
		}
	}
}

