using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncStats : android.os.Parcelable
	{
		public long numAuthExceptions;

		public long numIoExceptions;

		public long numParseExceptions;

		public long numConflictDetectedExceptions;

		public long numInserts;

		public long numUpdates;

		public long numDeletes;

		public long numEntries;

		public long numSkippedEntries;

		[Sharpen.Stub]
		public SyncStats()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SyncStats(android.os.Parcel @in)
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
		public virtual void clear()
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

		private sealed class _Creator_169 : android.os.ParcelableClass.Creator<android.content.SyncStats
			>
		{
			public _Creator_169()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncStats createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncStats[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.SyncStats
			> CREATOR = new _Creator_169();
	}
}
