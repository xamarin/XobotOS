using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class RadialGradient : android.graphics.Shader
	{
		/// <summary>Create a shader that draws a radial gradient given the center and radius.
		/// 	</summary>
		/// <remarks>Create a shader that draws a radial gradient given the center and radius.
		/// 	</remarks>
		/// <param name="x">The x-coordinate of the center of the radius</param>
		/// <param name="y">The y-coordinate of the center of the radius</param>
		/// <param name="radius">Must be positive. The radius of the circle for this gradient
		/// 	</param>
		/// <param name="colors">The colors to be distributed between the center and edge of the circle
		/// 	</param>
		/// <param name="positions">
		/// May be NULL. The relative position of
		/// each corresponding color in the colors array. If this is NULL,
		/// the the colors are distributed evenly between the center and edge of the circle.
		/// </param>
		/// <param name="tile">The Shader tiling mode</param>
		public RadialGradient(float x, float y, float radius, int[] colors, float[] positions
			, android.graphics.Shader.TileMode? tile)
		{
			if (radius <= 0)
			{
				throw new System.ArgumentException("radius must be > 0");
			}
			if (colors.Length < 2)
			{
				throw new System.ArgumentException("needs >= 2 number of colors");
			}
			if (positions != null && colors.Length != positions.Length)
			{
				throw new System.ArgumentException("color and position arrays must be of equal length"
					);
			}
			native_instance = nativeCreate1(x, y, radius, colors, positions, (int)tile);
			native_shader = nativePostCreate1(native_instance, x, y, radius, colors, positions
				, (int)tile);
		}

		/// <summary>Create a shader that draws a radial gradient given the center and radius.
		/// 	</summary>
		/// <remarks>Create a shader that draws a radial gradient given the center and radius.
		/// 	</remarks>
		/// <param name="x">The x-coordinate of the center of the radius</param>
		/// <param name="y">The y-coordinate of the center of the radius</param>
		/// <param name="radius">Must be positive. The radius of the circle for this gradient
		/// 	</param>
		/// <param name="color0">The color at the center of the circle.</param>
		/// <param name="color1">The color at the edge of the circle.</param>
		/// <param name="tile">The Shader tiling mode</param>
		public RadialGradient(float x, float y, float radius, int color0, int color1, android.graphics.Shader.TileMode
			? tile)
		{
			if (radius <= 0)
			{
				throw new System.ArgumentException("radius must be > 0");
			}
			native_instance = nativeCreate2(x, y, radius, color0, color1, (int)tile);
			native_shader = nativePostCreate2(native_instance, x, y, radius, color0, color1, 
				(int)tile);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_RadialGradient_RadialGradient_create
			(float x, float y, float radius, System.IntPtr colors, System.IntPtr positions, 
			int tileMode);

		private static android.graphics.Shader.NativeShader nativeCreate1(float x, float 
			y, float radius, int[] colors, float[] positions, int tileMode)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_RadialGradient_RadialGradient_create(x, y, radius, colors_handle
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
		private static extern android.graphics.Shader.NativeShader libxobotos_RadialGradient_RadialGradient_create_0
			(float x, float y, float radius, int color0, int color1, int tileMode);

		private static android.graphics.Shader.NativeShader nativeCreate2(float x, float 
			y, float radius, int color0, int color1, int tileMode)
		{
			return libxobotos_RadialGradient_RadialGradient_create_0(x, y, radius, color0, color1
				, tileMode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_RadialGradient_RadialGradient_postCreate
			(android.graphics.Shader.NativeShader native_shader, float x, float y, float radius
			, System.IntPtr colors, System.IntPtr positions, int tileMode);

		private static System.IntPtr nativePostCreate1(android.graphics.Shader.NativeShader
			 native_shader, float x, float y, float radius, int[] colors, float[] positions, 
			int tileMode)
		{
			Sharpen.INativeHandle colors_handle = null;
			Sharpen.INativeHandle positions_handle = null;
			try
			{
				colors_handle = XobotOS.Runtime.MarshalGlue.Array_int_Helper.GetPinnedPtr(colors);
				positions_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(positions
					);
				return libxobotos_RadialGradient_RadialGradient_postCreate(native_shader, x, y, radius
					, colors_handle.Address, positions_handle != null ? positions_handle.Address : System.IntPtr.Zero
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
		private static extern System.IntPtr libxobotos_RadialGradient_RadialGradient_postCreate_0
			(android.graphics.Shader.NativeShader native_shader, float x, float y, float radius
			, int color0, int color1, int tileMode);

		private static System.IntPtr nativePostCreate2(android.graphics.Shader.NativeShader
			 native_shader, float x, float y, float radius, int color0, int color1, int tileMode
			)
		{
			return libxobotos_RadialGradient_RadialGradient_postCreate_0(native_shader, x, y, 
				radius, color0, color1, tileMode);
		}
	}
}
