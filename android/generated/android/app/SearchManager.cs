using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class SearchManager : android.content.DialogInterfaceClass.OnDismissListener
		, android.content.DialogInterfaceClass.OnCancelListener
	{
		internal const bool DBG = false;

		internal const string TAG = "SearchManager";

		public const char MENU_KEY = 's';

		public const int MENU_KEYCODE = android.view.KeyEvent.KEYCODE_S;

		public const string QUERY = "query";

		public const string USER_QUERY = "user_query";

		public const string APP_DATA = "app_data";

		public const string SEARCH_MODE = "search_mode";

		public const string ACTION_KEY = "action_key";

		public const string EXTRA_DATA_KEY = "intent_extra_data_key";

		public const string EXTRA_SELECT_QUERY = "select_query";

		public const string EXTRA_NEW_SEARCH = "new_search";

		public const string EXTRA_WEB_SEARCH_PENDINGINTENT = "web_search_pendingintent";

		public const string CURSOR_EXTRA_KEY_IN_PROGRESS = "in_progress";

		public const string ACTION_MSG = "action_msg";

		public const int FLAG_QUERY_REFINEMENT = 1 << 0;

		public const string SUGGEST_URI_PATH_QUERY = "search_suggest_query";

		public const string SUGGEST_MIME_TYPE = "vnd.android.cursor.dir/vnd.android.search.suggest";

		public const string SUGGEST_URI_PATH_SHORTCUT = "search_suggest_shortcut";

		public const string SHORTCUT_MIME_TYPE = "vnd.android.cursor.item/vnd.android.search.suggest";

		public const string SUGGEST_COLUMN_FORMAT = "suggest_format";

		public const string SUGGEST_COLUMN_TEXT_1 = "suggest_text_1";

		public const string SUGGEST_COLUMN_TEXT_2 = "suggest_text_2";

		public const string SUGGEST_COLUMN_TEXT_2_URL = "suggest_text_2_url";

		public const string SUGGEST_COLUMN_ICON_1 = "suggest_icon_1";

		public const string SUGGEST_COLUMN_ICON_2 = "suggest_icon_2";

		public const string SUGGEST_COLUMN_INTENT_ACTION = "suggest_intent_action";

		public const string SUGGEST_COLUMN_INTENT_DATA = "suggest_intent_data";

		public const string SUGGEST_COLUMN_INTENT_EXTRA_DATA = "suggest_intent_extra_data";

		public const string SUGGEST_COLUMN_INTENT_DATA_ID = "suggest_intent_data_id";

		public const string SUGGEST_COLUMN_QUERY = "suggest_intent_query";

		public const string SUGGEST_COLUMN_SHORTCUT_ID = "suggest_shortcut_id";

		public const string SUGGEST_COLUMN_SPINNER_WHILE_REFRESHING = "suggest_spinner_while_refreshing";

		public const string SUGGEST_COLUMN_FLAGS = "suggest_flags";

		public const string SUGGEST_COLUMN_LAST_ACCESS_HINT = "suggest_last_access_hint";

		public const string SUGGEST_NEVER_MAKE_SHORTCUT = "_-1";

		public const string SUGGEST_PARAMETER_LIMIT = "limit";

		public const string INTENT_ACTION_GLOBAL_SEARCH = "android.search.action.GLOBAL_SEARCH";

		public const string INTENT_ACTION_SEARCH_SETTINGS = "android.search.action.SEARCH_SETTINGS";

		public const string INTENT_ACTION_WEB_SEARCH_SETTINGS = "android.search.action.WEB_SEARCH_SETTINGS";

		public const string INTENT_ACTION_SEARCHABLES_CHANGED = "android.search.action.SEARCHABLES_CHANGED";

		public const string INTENT_GLOBAL_SEARCH_ACTIVITY_CHANGED = "android.search.action.GLOBAL_SEARCH_ACTIVITY_CHANGED";

		public const string INTENT_ACTION_SEARCH_SETTINGS_CHANGED = "android.search.action.SETTINGS_CHANGED";

		public const string CONTEXT_IS_VOICE = "android.search.CONTEXT_IS_VOICE";

		public const string DISABLE_VOICE_SEARCH = "android.search.DISABLE_VOICE_SEARCH";

		private static android.app.ISearchManager mService;

		private readonly android.content.Context mContext;

		private string mAssociatedPackage;

		internal readonly android.os.Handler mHandler;

		internal android.app.SearchManager.OnDismissListener mDismissListener = null;

		internal android.app.SearchManager.OnCancelListener mCancelListener = null;

		private android.app.SearchDialog mSearchDialog;

		[Sharpen.Stub]
		internal SearchManager(android.content.Context context, android.os.Handler handler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void startSearch(string initialQuery, bool selectInitialQuery, android.content.ComponentName
			 launchActivity, android.os.Bundle appSearchData, bool globalSearch)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensureSearchDialog()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void startGlobalSearch(string initialQuery, bool selectInitialQuery
			, android.os.Bundle appSearchData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName getGlobalSearchActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.ComponentName getWebSearchActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void triggerSearch(string query, android.content.ComponentName launchActivity
			, android.os.Bundle appSearchData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopSearch()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isVisible()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public interface OnDismissListener
		{
			[Sharpen.Stub]
			void onDismiss();
		}

		[Sharpen.Stub]
		public interface OnCancelListener
		{
			[Sharpen.Stub]
			void onCancel();
		}

		[Sharpen.Stub]
		public virtual void setOnDismissListener(android.app.SearchManager.OnDismissListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnCancelListener(android.app.SearchManager.OnCancelListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method is an obsolete internal implementation detail. Do not use."
			)]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnCancelListener")]
		public virtual void onCancel(android.content.DialogInterface dialog)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"This method is an obsolete internal implementation detail. Do not use."
			)]
		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnDismissListener"
			)]
		public virtual void onDismiss(android.content.DialogInterface dialog)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.SearchableInfo getSearchableInfo(android.content.ComponentName
			 componentName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor getSuggestions(android.app.SearchableInfo 
			searchable, string query)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.database.Cursor getSuggestions(android.app.SearchableInfo 
			searchable, string query, int limit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch
			()
		{
			throw new System.NotImplementedException();
		}
	}
}
