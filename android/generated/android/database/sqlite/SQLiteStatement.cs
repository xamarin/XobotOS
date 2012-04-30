using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteStatement : android.database.sqlite.SQLiteProgram
	{
		internal const string TAG = "SQLiteStatement";

		internal const bool READ = true;

		internal const bool WRITE = false;

		private android.database.sqlite.SQLiteDatabase mOrigDb;

		private int mState;

		internal const int TRANS_STARTED = 1;

		internal const int LOCK_ACQUIRED = 2;

		[Sharpen.Stub]
		internal SQLiteStatement(android.database.sqlite.SQLiteDatabase db, string sql, object
			[] bindArgs) : base(db, sql, bindArgs, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void execute()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int executeUpdateDelete()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long executeInsert()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void saveSqlAsLastSqlStatement()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long simpleQueryForLong()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string simpleQueryForString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.ParcelFileDescriptor simpleQueryForBlobFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private long acquireAndLock(bool rwFlag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void releaseAndUnlock()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int native_execute()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private long native_executeInsert()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private long native_1x1_long()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string native_1x1_string()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.os.ParcelFileDescriptor native_1x1_blob_ashmem()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_executeSql(string sql)
		{
			throw new System.NotImplementedException();
		}
	}
}
