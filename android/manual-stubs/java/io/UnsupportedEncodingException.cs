using Sharpen;

namespace java.io
{
	/// <summary>
	/// Thrown when a program asks for a particular character converter that is
	/// unavailable.
	/// </summary>
	/// <remarks>
	/// Thrown when a program asks for a particular character converter that is
	/// unavailable.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnsupportedEncodingException : System.IO.IOException
	{
		private const long serialVersionUID = -4274276298326136670L;

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedEncodingException</code>
		/// with its stack
		/// trace filled in.
		/// </summary>
		public UnsupportedEncodingException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedEncodingException</code>
		/// with its stack
		/// trace and detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public UnsupportedEncodingException(string detailMessage) : base(detailMessage)
		{
		}

		public UnsupportedEncodingException(string detailMessage, System.Exception cause)
			: base(detailMessage, cause)
		{
		}
	}
}
