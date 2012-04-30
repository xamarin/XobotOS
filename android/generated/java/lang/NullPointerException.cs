using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a program tries to access a field or method of an object or an
	/// element of an array when there is no instance or array to use, that is if the
	/// object or array points to
	/// <code>null</code>
	/// . It also occurs in some other, less
	/// obvious circumstances, like a
	/// <code>throw e</code>
	/// statement where the
	/// <see cref="Exception">Exception</see>
	/// reference is
	/// <code>null</code>
	/// .
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ArgumentNullException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 5162710183389028792L;

		/// <summary>
		/// Constructs a new
		/// <code>NullPointerException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public ArgumentNullException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NullPointerException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public ArgumentNullException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
