using Sharpen;

namespace android.util
{
	[System.Serializable]
	[Sharpen.Stub]
	public class OperationApplicationException : System.Exception
	{
		public OperationApplicationException ()
			: base("OperationApplicationException")
		{
		}

		public OperationApplicationException (string name)
			: base(name)
		{
		}

		public OperationApplicationException (System.Exception cause)
			: base("OperationApplicationException", cause)
		{
		}
	}
}
