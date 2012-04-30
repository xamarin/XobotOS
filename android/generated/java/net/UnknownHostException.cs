using Sharpen;

namespace java.net
{
	/// <summary>Thrown when a hostname can not be resolved.</summary>
	/// <remarks>Thrown when a hostname can not be resolved.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class UnknownHostException : System.IO.IOException
	{
		internal const long serialVersionUID = -4639126076052875403L;

		/// <summary>
		/// Constructs a new
		/// <code>UnknownHostException</code>
		/// instance with no detail message.
		/// Callers should usually supply a detail message.
		/// </summary>
		public UnknownHostException()
		{
		}

		/// <summary>
		/// Constructs a new
		/// <code>UnknownHostException</code>
		/// instance with the given detail message.
		/// The detail message should generally contain the hostname and a reason for the failure,
		/// if known.
		/// </summary>
		/// <param name="detailMessage">the detail message for this exception.</param>
		public UnknownHostException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
