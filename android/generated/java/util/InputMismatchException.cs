using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>InputMismatchException</code>
	/// is thrown by a scanner to indicate that the
	/// next token does not match or is out of range for the type specified in the
	/// pattern.
	/// </summary>
	/// <seealso cref="Scanner">Scanner</seealso>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InputMismatchException : java.util.NoSuchElementException
	{
		internal const long serialVersionUID = 8811230760997066428L;

		/// <summary>
		/// Constructs a new
		/// <code>InputMismatchException</code>
		/// with the current stack
		/// trace filled in.
		/// </summary>
		public InputMismatchException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>InputMismatchException</code>
		/// with the stack trace
		/// filled in and
		/// <code>msg</code>
		/// as its error message.
		/// </summary>
		/// <param name="msg">the specified error message.</param>
		public InputMismatchException(string msg) : base(msg)
		{
		}
	}
}
