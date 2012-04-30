using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Information you can retrieve about a particular application
	/// service.
	/// </summary>
	/// <remarks>
	/// Information you can retrieve about a particular application
	/// service. This corresponds to information collected from the
	/// AndroidManifest.xml's &lt;service&gt; tags.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ServiceInfo : android.content.pm.ComponentInfo, android.os.Parcelable
	{
		/// <summary>
		/// Optional name of a permission required to be able to access this
		/// Service.
		/// </summary>
		/// <remarks>
		/// Optional name of a permission required to be able to access this
		/// Service.  From the "permission" attribute.
		/// </remarks>
		public string permission;

		/// <summary>
		/// Bit in
		/// <see cref="flags">flags</see>
		/// : If set, the service will automatically be
		/// stopped by the system if the user removes a task that is rooted
		/// in one of the application's activities.  Set from the
		/// <see cref="android.R.attr.stopWithTask">android.R.attr.stopWithTask</see>
		/// attribute.
		/// </summary>
		public const int FLAG_STOP_WITH_TASK = unchecked((int)(0x0001));

		/// <summary>
		/// Options that have been set in the service declaration in the
		/// manifest.
		/// </summary>
		/// <remarks>
		/// Options that have been set in the service declaration in the
		/// manifest.
		/// These include:
		/// <see cref="FLAG_STOP_WITH_TASK">FLAG_STOP_WITH_TASK</see>
		/// </remarks>
		public int flags;

		public ServiceInfo()
		{
		}

		public ServiceInfo(android.content.pm.ServiceInfo orig) : base(orig)
		{
			permission = orig.permission;
			flags = orig.flags;
		}

		public virtual void dump(android.util.Printer pw, string prefix)
		{
			base.dumpFront(pw, prefix);
			pw.println(prefix + "permission=" + permission);
			pw.println(prefix + "flags=0x" + Sharpen.Util.IntToHexString(flags));
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ServiceInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
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
			dest.writeString(permission);
			dest.writeInt(flags);
		}

		private sealed class _Creator_84 : android.os.ParcelableClass.Creator<android.content.pm.ServiceInfo
			>
		{
			public _Creator_84()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ServiceInfo createFromParcel(android.os.Parcel source)
			{
				return new android.content.pm.ServiceInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ServiceInfo[] newArray(int size)
			{
				return new android.content.pm.ServiceInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ServiceInfo
			> CREATOR = new _Creator_84();

		private ServiceInfo(android.os.Parcel source) : base(source)
		{
			permission = source.readString();
			flags = source.readInt();
		}
	}
}
