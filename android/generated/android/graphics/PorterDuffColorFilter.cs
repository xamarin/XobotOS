using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PorterDuffColorFilter : android.graphics.ColorFilter
	{
		/// <summary>Create a colorfilter that uses the specified color and porter-duff mode.
		/// 	</summary>
		/// <remarks>Create a colorfilter that uses the specified color and porter-duff mode.
		/// 	</remarks>
		/// <param name="srcColor">
		/// The source color used with the specified
		/// porter-duff mode
		/// </param>
		/// <param name="mode">The porter-duff mode that is applied</param>
		public PorterDuffColorFilter(int srcColor, android.graphics.PorterDuff.Mode mode)
		{
			native_instance = native_CreatePorterDuffFilter(srcColor, (int)mode);
			nativeColorFilter = nCreatePorterDuffFilter(native_instance, srcColor, (int)mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.ColorFilter.NativeFilter libxobotos_PorterDuffColorFilter_PorterDuffFilter_create
			(int srcColor, int porterDuffMode);

		private static android.graphics.ColorFilter.NativeFilter native_CreatePorterDuffFilter
			(int srcColor, int porterDuffMode)
		{
			return libxobotos_PorterDuffColorFilter_PorterDuffFilter_create(srcColor, porterDuffMode
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_PorterDuffColorFilter_PorterDuffFilter_postCreate
			(android.graphics.ColorFilter.NativeFilter nativeFilter, int srcColor, int porterDuffMode
			);

		private static System.IntPtr nCreatePorterDuffFilter(android.graphics.ColorFilter.NativeFilter
			 nativeFilter, int srcColor, int porterDuffMode)
		{
			return libxobotos_PorterDuffColorFilter_PorterDuffFilter_postCreate(nativeFilter, 
				srcColor, porterDuffMode);
		}
	}
}
