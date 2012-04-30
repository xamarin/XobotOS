using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class SweepGradient : android.graphics.Shader
	{
		/// <summary>A subclass of Shader that draws a sweep gradient around a center point.</summary>
		/// <remarks>A subclass of Shader that draws a sweep gradient around a center point.</remarks>
		/// <param name="cx">The x-coordinate of the center</param>
		/// <param name="cy">The y-coordinate of the center</param>
		/// <param name="colors">
		/// The colors to be distributed between around the center.
		/// There must be at least 2 colors in the array.
		/// </param>
		/// <param name="positions">
		/// May be NULL. The relative position of
		/// each corresponding color in the colors array, beginning
		/// with 0 and ending with 1.0. If the values are not
		/// monotonic, the drawing may produce unexpected results.
		/// If positions is NULL, then the colors are automatically
		/// spaced evenly.
		/// </param>
		public SweepGradient(float cx, float cy, int[] colors, float[] positions)
		{
			if (colors.Length < 2)
			{
				throw new System.ArgumentException("needs >= 2 number of colors");
			}
			if (positions != null && colors.Length != positions.Length)
			{
				throw new System.ArgumentException("color and position arrays must be of equal length"
					);
			}
			native_instance = nativeCreate1(cx, cy, colors, positions);
			native_shader = nativePostCreate1(native_instance, cx, cy, colors, positions);
		}

		/// <summary>A subclass of Shader that draws a sweep gradient around a center point.</summary>
		/// <remarks>A subclass of Shader that draws a sweep gradient around a center point.</remarks>
		/// <param name="cx">The x-coordinate of the center</param>
		/// <param name="cy">The y-coordinate of the center</param>
		/// <param name="color0">The color to use at the start of the sweep</param>
		/// <param name="color1">The color to use at the end of the sweep</param>
		public SweepGradient(float cx, float cy, int color0, int color1)
		{
			native_instance = nativeCreate2(cx, cy, color0, color1);
			native_shader = nativePostCreate2(native_instance, cx, cy, color0, color1);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_SweepGradient_SweepGradient_create
			(float x, float y, System.IntPtr colors, System.IntPtr positions);

		private static android.graphics.Shader.NativeShader nativeCreate1(float x, float 
			y, int[] colors, float[] positions)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_SweepGradient_SweepGradient_create(x, y, colors_handle.Address, 
					positions_handle != null ? positions_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
				if (positions_handle != null)
				{
					positions_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_SweepGradient_SweepGradient_create_0
			(float x, float y, int color0, int color1);

		private static android.graphics.Shader.NativeShader nativeCreate2(float x, float 
			y, int color0, int color1)
		{
			return libxobotos_SweepGradient_SweepGradient_create_0(x, y, color0, color1);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_SweepGradient_SweepGradient_postCreate
			(android.graphics.Shader.NativeShader native_shader, float cx, float cy, System.IntPtr
			 colors, System.IntPtr positions);

		private static System.IntPtr nativePostCreate1(android.graphics.Shader.NativeShader
			 native_shader, float cx, float cy, int[] colors, float[] positions)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_SweepGradient_SweepGradient_postCreate(native_shader, cx, cy, colors_handle
					.Address, positions_handle != null ? positions_handle.Address : System.IntPtr.Zero
					);
			}
			finally
			{
				if (colors_handle != null)
				{
					colors_handle.Free();
				}
				if (positions_handle != null)
				{
					positions_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_SweepGradient_SweepGradient_postCreate_0
			(android.graphics.Shader.NativeShader native_shader, float cx, float cy, int color0
			, int color1);

		private static System.IntPtr nativePostCreate2(android.graphics.Shader.NativeShader
			 native_shader, float cx, float cy, int color0, int color1)
		{
			return libxobotos_SweepGradient_SweepGradient_postCreate_0(native_shader, cx, cy, 
				color0, color1);
		}
	}
}
