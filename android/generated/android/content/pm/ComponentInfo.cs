using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Base class containing information common to all application components
	/// (
	/// <see cref="ActivityInfo">ActivityInfo</see>
	/// ,
	/// <see cref="ServiceInfo">ServiceInfo</see>
	/// ).  This class is not intended
	/// to be used by itself; it is simply here to share common definitions
	/// between all application components.  As such, it does not itself
	/// implement Parcelable, but does provide convenience methods to assist
	/// in the implementation of Parcelable in subclasses.
	/// </summary>
	[Sharpen.Sharpened]
	public class ComponentInfo : android.content.pm.PackageItemInfo
	{
		/// <summary>
		/// Global information about the application/package this component is a
		/// part of.
		/// </summary>
		/// <remarks>
		/// Global information about the application/package this component is a
		/// part of.
		/// </remarks>
		public android.content.pm.ApplicationInfo applicationInfo;

		/// <summary>The name of the process this component should run in.</summary>
		/// <remarks>
		/// The name of the process this component should run in.
		/// From the "android:process" attribute or, if not set, the same
		/// as <var>applicationInfo.processName</var>.
		/// </remarks>
		public string processName;

		/// <summary>
		/// A string resource identifier (in the package's resources) containing
		/// a user-readable description of the component.
		/// </summary>
		/// <remarks>
		/// A string resource identifier (in the package's resources) containing
		/// a user-readable description of the component.  From the "description"
		/// attribute or, if not set, 0.
		/// </remarks>
		public int descriptionRes;

		/// <summary>Indicates whether or not this component may be instantiated.</summary>
		/// <remarks>
		/// Indicates whether or not this component may be instantiated.  Note that this value can be
		/// overriden by the one in its parent
		/// <see cref="ApplicationInfo">ApplicationInfo</see>
		/// .
		/// </remarks>
		public bool enabled = true;

		/// <summary>Set to true if this component is available for use by other applications.
		/// 	</summary>
		/// <remarks>
		/// Set to true if this component is available for use by other applications.
		/// Comes from
		/// <see cref="android.R.attr.exported">android:exported</see>
		/// of the
		/// &lt;activity&gt;, &lt;receiver&gt;, &lt;service&gt;, or
		/// &lt;provider&gt; tag.
		/// </remarks>
		public bool exported = false;

		public ComponentInfo()
		{
		}

		public ComponentInfo(android.content.pm.ComponentInfo orig) : base(orig)
		{
			applicationInfo = orig.applicationInfo;
			processName = orig.processName;
			descriptionRes = orig.descriptionRes;
			enabled = orig.enabled;
			exported = orig.exported;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override java.lang.CharSequence loadLabel(android.content.pm.PackageManager
			 pm)
		{
			if (nonLocalizedLabel != null)
			{
				return nonLocalizedLabel;
			}
			android.content.pm.ApplicationInfo ai = applicationInfo;
			java.lang.CharSequence label;
			if (labelRes != 0)
			{
				label = pm.getText(packageName, labelRes, ai);
				if (label != null)
				{
					return label;
				}
			}
			if (ai.nonLocalizedLabel != null)
			{
				return ai.nonLocalizedLabel;
			}
			if (ai.labelRes != 0)
			{
				label = pm.getText(packageName, ai.labelRes, ai);
				if (label != null)
				{
					return label;
				}
			}
			return java.lang.CharSequenceProxy.Wrap(name);
		}

		/// <summary>Return whether this component and its enclosing application are enabled.
		/// 	</summary>
		/// <remarks>Return whether this component and its enclosing application are enabled.
		/// 	</remarks>
		public virtual bool isEnabled()
		{
			return enabled && applicationInfo.enabled;
		}

		/// <summary>Return the icon resource identifier to use for this component.</summary>
		/// <remarks>
		/// Return the icon resource identifier to use for this component.  If
		/// the component defines an icon, that is used; else, the application
		/// icon is used.
		/// </remarks>
		/// <returns>The icon associated with this component.</returns>
		public int getIconResource()
		{
			return icon != 0 ? icon : applicationInfo.icon;
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override void dumpFront(android.util.Printer pw, string prefix
			)
		{
			base.dumpFront(pw, prefix);
			pw.println(prefix + "enabled=" + enabled + " exported=" + exported + " processName="
				 + processName);
			if (descriptionRes != 0)
			{
				pw.println(prefix + "description=" + descriptionRes);
			}
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override void dumpBack(android.util.Printer pw, string prefix)
		{
			if (applicationInfo != null)
			{
				pw.println(prefix + "ApplicationInfo:");
				applicationInfo.dump(pw, prefix + "  ");
			}
			else
			{
				pw.println(prefix + "ApplicationInfo: null");
			}
			base.dumpBack(pw, prefix);
		}

		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		public override void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			base.writeToParcel(dest, parcelableFlags);
			applicationInfo.writeToParcel(dest, parcelableFlags);
			dest.writeString(processName);
			dest.writeInt(descriptionRes);
			dest.writeInt(enabled ? 1 : 0);
			dest.writeInt(exported ? 1 : 0);
		}

		protected internal ComponentInfo(android.os.Parcel source) : base(source)
		{
			applicationInfo = android.content.pm.ApplicationInfo.CREATOR.createFromParcel(source
				);
			processName = source.readString();
			descriptionRes = source.readInt();
			enabled = (source.readInt() != 0);
			exported = (source.readInt() != 0);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override android.graphics.drawable.Drawable loadDefaultIcon(android.content.pm.PackageManager
			 pm)
		{
			return applicationInfo.loadIcon(pm);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override android.graphics.drawable.Drawable loadDefaultLogo(android.content.pm.PackageManager
			 pm)
		{
			return applicationInfo.loadLogo(pm);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.content.pm.PackageItemInfo")]
		protected internal override android.content.pm.ApplicationInfo getApplicationInfo
			()
		{
			return applicationInfo;
		}
	}
}
