using Sharpen;

namespace android.view
{
	/// <summary>Provides information about the display size and density.</summary>
	/// <remarks>Provides information about the display size and density.</remarks>
	[Sharpen.Sharpened]
	public partial class Display
	{
		internal const string TAG = "Display";

		internal const bool DEBUG_DISPLAY_SIZE = false;

		/// <summary>The default Display id.</summary>
		/// <remarks>The default Display id.</remarks>
		public const int DEFAULT_DISPLAY = 0;

		/// <summary>
		/// Use
		/// <see cref="WindowManager.getDefaultDisplay()">WindowManager.getDefaultDisplay()</see>
		/// to create a Display object.
		/// Display gives you access to some information about a particular display
		/// connected to the device.
		/// </summary>
		internal Display(int display, android.view.CompatibilityInfoHolder compatInfo)
		{
			// initalize the statics when this class is first instansiated. This is
			// done here instead of in the static block because Zygote
			lock (sStaticInit)
			{
				if (!sInitialized)
				{
					nativeClassInit();
					sInitialized = true;
				}
			}
			mCompatibilityInfo = compatInfo != null ? compatInfo : new android.view.CompatibilityInfoHolder
				();
			mDisplay = display;
			init(display);
		}

		/// <summary>Returns the index of this display.</summary>
		/// <remarks>
		/// Returns the index of this display.  This is currently undefined; do
		/// not use.
		/// </remarks>
		public virtual int getDisplayId()
		{
			return mDisplay;
		}

		/// <summary>Gets the size of the display, in pixels.</summary>
		/// <remarks>
		/// Gets the size of the display, in pixels.
		/// <p>
		/// Note that this value should <em>not</em> be used for computing layouts,
		/// since a device will typically have screen decoration (such as a status bar)
		/// along the edges of the display that reduce the amount of application
		/// space available from the size returned here.  Layouts should instead use
		/// the window size.
		/// </p><p>
		/// The size is adjusted based on the current rotation of the display.
		/// </p><p>
		/// The size returned by this method does not necessarily represent the
		/// actual raw size (native resolution) of the display.  The returned size may
		/// be adjusted to exclude certain system decor elements that are always visible.
		/// It may also be scaled to provide compatibility with older applications that
		/// were originally designed for smaller displays.
		/// </p>
		/// </remarks>
		/// <param name="outSize">
		/// A
		/// <see cref="android.graphics.Point">android.graphics.Point</see>
		/// object to receive the size information.
		/// </param>
		public virtual void getSize(android.graphics.Point outSize)
		{
			getSizeInternal(outSize, true);
		}

		private void getSizeInternal(android.graphics.Point outSize, bool doCompat)
		{
			try
			{
				android.view.IWindowManager wm = getWindowManager();
				if (wm != null)
				{
					wm.getDisplaySize(outSize);
					android.content.res.CompatibilityInfo ci;
					if (doCompat && (ci = mCompatibilityInfo.getIfNeeded()) != null)
					{
						lock (mTmpMetrics)
						{
							mTmpMetrics.noncompatWidthPixels = outSize.x;
							mTmpMetrics.noncompatHeightPixels = outSize.y;
							mTmpMetrics.density = mDensity;
							ci.applyToDisplayMetrics(mTmpMetrics);
							outSize.x = mTmpMetrics.widthPixels;
							outSize.y = mTmpMetrics.heightPixels;
						}
					}
				}
				else
				{
					// This is just for boot-strapping, initializing the
					// system process before the window manager is up.
					outSize.x = getRawWidth();
					outSize.y = getRawHeight();
				}
				if (false)
				{
					java.lang.RuntimeException here = new java.lang.RuntimeException("here");
					XobotOS.Runtime.Util.FillInStackTrace(here);
					android.util.Slog.v(TAG, "Returning display size: " + outSize, here);
				}
				if (DEBUG_DISPLAY_SIZE && doCompat)
				{
					android.util.Slog.v(TAG, "Returning display size: " + outSize);
				}
			}
			catch (android.os.RemoteException e)
			{
				android.util.Slog.w("Display", "Unable to get display size", e);
			}
		}

		/// <summary>Gets the size of the display as a rectangle, in pixels.</summary>
		/// <remarks>Gets the size of the display as a rectangle, in pixels.</remarks>
		/// <param name="outSize">
		/// A
		/// <see cref="android.graphics.Rect">android.graphics.Rect</see>
		/// object to receive the size information.
		/// </param>
		/// <seealso cref="getSize(android.graphics.Point)">getSize(android.graphics.Point)</seealso>
		public virtual void getRectSize(android.graphics.Rect outSize)
		{
			lock (mTmpPoint)
			{
				getSizeInternal(mTmpPoint, true);
				outSize.set(0, 0, mTmpPoint.x, mTmpPoint.y);
			}
		}

		/// <summary>Return the maximum screen size dimension that will happen.</summary>
		/// <remarks>
		/// Return the maximum screen size dimension that will happen.  This is
		/// mostly for wallpapers.
		/// </remarks>
		/// <hide></hide>
		public virtual int getMaximumSizeDimension()
		{
			try
			{
				android.view.IWindowManager wm = getWindowManager();
				return wm.getMaximumSizeDimension();
			}
			catch (android.os.RemoteException e)
			{
				android.util.Slog.w("Display", "Unable to get display maximum size dimension", e);
				return 0;
			}
		}

		[System.ObsoleteAttribute(@"Use getSize(android.graphics.Point) instead.")]
		public virtual int getWidth()
		{
			lock (mTmpPoint)
			{
				long now = android.os.SystemClock.uptimeMillis();
				if (now > (mLastGetTime + 20))
				{
					getSizeInternal(mTmpPoint, true);
					mLastGetTime = now;
				}
				return mTmpPoint.x;
			}
		}

		[System.ObsoleteAttribute(@"Use getSize(android.graphics.Point) instead.")]
		public virtual int getHeight()
		{
			lock (mTmpPoint)
			{
				long now = android.os.SystemClock.uptimeMillis();
				if (now > (mLastGetTime + 20))
				{
					getSizeInternal(mTmpPoint, true);
					mLastGetTime = now;
				}
				return mTmpPoint.y;
			}
		}

		/// <summary>
		/// Gets the real size of the display without subtracting any window decor or
		/// applying any compatibility scale factors.
		/// </summary>
		/// <remarks>
		/// Gets the real size of the display without subtracting any window decor or
		/// applying any compatibility scale factors.
		/// <p>
		/// The real size may be smaller than the raw size when the window manager
		/// is emulating a smaller display (using adb shell am display-size).
		/// </p><p>
		/// The size is adjusted based on the current rotation of the display.
		/// </p>
		/// </remarks>
		/// <hide></hide>
		public virtual void getRealSize(android.graphics.Point outSize)
		{
			try
			{
				android.view.IWindowManager wm = getWindowManager();
				if (wm != null)
				{
					wm.getRealDisplaySize(outSize);
				}
				else
				{
					// This is just for boot-strapping, initializing the
					// system process before the window manager is up.
					outSize.x = getRawWidth();
					outSize.y = getRawHeight();
				}
			}
			catch (android.os.RemoteException e)
			{
				android.util.Slog.w("Display", "Unable to get real display size", e);
			}
		}

		/// <summary>Returns the rotation of the screen from its "natural" orientation.</summary>
		/// <remarks>
		/// Returns the rotation of the screen from its "natural" orientation.
		/// The returned value may be
		/// <see cref="Surface.ROTATION_0">Surface.ROTATION_0</see>
		/// (no rotation),
		/// <see cref="Surface.ROTATION_90">Surface.ROTATION_90</see>
		/// ,
		/// <see cref="Surface.ROTATION_180">Surface.ROTATION_180</see>
		/// , or
		/// <see cref="Surface.ROTATION_270">Surface.ROTATION_270</see>
		/// .  For
		/// example, if a device has a naturally tall screen, and the user has
		/// turned it on its side to go into a landscape orientation, the value
		/// returned here may be either
		/// <see cref="Surface.ROTATION_90">Surface.ROTATION_90</see>
		/// or
		/// <see cref="Surface.ROTATION_270">Surface.ROTATION_270</see>
		/// depending on
		/// the direction it was turned.  The angle is the rotation of the drawn
		/// graphics on the screen, which is the opposite direction of the physical
		/// rotation of the device.  For example, if the device is rotated 90
		/// degrees counter-clockwise, to compensate rendering will be rotated by
		/// 90 degrees clockwise and thus the returned value here will be
		/// <see cref="Surface.ROTATION_90">Surface.ROTATION_90</see>
		/// .
		/// </remarks>
		public virtual int getRotation()
		{
			return getOrientation();
		}

		/// <summary>Return the native pixel format of the display.</summary>
		/// <remarks>
		/// Return the native pixel format of the display.  The returned value
		/// may be one of the constants int
		/// <see cref="android.graphics.PixelFormat">android.graphics.PixelFormat</see>
		/// .
		/// </remarks>
		public virtual int getPixelFormat()
		{
			return mPixelFormat;
		}

		/// <summary>Return the refresh rate of this display in frames per second.</summary>
		/// <remarks>Return the refresh rate of this display in frames per second.</remarks>
		public virtual float getRefreshRate()
		{
			return mRefreshRate;
		}

		/// <summary>Gets display metrics that describe the size and density of this display.
		/// 	</summary>
		/// <remarks>
		/// Gets display metrics that describe the size and density of this display.
		/// <p>
		/// The size is adjusted based on the current rotation of the display.
		/// </p><p>
		/// The size returned by this method does not necessarily represent the
		/// actual raw size (native resolution) of the display.  The returned size may
		/// be adjusted to exclude certain system decor elements that are always visible.
		/// It may also be scaled to provide compatibility with older applications that
		/// were originally designed for smaller displays.
		/// </p>
		/// </remarks>
		/// <param name="outMetrics">
		/// A
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// object to receive the metrics.
		/// </param>
		public virtual void getMetrics(android.util.DisplayMetrics outMetrics)
		{
			lock (mTmpPoint)
			{
				getSizeInternal(mTmpPoint, false);
				getMetricsWithSize(outMetrics, mTmpPoint.x, mTmpPoint.y);
			}
			android.content.res.CompatibilityInfo ci = mCompatibilityInfo.getIfNeeded();
			if (ci != null)
			{
				ci.applyToDisplayMetrics(outMetrics);
			}
		}

		/// <summary>Gets display metrics based on the real size of this display.</summary>
		/// <remarks>Gets display metrics based on the real size of this display.</remarks>
		/// <hide></hide>
		public virtual void getRealMetrics(android.util.DisplayMetrics outMetrics)
		{
			lock (mTmpPoint)
			{
				getRealSize(mTmpPoint);
				getMetricsWithSize(outMetrics, mTmpPoint.x, mTmpPoint.y);
			}
		}

		/// <summary>
		/// If the display is mirrored to an external HDMI display, returns the
		/// width of that display.
		/// </summary>
		/// <remarks>
		/// If the display is mirrored to an external HDMI display, returns the
		/// width of that display.
		/// </remarks>
		/// <hide></hide>
		public virtual int getRawExternalWidth()
		{
			return 1280;
		}

		/// <summary>
		/// If the display is mirrored to an external HDMI display, returns the
		/// height of that display.
		/// </summary>
		/// <remarks>
		/// If the display is mirrored to an external HDMI display, returns the
		/// height of that display.
		/// </remarks>
		/// <hide></hide>
		public virtual int getRawExternalHeight()
		{
			return 720;
		}

		/// <summary>Gets display metrics based on an explicit assumed display size.</summary>
		/// <remarks>Gets display metrics based on an explicit assumed display size.</remarks>
		/// <hide></hide>
		public virtual void getMetricsWithSize(android.util.DisplayMetrics outMetrics, int
			 width, int height)
		{
			outMetrics.densityDpi = (int)((mDensity * android.util.DisplayMetrics.DENSITY_DEFAULT
				) + .5f);
			outMetrics.noncompatWidthPixels = outMetrics.widthPixels = width;
			outMetrics.noncompatHeightPixels = outMetrics.heightPixels = height;
			outMetrics.density = outMetrics.noncompatDensity = mDensity;
			outMetrics.scaledDensity = outMetrics.noncompatScaledDensity = outMetrics.density;
			outMetrics.xdpi = outMetrics.noncompatXdpi = mDpiX;
			outMetrics.ydpi = outMetrics.noncompatYdpi = mDpiY;
		}

		private readonly android.view.CompatibilityInfoHolder mCompatibilityInfo;

		private readonly int mDisplay;

		private int mPixelFormat;

		private float mRefreshRate;

		internal float mDensity;

		internal float mDpiX;

		internal float mDpiY;

		private readonly android.graphics.Point mTmpPoint = new android.graphics.Point();

		private readonly android.util.DisplayMetrics mTmpMetrics = new android.util.DisplayMetrics
			();

		private float mLastGetTime;

		private static readonly object sStaticInit = new object();

		private static bool sInitialized = false;

		private static android.view.IWindowManager sWindowManager;

		// Following fields are initialized from native code
		/// <summary>Returns a display object which uses the metric's width/height instead.</summary>
		/// <remarks>Returns a display object which uses the metric's width/height instead.</remarks>
		/// <hide></hide>
		public static android.view.Display createCompatibleDisplay(int displayId, android.view.CompatibilityInfoHolder
			 compat)
		{
			return new android.view.Display(displayId, compat);
		}
	}
}
