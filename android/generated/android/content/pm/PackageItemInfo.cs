using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Base class containing information common to all package items held by
	/// the package manager.
	/// </summary>
	/// <remarks>
	/// Base class containing information common to all package items held by
	/// the package manager.  This provides a very common basic set of attributes:
	/// a label, icon, and meta-data.  This class is not intended
	/// to be used by itself; it is simply here to share common definitions
	/// between all items returned by the package manager.  As such, it does not
	/// itself implement Parcelable, but does provide convenience methods to assist
	/// in the implementation of Parcelable in subclasses.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PackageItemInfo
	{
		/// <summary>Public name of this item.</summary>
		/// <remarks>Public name of this item. From the "android:name" attribute.</remarks>
		public string name;

		/// <summary>Name of the package that this item is in.</summary>
		/// <remarks>Name of the package that this item is in.</remarks>
		public string packageName;

		/// <summary>
		/// A string resource identifier (in the package's resources) of this
		/// component's label.
		/// </summary>
		/// <remarks>
		/// A string resource identifier (in the package's resources) of this
		/// component's label.  From the "label" attribute or, if not set, 0.
		/// </remarks>
		public int labelRes;

		/// <summary>The string provided in the AndroidManifest file, if any.</summary>
		/// <remarks>
		/// The string provided in the AndroidManifest file, if any.  You
		/// probably don't want to use this.  You probably want
		/// <see cref="PackageManager.getApplicationLabel(ApplicationInfo)">PackageManager.getApplicationLabel(ApplicationInfo)
		/// 	</see>
		/// </remarks>
		public java.lang.CharSequence nonLocalizedLabel;

		/// <summary>
		/// A drawable resource identifier (in the package's resources) of this
		/// component's icon.
		/// </summary>
		/// <remarks>
		/// A drawable resource identifier (in the package's resources) of this
		/// component's icon.  From the "icon" attribute or, if not set, 0.
		/// </remarks>
		public int icon;

		/// <summary>
		/// A drawable resource identifier (in the package's resources) of this
		/// component's logo.
		/// </summary>
		/// <remarks>
		/// A drawable resource identifier (in the package's resources) of this
		/// component's logo. Logos may be larger/wider than icons and are
		/// displayed by certain UI elements in place of a name or name/icon
		/// combination. From the "logo" attribute or, if not set, 0.
		/// </remarks>
		public int logo;

		/// <summary>Additional meta-data associated with this component.</summary>
		/// <remarks>
		/// Additional meta-data associated with this component.  This field
		/// will only be filled in if you set the
		/// <see cref="PackageManager.GET_META_DATA">PackageManager.GET_META_DATA</see>
		/// flag when requesting the info.
		/// </remarks>
		public android.os.Bundle metaData;

		public PackageItemInfo()
		{
		}

		public PackageItemInfo(android.content.pm.PackageItemInfo orig)
		{
			name = orig.name;
			if (name != null)
			{
				name = name.Trim();
			}
			packageName = orig.packageName;
			labelRes = orig.labelRes;
			nonLocalizedLabel = orig.nonLocalizedLabel;
			if (nonLocalizedLabel != null)
			{
				nonLocalizedLabel = java.lang.CharSequenceProxy.Wrap(nonLocalizedLabel.ToString()
					.Trim());
			}
			icon = orig.icon;
			logo = orig.logo;
			metaData = orig.metaData;
		}

		/// <summary>Retrieve the current textual label associated with this item.</summary>
		/// <remarks>
		/// Retrieve the current textual label associated with this item.  This
		/// will call back on the given PackageManager to load the label from
		/// the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the label can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a CharSequence containing the item's label.  If the
		/// item does not have a label, its name is returned.
		/// </returns>
		public virtual java.lang.CharSequence loadLabel(android.content.pm.PackageManager
			 pm)
		{
			if (nonLocalizedLabel != null)
			{
				return nonLocalizedLabel;
			}
			if (labelRes != 0)
			{
				java.lang.CharSequence label = pm.getText(packageName, labelRes, getApplicationInfo
					());
				if (label != null)
				{
					return java.lang.CharSequenceProxy.Wrap(label.ToString().Trim());
				}
			}
			if (name != null)
			{
				return java.lang.CharSequenceProxy.Wrap(name);
			}
			return java.lang.CharSequenceProxy.Wrap(packageName);
		}

		/// <summary>Retrieve the current graphical icon associated with this item.</summary>
		/// <remarks>
		/// Retrieve the current graphical icon associated with this item.  This
		/// will call back on the given PackageManager to load the icon from
		/// the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the icon can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a Drawable containing the item's icon.  If the
		/// item does not have an icon, the item's default icon is returned
		/// such as the default activity icon.
		/// </returns>
		public virtual android.graphics.drawable.Drawable loadIcon(android.content.pm.PackageManager
			 pm)
		{
			if (icon != 0)
			{
				android.graphics.drawable.Drawable dr = pm.getDrawable(packageName, icon, getApplicationInfo
					());
				if (dr != null)
				{
					return dr;
				}
			}
			return loadDefaultIcon(pm);
		}

		/// <summary>Retrieve the default graphical icon associated with this item.</summary>
		/// <remarks>Retrieve the default graphical icon associated with this item.</remarks>
		/// <param name="pm">
		/// A PackageManager from which the icon can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a Drawable containing the item's default icon
		/// such as the default activity icon.
		/// </returns>
		/// <hide></hide>
		protected internal virtual android.graphics.drawable.Drawable loadDefaultIcon(android.content.pm.PackageManager
			 pm)
		{
			return pm.getDefaultActivityIcon();
		}

		/// <summary>Retrieve the current graphical logo associated with this item.</summary>
		/// <remarks>
		/// Retrieve the current graphical logo associated with this item. This
		/// will call back on the given PackageManager to load the logo from
		/// the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the logo can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a Drawable containing the item's logo. If the item
		/// does not have a logo, this method will return null.
		/// </returns>
		public virtual android.graphics.drawable.Drawable loadLogo(android.content.pm.PackageManager
			 pm)
		{
			if (logo != 0)
			{
				android.graphics.drawable.Drawable d = pm.getDrawable(packageName, logo, getApplicationInfo
					());
				if (d != null)
				{
					return d;
				}
			}
			return loadDefaultLogo(pm);
		}

		/// <summary>Retrieve the default graphical logo associated with this item.</summary>
		/// <remarks>Retrieve the default graphical logo associated with this item.</remarks>
		/// <param name="pm">
		/// A PackageManager from which the logo can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <returns>
		/// Returns a Drawable containing the item's default logo
		/// or null if no default logo is available.
		/// </returns>
		/// <hide></hide>
		protected internal virtual android.graphics.drawable.Drawable loadDefaultLogo(android.content.pm.PackageManager
			 pm)
		{
			return null;
		}

		/// <summary>Load an XML resource attached to the meta-data of this item.</summary>
		/// <remarks>
		/// Load an XML resource attached to the meta-data of this item.  This will
		/// retrieved the name meta-data entry, and if defined call back on the
		/// given PackageManager to load its XML file from the application.
		/// </remarks>
		/// <param name="pm">
		/// A PackageManager from which the XML can be loaded; usually
		/// the PackageManager from which you originally retrieved this item.
		/// </param>
		/// <param name="name">Name of the meta-date you would like to load.</param>
		/// <returns>
		/// Returns an XmlPullParser you can use to parse the XML file
		/// assigned as the given meta-data.  If the meta-data name is not defined
		/// or the XML resource could not be found, null is returned.
		/// </returns>
		public virtual android.content.res.XmlResourceParser loadXmlMetaData(android.content.pm.PackageManager
			 pm, string name)
		{
			if (metaData != null)
			{
				int resid = metaData.getInt(name);
				if (resid != 0)
				{
					return pm.getXml(packageName, resid, getApplicationInfo());
				}
			}
			return null;
		}

		protected internal virtual void dumpFront(android.util.Printer pw, string prefix)
		{
			if (name != null)
			{
				pw.println(prefix + "name=" + name);
			}
			pw.println(prefix + "packageName=" + packageName);
			if (labelRes != 0 || nonLocalizedLabel != null || icon != 0)
			{
				pw.println(prefix + "labelRes=0x" + Sharpen.Util.IntToHexString(labelRes) + " nonLocalizedLabel="
					 + nonLocalizedLabel + " icon=0x" + Sharpen.Util.IntToHexString(icon));
			}
		}

		protected internal virtual void dumpBack(android.util.Printer pw, string prefix)
		{
		}

		// no back here
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeString(name);
			dest.writeString(packageName);
			dest.writeInt(labelRes);
			android.text.TextUtils.writeToParcel(nonLocalizedLabel, dest, parcelableFlags);
			dest.writeInt(icon);
			dest.writeInt(logo);
			dest.writeBundle(metaData);
		}

		protected internal PackageItemInfo(android.os.Parcel source)
		{
			name = source.readString();
			packageName = source.readString();
			labelRes = source.readInt();
			nonLocalizedLabel = android.text.TextUtils.CHAR_SEQUENCE_CREATOR.createFromParcel
				(source);
			icon = source.readInt();
			logo = source.readInt();
			metaData = source.readBundle();
		}

		/// <summary>
		/// Get the ApplicationInfo for the application to which this item belongs,
		/// if available, otherwise returns null.
		/// </summary>
		/// <remarks>
		/// Get the ApplicationInfo for the application to which this item belongs,
		/// if available, otherwise returns null.
		/// </remarks>
		/// <returns>Returns the ApplicationInfo of this item, or null if not known.</returns>
		/// <hide></hide>
		protected internal virtual android.content.pm.ApplicationInfo getApplicationInfo(
			)
		{
			return null;
		}

		public class DisplayNameComparator : java.util.Comparator<android.content.pm.PackageItemInfo
			>
		{
			public DisplayNameComparator(android.content.pm.PackageManager pm)
			{
				mPM = pm;
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public virtual int compare(android.content.pm.PackageItemInfo aa, android.content.pm.PackageItemInfo
				 ab)
			{
				java.lang.CharSequence sa = aa.loadLabel(mPM);
				if (sa == null)
				{
					sa = java.lang.CharSequenceProxy.Wrap(aa.name);
				}
				java.lang.CharSequence sb = ab.loadLabel(mPM);
				if (sb == null)
				{
					sb = java.lang.CharSequenceProxy.Wrap(ab.name);
				}
				return sCollator.compare(sa.ToString(), sb.ToString());
			}

			private readonly java.text.Collator sCollator = java.text.Collator.getInstance();

			private android.content.pm.PackageManager mPM;
		}
	}
}
