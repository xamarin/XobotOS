// This is based on the Android API sample
// http://developer.android.com/resources/samples/ApiDemos/src/com/example/android/apis/graphics/Xfermodes.html
using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Xfermodes")]
	public class Xfermodes : TestView
	{
		// create a bitmap with a circle, used for the "dst" image
		static Bitmap makeDst (int w, int h)
		{
			Bitmap bm = Bitmap.createBitmap (w, h, Bitmap.Config.ARGB_8888);
			Canvas c = new Canvas (bm);
			Paint p = new Paint (Paint.ANTI_ALIAS_FLAG);

			p.setColor (unchecked((int)0xFFFFCC44));
			c.drawOval (new RectF (0, 0, w * 3 / 4, h * 3 / 4), p);
			return bm;
		}

		// create a bitmap with a rect, used for the "src" image
		static Bitmap makeSrc (int w, int h)
		{
			Bitmap bm = Bitmap.createBitmap (w, h, Bitmap.Config.ARGB_8888);
			Canvas c = new Canvas (bm);
			Paint p = new Paint (Paint.ANTI_ALIAS_FLAG);

			p.setColor (unchecked((int)0xFF66AAFF));
			c.drawRect (w / 3, h / 3, w * 19 / 20, h * 19 / 20, p);
			return bm;
		}

		private const int W = 64;
		private const int H = 64;
		private const int ROW_MAX = 4;	// number of samples per row

		private Bitmap mSrcB;
		private Bitmap mDstB;
		private Shader mBG;	// background checker-board pattern

		private static readonly Xfermode[] sModes = {
			new PorterDuffXfermode (PorterDuff.Mode.CLEAR),
			new PorterDuffXfermode (PorterDuff.Mode.SRC),
			new PorterDuffXfermode (PorterDuff.Mode.DST),
			new PorterDuffXfermode (PorterDuff.Mode.SRC_OVER),
			new PorterDuffXfermode (PorterDuff.Mode.DST_OVER),
			new PorterDuffXfermode (PorterDuff.Mode.SRC_IN),
			new PorterDuffXfermode (PorterDuff.Mode.DST_IN),
			new PorterDuffXfermode (PorterDuff.Mode.SRC_OUT),
			new PorterDuffXfermode (PorterDuff.Mode.DST_OUT),
			new PorterDuffXfermode (PorterDuff.Mode.SRC_ATOP),
			new PorterDuffXfermode (PorterDuff.Mode.DST_ATOP),
			new PorterDuffXfermode (PorterDuff.Mode.XOR),
			new PorterDuffXfermode (PorterDuff.Mode.DARKEN),
			new PorterDuffXfermode (PorterDuff.Mode.LIGHTEN),
			new PorterDuffXfermode (PorterDuff.Mode.MULTIPLY),
			new PorterDuffXfermode (PorterDuff.Mode.SCREEN)
		};
		private static readonly string[] sLabels = {
			"Clear", "Src", "Dst", "SrcOver",
			"DstOver", "SrcIn", "DstIn", "SrcOut",
			"DstOut", "SrcATop", "DstATop", "Xor",
			"Darken", "Lighten", "Multiply", "Screen"
		};

		public Xfermodes (Context context)
			: base (context)
		{
			mSrcB = makeSrc (W, H);
			mDstB = makeDst (W, H);

			// make a ckeckerboard pattern
			int[] colors = new int[] {
				unchecked((int)0xFFFFFFFF), unchecked((int)0xFFCCCCCC),
				unchecked((int)0xFFCCCCCC), unchecked((int)0xFFFFFFFF)
			};
			Bitmap bm = Bitmap.createBitmap (colors, 2, 2, Bitmap.Config.RGB_565);
			mBG = new BitmapShader (bm,
					       Shader.TileMode.REPEAT,
					       Shader.TileMode.REPEAT);
			Matrix m = new Matrix ();
			m.setScale (6, 6);
			mBG.setLocalMatrix (m);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			Paint labelP = new Paint (Paint.ANTI_ALIAS_FLAG);
			labelP.setTextAlign (Paint.Align.CENTER);

			Paint paint = new Paint ();
			paint.setFilterBitmap (false);

			canvas.translate (15, 35);

			int x = 0;
			int y = 0;
			for (int i = 0; i < sModes.Length; i++) {
				// draw the border
				paint.setStyle (Paint.Style.STROKE);
				paint.setShader (null);
				canvas.drawRect (x - 0.5f, y - 0.5f,
						x + W + 0.5f, y + H + 0.5f, paint);

				// draw the checker-board pattern
				paint.setStyle (Paint.Style.FILL);
				paint.setShader (mBG);
				canvas.drawRect (x, y, x + W, y + H, paint);

				// draw the src/dst example into our offscreen bitmap
				int sc = canvas.saveLayer (x, y, x + W, y + H, null,
							  Canvas.MATRIX_SAVE_FLAG |
							  Canvas.CLIP_SAVE_FLAG |
							  Canvas.HAS_ALPHA_LAYER_SAVE_FLAG |
							  Canvas.FULL_COLOR_LAYER_SAVE_FLAG |
							  Canvas.CLIP_TO_LAYER_SAVE_FLAG);
				canvas.translate (x, y);
				canvas.drawBitmap (mDstB, 0, 0, paint);
				paint.setXfermode (sModes [i]);
				canvas.drawBitmap (mSrcB, 0, 0, paint);
				paint.setXfermode (null);
				canvas.restoreToCount (sc);

				// draw the label
				canvas.drawText (sLabels [i],
						x + W / 2, y - labelP.getTextSize () / 2, labelP);

				x += W + 10;

				// wrap around when we've drawn enough for one row
				if ((i % ROW_MAX) == ROW_MAX - 1) {
					x = 0;
					y += H + 30;
				}
			}
		}
	}
}
