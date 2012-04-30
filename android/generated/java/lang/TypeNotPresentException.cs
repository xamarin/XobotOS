using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a program tries to access a class, interface, enum or annotation
	/// type through a string that contains the type's name and the type cannot be
	/// found.
	/// </summary>
	/// <remarks>
	/// Thrown when a program tries to access a class, interface, enum or annotation
	/// type through a string that contains the type's name and the type cannot be
	/// found. This exception is an unchecked alternative to
	/// <see cref="ClassNotFoundException">ClassNotFoundException</see>
	/// .
	/// </remarks>
	/// <since>1.5</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class TypeNotPresentException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = -5101214195716534496L;

		private string _typeName;

		/// <summary>
		/// Constructs a new
		/// <code>TypeNotPresentException</code>
		/// with the current stack
		/// trace, a detail message that includes the name of the type that could not
		/// be found and the
		/// <code>Throwable</code>
		/// that caused this exception.
		/// </summary>
		/// <param name="typeName">the fully qualified name of the type that could not be found.
		/// 	</param>
		/// <param name="cause">
		/// the optional cause of this exception, may be
		/// <code>null</code>
		/// .
		/// </param>
		public TypeNotPresentException(string typeName_1, System.Exception cause) : base(
			"Type " + typeName_1 + " not present", cause)
		{
			this._typeName = typeName_1;
		}

		/// <summary>Gets the fully qualified name of the type that could not be found.</summary>
		/// <remarks>Gets the fully qualified name of the type that could not be found.</remarks>
		/// <returns>the name of the type that caused this exception.</returns>
		public virtual string typeName()
		{
			return _typeName;
		}
	}
}
