using Sharpen;

namespace java.io
{
	/// <summary>Thrown when a file specified by a program cannot be found.</summary>
	/// <remarks>Thrown when a file specified by a program cannot be found.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class FileNotFoundException : System.IO.IOException
	{
		internal const long serialVersionUID = -897856973823710492L;

		/// <summary>
		/// Constructs a new
		/// <code>FileNotFoundException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public FileNotFoundException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>FileNotFoundException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public FileNotFoundException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
