using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>A DrawFilter subclass can be installed in a Canvas.</summary>
	/// <remarks>
	/// A DrawFilter subclass can be installed in a Canvas. When it is present, it
	/// can modify the paint that is used to draw (temporarily). With this, a filter
	/// can disable/enable antialiasing, or change the color for everything this is
	/// drawn.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class DrawFilter : System.IDisposable
	{
		internal android.graphics.DrawFilter.NativeDrawFilter mNativeInt;

		~DrawFilter()
		{
			// this is set by subclasses, but don't make it public
			// pointer to native object
			nativeDestructor(mNativeInt);
		}

		private static void nativeDestructor(android.graphics.DrawFilter.NativeDrawFilter
			 nativeDrawFilter)
		{
			nativeDrawFilter.Dispose();
		}

		internal NativeDrawFilter nativeInstance
		{
			get
			{
				return mNativeInt;
			}
		}

		public void Dispose()
		{
			mNativeInt.Dispose();
		}

		internal class NativeDrawFilter : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeDrawFilter() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeDrawFilter(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_DrawFilter_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeDrawFilter Zero = new NativeDrawFilter();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_DrawFilter_destructor(handle);
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
