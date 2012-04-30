using Sharpen;

namespace java.io
{
	/// <summary>Signals that a blocking I/O operation has been interrupted.</summary>
	/// <remarks>
	/// Signals that a blocking I/O operation has been interrupted. The number of
	/// bytes that were transferred successfully before the interruption took place
	/// is stored in a field of the exception.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InterruptedIOException : System.IO.IOException
	{
		internal const long serialVersionUID = 4020568460727500567L;

		/// <summary>The number of bytes transferred before the I/O interrupt occurred.</summary>
		/// <remarks>The number of bytes transferred before the I/O interrupt occurred.</remarks>
		public int bytesTransferred;

		/// <summary>Constructs a new instance.</summary>
		/// <remarks>Constructs a new instance.</remarks>
		public InterruptedIOException()
		{
		}

		/// <summary>Constructs a new instance with the given detail message.</summary>
		/// <remarks>Constructs a new instance with the given detail message.</remarks>
		public InterruptedIOException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>Constructs a new instance with given detail message and cause.</summary>
		/// <remarks>Constructs a new instance with given detail message and cause.</remarks>
		/// <hide>internal use only</hide>
		public InterruptedIOException(string detailMessage, System.Exception cause) : base
			(detailMessage, cause)
		{
		}
	}
}
