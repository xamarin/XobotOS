using System;
using android.content;
using android.graphics;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Color Matrix")]
	public class ColorMatrixSample : TestView
	{
		Paint mPaint = new Paint (Paint.ANTI_ALIAS_FLAG);
		Bitmap mBitmap;
		float mAngle;

		public ColorMatrixSample (Context context)
			: base (context)
		{
			mBitmap = GetResourceBitmap (R.drawable.balloons);
		}

		static void setTranslate (ColorMatrix cm, float dr, float dg, float db, float da)
		{
			cm.set (new float[] {
				2, 0, 0, 0, dr,
				0, 2, 0, 0, dg,
				0, 0, 2, 0, db,
				0, 0, 0, 1, da
			});
		}

		static void setContrast (ColorMatrix cm, float contrast)
		{
			float scale = contrast + 1.0f;
			float translate = (-.5f * scale + .5f) * 255.0f;
			cm.set (new float[] {
				scale, 0, 0, 0, translate,
				0, scale, 0, 0, translate,
				0, 0, scale, 0, translate,
				0, 0, 0, 1, 0
			});
		}

		private static void setContrastTranslateOnly (ColorMatrix cm, float contrast)
		{
			float scale = contrast + 1.0f;
			float translate = (-.5f * scale + .5f) * 255.0f;
			cm.set (new float[] {
				1, 0, 0, 0, translate,
				0, 1, 0, 0, translate,
				0, 0, 1, 0, translate,
				0, 0, 0, 1, 0
			});
		}

		static void setContrastScaleOnly (ColorMatrix cm, float contrast)
		{
			float scale = contrast + 1.0f;
			// float translate = (-.5f * scale + .5f) * 255.0f;
			cm.set (new float[] {
				scale, 0, 0, 0, 0,
				0, scale, 0, 0, 0,
				0, 0, scale, 0, 0,
				0, 0, 0, 1, 0
			});
		}

		protected override void onDraw (Canvas canvas)
		{
			Paint paint = mPaint;
			float x = 20;
			float y = 20;

			canvas.drawColor (Color.WHITE);

			paint.setColorFilter (null);
			canvas.drawBitmap (mBitmap, x, y, paint);

			ColorMatrix cm = new ColorMatrix ();

			mAngle += 2;
			if (mAngle > 180) {
				mAngle = 0;
			}

			//convert our animated angle [-180...180] to a contrast value of [-1..1]
			float contrast = mAngle / 180.0f;

			setContrast (cm, contrast);
			paint.setColorFilter (new ColorMatrixColorFilter (cm));
			canvas.drawBitmap (mBitmap, x + mBitmap.getWidth () + 10, y, paint);

			setContrastScaleOnly (cm, contrast);
			paint.setColorFilter (new ColorMatrixColorFilter (cm));
			canvas.drawBitmap (mBitmap, x, y + mBitmap.getHeight () + 10, paint);

			setContrastTranslateOnly (cm, contrast);
			paint.setColorFilter (new ColorMatrixColorFilter (cm));
			canvas.drawBitmap (mBitmap, x, y + 2 * (mBitmap.getHeight () + 10), paint);
		}
	}
}

