using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class SearchRecentSuggestionsProvider : android.content.ContentProvider
	{
		internal const string TAG = "SuggestionsProvider";

		private string mAuthority;

		private int mMode;

		private bool mTwoLineDisplay;

		private android.database.sqlite.SQLiteOpenHelper mOpenHelper;

		internal const string sDatabaseName = "suggestions.db";

		internal const string sSuggestions = "suggestions";

		internal const string ORDER_BY = "date DESC";

		internal const string NULL_COLUMN = "query";

		internal const int DATABASE_VERSION = 2 * 256;

		public const int DATABASE_MODE_QUERIES = 1;

		public const int DATABASE_MODE_2LINES = 2;

		internal const int URI_MATCH_SUGGEST = 1;

		private System.Uri mSuggestionsUri;

		private android.content.UriMatcher mUriMatcher;

		private string mSuggestSuggestionClause;

		private string[] mSuggestionProjection;

		[Sharpen.Stub]
		private class DatabaseHelper : android.database.sqlite.SQLiteOpenHelper
		{
			internal int mNewVersion;

			[Sharpen.Stub]
			public DatabaseHelper(android.content.Context context, int newVersion) : base(context
				, sDatabaseName, null, newVersion)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteOpenHelper")]
			public override void onCreate(android.database.sqlite.SQLiteDatabase db)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.sqlite.SQLiteOpenHelper")]
			public override void onUpgrade(android.database.sqlite.SQLiteDatabase db, int oldVersion
				, int newVersion)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		protected internal virtual void setupSuggestions(string authority, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override int delete(System.Uri uri, string selection, string[] selectionArgs
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override string getType(System.Uri uri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override System.Uri insert(System.Uri uri, android.content.ContentValues values
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override bool onCreate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override android.database.Cursor query(System.Uri uri, string[] projection
			, string selection, string[] selectionArgs, string sortOrder)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.ContentProvider")]
		public override int update(System.Uri uri, android.content.ContentValues values, 
			string selection, string[] selectionArgs)
		{
			throw new System.NotImplementedException();
		}
	}
}
