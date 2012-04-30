using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when an action is attempted at a time when the VM is not
	/// in the correct state.
	/// </summary>
	/// <remarks>
	/// Thrown when an action is attempted at a time when the VM is not
	/// in the correct state.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InvalidOperationException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -1848914673093119416L;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalStateException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public InvalidOperationException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IllegalStateException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public InvalidOperationException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IllegalStateException</code>
		/// with the current stack
		/// trace, the specified detail message and the specified cause.
		/// </summary>
		/// <param name="message">the detail message for this exception.</param>
		/// <param name="cause">the cause of this exception.</param>
		/// <since>1.5</since>
		public InvalidOperationException(string message, System.Exception cause) : base(message
			, cause)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IllegalStateException</code>
		/// with the current stack
		/// trace and the specified cause.
		/// </summary>
		/// <param name="cause">
		/// the cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <since>1.5</since>
		public InvalidOperationException(System.Exception cause) : base((cause == null ? 
			null : cause.ToString()), cause)
		{
		}
	}
}
