using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals a problem during the serialization or or deserialization of an
	/// object.
	/// </summary>
	/// <remarks>
	/// Signals a problem during the serialization or or deserialization of an
	/// object. Possible reasons include:
	/// <ul>
	/// <li>The SUIDs of the class loaded by the VM and the serialized class info do
	/// not match.</li>
	/// <li>A serializable or externalizable object cannot be instantiated (when
	/// deserializing) because the no-arg constructor that needs to be run is not
	/// visible or fails.</li>
	/// </ul>
	/// </remarks>
	/// <seealso cref="ObjectInputStream.readObject()">ObjectInputStream.readObject()</seealso>
	/// <seealso cref="ObjectInputValidation.validateObject()">ObjectInputValidation.validateObject()
	/// 	</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InvalidClassException : java.io.ObjectStreamException
	{
		internal const long serialVersionUID = -4333316296251054416L;

		/// <summary>The fully qualified name of the class that caused the problem.</summary>
		/// <remarks>The fully qualified name of the class that caused the problem.</remarks>
		public string classname;

		/// <summary>
		/// Constructs a new
		/// <code>InvalidClassException</code>
		/// with its stack trace and
		/// detailed message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public InvalidClassException(string detailMessage) : base(detailMessage)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>InvalidClassException</code>
		/// with its stack trace,
		/// detail message and the fully qualified name of the class which caused the
		/// exception filled in.
		/// </summary>
		/// <param name="className">the name of the class that caused the exception.</param>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public InvalidClassException(string className, string detailMessage) : base(detailMessage
			)
		{
			this.classname = className;
		}

		/// <summary>
		/// Returns the detail message which was provided when the exception was
		/// created.
		/// </summary>
		/// <remarks>
		/// Returns the detail message which was provided when the exception was
		/// created.
		/// <code>null</code>
		/// is returned if no message was provided at creation
		/// time. If a detail message as well as a class name are provided, then the
		/// values are concatenated and returned.
		/// </remarks>
		/// <returns>
		/// the detail message, possibly concatenated with the name of the
		/// class that caused the problem.
		/// </returns>
		public override string Message
		{
			get
			{
				string msg = base.Message;
				if (classname != null)
				{
					msg = classname + "; " + msg;
				}
				return msg;
			}
		}
	}
}
