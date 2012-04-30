using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class LinearGradient : android.graphics.Shader
	{
		/// <summary>Create a shader that draws a linear gradient along a line.</summary>
		/// <remarks>Create a shader that draws a linear gradient along a line.</remarks>
		/// <param name="x0">The x-coordinate for the start of the gradient line</param>
		/// <param name="y0">The y-coordinate for the start of the gradient line</param>
		/// <param name="x1">The x-coordinate for the end of the gradient line</param>
		/// <param name="y1">The y-coordinate for the end of the gradient line</param>
		/// <param name="colors">The colors to be distributed along the gradient line</param>
		/// <param name="positions">
		/// May be null. The relative positions [0..1] of
		/// each corresponding color in the colors array. If this is null,
		/// the the colors are distributed evenly along the gradient line.
		/// </param>
		/// <param name="tile">The Shader tiling mode</param>
		public LinearGradient(float x0, float y0, float x1, float y1, int[] colors, float
			[] positions, android.graphics.Shader.TileMode? tile)
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
			native_instance = nativeCreate1(x0, y0, x1, y1, colors, positions, (int)tile);
			native_shader = nativePostCreate1(native_instance, x0, y0, x1, y1, colors, positions
				, (int)tile);
		}

		/// <summary>Create a shader that draws a linear gradient along a line.</summary>
		/// <remarks>Create a shader that draws a linear gradient along a line.</remarks>
		/// <param name="x0">The x-coordinate for the start of the gradient line</param>
		/// <param name="y0">The y-coordinate for the start of the gradient line</param>
		/// <param name="x1">The x-coordinate for the end of the gradient line</param>
		/// <param name="y1">The y-coordinate for the end of the gradient line</param>
		/// <param name="color0">The color at the start of the gradient line.</param>
		/// <param name="color1">The color at the end of the gradient line.</param>
		/// <param name="tile">The Shader tiling mode</param>
		public LinearGradient(float x0, float y0, float x1, float y1, int color0, int color1
			, android.graphics.Shader.TileMode? tile)
		{
			native_instance = nativeCreate2(x0, y0, x1, y1, color0, color1, (int)tile);
			native_shader = nativePostCreate2(native_instance, x0, y0, x1, y1, color0, color1
				, (int)tile);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_LinearGradient_LinearGradient_create
			(float x0, float y0, float x1, float y1, System.IntPtr colors, System.IntPtr positions
			, int tileMode);

		private android.graphics.Shader.NativeShader nativeCreate1(float x0, float y0, float
			 x1, float y1, int[] colors, float[] positions, int tileMode)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_LinearGradient_LinearGradient_create(x0, y0, x1, y1, colors_handle
					.Address, positions_handle != null ? positions_handle.Address : System.IntPtr.Zero
					, tileMode);
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
		private static extern android.graphics.Shader.NativeShader libxobotos_LinearGradient_LinearGradient_create_0
			(float x0, float y0, float x1, float y1, int color0, int color1, int tileMode);

		private android.graphics.Shader.NativeShader nativeCreate2(float x0, float y0, float
			 x1, float y1, int color0, int color1, int tileMode)
		{
			return libxobotos_LinearGradient_LinearGradient_create_0(x0, y0, x1, y1, color0, 
				color1, tileMode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_LinearGradient_LinearGradient_postCreate
			(android.graphics.Shader.NativeShader native_shader, float x0, float y0, float x1
			, float y1, System.IntPtr colors, System.IntPtr positions, int tileMode);

		private System.IntPtr nativePostCreate1(android.graphics.Shader.NativeShader native_shader
			, float x0, float y0, float x1, float y1, int[] colors, float[] positions, int tileMode
			)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_LinearGradient_LinearGradient_postCreate(native_shader, x0, y0, 
					x1, y1, colors_handle.Address, positions_handle != null ? positions_handle.Address
					 : System.IntPtr.Zero, tileMode);
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
		private static extern System.IntPtr libxobotos_LinearGradient_LinearGradient_postCreate_0
			(android.graphics.Shader.NativeShader native_shader, float x0, float y0, float x1
			, float y1, int color0, int color1, int tileMode);

		private System.IntPtr nativePostCreate2(android.graphics.Shader.NativeShader native_shader
			, float x0, float y0, float x1, float y1, int color0, int color1, int tileMode)
		{
			return libxobotos_LinearGradient_LinearGradient_postCreate_0(native_shader, x0, y0
				, x1, y1, color0, color1, tileMode);
		}
	}
}
