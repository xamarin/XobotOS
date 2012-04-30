using Sharpen;

namespace java.lang
{
	/// <summary>Thrown when the an invalid arithmetic operation is attempted.</summary>
	/// <remarks>Thrown when the an invalid arithmetic operation is attempted.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ArithmeticException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 2256477558314496007L;

		/// <summary>
		/// Constructs a new
		/// <code>ArithmeticException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public ArithmeticException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ArithmeticException</code>
		/// with the current stack trace
		/// and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public ArithmeticException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
