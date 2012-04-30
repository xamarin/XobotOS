using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>ConcurrentModificationException</code>
	/// is thrown when a Collection is
	/// modified and an existing iterator on the Collection is used to modify the
	/// Collection as well.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ConcurrentModificationException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -3666751008965953603L;

		/// <summary>
		/// Constructs a new
		/// <code>ConcurrentModificationException</code>
		/// with the current
		/// stack trace filled in.
		/// </summary>
		public ConcurrentModificationException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ConcurrentModificationException</code>
		/// with the current
		/// stack trace and message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for the exception.</param>
		public ConcurrentModificationException(string detailMessage) : base(detailMessage
			)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ConcurrentModificationException</code>
		/// with the given detail
		/// message and cause.
		/// </summary>
		/// <since>1.7</since>
		/// <hide>1.7</hide>
		public ConcurrentModificationException(string detailMessage, System.Exception cause
			) : base(detailMessage, cause)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ConcurrentModificationException</code>
		/// with the given cause.
		/// </summary>
		/// <since>1.7</since>
		/// <hide>1.7</hide>
		public ConcurrentModificationException(System.Exception cause) : base(cause)
		{
		}
	}
}
