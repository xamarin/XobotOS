using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatCodePointException</code>
	/// will be thrown if an invalid
	/// Unicode code point (defined by
	/// <see cref="char.isValidCodePoint(int)">char.isValidCodePoint(int)</see>
	/// ) is
	/// passed as a parameter to a Formatter.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatCodePointException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 19080630L;

		private readonly int c;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalFormatCodePointException</code>
		/// which is
		/// specified by the invalid Unicode code point.
		/// </summary>
		/// <param name="c">the invalid Unicode code point.</param>
		public IllegalFormatCodePointException(int c)
		{
			this.c = c;
		}

		/// <summary>Returns the invalid Unicode code point.</summary>
		/// <remarks>Returns the invalid Unicode code point.</remarks>
		/// <returns>the invalid Unicode code point.</returns>
		public virtual int getCodePoint()
		{
			return c;
		}

		public override string Message
		{
			get
			{
				return Sharpen.Util.IntToHexString(c);
			}
		}
	}
}
