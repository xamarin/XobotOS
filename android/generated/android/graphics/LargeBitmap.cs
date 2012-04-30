using Sharpen;

namespace android.graphics
{
	/// <summary>LargeBitmap can be used to decode a rectangle region from an image.</summary>
	/// <remarks>
	/// LargeBitmap can be used to decode a rectangle region from an image.
	/// LargeBimap is particularly useful when an original image is large and
	/// you only need parts of the image.
	/// To create a LargeBitmap, call BitmapFactory.createLargeBitmap().
	/// Given a LargeBitmap, users can call decodeRegion() repeatedly
	/// to get a decoded Bitmap of the specified region.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class LargeBitmap
	{
		private int mNativeLargeBitmap;

		private bool mRecycled;

		private LargeBitmap(int lbm)
		{
			mNativeLargeBitmap = lbm;
			mRecycled = false;
		}

		/// <summary>Decodes a rectangle region in the image specified by rect.</summary>
		/// <remarks>Decodes a rectangle region in the image specified by rect.</remarks>
		/// <param name="rect">The rectangle that specified the region to be decode.</param>
		/// <param name="opts">
		/// null-ok; Options that control downsampling.
		/// inPurgeable is not supported.
		/// </param>
		/// <returns>
		/// The decoded bitmap, or null if the image data could not be
		/// decoded.
		/// </returns>
		public android.graphics.Bitmap decodeRegion(android.graphics.Rect rect, android.graphics.BitmapFactory
			.Options options)
		{
			checkRecycled("decodeRegion called on recycled large bitmap");
			if (rect.left < 0 || rect.top < 0 || rect.right > getWidth() || rect.bottom > getHeight
				())
			{
				throw new System.ArgumentException("rectangle is not inside the image");
			}
			return nativeDecodeRegion(mNativeLargeBitmap, rect.left, rect.top, rect.right - rect
				.left, rect.bottom - rect.top, options);
		}

		/// <summary>Returns the original image's width</summary>
		public int getWidth()
		{
			checkRecycled("getWidth called on recycled large bitmap");
			return nativeGetWidth(mNativeLargeBitmap);
		}

		/// <summary>Returns the original image's height</summary>
		public int getHeight()
		{
			checkRecycled("getHeight called on recycled large bitmap");
			return nativeGetHeight(mNativeLargeBitmap);
		}

		/// <summary>
		/// Frees up the memory associated with this large bitmap, and mark the
		/// large bitmap as "dead", meaning it will throw an exception if decodeRegion(),
		/// getWidth() or getHeight() is called.
		/// </summary>
		/// <remarks>
		/// Frees up the memory associated with this large bitmap, and mark the
		/// large bitmap as "dead", meaning it will throw an exception if decodeRegion(),
		/// getWidth() or getHeight() is called.
		/// This operation cannot be reversed, so it should only be called if you are
		/// sure there are no further uses for the large bitmap. This is an advanced call,
		/// and normally need not be called, since the normal GC process will free up this
		/// memory when there are no more references to this bitmap.
		/// </remarks>
		public void recycle()
		{
			if (!mRecycled)
			{
				nativeClean(mNativeLargeBitmap);
				mRecycled = true;
			}
		}

		/// <summary>Returns true if this large bitmap has been recycled.</summary>
		/// <remarks>
		/// Returns true if this large bitmap has been recycled.
		/// If so, then it is an error to try use its method.
		/// </remarks>
		/// <returns>true if the large bitmap has been recycled</returns>
		public bool isRecycled()
		{
			return mRecycled;
		}

		/// <summary>
		/// Called by methods that want to throw an exception if the bitmap
		/// has already been recycled.
		/// </summary>
		/// <remarks>
		/// Called by methods that want to throw an exception if the bitmap
		/// has already been recycled.
		/// </remarks>
		private void checkRecycled(string errorMessage)
		{
			if (mRecycled)
			{
				throw new System.InvalidOperationException(errorMessage);
			}
		}

		~LargeBitmap()
		{
			recycle();
		}

		[Sharpen.NativeStub]
		private static android.graphics.Bitmap nativeDecodeRegion(int lbm, int start_x, int
			 start_y, int width, int height, android.graphics.BitmapFactory.Options options)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static int nativeGetWidth(int lbm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static int nativeGetHeight(int lbm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private static void nativeClean(int lbm)
		{
			throw new System.NotImplementedException();
		}
	}
}
