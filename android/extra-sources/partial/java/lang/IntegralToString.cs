namespace java.lang
{
	partial class IntegralToString
	{
		/// <summary>
		/// Table for MOD / DIV 10 computation described in Section 10-21
		/// of Hank Warren's "Hacker's Delight" online addendum.
		/// </summary>
		/// <remarks>
		/// Table for MOD / DIV 10 computation described in Section 10-21
		/// of Hank Warren's "Hacker's Delight" online addendum.
		/// http://www.hackersdelight.org/divcMore.pdf
		/// </remarks>
		private static readonly short[] MOD_10_TABLE = new short[] {
			0, 1, 2, 2, 3, 3, 4, 5, 5, 6, 7, 7, 8, 8, 9, 0
		};
	}
}
