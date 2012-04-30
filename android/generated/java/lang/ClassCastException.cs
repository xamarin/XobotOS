using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a program attempts to cast a an object to a type with which it is
	/// not compatible.
	/// </summary>
	/// <remarks>
	/// Thrown when a program attempts to cast a an object to a type with which it is
	/// not compatible.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InvalidCastException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -9223365651070458532L;

		/// <summary>
		/// Constructs a new
		/// <code>ClassCastException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public InvalidCastException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ClassCastException</code>
		/// with the current stack trace
		/// and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public InvalidCastException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
