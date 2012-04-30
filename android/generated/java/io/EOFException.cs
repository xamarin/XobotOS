using Sharpen;

namespace java.io
{
	/// <summary>
	/// Thrown when a program encounters the end of a file or stream during an input
	/// operation.
	/// </summary>
	/// <remarks>
	/// Thrown when a program encounters the end of a file or stream during an input
	/// operation.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class EOFException : System.IO.IOException
	{
		internal const long serialVersionUID = 6433858223774886977L;

		/// <summary>
		/// Constructs a new
		/// <code>EOFException</code>
		/// with its stack trace filled in.
		/// </summary>
		public EOFException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>EOFException</code>
		/// with its stack trace and detail
		/// message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public EOFException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
