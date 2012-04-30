using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public abstract class DynamicDrawableSpan : android.text.style.ReplacementSpan
	{
		internal const string TAG = "DynamicDrawableSpan";

		public const int ALIGN_BOTTOM = 0;

		public const int ALIGN_BASELINE = 1;

		protected internal readonly int mVerticalAlignment;

		[Sharpen.Stub]
		public DynamicDrawableSpan()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal DynamicDrawableSpan(int verticalAlignment)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getVerticalAlignment()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.graphics.drawable.Drawable getDrawable();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.ReplacementSpan")]
		public override int getSize(android.graphics.Paint paint, java.lang.CharSequence 
			text, int start, int end, android.graphics.Paint.FontMetricsInt fm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.ReplacementSpan")]
		public override void draw(android.graphics.Canvas canvas, java.lang.CharSequence 
			text, int start, int end, float x, int top, int y, int bottom, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.graphics.drawable.Drawable getCachedDrawable()
		{
			throw new System.NotImplementedException();
		}

		private java.lang.@ref.WeakReference<android.graphics.drawable.Drawable> mDrawableRef;
	}
}
