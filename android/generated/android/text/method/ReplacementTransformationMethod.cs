using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// This transformation method causes the characters in the
	/// <see cref="getOriginal()">getOriginal()</see>
	/// array to be replaced by the corresponding characters in the
	/// <see cref="getReplacement()">getReplacement()</see>
	/// array.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class ReplacementTransformationMethod : android.text.method.TransformationMethod
	{
		/// <summary>
		/// Returns the list of characters that are to be replaced by other
		/// characters when displayed.
		/// </summary>
		/// <remarks>
		/// Returns the list of characters that are to be replaced by other
		/// characters when displayed.
		/// </remarks>
		protected internal abstract char[] getOriginal();

		/// <summary>
		/// Returns a parallel array of replacement characters for the ones
		/// that are to be replaced.
		/// </summary>
		/// <remarks>
		/// Returns a parallel array of replacement characters for the ones
		/// that are to be replaced.
		/// </remarks>
		protected internal abstract char[] getReplacement();

		/// <summary>
		/// Returns a CharSequence that will mirror the contents of the
		/// source CharSequence but with the characters in
		/// <see cref="getOriginal()">getOriginal()</see>
		/// replaced by ones from
		/// <see cref="getReplacement()">getReplacement()</see>
		/// .
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod")]
		public virtual java.lang.CharSequence getTransformation(java.lang.CharSequence source
			, android.view.View v)
		{
			char[] original = getOriginal();
			char[] replacement = getReplacement();
			if (!(source is android.text.Editable))
			{
				bool doNothing = true;
				int n = original.Length;
				{
					for (int i = 0; i < n; i++)
					{
						if (android.text.TextUtils.indexOf(source, original[i]) >= 0)
						{
							doNothing = false;
							break;
						}
					}
				}
				if (doNothing)
				{
					return source;
				}
				if (!(source is android.text.Spannable))
				{
					if (source is android.text.Spanned)
					{
						return new android.text.SpannedString(new android.text.method.ReplacementTransformationMethod
							.SpannedReplacementCharSequence((android.text.Spanned)source, original, replacement
							));
					}
					else
					{
						return java.lang.CharSequenceProxy.Wrap(new android.text.method.ReplacementTransformationMethod
							.ReplacementCharSequence(source, original, replacement).ToString());
					}
				}
			}
			if (source is android.text.Spanned)
			{
				return new android.text.method.ReplacementTransformationMethod.SpannedReplacementCharSequence
					((android.text.Spanned)source, original, replacement);
			}
			else
			{
				return new android.text.method.ReplacementTransformationMethod.ReplacementCharSequence
					(source, original, replacement);
			}
		}

		[Sharpen.ImplementsInterface(@"android.text.method.TransformationMethod")]
		public virtual void onFocusChanged(android.view.View view, java.lang.CharSequence
			 sourceText, bool focused, int direction, android.graphics.Rect previouslyFocusedRect
			)
		{
		}

		private class ReplacementCharSequence : java.lang.CharSequence, android.text.GetChars
		{
			internal char[] mOriginal;

			internal char[] mReplacement;

			public ReplacementCharSequence(java.lang.CharSequence source, char[] original, char
				[] replacement)
			{
				// This callback isn't used.
				mSource = source;
				mOriginal = original;
				mReplacement = replacement;
			}

			public virtual int Length
			{
				get
				{
					return mSource.Length;
				}
			}

			public virtual char this[int i]
			{
				get
				{
					char c = mSource[i];
					int n = mOriginal.Length;
					{
						for (int j = 0; j < n; j++)
						{
							if (c == mOriginal[j])
							{
								c = mReplacement[j];
							}
						}
					}
					return c;
				}
			}

			[Sharpen.ImplementsInterface(@"java.lang.CharSequence")]
			public virtual java.lang.CharSequence SubSequence(int start, int end)
			{
				char[] c = new char[end - start];
				getChars(start, end, c, 0);
				return java.lang.CharSequenceProxy.Wrap(new string(c));
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				char[] c = new char[Length];
				getChars(0, Length, c, 0);
				return new string(c);
			}

			[Sharpen.ImplementsInterface(@"android.text.GetChars")]
			public virtual void getChars(int start, int end, char[] dest, int off)
			{
				android.text.TextUtils.getChars(mSource, start, end, dest, off);
				int offend = end - start + off;
				int n = mOriginal.Length;
				{
					for (int i = off; i < offend; i++)
					{
						char c = dest[i];
						{
							for (int j = 0; j < n; j++)
							{
								if (c == mOriginal[j])
								{
									dest[i] = mReplacement[j];
								}
							}
						}
					}
				}
			}

			internal java.lang.CharSequence mSource;
		}

		private class SpannedReplacementCharSequence : android.text.method.ReplacementTransformationMethod
			.ReplacementCharSequence, android.text.Spanned
		{
			public SpannedReplacementCharSequence(android.text.Spanned source, char[] original
				, char[] replacement) : base(source, original, replacement)
			{
				mSpanned = source;
			}

			[Sharpen.OverridesMethod(@"android.text.method.ReplacementTransformationMethod.ReplacementCharSequence"
				)]
			public override java.lang.CharSequence SubSequence(int start, int end)
			{
				return new android.text.SpannedString(this).SubSequence(start, end);
			}

			[Sharpen.Proxy]
			T[] android.text.Spanned.getSpans<T>(int start, int end)
			{
				System.Type type = typeof(T);
				return getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual T[] getSpans<T>(int start, int end)
			{
				System.Type type = typeof(T);
				return mSpanned.getSpans<T>(start, end);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanStart(object tag)
			{
				return mSpanned.getSpanStart(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanEnd(object tag)
			{
				return mSpanned.getSpanEnd(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int getSpanFlags(object tag)
			{
				return mSpanned.getSpanFlags(tag);
			}

			[Sharpen.ImplementsInterface(@"android.text.Spanned")]
			public virtual int nextSpanTransition(int start, int end, System.Type type)
			{
				return mSpanned.nextSpanTransition(start, end, type);
			}

			internal android.text.Spanned mSpanned;
		}
	}
}
