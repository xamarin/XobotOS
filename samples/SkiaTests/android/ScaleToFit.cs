using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Scale To Fit")]
	public class ScaleToFit : TestView
	{
		readonly Paint   mPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
		readonly Paint   mHairPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
		readonly Paint   mLabelPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
		readonly Matrix  mMatrix = new Matrix ();
		readonly RectF   mSrcR = new RectF ();
		static readonly Matrix.ScaleToFit[] sFits = new Matrix.ScaleToFit[] {
			Matrix.ScaleToFit.FILL,
			Matrix.ScaleToFit.START,
			Matrix.ScaleToFit.CENTER,
			Matrix.ScaleToFit.END
		};
		static readonly string[] sFitLabels = {
			"FILL", "START", "CENTER", "END"
		};
		static readonly int[] sSrcData = {
			80, 40, Color.RED,
			40, 80, Color.GREEN,
			30, 30, Color.BLUE,
			80, 80, Color.BLACK
		};
		const int N = 4;
		const int WIDTH = 52;
		const int HEIGHT = 52;
		readonly RectF mDstR = new RectF (0, 0, WIDTH, HEIGHT);

		public ScaleToFit (Context context)
			: base (context)
		{
			mHairPaint.setStyle (Paint.Style.STROKE);
			mLabelPaint.setTextSize (16);
		}

		void setSrcR (int index)
		{
			int w = sSrcData [index * 3 + 0];
			int h = sSrcData [index * 3 + 1];
			mSrcR.set (0, 0, w, h);
		}

		void drawSrcR (Canvas canvas, int index)
		{
			mPaint.setColor (sSrcData [index * 3 + 2]);
			canvas.drawOval (mSrcR, mPaint);
		}

		void drawFit (Canvas canvas, int index, Matrix.ScaleToFit stf)
		{
			canvas.save ();

			setSrcR (index);
			mMatrix.setRectToRect (mSrcR, mDstR, stf);
			canvas.concat (mMatrix);
			drawSrcR (canvas, index);

			canvas.restore ();

			canvas.drawRect (mDstR, mHairPaint);
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (Color.WHITE);

			canvas.translate (10, 10);

			canvas.save ();
			for (int i = 0; i < N; i++) {
				setSrcR (i);
				drawSrcR (canvas, i);
				canvas.translate (mSrcR.width () + 15, 0);
			}
			canvas.restore ();

			canvas.translate (0, 100);
			for (int j = 0; j < sFits.Length; j++) {
				canvas.save ();
				for (int i = 0; i < N; i++) {
					drawFit (canvas, i, sFits [j]);
					canvas.translate (mDstR.width () + 8, 0);
				}
				canvas.drawText (sFitLabels [j], 0, HEIGHT * 2 / 3, mLabelPaint);
				canvas.restore ();
				canvas.translate (0, 80);
			}
		}
	}
}
