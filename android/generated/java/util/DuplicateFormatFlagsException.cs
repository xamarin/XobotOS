using Sharpen;

namespace java.util
{
	/// <summary>
	/// The unchecked exception will be thrown out if there are duplicate flags given
	/// out in the format specifier.
	/// </summary>
	/// <remarks>
	/// The unchecked exception will be thrown out if there are duplicate flags given
	/// out in the format specifier.
	/// </remarks>
	/// <seealso cref="java.lang.RuntimeException">java.lang.RuntimeException</seealso>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class DuplicateFormatFlagsException : java.util.IllegalFormatException
	{
		internal const long serialVersionUID = 18890531L;

		private readonly string flags;

		/// <summary>
		/// Constructs a new
		/// <code>DuplicateFormatFlagsException</code>
		/// with the flags
		/// containing duplicates.
		/// </summary>
		/// <param name="f">the format flags that contain a duplicate flag.</param>
		public DuplicateFormatFlagsException(string f)
		{
			if (f == null)
			{
				throw new System.ArgumentNullException();
			}
			flags = f;
		}

		/// <summary>Returns the format flags that contain a duplicate flag.</summary>
		/// <remarks>Returns the format flags that contain a duplicate flag.</remarks>
		/// <returns>the format flags that contain a duplicate flag.</returns>
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
