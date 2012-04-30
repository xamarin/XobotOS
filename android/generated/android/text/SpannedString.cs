using Sharpen;

namespace android.text
{
	/// <summary>This is the class for text whose content and markup are immutable.</summary>
	/// <remarks>
	/// This is the class for text whose content and markup are immutable.
	/// For mutable markup, see
	/// <see cref="SpannableString">SpannableString</see>
	/// ; for mutable text,
	/// see
	/// <see cref="SpannableStringBuilder">SpannableStringBuilder</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed class SpannedString : android.text.SpannableStringInternal, java.lang.CharSequence
		, android.text.GetChars, android.text.Spanned
	{
		public SpannedString(java.lang.CharSequence source) : base(source, 0, source.Length
			)
		{
		}

		private SpannedString(java.lang.CharSequence source, int start, int end) : base(source
			, start, end)
		{
		}

		[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
		public java.lang.CharSequence SubSequence(int start, int end)
		{
			return new android.text.SpannedString(this, start, end);
		}

		public static android.text.SpannedString valueOf(java.lang.CharSequence source)
		{
			if (source is android.text.SpannedString)
			{
				return (android.text.SpannedString)source;
			}
			else
			{
				return new android.text.SpannedString(source);
			}
		}
	}
}
