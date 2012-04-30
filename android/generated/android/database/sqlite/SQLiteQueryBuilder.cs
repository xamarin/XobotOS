using Sharpen;

namespace android.database.sqlite
{
	[Sharpen.Stub]
	public class SQLiteQueryBuilder
	{
		internal const string TAG = "SQLiteQueryBuilder";

		private static readonly java.util.regex.Pattern sLimitPattern = java.util.regex.Pattern
			.compile("\\s*\\d+\\s*(,\\s*\\d+\\s*)?");

		private java.util.Map<string, string> mProjectionMap = null;

		private string mTables = string.Empty;

		private java.lang.StringBuilder mWhereClause = null;

		private bool mDistinct;

		private android.database.sqlite.SQLiteDatabase.CursorFactory mFactory;

		private bool mStrict;

		[Sharpen.Stub]
		public SQLiteQueryBuilder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDistinct(bool distinct)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getTables()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTables(string inTables)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void appendWhere(java.lang.CharSequence inWhere)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void appendWhereEscapeString(string inWhere)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProjectionMap(java.util.Map<string, string> columnMap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCursorFactory(android.database.sqlite.SQLiteDatabase.CursorFactory
			 factory)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setStrict(bool flag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string buildQueryString(bool distinct, string tables, string[] columns
			, string where, string groupBy, string having, string orderBy, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void appendClause(java.lang.StringBuilder s, string name, string clause
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void appendColumns(java.lang.StringBuilder s, string[] columns)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(android.database.sqlite.SQLiteDatabase
			 db, string[] projectionIn, string selection, string[] selectionArgs, string groupBy
			, string having, string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor query(android.database.sqlite.SQLiteDatabase
			 db, string[] projectionIn, string selection, string[] selectionArgs, string groupBy
			, string having, string sortOrder, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void validateSql(android.database.sqlite.SQLiteDatabase db, string sql)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string buildQuery(string[] projectionIn, string selection, string 
			groupBy, string having, string sortOrder, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method's signature is misleading since no SQL parameter substitution is carried out.  The selection arguments parameter does not get used at all.  To avoid confusion, callbuildQuery(string[], string, string, string, string, string) instead."
			)]
		public virtual string buildQuery(string[] projectionIn, string selection, string[]
			 selectionArgs, string groupBy, string having, string sortOrder, string limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string buildUnionSubQuery(string typeDiscriminatorColumn, string[]
			 unionColumns, java.util.Set<string> columnsPresentInTable, int computedColumnsOffset
			, string typeDiscriminatorValue, string selection, string groupBy, string having
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method's signature is misleading since no SQL parameter substitution is carried out.  The selection arguments parameter does not get used at all.  To avoid confusion, callbuildUnionSubQuery(string, string[], java.util.Set{E}, int, string, string, string, string) instead."
			)]
		public virtual string buildUnionSubQuery(string typeDiscriminatorColumn, string[]
			 unionColumns, java.util.Set<string> columnsPresentInTable, int computedColumnsOffset
			, string typeDiscriminatorValue, string selection, string[] selectionArgs, string
			 groupBy, string having)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string buildUnionQuery(string[] subQueries, string sortOrder, string
			 limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private string[] computeProjection(string[] projectionIn)
		{
			throw new System.NotImplementedException();
		}
	}
}
