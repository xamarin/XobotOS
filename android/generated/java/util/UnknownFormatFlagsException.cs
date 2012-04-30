using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>UnknownFormatFlagsException</code>
	/// will be thrown if there is
	/// an unknown flag.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnknownFormatFlagsException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 19370506L;

		private readonly string flags;

		/// <summary>
		/// Constructs a new
		/// <code>UnknownFormatFlagsException</code>
		/// with the specified
		/// flags.
		/// </summary>
		/// <param name="f">the specified flags.</param>
		public UnknownFormatFlagsException(string f)
		{
			if (f == null)
			{
				throw new System.ArgumentNullException();
			}
			flags = f;
		}

		/// <summary>Returns the flags associated with the exception.</summary>
		/// <remarks>Returns the flags associated with the exception.</remarks>
		/// <returns>the flags associated with the exception.</returns>
		public virtual string getFlags()
		{
			return flags;
		}

		public override string Message
		{
			get
			{
				return "Flags: " + flags;
			}
		}
	}
}
