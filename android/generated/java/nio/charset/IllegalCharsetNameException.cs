using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// An
	/// <code>IllegalCharsetNameException</code>
	/// is thrown when an illegal charset name
	/// is encountered.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalCharsetNameException : System.ArgumentException
	{
		internal const long serialVersionUID = 1457525358470002989L;

		private string charsetName;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalCharsetNameException</code>
		/// with the supplied
		/// charset name.
		/// </summary>
		/// <param name="charsetName">the encountered illegal charset name.</param>
		public IllegalCharsetNameException(string charsetName) : base((charsetName != null
			) ? charsetName : "null")
		{
			// The illegal charset name
			this.charsetName = charsetName;
		}

		/// <summary>Returns the encountered illegal charset name.</summary>
		/// <remarks>Returns the encountered illegal charset name.</remarks>
		public virtual string getCharsetName()
		{
			return charsetName;
		}
	}
}
