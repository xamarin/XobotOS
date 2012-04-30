using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Information you can retrieve about a particular piece of test
	/// instrumentation.
	/// </summary>
	/// <remarks>
	/// Information you can retrieve about a particular piece of test
	/// instrumentation.  This corresponds to information collected
	/// from the AndroidManifest.xml's &lt;instrumentation&gt; tag.
	/// </remarks>
	[Sharpen.Sharpened]
	public class InstrumentationInfo : android.content.pm.PackageItemInfo, android.os.Parcelable
	{
		/// <summary>The name of the application package being instrumented.</summary>
		/// <remarks>
		/// The name of the application package being instrumented.  From the
		/// "package" attribute.
		/// </remarks>
		public string targetPackage;

		/// <summary>Full path to the location of this package.</summary>
		/// <remarks>Full path to the location of this package.</remarks>
		public string sourceDir;

		/// <summary>Full path to the location of the publicly available parts of this package (i.e.
		/// 	</summary>
		/// <remarks>
		/// Full path to the location of the publicly available parts of this package (i.e. the resources
		/// and manifest).  For non-forward-locked apps this will be the same as
		/// <see>#sourceDir).</see>
		/// </remarks>
		public string publicSourceDir;

		/// <summary>
		/// Full path to a directory assigned to the package for its persistent
		/// data.
		/// </summary>
		/// <remarks>
		/// Full path to a directory assigned to the package for its persistent
		/// data.
		/// </remarks>
		public string dataDir;

		/// <summary>Full path to the directory where the native JNI libraries are stored.</summary>
		/// <remarks>
		/// Full path to the directory where the native JNI libraries are stored.
		/// <hide></hide>
		/// </remarks>
		public string nativeLibraryDir;

		/// <summary>Specifies whether or not this instrumentation will handle profiling.</summary>
		/// <remarks>Specifies whether or not this instrumentation will handle profiling.</remarks>
		public bool handleProfiling;

		/// <summary>Specifies whether or not to run this instrumentation as a functional test
		/// 	</summary>
		public bool functionalTest;

		public InstrumentationInfo()
		{
		}

		public InstrumentationInfo(android.content.pm.InstrumentationInfo orig) : base(orig
			)
		{
			targetPackage = orig.targetPackage;
			sourceDir = orig.sourceDir;
			publicSourceDir = orig.publicSourceDir;
			dataDir = orig.dataDir;
			nativeLibraryDir = orig.nativeLibraryDir;
			handleProfiling = orig.handleProfiling;
			functionalTest = orig.functionalTest;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "InstrumentationInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " " + packageName + "}";
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
			dest.writeString(targetPackage);
			dest.writeString(sourceDir);
			dest.writeString(publicSourceDir);
			dest.writeString(dataDir);
			dest.writeString(nativeLibraryDir);
			dest.writeInt((handleProfiling == false) ? 0 : 1);
			dest.writeInt((functionalTest == false) ? 0 : 1);
		}

		private sealed class _Creator_105 : android.os.ParcelableClass.Creator<android.content.pm.InstrumentationInfo
			>
		{
			public _Creator_105()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.InstrumentationInfo createFromParcel(android.os.Parcel 
				source)
			{
				return new android.content.pm.InstrumentationInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.InstrumentationInfo[] newArray(int size)
			{
				return new android.content.pm.InstrumentationInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.InstrumentationInfo
			> CREATOR = new _Creator_105();

		private InstrumentationInfo(android.os.Parcel source) : base(source)
		{
			targetPackage = source.readString();
			sourceDir = source.readString();
			publicSourceDir = source.readString();
			dataDir = source.readString();
			nativeLibraryDir = source.readString();
			handleProfiling = source.readInt() != 0;
			functionalTest = source.readInt() != 0;
		}
	}
}
