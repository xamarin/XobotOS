using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that an object that is not serializable has been passed into the
	/// <code>ObjectOutput.writeObject()</code>
	/// method. This can happen if the object
	/// does not implement
	/// <code>Serializable</code>
	/// or
	/// <code>Externalizable</code>
	/// , or if it
	/// is serializable but it overrides
	/// <code>writeObject(ObjectOutputStream)</code>
	/// and
	/// explicitly prevents serialization by throwing this type of exception.
	/// </summary>
	/// <seealso cref="ObjectOutput.writeObject(object)">ObjectOutput.writeObject(object)
	/// 	</seealso>
	/// <seealso cref="ObjectOutputStream.writeObject(object)">ObjectOutputStream.writeObject(object)
	/// 	</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class NotSerializableException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = 2906642554793891381L;

		/// <summary>
		/// Constructs a new
		/// <code>NotSerializableException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public NotSerializableException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <see cref="NotSerializableException">NotSerializableException</see>
		/// with its stack trace
		/// and detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public NotSerializableException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
