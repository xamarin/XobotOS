using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when an operation is attempted which is not possible given the state
	/// that the executing thread is in.
	/// </summary>
	/// <remarks>
	/// Thrown when an operation is attempted which is not possible given the state
	/// that the executing thread is in.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalThreadStateException : System.ArgumentException
	{
		internal const long serialVersionUID = -7626246362397460174L;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalThreadStateException</code>
		/// that includes the
		/// current stack trace.
		/// </summary>
		public IllegalThreadStateException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IllegalThreadStateException</code>
		/// with the current
		/// stack trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public IllegalThreadStateException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
