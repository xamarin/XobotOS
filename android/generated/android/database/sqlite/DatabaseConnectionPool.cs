using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	internal class DatabaseConnectionPool
	{
		internal const string TAG = "DatabaseConnectionPool";

		private volatile int mMaxPoolSize = android.content.res.Resources.getSystem().getInteger
			(android.@internal.R.integer.db_connection_pool_size);

		private readonly java.util.ArrayList<android.database.sqlite.DatabaseConnectionPool
			.PoolObj> mPool;

		private readonly android.database.sqlite.SQLiteDatabase mParentDbObj;

		private System.Random rand;

		[Sharpen.Stub]
		internal DatabaseConnectionPool(android.database.sqlite.SQLiteDatabase db)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.database.sqlite.SQLiteDatabase get(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void release(android.database.sqlite.SQLiteDatabase db)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual java.util.ArrayList<android.database.sqlite.SQLiteDatabase> getConnectionList
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getFreePoolSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual java.util.ArrayList<android.database.sqlite.DatabaseConnectionPool
			.PoolObj> getPool()
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
		private void doAsserts()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void setMaxPoolSize(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getMaxPoolSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isDatabaseObjFree(android.database.sqlite.SQLiteDatabase db
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class PoolObj
		{
			private readonly android.database.sqlite.SQLiteDatabase mDb;

			private bool mFreeBusyFlag = FREE;

			internal const bool FREE = true;

			internal const bool BUSY = false;

			private int mNumHolders = 0;

			private java.util.HashSet<long> mHolderIds = new java.util.HashSet<long>();

			[Sharpen.Stub]
			public PoolObj(android.database.sqlite.SQLiteDatabase db)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void acquire()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void release()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool isFree()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void verify()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual int getNumHolders()
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
}
