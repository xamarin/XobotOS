using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// Xfermode is the base class for objects that are called to implement custom
	/// "transfer-modes" in the drawing pipeline.
	/// </summary>
	/// <remarks>
	/// Xfermode is the base class for objects that are called to implement custom
	/// "transfer-modes" in the drawing pipeline. The static function Create(Modes)
	/// can be called to return an instance of any of the predefined subclasses as
	/// specified in the Modes enum. When an Xfermode is assigned to an Paint, then
	/// objects drawn with that paint have the xfermode applied.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Xfermode : System.IDisposable
	{
		~Xfermode()
		{
			// This file was generated from the C++ include file: SkXfermode.h
			// Any changes made to this file will be discarded by the build.
			// To change this file, either edit the include, or device/tools/gluemaker/main.cpp, 
			// or one of the auxilary file specifications in device/tools/gluemaker.
			try
			{
				finalizer(native_instance);
			}
			finally
			{
				;
			}
		}

		private static void finalizer(android.graphics.Xfermode.NativeXfermode native_instance
			)
		{
			native_instance.Dispose();
		}

		internal android.graphics.Xfermode.NativeXfermode native_instance;

		internal NativeXfermode nativeInstance
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

		internal class NativeXfermode : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeXfermode() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeXfermode(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Xfermode_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeXfermode Zero = new NativeXfermode();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Xfermode_destructor(handle);
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
