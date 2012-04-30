using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A ListPopupWindow anchors itself to a host view and displays a
	/// list of choices.
	/// </summary>
	/// <remarks>
	/// A ListPopupWindow anchors itself to a host view and displays a
	/// list of choices.
	/// <p>ListPopupWindow contains a number of tricky behaviors surrounding
	/// positioning, scrolling parents to fit the dropdown, interacting
	/// sanely with the IME if present, and others.
	/// </remarks>
	/// <seealso cref="AutoCompleteTextView">AutoCompleteTextView</seealso>
	/// <seealso cref="Spinner">Spinner</seealso>
	[Sharpen.Sharpened]
	public class ListPopupWindow
	{
		internal const string TAG = "ListPopupWindow";

		internal const bool DEBUG = false;

		/// <summary>
		/// This value controls the length of time that the user
		/// must leave a pointer down without scrolling to expand
		/// the autocomplete dropdown list to cover the IME.
		/// </summary>
		/// <remarks>
		/// This value controls the length of time that the user
		/// must leave a pointer down without scrolling to expand
		/// the autocomplete dropdown list to cover the IME.
		/// </remarks>
		internal const int EXPAND_LIST_TIMEOUT = 250;

		private android.content.Context mContext;

		private android.widget.PopupWindow mPopup;

		private android.widget.ListAdapter mAdapter;

		private android.widget.ListPopupWindow.DropDownListView mDropDownList;

		private int mDropDownHeight = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;

		private int mDropDownWidth = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;

		private int mDropDownHorizontalOffset;

		private int mDropDownVerticalOffset;

		private bool mDropDownVerticalOffsetSet;

		private bool mDropDownAlwaysVisible = false;

		private bool mForceIgnoreOutsideTouch = false;

		internal int mListItemExpandMaximum = int.MaxValue;

		private android.view.View mPromptView;

		private int mPromptPosition = POSITION_PROMPT_ABOVE;

		private android.database.DataSetObserver mObserver;

		private android.view.View mDropDownAnchorView;

		private android.graphics.drawable.Drawable mDropDownListHighlight;

		private android.widget.AdapterView.OnItemClickListener mItemClickListener;

		private android.widget.AdapterView.OnItemSelectedListener mItemSelectedListener;

		private readonly android.widget.ListPopupWindow.ResizePopupRunnable mResizePopupRunnable;

		private readonly android.widget.ListPopupWindow.PopupTouchInterceptor mTouchInterceptor;

		private readonly android.widget.ListPopupWindow.PopupScrollListener mScrollListener;

		private readonly android.widget.ListPopupWindow.ListSelectorHider mHideSelector;

		private java.lang.Runnable mShowDropDownRunnable;

		private android.os.Handler mHandler = new android.os.Handler();

		private android.graphics.Rect mTempRect = new android.graphics.Rect();

		private bool mModal;

		/// <summary>The provided prompt view should appear above list content.</summary>
		/// <remarks>The provided prompt view should appear above list content.</remarks>
		/// <seealso cref="setPromptPosition(int)">setPromptPosition(int)</seealso>
		/// <seealso cref="getPromptPosition()">getPromptPosition()</seealso>
		/// <seealso cref="setPromptView(android.view.View)">setPromptView(android.view.View)
		/// 	</seealso>
		public const int POSITION_PROMPT_ABOVE = 0;

		/// <summary>The provided prompt view should appear below list content.</summary>
		/// <remarks>The provided prompt view should appear below list content.</remarks>
		/// <seealso cref="setPromptPosition(int)">setPromptPosition(int)</seealso>
		/// <seealso cref="getPromptPosition()">getPromptPosition()</seealso>
		/// <seealso cref="setPromptView(android.view.View)">setPromptView(android.view.View)
		/// 	</seealso>
		public const int POSITION_PROMPT_BELOW = 1;

		/// <summary>
		/// Alias for
		/// <see cref="android.view.ViewGroup.LayoutParams.MATCH_PARENT">android.view.ViewGroup.LayoutParams.MATCH_PARENT
		/// 	</see>
		/// .
		/// If used to specify a popup width, the popup will match the width of the anchor view.
		/// If used to specify a popup height, the popup will fill available space.
		/// </summary>
		public const int MATCH_PARENT = android.view.ViewGroup.LayoutParams.MATCH_PARENT;

		/// <summary>
		/// Alias for
		/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
		/// 	</see>
		/// .
		/// If used to specify a popup width, the popup will use the width of its content.
		/// </summary>
		public const int WRAP_CONTENT = android.view.ViewGroup.LayoutParams.WRAP_CONTENT;

		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : the requirements for the
		/// input method should be based on the focusability of the popup.  That is
		/// if it is focusable than it needs to work with the input method, else
		/// it doesn't.
		/// </summary>
		public const int INPUT_METHOD_FROM_FOCUSABLE = android.widget.PopupWindow.INPUT_METHOD_FROM_FOCUSABLE;

		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : this popup always needs to
		/// work with an input method, regardless of whether it is focusable.  This
		/// means that it will always be displayed so that the user can also operate
		/// the input method while it is shown.
		/// </summary>
		public const int INPUT_METHOD_NEEDED = android.widget.PopupWindow.INPUT_METHOD_NEEDED;

		/// <summary>
		/// Mode for
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// : this popup never needs to
		/// work with an input method, regardless of whether it is focusable.  This
		/// means that it will always be displayed to use as much space on the
		/// screen as needed, regardless of whether this covers the input method.
		/// </summary>
		public const int INPUT_METHOD_NOT_NEEDED = android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED;

		/// <summary>Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// 	</summary>
		/// <remarks>
		/// Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// Backgrounds should be set using
		/// <see cref="setBackgroundDrawable(android.graphics.drawable.Drawable)">setBackgroundDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">Context used for contained views.</param>
		public ListPopupWindow(android.content.Context context) : this(context, null, android.@internal.R
			.attr.listPopupWindowStyle, 0)
		{
			mResizePopupRunnable = new android.widget.ListPopupWindow.ResizePopupRunnable(this
				);
			mTouchInterceptor = new android.widget.ListPopupWindow.PopupTouchInterceptor(this
				);
			mScrollListener = new android.widget.ListPopupWindow.PopupScrollListener(this);
			mHideSelector = new android.widget.ListPopupWindow.ListSelectorHider(this);
		}

		/// <summary>Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// 	</summary>
		/// <remarks>
		/// Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// Backgrounds should be set using
		/// <see cref="setBackgroundDrawable(android.graphics.drawable.Drawable)">setBackgroundDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">Context used for contained views.</param>
		/// <param name="attrs">Attributes from inflating parent views used to style the popup.
		/// 	</param>
		public ListPopupWindow(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.@internal.R.attr.listPopupWindowStyle, 0)
		{
			mResizePopupRunnable = new android.widget.ListPopupWindow.ResizePopupRunnable(this
				);
			mTouchInterceptor = new android.widget.ListPopupWindow.PopupTouchInterceptor(this
				);
			mScrollListener = new android.widget.ListPopupWindow.PopupScrollListener(this);
			mHideSelector = new android.widget.ListPopupWindow.ListSelectorHider(this);
		}

		/// <summary>Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// 	</summary>
		/// <remarks>
		/// Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// Backgrounds should be set using
		/// <see cref="setBackgroundDrawable(android.graphics.drawable.Drawable)">setBackgroundDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">Context used for contained views.</param>
		/// <param name="attrs">Attributes from inflating parent views used to style the popup.
		/// 	</param>
		/// <param name="defStyleAttr">Default style attribute to use for popup content.</param>
		public ListPopupWindow(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyleAttr) : this(context, attrs, defStyleAttr, 0)
		{
			mResizePopupRunnable = new android.widget.ListPopupWindow.ResizePopupRunnable(this
				);
			mTouchInterceptor = new android.widget.ListPopupWindow.PopupTouchInterceptor(this
				);
			mScrollListener = new android.widget.ListPopupWindow.PopupScrollListener(this);
			mHideSelector = new android.widget.ListPopupWindow.ListSelectorHider(this);
		}

		/// <summary>Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// 	</summary>
		/// <remarks>
		/// Create a new, empty popup window capable of displaying items from a ListAdapter.
		/// Backgrounds should be set using
		/// <see cref="setBackgroundDrawable(android.graphics.drawable.Drawable)">setBackgroundDrawable(android.graphics.drawable.Drawable)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">Context used for contained views.</param>
		/// <param name="attrs">Attributes from inflating parent views used to style the popup.
		/// 	</param>
		/// <param name="defStyleAttr">Style attribute to read for default styling of popup content.
		/// 	</param>
		/// <param name="defStyleRes">Style resource ID to use for default styling of popup content.
		/// 	</param>
		public ListPopupWindow(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyleAttr, int defStyleRes)
		{
			mResizePopupRunnable = new android.widget.ListPopupWindow.ResizePopupRunnable(this
				);
			mTouchInterceptor = new android.widget.ListPopupWindow.PopupTouchInterceptor(this
				);
			mScrollListener = new android.widget.ListPopupWindow.PopupScrollListener(this);
			mHideSelector = new android.widget.ListPopupWindow.ListSelectorHider(this);
			mContext = context;
			mPopup = new android.widget.PopupWindow(context, attrs, defStyleAttr, defStyleRes
				);
			mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NEEDED);
		}

		/// <summary>
		/// Sets the adapter that provides the data and the views to represent the data
		/// in this popup window.
		/// </summary>
		/// <remarks>
		/// Sets the adapter that provides the data and the views to represent the data
		/// in this popup window.
		/// </remarks>
		/// <param name="adapter">The adapter to use to create this window's content.</param>
		public virtual void setAdapter(android.widget.ListAdapter adapter)
		{
			if (mObserver == null)
			{
				mObserver = new android.widget.ListPopupWindow.PopupDataSetObserver(this);
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
				adapter.registerDataSetObserver(mObserver);
			}
			if (mDropDownList != null)
			{
				mDropDownList.setAdapter(mAdapter);
			}
		}

		/// <summary>Set where the optional prompt view should appear.</summary>
		/// <remarks>
		/// Set where the optional prompt view should appear. The default is
		/// <see cref="POSITION_PROMPT_ABOVE">POSITION_PROMPT_ABOVE</see>
		/// .
		/// </remarks>
		/// <param name="position">A position constant declaring where the prompt should be displayed.
		/// 	</param>
		/// <seealso cref="POSITION_PROMPT_ABOVE">POSITION_PROMPT_ABOVE</seealso>
		/// <seealso cref="POSITION_PROMPT_BELOW">POSITION_PROMPT_BELOW</seealso>
		public virtual void setPromptPosition(int position)
		{
			mPromptPosition = position;
		}

		/// <returns>Where the optional prompt view should appear.</returns>
		/// <seealso cref="POSITION_PROMPT_ABOVE">POSITION_PROMPT_ABOVE</seealso>
		/// <seealso cref="POSITION_PROMPT_BELOW">POSITION_PROMPT_BELOW</seealso>
		public virtual int getPromptPosition()
		{
			return mPromptPosition;
		}

		/// <summary>Set whether this window should be modal when shown.</summary>
		/// <remarks>
		/// Set whether this window should be modal when shown.
		/// <p>If a popup window is modal, it will receive all touch and key input.
		/// If the user touches outside the popup window's content area the popup window
		/// will be dismissed.
		/// </remarks>
		/// <param name="modal">
		/// 
		/// <code>true</code>
		/// if the popup window should be modal,
		/// <code>false</code>
		/// otherwise.
		/// </param>
		public virtual void setModal(bool modal)
		{
			mModal = true;
			mPopup.setFocusable(modal);
		}

		/// <summary>Returns whether the popup window will be modal when shown.</summary>
		/// <remarks>Returns whether the popup window will be modal when shown.</remarks>
		/// <returns>
		/// 
		/// <code>true</code>
		/// if the popup window will be modal,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isModal()
		{
			return mModal;
		}

		/// <summary>Forces outside touches to be ignored.</summary>
		/// <remarks>
		/// Forces outside touches to be ignored. Normally if
		/// <see cref="isDropDownAlwaysVisible()">isDropDownAlwaysVisible()</see>
		/// is
		/// false, we allow outside touch to dismiss the dropdown. If this is set to true, then we
		/// ignore outside touch even when the drop down is not set to always visible.
		/// </remarks>
		/// <hide>Used only by AutoCompleteTextView to handle some internal special cases.</hide>
		public virtual void setForceIgnoreOutsideTouch(bool forceIgnoreOutsideTouch)
		{
			mForceIgnoreOutsideTouch = forceIgnoreOutsideTouch;
		}

		/// <summary>Sets whether the drop-down should remain visible under certain conditions.
		/// 	</summary>
		/// <remarks>
		/// Sets whether the drop-down should remain visible under certain conditions.
		/// The drop-down will occupy the entire screen below
		/// <see cref="getAnchorView()">getAnchorView()</see>
		/// regardless
		/// of the size or content of the list.
		/// <see cref="getBackground()">getBackground()</see>
		/// will fill any space
		/// that is not used by the list.
		/// </remarks>
		/// <param name="dropDownAlwaysVisible">Whether to keep the drop-down visible.</param>
		/// <hide>Only used by AutoCompleteTextView under special conditions.</hide>
		public virtual void setDropDownAlwaysVisible(bool dropDownAlwaysVisible)
		{
			mDropDownAlwaysVisible = dropDownAlwaysVisible;
		}

		/// <returns>Whether the drop-down is visible under special conditions.</returns>
		/// <hide>Only used by AutoCompleteTextView under special conditions.</hide>
		public virtual bool isDropDownAlwaysVisible()
		{
			return mDropDownAlwaysVisible;
		}

		/// <summary>Sets the operating mode for the soft input area.</summary>
		/// <remarks>Sets the operating mode for the soft input area.</remarks>
		/// <param name="mode">
		/// The desired mode, see
		/// <see cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</see>
		/// for the full list
		/// </param>
		/// <seealso cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</seealso>
		/// <seealso cref="getSoftInputMode()">getSoftInputMode()</seealso>
		public virtual void setSoftInputMode(int mode)
		{
			mPopup.setSoftInputMode(mode);
		}

		/// <summary>
		/// Returns the current value in
		/// <see cref="setSoftInputMode(int)">setSoftInputMode(int)</see>
		/// .
		/// </summary>
		/// <seealso cref="setSoftInputMode(int)">setSoftInputMode(int)</seealso>
		/// <seealso cref="android.view.WindowManagerClass.LayoutParams.softInputMode">android.view.WindowManagerClass.LayoutParams.softInputMode
		/// 	</seealso>
		public virtual int getSoftInputMode()
		{
			return mPopup.getSoftInputMode();
		}

		/// <summary>Sets a drawable to use as the list item selector.</summary>
		/// <remarks>Sets a drawable to use as the list item selector.</remarks>
		/// <param name="selector">List selector drawable to use in the popup.</param>
		public virtual void setListSelector(android.graphics.drawable.Drawable selector)
		{
			mDropDownListHighlight = selector;
		}

		/// <returns>The background drawable for the popup window.</returns>
		public virtual android.graphics.drawable.Drawable getBackground()
		{
			return mPopup.getBackground();
		}

		/// <summary>Sets a drawable to be the background for the popup window.</summary>
		/// <remarks>Sets a drawable to be the background for the popup window.</remarks>
		/// <param name="d">A drawable to set as the background.</param>
		public virtual void setBackgroundDrawable(android.graphics.drawable.Drawable d)
		{
			mPopup.setBackgroundDrawable(d);
		}

		/// <summary>Set an animation style to use when the popup window is shown or dismissed.
		/// 	</summary>
		/// <remarks>Set an animation style to use when the popup window is shown or dismissed.
		/// 	</remarks>
		/// <param name="animationStyle">Animation style to use.</param>
		public virtual void setAnimationStyle(int animationStyle)
		{
			mPopup.setAnimationStyle(animationStyle);
		}

		/// <summary>
		/// Returns the animation style that will be used when the popup window is
		/// shown or dismissed.
		/// </summary>
		/// <remarks>
		/// Returns the animation style that will be used when the popup window is
		/// shown or dismissed.
		/// </remarks>
		/// <returns>Animation style that will be used.</returns>
		public virtual int getAnimationStyle()
		{
			return mPopup.getAnimationStyle();
		}

		/// <summary>Returns the view that will be used to anchor this popup.</summary>
		/// <remarks>Returns the view that will be used to anchor this popup.</remarks>
		/// <returns>The popup's anchor view</returns>
		public virtual android.view.View getAnchorView()
		{
			return mDropDownAnchorView;
		}

		/// <summary>Sets the popup's anchor view.</summary>
		/// <remarks>
		/// Sets the popup's anchor view. This popup will always be positioned relative to
		/// the anchor view when shown.
		/// </remarks>
		/// <param name="anchor">The view to use as an anchor.</param>
		public virtual void setAnchorView(android.view.View anchor)
		{
			mDropDownAnchorView = anchor;
		}

		/// <returns>The horizontal offset of the popup from its anchor in pixels.</returns>
		public virtual int getHorizontalOffset()
		{
			return mDropDownHorizontalOffset;
		}

		/// <summary>Set the horizontal offset of this popup from its anchor view in pixels.</summary>
		/// <remarks>Set the horizontal offset of this popup from its anchor view in pixels.</remarks>
		/// <param name="offset">The horizontal offset of the popup from its anchor.</param>
		public virtual void setHorizontalOffset(int offset)
		{
			mDropDownHorizontalOffset = offset;
		}

		/// <returns>The vertical offset of the popup from its anchor in pixels.</returns>
		public virtual int getVerticalOffset()
		{
			if (!mDropDownVerticalOffsetSet)
			{
				return 0;
			}
			return mDropDownVerticalOffset;
		}

		/// <summary>Set the vertical offset of this popup from its anchor view in pixels.</summary>
		/// <remarks>Set the vertical offset of this popup from its anchor view in pixels.</remarks>
		/// <param name="offset">The vertical offset of the popup from its anchor.</param>
		public virtual void setVerticalOffset(int offset)
		{
			mDropDownVerticalOffset = offset;
			mDropDownVerticalOffsetSet = true;
		}

		/// <returns>The width of the popup window in pixels.</returns>
		public virtual int getWidth()
		{
			return mDropDownWidth;
		}

		/// <summary>Sets the width of the popup window in pixels.</summary>
		/// <remarks>
		/// Sets the width of the popup window in pixels. Can also be
		/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
		/// or
		/// <see cref="WRAP_CONTENT">WRAP_CONTENT</see>
		/// .
		/// </remarks>
		/// <param name="width">Width of the popup window.</param>
		public virtual void setWidth(int width)
		{
			mDropDownWidth = width;
		}

		/// <summary>Sets the width of the popup window by the size of its content.</summary>
		/// <remarks>
		/// Sets the width of the popup window by the size of its content. The final width may be
		/// larger to accommodate styled window dressing.
		/// </remarks>
		/// <param name="width">Desired width of content in pixels.</param>
		public virtual void setContentWidth(int width)
		{
			android.graphics.drawable.Drawable popupBackground = mPopup.getBackground();
			if (popupBackground != null)
			{
				popupBackground.getPadding(mTempRect);
				mDropDownWidth = mTempRect.left + mTempRect.right + width;
			}
			else
			{
				setWidth(width);
			}
		}

		/// <returns>The height of the popup window in pixels.</returns>
		public virtual int getHeight()
		{
			return mDropDownHeight;
		}

		/// <summary>Sets the height of the popup window in pixels.</summary>
		/// <remarks>
		/// Sets the height of the popup window in pixels. Can also be
		/// <see cref="MATCH_PARENT">MATCH_PARENT</see>
		/// .
		/// </remarks>
		/// <param name="height">Height of the popup window.</param>
		public virtual void setHeight(int height)
		{
			mDropDownHeight = height;
		}

		/// <summary>Sets a listener to receive events when a list item is clicked.</summary>
		/// <remarks>Sets a listener to receive events when a list item is clicked.</remarks>
		/// <param name="clickListener">Listener to register</param>
		/// <seealso cref="AdapterView{T}.setOnItemClickListener(OnItemClickListener)">AdapterView&lt;T&gt;.setOnItemClickListener(OnItemClickListener)
		/// 	</seealso>
		public virtual void setOnItemClickListener(android.widget.AdapterView.OnItemClickListener
			 clickListener)
		{
			mItemClickListener = clickListener;
		}

		/// <summary>Sets a listener to receive events when a list item is selected.</summary>
		/// <remarks>Sets a listener to receive events when a list item is selected.</remarks>
		/// <param name="selectedListener">Listener to register.</param>
		/// <seealso cref="AdapterView{T}.setOnItemSelectedListener(OnItemSelectedListener)">AdapterView&lt;T&gt;.setOnItemSelectedListener(OnItemSelectedListener)
		/// 	</seealso>
		public virtual void setOnItemSelectedListener(android.widget.AdapterView.OnItemSelectedListener
			 selectedListener)
		{
			mItemSelectedListener = selectedListener;
		}

		/// <summary>Set a view to act as a user prompt for this popup window.</summary>
		/// <remarks>
		/// Set a view to act as a user prompt for this popup window. Where the prompt view will appear
		/// is controlled by
		/// <see cref="setPromptPosition(int)">setPromptPosition(int)</see>
		/// .
		/// </remarks>
		/// <param name="prompt">View to use as an informational prompt.</param>
		public virtual void setPromptView(android.view.View prompt)
		{
			bool showing = isShowing();
			if (showing)
			{
				removePromptView();
			}
			mPromptView = prompt;
			if (showing)
			{
				show();
			}
		}

		/// <summary>
		/// Post a
		/// <see cref="show()">show()</see>
		/// call to the UI thread.
		/// </summary>
		public virtual void postShow()
		{
			mHandler.post(mShowDropDownRunnable);
		}

		/// <summary>Show the popup list.</summary>
		/// <remarks>
		/// Show the popup list. If the list is already showing, this method
		/// will recalculate the popup's size and position.
		/// </remarks>
		public virtual void show()
		{
			int height = buildDropDown();
			int widthSpec = 0;
			int heightSpec = 0;
			bool noInputMethod = isInputMethodNotNeeded();
			mPopup.setAllowScrollingAnchorParent(!noInputMethod);
			if (mPopup.isShowing())
			{
				if (mDropDownWidth == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
				{
					// The call to PopupWindow's update method below can accept -1 for any
					// value you do not want to update.
					widthSpec = -1;
				}
				else
				{
					if (mDropDownWidth == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
					{
						widthSpec = getAnchorView().getWidth();
					}
					else
					{
						widthSpec = mDropDownWidth;
					}
				}
				if (mDropDownHeight == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
				{
					// The call to PopupWindow's update method below can accept -1 for any
					// value you do not want to update.
					heightSpec = noInputMethod ? height : android.view.ViewGroup.LayoutParams.MATCH_PARENT;
					if (noInputMethod)
					{
						mPopup.setWindowLayoutMode(mDropDownWidth == android.view.ViewGroup.LayoutParams.
							MATCH_PARENT ? android.view.ViewGroup.LayoutParams.MATCH_PARENT : 0, 0);
					}
					else
					{
						mPopup.setWindowLayoutMode(mDropDownWidth == android.view.ViewGroup.LayoutParams.
							MATCH_PARENT ? android.view.ViewGroup.LayoutParams.MATCH_PARENT : 0, android.view.ViewGroup
							.LayoutParams.MATCH_PARENT);
					}
				}
				else
				{
					if (mDropDownHeight == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
					{
						heightSpec = height;
					}
					else
					{
						heightSpec = mDropDownHeight;
					}
				}
				mPopup.setOutsideTouchable(!mForceIgnoreOutsideTouch && !mDropDownAlwaysVisible);
				mPopup.update(getAnchorView(), mDropDownHorizontalOffset, mDropDownVerticalOffset
					, widthSpec, heightSpec);
			}
			else
			{
				if (mDropDownWidth == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
				{
					widthSpec = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				}
				else
				{
					if (mDropDownWidth == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
					{
						mPopup.setWidth(getAnchorView().getWidth());
					}
					else
					{
						mPopup.setWidth(mDropDownWidth);
					}
				}
				if (mDropDownHeight == android.view.ViewGroup.LayoutParams.MATCH_PARENT)
				{
					heightSpec = android.view.ViewGroup.LayoutParams.MATCH_PARENT;
				}
				else
				{
					if (mDropDownHeight == android.view.ViewGroup.LayoutParams.WRAP_CONTENT)
					{
						mPopup.setHeight(height);
					}
					else
					{
						mPopup.setHeight(mDropDownHeight);
					}
				}
				mPopup.setWindowLayoutMode(widthSpec, heightSpec);
				mPopup.setClipToScreenEnabled(true);
				// use outside touchable to dismiss drop down when touching outside of it, so
				// only set this if the dropdown is not always visible
				mPopup.setOutsideTouchable(!mForceIgnoreOutsideTouch && !mDropDownAlwaysVisible);
				mPopup.setTouchInterceptor(mTouchInterceptor);
				mPopup.showAsDropDown(getAnchorView(), mDropDownHorizontalOffset, mDropDownVerticalOffset
					);
				mDropDownList.setSelection(android.widget.AdapterView.INVALID_POSITION);
				if (!mModal || mDropDownList.isInTouchMode())
				{
					clearListSelection();
				}
				if (!mModal)
				{
					mHandler.post(mHideSelector);
				}
			}
		}

		/// <summary>Dismiss the popup window.</summary>
		/// <remarks>Dismiss the popup window.</remarks>
		public virtual void dismiss()
		{
			mPopup.dismiss();
			removePromptView();
			mPopup.setContentView(null);
			mDropDownList = null;
			mHandler.removeCallbacks(mResizePopupRunnable);
		}

		/// <summary>Set a listener to receive a callback when the popup is dismissed.</summary>
		/// <remarks>Set a listener to receive a callback when the popup is dismissed.</remarks>
		/// <param name="listener">Listener that will be notified when the popup is dismissed.
		/// 	</param>
		public virtual void setOnDismissListener(android.widget.PopupWindow.OnDismissListener
			 listener)
		{
			mPopup.setOnDismissListener(listener);
		}

		private void removePromptView()
		{
			if (mPromptView != null)
			{
				android.view.ViewParent parent = mPromptView.getParent();
				if (parent is android.view.ViewGroup)
				{
					android.view.ViewGroup group = (android.view.ViewGroup)parent;
					group.removeView(mPromptView);
				}
			}
		}

		/// <summary>
		/// Control how the popup operates with an input method: one of
		/// <see cref="INPUT_METHOD_FROM_FOCUSABLE">INPUT_METHOD_FROM_FOCUSABLE</see>
		/// ,
		/// <see cref="INPUT_METHOD_NEEDED">INPUT_METHOD_NEEDED</see>
		/// ,
		/// or
		/// <see cref="INPUT_METHOD_NOT_NEEDED">INPUT_METHOD_NOT_NEEDED</see>
		/// .
		/// <p>If the popup is showing, calling this method will take effect only
		/// the next time the popup is shown or through a manual call to the
		/// <see cref="show()">show()</see>
		/// method.</p>
		/// </summary>
		/// <seealso cref="getInputMethodMode()">getInputMethodMode()</seealso>
		/// <seealso cref="show()">show()</seealso>
		public virtual void setInputMethodMode(int mode)
		{
			mPopup.setInputMethodMode(mode);
		}

		/// <summary>
		/// Return the current value in
		/// <see cref="setInputMethodMode(int)">setInputMethodMode(int)</see>
		/// .
		/// </summary>
		/// <seealso cref="setInputMethodMode(int)">setInputMethodMode(int)</seealso>
		public virtual int getInputMethodMode()
		{
			return mPopup.getInputMethodMode();
		}

		/// <summary>Set the selected position of the list.</summary>
		/// <remarks>
		/// Set the selected position of the list.
		/// Only valid when
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>true</code>
		/// .
		/// </remarks>
		/// <param name="position">List position to set as selected.</param>
		public virtual void setSelection(int position)
		{
			android.widget.ListPopupWindow.DropDownListView list = mDropDownList;
			if (isShowing() && list != null)
			{
				list.mListSelectionHidden = false;
				list.setSelection(position);
				if (list.getChoiceMode() != android.widget.AbsListView.CHOICE_MODE_NONE)
				{
					list.setItemChecked(position, true);
				}
			}
		}

		/// <summary>Clear any current list selection.</summary>
		/// <remarks>
		/// Clear any current list selection.
		/// Only valid when
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>true</code>
		/// .
		/// </remarks>
		public virtual void clearListSelection()
		{
			android.widget.ListPopupWindow.DropDownListView list = mDropDownList;
			if (list != null)
			{
				// WARNING: Please read the comment where mListSelectionHidden is declared
				list.mListSelectionHidden = true;
				list.hideSelector();
				list.requestLayout();
			}
		}

		/// <returns>
		/// 
		/// <code>true</code>
		/// if the popup is currently showing,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isShowing()
		{
			return mPopup.isShowing();
		}

		/// <returns>
		/// 
		/// <code>true</code>
		/// if this popup is configured to assume the user does not need
		/// to interact with the IME while it is showing,
		/// <code>false</code>
		/// otherwise.
		/// </returns>
		public virtual bool isInputMethodNotNeeded()
		{
			return mPopup.getInputMethodMode() == INPUT_METHOD_NOT_NEEDED;
		}

		/// <summary>Perform an item click operation on the specified list adapter position.</summary>
		/// <remarks>Perform an item click operation on the specified list adapter position.</remarks>
		/// <param name="position">Adapter position for performing the click</param>
		/// <returns>
		/// true if the click action could be performed, false if not.
		/// (e.g. if the popup was not showing, this method would return false.)
		/// </returns>
		public virtual bool performItemClick(int position)
		{
			if (isShowing())
			{
				if (mItemClickListener != null)
				{
					android.widget.ListPopupWindow.DropDownListView list = mDropDownList;
					android.view.View child = list.getChildAt(position - list.getFirstVisiblePosition
						());
					android.widget.ListAdapter adapter = list.getAdapter();
					mItemClickListener.onItemClick(list, child, position, adapter.getItemId(position)
						);
				}
				return true;
			}
			return false;
		}

		/// <returns>The currently selected item or null if the popup is not showing.</returns>
		public virtual object getSelectedItem()
		{
			if (!isShowing())
			{
				return null;
			}
			return mDropDownList.getSelectedItem();
		}

		/// <returns>
		/// The position of the currently selected item or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>false</code>
		/// .
		/// </returns>
		/// <seealso cref="AdapterView{T}.getSelectedItemPosition()">AdapterView&lt;T&gt;.getSelectedItemPosition()
		/// 	</seealso>
		public virtual int getSelectedItemPosition()
		{
			if (!isShowing())
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			return mDropDownList.getSelectedItemPosition();
		}

		/// <returns>
		/// The ID of the currently selected item or
		/// <see cref="android.widget.AdapterView.INVALID_ROW_ID">android.widget.AdapterView.INVALID_ROW_ID
		/// 	</see>
		/// if
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>false</code>
		/// .
		/// </returns>
		/// <seealso cref="AdapterView{T}.getSelectedItemId()">AdapterView&lt;T&gt;.getSelectedItemId()
		/// 	</seealso>
		public virtual long getSelectedItemId()
		{
			if (!isShowing())
			{
				return android.widget.AdapterView.INVALID_ROW_ID;
			}
			return mDropDownList.getSelectedItemId();
		}

		/// <returns>
		/// The View for the currently selected item or null if
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>false</code>
		/// .
		/// </returns>
		/// <seealso cref="AbsListView.getSelectedView()">AbsListView.getSelectedView()</seealso>
		public virtual android.view.View getSelectedView()
		{
			if (!isShowing())
			{
				return null;
			}
			return mDropDownList.getSelectedView();
		}

		/// <returns>
		/// The
		/// <see cref="ListView">ListView</see>
		/// displayed within the popup window.
		/// Only valid when
		/// <see cref="isShowing()">isShowing()</see>
		/// ==
		/// <code>true</code>
		/// .
		/// </returns>
		public virtual android.widget.ListView getListView()
		{
			return mDropDownList;
		}

		/// <summary>
		/// The maximum number of list items that can be visible and still have
		/// the list expand when touched.
		/// </summary>
		/// <remarks>
		/// The maximum number of list items that can be visible and still have
		/// the list expand when touched.
		/// </remarks>
		/// <param name="max">Max number of items that can be visible and still allow the list to expand.
		/// 	</param>
		internal virtual void setListItemExpandMax(int max)
		{
			mListItemExpandMaximum = max;
		}

		/// <summary>Filter key down events.</summary>
		/// <remarks>
		/// Filter key down events. By forwarding key down events to this function,
		/// views using non-modal ListPopupWindow can have it handle key selection of items.
		/// </remarks>
		/// <param name="keyCode">keyCode param passed to the host view's onKeyDown</param>
		/// <param name="event">event param passed to the host view's onKeyDown</param>
		/// <returns>true if the event was handled, false if it was ignored.</returns>
		/// <seealso cref="setModal(bool)">setModal(bool)</seealso>
		public virtual bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			// when the drop down is shown, we drive it directly
			if (isShowing())
			{
				// the key events are forwarded to the list in the drop down view
				// note that ListView handles space but we don't want that to happen
				// also if selection is not currently in the drop down, then don't
				// let center or enter presses go there since that would cause it
				// to select one of its items
				if (keyCode != android.view.KeyEvent.KEYCODE_SPACE && (mDropDownList.getSelectedItemPosition
					() >= 0 || (keyCode != android.view.KeyEvent.KEYCODE_ENTER && keyCode != android.view.KeyEvent
					.KEYCODE_DPAD_CENTER)))
				{
					int curIndex = mDropDownList.getSelectedItemPosition();
					bool consumed;
					bool below = !mPopup.isAboveAnchor();
					android.widget.ListAdapter adapter = mAdapter;
					bool allEnabled;
					int firstItem = int.MaxValue;
					int lastItem = int.MinValue;
					if (adapter != null)
					{
						allEnabled = adapter.areAllItemsEnabled();
						firstItem = allEnabled ? 0 : mDropDownList.lookForSelectablePosition(0, true);
						lastItem = allEnabled ? adapter.getCount() - 1 : mDropDownList.lookForSelectablePosition
							(adapter.getCount() - 1, false);
					}
					if ((below && keyCode == android.view.KeyEvent.KEYCODE_DPAD_UP && curIndex <= firstItem
						) || (!below && keyCode == android.view.KeyEvent.KEYCODE_DPAD_DOWN && curIndex >=
						 lastItem))
					{
						// When the selection is at the top, we block the key
						// event to prevent focus from moving.
						clearListSelection();
						mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NEEDED);
						show();
						return true;
					}
					else
					{
						// WARNING: Please read the comment where mListSelectionHidden
						//          is declared
						mDropDownList.mListSelectionHidden = false;
					}
					consumed = mDropDownList.onKeyDown(keyCode, @event);
					if (consumed)
					{
						// If it handled the key event, then the user is
						// navigating in the list, so we should put it in front.
						mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED);
						// Here's a little trick we need to do to make sure that
						// the list view is actually showing its focus indicator,
						// by ensuring it has focus and getting its window out
						// of touch mode.
						mDropDownList.requestFocusFromTouch();
						show();
						switch (keyCode)
						{
							case android.view.KeyEvent.KEYCODE_ENTER:
							case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
							case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
							case android.view.KeyEvent.KEYCODE_DPAD_UP:
							{
								// avoid passing the focus from the text view to the
								// next component
								return true;
							}
						}
					}
					else
					{
						if (below && keyCode == android.view.KeyEvent.KEYCODE_DPAD_DOWN)
						{
							// when the selection is at the bottom, we block the
							// event to avoid going to the next focusable widget
							if (curIndex == lastItem)
							{
								return true;
							}
						}
						else
						{
							if (!below && keyCode == android.view.KeyEvent.KEYCODE_DPAD_UP && curIndex == firstItem)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		/// <summary>Filter key down events.</summary>
		/// <remarks>
		/// Filter key down events. By forwarding key up events to this function,
		/// views using non-modal ListPopupWindow can have it handle key selection of items.
		/// </remarks>
		/// <param name="keyCode">keyCode param passed to the host view's onKeyUp</param>
		/// <param name="event">event param passed to the host view's onKeyUp</param>
		/// <returns>true if the event was handled, false if it was ignored.</returns>
		/// <seealso cref="setModal(bool)">setModal(bool)</seealso>
		public virtual bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			if (isShowing() && mDropDownList.getSelectedItemPosition() >= 0)
			{
				bool consumed = mDropDownList.onKeyUp(keyCode, @event);
				if (consumed)
				{
					switch (keyCode)
					{
						case android.view.KeyEvent.KEYCODE_ENTER:
						case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
						{
							// if the list accepts the key events and the key event
							// was a click, the text view gets the selected item
							// from the drop down as its content
							dismiss();
							break;
						}
					}
				}
				return consumed;
			}
			return false;
		}

		/// <summary>Filter pre-IME key events.</summary>
		/// <remarks>
		/// Filter pre-IME key events. By forwarding
		/// <see cref="android.view.View.onKeyPreIme(int, android.view.KeyEvent)">android.view.View.onKeyPreIme(int, android.view.KeyEvent)
		/// 	</see>
		/// events to this function, views using ListPopupWindow can have it dismiss the popup
		/// when the back key is pressed.
		/// </remarks>
		/// <param name="keyCode">keyCode param passed to the host view's onKeyPreIme</param>
		/// <param name="event">event param passed to the host view's onKeyPreIme</param>
		/// <returns>true if the event was handled, false if it was ignored.</returns>
		/// <seealso cref="setModal(bool)">setModal(bool)</seealso>
		public virtual bool onKeyPreIme(int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_BACK && isShowing())
			{
				// special case for the back key, we do not even try to send it
				// to the drop down list but instead, consume it immediately
				android.view.View anchorView = mDropDownAnchorView;
				if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
					() == 0)
				{
					android.view.KeyEvent.DispatcherState state = anchorView.getKeyDispatcherState();
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
						android.view.KeyEvent.DispatcherState state = anchorView.getKeyDispatcherState();
						if (state != null)
						{
							state.handleUpEvent(@event);
						}
						if (@event.isTracking() && !@event.isCanceled())
						{
							dismiss();
							return true;
						}
					}
				}
			}
			return false;
		}

		private sealed class _Runnable_976 : java.lang.Runnable
		{
			public _Runnable_976(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				// View layout should be all done before displaying the drop down.
				android.view.View view = this._enclosing.getAnchorView();
				if (view != null && view.getWindowToken() != null)
				{
					this._enclosing.show();
				}
			}

			private readonly ListPopupWindow _enclosing;
		}

		private sealed class _OnItemSelectedListener_994 : android.widget.AdapterView.OnItemSelectedListener
		{
			public _OnItemSelectedListener_994(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onItemSelected(object parent, android.view.View view, int position, long
				 id)
			{
				if (position != -1)
				{
					android.widget.ListPopupWindow.DropDownListView dropDownList = this._enclosing.mDropDownList;
					if (dropDownList != null)
					{
						dropDownList.mListSelectionHidden = false;
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemSelectedListener"
				)]
			public void onNothingSelected(object parent)
			{
			}

			private readonly ListPopupWindow _enclosing;
		}

		/// <summary>
		/// <p>Builds the popup window's content and returns the height the popup
		/// should have.
		/// </summary>
		/// <remarks>
		/// <p>Builds the popup window's content and returns the height the popup
		/// should have. Returns -1 when the content already exists.</p>
		/// </remarks>
		/// <returns>the content's height or -1 if content already exists</returns>
		private int buildDropDown()
		{
			android.view.ViewGroup dropDownView;
			int otherHeights = 0;
			if (mDropDownList == null)
			{
				android.content.Context context = mContext;
				mShowDropDownRunnable = new _Runnable_976(this);
				mDropDownList = new android.widget.ListPopupWindow.DropDownListView(context, !mModal
					);
				if (mDropDownListHighlight != null)
				{
					mDropDownList.setSelector(mDropDownListHighlight);
				}
				mDropDownList.setAdapter(mAdapter);
				mDropDownList.setOnItemClickListener(mItemClickListener);
				mDropDownList.setFocusable(true);
				mDropDownList.setFocusableInTouchMode(true);
				mDropDownList.setOnItemSelectedListener(new _OnItemSelectedListener_994(this));
				mDropDownList.setOnScrollListener(mScrollListener);
				if (mItemSelectedListener != null)
				{
					mDropDownList.setOnItemSelectedListener(mItemSelectedListener);
				}
				dropDownView = mDropDownList;
				android.view.View hintView = mPromptView;
				if (hintView != null)
				{
					// if an hint has been specified, we accomodate more space for it and
					// add a text view in the drop down menu, at the bottom of the list
					android.widget.LinearLayout hintContainer = new android.widget.LinearLayout(context
						);
					hintContainer.setOrientation(android.widget.LinearLayout.VERTICAL);
					android.widget.LinearLayout.LayoutParams hintParams = new android.widget.LinearLayout
						.LayoutParams(android.view.ViewGroup.LayoutParams.MATCH_PARENT, 0, 1.0f);
					switch (mPromptPosition)
					{
						case POSITION_PROMPT_BELOW:
						{
							hintContainer.addView(dropDownView, hintParams);
							hintContainer.addView(hintView);
							break;
						}

						case POSITION_PROMPT_ABOVE:
						{
							hintContainer.addView(hintView);
							hintContainer.addView(dropDownView, hintParams);
							break;
						}

						default:
						{
							android.util.Log.e(TAG, "Invalid hint position " + mPromptPosition);
							break;
						}
					}
					// measure the hint's height to find how much more vertical space
					// we need to add to the drop down's height
					int widthSpec = android.view.View.MeasureSpec.makeMeasureSpec(mDropDownWidth, android.view.View
						.MeasureSpec.AT_MOST);
					int heightSpec = android.view.View.MeasureSpec.UNSPECIFIED;
					hintView.measure(widthSpec, heightSpec);
					hintParams = (android.widget.LinearLayout.LayoutParams)hintView.getLayoutParams();
					otherHeights = hintView.getMeasuredHeight() + hintParams.topMargin + hintParams.bottomMargin;
					dropDownView = hintContainer;
				}
				mPopup.setContentView(dropDownView);
			}
			else
			{
				dropDownView = (android.view.ViewGroup)mPopup.getContentView();
				android.view.View view = mPromptView;
				if (view != null)
				{
					android.widget.LinearLayout.LayoutParams hintParams = (android.widget.LinearLayout
						.LayoutParams)view.getLayoutParams();
					otherHeights = view.getMeasuredHeight() + hintParams.topMargin + hintParams.bottomMargin;
				}
			}
			// getMaxAvailableHeight() subtracts the padding, so we put it back
			// to get the available height for the whole window
			int padding = 0;
			android.graphics.drawable.Drawable background = mPopup.getBackground();
			if (background != null)
			{
				background.getPadding(mTempRect);
				padding = mTempRect.top + mTempRect.bottom;
				// If we don't have an explicit vertical offset, determine one from the window
				// background so that content will line up.
				if (!mDropDownVerticalOffsetSet)
				{
					mDropDownVerticalOffset = -mTempRect.top;
				}
			}
			// Max height available on the screen for a popup.
			bool ignoreBottomDecorations = mPopup.getInputMethodMode() == android.widget.PopupWindow
				.INPUT_METHOD_NOT_NEEDED;
			int maxHeight = mPopup.getMaxAvailableHeight(getAnchorView(), mDropDownVerticalOffset
				, ignoreBottomDecorations);
			if (mDropDownAlwaysVisible || mDropDownHeight == android.view.ViewGroup.LayoutParams
				.MATCH_PARENT)
			{
				return maxHeight + padding;
			}
			int listContent = mDropDownList.measureHeightOfChildren(android.view.View.MeasureSpec
				.UNSPECIFIED, 0, android.widget.ListView.NO_POSITION, maxHeight - otherHeights, 
				-1);
			// add padding only if the list has items in it, that way we don't show
			// the popup if it is not needed
			if (listContent > 0)
			{
				otherHeights += padding;
			}
			return listContent + otherHeights;
		}

		/// <summary><p>Wrapper class for a ListView.</summary>
		/// <remarks>
		/// <p>Wrapper class for a ListView. This wrapper can hijack the focus to
		/// make sure the list uses the appropriate drawables and states when
		/// displayed on screen within a drop down. The focus is never actually
		/// passed to the drop down in this mode; the list only looks focused.</p>
		/// </remarks>
		private class DropDownListView : android.widget.ListView
		{
			internal static readonly string TAG = android.widget.ListPopupWindow.TAG + ".DropDownListView";

			internal bool mListSelectionHidden;

			/// <summary>True if this wrapper should fake focus.</summary>
			/// <remarks>True if this wrapper should fake focus.</remarks>
			internal bool mHijackFocus;

			/// <summary><p>Creates a new list view wrapper.</p></summary>
			/// <param name="context">this view's context</param>
			public DropDownListView(android.content.Context context, bool hijackFocus) : base
				(context, null, android.@internal.R.attr.dropDownListViewStyle)
			{
				mHijackFocus = hijackFocus;
				// TODO: Add an API to control this
				setCacheColorHint(0);
			}

			// Transparent, since the background drawable could be anything.
			/// <summary>
			/// <p>Avoids jarring scrolling effect by ensuring that list elements
			/// made of a text view fit on a single line.</p>
			/// </summary>
			/// <param name="position">the item index in the list to get a view for</param>
			/// <returns>the view for the specified item</returns>
			[Sharpen.OverridesMethod(@"android.widget.AbsListView")]
			internal override android.view.View obtainView(int position, bool[] isScrap)
			{
				android.view.View view = base.obtainView(position, isScrap);
				if (view is android.widget.TextView)
				{
					((android.widget.TextView)view).setHorizontallyScrolling(true);
				}
				return view;
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool isInTouchMode()
			{
				// WARNING: Please read the comment where mListSelectionHidden is declared
				return (mHijackFocus && mListSelectionHidden) || base.isInTouchMode();
			}

			/// <summary><p>Returns the focus state in the drop down.</p></summary>
			/// <returns>true always if hijacking focus</returns>
			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool hasWindowFocus()
			{
				return mHijackFocus || base.hasWindowFocus();
			}

			/// <summary><p>Returns the focus state in the drop down.</p></summary>
			/// <returns>true always if hijacking focus</returns>
			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool isFocused()
			{
				return mHijackFocus || base.isFocused();
			}

			/// <summary><p>Returns the focus state in the drop down.</p></summary>
			/// <returns>true always if hijacking focus</returns>
			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool hasFocus()
			{
				return mHijackFocus || base.hasFocus();
			}
		}

		private class PopupDataSetObserver : android.database.DataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				if (this._enclosing.isShowing())
				{
					// Resize the popup to fit new content
					this._enclosing.show();
				}
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				this._enclosing.dismiss();
			}

			internal PopupDataSetObserver(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListPopupWindow _enclosing;
		}

		private class ListSelectorHider : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.clearListSelection();
			}

			internal ListSelectorHider(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListPopupWindow _enclosing;
		}

		private class ResizePopupRunnable : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.mDropDownList != null && this._enclosing.mDropDownList.getCount
					() > this._enclosing.mDropDownList.getChildCount() && this._enclosing.mDropDownList
					.getChildCount() <= this._enclosing.mListItemExpandMaximum)
				{
					this._enclosing.mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED
						);
					this._enclosing.show();
				}
			}

			internal ResizePopupRunnable(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListPopupWindow _enclosing;
		}

		private class PopupTouchInterceptor : android.view.View.OnTouchListener
		{
			[Sharpen.ImplementsInterface(@"android.view.View.OnTouchListener")]
			public virtual bool onTouch(android.view.View v, android.view.MotionEvent @event)
			{
				int action = @event.getAction();
				int x = (int)@event.getX();
				int y = (int)@event.getY();
				if (action == android.view.MotionEvent.ACTION_DOWN && this._enclosing.mPopup != null
					 && this._enclosing.mPopup.isShowing() && (x >= 0 && x < this._enclosing.mPopup.
					getWidth() && y >= 0 && y < this._enclosing.mPopup.getHeight()))
				{
					this._enclosing.mHandler.postDelayed(this._enclosing.mResizePopupRunnable, android.widget.ListPopupWindow
						.EXPAND_LIST_TIMEOUT);
				}
				else
				{
					if (action == android.view.MotionEvent.ACTION_UP)
					{
						this._enclosing.mHandler.removeCallbacks(this._enclosing.mResizePopupRunnable);
					}
				}
				return false;
			}

			internal PopupTouchInterceptor(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListPopupWindow _enclosing;
		}

		private class PopupScrollListener : android.widget.AbsListView.OnScrollListener
		{
			[Sharpen.ImplementsInterface(@"android.widget.AbsListView.OnScrollListener")]
			public virtual void onScroll(android.widget.AbsListView view, int firstVisibleItem
				, int visibleItemCount, int totalItemCount)
			{
			}

			[Sharpen.ImplementsInterface(@"android.widget.AbsListView.OnScrollListener")]
			public virtual void onScrollStateChanged(android.widget.AbsListView view, int scrollState
				)
			{
				if (scrollState == android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
					 && !this._enclosing.isInputMethodNotNeeded() && this._enclosing.mPopup.getContentView
					() != null)
				{
					this._enclosing.mHandler.removeCallbacks(this._enclosing.mResizePopupRunnable);
					this._enclosing.mResizePopupRunnable.run();
				}
			}

			internal PopupScrollListener(ListPopupWindow _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListPopupWindow _enclosing;
		}
	}
}
