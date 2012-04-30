using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A widget that provides a user interface for the user to enter a search query and submit a request
	/// to a search provider.
	/// </summary>
	/// <remarks>
	/// A widget that provides a user interface for the user to enter a search query and submit a request
	/// to a search provider. Shows a list of query suggestions or results, if available, and allows the
	/// user to pick a suggestion or result to launch into.
	/// <p>
	/// When the SearchView is used in an ActionBar as an action view for a collapsible menu item, it
	/// needs to be set to iconified by default using
	/// <see cref="setIconifiedByDefault(bool)">setIconifiedByDefault(true)</see>
	/// . This is the default, so nothing needs to be done.
	/// </p>
	/// <p>
	/// If you want the search field to always be visible, then call setIconifiedByDefault(false).
	/// </p>
	/// <p>
	/// For more information, see the &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/search/index.html"&gt;Search</a>
	/// documentation.
	/// <p>
	/// </remarks>
	/// <seealso cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
	/// 	</seealso>
	/// <attr>ref android.R.styleable#SearchView_iconifiedByDefault</attr>
	/// <attr>ref android.R.styleable#SearchView_imeOptions</attr>
	/// <attr>ref android.R.styleable#SearchView_inputType</attr>
	/// <attr>ref android.R.styleable#SearchView_maxWidth</attr>
	/// <attr>ref android.R.styleable#SearchView_queryHint</attr>
	[Sharpen.Sharpened]
	public class SearchView : android.widget.LinearLayout, android.view.CollapsibleActionView
	{
		internal const bool DBG = false;

		internal const string LOG_TAG = "SearchView";

		/// <summary>Private constant for removing the microphone in the keyboard.</summary>
		/// <remarks>Private constant for removing the microphone in the keyboard.</remarks>
		internal const string IME_OPTION_NO_MICROPHONE = "nm";

		private android.widget.SearchView.OnQueryTextListener mOnQueryChangeListener;

		private android.widget.SearchView.OnCloseListener mOnCloseListener;

		private android.view.View.OnFocusChangeListener mOnQueryTextFocusChangeListener;

		private android.widget.SearchView.OnSuggestionListener mOnSuggestionListener;

		private android.view.View.OnClickListener mOnSearchClickListener;

		private bool mIconifiedByDefault;

		private bool mIconified;

		private android.widget.CursorAdapter mSuggestionsAdapter;

		private android.view.View mSearchButton;

		private android.view.View mSubmitButton;

		private android.view.View mSearchPlate;

		private android.view.View mSubmitArea;

		private android.widget.ImageView mCloseButton;

		private android.view.View mSearchEditFrame;

		private android.view.View mVoiceButton;

		private android.widget.SearchView.SearchAutoComplete mQueryTextView;

		private android.view.View mDropDownAnchor;

		private android.widget.ImageView mSearchHintIcon;

		private bool mSubmitButtonEnabled;

		private java.lang.CharSequence mQueryHint;

		private bool mQueryRefinement;

		private bool mClearingFocus;

		private int mMaxWidth;

		private bool mVoiceButtonEnabled;

		private java.lang.CharSequence mOldQueryText;

		private java.lang.CharSequence mUserQuery;

		private bool mExpandedInActionView;

		private int mCollapsedImeOptions;

		private android.app.SearchableInfo mSearchable;

		private android.os.Bundle mAppSearchData;

		private sealed class _Runnable_137 : java.lang.Runnable
		{
			public _Runnable_137(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				android.view.inputmethod.InputMethodManager imm = (android.view.inputmethod.InputMethodManager
					)this._enclosing.getContext().getSystemService(android.content.Context.INPUT_METHOD_SERVICE
					);
				if (imm != null)
				{
					imm.showSoftInputUnchecked(0, null);
				}
			}

			private readonly SearchView _enclosing;
		}

		private java.lang.Runnable mShowImeRunnable;

		private sealed class _Runnable_148 : java.lang.Runnable
		{
			public _Runnable_148(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.updateFocusedState();
			}

			private readonly SearchView _enclosing;
		}

		private java.lang.Runnable mUpdateDrawableStateRunnable;

		private readonly android.content.Intent mVoiceWebSearchIntent;

		private readonly android.content.Intent mVoiceAppSearchIntent;

		private readonly java.util.WeakHashMap<string, android.graphics.drawable.Drawable
			.ConstantState> mOutsideDrawablesCache = new java.util.WeakHashMap<string, android.graphics.drawable.Drawable
			.ConstantState>();

		/// <summary>Callbacks for changes to the query text.</summary>
		/// <remarks>Callbacks for changes to the query text.</remarks>
		public interface OnQueryTextListener
		{
			// For voice searching
			// A weak map of drawables we've gotten from other packages, so we don't load them
			// more than once.
			/// <summary>Called when the user submits the query.</summary>
			/// <remarks>
			/// Called when the user submits the query. This could be due to a key press on the
			/// keyboard or due to pressing a submit button.
			/// The listener can override the standard behavior by returning true
			/// to indicate that it has handled the submit request. Otherwise return false to
			/// let the SearchView handle the submission by launching any associated intent.
			/// </remarks>
			/// <param name="query">the query text that is to be submitted</param>
			/// <returns>
			/// true if the query has been handled by the listener, false to let the
			/// SearchView perform the default action.
			/// </returns>
			bool onQueryTextSubmit(string query);

			/// <summary>Called when the query text is changed by the user.</summary>
			/// <remarks>Called when the query text is changed by the user.</remarks>
			/// <param name="newText">the new content of the query text field.</param>
			/// <returns>
			/// false if the SearchView should perform the default action of showing any
			/// suggestions if available, true if the action was handled by the listener.
			/// </returns>
			bool onQueryTextChange(string newText);
		}

		public interface OnCloseListener
		{
			/// <summary>The user is attempting to close the SearchView.</summary>
			/// <remarks>The user is attempting to close the SearchView.</remarks>
			/// <returns>
			/// true if the listener wants to override the default behavior of clearing the
			/// text field and dismissing it, false otherwise.
			/// </returns>
			bool onClose();
		}

		/// <summary>Callback interface for selection events on suggestions.</summary>
		/// <remarks>
		/// Callback interface for selection events on suggestions. These callbacks
		/// are only relevant when a SearchableInfo has been specified by
		/// <see cref="#setSearchableInfo">#setSearchableInfo</see>
		/// .
		/// </remarks>
		public interface OnSuggestionListener
		{
			/// <summary>Called when a suggestion was selected by navigating to it.</summary>
			/// <remarks>Called when a suggestion was selected by navigating to it.</remarks>
			/// <param name="position">the absolute position in the list of suggestions.</param>
			/// <returns>
			/// true if the listener handles the event and wants to override the default
			/// behavior of possibly rewriting the query based on the selected item, false otherwise.
			/// </returns>
			bool onSuggestionSelect(int position);

			/// <summary>Called when a suggestion was clicked.</summary>
			/// <remarks>Called when a suggestion was clicked.</remarks>
			/// <param name="position">the absolute position of the clicked item in the list of suggestions.
			/// 	</param>
			/// <returns>
			/// true if the listener handles the event and wants to override the default
			/// behavior of launching any intent or submitting a search query specified on that item.
			/// Return false otherwise.
			/// </returns>
			bool onSuggestionClick(int position);
		}

		public SearchView(android.content.Context context) : this(context, null)
		{
			mShowImeRunnable = new _Runnable_137(this);
			mUpdateDrawableStateRunnable = new _Runnable_148(this);
			mOnClickListener = new _OnClickListener_787(this);
			mTextKeyListener = new _OnKeyListener_836(this);
			mOnEditorActionListener = new _OnEditorActionListener_1059(this);
			mOnItemClickListener = new _OnItemClickListener_1233(this);
			mOnItemSelectedListener = new _OnItemSelectedListener_1244(this);
			mTextWatcher = new _TextWatcher_1530(this);
		}

		private sealed class _OnFocusChangeListener_265 : android.view.View.OnFocusChangeListener
		{
			public _OnFocusChangeListener_265(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Inform any listener of focus changes
			[Sharpen.ImplementsInterface(@"android.view.View.OnFocusChangeListener")]
			public void onFocusChange(android.view.View v, bool hasFocus_1)
			{
				if (this._enclosing.mOnQueryTextFocusChangeListener != null)
				{
					this._enclosing.mOnQueryTextFocusChangeListener.onFocusChange(this._enclosing, hasFocus_1
						);
				}
			}

			private readonly SearchView _enclosing;
		}

		private sealed class _OnLayoutChangeListener_313 : android.view.View.OnLayoutChangeListener
		{
			public _OnLayoutChangeListener_313(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Save voice intent for later queries/launching
			[Sharpen.ImplementsInterface(@"android.view.View.OnLayoutChangeListener")]
			public void onLayoutChange(android.view.View v, int left, int top, int right, int
				 bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
			{
				this._enclosing.adjustDropDownSizeAndPosition();
			}

			private readonly SearchView _enclosing;
		}

		public SearchView(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			mShowImeRunnable = new _Runnable_137(this);
			mUpdateDrawableStateRunnable = new _Runnable_148(this);
			mOnClickListener = new _OnClickListener_787(this);
			mTextKeyListener = new _OnKeyListener_836(this);
			mOnEditorActionListener = new _OnEditorActionListener_1059(this);
			mOnItemClickListener = new _OnItemClickListener_1233(this);
			mOnItemSelectedListener = new _OnItemSelectedListener_1244(this);
			mTextWatcher = new _TextWatcher_1530(this);
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			inflater.inflate(android.@internal.R.layout.search_view, this, true);
			mSearchButton = findViewById(android.@internal.R.id.search_button);
			mQueryTextView = (android.widget.SearchView.SearchAutoComplete)findViewById(android.@internal.R
				.id.search_src_text);
			mQueryTextView.setSearchView(this);
			mSearchEditFrame = findViewById(android.@internal.R.id.search_edit_frame);
			mSearchPlate = findViewById(android.@internal.R.id.search_plate);
			mSubmitArea = findViewById(android.@internal.R.id.submit_area);
			mSubmitButton = findViewById(android.@internal.R.id.search_go_btn);
			mCloseButton = (android.widget.ImageView)findViewById(android.@internal.R.id.search_close_btn
				);
			mVoiceButton = findViewById(android.@internal.R.id.search_voice_btn);
			mSearchHintIcon = (android.widget.ImageView)findViewById(android.@internal.R.id.search_mag_icon
				);
			mSearchButton.setOnClickListener(mOnClickListener);
			mCloseButton.setOnClickListener(mOnClickListener);
			mSubmitButton.setOnClickListener(mOnClickListener);
			mVoiceButton.setOnClickListener(mOnClickListener);
			mQueryTextView.setOnClickListener(mOnClickListener);
			mQueryTextView.addTextChangedListener(mTextWatcher);
			mQueryTextView.setOnEditorActionListener(mOnEditorActionListener);
			mQueryTextView.setOnItemClickListener(mOnItemClickListener);
			mQueryTextView.setOnItemSelectedListener(mOnItemSelectedListener);
			mQueryTextView.setOnKeyListener(mTextKeyListener);
			mQueryTextView.setOnFocusChangeListener(new _OnFocusChangeListener_265(this));
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.SearchView, 0, 0);
			setIconifiedByDefault(a.getBoolean(android.@internal.R.styleable.SearchView_iconifiedByDefault
				, true));
			int maxWidth = a.getDimensionPixelSize(android.@internal.R.styleable.SearchView_maxWidth
				, -1);
			if (maxWidth != -1)
			{
				setMaxWidth(maxWidth);
			}
			java.lang.CharSequence queryHint = a.getText(android.@internal.R.styleable.SearchView_queryHint
				);
			if (!android.text.TextUtils.isEmpty(queryHint))
			{
				setQueryHint(queryHint);
			}
			int imeOptions = a.getInt(android.@internal.R.styleable.SearchView_imeOptions, -1
				);
			if (imeOptions != -1)
			{
				setImeOptions(imeOptions);
			}
			int inputType = a.getInt(android.@internal.R.styleable.SearchView_inputType, -1);
			if (inputType != -1)
			{
				setInputType(inputType);
			}
			a.recycle();
			bool focusable = true;
			a = context.obtainStyledAttributes(attrs, android.@internal.R.styleable.View, 0, 
				0);
			focusable = a.getBoolean(android.@internal.R.styleable.View_focusable, focusable);
			a.recycle();
			setFocusable(focusable);
			mVoiceWebSearchIntent = new android.content.Intent(android.speech.RecognizerIntent
				.ACTION_WEB_SEARCH);
			mVoiceWebSearchIntent.addFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK);
			mVoiceWebSearchIntent.putExtra(android.speech.RecognizerIntent.EXTRA_LANGUAGE_MODEL
				, android.speech.RecognizerIntent.LANGUAGE_MODEL_WEB_SEARCH);
			mVoiceAppSearchIntent = new android.content.Intent(android.speech.RecognizerIntent
				.ACTION_RECOGNIZE_SPEECH);
			mVoiceAppSearchIntent.addFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK);
			mDropDownAnchor = findViewById(mQueryTextView.getDropDownAnchor());
			if (mDropDownAnchor != null)
			{
				mDropDownAnchor.addOnLayoutChangeListener(new _OnLayoutChangeListener_313(this));
			}
			updateViewsVisibility(mIconifiedByDefault);
			updateQueryHint();
		}

		/// <summary>Sets the SearchableInfo for this SearchView.</summary>
		/// <remarks>
		/// Sets the SearchableInfo for this SearchView. Properties in the SearchableInfo are used
		/// to display labels, hints, suggestions, create intents for launching search results screens
		/// and controlling other affordances such as a voice button.
		/// </remarks>
		/// <param name="searchable">
		/// a SearchableInfo can be retrieved from the SearchManager, for a specific
		/// activity or a global search provider.
		/// </param>
		public virtual void setSearchableInfo(android.app.SearchableInfo searchable)
		{
			mSearchable = searchable;
			if (mSearchable != null)
			{
				updateSearchAutoComplete();
				updateQueryHint();
			}
			// Cache the voice search capability
			mVoiceButtonEnabled = hasVoiceSearch();
			if (mVoiceButtonEnabled)
			{
				// Disable the microphone on the keyboard, as a mic is displayed near the text box
				// TODO: use imeOptions to disable voice input when the new API will be available
				mQueryTextView.setPrivateImeOptions(IME_OPTION_NO_MICROPHONE);
			}
			updateViewsVisibility(isIconified());
		}

		/// <summary>Sets the APP_DATA for legacy SearchDialog use.</summary>
		/// <remarks>Sets the APP_DATA for legacy SearchDialog use.</remarks>
		/// <param name="appSearchData">bundle provided by the app when launching the search dialog
		/// 	</param>
		/// <hide></hide>
		public virtual void setAppSearchData(android.os.Bundle appSearchData)
		{
			mAppSearchData = appSearchData;
		}

		/// <summary>Sets the IME options on the query text field.</summary>
		/// <remarks>Sets the IME options on the query text field.</remarks>
		/// <seealso cref="TextView.setImeOptions(int)">TextView.setImeOptions(int)</seealso>
		/// <param name="imeOptions">the options to set on the query text field</param>
		/// <attr>ref android.R.styleable#SearchView_imeOptions</attr>
		public virtual void setImeOptions(int imeOptions)
		{
			mQueryTextView.setImeOptions(imeOptions);
		}

		/// <summary>Sets the input type on the query text field.</summary>
		/// <remarks>Sets the input type on the query text field.</remarks>
		/// <seealso cref="TextView.setInputType(int)">TextView.setInputType(int)</seealso>
		/// <param name="inputType">the input type to set on the query text field</param>
		/// <attr>ref android.R.styleable#SearchView_inputType</attr>
		public virtual void setInputType(int inputType)
		{
			mQueryTextView.setInputType(inputType);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool requestFocus(int direction, android.graphics.Rect previouslyFocusedRect
			)
		{
			// Don't accept focus if in the middle of clearing focus
			if (mClearingFocus)
			{
				return false;
			}
			// Check if SearchView is focusable.
			if (!isFocusable())
			{
				return false;
			}
			// If it is not iconified, then give the focus to the text field
			if (!isIconified())
			{
				bool result = mQueryTextView.requestFocus(direction, previouslyFocusedRect);
				if (result)
				{
					updateViewsVisibility(false);
				}
				return result;
			}
			else
			{
				return base.requestFocus(direction, previouslyFocusedRect);
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void clearFocus()
		{
			mClearingFocus = true;
			setImeVisibility(false);
			base.clearFocus();
			mQueryTextView.clearFocus();
			mClearingFocus = false;
		}

		/// <summary>Sets a listener for user actions within the SearchView.</summary>
		/// <remarks>Sets a listener for user actions within the SearchView.</remarks>
		/// <param name="listener">
		/// the listener object that receives callbacks when the user performs
		/// actions in the SearchView such as clicking on buttons or typing a query.
		/// </param>
		public virtual void setOnQueryTextListener(android.widget.SearchView.OnQueryTextListener
			 listener)
		{
			mOnQueryChangeListener = listener;
		}

		/// <summary>Sets a listener to inform when the user closes the SearchView.</summary>
		/// <remarks>Sets a listener to inform when the user closes the SearchView.</remarks>
		/// <param name="listener">the listener to call when the user closes the SearchView.</param>
		public virtual void setOnCloseListener(android.widget.SearchView.OnCloseListener 
			listener)
		{
			mOnCloseListener = listener;
		}

		/// <summary>Sets a listener to inform when the focus of the query text field changes.
		/// 	</summary>
		/// <remarks>Sets a listener to inform when the focus of the query text field changes.
		/// 	</remarks>
		/// <param name="listener">the listener to inform of focus changes.</param>
		public virtual void setOnQueryTextFocusChangeListener(android.view.View.OnFocusChangeListener
			 listener)
		{
			mOnQueryTextFocusChangeListener = listener;
		}

		/// <summary>Sets a listener to inform when a suggestion is focused or clicked.</summary>
		/// <remarks>Sets a listener to inform when a suggestion is focused or clicked.</remarks>
		/// <param name="listener">the listener to inform of suggestion selection events.</param>
		public virtual void setOnSuggestionListener(android.widget.SearchView.OnSuggestionListener
			 listener)
		{
			mOnSuggestionListener = listener;
		}

		/// <summary>Sets a listener to inform when the search button is pressed.</summary>
		/// <remarks>
		/// Sets a listener to inform when the search button is pressed. This is only
		/// relevant when the text field is not visible by default. Calling
		/// <see cref="setIconified(bool)">setIconified(false)</see>
		/// can also cause this listener to be informed.
		/// </remarks>
		/// <param name="listener">
		/// the listener to inform when the search button is clicked or
		/// the text field is programmatically de-iconified.
		/// </param>
		public virtual void setOnSearchClickListener(android.view.View.OnClickListener listener
			)
		{
			mOnSearchClickListener = listener;
		}

		/// <summary>Returns the query string currently in the text field.</summary>
		/// <remarks>Returns the query string currently in the text field.</remarks>
		/// <returns>the query string</returns>
		public virtual java.lang.CharSequence getQuery()
		{
			return ((android.text.Editable)mQueryTextView.getText());
		}

		/// <summary>Sets a query string in the text field and optionally submits the query as well.
		/// 	</summary>
		/// <remarks>Sets a query string in the text field and optionally submits the query as well.
		/// 	</remarks>
		/// <param name="query">
		/// the query string. This replaces any query text already present in the
		/// text field.
		/// </param>
		/// <param name="submit">
		/// whether to submit the query right now or only update the contents of
		/// text field.
		/// </param>
		public virtual void setQuery(java.lang.CharSequence query, bool submit)
		{
			mQueryTextView.setText(query);
			if (query != null)
			{
				mQueryTextView.setSelection(query.Length);
				mUserQuery = query;
			}
			// If the query is not empty and submit is requested, submit the query
			if (submit && !android.text.TextUtils.isEmpty(query))
			{
				onSubmitQuery();
			}
		}

		/// <summary>Sets the hint text to display in the query text field.</summary>
		/// <remarks>
		/// Sets the hint text to display in the query text field. This overrides any hint specified
		/// in the SearchableInfo.
		/// </remarks>
		/// <param name="hint">the hint text to display</param>
		/// <attr>ref android.R.styleable#SearchView_queryHint</attr>
		public virtual void setQueryHint(java.lang.CharSequence hint)
		{
			mQueryHint = hint;
			updateQueryHint();
		}

		/// <summary>Sets the default or resting state of the search field.</summary>
		/// <remarks>
		/// Sets the default or resting state of the search field. If true, a single search icon is
		/// shown by default and expands to show the text field and other buttons when pressed. Also,
		/// if the default state is iconified, then it collapses to that state when the close button
		/// is pressed. Changes to this property will take effect immediately.
		/// <p>The default value is true.</p>
		/// </remarks>
		/// <param name="iconified">whether the search field should be iconified by default</param>
		/// <attr>ref android.R.styleable#SearchView_iconifiedByDefault</attr>
		public virtual void setIconifiedByDefault(bool iconified)
		{
			if (mIconifiedByDefault == iconified)
			{
				return;
			}
			mIconifiedByDefault = iconified;
			updateViewsVisibility(iconified);
			updateQueryHint();
		}

		/// <summary>Returns the default iconified state of the search field.</summary>
		/// <remarks>Returns the default iconified state of the search field.</remarks>
		/// <returns></returns>
		public virtual bool isIconfiedByDefault()
		{
			return mIconifiedByDefault;
		}

		/// <summary>Iconifies or expands the SearchView.</summary>
		/// <remarks>
		/// Iconifies or expands the SearchView. Any query text is cleared when iconified. This is
		/// a temporary state and does not override the default iconified state set by
		/// <see cref="setIconifiedByDefault(bool)">setIconifiedByDefault(bool)</see>
		/// . If the default state is iconified, then
		/// a false here will only be valid until the user closes the field. And if the default
		/// state is expanded, then a true here will only clear the text field and not close it.
		/// </remarks>
		/// <param name="iconify">
		/// a true value will collapse the SearchView to an icon, while a false will
		/// expand it.
		/// </param>
		public virtual void setIconified(bool iconify)
		{
			if (iconify)
			{
				onCloseClicked();
			}
			else
			{
				onSearchClicked();
			}
		}

		/// <summary>Returns the current iconified state of the SearchView.</summary>
		/// <remarks>Returns the current iconified state of the SearchView.</remarks>
		/// <returns>
		/// true if the SearchView is currently iconified, false if the search field is
		/// fully visible.
		/// </returns>
		public virtual bool isIconified()
		{
			return mIconified;
		}

		/// <summary>Enables showing a submit button when the query is non-empty.</summary>
		/// <remarks>
		/// Enables showing a submit button when the query is non-empty. In cases where the SearchView
		/// is being used to filter the contents of the current activity and doesn't launch a separate
		/// results activity, then the submit button should be disabled.
		/// </remarks>
		/// <param name="enabled">
		/// true to show a submit button for submitting queries, false if a submit
		/// button is not required.
		/// </param>
		public virtual void setSubmitButtonEnabled(bool enabled)
		{
			mSubmitButtonEnabled = enabled;
			updateViewsVisibility(isIconified());
		}

		/// <summary>Returns whether the submit button is enabled when necessary or never displayed.
		/// 	</summary>
		/// <remarks>Returns whether the submit button is enabled when necessary or never displayed.
		/// 	</remarks>
		/// <returns>whether the submit button is enabled automatically when necessary</returns>
		public virtual bool isSubmitButtonEnabled()
		{
			return mSubmitButtonEnabled;
		}

		/// <summary>
		/// Specifies if a query refinement button should be displayed alongside each suggestion
		/// or if it should depend on the flags set in the individual items retrieved from the
		/// suggestions provider.
		/// </summary>
		/// <remarks>
		/// Specifies if a query refinement button should be displayed alongside each suggestion
		/// or if it should depend on the flags set in the individual items retrieved from the
		/// suggestions provider. Clicking on the query refinement button will replace the text
		/// in the query text field with the text from the suggestion. This flag only takes effect
		/// if a SearchableInfo has been specified with
		/// <see cref="setSearchableInfo(android.app.SearchableInfo)">setSearchableInfo(android.app.SearchableInfo)
		/// 	</see>
		/// and not when using a custom adapter.
		/// </remarks>
		/// <param name="enable">
		/// true if all items should have a query refinement button, false if only
		/// those items that have a query refinement flag set should have the button.
		/// </param>
		/// <seealso cref="android.app.SearchManager.SUGGEST_COLUMN_FLAGS">android.app.SearchManager.SUGGEST_COLUMN_FLAGS
		/// 	</seealso>
		/// <seealso cref="android.app.SearchManager.FLAG_QUERY_REFINEMENT">android.app.SearchManager.FLAG_QUERY_REFINEMENT
		/// 	</seealso>
		public virtual void setQueryRefinementEnabled(bool enable)
		{
			mQueryRefinement = enable;
			if (mSuggestionsAdapter is android.widget.SuggestionsAdapter)
			{
				((android.widget.SuggestionsAdapter)mSuggestionsAdapter).setQueryRefinement(enable
					 ? android.widget.SuggestionsAdapter.REFINE_ALL : android.widget.SuggestionsAdapter
					.REFINE_BY_ENTRY);
			}
		}

		/// <summary>Returns whether query refinement is enabled for all items or only specific ones.
		/// 	</summary>
		/// <remarks>Returns whether query refinement is enabled for all items or only specific ones.
		/// 	</remarks>
		/// <returns>true if enabled for all items, false otherwise.</returns>
		public virtual bool isQueryRefinementEnabled()
		{
			return mQueryRefinement;
		}

		/// <summary>You can set a custom adapter if you wish.</summary>
		/// <remarks>
		/// You can set a custom adapter if you wish. Otherwise the default adapter is used to
		/// display the suggestions from the suggestions provider associated with the SearchableInfo.
		/// </remarks>
		/// <seealso cref="setSearchableInfo(android.app.SearchableInfo)">setSearchableInfo(android.app.SearchableInfo)
		/// 	</seealso>
		public virtual void setSuggestionsAdapter(android.widget.CursorAdapter adapter)
		{
			mSuggestionsAdapter = adapter;
			mQueryTextView.setAdapter(mSuggestionsAdapter);
		}

		/// <summary>Returns the adapter used for suggestions, if any.</summary>
		/// <remarks>Returns the adapter used for suggestions, if any.</remarks>
		/// <returns>the suggestions adapter</returns>
		public virtual android.widget.CursorAdapter getSuggestionsAdapter()
		{
			return mSuggestionsAdapter;
		}

		/// <summary>Makes the view at most this many pixels wide</summary>
		/// <attr>ref android.R.styleable#SearchView_maxWidth</attr>
		public virtual void setMaxWidth(int maxpixels)
		{
			mMaxWidth = maxpixels;
			requestLayout();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			// Let the standard measurements take effect in iconified state.
			if (isIconified())
			{
				base.onMeasure(widthMeasureSpec, heightMeasureSpec);
				return;
			}
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int width = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			switch (widthMode)
			{
				case android.view.View.MeasureSpec.AT_MOST:
				{
					// If there is an upper limit, don't exceed maximum width (explicit or implicit)
					if (mMaxWidth > 0)
					{
						width = System.Math.Min(mMaxWidth, width);
					}
					else
					{
						width = System.Math.Min(getPreferredWidth(), width);
					}
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					// If an exact width is specified, still don't exceed any specified maximum width
					if (mMaxWidth > 0)
					{
						width = System.Math.Min(mMaxWidth, width);
					}
					break;
				}

				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					// Use maximum width, if specified, else preferred width
					width = mMaxWidth > 0 ? mMaxWidth : getPreferredWidth();
					break;
				}
			}
			widthMode = android.view.View.MeasureSpec.EXACTLY;
			base.onMeasure(android.view.View.MeasureSpec.makeMeasureSpec(width, widthMode), heightMeasureSpec
				);
		}

		private int getPreferredWidth()
		{
			return getContext().getResources().getDimensionPixelSize(android.@internal.R.dimen
				.search_view_preferred_width);
		}

		private void updateViewsVisibility(bool collapsed)
		{
			mIconified = collapsed;
			// Visibility of views that are visible when collapsed
			int visCollapsed = collapsed ? VISIBLE : GONE;
			// Is there text in the query
			bool hasText = !android.text.TextUtils.isEmpty(((android.text.Editable)mQueryTextView
				.getText()));
			mSearchButton.setVisibility(visCollapsed);
			updateSubmitButton(hasText);
			mSearchEditFrame.setVisibility(collapsed ? GONE : VISIBLE);
			mSearchHintIcon.setVisibility(mIconifiedByDefault ? GONE : VISIBLE);
			updateCloseButton();
			updateVoiceButton(!hasText);
			updateSubmitArea();
		}

		private bool hasVoiceSearch()
		{
			if (mSearchable != null && mSearchable.getVoiceSearchEnabled())
			{
				android.content.Intent testIntent = null;
				if (mSearchable.getVoiceSearchLaunchWebSearch())
				{
					testIntent = mVoiceWebSearchIntent;
				}
				else
				{
					if (mSearchable.getVoiceSearchLaunchRecognizer())
					{
						testIntent = mVoiceAppSearchIntent;
					}
				}
				if (testIntent != null)
				{
					android.content.pm.ResolveInfo ri = getContext().getPackageManager().resolveActivity
						(testIntent, android.content.pm.PackageManager.MATCH_DEFAULT_ONLY);
					return ri != null;
				}
			}
			return false;
		}

		private bool isSubmitAreaEnabled()
		{
			return (mSubmitButtonEnabled || mVoiceButtonEnabled) && !isIconified();
		}

		private void updateSubmitButton(bool hasText)
		{
			int visibility = GONE;
			if (isSubmitAreaEnabled() && hasFocus() && (hasText || !mVoiceButtonEnabled))
			{
				visibility = VISIBLE;
			}
			mSubmitButton.setVisibility(visibility);
		}

		private void updateSubmitArea()
		{
			int visibility = GONE;
			if (isSubmitAreaEnabled() && (mSubmitButton.getVisibility() == VISIBLE || mVoiceButton
				.getVisibility() == VISIBLE))
			{
				visibility = VISIBLE;
			}
			mSubmitArea.setVisibility(visibility);
		}

		private void updateCloseButton()
		{
			bool hasText = !android.text.TextUtils.isEmpty(((android.text.Editable)mQueryTextView
				.getText()));
			// Should we show the close button? It is not shown if there's no focus,
			// field is not iconified by default and there is no text in it.
			bool showClose = hasText || (mIconifiedByDefault && !mExpandedInActionView);
			mCloseButton.setVisibility(showClose ? VISIBLE : GONE);
			mCloseButton.getDrawable().setState(hasText ? ENABLED_STATE_SET : EMPTY_STATE_SET
				);
		}

		private void postUpdateFocusedState()
		{
			post(mUpdateDrawableStateRunnable);
		}

		private void updateFocusedState()
		{
			bool focused = mQueryTextView.hasFocus();
			mSearchPlate.getBackground().setState(focused ? FOCUSED_STATE_SET : EMPTY_STATE_SET
				);
			mSubmitArea.getBackground().setState(focused ? FOCUSED_STATE_SET : EMPTY_STATE_SET
				);
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			removeCallbacks(mUpdateDrawableStateRunnable);
			base.onDetachedFromWindow();
		}

		private void setImeVisibility(bool visible)
		{
			if (visible)
			{
				post(mShowImeRunnable);
			}
			else
			{
				removeCallbacks(mShowImeRunnable);
				android.view.inputmethod.InputMethodManager imm = (android.view.inputmethod.InputMethodManager
					)getContext().getSystemService(android.content.Context.INPUT_METHOD_SERVICE);
				if (imm != null)
				{
					imm.hideSoftInputFromWindow(getWindowToken(), 0);
				}
			}
		}

		/// <summary>Called by the SuggestionsAdapter</summary>
		/// <hide></hide>
		internal virtual void onQueryRefine(java.lang.CharSequence queryText)
		{
			setQuery(queryText);
		}

		private sealed class _OnClickListener_787 : android.view.View.OnClickListener
		{
			public _OnClickListener_787(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				if (v == this._enclosing.mSearchButton)
				{
					this._enclosing.onSearchClicked();
				}
				else
				{
					if (v == this._enclosing.mCloseButton)
					{
						this._enclosing.onCloseClicked();
					}
					else
					{
						if (v == this._enclosing.mSubmitButton)
						{
							this._enclosing.onSubmitQuery();
						}
						else
						{
							if (v == this._enclosing.mVoiceButton)
							{
								this._enclosing.onVoiceClicked();
							}
							else
							{
								if (v == this._enclosing.mQueryTextView)
								{
									this._enclosing.forceSuggestionQuery();
								}
							}
						}
					}
				}
			}

			private readonly SearchView _enclosing;
		}

		private readonly android.view.View.OnClickListener mOnClickListener;

		/// <summary>Handles the key down event for dealing with action keys.</summary>
		/// <remarks>Handles the key down event for dealing with action keys.</remarks>
		/// <param name="keyCode">
		/// This is the keycode of the typed key, and is the same value as
		/// found in the KeyEvent parameter.
		/// </param>
		/// <param name="event">The complete event record for the typed key</param>
		/// <returns>true if the event was handled here, or false if not.</returns>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			if (mSearchable == null)
			{
				return false;
			}
			// if it's an action specified by the searchable activity, launch the
			// entered query with the action key
			android.app.SearchableInfo.ActionKeyInfo actionKey = mSearchable.findActionKey(keyCode
				);
			if ((actionKey != null) && (actionKey.getQueryActionMsg() != null))
			{
				launchQuerySearch(keyCode, actionKey.getQueryActionMsg(), ((android.text.Editable
					)mQueryTextView.getText()).ToString());
				return true;
			}
			return base.onKeyDown(keyCode, @event);
		}

		private sealed class _OnKeyListener_836 : android.view.View.OnKeyListener
		{
			public _OnKeyListener_836(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnKeyListener")]
			public bool onKey(android.view.View v, int keyCode, android.view.KeyEvent @event)
			{
				// guard against possible race conditions
				if (this._enclosing.mSearchable == null)
				{
					return false;
				}
				// If a suggestion is selected, handle enter, search key, and action keys
				// as presses on the selected suggestion
				if (this._enclosing.mQueryTextView.isPopupShowing() && this._enclosing.mQueryTextView
					.getListSelection() != android.widget.AdapterView.INVALID_POSITION)
				{
					return this._enclosing.onSuggestionsKey(v, keyCode, @event);
				}
				// If there is text in the query box, handle enter, and action keys
				// The search key is handled by the dialog's onKeyDown().
				if (!this._enclosing.mQueryTextView.isEmpty() && @event.hasNoModifiers())
				{
					if (@event.getAction() == android.view.KeyEvent.ACTION_UP)
					{
						if (keyCode == android.view.KeyEvent.KEYCODE_ENTER)
						{
							v.cancelLongPress();
							// Launch as a regular search.
							this._enclosing.launchQuerySearch(android.view.KeyEvent.KEYCODE_UNKNOWN, null, ((
								android.text.Editable)this._enclosing.mQueryTextView.getText()).ToString());
							return true;
						}
					}
					if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN)
					{
						android.app.SearchableInfo.ActionKeyInfo actionKey = this._enclosing.mSearchable.
							findActionKey(keyCode);
						if ((actionKey != null) && (actionKey.getQueryActionMsg() != null))
						{
							this._enclosing.launchQuerySearch(keyCode, actionKey.getQueryActionMsg(), ((android.text.Editable
								)this._enclosing.mQueryTextView.getText()).ToString());
							return true;
						}
					}
				}
				return false;
			}

			private readonly SearchView _enclosing;
		}

		/// <summary>
		/// React to the user typing "enter" or other hardwired keys while typing in
		/// the search box.
		/// </summary>
		/// <remarks>
		/// React to the user typing "enter" or other hardwired keys while typing in
		/// the search box. This handles these special keys while the edit box has
		/// focus.
		/// </remarks>
		internal android.view.View.OnKeyListener mTextKeyListener;

		/// <summary>React to the user typing while in the suggestions list.</summary>
		/// <remarks>
		/// React to the user typing while in the suggestions list. First, check for
		/// action keys. If not handled, try refocusing regular characters into the
		/// EditText.
		/// </remarks>
		private bool onSuggestionsKey(android.view.View v, int keyCode, android.view.KeyEvent
			 @event)
		{
			// guard against possible race conditions (late arrival after dismiss)
			if (mSearchable == null)
			{
				return false;
			}
			if (mSuggestionsAdapter == null)
			{
				return false;
			}
			if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.hasNoModifiers
				())
			{
				// First, check for enter or search (both of which we'll treat as a
				// "click")
				if (keyCode == android.view.KeyEvent.KEYCODE_ENTER || keyCode == android.view.KeyEvent
					.KEYCODE_SEARCH || keyCode == android.view.KeyEvent.KEYCODE_TAB)
				{
					int position = mQueryTextView.getListSelection();
					return onItemClicked(position, android.view.KeyEvent.KEYCODE_UNKNOWN, null);
				}
				// Next, check for left/right moves, which we use to "return" the
				// user to the edit view
				if (keyCode == android.view.KeyEvent.KEYCODE_DPAD_LEFT || keyCode == android.view.KeyEvent
					.KEYCODE_DPAD_RIGHT)
				{
					// give "focus" to text editor, with cursor at the beginning if
					// left key, at end if right key
					// TODO: Reverse left/right for right-to-left languages, e.g.
					// Arabic
					int selPoint = (keyCode == android.view.KeyEvent.KEYCODE_DPAD_LEFT) ? 0 : mQueryTextView
						.length();
					mQueryTextView.setSelection(selPoint);
					mQueryTextView.setListSelection(0);
					mQueryTextView.clearListSelection();
					mQueryTextView.ensureImeVisible(true);
					return true;
				}
				// Next, check for an "up and out" move
				if (keyCode == android.view.KeyEvent.KEYCODE_DPAD_UP && 0 == mQueryTextView.getListSelection
					())
				{
					// TODO: restoreUserQuery();
					// let ACTV complete the move
					return false;
				}
				// Next, check for an "action key"
				android.app.SearchableInfo.ActionKeyInfo actionKey = mSearchable.findActionKey(keyCode
					);
				if ((actionKey != null) && ((actionKey.getSuggestActionMsg() != null) || (actionKey
					.getSuggestActionMsgColumn() != null)))
				{
					// launch suggestion using action key column
					int position = mQueryTextView.getListSelection();
					if (position != android.widget.AdapterView.INVALID_POSITION)
					{
						android.database.Cursor c = mSuggestionsAdapter.getCursor();
						if (c.moveToPosition(position))
						{
							string actionMsg = getActionKeyMessage(c, actionKey);
							if (actionMsg != null && (actionMsg.Length > 0))
							{
								return onItemClicked(position, keyCode, actionMsg);
							}
						}
					}
				}
			}
			return false;
		}

		/// <summary>For a given suggestion and a given cursor row, get the action message.</summary>
		/// <remarks>
		/// For a given suggestion and a given cursor row, get the action message. If
		/// not provided by the specific row/column, also check for a single
		/// definition (for the action key).
		/// </remarks>
		/// <param name="c">The cursor providing suggestions</param>
		/// <param name="actionKey">The actionkey record being examined</param>
		/// <returns>
		/// Returns a string, or null if no action key message for this
		/// suggestion
		/// </returns>
		private static string getActionKeyMessage(android.database.Cursor c, android.app.SearchableInfo
			.ActionKeyInfo actionKey)
		{
			string result = null;
			// check first in the cursor data, for a suggestion-specific message
			string column = actionKey.getSuggestActionMsgColumn();
			if (column != null)
			{
				result = android.widget.SuggestionsAdapter.getColumnString(c, column);
			}
			// If the cursor didn't give us a message, see if there's a single
			// message defined
			// for the actionkey (for all suggestions)
			if (result == null)
			{
				result = actionKey.getSuggestActionMsg();
			}
			return result;
		}

		private int getSearchIconId()
		{
			android.util.TypedValue outValue = new android.util.TypedValue();
			getContext().getTheme().resolveAttribute(android.@internal.R.attr.searchViewSearchIcon
				, outValue, true);
			return outValue.resourceId;
		}

		private java.lang.CharSequence getDecoratedHint(java.lang.CharSequence hintText)
		{
			// If the field is always expanded, then don't add the search icon to the hint
			if (!mIconifiedByDefault)
			{
				return hintText;
			}
			android.text.SpannableStringBuilder ssb = new android.text.SpannableStringBuilder
				(java.lang.CharSequenceProxy.Wrap("   "));
			// for the icon
			ssb.append(hintText);
			android.graphics.drawable.Drawable searchIcon = getContext().getResources().getDrawable
				(getSearchIconId());
			int textSize = (int)(mQueryTextView.getTextSize() * 1.25);
			searchIcon.setBounds(0, 0, textSize, textSize);
			ssb.setSpan(new android.text.style.ImageSpan(searchIcon), 1, 2, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
				);
			return ssb;
		}

		private void updateQueryHint()
		{
			if (mQueryHint != null)
			{
				mQueryTextView.setHint(getDecoratedHint(mQueryHint));
			}
			else
			{
				if (mSearchable != null)
				{
					java.lang.CharSequence hint = null;
					int hintId = mSearchable.getHintId();
					if (hintId != 0)
					{
						hint = java.lang.CharSequenceProxy.Wrap(getContext().getString(hintId));
					}
					if (hint != null)
					{
						mQueryTextView.setHint(getDecoratedHint(hint));
					}
				}
				else
				{
					mQueryTextView.setHint(getDecoratedHint(java.lang.CharSequenceProxy.Wrap(string.Empty
						)));
				}
			}
		}

		/// <summary>Updates the auto-complete text view.</summary>
		/// <remarks>Updates the auto-complete text view.</remarks>
		private void updateSearchAutoComplete()
		{
			mQueryTextView.setDropDownAnimationStyle(0);
			// no animation
			mQueryTextView.setThreshold(mSearchable.getSuggestThreshold());
			mQueryTextView.setImeOptions(mSearchable.getImeOptions());
			int inputType = mSearchable.getInputType();
			// We only touch this if the input type is set up for text (which it almost certainly
			// should be, in the case of search!)
			if ((inputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				// The existence of a suggestions authority is the proxy for "suggestions
				// are available here"
				inputType &= ~android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_COMPLETE;
				if (mSearchable.getSuggestAuthority() != null)
				{
					inputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_COMPLETE;
				}
			}
			mQueryTextView.setInputType(inputType);
			// attach the suggestions adapter, if suggestions are available
			// The existence of a suggestions authority is the proxy for "suggestions available here"
			if (mSearchable.getSuggestAuthority() != null)
			{
				mSuggestionsAdapter = new android.widget.SuggestionsAdapter(getContext(), this, mSearchable
					, mOutsideDrawablesCache);
				mQueryTextView.setAdapter(mSuggestionsAdapter);
				((android.widget.SuggestionsAdapter)mSuggestionsAdapter).setQueryRefinement(mQueryRefinement
					 ? android.widget.SuggestionsAdapter.REFINE_ALL : android.widget.SuggestionsAdapter
					.REFINE_BY_ENTRY);
			}
		}

		/// <summary>Update the visibility of the voice button.</summary>
		/// <remarks>
		/// Update the visibility of the voice button.  There are actually two voice search modes,
		/// either of which will activate the button.
		/// </remarks>
		/// <param name="empty">
		/// whether the search query text field is empty. If it is, then the other
		/// criteria apply to make the voice button visible.
		/// </param>
		private void updateVoiceButton(bool empty)
		{
			int visibility = GONE;
			if (mVoiceButtonEnabled && !isIconified() && empty)
			{
				visibility = VISIBLE;
				mSubmitButton.setVisibility(GONE);
			}
			mVoiceButton.setVisibility(visibility);
		}

		private sealed class _OnEditorActionListener_1059 : android.widget.TextView.OnEditorActionListener
		{
			public _OnEditorActionListener_1059(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			/// <summary>Called when the input method default action key is pressed.</summary>
			/// <remarks>Called when the input method default action key is pressed.</remarks>
			[Sharpen.ImplementsInterface(@"android.widget.TextView.OnEditorActionListener")]
			public bool onEditorAction(android.widget.TextView v, int actionId, android.view.KeyEvent
				 @event)
			{
				this._enclosing.onSubmitQuery();
				return true;
			}

			private readonly SearchView _enclosing;
		}

		private readonly android.widget.TextView.OnEditorActionListener mOnEditorActionListener;

		private void onTextChanged(java.lang.CharSequence newText)
		{
			java.lang.CharSequence text = ((android.text.Editable)mQueryTextView.getText());
			mUserQuery = text;
			bool hasText = !android.text.TextUtils.isEmpty(text);
			if (isSubmitButtonEnabled())
			{
				updateSubmitButton(hasText);
			}
			updateVoiceButton(!hasText);
			updateCloseButton();
			updateSubmitArea();
			if (mOnQueryChangeListener != null && !android.text.TextUtils.equals(newText, mOldQueryText
				))
			{
				mOnQueryChangeListener.onQueryTextChange(newText.ToString());
			}
			mOldQueryText = java.lang.CharSequenceProxy.Wrap(newText.ToString());
		}

		private void onSubmitQuery()
		{
			java.lang.CharSequence query = ((android.text.Editable)mQueryTextView.getText());
			if (query != null && android.text.TextUtils.getTrimmedLength(query) > 0)
			{
				if (mOnQueryChangeListener == null || !mOnQueryChangeListener.onQueryTextSubmit(query
					.ToString()))
				{
					if (mSearchable != null)
					{
						launchQuerySearch(android.view.KeyEvent.KEYCODE_UNKNOWN, null, query.ToString());
						setImeVisibility(false);
					}
					dismissSuggestions();
				}
			}
		}

		private void dismissSuggestions()
		{
			mQueryTextView.dismissDropDown();
		}

		private void onCloseClicked()
		{
			java.lang.CharSequence text = ((android.text.Editable)mQueryTextView.getText());
			if (android.text.TextUtils.isEmpty(text))
			{
				if (mIconifiedByDefault)
				{
					// If the app doesn't override the close behavior
					if (mOnCloseListener == null || !mOnCloseListener.onClose())
					{
						// hide the keyboard and remove focus
						clearFocus();
						// collapse the search field
						updateViewsVisibility(true);
					}
				}
			}
			else
			{
				mQueryTextView.setText(java.lang.CharSequenceProxy.Wrap(string.Empty));
				mQueryTextView.requestFocus();
				setImeVisibility(true);
			}
		}

		private void onSearchClicked()
		{
			updateViewsVisibility(false);
			mQueryTextView.requestFocus();
			setImeVisibility(true);
			if (mOnSearchClickListener != null)
			{
				mOnSearchClickListener.onClick(this);
			}
		}

		private void onVoiceClicked()
		{
			// guard against possible race conditions
			if (mSearchable == null)
			{
				return;
			}
			android.app.SearchableInfo searchable = mSearchable;
			try
			{
				if (searchable.getVoiceSearchLaunchWebSearch())
				{
					android.content.Intent webSearchIntent = createVoiceWebSearchIntent(mVoiceWebSearchIntent
						, searchable);
					getContext().startActivity(webSearchIntent);
				}
				else
				{
					if (searchable.getVoiceSearchLaunchRecognizer())
					{
						android.content.Intent appSearchIntent = createVoiceAppSearchIntent(mVoiceAppSearchIntent
							, searchable);
						getContext().startActivity(appSearchIntent);
					}
				}
			}
			catch (android.content.ActivityNotFoundException)
			{
				// Should not happen, since we check the availability of
				// voice search before showing the button. But just in case...
				android.util.Log.w(LOG_TAG, "Could not find voice search activity");
			}
		}

		internal virtual void onTextFocusChanged()
		{
			updateViewsVisibility(isIconified());
			// Delayed update to make sure that the focus has settled down and window focus changes
			// don't affect it. A synchronous update was not working.
			postUpdateFocusedState();
			if (mQueryTextView.hasFocus())
			{
				forceSuggestionQuery();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			base.onWindowFocusChanged(hasWindowFocus_1);
			postUpdateFocusedState();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.CollapsibleActionView")]
		public virtual void onActionViewCollapsed()
		{
			clearFocus();
			updateViewsVisibility(true);
			mQueryTextView.setText(java.lang.CharSequenceProxy.Wrap(string.Empty));
			mQueryTextView.setImeOptions(mCollapsedImeOptions);
			mExpandedInActionView = false;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.view.CollapsibleActionView")]
		public virtual void onActionViewExpanded()
		{
			mExpandedInActionView = true;
			mCollapsedImeOptions = mQueryTextView.getImeOptions();
			mQueryTextView.setImeOptions(mCollapsedImeOptions | android.view.inputmethod.EditorInfo
				.IME_FLAG_NO_FULLSCREEN);
			setIconified(false);
		}

		private void adjustDropDownSizeAndPosition()
		{
			if (mDropDownAnchor.getWidth() > 1)
			{
				android.content.res.Resources res = getContext().getResources();
				int anchorPadding = mSearchPlate.getPaddingLeft();
				android.graphics.Rect dropDownPadding = new android.graphics.Rect();
				int iconOffset = mIconifiedByDefault ? res.getDimensionPixelSize(android.@internal.R
					.dimen.dropdownitem_icon_width) + res.getDimensionPixelSize(android.@internal.R.
					dimen.dropdownitem_text_padding_left) : 0;
				mQueryTextView.getDropDownBackground().getPadding(dropDownPadding);
				mQueryTextView.setDropDownHorizontalOffset(-(dropDownPadding.left + iconOffset) +
					 anchorPadding);
				mQueryTextView.setDropDownWidth(mDropDownAnchor.getWidth() + dropDownPadding.left
					 + dropDownPadding.right + iconOffset - (anchorPadding));
			}
		}

		private bool onItemClicked(int position, int actionKey, string actionMsg)
		{
			if (mOnSuggestionListener == null || !mOnSuggestionListener.onSuggestionClick(position
				))
			{
				launchSuggestion(position, android.view.KeyEvent.KEYCODE_UNKNOWN, null);
				setImeVisibility(false);
				dismissSuggestions();
				return true;
			}
			return false;
		}

		private bool onItemSelected(int position)
		{
			if (mOnSuggestionListener == null || !mOnSuggestionListener.onSuggestionSelect(position
				))
			{
				rewriteQueryFromSuggestion(position);
				return true;
			}
			return false;
		}

		private sealed class _OnItemClickListener_1233 : android.widget.AdapterView.OnItemClickListener
		{
			public _OnItemClickListener_1233(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			/// <summary>Implements OnItemClickListener</summary>
			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public void onItemClick(object parent, android.view.View view, int position, long
				 id)
			{
				this._enclosing.onItemClicked(position, android.view.KeyEvent.KEYCODE_UNKNOWN, null
					);
			}

			private readonly SearchView _enclosing;
		}

		private readonly android.widget.AdapterView.OnItemClickListener mOnItemClickListener;

		private sealed class _OnItemSelectedListener_1244 : android.widget.AdapterView.OnItemSelectedListener
		{
			public _OnItemSelectedListener_1244(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			/// <summary>Implements OnItemSelectedListener</summary>
			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onItemSelected(object parent, android.view.View view, int position, long
				 id)
			{
				this._enclosing.onItemSelected(position);
			}

			/// <summary>Implements OnItemSelectedListener</summary>
			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onNothingSelected(object parent)
			{
			}

			private readonly SearchView _enclosing;
		}

		private readonly android.widget.AdapterView.OnItemSelectedListener mOnItemSelectedListener;

		/// <summary>Query rewriting.</summary>
		/// <remarks>Query rewriting.</remarks>
		private void rewriteQueryFromSuggestion(int position)
		{
			java.lang.CharSequence oldQuery = ((android.text.Editable)mQueryTextView.getText(
				));
			android.database.Cursor c = mSuggestionsAdapter.getCursor();
			if (c == null)
			{
				return;
			}
			if (c.moveToPosition(position))
			{
				// Get the new query from the suggestion.
				java.lang.CharSequence newQuery = mSuggestionsAdapter.convertToString(c);
				if (newQuery != null)
				{
					// The suggestion rewrites the query.
					// Update the text field, without getting new suggestions.
					setQuery(newQuery);
				}
				else
				{
					// The suggestion does not rewrite the query, restore the user's query.
					setQuery(oldQuery);
				}
			}
			else
			{
				// We got a bad position, restore the user's query.
				setQuery(oldQuery);
			}
		}

		/// <summary>Launches an intent based on a suggestion.</summary>
		/// <remarks>Launches an intent based on a suggestion.</remarks>
		/// <param name="position">The index of the suggestion to create the intent from.</param>
		/// <param name="actionKey">
		/// The key code of the action key that was pressed,
		/// or
		/// <see cref="android.view.KeyEvent.KEYCODE_UNKNOWN">android.view.KeyEvent.KEYCODE_UNKNOWN
		/// 	</see>
		/// if none.
		/// </param>
		/// <param name="actionMsg">
		/// The message for the action key that was pressed,
		/// or <code>null</code> if none.
		/// </param>
		/// <returns>true if a successful launch, false if could not (e.g. bad position).</returns>
		private bool launchSuggestion(int position, int actionKey, string actionMsg)
		{
			android.database.Cursor c = mSuggestionsAdapter.getCursor();
			if ((c != null) && c.moveToPosition(position))
			{
				android.content.Intent intent = createIntentFromSuggestion(c, actionKey, actionMsg
					);
				// launch the intent
				launchIntent(intent);
				return true;
			}
			return false;
		}

		/// <summary>Launches an intent, including any special intent handling.</summary>
		/// <remarks>Launches an intent, including any special intent handling.</remarks>
		private void launchIntent(android.content.Intent intent)
		{
			if (intent == null)
			{
				return;
			}
			try
			{
				// If the intent was created from a suggestion, it will always have an explicit
				// component here.
				getContext().startActivity(intent);
			}
			catch (java.lang.RuntimeException ex)
			{
				android.util.Log.e(LOG_TAG, "Failed launch activity: " + intent, ex);
			}
		}

		/// <summary>Sets the text in the query box, without updating the suggestions.</summary>
		/// <remarks>Sets the text in the query box, without updating the suggestions.</remarks>
		private void setQuery(java.lang.CharSequence query)
		{
			mQueryTextView.setText(query, true);
			// Move the cursor to the end
			mQueryTextView.setSelection(android.text.TextUtils.isEmpty(query) ? 0 : query.Length
				);
		}

		private void launchQuerySearch(int actionKey, string actionMsg, string query)
		{
			string action = android.content.Intent.ACTION_SEARCH;
			android.content.Intent intent = createIntent(action, null, null, query, actionKey
				, actionMsg);
			getContext().startActivity(intent);
		}

		/// <summary>Constructs an intent from the given information and the search dialog state.
		/// 	</summary>
		/// <remarks>Constructs an intent from the given information and the search dialog state.
		/// 	</remarks>
		/// <param name="action">Intent action.</param>
		/// <param name="data">Intent data, or <code>null</code>.</param>
		/// <param name="extraData">
		/// Data for
		/// <see cref="android.app.SearchManager.EXTRA_DATA_KEY">android.app.SearchManager.EXTRA_DATA_KEY
		/// 	</see>
		/// or <code>null</code>.
		/// </param>
		/// <param name="query">Intent query, or <code>null</code>.</param>
		/// <param name="actionKey">
		/// The key code of the action key that was pressed,
		/// or
		/// <see cref="android.view.KeyEvent.KEYCODE_UNKNOWN">android.view.KeyEvent.KEYCODE_UNKNOWN
		/// 	</see>
		/// if none.
		/// </param>
		/// <param name="actionMsg">
		/// The message for the action key that was pressed,
		/// or <code>null</code> if none.
		/// </param>
		/// <param name="mode">
		/// The search mode, one of the acceptable values for
		/// <see cref="android.app.SearchManager.SEARCH_MODE">android.app.SearchManager.SEARCH_MODE
		/// 	</see>
		/// , or
		/// <code>null</code>
		/// .
		/// </param>
		/// <returns>The intent.</returns>
		private android.content.Intent createIntent(string action, System.Uri data, string
			 extraData, string query, int actionKey, string actionMsg)
		{
			// Now build the Intent
			android.content.Intent intent = new android.content.Intent(action);
			intent.addFlags(android.content.Intent.FLAG_ACTIVITY_NEW_TASK);
			// We need CLEAR_TOP to avoid reusing an old task that has other activities
			// on top of the one we want. We don't want to do this in in-app search though,
			// as it can be destructive to the activity stack.
			if (data != null)
			{
				intent.setData(data);
			}
			intent.putExtra(android.app.SearchManager.USER_QUERY, mUserQuery);
			if (query != null)
			{
				intent.putExtra(android.app.SearchManager.QUERY, query);
			}
			if (extraData != null)
			{
				intent.putExtra(android.app.SearchManager.EXTRA_DATA_KEY, extraData);
			}
			if (mAppSearchData != null)
			{
				intent.putExtra(android.app.SearchManager.APP_DATA, mAppSearchData);
			}
			if (actionKey != android.view.KeyEvent.KEYCODE_UNKNOWN)
			{
				intent.putExtra(android.app.SearchManager.ACTION_KEY, actionKey);
				intent.putExtra(android.app.SearchManager.ACTION_MSG, actionMsg);
			}
			intent.setComponent(mSearchable.getSearchActivity());
			return intent;
		}

		/// <summary>Create and return an Intent that can launch the voice search activity for web search.
		/// 	</summary>
		/// <remarks>Create and return an Intent that can launch the voice search activity for web search.
		/// 	</remarks>
		private android.content.Intent createVoiceWebSearchIntent(android.content.Intent 
			baseIntent, android.app.SearchableInfo searchable)
		{
			android.content.Intent voiceIntent = new android.content.Intent(baseIntent);
			android.content.ComponentName searchActivity = searchable.getSearchActivity();
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_CALLING_PACKAGE, searchActivity
				 == null ? null : searchActivity.flattenToShortString());
			return voiceIntent;
		}

		/// <summary>
		/// Create and return an Intent that can launch the voice search activity, perform a specific
		/// voice transcription, and forward the results to the searchable activity.
		/// </summary>
		/// <remarks>
		/// Create and return an Intent that can launch the voice search activity, perform a specific
		/// voice transcription, and forward the results to the searchable activity.
		/// </remarks>
		/// <param name="baseIntent">The voice app search intent to start from</param>
		/// <returns>A completely-configured intent ready to send to the voice search activity
		/// 	</returns>
		private android.content.Intent createVoiceAppSearchIntent(android.content.Intent 
			baseIntent, android.app.SearchableInfo searchable)
		{
			android.content.ComponentName searchActivity = searchable.getSearchActivity();
			// create the necessary intent to set up a search-and-forward operation
			// in the voice search system.   We have to keep the bundle separate,
			// because it becomes immutable once it enters the PendingIntent
			android.content.Intent queryIntent = new android.content.Intent(android.content.Intent
				.ACTION_SEARCH);
			queryIntent.setComponent(searchActivity);
			android.app.PendingIntent pending = android.app.PendingIntent.getActivity(getContext
				(), 0, queryIntent, android.app.PendingIntent.FLAG_ONE_SHOT);
			// Now set up the bundle that will be inserted into the pending intent
			// when it's time to do the search.  We always build it here (even if empty)
			// because the voice search activity will always need to insert "QUERY" into
			// it anyway.
			android.os.Bundle queryExtras = new android.os.Bundle();
			// Now build the intent to launch the voice search.  Add all necessary
			// extras to launch the voice recognizer, and then all the necessary extras
			// to forward the results to the searchable activity
			android.content.Intent voiceIntent = new android.content.Intent(baseIntent);
			// Add all of the configuration options supplied by the searchable's metadata
			string languageModel = android.speech.RecognizerIntent.LANGUAGE_MODEL_FREE_FORM;
			string prompt = null;
			string language = null;
			int maxResults = 1;
			android.content.res.Resources resources = getResources();
			if (searchable.getVoiceLanguageModeId() != 0)
			{
				languageModel = resources.getString(searchable.getVoiceLanguageModeId());
			}
			if (searchable.getVoicePromptTextId() != 0)
			{
				prompt = resources.getString(searchable.getVoicePromptTextId());
			}
			if (searchable.getVoiceLanguageId() != 0)
			{
				language = resources.getString(searchable.getVoiceLanguageId());
			}
			if (searchable.getVoiceMaxResults() != 0)
			{
				maxResults = searchable.getVoiceMaxResults();
			}
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_LANGUAGE_MODEL, languageModel
				);
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_PROMPT, prompt);
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_LANGUAGE, language);
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_MAX_RESULTS, maxResults
				);
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_CALLING_PACKAGE, searchActivity
				 == null ? null : searchActivity.flattenToShortString());
			// Add the values that configure forwarding the results
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_RESULTS_PENDINGINTENT, 
				pending);
			voiceIntent.putExtra(android.speech.RecognizerIntent.EXTRA_RESULTS_PENDINGINTENT_BUNDLE
				, queryExtras);
			return voiceIntent;
		}

		/// <summary>
		/// When a particular suggestion has been selected, perform the various lookups required
		/// to use the suggestion.
		/// </summary>
		/// <remarks>
		/// When a particular suggestion has been selected, perform the various lookups required
		/// to use the suggestion.  This includes checking the cursor for suggestion-specific data,
		/// and/or falling back to the XML for defaults;  It also creates REST style Uri data when
		/// the suggestion includes a data id.
		/// </remarks>
		/// <param name="c">The suggestions cursor, moved to the row of the user's selection</param>
		/// <param name="actionKey">
		/// The key code of the action key that was pressed,
		/// or
		/// <see cref="android.view.KeyEvent.KEYCODE_UNKNOWN">android.view.KeyEvent.KEYCODE_UNKNOWN
		/// 	</see>
		/// if none.
		/// </param>
		/// <param name="actionMsg">
		/// The message for the action key that was pressed,
		/// or <code>null</code> if none.
		/// </param>
		/// <returns>An intent for the suggestion at the cursor's position.</returns>
		private android.content.Intent createIntentFromSuggestion(android.database.Cursor
			 c, int actionKey, string actionMsg)
		{
			try
			{
				// use specific action if supplied, or default action if supplied, or fixed default
				string action = android.widget.SuggestionsAdapter.getColumnString(c, android.app.SearchManager
					.SUGGEST_COLUMN_INTENT_ACTION);
				if (action == null)
				{
					action = mSearchable.getSuggestIntentAction();
				}
				if (action == null)
				{
					action = android.content.Intent.ACTION_SEARCH;
				}
				// use specific data if supplied, or default data if supplied
				string data = android.widget.SuggestionsAdapter.getColumnString(c, android.app.SearchManager
					.SUGGEST_COLUMN_INTENT_DATA);
				if (data == null)
				{
					data = mSearchable.getSuggestIntentData();
				}
				// then, if an ID was provided, append it.
				if (data != null)
				{
					string id = android.widget.SuggestionsAdapter.getColumnString(c, android.app.SearchManager
						.SUGGEST_COLUMN_INTENT_DATA_ID);
					if (id != null)
					{
						data = data + "/" + Sharpen.Util.EncodeUri(id);
					}
				}
				System.Uri dataUri = (data == null) ? null : Sharpen.Util.ParseUri(data);
				string query = android.widget.SuggestionsAdapter.getColumnString(c, android.app.SearchManager
					.SUGGEST_COLUMN_QUERY);
				string extraData = android.widget.SuggestionsAdapter.getColumnString(c, android.app.SearchManager
					.SUGGEST_COLUMN_INTENT_EXTRA_DATA);
				return createIntent(action, dataUri, extraData, query, actionKey, actionMsg);
			}
			catch (java.lang.RuntimeException e)
			{
				int rowNum;
				try
				{
					// be really paranoid now
					rowNum = c.getPosition();
				}
				catch (java.lang.RuntimeException)
				{
					rowNum = -1;
				}
				android.util.Log.w(LOG_TAG, "Search Suggestions cursor at row " + rowNum + " returned exception"
					 + e.ToString());
				return null;
			}
		}

		private void forceSuggestionQuery()
		{
			mQueryTextView.doBeforeTextChanged();
			mQueryTextView.doAfterTextChanged();
		}

		internal static bool isLandscapeMode(android.content.Context context)
		{
			return context.getResources().getConfiguration().orientation == android.content.res.Configuration
				.ORIENTATION_LANDSCAPE;
		}

		private sealed class _TextWatcher_1530 : android.text.TextWatcher
		{
			public _TextWatcher_1530(SearchView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public void beforeTextChanged(java.lang.CharSequence s, int start, int before, int
				 after)
			{
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public void onTextChanged(java.lang.CharSequence s, int start, int before, int after
				)
			{
				this._enclosing.onTextChanged(s);
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public void afterTextChanged(android.text.Editable s)
			{
			}

			private readonly SearchView _enclosing;
		}

		/// <summary>Callback to watch the text field for empty/non-empty</summary>
		private android.text.TextWatcher mTextWatcher;

		/// <summary>Local subclass for AutoCompleteTextView.</summary>
		/// <remarks>Local subclass for AutoCompleteTextView.</remarks>
		/// <hide></hide>
		public class SearchAutoComplete : android.widget.AutoCompleteTextView
		{
			private int mThreshold;

			private android.widget.SearchView mSearchView;

			public SearchAutoComplete(android.content.Context context) : base(context)
			{
				mThreshold = getThreshold();
			}

			public SearchAutoComplete(android.content.Context context, android.util.AttributeSet
				 attrs) : base(context, attrs)
			{
				mThreshold = getThreshold();
			}

			public SearchAutoComplete(android.content.Context context, android.util.AttributeSet
				 attrs, int defStyle) : base(context, attrs, defStyle)
			{
				mThreshold = getThreshold();
			}

			internal virtual void setSearchView(android.widget.SearchView searchView)
			{
				mSearchView = searchView;
			}

			[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
			public override void setThreshold(int threshold)
			{
				base.setThreshold(threshold);
				mThreshold = threshold;
			}

			/// <summary>Returns true if the text field is empty, or contains only whitespace.</summary>
			/// <remarks>Returns true if the text field is empty, or contains only whitespace.</remarks>
			internal bool isEmpty()
			{
				return android.text.TextUtils.getTrimmedLength(((android.text.Editable)getText())
					) == 0;
			}

			/// <summary>
			/// We override this method to avoid replacing the query box text when a
			/// suggestion is clicked.
			/// </summary>
			/// <remarks>
			/// We override this method to avoid replacing the query box text when a
			/// suggestion is clicked.
			/// </remarks>
			[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
			protected internal override void replaceText(java.lang.CharSequence text)
			{
			}

			/// <summary>
			/// We override this method to avoid an extra onItemClick being called on
			/// the drop-down's OnItemClickListener by
			/// <see cref="AutoCompleteTextView.onKeyUp(int, android.view.KeyEvent)">AutoCompleteTextView.onKeyUp(int, android.view.KeyEvent)
			/// 	</see>
			/// when an item is
			/// clicked with the trackball.
			/// </summary>
			[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
			public override void performCompletion()
			{
			}

			/// <summary>
			/// We override this method to be sure and show the soft keyboard if
			/// appropriate when the TextView has focus.
			/// </summary>
			/// <remarks>
			/// We override this method to be sure and show the soft keyboard if
			/// appropriate when the TextView has focus.
			/// </remarks>
			[Sharpen.OverridesMethod(@"android.view.View")]
			public override void onWindowFocusChanged(bool hasWindowFocus_1)
			{
				base.onWindowFocusChanged(hasWindowFocus_1);
				if (hasWindowFocus_1 && mSearchView.hasFocus() && getVisibility() == VISIBLE)
				{
					android.view.inputmethod.InputMethodManager inputManager = (android.view.inputmethod.InputMethodManager
						)getContext().getSystemService(android.content.Context.INPUT_METHOD_SERVICE);
					inputManager.showSoftInput(this, 0);
					// If in landscape mode, then make sure that
					// the ime is in front of the dropdown.
					if (isLandscapeMode(getContext()))
					{
						ensureImeVisible(true);
					}
				}
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onFocusChanged(bool focused, int direction, android.graphics.Rect
				 previouslyFocusedRect)
			{
				base.onFocusChanged(focused, direction, previouslyFocusedRect);
				mSearchView.onTextFocusChanged();
			}

			/// <summary>
			/// We override this method so that we can allow a threshold of zero,
			/// which ACTV does not.
			/// </summary>
			/// <remarks>
			/// We override this method so that we can allow a threshold of zero,
			/// which ACTV does not.
			/// </remarks>
			[Sharpen.OverridesMethod(@"android.widget.AutoCompleteTextView")]
			public override bool enoughToFilter()
			{
				return mThreshold <= 0 || base.enoughToFilter();
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool onKeyPreIme(int keyCode, android.view.KeyEvent @event)
			{
				if (keyCode == android.view.KeyEvent.KEYCODE_BACK)
				{
					// special case for the back key, we do not even try to send it
					// to the drop down list but instead, consume it immediately
					if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
						() == 0)
					{
						android.view.KeyEvent.DispatcherState state = getKeyDispatcherState();
						if (state != null)
						{
							state.startTracking(@event, this);
						}
						return true;
					}
					else
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_UP)
						{
							android.view.KeyEvent.DispatcherState state = getKeyDispatcherState();
							if (state != null)
							{
								state.handleUpEvent(@event);
							}
							if (@event.isTracking() && !@event.isCanceled())
							{
								mSearchView.clearFocus();
								mSearchView.setImeVisibility(false);
								return true;
							}
						}
					}
				}
				return base.onKeyPreIme(keyCode, @event);
			}
		}
	}
}
