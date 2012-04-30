using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PathDashPathEffect : android.graphics.PathEffect
	{
		public enum Style : int
		{
			TRANSLATE = 0,
			ROTATE = 1,
			MORPH = 2
		}

		/// <summary>Dash the drawn path by stamping it with the specified shape.</summary>
		/// <remarks>
		/// Dash the drawn path by stamping it with the specified shape. This only
		/// applies to drawings when the paint's style is STROKE or STROKE_AND_FILL.
		/// If the paint's style is FILL, then this effect is ignored. The paint's
		/// strokeWidth does not affect the results.
		/// </remarks>
		/// <param name="shape">The path to stamp along</param>
		/// <param name="advance">spacing between each stamp of shape</param>
		/// <param name="phase">amount to offset before the first shape is stamped</param>
		/// <param name="style">how to transform the shape at each position as it is stamped</param>
		public PathDashPathEffect(android.graphics.Path shape, float advance, float phase
			, android.graphics.PathDashPathEffect.Style style)
		{
			//!< translate the shape to each position
			//!< rotate the shape about its center
			//!< transform each point, and turn lines into curves
			native_instance = nativeCreate(shape.nativeInstance, advance, phase, (int)style);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.PathDashPathEffect.NativePathEffect libxobotos_PathDashPathEffect_create
			(android.graphics.Path.NativePath native_path, float advance, float phase, int native_style
			);

		private static android.graphics.PathDashPathEffect.NativePathEffect nativeCreate(
			android.graphics.Path.NativePath native_path, float advance, float phase, int native_style
			)
		{
			return libxobotos_PathDashPathEffect_create(native_path, advance, phase, native_style
				);
		}

		internal class NativePathEffect : android.graphics.PathEffect.NativePathEffect
		{
			internal NativePathEffect()
			{
			}

			internal NativePathEffect(System.IntPtr handle)
			{
				this.handle = handle;
			}
		}
	}
}
