using Sharpen;

namespace java.io
{
	/// <summary>Signals that, during deserialization, the validation of an object has failed.
	/// 	</summary>
	/// <remarks>Signals that, during deserialization, the validation of an object has failed.
	/// 	</remarks>
	/// <seealso cref="ObjectInputStream.registerValidation(ObjectInputValidation, int)">ObjectInputStream.registerValidation(ObjectInputValidation, int)
	/// 	</seealso>
	/// <seealso cref="ObjectInputValidation.validateObject()">ObjectInputValidation.validateObject()
	/// 	</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InvalidObjectException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = 3233174318281839583L;

		/// <summary>
		/// Constructs an
		/// <code>InvalidObjectException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public InvalidObjectException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
