using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// A
	/// <code>MalformedInputException</code>
	/// is thrown when a malformed input is
	/// encountered, for example if a byte sequence is illegal for the given charset.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class MalformedInputException : java.nio.charset.CharacterCodingException
	{
		internal const long serialVersionUID = -3438823399834806194L;

		private int inputLength;

		/// <summary>
		/// Constructs a new
		/// <code>MalformedInputException</code>
		/// .
		/// </summary>
		/// <param name="length">the length of the malformed input.</param>
		public MalformedInputException(int length)
		{
			// the length of the malformed input
			this.inputLength = length;
		}

		/// <summary>Gets the length of the malformed input.</summary>
		/// <remarks>Gets the length of the malformed input.</remarks>
		/// <returns>the length of the malformed input.</returns>
		public virtual int getInputLength()
		{
			return this.inputLength;
		}

		public override string Message
		{
			get
			{
				return "Length: " + inputLength;
			}
		}
	}
}
