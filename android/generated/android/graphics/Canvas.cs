using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>The Canvas class holds the "draw" calls.</summary>
	/// <remarks>
	/// The Canvas class holds the "draw" calls. To draw something, you need
	/// 4 basic components: A Bitmap to hold the pixels, a Canvas to host
	/// the draw calls (writing into the bitmap), a drawing primitive (e.g. Rect,
	/// Path, text, Bitmap), and a paint (to describe the colors and styles for the
	/// drawing).
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about how to use Canvas, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/graphics/2d-graphics.html"&gt;
	/// Canvas and Drawables</a> developer guide.</p></div>
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class Canvas : System.IDisposable
	{
		internal readonly android.graphics.Canvas.NativeCanvas mNativeCanvas;

		private android.graphics.Bitmap mBitmap;

		private android.graphics.DrawFilter mDrawFilter;

		/// <hide></hide>
		protected internal int mDensity = android.graphics.Bitmap.DENSITY_NONE;

		/// <summary>Used to determine when compatibility scaling is in effect.</summary>
		/// <remarks>Used to determine when compatibility scaling is in effect.</remarks>
		/// <hide></hide>
		protected internal int mScreenDensity = android.graphics.Bitmap.DENSITY_NONE;

		private int mSurfaceFormat;

		/// <summary>Flag for drawTextRun indicating left-to-right run direction.</summary>
		/// <remarks>Flag for drawTextRun indicating left-to-right run direction.</remarks>
		/// <hide></hide>
		public const int DIRECTION_LTR = 0;

		/// <summary>Flag for drawTextRun indicating right-to-left run direction.</summary>
		/// <remarks>Flag for drawTextRun indicating right-to-left run direction.</remarks>
		/// <hide></hide>
		public const int DIRECTION_RTL = 1;

		internal const int MAXMIMUM_BITMAP_SIZE = 32766;

		// assigned in constructors, freed in finalizer
		// if not null, mGL must be null
		// optional field set by the caller
		// Used by native code
		// Maximum bitmap size as defined in Skia's native code
		// (see SkCanvas.cpp, SkDraw.cpp)
		// This field is used to finalize the native Canvas properly
		// 0 means no native bitmap
		/// <summary>Returns null.</summary>
		/// <remarks>Returns null.</remarks>
		/// <hide></hide>
		[System.ObsoleteAttribute(@"This method is not supported and should not be invoked."
			)]
		protected internal virtual javax.microedition.khronos.opengles.GL getGL()
		{
			return null;
		}

		/// <summary>Indicates whether this Canvas uses hardware acceleration.</summary>
		/// <remarks>
		/// Indicates whether this Canvas uses hardware acceleration.
		/// Note that this method does not define what type of hardware acceleration
		/// may or may not be used.
		/// </remarks>
		/// <returns>
		/// True if drawing operations are hardware accelerated,
		/// false otherwise.
		/// </returns>
		public virtual bool isHardwareAccelerated()
		{
			return false;
		}

		/// <summary>Specify a bitmap for the canvas to draw into.</summary>
		/// <remarks>
		/// Specify a bitmap for the canvas to draw into.  As a side-effect, also
		/// updates the canvas's target density to match that of the bitmap.
		/// </remarks>
		/// <param name="bitmap">Specifies a mutable bitmap for the canvas to draw into.</param>
		/// <seealso cref="setDensity(int)">setDensity(int)</seealso>
		/// <seealso cref="getDensity()">getDensity()</seealso>
		public virtual void setBitmap(android.graphics.Bitmap bitmap)
		{
			if (isHardwareAccelerated())
			{
				throw new java.lang.RuntimeException("Can't set a bitmap device on a GL canvas");
			}
			android.graphics.Bitmap.NativeBitmap pointer = null;
			if (bitmap != null)
			{
				if (!bitmap.isMutable())
				{
					throw new System.InvalidOperationException();
				}
				throwIfRecycled(bitmap);
				mDensity = bitmap.mDensity;
				pointer = bitmap.nativeInstance;
			}
			native_setBitmap(mNativeCanvas, pointer);
			mBitmap = bitmap;
		}

		/// <summary>Set the viewport dimensions if this canvas is GL based.</summary>
		/// <remarks>
		/// Set the viewport dimensions if this canvas is GL based. If it is not,
		/// this method is ignored and no exception is thrown.
		/// </remarks>
		/// <param name="width">The width of the viewport</param>
		/// <param name="height">The height of the viewport</param>
		/// <hide></hide>
		public virtual void setViewport(int width, int height)
		{
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_isOpaque(android.graphics.Canvas.NativeCanvas
			 _instance);

		/// <summary>
		/// Return true if the device that the current layer draws into is opaque
		/// (i.e.
		/// </summary>
		/// <remarks>
		/// Return true if the device that the current layer draws into is opaque
		/// (i.e. does not support per-pixel alpha).
		/// </remarks>
		/// <returns>true if the device that the current layer draws into is opaque</returns>
		public virtual bool isOpaque()
		{
			return libxobotos_Canvas_isOpaque(mNativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_getWidth(android.graphics.Canvas.NativeCanvas
			 _instance);

		/// <summary>Returns the width of the current drawing layer</summary>
		/// <returns>the width of the current drawing layer</returns>
		public virtual int getWidth()
		{
			return libxobotos_Canvas_getWidth(mNativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_getHeight(android.graphics.Canvas.NativeCanvas
			 _instance);

		/// <summary>Returns the height of the current drawing layer</summary>
		/// <returns>the height of the current drawing layer</returns>
		public virtual int getHeight()
		{
			return libxobotos_Canvas_getHeight(mNativeCanvas);
		}

		/// <summary><p>Returns the target density of the canvas.</summary>
		/// <remarks>
		/// <p>Returns the target density of the canvas.  The default density is
		/// derived from the density of its backing bitmap, or
		/// <see cref="Bitmap.DENSITY_NONE">Bitmap.DENSITY_NONE</see>
		/// if there is not one.</p>
		/// </remarks>
		/// <returns>
		/// Returns the current target density of the canvas, which is used
		/// to determine the scaling factor when drawing a bitmap into it.
		/// </returns>
		/// <seealso cref="setDensity(int)">setDensity(int)</seealso>
		/// <seealso cref="Bitmap.getDensity()"></seealso>
		public virtual int getDensity()
		{
			return mDensity;
		}

		/// <summary><p>Specifies the density for this Canvas' backing bitmap.</summary>
		/// <remarks>
		/// <p>Specifies the density for this Canvas' backing bitmap.  This modifies
		/// the target density of the canvas itself, as well as the density of its
		/// backing bitmap via
		/// <see cref="Bitmap.setDensity(int)">Bitmap.setDensity(int)</see>
		/// .
		/// </remarks>
		/// <param name="density">
		/// The new target density of the canvas, which is used
		/// to determine the scaling factor when drawing a bitmap into it.  Use
		/// <see cref="Bitmap.DENSITY_NONE">Bitmap.DENSITY_NONE</see>
		/// to disable bitmap scaling.
		/// </param>
		/// <seealso cref="getDensity()">getDensity()</seealso>
		/// <seealso cref="Bitmap.setDensity(int)"></seealso>
		public virtual void setDensity(int density)
		{
			if (mBitmap != null)
			{
				mBitmap.setDensity(density);
			}
			mDensity = density;
		}

		/// <hide></hide>
		public virtual void setScreenDensity(int density)
		{
			mScreenDensity = density;
		}

		/// <summary>Returns the maximum allowed width for bitmaps drawn with this canvas.</summary>
		/// <remarks>
		/// Returns the maximum allowed width for bitmaps drawn with this canvas.
		/// Attempting to draw with a bitmap wider than this value will result
		/// in an error.
		/// </remarks>
		/// <seealso cref="getMaximumBitmapHeight()"></seealso>
		public virtual int getMaximumBitmapWidth()
		{
			return MAXMIMUM_BITMAP_SIZE;
		}

		/// <summary>Returns the maximum allowed height for bitmaps drawn with this canvas.</summary>
		/// <remarks>
		/// Returns the maximum allowed height for bitmaps drawn with this canvas.
		/// Attempting to draw with a bitmap taller than this value will result
		/// in an error.
		/// </remarks>
		/// <seealso cref="getMaximumBitmapWidth()"></seealso>
		public virtual int getMaximumBitmapHeight()
		{
			return MAXMIMUM_BITMAP_SIZE;
		}

		/// <summary>restore the current matrix when restore() is called</summary>
		public const int MATRIX_SAVE_FLAG = unchecked((int)(0x01));

		/// <summary>restore the current clip when restore() is called</summary>
		public const int CLIP_SAVE_FLAG = unchecked((int)(0x02));

		/// <summary>the layer needs to per-pixel alpha</summary>
		public const int HAS_ALPHA_LAYER_SAVE_FLAG = unchecked((int)(0x04));

		/// <summary>the layer needs to 8-bits per color component</summary>
		public const int FULL_COLOR_LAYER_SAVE_FLAG = unchecked((int)(0x08));

		/// <summary>clip against the layer's bounds</summary>
		public const int CLIP_TO_LAYER_SAVE_FLAG = unchecked((int)(0x10));

		/// <summary>restore everything when restore() is called</summary>
		public const int ALL_SAVE_FLAG = unchecked((int)(0x1F));

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_save(android.graphics.Canvas.NativeCanvas
			 _instance);

		// the SAVE_FLAG constants must match their native equivalents
		/// <summary>Saves the current matrix and clip onto a private stack.</summary>
		/// <remarks>
		/// Saves the current matrix and clip onto a private stack. Subsequent
		/// calls to translate,scale,rotate,skew,concat or clipRect,clipPath
		/// will all operate as usual, but when the balancing call to restore()
		/// is made, those calls will be forgotten, and the settings that existed
		/// before the save() will be reinstated.
		/// </remarks>
		/// <returns>The value to pass to restoreToCount() to balance this save()</returns>
		public virtual int save()
		{
			return libxobotos_Canvas_save(mNativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_save_0(android.graphics.Canvas.NativeCanvas
			 _instance, int saveFlags);

		/// <summary>
		/// Based on saveFlags, can save the current matrix and clip onto a private
		/// stack.
		/// </summary>
		/// <remarks>
		/// Based on saveFlags, can save the current matrix and clip onto a private
		/// stack. Subsequent calls to translate,scale,rotate,skew,concat or
		/// clipRect,clipPath will all operate as usual, but when the balancing
		/// call to restore() is made, those calls will be forgotten, and the
		/// settings that existed before the save() will be reinstated.
		/// </remarks>
		/// <param name="saveFlags">
		/// flag bits that specify which parts of the Canvas state
		/// to save/restore
		/// </param>
		/// <returns>The value to pass to restoreToCount() to balance this save()</returns>
		public virtual int save(int saveFlags)
		{
			return libxobotos_Canvas_save_0(mNativeCanvas, saveFlags);
		}

		/// <summary>
		/// This behaves the same as save(), but in addition it allocates an
		/// offscreen bitmap.
		/// </summary>
		/// <remarks>
		/// This behaves the same as save(), but in addition it allocates an
		/// offscreen bitmap. All drawing calls are directed there, and only when
		/// the balancing call to restore() is made is that offscreen transfered to
		/// the canvas (or the previous layer). Subsequent calls to translate,
		/// scale, rotate, skew, concat or clipRect, clipPath all operate on this
		/// copy. When the balancing call to restore() is made, this copy is
		/// deleted and the previous matrix/clip state is restored.
		/// </remarks>
		/// <param name="bounds">
		/// May be null. The maximum size the offscreen bitmap
		/// needs to be (in local coordinates)
		/// </param>
		/// <param name="paint">
		/// This is copied, and is applied to the offscreen when
		/// restore() is called.
		/// </param>
		/// <param name="saveFlags">see _SAVE_FLAG constants</param>
		/// <returns>value to pass to restoreToCount() to balance this save()</returns>
		public virtual int saveLayer(android.graphics.RectF bounds, android.graphics.Paint
			 paint, int saveFlags)
		{
			return native_saveLayer(mNativeCanvas, bounds, paint != null ? paint.mNativePaint
				 : null, saveFlags);
		}

		/// <summary>Helper version of saveLayer() that takes 4 values rather than a RectF.</summary>
		/// <remarks>Helper version of saveLayer() that takes 4 values rather than a RectF.</remarks>
		public virtual int saveLayer(float left, float top, float right, float bottom, android.graphics.Paint
			 paint, int saveFlags)
		{
			return native_saveLayer(mNativeCanvas, left, top, right, bottom, paint != null ? 
				paint.mNativePaint : null, saveFlags);
		}

		/// <summary>
		/// This behaves the same as save(), but in addition it allocates an
		/// offscreen bitmap.
		/// </summary>
		/// <remarks>
		/// This behaves the same as save(), but in addition it allocates an
		/// offscreen bitmap. All drawing calls are directed there, and only when
		/// the balancing call to restore() is made is that offscreen transfered to
		/// the canvas (or the previous layer). Subsequent calls to translate,
		/// scale, rotate, skew, concat or clipRect, clipPath all operate on this
		/// copy. When the balancing call to restore() is made, this copy is
		/// deleted and the previous matrix/clip state is restored.
		/// </remarks>
		/// <param name="bounds">
		/// The maximum size the offscreen bitmap needs to be
		/// (in local coordinates)
		/// </param>
		/// <param name="alpha">
		/// The alpha to apply to the offscreen when when it is
		/// drawn during restore()
		/// </param>
		/// <param name="saveFlags">see _SAVE_FLAG constants</param>
		/// <returns>value to pass to restoreToCount() to balance this call</returns>
		public virtual int saveLayerAlpha(android.graphics.RectF bounds, int alpha, int saveFlags
			)
		{
			alpha = System.Math.Min(255, System.Math.Max(0, alpha));
			return native_saveLayerAlpha(mNativeCanvas, bounds, alpha, saveFlags);
		}

		/// <summary>Helper for saveLayerAlpha() that takes 4 values instead of a RectF.</summary>
		/// <remarks>Helper for saveLayerAlpha() that takes 4 values instead of a RectF.</remarks>
		public virtual int saveLayerAlpha(float left, float top, float right, float bottom
			, int alpha, int saveFlags)
		{
			return native_saveLayerAlpha(mNativeCanvas, left, top, right, bottom, alpha, saveFlags
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_restore(android.graphics.Canvas.NativeCanvas
			 _instance);

		/// <summary>
		/// This call balances a previous call to save(), and is used to remove all
		/// modifications to the matrix/clip state since the last save call.
		/// </summary>
		/// <remarks>
		/// This call balances a previous call to save(), and is used to remove all
		/// modifications to the matrix/clip state since the last save call. It is
		/// an error to call restore() more times than save() was called.
		/// </remarks>
		public virtual void restore()
		{
			libxobotos_Canvas_restore(mNativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_getSaveCount(android.graphics.Canvas.NativeCanvas
			 _instance);

		/// <summary>Returns the number of matrix/clip states on the Canvas' private stack.</summary>
		/// <remarks>
		/// Returns the number of matrix/clip states on the Canvas' private stack.
		/// This will equal # save() calls - # restore() calls.
		/// </remarks>
		public virtual int getSaveCount()
		{
			return libxobotos_Canvas_getSaveCount(mNativeCanvas);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_restoreToCount(android.graphics.Canvas.NativeCanvas
			 _instance, int saveCount);

		/// <summary>
		/// Efficient way to pop any calls to save() that happened after the save
		/// count reached saveCount.
		/// </summary>
		/// <remarks>
		/// Efficient way to pop any calls to save() that happened after the save
		/// count reached saveCount. It is an error for saveCount to be less than 1.
		/// Example:
		/// int count = canvas.save();
		/// ... // more calls potentially to save()
		/// canvas.restoreToCount(count);
		/// // now the canvas is back in the same state it was before the initial
		/// // call to save().
		/// </remarks>
		/// <param name="saveCount">The save level to restore to.</param>
		public virtual void restoreToCount(int saveCount)
		{
			libxobotos_Canvas_restoreToCount(mNativeCanvas, saveCount);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_translate(android.graphics.Canvas.NativeCanvas
			 _instance, float dx, float dy);

		/// <summary>Preconcat the current matrix with the specified translation</summary>
		/// <param name="dx">The distance to translate in X</param>
		/// <param name="dy">The distance to translate in Y</param>
		public virtual void translate(float dx, float dy)
		{
			libxobotos_Canvas_translate(mNativeCanvas, dx, dy);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_scale(android.graphics.Canvas.NativeCanvas
			 _instance, float sx, float sy);

		/// <summary>Preconcat the current matrix with the specified scale.</summary>
		/// <remarks>Preconcat the current matrix with the specified scale.</remarks>
		/// <param name="sx">The amount to scale in X</param>
		/// <param name="sy">The amount to scale in Y</param>
		public virtual void scale(float sx, float sy)
		{
			libxobotos_Canvas_scale(mNativeCanvas, sx, sy);
		}

		/// <summary>Preconcat the current matrix with the specified scale.</summary>
		/// <remarks>Preconcat the current matrix with the specified scale.</remarks>
		/// <param name="sx">The amount to scale in X</param>
		/// <param name="sy">The amount to scale in Y</param>
		/// <param name="px">The x-coord for the pivot point (unchanged by the scale)</param>
		/// <param name="py">The y-coord for the pivot point (unchanged by the scale)</param>
		public void scale(float sx, float sy, float px, float py)
		{
			translate(px, py);
			scale(sx, sy);
			translate(-px, -py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_rotate(android.graphics.Canvas.NativeCanvas
			 _instance, float degrees);

		/// <summary>Preconcat the current matrix with the specified rotation.</summary>
		/// <remarks>Preconcat the current matrix with the specified rotation.</remarks>
		/// <param name="degrees">The amount to rotate, in degrees</param>
		public virtual void rotate(float degrees)
		{
			libxobotos_Canvas_rotate(mNativeCanvas, degrees);
		}

		/// <summary>Preconcat the current matrix with the specified rotation.</summary>
		/// <remarks>Preconcat the current matrix with the specified rotation.</remarks>
		/// <param name="degrees">The amount to rotate, in degrees</param>
		/// <param name="px">The x-coord for the pivot point (unchanged by the rotation)</param>
		/// <param name="py">The y-coord for the pivot point (unchanged by the rotation)</param>
		public void rotate(float degrees, float px, float py)
		{
			translate(px, py);
			rotate(degrees);
			translate(-px, -py);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_skew(android.graphics.Canvas.NativeCanvas
			 _instance, float sx, float sy);

		/// <summary>Preconcat the current matrix with the specified skew.</summary>
		/// <remarks>Preconcat the current matrix with the specified skew.</remarks>
		/// <param name="sx">The amount to skew in X</param>
		/// <param name="sy">The amount to skew in Y</param>
		public virtual void skew(float sx, float sy)
		{
			libxobotos_Canvas_skew(mNativeCanvas, sx, sy);
		}

		/// <summary>Preconcat the current matrix with the specified matrix.</summary>
		/// <remarks>Preconcat the current matrix with the specified matrix.</remarks>
		/// <param name="matrix">The matrix to preconcatenate with the current matrix</param>
		public virtual void concat(android.graphics.Matrix matrix)
		{
			native_concat(mNativeCanvas, matrix.native_instance);
		}

		/// <summary>Completely replace the current matrix with the specified matrix.</summary>
		/// <remarks>
		/// Completely replace the current matrix with the specified matrix. If the
		/// matrix parameter is null, then the current matrix is reset to identity.
		/// </remarks>
		/// <param name="matrix">
		/// The matrix to replace the current matrix with. If it is
		/// null, set the current matrix to identity.
		/// </param>
		public virtual void setMatrix(android.graphics.Matrix matrix)
		{
			native_setMatrix(mNativeCanvas, matrix == null ? null : matrix.native_instance);
		}

		/// <summary>Return, in ctm, the current transformation matrix.</summary>
		/// <remarks>
		/// Return, in ctm, the current transformation matrix. This does not alter
		/// the matrix in the canvas, but just returns a copy of it.
		/// </remarks>
		public virtual void getMatrix(android.graphics.Matrix ctm)
		{
			native_getCTM(mNativeCanvas, ctm.native_instance);
		}

		/// <summary>
		/// Return a new matrix with a copy of the canvas' current transformation
		/// matrix.
		/// </summary>
		/// <remarks>
		/// Return a new matrix with a copy of the canvas' current transformation
		/// matrix.
		/// </remarks>
		public android.graphics.Matrix getMatrix()
		{
			android.graphics.Matrix m = new android.graphics.Matrix();
			getMatrix(m);
			return m;
		}

		/// <summary>Modify the current clip with the specified rectangle.</summary>
		/// <remarks>Modify the current clip with the specified rectangle.</remarks>
		/// <param name="rect">The rect to intersect with the current clip</param>
		/// <param name="op">How the clip is modified</param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(android.graphics.RectF rect, android.graphics.Region
			.Op op)
		{
			return native_clipRect(mNativeCanvas, rect.left, rect.top, rect.right, rect.bottom
				, (int)op);
		}

		/// <summary>
		/// Modify the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Modify the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="rect">The rectangle to intersect with the current clip.</param>
		/// <param name="op">How the clip is modified</param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(android.graphics.Rect rect, android.graphics.Region.
			Op op)
		{
			return native_clipRect(mNativeCanvas, rect.left, rect.top, rect.right, rect.bottom
				, (int)op);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipRect(android.graphics.Canvas.NativeCanvas
			 _instance, System.IntPtr rect);

		/// <summary>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="rect">The rectangle to intersect with the current clip.</param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(android.graphics.RectF rect)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				return libxobotos_Canvas_clipRect(mNativeCanvas, rect_ptr);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipIRect(android.graphics.Canvas.NativeCanvas
			 _instance, System.IntPtr rect);

		/// <summary>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="rect">The rectangle to intersect with the current clip.</param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(android.graphics.Rect rect)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(rect);
				return libxobotos_Canvas_clipIRect(mNativeCanvas, rect_ptr);
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		/// <summary>
		/// Modify the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Modify the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="left">
		/// The left side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="top">
		/// The top of the rectangle to intersect with the current
		/// clip
		/// </param>
		/// <param name="right">
		/// The right side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="bottom">
		/// The bottom of the rectangle to intersect with the current
		/// clip
		/// </param>
		/// <param name="op">How the clip is modified</param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(float left, float top, float right, float bottom, android.graphics.Region
			.Op op)
		{
			return native_clipRect(mNativeCanvas, left, top, right, bottom, (int)op);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipRect_0(android.graphics.Canvas.NativeCanvas
			 _instance, float left, float top, float right, float bottom);

		/// <summary>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="left">
		/// The left side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="top">The top of the rectangle to intersect with the current clip</param>
		/// <param name="right">
		/// The right side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="bottom">
		/// The bottom of the rectangle to intersect with the current
		/// clip
		/// </param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(float left, float top, float right, float bottom)
		{
			return libxobotos_Canvas_clipRect_0(mNativeCanvas, left, top, right, bottom);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipIRect_0(android.graphics.Canvas.NativeCanvas
			 _instance, int left, int top, int right, int bottom);

		/// <summary>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </summary>
		/// <remarks>
		/// Intersect the current clip with the specified rectangle, which is
		/// expressed in local coordinates.
		/// </remarks>
		/// <param name="left">
		/// The left side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="top">The top of the rectangle to intersect with the current clip</param>
		/// <param name="right">
		/// The right side of the rectangle to intersect with the
		/// current clip
		/// </param>
		/// <param name="bottom">
		/// The bottom of the rectangle to intersect with the current
		/// clip
		/// </param>
		/// <returns>true if the resulting clip is non-empty</returns>
		public virtual bool clipRect(int left, int top, int right, int bottom)
		{
			return libxobotos_Canvas_clipIRect_0(mNativeCanvas, left, top, right, bottom);
		}

		/// <summary>Modify the current clip with the specified path.</summary>
		/// <remarks>Modify the current clip with the specified path.</remarks>
		/// <param name="path">The path to operate on the current clip</param>
		/// <param name="op">How the clip is modified</param>
		/// <returns>true if the resulting is non-empty</returns>
		public virtual bool clipPath(android.graphics.Path path, android.graphics.Region.
			Op op)
		{
			return native_clipPath(mNativeCanvas, path.nativeInstance, (int)op);
		}

		/// <summary>Intersect the current clip with the specified path.</summary>
		/// <remarks>Intersect the current clip with the specified path.</remarks>
		/// <param name="path">The path to intersect with the current clip</param>
		/// <returns>true if the resulting is non-empty</returns>
		public virtual bool clipPath(android.graphics.Path path)
		{
			return clipPath(path, android.graphics.Region.Op.INTERSECT);
		}

		/// <summary>Modify the current clip with the specified region.</summary>
		/// <remarks>
		/// Modify the current clip with the specified region. Note that unlike
		/// clipRect() and clipPath() which transform their arguments by the
		/// current matrix, clipRegion() assumes its argument is already in the
		/// coordinate system of the current layer's bitmap, and so not
		/// transformation is performed.
		/// </remarks>
		/// <param name="region">The region to operate on the current clip, based on op</param>
		/// <param name="op">How the clip is modified</param>
		/// <returns>true if the resulting is non-empty</returns>
		public virtual bool clipRegion(android.graphics.Region region, android.graphics.Region
			.Op op)
		{
			return native_clipRegion(mNativeCanvas, region.nativeInstance, (int)op);
		}

		/// <summary>Intersect the current clip with the specified region.</summary>
		/// <remarks>
		/// Intersect the current clip with the specified region. Note that unlike
		/// clipRect() and clipPath() which transform their arguments by the
		/// current matrix, clipRegion() assumes its argument is already in the
		/// coordinate system of the current layer's bitmap, and so not
		/// transformation is performed.
		/// </remarks>
		/// <param name="region">The region to operate on the current clip, based on op</param>
		/// <returns>true if the resulting is non-empty</returns>
		public virtual bool clipRegion(android.graphics.Region region)
		{
			return clipRegion(region, android.graphics.Region.Op.INTERSECT);
		}

		public virtual android.graphics.DrawFilter getDrawFilter()
		{
			return mDrawFilter;
		}

		public virtual void setDrawFilter(android.graphics.DrawFilter filter)
		{
			android.graphics.DrawFilter.NativeDrawFilter nativeFilter = null;
			if (filter != null)
			{
				nativeFilter = filter.mNativeInt;
			}
			mDrawFilter = filter;
			nativeSetDrawFilter(mNativeCanvas, nativeFilter);
		}

		public enum EdgeType : int
		{
			BW = 0,
			AA = 1
		}

		//!< treat edges by just rounding to nearest pixel boundary
		//!< treat edges by rounding-out, since they may be antialiased
		/// <summary>
		/// Return true if the specified rectangle, after being transformed by the
		/// current matrix, would lie completely outside of the current clip.
		/// </summary>
		/// <remarks>
		/// Return true if the specified rectangle, after being transformed by the
		/// current matrix, would lie completely outside of the current clip. Call
		/// this to check if an area you intend to draw into is clipped out (and
		/// therefore you can skip making the draw calls).
		/// </remarks>
		/// <param name="rect">the rect to compare with the current clip</param>
		/// <param name="type">specifies how to treat the edges (BW or antialiased)</param>
		/// <returns>
		/// true if the rect (transformed by the canvas' matrix)
		/// does not intersect with the canvas' clip
		/// </returns>
		public virtual bool quickReject(android.graphics.RectF rect, android.graphics.Canvas
			.EdgeType type)
		{
			return native_quickReject(mNativeCanvas, rect, (int)type);
		}

		/// <summary>
		/// Return true if the specified path, after being transformed by the
		/// current matrix, would lie completely outside of the current clip.
		/// </summary>
		/// <remarks>
		/// Return true if the specified path, after being transformed by the
		/// current matrix, would lie completely outside of the current clip. Call
		/// this to check if an area you intend to draw into is clipped out (and
		/// therefore you can skip making the draw calls). Note: for speed it may
		/// return false even if the path itself might not intersect the clip
		/// (i.e. the bounds of the path intersects, but the path does not).
		/// </remarks>
		/// <param name="path">The path to compare with the current clip</param>
		/// <param name="type">
		/// true if the path should be considered antialiased,
		/// since that means it may
		/// affect a larger area (more pixels) than
		/// non-antialiased.
		/// </param>
		/// <returns>
		/// true if the path (transformed by the canvas' matrix)
		/// does not intersect with the canvas' clip
		/// </returns>
		public virtual bool quickReject(android.graphics.Path path, android.graphics.Canvas
			.EdgeType type)
		{
			return native_quickReject(mNativeCanvas, path.nativeInstance, (int)type);
		}

		/// <summary>
		/// Return true if the specified rectangle, after being transformed by the
		/// current matrix, would lie completely outside of the current clip.
		/// </summary>
		/// <remarks>
		/// Return true if the specified rectangle, after being transformed by the
		/// current matrix, would lie completely outside of the current clip. Call
		/// this to check if an area you intend to draw into is clipped out (and
		/// therefore you can skip making the draw calls).
		/// </remarks>
		/// <param name="left">
		/// The left side of the rectangle to compare with the
		/// current clip
		/// </param>
		/// <param name="top">
		/// The top of the rectangle to compare with the current
		/// clip
		/// </param>
		/// <param name="right">
		/// The right side of the rectangle to compare with the
		/// current clip
		/// </param>
		/// <param name="bottom">
		/// The bottom of the rectangle to compare with the
		/// current clip
		/// </param>
		/// <param name="type">
		/// true if the rect should be considered antialiased,
		/// since that means it may affect a larger area (more
		/// pixels) than non-antialiased.
		/// </param>
		/// <returns>
		/// true if the rect (transformed by the canvas' matrix)
		/// does not intersect with the canvas' clip
		/// </returns>
		public virtual bool quickReject(float left, float top, float right, float bottom, 
			android.graphics.Canvas.EdgeType type)
		{
			return native_quickReject(mNativeCanvas, left, top, right, bottom, (int)type);
		}

		/// <summary>Retrieve the clip bounds, returning true if they are non-empty.</summary>
		/// <remarks>Retrieve the clip bounds, returning true if they are non-empty.</remarks>
		/// <param name="bounds">
		/// Return the clip bounds here. If it is null, ignore it but
		/// still return true if the current clip is non-empty.
		/// </param>
		/// <returns>true if the current clip is non-empty.</returns>
		public virtual bool getClipBounds(android.graphics.Rect bounds)
		{
			return native_getClipBounds(mNativeCanvas, bounds);
		}

		/// <summary>Retrieve the clip bounds.</summary>
		/// <remarks>Retrieve the clip bounds.</remarks>
		/// <returns>the clip bounds, or [0, 0, 0, 0] if the clip is empty.</returns>
		public android.graphics.Rect getClipBounds()
		{
			android.graphics.Rect r = new android.graphics.Rect();
			getClipBounds(r);
			return r;
		}

		/// <summary>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified RGB color, using srcover porterduff mode.
		/// </summary>
		/// <remarks>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified RGB color, using srcover porterduff mode.
		/// </remarks>
		/// <param name="r">red component (0..255) of the color to draw onto the canvas</param>
		/// <param name="g">green component (0..255) of the color to draw onto the canvas</param>
		/// <param name="b">blue component (0..255) of the color to draw onto the canvas</param>
		public virtual void drawRGB(int r, int g, int b)
		{
			native_drawRGB(mNativeCanvas, r, g, b);
		}

		/// <summary>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified ARGB color, using srcover porterduff mode.
		/// </summary>
		/// <remarks>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified ARGB color, using srcover porterduff mode.
		/// </remarks>
		/// <param name="a">alpha component (0..255) of the color to draw onto the canvas</param>
		/// <param name="r">red component (0..255) of the color to draw onto the canvas</param>
		/// <param name="g">green component (0..255) of the color to draw onto the canvas</param>
		/// <param name="b">blue component (0..255) of the color to draw onto the canvas</param>
		public virtual void drawARGB(int a, int r, int g, int b)
		{
			native_drawARGB(mNativeCanvas, a, r, g, b);
		}

		/// <summary>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified color, using srcover porterduff mode.
		/// </summary>
		/// <remarks>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified color, using srcover porterduff mode.
		/// </remarks>
		/// <param name="color">the color to draw onto the canvas</param>
		public virtual void drawColor(int color)
		{
			native_drawColor(mNativeCanvas, color);
		}

		/// <summary>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified color and porter-duff xfermode.
		/// </summary>
		/// <remarks>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with the
		/// specified color and porter-duff xfermode.
		/// </remarks>
		/// <param name="color">the color to draw with</param>
		/// <param name="mode">the porter-duff mode to apply to the color</param>
		public virtual void drawColor(int color, android.graphics.PorterDuff.Mode mode)
		{
			native_drawColor(mNativeCanvas, color, (int)mode);
		}

		/// <summary>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with
		/// the specified paint.
		/// </summary>
		/// <remarks>
		/// Fill the entire canvas' bitmap (restricted to the current clip) with
		/// the specified paint. This is equivalent (but faster) to drawing an
		/// infinitely large rectangle with the specified paint.
		/// </remarks>
		/// <param name="paint">The paint used to draw onto the canvas</param>
		public virtual void drawPaint(android.graphics.Paint paint)
		{
			native_drawPaint(mNativeCanvas, paint.mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawPoints(android.graphics.Canvas.NativeCanvas
			 _instance, System.IntPtr pts, int offset, int count, android.graphics.Paint.NativePaint
			 paint);

		/// <summary>Draw a series of points.</summary>
		/// <remarks>
		/// Draw a series of points. Each point is centered at the coordinate
		/// specified by pts[], and its diameter is specified by the paint's stroke
		/// width (as transformed by the canvas' CTM), with special treatment for
		/// a stroke width of 0, which always draws exactly 1 pixel (or at most 4
		/// if antialiasing is enabled). The shape of the point is controlled by
		/// the paint's Cap type. The shape is a square, unless the cap type is
		/// Round, in which case the shape is a circle.
		/// </remarks>
		/// <param name="pts">Array of points to draw [x0 y0 x1 y1 x2 y2 ...]</param>
		/// <param name="offset">Number of values to skip before starting to draw.</param>
		/// <param name="count">
		/// The number of values to process, after skipping offset
		/// of them. Since one point uses two values, the number of
		/// "points" that are drawn is really (count &gt;&gt; 1).
		/// </param>
		/// <param name="paint">The paint used to draw the points</param>
		public virtual void drawPoints(float[] pts, int offset, int count, android.graphics.Paint
			 paint)
		{
			Sharpen.INativeHandle pts_handle = null;
			try
			{
				pts_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(pts);
				libxobotos_Canvas_drawPoints(mNativeCanvas, pts_handle.Address, offset, count, paint
					 != null ? paint.mNativePaint : android.graphics.Paint.NativePaint.Zero);
			}
			finally
			{
				if (pts_handle != null)
				{
					pts_handle.Free();
				}
			}
		}

		/// <summary>Helper for drawPoints() that assumes you want to draw the entire array</summary>
		public virtual void drawPoints(float[] pts, android.graphics.Paint paint)
		{
			drawPoints(pts, 0, pts.Length, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawPoint(android.graphics.Canvas.NativeCanvas
			 _instance, float x, float y, android.graphics.Paint.NativePaint paint);

		/// <summary>Helper for drawPoints() for drawing a single point.</summary>
		/// <remarks>Helper for drawPoints() for drawing a single point.</remarks>
		public virtual void drawPoint(float x, float y, android.graphics.Paint paint)
		{
			libxobotos_Canvas_drawPoint(mNativeCanvas, x, y, paint != null ? paint.mNativePaint
				 : android.graphics.Paint.NativePaint.Zero);
		}

		/// <summary>
		/// Draw a line segment with the specified start and stop x,y coordinates,
		/// using the specified paint.
		/// </summary>
		/// <remarks>
		/// Draw a line segment with the specified start and stop x,y coordinates,
		/// using the specified paint. NOTE: since a line is always "framed", the
		/// Style is ignored in the paint.
		/// </remarks>
		/// <param name="startX">The x-coordinate of the start point of the line</param>
		/// <param name="startY">The y-coordinate of the start point of the line</param>
		/// <param name="paint">The paint used to draw the line</param>
		public virtual void drawLine(float startX, float startY, float stopX, float stopY
			, android.graphics.Paint paint)
		{
			native_drawLine(mNativeCanvas, startX, startY, stopX, stopY, paint.mNativePaint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawLines(android.graphics.Canvas.NativeCanvas
			 _instance, System.IntPtr pts, int offset, int count, android.graphics.Paint.NativePaint
			 paint);

		/// <summary>Draw a series of lines.</summary>
		/// <remarks>
		/// Draw a series of lines. Each line is taken from 4 consecutive values
		/// in the pts array. Thus to draw 1 line, the array must contain at least 4
		/// values. This is logically the same as drawing the array as follows:
		/// drawLine(pts[0], pts[1], pts[2], pts[3]) followed by
		/// drawLine(pts[4], pts[5], pts[6], pts[7]) and so on.
		/// </remarks>
		/// <param name="pts">Array of points to draw [x0 y0 x1 y1 x2 y2 ...]</param>
		/// <param name="offset">Number of values in the array to skip before drawing.</param>
		/// <param name="count">
		/// The number of values in the array to process, after
		/// skipping "offset" of them. Since each line uses 4 values,
		/// the number of "lines" that are drawn is really
		/// (count &gt;&gt; 2).
		/// </param>
		/// <param name="paint">The paint used to draw the points</param>
		public virtual void drawLines(float[] pts, int offset, int count, android.graphics.Paint
			 paint)
		{
			Sharpen.INativeHandle pts_handle = null;
			try
			{
				pts_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(pts);
				libxobotos_Canvas_drawLines(mNativeCanvas, pts_handle.Address, offset, count, paint
					 != null ? paint.mNativePaint : android.graphics.Paint.NativePaint.Zero);
			}
			finally
			{
				if (pts_handle != null)
				{
					pts_handle.Free();
				}
			}
		}

		public virtual void drawLines(float[] pts, android.graphics.Paint paint)
		{
			drawLines(pts, 0, pts.Length, paint);
		}

		/// <summary>Draw the specified Rect using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified Rect using the specified paint. The rectangle will
		/// be filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="rect">The rect to be drawn</param>
		/// <param name="paint">The paint used to draw the rect</param>
		public virtual void drawRect(android.graphics.RectF rect, android.graphics.Paint 
			paint)
		{
			native_drawRect(mNativeCanvas, rect, paint.mNativePaint);
		}

		/// <summary>Draw the specified Rect using the specified Paint.</summary>
		/// <remarks>
		/// Draw the specified Rect using the specified Paint. The rectangle
		/// will be filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="r">The rectangle to be drawn.</param>
		/// <param name="paint">The paint used to draw the rectangle</param>
		public virtual void drawRect(android.graphics.Rect r, android.graphics.Paint paint
			)
		{
			drawRect(r.left, r.top, r.right, r.bottom, paint);
		}

		/// <summary>Draw the specified Rect using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified Rect using the specified paint. The rectangle will
		/// be filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="left">The left side of the rectangle to be drawn</param>
		/// <param name="top">The top side of the rectangle to be drawn</param>
		/// <param name="right">The right side of the rectangle to be drawn</param>
		/// <param name="bottom">The bottom side of the rectangle to be drawn</param>
		/// <param name="paint">The paint used to draw the rect</param>
		public virtual void drawRect(float left, float top, float right, float bottom, android.graphics.Paint
			 paint)
		{
			native_drawRect(mNativeCanvas, left, top, right, bottom, paint.mNativePaint);
		}

		/// <summary>Draw the specified oval using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified oval using the specified paint. The oval will be
		/// filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="oval">The rectangle bounds of the oval to be drawn</param>
		public virtual void drawOval(android.graphics.RectF oval, android.graphics.Paint 
			paint)
		{
			if (oval == null)
			{
				throw new System.ArgumentNullException();
			}
			native_drawOval(mNativeCanvas, oval, paint.mNativePaint);
		}

		/// <summary>Draw the specified circle using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified circle using the specified paint. If radius is &lt;= 0,
		/// then nothing will be drawn. The circle will be filled or framed based
		/// on the Style in the paint.
		/// </remarks>
		/// <param name="cx">The x-coordinate of the center of the cirle to be drawn</param>
		/// <param name="cy">The y-coordinate of the center of the cirle to be drawn</param>
		/// <param name="radius">The radius of the cirle to be drawn</param>
		/// <param name="paint">The paint used to draw the circle</param>
		public virtual void drawCircle(float cx, float cy, float radius, android.graphics.Paint
			 paint)
		{
			native_drawCircle(mNativeCanvas, cx, cy, radius, paint.mNativePaint);
		}

		/// <summary>
		/// <p>Draw the specified arc, which will be scaled to fit inside the
		/// specified oval.</p>
		/// <p>If the start angle is negative or &gt;= 360, the start angle is treated
		/// as start angle modulo 360.</p>
		/// <p>If the sweep angle is &gt;= 360, then the oval is drawn
		/// completely.
		/// </summary>
		/// <remarks>
		/// <p>Draw the specified arc, which will be scaled to fit inside the
		/// specified oval.</p>
		/// <p>If the start angle is negative or &gt;= 360, the start angle is treated
		/// as start angle modulo 360.</p>
		/// <p>If the sweep angle is &gt;= 360, then the oval is drawn
		/// completely. Note that this differs slightly from SkPath::arcTo, which
		/// treats the sweep angle modulo 360. If the sweep angle is negative,
		/// the sweep angle is treated as sweep angle modulo 360</p>
		/// <p>The arc is drawn clockwise. An angle of 0 degrees correspond to the
		/// geometric angle of 0 degrees (3 o'clock on a watch.)</p>
		/// </remarks>
		/// <param name="oval">
		/// The bounds of oval used to define the shape and size
		/// of the arc
		/// </param>
		/// <param name="startAngle">Starting angle (in degrees) where the arc begins</param>
		/// <param name="sweepAngle">Sweep angle (in degrees) measured clockwise</param>
		/// <param name="useCenter">
		/// If true, include the center of the oval in the arc, and
		/// close it if it is being stroked. This will draw a wedge
		/// </param>
		/// <param name="paint">The paint used to draw the arc</param>
		public virtual void drawArc(android.graphics.RectF oval, float startAngle, float 
			sweepAngle, bool useCenter, android.graphics.Paint paint)
		{
			if (oval == null)
			{
				throw new System.ArgumentNullException();
			}
			native_drawArc(mNativeCanvas, oval, startAngle, sweepAngle, useCenter, paint.mNativePaint
				);
		}

		/// <summary>Draw the specified round-rect using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified round-rect using the specified paint. The roundrect
		/// will be filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="rect">The rectangular bounds of the roundRect to be drawn</param>
		/// <param name="rx">The x-radius of the oval used to round the corners</param>
		/// <param name="ry">The y-radius of the oval used to round the corners</param>
		/// <param name="paint">The paint used to draw the roundRect</param>
		public virtual void drawRoundRect(android.graphics.RectF rect, float rx, float ry
			, android.graphics.Paint paint)
		{
			if (rect == null)
			{
				throw new System.ArgumentNullException();
			}
			native_drawRoundRect(mNativeCanvas, rect, rx, ry, paint.mNativePaint);
		}

		/// <summary>Draw the specified path using the specified paint.</summary>
		/// <remarks>
		/// Draw the specified path using the specified paint. The path will be
		/// filled or framed based on the Style in the paint.
		/// </remarks>
		/// <param name="path">The path to be drawn</param>
		/// <param name="paint">The paint used to draw the path</param>
		public virtual void drawPath(android.graphics.Path path, android.graphics.Paint paint
			)
		{
			native_drawPath(mNativeCanvas, path.nativeInstance, paint.mNativePaint);
		}

		private static void throwIfRecycled(android.graphics.Bitmap bitmap)
		{
			if (bitmap.isRecycled())
			{
				throw new java.lang.RuntimeException("Canvas: trying to use a recycled bitmap " +
					 bitmap);
			}
		}

		/// <summary>
		/// Draws the specified bitmap as an N-patch (most often, a 9-patches.)
		/// Note: Only supported by hardware accelerated canvas at the moment.
		/// </summary>
		/// <remarks>
		/// Draws the specified bitmap as an N-patch (most often, a 9-patches.)
		/// Note: Only supported by hardware accelerated canvas at the moment.
		/// </remarks>
		/// <param name="bitmap">The bitmap to draw as an N-patch</param>
		/// <param name="chunks">The patches information (matches the native struct Res_png_9patch)
		/// 	</param>
		/// <param name="dst">The destination rectangle.</param>
		/// <param name="paint">The paint to draw the bitmap with. may be null</param>
		/// <hide></hide>
		public virtual void drawPatch(android.graphics.Bitmap bitmap, byte[] chunks, android.graphics.RectF
			 dst, android.graphics.Paint paint)
		{
		}

		/// <summary>
		/// Draw the specified bitmap, with its top/left corner at (x,y), using
		/// the specified paint, transformed by the current matrix.
		/// </summary>
		/// <remarks>
		/// Draw the specified bitmap, with its top/left corner at (x,y), using
		/// the specified paint, transformed by the current matrix.
		/// <p>Note: if the paint contains a maskfilter that generates a mask which
		/// extends beyond the bitmap's original width/height (e.g. BlurMaskFilter),
		/// then the bitmap will be drawn as if it were in a Shader with CLAMP mode.
		/// Thus the color outside of the original width/height will be the edge
		/// color replicated.
		/// <p>If the bitmap and canvas have different densities, this function
		/// will take care of automatically scaling the bitmap to draw at the
		/// same density as the canvas.
		/// </remarks>
		/// <param name="bitmap">The bitmap to be drawn</param>
		/// <param name="left">The position of the left side of the bitmap being drawn</param>
		/// <param name="top">The position of the top side of the bitmap being drawn</param>
		/// <param name="paint">The paint used to draw the bitmap (may be null)</param>
		public virtual void drawBitmap(android.graphics.Bitmap bitmap, float left, float 
			top, android.graphics.Paint paint)
		{
			throwIfRecycled(bitmap);
			native_drawBitmap(mNativeCanvas, bitmap.nativeInstance, left, top, paint != null ? 
				paint.mNativePaint : null, mDensity, mScreenDensity, bitmap.mDensity);
		}

		/// <summary>
		/// Draw the specified bitmap, scaling/translating automatically to fill
		/// the destination rectangle.
		/// </summary>
		/// <remarks>
		/// Draw the specified bitmap, scaling/translating automatically to fill
		/// the destination rectangle. If the source rectangle is not null, it
		/// specifies the subset of the bitmap to draw.
		/// <p>Note: if the paint contains a maskfilter that generates a mask which
		/// extends beyond the bitmap's original width/height (e.g. BlurMaskFilter),
		/// then the bitmap will be drawn as if it were in a Shader with CLAMP mode.
		/// Thus the color outside of the original width/height will be the edge
		/// color replicated.
		/// <p>This function <em>ignores the density associated with the bitmap</em>.
		/// This is because the source and destination rectangle coordinate
		/// spaces are in their respective densities, so must already have the
		/// appropriate scaling factor applied.
		/// </remarks>
		/// <param name="bitmap">The bitmap to be drawn</param>
		/// <param name="src">May be null. The subset of the bitmap to be drawn</param>
		/// <param name="dst">
		/// The rectangle that the bitmap will be scaled/translated
		/// to fit into
		/// </param>
		/// <param name="paint">May be null. The paint used to draw the bitmap</param>
		public virtual void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Rect
			 src, android.graphics.RectF dst, android.graphics.Paint paint)
		{
			if (dst == null)
			{
				throw new System.ArgumentNullException();
			}
			throwIfRecycled(bitmap);
			native_drawBitmap(mNativeCanvas, bitmap.nativeInstance, src, dst, paint != null ? 
				paint.mNativePaint : null, mScreenDensity, bitmap.mDensity);
		}

		/// <summary>
		/// Draw the specified bitmap, scaling/translating automatically to fill
		/// the destination rectangle.
		/// </summary>
		/// <remarks>
		/// Draw the specified bitmap, scaling/translating automatically to fill
		/// the destination rectangle. If the source rectangle is not null, it
		/// specifies the subset of the bitmap to draw.
		/// <p>Note: if the paint contains a maskfilter that generates a mask which
		/// extends beyond the bitmap's original width/height (e.g. BlurMaskFilter),
		/// then the bitmap will be drawn as if it were in a Shader with CLAMP mode.
		/// Thus the color outside of the original width/height will be the edge
		/// color replicated.
		/// <p>This function <em>ignores the density associated with the bitmap</em>.
		/// This is because the source and destination rectangle coordinate
		/// spaces are in their respective densities, so must already have the
		/// appropriate scaling factor applied.
		/// </remarks>
		/// <param name="bitmap">The bitmap to be drawn</param>
		/// <param name="src">May be null. The subset of the bitmap to be drawn</param>
		/// <param name="dst">
		/// The rectangle that the bitmap will be scaled/translated
		/// to fit into
		/// </param>
		/// <param name="paint">May be null. The paint used to draw the bitmap</param>
		public virtual void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Rect
			 src, android.graphics.Rect dst, android.graphics.Paint paint)
		{
			if (dst == null)
			{
				throw new System.ArgumentNullException();
			}
			throwIfRecycled(bitmap);
			native_drawBitmap(mNativeCanvas, bitmap.nativeInstance, src, dst, paint != null ? 
				paint.mNativePaint : null, mScreenDensity, bitmap.mDensity);
		}

		/// <summary>Treat the specified array of colors as a bitmap, and draw it.</summary>
		/// <remarks>
		/// Treat the specified array of colors as a bitmap, and draw it. This gives
		/// the same result as first creating a bitmap from the array, and then
		/// drawing it, but this method avoids explicitly creating a bitmap object
		/// which can be more efficient if the colors are changing often.
		/// </remarks>
		/// <param name="colors">Array of colors representing the pixels of the bitmap</param>
		/// <param name="offset">Offset into the array of colors for the first pixel</param>
		/// <param name="stride">
		/// The number of colors in the array between rows (must be
		/// &gt;= width or &lt;= -width).
		/// </param>
		/// <param name="x">The X coordinate for where to draw the bitmap</param>
		/// <param name="y">The Y coordinate for where to draw the bitmap</param>
		/// <param name="width">The width of the bitmap</param>
		/// <param name="height">The height of the bitmap</param>
		/// <param name="hasAlpha">
		/// True if the alpha channel of the colors contains valid
		/// values. If false, the alpha byte is ignored (assumed to
		/// be 0xFF for every pixel).
		/// </param>
		/// <param name="paint">May be null. The paint used to draw the bitmap</param>
		public virtual void drawBitmap(int[] colors, int offset, int stride, float x, float
			 y, int width, int height, bool hasAlpha, android.graphics.Paint paint)
		{
			// check for valid input
			if (width < 0)
			{
				throw new System.ArgumentException("width must be >= 0");
			}
			if (height < 0)
			{
				throw new System.ArgumentException("height must be >= 0");
			}
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
			// quick escape if there's nothing to draw
			if (width == 0 || height == 0)
			{
				return;
			}
			// punch down to native for the actual draw
			native_drawBitmap(mNativeCanvas, colors, offset, stride, x, y, width, height, hasAlpha
				, paint != null ? paint.mNativePaint : null);
		}

		/// <summary>Legacy version of drawBitmap(int[] colors, ...) that took ints for x,y</summary>
		public virtual void drawBitmap(int[] colors, int offset, int stride, int x, int y
			, int width, int height, bool hasAlpha, android.graphics.Paint paint)
		{
			// call through to the common float version
			drawBitmap(colors, offset, stride, (float)x, (float)y, width, height, hasAlpha, paint
				);
		}

		/// <summary>Draw the bitmap using the specified matrix.</summary>
		/// <remarks>Draw the bitmap using the specified matrix.</remarks>
		/// <param name="bitmap">The bitmap to draw</param>
		/// <param name="matrix">The matrix used to transform the bitmap when it is drawn</param>
		/// <param name="paint">May be null. The paint used to draw the bitmap</param>
		public virtual void drawBitmap(android.graphics.Bitmap bitmap, android.graphics.Matrix
			 matrix, android.graphics.Paint paint)
		{
			nativeDrawBitmapMatrix(mNativeCanvas, bitmap.nativeInstance, matrix.nativeInstance
				, paint != null ? paint.mNativePaint : null);
		}

		/// <hide></hide>
		protected internal static void checkRange(int length, int offset, int count)
		{
			if ((offset | count) < 0 || offset + count > length)
			{
				throw new System.IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Draw the bitmap through the mesh, where mesh vertices are evenly
		/// distributed across the bitmap.
		/// </summary>
		/// <remarks>
		/// Draw the bitmap through the mesh, where mesh vertices are evenly
		/// distributed across the bitmap. There are meshWidth+1 vertices across, and
		/// meshHeight+1 vertices down. The verts array is accessed in row-major
		/// order, so that the first meshWidth+1 vertices are distributed across the
		/// top of the bitmap from left to right. A more general version of this
		/// methid is drawVertices().
		/// </remarks>
		/// <param name="bitmap">The bitmap to draw using the mesh</param>
		/// <param name="meshWidth">
		/// The number of columns in the mesh. Nothing is drawn if
		/// this is 0
		/// </param>
		/// <param name="meshHeight">
		/// The number of rows in the mesh. Nothing is drawn if
		/// this is 0
		/// </param>
		/// <param name="verts">
		/// Array of x,y pairs, specifying where the mesh should be
		/// drawn. There must be at least
		/// (meshWidth+1) * (meshHeight+1) * 2 + meshOffset values
		/// in the array
		/// </param>
		/// <param name="vertOffset">Number of verts elements to skip before drawing</param>
		/// <param name="colors">
		/// May be null. Specifies a color at each vertex, which is
		/// interpolated across the cell, and whose values are
		/// multiplied by the corresponding bitmap colors. If not null,
		/// there must be at least (meshWidth+1) * (meshHeight+1) +
		/// colorOffset values in the array.
		/// </param>
		/// <param name="colorOffset">Number of color elements to skip before drawing</param>
		/// <param name="paint">May be null. The paint used to draw the bitmap</param>
		public virtual void drawBitmapMesh(android.graphics.Bitmap bitmap, int meshWidth, 
			int meshHeight, float[] verts, int vertOffset, int[] colors, int colorOffset, android.graphics.Paint
			 paint)
		{
			if ((meshWidth | meshHeight | vertOffset | colorOffset) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (meshWidth == 0 || meshHeight == 0)
			{
				return;
			}
			int count = (meshWidth + 1) * (meshHeight + 1);
			// we mul by 2 since we need two floats per vertex
			checkRange(verts.Length, vertOffset, count * 2);
			if (colors != null)
			{
				// no mul by 2, since we need only 1 color per vertex
				checkRange(colors.Length, colorOffset, count);
			}
			nativeDrawBitmapMesh(mNativeCanvas, bitmap.nativeInstance, meshWidth, meshHeight, 
				verts, vertOffset, colors, colorOffset, paint != null ? paint.mNativePaint : null
				);
		}

		public enum VertexMode : int
		{
			TRIANGLES = 0,
			TRIANGLE_STRIP = 1,
			TRIANGLE_FAN = 2
		}

		/// <summary>Draw the array of vertices, interpreted as triangles (based on mode).</summary>
		/// <remarks>
		/// Draw the array of vertices, interpreted as triangles (based on mode). The
		/// verts array is required, and specifies the x,y pairs for each vertex. If
		/// texs is non-null, then it is used to specify the coordinate in shader
		/// coordinates to use at each vertex (the paint must have a shader in this
		/// case). If there is no texs array, but there is a color array, then each
		/// color is interpolated across its corresponding triangle in a gradient. If
		/// both texs and colors arrays are present, then they behave as before, but
		/// the resulting color at each pixels is the result of multiplying the
		/// colors from the shader and the color-gradient together. The indices array
		/// is optional, but if it is present, then it is used to specify the index
		/// of each triangle, rather than just walking through the arrays in order.
		/// </remarks>
		/// <param name="mode">How to interpret the array of vertices</param>
		/// <param name="vertexCount">
		/// The number of values in the vertices array (and
		/// corresponding texs and colors arrays if non-null). Each logical
		/// vertex is two values (x, y), vertexCount must be a multiple of 2.
		/// </param>
		/// <param name="verts">Array of vertices for the mesh</param>
		/// <param name="vertOffset">Number of values in the verts to skip before drawing.</param>
		/// <param name="texs">
		/// May be null. If not null, specifies the coordinates to sample
		/// into the current shader (e.g. bitmap tile or gradient)
		/// </param>
		/// <param name="texOffset">Number of values in texs to skip before drawing.</param>
		/// <param name="colors">
		/// May be null. If not null, specifies a color for each
		/// vertex, to be interpolated across the triangle.
		/// </param>
		/// <param name="colorOffset">Number of values in colors to skip before drawing.</param>
		/// <param name="indices">
		/// If not null, array of indices to reference into the
		/// vertex (texs, colors) array.
		/// </param>
		/// <param name="indexCount">number of entries in the indices array (if not null).</param>
		/// <param name="paint">Specifies the shader to use if the texs array is non-null.</param>
		public virtual void drawVertices(android.graphics.Canvas.VertexMode mode, int vertexCount
			, float[] verts, int vertOffset, float[] texs, int texOffset, int[] colors, int 
			colorOffset, short[] indices, int indexOffset, int indexCount, android.graphics.Paint
			 paint)
		{
			checkRange(verts.Length, vertOffset, vertexCount);
			if (texs != null)
			{
				checkRange(texs.Length, texOffset, vertexCount);
			}
			if (colors != null)
			{
				checkRange(colors.Length, colorOffset, vertexCount / 2);
			}
			if (indices != null)
			{
				checkRange(indices.Length, indexOffset, indexCount);
			}
			nativeDrawVertices(mNativeCanvas, (int)mode, vertexCount, verts, vertOffset, texs
				, texOffset, colors, colorOffset, indices, indexOffset, indexCount, paint.mNativePaint
				);
		}

		/// <summary>Draw the text, with origin at (x,y), using the specified paint.</summary>
		/// <remarks>
		/// Draw the text, with origin at (x,y), using the specified paint. The
		/// origin is interpreted based on the Align setting in the paint.
		/// </remarks>
		/// <param name="text">The text to be drawn</param>
		/// <param name="x">The x-coordinate of the origin of the text being drawn</param>
		/// <param name="y">The y-coordinate of the origin of the text being drawn</param>
		/// <param name="paint">The paint used for the text (e.g. color, size, style)</param>
		public virtual void drawText(char[] text, int index, int count, float x, float y, 
			android.graphics.Paint paint)
		{
			if ((index | count | (index + count) | (text.Length - index - count)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_drawText(mNativeCanvas, text, index, count, x, y, paint.mBidiFlags, paint.
				mNativePaint);
		}

		/// <summary>Draw the text, with origin at (x,y), using the specified paint.</summary>
		/// <remarks>
		/// Draw the text, with origin at (x,y), using the specified paint. The
		/// origin is interpreted based on the Align setting in the paint.
		/// </remarks>
		/// <param name="text">The text to be drawn</param>
		/// <param name="x">The x-coordinate of the origin of the text being drawn</param>
		/// <param name="y">The y-coordinate of the origin of the text being drawn</param>
		/// <param name="paint">The paint used for the text (e.g. color, size, style)</param>
		public virtual void drawText(string text, float x, float y, android.graphics.Paint
			 paint)
		{
			native_drawText(mNativeCanvas, text, 0, text.Length, x, y, paint.mBidiFlags, paint
				.mNativePaint);
		}

		/// <summary>Draw the text, with origin at (x,y), using the specified paint.</summary>
		/// <remarks>
		/// Draw the text, with origin at (x,y), using the specified paint.
		/// The origin is interpreted based on the Align setting in the paint.
		/// </remarks>
		/// <param name="text">The text to be drawn</param>
		/// <param name="start">The index of the first character in text to draw</param>
		/// <param name="end">(end - 1) is the index of the last character in text to draw</param>
		/// <param name="x">The x-coordinate of the origin of the text being drawn</param>
		/// <param name="y">The y-coordinate of the origin of the text being drawn</param>
		/// <param name="paint">The paint used for the text (e.g. color, size, style)</param>
		public virtual void drawText(string text, int start, int end, float x, float y, android.graphics.Paint
			 paint)
		{
			if ((start | end | (end - start) | (text.Length - end)) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_drawText(mNativeCanvas, text, start, end, x, y, paint.mBidiFlags, paint.mNativePaint
				);
		}

		/// <summary>
		/// Draw the specified range of text, specified by start/end, with its
		/// origin at (x,y), in the specified Paint.
		/// </summary>
		/// <remarks>
		/// Draw the specified range of text, specified by start/end, with its
		/// origin at (x,y), in the specified Paint. The origin is interpreted
		/// based on the Align setting in the Paint.
		/// </remarks>
		/// <param name="text">The text to be drawn</param>
		/// <param name="start">The index of the first character in text to draw</param>
		/// <param name="end">
		/// (end - 1) is the index of the last character in text
		/// to draw
		/// </param>
		/// <param name="x">The x-coordinate of origin for where to draw the text</param>
		/// <param name="y">The y-coordinate of origin for where to draw the text</param>
		/// <param name="paint">The paint used for the text (e.g. color, size, style)</param>
		public virtual void drawText(java.lang.CharSequence text, int start, int end, float
			 x, float y, android.graphics.Paint paint)
		{
			if (java.lang.CharSequenceProxy.IsStringProxy(text) || text is android.text.SpannedString
				 || text is android.text.SpannableString)
			{
				native_drawText(mNativeCanvas, text.ToString(), start, end, x, y, paint.mBidiFlags
					, paint.mNativePaint);
			}
			else
			{
				if (text is android.text.GraphicsOperations)
				{
					((android.text.GraphicsOperations)text).drawText(this, start, end, x, y, paint);
				}
				else
				{
					char[] buf = android.graphics.TemporaryBuffer.obtain(end - start);
					android.text.TextUtils.getChars(text, start, end, buf, 0);
					native_drawText(mNativeCanvas, buf, 0, end - start, x, y, paint.mBidiFlags, paint
						.mNativePaint);
					android.graphics.TemporaryBuffer.recycle(buf);
				}
			}
		}

		/// <summary>Render a run of all LTR or all RTL text, with shaping.</summary>
		/// <remarks>
		/// Render a run of all LTR or all RTL text, with shaping. This does not run
		/// bidi on the provided text, but renders it as a uniform right-to-left or
		/// left-to-right run, as indicated by dir. Alignment of the text is as
		/// determined by the Paint's TextAlign value.
		/// </remarks>
		/// <param name="text">the text to render</param>
		/// <param name="index">the start of the text to render</param>
		/// <param name="count">the count of chars to render</param>
		/// <param name="contextIndex">
		/// the start of the context for shaping.  Must be
		/// no greater than index.
		/// </param>
		/// <param name="contextCount">
		/// the number of characters in the context for shaping.
		/// ContexIndex + contextCount must be no less than index
		/// + count.
		/// </param>
		/// <param name="x">the x position at which to draw the text</param>
		/// <param name="y">the y position at which to draw the text</param>
		/// <param name="dir">
		/// the run direction, either
		/// <see cref="DIRECTION_LTR">DIRECTION_LTR</see>
		/// or
		/// <see cref="DIRECTION_RTL">DIRECTION_RTL</see>
		/// .
		/// </param>
		/// <param name="paint">the paint</param>
		/// <hide></hide>
		public virtual void drawTextRun(char[] text, int index, int count, int contextIndex
			, int contextCount, float x, float y, int dir, android.graphics.Paint paint)
		{
			if (text == null)
			{
				throw new System.ArgumentNullException("text is null");
			}
			if (paint == null)
			{
				throw new System.ArgumentNullException("paint is null");
			}
			if ((index | count | text.Length - index - count) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (dir != DIRECTION_LTR && dir != DIRECTION_RTL)
			{
				throw new System.ArgumentException("unknown dir: " + dir);
			}
			native_drawTextRun(mNativeCanvas, text, index, count, contextIndex, contextCount, 
				x, y, dir, paint.mNativePaint);
		}

		/// <summary>Render a run of all LTR or all RTL text, with shaping.</summary>
		/// <remarks>
		/// Render a run of all LTR or all RTL text, with shaping. This does not run
		/// bidi on the provided text, but renders it as a uniform right-to-left or
		/// left-to-right run, as indicated by dir. Alignment of the text is as
		/// determined by the Paint's TextAlign value.
		/// </remarks>
		/// <param name="text">the text to render</param>
		/// <param name="start">
		/// the start of the text to render. Data before this position
		/// can be used for shaping context.
		/// </param>
		/// <param name="end">
		/// the end of the text to render. Data at or after this
		/// position can be used for shaping context.
		/// </param>
		/// <param name="x">the x position at which to draw the text</param>
		/// <param name="y">the y position at which to draw the text</param>
		/// <param name="dir">the run direction, either 0 for LTR or 1 for RTL.</param>
		/// <param name="paint">the paint</param>
		/// <hide></hide>
		public virtual void drawTextRun(java.lang.CharSequence text, int start, int end, 
			int contextStart, int contextEnd, float x, float y, int dir, android.graphics.Paint
			 paint)
		{
			if (text == null)
			{
				throw new System.ArgumentNullException("text is null");
			}
			if (paint == null)
			{
				throw new System.ArgumentNullException("paint is null");
			}
			if ((start | end | end - start | text.Length - end) < 0)
			{
				throw new System.IndexOutOfRangeException();
			}
			int flags = dir == 0 ? 0 : 1;
			if (java.lang.CharSequenceProxy.IsStringProxy(text) || text is android.text.SpannedString
				 || text is android.text.SpannableString)
			{
				native_drawTextRun(mNativeCanvas, text.ToString(), start, end, contextStart, contextEnd
					, x, y, flags, paint.mNativePaint);
			}
			else
			{
				if (text is android.text.GraphicsOperations)
				{
					((android.text.GraphicsOperations)text).drawTextRun(this, start, end, contextStart
						, contextEnd, x, y, flags, paint);
				}
				else
				{
					int contextLen = contextEnd - contextStart;
					int len = end - start;
					char[] buf = android.graphics.TemporaryBuffer.obtain(contextLen);
					android.text.TextUtils.getChars(text, contextStart, contextEnd, buf, 0);
					native_drawTextRun(mNativeCanvas, buf, start - contextStart, len, 0, contextLen, 
						x, y, flags, paint.mNativePaint);
					android.graphics.TemporaryBuffer.recycle(buf);
				}
			}
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"This requires frameworks/base/core/jni/android/graphics/TextLayout.cpp."
			)]
		public virtual void drawPosText(char[] text, int index, int count, float[] pos, android.graphics.Paint
			 paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"This requires frameworks/base/core/jni/android/graphics/TextLayout.cpp."
			)]
		public virtual void drawPosText(string text, float[] pos, android.graphics.Paint 
			paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"This requires frameworks/base/core/jni/android/graphics/TextLayout.cpp."
			)]
		public virtual void drawTextOnPath(char[] text, int index, int count, android.graphics.Path
			 path, float hOffset, float vOffset, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.Comment(@"This requires frameworks/base/core/jni/android/graphics/TextLayout.cpp."
			)]
		public virtual void drawTextOnPath(string text, android.graphics.Path path, float
			 hOffset, float vOffset, android.graphics.Paint paint)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Save the canvas state, draw the picture, and restore the canvas state.</summary>
		/// <remarks>
		/// Save the canvas state, draw the picture, and restore the canvas state.
		/// This differs from picture.draw(canvas), which does not perform any
		/// save/restore.
		/// </remarks>
		/// <param name="picture">The picture to be drawn</param>
		public virtual void drawPicture(android.graphics.Picture picture)
		{
			picture.endRecording();
			native_drawPicture(mNativeCanvas, picture.nativeInstance);
		}

		/// <summary>Draw the picture, stretched to fit into the dst rectangle.</summary>
		/// <remarks>Draw the picture, stretched to fit into the dst rectangle.</remarks>
		public virtual void drawPicture(android.graphics.Picture picture, android.graphics.RectF
			 dst)
		{
			save();
			translate(dst.left, dst.top);
			if (picture.getWidth() > 0 && picture.getHeight() > 0)
			{
				scale(dst.width() / picture.getWidth(), dst.height() / picture.getHeight());
			}
			drawPicture(picture);
			restore();
		}

		/// <summary>Draw the picture, stretched to fit into the dst rectangle.</summary>
		/// <remarks>Draw the picture, stretched to fit into the dst rectangle.</remarks>
		public virtual void drawPicture(android.graphics.Picture picture, android.graphics.Rect
			 dst)
		{
			save();
			translate(dst.left, dst.top);
			if (picture.getWidth() > 0 && picture.getHeight() > 0)
			{
				scale((float)dst.width() / picture.getWidth(), (float)dst.height() / picture.getHeight
					());
			}
			drawPicture(picture);
			restore();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_freeCaches();

		/// <summary>Free up as much memory as possible from private caches (e.g.</summary>
		/// <remarks>Free up as much memory as possible from private caches (e.g. fonts, images)
		/// 	</remarks>
		/// <hide></hide>
		public static void freeCaches()
		{
			libxobotos_Canvas_freeCaches();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Canvas.NativeCanvas libxobotos_Canvas_create
			(android.graphics.Bitmap.NativeBitmap nativeBitmapOrZero);

		private static android.graphics.Canvas.NativeCanvas initRaster(android.graphics.Bitmap.NativeBitmap
			 nativeBitmapOrZero)
		{
			return libxobotos_Canvas_create(nativeBitmapOrZero != null ? nativeBitmapOrZero : 
				android.graphics.Bitmap.NativeBitmap.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_setBitmap(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Bitmap.NativeBitmap bitmap);

		private static void native_setBitmap(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Bitmap.NativeBitmap bitmap)
		{
			libxobotos_Canvas_setBitmap(nativeCanvas, bitmap != null ? bitmap : android.graphics.Bitmap.NativeBitmap
				.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_saveLayer(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr bounds, android.graphics.Paint.NativePaint paint, int
			 layerFlags);

		private static int native_saveLayer(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF bounds, android.graphics.Paint.NativePaint paint, int layerFlags
			)
		{
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				bounds_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(bounds);
				return libxobotos_Canvas_saveLayer(nativeCanvas, bounds_ptr, paint != null ? paint
					 : android.graphics.Paint.NativePaint.Zero, layerFlags);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(bounds_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_saveLayerValues(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float l, float t, float r, float b, android.graphics.Paint.NativePaint
			 paint, int layerFlags);

		private static int native_saveLayer(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float l, float t, float r, float b, android.graphics.Paint.NativePaint paint, 
			int layerFlags)
		{
			return libxobotos_Canvas_saveLayerValues(nativeCanvas, l, t, r, b, paint != null ? 
				paint : android.graphics.Paint.NativePaint.Zero, layerFlags);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_saveLayerAlpha(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr bounds, int alpha, int layerFlags);

		private static int native_saveLayerAlpha(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF bounds, int alpha, int layerFlags)
		{
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				bounds_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(bounds);
				return libxobotos_Canvas_saveLayerAlpha(nativeCanvas, bounds_ptr, alpha, layerFlags
					);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(bounds_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Canvas_saveLayerAlphaValues(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float l, float t, float r, float b, int alpha, int layerFlags);

		private static int native_saveLayerAlpha(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float l, float t, float r, float b, int alpha, int layerFlags)
		{
			return libxobotos_Canvas_saveLayerAlphaValues(nativeCanvas, l, t, r, b, alpha, layerFlags
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_concat(android.graphics.Canvas.NativeCanvas
			 nCanvas, android.graphics.Matrix.NativeMatrix nMatrix);

		private static void native_concat(android.graphics.Canvas.NativeCanvas nCanvas, android.graphics.Matrix.NativeMatrix
			 nMatrix)
		{
			libxobotos_Canvas_concat(nCanvas, nMatrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_setMatrix(android.graphics.Canvas.NativeCanvas
			 nCanvas, android.graphics.Matrix.NativeMatrix nMatrix);

		private static void native_setMatrix(android.graphics.Canvas.NativeCanvas nCanvas
			, android.graphics.Matrix.NativeMatrix nMatrix)
		{
			libxobotos_Canvas_setMatrix(nCanvas, nMatrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipRectValues(android.graphics.Canvas.NativeCanvas
			 nCanvas, float left, float top, float right, float bottom, int regionOp);

		private static bool native_clipRect(android.graphics.Canvas.NativeCanvas nCanvas, 
			float left, float top, float right, float bottom, int regionOp)
		{
			return libxobotos_Canvas_clipRectValues(nCanvas, left, top, right, bottom, regionOp
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipPath(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Path.NativePath nativePath, int regionOp);

		private static bool native_clipPath(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Path.NativePath nativePath, int regionOp)
		{
			return libxobotos_Canvas_clipPath(nativeCanvas, nativePath, regionOp);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_clipRegion(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Region.NativeRegion nativeRegion, int regionOp);

		private static bool native_clipRegion(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Region.NativeRegion nativeRegion, int regionOp)
		{
			return libxobotos_Canvas_clipRegion(nativeCanvas, nativeRegion, regionOp);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_setDrawFilter(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.DrawFilter.NativeDrawFilter nativeFilter);

		private static void nativeSetDrawFilter(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.DrawFilter.NativeDrawFilter nativeFilter)
		{
			libxobotos_Canvas_setDrawFilter(nativeCanvas, nativeFilter != null ? nativeFilter
				 : android.graphics.DrawFilter.NativeDrawFilter.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_getClipBoundsIRect(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr bounds);

		private static bool native_getClipBounds(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Rect bounds)
		{
			System.IntPtr bounds_ptr = System.IntPtr.Zero;
			try
			{
				bounds_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(bounds);
				bool _retval = libxobotos_Canvas_getClipBoundsIRect(nativeCanvas, bounds_ptr);
				android.graphics.Rect.Rect_Helper.MarshalOut(bounds_ptr, bounds);
				return _retval;
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(bounds_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_getCTM(android.graphics.Canvas.NativeCanvas
			 canvas, android.graphics.Matrix.NativeMatrix matrix);

		private static void native_getCTM(android.graphics.Canvas.NativeCanvas canvas, android.graphics.Matrix.NativeMatrix
			 matrix)
		{
			libxobotos_Canvas_getCTM(canvas, matrix);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_quickReject(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr rect, int native_edgeType);

		private static bool native_quickReject(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF rect, int native_edgeType)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				return libxobotos_Canvas_quickReject(nativeCanvas, rect_ptr, native_edgeType);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_quickReject_0(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Path.NativePath path, int native_edgeType);

		private static bool native_quickReject(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Path.NativePath path, int native_edgeType)
		{
			return libxobotos_Canvas_quickReject_0(nativeCanvas, path, native_edgeType);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_Canvas_quickReject_1(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float left, float top, float right, float bottom, int native_edgeType
			);

		private static bool native_quickReject(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float left, float top, float right, float bottom, int native_edgeType)
		{
			return libxobotos_Canvas_quickReject_1(nativeCanvas, left, top, right, bottom, native_edgeType
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawRGB(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, int r, int g, int b);

		private static void native_drawRGB(android.graphics.Canvas.NativeCanvas nativeCanvas
			, int r, int g, int b)
		{
			libxobotos_Canvas_drawRGB(nativeCanvas, r, g, b);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawARGB(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, int a, int r, int g, int b);

		private static void native_drawARGB(android.graphics.Canvas.NativeCanvas nativeCanvas
			, int a, int r, int g, int b)
		{
			libxobotos_Canvas_drawARGB(nativeCanvas, a, r, g, b);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawColor(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, int color);

		private static void native_drawColor(android.graphics.Canvas.NativeCanvas nativeCanvas
			, int color)
		{
			libxobotos_Canvas_drawColor(nativeCanvas, color);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawColor_0(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, int color, int mode);

		private static void native_drawColor(android.graphics.Canvas.NativeCanvas nativeCanvas
			, int color, int mode)
		{
			libxobotos_Canvas_drawColor_0(nativeCanvas, color, mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawPaint(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Paint.NativePaint paint);

		private static void native_drawPaint(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Paint.NativePaint paint)
		{
			libxobotos_Canvas_drawPaint(nativeCanvas, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawLine(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float startX, float startY, float stopX, float stopY, android.graphics.Paint.NativePaint
			 paint);

		private static void native_drawLine(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float startX, float startY, float stopX, float stopY, android.graphics.Paint.NativePaint
			 paint)
		{
			libxobotos_Canvas_drawLine(nativeCanvas, startX, startY, stopX, stopY, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawRect(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr rect, android.graphics.Paint.NativePaint paint);

		private static void native_drawRect(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF rect, android.graphics.Paint.NativePaint paint)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				libxobotos_Canvas_drawRect(nativeCanvas, rect_ptr, paint);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawRect_0(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float left, float top, float right, float bottom, android.graphics.Paint.NativePaint
			 paint);

		private static void native_drawRect(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float left, float top, float right, float bottom, android.graphics.Paint.NativePaint
			 paint)
		{
			libxobotos_Canvas_drawRect_0(nativeCanvas, left, top, right, bottom, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawOval(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr oval, android.graphics.Paint.NativePaint paint);

		private static void native_drawOval(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF oval, android.graphics.Paint.NativePaint paint)
		{
			System.IntPtr oval_ptr = System.IntPtr.Zero;
			try
			{
				oval_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(oval);
				libxobotos_Canvas_drawOval(nativeCanvas, oval_ptr, paint);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(oval_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawCircle(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, float cx, float cy, float radius, android.graphics.Paint.NativePaint
			 paint);

		private static void native_drawCircle(android.graphics.Canvas.NativeCanvas nativeCanvas
			, float cx, float cy, float radius, android.graphics.Paint.NativePaint paint)
		{
			libxobotos_Canvas_drawCircle(nativeCanvas, cx, cy, radius, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawArc(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr oval, float startAngle, float sweep, bool useCenter
			, android.graphics.Paint.NativePaint paint);

		private static void native_drawArc(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF oval, float startAngle, float sweep, bool useCenter, android.graphics.Paint.NativePaint
			 paint)
		{
			System.IntPtr oval_ptr = System.IntPtr.Zero;
			try
			{
				oval_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(oval);
				libxobotos_Canvas_drawArc(nativeCanvas, oval_ptr, startAngle, sweep, useCenter, paint
					);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(oval_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawRoundRect(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr rect, float rx, float ry, android.graphics.Paint.NativePaint
			 paint);

		private static void native_drawRoundRect(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.RectF rect, float rx, float ry, android.graphics.Paint.NativePaint
			 paint)
		{
			System.IntPtr rect_ptr = System.IntPtr.Zero;
			try
			{
				rect_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(rect);
				libxobotos_Canvas_drawRoundRect(nativeCanvas, rect_ptr, rx, ry, paint);
			}
			finally
			{
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(rect_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawPath(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Path.NativePath path, android.graphics.Paint.NativePaint
			 paint);

		private static void native_drawPath(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Path.NativePath path, android.graphics.Paint.NativePaint paint
			)
		{
			libxobotos_Canvas_drawPath(nativeCanvas, path, paint);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawBitmap(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Bitmap.NativeBitmap bitmap, float left, float top
			, android.graphics.Paint.NativePaint nativePaintOrZero, int canvasDensity, int screenDensity
			, int bitmapDensity);

		private void native_drawBitmap(android.graphics.Canvas.NativeCanvas nativeCanvas, 
			android.graphics.Bitmap.NativeBitmap bitmap, float left, float top, android.graphics.Paint.NativePaint
			 nativePaintOrZero, int canvasDensity, int screenDensity, int bitmapDensity)
		{
			libxobotos_Canvas_drawBitmap(nativeCanvas, bitmap, left, top, nativePaintOrZero !=
				 null ? nativePaintOrZero : android.graphics.Paint.NativePaint.Zero, canvasDensity
				, screenDensity, bitmapDensity);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawBitmapRectF(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Bitmap.NativeBitmap bitmap, System.IntPtr src, System.IntPtr
			 dst, android.graphics.Paint.NativePaint nativePaintOrZero, int screenDensity, int
			 bitmapDensity);

		private void native_drawBitmap(android.graphics.Canvas.NativeCanvas nativeCanvas, 
			android.graphics.Bitmap.NativeBitmap bitmap, android.graphics.Rect src, android.graphics.RectF
			 dst, android.graphics.Paint.NativePaint nativePaintOrZero, int screenDensity, int
			 bitmapDensity)
		{
			System.IntPtr src_ptr = System.IntPtr.Zero;
			System.IntPtr dst_ptr = System.IntPtr.Zero;
			try
			{
				src_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(src);
				dst_ptr = android.graphics.RectF.RectF_Helper.ManagedToNative(dst);
				libxobotos_Canvas_drawBitmapRectF(nativeCanvas, bitmap, src_ptr, dst_ptr, nativePaintOrZero
					 != null ? nativePaintOrZero : android.graphics.Paint.NativePaint.Zero, screenDensity
					, bitmapDensity);
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(src_ptr);
				android.graphics.RectF.RectF_Helper.FreeManagedPtr(dst_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawBitmapRect(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Bitmap.NativeBitmap bitmap, System.IntPtr src, System.IntPtr
			 dst, android.graphics.Paint.NativePaint nativePaintOrZero, int screenDensity, int
			 bitmapDensity);

		private static void native_drawBitmap(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Bitmap.NativeBitmap bitmap, android.graphics.Rect src, android.graphics.Rect
			 dst, android.graphics.Paint.NativePaint nativePaintOrZero, int screenDensity, int
			 bitmapDensity)
		{
			System.IntPtr src_ptr = System.IntPtr.Zero;
			System.IntPtr dst_ptr = System.IntPtr.Zero;
			try
			{
				src_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(src);
				dst_ptr = android.graphics.Rect.Rect_Helper.ManagedToNative(dst);
				libxobotos_Canvas_drawBitmapRect(nativeCanvas, bitmap, src_ptr, dst_ptr, nativePaintOrZero
					 != null ? nativePaintOrZero : android.graphics.Paint.NativePaint.Zero, screenDensity
					, bitmapDensity);
			}
			finally
			{
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(src_ptr);
				android.graphics.Rect.Rect_Helper.FreeManagedPtr(dst_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawBitmapColors(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr colors, int offset, int stride, float x, float y, int
			 width, int height, bool hasAlpha, android.graphics.Paint.NativePaint nativePaintOrZero
			);

		private static void native_drawBitmap(android.graphics.Canvas.NativeCanvas nativeCanvas
			, int[] colors, int offset, int stride, float x, float y, int width, int height, 
			bool hasAlpha, android.graphics.Paint.NativePaint nativePaintOrZero)
		{
			Sharpen.INativeHandle colors_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				libxobotos_Canvas_drawBitmapColors(nativeCanvas, colors_handle.Address, offset, stride
					, x, y, width, height, hasAlpha, nativePaintOrZero != null ? nativePaintOrZero : 
					android.graphics.Paint.NativePaint.Zero);
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
		private static extern void libxobotos_Canvas_drawBitmapMatrix(android.graphics.Canvas.NativeCanvas
			 nCanvas, android.graphics.Bitmap.NativeBitmap nBitmap, android.graphics.Matrix.NativeMatrix
			 nMatrix, android.graphics.Paint.NativePaint nPaint);

		private static void nativeDrawBitmapMatrix(android.graphics.Canvas.NativeCanvas nCanvas
			, android.graphics.Bitmap.NativeBitmap nBitmap, android.graphics.Matrix.NativeMatrix
			 nMatrix, android.graphics.Paint.NativePaint nPaint)
		{
			libxobotos_Canvas_drawBitmapMatrix(nCanvas, nBitmap, nMatrix, nPaint != null ? nPaint
				 : android.graphics.Paint.NativePaint.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawBitmapMesh(android.graphics.Canvas.NativeCanvas
			 nCanvas, android.graphics.Bitmap.NativeBitmap nBitmap, int meshWidth, int meshHeight
			, System.IntPtr verts, int vertOffset, System.IntPtr colors, int colorOffset, android.graphics.Paint.NativePaint
			 nPaint);

		private static void nativeDrawBitmapMesh(android.graphics.Canvas.NativeCanvas nCanvas
			, android.graphics.Bitmap.NativeBitmap nBitmap, int meshWidth, int meshHeight, float
			[] verts, int vertOffset, int[] colors, int colorOffset, android.graphics.Paint.NativePaint
			 nPaint)
		{
			Sharpen.INativeHandle verts_handle = null;
			Sharpen.INativeHandle colors_handle = null;
			try
			{
				verts_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(verts);
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				libxobotos_Canvas_drawBitmapMesh(nCanvas, nBitmap, meshWidth, meshHeight, verts_handle
					.Address, vertOffset, colors_handle != null ? colors_handle.Address : System.IntPtr.Zero
					, colorOffset, nPaint != null ? nPaint : android.graphics.Paint.NativePaint.Zero
					);
			}
			finally
			{
				if (verts_handle != null)
				{
					verts_handle.Free();
				}
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawVertices(android.graphics.Canvas.NativeCanvas
			 nCanvas, int mode, int n, System.IntPtr verts, int vertOffset, System.IntPtr texs
			, int texOffset, System.IntPtr colors, int colorOffset, System.IntPtr indices, int
			 indexOffset, int indexCount, android.graphics.Paint.NativePaint nPaint);

		private static void nativeDrawVertices(android.graphics.Canvas.NativeCanvas nCanvas
			, int mode, int n, float[] verts, int vertOffset, float[] texs, int texOffset, int
			[] colors, int colorOffset, short[] indices, int indexOffset, int indexCount, android.graphics.Paint.NativePaint
			 nPaint)
		{
			Sharpen.INativeHandle verts_handle = null;
			Sharpen.INativeHandle texs_handle = null;
			Sharpen.INativeHandle colors_handle = null;
			System.IntPtr indices_ptr = System.IntPtr.Zero;
			try
			{
				verts_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(verts);
				texs_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(texs);
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				indices_ptr = Array_short_Helper.ManagedToNative(indices);
				libxobotos_Canvas_drawVertices(nCanvas, mode, n, verts_handle.Address, vertOffset
					, texs_handle != null ? texs_handle.Address : System.IntPtr.Zero, texOffset, colors_handle
					 != null ? colors_handle.Address : System.IntPtr.Zero, colorOffset, indices_ptr, 
					indexOffset, indexCount, nPaint);
			}
			finally
			{
				if (verts_handle != null)
				{
					verts_handle.Free();
				}
				if (texs_handle != null)
				{
					texs_handle.Free();
				}
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
				Array_short_Helper.FreeManagedPtr(indices_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawTextC(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr text, int index, int count, float x, float y, int flags
			, android.graphics.Paint.NativePaint paint);

		private static void native_drawText(android.graphics.Canvas.NativeCanvas nativeCanvas
			, char[] text, int index, int count, float x, float y, int flags, android.graphics.Paint.NativePaint
			 paint)
		{
			Sharpen.INativeHandle text_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				libxobotos_Canvas_drawTextC(nativeCanvas, text_handle.Address, index, count, x, y
					, flags, paint);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawTextS(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr text, int start, int end, float x, float y, int flags
			, android.graphics.Paint.NativePaint paint);

		private static void native_drawText(android.graphics.Canvas.NativeCanvas nativeCanvas
			, string text, int start, int end, float x, float y, int flags, android.graphics.Paint.NativePaint
			 paint)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				libxobotos_Canvas_drawTextS(nativeCanvas, text_ptr, start, end, x, y, flags, paint
					);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawTextRunS(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr text, int start, int end, int contextStart, int contextEnd
			, float x, float y, int flags, android.graphics.Paint.NativePaint paint);

		private static void native_drawTextRun(android.graphics.Canvas.NativeCanvas nativeCanvas
			, string text, int start, int end, int contextStart, int contextEnd, float x, float
			 y, int flags, android.graphics.Paint.NativePaint paint)
		{
			System.IntPtr text_ptr = System.IntPtr.Zero;
			try
			{
				text_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(text);
				libxobotos_Canvas_drawTextRunS(nativeCanvas, text_ptr, start, end, contextStart, 
					contextEnd, x, y, flags, paint);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(text_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawTextRunC(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, System.IntPtr text, int start, int count, int contextStart, int contextCount
			, float x, float y, int flags, android.graphics.Paint.NativePaint paint);

		private static void native_drawTextRun(android.graphics.Canvas.NativeCanvas nativeCanvas
			, char[] text, int start, int count, int contextStart, int contextCount, float x
			, float y, int flags, android.graphics.Paint.NativePaint paint)
		{
			Sharpen.INativeHandle text_handle = null;
			try
			{
				text_handle = XobotOS.Runtime.MarshalGlue.Array_char_Helper.GetPinnedPtr(text);
				libxobotos_Canvas_drawTextRunC(nativeCanvas, text_handle.Address, start, count, contextStart
					, contextCount, x, y, flags, paint);
			}
			finally
			{
				if (text_handle != null)
				{
					text_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Canvas_drawPicture(android.graphics.Canvas.NativeCanvas
			 nativeCanvas, android.graphics.Picture.NativePicture nativePicture);

		private static void native_drawPicture(android.graphics.Canvas.NativeCanvas nativeCanvas
			, android.graphics.Picture.NativePicture nativePicture)
		{
			libxobotos_Canvas_drawPicture(nativeCanvas, nativePicture);
		}

		private static void finalizer(android.graphics.Canvas.NativeCanvas nativeCanvas)
		{
			nativeCanvas.Dispose();
		}

		[Sharpen.MarshalHelper(@"NativeArray<short>")]
		internal static class Array_short_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_short_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_short_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, short[] arg)
			{
				Array_short_Struct obj = new Array_short_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_short_Helper.NativeSize;
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < arg.Length; i++, addr += Marshal.SizeOf(typeof(short)))
					{
						Marshal.StructureToPtr(arg[i], addr, false);
					}
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, short[] arg)
			{
				Array_short_Struct obj = (Array_short_Struct)Marshal.PtrToStructure(ptr, typeof(Array_short_Struct
					));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += Marshal.SizeOf(typeof(short)))
					{
						arg[i] = (short)Marshal.PtrToStructure(addr, typeof(short));
					}
				}
			}

			public static System.IntPtr ManagedToNative(short[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_short_Helper.NativeSize + Marshal.SizeOf
					(typeof(short)) * arg.Length);
				Array_short_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static short[] NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_short_Struct obj = (Array_short_Struct)Marshal.PtrToStructure(ptr, typeof(Array_short_Struct
					));
				short[] arg = new short[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += Marshal.SizeOf(typeof(short)))
					{
						arg[i] = (short)Marshal.PtrToStructure(addr, typeof(short));
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_graphics_Canvas_Array_short_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Canvas_Array_short_destructor
				(System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_short_Struct obj = (Array_short_Struct)Marshal.PtrToStructure(ptr, typeof(Array_short_Struct
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
				Array_short_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		internal NativeCanvas nativeInstance
		{
			get
			{
				return mNativeCanvas;
			}
		}

		public void Dispose()
		{
			mNativeCanvas.Dispose();
		}

		internal class NativeCanvas : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeCanvas() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeCanvas(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Canvas_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeCanvas Zero = new NativeCanvas();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Canvas_destructor(handle);
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
