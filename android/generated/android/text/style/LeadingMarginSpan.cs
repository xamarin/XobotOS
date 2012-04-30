using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public interface LeadingMarginSpan : android.text.style.ParagraphStyle
	{
		[Sharpen.Stub]
		int getLeadingMargin(bool first);

		[Sharpen.Stub]
		void drawLeadingMargin(android.graphics.Canvas c, android.graphics.Paint p, int x
			, int dir, int top, int baseline, int bottom, java.lang.CharSequence text, int start
			, int end, bool first, android.text.Layout layout);
	}

	[Sharpen.Stub]
	public static class LeadingMarginSpanClass
	{
		[Sharpen.Stub]
		public interface LeadingMarginSpan2 : android.text.style.LeadingMarginSpan, android.text.style.WrapTogetherSpan
		{
			[Sharpen.Stub]
			int getLeadingMarginLineCount();
		}

		[Sharpen.Stub]
		public class Standard : android.text.style.LeadingMarginSpan, android.text.ParcelableSpan
		{
			private readonly int mFirst;

			private readonly int mRest;

			[Sharpen.Stub]
			public Standard(int first, int rest)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Standard(int every) : this(every, every)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public Standard(android.os.Parcel src)
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
}
