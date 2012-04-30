using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class ContentProviderResult : android.os.Parcelable
	{
		public readonly System.Uri uri;

		public readonly int count;

		[Sharpen.Stub]
		public ContentProviderResult(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ContentProviderResult(int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ContentProviderResult(android.os.Parcel source)
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
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_68 : android.os.ParcelableClass.Creator<android.content.ContentProviderResult
			>
		{
			public _Creator_68()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentProviderResult createFromParcel(android.os.Parcel source
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentProviderResult[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ContentProviderResult
			> CREATOR = new _Creator_68();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
