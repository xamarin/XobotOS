using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatException</code>
	/// is thrown when a format string that
	/// contains either an illegal syntax or format specifier is transferred as a
	/// parameter. Only subclasses inheriting explicitly from this exception are
	/// allowed to be instantiated.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatException : System.ArgumentException
	{
		internal const long serialVersionUID = 18830826L;

		internal IllegalFormatException()
		{
		}
		// the constructor is not callable from outside from the package
		// do nothing
	}
}
