using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when an attempt is made to create an array with a size of less than
	/// zero.
	/// </summary>
	/// <remarks>
	/// Thrown when an attempt is made to create an array with a size of less than
	/// zero.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NegativeArraySizeException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -8960118058596991861L;

		/// <summary>
		/// Constructs a new
		/// <code>NegativeArraySizeException</code>
		/// that includes the
		/// current stack trace.
		/// </summary>
		public NegativeArraySizeException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NegativeArraySizeException</code>
		/// with the current
		/// stack trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NegativeArraySizeException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
