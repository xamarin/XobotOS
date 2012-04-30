using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// Shader is the based class for objects that return horizontal spans of colors
	/// during drawing.
	/// </summary>
	/// <remarks>
	/// Shader is the based class for objects that return horizontal spans of colors
	/// during drawing. A subclass of Shader is installed in a Paint calling
	/// paint.setShader(shader). After that any object (other than a bitmap) that is
	/// drawn with that paint will get its color(s) from the shader.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Shader : System.IDisposable
	{
		/// <summary>This is set by subclasses, but don't make it public.</summary>
		/// <remarks>This is set by subclasses, but don't make it public.</remarks>
		/// <hide></hide>
		internal android.graphics.Shader.NativeShader native_instance;

		/// <hide></hide>
		public System.IntPtr native_shader;

		private android.graphics.Matrix mLocalMatrix;

		public enum TileMode : int
		{
			/// <summary>
			/// replicate the edge color if the shader draws outside of its
			/// original bounds
			/// </summary>
			CLAMP = 0,
			/// <summary>repeat the shader's image horizontally and vertically</summary>
			REPEAT = 1,
			/// <summary>
			/// repeat the shader's image horizontally and vertically, alternating
			/// mirror images so that adjacent images always seam
			/// </summary>
			MIRROR = 2
		}

		/// <summary>Return true if the shader has a non-identity local matrix.</summary>
		/// <remarks>Return true if the shader has a non-identity local matrix.</remarks>
		/// <param name="localM">If not null, it is set to the shader's local matrix.</param>
		/// <returns>true if the shader has a non-identity local matrix</returns>
		public virtual bool getLocalMatrix(android.graphics.Matrix localM)
		{
			if (mLocalMatrix != null)
			{
				localM.set(mLocalMatrix);
				return !mLocalMatrix.isIdentity();
			}
			return false;
		}

		/// <summary>Set the shader's local matrix.</summary>
		/// <remarks>
		/// Set the shader's local matrix. Passing null will reset the shader's
		/// matrix to identity
		/// </remarks>
		/// <param name="localM">The shader's new local matrix, or null to specify identity</param>
		public virtual void setLocalMatrix(android.graphics.Matrix localM)
		{
			mLocalMatrix = localM;
			nativeSetLocalMatrix(native_instance, localM == null ? null : localM.native_instance
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Shader_setLocalMatrix(android.graphics.Shader.NativeShader
			 native_shader, android.graphics.Matrix.NativeMatrix matrix_instance);

		private static void nativeSetLocalMatrix(android.graphics.Shader.NativeShader native_shader
			, android.graphics.Matrix.NativeMatrix matrix_instance)
		{
			libxobotos_Shader_setLocalMatrix(native_shader != null ? native_shader : android.graphics.Shader.NativeShader
				.Zero, matrix_instance != null ? matrix_instance : android.graphics.Matrix.NativeMatrix
				.Zero);
		}

		internal NativeShader nativeInstance
		{
			get
			{
				return native_instance;
			}
		}

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativeShader : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeShader() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeShader(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Shader_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeShader Zero = new NativeShader();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Shader_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
