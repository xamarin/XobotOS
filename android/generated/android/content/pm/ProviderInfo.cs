using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Holds information about a specific
	/// <see cref="android.content.ContentProvider">content provider</see>
	/// . This is returned by
	/// <see cref="PackageManager.resolveContentProvider(string, int)">PackageManager.resolveContentProvider()
	/// 	</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class ProviderInfo : android.content.pm.ComponentInfo, android.os.Parcelable
	{
		/// <summary>The name provider is published under content://</summary>
		public string authority = null;

		/// <summary>
		/// Optional permission required for read-only access this content
		/// provider.
		/// </summary>
		/// <remarks>
		/// Optional permission required for read-only access this content
		/// provider.
		/// </remarks>
		public string readPermission = null;

		/// <summary>
		/// Optional permission required for read/write access this content
		/// provider.
		/// </summary>
		/// <remarks>
		/// Optional permission required for read/write access this content
		/// provider.
		/// </remarks>
		public string writePermission = null;

		/// <summary>
		/// If true, additional permissions to specific Uris in this content
		/// provider can be granted, as per the
		/// <see cref="android.R.styleable.AndroidManifestProvider_grantUriPermissions">grantUriPermissions
		/// 	</see>
		/// attribute.
		/// </summary>
		public bool grantUriPermissions = false;

		/// <summary>
		/// If non-null, these are the patterns that are allowed for granting URI
		/// permissions.
		/// </summary>
		/// <remarks>
		/// If non-null, these are the patterns that are allowed for granting URI
		/// permissions.  Any URI that does not match one of these patterns will not
		/// allowed to be granted.  If null, all URIs are allowed.  The
		/// <see cref="PackageManager.GET_URI_PERMISSION_PATTERNS">PackageManager.GET_URI_PERMISSION_PATTERNS
		/// 	</see>
		/// flag must be specified for
		/// this field to be filled in.
		/// </remarks>
		public android.os.PatternMatcher[] uriPermissionPatterns = null;

		/// <summary>
		/// If non-null, these are path-specific permissions that are allowed for
		/// accessing the provider.
		/// </summary>
		/// <remarks>
		/// If non-null, these are path-specific permissions that are allowed for
		/// accessing the provider.  Any permissions listed here will allow a
		/// holding client to access the provider, and the provider will check
		/// the URI it provides when making calls against the patterns here.
		/// </remarks>
		public android.content.pm.PathPermission[] pathPermissions = null;

		/// <summary>
		/// If true, this content provider allows multiple instances of itself
		/// to run in different process.
		/// </summary>
		/// <remarks>
		/// If true, this content provider allows multiple instances of itself
		/// to run in different process.  If false, a single instances is always
		/// run in
		/// <see cref="ComponentInfo.processName">ComponentInfo.processName</see>
		/// .
		/// </remarks>
		public bool multiprocess = false;

		/// <summary>
		/// Used to control initialization order of single-process providers
		/// running in the same process.
		/// </summary>
		/// <remarks>
		/// Used to control initialization order of single-process providers
		/// running in the same process.  Higher goes first.
		/// </remarks>
		public int initOrder = 0;

		/// <summary>Whether or not this provider is syncable.</summary>
		/// <remarks>Whether or not this provider is syncable.</remarks>
		[System.ObsoleteAttribute(@"This flag is now being ignored. The current way to make a provider syncable is to provide a SyncAdapter service for a given provider/account type."
			)]
		public bool isSyncable = false;

		public ProviderInfo()
		{
		}

		public ProviderInfo(android.content.pm.ProviderInfo orig) : base(orig)
		{
			authority = orig.authority;
			readPermission = orig.readPermission;
			writePermission = orig.writePermission;
			grantUriPermissions = orig.grantUriPermissions;
			uriPermissionPatterns = orig.uriPermissionPatterns;
			pathPermissions = orig.pathPermissions;
			multiprocess = orig.multiprocess;
			initOrder = orig.initOrder;
			isSyncable = orig.isSyncable;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override void writeToParcel(android.os.Parcel @out, int parcelableFlags)
		{
			base.writeToParcel(@out, parcelableFlags);
			@out.writeString(authority);
			@out.writeString(readPermission);
			@out.writeString(writePermission);
			@out.writeInt(grantUriPermissions ? 1 : 0);
			@out.writeTypedArray(uriPermissionPatterns, parcelableFlags);
			@out.writeTypedArray(pathPermissions, parcelableFlags);
			@out.writeInt(multiprocess ? 1 : 0);
			@out.writeInt(initOrder);
			@out.writeInt(isSyncable ? 1 : 0);
		}

		private sealed class _Creator_119 : android.os.ParcelableClass.Creator<android.content.pm.ProviderInfo
			>
		{
			public _Creator_119()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ProviderInfo createFromParcel(android.os.Parcel @in)
			{
				return new android.content.pm.ProviderInfo(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ProviderInfo[] newArray(int size)
			{
				return new android.content.pm.ProviderInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ProviderInfo
			> CREATOR = new _Creator_119();

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ContentProviderInfo{name=" + authority + " className=" + name + " isSyncable="
				 + (isSyncable ? "true" : "false") + "}";
		}

		private ProviderInfo(android.os.Parcel @in) : base(@in)
		{
			authority = @in.readString();
			readPermission = @in.readString();
			writePermission = @in.readString();
			grantUriPermissions = @in.readInt() != 0;
			uriPermissionPatterns = @in.createTypedArray(android.os.PatternMatcher.CREATOR);
			pathPermissions = @in.createTypedArray(android.content.pm.PathPermission.CREATOR);
			multiprocess = @in.readInt() != 0;
			initOrder = @in.readInt();
			isSyncable = @in.readInt() != 0;
		}
	}
}
