using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public abstract class SQLiteProgram : android.database.sqlite.SQLiteClosable
	{
		internal const string TAG = "SQLiteProgram";

		[System.ObsoleteAttribute(@"do not use this")]
		protected internal android.database.sqlite.SQLiteDatabase mDatabase;

		internal readonly string mSql;

		[System.ObsoleteAttribute(@"do not use this")]
		protected internal int nHandle;

		internal android.database.sqlite.SQLiteCompiledSql mCompiledSql;

		[System.ObsoleteAttribute(@"do not use this")]
		protected internal int nStatement;

		internal java.util.HashMap<int, object> mBindArgs = null;

		internal readonly int mStatementType;

		internal const int STATEMENT_CACHEABLE = 16;

		internal const int STATEMENT_DONT_PREPARE = 32;

		internal const int STATEMENT_USE_POOLED_CONN = 64;

		internal const int STATEMENT_TYPE_MASK = unchecked((int)(0x0f));

		[Sharpen.Stub]
		internal SQLiteProgram(android.database.sqlite.SQLiteDatabase db, string sql) : this
			(db, sql, null, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal SQLiteProgram(android.database.sqlite.SQLiteDatabase db, string sql, object
			[] bindArgs, bool compileFlag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void compileSql()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteClosable")]
		protected internal override void onAllReferencesReleased()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteClosable")]
		protected internal override void onAllReferencesReleasedFromContainer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void release()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"do not use this method. it is not guaranteed to be the same across executions of the SQL statement contained in this object."
			)]
		public int getUniqueId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual int getSqlStatementId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual string getSqlString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method is deprecated and must not be used.")]
		protected internal virtual void compile(string sql, bool forceCompilation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void bind(int type, int index, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindNull(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindLong(int index, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindDouble(int index, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindString(int index, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindBlob(int index, byte[] value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearBindings()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addToBindArgs(int index, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void compileAndbindAllArgs()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void bindAllArgsAsStrings(string[] bindArgs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void setNativeHandle(int nHandle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method is deprecated and must not be used. Compiles SQL into a SQLite program. <P>The database lock must be held when calling this method."
			)]
		protected internal void native_compile(string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method is deprecated and must not be used.")]
		protected internal void native_finalize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void native_bind_null(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void native_bind_long(int index, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void native_bind_double(int index, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void native_bind_string(int index, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void native_bind_blob(int index, byte[] value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void native_clear_bindings()
		{
			throw new System.NotImplementedException();
		}
	}
}
