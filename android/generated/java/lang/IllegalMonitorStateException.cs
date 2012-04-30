using Sharpen;

namespace java.lang
{
	/// <summary>
	/// Thrown when a monitor operation is attempted when the monitor is not in the
	/// correct state, for example when a thread attempts to exit a monitor which it
	/// does not own.
	/// </summary>
	/// <remarks>
	/// Thrown when a monitor operation is attempted when the monitor is not in the
	/// correct state, for example when a thread attempts to exit a monitor which it
	/// does not own.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IllegalMonitorStateException : java.lang.RuntimeException
	{
		internal const long serialVersionUID = 3713306369498869069L;

		/// <summary>
		/// Constructs a new
		/// <code>IllegalMonitorStateException</code>
		/// that includes the
		/// current stack trace.
		/// </summary>
		public IllegalMonitorStateException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>IllegalArgumentException</code>
		/// with the current stack
		/// trace and the specified detail message.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public IllegalMonitorStateException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
