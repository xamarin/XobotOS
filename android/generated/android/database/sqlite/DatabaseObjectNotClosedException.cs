using Sharpen;

namespace android.database.sqlite
{
	[System.Serializable]
	[Sharpen.Stub]
	public class DatabaseObjectNotClosedException : java.lang.RuntimeException
	{
		private static readonly string s = "Application did not close the cursor or database object "
			 + "that was opened here";

		[Sharpen.Stub]
		public DatabaseObjectNotClosedException() : base(s)
		{
			throw new System.NotImplementedException();
		}
	}
}
