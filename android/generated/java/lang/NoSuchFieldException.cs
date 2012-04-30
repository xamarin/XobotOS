using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when the VM notices that a program tries to reference,
	/// on a class or object, a field that does not exist.
	/// </summary>
	/// <remarks>
	/// Thrown when the VM notices that a program tries to reference,
	/// on a class or object, a field that does not exist.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NoSuchFieldException : System.Exception
	{
		internal const long serialVersionUID = -6143714805279938260L;

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchFieldException</code>
		/// that includes the current
		/// stack trace.
		/// </summary>
		public NoSuchFieldException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NoSuchFieldException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NoSuchFieldException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
