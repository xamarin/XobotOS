using Sharpen;

namespace android.util
{
	/// <summary>
	/// This exception is thrown by
	/// <see cref="Base64InputStream">Base64InputStream</see>
	/// or
	/// <see cref="Base64OutputStream">Base64OutputStream</see>
	/// when an error is detected in the data being decoded.  This allows problems with the base64 data
	/// to be disambiguated from errors in the underlying streams (e.g. actual connection errors.)
	/// </summary>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class Base64DataException : System.IO.IOException
	{
		public Base64DataException(string detailMessage) : base(detailMessage)
		{
		}
	}
}
