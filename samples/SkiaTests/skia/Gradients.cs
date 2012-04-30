// Ported from the SampleGradients.cpp Skia sample
using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Gradients")]
	public class Gradients : TestView
	{
		public Gradients (Context context)
			: base (context)
		{
		}

		static Shader setgrad (RectF r, uint c0, uint c1)
		{
			int[] colors = { unchecked((int)c0), unchecked((int)c1) };
			return new LinearGradient (
				r.left, r.top, r.right, r.top, colors, null, Shader.TileMode.CLAMP);
		}

		static void test_alphagradients (Canvas canvas)
		{
			canvas.translate (20, 10);

			RectF r = new RectF (10, 10, 410, 30);
			Paint p = new Paint (), p2 = new Paint ();
			p2.setStyle (Paint.Style.STROKE);

			using (Shader shader = setgrad (r, 0xFF00FF00, 0x0000FF00))
				p.setShader (shader);
			canvas.drawRect (r, p);
			canvas.drawRect (r, p2);

			r.offset (0, r.height () + 4);
			using (Shader shader = setgrad(r, 0xFF00FF00, 0x00000000))
				p.setShader (shader);
			canvas.drawRect (r, p);
			canvas.drawRect (r, p2);

			r.offset (0, r.height () + 4);
			using (Shader shader = setgrad(r, 0xFF00FF00, 0x00FF0000))
				p.setShader (shader);
			canvas.drawRect (r, p);
			canvas.drawRect (r, p2);
		}

		struct GradData
		{
			public readonly int[] Colors;
			public readonly float[] Pos;

			public GradData (int[] colors, float[] pos)
			{
				this.Colors = colors;
				this.Pos = pos;
			}
		}

		static readonly int[] Colors0 = {
			Color.RED, Color.GREEN
		};
		static readonly int[] Colors1 = {
			Color.RED, Color.GREEN, Color.BLUE, Color.WHITE, Color.BLACK
		};
		static readonly float[] Pos0 = { 0, 1 };
		static readonly float[] Pos1 = { 1 / 4, 3 / 4 };
		static readonly float[] Pos2 = { 0, 1 / 8, 1 / 2, 7 / 8, 1 };
		static readonly GradData[] Grads = {
			new GradData (Colors0, null),
			new GradData (Colors0, Pos0),
			new GradData (Colors0, Pos1),
			new GradData (Colors1, null),
			new GradData (Colors1, Pos2)
		};

		static Shader MakeLinear (RectF r, GradData data, Shader.TileMode tile)
		{
			return new LinearGradient (
				r.left, r.top, r.right, r.bottom, data.Colors, data.Pos, tile);
		}

		static Shader MakeRadial (RectF r, GradData data, Shader.TileMode tile)
		{
			return new RadialGradient (
				r.centerX (), r.centerY (), r.centerX (), data.Colors, data.Pos, tile);
		}

		static Shader MakeSweep (RectF r, GradData data, Shader.TileMode tile)
		{
			return new SweepGradient (
				r.centerX (), r.centerX (), data.Colors, data.Pos);
		}

		delegate Shader GradMaker (RectF r,GradData data,Shader.TileMode tile);

		static readonly GradMaker[] GradMakers = {
			MakeLinear, MakeRadial, MakeSweep
		};

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFDDDDDD));

			test_alphagradients (canvas);

			RectF r = new RectF (0, 0, 100, 100);

			Paint paint = new Paint ();
			paint.setDither (true);

			canvas.save ();
			canvas.translate (20, 100);

			Shader.TileMode[] modes = {
				Shader.TileMode.CLAMP, Shader.TileMode.MIRROR, Shader.TileMode.CLAMP
			};

			foreach (Shader.TileMode tile in modes) {
				canvas.save ();
				foreach (GradData data in Grads) {
					canvas.save ();
					foreach (GradMaker maker in GradMakers) {
						using (Shader shader = maker(r, data, tile))
							paint.setShader (shader);
						canvas.drawRect (r, paint);
						canvas.translate (0, 120);
					}
					canvas.restore ();
					canvas.translate (120, 0);
				}
				canvas.translate (Grads.Length * 120, 0);
			}

			canvas.restore ();
			canvas.translate (0, 370);
		}

	}
}

