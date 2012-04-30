using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// This transformation method causes any newline characters (\n) to be
	/// displayed as spaces instead of causing line breaks, and causes
	/// carriage return characters (\r) to have no appearance.
	/// </summary>
	/// <remarks>
	/// This transformation method causes any newline characters (\n) to be
	/// displayed as spaces instead of causing line breaks, and causes
	/// carriage return characters (\r) to have no appearance.
	/// </remarks>
	[Sharpen.Sharpened]
	public class SingleLineTransformationMethod : android.text.method.ReplacementTransformationMethod
	{
		private static char[] ORIGINAL = new char[] { '\n', '\r' };

		private static char[] REPLACEMENT = new char[] { ' ', '\uFEFF' };

		/// <summary>The characters to be replaced are \n and \r.</summary>
		/// <remarks>The characters to be replaced are \n and \r.</remarks>
		[Sharpen.OverridesMethod(@"android.text.method.ReplacementTransformationMethod")]
		protected internal override char[] getOriginal()
		{
			return ORIGINAL;
		}

		/// <summary>
		/// The character \n is replaced with is space;
		/// the character \r is replaced with is FEFF (zero width space).
		/// </summary>
		/// <remarks>
		/// The character \n is replaced with is space;
		/// the character \r is replaced with is FEFF (zero width space).
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.text.method.ReplacementTransformationMethod")]
		protected internal override char[] getReplacement()
		{
			return REPLACEMENT;
		}

		public static android.text.method.SingleLineTransformationMethod getInstance()
		{
			if (sInstance != null)
			{
				return sInstance;
			}
			sInstance = new android.text.method.SingleLineTransformationMethod();
			return sInstance;
		}

		private static android.text.method.SingleLineTransformationMethod sInstance;
	}
}
