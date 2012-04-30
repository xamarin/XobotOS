using Sharpen;

namespace libcore.icu
{
	[Sharpen.Sharpened]
	public sealed class NativePluralRules
	{
		public const int ZERO = 0;
		public const int ONE = 1;
		public const int TWO = 2;
		public const int FEW = 3;
		public const int MANY = 4;
		public const int OTHER = 5;

		private NativePluralRules ()
		{
		}

		public static NativePluralRules forLocale (System.Globalization.CultureInfo locale)
		{
			return null;
		}

		[Stub]
		public int quantityForInt (int value)
		{
			throw new System.NotImplementedException ();
		}
	}
}
