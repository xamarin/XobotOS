using Sharpen;

namespace android.util
{
	/// <summary>Thrown when a reader encounters malformed JSON.</summary>
	/// <remarks>
	/// Thrown when a reader encounters malformed JSON. Some syntax errors can be
	/// ignored by calling
	/// <see cref="JsonReader.setLenient(bool)">JsonReader.setLenient(bool)</see>
	/// .
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed class MalformedJsonException : System.IO.IOException
	{
		internal const long serialVersionUID = 1L;

		public MalformedJsonException(string message) : base(message)
		{
		}
	}
}
