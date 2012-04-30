using Sharpen;

namespace android.util
{
	/// <summary>Base class for all unchecked exceptions thrown by the Android frameworks.
	/// 	</summary>
	/// <remarks>Base class for all unchecked exceptions thrown by the Android frameworks.
	/// 	</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public class AndroidRuntimeException : java.lang.RuntimeException
	{
		public AndroidRuntimeException()
		{
		}

		public AndroidRuntimeException(string name) : base(name)
		{
		}

		public AndroidRuntimeException(string name, System.Exception cause) : base(name, 
			cause)
		{
		}

		public AndroidRuntimeException(System.Exception cause) : base(cause)
		{
		}
	}
}
