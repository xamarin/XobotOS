using Sharpen;

namespace android.content.pm
{
	/// <summary>
	/// Information you can retrieve about hardware configuration preferences
	/// declared by an application.
	/// </summary>
	/// <remarks>
	/// Information you can retrieve about hardware configuration preferences
	/// declared by an application. This corresponds to information collected from the
	/// AndroidManifest.xml's &lt;uses-configuration&gt; and &lt;uses-feature&gt; tags.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ConfigurationInfo : android.os.Parcelable
	{
		/// <summary>The kind of touch screen attached to the device.</summary>
		/// <remarks>
		/// The kind of touch screen attached to the device.
		/// One of:
		/// <see cref="android.content.res.Configuration.TOUCHSCREEN_NOTOUCH">android.content.res.Configuration.TOUCHSCREEN_NOTOUCH
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.TOUCHSCREEN_STYLUS">android.content.res.Configuration.TOUCHSCREEN_STYLUS
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.TOUCHSCREEN_FINGER">android.content.res.Configuration.TOUCHSCREEN_FINGER
		/// 	</see>
		/// .
		/// </remarks>
		public int reqTouchScreen;

		/// <summary>Application's input method preference.</summary>
		/// <remarks>
		/// Application's input method preference.
		/// One of:
		/// <see cref="android.content.res.Configuration.KEYBOARD_UNDEFINED">android.content.res.Configuration.KEYBOARD_UNDEFINED
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.KEYBOARD_NOKEYS">android.content.res.Configuration.KEYBOARD_NOKEYS
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.KEYBOARD_QWERTY">android.content.res.Configuration.KEYBOARD_QWERTY
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.KEYBOARD_12KEY">android.content.res.Configuration.KEYBOARD_12KEY
		/// 	</see>
		/// </remarks>
		public int reqKeyboardType;

		/// <summary>A flag indicating whether any keyboard is available.</summary>
		/// <remarks>
		/// A flag indicating whether any keyboard is available.
		/// one of:
		/// <see cref="android.content.res.Configuration.NAVIGATION_UNDEFINED">android.content.res.Configuration.NAVIGATION_UNDEFINED
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.NAVIGATION_DPAD">android.content.res.Configuration.NAVIGATION_DPAD
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.NAVIGATION_TRACKBALL">android.content.res.Configuration.NAVIGATION_TRACKBALL
		/// 	</see>
		/// ,
		/// <see cref="android.content.res.Configuration.NAVIGATION_WHEEL">android.content.res.Configuration.NAVIGATION_WHEEL
		/// 	</see>
		/// </remarks>
		public int reqNavigation;

		/// <summary>
		/// Value for
		/// <see cref="reqInputFeatures">reqInputFeatures</see>
		/// : if set, indicates that the application
		/// requires a hard keyboard
		/// </summary>
		public const int INPUT_FEATURE_HARD_KEYBOARD = unchecked((int)(0x00000001));

		/// <summary>
		/// Value for
		/// <see cref="reqInputFeatures">reqInputFeatures</see>
		/// : if set, indicates that the application
		/// requires a five way navigation device
		/// </summary>
		public const int INPUT_FEATURE_FIVE_WAY_NAV = unchecked((int)(0x00000002));

		/// <summary>Flags associated with the input features.</summary>
		/// <remarks>
		/// Flags associated with the input features.  Any combination of
		/// <see cref="INPUT_FEATURE_HARD_KEYBOARD">INPUT_FEATURE_HARD_KEYBOARD</see>
		/// ,
		/// <see cref="INPUT_FEATURE_FIVE_WAY_NAV">INPUT_FEATURE_FIVE_WAY_NAV</see>
		/// </remarks>
		public int reqInputFeatures = 0;

		/// <summary>
		/// Default value for
		/// <see cref="reqGlEsVersion">reqGlEsVersion</see>
		/// ;
		/// </summary>
		public const int GL_ES_VERSION_UNDEFINED = 0;

		/// <summary>The GLES version used by an application.</summary>
		/// <remarks>
		/// The GLES version used by an application. The upper order 16 bits represent the
		/// major version and the lower order 16 bits the minor version.
		/// </remarks>
		public int reqGlEsVersion;

		public ConfigurationInfo()
		{
		}

		public ConfigurationInfo(android.content.pm.ConfigurationInfo orig)
		{
			reqTouchScreen = orig.reqTouchScreen;
			reqKeyboardType = orig.reqKeyboardType;
			reqNavigation = orig.reqNavigation;
			reqInputFeatures = orig.reqInputFeatures;
			reqGlEsVersion = orig.reqGlEsVersion;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ConfigurationInfo{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
				(this)) + " touchscreen = " + reqTouchScreen + " inputMethod = " + reqKeyboardType
				 + " navigation = " + reqNavigation + " reqInputFeatures = " + reqInputFeatures 
				+ " reqGlEsVersion = " + reqGlEsVersion + "}";
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int parcelableFlags)
		{
			dest.writeInt(reqTouchScreen);
			dest.writeInt(reqKeyboardType);
			dest.writeInt(reqNavigation);
			dest.writeInt(reqInputFeatures);
			dest.writeInt(reqGlEsVersion);
		}

		private sealed class _Creator_117 : android.os.ParcelableClass.Creator<android.content.pm.ConfigurationInfo
			>
		{
			public _Creator_117()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ConfigurationInfo createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.pm.ConfigurationInfo(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.pm.ConfigurationInfo[] newArray(int size)
			{
				return new android.content.pm.ConfigurationInfo[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.pm.ConfigurationInfo
			> CREATOR = new _Creator_117();

		private ConfigurationInfo(android.os.Parcel source)
		{
			reqTouchScreen = source.readInt();
			reqKeyboardType = source.readInt();
			reqNavigation = source.readInt();
			reqInputFeatures = source.readInt();
			reqGlEsVersion = source.readInt();
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
