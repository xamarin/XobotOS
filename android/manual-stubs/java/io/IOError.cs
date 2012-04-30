using Sharpen;

namespace java.io
{
	/// <summary>This error is thrown when a severe I/O error has happened.</summary>
	/// <remarks>This error is thrown when a severe I/O error has happened.</remarks>
	/// <since>1.6</since>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class IOError : System.Exception
	{
		private const long serialVersionUID = 67100927991680413L;

		/// <summary>Constructs a new instance with its cause filled in.</summary>
		/// <remarks>Constructs a new instance with its cause filled in.</remarks>
		/// <param name="cause">The detail cause for the error.</param>
		public IOError(System.Exception cause) : base("IOError", cause)
		{
		}
	}
}
