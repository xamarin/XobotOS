using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals some sort of problem during either serialization or deserialization
	/// of objects.
	/// </summary>
	/// <remarks>
	/// Signals some sort of problem during either serialization or deserialization
	/// of objects. This is actually the superclass of several other, more specific
	/// exception classes.
	/// </remarks>
	/// <seealso cref="InvalidObjectException">InvalidObjectException</seealso>
	/// <seealso cref="NotActiveException">NotActiveException</seealso>
	/// <seealso cref="NotSerializableException">NotSerializableException</seealso>
	/// <seealso cref="OptionalDataException">OptionalDataException</seealso>
	/// <seealso cref="StreamCorruptedException">StreamCorruptedException</seealso>
	/// <seealso cref="WriteAbortedException">WriteAbortedException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public abstract class ObjectStreamException : System.IO.IOException
	{
		private const long serialVersionUID = 7260898174833392607L;

		/// <summary>
		/// Constructs a new
		/// <code>ObjectStreamException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public ObjectStreamException ()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>ObjectStreamException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public ObjectStreamException (string detailMessage) : base(detailMessage)
		{
		}

		protected ObjectStreamException (string detailMessage, System.Exception rootCause)
			: base(detailMessage, rootCause)
		{
		}
	}
}
