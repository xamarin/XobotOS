using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// Creates Bitmap objects from various sources, including files, streams,
	/// and byte-arrays.
	/// </summary>
	/// <remarks>
	/// Creates Bitmap objects from various sources, including files, streams,
	/// and byte-arrays.
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class BitmapFactory
	{
		public class Options
		{
			/// <summary>
			/// Create a default Options object, which if left unchanged will give
			/// the same result from the decoder as if null were passed.
			/// </summary>
			/// <remarks>
			/// Create a default Options object, which if left unchanged will give
			/// the same result from the decoder as if null were passed.
			/// </remarks>
			public Options()
			{
				inDither = false;
				inScaled = true;
			}

			/// <summary>
			/// If set, decode methods that take the Options object will attempt to
			/// reuse this bitmap when loading content.
			/// </summary>
			/// <remarks>
			/// If set, decode methods that take the Options object will attempt to
			/// reuse this bitmap when loading content. If the decode operation cannot
			/// use this bitmap, the decode method will return <code>null</code> and
			/// will throw an IllegalArgumentException. The
			/// current implementation necessitates that the reused bitmap be of the
			/// same size as the source content and in jpeg or png format (whether as a
			/// resource or as a stream). The
			/// <see cref="Config">configuration</see>
			/// of the reused bitmap will override the setting of
			/// <see cref="inPreferredConfig">inPreferredConfig</see>
			/// , if set.
			/// <p>You should still always use the returned Bitmap of the decode
			/// method and not assume that reusing the bitmap worked, due to the
			/// constraints outlined above and failure situations that can occur.
			/// Checking whether the return value matches the value of the inBitmap
			/// set in the Options structure is a way to see if the bitmap was reused,
			/// but in all cases you should use the returned Bitmap to make sure
			/// that you are using the bitmap that was used as the decode destination.</p>
			/// </remarks>
			public android.graphics.Bitmap inBitmap;

			/// <summary>
			/// If set, decode methods will always return a mutable Bitmap instead of
			/// an immutable one.
			/// </summary>
			/// <remarks>
			/// If set, decode methods will always return a mutable Bitmap instead of
			/// an immutable one. This can be used for instance to programmatically apply
			/// effects to a Bitmap loaded through BitmapFactory.
			/// </remarks>
			public bool inMutable;

			/// <summary>
			/// If set to true, the decoder will return null (no bitmap), but
			/// the out...
			/// </summary>
			/// <remarks>
			/// If set to true, the decoder will return null (no bitmap), but
			/// the out... fields will still be set, allowing the caller to query
			/// the bitmap without having to allocate the memory for its pixels.
			/// </remarks>
			public bool inJustDecodeBounds;

			/// <summary>
			/// If set to a value &gt; 1, requests the decoder to subsample the original
			/// image, returning a smaller image to save memory.
			/// </summary>
			/// <remarks>
			/// If set to a value &gt; 1, requests the decoder to subsample the original
			/// image, returning a smaller image to save memory. The sample size is
			/// the number of pixels in either dimension that correspond to a single
			/// pixel in the decoded bitmap. For example, inSampleSize == 4 returns
			/// an image that is 1/4 the width/height of the original, and 1/16 the
			/// number of pixels. Any value &lt;= 1 is treated the same as 1. Note: the
			/// decoder will try to fulfill this request, but the resulting bitmap
			/// may have different dimensions that precisely what has been requested.
			/// Also, powers of 2 are often faster/easier for the decoder to honor.
			/// </remarks>
			public int inSampleSize;

			/// <summary>
			/// If this is non-null, the decoder will try to decode into this
			/// internal configuration.
			/// </summary>
			/// <remarks>
			/// If this is non-null, the decoder will try to decode into this
			/// internal configuration. If it is null, or the request cannot be met,
			/// the decoder will try to pick the best matching config based on the
			/// system's screen depth, and characteristics of the original image such
			/// as if it has per-pixel alpha (requiring a config that also does).
			/// Image are loaded with the
			/// <see cref="Config.ARGB_8888">Config.ARGB_8888</see>
			/// config by
			/// default.
			/// </remarks>
			public android.graphics.Bitmap.Config inPreferredConfig = android.graphics.Bitmap.Config
				.ARGB_8888;

			/// <summary>
			/// If dither is true, the decoder will attempt to dither the decoded
			/// image.
			/// </summary>
			/// <remarks>
			/// If dither is true, the decoder will attempt to dither the decoded
			/// image.
			/// </remarks>
			public bool inDither;

			/// <summary>The pixel density to use for the bitmap.</summary>
			/// <remarks>
			/// The pixel density to use for the bitmap.  This will always result
			/// in the returned bitmap having a density set for it (see
			/// <see cref="Bitmap.setDensity(int)">Bitmap.setDensity(int)</see>
			/// ).  In addition,
			/// if
			/// <see cref="inScaled">inScaled</see>
			/// is set (which it is by default} and this
			/// density does not match
			/// <see cref="inTargetDensity">inTargetDensity</see>
			/// , then the bitmap
			/// will be scaled to the target density before being returned.
			/// <p>If this is 0,
			/// <see cref="BitmapFactory.decodeResource(android.content.res.Resources, int)">BitmapFactory.decodeResource(android.content.res.Resources, int)
			/// 	</see>
			/// ,
			/// <see cref="BitmapFactory.decodeResource(android.content.res.Resources, int, Options)
			/// 	">BitmapFactory.decodeResource(android.content.res.Resources, int, Options)</see>
			/// ,
			/// and
			/// <see cref="BitmapFactory.decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
			/// 	">BitmapFactory.decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
			/// 	</see>
			/// will fill in the density associated with the resource.  The other
			/// functions will leave it as-is and no density will be applied.
			/// </remarks>
			/// <seealso cref="inTargetDensity">inTargetDensity</seealso>
			/// <seealso cref="inScreenDensity">inScreenDensity</seealso>
			/// <seealso cref="inScaled">inScaled</seealso>
			/// <seealso cref="Bitmap.setDensity(int)">Bitmap.setDensity(int)</seealso>
			/// <seealso cref="android.util.DisplayMetrics.densityDpi">android.util.DisplayMetrics.densityDpi
			/// 	</seealso>
			public int inDensity;

			/// <summary>The pixel density of the destination this bitmap will be drawn to.</summary>
			/// <remarks>
			/// The pixel density of the destination this bitmap will be drawn to.
			/// This is used in conjunction with
			/// <see cref="inDensity">inDensity</see>
			/// and
			/// <see cref="inScaled">inScaled</see>
			/// to determine if and how to scale the bitmap before
			/// returning it.
			/// <p>If this is 0,
			/// <see cref="BitmapFactory.decodeResource(android.content.res.Resources, int)">BitmapFactory.decodeResource(android.content.res.Resources, int)
			/// 	</see>
			/// ,
			/// <see cref="BitmapFactory.decodeResource(android.content.res.Resources, int, Options)
			/// 	">BitmapFactory.decodeResource(android.content.res.Resources, int, Options)</see>
			/// ,
			/// and
			/// <see cref="BitmapFactory.decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
			/// 	">BitmapFactory.decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
			/// 	</see>
			/// will fill in the density associated the Resources object's
			/// DisplayMetrics.  The other
			/// functions will leave it as-is and no scaling for density will be
			/// performed.
			/// </remarks>
			/// <seealso cref="inDensity">inDensity</seealso>
			/// <seealso cref="inScreenDensity">inScreenDensity</seealso>
			/// <seealso cref="inScaled">inScaled</seealso>
			/// <seealso cref="android.util.DisplayMetrics.densityDpi">android.util.DisplayMetrics.densityDpi
			/// 	</seealso>
			public int inTargetDensity;

			/// <summary>The pixel density of the actual screen that is being used.</summary>
			/// <remarks>
			/// The pixel density of the actual screen that is being used.  This is
			/// purely for applications running in density compatibility code, where
			/// <see cref="inTargetDensity">inTargetDensity</see>
			/// is actually the density the application
			/// sees rather than the real screen density.
			/// <p>By setting this, you
			/// allow the loading code to avoid scaling a bitmap that is currently
			/// in the screen density up/down to the compatibility density.  Instead,
			/// if
			/// <see cref="inDensity">inDensity</see>
			/// is the same as
			/// <see cref="inScreenDensity">inScreenDensity</see>
			/// , the
			/// bitmap will be left as-is.  Anything using the resulting bitmap
			/// must also used
			/// <see cref="Bitmap.getScaledWidth(int)">Bitmap.getScaledWidth</see>
			/// and
			/// <see cref="Bitmap.getScaledHeight(Canvas)">Bitmap.getScaledHeight</see>
			/// to account for any different between the
			/// bitmap's density and the target's density.
			/// <p>This is never set automatically for the caller by
			/// <see cref="BitmapFactory">BitmapFactory</see>
			/// itself.  It must be explicitly set, since the
			/// caller must deal with the resulting bitmap in a density-aware way.
			/// </remarks>
			/// <seealso cref="inDensity">inDensity</seealso>
			/// <seealso cref="inTargetDensity">inTargetDensity</seealso>
			/// <seealso cref="inScaled">inScaled</seealso>
			/// <seealso cref="android.util.DisplayMetrics.densityDpi">android.util.DisplayMetrics.densityDpi
			/// 	</seealso>
			public int inScreenDensity;

			/// <summary>
			/// When this flag is set, if
			/// <see cref="inDensity">inDensity</see>
			/// and
			/// <see cref="inTargetDensity">inTargetDensity</see>
			/// are not 0, the
			/// bitmap will be scaled to match
			/// <see cref="inTargetDensity">inTargetDensity</see>
			/// when loaded,
			/// rather than relying on the graphics system scaling it each time it
			/// is drawn to a Canvas.
			/// <p>This flag is turned on by default and should be turned off if you need
			/// a non-scaled version of the bitmap.  Nine-patch bitmaps ignore this
			/// flag and are always scaled.
			/// </summary>
			public bool inScaled;

			/// <summary>
			/// If this is set to true, then the resulting bitmap will allocate its
			/// pixels such that they can be purged if the system needs to reclaim
			/// memory.
			/// </summary>
			/// <remarks>
			/// If this is set to true, then the resulting bitmap will allocate its
			/// pixels such that they can be purged if the system needs to reclaim
			/// memory. In that instance, when the pixels need to be accessed again
			/// (e.g. the bitmap is drawn, getPixels() is called), they will be
			/// automatically re-decoded.
			/// For the re-decode to happen, the bitmap must have access to the
			/// encoded data, either by sharing a reference to the input
			/// or by making a copy of it. This distinction is controlled by
			/// inInputShareable. If this is true, then the bitmap may keep a shallow
			/// reference to the input. If this is false, then the bitmap will
			/// explicitly make a copy of the input data, and keep that. Even if
			/// sharing is allowed, the implementation may still decide to make a
			/// deep copy of the input data.
			/// </remarks>
			public bool inPurgeable;

			/// <summary>This field works in conjuction with inPurgeable.</summary>
			/// <remarks>
			/// This field works in conjuction with inPurgeable. If inPurgeable is
			/// false, then this field is ignored. If inPurgeable is true, then this
			/// field determines whether the bitmap can share a reference to the
			/// input data (inputstream, array, etc.) or if it must make a deep copy.
			/// </remarks>
			public bool inInputShareable;

			/// <summary>
			/// If inPreferQualityOverSpeed is set to true, the decoder will try to
			/// decode the reconstructed image to a higher quality even at the
			/// expense of the decoding speed.
			/// </summary>
			/// <remarks>
			/// If inPreferQualityOverSpeed is set to true, the decoder will try to
			/// decode the reconstructed image to a higher quality even at the
			/// expense of the decoding speed. Currently the field only affects JPEG
			/// decode, in the case of which a more accurate, but slightly slower,
			/// IDCT method will be used instead.
			/// </remarks>
			public bool inPreferQualityOverSpeed;

			/// <summary>
			/// The resulting width of the bitmap, set independent of the state of
			/// inJustDecodeBounds.
			/// </summary>
			/// <remarks>
			/// The resulting width of the bitmap, set independent of the state of
			/// inJustDecodeBounds. However, if there is an error trying to decode,
			/// outWidth will be set to -1.
			/// </remarks>
			public int outWidth;

			/// <summary>
			/// The resulting height of the bitmap, set independent of the state of
			/// inJustDecodeBounds.
			/// </summary>
			/// <remarks>
			/// The resulting height of the bitmap, set independent of the state of
			/// inJustDecodeBounds. However, if there is an error trying to decode,
			/// outHeight will be set to -1.
			/// </remarks>
			public int outHeight;

			/// <summary>If known, this string is set to the mimetype of the decoded image.</summary>
			/// <remarks>
			/// If known, this string is set to the mimetype of the decoded image.
			/// If not know, or there is an error, it is set to null.
			/// </remarks>
			public string outMimeType;

			/// <summary>Temp storage to use for decoding.</summary>
			/// <remarks>Temp storage to use for decoding.  Suggest 16K or so.</remarks>
			public byte[] inTempStorage;

			/// <summary>Flag to indicate that cancel has been called on this object.</summary>
			/// <remarks>
			/// Flag to indicate that cancel has been called on this object.  This
			/// is useful if there's an intermediary that wants to first decode the
			/// bounds and then decode the image.  In that case the intermediary
			/// can check, inbetween the bounds decode and the image decode, to see
			/// if the operation is canceled.
			/// </remarks>
			public bool mCancel;

			[Sharpen.Stub]
			public virtual void requestCancelDecode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.MarshalHelper(@"BitmapFactoryGlue::Options")]
			internal static class Options_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct Options_Struct
				{
					public uint _owner;

					public int inMutable;

					public int inJustDecodeBounds;

					public int inSampleSize;

					public int inDither;

					public int inPurgeable;

					public int inPreferredConfig;

					public System.IntPtr inBitmap;

					public int outWidth;

					public int outHeight;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(Options_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, android.graphics.BitmapFactory.Options
					 arg)
				{
					Options_Struct obj = new Options_Struct();
					obj._owner = 0x972f3813;
					obj.inMutable = arg.inMutable ? 1 : 0;
					obj.inJustDecodeBounds = arg.inJustDecodeBounds ? 1 : 0;
					obj.inSampleSize = arg.inSampleSize;
					obj.inDither = arg.inDither ? 1 : 0;
					obj.inPurgeable = arg.inPurgeable ? 1 : 0;
					obj.inPreferredConfig = (int)arg.inPreferredConfig;
					obj.inBitmap = arg.inBitmap != null ? arg.inBitmap.mNativeBitmap.Handle : System.IntPtr.Zero;
					obj.outWidth = arg.outWidth;
					obj.outHeight = arg.outHeight;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, android.graphics.BitmapFactory.Options
					 arg)
				{
					Options_Struct obj = (Options_Struct)Marshal.PtrToStructure(ptr, typeof(Options_Struct
						));
					arg.outWidth = obj.outWidth;
					arg.outHeight = obj.outHeight;
				}

				public static System.IntPtr ManagedToNative(android.graphics.BitmapFactory.Options
					 arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Options_Struct)));
					android.graphics.BitmapFactory.Options.Options_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static android.graphics.BitmapFactory.Options NativeToManaged(System.IntPtr
					 ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					Options_Struct obj = (Options_Struct)Marshal.PtrToStructure(ptr, typeof(Options_Struct
						));
					android.graphics.BitmapFactory.Options arg = new android.graphics.BitmapFactory.Options
						();
					arg.outWidth = obj.outWidth;
					arg.outHeight = obj.outHeight;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_android_graphics_BitmapFactory_Options_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_graphics_BitmapFactory_Options_destructor
					(System.IntPtr ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					Options_Struct obj = (Options_Struct)Marshal.PtrToStructure(ptr, typeof(Options_Struct
						));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					android.graphics.BitmapFactory.Options.Options_Helper.FreeManagedPtr_inner(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
			// used in native code
		}

		// do nothing here
		/// <summary>Decode a new Bitmap from an InputStream.</summary>
		/// <remarks>
		/// Decode a new Bitmap from an InputStream. This InputStream was obtained from
		/// resources, which we pass to be able to scale the bitmap accordingly.
		/// </remarks>
		public static android.graphics.Bitmap decodeResourceStream(android.content.res.Resources
			 res, android.util.TypedValue value, java.io.InputStream @is, android.graphics.Rect
			 pad, android.graphics.BitmapFactory.Options opts)
		{
			if (opts == null)
			{
				opts = new android.graphics.BitmapFactory.Options();
			}
			if (opts.inDensity == 0 && value != null)
			{
				int density = value.density;
				if (density == android.util.TypedValue.DENSITY_DEFAULT)
				{
					opts.inDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;
				}
				else
				{
					if (density != android.util.TypedValue.DENSITY_NONE)
					{
						opts.inDensity = density;
					}
				}
			}
			if (opts.inTargetDensity == 0 && res != null)
			{
				opts.inTargetDensity = res.getDisplayMetrics().densityDpi;
			}
			return decodeStream(@is, pad, opts);
		}

		/// <summary>
		/// Synonym for opening the given resource and calling
		/// <see cref="decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
		/// 	">decodeResourceStream(android.content.res.Resources, android.util.TypedValue, java.io.InputStream, Rect, Options)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="res">The resources object containing the image data</param>
		/// <param name="id">The resource id of the image data</param>
		/// <param name="opts">
		/// null-ok; Options that control downsampling and whether the
		/// image should be completely decoded, or just is size returned.
		/// </param>
		/// <returns>
		/// The decoded bitmap, or null if the image data could not be
		/// decoded, or, if opts is non-null, if opts requested only the
		/// size be returned (in opts.outWidth and opts.outHeight)
		/// </returns>
		public static android.graphics.Bitmap decodeResource(android.content.res.Resources
			 res, int id, android.graphics.BitmapFactory.Options opts)
		{
			android.graphics.Bitmap bm = null;
			java.io.InputStream @is = null;
			try
			{
				android.util.TypedValue value = new android.util.TypedValue();
				@is = res.openRawResource(id, value);
				bm = decodeResourceStream(res, value, @is, null, opts);
			}
			catch (System.Exception)
			{
			}
			finally
			{
				try
				{
					if (@is != null)
					{
						@is.close();
					}
				}
				catch (System.IO.IOException)
				{
				}
			}
			// Ignore
			if (bm == null && opts != null && opts.inBitmap != null)
			{
				throw new System.ArgumentException("Problem decoding into existing bitmap");
			}
			return bm;
		}

		/// <summary>
		/// Synonym for
		/// <see cref="decodeResource(android.content.res.Resources, int, Options)">decodeResource(android.content.res.Resources, int, Options)
		/// 	</see>
		/// will null Options.
		/// </summary>
		/// <param name="res">The resources object containing the image data</param>
		/// <param name="id">The resource id of the image data</param>
		/// <returns>The decoded bitmap, or null if the image could not be decode.</returns>
		public static android.graphics.Bitmap decodeResource(android.content.res.Resources
			 res, int id)
		{
			return decodeResource(res, id, null);
		}

		/// <summary>Decode an immutable bitmap from the specified byte array.</summary>
		/// <remarks>Decode an immutable bitmap from the specified byte array.</remarks>
		/// <param name="data">byte array of compressed image data</param>
		/// <param name="offset">
		/// offset into imageData for where the decoder should begin
		/// parsing.
		/// </param>
		/// <param name="length">the number of bytes, beginning at offset, to parse</param>
		/// <param name="opts">
		/// null-ok; Options that control downsampling and whether the
		/// image should be completely decoded, or just is size returned.
		/// </param>
		/// <returns>
		/// The decoded bitmap, or null if the image data could not be
		/// decoded, or, if opts is non-null, if opts requested only the
		/// size be returned (in opts.outWidth and opts.outHeight)
		/// </returns>
		public static android.graphics.Bitmap decodeByteArray(byte[] data, int offset, int
			 length, android.graphics.BitmapFactory.Options opts)
		{
			if ((offset | length) < 0 || data.Length < offset + length)
			{
				throw new System.IndexOutOfRangeException();
			}
			android.graphics.Bitmap bm = nativeDecodeByteArray(data, offset, length, opts);
			if (bm == null && opts != null && opts.inBitmap != null)
			{
				throw new System.ArgumentException("Problem decoding into existing bitmap");
			}
			return bm;
		}

		/// <summary>Decode an immutable bitmap from the specified byte array.</summary>
		/// <remarks>Decode an immutable bitmap from the specified byte array.</remarks>
		/// <param name="data">byte array of compressed image data</param>
		/// <param name="offset">
		/// offset into imageData for where the decoder should begin
		/// parsing.
		/// </param>
		/// <param name="length">the number of bytes, beginning at offset, to parse</param>
		/// <returns>The decoded bitmap, or null if the image could not be decode.</returns>
		public static android.graphics.Bitmap decodeByteArray(byte[] data, int offset, int
			 length)
		{
			return decodeByteArray(data, offset, length, null);
		}

		/// <summary>Decode an input stream into a bitmap.</summary>
		/// <remarks>
		/// Decode an input stream into a bitmap. If the input stream is null, or
		/// cannot be used to decode a bitmap, the function returns null.
		/// The stream's position will be where ever it was after the encoded data
		/// was read.
		/// </remarks>
		/// <param name="is">
		/// The input stream that holds the raw data to be decoded into a
		/// bitmap.
		/// </param>
		/// <param name="outPadding">
		/// If not null, return the padding rect for the bitmap if
		/// it exists, otherwise set padding to [-1,-1,-1,-1]. If
		/// no bitmap is returned (null) then padding is
		/// unchanged.
		/// </param>
		/// <param name="opts">
		/// null-ok; Options that control downsampling and whether the
		/// image should be completely decoded, or just is size returned.
		/// </param>
		/// <returns>
		/// The decoded bitmap, or null if the image data could not be
		/// decoded, or, if opts is non-null, if opts requested only the
		/// size be returned (in opts.outWidth and opts.outHeight)
		/// </returns>
		public static android.graphics.Bitmap decodeStream(java.io.InputStream @is, android.graphics.Rect
			 outPadding, android.graphics.BitmapFactory.Options opts)
		{
			// we don't throw in this case, thus allowing the caller to only check
			// the cache, and not force the image to be decoded.
			if (@is == null)
			{
				return null;
			}
			// we need mark/reset to work properly
			if (!@is.markSupported())
			{
				@is = new java.io.BufferedInputStream(@is, 16 * 1024);
			}
			// so we can call reset() if a given codec gives up after reading up to
			// this many bytes. FIXME: need to find out from the codecs what this
			// value should be.
			@is.mark(1024);
			android.graphics.Bitmap bm;
			if (@is is android.content.res.AssetManager.AssetInputStream)
			{
				bm = nativeDecodeAsset(((android.content.res.AssetManager.AssetInputStream)@is).mAsset
					, outPadding, opts);
			}
			else
			{
				// pass some temp storage down to the native code. 1024 is made up,
				// but should be large enough to avoid too many small calls back
				// into is.read(...) This number is not related to the value passed
				// to mark(...) above.
				byte[] tempStorage = null;
				if (opts != null)
				{
					tempStorage = opts.inTempStorage;
				}
				if (tempStorage == null)
				{
					tempStorage = new byte[16 * 1024];
				}
				bm = nativeDecodeStream(@is, tempStorage, outPadding, opts);
			}
			if (bm == null && opts != null && opts.inBitmap != null)
			{
				throw new System.ArgumentException("Problem decoding into existing bitmap");
			}
			return finishDecode(bm, outPadding, opts);
		}

		private static android.graphics.Bitmap finishDecode(android.graphics.Bitmap bm, android.graphics.Rect
			 outPadding, android.graphics.BitmapFactory.Options opts)
		{
			if (bm == null || opts == null)
			{
				return bm;
			}
			int density = opts.inDensity;
			if (density == 0)
			{
				return bm;
			}
			bm.setDensity(density);
			int targetDensity = opts.inTargetDensity;
			if (targetDensity == 0 || density == targetDensity || density == opts.inScreenDensity)
			{
				return bm;
			}
			byte[] np = bm.getNinePatchChunk();
			bool isNinePatch = np != null && android.graphics.NinePatch.isNinePatchChunk(np);
			if (opts.inScaled || isNinePatch)
			{
				float scale = targetDensity / (float)density;
				// TODO: This is very inefficient and should be done in native by Skia
				android.graphics.Bitmap oldBitmap = bm;
				bm = android.graphics.Bitmap.createScaledBitmap(oldBitmap, (int)(bm.getWidth() * 
					scale + 0.5f), (int)(bm.getHeight() * scale + 0.5f), true);
				oldBitmap.recycle();
				if (isNinePatch)
				{
					np = nativeScaleNinePatch(np, scale, outPadding);
					bm.setNinePatchChunk(np);
				}
				bm.setDensity(targetDensity);
			}
			return bm;
		}

		/// <summary>Decode an input stream into a bitmap.</summary>
		/// <remarks>
		/// Decode an input stream into a bitmap. If the input stream is null, or
		/// cannot be used to decode a bitmap, the function returns null.
		/// The stream's position will be where ever it was after the encoded data
		/// was read.
		/// </remarks>
		/// <param name="is">
		/// The input stream that holds the raw data to be decoded into a
		/// bitmap.
		/// </param>
		/// <returns>The decoded bitmap, or null if the image data could not be decoded.</returns>
		public static android.graphics.Bitmap decodeStream(java.io.InputStream @is)
		{
			return decodeStream(@is, null, null);
		}

		[Sharpen.Stub]
		public static android.graphics.Bitmap decodeFileDescriptor(java.io.FileDescriptor
			 fd, android.graphics.Rect outPadding, android.graphics.BitmapFactory.Options opts
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.graphics.Bitmap decodeFileDescriptor(java.io.FileDescriptor
			 fd)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Set the default config used for decoding bitmaps.</summary>
		/// <remarks>
		/// Set the default config used for decoding bitmaps. This config is
		/// presented to the codec if the caller did not specify a preferred config
		/// in their call to decode...
		/// The default value is chosen by the system to best match the device's
		/// screen and memory constraints.
		/// </remarks>
		/// <param name="config">
		/// The preferred config for decoding bitmaps. If null, then
		/// a suitable default is chosen by the system.
		/// </param>
		/// <hide>
		/// - only called by the browser at the moment, but should be stable
		/// enough to expose if needed
		/// </hide>
		public static void setDefaultConfig(android.graphics.Bitmap.Config config)
		{
			if (config == null)
			{
				// pick this for now, as historically it was our default.
				// However, if we have a smarter algorithm, we can change this.
				config = android.graphics.Bitmap.Config.RGB_565;
			}
			nativeSetDefaultConfig((int)config);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_BitmapFactory_setDefaultConfig(int nativeConfig
			);

		private static void nativeSetDefaultConfig(int nativeConfig)
		{
			libxobotos_BitmapFactory_setDefaultConfig((int)nativeConfig);
		}

		[Sharpen.NativeStub]
		private static android.graphics.Bitmap nativeDecodeStream(java.io.InputStream @is
			, byte[] storage, android.graphics.Rect padding, android.graphics.BitmapFactory.
			Options opts)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Bitmap.NativeBitmap libxobotos_BitmapFactory_nativeDecodeAsset
			(android.content.res.AssetManager.AssetInputStream.NativeAsset asset, System.IntPtr
			 padding, System.IntPtr opts);

		private static android.graphics.Bitmap nativeDecodeAsset(android.content.res.AssetManager.AssetInputStream.NativeAsset
			 asset, android.graphics.Rect padding, android.graphics.BitmapFactory.Options opts
			)
		{
			System.IntPtr padding_ptr = System.IntPtr.Zero;
			System.IntPtr opts_ptr = System.IntPtr.Zero;
			try
			{
				padding_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(padding);
				opts_ptr = android.graphics.BitmapFactory.Options.Options_Helper.ManagedToNative(
					opts);
				android.graphics.Bitmap _retval = new android.graphics.Bitmap(libxobotos_BitmapFactory_nativeDecodeAsset
					(asset, padding_ptr, opts_ptr));
				android.graphics.BitmapFactory.Options.Options_Helper.MarshalOut(opts_ptr, opts);
				return _retval;
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(padding_ptr);
				android.graphics.BitmapFactory.Options.Options_Helper.FreeManagedPtr(opts_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Bitmap.NativeBitmap libxobotos_BitmapFactory_decodeByteArray
			(System.IntPtr data, int offset, int length, System.IntPtr opts);

		private static android.graphics.Bitmap nativeDecodeByteArray(byte[] data, int offset
			, int length, android.graphics.BitmapFactory.Options opts)
		{
			Sharpen.INativeHandle data_handle = null;
			System.IntPtr opts_ptr = System.IntPtr.Zero;
			try
			{
				data_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(data);
				opts_ptr = android.graphics.BitmapFactory.Options.Options_Helper.ManagedToNative(
					opts);
				android.graphics.Bitmap _retval = new android.graphics.Bitmap(libxobotos_BitmapFactory_decodeByteArray
					(data_handle.Address, offset, length, opts_ptr));
				android.graphics.BitmapFactory.Options.Options_Helper.MarshalOut(opts_ptr, opts);
				return _retval;
			}
			finally
			{
				if (data_handle != null)
				{
					data_handle.Free();
				}
				android.graphics.BitmapFactory.Options.Options_Helper.FreeManagedPtr(opts_ptr);
			}
		}

		[Sharpen.NativeStub]
		private static byte[] nativeScaleNinePatch(byte[] chunk, float scale, android.graphics.Rect
			 pad)
		{
			throw new System.NotImplementedException();
		}
	}
}
