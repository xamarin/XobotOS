using Sharpen;

namespace java.util
{
	/// <summary>
	/// Thrown when trying to retrieve an element
	/// past the end of an Enumeration or Iterator.
	/// </summary>
	/// <remarks>
	/// Thrown when trying to retrieve an element
	/// past the end of an Enumeration or Iterator.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NoSuchElementException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 6769829250639411880L;

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchElementException</code>
		/// with the current stack
		/// trace filled in.
		/// </summary>
		public NoSuchElementException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchElementException</code>
		/// with the current stack
		/// trace and message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for the exception.</param>
		public NoSuchElementException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
