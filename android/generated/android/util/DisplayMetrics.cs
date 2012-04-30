using Sharpen;

namespace android.util
{
	/// <summary>
	/// A structure describing general information about a display, such as its
	/// size, density, and font scaling.
	/// </summary>
	/// <remarks>
	/// A structure describing general information about a display, such as its
	/// size, density, and font scaling.
	/// <p>To access the DisplayMetrics members, initialize an object like this:</p>
	/// <pre> DisplayMetrics metrics = new DisplayMetrics();
	/// getWindowManager().getDefaultDisplay().getMetrics(metrics);</pre>
	/// </remarks>
	[Sharpen.Sharpened]
	public class DisplayMetrics
	{
		/// <summary>Standard quantized DPI for low-density screens.</summary>
		/// <remarks>Standard quantized DPI for low-density screens.</remarks>
		public const int DENSITY_LOW = 120;

		/// <summary>Standard quantized DPI for medium-density screens.</summary>
		/// <remarks>Standard quantized DPI for medium-density screens.</remarks>
		public const int DENSITY_MEDIUM = 160;

		/// <summary>Standard quantized DPI for 720p TV screens.</summary>
		/// <remarks>
		/// Standard quantized DPI for 720p TV screens.  Applications should
		/// generally not worry about this density, instead targeting
		/// <see cref="DENSITY_XHIGH">DENSITY_XHIGH</see>
		/// for 1080p TV screens.  For situations where
		/// output is needed for a 720p screen, the UI elements can be scaled
		/// automatically by the platform.
		/// </remarks>
		public const int DENSITY_TV = 213;

		/// <summary>Standard quantized DPI for high-density screens.</summary>
		/// <remarks>Standard quantized DPI for high-density screens.</remarks>
		public const int DENSITY_HIGH = 240;

		/// <summary>Standard quantized DPI for extra-high-density screens.</summary>
		/// <remarks>Standard quantized DPI for extra-high-density screens.</remarks>
		public const int DENSITY_XHIGH = 320;

		/// <summary>The reference density used throughout the system.</summary>
		/// <remarks>The reference density used throughout the system.</remarks>
		public const int DENSITY_DEFAULT = DENSITY_MEDIUM;

		/// <summary>The device's density.</summary>
		/// <remarks>The device's density.</remarks>
		/// <hide>
		/// becase eventually this should be able to change while
		/// running, so shouldn't be a constant.
		/// </hide>
		public static readonly int DENSITY_DEVICE = DENSITY_DEFAULT;

		/// <summary>The absolute width of the display in pixels.</summary>
		/// <remarks>The absolute width of the display in pixels.</remarks>
		public int widthPixels;

		/// <summary>The absolute height of the display in pixels.</summary>
		/// <remarks>The absolute height of the display in pixels.</remarks>
		public int heightPixels;

		/// <summary>The logical density of the display.</summary>
		/// <remarks>
		/// The logical density of the display.  This is a scaling factor for the
		/// Density Independent Pixel unit, where one DIP is one pixel on an
		/// approximately 160 dpi screen (for example a 240x320, 1.5"x2" screen),
		/// providing the baseline of the system's display. Thus on a 160dpi screen
		/// this density value will be 1; on a 120 dpi screen it would be .75; etc.
		/// <p>This value does not exactly follow the real screen size (as given by
		/// <see cref="xdpi">xdpi</see>
		/// and
		/// <see cref="ydpi">ydpi</see>
		/// , but rather is used to scale the size of
		/// the overall UI in steps based on gross changes in the display dpi.  For
		/// example, a 240x320 screen will have a density of 1 even if its width is
		/// 1.8", 1.3", etc. However, if the screen resolution is increased to
		/// 320x480 but the screen size remained 1.5"x2" then the density would be
		/// increased (probably to 1.5).
		/// </remarks>
		/// <seealso cref="DENSITY_DEFAULT">DENSITY_DEFAULT</seealso>
		public float density;

		/// <summary>The screen density expressed as dots-per-inch.</summary>
		/// <remarks>
		/// The screen density expressed as dots-per-inch.  May be either
		/// <see cref="DENSITY_LOW">DENSITY_LOW</see>
		/// ,
		/// <see cref="DENSITY_MEDIUM">DENSITY_MEDIUM</see>
		/// , or
		/// <see cref="DENSITY_HIGH">DENSITY_HIGH</see>
		/// .
		/// </remarks>
		public int densityDpi;

		/// <summary>A scaling factor for fonts displayed on the display.</summary>
		/// <remarks>
		/// A scaling factor for fonts displayed on the display.  This is the same
		/// as
		/// <see cref="density">density</see>
		/// , except that it may be adjusted in smaller
		/// increments at runtime based on a user preference for the font size.
		/// </remarks>
		public float scaledDensity;

		/// <summary>The exact physical pixels per inch of the screen in the X dimension.</summary>
		/// <remarks>The exact physical pixels per inch of the screen in the X dimension.</remarks>
		public float xdpi;

		/// <summary>The exact physical pixels per inch of the screen in the Y dimension.</summary>
		/// <remarks>The exact physical pixels per inch of the screen in the Y dimension.</remarks>
		public float ydpi;

		/// <summary>
		/// The reported display width prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported display width prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public int noncompatWidthPixels;

		/// <summary>
		/// The reported display height prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported display height prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public int noncompatHeightPixels;

		/// <summary>
		/// The reported display density prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported display density prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public float noncompatDensity;

		/// <summary>
		/// The reported scaled density prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported scaled density prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public float noncompatScaledDensity;

		/// <summary>
		/// The reported display xdpi prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported display xdpi prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public float noncompatXdpi;

		/// <summary>
		/// The reported display ydpi prior to any compatibility mode scaling
		/// being applied.
		/// </summary>
		/// <remarks>
		/// The reported display ydpi prior to any compatibility mode scaling
		/// being applied.
		/// </remarks>
		/// <hide></hide>
		public float noncompatYdpi;

		public DisplayMetrics()
		{
		}

		public virtual void setTo(android.util.DisplayMetrics o)
		{
			widthPixels = o.widthPixels;
			heightPixels = o.heightPixels;
			density = o.density;
			densityDpi = o.densityDpi;
			scaledDensity = o.scaledDensity;
			xdpi = o.xdpi;
			ydpi = o.ydpi;
			noncompatWidthPixels = o.noncompatWidthPixels;
			noncompatHeightPixels = o.noncompatHeightPixels;
			noncompatDensity = o.noncompatDensity;
			noncompatScaledDensity = o.noncompatScaledDensity;
			noncompatXdpi = o.noncompatXdpi;
			noncompatYdpi = o.noncompatYdpi;
		}

		public virtual void setToDefaults()
		{
			widthPixels = 0;
			heightPixels = 0;
			density = DENSITY_DEVICE / (float)DENSITY_DEFAULT;
			densityDpi = DENSITY_DEVICE;
			scaledDensity = density;
			xdpi = DENSITY_DEVICE;
			ydpi = DENSITY_DEVICE;
			noncompatWidthPixels = 0;
			noncompatHeightPixels = 0;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "DisplayMetrics{density=" + density + ", width=" + widthPixels + ", height="
				 + heightPixels + ", scaledDensity=" + scaledDensity + ", xdpi=" + xdpi + ", ydpi="
				 + ydpi + "}";
		}

		private static int getDeviceDensity()
		{
			// qemu.sf.lcd_density can be used to override ro.sf.lcd_density
			// when running in the emulator, allowing for dynamic configurations.
			// The reason for this is that ro.sf.lcd_density is write-once and is
			// set by the init process when it parses build.prop before anything else.
			return android.os.SystemProperties.getInt("qemu.sf.lcd_density", android.os.SystemProperties
				.getInt("ro.sf.lcd_density", DENSITY_DEFAULT));
		}
	}
}
