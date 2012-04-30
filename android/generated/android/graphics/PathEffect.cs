using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// PathEffect is the base class for objects in the Paint that affect
	/// the geometry of a drawing primitive before it is transformed by the
	/// canvas' matrix and drawn.
	/// </summary>
	/// <remarks>
	/// PathEffect is the base class for objects in the Paint that affect
	/// the geometry of a drawing primitive before it is transformed by the
	/// canvas' matrix and drawn.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class PathEffect : System.IDisposable
	{
		~PathEffect()
		{
			nativeDestructor(native_instance);
		}

		private static void nativeDestructor(android.graphics.PathEffect.NativePathEffect
			 native_patheffect)
		{
			native_patheffect.Dispose();
		}

		internal android.graphics.PathEffect.NativePathEffect native_instance;

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativePathEffect : System.Runtime.InteropServices.SafeHandle
		{
			internal NativePathEffect() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativePathEffect(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_PathEffect_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativePathEffect Zero = new NativePathEffect();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_PathEffect_destructor(handle);
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
