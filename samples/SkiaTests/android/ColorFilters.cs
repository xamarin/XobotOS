// This is based on the Android API sample
// http://developer.android.com/resources/samples/ApiDemos/src/com/example/android/apis/graphics/ColorFilters.html
using System;
using android.content;
using android.graphics;
using android.graphics.drawable;
using android.view;

namespace XobotOS.Samples.SkiaTests
{
	[Test("Color Filters")]
	public class ColorFilters : TestView
	{
		private Drawable mDrawable;
		private Drawable[] mDrawables;
		private Paint mPaint;
		private Paint mPaint2;
		private float mPaintTextOffset;
		private uint[] mColors;
		private PorterDuff.Mode[] mModes;
		private int mModeIndex;

		private static void addToTheRight (Drawable curr, Drawable prev)
		{
			Rect r = prev.getBounds ();
			int x = r.right + 12;
			int center = (r.top + r.bottom) >> 1;
			int h = curr.getIntrinsicHeight ();
			int y = center - (h >> 1);

			curr.setBounds (x, y, x + curr.getIntrinsicWidth (), y + h);
		}

		public ColorFilters (Context context)
			: base (context)
		{
			mDrawable = getResources ().getDrawable (R.drawable.btn_default_normal);
			mDrawable.setBounds (0, 0, 150, 48);
			mDrawable.setDither (true);

			int[] resIDs = new int[] {
				R.drawable.btn_circle_normal,
				R.drawable.btn_check_off,
				R.drawable.btn_check_on
			};
			mDrawables = new Drawable[resIDs.Length];
			Drawable prev = mDrawable;
			for (int i = 0; i < resIDs.Length; i++) {
				mDrawables [i] = getResources ().getDrawable (resIDs [i]);
				mDrawables [i].setDither (true);
				addToTheRight (mDrawables [i], prev);
				prev = mDrawables [i];
			}

			mPaint = new Paint ();
			mPaint.setAntiAlias (true);
			mPaint.setTextSize (16);
			mPaint.setTextAlign (Paint.Align.CENTER);

			mPaint2 = new Paint (mPaint);
			mPaint2.setAlpha (64);

			Paint.FontMetrics fm = mPaint.getFontMetrics ();
			mPaintTextOffset = (fm.descent + fm.ascent) * 0.5f;

			mColors = new uint[] {
				0, 0xCC0000FF, 0x880000FF, 0x440000FF, 0xFFCCCCFF,
				0xFF8888FF, 0xFF4444FF
			};

			mModes = new PorterDuff.Mode[] {
				PorterDuff.Mode.SRC_ATOP, PorterDuff.Mode.MULTIPLY,
			};
			mModeIndex = 0;

			updateTitle ();
		}

		private void swapPaintColors ()
		{
			if (mPaint.getColor () == unchecked((int)0xFF000000)) {
				mPaint.setColor (unchecked((int)0xFFFFFFFF));
				mPaint2.setColor (unchecked((int)0xFF000000));
			} else {
				mPaint.setColor (unchecked((int)0xFF000000));
				mPaint2.setColor (unchecked((int)0xFFFFFFFF));
			}
			mPaint2.setAlpha (64);
		}

		private void updateTitle ()
		{
		}

		private void drawSample (Canvas canvas, ColorFilter filter)
		{
			Rect r = mDrawable.getBounds ();
			float x = (r.left + r.right) * 0.5f;
			float y = (r.top + r.bottom) * 0.5f - mPaintTextOffset;

			mDrawable.setColorFilter (filter);
			mDrawable.draw (canvas);
			canvas.drawText ("Label", x + 1, y + 1, mPaint2);
			canvas.drawText ("Label", x, y, mPaint);

			foreach (Drawable dr in mDrawables) {
				dr.setColorFilter (filter);
				dr.draw (canvas);
			}
		}

		protected override void onDraw (Canvas canvas)
		{
			canvas.drawColor (unchecked((int)0xFFCCCCCC));

			canvas.translate (8, 12);
			foreach (int color in mColors) {
				ColorFilter filter;
				if (color == 0) {
					filter = null;
				} else {
					filter = new PorterDuffColorFilter (color,
                                                       mModes [mModeIndex]);
				}
				drawSample (canvas, filter);
				canvas.translate (0, 55);
			}
		}

		public override bool onTouchEvent (MotionEvent @event)
		{
			switch (@event.getAction ()) {
			case MotionEvent.ACTION_DOWN:
				break;
			case MotionEvent.ACTION_MOVE:
				break;
			case MotionEvent.ACTION_UP:
				// update mode every other time we change paint colors
				if (mPaint.getColor () == unchecked((int)0xFFFFFFFF)) {
					mModeIndex = (mModeIndex + 1) % mModes.Length;
					updateTitle ();
				}
				swapPaintColors ();
				invalidate ();
				break;
			}
			return true;
		}
	}
}

