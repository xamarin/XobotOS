using Sharpen;

namespace android.graphics
{
	[Sharpen.Stub]
	public sealed class BitmapRegionDecoder
	{
		private int mNativeBitmapRegionDecoder;

		private bool mRecycled;

		[Sharpen.Stub]
		public static android.graphics.BitmapRegionDecoder newInstance(byte[] data, int offset
			, int length, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.BitmapRegionDecoder newInstance(java.io.FileDescriptor
			 fd, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.BitmapRegionDecoder newInstance(java.io.InputStream
			 @is, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.BitmapRegionDecoder newInstance(string pathName, bool
			 isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private BitmapRegionDecoder(int decoder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.graphics.Bitmap decodeRegion(android.graphics.Rect rect, android.graphics.BitmapFactory
			.Options options)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isRecycled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void checkRecycled(string errorMessage)
		{
			throw new System.NotImplementedException();
		}

		~BitmapRegionDecoder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.Bitmap nativeDecodeRegion(int lbm, int start_x, int
			 start_y, int width, int height, android.graphics.BitmapFactory.Options options)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeGetWidth(int lbm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeGetHeight(int lbm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeClean(int lbm)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.BitmapRegionDecoder nativeNewInstance(byte[] data
			, int offset, int length, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.BitmapRegionDecoder nativeNewInstance(java.io.FileDescriptor
			 fd, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.BitmapRegionDecoder nativeNewInstance(java.io.InputStream
			 @is, byte[] storage, bool isShareable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.graphics.BitmapRegionDecoder nativeNewInstance(int asset, 
			bool isShareable)
		{
			throw new System.NotImplementedException();
		}
	}
}
