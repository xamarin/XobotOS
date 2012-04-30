using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>MissingFormatWidthException</code>
	/// will be thrown if the format width is
	/// missing but is required.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class MissingFormatWidthException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 15560123L;

		private readonly string s;

		/// <summary>
		/// Constructs a new
		/// <code>MissingFormatWidthException</code>
		/// with the specified
		/// format specifier.
		/// </summary>
		/// <param name="s">the specified format specifier.</param>
		public MissingFormatWidthException(string s)
		{
			if (s == null)
			{
				throw new System.ArgumentNullException();
			}
			this.s = s;
		}

		/// <summary>Returns the format specifier associated with the exception.</summary>
		/// <remarks>Returns the format specifier associated with the exception.</remarks>
		/// <returns>the format specifier associated with the exception.</returns>
		public virtual string getFormatSpecifier()
		{
			return s;
		}

		public override string Message
		{
			get
			{
				return s;
			}
		}
	}
}
