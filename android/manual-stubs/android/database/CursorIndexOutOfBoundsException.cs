using Sharpen;

namespace android.database
{
	[System.Serializable]
	[Sharpen.Stub]
	public class CursorIndexOutOfBoundsException : System.Exception
	{
		public CursorIndexOutOfBoundsException(int index, int size) : base("Index " + index
			 + " requested, with a size of " + size)
		{
			throw new System.NotImplementedException();
		}

		public CursorIndexOutOfBoundsException(string message) : base(message)
		{
			throw new System.NotImplementedException();
		}
	}
}
