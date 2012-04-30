using Sharpen;

namespace java.text
{
	/// <summary>An interface for the bidirectional iteration over a group of characters.
	/// 	</summary>
	/// <remarks>
	/// An interface for the bidirectional iteration over a group of characters. The
	/// iteration starts at the begin index in the group of characters and continues
	/// to one index before the end index.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface CharacterIterator : System.ICloneable
	{
		/// <summary>
		/// Returns a new
		/// <code>CharacterIterator</code>
		/// with the same properties.
		/// </summary>
		/// <returns>a shallow copy of this character iterator.</returns>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		object Clone();

		/// <summary>Returns the character at the current index.</summary>
		/// <remarks>Returns the character at the current index.</remarks>
		/// <returns>
		/// the current character, or
		/// <code>DONE</code>
		/// if the current index is
		/// past the beginning or end of the sequence.
		/// </returns>
		char current();

		/// <summary>
		/// Sets the current position to the begin index and returns the character at
		/// the new position.
		/// </summary>
		/// <remarks>
		/// Sets the current position to the begin index and returns the character at
		/// the new position.
		/// </remarks>
		/// <returns>the character at the begin index.</returns>
		char first();

		/// <summary>Returns the begin index.</summary>
		/// <remarks>Returns the begin index.</remarks>
		/// <returns>the index of the first character of the iteration.</returns>
		int getBeginIndex();

		/// <summary>Returns the end index.</summary>
		/// <remarks>Returns the end index.</remarks>
		/// <returns>the index one past the last character of the iteration.</returns>
		int getEndIndex();

		/// <summary>Returns the current index.</summary>
		/// <remarks>Returns the current index.</remarks>
		/// <returns>the current index.</returns>
		int getIndex();

		/// <summary>
		/// Sets the current position to the end index - 1 and returns the character
		/// at the new position.
		/// </summary>
		/// <remarks>
		/// Sets the current position to the end index - 1 and returns the character
		/// at the new position.
		/// </remarks>
		/// <returns>the character before the end index.</returns>
		char last();

		/// <summary>Increments the current index and returns the character at the new index.
		/// 	</summary>
		/// <remarks>Increments the current index and returns the character at the new index.
		/// 	</remarks>
		/// <returns>
		/// the character at the next index, or
		/// <code>DONE</code>
		/// if the next
		/// index would be past the end.
		/// </returns>
		char next();

		/// <summary>Decrements the current index and returns the character at the new index.
		/// 	</summary>
		/// <remarks>Decrements the current index and returns the character at the new index.
		/// 	</remarks>
		/// <returns>
		/// the character at the previous index, or
		/// <code>DONE</code>
		/// if the
		/// previous index would be past the beginning.
		/// </returns>
		char previous();

		/// <summary>
		/// Sets the current index to a new position and returns the character at the
		/// new index.
		/// </summary>
		/// <remarks>
		/// Sets the current index to a new position and returns the character at the
		/// new index.
		/// </remarks>
		/// <param name="location">the new index that this character iterator is set to.</param>
		/// <returns>
		/// the character at the new index, or
		/// <code>DONE</code>
		/// if the index is
		/// past the end.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// if
		/// <code>location</code>
		/// is less than the begin index or greater than
		/// the end index.
		/// </exception>
		char setIndex(int location);
	}

	/// <summary>An interface for the bidirectional iteration over a group of characters.
	/// 	</summary>
	/// <remarks>
	/// An interface for the bidirectional iteration over a group of characters. The
	/// iteration starts at the begin index in the group of characters and continues
	/// to one index before the end index.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class CharacterIteratorClass
	{
		/// <summary>
		/// A constant which indicates that there is no character at the current
		/// index.
		/// </summary>
		/// <remarks>
		/// A constant which indicates that there is no character at the current
		/// index.
		/// </remarks>
		public const char DONE = '\uffff';
	}
}
