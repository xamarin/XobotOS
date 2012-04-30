using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public sealed class SyncResult : android.os.Parcelable
	{
		public readonly bool syncAlreadyInProgress;

		public bool tooManyDeletions;

		public bool tooManyRetries;

		public bool databaseError;

		public bool fullSyncRequested;

		public bool partialSyncUnavailable;

		public bool moreRecordsToGet;

		public long delayUntil;

		public readonly android.content.SyncStats stats;

		public static readonly android.content.SyncResult ALREADY_IN_PROGRESS;

		static SyncResult()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SyncResult() : this(false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SyncResult(bool syncAlreadyInProgress)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SyncResult(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasHardError()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasSoftError()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasError()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool madeSomeProgress()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void clear()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_223 : android.os.ParcelableClass.Creator<android.content.SyncResult
			>
		{
			public _Creator_223()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncResult createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncResult[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.SyncResult
			> CREATOR = new _Creator_223();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel parcel, int flags)
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
		public string toDebugString()
		{
			throw new System.NotImplementedException();
		}
	}
}
