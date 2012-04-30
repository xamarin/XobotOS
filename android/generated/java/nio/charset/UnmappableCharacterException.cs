using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// An
	/// <code>UnmappableCharacterException</code>
	/// is thrown when an unmappable
	/// character for the given charset is encountered.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnmappableCharacterException : java.nio.charset.CharacterCodingException
	{
		internal const long serialVersionUID = -7026962371537706123L;

		private int inputLength;

		/// <summary>
		/// Constructs a new
		/// <code>UnmappableCharacterException</code>
		/// .
		/// </summary>
		/// <param name="length">the length of the unmappable character.</param>
		public UnmappableCharacterException(int length)
		{
			// The length of the unmappable character
			this.inputLength = length;
		}

		/// <summary>Returns the length of the unmappable character.</summary>
		/// <remarks>Returns the length of the unmappable character.</remarks>
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
