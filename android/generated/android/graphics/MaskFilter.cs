using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// MaskFilter is the base class for object that perform transformations on
	/// an alpha-channel mask before drawing it.
	/// </summary>
	/// <remarks>
	/// MaskFilter is the base class for object that perform transformations on
	/// an alpha-channel mask before drawing it. A subclass of MaskFilter may be
	/// installed into a Paint. Blur and emboss are implemented as subclasses of MaskFilter.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class MaskFilter : System.IDisposable
	{
		~MaskFilter()
		{
			nativeDestructor(native_instance);
		}

		private static void nativeDestructor(android.graphics.MaskFilter.NativeFilter native_filter
			)
		{
			native_filter.Dispose();
		}

		internal android.graphics.MaskFilter.NativeFilter native_instance;

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
			private static extern void libxobotos_android_graphics_MaskFilter_destructor(System.IntPtr
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
					libxobotos_android_graphics_MaskFilter_destructor(handle);
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
