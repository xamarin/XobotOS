using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class ColorMatrixColorFilter : android.graphics.ColorFilter
	{
		/// <summary>Create a colorfilter that transforms colors through a 4x5 color matrix.</summary>
		/// <remarks>Create a colorfilter that transforms colors through a 4x5 color matrix.</remarks>
		/// <param name="matrix">
		/// 4x5 matrix used to transform colors. It is copied into
		/// the filter, so changes made to the matrix after the filter
		/// is constructed will not be reflected in the filter.
		/// </param>
		public ColorMatrixColorFilter(android.graphics.ColorMatrix matrix)
		{
			float[] colorMatrix = matrix.getArray();
			native_instance = nativeColorMatrixFilter(colorMatrix);
			nativeColorFilter = nColorMatrixFilter(native_instance, colorMatrix);
		}

		/// <summary>Create a colorfilter that transforms colors through a 4x5 color matrix.</summary>
		/// <remarks>Create a colorfilter that transforms colors through a 4x5 color matrix.</remarks>
		/// <param name="array">
		/// array of floats used to transform colors, treated as a 4x5
		/// matrix. The first 20 entries of the array are copied into
		/// the filter. See ColorMatrix.
		/// </param>
		public ColorMatrixColorFilter(float[] array)
		{
			if (array.Length < 20)
			{
				throw new System.IndexOutOfRangeException();
			}
			native_instance = nativeColorMatrixFilter(array);
			nativeColorFilter = nColorMatrixFilter(native_instance, array);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.ColorFilter.NativeFilter libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_create
			(System.IntPtr array);

		private static android.graphics.ColorFilter.NativeFilter nativeColorMatrixFilter(
			float[] array)
		{
			Sharpen.INativeHandle array_handle = null;
			try
			{
				array_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(array);
				return libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_create(array_handle.Address
					);
			}
			finally
			{
				if (array_handle != null)
				{
					array_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_postCreate
			(android.graphics.ColorFilter.NativeFilter nativeFilter, System.IntPtr array);

		private static System.IntPtr nColorMatrixFilter(android.graphics.ColorFilter.NativeFilter
			 nativeFilter, float[] array)
		{
			Sharpen.INativeHandle array_handle = null;
			try
			{
				array_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(array);
				return libxobotos_ColorMatrixColorFilter_ColorMatrixFilter_postCreate(nativeFilter
					, array_handle.Address);
			}
			finally
			{
				if (array_handle != null)
				{
					array_handle.Free();
				}
			}
		}
	}
}
