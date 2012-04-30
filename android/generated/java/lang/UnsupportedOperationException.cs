using Sharpen;

namespace java.lang
{
	/// <summary>Thrown when an unsupported operation is attempted.</summary>
	/// <remarks>Thrown when an unsupported operation is attempted.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NotSupportedException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -1242599979055084673L;

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedOperationException</code>
		/// that includes the
		/// current stack trace.
		/// </summary>
		public NotSupportedException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedOperationException</code>
		/// with the current
		/// stack trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NotSupportedException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedOperationException</code>
		/// with the current
		/// stack trace, the specified detail message and the specified cause.
		/// </summary>
		/// <param name="message">the detail message for this exception.</param>
		/// <param name="cause">
		/// the optional cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <since>1.5</since>
		public NotSupportedException(string message, System.Exception cause) : base(message
			, cause)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedOperationException</code>
		/// with the current
		/// stack trace and the specified cause.
		/// </summary>
		/// <param name="cause">
		/// the optional cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <since>1.5</since>
		public NotSupportedException(System.Exception cause) : base((cause == null ? null
			 : cause.ToString()), cause)
		{
		}
	}
}
