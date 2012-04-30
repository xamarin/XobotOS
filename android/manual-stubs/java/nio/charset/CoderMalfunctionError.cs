using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// A
	/// <code>CoderMalfunctionError</code>
	/// is thrown when the encoder/decoder is
	/// malfunctioning.
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class CoderMalfunctionError : System.Exception
	{
		private const long serialVersionUID = -1151412348057794301L;

		/// <summary>
		/// Constructs a new
		/// <code>CoderMalfunctionError</code>
		/// .
		/// </summary>
		/// <param name="ex">the original exception thrown by the encoder/decoder.</param>
		public CoderMalfunctionError(System.Exception ex) : base("CoderMalfunctionError", ex)
		{
		}
	}
}
