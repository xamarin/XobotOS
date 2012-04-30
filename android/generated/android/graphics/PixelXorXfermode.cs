using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>PixelXorXfermode implements a simple pixel xor (op ^ src ^ dst).</summary>
	/// <remarks>
	/// PixelXorXfermode implements a simple pixel xor (op ^ src ^ dst).
	/// This transformation does not follow premultiplied conventions, therefore
	/// this mode *always* returns an opaque color (alpha == 255). Thus it is
	/// not really usefull for operating on blended colors.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PixelXorXfermode : android.graphics.Xfermode
	{
		public PixelXorXfermode(int opColor)
		{
			native_instance = nativeCreate(opColor);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Xfermode.NativeXfermode libxobotos_PixelXorXfermode_PixelXor_create
			(int opColor);

		private static android.graphics.Xfermode.NativeXfermode nativeCreate(int opColor)
		{
			return libxobotos_PixelXorXfermode_PixelXor_create(opColor);
		}
	}
}
