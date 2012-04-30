using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// YuvImage contains YUV data and provides a method that compresses a region of
	/// the YUV data to a Jpeg.
	/// </summary>
	/// <remarks>
	/// YuvImage contains YUV data and provides a method that compresses a region of
	/// the YUV data to a Jpeg. The YUV data should be provided as a single byte
	/// array irrespective of the number of image planes in it.
	/// Currently only ImageFormat.NV21 and ImageFormat.YUY2 are supported.
	/// To compress a rectangle region in the YUV data, users have to specify the
	/// region by left, top, width and height.
	/// </remarks>
	[Sharpen.Sharpened]
	public class YuvImage
	{
		/// <summary>
		/// Number of bytes of temp storage we use for communicating between the
		/// native compressor and the java OutputStream.
		/// </summary>
		/// <remarks>
		/// Number of bytes of temp storage we use for communicating between the
		/// native compressor and the java OutputStream.
		/// </remarks>
		internal const int WORKING_COMPRESS_STORAGE = 4096;

		/// <summary>
		/// The YUV format as defined in
		/// <see cref="ImageFormat">ImageFormat</see>
		/// .
		/// </summary>
		private int mFormat;

		/// <summary>The raw YUV data.</summary>
		/// <remarks>
		/// The raw YUV data.
		/// In the case of more than one image plane, the image planes must be
		/// concatenated into a single byte array.
		/// </remarks>
		private byte[] mData;

		/// <summary>The number of row bytes in each image plane.</summary>
		/// <remarks>The number of row bytes in each image plane.</remarks>
		private int[] mStrides;

		/// <summary>The width of the image.</summary>
		/// <remarks>The width of the image.</remarks>
		private int mWidth;

		/// <summary>The height of the the image.</summary>
		/// <remarks>The height of the the image.</remarks>
		private int mHeight;

		/// <summary>Construct an YuvImage.</summary>
		/// <remarks>Construct an YuvImage.</remarks>
		/// <param name="yuv">
		/// The YUV data. In the case of more than one image plane, all the planes must be
		/// concatenated into a single byte array.
		/// </param>
		/// <param name="format">
		/// The YUV data format as defined in
		/// <see cref="ImageFormat">ImageFormat</see>
		/// .
		/// </param>
		/// <param name="width">The width of the YuvImage.</param>
		/// <param name="height">The height of the YuvImage.</param>
		/// <param name="strides">
		/// (Optional) Row bytes of each image plane. If yuv contains padding, the stride
		/// of each image must be provided. If strides is null, the method assumes no
		/// padding and derives the row bytes by format and width itself.
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if format is not support; width or height &lt;= 0; or yuv is
		/// null.
		/// </exception>
		public YuvImage(byte[] yuv, int format, int width, int height, int[] strides)
		{
			if (format != android.graphics.ImageFormat.NV21 && format != android.graphics.ImageFormat
				.YUY2)
			{
				throw new System.ArgumentException("only support ImageFormat.NV21 " + "and ImageFormat.YUY2 for now"
					);
			}
			if (width <= 0 || height <= 0)
			{
				throw new System.ArgumentException("width and height must large than 0");
			}
			if (yuv == null)
			{
				throw new System.ArgumentException("yuv cannot be null");
			}
			if (strides == null)
			{
				mStrides = calculateStrides(width, format);
			}
			else
			{
				mStrides = strides;
			}
			mData = yuv;
			mFormat = format;
			mWidth = width;
			mHeight = height;
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"java.io has not yet been ported.")]
		public virtual bool compressToJpeg(android.graphics.Rect rectangle, int quality, 
			java.io.OutputStream stream)
		{
			throw new System.NotImplementedException();
		}

		/// <returns>the YUV data.</returns>
		public virtual byte[] getYuvData()
		{
			return mData;
		}

		/// <returns>
		/// the YUV format as defined in
		/// <see cref="ImageFormat">ImageFormat</see>
		/// .
		/// </returns>
		public virtual int getYuvFormat()
		{
			return mFormat;
		}

		/// <returns>the number of row bytes in each image plane.</returns>
		public virtual int[] getStrides()
		{
			return mStrides;
		}

		/// <returns>the width of the image.</returns>
		public virtual int getWidth()
		{
			return mWidth;
		}

		/// <returns>the height of the image.</returns>
		public virtual int getHeight()
		{
			return mHeight;
		}

		internal virtual int[] calculateOffsets(int left, int top)
		{
			int[] offsets = null;
			if (mFormat == android.graphics.ImageFormat.NV21)
			{
				offsets = new int[] { top * mStrides[0] + left, mHeight * mStrides[0] + top / 2 *
					 mStrides[1] + left / 2 * 2 };
				return offsets;
			}
			if (mFormat == android.graphics.ImageFormat.YUY2)
			{
				offsets = new int[] { top * mStrides[0] + left / 2 * 4 };
				return offsets;
			}
			return offsets;
		}

		private int[] calculateStrides(int width, int format)
		{
			int[] strides = null;
			if (format == android.graphics.ImageFormat.NV21)
			{
				strides = new int[] { width, width };
				return strides;
			}
			if (format == android.graphics.ImageFormat.YUY2)
			{
				strides = new int[] { width * 2 };
				return strides;
			}
			return strides;
		}

		private void adjustRectangle(android.graphics.Rect rect)
		{
			int width = rect.width();
			int height = rect.height();
			if (mFormat == android.graphics.ImageFormat.NV21)
			{
				// Make sure left, top, width and height are all even.
				width &= ~1;
				height &= ~1;
				rect.left &= ~1;
				rect.top &= ~1;
				rect.right = rect.left + width;
				rect.bottom = rect.top + height;
			}
			if (mFormat == android.graphics.ImageFormat.YUY2)
			{
				// Make sure left and width are both even.
				width &= ~1;
				rect.left &= ~1;
				rect.right = rect.left + width;
			}
		}
		//////////// native methods
	}
}
