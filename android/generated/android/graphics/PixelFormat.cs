using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PixelFormat
	{
		public const int UNKNOWN = 0;

		/// <summary>System chooses a format that supports translucency (many alpha bits)</summary>
		public const int TRANSLUCENT = -3;

		/// <summary>
		/// System chooses a format that supports transparency
		/// (at least 1 alpha bit)
		/// </summary>
		public const int TRANSPARENT = -2;

		/// <summary>System chooses an opaque format (no alpha bits required)</summary>
		public const int OPAQUE = -1;

		public const int RGBA_8888 = 1;

		public const int RGBX_8888 = 2;

		public const int RGB_888 = 3;

		public const int RGB_565 = 4;

		public const int RGBA_5551 = 6;

		public const int RGBA_4444 = 7;

		public const int A_8 = 8;

		public const int L_8 = 9;

		public const int LA_88 = unchecked((int)(0xA));

		public const int RGB_332 = unchecked((int)(0xB));

		[System.ObsoleteAttribute(@"use ImageFormat.NV16 ImageFormat.NV16 instead.")]
		public const int YCbCr_422_SP = unchecked((int)(0x10));

		[System.ObsoleteAttribute(@"use ImageFormat.NV21 ImageFormat.NV21 instead.")]
		public const int YCbCr_420_SP = unchecked((int)(0x11));

		[System.ObsoleteAttribute(@"use ImageFormat.YUY2 ImageFormat.YUY2 instead.")]
		public const int YCbCr_422_I = unchecked((int)(0x14));

		[System.ObsoleteAttribute(@"use ImageFormat.JPEG ImageFormat.JPEG instead.")]
		public const int JPEG = unchecked((int)(0x100));

		public static bool formatHasAlpha(int format)
		{
			switch (format)
			{
				case android.graphics.PixelFormat.A_8:
				case android.graphics.PixelFormat.LA_88:
				case android.graphics.PixelFormat.RGBA_4444:
				case android.graphics.PixelFormat.RGBA_5551:
				case android.graphics.PixelFormat.RGBA_8888:
				case android.graphics.PixelFormat.TRANSLUCENT:
				case android.graphics.PixelFormat.TRANSPARENT:
				{
					return true;
				}
			}
			return false;
		}

		public int bytesPerPixel;

		public int bitsPerPixel;
	}
}
