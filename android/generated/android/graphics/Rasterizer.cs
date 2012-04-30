using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public abstract class Rasterizer : System.IDisposable
	{
		~Rasterizer()
		{
			// This file was generated from the C++ include file: SkRasterizer.h
			// Any changes made to this file will be discarded by the build.
			// To change this file, either edit the include, or device/tools/gluemaker/main.cpp, 
			// or one of the auxilary file specifications in device/tools/gluemaker.
			finalizer(native_instance);
		}

		private static void finalizer(android.graphics.Rasterizer.NativeRasterizer native_instance
			)
		{
			native_instance.Dispose();
		}

		internal android.graphics.Rasterizer.NativeRasterizer native_instance;

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativeRasterizer : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeRasterizer() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeRasterizer(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Rasterizer_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeRasterizer Zero = new NativeRasterizer();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Rasterizer_destructor(handle);
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
