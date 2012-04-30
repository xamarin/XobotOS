using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class IconMarginSpan : android.text.style.LeadingMarginSpan, android.text.style.LineHeightSpan
	{
		[Sharpen.Stub]
		public IconMarginSpan(android.graphics.Bitmap b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public IconMarginSpan(android.graphics.Bitmap b, int pad)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.style.LeadingMarginSpan")]
		public virtual int getLeadingMargin(bool first)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.style.LeadingMarginSpan")]
		public virtual void drawLeadingMargin(android.graphics.Canvas c, android.graphics.Paint
			 p, int x, int dir, int top, int baseline, int bottom, java.lang.CharSequence text
			, int start, int end, bool first, android.text.Layout layout)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.style.LineHeightSpan")]
		public virtual void chooseHeight(java.lang.CharSequence text, int start, int end, 
			int istartv, int v, android.graphics.Paint.FontMetricsInt fm)
		{
			throw new System.NotImplementedException();
		}

		private android.graphics.Bitmap mBitmap;

		private int mPad;
	}
}
