using Sharpen;

namespace android.text.method
{
	/// <summary>Walks through cursor positions at word boundaries.</summary>
	/// <remarks>
	/// Walks through cursor positions at word boundaries. Internally uses
	/// <see cref="java.text.BreakIterator.getWordInstance()">java.text.BreakIterator.getWordInstance()
	/// 	</see>
	/// , and caches
	/// <see cref="java.lang.CharSequence">java.lang.CharSequence</see>
	/// for performance reasons.
	/// Also provides methods to determine word boundaries.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public class WordIterator : android.text.Selection.PositionIterator
	{
		internal const int WINDOW_WIDTH = 50;

		private string mString;

		private int mOffsetShift;

		private java.text.BreakIterator mIterator;

		/// <summary>Constructs a WordIterator using the default locale.</summary>
		/// <remarks>Constructs a WordIterator using the default locale.</remarks>
		public WordIterator() : this(System.Globalization.CultureInfo.CurrentCulture)
		{
		}

		/// <summary>Constructs a new WordIterator for the specified locale.</summary>
		/// <remarks>Constructs a new WordIterator for the specified locale.</remarks>
		/// <param name="locale">The locale to be used when analysing the text.</param>
		public WordIterator(System.Globalization.CultureInfo locale)
		{
			// Size of the window for the word iterator, should be greater than the longest word's length
			mIterator = java.text.BreakIterator.getWordInstance(locale);
		}

		public virtual void setCharSequence(java.lang.CharSequence charSequence, int start
			, int end)
		{
			mOffsetShift = System.Math.Max(0, start - WINDOW_WIDTH);
			int windowEnd = System.Math.Min(charSequence.Length, end + WINDOW_WIDTH);
			mString = Sharpen.StringHelper.Substring(charSequence.ToString(), mOffsetShift, windowEnd
				);
			mIterator.setText(mString);
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.text.Selection.PositionIterator")]
		public virtual int preceding(int offset)
		{
			int shiftedOffset = offset - mOffsetShift;
			do
			{
				shiftedOffset = mIterator.preceding(shiftedOffset);
				if (shiftedOffset == java.text.BreakIterator.DONE)
				{
					return java.text.BreakIterator.DONE;
				}
				if (isOnLetterOrDigit(shiftedOffset))
				{
					return shiftedOffset + mOffsetShift;
				}
			}
			while (true);
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.text.Selection.PositionIterator")]
		public virtual int following(int offset)
		{
			int shiftedOffset = offset - mOffsetShift;
			do
			{
				shiftedOffset = mIterator.following(shiftedOffset);
				if (shiftedOffset == java.text.BreakIterator.DONE)
				{
					return java.text.BreakIterator.DONE;
				}
				if (isAfterLetterOrDigit(shiftedOffset))
				{
					return shiftedOffset + mOffsetShift;
				}
			}
			while (true);
		}

		/// <summary>
		/// If <code>offset</code> is within a word, returns the index of the first character of that
		/// word, otherwise returns BreakIterator.DONE.
		/// </summary>
		/// <remarks>
		/// If <code>offset</code> is within a word, returns the index of the first character of that
		/// word, otherwise returns BreakIterator.DONE.
		/// The offsets that are considered to be part of a word are the indexes of its characters,
		/// <i>as well as</i> the index of its last character plus one.
		/// If offset is the index of a low surrogate character, BreakIterator.DONE will be returned.
		/// Valid range for offset is [0..textLength] (note the inclusive upper bound).
		/// The returned value is within [0..offset] or BreakIterator.DONE.
		/// </remarks>
		/// <exception cref="System.ArgumentException">is offset is not valid.</exception>
		public virtual int getBeginning(int offset)
		{
			int shiftedOffset = offset - mOffsetShift;
			checkOffsetIsValid(shiftedOffset);
			if (isOnLetterOrDigit(shiftedOffset))
			{
				if (mIterator.isBoundary(shiftedOffset))
				{
					return shiftedOffset + mOffsetShift;
				}
				else
				{
					return mIterator.preceding(shiftedOffset) + mOffsetShift;
				}
			}
			else
			{
				if (isAfterLetterOrDigit(shiftedOffset))
				{
					return mIterator.preceding(shiftedOffset) + mOffsetShift;
				}
			}
			return java.text.BreakIterator.DONE;
		}

		/// <summary>
		/// If <code>offset</code> is within a word, returns the index of the last character of that
		/// word plus one, otherwise returns BreakIterator.DONE.
		/// </summary>
		/// <remarks>
		/// If <code>offset</code> is within a word, returns the index of the last character of that
		/// word plus one, otherwise returns BreakIterator.DONE.
		/// The offsets that are considered to be part of a word are the indexes of its characters,
		/// <i>as well as</i> the index of its last character plus one.
		/// If offset is the index of a low surrogate character, BreakIterator.DONE will be returned.
		/// Valid range for offset is [0..textLength] (note the inclusive upper bound).
		/// The returned value is within [offset..textLength] or BreakIterator.DONE.
		/// </remarks>
		/// <exception cref="System.ArgumentException">is offset is not valid.</exception>
		public virtual int getEnd(int offset)
		{
			int shiftedOffset = offset - mOffsetShift;
			checkOffsetIsValid(shiftedOffset);
			if (isAfterLetterOrDigit(shiftedOffset))
			{
				if (mIterator.isBoundary(shiftedOffset))
				{
					return shiftedOffset + mOffsetShift;
				}
				else
				{
					return mIterator.following(shiftedOffset) + mOffsetShift;
				}
			}
			else
			{
				if (isOnLetterOrDigit(shiftedOffset))
				{
					return mIterator.following(shiftedOffset) + mOffsetShift;
				}
			}
			return java.text.BreakIterator.DONE;
		}

		private bool isAfterLetterOrDigit(int shiftedOffset)
		{
			if (shiftedOffset >= 1 && shiftedOffset <= mString.Length)
			{
				int codePoint = Sharpen.CharHelper.CodePointBefore(mString, shiftedOffset);
				if (Sharpen.CharHelper.IsLetterOrDigit(codePoint))
				{
					return true;
				}
			}
			return false;
		}

		private bool isOnLetterOrDigit(int shiftedOffset)
		{
			if (shiftedOffset >= 0 && shiftedOffset < mString.Length)
			{
				int codePoint = Sharpen.CharHelper.CodePointAt(mString, shiftedOffset);
				if (Sharpen.CharHelper.IsLetterOrDigit(codePoint))
				{
					return true;
				}
			}
			return false;
		}

		private void checkOffsetIsValid(int shiftedOffset)
		{
			if (shiftedOffset < 0 || shiftedOffset > mString.Length)
			{
				throw new System.ArgumentException("Invalid offset: " + (shiftedOffset + mOffsetShift
					) + ". Valid range is [" + mOffsetShift + ", " + (mString.Length + mOffsetShift)
					 + "]");
			}
		}
	}
}
