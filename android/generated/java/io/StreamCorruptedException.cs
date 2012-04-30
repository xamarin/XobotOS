using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that the
	/// <see cref="ObjectInputStream.readObject()">ObjectInputStream.readObject()</see>
	/// method could not
	/// read an object due to missing information (for example, a cyclic reference
	/// that doesn't match a previous instance, or a missing class descriptor for the
	/// object to be loaded).
	/// </summary>
	/// <seealso cref="ObjectInputStream">ObjectInputStream</seealso>
	/// <seealso cref="OptionalDataException">OptionalDataException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class StreamCorruptedException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = 8983558202217591746L;

		/// <summary>
		/// Constructs a new
		/// <code>StreamCorruptedException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		public StreamCorruptedException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>StreamCorruptedException</code>
		/// with its stack trace
		/// and detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public StreamCorruptedException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
