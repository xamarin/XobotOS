using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a program attempts to clone an object which does not support the
	/// <see cref="ICloneable">ICloneable</see>
	/// interface.
	/// </summary>
	/// <seealso cref="ICloneable">ICloneable</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class CloneNotSupportedException : System.Exception
	{
		internal const long serialVersionUID = 5195511250079656443L;

		/// <summary>
		/// Constructs a new
		/// <code>CloneNotSupportedException</code>
		/// that includes the
		/// current stack trace.
		/// </summary>
		public CloneNotSupportedException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>CloneNotSupportedException</code>
		/// with the current
		/// stack trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public CloneNotSupportedException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
