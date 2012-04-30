using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>Shader used to draw a bitmap as a texture.</summary>
	/// <remarks>
	/// Shader used to draw a bitmap as a texture. The bitmap can be repeated or
	/// mirrored by setting the tiling mode.
	/// </remarks>
	[Sharpen.Sharpened]
	public class BitmapShader : android.graphics.Shader
	{
		/// <summary>Prevent garbage collection.</summary>
		/// <remarks>Prevent garbage collection.</remarks>
		/// <hide></hide>
		public readonly android.graphics.Bitmap mBitmap;

		/// <summary>Call this to create a new shader that will draw with a bitmap.</summary>
		/// <remarks>Call this to create a new shader that will draw with a bitmap.</remarks>
		/// <param name="bitmap">The bitmap to use inside the shader</param>
		/// <param name="tileX">The tiling mode for x to draw the bitmap in.</param>
		/// <param name="tileY">The tiling mode for y to draw the bitmap in.</param>
		public BitmapShader(android.graphics.Bitmap bitmap, android.graphics.Shader.TileMode
			? tileX, android.graphics.Shader.TileMode? tileY)
		{
			mBitmap = bitmap;
			android.graphics.Bitmap.NativeBitmap b = bitmap.nativeInstance;
			native_instance = nativeCreate(b, (int)tileX, (int)tileY);
			native_shader = nativePostCreate(native_instance, b, (int)tileX, (int)tileY);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_BitmapShader_BitmapShader_create
			(android.graphics.Bitmap.NativeBitmap native_bitmap, int shaderTileModeX, int shaderTileModeY
			);

		private static android.graphics.Shader.NativeShader nativeCreate(android.graphics.Bitmap.NativeBitmap
			 native_bitmap, int shaderTileModeX, int shaderTileModeY)
		{
			return libxobotos_BitmapShader_BitmapShader_create(native_bitmap, shaderTileModeX
				, shaderTileModeY);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_BitmapShader_BitmapShader_postCreate
			(android.graphics.Shader.NativeShader native_shader, android.graphics.Bitmap.NativeBitmap
			 native_bitmap, int shaderTileModeX, int shaderTileModeY);

		private static System.IntPtr nativePostCreate(android.graphics.Shader.NativeShader
			 native_shader, android.graphics.Bitmap.NativeBitmap native_bitmap, int shaderTileModeX
			, int shaderTileModeY)
		{
			return libxobotos_BitmapShader_BitmapShader_postCreate(native_shader, native_bitmap
				, shaderTileModeX, shaderTileModeY);
		}
	}
}
