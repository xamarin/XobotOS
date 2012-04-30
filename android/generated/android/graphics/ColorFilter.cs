using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public abstract class ColorFilter : System.IDisposable
	{
		internal android.graphics.ColorFilter.NativeFilter native_instance;

		/// <hide></hide>
		public System.IntPtr nativeColorFilter;

		internal NativeFilter nativeInstance
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

		internal class NativeFilter : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeFilter() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeFilter(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_ColorFilter_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeFilter Zero = new NativeFilter();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_ColorFilter_destructor(handle);
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
		// This file was generated from the C++ include file: SkColorFilter.h
		// Any changes made to this file will be discarded by the build.
		// To change this file, either edit the include, or device/tools/gluemaker/main.cpp, 
		// or one of the auxilary file specifications in device/tools/gluemaker.
	}
}
