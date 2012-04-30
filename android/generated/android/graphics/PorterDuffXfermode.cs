using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PorterDuffXfermode : android.graphics.Xfermode
	{
		/// <hide></hide>
		public readonly android.graphics.PorterDuff.Mode mode;

		/// <summary>Create an xfermode that uses the specified porter-duff mode.</summary>
		/// <remarks>Create an xfermode that uses the specified porter-duff mode.</remarks>
		/// <param name="mode">The porter-duff mode that is applied</param>
		public PorterDuffXfermode(android.graphics.PorterDuff.Mode mode)
		{
			this.mode = mode;
			native_instance = nativeCreateXfermode((int)mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Xfermode.NativeXfermode libxobotos_PorterDuffXfermode_PorterDuff_create
			(int mode);

		private static android.graphics.Xfermode.NativeXfermode nativeCreateXfermode(int 
			mode)
		{
			return libxobotos_PorterDuffXfermode_PorterDuff_create(mode);
		}
	}
}
