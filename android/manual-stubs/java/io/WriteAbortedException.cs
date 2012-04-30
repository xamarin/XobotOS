using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that the
	/// <see cref="ObjectInputStream.readObject()">ObjectInputStream.readObject()</see>
	/// method has detected
	/// an exception marker in the input stream. This marker indicates that exception
	/// occurred when the object was serialized, and this marker was inserted instead
	/// of the original object. It is a way to "propagate" an exception from the code
	/// that attempted to write the object to the code that is attempting to read the
	/// object.
	/// </summary>
	/// <seealso cref="ObjectInputStream.readObject()">ObjectInputStream.readObject()</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class WriteAbortedException : java.io.ObjectStreamException
	{
		private const long serialVersionUID = -3326426625597282442L;

		/// <summary>
		/// Constructs a new
		/// <code>WriteAbortedException</code>
		/// with its stack trace,
		/// detail message and the exception which caused the underlying problem when
		/// serializing the object filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		/// <param name="rootCause">the exception that was thrown when serializing the object.
		/// 	</param>
		public WriteAbortedException (string detailMessage, System.Exception rootCause) :
			base(detailMessage, rootCause)
		{
		}

		/// <summary>
		/// Gets the extra information message which was provided when this exception
		/// was created.
		/// </summary>
		/// <remarks>
		/// Gets the extra information message which was provided when this exception
		/// was created. Returns
		/// <code>null</code>
		/// if no message was provided at creation
		/// time.
		/// </remarks>
		/// <returns>the exception message.</returns>
		public override string Message {
			get {
				string msg = base.Message;
				if (InnerException != null) {
					msg = msg + "; " + InnerException.ToString ();
				}
				return msg;
			}
		}
	}
}
