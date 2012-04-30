using Sharpen;

namespace android.content.res
{
	/// <summary>
	/// This class describes all device configuration information that can
	/// impact the resources the application retrieves.
	/// </summary>
	/// <remarks>
	/// This class describes all device configuration information that can
	/// impact the resources the application retrieves.  This includes both
	/// user-specified configuration options (locale and scaling) as well
	/// as device configurations (such as input modes, screen size and screen orientation).
	/// <p>You can acquire this object from
	/// <see cref="Resources">Resources</see>
	/// , using
	/// <see cref="Resources.getConfiguration()">Resources.getConfiguration()</see>
	/// . Thus, from an activity, you can get it by chaining the request
	/// with
	/// <see cref="android.content.ContextWrapper.getResources()">android.content.ContextWrapper.getResources()
	/// 	</see>
	/// :</p>
	/// <pre>Configuration config = getResources().getConfiguration();</pre>
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class Configuration : android.os.Parcelable, java.lang.Comparable<android.content.res.Configuration
		>
	{
		/// <summary>
		/// Current user preference for the scaling factor for fonts, relative
		/// to the base density scaling.
		/// </summary>
		/// <remarks>
		/// Current user preference for the scaling factor for fonts, relative
		/// to the base density scaling.
		/// </remarks>
		public float fontScale;

		/// <summary>IMSI MCC (Mobile Country Code).</summary>
		/// <remarks>IMSI MCC (Mobile Country Code).  0 if undefined.</remarks>
		public int mcc;

		/// <summary>IMSI MNC (Mobile Network Code).</summary>
		/// <remarks>IMSI MNC (Mobile Network Code).  0 if undefined.</remarks>
		public int mnc;

		/// <summary>Current user preference for the locale.</summary>
		/// <remarks>Current user preference for the locale.</remarks>
		public System.Globalization.CultureInfo locale;

		/// <summary>Locale should persist on setting.</summary>
		/// <remarks>
		/// Locale should persist on setting.  This is hidden because it is really
		/// questionable whether this is the right way to expose the functionality.
		/// </remarks>
		/// <hide></hide>
		public bool userSetLocale;

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : bits that encode the size.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_MASK = unchecked((int)(0x0f));

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : a
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// value indicating that no size has been set.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_UNDEFINED = unchecked((int)(0x00));

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : a
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// value indicating the screen is at least approximately 320x426 dp units.
		/// See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/practices/screens_support.html"&gt;Supporting
		/// Multiple Screens</a> for more information.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_SMALL = unchecked((int)(0x01));

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : a
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// value indicating the screen is at least approximately 320x470 dp units.
		/// See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/practices/screens_support.html"&gt;Supporting
		/// Multiple Screens</a> for more information.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_NORMAL = unchecked((int)(0x02));

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : a
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// value indicating the screen is at least approximately 480x640 dp units.
		/// See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/practices/screens_support.html"&gt;Supporting
		/// Multiple Screens</a> for more information.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_LARGE = unchecked((int)(0x03));

		/// <summary>
		/// Constant for
		/// <see cref="screenLayout">screenLayout</see>
		/// : a
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// value indicating the screen is at least approximately 720x960 dp units.
		/// See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/practices/screens_support.html"&gt;Supporting
		/// Multiple Screens</a> for more information.
		/// </summary>
		public const int SCREENLAYOUT_SIZE_XLARGE = unchecked((int)(0x04));

		public const int SCREENLAYOUT_LONG_MASK = unchecked((int)(0x30));

		public const int SCREENLAYOUT_LONG_UNDEFINED = unchecked((int)(0x00));

		public const int SCREENLAYOUT_LONG_NO = unchecked((int)(0x10));

		public const int SCREENLAYOUT_LONG_YES = unchecked((int)(0x20));

		/// <summary>
		/// Special flag we generate to indicate that the screen layout requires
		/// us to use a compatibility mode for apps that are not modern layout
		/// aware.
		/// </summary>
		/// <remarks>
		/// Special flag we generate to indicate that the screen layout requires
		/// us to use a compatibility mode for apps that are not modern layout
		/// aware.
		/// </remarks>
		/// <hide></hide>
		public const int SCREENLAYOUT_COMPAT_NEEDED = unchecked((int)(0x10000000));

		/// <summary>Bit mask of overall layout of the screen.</summary>
		/// <remarks>
		/// Bit mask of overall layout of the screen.  Currently there are two
		/// fields:
		/// <p>The
		/// <see cref="SCREENLAYOUT_SIZE_MASK">SCREENLAYOUT_SIZE_MASK</see>
		/// bits define the overall size
		/// of the screen.  They may be one of
		/// <see cref="SCREENLAYOUT_SIZE_SMALL">SCREENLAYOUT_SIZE_SMALL</see>
		/// ,
		/// <see cref="SCREENLAYOUT_SIZE_NORMAL">SCREENLAYOUT_SIZE_NORMAL</see>
		/// ,
		/// <see cref="SCREENLAYOUT_SIZE_LARGE">SCREENLAYOUT_SIZE_LARGE</see>
		/// , or
		/// <see cref="SCREENLAYOUT_SIZE_XLARGE">SCREENLAYOUT_SIZE_XLARGE</see>
		/// .
		/// <p>The
		/// <see cref="SCREENLAYOUT_LONG_MASK">SCREENLAYOUT_LONG_MASK</see>
		/// defines whether the screen
		/// is wider/taller than normal.  They may be one of
		/// <see cref="SCREENLAYOUT_LONG_NO">SCREENLAYOUT_LONG_NO</see>
		/// or
		/// <see cref="SCREENLAYOUT_LONG_YES">SCREENLAYOUT_LONG_YES</see>
		/// .
		/// <p>See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/practices/screens_support.html"&gt;Supporting
		/// Multiple Screens</a> for more information.
		/// </remarks>
		public int screenLayout;

		/// <summary>
		/// Check if the Configuration's current
		/// <see cref="screenLayout">screenLayout</see>
		/// is at
		/// least the given size.
		/// </summary>
		/// <param name="size">
		/// The desired size, either
		/// <see cref="SCREENLAYOUT_SIZE_SMALL">SCREENLAYOUT_SIZE_SMALL</see>
		/// ,
		/// <see cref="SCREENLAYOUT_SIZE_NORMAL">SCREENLAYOUT_SIZE_NORMAL</see>
		/// ,
		/// <see cref="SCREENLAYOUT_SIZE_LARGE">SCREENLAYOUT_SIZE_LARGE</see>
		/// , or
		/// <see cref="SCREENLAYOUT_SIZE_XLARGE">SCREENLAYOUT_SIZE_XLARGE</see>
		/// .
		/// </param>
		/// <returns>
		/// Returns true if the current screen layout size is at least
		/// the given size.
		/// </returns>
		public bool isLayoutSizeAtLeast(int size)
		{
			int cur = screenLayout & SCREENLAYOUT_SIZE_MASK;
			if (cur == SCREENLAYOUT_SIZE_UNDEFINED)
			{
				return false;
			}
			return cur >= size;
		}

		public const int TOUCHSCREEN_UNDEFINED = 0;

		public const int TOUCHSCREEN_NOTOUCH = 1;

		public const int TOUCHSCREEN_STYLUS = 2;

		public const int TOUCHSCREEN_FINGER = 3;

		/// <summary>The kind of touch screen attached to the device.</summary>
		/// <remarks>
		/// The kind of touch screen attached to the device.
		/// One of:
		/// <see cref="TOUCHSCREEN_NOTOUCH">TOUCHSCREEN_NOTOUCH</see>
		/// ,
		/// <see cref="TOUCHSCREEN_STYLUS">TOUCHSCREEN_STYLUS</see>
		/// ,
		/// <see cref="TOUCHSCREEN_FINGER">TOUCHSCREEN_FINGER</see>
		/// .
		/// </remarks>
		public int touchscreen;

		public const int KEYBOARD_UNDEFINED = 0;

		public const int KEYBOARD_NOKEYS = 1;

		public const int KEYBOARD_QWERTY = 2;

		public const int KEYBOARD_12KEY = 3;

		/// <summary>The kind of keyboard attached to the device.</summary>
		/// <remarks>
		/// The kind of keyboard attached to the device.
		/// One of:
		/// <see cref="KEYBOARD_NOKEYS">KEYBOARD_NOKEYS</see>
		/// ,
		/// <see cref="KEYBOARD_QWERTY">KEYBOARD_QWERTY</see>
		/// ,
		/// <see cref="KEYBOARD_12KEY">KEYBOARD_12KEY</see>
		/// .
		/// </remarks>
		public int keyboard;

		public const int KEYBOARDHIDDEN_UNDEFINED = 0;

		public const int KEYBOARDHIDDEN_NO = 1;

		public const int KEYBOARDHIDDEN_YES = 2;

		/// <summary>Constant matching actual resource implementation.</summary>
		/// <remarks>
		/// Constant matching actual resource implementation.
		/// <hide></hide>
		/// 
		/// </remarks>
		public const int KEYBOARDHIDDEN_SOFT = 3;

		/// <summary>A flag indicating whether any keyboard is available.</summary>
		/// <remarks>
		/// A flag indicating whether any keyboard is available.  Unlike
		/// <see cref="hardKeyboardHidden">hardKeyboardHidden</see>
		/// , this also takes into account a soft
		/// keyboard, so if the hard keyboard is hidden but there is soft
		/// keyboard available, it will be set to NO.  Value is one of:
		/// <see cref="KEYBOARDHIDDEN_NO">KEYBOARDHIDDEN_NO</see>
		/// ,
		/// <see cref="KEYBOARDHIDDEN_YES">KEYBOARDHIDDEN_YES</see>
		/// .
		/// </remarks>
		public int keyboardHidden;

		public const int HARDKEYBOARDHIDDEN_UNDEFINED = 0;

		public const int HARDKEYBOARDHIDDEN_NO = 1;

		public const int HARDKEYBOARDHIDDEN_YES = 2;

		/// <summary>A flag indicating whether the hard keyboard has been hidden.</summary>
		/// <remarks>
		/// A flag indicating whether the hard keyboard has been hidden.  This will
		/// be set on a device with a mechanism to hide the keyboard from the
		/// user, when that mechanism is closed.  One of:
		/// <see cref="HARDKEYBOARDHIDDEN_NO">HARDKEYBOARDHIDDEN_NO</see>
		/// ,
		/// <see cref="HARDKEYBOARDHIDDEN_YES">HARDKEYBOARDHIDDEN_YES</see>
		/// .
		/// </remarks>
		public int hardKeyboardHidden;

		public const int NAVIGATION_UNDEFINED = 0;

		public const int NAVIGATION_NONAV = 1;

		public const int NAVIGATION_DPAD = 2;

		public const int NAVIGATION_TRACKBALL = 3;

		public const int NAVIGATION_WHEEL = 4;

		/// <summary>The kind of navigation method available on the device.</summary>
		/// <remarks>
		/// The kind of navigation method available on the device.
		/// One of:
		/// <see cref="NAVIGATION_NONAV">NAVIGATION_NONAV</see>
		/// ,
		/// <see cref="NAVIGATION_DPAD">NAVIGATION_DPAD</see>
		/// ,
		/// <see cref="NAVIGATION_TRACKBALL">NAVIGATION_TRACKBALL</see>
		/// ,
		/// <see cref="NAVIGATION_WHEEL">NAVIGATION_WHEEL</see>
		/// .
		/// </remarks>
		public int navigation;

		public const int NAVIGATIONHIDDEN_UNDEFINED = 0;

		public const int NAVIGATIONHIDDEN_NO = 1;

		public const int NAVIGATIONHIDDEN_YES = 2;

		/// <summary>A flag indicating whether any 5-way or DPAD navigation available.</summary>
		/// <remarks>
		/// A flag indicating whether any 5-way or DPAD navigation available.
		/// This will be set on a device with a mechanism to hide the navigation
		/// controls from the user, when that mechanism is closed.  One of:
		/// <see cref="NAVIGATIONHIDDEN_NO">NAVIGATIONHIDDEN_NO</see>
		/// ,
		/// <see cref="NAVIGATIONHIDDEN_YES">NAVIGATIONHIDDEN_YES</see>
		/// .
		/// </remarks>
		public int navigationHidden;

		public const int ORIENTATION_UNDEFINED = 0;

		public const int ORIENTATION_PORTRAIT = 1;

		public const int ORIENTATION_LANDSCAPE = 2;

		public const int ORIENTATION_SQUARE = 3;

		/// <summary>Overall orientation of the screen.</summary>
		/// <remarks>
		/// Overall orientation of the screen.  May be one of
		/// <see cref="ORIENTATION_LANDSCAPE">ORIENTATION_LANDSCAPE</see>
		/// ,
		/// <see cref="ORIENTATION_PORTRAIT">ORIENTATION_PORTRAIT</see>
		/// ,
		/// or
		/// <see cref="ORIENTATION_SQUARE">ORIENTATION_SQUARE</see>
		/// .
		/// </remarks>
		public int orientation;

		public const int UI_MODE_TYPE_MASK = unchecked((int)(0x0f));

		public const int UI_MODE_TYPE_UNDEFINED = unchecked((int)(0x00));

		public const int UI_MODE_TYPE_NORMAL = unchecked((int)(0x01));

		public const int UI_MODE_TYPE_DESK = unchecked((int)(0x02));

		public const int UI_MODE_TYPE_CAR = unchecked((int)(0x03));

		public const int UI_MODE_TYPE_TELEVISION = unchecked((int)(0x04));

		public const int UI_MODE_NIGHT_MASK = unchecked((int)(0x30));

		public const int UI_MODE_NIGHT_UNDEFINED = unchecked((int)(0x00));

		public const int UI_MODE_NIGHT_NO = unchecked((int)(0x10));

		public const int UI_MODE_NIGHT_YES = unchecked((int)(0x20));

		/// <summary>Bit mask of the ui mode.</summary>
		/// <remarks>
		/// Bit mask of the ui mode.  Currently there are two fields:
		/// <p>The
		/// <see cref="UI_MODE_TYPE_MASK">UI_MODE_TYPE_MASK</see>
		/// bits define the overall ui mode of the
		/// device. They may be one of
		/// <see cref="UI_MODE_TYPE_UNDEFINED">UI_MODE_TYPE_UNDEFINED</see>
		/// ,
		/// <see cref="UI_MODE_TYPE_NORMAL">UI_MODE_TYPE_NORMAL</see>
		/// ,
		/// <see cref="UI_MODE_TYPE_DESK">UI_MODE_TYPE_DESK</see>
		/// ,
		/// or
		/// <see cref="UI_MODE_TYPE_CAR">UI_MODE_TYPE_CAR</see>
		/// .
		/// <p>The
		/// <see cref="UI_MODE_NIGHT_MASK">UI_MODE_NIGHT_MASK</see>
		/// defines whether the screen
		/// is in a special mode. They may be one of
		/// <see cref="UI_MODE_NIGHT_UNDEFINED">UI_MODE_NIGHT_UNDEFINED</see>
		/// ,
		/// <see cref="UI_MODE_NIGHT_NO">UI_MODE_NIGHT_NO</see>
		/// or
		/// <see cref="UI_MODE_NIGHT_YES">UI_MODE_NIGHT_YES</see>
		/// .
		/// </remarks>
		public int uiMode;

		public const int SCREEN_WIDTH_DP_UNDEFINED = 0;

		/// <summary>The current width of the available screen space, in dp units.</summary>
		/// <remarks>The current width of the available screen space, in dp units.</remarks>
		public int screenWidthDp;

		public const int SCREEN_HEIGHT_DP_UNDEFINED = 0;

		/// <summary>The current height of the available screen space, in dp units.</summary>
		/// <remarks>The current height of the available screen space, in dp units.</remarks>
		public int screenHeightDp;

		public const int SMALLEST_SCREEN_WIDTH_DP_UNDEFINED = 0;

		/// <summary>The smallest screen size an application will see in normal operation.</summary>
		/// <remarks>
		/// The smallest screen size an application will see in normal operation.
		/// This is the smallest value of both screenWidthDp and screenHeightDp
		/// in both portrait and landscape.
		/// </remarks>
		public int smallestScreenWidthDp;

		/// <hide>Hack to get this information from WM to app running in compat mode.</hide>
		public int compatScreenWidthDp;

		/// <hide>Hack to get this information from WM to app running in compat mode.</hide>
		public int compatScreenHeightDp;

		/// <hide>Hack to get this information from WM to app running in compat mode.</hide>
		public int compatSmallestScreenWidthDp;

		/// <hide>The text layout direction associated to the current Locale</hide>
		public int textLayoutDirection;

		/// <hide>Internal book-keeping.</hide>
		public int seq;

		/// <summary>Construct an invalid Configuration.</summary>
		/// <remarks>
		/// Construct an invalid Configuration.  You must call
		/// <see cref="setToDefaults()">setToDefaults()</see>
		/// for this object to be valid.
		/// <more></more>
		/// </remarks>
		public Configuration()
		{
			setToDefaults();
		}

		/// <summary>Makes a deep copy suitable for modification.</summary>
		/// <remarks>Makes a deep copy suitable for modification.</remarks>
		public Configuration(android.content.res.Configuration o)
		{
			setTo(o);
		}

		public void setTo(android.content.res.Configuration o)
		{
			fontScale = o.fontScale;
			mcc = o.mcc;
			mnc = o.mnc;
			if (o.locale != null)
			{
				locale = (System.Globalization.CultureInfo)o.locale.Clone();
				textLayoutDirection = o.textLayoutDirection;
			}
			userSetLocale = o.userSetLocale;
			touchscreen = o.touchscreen;
			keyboard = o.keyboard;
			keyboardHidden = o.keyboardHidden;
			hardKeyboardHidden = o.hardKeyboardHidden;
			navigation = o.navigation;
			navigationHidden = o.navigationHidden;
			orientation = o.orientation;
			screenLayout = o.screenLayout;
			uiMode = o.uiMode;
			screenWidthDp = o.screenWidthDp;
			screenHeightDp = o.screenHeightDp;
			smallestScreenWidthDp = o.smallestScreenWidthDp;
			compatScreenWidthDp = o.compatScreenWidthDp;
			compatScreenHeightDp = o.compatScreenHeightDp;
			compatSmallestScreenWidthDp = o.compatSmallestScreenWidthDp;
			seq = o.seq;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder sb = new java.lang.StringBuilder(128);
			sb.append("{");
			sb.append(fontScale);
			sb.append(" ");
			sb.append(mcc);
			sb.append("mcc");
			sb.append(mnc);
			sb.append("mnc");
			if (locale != null)
			{
				sb.append(" ");
				sb.append(locale);
			}
			else
			{
				sb.append(" (no locale)");
			}
			switch (textLayoutDirection)
			{
				case android.util.LocaleUtil.TEXT_LAYOUT_DIRECTION_RTL_DO_NOT_USE:
				{
					sb.append(" rtl");
					break;
				}

				default:
				{
					sb.append(" layoutdir=");
					sb.append(textLayoutDirection);
					break;
				}
			}
			if (smallestScreenWidthDp != SMALLEST_SCREEN_WIDTH_DP_UNDEFINED)
			{
				sb.append(" sw");
				sb.append(smallestScreenWidthDp);
				sb.append("dp");
			}
			else
			{
				sb.append(" ?swdp");
			}
			if (screenWidthDp != SCREEN_WIDTH_DP_UNDEFINED)
			{
				sb.append(" w");
				sb.append(screenWidthDp);
				sb.append("dp");
			}
			else
			{
				sb.append(" ?wdp");
			}
			if (screenHeightDp != SCREEN_HEIGHT_DP_UNDEFINED)
			{
				sb.append(" h");
				sb.append(screenHeightDp);
				sb.append("dp");
			}
			else
			{
				sb.append(" ?hdp");
			}
			switch ((screenLayout & SCREENLAYOUT_SIZE_MASK))
			{
				case SCREENLAYOUT_SIZE_UNDEFINED:
				{
					sb.append(" ?lsize");
					break;
				}

				case SCREENLAYOUT_SIZE_SMALL:
				{
					sb.append(" smll");
					break;
				}

				case SCREENLAYOUT_SIZE_NORMAL:
				{
					sb.append(" nrml");
					break;
				}

				case SCREENLAYOUT_SIZE_LARGE:
				{
					sb.append(" lrg");
					break;
				}

				case SCREENLAYOUT_SIZE_XLARGE:
				{
					sb.append(" xlrg");
					break;
				}

				default:
				{
					sb.append(" layoutSize=");
					sb.append(screenLayout & SCREENLAYOUT_SIZE_MASK);
					break;
				}
			}
			switch ((screenLayout & SCREENLAYOUT_LONG_MASK))
			{
				case SCREENLAYOUT_LONG_UNDEFINED:
				{
					sb.append(" ?long");
					break;
				}

				case SCREENLAYOUT_LONG_NO:
				{
					break;
				}

				case SCREENLAYOUT_LONG_YES:
				{
					sb.append(" long");
					break;
				}

				default:
				{
					sb.append(" layoutLong=");
					sb.append(screenLayout & SCREENLAYOUT_LONG_MASK);
					break;
				}
			}
			switch (orientation)
			{
				case ORIENTATION_UNDEFINED:
				{
					sb.append(" ?orien");
					break;
				}

				case ORIENTATION_LANDSCAPE:
				{
					sb.append(" land");
					break;
				}

				case ORIENTATION_PORTRAIT:
				{
					sb.append(" port");
					break;
				}

				default:
				{
					sb.append(" orien=");
					sb.append(orientation);
					break;
				}
			}
			switch ((uiMode & UI_MODE_TYPE_MASK))
			{
				case UI_MODE_TYPE_UNDEFINED:
				{
					sb.append(" ?uimode");
					break;
				}

				case UI_MODE_TYPE_NORMAL:
				{
					break;
				}

				case UI_MODE_TYPE_DESK:
				{
					sb.append(" desk");
					break;
				}

				case UI_MODE_TYPE_CAR:
				{
					sb.append(" car");
					break;
				}

				case UI_MODE_TYPE_TELEVISION:
				{
					sb.append(" television");
					break;
				}

				default:
				{
					sb.append(" uimode=");
					sb.append(uiMode & UI_MODE_TYPE_MASK);
					break;
				}
			}
			switch ((uiMode & UI_MODE_NIGHT_MASK))
			{
				case UI_MODE_NIGHT_UNDEFINED:
				{
					sb.append(" ?night");
					break;
				}

				case UI_MODE_NIGHT_NO:
				{
					break;
				}

				case UI_MODE_NIGHT_YES:
				{
					sb.append(" night");
					break;
				}

				default:
				{
					sb.append(" night=");
					sb.append(uiMode & UI_MODE_NIGHT_MASK);
					break;
				}
			}
			switch (touchscreen)
			{
				case TOUCHSCREEN_UNDEFINED:
				{
					sb.append(" ?touch");
					break;
				}

				case TOUCHSCREEN_NOTOUCH:
				{
					sb.append(" -touch");
					break;
				}

				case TOUCHSCREEN_STYLUS:
				{
					sb.append(" stylus");
					break;
				}

				case TOUCHSCREEN_FINGER:
				{
					sb.append(" finger");
					break;
				}

				default:
				{
					sb.append(" touch=");
					sb.append(touchscreen);
					break;
				}
			}
			switch (keyboard)
			{
				case KEYBOARD_UNDEFINED:
				{
					sb.append(" ?keyb");
					break;
				}

				case KEYBOARD_NOKEYS:
				{
					sb.append(" -keyb");
					break;
				}

				case KEYBOARD_QWERTY:
				{
					sb.append(" qwerty");
					break;
				}

				case KEYBOARD_12KEY:
				{
					sb.append(" 12key");
					break;
				}

				default:
				{
					sb.append(" keys=");
					sb.append(keyboard);
					break;
				}
			}
			switch (keyboardHidden)
			{
				case KEYBOARDHIDDEN_UNDEFINED:
				{
					sb.append("/?");
					break;
				}

				case KEYBOARDHIDDEN_NO:
				{
					sb.append("/v");
					break;
				}

				case KEYBOARDHIDDEN_YES:
				{
					sb.append("/h");
					break;
				}

				case KEYBOARDHIDDEN_SOFT:
				{
					sb.append("/s");
					break;
				}

				default:
				{
					sb.append("/");
					sb.append(keyboardHidden);
					break;
				}
			}
			switch (hardKeyboardHidden)
			{
				case HARDKEYBOARDHIDDEN_UNDEFINED:
				{
					sb.append("/?");
					break;
				}

				case HARDKEYBOARDHIDDEN_NO:
				{
					sb.append("/v");
					break;
				}

				case HARDKEYBOARDHIDDEN_YES:
				{
					sb.append("/h");
					break;
				}

				default:
				{
					sb.append("/");
					sb.append(hardKeyboardHidden);
					break;
				}
			}
			switch (navigation)
			{
				case NAVIGATION_UNDEFINED:
				{
					sb.append(" ?nav");
					break;
				}

				case NAVIGATION_NONAV:
				{
					sb.append(" -nav");
					break;
				}

				case NAVIGATION_DPAD:
				{
					sb.append(" dpad");
					break;
				}

				case NAVIGATION_TRACKBALL:
				{
					sb.append(" tball");
					break;
				}

				case NAVIGATION_WHEEL:
				{
					sb.append(" wheel");
					break;
				}

				default:
				{
					sb.append(" nav=");
					sb.append(navigation);
					break;
				}
			}
			switch (navigationHidden)
			{
				case NAVIGATIONHIDDEN_UNDEFINED:
				{
					sb.append("/?");
					break;
				}

				case NAVIGATIONHIDDEN_NO:
				{
					sb.append("/v");
					break;
				}

				case NAVIGATIONHIDDEN_YES:
				{
					sb.append("/h");
					break;
				}

				default:
				{
					sb.append("/");
					sb.append(navigationHidden);
					break;
				}
			}
			if (seq != 0)
			{
				sb.append(" s.");
				sb.append(seq);
			}
			sb.append('}');
			return sb.ToString();
		}

		/// <summary>Set this object to the system defaults.</summary>
		/// <remarks>Set this object to the system defaults.</remarks>
		public void setToDefaults()
		{
			fontScale = 1;
			mcc = mnc = 0;
			locale = null;
			userSetLocale = false;
			touchscreen = TOUCHSCREEN_UNDEFINED;
			keyboard = KEYBOARD_UNDEFINED;
			keyboardHidden = KEYBOARDHIDDEN_UNDEFINED;
			hardKeyboardHidden = HARDKEYBOARDHIDDEN_UNDEFINED;
			navigation = NAVIGATION_UNDEFINED;
			navigationHidden = NAVIGATIONHIDDEN_UNDEFINED;
			orientation = ORIENTATION_UNDEFINED;
			screenLayout = SCREENLAYOUT_SIZE_UNDEFINED;
			uiMode = UI_MODE_TYPE_UNDEFINED;
			screenWidthDp = compatScreenWidthDp = SCREEN_WIDTH_DP_UNDEFINED;
			screenHeightDp = compatScreenHeightDp = SCREEN_HEIGHT_DP_UNDEFINED;
			smallestScreenWidthDp = compatSmallestScreenWidthDp = SMALLEST_SCREEN_WIDTH_DP_UNDEFINED;
			textLayoutDirection = android.util.LocaleUtil.TEXT_LAYOUT_DIRECTION_LTR_DO_NOT_USE;
			seq = 0;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		[System.Obsolete]
		public void makeDefault()
		{
			setToDefaults();
		}

		/// <summary>
		/// Copy the fields from delta into this Configuration object, keeping
		/// track of which ones have changed.
		/// </summary>
		/// <remarks>
		/// Copy the fields from delta into this Configuration object, keeping
		/// track of which ones have changed.  Any undefined fields in
		/// <var>delta</var> are ignored and not copied in to the current
		/// Configuration.
		/// </remarks>
		/// <returns>
		/// Returns a bit mask of the changed fields, as per
		/// <see cref="diff(Configuration)">diff(Configuration)</see>
		/// .
		/// </returns>
		public int updateFrom(android.content.res.Configuration delta)
		{
			int changed = 0;
			if (delta.fontScale > 0 && fontScale != delta.fontScale)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_FONT_SCALE;
				fontScale = delta.fontScale;
			}
			if (delta.mcc != 0 && mcc != delta.mcc)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_MCC;
				mcc = delta.mcc;
			}
			if (delta.mnc != 0 && mnc != delta.mnc)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_MNC;
				mnc = delta.mnc;
			}
			if (delta.locale != null && (locale == null || !locale.Equals(delta.locale)))
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_LOCALE;
				locale = delta.locale != null ? (System.Globalization.CultureInfo)delta.locale.Clone
					() : null;
				textLayoutDirection = android.util.LocaleUtil.getLayoutDirectionFromLocale(locale
					);
			}
			if (delta.userSetLocale && (!userSetLocale || ((changed & android.content.pm.ActivityInfo
				.CONFIG_LOCALE) != 0)))
			{
				userSetLocale = true;
				changed |= android.content.pm.ActivityInfo.CONFIG_LOCALE;
			}
			if (delta.touchscreen != TOUCHSCREEN_UNDEFINED && touchscreen != delta.touchscreen)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_TOUCHSCREEN;
				touchscreen = delta.touchscreen;
			}
			if (delta.keyboard != KEYBOARD_UNDEFINED && keyboard != delta.keyboard)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD;
				keyboard = delta.keyboard;
			}
			if (delta.keyboardHidden != KEYBOARDHIDDEN_UNDEFINED && keyboardHidden != delta.keyboardHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
				keyboardHidden = delta.keyboardHidden;
			}
			if (delta.hardKeyboardHidden != HARDKEYBOARDHIDDEN_UNDEFINED && hardKeyboardHidden
				 != delta.hardKeyboardHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
				hardKeyboardHidden = delta.hardKeyboardHidden;
			}
			if (delta.navigation != NAVIGATION_UNDEFINED && navigation != delta.navigation)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_NAVIGATION;
				navigation = delta.navigation;
			}
			if (delta.navigationHidden != NAVIGATIONHIDDEN_UNDEFINED && navigationHidden != delta
				.navigationHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
				navigationHidden = delta.navigationHidden;
			}
			if (delta.orientation != ORIENTATION_UNDEFINED && orientation != delta.orientation)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_ORIENTATION;
				orientation = delta.orientation;
			}
			if (delta.screenLayout != SCREENLAYOUT_SIZE_UNDEFINED && screenLayout != delta.screenLayout)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_LAYOUT;
				screenLayout = delta.screenLayout;
			}
			if (delta.uiMode != (UI_MODE_TYPE_UNDEFINED | UI_MODE_NIGHT_UNDEFINED) && uiMode 
				!= delta.uiMode)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_UI_MODE;
				if ((delta.uiMode & UI_MODE_TYPE_MASK) != UI_MODE_TYPE_UNDEFINED)
				{
					uiMode = (uiMode & ~UI_MODE_TYPE_MASK) | (delta.uiMode & UI_MODE_TYPE_MASK);
				}
				if ((delta.uiMode & UI_MODE_NIGHT_MASK) != UI_MODE_NIGHT_UNDEFINED)
				{
					uiMode = (uiMode & ~UI_MODE_NIGHT_MASK) | (delta.uiMode & UI_MODE_NIGHT_MASK);
				}
			}
			if (delta.screenWidthDp != SCREEN_WIDTH_DP_UNDEFINED && screenWidthDp != delta.screenWidthDp)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE;
				screenWidthDp = delta.screenWidthDp;
			}
			if (delta.screenHeightDp != SCREEN_HEIGHT_DP_UNDEFINED && screenHeightDp != delta
				.screenHeightDp)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE;
				screenHeightDp = delta.screenHeightDp;
			}
			if (delta.smallestScreenWidthDp != SMALLEST_SCREEN_WIDTH_DP_UNDEFINED)
			{
				smallestScreenWidthDp = delta.smallestScreenWidthDp;
			}
			if (delta.compatScreenWidthDp != SCREEN_WIDTH_DP_UNDEFINED)
			{
				compatScreenWidthDp = delta.compatScreenWidthDp;
			}
			if (delta.compatScreenHeightDp != SCREEN_HEIGHT_DP_UNDEFINED)
			{
				compatScreenHeightDp = delta.compatScreenHeightDp;
			}
			if (delta.compatSmallestScreenWidthDp != SMALLEST_SCREEN_WIDTH_DP_UNDEFINED)
			{
				compatSmallestScreenWidthDp = delta.compatSmallestScreenWidthDp;
			}
			if (delta.seq != 0)
			{
				seq = delta.seq;
			}
			return changed;
		}

		/// <summary>
		/// Return a bit mask of the differences between this Configuration
		/// object and the given one.
		/// </summary>
		/// <remarks>
		/// Return a bit mask of the differences between this Configuration
		/// object and the given one.  Does not change the values of either.  Any
		/// undefined fields in <var>delta</var> are ignored.
		/// </remarks>
		/// <returns>
		/// Returns a bit mask indicating which configuration
		/// values has changed, containing any combination of
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_FONT_SCALE">PackageManager.ActivityInfo.CONFIG_FONT_SCALE
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_MCC">PackageManager.ActivityInfo.CONFIG_MCC
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_MNC">PackageManager.ActivityInfo.CONFIG_MNC
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_LOCALE">PackageManager.ActivityInfo.CONFIG_LOCALE
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_TOUCHSCREEN">PackageManager.ActivityInfo.CONFIG_TOUCHSCREEN
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_KEYBOARD">PackageManager.ActivityInfo.CONFIG_KEYBOARD
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_NAVIGATION">PackageManager.ActivityInfo.CONFIG_NAVIGATION
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_ORIENTATION">PackageManager.ActivityInfo.CONFIG_ORIENTATION
		/// 	</see>
		/// ,
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_SCREEN_LAYOUT">PackageManager.ActivityInfo.CONFIG_SCREEN_LAYOUT
		/// 	</see>
		/// , or
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE">PackageManager.ActivityInfo.CONFIG_SCREEN_SIZE
		/// 	</see>
		/// , or
		/// <see cref="android.content.pm.ActivityInfo.CONFIG_SMALLEST_SCREEN_SIZE">PackageManager.ActivityInfo.CONFIG_SMALLEST_SCREEN_SIZE
		/// 	</see>
		/// .
		/// </returns>
		public int diff(android.content.res.Configuration delta)
		{
			int changed = 0;
			if (delta.fontScale > 0 && fontScale != delta.fontScale)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_FONT_SCALE;
			}
			if (delta.mcc != 0 && mcc != delta.mcc)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_MCC;
			}
			if (delta.mnc != 0 && mnc != delta.mnc)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_MNC;
			}
			if (delta.locale != null && (locale == null || !locale.Equals(delta.locale)))
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_LOCALE;
			}
			if (delta.touchscreen != TOUCHSCREEN_UNDEFINED && touchscreen != delta.touchscreen)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_TOUCHSCREEN;
			}
			if (delta.keyboard != KEYBOARD_UNDEFINED && keyboard != delta.keyboard)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD;
			}
			if (delta.keyboardHidden != KEYBOARDHIDDEN_UNDEFINED && keyboardHidden != delta.keyboardHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
			}
			if (delta.hardKeyboardHidden != HARDKEYBOARDHIDDEN_UNDEFINED && hardKeyboardHidden
				 != delta.hardKeyboardHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
			}
			if (delta.navigation != NAVIGATION_UNDEFINED && navigation != delta.navigation)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_NAVIGATION;
			}
			if (delta.navigationHidden != NAVIGATIONHIDDEN_UNDEFINED && navigationHidden != delta
				.navigationHidden)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_KEYBOARD_HIDDEN;
			}
			if (delta.orientation != ORIENTATION_UNDEFINED && orientation != delta.orientation)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_ORIENTATION;
			}
			if (delta.screenLayout != SCREENLAYOUT_SIZE_UNDEFINED && screenLayout != delta.screenLayout)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_LAYOUT;
			}
			if (delta.uiMode != (UI_MODE_TYPE_UNDEFINED | UI_MODE_NIGHT_UNDEFINED) && uiMode 
				!= delta.uiMode)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_UI_MODE;
			}
			if (delta.screenWidthDp != SCREEN_WIDTH_DP_UNDEFINED && screenWidthDp != delta.screenWidthDp)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE;
			}
			if (delta.screenHeightDp != SCREEN_HEIGHT_DP_UNDEFINED && screenHeightDp != delta
				.screenHeightDp)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SCREEN_SIZE;
			}
			if (delta.smallestScreenWidthDp != SMALLEST_SCREEN_WIDTH_DP_UNDEFINED && smallestScreenWidthDp
				 != delta.smallestScreenWidthDp)
			{
				changed |= android.content.pm.ActivityInfo.CONFIG_SMALLEST_SCREEN_SIZE;
			}
			return changed;
		}

		/// <summary>
		/// Determine if a new resource needs to be loaded from the bit set of
		/// configuration changes returned by
		/// <see cref="updateFrom(Configuration)">updateFrom(Configuration)</see>
		/// .
		/// </summary>
		/// <param name="configChanges">
		/// The mask of changes configurations as returned by
		/// <see cref="updateFrom(Configuration)">updateFrom(Configuration)</see>
		/// .
		/// </param>
		/// <param name="interestingChanges">
		/// The configuration changes that the resource
		/// can handled, as given in
		/// <see cref="android.util.TypedValue.changingConfigurations">android.util.TypedValue.changingConfigurations
		/// 	</see>
		/// .
		/// </param>
		/// <returns>Return true if the resource needs to be loaded, else false.</returns>
		public static bool needNewResources(int configChanges, int interestingChanges)
		{
			return (configChanges & (interestingChanges | android.content.pm.ActivityInfo.CONFIG_FONT_SCALE
				)) != 0;
		}

		/// <hide>
		/// Return true if the sequence of 'other' is better than this.  Assumes
		/// that 'this' is your current sequence and 'other' is a new one you have
		/// received some how and want to compare with what you have.
		/// </hide>
		public bool isOtherSeqNewer(android.content.res.Configuration other)
		{
			if (other == null)
			{
				// Sanity check.
				return false;
			}
			if (other.seq == 0)
			{
				// If the other sequence is not specified, then we must assume
				// it is newer since we don't know any better.
				return true;
			}
			if (seq == 0)
			{
				// If this sequence is not specified, then we also consider the
				// other is better.  Yes we have a preference for other.  Sue us.
				return true;
			}
			int diff_1 = other.seq - seq;
			if (diff_1 > unchecked((int)(0x10000)))
			{
				// If there has been a sufficiently large jump, assume the
				// sequence has wrapped around.
				return false;
			}
			return diff_1 > 0;
		}

		/// <summary>Parcelable methods</summary>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readFromParcel(android.os.Parcel source)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_808 : android.os.ParcelableClass.Creator<android.content.res.Configuration
			>
		{
			public _Creator_808()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.Configuration createFromParcel(android.os.Parcel source
				)
			{
				return new android.content.res.Configuration(source);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.Configuration[] newArray(int size)
			{
				return new android.content.res.Configuration[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.res.Configuration
			> CREATOR = new _Creator_808();

		/// <summary>Construct this Configuration object, reading from the Parcel.</summary>
		/// <remarks>Construct this Configuration object, reading from the Parcel.</remarks>
		private Configuration(android.os.Parcel source)
		{
			readFromParcel(source);
		}

		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public int compareTo(android.content.res.Configuration that)
		{
			int n;
			float a = this.fontScale;
			float b = that.fontScale;
			if (a < b)
			{
				return -1;
			}
			if (a > b)
			{
				return 1;
			}
			n = this.mcc - that.mcc;
			if (n != 0)
			{
				return n;
			}
			n = this.mnc - that.mnc;
			if (n != 0)
			{
				return n;
			}
			if (this.locale == null)
			{
				if (that.locale != null)
				{
					return 1;
				}
			}
			else
			{
				if (that.locale == null)
				{
					return -1;
				}
				else
				{
					n = string.CompareOrdinal(Sharpen.Util.GetLanguage(this.locale), Sharpen.Util.GetLanguage
						(that.locale));
					if (n != 0)
					{
						return n;
					}
					n = string.CompareOrdinal(Sharpen.Util.GetCountry(this.locale), Sharpen.Util.GetCountry
						(that.locale));
					if (n != 0)
					{
						return n;
					}
					n = string.CompareOrdinal(Sharpen.Util.GetVariant(this.locale), Sharpen.Util.GetVariant
						(that.locale));
					if (n != 0)
					{
						return n;
					}
				}
			}
			n = this.touchscreen - that.touchscreen;
			if (n != 0)
			{
				return n;
			}
			n = this.keyboard - that.keyboard;
			if (n != 0)
			{
				return n;
			}
			n = this.keyboardHidden - that.keyboardHidden;
			if (n != 0)
			{
				return n;
			}
			n = this.hardKeyboardHidden - that.hardKeyboardHidden;
			if (n != 0)
			{
				return n;
			}
			n = this.navigation - that.navigation;
			if (n != 0)
			{
				return n;
			}
			n = this.navigationHidden - that.navigationHidden;
			if (n != 0)
			{
				return n;
			}
			n = this.orientation - that.orientation;
			if (n != 0)
			{
				return n;
			}
			n = this.screenLayout - that.screenLayout;
			if (n != 0)
			{
				return n;
			}
			n = this.uiMode - that.uiMode;
			if (n != 0)
			{
				return n;
			}
			n = this.screenWidthDp - that.screenWidthDp;
			if (n != 0)
			{
				return n;
			}
			n = this.screenHeightDp - that.screenHeightDp;
			if (n != 0)
			{
				return n;
			}
			n = this.smallestScreenWidthDp - that.smallestScreenWidthDp;
			//if (n != 0) return n;
			return n;
		}

		public bool equals(android.content.res.Configuration that)
		{
			if (that == null)
			{
				return false;
			}
			if (that == this)
			{
				return true;
			}
			return this.compareTo(that) == 0;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object that)
		{
			try
			{
				return equals((android.content.res.Configuration)that);
			}
			catch (System.InvalidCastException)
			{
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			int result = 17;
			result = 31 * result + Sharpen.Util.FloatToIntBits(fontScale);
			result = 31 * result + mcc;
			result = 31 * result + mnc;
			result = 31 * result + (locale != null ? locale.GetHashCode() : 0);
			result = 31 * result + touchscreen;
			result = 31 * result + keyboard;
			result = 31 * result + keyboardHidden;
			result = 31 * result + hardKeyboardHidden;
			result = 31 * result + navigation;
			result = 31 * result + navigationHidden;
			result = 31 * result + orientation;
			result = 31 * result + screenLayout;
			result = 31 * result + uiMode;
			result = 31 * result + screenWidthDp;
			result = 31 * result + screenHeightDp;
			result = 31 * result + smallestScreenWidthDp;
			return result;
		}
	}
}
