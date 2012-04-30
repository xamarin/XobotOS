using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a program attempts to store an element of an incompatible type in
	/// an array.
	/// </summary>
	/// <remarks>
	/// Thrown when a program attempts to store an element of an incompatible type in
	/// an array.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class ArrayStoreException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -4522193890499838241L;

		/// <summary>
		/// Constructs a new
		/// <code>ArrayStoreException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public ArrayStoreException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ArrayStoreException</code>
		/// with the current stack trace
		/// and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public ArrayStoreException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
