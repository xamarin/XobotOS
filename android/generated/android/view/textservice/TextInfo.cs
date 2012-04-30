using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public sealed class TextInfo : android.os.Parcelable
	{
		private readonly string mText;

		private readonly int mCookie;

		private readonly int mSequence;

		[Sharpen.Stub]
		public TextInfo(string text) : this(text, 0, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TextInfo(string text, int cookie, int sequence)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public TextInfo(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getCookie()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSequence()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_98 : android.os.ParcelableClass.Creator<android.view.textservice.TextInfo
			>
		{
			public _Creator_98()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.TextInfo createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.textservice.TextInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.textservice.TextInfo
			> CREATOR = new _Creator_98();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}
	}
}
