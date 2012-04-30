using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PaintFlagsDrawFilter : android.graphics.DrawFilter
	{
		/// <summary>
		/// Subclass of DrawFilter that affects every paint by first clearing
		/// the specified clearBits in the paint's flags, and then setting the
		/// specified setBits in the paint's flags.
		/// </summary>
		/// <remarks>
		/// Subclass of DrawFilter that affects every paint by first clearing
		/// the specified clearBits in the paint's flags, and then setting the
		/// specified setBits in the paint's flags.
		/// </remarks>
		/// <param name="clearBits">These bits will be cleared in the paint's flags</param>
		/// <param name="setBits">These bits will be set in the paint's flags</param>
		public PaintFlagsDrawFilter(int clearBits, int setBits)
		{
			// our native constructor can return 0, if the specified bits
			// are effectively a no-op
			mNativeInt = nativeConstructor(clearBits, setBits);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.DrawFilter.NativeDrawFilter libxobotos_PaintFlagsDrawFilter_PaintFlagsDrawFilter_create
			(int clearBits, int setBits);

		private static android.graphics.DrawFilter.NativeDrawFilter nativeConstructor(int
			 clearBits, int setBits)
		{
			return libxobotos_PaintFlagsDrawFilter_PaintFlagsDrawFilter_create(clearBits, setBits
				);
		}
	}
}
