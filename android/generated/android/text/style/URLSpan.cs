using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public class URLSpan : android.text.style.ClickableSpan, android.text.ParcelableSpan
	{
		private readonly string mURL;

		[Sharpen.Stub]
		public URLSpan(string url)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public URLSpan(android.os.Parcel src)
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
		public virtual string getURL()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.text.style.ClickableSpan")]
		public override void onClick(android.view.View widget)
		{
			throw new System.NotImplementedException();
		}
	}
}
