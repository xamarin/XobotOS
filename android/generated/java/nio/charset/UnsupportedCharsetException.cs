using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// An
	/// <code>UnsupportedCharsetException</code>
	/// is thrown when an unsupported charset
	/// name is encountered.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnsupportedCharsetException : System.ArgumentException
	{
		internal const long serialVersionUID = 1490765524727386367L;

		private string charsetName;

		/// <summary>
		/// Constructs a new
		/// <code>UnsupportedCharsetException</code>
		/// with the supplied
		/// charset name.
		/// </summary>
		/// <param name="charsetName">the encountered unsupported charset name.</param>
		public UnsupportedCharsetException(string charsetName) : base((charsetName != null
			) ? charsetName : "null")
		{
			// the unsupported charset name
			this.charsetName = charsetName;
		}

		/// <summary>Gets the encountered unsupported charset name.</summary>
		/// <remarks>Gets the encountered unsupported charset name.</remarks>
		/// <returns>the encountered unsupported charset name.</returns>
		public virtual string getCharsetName()
		{
			return charsetName;
		}
	}
}
