using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class PackageStats : android.os.Parcelable
	{
		public string packageName;

		public long codeSize;

		public long dataSize;

		public long cacheSize;

		public long externalCodeSize;

		public long externalDataSize;

		public long externalCacheSize;

		public long externalMediaSize;

		public long externalObbSize;

		private sealed class _Creator_68 : android.os.ParcelableClass.Creator<android.content.pm.PackageStats
			>
		{
			public _Creator_68()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageStats createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageStats[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PackageStats
			> CREATOR = new _Creator_68();

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PackageStats(string pkgName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PackageStats(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PackageStats(android.content.pm.PackageStats pStats)
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
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}
	}
}
