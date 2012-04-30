using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Information you can retrieve about a particular security permission
	/// known to the system.
	/// </summary>
	/// <remarks>
	/// Information you can retrieve about a particular security permission
	/// known to the system.  This corresponds to information collected from the
	/// AndroidManifest.xml's &lt;permission&gt; tags.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PermissionInfo : android.content.pm.PackageItemInfo, android.os.Parcelable
	{
		/// <summary>
		/// A normal application value for
		/// <see cref="protectionLevel">protectionLevel</see>
		/// , corresponding
		/// to the <code>normal</code> value of
		/// <see cref="android.R.attr.protectionLevel">android.R.attr.protectionLevel</see>
		/// .
		/// </summary>
		public const int PROTECTION_NORMAL = 0;

		/// <summary>
		/// Dangerous value for
		/// <see cref="protectionLevel">protectionLevel</see>
		/// , corresponding
		/// to the <code>dangerous</code> value of
		/// <see cref="android.R.attr.protectionLevel">android.R.attr.protectionLevel</see>
		/// .
		/// </summary>
		public const int PROTECTION_DANGEROUS = 1;

		/// <summary>
		/// System-level value for
		/// <see cref="protectionLevel">protectionLevel</see>
		/// , corresponding
		/// to the <code>signature</code> value of
		/// <see cref="android.R.attr.protectionLevel">android.R.attr.protectionLevel</see>
		/// .
		/// </summary>
		public const int PROTECTION_SIGNATURE = 2;

		/// <summary>
		/// System-level value for
		/// <see cref="protectionLevel">protectionLevel</see>
		/// , corresponding
		/// to the <code>signatureOrSystem</code> value of
		/// <see cref="android.R.attr.protectionLevel">android.R.attr.protectionLevel</see>
		/// .
		/// </summary>
		public const int PROTECTION_SIGNATURE_OR_SYSTEM = 3;

		/// <summary>
		/// The group this permission is a part of, as per
		/// <see cref="android.R.attr.permissionGroup">android.R.attr.permissionGroup</see>
		/// .
		/// </summary>
		public string group;

		/// <summary>
		/// A string resource identifier (in the package's resources) of this
		/// permission's description.
		/// </summary>
		/// <remarks>
		/// A string resource identifier (in the package's resources) of this
		/// permission's description.  From the "description" attribute or,
		/// if not set, 0.
		/// </remarks>
		public int descriptionRes;

		/// <summary>The description string provided in the AndroidManifest file, if any.</summary>
		/// <remarks>
		/// The description string provided in the AndroidManifest file, if any.  You
		/// probably don't want to use this, since it will be null if the description
		/// is in a resource.  You probably want
		/// <see cref="loadDescription(PackageManager)">loadDescription(PackageManager)</see>
		/// instead.
		/// </remarks>
		public java.lang.CharSequence nonLocalizedDescription;

		/// <summary>
		/// The level of access this permission is protecting, as per
		/// <see cref="android.R.attr.protectionLevel">android.R.attr.protectionLevel</see>
		/// .  Values may be
		/// <see cref="PROTECTION_NORMAL">PROTECTION_NORMAL</see>
		/// ,
		/// <see cref="PROTECTION_DANGEROUS">PROTECTION_DANGEROUS</see>
		/// , or
		/// <see cref="PROTECTION_SIGNATURE">PROTECTION_SIGNATURE</see>
		/// .
		/// </summary>
		public int protectionLevel;

		public PermissionInfo()
		{
		}

		public PermissionInfo(android.content.pm.PermissionInfo orig) : base(orig)
		{
			group = orig.group;
			descriptionRes = orig.descriptionRes;
			protectionLevel = orig.protectionLevel;
			nonLocalizedDescription = orig.nonLocalizedDescription;
		}

		/// <summary>Retrieve the textual description of this permission.</summary>
		/// <remarks>
		/// Retrieve the textual description of this permission.  This
		/// will call back on the given PackageManager to load the description from
		/// the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the label can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a CharSequence containing the permission's description.
		/// If there is no description, null is returned.
		/// </returns>
		public virtual java.lang.CharSequence loadDescription(android.content.pm.PackageManager
			 pm)
		{
			if (nonLocalizedDescription != null)
			{
				return nonLocalizedDescription;
			}
			if (descriptionRes != 0)
			{
				java.lang.CharSequence label = pm.getText(packageName, descriptionRes, null);
				if (label != null)
				{
					return label;
				}
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "PermissionInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + name + "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			base.writeToParcel(dest, parcelableFlags);
			dest.writeString(group);
			dest.writeInt(descriptionRes);
			dest.writeInt(protectionLevel);
			android.text.TextUtils.writeToParcel(nonLocalizedDescription, dest, parcelableFlags
				);
		}

		private sealed class _Creator_140 : android.os.ParcelableClass.Creator<android.content.pm.PermissionInfo
			>
		{
			public _Creator_140()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PermissionInfo createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.pm.PermissionInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.PermissionInfo[] newArray(int size)
			{
				return new android.content.pm.PermissionInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.PermissionInfo
			> CREATOR = new _Creator_140();

		private PermissionInfo(android.os.Parcel source) : base(source)
		{
			group = source.readString();
			descriptionRes = source.readInt();
			protectionLevel = source.readInt();
			nonLocalizedDescription = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel
				(source);
		}
	}
}
