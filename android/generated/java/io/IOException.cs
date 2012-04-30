using Sharpen;

namespace java.io
{
	/// <summary>Signals a general, I/O-related error.</summary>
	/// <remarks>
	/// Signals a general, I/O-related error. Error details may be specified when
	/// calling the constructor, as usual. Note there are also several subclasses of
	/// this class for more specific error situations, such as
	/// <see cref="FileNotFoundException">FileNotFoundException</see>
	/// or
	/// <see cref="EOFException">EOFException</see>
	/// .
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IOException : System.Exception
	{
		internal const long serialVersionUID = 7818375828146090155L;

		/// <summary>
		/// Constructs a new
		/// <code>IOException</code>
		/// with its stack trace filled in.
		/// </summary>
		public IOException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IOException</code>
		/// with its stack trace and detail
		/// message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public IOException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new instance of this class with detail message and cause
		/// filled in.
		/// </summary>
		/// <remarks>
		/// Constructs a new instance of this class with detail message and cause
		/// filled in.
		/// </remarks>
		/// <param name="message">The detail message for the exception.</param>
		/// <param name="cause">The detail cause for the exception.</param>
		/// <since>1.6</since>
		public IOException(string message, System.Exception cause) : base(message, cause)
		{
		}

		/// <summary>Constructs a new instance of this class with its detail cause filled in.
		/// 	</summary>
		/// <remarks>Constructs a new instance of this class with its detail cause filled in.
		/// 	</remarks>
		/// <param name="cause">The detail cause for the exception.</param>
		/// <since>1.6</since>
		public IOException(System.Exception cause) : base(cause == null ? null : cause.ToString
			(), cause)
		{
		}
	}
}
