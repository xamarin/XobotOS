using Sharpen;

namespace android.text
{
	/// <summary>
	/// This is the class for text whose content is immutable but to which
	/// markup objects can be attached and detached.
	/// </summary>
	/// <remarks>
	/// This is the class for text whose content is immutable but to which
	/// markup objects can be attached and detached.
	/// For mutable text, see
	/// <see cref="SpannableStringBuilder">SpannableStringBuilder</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	internal partial class SpannableString : android.text.SpannableStringInternal, java.lang.CharSequence
		, android.text.GetChars, android.text.Spannable
	{
		public SpannableString(java.lang.CharSequence source) : base(source, 0, source.Length
			)
		{
		}

		private SpannableString(java.lang.CharSequence source, int start, int end) : base
			(source, start, end)
		{
		}

		public static android.text.SpannableString valueOf(java.lang.CharSequence source)
		{
			if (source is android.text.SpannableString)
			{
				return (android.text.SpannableString)source;
			}
			else
			{
				return new android.text.SpannableString(source);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.SpannableStringInternal")]
		public override void setSpan(object what, int start, int end, int flags)
		{
			base.setSpan(what, start, end, flags);
		}

		[Sharpen.OverridesMethod(@"android.text.SpannableStringInternal")]
		public override void removeSpan(object what)
		{
			base.removeSpan(what);
		}

		[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
		public virtual java.lang.CharSequence SubSequence(int start, int end)
		{
			return new android.text.SpannableString(this, start, end);
		}
	}
}
