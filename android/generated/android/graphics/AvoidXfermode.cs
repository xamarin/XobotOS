using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	/// <summary>
	/// AvoidXfermode xfermode will draw the src everywhere except on top of the
	/// opColor or, depending on the Mode, draw only on top of the opColor.
	/// </summary>
	/// <remarks>
	/// AvoidXfermode xfermode will draw the src everywhere except on top of the
	/// opColor or, depending on the Mode, draw only on top of the opColor.
	/// </remarks>
	[Sharpen.Sharpened]
	public class AvoidXfermode : android.graphics.Xfermode
	{
		public enum Mode : int
		{
			AVOID = 0,
			TARGET = 1
		}

		/// <summary>
		/// This xfermode draws, or doesn't draw, based on the destination's
		/// distance from an op-color.
		/// </summary>
		/// <remarks>
		/// This xfermode draws, or doesn't draw, based on the destination's
		/// distance from an op-color.
		/// There are two modes, and each mode interprets a tolerance value.
		/// Avoid: In this mode, drawing is allowed only on destination pixels that
		/// are different from the op-color.
		/// Tolerance near 0: avoid any colors even remotely similar to the op-color
		/// Tolerance near 255: avoid only colors nearly identical to the op-color
		/// Target: In this mode, drawing only occurs on destination pixels that
		/// are similar to the op-color
		/// Tolerance near 0: draw only on colors that are nearly identical to the op-color
		/// Tolerance near 255: draw on any colors even remotely similar to the op-color
		/// </remarks>
		public AvoidXfermode(int opColor, int tolerance, android.graphics.AvoidXfermode.Mode
			 mode)
		{
			// these need to match the enum in SkAvoidXfermode.h on the native side
			//!< draw everywhere except on the opColor
			//!< draw only on top of the opColor
			if (tolerance < 0 || tolerance > 255)
			{
				throw new System.ArgumentException("tolerance must be 0..255");
			}
			native_instance = nativeCreate(opColor, tolerance, (int)mode);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Xfermode.NativeXfermode libxobotos_AvoidXfermode_Avoid_create
			(int opColor, int tolerance, int nativeMode);

		private static android.graphics.Xfermode.NativeXfermode nativeCreate(int opColor, 
			int tolerance, int nativeMode)
		{
			return libxobotos_AvoidXfermode_Avoid_create(opColor, tolerance, nativeMode);
		}
	}
}
