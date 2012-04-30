using Sharpen;

namespace java.util
{
	/// <summary>
	/// A
	/// <code>FormatterClosedException</code>
	/// will be thrown if the formatter has been
	/// closed.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class FormatterClosedException : System.InvalidOperationException
	{
		internal const long serialVersionUID = 18111216L;

		/// <summary>
		/// Constructs a new
		/// <code>FormatterClosedException</code>
		/// with the stack trace
		/// filled in.
		/// </summary>
		public FormatterClosedException()
		{
		}
	}
}
