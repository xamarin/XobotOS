using Sharpen;

namespace android.content.pm
{
	/// <summary>A single feature that can be requested by an application.</summary>
	/// <remarks>
	/// A single feature that can be requested by an application. This corresponds
	/// to information collected from the
	/// AndroidManifest.xml's &lt;uses-feature&gt; tag.
	/// </remarks>
	[Sharpen.Sharpened]
	public class FeatureInfo : android.os.Parcelable
	{
		/// <summary>The name of this feature, for example "android.hardware.camera".</summary>
		/// <remarks>
		/// The name of this feature, for example "android.hardware.camera".  If
		/// this is null, then this is an OpenGL ES version feature as described
		/// in
		/// <see cref="reqGlEsVersion">reqGlEsVersion</see>
		/// .
		/// </remarks>
		public string name;

		/// <summary>
		/// Default value for
		/// <see cref="reqGlEsVersion">reqGlEsVersion</see>
		/// ;
		/// </summary>
		public const int GL_ES_VERSION_UNDEFINED = 0;

		/// <summary>The GLES version used by an application.</summary>
		/// <remarks>
		/// The GLES version used by an application. The upper order 16 bits represent the
		/// major version and the lower order 16 bits the minor version.  Only valid
		/// if
		/// <see cref="name">name</see>
		/// is null.
		/// </remarks>
		public int reqGlEsVersion;

		/// <summary>
		/// Set on
		/// <see cref="flags">flags</see>
		/// if this feature has been required by the application.
		/// </summary>
		public const int FLAG_REQUIRED = unchecked((int)(0x0001));

		/// <summary>Additional flags.</summary>
		/// <remarks>
		/// Additional flags.  May be zero or more of
		/// <see cref="FLAG_REQUIRED">FLAG_REQUIRED</see>
		/// .
		/// </remarks>
		public int flags;

		public FeatureInfo()
		{
		}

		public FeatureInfo(android.content.pm.FeatureInfo orig)
		{
			name = orig.name;
			reqGlEsVersion = orig.reqGlEsVersion;
			flags = orig.flags;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			if (name != null)
			{
				return "FeatureInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " " + name + " fl=0x" + Sharpen.Util.IntToHexString(flags) + "}";
			}
			else
			{
				return "FeatureInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " glEsVers=" + getGlEsVersion() + " fl=0x" + Sharpen.Util.IntToHexString
					(flags) + "}";
			}
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeString(name);
			dest.writeInt(reqGlEsVersion);
			dest.writeInt(flags);
		}

		private sealed class _Creator_91 : android.os.ParcelableClass.Creator<android.content.pm.FeatureInfo
			>
		{
			public _Creator_91()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.FeatureInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.pm.FeatureInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.FeatureInfo[] newArray(int size)
			{
				return new android.content.pm.FeatureInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.FeatureInfo
			> CREATOR = new _Creator_91();

		private FeatureInfo(android.os.Parcel source)
		{
			name = source.readString();
			reqGlEsVersion = source.readInt();
			flags = source.readInt();
		}

		/// <summary>
		/// This method extracts the major and minor version of reqGLEsVersion attribute
		/// and returns it as a string.
		/// </summary>
		/// <remarks>
		/// This method extracts the major and minor version of reqGLEsVersion attribute
		/// and returns it as a string. Say reqGlEsVersion value of 0x00010002 is returned
		/// as 1.2
		/// </remarks>
		/// <returns>String representation of the reqGlEsVersion attribute</returns>
		public virtual string getGlEsVersion()
		{
			int major = ((reqGlEsVersion & unchecked((int)(0xffff0000))) >> 16);
			int minor = reqGlEsVersion & unchecked((int)(0x0000ffff));
			return major.ToString() + "." + minor.ToString();
		}
	}
}
