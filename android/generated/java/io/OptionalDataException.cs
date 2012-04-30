using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that the
	/// <see cref="ObjectInputStream">ObjectInputStream</see>
	/// class encountered a primitive type
	/// (
	/// <code>int</code>
	/// ,
	/// <code>char</code>
	/// etc.) instead of an object instance in the input
	/// stream.
	/// </summary>
	/// <seealso cref="ObjectInputStream.available()">ObjectInputStream.available()</seealso>
	/// <seealso cref="ObjectInputStream.readObject()">ObjectInputStream.readObject()</seealso>
	/// <seealso cref="ObjectInputStream.skipBytes(int)">ObjectInputStream.skipBytes(int)
	/// 	</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class OptionalDataException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = -8011121865681257820L;

		/// <summary>
		/// <code>true</code>
		/// indicates that there is no more primitive data available.
		/// </summary>
		public bool eof;

		/// <summary>
		/// The number of bytes of primitive data (int, char, long etc.) that are
		/// available.
		/// </summary>
		/// <remarks>
		/// The number of bytes of primitive data (int, char, long etc.) that are
		/// available.
		/// </remarks>
		public int length;

		/// <summary>
		/// Constructs a new
		/// <code>OptionalDataException</code>
		/// with its stack trace
		/// filled in.
		/// </summary>
		internal OptionalDataException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>OptionalDataException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		internal OptionalDataException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
