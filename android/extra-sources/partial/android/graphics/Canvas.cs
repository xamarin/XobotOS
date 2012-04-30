using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

namespace android.graphics
{
	partial class Canvas
	{
		internal Canvas(IntPtr native)
			: this (new NativeCanvas(native))
		{ }

		internal Canvas(NativeCanvas native)
		{
			mNativeCanvas = native;
			mDensity = android.util.DisplayMetrics.DENSITY_DEFAULT;
		}

		/// <summary>Construct an empty raster canvas.</summary>
		/// <remarks>
		/// Construct an empty raster canvas. Use setBitmap() to specify a bitmap to
		/// draw into.  The initial target density is
		/// <see cref="Bitmap.DENSITY_NONE">Bitmap.DENSITY_NONE</see>
		/// ;
		/// this will typically be replaced when a target bitmap is set for the
		/// canvas.
		/// </remarks>
		public Canvas()
		{
			// 0 means no native bitmap
			mNativeCanvas = initRaster(null);
		}

		/// <summary>Construct a canvas with the specified bitmap to draw into.</summary>
		/// <remarks>
		/// Construct a canvas with the specified bitmap to draw into. The bitmap
		/// must be mutable.
		/// <p>The initial target density of the canvas is the same as the given
		/// bitmap's density.
		/// </remarks>
		/// <param name="bitmap">Specifies a mutable bitmap for the canvas to draw into.</param>
		public Canvas(android.graphics.Bitmap bitmap)
		{
			if (!bitmap.isMutable())
			{
				throw new System.InvalidOperationException("Immutable bitmap passed to Canvas constructor"
					);
			}
			throwIfRecycled(bitmap);
			mNativeCanvas = initRaster(bitmap.nativeInstance);
			mBitmap = bitmap;
			mDensity = bitmap.mDensity;
		}
	}
}
