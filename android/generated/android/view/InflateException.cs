using Sharpen;

namespace android.view
{
	/// <summary>This exception is thrown by an inflater on error conditions.</summary>
	/// <remarks>This exception is thrown by an inflater on error conditions.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class InflateException : java.lang.RuntimeException
	{
		public InflateException() : base()
		{
		}

		public InflateException(string detailMessage, System.Exception throwable) : base(
			detailMessage, throwable)
		{
		}

		public InflateException(string detailMessage) : base(detailMessage)
		{
		}

		public InflateException(System.Exception throwable) : base(throwable)
		{
		}
	}
}
