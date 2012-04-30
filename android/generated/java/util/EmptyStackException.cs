using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>EmptyStackException</code>
	/// is thrown if the pop/peek method of a stack is
	/// executed on an empty stack.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class EmptyStackException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 5084686378493302095L;

		/// <summary>
		/// Constructs a new
		/// <code>EmptyStackException</code>
		/// with the stack trace filled
		/// in.
		/// </summary>
		public EmptyStackException()
		{
		}
	}
}
