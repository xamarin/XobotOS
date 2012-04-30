using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class ResultInfo : android.os.Parcelable
	{
		public readonly string mResultWho;

		public readonly int mRequestCode;

		public readonly int mResultCode;

		public readonly android.content.Intent mData;

		[Sharpen.Stub]
		public ResultInfo(string resultWho, int requestCode, int resultCode, android.content.Intent
			 data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
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
		public virtual void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_66 : android.os.ParcelableClass.Creator<android.app.ResultInfo
			>
		{
			public _Creator_66()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.ResultInfo createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.ResultInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.ResultInfo>
			 CREATOR = new _Creator_66();

		[Sharpen.Stub]
		public ResultInfo(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}
	}
}
