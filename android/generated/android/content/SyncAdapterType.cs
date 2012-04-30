using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SyncAdapterType : android.os.Parcelable
	{
		public readonly string authority;

		public readonly string accountType;

		public readonly bool isKey;

		private readonly bool userVisible;

		private readonly bool _supportsUploading;

		private readonly bool _isAlwaysSyncable;

		private readonly bool _allowParallelSyncs;

		private readonly string settingsActivity;

		[Sharpen.Stub]
		public SyncAdapterType(string authority, string accountType, bool userVisible, bool
			 supportsUploading_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SyncAdapterType(string authority, string accountType, bool userVisible, bool
			 supportsUploading_1, bool isAlwaysSyncable_1, bool allowParallelSyncs_1, string
			 settingsActivity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SyncAdapterType(string authority, string accountType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool supportsUploading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isUserVisible()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool allowParallelSyncs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isAlwaysSyncable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getSettingsActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.SyncAdapterType newKey(string authority, string accountType
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
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
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SyncAdapterType(android.os.Parcel source) : this(source.readString(), source
			.readString(), source.readInt() != 0, source.readInt() != 0, source.readInt() !=
			 0, source.readInt() != 0, source.readString())
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_217 : android.os.ParcelableClass.Creator<android.content.SyncAdapterType
			>
		{
			public _Creator_217()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncAdapterType createFromParcel(android.os.Parcel source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.SyncAdapterType[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.SyncAdapterType
			> CREATOR = new _Creator_217();
	}
}
