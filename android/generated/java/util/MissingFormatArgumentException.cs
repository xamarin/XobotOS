using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>MissingFormatArgumentException</code>
	/// will be thrown if there is no
	/// corresponding argument with the specified conversion or an argument index
	/// that refers to a missing argument.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class MissingFormatArgumentException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 19190115L;

		private readonly string s;

		/// <summary>
		/// Constructs a new
		/// <code>MissingFormatArgumentException</code>
		/// with the
		/// specified conversion that lacks the argument.
		/// </summary>
		/// <param name="s">the specified conversion that lacks the argument.</param>
		public MissingFormatArgumentException(string s)
		{
			if (s == null)
			{
				throw new System.ArgumentNullException();
			}
			this.s = s;
		}

		/// <summary>Returns the conversion associated with the exception.</summary>
		/// <remarks>Returns the conversion associated with the exception.</remarks>
		/// <returns>the conversion associated with the exception.</returns>
		public virtual string getFormatSpecifier()
		{
			return s;
		}

		public override string Message
		{
			get
			{
				return "Format specifier: " + s;
			}
		}
	}
}
