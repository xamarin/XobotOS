using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when an invalid value is passed to a string-to-number conversion
	/// method.
	/// </summary>
	/// <remarks>
	/// Thrown when an invalid value is passed to a string-to-number conversion
	/// method.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ArgumentException : System.ArgumentException
	{
		internal const long serialVersionUID = -2848938806368998894L;

		/// <summary>
		/// Constructs a new
		/// <code>NumberFormatException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public ArgumentException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NumberFormatException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public ArgumentException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
