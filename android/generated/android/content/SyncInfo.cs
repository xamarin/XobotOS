using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncInfo : android.os.Parcelable
	{
		public readonly int authorityId;

		public readonly android.accounts.Account account;

		public readonly string authority;

		public readonly long startTime;

		[Sharpen.Stub]
		internal SyncInfo(int authorityId, android.accounts.Account account, string authority
			, long startTime)
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
		public virtual void writeToParcel(android.os.Parcel parcel, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal SyncInfo(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_79 : android.os.ParcelableClass.Creator<android.content.SyncInfo
			>
		{
			public _Creator_79()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncInfo createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.SyncInfo
			> CREATOR = new _Creator_79();
	}
}
