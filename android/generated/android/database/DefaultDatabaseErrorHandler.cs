using Sharpen;

namespace android.database
{
	[Sharpen.Stub]
	public sealed class DefaultDatabaseErrorHandler : android.database.DatabaseErrorHandler
	{
		internal const string TAG = "DefaultDatabaseErrorHandler";

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.DatabaseErrorHandler")]
		public void onCorruption(android.database.sqlite.SQLiteDatabase dbObj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void deleteDatabaseFile(string fileName)
		{
			throw new System.NotImplementedException();
		}
	}
}
