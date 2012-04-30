using System;
using XobotOS.Runtime;
using SWF = System.Windows.Forms;
using android.graphics;

namespace android.view
{
	partial class Display
	{
		SWF.Screen screen;

		private static void nativeClassInit ()
		{
			; // Do nothing
		}

		private void init (int display)
		{
			this.screen = SWF.Screen.PrimaryScreen;
			// FIXME
			this.mPixelFormat = PixelFormat.UNKNOWN;
			this.mDensity = 1;
			this.mDpiX = 160;
			this.mDpiY = 160;
		}

		internal static IWindowManager getWindowManager ()
		{
			return null;
		}

		/// <summary>Returns the number of displays connected to the device.</summary>
		/// <remarks>
		/// Returns the number of displays connected to the device.  This is
		/// currently undefined; do not use.
		/// </remarks>
		internal static int getDisplayCount()
		{
			return SWF.Screen.AllScreens.Length;
		}

		/// <summary>Gets the raw width of the display, in pixels.</summary>
		/// <remarks>
		/// Gets the raw width of the display, in pixels.
		/// <p>
		/// The size is adjusted based on the current rotation of the display.
		/// </p>
		/// </remarks>
		/// <hide></hide>
		public virtual int getRawWidth ()
		{
			return XobotActivityManager.DeviceConfig.Size.Width;
		}

		/// <summary>Gets the raw height of the display, in pixels.</summary>
		/// <remarks>
		/// Gets the raw height of the display, in pixels.
		/// <p>
		/// The size is adjusted based on the current rotation of the display.
		/// </p>
		/// </remarks>
		/// <hide></hide>
		public virtual int getRawHeight ()
		{
			return XobotActivityManager.DeviceConfig.Size.Height;
		}

		/// <returns>orientation of this display.</returns>
		[System.ObsoleteAttribute(@"use getRotation()")]
		public virtual int getOrientation ()
		{
			return Surface.ROTATION_0;
		}
	}
}

