using Sharpen;

namespace java.text
{
	/// <summary>Locates boundaries in text.</summary>
	/// <remarks>
	/// Locates boundaries in text. This class defines a protocol for objects that
	/// break up a piece of natural-language text according to a set of criteria.
	/// Instances or subclasses of
	/// <code>BreakIterator</code>
	/// can be provided, for
	/// example, to break a piece of text into words, sentences, or logical
	/// characters according to the conventions of some language or group of
	/// languages. We provide four built-in types of
	/// <code>BreakIterator</code>
	/// :
	/// <ul>
	/// <li>
	/// <see cref="getSentenceInstance()">getSentenceInstance()</see>
	/// returns a
	/// <code>BreakIterator</code>
	/// that
	/// locates boundaries between sentences. This is useful for triple-click
	/// selection, for example.</li>
	/// <li>
	/// <see cref="getWordInstance()">getWordInstance()</see>
	/// returns a
	/// <code>BreakIterator</code>
	/// that locates
	/// boundaries between words. This is useful for double-click selection or "find
	/// whole words" searches. This type of
	/// <code>BreakIterator</code>
	/// makes sure there is
	/// a boundary position at the beginning and end of each legal word (numbers
	/// count as words, too). Whitespace and punctuation are kept separate from real
	/// words.</li>
	/// <li>
	/// <code>getLineInstance()</code>
	/// returns a
	/// <code>BreakIterator</code>
	/// that locates
	/// positions where it is legal for a text editor to wrap lines. This is similar
	/// to word breaking, but not the same: punctuation and whitespace are generally
	/// kept with words (you don't want a line to start with whitespace, for
	/// example), and some special characters can force a position to be considered a
	/// line break position or prevent a position from being a line break position.</li>
	/// <li>
	/// <code>getCharacterInstance()</code>
	/// returns a
	/// <code>BreakIterator</code>
	/// that
	/// locates boundaries between logical characters. Because of the structure of
	/// the Unicode encoding, a logical character may be stored internally as more
	/// than one Unicode code point. (A with an umlaut may be stored as an a followed
	/// by a separate combining umlaut character, for example, but the user still
	/// thinks of it as one character.) This iterator allows various processes
	/// (especially text editors) to treat as characters the units of text that a
	/// user would think of as characters, rather than the units of text that the
	/// computer sees as "characters".</li>
	/// </ul>
	/// <code>BreakIterator</code>
	/// 's interface follows an "iterator" model (hence
	/// the name), meaning it has a concept of a "current position" and methods like
	/// <code>first()</code>
	/// ,
	/// <code>last()</code>
	/// ,
	/// <code>next()</code>
	/// , and
	/// <code>previous()</code>
	/// that
	/// update the current position. All
	/// <code>BreakIterator</code>
	/// s uphold the following
	/// invariants:
	/// <ul>
	/// <li>The beginning and end of the text are always treated as boundary
	/// positions.</li>
	/// <li>The current position of the iterator is always a boundary position
	/// (random- access methods move the iterator to the nearest boundary position
	/// before or after the specified position, not <i>to</i> the specified
	/// position).</li>
	/// <li>
	/// <code>DONE</code>
	/// is used as a flag to indicate when iteration has stopped.
	/// <code>DONE</code>
	/// is only returned when the current position is the end of the
	/// text and the user calls
	/// <code>next()</code>
	/// , or when the current position is the
	/// beginning of the text and the user calls
	/// <code>previous()</code>
	/// .</li>
	/// <li>Break positions are numbered by the positions of the characters that
	/// follow them. Thus, under normal circumstances, the position before the first
	/// character is 0, the position after the first character is 1, and the position
	/// after the last character is 1 plus the length of the string.</li>
	/// <li>The client can change the position of an iterator, or the text it
	/// analyzes, at will, but cannot change the behavior. If the user wants
	/// different behavior, he must instantiate a new iterator.</li>
	/// </ul>
	/// <p>
	/// <code>BreakIterator</code>
	/// accesses the text it analyzes through a
	/// <see cref="CharacterIterator">CharacterIterator</see>
	/// , which makes it possible to use
	/// <code>BreakIterator</code>
	/// to analyze text in any text-storage vehicle that provides a
	/// <code>CharacterIterator</code>
	/// interface.
	/// <p>
	/// <em>Note:</em> Some types of
	/// <code>BreakIterator</code>
	/// can take a long time to
	/// create, and instances of
	/// <code>BreakIterator</code>
	/// are not currently cached by
	/// the system. For optimal performance, keep instances of
	/// <code>BreakIterator</code>
	/// around as long as it makes sense. For example, when word-wrapping a document,
	/// don't create and destroy a new
	/// <code>BreakIterator</code>
	/// for each line. Create
	/// one break iterator for the whole document (or whatever stretch of text you're
	/// wrapping) and use it to do the whole job of wrapping the text.
	/// <p>
	/// <em>Examples</em>:
	/// <p>
	/// Creating and using text boundaries:
	/// <blockquote>
	/// <pre>
	/// public static void main(String args[]) {
	/// if (args.length == 1) {
	/// String stringToExamine = args[0];
	/// //print each word in order
	/// BreakIterator boundary = BreakIterator.getWordInstance();
	/// boundary.setText(stringToExamine);
	/// printEachForward(boundary, stringToExamine);
	/// //print each sentence in reverse order
	/// boundary = BreakIterator.getSentenceInstance(Locale.US);
	/// boundary.setText(stringToExamine);
	/// printEachBackward(boundary, stringToExamine);
	/// printFirst(boundary, stringToExamine);
	/// printLast(boundary, stringToExamine);
	/// }
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Print each element in order:
	/// <blockquote>
	/// <pre>
	/// public static void printEachForward(BreakIterator boundary, String source) {
	/// int start = boundary.first();
	/// for (int end = boundary.next(); end != BreakIterator.DONE; start = end, end = boundary.next()) {
	/// System.out.println(source.substring(start, end));
	/// }
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Print each element in reverse order:
	/// <blockquote>
	/// <pre>
	/// public static void printEachBackward(BreakIterator boundary, String source) {
	/// int end = boundary.last();
	/// for (int start = boundary.previous(); start != BreakIterator.DONE; end = start, start = boundary
	/// .previous()) {
	/// System.out.println(source.substring(start, end));
	/// }
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Print the first element:
	/// <blockquote>
	/// <pre>
	/// public static void printFirst(BreakIterator boundary, String source) {
	/// int start = boundary.first();
	/// int end = boundary.next();
	/// System.out.println(source.substring(start, end));
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Print the last element:
	/// <blockquote>
	/// <pre>
	/// public static void printLast(BreakIterator boundary, String source) {
	/// int end = boundary.last();
	/// int start = boundary.previous();
	/// System.out.println(source.substring(start, end));
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Print the element at a specified position:
	/// <blockquote>
	/// <pre>
	/// public static void printAt(BreakIterator boundary, int pos, String source) {
	/// int end = boundary.following(pos);
	/// int start = boundary.previous();
	/// System.out.println(source.substring(start, end));
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// Find the next word:
	/// <blockquote>
	/// <pre>
	/// public static int nextWordStartAfter(int pos, String text) {
	/// BreakIterator wb = BreakIterator.getWordInstance();
	/// wb.setText(text);
	/// int last = wb.following(pos);
	/// int current = wb.next();
	/// while (current != BreakIterator.DONE) {
	/// for (int p = last; p &lt; current; p++) {
	/// if (Character.isLetter(text.charAt(p)))
	/// return last;
	/// }
	/// last = current;
	/// current = wb.next();
	/// }
	/// return BreakIterator.DONE;
	/// }
	/// </pre>
	/// </blockquote>
	/// <p>
	/// The iterator returned by
	/// <code>BreakIterator.getWordInstance()</code>
	/// is unique in
	/// that the break positions it returns don't represent both the start and end of
	/// the thing being iterated over. That is, a sentence-break iterator returns
	/// breaks that each represent the end of one sentence and the beginning of the
	/// next. With the word-break iterator, the characters between two boundaries
	/// might be a word, or they might be the punctuation or whitespace between two
	/// words. The above code uses a simple heuristic to determine which boundary is
	/// the beginning of a word: If the characters between this boundary and the next
	/// boundary include at least one letter (this can be an alphabetical letter, a
	/// CJK ideograph, a Hangul syllable, a Kana character, etc.), then the text
	/// between this boundary and the next is a word; otherwise, it's the material
	/// between words.)
	/// </remarks>
	/// <seealso cref="CharacterIterator">CharacterIterator</seealso>
	[Sharpen.Sharpened]
	public abstract partial class BreakIterator : System.ICloneable
	{
		/// <summary>
		/// This constant is returned by iterate methods like
		/// <code>previous()</code>
		/// or
		/// <code>next()</code>
		/// if they have returned all valid boundaries.
		/// </summary>
		public const int DONE = -1;

		// the wrapped ICU implementation
		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// characters using the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the default locale.
		/// </returns>
		public static java.text.BreakIterator getCharacterInstance()
		{
			return getCharacterInstance(System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns a new instance of {
		/// <code>BreakIterator</code>
		/// to iterate over
		/// line breaks using the user's default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the default locale.
		/// </returns>
		public static java.text.BreakIterator getLineInstance()
		{
			return getLineInstance(System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// sentence-breaks using the default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the default locale.
		/// </returns>
		public static java.text.BreakIterator getSentenceInstance()
		{
			return getSentenceInstance(System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns a new instance of
		/// <code>BreakIterator</code>
		/// to iterate over
		/// word-breaks using the default locale.
		/// See "<a href="../util/Locale.html#default_locale">Be wary of the default locale</a>".
		/// </summary>
		/// <returns>
		/// a new instance of
		/// <code>BreakIterator</code>
		/// using the default locale.
		/// </returns>
		public static java.text.BreakIterator getWordInstance()
		{
			return getWordInstance(System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>Returns this iterator's current position.</summary>
		/// <remarks>Returns this iterator's current position.</remarks>
		/// <returns>this iterator's current position.</returns>
		public abstract int current();

		/// <summary>
		/// Sets this iterator's current position to the first boundary and returns
		/// that position.
		/// </summary>
		/// <remarks>
		/// Sets this iterator's current position to the first boundary and returns
		/// that position.
		/// </remarks>
		/// <returns>the position of the first boundary.</returns>
		public abstract int first();

		/// <summary>
		/// Sets the position of the first boundary to the one following the given
		/// offset and returns this position.
		/// </summary>
		/// <remarks>
		/// Sets the position of the first boundary to the one following the given
		/// offset and returns this position. Returns
		/// <code>DONE</code>
		/// if there is no
		/// boundary after the given offset.
		/// </remarks>
		/// <param name="offset">the given position to be searched for.</param>
		/// <returns>the position of the first boundary following the given offset.</returns>
		/// <exception cref="System.ArgumentException">if the offset is invalid.</exception>
		public abstract int following(int offset);

		/// <summary>
		/// Returns a
		/// <code>CharacterIterator</code>
		/// which represents the text being
		/// analyzed. Please note that the returned value is probably the internal
		/// iterator used by this object. If the invoker wants to modify the status
		/// of the returned iterator, it is recommended to first create a clone of
		/// the iterator returned.
		/// </summary>
		/// <returns>
		/// a
		/// <code>CharacterIterator</code>
		/// which represents the text being
		/// analyzed.
		/// </returns>
		public abstract java.text.CharacterIterator getText();

		/// <summary>
		/// Sets this iterator's current position to the last boundary and returns
		/// that position.
		/// </summary>
		/// <remarks>
		/// Sets this iterator's current position to the last boundary and returns
		/// that position.
		/// </remarks>
		/// <returns>the position of last boundary.</returns>
		public abstract int last();

		/// <summary>
		/// Sets this iterator's current position to the next boundary after the
		/// current position, and returns this position.
		/// </summary>
		/// <remarks>
		/// Sets this iterator's current position to the next boundary after the
		/// current position, and returns this position. Returns
		/// <code>DONE</code>
		/// if no
		/// boundary was found after the current position.
		/// </remarks>
		/// <returns>the position of last boundary.</returns>
		public abstract int next();

		/// <summary>
		/// Sets this iterator's current position to the next boundary after the
		/// given position, and returns that position.
		/// </summary>
		/// <remarks>
		/// Sets this iterator's current position to the next boundary after the
		/// given position, and returns that position. Returns
		/// <code>DONE</code>
		/// if no
		/// boundary was found after the given position.
		/// </remarks>
		/// <param name="n">the given position.</param>
		/// <returns>the position of last boundary.</returns>
		public abstract int next(int n);

		/// <summary>
		/// Sets this iterator's current position to the previous boundary before the
		/// current position and returns that position.
		/// </summary>
		/// <remarks>
		/// Sets this iterator's current position to the previous boundary before the
		/// current position and returns that position. Returns
		/// <code>DONE</code>
		/// if
		/// no boundary was found before the current position.
		/// </remarks>
		/// <returns>the position of last boundary.</returns>
		public abstract int previous();

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
