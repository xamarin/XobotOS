using Sharpen;

namespace java.lang
{
	/// <summary>Thrown when a security manager check fails.</summary>
	/// <remarks>Thrown when a security manager check fails.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class SecurityException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 6878364983674394167L;

		/// <summary>
		/// Constructs a new
		/// <code>SecurityException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public SecurityException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>SecurityException</code>
		/// with the current stack trace
		/// and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public SecurityException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>SecurityException</code>
		/// with the current stack trace,
		/// the specified detail message and the specified cause.
		/// </summary>
		/// <param name="message">the detail message for this exception.</param>
		/// <param name="cause">
		/// the optional cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <since>1.5</since>
		public SecurityException(string message, System.Exception cause) : base(message, 
			cause)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>SecurityException</code>
		/// with the current stack trace
		/// and the specified cause.
		/// </summary>
		/// <param name="cause">
		/// the optional cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		/// <since>1.5</since>
		public SecurityException(System.Exception cause) : base((cause == null ? null : cause
			.ToString()), cause)
		{
		}
	}
}
