using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that an incorrectly encoded UTF-8 string has been encountered, most
	/// likely while reading some
	/// <see cref="DataInputStream">DataInputStream</see>
	/// .
	/// </summary>
	/// <seealso cref="DataInputStream.readUTF()">DataInputStream.readUTF()</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UTFDataFormatException : System.IO.IOException
	{
		internal const long serialVersionUID = 420743449228280612L;

		/// <summary>
		/// Constructs a new
		/// <code>UTFDataFormatException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public UTFDataFormatException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UTFDataFormatException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public UTFDataFormatException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
