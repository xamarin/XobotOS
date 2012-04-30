using Sharpen;

namespace android.text
{
	/// <summary>
	/// InputFilters can be attached to
	/// <see cref="Editable">Editable</see>
	/// s to constrain the
	/// changes that can be made to them.
	/// </summary>
	[Sharpen.Sharpened]
	public interface InputFilter
	{
		/// <summary>
		/// This method is called when the buffer is going to replace the
		/// range <code>dstart &hellip; dend</code> of <code>dest</code>
		/// with the new text from the range <code>start &hellip; end</code>
		/// of <code>source</code>.
		/// </summary>
		/// <remarks>
		/// This method is called when the buffer is going to replace the
		/// range <code>dstart &hellip; dend</code> of <code>dest</code>
		/// with the new text from the range <code>start &hellip; end</code>
		/// of <code>source</code>.  Return the CharSequence that you would
		/// like to have placed there instead, including an empty string
		/// if appropriate, or <code>null</code> to accept the original
		/// replacement.  Be careful to not to reject 0-length replacements,
		/// as this is what happens when you delete text.  Also beware that
		/// you should not attempt to make any changes to <code>dest</code>
		/// from this method; you may only examine it for context.
		/// Note: If <var>source</var> is an instance of
		/// <see cref="Spanned">Spanned</see>
		/// or
		/// <see cref="Spannable">Spannable</see>
		/// , the span objects in the <var>source</var> should be
		/// copied into the filtered result (i.e. the non-null return value).
		/// <see cref="TextUtils.copySpansFrom(Spanned, int, int, System.Type{T}, Spannable, int)
		/// 	">TextUtils.copySpansFrom(Spanned, int, int, System.Type&lt;T&gt;, Spannable, int)
		/// 	</see>
		/// can be used for convenience.
		/// </remarks>
		java.lang.CharSequence filter(java.lang.CharSequence source, int start, int end, 
			android.text.Spanned dest, int dstart, int dend);
		// keep original
		// keep original
	}

	/// <summary>
	/// InputFilters can be attached to
	/// <see cref="Editable">Editable</see>
	/// s to constrain the
	/// changes that can be made to them.
	/// </summary>
	[Sharpen.Sharpened]
	public static class InputFilterClass
	{
		/// <summary>
		/// This filter will capitalize all the lower case letters that are added
		/// through edits.
		/// </summary>
		/// <remarks>
		/// This filter will capitalize all the lower case letters that are added
		/// through edits.
		/// </remarks>
		public class AllCaps : android.text.InputFilter
		{
			[Sharpen.ImplementsInterface(@"android.text.InputFilter")]
			public virtual java.lang.CharSequence filter(java.lang.CharSequence source, int start
				, int end, android.text.Spanned dest, int dstart, int dend)
			{
				{
					for (int i = start; i < end; i++)
					{
						if (System.Char.IsLower(source[i]))
						{
							char[] v = new char[end - start];
							android.text.TextUtils.getChars(source, start, end, v, 0);
							string s = new string(v).ToUpper();
							if (source is android.text.Spanned)
							{
								android.text.SpannableString sp = new android.text.SpannableString(java.lang.CharSequenceProxy.Wrap
									(s));
								android.text.TextUtils.copySpansFrom((android.text.Spanned)source, start, end, null
									, sp, 0);
								return sp;
							}
							else
							{
								return java.lang.CharSequenceProxy.Wrap(s);
							}
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		/// This filter will constrain edits not to make the length of the text
		/// greater than the specified length.
		/// </summary>
		/// <remarks>
		/// This filter will constrain edits not to make the length of the text
		/// greater than the specified length.
		/// </remarks>
		public class LengthFilter : android.text.InputFilter
		{
			public LengthFilter(int max)
			{
				mMax = max;
			}

			[Sharpen.ImplementsInterface(@"android.text.InputFilter")]
			public virtual java.lang.CharSequence filter(java.lang.CharSequence source, int start
				, int end, android.text.Spanned dest, int dstart, int dend)
			{
				int keep = mMax - (dest.Length - (dend - dstart));
				if (keep <= 0)
				{
					return java.lang.CharSequenceProxy.Wrap(string.Empty);
				}
				else
				{
					if (keep >= end - start)
					{
						return null;
					}
					else
					{
						keep += start;
						if (System.Char.IsHighSurrogate(source[keep - 1]))
						{
							--keep;
							if (keep == start)
							{
								return java.lang.CharSequenceProxy.Wrap(string.Empty);
							}
						}
						return source.SubSequence(start, keep);
					}
				}
			}

			private int mMax;
		}
	}
}
