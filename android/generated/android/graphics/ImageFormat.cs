using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class ImageFormat
	{
		public const int UNKNOWN = 0;

		/// <summary>
		/// RGB format used for pictures encoded as RGB_565 see
		/// <see cref="android.hardware.Camera.Parameters.setPictureFormat(int)">android.hardware.Camera.Parameters.setPictureFormat(int)
		/// 	</see>
		/// .
		/// </summary>
		public const int RGB_565 = 4;

		/// <summary>
		/// Android YUV format:
		/// This format is exposed to software decoders and applications.
		/// </summary>
		/// <remarks>
		/// Android YUV format:
		/// This format is exposed to software decoders and applications.
		/// YV12 is a 4:2:0 YCrCb planar format comprised of a WxH Y plane followed
		/// by (W/2) x (H/2) Cr and Cb planes.
		/// This format assumes
		/// - an even width
		/// - an even height
		/// - a horizontal stride multiple of 16 pixels
		/// - a vertical stride equal to the height
		/// y_size = stride * height
		/// c_size = ALIGN(stride/2, 16) * height/2
		/// size = y_size + c_size * 2
		/// cr_offset = y_size
		/// cb_offset = y_size + c_size
		/// Whether this format is supported by the camera hardware can be determined
		/// by
		/// <see cref="android.hardware.Camera.Parameters.getSupportedPreviewFormats()">android.hardware.Camera.Parameters.getSupportedPreviewFormats()
		/// 	</see>
		/// .
		/// </remarks>
		public const int YV12 = unchecked((int)(0x32315659));

		/// <summary>YCbCr format, used for video.</summary>
		/// <remarks>
		/// YCbCr format, used for video. Whether this format is supported by the
		/// camera hardware can be determined by
		/// <see cref="android.hardware.Camera.Parameters.getSupportedPreviewFormats()">android.hardware.Camera.Parameters.getSupportedPreviewFormats()
		/// 	</see>
		/// .
		/// </remarks>
		public const int NV16 = unchecked((int)(0x10));

		/// <summary>YCrCb format used for images, which uses the NV21 encoding format.</summary>
		/// <remarks>
		/// YCrCb format used for images, which uses the NV21 encoding format. This
		/// is the default format for camera preview images, when not otherwise set
		/// with
		/// <see cref="android.hardware.Camera.Parameters.setPreviewFormat(int)">android.hardware.Camera.Parameters.setPreviewFormat(int)
		/// 	</see>
		/// .
		/// </remarks>
		public const int NV21 = unchecked((int)(0x11));

		/// <summary>YCbCr format used for images, which uses YUYV (YUY2) encoding format.</summary>
		/// <remarks>
		/// YCbCr format used for images, which uses YUYV (YUY2) encoding format.
		/// This is an alternative format for camera preview images. Whether this
		/// format is supported by the camera hardware can be determined by
		/// <see cref="android.hardware.Camera.Parameters.getSupportedPreviewFormats()">android.hardware.Camera.Parameters.getSupportedPreviewFormats()
		/// 	</see>
		/// .
		/// </remarks>
		public const int YUY2 = unchecked((int)(0x14));

		/// <summary>Encoded formats.</summary>
		/// <remarks>Encoded formats. These are not necessarily supported by the hardware.</remarks>
		public const int JPEG = unchecked((int)(0x100));

		/// <summary>
		/// Raw bayer format used for images, which is 10 bit precision samples
		/// stored in 16 bit words.
		/// </summary>
		/// <remarks>
		/// Raw bayer format used for images, which is 10 bit precision samples
		/// stored in 16 bit words. The filter pattern is RGGB. Whether this format
		/// is supported by the camera hardware can be determined by
		/// <see cref="android.hardware.Camera.Parameters.getSupportedPreviewFormats()">android.hardware.Camera.Parameters.getSupportedPreviewFormats()
		/// 	</see>
		/// .
		/// </remarks>
		/// <hide></hide>
		public const int BAYER_RGGB = unchecked((int)(0x200));

		/// <summary>
		/// Use this function to retrieve the number of bits per pixel of an
		/// ImageFormat.
		/// </summary>
		/// <remarks>
		/// Use this function to retrieve the number of bits per pixel of an
		/// ImageFormat.
		/// </remarks>
		/// <param name="format"></param>
		/// <returns>
		/// the number of bits per pixel of the given format or -1 if the
		/// format doesn't exist or is not supported.
		/// </returns>
		public static int getBitsPerPixel(int format)
		{
			switch (format)
			{
				case RGB_565:
				{
					return 16;
				}

				case NV16:
				{
					return 16;
				}

				case YUY2:
				{
					return 16;
				}

				case YV12:
				{
					return 12;
				}

				case NV21:
				{
					return 12;
				}

				case BAYER_RGGB:
				{
					return 16;
				}
			}
			return -1;
		}
	}
}
