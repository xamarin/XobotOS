using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when the VM notices that a program tries to reference,
	/// on a class or object, a method that does not exist.
	/// </summary>
	/// <remarks>
	/// Thrown when the VM notices that a program tries to reference,
	/// on a class or object, a method that does not exist.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NoSuchMethodException : System.Exception
	{
		internal const long serialVersionUID = 5034388446362600923L;

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchMethodException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public NoSuchMethodException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchMethodException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NoSuchMethodException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
