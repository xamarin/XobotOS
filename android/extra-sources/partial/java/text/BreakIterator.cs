using System;
using System.Text;
using System.Globalization;
using XobotOS.Text;

namespace java.text
{
	partial class BreakIterator
	{
		/// <summary>
		/// Returns an array of locales for which custom
		/// <code>BreakIterator</code>
		/// instances
		/// are available.
		/// <p>Note that Android does not support user-supplied locale service providers.
		/// </summary>
		public static CultureInfo[] getAvailableLocales ()
		{
			return new CultureInfo[] { CultureInfo.InvariantCulture };
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// characters using the given locale.
		/// </summary>
		/// <param name="where">the given locale.</param>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the given locale.
		/// </returns>
		public static BreakIterator getCharacterInstance (CultureInfo culture)
		{
			return XobotBreakIterator.GetCharacterInstance (culture);
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// line breaks using the given locale.
		/// </summary>
		/// <param name="where">the given locale.</param>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the given locale.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>where</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public static BreakIterator getLineInstance (CultureInfo culture)
		{
			return XobotBreakIterator.GetLineInstance (culture);
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// sentence-breaks using the given locale.
		/// </summary>
		/// <param name="where">the given locale.</param>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the given locale.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>where</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public static BreakIterator getSentenceInstance (CultureInfo culture)
		{
			return XobotBreakIterator.GetSentenceInstance (culture);
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// word-breaks using the given locale.
		/// </summary>
		/// <param name="where">the given locale.</param>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the given locale.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		/// if
		/// <code>where</code>
		/// is
		/// <code>null</code>
		/// .
		/// </exception>
		public static BreakIterator getWordInstance (CultureInfo culture)
		{
			return XobotBreakIterator.GetWordInstance (culture);
		}

		/// <summary>Indicates whether the given offset is a boundary position.</summary>
		/// <remarks>
		/// Indicates whether the given offset is a boundary position. If this method
		/// returns true, the current iteration position is set to the given
		/// position; if the function returns false, the current iteration position
		/// is set as though
		/// <see cref="following(int)">following(int)</see>
		/// had been called.
		/// </remarks>
		/// <param name="offset">the given offset to check.</param>
		/// <returns>
		///
		/// <code>true</code>
		/// if the given offset is a boundary position;
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public abstract bool isBoundary (int offset);

		/// <summary>
		/// Returns the position of last boundary preceding the given offset, and
		/// sets the current position to the returned value, or
		/// <code>DONE</code>
		/// if the
		/// given offset specifies the starting position.
		/// </summary>
		/// <param name="offset">the given start position to be searched for.</param>
		/// <returns>the position of the last boundary preceding the given offset.</returns>
		/// <exception cref="System.ArgumentException">if the offset is invalid.</exception>
		public abstract int preceding (int offset);

		/// <summary>
		/// Sets the new text string to be analyzed, the current position will be
		/// reset to the beginning of this new string, and the old string will be
		/// lost.
		/// </summary>
		/// <remarks>
		/// Sets the new text string to be analyzed, the current position will be
		/// reset to the beginning of this new string, and the old string will be
		/// lost.
		/// </remarks>
		/// <param name="newText">the new text string to be analyzed.</param>
		public void setText (string newText)
		{
			setText (new StringCharacterIterator (newText));
		}

		/// <summary>
		/// Sets the new text to be analyzed by the given
		/// <code>CharacterIterator</code>
		/// .
		/// The position will be reset to the beginning of the new text, and other
		/// status information of this iterator will be kept.
		/// </summary>
		/// <param name="newText">
		/// the
		/// <code>CharacterIterator</code>
		/// referring to the text to be
		/// analyzed.
		/// </param>
		public abstract void setText (CharacterIterator newText);
	}
}

