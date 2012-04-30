using Sharpen;

namespace android.util
{
	/// <summary>Base class for all checked exceptions thrown by the Android frameworks.</summary>
	/// <remarks>Base class for all checked exceptions thrown by the Android frameworks.</remarks>
	[System.Serializable]
	public class AndroidException : System.Exception
	{
		public AndroidException()
		{
		}

		public AndroidException(string name) : base(name)
		{
		}

		public AndroidException(string name, System.Exception cause) : base(name, cause)
		{
		}

		public AndroidException(System.Exception cause) : base("AndroidException", cause)
		{
		}
	}
}
