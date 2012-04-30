using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>TooManyListenersException</code>
	/// is thrown when an attempt is made to add
	/// more than one listener to an event source which only supports a single
	/// listener. It is also thrown when the same listener is added more than once.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class TooManyListenersException : System.Exception
	{
		internal const long serialVersionUID = 5074640544770687831L;

		/// <summary>
		/// Constructs a new
		/// <code>TooManyListenersException</code>
		/// with the current stack
		/// trace filled in.
		/// </summary>
		public TooManyListenersException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>TooManyListenersException</code>
		/// with the stack trace
		/// and message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for the exception.</param>
		public TooManyListenersException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
