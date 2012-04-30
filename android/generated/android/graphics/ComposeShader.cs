using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// A subclass of shader that returns the coposition of two other shaders, combined by
	/// an
	/// <see cref="Xfermode">Xfermode</see>
	/// subclass.
	/// </summary>
	[Sharpen.Sharpened]
	public class ComposeShader : android.graphics.Shader
	{
		/// <summary>Hold onto the shaders to avoid GC.</summary>
		/// <remarks>Hold onto the shaders to avoid GC.</remarks>
		private readonly android.graphics.Shader mShaderA;

		private readonly android.graphics.Shader mShaderB;

		/// <summary>Create a new compose shader, given shaders A, B, and a combining mode.</summary>
		/// <remarks>
		/// Create a new compose shader, given shaders A, B, and a combining mode.
		/// When the mode is applied, it will be given the result from shader A as its
		/// "dst", and the result from shader B as its "src".
		/// </remarks>
		/// <param name="shaderA">The colors from this shader are seen as the "dst" by the mode
		/// 	</param>
		/// <param name="shaderB">The colors from this shader are seen as the "src" by the mode
		/// 	</param>
		/// <param name="mode">
		/// The mode that combines the colors from the two shaders. If mode
		/// is null, then SRC_OVER is assumed.
		/// </param>
		public ComposeShader(android.graphics.Shader shaderA, android.graphics.Shader shaderB
			, android.graphics.Xfermode mode)
		{
			mShaderA = shaderA;
			mShaderB = shaderB;
			native_instance = nativeCreate1(shaderA.native_instance, shaderB.native_instance, 
				(mode != null) ? mode.native_instance : null);
			if (mode is android.graphics.PorterDuffXfermode)
			{
				android.graphics.PorterDuff.Mode pdMode = ((android.graphics.PorterDuffXfermode)mode
					).mode;
				native_shader = nativePostCreate2(native_instance, shaderA.native_shader, shaderB
					.native_shader, pdMode != null ? (int)pdMode : 0);
			}
			else
			{
				native_shader = nativePostCreate1(native_instance, shaderA.native_shader, shaderB
					.native_shader, mode != null ? mode.native_instance : null);
			}
		}

		/// <summary>Create a new compose shader, given shaders A, B, and a combining PorterDuff mode.
		/// 	</summary>
		/// <remarks>
		/// Create a new compose shader, given shaders A, B, and a combining PorterDuff mode.
		/// When the mode is applied, it will be given the result from shader A as its
		/// "dst", and the result from shader B as its "src".
		/// </remarks>
		/// <param name="shaderA">The colors from this shader are seen as the "dst" by the mode
		/// 	</param>
		/// <param name="shaderB">The colors from this shader are seen as the "src" by the mode
		/// 	</param>
		/// <param name="mode">The PorterDuff mode that combines the colors from the two shaders.
		/// 	</param>
		public ComposeShader(android.graphics.Shader shaderA, android.graphics.Shader shaderB
			, android.graphics.PorterDuff.Mode mode)
		{
			mShaderA = shaderA;
			mShaderB = shaderB;
			native_instance = nativeCreate2(shaderA.native_instance, shaderB.native_instance, 
				(int)mode);
			native_shader = nativePostCreate2(native_instance, shaderA.native_shader, shaderB
				.native_shader, (int)mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_ComposeShader_ComposeShader_create
			(android.graphics.Shader.NativeShader native_shaderA, android.graphics.Shader.NativeShader
			 native_shaderB, android.graphics.Xfermode.NativeXfermode native_mode);

		private static android.graphics.Shader.NativeShader nativeCreate1(android.graphics.Shader.NativeShader
			 native_shaderA, android.graphics.Shader.NativeShader native_shaderB, android.graphics.Xfermode.NativeXfermode
			 native_mode)
		{
			return libxobotos_ComposeShader_ComposeShader_create(native_shaderA, native_shaderB
				, native_mode != null ? native_mode : android.graphics.Xfermode.NativeXfermode.Zero
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Shader.NativeShader libxobotos_ComposeShader_ComposeShader_create_0
			(android.graphics.Shader.NativeShader native_shaderA, android.graphics.Shader.NativeShader
			 native_shaderB, int porterDuffMode);

		private static android.graphics.Shader.NativeShader nativeCreate2(android.graphics.Shader.NativeShader
			 native_shaderA, android.graphics.Shader.NativeShader native_shaderB, int porterDuffMode
			)
		{
			return libxobotos_ComposeShader_ComposeShader_create_0(native_shaderA, native_shaderB
				, porterDuffMode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_ComposeShader_ComposeShader_postCreate
			(android.graphics.Shader.NativeShader native_shader, System.IntPtr native_skiaShaderA
			, System.IntPtr native_skiaShaderB, android.graphics.Xfermode.NativeXfermode native_mode
			);

		private static System.IntPtr nativePostCreate1(android.graphics.Shader.NativeShader
			 native_shader, System.IntPtr native_skiaShaderA, System.IntPtr native_skiaShaderB
			, android.graphics.Xfermode.NativeXfermode native_mode)
		{
			return libxobotos_ComposeShader_ComposeShader_postCreate(native_shader, native_skiaShaderA
				, native_skiaShaderB, native_mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern System.IntPtr libxobotos_ComposeShader_ComposeShader_postCreate_0
			(android.graphics.Shader.NativeShader native_shader, System.IntPtr native_skiaShaderA
			, System.IntPtr native_skiaShaderB, int porterDuffMode);

		private static System.IntPtr nativePostCreate2(android.graphics.Shader.NativeShader
			 native_shader, System.IntPtr native_skiaShaderA, System.IntPtr native_skiaShaderB
			, int porterDuffMode)
		{
			return libxobotos_ComposeShader_ComposeShader_postCreate_0(native_shader, native_skiaShaderA
				, native_skiaShaderB, porterDuffMode);
		}
	}
}
