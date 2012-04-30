using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public class PermissionGroupInfo : android.content.pm.PackageItemInfo, android.os.Parcelable
	{
		public int descriptionRes;

		public java.lang.CharSequence nonLocalizedDescription;

		[Sharpen.Stub]
		public PermissionGroupInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PermissionGroupInfo(android.content.pm.PermissionGroupInfo orig) : base(orig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence loadDescription(android.content.pm.PackageManager
			 pm)
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
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_94 : android.os.ParcelableClass.Creator<android.content.pm.PermissionGroupInfo
			>
		{
			public _Creator_94()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PermissionGroupInfo createFromParcel(android.os.Parcel 
				source)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PermissionGroupInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PermissionGroupInfo
			> CREATOR = new _Creator_94();

		[Sharpen.Stub]
		private PermissionGroupInfo(android.os.Parcel source) : base(source)
		{
			throw new System.NotImplementedException();
		}
	}
}
