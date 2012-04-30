using Sharpen;

namespace java.util
{
	/// <summary>
	/// An
	/// <code>IllegalFormatFlagsException</code>
	/// will be thrown if the combination of
	/// the format flags is illegal.
	/// </summary>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalFormatFlagsException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 790824L;

		private readonly string flags;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalFormatFlagsException</code>
		/// with the specified
		/// flags.
		/// </summary>
		/// <param name="flags">the specified flags.</param>
		public IllegalFormatFlagsException(string flags)
		{
			if (flags == null)
			{
				throw new System.ArgumentNullException();
			}
			this.flags = flags;
		}

		/// <summary>Returns the flags that are illegal.</summary>
		/// <remarks>Returns the flags that are illegal.</remarks>
		/// <returns>the flags that are illegal.</returns>
		public virtual string getFlags()
		{
			return flags;
		}

		public override string Message
		{
			get
			{
				return flags;
			}
		}
	}
}
