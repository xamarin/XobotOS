using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>An editable text view that shows completion suggestions automatically
	/// while the user is typing.
	/// </summary>
	/// <remarks>
	/// <p>An editable text view that shows completion suggestions automatically
	/// while the user is typing. The list of suggestions is displayed in a drop
	/// down menu from which the user can choose an item to replace the content
	/// of the edit box with.</p>
	/// <p>The drop down can be dismissed at any time by pressing the back key or,
	/// if no item is selected in the drop down, by pressing the enter/dpad center
	/// key.</p>
	/// <p>The list of suggestions is obtained from a data adapter and appears
	/// only after a given number of characters defined by
	/// <see cref="getThreshold()">the threshold</see>
	/// .</p>
	/// <p>The following code snippet shows how to create a text view which suggests
	/// various countries names while the user is typing:</p>
	/// <pre class="prettyprint">
	/// public class CountriesActivity extends Activity {
	/// protected void onCreate(Bundle icicle) {
	/// super.onCreate(icicle);
	/// setContentView(R.layout.countries);
	/// ArrayAdapter&lt;String&gt; adapter = new ArrayAdapter&lt;String&gt;(this,
	/// android.R.layout.simple_dropdown_item_1line, COUNTRIES);
	/// AutoCompleteTextView textView = (AutoCompleteTextView)
	/// findViewById(R.id.countries_list);
	/// textView.setAdapter(adapter);
	/// }
	/// private static final String[] COUNTRIES = new String[] {
	/// "Belgium", "France", "Italy", "Germany", "Spain"
	/// };
	/// }
	/// </pre>
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-autocomplete.html"&gt;Auto Complete
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_completionHint</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_completionThreshold</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_completionHintView</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownSelector</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownAnchor</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownWidth</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownHeight</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownVerticalOffset</attr>
	/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownHorizontalOffset</attr>
	[Sharpen.Sharpened]
	public class AutoCompleteTextView : android.widget.EditText, android.widget.Filter
		.FilterListener
	{
		internal const bool DEBUG = false;

		internal const string TAG = "AutoCompleteTextView";

		internal const int EXPAND_MAX = 3;

		private java.lang.CharSequence mHintText;

		private android.widget.TextView mHintView;

		private int mHintResource;

		private android.widget.ListAdapter mAdapter;

		private android.widget.Filter mFilter;

		private int mThreshold;

		private android.widget.ListPopupWindow mPopup;

		private int mDropDownAnchorId;

		private android.widget.AdapterView.OnItemClickListener mItemClickListener;

		private android.widget.AdapterView.OnItemSelectedListener mItemSelectedListener;

		private bool mDropDownDismissedOnCompletion = true;

		private int mLastKeyCode = android.view.KeyEvent.KEYCODE_UNKNOWN;

		private bool mOpenBefore;

		private android.widget.AutoCompleteTextView.Validator mValidator = null;

		private bool mBlockCompletion;

		private bool mPopupCanBeUpdated = true;

		private android.widget.AutoCompleteTextView.PassThroughClickListener mPassThroughClickListener;

		private android.widget.AutoCompleteTextView.PopupDataSetObserver mObserver;

		public AutoCompleteTextView(android.content.Context context) : this(context, null
			)
		{
		}

		public AutoCompleteTextView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.autoCompleteTextViewStyle
			)
		{
		}

		public AutoCompleteTextView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			// Set to true when text is set directly and no filtering shall be performed
			// When set, an update in the underlying adapter will update the result list popup.
			// Set to false when the list is hidden to prevent asynchronous updates to popup the list again.
			mPopup = new android.widget.ListPopupWindow(context, attrs, android.@internal.R.attr
				.autoCompleteTextViewStyle);
			mPopup.setSoftInputMode(android.view.WindowManagerClass.LayoutParams.SOFT_INPUT_ADJUST_RESIZE
				);
			mPopup.setPromptPosition(android.widget.ListPopupWindow.POSITION_PROMPT_BELOW);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AutoCompleteTextView, defStyle, 0);
			mThreshold = a.getInt(android.@internal.R.styleable.AutoCompleteTextView_completionThreshold
				, 2);
			mPopup.setListSelector(a.getDrawable(android.@internal.R.styleable.AutoCompleteTextView_dropDownSelector
				));
			mPopup.setVerticalOffset((int)a.getDimension(android.@internal.R.styleable.AutoCompleteTextView_dropDownVerticalOffset
				, 0.0f));
			mPopup.setHorizontalOffset((int)a.getDimension(android.@internal.R.styleable.AutoCompleteTextView_dropDownHorizontalOffset
				, 0.0f));
			// Get the anchor's id now, but the view won't be ready, so wait to actually get the
			// view and store it in mDropDownAnchorView lazily in getDropDownAnchorView later.
			// Defaults to NO_ID, in which case the getDropDownAnchorView method will simply return
			// this TextView, as a default anchoring point.
			mDropDownAnchorId = a.getResourceId(android.@internal.R.styleable.AutoCompleteTextView_dropDownAnchor
				, android.view.View.NO_ID);
			// For dropdown width, the developer can specify a specific width, or MATCH_PARENT
			// (for full screen width) or WRAP_CONTENT (to match the width of the anchored view).
			mPopup.setWidth(a.getLayoutDimension(android.@internal.R.styleable.AutoCompleteTextView_dropDownWidth
				, android.view.ViewGroup.LayoutParams.WRAP_CONTENT));
			mPopup.setHeight(a.getLayoutDimension(android.@internal.R.styleable.AutoCompleteTextView_dropDownHeight
				, android.view.ViewGroup.LayoutParams.WRAP_CONTENT));
			mHintResource = a.getResourceId(android.@internal.R.styleable.AutoCompleteTextView_completionHintView
				, android.@internal.R.layout.simple_dropdown_hint);
			mPopup.setOnItemClickListener(new android.widget.AutoCompleteTextView.DropDownItemClickListener
				(this));
			setCompletionHint(a.getText(android.@internal.R.styleable.AutoCompleteTextView_completionHint
				));
			// Always turn on the auto complete input type flag, since it
			// makes no sense to use this widget without it.
			int inputType = getInputType();
			if ((inputType & android.text.InputTypeClass.TYPE_MASK_CLASS) == android.text.InputTypeClass.TYPE_CLASS_TEXT)
			{
				inputType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_COMPLETE;
				setRawInputType(inputType);
			}
			a.recycle();
			setFocusable(true);
			addTextChangedListener(new android.widget.AutoCompleteTextView.MyWatcher(this));
			mPassThroughClickListener = new android.widget.AutoCompleteTextView.PassThroughClickListener
				(this);
			base.setOnClickListener(mPassThroughClickListener);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setOnClickListener(android.view.View.OnClickListener listener
			)
		{
			mPassThroughClickListener.mWrapped = listener;
		}

		/// <summary>
		/// Private hook into the on click event, dispatched from
		/// <see cref="PassThroughClickListener">PassThroughClickListener</see>
		/// </summary>
		private void onClickImpl()
		{
			// If the dropdown is showing, bring the keyboard to the front
			// when the user touches the text field.
			if (isPopupShowing())
			{
				ensureImeVisible(true);
			}
		}

		/// <summary>
		/// <p>Sets the optional hint text that is displayed at the bottom of the
		/// the matching list.
		/// </summary>
		/// <remarks>
		/// <p>Sets the optional hint text that is displayed at the bottom of the
		/// the matching list.  This can be used as a cue to the user on how to
		/// best use the list, or to provide extra information.</p>
		/// </remarks>
		/// <param name="hint">the text to be displayed to the user</param>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_completionHint</attr>
		public virtual void setCompletionHint(java.lang.CharSequence hint)
		{
			mHintText = hint;
			if (hint != null)
			{
				if (mHintView == null)
				{
					android.widget.TextView hintView = (android.widget.TextView)android.view.LayoutInflater
						.from(getContext()).inflate(mHintResource, null).findViewById(android.@internal.R
						.id.text1);
					hintView.setText(mHintText);
					mHintView = hintView;
					mPopup.setPromptView(hintView);
				}
				else
				{
					mHintView.setText(hint);
				}
			}
			else
			{
				mPopup.setPromptView(null);
				mHintView = null;
			}
		}

		/// <summary><p>Returns the current width for the auto-complete drop down list.</summary>
		/// <remarks>
		/// <p>Returns the current width for the auto-complete drop down list. This can
		/// be a fixed width, or
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// to fill the screen, or
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// to fit the width of its anchor view.</p>
		/// </remarks>
		/// <returns>the width for the drop down list</returns>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownWidth</attr>
		public virtual int getDropDownWidth()
		{
			return mPopup.getWidth();
		}

		/// <summary><p>Sets the current width for the auto-complete drop down list.</summary>
		/// <remarks>
		/// <p>Sets the current width for the auto-complete drop down list. This can
		/// be a fixed width, or
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// to fill the screen, or
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// to fit the width of its anchor view.</p>
		/// </remarks>
		/// <param name="width">the width to use</param>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownWidth</attr>
		public virtual void setDropDownWidth(int width)
		{
			mPopup.setWidth(width);
		}

		/// <summary><p>Returns the current height for the auto-complete drop down list.</summary>
		/// <remarks>
		/// <p>Returns the current height for the auto-complete drop down list. This can
		/// be a fixed height, or
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// to fill
		/// the screen, or
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// to fit the height
		/// of the drop down's content.</p>
		/// </remarks>
		/// <returns>the height for the drop down list</returns>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownHeight</attr>
		public virtual int getDropDownHeight()
		{
			return mPopup.getHeight();
		}

		/// <summary><p>Sets the current height for the auto-complete drop down list.</summary>
		/// <remarks>
		/// <p>Sets the current height for the auto-complete drop down list. This can
		/// be a fixed height, or
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// to fill
		/// the screen, or
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// to fit the height
		/// of the drop down's content.</p>
		/// </remarks>
		/// <param name="height">the height to use</param>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownHeight</attr>
		public virtual void setDropDownHeight(int height)
		{
			mPopup.setHeight(height);
		}

		/// <summary><p>Returns the id for the view that the auto-complete drop down list is anchored to.</p>
		/// 	</summary>
		/// <returns>
		/// the view's id, or
		/// <see cref="android.view.View.NO_ID">android.view.View.NO_ID</see>
		/// if none specified
		/// </returns>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownAnchor</attr>
		public virtual int getDropDownAnchor()
		{
			return mDropDownAnchorId;
		}

		/// <summary><p>Sets the view to which the auto-complete drop down list should anchor.
		/// 	</summary>
		/// <remarks>
		/// <p>Sets the view to which the auto-complete drop down list should anchor. The view
		/// corresponding to this id will not be loaded until the next time it is needed to avoid
		/// loading a view which is not yet instantiated.</p>
		/// </remarks>
		/// <param name="id">the id to anchor the drop down list view to</param>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_dropDownAnchor</attr>
		public virtual void setDropDownAnchor(int id)
		{
			mDropDownAnchorId = id;
			mPopup.setAnchorView(null);
		}

		/// <summary><p>Gets the background of the auto-complete drop-down list.</p></summary>
		/// <returns>the background drawable</returns>
		/// <attr>ref android.R.styleable#PopupWindow_popupBackground</attr>
		public virtual android.graphics.drawable.Drawable getDropDownBackground()
		{
			return mPopup.getBackground();
		}

		/// <summary><p>Sets the background of the auto-complete drop-down list.</p></summary>
		/// <param name="d">the drawable to set as the background</param>
		/// <attr>ref android.R.styleable#PopupWindow_popupBackground</attr>
		public virtual void setDropDownBackgroundDrawable(android.graphics.drawable.Drawable
			 d)
		{
			mPopup.setBackgroundDrawable(d);
		}

		/// <summary><p>Sets the background of the auto-complete drop-down list.</p></summary>
		/// <param name="id">the id of the drawable to set as the background</param>
		/// <attr>ref android.R.styleable#PopupWindow_popupBackground</attr>
		public virtual void setDropDownBackgroundResource(int id)
		{
			mPopup.setBackgroundDrawable(getResources().getDrawable(id));
		}

		/// <summary><p>Sets the vertical offset used for the auto-complete drop-down list.</p>
		/// 	</summary>
		/// <param name="offset">the vertical offset</param>
		public virtual void setDropDownVerticalOffset(int offset)
		{
			mPopup.setVerticalOffset(offset);
		}

		/// <summary><p>Gets the vertical offset used for the auto-complete drop-down list.</p>
		/// 	</summary>
		/// <returns>the vertical offset</returns>
		public virtual int getDropDownVerticalOffset()
		{
			return mPopup.getVerticalOffset();
		}

		/// <summary><p>Sets the horizontal offset used for the auto-complete drop-down list.</p>
		/// 	</summary>
		/// <param name="offset">the horizontal offset</param>
		public virtual void setDropDownHorizontalOffset(int offset)
		{
			mPopup.setHorizontalOffset(offset);
		}

		/// <summary><p>Gets the horizontal offset used for the auto-complete drop-down list.</p>
		/// 	</summary>
		/// <returns>the horizontal offset</returns>
		public virtual int getDropDownHorizontalOffset()
		{
			return mPopup.getHorizontalOffset();
		}

		/// <summary>
		/// <p>Sets the animation style of the auto-complete drop-down list.</p>
		/// <p>If the drop-down is showing, calling this method will take effect only
		/// the next time the drop-down is shown.</p>
		/// </summary>
		/// <param name="animationStyle">
		/// animation style to use when the drop-down appears
		/// and disappears.  Set to -1 for the default animation, 0 for no
		/// animation, or a resource identifier for an explicit animation.
		/// </param>
		/// <hide>Pending API council approval</hide>
		public virtual void setDropDownAnimationStyle(int animationStyle)
		{
			mPopup.setAnimationStyle(animationStyle);
		}

		/// <summary>
		/// <p>Returns the animation style that is used when the drop-down list appears and disappears
		/// </p>
		/// </summary>
		/// <returns>the animation style that is used when the drop-down list appears and disappears
		/// 	</returns>
		/// <hide>Pending API council approval</hide>
		public virtual int getDropDownAnimationStyle()
		{
			return mPopup.getAnimationStyle();
		}

		/// <returns>
		/// Whether the drop-down is visible as long as there is
		/// <see cref="enoughToFilter()">enoughToFilter()</see>
		/// </returns>
		/// <hide>Pending API council approval</hide>
		public virtual bool isDropDownAlwaysVisible()
		{
			return mPopup.isDropDownAlwaysVisible();
		}

		/// <summary>
		/// Sets whether the drop-down should remain visible as long as there is there is
		/// <see cref="enoughToFilter()">enoughToFilter()</see>
		/// .  This is useful if an unknown number of results are expected
		/// to show up in the adapter sometime in the future.
		/// The drop-down will occupy the entire screen below
		/// <see cref="getDropDownAnchor()">getDropDownAnchor()</see>
		/// regardless
		/// of the size or content of the list.
		/// <see cref="getDropDownBackground()">getDropDownBackground()</see>
		/// will fill any space
		/// that is not used by the list.
		/// </summary>
		/// <param name="dropDownAlwaysVisible">Whether to keep the drop-down visible.</param>
		/// <hide>Pending API council approval</hide>
		public virtual void setDropDownAlwaysVisible(bool dropDownAlwaysVisible)
		{
			mPopup.setDropDownAlwaysVisible(dropDownAlwaysVisible);
		}

		/// <summary>Checks whether the drop-down is dismissed when a suggestion is clicked.</summary>
		/// <remarks>Checks whether the drop-down is dismissed when a suggestion is clicked.</remarks>
		/// <hide>Pending API council approval</hide>
		public virtual bool isDropDownDismissedOnCompletion()
		{
			return mDropDownDismissedOnCompletion;
		}

		/// <summary>Sets whether the drop-down is dismissed when a suggestion is clicked.</summary>
		/// <remarks>
		/// Sets whether the drop-down is dismissed when a suggestion is clicked. This is
		/// true by default.
		/// </remarks>
		/// <param name="dropDownDismissedOnCompletion">Whether to dismiss the drop-down.</param>
		/// <hide>Pending API council approval</hide>
		public virtual void setDropDownDismissedOnCompletion(bool dropDownDismissedOnCompletion
			)
		{
			mDropDownDismissedOnCompletion = dropDownDismissedOnCompletion;
		}

		/// <summary>
		/// <p>Returns the number of characters the user must type before the drop
		/// down list is shown.</p>
		/// </summary>
		/// <returns>the minimum number of characters to type to show the drop down</returns>
		/// <seealso cref="setThreshold(int)">setThreshold(int)</seealso>
		public virtual int getThreshold()
		{
			return mThreshold;
		}

		/// <summary>
		/// <p>Specifies the minimum number of characters the user has to type in the
		/// edit box before the drop down list is shown.</p>
		/// <p>When <code>threshold</code> is less than or equals 0, a threshold of
		/// 1 is applied.</p>
		/// </summary>
		/// <param name="threshold">
		/// the number of characters to type before the drop down
		/// is shown
		/// </param>
		/// <seealso cref="getThreshold()">getThreshold()</seealso>
		/// <attr>ref android.R.styleable#AutoCompleteTextView_completionThreshold</attr>
		public virtual void setThreshold(int threshold)
		{
			if (threshold <= 0)
			{
				threshold = 1;
			}
			mThreshold = threshold;
		}

		/// <summary>
		/// <p>Sets the listener that will be notified when the user clicks an item
		/// in the drop down list.</p>
		/// </summary>
		/// <param name="l">the item click listener</param>
		public virtual void setOnItemClickListener(android.widget.AdapterView.OnItemClickListener
			 l)
		{
			mItemClickListener = l;
		}

		/// <summary>
		/// <p>Sets the listener that will be notified when the user selects an item
		/// in the drop down list.</p>
		/// </summary>
		/// <param name="l">the item selected listener</param>
		public virtual void setOnItemSelectedListener(android.widget.AdapterView.OnItemSelectedListener
			 l)
		{
			mItemSelectedListener = l;
		}

		/// <summary>
		/// <p>Returns the listener that is notified whenever the user clicks an item
		/// in the drop down list.</p>
		/// </summary>
		/// <returns>the item click listener</returns>
		[System.ObsoleteAttribute(@"Use getOnItemClickListener() intead")]
		public virtual android.widget.AdapterView.OnItemClickListener getItemClickListener
			()
		{
			return mItemClickListener;
		}

		/// <summary>
		/// <p>Returns the listener that is notified whenever the user selects an
		/// item in the drop down list.</p>
		/// </summary>
		/// <returns>the item selected listener</returns>
		[System.ObsoleteAttribute(@"Use getOnItemSelectedListener() intead")]
		public virtual android.widget.AdapterView.OnItemSelectedListener getItemSelectedListener
			()
		{
			return mItemSelectedListener;
		}

		/// <summary>
		/// <p>Returns the listener that is notified whenever the user clicks an item
		/// in the drop down list.</p>
		/// </summary>
		/// <returns>the item click listener</returns>
		public virtual android.widget.AdapterView.OnItemClickListener getOnItemClickListener
			()
		{
			return mItemClickListener;
		}

		/// <summary>
		/// <p>Returns the listener that is notified whenever the user selects an
		/// item in the drop down list.</p>
		/// </summary>
		/// <returns>the item selected listener</returns>
		public virtual android.widget.AdapterView.OnItemSelectedListener getOnItemSelectedListener
			()
		{
			return mItemSelectedListener;
		}

		/// <summary><p>Returns a filterable list adapter used for auto completion.</p></summary>
		/// <returns>a data adapter used for auto completion</returns>
		public virtual android.widget.ListAdapter getAdapter()
		{
			return mAdapter;
		}

		/// <summary><p>Changes the list of data used for auto completion.</summary>
		/// <remarks>
		/// <p>Changes the list of data used for auto completion. The provided list
		/// must be a filterable list adapter.</p>
		/// <p>The caller is still responsible for managing any resources used by the adapter.
		/// Notably, when the AutoCompleteTextView is closed or released, the adapter is not notified.
		/// A common case is the use of
		/// <see cref="CursorAdapter">CursorAdapter</see>
		/// , which
		/// contains a
		/// <see cref="android.database.Cursor">android.database.Cursor</see>
		/// that must be closed.  This can be done
		/// automatically (see
		/// <see cref="android.app.Activity.startManagingCursor(android.database.Cursor)">
		/// 
		/// startManagingCursor()
		/// </see>
		/// ),
		/// or by manually closing the cursor when the AutoCompleteTextView is dismissed.</p>
		/// </remarks>
		/// <param name="adapter">the adapter holding the auto completion data</param>
		/// <seealso cref="getAdapter()">getAdapter()</seealso>
		/// <seealso cref="Filterable">Filterable</seealso>
		/// <seealso cref="ListAdapter">ListAdapter</seealso>
		public virtual void setAdapter<T>(T adapter) where T:android.widget.ListAdapter
		{
			if (mObserver == null)
			{
				mObserver = new android.widget.AutoCompleteTextView.PopupDataSetObserver(this);
			}
			else
			{
				if (mAdapter != null)
				{
					mAdapter.unregisterDataSetObserver(mObserver);
				}
			}
			mAdapter = adapter;
			if (mAdapter != null)
			{
				//noinspection unchecked
				mFilter = ((android.widget.Filterable)mAdapter).getFilter();
				adapter.registerDataSetObserver(mObserver);
			}
			else
			{
				mFilter = null;
			}
			mPopup.setAdapter(mAdapter);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyPreIme(int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_BACK && isPopupShowing() && !mPopup.
				isDropDownAlwaysVisible())
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
							dismissDropDown();
							return true;
						}
					}
				}
			}
			return base.onKeyPreIme(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			bool consumed = mPopup.onKeyUp(keyCode, @event);
			if (consumed)
			{
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_ENTER:
					case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
					case android.view.KeyEvent.KEYCODE_TAB:
					{
						// if the list accepts the key events and the key event
						// was a click, the text view gets the selected item
						// from the drop down as its content
						if (@event.hasNoModifiers())
						{
							performCompletion();
						}
						return true;
					}
				}
			}
			if (isPopupShowing() && keyCode == android.view.KeyEvent.KEYCODE_TAB && @event.hasNoModifiers
				())
			{
				performCompletion();
				return true;
			}
			return base.onKeyUp(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			if (mPopup.onKeyDown(keyCode, @event))
			{
				return true;
			}
			if (!isPopupShowing())
			{
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
					{
						if (@event.hasNoModifiers())
						{
							performValidation();
						}
						break;
					}
				}
			}
			if (isPopupShowing() && keyCode == android.view.KeyEvent.KEYCODE_TAB && @event.hasNoModifiers
				())
			{
				return true;
			}
			mLastKeyCode = keyCode;
			bool handled = base.onKeyDown(keyCode, @event);
			mLastKeyCode = android.view.KeyEvent.KEYCODE_UNKNOWN;
			if (handled && isPopupShowing())
			{
				clearListSelection();
			}
			return handled;
		}

		/// <summary>
		/// Returns <code>true</code> if the amount of text in the field meets
		/// or exceeds the
		/// <see cref="getThreshold()">getThreshold()</see>
		/// requirement.  You can override
		/// this to impose a different standard for when filtering will be
		/// triggered.
		/// </summary>
		public virtual bool enoughToFilter()
		{
			return ((android.text.Editable)getText()).Length >= mThreshold;
		}

		/// <summary>This is used to watch for edits to the text view.</summary>
		/// <remarks>
		/// This is used to watch for edits to the text view.  Note that we call
		/// to methods on the auto complete text view class so that we can access
		/// private vars without going through thunks.
		/// </remarks>
		private class MyWatcher : android.text.TextWatcher
		{
			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void afterTextChanged(android.text.Editable s)
			{
				this._enclosing.doAfterTextChanged();
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void beforeTextChanged(java.lang.CharSequence s, int start, int count
				, int after)
			{
				this._enclosing.doBeforeTextChanged();
			}

			[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
			public virtual void onTextChanged(java.lang.CharSequence s, int start, int before
				, int count)
			{
			}

			internal MyWatcher(AutoCompleteTextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AutoCompleteTextView _enclosing;
		}

		internal virtual void doBeforeTextChanged()
		{
			if (mBlockCompletion)
			{
				return;
			}
			// when text is changed, inserted or deleted, we attempt to show
			// the drop down
			mOpenBefore = isPopupShowing();
		}

		internal virtual void doAfterTextChanged()
		{
			if (mBlockCompletion)
			{
				return;
			}
			// if the list was open before the keystroke, but closed afterwards,
			// then something in the keystroke processing (an input filter perhaps)
			// called performCompletion() and we shouldn't do any more processing.
			if (mOpenBefore && !isPopupShowing())
			{
				return;
			}
			// the drop down is shown only when a minimum number of characters
			// was typed in the text view
			if (enoughToFilter())
			{
				if (mFilter != null)
				{
					mPopupCanBeUpdated = true;
					performFiltering(((android.text.Editable)getText()), mLastKeyCode);
				}
			}
			else
			{
				// drop down is automatically dismissed when enough characters
				// are deleted from the text view
				if (!mPopup.isDropDownAlwaysVisible())
				{
					dismissDropDown();
				}
				if (mFilter != null)
				{
					mFilter.filter(null);
				}
			}
		}

		/// <summary><p>Indicates whether the popup menu is showing.</p></summary>
		/// <returns>true if the popup menu is showing, false otherwise</returns>
		public virtual bool isPopupShowing()
		{
			return mPopup.isShowing();
		}

		/// <summary>
		/// <p>Converts the selected item from the drop down list into a sequence
		/// of character that can be used in the edit box.</p>
		/// </summary>
		/// <param name="selectedItem">the item selected by the user for completion</param>
		/// <returns>a sequence of characters representing the selected suggestion</returns>
		protected internal virtual java.lang.CharSequence convertSelectionToString(object
			 selectedItem)
		{
			return mFilter.convertResultToString(selectedItem);
		}

		/// <summary><p>Clear the list selection.</summary>
		/// <remarks>
		/// <p>Clear the list selection.  This may only be temporary, as user input will often bring
		/// it back.
		/// </remarks>
		public virtual void clearListSelection()
		{
			mPopup.clearListSelection();
		}

		/// <summary>Set the position of the dropdown view selection.</summary>
		/// <remarks>Set the position of the dropdown view selection.</remarks>
		/// <param name="position">The position to move the selector to.</param>
		public virtual void setListSelection(int position)
		{
			mPopup.setSelection(position);
		}

		/// <summary>Get the position of the dropdown view selection, if there is one.</summary>
		/// <remarks>
		/// Get the position of the dropdown view selection, if there is one.  Returns
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">ListView.INVALID_POSITION
		/// 	</see>
		/// if there is no dropdown or if
		/// there is no selection.
		/// </remarks>
		/// <returns>
		/// the position of the current selection, if there is one, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">ListView.INVALID_POSITION
		/// 	</see>
		/// if not.
		/// </returns>
		/// <seealso cref="AdapterView{T}.getSelectedItemPosition()">AdapterView&lt;T&gt;.getSelectedItemPosition()
		/// 	</seealso>
		public virtual int getListSelection()
		{
			return mPopup.getSelectedItemPosition();
		}

		/// <summary><p>Starts filtering the content of the drop down list.</summary>
		/// <remarks>
		/// <p>Starts filtering the content of the drop down list. The filtering
		/// pattern is the content of the edit box. Subclasses should override this
		/// method to filter with a different pattern, for instance a substring of
		/// <code>text</code>.</p>
		/// </remarks>
		/// <param name="text">the filtering pattern</param>
		/// <param name="keyCode">
		/// the last character inserted in the edit box; beware that
		/// this will be null when text is being added through a soft input method.
		/// </param>
		protected internal virtual void performFiltering(java.lang.CharSequence text, int
			 keyCode)
		{
			mFilter.filter(text, this);
		}

		/// <summary>
		/// <p>Performs the text completion by converting the selected item from
		/// the drop down list into a string, replacing the text box's content with
		/// this string and finally dismissing the drop down menu.</p>
		/// </summary>
		public virtual void performCompletion()
		{
			performCompletion(null, -1, -1);
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override void onCommitCompletion(android.view.inputmethod.CompletionInfo completion
			)
		{
			if (isPopupShowing())
			{
				mPopup.performItemClick(completion.getPosition());
			}
		}

		private void performCompletion(android.view.View selectedView, int position, long
			 id)
		{
			if (isPopupShowing())
			{
				object selectedItem;
				if (position < 0)
				{
					selectedItem = mPopup.getSelectedItem();
				}
				else
				{
					selectedItem = mAdapter.getItem(position);
				}
				if (selectedItem == null)
				{
					android.util.Log.w(TAG, "performCompletion: no selected item");
					return;
				}
				mBlockCompletion = true;
				replaceText(convertSelectionToString(selectedItem));
				mBlockCompletion = false;
				if (mItemClickListener != null)
				{
					android.widget.ListPopupWindow list = mPopup;
					if (selectedView == null || position < 0)
					{
						selectedView = list.getSelectedView();
						position = list.getSelectedItemPosition();
						id = list.getSelectedItemId();
					}
					mItemClickListener.onItemClick(list.getListView(), selectedView, position, id);
				}
			}
			if (mDropDownDismissedOnCompletion && !mPopup.isDropDownAlwaysVisible())
			{
				dismissDropDown();
			}
		}

		/// <summary>
		/// Identifies whether the view is currently performing a text completion, so subclasses
		/// can decide whether to respond to text changed events.
		/// </summary>
		/// <remarks>
		/// Identifies whether the view is currently performing a text completion, so subclasses
		/// can decide whether to respond to text changed events.
		/// </remarks>
		public virtual bool isPerformingCompletion()
		{
			return mBlockCompletion;
		}

		/// <summary>
		/// Like
		/// <see cref="TextView.setText(java.lang.CharSequence)">TextView.setText(java.lang.CharSequence)
		/// 	</see>
		/// , except that it can disable filtering.
		/// </summary>
		/// <param name="filter">
		/// If <code>false</code>, no filtering will be performed
		/// as a result of this call.
		/// </param>
		/// <hide>Pending API council approval.</hide>
		public virtual void setText(java.lang.CharSequence text, bool filter)
		{
			if (filter)
			{
				setText(text);
			}
			else
			{
				mBlockCompletion = true;
				setText(text);
				mBlockCompletion = false;
			}
		}

		/// <summary>
		/// <p>Performs the text completion by replacing the current text by the
		/// selected item.
		/// </summary>
		/// <remarks>
		/// <p>Performs the text completion by replacing the current text by the
		/// selected item. Subclasses should override this method to avoid replacing
		/// the whole content of the edit box.</p>
		/// </remarks>
		/// <param name="text">the selected suggestion in the drop down list</param>
		protected internal virtual void replaceText(java.lang.CharSequence text)
		{
			clearComposingText();
			setText(text);
			// make sure we keep the caret at the end of the text view
			android.text.Editable spannable = ((android.text.Editable)getText());
			android.text.Selection.setSelection(spannable, spannable.Length);
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.widget.Filter.FilterListener")]
		public virtual void onFilterComplete(int count)
		{
			updateDropDownForFilter(count);
		}

		private void updateDropDownForFilter(int count)
		{
			// Not attached to window, don't update drop-down
			if (getWindowVisibility() == android.view.View.GONE)
			{
				return;
			}
			bool dropDownAlwaysVisible = mPopup.isDropDownAlwaysVisible();
			bool enoughToFilter_1 = enoughToFilter();
			if ((count > 0 || dropDownAlwaysVisible) && enoughToFilter_1)
			{
				if (hasFocus() && hasWindowFocus() && mPopupCanBeUpdated)
				{
					showDropDown();
				}
			}
			else
			{
				if (!dropDownAlwaysVisible && isPopupShowing())
				{
					dismissDropDown();
					// When the filter text is changed, the first update from the adapter may show an empty
					// count (when the query is being performed on the network). Future updates when some
					// content has been retrieved should still be able to update the list.
					mPopupCanBeUpdated = true;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			base.onWindowFocusChanged(hasWindowFocus_1);
			if (!hasWindowFocus_1 && !mPopup.isDropDownAlwaysVisible())
			{
				dismissDropDown();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDisplayHint(int hint)
		{
			base.onDisplayHint(hint);
			switch (hint)
			{
				case INVISIBLE:
				{
					if (!mPopup.isDropDownAlwaysVisible())
					{
						dismissDropDown();
					}
					break;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool focused, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(focused, direction, previouslyFocusedRect);
			// Perform validation if the view is losing focus.
			if (!focused)
			{
				performValidation();
			}
			if (!focused && !mPopup.isDropDownAlwaysVisible())
			{
				dismissDropDown();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			dismissDropDown();
			base.onDetachedFromWindow();
		}

		/// <summary><p>Closes the drop down if present on screen.</p></summary>
		public virtual void dismissDropDown()
		{
			android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (imm != null)
			{
				imm.displayCompletions(this, null);
			}
			mPopup.dismiss();
			mPopupCanBeUpdated = false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool setFrame(int l, int t, int r, int b)
		{
			bool result = base.setFrame(l, t, r, b);
			if (isPopupShowing())
			{
				showDropDown();
			}
			return result;
		}

		/// <summary>Issues a runnable to show the dropdown as soon as possible.</summary>
		/// <remarks>Issues a runnable to show the dropdown as soon as possible.</remarks>
		/// <hide>internal used only by SearchDialog</hide>
		public virtual void showDropDownAfterLayout()
		{
			mPopup.postShow();
		}

		/// <summary>Ensures that the drop down is not obscuring the IME.</summary>
		/// <remarks>Ensures that the drop down is not obscuring the IME.</remarks>
		/// <param name="visible">
		/// whether the ime should be in front. If false, the ime is pushed to
		/// the background.
		/// </param>
		/// <hide>internal used only here and SearchDialog</hide>
		public virtual void ensureImeVisible(bool visible)
		{
			mPopup.setInputMethodMode(visible ? android.widget.ListPopupWindow.INPUT_METHOD_NEEDED
				 : android.widget.ListPopupWindow.INPUT_METHOD_NOT_NEEDED);
			showDropDown();
		}

		/// <hide>internal used only here and SearchDialog</hide>
		public virtual bool isInputMethodNotNeeded()
		{
			return mPopup.getInputMethodMode() == android.widget.ListPopupWindow.INPUT_METHOD_NOT_NEEDED;
		}

		/// <summary><p>Displays the drop down on screen.</p></summary>
		public virtual void showDropDown()
		{
			buildImeCompletions();
			if (mPopup.getAnchorView() == null)
			{
				if (mDropDownAnchorId != android.view.View.NO_ID)
				{
					mPopup.setAnchorView(getRootView().findViewById(mDropDownAnchorId));
				}
				else
				{
					mPopup.setAnchorView(this);
				}
			}
			if (!isPopupShowing())
			{
				// Make sure the list does not obscure the IME when shown for the first time.
				mPopup.setInputMethodMode(android.widget.ListPopupWindow.INPUT_METHOD_NEEDED);
				mPopup.setListItemExpandMax(EXPAND_MAX);
			}
			mPopup.show();
			mPopup.getListView().setOverScrollMode(android.view.View.OVER_SCROLL_ALWAYS);
		}

		/// <summary>Forces outside touches to be ignored.</summary>
		/// <remarks>
		/// Forces outside touches to be ignored. Normally if
		/// <see cref="isDropDownAlwaysVisible()">isDropDownAlwaysVisible()</see>
		/// is
		/// false, we allow outside touch to dismiss the dropdown. If this is set to true, then we
		/// ignore outside touch even when the drop down is not set to always visible.
		/// </remarks>
		/// <hide>used only by SearchDialog</hide>
		public virtual void setForceIgnoreOutsideTouch(bool forceIgnoreOutsideTouch)
		{
			mPopup.setForceIgnoreOutsideTouch(forceIgnoreOutsideTouch);
		}

		private void buildImeCompletions()
		{
			android.widget.ListAdapter adapter = mAdapter;
			if (adapter != null)
			{
				android.view.inputmethod.InputMethodManager imm = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (imm != null)
				{
					int count = System.Math.Min(adapter.getCount(), 20);
					android.view.inputmethod.CompletionInfo[] completions = new android.view.inputmethod.CompletionInfo
						[count];
					int realCount = 0;
					{
						for (int i = 0; i < count; i++)
						{
							if (adapter.isEnabled(i))
							{
								realCount++;
								object item = adapter.getItem(i);
								long id = adapter.getItemId(i);
								completions[i] = new android.view.inputmethod.CompletionInfo(id, i, convertSelectionToString
									(item));
							}
						}
					}
					if (realCount != count)
					{
						android.view.inputmethod.CompletionInfo[] tmp = new android.view.inputmethod.CompletionInfo
							[realCount];
						System.Array.Copy(completions, 0, tmp, 0, realCount);
						completions = tmp;
					}
					imm.displayCompletions(this, completions);
				}
			}
		}

		/// <summary>Sets the validator used to perform text validation.</summary>
		/// <remarks>Sets the validator used to perform text validation.</remarks>
		/// <param name="validator">The validator used to validate the text entered in this widget.
		/// 	</param>
		/// <seealso cref="getValidator()">getValidator()</seealso>
		/// <seealso cref="performValidation()">performValidation()</seealso>
		public virtual void setValidator(android.widget.AutoCompleteTextView.Validator validator
			)
		{
			mValidator = validator;
		}

		/// <summary>
		/// Returns the Validator set with
		/// <see cref="setValidator(Validator)">setValidator(Validator)</see>
		/// ,
		/// or <code>null</code> if it was not set.
		/// </summary>
		/// <seealso cref="setValidator(Validator)">setValidator(Validator)</seealso>
		/// <seealso cref="performValidation()">performValidation()</seealso>
		public virtual android.widget.AutoCompleteTextView.Validator getValidator()
		{
			return mValidator;
		}

		/// <summary>
		/// If a validator was set on this view and the current string is not valid,
		/// ask the validator to fix it.
		/// </summary>
		/// <remarks>
		/// If a validator was set on this view and the current string is not valid,
		/// ask the validator to fix it.
		/// </remarks>
		/// <seealso cref="getValidator()">getValidator()</seealso>
		/// <seealso cref="setValidator(Validator)">setValidator(Validator)</seealso>
		public virtual void performValidation()
		{
			if (mValidator == null)
			{
				return;
			}
			java.lang.CharSequence text = ((android.text.Editable)getText());
			if (!android.text.TextUtils.isEmpty(text) && !mValidator.isValid(text))
			{
				setText(mValidator.fixText(text));
			}
		}

		/// <summary>
		/// Returns the Filter obtained from
		/// <see cref="Filterable.getFilter()">Filterable.getFilter()</see>
		/// ,
		/// or <code>null</code> if
		/// <see cref="setAdapter{T}(T)">setAdapter&lt;T&gt;(T)</see>
		/// was not called with
		/// a Filterable.
		/// </summary>
		protected internal virtual android.widget.Filter getFilter()
		{
			return mFilter;
		}

		private class DropDownItemClickListener : android.widget.AdapterView.OnItemClickListener
		{
			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public virtual void onItemClick(object parent, android.view.View v, int position, 
				long id)
			{
				this._enclosing.performCompletion(v, position, id);
			}

			internal DropDownItemClickListener(AutoCompleteTextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AutoCompleteTextView _enclosing;
		}

		/// <summary>
		/// This interface is used to make sure that the text entered in this TextView complies to
		/// a certain format.
		/// </summary>
		/// <remarks>
		/// This interface is used to make sure that the text entered in this TextView complies to
		/// a certain format.  Since there is no foolproof way to prevent the user from leaving
		/// this View with an incorrect value in it, all we can do is try to fix it ourselves
		/// when this happens.
		/// </remarks>
		public interface Validator
		{
			/// <summary>Validates the specified text.</summary>
			/// <remarks>Validates the specified text.</remarks>
			/// <returns>true If the text currently in the text editor is valid.</returns>
			/// <seealso cref="fixText(java.lang.CharSequence)">fixText(java.lang.CharSequence)</seealso>
			bool isValid(java.lang.CharSequence text);

			/// <summary>Corrects the specified text to make it valid.</summary>
			/// <remarks>Corrects the specified text to make it valid.</remarks>
			/// <param name="invalidText">
			/// A string that doesn't pass validation: isValid(invalidText)
			/// returns false
			/// </param>
			/// <returns>A string based on invalidText such as invoking isValid() on it returns true.
			/// 	</returns>
			/// <seealso cref="isValid(java.lang.CharSequence)">isValid(java.lang.CharSequence)</seealso>
			java.lang.CharSequence fixText(java.lang.CharSequence invalidText);
		}

		/// <summary>
		/// Allows us a private hook into the on click event without preventing users from setting
		/// their own click listener.
		/// </summary>
		/// <remarks>
		/// Allows us a private hook into the on click event without preventing users from setting
		/// their own click listener.
		/// </remarks>
		private class PassThroughClickListener : android.view.View.OnClickListener
		{
			internal android.view.View.OnClickListener mWrapped;

			/// <summary>
			/// <inheritDoc></inheritDoc>
			/// 
			/// </summary>
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View v)
			{
				this._enclosing.onClickImpl();
				if (this.mWrapped != null)
				{
					this.mWrapped.onClick(v);
				}
			}

			internal PassThroughClickListener(AutoCompleteTextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AutoCompleteTextView _enclosing;
		}

		private class PopupDataSetObserver : android.database.DataSetObserver
		{
			internal sealed class _Runnable_1214 : java.lang.Runnable
			{
				public _Runnable_1214(PopupDataSetObserver _enclosing)
				{
					this._enclosing = _enclosing;
				}

				// If the popup is not showing already, showing it will cause
				// the list of data set observers attached to the adapter to
				// change. We can't do it from here, because we are in the middle
				// of iterating through the list of observers.
				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					android.widget.ListAdapter adapter = this._enclosing._enclosing.mAdapter;
					if (adapter != null)
					{
						// This will re-layout, thus resetting mDataChanged, so that the
						// listView click listener stays responsive
						this._enclosing._enclosing.updateDropDownForFilter(adapter.getCount());
					}
				}

				private readonly PopupDataSetObserver _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				if (this._enclosing.mAdapter != null)
				{
					this._enclosing.post(new _Runnable_1214(this));
				}
			}

			internal PopupDataSetObserver(AutoCompleteTextView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AutoCompleteTextView _enclosing;
		}
	}
}
