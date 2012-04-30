using Sharpen;

namespace java.util.regex
{
	/// <summary>
	/// Encapsulates a syntax error that occurred during the compilation of a
	/// <see cref="Pattern">Pattern</see>
	/// . Might include a detailed description, the original regular
	/// expression, and the index at which the error occurred.
	/// </summary>
	/// <seealso cref="Pattern.compile(string)">Pattern.compile(string)</seealso>
	/// <seealso cref="Pattern.compile(string, int)">Pattern.compile(string, int)</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class PatternSyntaxException : System.ArgumentException
	{
		internal const long serialVersionUID = -3864639126226059218L;

		/// <summary>
		/// Holds the description of the syntax error, or null if the description is
		/// not known.
		/// </summary>
		/// <remarks>
		/// Holds the description of the syntax error, or null if the description is
		/// not known.
		/// </remarks>
		private string desc;

		/// <summary>
		/// Holds the syntactically incorrect regular expression, or null if the
		/// regular expression is not known.
		/// </summary>
		/// <remarks>
		/// Holds the syntactically incorrect regular expression, or null if the
		/// regular expression is not known.
		/// </remarks>
		private string pattern;

		/// <summary>
		/// Holds the index around which the error occured, or -1, in case it is
		/// unknown.
		/// </summary>
		/// <remarks>
		/// Holds the index around which the error occured, or -1, in case it is
		/// unknown.
		/// </remarks>
		private int index = -1;

		/// <summary>
		/// Creates a new PatternSyntaxException for a given message, pattern, and
		/// error index.
		/// </summary>
		/// <remarks>
		/// Creates a new PatternSyntaxException for a given message, pattern, and
		/// error index.
		/// </remarks>
		/// <param name="description">
		/// the description of the syntax error, or
		/// <code>null</code>
		/// if the
		/// description is not known.
		/// </param>
		/// <param name="pattern">
		/// the syntactically incorrect regular expression, or
		/// <code>null</code>
		/// if the regular expression is not known.
		/// </param>
		/// <param name="index">
		/// the character index around which the error occurred, or -1 if
		/// the index is not known.
		/// </param>
		public PatternSyntaxException(string description, string pattern, int index)
		{
			this.desc = description;
			this.pattern = pattern;
			this.index = index;
		}

		/// <summary>Returns the syntactically incorrect regular expression.</summary>
		/// <remarks>Returns the syntactically incorrect regular expression.</remarks>
		/// <returns>the regular expression.</returns>
		public virtual string getPattern()
		{
			return pattern;
		}

		/// <summary>Returns a detailed error message for the exception.</summary>
		/// <remarks>
		/// Returns a detailed error message for the exception. The message is
		/// potentially multi-line, and it might include a detailed description, the
		/// original regular expression, and the index at which the error occurred.
		/// </remarks>
		/// <returns>the error message.</returns>
		public override string Message
		{
			get
			{
				java.lang.StringBuilder sb = new java.lang.StringBuilder();
				if (desc != null)
				{
					sb.append(desc);
				}
				if (index >= 0)
				{
					if (desc != null)
					{
						sb.append(' ');
					}
					sb.append("near index ");
					sb.append(index);
					sb.append(':');
				}
				if (pattern != null)
				{
					sb.append('\n');
					sb.append(pattern);
					if (index >= 0)
					{
						char[] spaces = new char[index];
						java.util.Arrays.fill(spaces, ' ');
						sb.append('\n');
						sb.append(spaces);
						sb.append('^');
					}
				}
				return sb.ToString();
			}
		}

		/// <summary>
		/// Returns the description of the syntax error, or
		/// <code>null</code>
		/// if the
		/// description is not known.
		/// </summary>
		/// <returns>the description.</returns>
		public virtual string getDescription()
		{
			return desc;
		}

		/// <summary>
		/// Returns the character index around which the error occurred, or -1 if the
		/// index is not known.
		/// </summary>
		/// <remarks>
		/// Returns the character index around which the error occurred, or -1 if the
		/// index is not known.
		/// </remarks>
		/// <returns>the index.</returns>
		public virtual int getIndex()
		{
			return index;
		}
	}
}
