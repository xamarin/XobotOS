using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteDirectCursorDriver : android.database.sqlite.SQLiteCursorDriver
	{
		private string mEditTable;

		private android.database.sqlite.SQLiteDatabase mDatabase;

		private android.database.Cursor mCursor;

		private string mSql;

		private android.database.sqlite.SQLiteQuery mQuery;

		[Sharpen.Stub]
		public SQLiteDirectCursorDriver(android.database.sqlite.SQLiteDatabase db, string
			 sql, string editTable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.sqlite.SQLiteCursorDriver")]
		public virtual android.database.Cursor query(android.database.sqlite.SQLiteDatabase
			.CursorFactory factory, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.sqlite.SQLiteCursorDriver")]
		public virtual void cursorClosed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.sqlite.SQLiteCursorDriver")]
		public virtual void setBindArguments(string[] bindArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.sqlite.SQLiteCursorDriver")]
		public virtual void cursorDeactivated()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.database.sqlite.SQLiteCursorDriver")]
		public virtual void cursorRequeried(android.database.Cursor cursor)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
