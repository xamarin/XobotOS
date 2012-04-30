using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncStatusInfo : android.os.Parcelable
	{
		internal const int VERSION = 2;

		public readonly int authorityId;

		public long totalElapsedTime;

		public int numSyncs;

		public int numSourcePoll;

		public int numSourceServer;

		public int numSourceLocal;

		public int numSourceUser;

		public int numSourcePeriodic;

		public long lastSuccessTime;

		public int lastSuccessSource;

		public long lastFailureTime;

		public int lastFailureSource;

		public string lastFailureMesg;

		public long initialFailureTime;

		public bool pending;

		public bool initialize;

		public java.util.ArrayList<long> periodicSyncTimes;

		internal const string TAG = "Sync";

		[Sharpen.Stub]
		internal SyncStatusInfo(int authorityId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLastFailureMesgAsInt(int def)
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
		internal SyncStatusInfo(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPeriodicSyncTime(int index, long when)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensurePeriodicSyncTimeSize(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getPeriodicSyncTime(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removePeriodicSyncTime(int index)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_160 : android.os.ParcelableClass.Creator<android.content.SyncStatusInfo
			>
		{
			public _Creator_160()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncStatusInfo createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncStatusInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.SyncStatusInfo
			> CREATOR = new _Creator_160();
	}
}
