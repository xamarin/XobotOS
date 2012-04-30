using Sharpen;

namespace java.io
{
	/// <summary>
	/// Signals that the
	/// <see cref="FileDescriptor.sync()">FileDescriptor.sync()</see>
	/// method has failed to
	/// complete.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class SyncFailedException : System.IO.IOException
	{
		internal const long serialVersionUID = -2353342684412443330L;

		/// <summary>
		/// Constructs a new
		/// <code>SyncFailedException</code>
		/// with its stack trace and
		/// detail message filled in.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public SyncFailedException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
