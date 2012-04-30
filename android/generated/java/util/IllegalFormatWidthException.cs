using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatWidthException</code>
	/// will be thrown if the width is a
	/// negative value other than -1 or in other cases where a width is not
	/// supported.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatWidthException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 16660902L;

		private readonly int w;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalFormatWidthException</code>
		/// with specified
		/// width.
		/// </summary>
		/// <param name="w">the width.</param>
		public IllegalFormatWidthException(int w)
		{
			this.w = w;
		}

		/// <summary>Returns the width associated with the exception.</summary>
		/// <remarks>Returns the width associated with the exception.</remarks>
		/// <returns>the width.</returns>
		public virtual int getWidth()
		{
			return w;
		}

		public override string Message
		{
			get
			{
				return System.Convert.ToString(w);
			}
		}
	}
}
