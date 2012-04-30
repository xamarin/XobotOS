using System;
using System.Drawing;
using android.content.res;

namespace XobotOS.Runtime
{
	internal abstract class XobotDeviceConfig
	{
		public abstract Size Size {
			get;
		}

		internal abstract void updateConfig (Configuration config);

		public static XobotDeviceConfig DEFAULT = new DefaultConfig ();

		public static XobotDeviceConfig HANDHELD = new HandheldConfig ();

		public static XobotDeviceConfig TABLET = new TabletConfig ();

		public static XobotDeviceConfig getDevice (string name)
		{
			switch (name) {
			case "default":
				return DEFAULT;
			case "handheld":
				return HANDHELD;
			case "tablet":
				return TABLET;
			default:
				throw new ArgumentException ();
			}
		}

		private class DefaultConfig : XobotDeviceConfig
		{
			public override Size Size {
				get {
					return new Size (800, 600);
				}
			}

			internal override void updateConfig (android.content.res.Configuration config)
			{
				;
			}
		}

		private class HandheldConfig : XobotDeviceConfig
		{
			public override Size Size {
				get {
					return new Size (480, 800);
				}
			}

			internal override void updateConfig (android.content.res.Configuration config)
			{
				;
			}
		}

		private class TabletConfig : XobotDeviceConfig
		{
			public override Size Size {
				get {
					return new Size (1200, 800);
				}
			}

			internal override void updateConfig (android.content.res.Configuration config)
			{
				config.screenLayout = Configuration.SCREENLAYOUT_SIZE_LARGE;
			}
		}
	}
}

