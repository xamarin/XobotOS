using Sharpen;

namespace android.provider
{
	[Sharpen.Stub]
	public class Applications
	{
		public const string AUTHORITY = "applications";

		public static readonly System.Uri CONTENT_URI = Sharpen.Util.ParseUri("content://"
			 + AUTHORITY);

		public const string APPLICATION_PATH = "applications";

		public const string SEARCH_PATH = "search";

		internal const string APPLICATION_SUB_TYPE = "vnd.android.application";

		public static readonly string APPLICATION_ITEM_TYPE = android.content.ContentResolver
			.CURSOR_ITEM_BASE_TYPE + "/" + APPLICATION_SUB_TYPE;

		public static readonly string APPLICATION_DIR_TYPE = android.content.ContentResolver
			.CURSOR_DIR_BASE_TYPE + "/" + APPLICATION_SUB_TYPE;

		[Sharpen.Stub]
		private Applications()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.database.Cursor search(android.content.ContentResolver resolver
			, string query)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.content.ComponentName uriToComponentName(System.Uri appUri)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static System.Uri componentNameToUri(string packageName, string className)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface ApplicationColumns : android.provider.BaseColumns
		{
		}

		[Sharpen.Stub]
		public static class ApplicationColumnsClass
		{
			public const string NAME = "name";

			public const string ICON = "icon";

			public const string URI = "uri";
		}
	}
}
