using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class LightingColorFilter : android.graphics.ColorFilter
	{
		/// <summary>
		/// Create a colorfilter that multiplies the RGB channels by one color, and then adds a second color,
		/// pinning the result for each component to [0..255].
		/// </summary>
		/// <remarks>
		/// Create a colorfilter that multiplies the RGB channels by one color, and then adds a second color,
		/// pinning the result for each component to [0..255]. The alpha components of the mul and add arguments
		/// are ignored.
		/// </remarks>
		public LightingColorFilter(int mul, int add)
		{
			// This file was generated from the C++ include file: SkColorFilter.h
			// Any changes made to this file will be discarded by the build.
			// To change this file, either edit the include, or device/tools/gluemaker/main.cpp, 
			// or one of the auxilary file specifications in device/tools/gluemaker.
			native_instance = native_CreateLightingFilter(mul, add);
			nativeColorFilter = nCreateLightingFilter(native_instance, mul, add);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.ColorFilter.NativeFilter libxobotos_LightingColorFilter_LightingFilter_create
			(int mul, int add);

		private static android.graphics.ColorFilter.NativeFilter native_CreateLightingFilter
			(int mul, int add)
		{
			return libxobotos_LightingColorFilter_LightingFilter_create(mul, add);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_LightingColorFilter_LightingFilter_postCreate
			(android.graphics.ColorFilter.NativeFilter nativeFilter, int mul, int add);

		private static System.IntPtr nCreateLightingFilter(android.graphics.ColorFilter.NativeFilter
			 nativeFilter, int mul, int add)
		{
			return libxobotos_LightingColorFilter_LightingFilter_postCreate(nativeFilter, mul
				, add);
		}
	}
}
