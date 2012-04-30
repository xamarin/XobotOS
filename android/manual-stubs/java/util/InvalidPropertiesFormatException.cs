using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>InvalidPropertiesFormatException</code>
	/// is thrown if loading the XML
	/// document defining the properties does not follow the
	/// <code>Properties</code>
	/// specification.
	/// Even though this Exception inherits the
	/// <code>Serializable</code>
	/// interface, it is not
	/// serializable. The methods used for serialization throw
	/// <code>NotSerializableException</code>
	/// s.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InvalidPropertiesFormatException : System.IO.IOException
	{
		private const long serialVersionUID = 7763056076009360219L;

		/// <summary>
		/// Constructs a new
		/// <code>InvalidPropertiesFormatException</code>
		/// with the
		/// current stack trace and message filled in.
		/// </summary>
		/// <param name="m">the detail message for the exception.</param>
		public InvalidPropertiesFormatException(string m) : base(m)
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>InvalidPropertiesFormatException</code>
		/// with the cause
		/// for the Exception.
		/// </summary>
		/// <param name="c">the cause for the Exception.</param>
		public InvalidPropertiesFormatException(System.Exception c)
			: base("InvalidPropertiesFormat", c)
		{
		}

		/// <exception cref="java.io.NotSerializableException"></exception>
		new private void writeObject(java.io.ObjectOutputStream @out)
		{
			throw new java.io.NotSerializableException();
		}

		/// <exception cref="java.io.NotSerializableException"></exception>
		new private void readObject(java.io.ObjectInputStream @in)
		{
			throw new java.io.NotSerializableException();
		}
	}
}
