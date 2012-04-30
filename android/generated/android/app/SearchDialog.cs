using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class SearchDialog : android.app.Dialog
	{
		internal const bool DBG = false;

		internal const string LOG_TAG = "SearchDialog";

		internal const string INSTANCE_KEY_COMPONENT = "comp";

		internal const string INSTANCE_KEY_APPDATA = "data";

		internal const string INSTANCE_KEY_USER_QUERY = "uQry";

		internal const string IME_OPTION_NO_MICROPHONE = "nm";

		internal const int SEARCH_PLATE_LEFT_PADDING_NON_GLOBAL = 7;

		private android.widget.TextView mBadgeLabel;

		private android.widget.ImageView mAppIcon;

		private android.widget.AutoCompleteTextView mSearchAutoComplete;

		private android.view.View mSearchPlate;

		private android.widget.SearchView mSearchView;

		private android.graphics.drawable.Drawable mWorkingSpinner;

		private android.view.View mCloseSearch;

		private android.app.SearchableInfo mSearchable;

		private android.content.ComponentName mLaunchComponent;

		private android.os.Bundle mAppSearchData;

		private android.content.Context mActivityContext;

		private readonly android.content.Intent mVoiceWebSearchIntent;

		private readonly android.content.Intent mVoiceAppSearchIntent;

		private string mUserQuery;

		private int mSearchAutoCompleteImeOptions;

		private sealed class _BroadcastReceiver_103 : android.content.BroadcastReceiver
		{
			public _BroadcastReceiver_103()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.content.BroadcastReceiver")]
			public override void onReceive(android.content.Context context, android.content.Intent
				 intent)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.content.BroadcastReceiver mConfChangeListener = new _BroadcastReceiver_103
			();

		[Sharpen.Stub]
		internal static int resolveDialogTheme(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SearchDialog(android.content.Context context, android.app.SearchManager searchManager
			) : base(context, resolveDialogTheme(context))
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void createContentView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool show(string initialQuery, bool selectInitialQuery, android.content.ComponentName
			 componentName, android.os.Bundle appSearchData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool doShow(string initialQuery, bool selectInitialQuery, android.content.ComponentName
			 componentName, android.os.Bundle appSearchData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool show(android.content.ComponentName componentName, android.os.Bundle 
			appSearchData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		protected internal override void onStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setWorking(bool working)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override android.os.Bundle onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void onRestoreInstanceState(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onConfigurationChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static bool isLandscapeMode(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateUI()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateSearchAutoComplete()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateSearchAppIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateSearchBadge()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isOutOfBounds(android.view.View v, android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void hide()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void launchQuerySearch()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void launchQuerySearch(int actionKey, string actionMsg
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void launchIntent(android.content.Intent intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setListSelection(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.content.Intent createIntent(string action, System.Uri data, string
			 extraData, string query, int actionKey, string actionMsg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class SearchBar : android.widget.LinearLayout
		{
			private android.app.SearchDialog mSearchDialog;

			[Sharpen.Stub]
			public SearchBar(android.content.Context context, android.util.AttributeSet attrs
				) : base(context, attrs)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public SearchBar(android.content.Context context) : base(context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setSearchDialog(android.app.SearchDialog searchDialog)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
			public override android.view.ActionMode startActionModeForChild(android.view.View
				 child, android.view.ActionMode.Callback callback)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private bool isEmpty(android.widget.AutoCompleteTextView actv)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Dialog")]
		public override void onBackPressed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool onClosePressed()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnCloseListener_674 : android.widget.SearchView.OnCloseListener
		{
			public _OnCloseListener_674()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SearchView.OnCloseListener")]
			public bool onClose()
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.widget.SearchView.OnCloseListener mOnCloseListener = new 
			_OnCloseListener_674();

		private sealed class _OnQueryTextListener_682 : android.widget.SearchView.OnQueryTextListener
		{
			public _OnQueryTextListener_682()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SearchView.OnQueryTextListener")]
			public bool onQueryTextSubmit(string query)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SearchView.OnQueryTextListener")]
			public bool onQueryTextChange(string newText)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.widget.SearchView.OnQueryTextListener mOnQueryChangeListener
			 = new _OnQueryTextListener_682();

		private sealed class _OnSuggestionListener_695 : android.widget.SearchView.OnSuggestionListener
		{
			public _OnSuggestionListener_695()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SearchView.OnSuggestionListener")]
			public bool onSuggestionSelect(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.SearchView.OnSuggestionListener")]
			public bool onSuggestionClick(int position)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.widget.SearchView.OnSuggestionListener mOnSuggestionSelectionListener
			 = new _OnSuggestionListener_695();

		[Sharpen.Stub]
		private void setUserQuery(string query)
		{
			throw new System.NotImplementedException();
		}
	}
}
