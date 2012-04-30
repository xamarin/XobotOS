using Sharpen;

namespace java.util.regex
{
	/// <summary>
	/// Holds the results of a successful match of a
	/// <see cref="Pattern">Pattern</see>
	/// against a
	/// given string. The result is divided into groups, with one group for each
	/// pair of parentheses in the regular expression and an additional group for
	/// the whole regular expression. The start, end, and contents of each group
	/// can be queried.
	/// </summary>
	/// <seealso cref="Matcher">Matcher</seealso>
	/// <seealso cref="Matcher.toMatchResult()">Matcher.toMatchResult()</seealso>
	[Sharpen.Sharpened]
	public interface MatchResult
	{
		/// <summary>
		/// Returns the index of the first character following the text that matched
		/// the whole regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character following the text that matched
		/// the whole regular expression.
		/// </remarks>
		/// <returns>the character index.</returns>
		int end();

		/// <summary>
		/// Returns the index of the first character following the text that matched
		/// a given group.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character following the text that matched
		/// a given group.
		/// </remarks>
		/// <param name="group">
		/// the group, ranging from 0 to groupCount() - 1, with 0
		/// representing the whole pattern.
		/// </param>
		/// <returns>the character index.</returns>
		int end(int group_1);

		/// <summary>Returns the text that matched the whole regular expression.</summary>
		/// <remarks>Returns the text that matched the whole regular expression.</remarks>
		/// <returns>the text.</returns>
		string group();

		/// <summary>Returns the text that matched a given group of the regular expression.</summary>
		/// <remarks>Returns the text that matched a given group of the regular expression.</remarks>
		/// <param name="group">
		/// the group, ranging from 0 to groupCount() - 1, with 0
		/// representing the whole pattern.
		/// </param>
		/// <returns>the text that matched the group.</returns>
		string group(int group_1);

		/// <summary>
		/// Returns the number of groups in the result, which is always equal to
		/// the number of groups in the original regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the number of groups in the result, which is always equal to
		/// the number of groups in the original regular expression.
		/// </remarks>
		/// <returns>the number of groups.</returns>
		int groupCount();

		/// <summary>
		/// Returns the index of the first character of the text that matched
		/// the whole regular expression.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character of the text that matched
		/// the whole regular expression.
		/// </remarks>
		/// <returns>the character index.</returns>
		int start();

		/// <summary>
		/// Returns the index of the first character of the text that matched a given
		/// group.
		/// </summary>
		/// <remarks>
		/// Returns the index of the first character of the text that matched a given
		/// group.
		/// </remarks>
		/// <param name="group">
		/// the group, ranging from 0 to groupCount() - 1, with 0
		/// representing the whole pattern.
		/// </param>
		/// <returns>the character index.</returns>
		int start(int group_1);
	}
}
