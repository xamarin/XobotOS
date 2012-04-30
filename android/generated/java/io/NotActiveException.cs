using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that a serialization-related method has been invoked in the wrong
	/// place.
	/// </summary>
	/// <remarks>
	/// Signals that a serialization-related method has been invoked in the wrong
	/// place. Some methods in
	/// <code>ObjectInputStream</code>
	/// and
	/// <code>ObjectOutputStream</code>
	/// can only be called from a nested call to readObject() or
	/// writeObject(). Any attempt to call them from another context will cause a
	/// <code>NotActiveException</code>
	/// to be thrown. The list of methods that are
	/// protected this way is:
	/// <ul>
	/// <li>
	/// <see cref="ObjectInputStream.defaultReadObject()">ObjectInputStream.defaultReadObject()
	/// 	</see>
	/// </li>
	/// <li>
	/// <see cref="ObjectInputStream.registerValidation(ObjectInputValidation, int)">ObjectInputStream.registerValidation(ObjectInputValidation, int)
	/// 	</see>
	/// </li>
	/// <li>
	/// <see cref="ObjectOutputStream.defaultWriteObject()">ObjectOutputStream.defaultWriteObject()
	/// 	</see>
	/// </li>
	/// </ul>
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NotActiveException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = -3893467273049808895L;

		/// <summary>
		/// Constructs a new
		/// <code>NotActiveException</code>
		/// with its stack trace filled
		/// in.
		/// </summary>
		public NotActiveException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>NotActiveException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NotActiveException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
