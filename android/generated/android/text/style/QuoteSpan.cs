using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class QuoteSpan : android.text.style.LeadingMarginSpan, android.text.ParcelableSpan
	{
		internal const int STRIPE_WIDTH = 2;

		internal const int GAP_WIDTH = 2;

		private readonly int mColor;

		[Sharpen.Stub]
		public QuoteSpan() : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public QuoteSpan(int color) : base()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public QuoteSpan(android.os.Parcel src)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.text.ParcelableSpan")]
		public virtual int getSpanTypeId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getColor()
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
	}
}
