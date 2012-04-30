using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteQuery : android.database.sqlite.SQLiteProgram
	{
		internal const string TAG = "SQLiteQuery";

		[Sharpen.Stub]
		private static int nativeFillWindow(int databasePtr, int statementPtr, int windowPtr
			, int startPos, int offsetParam)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int nativeColumnCount(int statementPtr)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string nativeColumnName(int statementPtr, int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		private int mOffsetIndex = 0;

		private bool mClosed = false;

		[Sharpen.Stub]
		internal SQLiteQuery(android.database.sqlite.SQLiteDatabase db, string query, int
			 offsetIndex, string[] bindArgs) : base(db, query)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal SQLiteQuery(android.database.sqlite.SQLiteDatabase db, android.database.sqlite.SQLiteQuery
			 query) : base(db, query.mSql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int fillWindow(android.database.CursorWindow window)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int columnCountLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual string columnNameLocked(int columnIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteProgram")]
		public override void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void requery()
		{
			throw new System.NotImplementedException();
		}
	}
}
