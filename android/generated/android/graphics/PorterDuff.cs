using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class PorterDuff
	{
		public enum Mode : int
		{
			/// <summary>[0, 0]</summary>
			CLEAR = 0,
			/// <summary>[Sa, Sc]</summary>
			SRC = 1,
			/// <summary>[Da, Dc]</summary>
			DST = 2,
			/// <summary>[Sa + (1 - Sa)*Da, Rc = Sc + (1 - Sa)*Dc]</summary>
			SRC_OVER = 3,
			/// <summary>[Sa + (1 - Sa)*Da, Rc = Dc + (1 - Da)*Sc]</summary>
			DST_OVER = 4,
			/// <summary>[Sa * Da, Sc * Da]</summary>
			SRC_IN = 5,
			/// <summary>[Sa * Da, Sa * Dc]</summary>
			DST_IN = 6,
			/// <summary>[Sa * (1 - Da), Sc * (1 - Da)]</summary>
			SRC_OUT = 7,
			/// <summary>[Da * (1 - Sa), Dc * (1 - Sa)]</summary>
			DST_OUT = 8,
			/// <summary>[Da, Sc * Da + (1 - Sa) * Dc]</summary>
			SRC_ATOP = 9,
			/// <summary>[Sa, Sa * Dc + Sc * (1 - Da)]</summary>
			DST_ATOP = 10,
			/// <summary>[Sa + Da - 2 * Sa * Da, Sc * (1 - Da) + (1 - Sa) * Dc]</summary>
			XOR = 11,
			/// <summary>
			/// [Sa + Da - Sa*Da,
			/// Sc*(1 - Da) + Dc*(1 - Sa) + min(Sc, Dc)]
			/// </summary>
			DARKEN = 12,
			/// <summary>
			/// [Sa + Da - Sa*Da,
			/// Sc*(1 - Da) + Dc*(1 - Sa) + max(Sc, Dc)]
			/// </summary>
			LIGHTEN = 13,
			/// <summary>[Sa * Da, Sc * Dc]</summary>
			MULTIPLY = 14,
			/// <summary>[Sa + Da - Sa * Da, Sc + Dc - Sc * Dc]</summary>
			SCREEN = 15,
			/// <summary>Saturate(S + D)</summary>
			ADD = 16,
			OVERLAY = 17
		}
		// these value must match their native equivalents. See SkPorterDuff.h
	}
}
