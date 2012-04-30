using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class BulletSpan : android.text.style.LeadingMarginSpan, android.text.ParcelableSpan
	{
		private readonly int mGapWidth;

		private readonly bool mWantColor;

		private readonly int mColor;

		internal const int BULLET_RADIUS = 3;

		private static android.graphics.Path sBulletPath = null;

		public const int STANDARD_GAP_WIDTH = 2;

		[Sharpen.Stub]
		public BulletSpan()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BulletSpan(int gapWidth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BulletSpan(int gapWidth, int color)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BulletSpan(android.os.Parcel src)
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
			, int start, int end, bool first, android.text.Layout l)
		{
			throw new System.NotImplementedException();
		}
	}
}
