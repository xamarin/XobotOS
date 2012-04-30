using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when the a string is indexed with a value less than zero, or greater
	/// than or equal to the size of the array.
	/// </summary>
	/// <remarks>
	/// Thrown when the a string is indexed with a value less than zero, or greater
	/// than or equal to the size of the array.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class StringIndexOutOfBoundsException : System.Exception
	{
		private const long serialVersionUID = -6762910422159637258L;

		/// <summary>
		/// Constructs a new
		/// <code>StringIndexOutOfBoundsException</code>
		/// that includes
		/// the current stack trace.
		/// </summary>
		public StringIndexOutOfBoundsException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>StringIndexOutOfBoundsException</code>
		/// with the current
		/// stack trace and a detail message that is based on the specified invalid
		/// <code>index</code>
		/// .
		/// </summary>
		/// <param name="index">the index which is out of bounds.</param>
		public StringIndexOutOfBoundsException(int index) : base("String index out of range: "
			 + index)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>StringIndexOutOfBoundsException</code>
		/// with the current
		/// stack trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public StringIndexOutOfBoundsException(string detailMessage) : base(detailMessage
			)
		{
		}

		/// <summary>Used internally for consistent high-quality error reporting.</summary>
		/// <remarks>Used internally for consistent high-quality error reporting.</remarks>
		/// <hide></hide>
		public StringIndexOutOfBoundsException(string s, int index) : this(s.Length, index
			)
		{
		}

		/// <summary>Used internally for consistent high-quality error reporting.</summary>
		/// <remarks>Used internally for consistent high-quality error reporting.</remarks>
		/// <hide></hide>
		public StringIndexOutOfBoundsException(int sourceLength, int index) : base("length="
			 + sourceLength + "; index=" + index)
		{
		}

		/// <summary>Used internally for consistent high-quality error reporting.</summary>
		/// <remarks>Used internally for consistent high-quality error reporting.</remarks>
		/// <hide></hide>
		public StringIndexOutOfBoundsException(string s, int offset, int count) : this(s.
			Length, offset, count)
		{
		}

		/// <summary>Used internally for consistent high-quality error reporting.</summary>
		/// <remarks>Used internally for consistent high-quality error reporting.</remarks>
		/// <hide></hide>
		public StringIndexOutOfBoundsException(int sourceLength, int offset, int count) : 
			base("length=" + sourceLength + "; regionStart=" + offset + "; regionLength=" + 
			count)
		{
		}
	}
}
