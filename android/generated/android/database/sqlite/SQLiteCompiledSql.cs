using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	internal class SQLiteCompiledSql
	{
		internal const string TAG = "SQLiteCompiledSql";

		internal readonly android.database.sqlite.SQLiteDatabase mDatabase;

		internal readonly int nHandle;

		internal int nStatement = 0;

		private string mSqlStmt = null;

		private System.Exception mStackTrace = null;

		private bool mInUse = false;

		[Sharpen.Stub]
		internal SQLiteCompiledSql(android.database.sqlite.SQLiteDatabase db, string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void releaseSqlStatement()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool acquire()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void release()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void releaseIfNotInUse()
		{
			throw new System.NotImplementedException();
		}

		~SQLiteCompiledSql()
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
		private void native_compile(string sql)
		{
			throw new System.NotImplementedException();
		}
	}
}
