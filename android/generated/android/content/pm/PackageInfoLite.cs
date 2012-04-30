using Sharpen;

namespace android.content.pm
{
	/// <summary>Basic information about a package as specified in its manifest.</summary>
	/// <remarks>
	/// Basic information about a package as specified in its manifest.
	/// Utility class used in PackageManager methods
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class PackageInfoLite : android.os.Parcelable
	{
		/// <summary>The name of this package.</summary>
		/// <remarks>
		/// The name of this package.  From the &lt;manifest&gt; tag's "name"
		/// attribute.
		/// </remarks>
		public string packageName;

		/// <summary>Specifies the recommended install location.</summary>
		/// <remarks>
		/// Specifies the recommended install location. Can be one of
		/// <see cref="#PackageHelper">#PackageHelper</see>
		/// to install on internal storage
		/// <see cref="#PackageHelper">#PackageHelper</see>
		/// to install on external media
		/// <see cref="PackageHelper.RECOMMEND_FAILED_INSUFFICIENT_STORAGE">PackageHelper.RECOMMEND_FAILED_INSUFFICIENT_STORAGE
		/// 	</see>
		/// for storage errors
		/// <see cref="PackageHelper.RECOMMEND_FAILED_INVALID_APK">PackageHelper.RECOMMEND_FAILED_INVALID_APK
		/// 	</see>
		/// for parse errors.
		/// </remarks>
		public int recommendedInstallLocation;

		public int installLocation;

		public android.content.pm.VerifierInfo[] verifiers;

		public PackageInfoLite()
		{
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "PackageInfoLite{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + packageName + "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeString(packageName);
			dest.writeInt(recommendedInstallLocation);
			dest.writeInt(installLocation);
			if (verifiers == null || verifiers.Length == 0)
			{
				dest.writeInt(0);
			}
			else
			{
				dest.writeInt(verifiers.Length);
				dest.writeTypedArray(verifiers, parcelableFlags);
			}
		}

		private sealed class _Creator_73 : android.os.ParcelableClass.Creator<android.content.pm.PackageInfoLite
			>
		{
			public _Creator_73()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageInfoLite createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.pm.PackageInfoLite(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PackageInfoLite[] newArray(int size)
			{
				return new android.content.pm.PackageInfoLite[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PackageInfoLite
			> CREATOR = new _Creator_73();

		private PackageInfoLite(android.os.Parcel source)
		{
			packageName = source.readString();
			recommendedInstallLocation = source.readInt();
			installLocation = source.readInt();
			int verifiersLength = source.readInt();
			if (verifiersLength == 0)
			{
				verifiers = new android.content.pm.VerifierInfo[0];
			}
			else
			{
				verifiers = new android.content.pm.VerifierInfo[verifiersLength];
				source.readTypedArray(verifiers, android.content.pm.VerifierInfo.CREATOR);
			}
		}
	}
}
