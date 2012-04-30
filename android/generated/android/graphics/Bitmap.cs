using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public sealed partial class Bitmap : android.os.Parcelable, System.IDisposable
	{
		/// <summary>Indicates that the bitmap was created for an unknown pixel density.</summary>
		/// <remarks>Indicates that the bitmap was created for an unknown pixel density.</remarks>
		/// <seealso cref="getDensity()">getDensity()</seealso>
		/// <seealso cref="setDensity(int)">setDensity(int)</seealso>
		public const int DENSITY_NONE = 0;

		/// <summary>
		/// Note:  mNativeBitmap is used by FaceDetector_jni.cpp
		/// Don't change/rename without updating FaceDetector_jni.cpp
		/// </summary>
		/// <hide></hide>
		internal readonly android.graphics.Bitmap.NativeBitmap mNativeBitmap;

		/// <summary>Backing buffer for the Bitmap.</summary>
		/// <remarks>
		/// Backing buffer for the Bitmap.
		/// Made public for quick access from drawing methods -- do NOT modify
		/// from outside this class.
		/// </remarks>
		/// <hide></hide>
		private byte[] mBuffer;

		private readonly android.graphics.Bitmap.BitmapFinalizer mFinalizer;

		private byte[] mNinePatchChunk;

		private int mWidth = -1;

		private int mHeight = -1;

		private bool mRecycled;

		internal int mDensity = sDefaultDensity = getDefaultDensity();

		private static volatile android.graphics.Matrix sScaleMatrix;

		private static volatile int sDefaultDensity = -1;

		// Keep to finalize native resources
		// may be null
		// Package-scoped for fast access.
		/// <summary>
		/// For backwards compatibility, allows the app layer to change the default
		/// density when running old apps.
		/// </summary>
		/// <remarks>
		/// For backwards compatibility, allows the app layer to change the default
		/// density when running old apps.
		/// </remarks>
		/// <hide></hide>
		public static void setDefaultDensity(int density)
		{
			sDefaultDensity = density;
		}

		internal static int getDefaultDensity()
		{
			if (sDefaultDensity >= 0)
			{
				return sDefaultDensity;
			}
			sDefaultDensity = android.util.DisplayMetrics.DENSITY_DEVICE;
			return sDefaultDensity;
		}

		// we delete this in our finalizer
		/// <summary>
		/// <p>Returns the density for this bitmap.</p>
		/// <p>The default density is the same density as the current display,
		/// unless the current application does not support different screen
		/// densities in which case it is
		/// <see cref="android.util.DisplayMetrics.DENSITY_DEFAULT">android.util.DisplayMetrics.DENSITY_DEFAULT
		/// 	</see>
		/// .  Note that
		/// compatibility mode is determined by the application that was initially
		/// loaded into a process -- applications that share the same process should
		/// all have the same compatibility, or ensure they explicitly set the
		/// density of their bitmaps appropriately.</p>
		/// </summary>
		/// <returns>
		/// A scaling factor of the default density or
		/// <see cref="DENSITY_NONE">DENSITY_NONE</see>
		/// if the scaling factor is unknown.
		/// </returns>
		/// <seealso cref="setDensity(int)">setDensity(int)</seealso>
		/// <seealso cref="android.util.DisplayMetrics.DENSITY_DEFAULT">android.util.DisplayMetrics.DENSITY_DEFAULT
		/// 	</seealso>
		/// <seealso cref="android.util.DisplayMetrics.densityDpi">android.util.DisplayMetrics.densityDpi
		/// 	</seealso>
		/// <seealso cref="DENSITY_NONE">DENSITY_NONE</seealso>
		public int getDensity()
		{
			return mDensity;
		}

		/// <summary><p>Specifies the density for this bitmap.</summary>
		/// <remarks>
		/// <p>Specifies the density for this bitmap.  When the bitmap is
		/// drawn to a Canvas that also has a density, it will be scaled
		/// appropriately.</p>
		/// </remarks>
		/// <param name="density">
		/// The density scaling factor to use with this bitmap or
		/// <see cref="DENSITY_NONE">DENSITY_NONE</see>
		/// if the density is unknown.
		/// </param>
		/// <seealso cref="getDensity()">getDensity()</seealso>
		/// <seealso cref="android.util.DisplayMetrics.DENSITY_DEFAULT">android.util.DisplayMetrics.DENSITY_DEFAULT
		/// 	</seealso>
		/// <seealso cref="android.util.DisplayMetrics.densityDpi">android.util.DisplayMetrics.densityDpi
		/// 	</seealso>
		/// <seealso cref="DENSITY_NONE">DENSITY_NONE</seealso>
		public void setDensity(int density)
		{
			mDensity = density;
		}

		/// <summary>Sets the nine patch chunk.</summary>
		/// <remarks>Sets the nine patch chunk.</remarks>
		/// <param name="chunk">The definition of the nine patch</param>
		/// <hide></hide>
		public void setNinePatchChunk(byte[] chunk)
		{
			mNinePatchChunk = chunk;
		}

		/// <summary>
		/// Free the native object associated with this bitmap, and clear the
		/// reference to the pixel data.
		/// </summary>
		/// <remarks>
		/// Free the native object associated with this bitmap, and clear the
		/// reference to the pixel data. This will not free the pixel data synchronously;
		/// it simply allows it to be garbage collected if there are no other references.
		/// The bitmap is marked as "dead", meaning it will throw an exception if
		/// getPixels() or setPixels() is called, and will draw nothing. This operation
		/// cannot be reversed, so it should only be called if you are sure there are no
		/// further uses for the bitmap. This is an advanced call, and normally need
		/// not be called, since the normal GC process will free up this memory when
		/// there are no more references to this bitmap.
		/// </remarks>
		public void recycle()
		{
			if (!mRecycled)
			{
				mBuffer = null;
				nativeRecycle(mNativeBitmap);
				mNinePatchChunk = null;
				mRecycled = true;
			}
		}

		/// <summary>Returns true if this bitmap has been recycled.</summary>
		/// <remarks>
		/// Returns true if this bitmap has been recycled. If so, then it is an error
		/// to try to access its pixels, and the bitmap will not draw.
		/// </remarks>
		/// <returns>true if the bitmap has been recycled</returns>
		public bool isRecycled()
		{
			return mRecycled;
		}

		/// <summary>Returns the generation ID of this bitmap.</summary>
		/// <remarks>
		/// Returns the generation ID of this bitmap. The generation ID changes
		/// whenever the bitmap is modified. This can be used as an efficient way to
		/// check if a bitmap has changed.
		/// </remarks>
		/// <returns>The current generation ID for this bitmap.</returns>
		public int getGenerationId()
		{
			return nativeGenerationId(mNativeBitmap);
		}

		/// <summary>
		/// This is called by methods that want to throw an exception if the bitmap
		/// has already been recycled.
		/// </summary>
		/// <remarks>
		/// This is called by methods that want to throw an exception if the bitmap
		/// has already been recycled.
		/// </remarks>
		private void checkRecycled(string errorMessage)
		{
			if (mRecycled)
			{
				throw new System.InvalidOperationException(errorMessage);
			}
		}

		/// <summary>Common code for checking that x and y are &gt;= 0</summary>
		/// <param name="x">x coordinate to ensure is &gt;= 0</param>
		/// <param name="y">y coordinate to ensure is &gt;= 0</param>
		private static void checkXYSign(int x, int y)
		{
			if (x < 0)
			{
				throw new System.ArgumentException("x must be >= 0");
			}
			if (y < 0)
			{
				throw new System.ArgumentException("y must be >= 0");
			}
		}

		/// <summary>Common code for checking that width and height are &gt; 0</summary>
		/// <param name="width">width to ensure is &gt; 0</param>
		/// <param name="height">height to ensure is &gt; 0</param>
		private static void checkWidthHeight(int width, int height)
		{
			if (width <= 0)
			{
				throw new System.ArgumentException("width must be > 0");
			}
			if (height <= 0)
			{
				throw new System.ArgumentException("height must be > 0");
			}
		}

		/// <summary>Possible bitmap configurations.</summary>
		/// <remarks>
		/// Possible bitmap configurations. A bitmap configuration describes
		/// how pixels are stored. This affects the quality (color depth) as
		/// well as the ability to display transparent/translucent colors.
		/// </remarks>
		public enum Config : int
		{
			/// <summary>Each pixel is stored as a single translucency (alpha) channel.</summary>
			/// <remarks>
			/// Each pixel is stored as a single translucency (alpha) channel.
			/// This is very useful to efficiently store masks for instance.
			/// No color information is stored.
			/// With this configuration, each pixel requires 1 byte of memory.
			/// </remarks>
			ALPHA_8 = 2,
			/// <summary>
			/// Each pixel is stored on 2 bytes and only the RGB channels are
			/// encoded: red is stored with 5 bits of precision (32 possible
			/// values), green is stored with 6 bits of precision (64 possible
			/// values) and blue is stored with 5 bits of precision.
			/// </summary>
			/// <remarks>
			/// Each pixel is stored on 2 bytes and only the RGB channels are
			/// encoded: red is stored with 5 bits of precision (32 possible
			/// values), green is stored with 6 bits of precision (64 possible
			/// values) and blue is stored with 5 bits of precision.
			/// This configuration can produce slight visual artifacts depending
			/// on the configuration of the source. For instance, without
			/// dithering, the result might show a greenish tint. To get better
			/// results dithering should be applied.
			/// This configuration may be useful when using opaque bitmaps
			/// that do not require high color fidelity.
			/// </remarks>
			RGB_565 = 4,
			/// <summary>Each pixel is stored on 2 bytes.</summary>
			/// <remarks>
			/// Each pixel is stored on 2 bytes. The three RGB color channels
			/// and the alpha channel (translucency) are stored with a 4 bits
			/// precision (16 possible values.)
			/// This configuration is mostly useful if the application needs
			/// to store translucency information but also needs to save
			/// memory.
			/// It is recommended to use
			/// <see cref="Config.ARGB_8888">Config.ARGB_8888</see>
			/// instead of this
			/// configuration.
			/// </remarks>
			ARGB_4444 = 5,
			/// <summary>Each pixel is stored on 4 bytes.</summary>
			/// <remarks>
			/// Each pixel is stored on 4 bytes. Each channel (RGB and alpha
			/// for translucency) is stored with 8 bits of precision (256
			/// possible values.)
			/// This configuration is very flexible and offers the best
			/// quality. It should be used whenever possible.
			/// </remarks>
			ARGB_8888 = 6
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"java.nio.Buffer has not yet been ported.")]
		public void copyPixelsFromBuffer(java.nio.Buffer src)
		{
			throw new System.NotImplementedException();
		}

		// these native values must match up with the enum in SkBitmap.h
		// now update the buffer's position
		/// <summary>
		/// Tries to make a new bitmap based on the dimensions of this bitmap,
		/// setting the new bitmap's config to the one specified, and then copying
		/// this bitmap's pixels into the new bitmap.
		/// </summary>
		/// <remarks>
		/// Tries to make a new bitmap based on the dimensions of this bitmap,
		/// setting the new bitmap's config to the one specified, and then copying
		/// this bitmap's pixels into the new bitmap. If the conversion is not
		/// supported, or the allocator fails, then this returns NULL.  The returned
		/// bitmap initially has the same density as the original.
		/// </remarks>
		/// <param name="config">The desired config for the resulting bitmap</param>
		/// <param name="isMutable">
		/// True if the resulting bitmap should be mutable (i.e.
		/// its pixels can be modified)
		/// </param>
		/// <returns>the new bitmap, or null if the copy could not be made.</returns>
		public android.graphics.Bitmap copy(android.graphics.Bitmap.Config config, bool isMutable_1
			)
		{
			checkRecycled("Can't copy a recycled bitmap");
			android.graphics.Bitmap b = nativeCopy(mNativeBitmap, (int)config, isMutable_1);
			if (b != null)
			{
				b.mDensity = mDensity;
			}
			return b;
		}

		/// <summary>Creates a new bitmap, scaled from an existing bitmap.</summary>
		/// <remarks>Creates a new bitmap, scaled from an existing bitmap.</remarks>
		/// <param name="src">The source bitmap.</param>
		/// <param name="dstWidth">The new bitmap's desired width.</param>
		/// <param name="dstHeight">The new bitmap's desired height.</param>
		/// <param name="filter">true if the source should be filtered.</param>
		/// <returns>the new scaled bitmap.</returns>
		public static android.graphics.Bitmap createScaledBitmap(android.graphics.Bitmap 
			src, int dstWidth, int dstHeight, bool filter)
		{
			android.graphics.Matrix m;
			lock (typeof(android.graphics.Bitmap))
			{
				// small pool of just 1 matrix
				m = sScaleMatrix;
				sScaleMatrix = null;
			}
			if (m == null)
			{
				m = new android.graphics.Matrix();
			}
			int width = src.getWidth();
			int height = src.getHeight();
			float sx = dstWidth / (float)width;
			float sy = dstHeight / (float)height;
			m.setScale(sx, sy);
			android.graphics.Bitmap b = android.graphics.Bitmap.createBitmap(src, 0, 0, width
				, height, m, filter);
			lock (typeof(android.graphics.Bitmap))
			{
				// do we need to check for null? why not just assign everytime?
				if (sScaleMatrix == null)
				{
					sScaleMatrix = m;
				}
			}
			return b;
		}

		/// <summary>Returns an immutable bitmap from the source bitmap.</summary>
		/// <remarks>
		/// Returns an immutable bitmap from the source bitmap. The new bitmap may
		/// be the same object as source, or a copy may have been made.  It is
		/// initialized with the same density as the original bitmap.
		/// </remarks>
		public static android.graphics.Bitmap createBitmap(android.graphics.Bitmap src)
		{
			return createBitmap(src, 0, 0, src.getWidth(), src.getHeight());
		}

		/// <summary>
		/// Returns an immutable bitmap from the specified subset of the source
		/// bitmap.
		/// </summary>
		/// <remarks>
		/// Returns an immutable bitmap from the specified subset of the source
		/// bitmap. The new bitmap may be the same object as source, or a copy may
		/// have been made.  It is
		/// initialized with the same density as the original bitmap.
		/// </remarks>
		/// <param name="source">The bitmap we are subsetting</param>
		/// <param name="x">The x coordinate of the first pixel in source</param>
		/// <param name="y">The y coordinate of the first pixel in source</param>
		/// <param name="width">The number of pixels in each row</param>
		/// <param name="height">The number of rows</param>
		public static android.graphics.Bitmap createBitmap(android.graphics.Bitmap source
			, int x, int y, int width, int height)
		{
			return createBitmap(source, x, y, width, height, null, false);
		}

		/// <summary>
		/// Returns an immutable bitmap from subset of the source bitmap,
		/// transformed by the optional matrix.
		/// </summary>
		/// <remarks>
		/// Returns an immutable bitmap from subset of the source bitmap,
		/// transformed by the optional matrix.  It is
		/// initialized with the same density as the original bitmap.
		/// </remarks>
		/// <param name="source">The bitmap we are subsetting</param>
		/// <param name="x">The x coordinate of the first pixel in source</param>
		/// <param name="y">The y coordinate of the first pixel in source</param>
		/// <param name="width">The number of pixels in each row</param>
		/// <param name="height">The number of rows</param>
		/// <param name="m">Optional matrix to be applied to the pixels</param>
		/// <param name="filter">
		/// true if the source should be filtered.
		/// Only applies if the matrix contains more than just
		/// translation.
		/// </param>
		/// <returns>A bitmap that represents the specified subset of source</returns>
		/// <exception cref="System.ArgumentException">
		/// if the x, y, width, height values are
		/// outside of the dimensions of the source bitmap.
		/// </exception>
		public static android.graphics.Bitmap createBitmap(android.graphics.Bitmap source
			, int x, int y, int width, int height, android.graphics.Matrix m, bool filter)
		{
			checkXYSign(x, y);
			checkWidthHeight(width, height);
			if (x + width > source.getWidth())
			{
				throw new System.ArgumentException("x + width must be <= bitmap.width()");
			}
			if (y + height > source.getHeight())
			{
				throw new System.ArgumentException("y + height must be <= bitmap.height()");
			}
			// check if we can just return our argument unchanged
			if (!source.isMutable() && x == 0 && y == 0 && width == source.getWidth() && height
				 == source.getHeight() && (m == null || m.isIdentity()))
			{
				return source;
			}
			int neww = width;
			int newh = height;
			android.graphics.Canvas canvas = new android.graphics.Canvas();
			android.graphics.Bitmap bitmap;
			android.graphics.Paint paint;
			android.graphics.Rect srcR = new android.graphics.Rect(x, y, x + width, y + height
				);
			android.graphics.RectF dstR = new android.graphics.RectF(0, 0, width, height);
			android.graphics.Bitmap.Config newConfig = android.graphics.Bitmap.Config.ARGB_8888;
			android.graphics.Bitmap.Config config = source.getConfig();
			// GIF files generate null configs, assume ARGB_8888
			if (config != null)
			{
				switch (config)
				{
					case android.graphics.Bitmap.Config.RGB_565:
					{
						newConfig = android.graphics.Bitmap.Config.RGB_565;
						break;
					}

					case android.graphics.Bitmap.Config.ALPHA_8:
					{
						newConfig = android.graphics.Bitmap.Config.ALPHA_8;
						break;
					}

					case android.graphics.Bitmap.Config.ARGB_4444:
					case android.graphics.Bitmap.Config.ARGB_8888:
					default:
					{
						//noinspection deprecation
						newConfig = android.graphics.Bitmap.Config.ARGB_8888;
						break;
					}
				}
			}
			if (m == null || m.isIdentity())
			{
				bitmap = createBitmap(neww, newh, newConfig, source.hasAlpha());
				paint = null;
			}
			else
			{
				// not needed
				bool transformed = !m.rectStaysRect();
				android.graphics.RectF deviceR = new android.graphics.RectF();
				m.mapRect(deviceR, dstR);
				neww = Sharpen.Util.Round(deviceR.width());
				newh = Sharpen.Util.Round(deviceR.height());
				bitmap = createBitmap(neww, newh, transformed ? android.graphics.Bitmap.Config.ARGB_8888
					 : newConfig, transformed || source.hasAlpha());
				canvas.translate(-deviceR.left, -deviceR.top);
				canvas.concat(m);
				paint = new android.graphics.Paint();
				paint.setFilterBitmap(filter);
				if (transformed)
				{
					paint.setAntiAlias(true);
				}
			}
			// The new bitmap was created from a known bitmap source so assume that
			// they use the same density
			bitmap.mDensity = source.mDensity;
			canvas.setBitmap(bitmap);
			canvas.drawBitmap(source, srcR, dstR, paint);
			canvas.setBitmap(null);
			return bitmap;
		}

		/// <summary>Returns a mutable bitmap with the specified width and height.</summary>
		/// <remarks>
		/// Returns a mutable bitmap with the specified width and height.  Its
		/// initial density is as per
		/// <see cref="getDensity()">getDensity()</see>
		/// .
		/// </remarks>
		/// <param name="width">The width of the bitmap</param>
		/// <param name="height">The height of the bitmap</param>
		/// <param name="config">The bitmap config to create.</param>
		/// <exception cref="System.ArgumentException">if the width or height are &lt;= 0</exception>
		public static android.graphics.Bitmap createBitmap(int width, int height, android.graphics.Bitmap
			.Config config)
		{
			return createBitmap(width, height, config, true);
		}

		/// <summary>Returns a mutable bitmap with the specified width and height.</summary>
		/// <remarks>
		/// Returns a mutable bitmap with the specified width and height.  Its
		/// initial density is as per
		/// <see cref="getDensity()">getDensity()</see>
		/// .
		/// </remarks>
		/// <param name="width">The width of the bitmap</param>
		/// <param name="height">The height of the bitmap</param>
		/// <param name="config">The bitmap config to create.</param>
		/// <param name="hasAlpha">
		/// If the bitmap is ARGB_8888 this flag can be used to mark the
		/// bitmap as opaque. Doing so will clear the bitmap in black
		/// instead of transparent.
		/// </param>
		/// <exception cref="System.ArgumentException">if the width or height are &lt;= 0</exception>
		private static android.graphics.Bitmap createBitmap(int width, int height, android.graphics.Bitmap
			.Config config, bool hasAlpha_1)
		{
			if (width <= 0 || height <= 0)
			{
				throw new System.ArgumentException("width and height must be > 0");
			}
			android.graphics.Bitmap bm = nativeCreate(null, 0, width, width, height, (int)config
				, true);
			if (config == android.graphics.Bitmap.Config.ARGB_8888 && !hasAlpha_1)
			{
				bm.eraseColor(unchecked((int)(0xff000000)));
				nativeSetHasAlpha(bm.mNativeBitmap, hasAlpha_1);
			}
			else
			{
				bm.eraseColor(0);
			}
			return bm;
		}

		/// <summary>
		/// Returns a immutable bitmap with the specified width and height, with each
		/// pixel value set to the corresponding value in the colors array.
		/// </summary>
		/// <remarks>
		/// Returns a immutable bitmap with the specified width and height, with each
		/// pixel value set to the corresponding value in the colors array.  Its
		/// initial density is as per
		/// <see cref="getDensity()">getDensity()</see>
		/// .
		/// </remarks>
		/// <param name="colors">
		/// Array of
		/// <see cref="Color">Color</see>
		/// used to initialize the pixels.
		/// </param>
		/// <param name="offset">
		/// Number of values to skip before the first color in the
		/// array of colors.
		/// </param>
		/// <param name="stride">
		/// Number of colors in the array between rows (must be &gt;=
		/// width or &lt;= -width).
		/// </param>
		/// <param name="width">The width of the bitmap</param>
		/// <param name="height">The height of the bitmap</param>
		/// <param name="config">
		/// The bitmap config to create. If the config does not
		/// support per-pixel alpha (e.g. RGB_565), then the alpha
		/// bytes in the colors[] will be ignored (assumed to be FF)
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if the width or height are &lt;= 0, or if
		/// the color array's length is less than the number of pixels.
		/// </exception>
		public static android.graphics.Bitmap createBitmap(int[] colors, int offset, int 
			stride, int width, int height, android.graphics.Bitmap.Config config)
		{
			checkWidthHeight(width, height);
			if (System.Math.Abs(stride) < width)
			{
				throw new System.ArgumentException("abs(stride) must be >= width");
			}
			int lastScanline = offset + (height - 1) * stride;
			int length = colors.Length;
			if (offset < 0 || (offset + width > length) || lastScanline < 0 || (lastScanline 
				+ width > length))
			{
				throw new System.IndexOutOfRangeException();
			}
			if (width <= 0 || height <= 0)
			{
				throw new System.ArgumentException("width and height must be > 0");
			}
			return nativeCreate(colors, offset, stride, width, height, (int)config, false);
		}

		/// <summary>
		/// Returns a immutable bitmap with the specified width and height, with each
		/// pixel value set to the corresponding value in the colors array.
		/// </summary>
		/// <remarks>
		/// Returns a immutable bitmap with the specified width and height, with each
		/// pixel value set to the corresponding value in the colors array.  Its
		/// initial density is as per
		/// <see cref="getDensity()">getDensity()</see>
		/// .
		/// </remarks>
		/// <param name="colors">
		/// Array of
		/// <see cref="Color">Color</see>
		/// used to initialize the pixels.
		/// This array must be at least as large as width * height.
		/// </param>
		/// <param name="width">The width of the bitmap</param>
		/// <param name="height">The height of the bitmap</param>
		/// <param name="config">
		/// The bitmap config to create. If the config does not
		/// support per-pixel alpha (e.g. RGB_565), then the alpha
		/// bytes in the colors[] will be ignored (assumed to be FF)
		/// </param>
		/// <exception cref="System.ArgumentException">
		/// if the width or height are &lt;= 0, or if
		/// the color array's length is less than the number of pixels.
		/// </exception>
		public static android.graphics.Bitmap createBitmap(int[] colors, int width, int height
			, android.graphics.Bitmap.Config config)
		{
			return createBitmap(colors, 0, width, width, height, config);
		}

		/// <summary>
		/// Returns an optional array of private data, used by the UI system for
		/// some bitmaps.
		/// </summary>
		/// <remarks>
		/// Returns an optional array of private data, used by the UI system for
		/// some bitmaps. Not intended to be called by applications.
		/// </remarks>
		public byte[] getNinePatchChunk()
		{
			return mNinePatchChunk;
		}

		/// <summary>Specifies the known formats a bitmap can be compressed into</summary>
		public enum CompressFormat : int
		{
			JPEG = 0,
			PNG = 1,
			WEBP = 2
		}

		/// <summary>
		/// Number of bytes of temp storage we use for communicating between the
		/// native compressor and the java OutputStream.
		/// </summary>
		/// <remarks>
		/// Number of bytes of temp storage we use for communicating between the
		/// native compressor and the java OutputStream.
		/// </remarks>
		internal const int WORKING_COMPRESS_STORAGE = 4096;

		[Sharpen.Stub]
		[Sharpen.Comment(@"java.io has not yet been ported.")]
		public bool compress(android.graphics.Bitmap.CompressFormat format, int quality, 
			java.io.OutputStream stream)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Bitmap_isMutable(android.graphics.Bitmap.NativeBitmap
			 _instance);

		// do explicit check before calling the native method
		/// <summary>Returns true if the bitmap is marked as mutable (i.e.</summary>
		/// <remarks>Returns true if the bitmap is marked as mutable (i.e. can be drawn into)
		/// 	</remarks>
		public bool isMutable()
		{
			return libxobotos_Bitmap_isMutable(mNativeBitmap);
		}

		/// <summary>Returns the bitmap's width</summary>
		public int getWidth()
		{
			return mWidth == -1 ? mWidth = nativeWidth(mNativeBitmap) : mWidth;
		}

		/// <summary>Returns the bitmap's height</summary>
		public int getHeight()
		{
			return mHeight == -1 ? mHeight = nativeHeight(mNativeBitmap) : mHeight;
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="getScaledWidth(int)">getScaledWidth(int)</see>
		/// with the target
		/// density of the given
		/// <see cref="Canvas">Canvas</see>
		/// .
		/// </summary>
		public int getScaledWidth(android.graphics.Canvas canvas)
		{
			return scaleFromDensity(getWidth(), mDensity, canvas.mDensity);
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="getScaledHeight(int)">getScaledHeight(int)</see>
		/// with the target
		/// density of the given
		/// <see cref="Canvas">Canvas</see>
		/// .
		/// </summary>
		public int getScaledHeight(android.graphics.Canvas canvas)
		{
			return scaleFromDensity(getHeight(), mDensity, canvas.mDensity);
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="getScaledWidth(int)">getScaledWidth(int)</see>
		/// with the target
		/// density of the given
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// .
		/// </summary>
		public int getScaledWidth(android.util.DisplayMetrics metrics)
		{
			return scaleFromDensity(getWidth(), mDensity, metrics.densityDpi);
		}

		/// <summary>
		/// Convenience for calling
		/// <see cref="getScaledHeight(int)">getScaledHeight(int)</see>
		/// with the target
		/// density of the given
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// .
		/// </summary>
		public int getScaledHeight(android.util.DisplayMetrics metrics)
		{
			return scaleFromDensity(getHeight(), mDensity, metrics.densityDpi);
		}

		/// <summary>
		/// Convenience method that returns the width of this bitmap divided
		/// by the density scale factor.
		/// </summary>
		/// <remarks>
		/// Convenience method that returns the width of this bitmap divided
		/// by the density scale factor.
		/// </remarks>
		/// <param name="targetDensity">The density of the target canvas of the bitmap.</param>
		/// <returns>The scaled width of this bitmap, according to the density scale factor.</returns>
		public int getScaledWidth(int targetDensity)
		{
			return scaleFromDensity(getWidth(), mDensity, targetDensity);
		}

		/// <summary>
		/// Convenience method that returns the height of this bitmap divided
		/// by the density scale factor.
		/// </summary>
		/// <remarks>
		/// Convenience method that returns the height of this bitmap divided
		/// by the density scale factor.
		/// </remarks>
		/// <param name="targetDensity">The density of the target canvas of the bitmap.</param>
		/// <returns>The scaled height of this bitmap, according to the density scale factor.
		/// 	</returns>
		public int getScaledHeight(int targetDensity)
		{
			return scaleFromDensity(getHeight(), mDensity, targetDensity);
		}

		/// <hide></hide>
		public static int scaleFromDensity(int size, int sdensity, int tdensity)
		{
			if (sdensity == DENSITY_NONE || sdensity == tdensity)
			{
				return size;
			}
			// Scale by tdensity / sdensity, rounding up.
			return ((size * tdensity) + (sdensity >> 1)) / sdensity;
		}

		/// <summary>Return the number of bytes between rows in the bitmap's pixels.</summary>
		/// <remarks>
		/// Return the number of bytes between rows in the bitmap's pixels. Note that
		/// this refers to the pixels as stored natively by the bitmap. If you call
		/// getPixels() or setPixels(), then the pixels are uniformly treated as
		/// 32bit values, packed according to the Color class.
		/// </remarks>
		/// <returns>number of bytes between rows of the native bitmap pixels.</returns>
		public int getRowBytes()
		{
			return nativeRowBytes(mNativeBitmap);
		}

		/// <summary>Returns the number of bytes used to store this bitmap's pixels.</summary>
		/// <remarks>Returns the number of bytes used to store this bitmap's pixels.</remarks>
		public int getByteCount()
		{
			// int result permits bitmaps up to 46,340 x 46,340
			return getRowBytes() * getHeight();
		}

		/// <summary>
		/// If the bitmap's internal config is in one of the public formats, return
		/// that config, otherwise return null.
		/// </summary>
		/// <remarks>
		/// If the bitmap's internal config is in one of the public formats, return
		/// that config, otherwise return null.
		/// </remarks>
		public android.graphics.Bitmap.Config getConfig()
		{
			return (android.graphics.Bitmap.Config)nativeConfig(mNativeBitmap);
		}

		/// <summary>
		/// Returns true if the bitmap's config supports per-pixel alpha, and
		/// if the pixels may contain non-opaque alpha values.
		/// </summary>
		/// <remarks>
		/// Returns true if the bitmap's config supports per-pixel alpha, and
		/// if the pixels may contain non-opaque alpha values. For some configs,
		/// this is always false (e.g. RGB_565), since they do not support per-pixel
		/// alpha. However, for configs that do, the bitmap may be flagged to be
		/// known that all of its pixels are opaque. In this case hasAlpha() will
		/// also return false. If a config such as ARGB_8888 is not so flagged,
		/// it will return true by default.
		/// </remarks>
		public bool hasAlpha()
		{
			return nativeHasAlpha(mNativeBitmap);
		}

		/// <summary>
		/// Tell the bitmap if all of the pixels are known to be opaque (false)
		/// or if some of the pixels may contain non-opaque alpha values (true).
		/// </summary>
		/// <remarks>
		/// Tell the bitmap if all of the pixels are known to be opaque (false)
		/// or if some of the pixels may contain non-opaque alpha values (true).
		/// Note, for some configs (e.g. RGB_565) this call is ignored, since it
		/// does not support per-pixel alpha values.
		/// This is meant as a drawing hint, as in some cases a bitmap that is known
		/// to be opaque can take a faster drawing case than one that may have
		/// non-opaque per-pixel alpha values.
		/// </remarks>
		public void setHasAlpha(bool hasAlpha_1)
		{
			nativeSetHasAlpha(mNativeBitmap, hasAlpha_1);
		}

		/// <summary>
		/// Fills the bitmap's pixels with the specified
		/// <see cref="Color">Color</see>
		/// .
		/// </summary>
		/// <exception cref="System.InvalidOperationException">if the bitmap is not mutable.</exception>
		public void eraseColor(int c)
		{
			checkRecycled("Can't erase a recycled bitmap");
			if (!isMutable())
			{
				throw new System.InvalidOperationException("cannot erase immutable bitmaps");
			}
			nativeErase(mNativeBitmap, c);
		}

		/// <summary>
		/// Returns the
		/// <see cref="Color">Color</see>
		/// at the specified location. Throws an exception
		/// if x or y are out of bounds (negative or &gt;= to the width or height
		/// respectively).
		/// </summary>
		/// <param name="x">The x coordinate (0...width-1) of the pixel to return</param>
		/// <param name="y">The y coordinate (0...height-1) of the pixel to return</param>
		/// <returns>
		/// The argb
		/// <see cref="Color">Color</see>
		/// at the specified coordinate
		/// </returns>
		/// <exception cref="System.ArgumentException">if x, y exceed the bitmap's bounds</exception>
		public int getPixel(int x, int y)
		{
			checkRecycled("Can't call getPixel() on a recycled bitmap");
			checkPixelAccess(x, y);
			return nativeGetPixel(mNativeBitmap, x, y);
		}

		/// <summary>Returns in pixels[] a copy of the data in the bitmap.</summary>
		/// <remarks>
		/// Returns in pixels[] a copy of the data in the bitmap. Each value is
		/// a packed int representing a
		/// <see cref="Color">Color</see>
		/// . The stride parameter allows
		/// the caller to allow for gaps in the returned pixels array between
		/// rows. For normal packed results, just pass width for the stride value.
		/// </remarks>
		/// <param name="pixels">The array to receive the bitmap's colors</param>
		/// <param name="offset">The first index to write into pixels[]</param>
		/// <param name="stride">
		/// The number of entries in pixels[] to skip between
		/// rows (must be &gt;= bitmap's width). Can be negative.
		/// </param>
		/// <param name="x">
		/// The x coordinate of the first pixel to read from
		/// the bitmap
		/// </param>
		/// <param name="y">
		/// The y coordinate of the first pixel to read from
		/// the bitmap
		/// </param>
		/// <param name="width">The number of pixels to read from each row</param>
		/// <param name="height">The number of rows to read</param>
		/// <exception cref="System.ArgumentException">
		/// if x, y, width, height exceed the
		/// bounds of the bitmap, or if abs(stride) &lt; width.
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the pixels array is too small
		/// to receive the specified number of pixels.
		/// </exception>
		public void getPixels(int[] pixels, int offset, int stride, int x, int y, int width
			, int height)
		{
			checkRecycled("Can't call getPixels() on a recycled bitmap");
			if (width == 0 || height == 0)
			{
				return;
			}
			// nothing to do
			checkPixelsAccess(x, y, width, height, offset, stride, pixels);
			nativeGetPixels(mNativeBitmap, pixels, offset, stride, x, y, width, height);
		}

		/// <summary>
		/// Shared code to check for illegal arguments passed to getPixel()
		/// or setPixel()
		/// </summary>
		/// <param name="x">x coordinate of the pixel</param>
		/// <param name="y">y coordinate of the pixel</param>
		private void checkPixelAccess(int x, int y)
		{
			checkXYSign(x, y);
			if (x >= getWidth())
			{
				throw new System.ArgumentException("x must be < bitmap.width()");
			}
			if (y >= getHeight())
			{
				throw new System.ArgumentException("y must be < bitmap.height()");
			}
		}

		/// <summary>
		/// Shared code to check for illegal arguments passed to getPixels()
		/// or setPixels()
		/// </summary>
		/// <param name="x">left edge of the area of pixels to access</param>
		/// <param name="y">top edge of the area of pixels to access</param>
		/// <param name="width">width of the area of pixels to access</param>
		/// <param name="height">height of the area of pixels to access</param>
		/// <param name="offset">offset into pixels[] array</param>
		/// <param name="stride">number of elements in pixels[] between each logical row</param>
		/// <param name="pixels">array to hold the area of pixels being accessed</param>
		private void checkPixelsAccess(int x, int y, int width, int height, int offset, int
			 stride, int[] pixels)
		{
			checkXYSign(x, y);
			if (width < 0)
			{
				throw new System.ArgumentException("width must be >= 0");
			}
			if (height < 0)
			{
				throw new System.ArgumentException("height must be >= 0");
			}
			if (x + width > getWidth())
			{
				throw new System.ArgumentException("x + width must be <= bitmap.width()");
			}
			if (y + height > getHeight())
			{
				throw new System.ArgumentException("y + height must be <= bitmap.height()");
			}
			if (System.Math.Abs(stride) < width)
			{
				throw new System.ArgumentException("abs(stride) must be >= width");
			}
			int lastScanline = offset + (height - 1) * stride;
			int length = pixels.Length;
			if (offset < 0 || (offset + width > length) || lastScanline < 0 || (lastScanline 
				+ width > length))
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Write the specified
		/// <see cref="Color">Color</see>
		/// into the bitmap (assuming it is
		/// mutable) at the x,y coordinate.
		/// </summary>
		/// <param name="x">The x coordinate of the pixel to replace (0...width-1)</param>
		/// <param name="y">The y coordinate of the pixel to replace (0...height-1)</param>
		/// <param name="color">
		/// The
		/// <see cref="Color">Color</see>
		/// to write into the bitmap
		/// </param>
		/// <exception cref="System.InvalidOperationException">if the bitmap is not mutable</exception>
		/// <exception cref="System.ArgumentException">
		/// if x, y are outside of the bitmap's
		/// bounds.
		/// </exception>
		public void setPixel(int x, int y, int color)
		{
			checkRecycled("Can't call setPixel() on a recycled bitmap");
			if (!isMutable())
			{
				throw new System.InvalidOperationException();
			}
			checkPixelAccess(x, y);
			nativeSetPixel(mNativeBitmap, x, y, color);
		}

		/// <summary>Replace pixels in the bitmap with the colors in the array.</summary>
		/// <remarks>
		/// Replace pixels in the bitmap with the colors in the array. Each element
		/// in the array is a packed int prepresenting a
		/// <see cref="Color">Color</see>
		/// </remarks>
		/// <param name="pixels">The colors to write to the bitmap</param>
		/// <param name="offset">The index of the first color to read from pixels[]</param>
		/// <param name="stride">
		/// The number of colors in pixels[] to skip between rows.
		/// Normally this value will be the same as the width of
		/// the bitmap, but it can be larger (or negative).
		/// </param>
		/// <param name="x">
		/// The x coordinate of the first pixel to write to in
		/// the bitmap.
		/// </param>
		/// <param name="y">
		/// The y coordinate of the first pixel to write to in
		/// the bitmap.
		/// </param>
		/// <param name="width">The number of colors to copy from pixels[] per row</param>
		/// <param name="height">The number of rows to write to the bitmap</param>
		/// <exception cref="System.InvalidOperationException">if the bitmap is not mutable</exception>
		/// <exception cref="System.ArgumentException">
		/// if x, y, width, height are outside of
		/// the bitmap's bounds.
		/// </exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// if the pixels array is too small
		/// to receive the specified number of pixels.
		/// </exception>
		public void setPixels(int[] pixels, int offset, int stride, int x, int y, int width
			, int height)
		{
			checkRecycled("Can't call setPixels() on a recycled bitmap");
			if (!isMutable())
			{
				throw new System.InvalidOperationException();
			}
			if (width == 0 || height == 0)
			{
				return;
			}
			// nothing to do
			checkPixelsAccess(x, y, width, height, offset, stride, pixels);
			nativeSetPixels(mNativeBitmap, pixels, offset, stride, x, y, width, height);
		}

		public static readonly android.os.ParcelableClass.Creator<android.graphics.Bitmap
			> CREATOR = null;

		/// <summary>No special parcel contents.</summary>
		/// <remarks>No special parcel contents.</remarks>
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			return 0;
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		[Sharpen.Comment(@"Parcel has not yet been ported.")]
		public void writeToParcel(android.os.Parcel p, int flags)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Returns a new bitmap that captures the alpha values of the original.</summary>
		/// <remarks>
		/// Returns a new bitmap that captures the alpha values of the original.
		/// This may be drawn with Canvas.drawBitmap(), where the color(s) will be
		/// taken from the paint that is passed to the draw call.
		/// </remarks>
		/// <returns>new bitmap containing the alpha channel of the original bitmap.</returns>
		public android.graphics.Bitmap extractAlpha()
		{
			return extractAlpha(null, null);
		}

		/// <summary>Returns a new bitmap that captures the alpha values of the original.</summary>
		/// <remarks>
		/// Returns a new bitmap that captures the alpha values of the original.
		/// These values may be affected by the optional Paint parameter, which
		/// can contain its own alpha, and may also contain a MaskFilter which
		/// could change the actual dimensions of the resulting bitmap (e.g.
		/// a blur maskfilter might enlarge the resulting bitmap). If offsetXY
		/// is not null, it returns the amount to offset the returned bitmap so
		/// that it will logically align with the original. For example, if the
		/// paint contains a blur of radius 2, then offsetXY[] would contains
		/// -2, -2, so that drawing the alpha bitmap offset by (-2, -2) and then
		/// drawing the original would result in the blur visually aligning with
		/// the original.
		/// <p>The initial density of the returned bitmap is the same as the original's.
		/// </remarks>
		/// <param name="paint">
		/// Optional paint used to modify the alpha values in the
		/// resulting bitmap. Pass null for default behavior.
		/// </param>
		/// <param name="offsetXY">
		/// Optional array that returns the X (index 0) and Y
		/// (index 1) offset needed to position the returned bitmap
		/// so that it visually lines up with the original.
		/// </param>
		/// <returns>
		/// new bitmap containing the (optionally modified by paint) alpha
		/// channel of the original bitmap. This may be drawn with
		/// Canvas.drawBitmap(), where the color(s) will be taken from the
		/// paint that is passed to the draw call.
		/// </returns>
		public android.graphics.Bitmap extractAlpha(android.graphics.Paint paint, int[] offsetXY
			)
		{
			checkRecycled("Can't extractAlpha on a recycled bitmap");
			android.graphics.Paint.NativePaint nativePaint = paint != null ? paint.mNativePaint
				 : null;
			android.graphics.Bitmap bm = nativeExtractAlpha(mNativeBitmap, nativePaint, offsetXY
				);
			if (bm == null)
			{
				throw new java.lang.RuntimeException("Failed to extractAlpha on Bitmap");
			}
			bm.mDensity = mDensity;
			return bm;
		}

		/// <summary>
		/// Given another bitmap, return true if it has the same dimensions, config,
		/// and pixel data as this bitmap.
		/// </summary>
		/// <remarks>
		/// Given another bitmap, return true if it has the same dimensions, config,
		/// and pixel data as this bitmap. If any of those differ, return false.
		/// If other is null, return false.
		/// </remarks>
		public bool sameAs(android.graphics.Bitmap other)
		{
			return this == other || (other != null && nativeSameAs(mNativeBitmap, other.mNativeBitmap
				));
		}

		/// <summary>
		/// Rebuilds any caches associated with the bitmap that are used for
		/// drawing it.
		/// </summary>
		/// <remarks>
		/// Rebuilds any caches associated with the bitmap that are used for
		/// drawing it. In the case of purgeable bitmaps, this call will attempt to
		/// ensure that the pixels have been decoded.
		/// If this is called on more than one bitmap in sequence, the priority is
		/// given in LRU order (i.e. the last bitmap called will be given highest
		/// priority).
		/// For bitmaps with no associated caches, this call is effectively a no-op,
		/// and therefore is harmless.
		/// </remarks>
		public void prepareToDraw()
		{
			nativePrepareToDraw(mNativeBitmap);
		}

		private class BitmapFinalizer
		{
			internal readonly android.graphics.Bitmap.NativeBitmap mNativeBitmap;

			internal BitmapFinalizer(android.graphics.Bitmap.NativeBitmap nativeBitmap)
			{
				mNativeBitmap = nativeBitmap;
			}
			// Ignore
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Bitmap.NativeBitmap libxobotos_Bitmap_create
			(System.IntPtr colors, int offset, int stride, int width, int height, int nativeConfig_1
			, bool mutable);

		//////////// native methods
		private static android.graphics.Bitmap nativeCreate(int[] colors, int offset, int
			 stride, int width, int height, int nativeConfig_1, bool mutable)
		{
			Sharpen.INativeHandle colors_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				return new android.graphics.Bitmap(libxobotos_Bitmap_create(colors_handle != null
					 ? colors_handle.Address : System.IntPtr.Zero, offset, stride, width, height, (int
					)nativeConfig_1, mutable));
			}
			finally
			{
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Bitmap.NativeBitmap libxobotos_Bitmap_copy
			(android.graphics.Bitmap.NativeBitmap srcBitmap, int nativeConfig_1, bool isMutable_1
			);

		private static android.graphics.Bitmap nativeCopy(android.graphics.Bitmap.NativeBitmap
			 srcBitmap, int nativeConfig_1, bool isMutable_1)
		{
			return new android.graphics.Bitmap(libxobotos_Bitmap_copy(srcBitmap, (int)nativeConfig_1
				, isMutable_1));
		}

		private static void nativeDestructor(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			nativeBitmap.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_recycle(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static void nativeRecycle(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			libxobotos_Bitmap_recycle(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_eraseColor(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, int color);

		private static void nativeErase(android.graphics.Bitmap.NativeBitmap nativeBitmap
			, int color)
		{
			libxobotos_Bitmap_eraseColor(nativeBitmap, color);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_width(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static int nativeWidth(android.graphics.Bitmap.NativeBitmap nativeBitmap)
		{
			return libxobotos_Bitmap_width(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_height(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static int nativeHeight(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			return libxobotos_Bitmap_height(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_rowBytes(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static int nativeRowBytes(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			return libxobotos_Bitmap_rowBytes(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_config(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static int nativeConfig(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			return libxobotos_Bitmap_config(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Bitmap_hasAlpha(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static bool nativeHasAlpha(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			return libxobotos_Bitmap_hasAlpha(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_getPixel(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, int x, int y);

		private static int nativeGetPixel(android.graphics.Bitmap.NativeBitmap nativeBitmap
			, int x, int y)
		{
			return libxobotos_Bitmap_getPixel(nativeBitmap, x, y);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_getPixels(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, System.IntPtr pixels, int offset, int stride, int x, int y, int width
			, int height);

		private static void nativeGetPixels(android.graphics.Bitmap.NativeBitmap nativeBitmap
			, int[] pixels, int offset, int stride, int x, int y, int width, int height)
		{
			Sharpen.INativeHandle pixels_handle = null;
			try
			{
				pixels_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(pixels);
				libxobotos_Bitmap_getPixels(nativeBitmap, pixels_handle.Address, offset, stride, 
					x, y, width, height);
			}
			finally
			{
				if (pixels_handle != null)
				{
					pixels_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_setPixel(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, int x, int y, int color);

		private static void nativeSetPixel(android.graphics.Bitmap.NativeBitmap nativeBitmap
			, int x, int y, int color)
		{
			libxobotos_Bitmap_setPixel(nativeBitmap, x, y, color);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_setPixels(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, System.IntPtr colors, int offset, int stride, int x, int y, int width
			, int height);

		private static void nativeSetPixels(android.graphics.Bitmap.NativeBitmap nativeBitmap
			, int[] colors, int offset, int stride, int x, int y, int width, int height)
		{
			Sharpen.INativeHandle colors_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				libxobotos_Bitmap_setPixels(nativeBitmap, colors_handle.Address, offset, stride, 
					x, y, width, height);
			}
			finally
			{
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Bitmap_getGenerationID(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static int nativeGenerationId(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			return libxobotos_Bitmap_getGenerationID(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Bitmap.NativeBitmap libxobotos_Bitmap_extractAlpha
			(android.graphics.Bitmap.NativeBitmap nativeBitmap, android.graphics.Paint.NativePaint
			 nativePaint, System.IntPtr offsetXY);

		// returns true on success
		// returns a new bitmap built from the native bitmap's alpha, and the paint
		private static android.graphics.Bitmap nativeExtractAlpha(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap, android.graphics.Paint.NativePaint nativePaint, int[] offsetXY)
		{
			Sharpen.INativeHandle offsetXY_handle = null;
			try
			{
				offsetXY_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(offsetXY
					);
				return new android.graphics.Bitmap(libxobotos_Bitmap_extractAlpha(nativeBitmap, nativePaint
					 != null ? nativePaint : android.graphics.Paint.NativePaint.Zero, offsetXY_handle
					 != null ? offsetXY_handle.Address : System.IntPtr.Zero));
			}
			finally
			{
				if (offsetXY_handle != null)
				{
					offsetXY_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_prepareToDraw(android.graphics.Bitmap.NativeBitmap
			 nativeBitmap);

		private static void nativePrepareToDraw(android.graphics.Bitmap.NativeBitmap nativeBitmap
			)
		{
			libxobotos_Bitmap_prepareToDraw(nativeBitmap);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Bitmap_setHasAlpha(android.graphics.Bitmap.NativeBitmap
			 nBitmap, bool hasAlpha_1);

		private static void nativeSetHasAlpha(android.graphics.Bitmap.NativeBitmap nBitmap
			, bool hasAlpha_1)
		{
			libxobotos_Bitmap_setHasAlpha(nBitmap, hasAlpha_1);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Bitmap_sameAs(android.graphics.Bitmap.NativeBitmap
			 nb0, android.graphics.Bitmap.NativeBitmap nb1);

		private static bool nativeSameAs(android.graphics.Bitmap.NativeBitmap nb0, android.graphics.Bitmap.NativeBitmap
			 nb1)
		{
			return libxobotos_Bitmap_sameAs(nb0, nb1);
		}

		internal NativeBitmap nativeInstance
		{
			get
			{
				return mNativeBitmap;
			}
		}

		public void Dispose()
		{
			mNativeBitmap.Dispose();
		}

		internal class NativeBitmap : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeBitmap() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeBitmap(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Bitmap_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeBitmap Zero = new NativeBitmap();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Bitmap_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
