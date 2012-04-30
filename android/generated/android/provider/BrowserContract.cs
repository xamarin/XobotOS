using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public class BrowserContract
	{
		public const string AUTHORITY = "com.android.browser";

		public static readonly System.Uri AUTHORITY_URI = Sharpen.Util.ParseUri("content://"
			 + AUTHORITY);

		public const string CALLER_IS_SYNCADAPTER = "caller_is_syncadapter";

		public const string PARAM_LIMIT = "limit";

		[Sharpen.Stub]
		internal interface BaseSyncColumns
		{
		}

		[Sharpen.Stub]
		internal static class BaseSyncColumnsClass
		{
			public const string SYNC1 = "sync1";

			public const string SYNC2 = "sync2";

			public const string SYNC3 = "sync3";

			public const string SYNC4 = "sync4";

			public const string SYNC5 = "sync5";
		}

		[Sharpen.Stub]
		public sealed class ChromeSyncColumns
		{
			[Sharpen.Stub]
			private ChromeSyncColumns()
			{
				throw new System.NotImplementedException();
			}

			public static readonly string SERVER_UNIQUE = android.provider.BrowserContract.BaseSyncColumnsClass.SYNC3;

			public const string FOLDER_NAME_ROOT = "google_chrome";

			public const string FOLDER_NAME_BOOKMARKS = "google_chrome_bookmarks";

			public const string FOLDER_NAME_BOOKMARKS_BAR = "bookmark_bar";

			public const string FOLDER_NAME_OTHER_BOOKMARKS = "other_bookmarks";

			public static readonly string CLIENT_UNIQUE = android.provider.BrowserContract.BaseSyncColumnsClass.SYNC4;
		}

		[Sharpen.Stub]
		internal interface SyncColumns : android.provider.BrowserContract.BaseSyncColumns
		{
		}

		[Sharpen.Stub]
		internal static class SyncColumnsClass
		{
			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string SOURCE_ID = "sourceid";

			public const string VERSION = "version";

			public const string DIRTY = "dirty";

			public const string DATE_MODIFIED = "modified";
		}

		[Sharpen.Stub]
		internal interface CommonColumns
		{
		}

		[Sharpen.Stub]
		internal static class CommonColumnsClass
		{
			public const string _ID = "_id";

			public const string URL = "url";

			public const string TITLE = "title";

			public const string DATE_CREATED = "created";
		}

		[Sharpen.Stub]
		internal interface ImageColumns
		{
		}

		[Sharpen.Stub]
		internal static class ImageColumnsClass
		{
			public const string FAVICON = "favicon";

			public const string THUMBNAIL = "thumbnail";

			public const string TOUCH_ICON = "touch_icon";
		}

		[Sharpen.Stub]
		internal interface HistoryColumns
		{
		}

		[Sharpen.Stub]
		internal static class HistoryColumnsClass
		{
			public const string DATE_LAST_VISITED = "date";

			public const string VISITS = "visits";

			public const string USER_ENTERED = "user_entered";
		}

		[Sharpen.Stub]
		public sealed class Bookmarks : android.provider.BrowserContract.CommonColumns, android.provider.BrowserContract
			.ImageColumns, android.provider.BrowserContract.SyncColumns
		{
			[Sharpen.Stub]
			private Bookmarks()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "bookmarks");

			public static readonly System.Uri CONTENT_URI_DEFAULT_FOLDER = Sharpen.Util.AppendUri
				(CONTENT_URI, "folder");

			public const string PARAM_ACCOUNT_NAME = "acct_name";

			public const string PARAM_ACCOUNT_TYPE = "acct_type";

			[Sharpen.Stub]
			public static System.Uri buildFolderUri(long folderId)
			{
				throw new System.NotImplementedException();
			}

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/bookmark";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/bookmark";

			public const string QUERY_PARAMETER_SHOW_DELETED = "show_deleted";

			public const string IS_FOLDER = "folder";

			public const string PARENT = "parent";

			public const string PARENT_SOURCE_ID = "parent_source";

			public const string POSITION = "position";

			public const string INSERT_AFTER = "insert_after";

			public const string INSERT_AFTER_SOURCE_ID = "insert_after_source";

			public const string IS_DELETED = "deleted";
		}

		[Sharpen.Stub]
		public sealed class Accounts
		{
			public static readonly System.Uri CONTENT_URI = null;

			public const string ACCOUNT_NAME = "account_name";

			public const string ACCOUNT_TYPE = "account_type";

			public const string ROOT_ID = "root_id";
		}

		[Sharpen.Stub]
		public sealed class History : android.provider.BrowserContract.CommonColumns, android.provider.BrowserContract
			.HistoryColumns, android.provider.BrowserContract.ImageColumns
		{
			[Sharpen.Stub]
			private History()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "history");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/browser-history";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/browser-history";
		}

		[Sharpen.Stub]
		public sealed class Searches
		{
			[Sharpen.Stub]
			private Searches()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "searches");

			public const string CONTENT_TYPE = "vnd.android.cursor.dir/searches";

			public const string CONTENT_ITEM_TYPE = "vnd.android.cursor.item/searches";

			public const string _ID = "_id";

			public const string SEARCH = "search";

			public const string DATE = "date";
		}

		[Sharpen.Stub]
		public sealed class SyncState : android.provider.SyncStateContract.Columns
		{
			[Sharpen.Stub]
			private SyncState()
			{
				throw new System.NotImplementedException();
			}

			public static readonly string CONTENT_DIRECTORY = android.provider.SyncStateContract
				.Constants.CONTENT_DIRECTORY;

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, CONTENT_DIRECTORY);

			[Sharpen.Stub]
			public static byte[] get(android.content.ContentProviderClient provider, android.accounts.Account
				 account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.util.Pair<System.Uri, byte[]> getWithUri(android.content.ContentProviderClient
				 provider, android.accounts.Account account)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void set(android.content.ContentProviderClient provider, android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ContentProviderOperation newSetOperation(android.accounts.Account
				 account, byte[] data)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public sealed class Images : android.provider.BrowserContract.ImageColumns
		{
			[Sharpen.Stub]
			private Images()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "images");

			public const string URL = "url_key";
		}

		[Sharpen.Stub]
		public sealed class Combined : android.provider.BrowserContract.CommonColumns, android.provider.BrowserContract
			.HistoryColumns, android.provider.BrowserContract.ImageColumns
		{
			[Sharpen.Stub]
			private Combined()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "combined");

			public const string IS_BOOKMARK = "bookmark";
		}

		[Sharpen.Stub]
		public sealed class Settings
		{
			[Sharpen.Stub]
			private Settings()
			{
				throw new System.NotImplementedException();
			}

			public static readonly System.Uri CONTENT_URI = Sharpen.Util.AppendUri(AUTHORITY_URI
				, "settings");

			public const string KEY = "key";

			public const string VALUE = "value";

			public const string KEY_SYNC_ENABLED = "sync_enabled";

			[Sharpen.Stub]
			public static bool isSyncEnabled(android.content.Context context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static void setSyncEnabled(android.content.Context context, bool enabled)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
