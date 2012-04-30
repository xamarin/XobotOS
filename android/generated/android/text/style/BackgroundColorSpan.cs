using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class BackgroundColorSpan : android.text.style.CharacterStyle, android.text.style.UpdateAppearance
		, android.text.ParcelableSpan
	{
		private readonly int mColor;

		[Sharpen.Stub]
		public BackgroundColorSpan(int color)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BackgroundColorSpan(android.os.Parcel src)
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
		public virtual int getBackgroundColor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.CharacterStyle")]
		public override void updateDrawState(android.text.TextPaint ds)
		{
			throw new System.NotImplementedException();
		}
	}
}
