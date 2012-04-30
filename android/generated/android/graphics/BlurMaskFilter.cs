using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>This takes a mask, and blurs its edge by the specified radius.</summary>
	/// <remarks>
	/// This takes a mask, and blurs its edge by the specified radius. Whether or
	/// or not to include the original mask, and whether the blur goes outside,
	/// inside, or straddles, the original mask's border, is controlled by the
	/// Blur enum.
	/// </remarks>
	[Sharpen.Sharpened]
	public class BlurMaskFilter : android.graphics.MaskFilter
	{
		public enum Blur : int
		{
			NORMAL = 0,
			SOLID = 1,
			OUTER = 2,
			INNER = 3
		}

		/// <summary>Create a blur maskfilter.</summary>
		/// <remarks>Create a blur maskfilter.</remarks>
		/// <param name="radius">The radius to extend the blur from the original mask. Must be &gt; 0.
		/// 	</param>
		/// <param name="style">The Blur to use</param>
		/// <returns>The new blur maskfilter</returns>
		public BlurMaskFilter(float radius, android.graphics.BlurMaskFilter.Blur style)
		{
			//!< blur inside and outside of the original border
			//!< include the original mask, blur outside
			//!< just blur outside the original border
			//!< just blur inside the original border
			native_instance = nativeConstructor(radius, (int)style);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.MaskFilter.NativeFilter libxobotos_BlurMaskFilter_constructor
			(float radius, int style);

		private static android.graphics.MaskFilter.NativeFilter nativeConstructor(float radius
			, int style)
		{
			return libxobotos_BlurMaskFilter_constructor(radius, style);
		}
	}
}
