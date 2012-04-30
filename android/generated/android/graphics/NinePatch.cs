using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>The NinePatch class permits drawing a bitmap in nine sections.</summary>
	/// <remarks>
	/// The NinePatch class permits drawing a bitmap in nine sections.
	/// The four corners are unscaled; the four edges are scaled in one axis,
	/// and the middle is scaled in both axes. Normally, the middle is
	/// transparent so that the patch can provide a selection about a rectangle.
	/// Essentially, it allows the creation of custom graphics that will scale the
	/// way that you define, when content added within the image exceeds the normal
	/// bounds of the graphic. For a thorough explanation of a NinePatch image,
	/// read the discussion in the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/graphics/2d-graphics.html#nine-patch"&gt;2D
	/// Graphics</a> document.
	/// <p>
	/// The &lt;a href="
	/// <docRoot></docRoot>
	/// guide/developing/tools/draw9patch.html"&gt;Draw 9-Patch</a>
	/// tool offers an extremely handy way to create your NinePatch images,
	/// using a WYSIWYG graphics editor.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class NinePatch
	{
		private readonly android.graphics.Bitmap mBitmap;

		private readonly byte[] mChunk;

		private android.graphics.Paint mPaint;

		private string mSrcName;

		private readonly android.graphics.RectF mRect = new android.graphics.RectF();

		/// <summary>Create a drawable projection from a bitmap to nine patches.</summary>
		/// <remarks>Create a drawable projection from a bitmap to nine patches.</remarks>
		/// <param name="bitmap">The bitmap describing the patches.</param>
		/// <param name="chunk">
		/// The 9-patch data chunk describing how the underlying
		/// bitmap is split apart and drawn.
		/// </param>
		/// <param name="srcName">The name of the source for the bitmap. Might be null.</param>
		public NinePatch(android.graphics.Bitmap bitmap, byte[] chunk, string srcName)
		{
			// Useful for debugging
			mBitmap = bitmap;
			mChunk = chunk;
			mSrcName = srcName;
			validateNinePatchChunk(mBitmap.nativeInstance, chunk);
		}

		/// <hide></hide>
		public NinePatch(android.graphics.NinePatch patch)
		{
			mBitmap = patch.mBitmap;
			mChunk = patch.mChunk;
			mSrcName = patch.mSrcName;
			if (patch.mPaint != null)
			{
				mPaint = new android.graphics.Paint(patch.mPaint);
			}
			validateNinePatchChunk(mBitmap.nativeInstance, mChunk);
		}

		public virtual void setPaint(android.graphics.Paint p)
		{
			mPaint = p;
		}

		/// <summary>Draw a bitmap of nine patches.</summary>
		/// <remarks>Draw a bitmap of nine patches.</remarks>
		/// <param name="canvas">A container for the current matrix and clip used to draw the bitmap.
		/// 	</param>
		/// <param name="location">Where to draw the bitmap.</param>
		public virtual void draw(android.graphics.Canvas canvas, android.graphics.RectF location
			)
		{
			if (!canvas.isHardwareAccelerated())
			{
				nativeDraw(canvas.mNativeCanvas, location, mBitmap.nativeInstance, mChunk, mPaint
					 != null ? mPaint.mNativePaint : null, canvas.mDensity, mBitmap.mDensity);
			}
			else
			{
				canvas.drawPatch(mBitmap, mChunk, location, mPaint);
			}
		}

		/// <summary>Draw a bitmap of nine patches.</summary>
		/// <remarks>Draw a bitmap of nine patches.</remarks>
		/// <param name="canvas">A container for the current matrix and clip used to draw the bitmap.
		/// 	</param>
		/// <param name="location">Where to draw the bitmap.</param>
		public virtual void draw(android.graphics.Canvas canvas, android.graphics.Rect location
			)
		{
			if (!canvas.isHardwareAccelerated())
			{
				nativeDraw(canvas.mNativeCanvas, location, mBitmap.nativeInstance, mChunk, mPaint
					 != null ? mPaint.mNativePaint : null, canvas.mDensity, mBitmap.mDensity);
			}
			else
			{
				mRect.set(location);
				canvas.drawPatch(mBitmap, mChunk, mRect, mPaint);
			}
		}

		/// <summary>Draw a bitmap of nine patches.</summary>
		/// <remarks>Draw a bitmap of nine patches.</remarks>
		/// <param name="canvas">A container for the current matrix and clip used to draw the bitmap.
		/// 	</param>
		/// <param name="location">Where to draw the bitmap.</param>
		/// <param name="paint">The Paint to draw through.</param>
		public virtual void draw(android.graphics.Canvas canvas, android.graphics.Rect location
			, android.graphics.Paint paint)
		{
			if (!canvas.isHardwareAccelerated())
			{
				nativeDraw(canvas.mNativeCanvas, location, mBitmap.nativeInstance, mChunk, paint 
					!= null ? paint.mNativePaint : null, canvas.mDensity, mBitmap.mDensity);
			}
			else
			{
				mRect.set(location);
				canvas.drawPatch(mBitmap, mChunk, mRect, paint);
			}
		}

		/// <summary>
		/// Return the underlying bitmap's density, as per
		/// <see cref="Bitmap.getDensity()">Bitmap.getDensity()</see>
		/// .
		/// </summary>
		public virtual int getDensity()
		{
			return mBitmap.mDensity;
		}

		public virtual int getWidth()
		{
			return mBitmap.getWidth();
		}

		public virtual int getHeight()
		{
			return mBitmap.getHeight();
		}

		public bool hasAlpha()
		{
			return mBitmap.hasAlpha();
		}

		public android.graphics.Region getTransparentRegion(android.graphics.Rect location
			)
		{
			android.graphics.Region.NativeRegion r = nativeGetTransparentRegion(mBitmap.nativeInstance
				, mChunk, location);
			return r != null ? new android.graphics.Region(r) : null;
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_NinePatch_isNinePatchChunk(System.IntPtr chunk
			);

		public static bool isNinePatchChunk(byte[] chunk)
		{
			Sharpen.INativeHandle chunk_handle = null;
			try
			{
				chunk_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(chunk);
				return libxobotos_NinePatch_isNinePatchChunk(chunk_handle != null ? chunk_handle.
					Address : System.IntPtr.Zero);
			}
			finally
			{
				if (chunk_handle != null)
				{
					chunk_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_NinePatch_validateNinePatchChunk(android.graphics.Bitmap.NativeBitmap
			 bitmap, System.IntPtr chunk);

		private static void validateNinePatchChunk(android.graphics.Bitmap.NativeBitmap bitmap
			, byte[] chunk)
		{
			Sharpen.INativeHandle chunk_handle = null;
			try
			{
				chunk_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(chunk);
				libxobotos_NinePatch_validateNinePatchChunk(bitmap, chunk_handle.Address);
			}
			finally
			{
				if (chunk_handle != null)
				{
					chunk_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_NinePatch_drawF(android.graphics.Canvas.NativeCanvas
			 canvas_instance, System.IntPtr loc, android.graphics.Bitmap.NativeBitmap bitmap_instance
			, System.IntPtr c, android.graphics.Paint.NativePaint paint_instance_or_null, int
			 destDensity, int srcDensity);

		private static void nativeDraw(android.graphics.Canvas.NativeCanvas canvas_instance
			, android.graphics.RectF loc, android.graphics.Bitmap.NativeBitmap bitmap_instance
			, byte[] c, android.graphics.Paint.NativePaint paint_instance_or_null, int destDensity
			, int srcDensity)
		{
			System.IntPtr loc_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle c_handle = null;
			try
			{
				loc_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(loc);
				c_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(c);
				libxobotos_NinePatch_drawF(canvas_instance, loc_ptr, bitmap_instance, c_handle.Address
					, paint_instance_or_null != null ? paint_instance_or_null : android.graphics.Paint.NativePaint
					.Zero, destDensity, srcDensity);
				android.graphics.RectF.RectF_Helper.MarshalOut(loc_ptr, loc);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(loc_ptr);
				if (c_handle != null)
				{
					c_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_NinePatch_drawI(android.graphics.Canvas.NativeCanvas
			 canvas_instance, System.IntPtr loc, android.graphics.Bitmap.NativeBitmap bitmap_instance
			, System.IntPtr c, android.graphics.Paint.NativePaint paint_instance_or_null, int
			 destDensity, int srcDensity);

		private static void nativeDraw(android.graphics.Canvas.NativeCanvas canvas_instance
			, android.graphics.Rect loc, android.graphics.Bitmap.NativeBitmap bitmap_instance
			, byte[] c, android.graphics.Paint.NativePaint paint_instance_or_null, int destDensity
			, int srcDensity)
		{
			System.IntPtr loc_ptr = System.IntPtr.Zero;
			Sharpen.INativeHandle c_handle = null;
			try
			{
				loc_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(loc);
				c_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(c);
				libxobotos_NinePatch_drawI(canvas_instance, loc_ptr, bitmap_instance, c_handle.Address
					, paint_instance_or_null != null ? paint_instance_or_null : android.graphics.Paint.NativePaint
					.Zero, destDensity, srcDensity);
				android.graphics.Rect.Rect_Helper.MarshalOut(loc_ptr, loc);
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(loc_ptr);
				if (c_handle != null)
				{
					c_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Region.NativeRegion libxobotos_NinePatch_getTransparentRegion
			(android.graphics.Bitmap.NativeBitmap bitmap, System.IntPtr chunk, System.IntPtr
			 location);

		private static android.graphics.Region.NativeRegion nativeGetTransparentRegion(android.graphics.Bitmap.NativeBitmap
			 bitmap, byte[] chunk, android.graphics.Rect location)
		{
			Sharpen.INativeHandle chunk_handle = null;
			System.IntPtr location_ptr = System.IntPtr.Zero;
			try
			{
				chunk_handle = XobotOS.Runtime.MarshalGlue.Array_byte_Helper.GetPinnedPtr(chunk);
				location_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(location);
				return libxobotos_NinePatch_getTransparentRegion(bitmap, chunk_handle.Address, location_ptr
					);
			}
			finally
			{
				if (chunk_handle != null)
				{
					chunk_handle.Free();
				}
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(location_ptr);
			}
		}
	}
}
