using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatPrecisionException</code>
	/// will be thrown if the precision is
	/// a negative other than -1 or in other cases where precision is not supported.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatPrecisionException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 18711008L;

		private readonly int p;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalFormatPrecisionException</code>
		/// with specified
		/// precision.
		/// </summary>
		/// <param name="p">the precision.</param>
		public IllegalFormatPrecisionException(int p)
		{
			this.p = p;
		}

		/// <summary>Returns the precision associated with the exception.</summary>
		/// <remarks>Returns the precision associated with the exception.</remarks>
		/// <returns>the precision.</returns>
		public virtual int getPrecision()
		{
			return p;
		}

		public override string Message
		{
			get
			{
				return System.Convert.ToString(p);
			}
		}
	}
}
