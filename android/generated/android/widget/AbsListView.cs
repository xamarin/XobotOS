using Sharpen;

namespace android.widget
{
	/// <summary>Base class that can be used to implement virtualized lists of items.</summary>
	/// <remarks>
	/// Base class that can be used to implement virtualized lists of items. A list does
	/// not have a spatial definition here. For instance, subclases of this class can
	/// display the content of the list in a grid, in a carousel, as stack, etc.
	/// </remarks>
	/// <attr>ref android.R.styleable#AbsListView_listSelector</attr>
	/// <attr>ref android.R.styleable#AbsListView_drawSelectorOnTop</attr>
	/// <attr>ref android.R.styleable#AbsListView_stackFromBottom</attr>
	/// <attr>ref android.R.styleable#AbsListView_scrollingCache</attr>
	/// <attr>ref android.R.styleable#AbsListView_textFilterEnabled</attr>
	/// <attr>ref android.R.styleable#AbsListView_transcriptMode</attr>
	/// <attr>ref android.R.styleable#AbsListView_cacheColorHint</attr>
	/// <attr>ref android.R.styleable#AbsListView_fastScrollEnabled</attr>
	/// <attr>ref android.R.styleable#AbsListView_smoothScrollbar</attr>
	/// <attr>ref android.R.styleable#AbsListView_choiceMode</attr>
	[Sharpen.Sharpened]
	public abstract class AbsListView : android.widget.AdapterView<android.widget.ListAdapter
		>, android.text.TextWatcher, android.view.ViewTreeObserver.OnGlobalLayoutListener
		, android.widget.Filter.FilterListener, android.view.ViewTreeObserver.OnTouchModeChangeListener
		, android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback
	{
		/// <summary>Disables the transcript mode.</summary>
		/// <remarks>Disables the transcript mode.</remarks>
		/// <seealso cref="setTranscriptMode(int)">setTranscriptMode(int)</seealso>
		public const int TRANSCRIPT_MODE_DISABLED = 0;

		/// <summary>
		/// The list will automatically scroll to the bottom when a data set change
		/// notification is received and only if the last item is already visible
		/// on screen.
		/// </summary>
		/// <remarks>
		/// The list will automatically scroll to the bottom when a data set change
		/// notification is received and only if the last item is already visible
		/// on screen.
		/// </remarks>
		/// <seealso cref="setTranscriptMode(int)">setTranscriptMode(int)</seealso>
		public const int TRANSCRIPT_MODE_NORMAL = 1;

		/// <summary>
		/// The list will automatically scroll to the bottom, no matter what items
		/// are currently visible.
		/// </summary>
		/// <remarks>
		/// The list will automatically scroll to the bottom, no matter what items
		/// are currently visible.
		/// </remarks>
		/// <seealso cref="setTranscriptMode(int)">setTranscriptMode(int)</seealso>
		public const int TRANSCRIPT_MODE_ALWAYS_SCROLL = 2;

		/// <summary>Indicates that we are not in the middle of a touch gesture</summary>
		internal const int TOUCH_MODE_REST = -1;

		/// <summary>
		/// Indicates we just received the touch event and we are waiting to see if the it is a tap or a
		/// scroll gesture.
		/// </summary>
		/// <remarks>
		/// Indicates we just received the touch event and we are waiting to see if the it is a tap or a
		/// scroll gesture.
		/// </remarks>
		internal const int TOUCH_MODE_DOWN = 0;

		/// <summary>
		/// Indicates the touch has been recognized as a tap and we are now waiting to see if the touch
		/// is a longpress
		/// </summary>
		internal const int TOUCH_MODE_TAP = 1;

		/// <summary>Indicates we have waited for everything we can wait for, but the user's finger is still down
		/// 	</summary>
		internal const int TOUCH_MODE_DONE_WAITING = 2;

		/// <summary>Indicates the touch gesture is a scroll</summary>
		internal const int TOUCH_MODE_SCROLL = 3;

		/// <summary>Indicates the view is in the process of being flung</summary>
		internal const int TOUCH_MODE_FLING = 4;

		/// <summary>Indicates the touch gesture is an overscroll - a scroll beyond the beginning or end.
		/// 	</summary>
		/// <remarks>Indicates the touch gesture is an overscroll - a scroll beyond the beginning or end.
		/// 	</remarks>
		internal const int TOUCH_MODE_OVERSCROLL = 5;

		/// <summary>
		/// Indicates the view is being flung outside of normal content bounds
		/// and will spring back.
		/// </summary>
		/// <remarks>
		/// Indicates the view is being flung outside of normal content bounds
		/// and will spring back.
		/// </remarks>
		internal const int TOUCH_MODE_OVERFLING = 6;

		/// <summary>Regular layout - usually an unsolicited layout from the view system</summary>
		internal const int LAYOUT_NORMAL = 0;

		/// <summary>Show the first item</summary>
		internal const int LAYOUT_FORCE_TOP = 1;

		/// <summary>Force the selected item to be on somewhere on the screen</summary>
		internal const int LAYOUT_SET_SELECTION = 2;

		/// <summary>Show the last item</summary>
		internal const int LAYOUT_FORCE_BOTTOM = 3;

		/// <summary>
		/// Make a mSelectedItem appear in a specific location and build the rest of
		/// the views from there.
		/// </summary>
		/// <remarks>
		/// Make a mSelectedItem appear in a specific location and build the rest of
		/// the views from there. The top is specified by mSpecificTop.
		/// </remarks>
		internal const int LAYOUT_SPECIFIC = 4;

		/// <summary>Layout to sync as a result of a data change.</summary>
		/// <remarks>
		/// Layout to sync as a result of a data change. Restore mSyncPosition to have its top
		/// at mSpecificTop
		/// </remarks>
		internal const int LAYOUT_SYNC = 5;

		/// <summary>Layout as a result of using the navigation keys</summary>
		internal const int LAYOUT_MOVE_SELECTION = 6;

		/// <summary>Normal list that does not indicate choices</summary>
		public const int CHOICE_MODE_NONE = 0;

		/// <summary>The list allows up to one choice</summary>
		public const int CHOICE_MODE_SINGLE = 1;

		/// <summary>The list allows multiple choices</summary>
		public const int CHOICE_MODE_MULTIPLE = 2;

		/// <summary>The list allows multiple choices in a modal selection mode</summary>
		public const int CHOICE_MODE_MULTIPLE_MODAL = 3;

		/// <summary>Controls if/how the user may choose/check items in the list</summary>
		internal int mChoiceMode = CHOICE_MODE_NONE;

		/// <summary>Controls CHOICE_MODE_MULTIPLE_MODAL.</summary>
		/// <remarks>Controls CHOICE_MODE_MULTIPLE_MODAL. null when inactive.</remarks>
		internal android.view.ActionMode mChoiceActionMode;

		/// <summary>
		/// Wrapper for the multiple choice mode callback; AbsListView needs to perform
		/// a few extra actions around what application code does.
		/// </summary>
		/// <remarks>
		/// Wrapper for the multiple choice mode callback; AbsListView needs to perform
		/// a few extra actions around what application code does.
		/// </remarks>
		internal android.widget.AbsListView.MultiChoiceModeWrapper mMultiChoiceModeCallback;

		/// <summary>Running count of how many items are currently checked</summary>
		internal int mCheckedItemCount;

		/// <summary>Running state of which positions are currently checked</summary>
		internal android.util.SparseBooleanArray mCheckStates;

		/// <summary>Running state of which IDs are currently checked.</summary>
		/// <remarks>
		/// Running state of which IDs are currently checked.
		/// If there is a value for a given key, the checked state for that ID is true
		/// and the value holds the last known position in the adapter for that id.
		/// </remarks>
		internal android.util.LongSparseArray<int> mCheckedIdStates;

		/// <summary>Controls how the next layout will happen</summary>
		internal int mLayoutMode = LAYOUT_NORMAL;

		/// <summary>Should be used by subclasses to listen to changes in the dataset</summary>
		internal android.widget.AbsListView.AdapterDataSetObserver mDataSetObserver;

		/// <summary>The adapter containing the data to be displayed by this view</summary>
		internal android.widget.ListAdapter mAdapter;

		/// <summary>The remote adapter containing the data to be displayed by this view to be set
		/// 	</summary>
		private android.widget.RemoteViewsAdapter mRemoteAdapter;

		/// <summary>This flag indicates the a full notify is required when the RemoteViewsAdapter connects
		/// 	</summary>
		private bool mDeferNotifyDataSetChanged = false;

		/// <summary>Indicates whether the list selector should be drawn on top of the children or behind
		/// 	</summary>
		internal bool mDrawSelectorOnTop = false;

		/// <summary>The drawable used to draw the selector</summary>
		internal android.graphics.drawable.Drawable mSelector;

		/// <summary>The current position of the selector in the list.</summary>
		/// <remarks>The current position of the selector in the list.</remarks>
		internal int mSelectorPosition = android.widget.AdapterView.INVALID_POSITION;

		/// <summary>Defines the selector's location and dimension at drawing time</summary>
		internal android.graphics.Rect mSelectorRect = new android.graphics.Rect();

		/// <summary>
		/// The data set used to store unused views that should be reused during the next layout
		/// to avoid creating new ones
		/// </summary>
		internal readonly android.widget.AbsListView.RecycleBin mRecycler;

		/// <summary>The selection's left padding</summary>
		internal int mSelectionLeftPadding = 0;

		/// <summary>The selection's top padding</summary>
		internal int mSelectionTopPadding = 0;

		/// <summary>The selection's right padding</summary>
		internal int mSelectionRightPadding = 0;

		/// <summary>The selection's bottom padding</summary>
		internal int mSelectionBottomPadding = 0;

		/// <summary>This view's padding</summary>
		internal android.graphics.Rect mListPadding = new android.graphics.Rect();

		/// <summary>Subclasses must retain their measure spec from onMeasure() into this member
		/// 	</summary>
		internal int mWidthMeasureSpec = 0;

		/// <summary>The top scroll indicator</summary>
		internal android.view.View mScrollUp;

		/// <summary>The down scroll indicator</summary>
		internal android.view.View mScrollDown;

		/// <summary>
		/// When the view is scrolling, this flag is set to true to indicate subclasses that
		/// the drawing cache was enabled on the children
		/// </summary>
		internal bool mCachingStarted;

		internal bool mCachingActive;

		/// <summary>The position of the view that received the down motion event</summary>
		internal int mMotionPosition;

		/// <summary>The offset to the top of the mMotionPosition view when the down motion event was received
		/// 	</summary>
		internal int mMotionViewOriginalTop;

		/// <summary>The desired offset to the top of the mMotionPosition view after a scroll
		/// 	</summary>
		internal int mMotionViewNewTop;

		/// <summary>The X value associated with the the down motion event</summary>
		internal int mMotionX;

		/// <summary>The Y value associated with the the down motion event</summary>
		internal int mMotionY;

		/// <summary>
		/// One of TOUCH_MODE_REST, TOUCH_MODE_DOWN, TOUCH_MODE_TAP, TOUCH_MODE_SCROLL, or
		/// TOUCH_MODE_DONE_WAITING
		/// </summary>
		internal int mTouchMode = TOUCH_MODE_REST;

		/// <summary>Y value from on the previous motion event (if any)</summary>
		internal int mLastY;

		/// <summary>How far the finger moved before we started scrolling</summary>
		internal int mMotionCorrection;

		/// <summary>Determines speed during touch scrolling</summary>
		private android.view.VelocityTracker mVelocityTracker;

		/// <summary>Handles one frame of a fling</summary>
		private android.widget.AbsListView.FlingRunnable mFlingRunnable;

		/// <summary>Handles scrolling between positions within the list.</summary>
		/// <remarks>Handles scrolling between positions within the list.</remarks>
		private android.widget.AbsListView.PositionScroller mPositionScroller;

		/// <summary>
		/// The offset in pixels form the top of the AdapterView to the top
		/// of the currently selected view.
		/// </summary>
		/// <remarks>
		/// The offset in pixels form the top of the AdapterView to the top
		/// of the currently selected view. Used to save and restore state.
		/// </remarks>
		internal int mSelectedTop = 0;

		/// <summary>
		/// Indicates whether the list is stacked from the bottom edge or
		/// the top edge.
		/// </summary>
		/// <remarks>
		/// Indicates whether the list is stacked from the bottom edge or
		/// the top edge.
		/// </remarks>
		internal bool mStackFromBottom;

		/// <summary>
		/// When set to true, the list automatically discards the children's
		/// bitmap cache after scrolling.
		/// </summary>
		/// <remarks>
		/// When set to true, the list automatically discards the children's
		/// bitmap cache after scrolling.
		/// </remarks>
		internal bool mScrollingCacheEnabled;

		/// <summary>Whether or not to enable the fast scroll feature on this list</summary>
		internal bool mFastScrollEnabled;

		/// <summary>Optional callback to notify client when scroll position has changed</summary>
		private android.widget.AbsListView.OnScrollListener mOnScrollListener;

		/// <summary>Keeps track of our accessory window</summary>
		internal android.widget.PopupWindow mPopup;

		/// <summary>Used with type filter window</summary>
		internal android.widget.EditText mTextFilter;

		/// <summary>
		/// Indicates whether to use pixels-based or position-based scrollbar
		/// properties.
		/// </summary>
		/// <remarks>
		/// Indicates whether to use pixels-based or position-based scrollbar
		/// properties.
		/// </remarks>
		private bool mSmoothScrollbarEnabled = true;

		/// <summary>Indicates that this view supports filtering</summary>
		private bool mTextFilterEnabled;

		/// <summary>Indicates that this view is currently displaying a filtered view of the data
		/// 	</summary>
		private bool mFiltered;

		/// <summary>Rectangle used for hit testing children</summary>
		private android.graphics.Rect mTouchFrame;

		/// <summary>The position to resurrect the selected position to.</summary>
		/// <remarks>The position to resurrect the selected position to.</remarks>
		internal int mResurrectToPosition = android.widget.AdapterView.INVALID_POSITION;

		private android.view.ContextMenuClass.ContextMenuInfo mContextMenuInfo = null;

		/// <summary>Maximum distance to record overscroll</summary>
		internal int mOverscrollMax;

		/// <summary>Content height divided by this is the overscroll limit.</summary>
		/// <remarks>Content height divided by this is the overscroll limit.</remarks>
		internal const int OVERSCROLL_LIMIT_DIVISOR = 3;

		/// <summary>
		/// How many positions in either direction we will search to try to
		/// find a checked item with a stable ID that moved position across
		/// a data set change.
		/// </summary>
		/// <remarks>
		/// How many positions in either direction we will search to try to
		/// find a checked item with a stable ID that moved position across
		/// a data set change. If the item isn't found it will be unselected.
		/// </remarks>
		internal const int CHECK_POSITION_SEARCH_DISTANCE = 20;

		/// <summary>Used to request a layout when we changed touch mode</summary>
		internal const int TOUCH_MODE_UNKNOWN = -1;

		internal const int TOUCH_MODE_ON = 0;

		internal const int TOUCH_MODE_OFF = 1;

		private int mLastTouchMode = TOUCH_MODE_UNKNOWN;

		internal const bool PROFILE_SCROLLING = false;

		private bool mScrollProfilingStarted = false;

		internal const bool PROFILE_FLINGING = false;

		private bool mFlingProfilingStarted = false;

		/// <summary>
		/// The StrictMode "critical time span" objects to catch animation
		/// stutters.
		/// </summary>
		/// <remarks>
		/// The StrictMode "critical time span" objects to catch animation
		/// stutters.  Non-null when a time-sensitive animation is
		/// in-flight.  Must call finish() on them when done animating.
		/// These are no-ops on user builds.
		/// </remarks>
		private android.os.StrictMode.Span mScrollStrictSpan = null;

		private android.os.StrictMode.Span mFlingStrictSpan = null;

		/// <summary>The last CheckForLongPress runnable we posted, if any</summary>
		private android.widget.AbsListView.CheckForLongPress mPendingCheckForLongPress;

		/// <summary>The last CheckForTap runnable we posted, if any</summary>
		private java.lang.Runnable mPendingCheckForTap;

		/// <summary>The last CheckForKeyLongPress runnable we posted, if any</summary>
		private android.widget.AbsListView.CheckForKeyLongPress mPendingCheckForKeyLongPress;

		/// <summary>Acts upon click</summary>
		private android.widget.AbsListView.PerformClick mPerformClick;

		/// <summary>Delayed action for touch mode.</summary>
		/// <remarks>Delayed action for touch mode.</remarks>
		private java.lang.Runnable mTouchModeReset;

		/// <summary>
		/// This view is in transcript mode -- it shows the bottom of the list when the data
		/// changes
		/// </summary>
		private int mTranscriptMode;

		/// <summary>
		/// Indicates that this list is always drawn on top of a solid, single-color, opaque
		/// background
		/// </summary>
		private int mCacheColorHint;

		/// <summary>The select child's view (from the adapter's getView) is enabled.</summary>
		/// <remarks>The select child's view (from the adapter's getView) is enabled.</remarks>
		private bool mIsChildViewEnabled;

		/// <summary>
		/// The last scroll state reported to clients through
		/// <see cref="OnScrollListener">OnScrollListener</see>
		/// .
		/// </summary>
		private int mLastScrollState = android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE;

		/// <summary>Helper object that renders and controls the fast scroll thumb.</summary>
		/// <remarks>Helper object that renders and controls the fast scroll thumb.</remarks>
		private android.widget.FastScroller mFastScroller;

		private bool mGlobalLayoutListenerAddedFilter;

		private int mTouchSlop;

		private float mDensityScale;

		private android.view.inputmethod.InputConnection mDefInputConnection;

		private android.view.inputmethod.InputConnectionWrapper mPublicInputConnection;

		private java.lang.Runnable mClearScrollingCache;

		private int mMinimumVelocity;

		private int mMaximumVelocity;

		private float mVelocityScale = 1.0f;

		internal readonly bool[] mIsScrap = new bool[1];

		private bool mPopupHidden;

		/// <summary>ID of the active pointer.</summary>
		/// <remarks>
		/// ID of the active pointer. This is used to retain consistency during
		/// drags/flings if multiple pointers are used.
		/// </remarks>
		private int mActivePointerId = INVALID_POINTER;

		/// <summary>Sentinel value for no current active pointer.</summary>
		/// <remarks>
		/// Sentinel value for no current active pointer.
		/// Used by
		/// <see cref="mActivePointerId">mActivePointerId</see>
		/// .
		/// </remarks>
		internal const int INVALID_POINTER = -1;

		/// <summary>Maximum distance to overscroll by during edge effects</summary>
		internal int mOverscrollDistance;

		/// <summary>Maximum distance to overfling during edge effects</summary>
		internal int mOverflingDistance;

		/// <summary>Tracks the state of the top edge glow.</summary>
		/// <remarks>Tracks the state of the top edge glow.</remarks>
		private android.widget.EdgeEffect mEdgeGlowTop;

		/// <summary>Tracks the state of the bottom edge glow.</summary>
		/// <remarks>Tracks the state of the bottom edge glow.</remarks>
		private android.widget.EdgeEffect mEdgeGlowBottom;

		/// <summary>
		/// An estimate of how many pixels are between the top of the list and
		/// the top of the first position in the adapter, based on the last time
		/// we saw it.
		/// </summary>
		/// <remarks>
		/// An estimate of how many pixels are between the top of the list and
		/// the top of the first position in the adapter, based on the last time
		/// we saw it. Used to hint where to draw edge glows.
		/// </remarks>
		private int mFirstPositionDistanceGuess;

		/// <summary>
		/// An estimate of how many pixels are between the bottom of the list and
		/// the bottom of the last position in the adapter, based on the last time
		/// we saw it.
		/// </summary>
		/// <remarks>
		/// An estimate of how many pixels are between the bottom of the list and
		/// the bottom of the last position in the adapter, based on the last time
		/// we saw it. Used to hint where to draw edge glows.
		/// </remarks>
		private int mLastPositionDistanceGuess;

		/// <summary>Used for determining when to cancel out of overscroll.</summary>
		/// <remarks>Used for determining when to cancel out of overscroll.</remarks>
		private int mDirection = 0;

		/// <summary>Tracked on measurement in transcript mode.</summary>
		/// <remarks>
		/// Tracked on measurement in transcript mode. Makes sure that we can still pin to
		/// the bottom correctly on resizes.
		/// </remarks>
		private bool mForceTranscriptScroll;

		private int mGlowPaddingLeft;

		private int mGlowPaddingRight;

		private int mLastAccessibilityScrollEventFromIndex;

		private int mLastAccessibilityScrollEventToIndex;

		/// <summary>Track if we are currently attached to a window.</summary>
		/// <remarks>Track if we are currently attached to a window.</remarks>
		internal bool mIsAttached;

		/// <summary>Track the item count from the last time we handled a data change.</summary>
		/// <remarks>Track the item count from the last time we handled a data change.</remarks>
		private int mLastHandledItemCount;

		/// <summary>
		/// Interface definition for a callback to be invoked when the list or grid
		/// has been scrolled.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the list or grid
		/// has been scrolled.
		/// </remarks>
		public interface OnScrollListener
		{
			// True when the popup should be hidden because of a call to
			// dispatchDisplayHint()
			// These two EdgeGlows are always set and used together.
			// Checking one for null is as good as checking both.
			/// <summary>Callback method to be invoked while the list view or grid view is being scrolled.
			/// 	</summary>
			/// <remarks>
			/// Callback method to be invoked while the list view or grid view is being scrolled. If the
			/// view is being scrolled, this method will be called before the next frame of the scroll is
			/// rendered. In particular, it will be called before any calls to
			/// <see cref="Adapter.getView(int, android.view.View, android.view.ViewGroup)">Adapter.getView(int, android.view.View, android.view.ViewGroup)
			/// 	</see>
			/// .
			/// </remarks>
			/// <param name="view">The view whose scroll state is being reported</param>
			/// <param name="scrollState">
			/// The current scroll state. One of
			/// <see cref="android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE">android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
			/// 	</see>
			/// ,
			/// <see cref="android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
			/// 	">android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL</see>
			/// or
			/// <see cref="android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE">android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
			/// 	</see>
			/// .
			/// </param>
			void onScrollStateChanged(android.widget.AbsListView view, int scrollState);

			/// <summary>Callback method to be invoked when the list or grid has been scrolled.</summary>
			/// <remarks>
			/// Callback method to be invoked when the list or grid has been scrolled. This will be
			/// called after the scroll has completed
			/// </remarks>
			/// <param name="view">The view whose scroll state is being reported</param>
			/// <param name="firstVisibleItem">
			/// the index of the first visible cell (ignore if
			/// visibleItemCount == 0)
			/// </param>
			/// <param name="visibleItemCount">the number of visible cells</param>
			/// <param name="totalItemCount">the number of items in the list adaptor</param>
			void onScroll(android.widget.AbsListView view, int firstVisibleItem, int visibleItemCount
				, int totalItemCount);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the list or grid
		/// has been scrolled.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the list or grid
		/// has been scrolled.
		/// </remarks>
		public static class OnScrollListenerClass
		{
			/// <summary>The view is not scrolling.</summary>
			/// <remarks>
			/// The view is not scrolling. Note navigating the list using the trackball counts as
			/// being in the idle state since these transitions are not animated.
			/// </remarks>
			public const int SCROLL_STATE_IDLE = 0;

			/// <summary>The user is scrolling using touch, and their finger is still on the screen
			/// 	</summary>
			public const int SCROLL_STATE_TOUCH_SCROLL = 1;

			/// <summary>The user had previously been scrolling using touch and had performed a fling.
			/// 	</summary>
			/// <remarks>
			/// The user had previously been scrolling using touch and had performed a fling. The
			/// animation is now coasting to a stop
			/// </remarks>
			public const int SCROLL_STATE_FLING = 2;
		}

		/// <summary>
		/// The top-level view of a list item can implement this interface to allow
		/// itself to modify the bounds of the selection shown for that item.
		/// </summary>
		/// <remarks>
		/// The top-level view of a list item can implement this interface to allow
		/// itself to modify the bounds of the selection shown for that item.
		/// </remarks>
		public interface SelectionBoundsAdjuster
		{
			/// <summary>
			/// Called to allow the list item to adjust the bounds shown for
			/// its selection.
			/// </summary>
			/// <remarks>
			/// Called to allow the list item to adjust the bounds shown for
			/// its selection.
			/// </remarks>
			/// <param name="bounds">
			/// On call, this contains the bounds the list has
			/// selected for the item (that is the bounds of the entire view).  The
			/// values can be modified as desired.
			/// </param>
			void adjustListItemSelectionBounds(android.graphics.Rect bounds);
		}

		public AbsListView(android.content.Context context) : base(context)
		{
			mRecycler = new android.widget.AbsListView.RecycleBin(this);
			initAbsListView();
			setVerticalScrollBarEnabled(true);
			android.content.res.TypedArray a = context.obtainStyledAttributes(android.@internal.R
				.styleable.View);
			initializeScrollbars(a);
			a.recycle();
		}

		public AbsListView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.absListViewStyle)
		{
			mRecycler = new android.widget.AbsListView.RecycleBin(this);
		}

		public AbsListView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mRecycler = new android.widget.AbsListView.RecycleBin(this);
			initAbsListView();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AbsListView, defStyle, 0);
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.AbsListView_listSelector);
			if (d != null)
			{
				setSelector(d);
			}
			mDrawSelectorOnTop = a.getBoolean(android.@internal.R.styleable.AbsListView_drawSelectorOnTop
				, false);
			bool stackFromBottom = a.getBoolean(android.@internal.R.styleable.AbsListView_stackFromBottom
				, false);
			setStackFromBottom(stackFromBottom);
			bool scrollingCacheEnabled = a.getBoolean(android.@internal.R.styleable.AbsListView_scrollingCache
				, true);
			setScrollingCacheEnabled(scrollingCacheEnabled);
			bool useTextFilter = a.getBoolean(android.@internal.R.styleable.AbsListView_textFilterEnabled
				, false);
			setTextFilterEnabled(useTextFilter);
			int transcriptMode = a.getInt(android.@internal.R.styleable.AbsListView_transcriptMode
				, TRANSCRIPT_MODE_DISABLED);
			setTranscriptMode(transcriptMode);
			int color = a.getColor(android.@internal.R.styleable.AbsListView_cacheColorHint, 
				0);
			setCacheColorHint(color);
			bool enableFastScroll = a.getBoolean(android.@internal.R.styleable.AbsListView_fastScrollEnabled
				, false);
			setFastScrollEnabled(enableFastScroll);
			bool smoothScrollbar = a.getBoolean(android.@internal.R.styleable.AbsListView_smoothScrollbar
				, true);
			setSmoothScrollbarEnabled(smoothScrollbar);
			setChoiceMode(a.getInt(android.@internal.R.styleable.AbsListView_choiceMode, CHOICE_MODE_NONE
				));
			setFastScrollAlwaysVisible(a.getBoolean(android.@internal.R.styleable.AbsListView_fastScrollAlwaysVisible
				, false));
			a.recycle();
		}

		private void initAbsListView()
		{
			// Setting focusable in touch mode will set the focusable property to true
			setClickable(true);
			setFocusableInTouchMode(true);
			setWillNotDraw(false);
			setAlwaysDrawnWithCacheEnabled(false);
			setScrollingCacheEnabled(true);
			android.view.ViewConfiguration configuration = android.view.ViewConfiguration.get
				(mContext);
			mTouchSlop = configuration.getScaledTouchSlop();
			mMinimumVelocity = configuration.getScaledMinimumFlingVelocity();
			mMaximumVelocity = configuration.getScaledMaximumFlingVelocity();
			mOverscrollDistance = configuration.getScaledOverscrollDistance();
			mOverflingDistance = configuration.getScaledOverflingDistance();
			mDensityScale = getContext().getResources().getDisplayMetrics().density;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setOverScrollMode(int mode)
		{
			if (mode != OVER_SCROLL_NEVER)
			{
				if (mEdgeGlowTop == null)
				{
					android.content.Context context = getContext();
					mEdgeGlowTop = new android.widget.EdgeEffect(context);
					mEdgeGlowBottom = new android.widget.EdgeEffect(context);
				}
			}
			else
			{
				mEdgeGlowTop = null;
				mEdgeGlowBottom = null;
			}
			base.setOverScrollMode(mode);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.ListAdapter adapter)
		{
			if (adapter != null)
			{
				if (mChoiceMode != CHOICE_MODE_NONE && mAdapter.hasStableIds() && mCheckedIdStates
					 == null)
				{
					mCheckedIdStates = new android.util.LongSparseArray<int>();
				}
			}
			if (mCheckStates != null)
			{
				mCheckStates.clear();
			}
			if (mCheckedIdStates != null)
			{
				mCheckedIdStates.clear();
			}
		}

		/// <summary>Returns the number of items currently selected.</summary>
		/// <remarks>
		/// Returns the number of items currently selected. This will only be valid
		/// if the choice mode is not
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// (default).
		/// <p>To determine the specific items that are currently selected, use one of
		/// the <code>getChecked*</code> methods.
		/// </remarks>
		/// <returns>The number of items currently selected</returns>
		/// <seealso cref="getCheckedItemPosition()">getCheckedItemPosition()</seealso>
		/// <seealso cref="getCheckedItemPositions()">getCheckedItemPositions()</seealso>
		/// <seealso cref="getCheckedItemIds()">getCheckedItemIds()</seealso>
		public virtual int getCheckedItemCount()
		{
			return mCheckedItemCount;
		}

		/// <summary>Returns the checked state of the specified position.</summary>
		/// <remarks>
		/// Returns the checked state of the specified position. The result is only
		/// valid if the choice mode has been set to
		/// <see cref="CHOICE_MODE_SINGLE">CHOICE_MODE_SINGLE</see>
		/// or
		/// <see cref="CHOICE_MODE_MULTIPLE">CHOICE_MODE_MULTIPLE</see>
		/// .
		/// </remarks>
		/// <param name="position">The item whose checked state to return</param>
		/// <returns>
		/// The item's checked state or <code>false</code> if choice mode
		/// is invalid
		/// </returns>
		/// <seealso cref="setChoiceMode(int)">setChoiceMode(int)</seealso>
		public virtual bool isItemChecked(int position)
		{
			if (mChoiceMode != CHOICE_MODE_NONE && mCheckStates != null)
			{
				return mCheckStates.get(position);
			}
			return false;
		}

		/// <summary>Returns the currently checked item.</summary>
		/// <remarks>
		/// Returns the currently checked item. The result is only valid if the choice
		/// mode has been set to
		/// <see cref="CHOICE_MODE_SINGLE">CHOICE_MODE_SINGLE</see>
		/// .
		/// </remarks>
		/// <returns>
		/// The position of the currently checked item or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if nothing is selected
		/// </returns>
		/// <seealso cref="setChoiceMode(int)">setChoiceMode(int)</seealso>
		public virtual int getCheckedItemPosition()
		{
			if (mChoiceMode == CHOICE_MODE_SINGLE && mCheckStates != null && mCheckStates.size
				() == 1)
			{
				return mCheckStates.keyAt(0);
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>Returns the set of checked items in the list.</summary>
		/// <remarks>
		/// Returns the set of checked items in the list. The result is only valid if
		/// the choice mode has not been set to
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// .
		/// </remarks>
		/// <returns>
		/// A SparseBooleanArray which will return true for each call to
		/// get(int position) where position is a position in the list,
		/// or <code>null</code> if the choice mode is set to
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// .
		/// </returns>
		public virtual android.util.SparseBooleanArray getCheckedItemPositions()
		{
			if (mChoiceMode != CHOICE_MODE_NONE)
			{
				return mCheckStates;
			}
			return null;
		}

		/// <summary>Returns the set of checked items ids.</summary>
		/// <remarks>
		/// Returns the set of checked items ids. The result is only valid if the
		/// choice mode has not been set to
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// and the adapter
		/// has stable IDs. (
		/// <see cref="Adapter.hasStableIds()">Adapter.hasStableIds()</see>
		/// ==
		/// <code>true</code>
		/// )
		/// </remarks>
		/// <returns>
		/// A new array which contains the id of each checked item in the
		/// list.
		/// </returns>
		public virtual long[] getCheckedItemIds()
		{
			if (mChoiceMode == CHOICE_MODE_NONE || mCheckedIdStates == null || mAdapter == null)
			{
				return new long[0];
			}
			android.util.LongSparseArray<int> idStates = mCheckedIdStates;
			int count = idStates.size();
			long[] ids = new long[count];
			{
				for (int i = 0; i < count; i++)
				{
					ids[i] = idStates.keyAt(i);
				}
			}
			return ids;
		}

		/// <summary>Clear any choices previously set</summary>
		public virtual void clearChoices()
		{
			if (mCheckStates != null)
			{
				mCheckStates.clear();
			}
			if (mCheckedIdStates != null)
			{
				mCheckedIdStates.clear();
			}
			mCheckedItemCount = 0;
		}

		/// <summary>Sets the checked state of the specified position.</summary>
		/// <remarks>
		/// Sets the checked state of the specified position. The is only valid if
		/// the choice mode has been set to
		/// <see cref="CHOICE_MODE_SINGLE">CHOICE_MODE_SINGLE</see>
		/// or
		/// <see cref="CHOICE_MODE_MULTIPLE">CHOICE_MODE_MULTIPLE</see>
		/// .
		/// </remarks>
		/// <param name="position">The item whose checked state is to be checked</param>
		/// <param name="value">The new checked state for the item</param>
		public virtual void setItemChecked(int position, bool value)
		{
			if (mChoiceMode == CHOICE_MODE_NONE)
			{
				return;
			}
			// Start selection mode if needed. We don't need to if we're unchecking something.
			if (value && mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL && mChoiceActionMode == null)
			{
				mChoiceActionMode = startActionMode(mMultiChoiceModeCallback);
			}
			if (mChoiceMode == CHOICE_MODE_MULTIPLE || mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL)
			{
				bool oldValue = mCheckStates.get(position);
				mCheckStates.put(position, value);
				if (mCheckedIdStates != null && mAdapter.hasStableIds())
				{
					if (value)
					{
						mCheckedIdStates.put(mAdapter.getItemId(position), position);
					}
					else
					{
						mCheckedIdStates.delete(mAdapter.getItemId(position));
					}
				}
				if (oldValue != value)
				{
					if (value)
					{
						mCheckedItemCount++;
					}
					else
					{
						mCheckedItemCount--;
					}
				}
				if (mChoiceActionMode != null)
				{
					long id = mAdapter.getItemId(position);
					mMultiChoiceModeCallback.onItemCheckedStateChanged(mChoiceActionMode, position, id
						, value);
				}
			}
			else
			{
				bool updateIds = mCheckedIdStates != null && mAdapter.hasStableIds();
				// Clear all values if we're checking something, or unchecking the currently
				// selected item
				if (value || isItemChecked(position))
				{
					mCheckStates.clear();
					if (updateIds)
					{
						mCheckedIdStates.clear();
					}
				}
				// this may end up selecting the value we just cleared but this way
				// we ensure length of mCheckStates is 1, a fact getCheckedItemPosition relies on
				if (value)
				{
					mCheckStates.put(position, true);
					if (updateIds)
					{
						mCheckedIdStates.put(mAdapter.getItemId(position), position);
					}
					mCheckedItemCount = 1;
				}
				else
				{
					if (mCheckStates.size() == 0 || !mCheckStates.valueAt(0))
					{
						mCheckedItemCount = 0;
					}
				}
			}
			// Do not generate a data change while we are in the layout phase
			if (!mInLayout && !mBlockLayoutRequests)
			{
				mDataChanged = true;
				rememberSyncState();
				requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override bool performItemClick(android.view.View view, int position, long 
			id)
		{
			bool handled = false;
			bool dispatchItemClick = true;
			if (mChoiceMode != CHOICE_MODE_NONE)
			{
				handled = true;
				if (mChoiceMode == CHOICE_MODE_MULTIPLE || (mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL
					 && mChoiceActionMode != null))
				{
					bool newValue = !mCheckStates.get(position, false);
					mCheckStates.put(position, newValue);
					if (mCheckedIdStates != null && mAdapter.hasStableIds())
					{
						if (newValue)
						{
							mCheckedIdStates.put(mAdapter.getItemId(position), position);
						}
						else
						{
							mCheckedIdStates.delete(mAdapter.getItemId(position));
						}
					}
					if (newValue)
					{
						mCheckedItemCount++;
					}
					else
					{
						mCheckedItemCount--;
					}
					if (mChoiceActionMode != null)
					{
						mMultiChoiceModeCallback.onItemCheckedStateChanged(mChoiceActionMode, position, id
							, newValue);
						dispatchItemClick = false;
					}
				}
				else
				{
					if (mChoiceMode == CHOICE_MODE_SINGLE)
					{
						bool newValue = !mCheckStates.get(position, false);
						if (newValue)
						{
							mCheckStates.clear();
							mCheckStates.put(position, true);
							if (mCheckedIdStates != null && mAdapter.hasStableIds())
							{
								mCheckedIdStates.clear();
								mCheckedIdStates.put(mAdapter.getItemId(position), position);
							}
							mCheckedItemCount = 1;
						}
						else
						{
							if (mCheckStates.size() == 0 || !mCheckStates.valueAt(0))
							{
								mCheckedItemCount = 0;
							}
						}
					}
				}
				mDataChanged = true;
				rememberSyncState();
				requestLayout();
			}
			if (dispatchItemClick)
			{
				handled |= base.performItemClick(view, position, id);
			}
			return handled;
		}

		/// <seealso cref="setChoiceMode(int)">setChoiceMode(int)</seealso>
		/// <returns>The current choice mode</returns>
		public virtual int getChoiceMode()
		{
			return mChoiceMode;
		}

		/// <summary>Defines the choice behavior for the List.</summary>
		/// <remarks>
		/// Defines the choice behavior for the List. By default, Lists do not have any choice behavior
		/// (
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// ). By setting the choiceMode to
		/// <see cref="CHOICE_MODE_SINGLE">CHOICE_MODE_SINGLE</see>
		/// , the
		/// List allows up to one item to  be in a chosen state. By setting the choiceMode to
		/// <see cref="CHOICE_MODE_MULTIPLE">CHOICE_MODE_MULTIPLE</see>
		/// , the list allows any number of items to be chosen.
		/// </remarks>
		/// <param name="choiceMode">
		/// One of
		/// <see cref="CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
		/// ,
		/// <see cref="CHOICE_MODE_SINGLE">CHOICE_MODE_SINGLE</see>
		/// , or
		/// <see cref="CHOICE_MODE_MULTIPLE">CHOICE_MODE_MULTIPLE</see>
		/// </param>
		public virtual void setChoiceMode(int choiceMode)
		{
			mChoiceMode = choiceMode;
			if (mChoiceActionMode != null)
			{
				mChoiceActionMode.finish();
				mChoiceActionMode = null;
			}
			if (mChoiceMode != CHOICE_MODE_NONE)
			{
				if (mCheckStates == null)
				{
					mCheckStates = new android.util.SparseBooleanArray();
				}
				if (mCheckedIdStates == null && mAdapter != null && mAdapter.hasStableIds())
				{
					mCheckedIdStates = new android.util.LongSparseArray<int>();
				}
				// Modal multi-choice mode only has choices when the mode is active. Clear them.
				if (mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL)
				{
					clearChoices();
					setLongClickable(true);
				}
			}
		}

		/// <summary>
		/// Set a
		/// <see cref="MultiChoiceModeListener">MultiChoiceModeListener</see>
		/// that will manage the lifecycle of the
		/// selection
		/// <see cref="android.view.ActionMode">android.view.ActionMode</see>
		/// . Only used when the choice mode is set to
		/// <see cref="CHOICE_MODE_MULTIPLE_MODAL">CHOICE_MODE_MULTIPLE_MODAL</see>
		/// .
		/// </summary>
		/// <param name="listener">Listener that will manage the selection mode</param>
		/// <seealso cref="setChoiceMode(int)">setChoiceMode(int)</seealso>
		public virtual void setMultiChoiceModeListener(android.widget.AbsListView.MultiChoiceModeListener
			 listener)
		{
			if (mMultiChoiceModeCallback == null)
			{
				mMultiChoiceModeCallback = new android.widget.AbsListView.MultiChoiceModeWrapper(
					this);
			}
			mMultiChoiceModeCallback.setWrapped(listener);
		}

		/// <returns>true if all list content currently fits within the view boundaries</returns>
		private bool contentFits()
		{
			int childCount = getChildCount();
			if (childCount == 0)
			{
				return true;
			}
			if (childCount != mItemCount)
			{
				return false;
			}
			return getChildAt(0).getTop() >= mListPadding.top && getChildAt(childCount - 1).getBottom
				() <= getHeight() - mListPadding.bottom;
		}

		/// <summary>
		/// Enables fast scrolling by letting the user quickly scroll through lists by
		/// dragging the fast scroll thumb.
		/// </summary>
		/// <remarks>
		/// Enables fast scrolling by letting the user quickly scroll through lists by
		/// dragging the fast scroll thumb. The adapter attached to the list may want
		/// to implement
		/// <see cref="SectionIndexer">SectionIndexer</see>
		/// if it wishes to display alphabet preview and
		/// jump between sections of the list.
		/// </remarks>
		/// <seealso cref="SectionIndexer">SectionIndexer</seealso>
		/// <seealso cref="isFastScrollEnabled()">isFastScrollEnabled()</seealso>
		/// <param name="enabled">whether or not to enable fast scrolling</param>
		public virtual void setFastScrollEnabled(bool enabled)
		{
			mFastScrollEnabled = enabled;
			if (enabled)
			{
				if (mFastScroller == null)
				{
					mFastScroller = new android.widget.FastScroller(getContext(), this);
				}
			}
			else
			{
				if (mFastScroller != null)
				{
					mFastScroller.stop();
					mFastScroller = null;
				}
			}
		}

		/// <summary>
		/// Set whether or not the fast scroller should always be shown in place of the
		/// standard scrollbars.
		/// </summary>
		/// <remarks>
		/// Set whether or not the fast scroller should always be shown in place of the
		/// standard scrollbars. Fast scrollers shown in this way will not fade out and will
		/// be a permanent fixture within the list. Best combined with an inset scroll bar style
		/// that will ensure enough padding. This will enable fast scrolling if it is not
		/// already enabled.
		/// </remarks>
		/// <param name="alwaysShow">true if the fast scroller should always be displayed.</param>
		/// <seealso cref="android.view.View.setScrollBarStyle(int)">android.view.View.setScrollBarStyle(int)
		/// 	</seealso>
		/// <seealso cref="setFastScrollEnabled(bool)">setFastScrollEnabled(bool)</seealso>
		public virtual void setFastScrollAlwaysVisible(bool alwaysShow)
		{
			if (alwaysShow && !mFastScrollEnabled)
			{
				setFastScrollEnabled(true);
			}
			if (mFastScroller != null)
			{
				mFastScroller.setAlwaysShow(alwaysShow);
			}
			computeOpaqueFlags();
			recomputePadding();
		}

		/// <summary>
		/// Returns true if the fast scroller is set to always show on this view rather than
		/// fade out when not in use.
		/// </summary>
		/// <remarks>
		/// Returns true if the fast scroller is set to always show on this view rather than
		/// fade out when not in use.
		/// </remarks>
		/// <returns>true if the fast scroller will always show.</returns>
		/// <seealso cref="setFastScrollAlwaysVisible(bool)">setFastScrollAlwaysVisible(bool)
		/// 	</seealso>
		public virtual bool isFastScrollAlwaysVisible()
		{
			return mFastScrollEnabled && mFastScroller.isAlwaysShowEnabled();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getVerticalScrollbarWidth()
		{
			if (isFastScrollAlwaysVisible())
			{
				return System.Math.Max(base.getVerticalScrollbarWidth(), mFastScroller.getWidth()
					);
			}
			return base.getVerticalScrollbarWidth();
		}

		/// <summary>Returns the current state of the fast scroll feature.</summary>
		/// <remarks>Returns the current state of the fast scroll feature.</remarks>
		/// <seealso cref="setFastScrollEnabled(bool)">setFastScrollEnabled(bool)</seealso>
		/// <returns>true if fast scroll is enabled, false otherwise</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isFastScrollEnabled()
		{
			return mFastScrollEnabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVerticalScrollbarPosition(int position)
		{
			base.setVerticalScrollbarPosition(position);
			if (mFastScroller != null)
			{
				mFastScroller.setScrollbarPosition(position);
			}
		}

		/// <summary>If fast scroll is visible, then don't draw the vertical scrollbar.</summary>
		/// <remarks>If fast scroll is visible, then don't draw the vertical scrollbar.</remarks>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool isVerticalScrollBarHidden()
		{
			return mFastScroller != null && mFastScroller.isVisible();
		}

		/// <summary>
		/// When smooth scrollbar is enabled, the position and size of the scrollbar thumb
		/// is computed based on the number of visible pixels in the visible items.
		/// </summary>
		/// <remarks>
		/// When smooth scrollbar is enabled, the position and size of the scrollbar thumb
		/// is computed based on the number of visible pixels in the visible items. This
		/// however assumes that all list items have the same height. If you use a list in
		/// which items have different heights, the scrollbar will change appearance as the
		/// user scrolls through the list. To avoid this issue, you need to disable this
		/// property.
		/// When smooth scrollbar is disabled, the position and size of the scrollbar thumb
		/// is based solely on the number of items in the adapter and the position of the
		/// visible items inside the adapter. This provides a stable scrollbar as the user
		/// navigates through a list of items with varying heights.
		/// </remarks>
		/// <param name="enabled">Whether or not to enable smooth scrollbar.</param>
		/// <seealso cref="setSmoothScrollbarEnabled(bool)">setSmoothScrollbarEnabled(bool)</seealso>
		/// <attr>ref android.R.styleable#AbsListView_smoothScrollbar</attr>
		public virtual void setSmoothScrollbarEnabled(bool enabled)
		{
			mSmoothScrollbarEnabled = enabled;
		}

		/// <summary>Returns the current state of the fast scroll feature.</summary>
		/// <remarks>Returns the current state of the fast scroll feature.</remarks>
		/// <returns>True if smooth scrollbar is enabled is enabled, false otherwise.</returns>
		/// <seealso cref="setSmoothScrollbarEnabled(bool)">setSmoothScrollbarEnabled(bool)</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isSmoothScrollbarEnabled()
		{
			return mSmoothScrollbarEnabled;
		}

		/// <summary>Set the listener that will receive notifications every time the list scrolls.
		/// 	</summary>
		/// <remarks>Set the listener that will receive notifications every time the list scrolls.
		/// 	</remarks>
		/// <param name="l">the scroll listener</param>
		public virtual void setOnScrollListener(android.widget.AbsListView.OnScrollListener
			 l)
		{
			mOnScrollListener = l;
			invokeOnItemScrollListener();
		}

		/// <summary>Notify our scroll listener (if there is one) of a change in scroll state
		/// 	</summary>
		internal virtual void invokeOnItemScrollListener()
		{
			if (mFastScroller != null)
			{
				mFastScroller.onScroll(this, mFirstPosition, getChildCount(), mItemCount);
			}
			if (mOnScrollListener != null)
			{
				mOnScrollListener.onScroll(this, mFirstPosition, getChildCount(), mItemCount);
			}
			onScrollChanged(0, 0, 0, 0);
		}

		// dummy values, View's implementation does not use these.
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void sendAccessibilityEvent(int eventType)
		{
			// Since this class calls onScrollChanged even if the mFirstPosition and the
			// child count have not changed we will avoid sending duplicate accessibility
			// events.
			if (eventType == android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SCROLLED)
			{
				int firstVisiblePosition = getFirstVisiblePosition();
				int lastVisiblePosition = getLastVisiblePosition();
				if (mLastAccessibilityScrollEventFromIndex == firstVisiblePosition && mLastAccessibilityScrollEventToIndex
					 == lastVisiblePosition)
				{
					return;
				}
				else
				{
					mLastAccessibilityScrollEventFromIndex = firstVisiblePosition;
					mLastAccessibilityScrollEventToIndex = lastVisiblePosition;
				}
			}
			base.sendAccessibilityEvent(eventType);
		}

		/// <summary>Indicates whether the children's drawing cache is used during a scroll.</summary>
		/// <remarks>
		/// Indicates whether the children's drawing cache is used during a scroll.
		/// By default, the drawing cache is enabled but this will consume more memory.
		/// </remarks>
		/// <returns>true if the scrolling cache is enabled, false otherwise</returns>
		/// <seealso cref="setScrollingCacheEnabled(bool)">setScrollingCacheEnabled(bool)</seealso>
		/// <seealso cref="android.view.View.setDrawingCacheEnabled(bool)">android.view.View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isScrollingCacheEnabled()
		{
			return mScrollingCacheEnabled;
		}

		/// <summary>Enables or disables the children's drawing cache during a scroll.</summary>
		/// <remarks>
		/// Enables or disables the children's drawing cache during a scroll.
		/// By default, the drawing cache is enabled but this will use more memory.
		/// When the scrolling cache is enabled, the caches are kept after the
		/// first scrolling. You can manually clear the cache by calling
		/// <see cref="android.view.ViewGroup.setChildrenDrawingCacheEnabled(bool)">android.view.ViewGroup.setChildrenDrawingCacheEnabled(bool)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="enabled">true to enable the scroll cache, false otherwise</param>
		/// <seealso cref="isScrollingCacheEnabled()">isScrollingCacheEnabled()</seealso>
		/// <seealso cref="android.view.View.setDrawingCacheEnabled(bool)">android.view.View.setDrawingCacheEnabled(bool)
		/// 	</seealso>
		public virtual void setScrollingCacheEnabled(bool enabled)
		{
			if (mScrollingCacheEnabled && !enabled)
			{
				clearScrollingCache();
			}
			mScrollingCacheEnabled = enabled;
		}

		/// <summary>Enables or disables the type filter window.</summary>
		/// <remarks>
		/// Enables or disables the type filter window. If enabled, typing when
		/// this view has focus will filter the children to match the users input.
		/// Note that the
		/// <see cref="Adapter">Adapter</see>
		/// used by this view must implement the
		/// <see cref="Filterable">Filterable</see>
		/// interface.
		/// </remarks>
		/// <param name="textFilterEnabled">true to enable type filtering, false otherwise</param>
		/// <seealso cref="Filterable">Filterable</seealso>
		public virtual void setTextFilterEnabled(bool textFilterEnabled)
		{
			mTextFilterEnabled = textFilterEnabled;
		}

		/// <summary>Indicates whether type filtering is enabled for this view</summary>
		/// <returns>true if type filtering is enabled, false otherwise</returns>
		/// <seealso cref="setTextFilterEnabled(bool)">setTextFilterEnabled(bool)</seealso>
		/// <seealso cref="Filterable">Filterable</seealso>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isTextFilterEnabled()
		{
			return mTextFilterEnabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void getFocusedRect(android.graphics.Rect r)
		{
			android.view.View view = getSelectedView();
			if (view != null && view.getParent() == this)
			{
				// the focused rectangle of the selected view offset into the
				// coordinate space of this view.
				view.getFocusedRect(r);
				offsetDescendantRectToMyCoords(view, r);
			}
			else
			{
				// otherwise, just the norm
				base.getFocusedRect(r);
			}
		}

		private void useDefaultSelector()
		{
			setSelector(getResources().getDrawable(android.@internal.R.drawable.list_selector_background
				));
		}

		/// <summary>
		/// Indicates whether the content of this view is pinned to, or stacked from,
		/// the bottom edge.
		/// </summary>
		/// <remarks>
		/// Indicates whether the content of this view is pinned to, or stacked from,
		/// the bottom edge.
		/// </remarks>
		/// <returns>true if the content is stacked from the bottom edge, false otherwise</returns>
		[android.view.ViewDebug.ExportedProperty]
		public virtual bool isStackFromBottom()
		{
			return mStackFromBottom;
		}

		/// <summary>
		/// When stack from bottom is set to true, the list fills its content starting from
		/// the bottom of the view.
		/// </summary>
		/// <remarks>
		/// When stack from bottom is set to true, the list fills its content starting from
		/// the bottom of the view.
		/// </remarks>
		/// <param name="stackFromBottom">
		/// true to pin the view's content to the bottom edge,
		/// false to pin the view's content to the top edge
		/// </param>
		public virtual void setStackFromBottom(bool stackFromBottom)
		{
			if (mStackFromBottom != stackFromBottom)
			{
				mStackFromBottom = stackFromBottom;
				requestLayoutIfNecessary();
			}
		}

		internal virtual void requestLayoutIfNecessary()
		{
			if (getChildCount() > 0)
			{
				resetList();
				requestLayout();
				invalidate();
			}
		}

		internal class SavedState : android.view.View.BaseSavedState
		{
			internal long selectedId;

			internal long firstId;

			internal int viewTop;

			internal int position;

			internal int height;

			internal string filter;

			internal bool inActionMode;

			internal int checkedItemCount;

			internal android.util.SparseBooleanArray checkState;

			internal android.util.LongSparseArray<int> checkIdState;

			/// <summary>
			/// Constructor called from
			/// <see cref="AbsListView.onSaveInstanceState()">AbsListView.onSaveInstanceState()</see>
			/// </summary>
			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			/// <summary>
			/// Constructor called from
			/// <see cref="CREATOR">CREATOR</see>
			/// </summary>
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				selectedId = @in.readLong();
				firstId = @in.readLong();
				viewTop = @in.readInt();
				position = @in.readInt();
				height = @in.readInt();
				filter = @in.readString();
				inActionMode = @in.readByte() != 0;
				checkedItemCount = @in.readInt();
				checkState = @in.readSparseBooleanArray();
				int N = @in.readInt();
				if (N > 0)
				{
					checkIdState = new android.util.LongSparseArray<int>();
					{
						for (int i = 0; i < N; i++)
						{
							long key = @in.readLong();
							int value = @in.readInt();
							checkIdState.put(key, value);
						}
					}
				}
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeLong(selectedId);
				@out.writeLong(firstId);
				@out.writeInt(viewTop);
				@out.writeInt(position);
				@out.writeInt(height);
				@out.writeString(filter);
				@out.writeByte(unchecked((byte)(inActionMode ? 1 : 0)));
				@out.writeInt(checkedItemCount);
				@out.writeSparseBooleanArray(checkState);
				int N = checkIdState != null ? checkIdState.size() : 0;
				@out.writeInt(N);
				{
					for (int i = 0; i < N; i++)
					{
						@out.writeLong(checkIdState.keyAt(i));
						@out.writeInt(checkIdState.valueAt(i));
					}
				}
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "AbsListView.SavedState{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " selectedId=" + selectedId + " firstId=" + firstId + " viewTop=" + viewTop
					 + " position=" + position + " height=" + height + " filter=" + filter + " checkState="
					 + checkState + "}";
			}

			private sealed class _Creator_1491 : android.os.ParcelableClass.Creator<android.widget.AbsListView
				.SavedState>
			{
				public _Creator_1491()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AbsListView.SavedState createFromParcel(android.os.Parcel @in
					)
				{
					return new android.widget.AbsListView.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AbsListView.SavedState[] newArray(int size)
				{
					return new android.widget.AbsListView.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.AbsListView
				.SavedState> CREATOR = new _Creator_1491();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			dismissPopup();
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.widget.AbsListView.SavedState ss = new android.widget.AbsListView.SavedState
				(superState);
			bool haveChildren = getChildCount() > 0 && mItemCount > 0;
			long selectedId = getSelectedItemId();
			ss.selectedId = selectedId;
			ss.height = getHeight();
			if (selectedId >= 0)
			{
				// Remember the selection
				ss.viewTop = mSelectedTop;
				ss.position = getSelectedItemPosition();
				ss.firstId = android.widget.AdapterView.INVALID_POSITION;
			}
			else
			{
				if (haveChildren && mFirstPosition > 0)
				{
					// Remember the position of the first child.
					// We only do this if we are not currently at the top of
					// the list, for two reasons:
					// (1) The list may be in the process of becoming empty, in
					// which case mItemCount may not be 0, but if we try to
					// ask for any information about position 0 we will crash.
					// (2) Being "at the top" seems like a special case, anyway,
					// and the user wouldn't expect to end up somewhere else when
					// they revisit the list even if its content has changed.
					android.view.View v = getChildAt(0);
					ss.viewTop = v.getTop();
					int firstPos = mFirstPosition;
					if (firstPos >= mItemCount)
					{
						firstPos = mItemCount - 1;
					}
					ss.position = firstPos;
					ss.firstId = mAdapter.getItemId(firstPos);
				}
				else
				{
					ss.viewTop = 0;
					ss.firstId = android.widget.AdapterView.INVALID_POSITION;
					ss.position = 0;
				}
			}
			ss.filter = null;
			if (mFiltered)
			{
				android.widget.EditText textFilter = mTextFilter;
				if (textFilter != null)
				{
					android.text.Editable filterText = ((android.text.Editable)textFilter.getText());
					if (filterText != null)
					{
						ss.filter = filterText.ToString();
					}
				}
			}
			ss.inActionMode = mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL && mChoiceActionMode 
				!= null;
			if (mCheckStates != null)
			{
				ss.checkState = mCheckStates.clone();
			}
			if (mCheckedIdStates != null)
			{
				android.util.LongSparseArray<int> idState = new android.util.LongSparseArray<int>
					();
				int count = mCheckedIdStates.size();
				{
					for (int i = 0; i < count; i++)
					{
						idState.put(mCheckedIdStates.keyAt(i), mCheckedIdStates.valueAt(i));
					}
				}
				ss.checkIdState = idState;
			}
			ss.checkedItemCount = mCheckedItemCount;
			return ss;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.widget.AbsListView.SavedState ss = (android.widget.AbsListView.SavedState
				)state;
			base.onRestoreInstanceState(ss.getSuperState());
			mDataChanged = true;
			mSyncHeight = ss.height;
			if (ss.selectedId >= 0)
			{
				mNeedSync = true;
				mSyncRowId = ss.selectedId;
				mSyncPosition = ss.position;
				mSpecificTop = ss.viewTop;
				mSyncMode = android.widget.AdapterView.SYNC_SELECTED_POSITION;
			}
			else
			{
				if (ss.firstId >= 0)
				{
					setSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
					// Do this before setting mNeedSync since setNextSelectedPosition looks at mNeedSync
					setNextSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
					mSelectorPosition = android.widget.AdapterView.INVALID_POSITION;
					mNeedSync = true;
					mSyncRowId = ss.firstId;
					mSyncPosition = ss.position;
					mSpecificTop = ss.viewTop;
					mSyncMode = android.widget.AdapterView.SYNC_FIRST_POSITION;
				}
			}
			setFilterText(ss.filter);
			if (ss.checkState != null)
			{
				mCheckStates = ss.checkState;
			}
			if (ss.checkIdState != null)
			{
				mCheckedIdStates = ss.checkIdState;
			}
			mCheckedItemCount = ss.checkedItemCount;
			if (ss.inActionMode && mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL && mMultiChoiceModeCallback
				 != null)
			{
				mChoiceActionMode = startActionMode(mMultiChoiceModeCallback);
			}
			requestLayout();
		}

		private bool acceptFilter()
		{
			return mTextFilterEnabled && getAdapter() is android.widget.Filterable && ((android.widget.Filterable
				)getAdapter()).getFilter() != null;
		}

		/// <summary>Sets the initial value for the text filter.</summary>
		/// <remarks>Sets the initial value for the text filter.</remarks>
		/// <param name="filterText">The text to use for the filter.</param>
		/// <seealso cref="setTextFilterEnabled(bool)">setTextFilterEnabled(bool)</seealso>
		public virtual void setFilterText(string filterText)
		{
			// TODO: Should we check for acceptFilter()?
			if (mTextFilterEnabled && !android.text.TextUtils.isEmpty(java.lang.CharSequenceProxy.Wrap
				(filterText)))
			{
				createTextFilter(false);
				// This is going to call our listener onTextChanged, but we might not
				// be ready to bring up a window yet
				mTextFilter.setText(java.lang.CharSequenceProxy.Wrap(filterText));
				mTextFilter.setSelection(filterText.Length);
				if (mAdapter is android.widget.Filterable)
				{
					// if mPopup is non-null, then onTextChanged will do the filtering
					if (mPopup == null)
					{
						android.widget.Filter f = ((android.widget.Filterable)mAdapter).getFilter();
						f.filter(java.lang.CharSequenceProxy.Wrap(filterText));
					}
					// Set filtered to true so we will display the filter window when our main
					// window is ready
					mFiltered = true;
					mDataSetObserver.clearSavedState();
				}
			}
		}

		/// <summary>Returns the list's text filter, if available.</summary>
		/// <remarks>Returns the list's text filter, if available.</remarks>
		/// <returns>the list's text filter or null if filtering isn't enabled</returns>
		public virtual java.lang.CharSequence getTextFilter()
		{
			if (mTextFilterEnabled && mTextFilter != null)
			{
				return ((android.text.Editable)mTextFilter.getText());
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool gainFocus, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(gainFocus, direction, previouslyFocusedRect);
			if (gainFocus && mSelectedPosition < 0 && !isInTouchMode())
			{
				if (!mIsAttached && mAdapter != null)
				{
					// Data may have changed while we were detached and it's valid
					// to change focus while detached. Refresh so we don't die.
					mDataChanged = true;
					mOldItemCount = mItemCount;
					mItemCount = mAdapter.getCount();
				}
				resurrectSelection();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			if (!mBlockLayoutRequests && !mInLayout)
			{
				base.requestLayout();
			}
		}

		/// <summary>The list is empty.</summary>
		/// <remarks>The list is empty. Clear everything out.</remarks>
		internal virtual void resetList()
		{
			removeAllViewsInLayout();
			mFirstPosition = 0;
			mDataChanged = false;
			mNeedSync = false;
			mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			setSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
			setNextSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
			mSelectedTop = 0;
			mSelectorPosition = android.widget.AdapterView.INVALID_POSITION;
			mSelectorRect.setEmpty();
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollExtent()
		{
			int count = getChildCount();
			if (count > 0)
			{
				if (mSmoothScrollbarEnabled)
				{
					int extent = count * 100;
					android.view.View view = getChildAt(0);
					int top = view.getTop();
					int height = view.getHeight();
					if (height > 0)
					{
						extent += (top * 100) / height;
					}
					view = getChildAt(count - 1);
					int bottom = view.getBottom();
					height = view.getHeight();
					if (height > 0)
					{
						extent -= ((bottom - getHeight()) * 100) / height;
					}
					return extent;
				}
				else
				{
					return 1;
				}
			}
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollOffset()
		{
			int firstPosition = mFirstPosition;
			int childCount = getChildCount();
			if (firstPosition >= 0 && childCount > 0)
			{
				if (mSmoothScrollbarEnabled)
				{
					android.view.View view = getChildAt(0);
					int top = view.getTop();
					int height = view.getHeight();
					if (height > 0)
					{
						return System.Math.Max(firstPosition * 100 - (top * 100) / height + (int)((float)
							mScrollY / getHeight() * mItemCount * 100), 0);
					}
				}
				else
				{
					int index;
					int count = mItemCount;
					if (firstPosition == 0)
					{
						index = 0;
					}
					else
					{
						if (firstPosition + childCount == count)
						{
							index = count;
						}
						else
						{
							index = firstPosition + childCount / 2;
						}
					}
					return (int)(firstPosition + childCount * (index / (float)count));
				}
			}
			return 0;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int computeVerticalScrollRange()
		{
			int result;
			if (mSmoothScrollbarEnabled)
			{
				result = System.Math.Max(mItemCount * 100, 0);
				if (mScrollY != 0)
				{
					// Compensate for overscroll
					result += System.Math.Abs((int)((float)mScrollY / getHeight() * mItemCount * 100)
						);
				}
			}
			else
			{
				result = mItemCount;
			}
			return result;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getTopFadingEdgeStrength()
		{
			int count = getChildCount();
			float fadeEdge = base.getTopFadingEdgeStrength();
			if (count == 0)
			{
				return fadeEdge;
			}
			else
			{
				if (mFirstPosition > 0)
				{
					return 1.0f;
				}
				int top = getChildAt(0).getTop();
				float fadeLength = (float)getVerticalFadingEdgeLength();
				return top < mPaddingTop ? (float)-(top - mPaddingTop) / fadeLength : fadeEdge;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getBottomFadingEdgeStrength()
		{
			int count = getChildCount();
			float fadeEdge = base.getBottomFadingEdgeStrength();
			if (count == 0)
			{
				return fadeEdge;
			}
			else
			{
				if (mFirstPosition + count - 1 < mItemCount - 1)
				{
					return 1.0f;
				}
				int bottom = getChildAt(count - 1).getBottom();
				int height = getHeight();
				float fadeLength = (float)getVerticalFadingEdgeLength();
				return bottom > height - mPaddingBottom ? (float)(bottom - height + mPaddingBottom
					) / fadeLength : fadeEdge;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			if (mSelector == null)
			{
				useDefaultSelector();
			}
			android.graphics.Rect listPadding = mListPadding;
			listPadding.left = mSelectionLeftPadding + mPaddingLeft;
			listPadding.top = mSelectionTopPadding + mPaddingTop;
			listPadding.right = mSelectionRightPadding + mPaddingRight;
			listPadding.bottom = mSelectionBottomPadding + mPaddingBottom;
			// Check if our previous measured size was at a point where we should scroll later.
			if (mTranscriptMode == TRANSCRIPT_MODE_NORMAL)
			{
				int childCount = getChildCount();
				int listBottom = getHeight() - getPaddingBottom();
				android.view.View lastChild = getChildAt(childCount - 1);
				int lastBottom = lastChild != null ? lastChild.getBottom() : listBottom;
				mForceTranscriptScroll = mFirstPosition + childCount >= mLastHandledItemCount && 
					lastBottom <= listBottom;
			}
		}

		/// <summary>
		/// Subclasses should NOT override this method but
		/// <see cref="layoutChildren()">layoutChildren()</see>
		/// instead.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			base.onLayout(changed, l, t, r, b);
			mInLayout = true;
			if (changed)
			{
				int childCount = getChildCount();
				{
					for (int i = 0; i < childCount; i++)
					{
						getChildAt(i).forceLayout();
					}
				}
				mRecycler.markChildrenDirty();
			}
			if (mFastScroller != null && mItemCount != mOldItemCount)
			{
				mFastScroller.onItemCountChanged(mOldItemCount, mItemCount);
			}
			layoutChildren();
			mInLayout = false;
			mOverscrollMax = (b - t) / OVERSCROLL_LIMIT_DIVISOR;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool setFrame(int left, int top, int right, int bottom
			)
		{
			bool changed = base.setFrame(left, top, right, bottom);
			if (changed)
			{
				// Reposition the popup when the frame has changed. This includes
				// translating the widget, not just changing its dimension. The
				// filter popup needs to follow the widget.
				bool visible = getWindowVisibility() == android.view.View.VISIBLE;
				if (mFiltered && visible && mPopup != null && mPopup.isShowing())
				{
					positionPopup();
				}
			}
			return changed;
		}

		/// <summary>Subclasses must override this method to layout their children.</summary>
		/// <remarks>Subclasses must override this method to layout their children.</remarks>
		protected internal virtual void layoutChildren()
		{
		}

		internal virtual void updateScrollIndicators()
		{
			if (mScrollUp != null)
			{
				bool canScrollUp;
				// 0th element is not visible
				canScrollUp = mFirstPosition > 0;
				// ... Or top of 0th element is not visible
				if (!canScrollUp)
				{
					if (getChildCount() > 0)
					{
						android.view.View child = getChildAt(0);
						canScrollUp = child.getTop() < mListPadding.top;
					}
				}
				mScrollUp.setVisibility(canScrollUp ? android.view.View.VISIBLE : android.view.View
					.INVISIBLE);
			}
			if (mScrollDown != null)
			{
				bool canScrollDown;
				int count = getChildCount();
				// Last item is not visible
				canScrollDown = (mFirstPosition + count) < mItemCount;
				// ... Or bottom of the last element is not visible
				if (!canScrollDown && count > 0)
				{
					android.view.View child = getChildAt(count - 1);
					canScrollDown = child.getBottom() > mBottom - mListPadding.bottom;
				}
				mScrollDown.setVisibility(canScrollDown ? android.view.View.VISIBLE : android.view.View
					.INVISIBLE);
			}
		}

		[android.view.ViewDebug.ExportedProperty]
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.view.View getSelectedView()
		{
			if (mItemCount > 0 && mSelectedPosition >= 0)
			{
				return getChildAt(mSelectedPosition - mFirstPosition);
			}
			else
			{
				return null;
			}
		}

		/// <summary>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</summary>
		/// <remarks>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</remarks>
		/// <seealso cref="android.view.View.getPaddingTop()">android.view.View.getPaddingTop()
		/// 	</seealso>
		/// <seealso cref="getSelector()">getSelector()</seealso>
		/// <returns>The top list padding.</returns>
		public virtual int getListPaddingTop()
		{
			return mListPadding.top;
		}

		/// <summary>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</summary>
		/// <remarks>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</remarks>
		/// <seealso cref="android.view.View.getPaddingBottom()">android.view.View.getPaddingBottom()
		/// 	</seealso>
		/// <seealso cref="getSelector()">getSelector()</seealso>
		/// <returns>The bottom list padding.</returns>
		public virtual int getListPaddingBottom()
		{
			return mListPadding.bottom;
		}

		/// <summary>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</summary>
		/// <remarks>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</remarks>
		/// <seealso cref="android.view.View.getPaddingLeft()">android.view.View.getPaddingLeft()
		/// 	</seealso>
		/// <seealso cref="getSelector()">getSelector()</seealso>
		/// <returns>The left list padding.</returns>
		public virtual int getListPaddingLeft()
		{
			return mListPadding.left;
		}

		/// <summary>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</summary>
		/// <remarks>List padding is the maximum of the normal view's padding and the padding of the selector.
		/// 	</remarks>
		/// <seealso cref="android.view.View.getPaddingRight()">android.view.View.getPaddingRight()
		/// 	</seealso>
		/// <seealso cref="getSelector()">getSelector()</seealso>
		/// <returns>The right list padding.</returns>
		public virtual int getListPaddingRight()
		{
			return mListPadding.right;
		}

		/// <summary>
		/// Get a view and have it show the data associated with the specified
		/// position.
		/// </summary>
		/// <remarks>
		/// Get a view and have it show the data associated with the specified
		/// position. This is called when we have already discovered that the view is
		/// not available for reuse in the recycle bin. The only choices left are
		/// converting an old view or making a new one.
		/// </remarks>
		/// <param name="position">The position to display</param>
		/// <param name="isScrap">
		/// Array of at least 1 boolean, the first entry will become true if
		/// the returned view was taken from the scrap heap, false if otherwise.
		/// </param>
		/// <returns>A view displaying the data associated with the specified position</returns>
		internal virtual android.view.View obtainView(int position, bool[] isScrap)
		{
			isScrap[0] = false;
			android.view.View scrapView;
			scrapView = mRecycler.getScrapView(position);
			android.view.View child;
			if (scrapView != null)
			{
				child = mAdapter.getView(position, scrapView, this);
				if (child != scrapView)
				{
					mRecycler.addScrapView(scrapView, position);
					if (mCacheColorHint != 0)
					{
						child.setDrawingCacheBackgroundColor(mCacheColorHint);
					}
				}
				else
				{
					isScrap[0] = true;
					child.dispatchFinishTemporaryDetach();
				}
			}
			else
			{
				child = mAdapter.getView(position, null, this);
				if (mCacheColorHint != 0)
				{
					child.setDrawingCacheBackgroundColor(mCacheColorHint);
				}
			}
			return child;
		}

		internal virtual void positionSelector(int position, android.view.View sel)
		{
			if (position != android.widget.AdapterView.INVALID_POSITION)
			{
				mSelectorPosition = position;
			}
			android.graphics.Rect selectorRect = mSelectorRect;
			selectorRect.set(sel.getLeft(), sel.getTop(), sel.getRight(), sel.getBottom());
			if (sel is android.widget.AbsListView.SelectionBoundsAdjuster)
			{
				((android.widget.AbsListView.SelectionBoundsAdjuster)sel).adjustListItemSelectionBounds
					(selectorRect);
			}
			positionSelector(selectorRect.left, selectorRect.top, selectorRect.right, selectorRect
				.bottom);
			bool isChildViewEnabled = mIsChildViewEnabled;
			if (sel.isEnabled() != isChildViewEnabled)
			{
				mIsChildViewEnabled = !isChildViewEnabled;
				if (getSelectedItemPosition() != android.widget.AdapterView.INVALID_POSITION)
				{
					refreshDrawableState();
				}
			}
		}

		private void positionSelector(int l, int t, int r, int b)
		{
			mSelectorRect.set(l - mSelectionLeftPadding, t - mSelectionTopPadding, r + mSelectionRightPadding
				, b + mSelectionBottomPadding);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
			int saveCount = 0;
			bool clipToPadding = (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK;
			if (clipToPadding)
			{
				saveCount = canvas.save();
				int scrollX = mScrollX;
				int scrollY = mScrollY;
				canvas.clipRect(scrollX + mPaddingLeft, scrollY + mPaddingTop, scrollX + mRight -
					 mLeft - mPaddingRight, scrollY + mBottom - mTop - mPaddingBottom);
				mGroupFlags &= ~CLIP_TO_PADDING_MASK;
			}
			bool drawSelectorOnTop = mDrawSelectorOnTop;
			if (!drawSelectorOnTop)
			{
				drawSelector(canvas);
			}
			base.dispatchDraw(canvas);
			if (drawSelectorOnTop)
			{
				drawSelector(canvas);
			}
			if (clipToPadding)
			{
				canvas.restoreToCount(saveCount);
				mGroupFlags |= CLIP_TO_PADDING_MASK;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool isPaddingOffsetRequired()
		{
			return (mGroupFlags & CLIP_TO_PADDING_MASK) != CLIP_TO_PADDING_MASK;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getLeftPaddingOffset()
		{
			return (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK ? 0 : -mPaddingLeft;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getTopPaddingOffset()
		{
			return (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK ? 0 : -mPaddingTop;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getRightPaddingOffset()
		{
			return (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK ? 0 : mPaddingRight;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getBottomPaddingOffset()
		{
			return (mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK ? 0 : mPaddingBottom;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			if (getChildCount() > 0)
			{
				mDataChanged = true;
				rememberSyncState();
			}
			if (mFastScroller != null)
			{
				mFastScroller.onSizeChanged(w, h, oldw, oldh);
			}
		}

		/// <returns>
		/// True if the current touch mode requires that we draw the selector in the pressed
		/// state.
		/// </returns>
		internal virtual bool touchModeDrawsInPressedState()
		{
			switch (mTouchMode)
			{
				case TOUCH_MODE_TAP:
				case TOUCH_MODE_DONE_WAITING:
				{
					// FIXME use isPressed for this
					return true;
				}

				default:
				{
					return false;
				}
			}
		}

		/// <summary>Indicates whether this view is in a state where the selector should be drawn.
		/// 	</summary>
		/// <remarks>
		/// Indicates whether this view is in a state where the selector should be drawn. This will
		/// happen if we have focus but are not in touch mode, or we are in the middle of displaying
		/// the pressed state for an item.
		/// </remarks>
		/// <returns>True if the selector should be shown</returns>
		internal virtual bool shouldShowSelector()
		{
			return (hasFocus() && !isInTouchMode()) || touchModeDrawsInPressedState();
		}

		private void drawSelector(android.graphics.Canvas canvas)
		{
			if (!mSelectorRect.isEmpty())
			{
				android.graphics.drawable.Drawable selector = mSelector;
				selector.setBounds(mSelectorRect);
				selector.draw(canvas);
			}
		}

		/// <summary>
		/// Controls whether the selection highlight drawable should be drawn on top of the item or
		/// behind it.
		/// </summary>
		/// <remarks>
		/// Controls whether the selection highlight drawable should be drawn on top of the item or
		/// behind it.
		/// </remarks>
		/// <param name="onTop">
		/// If true, the selector will be drawn on the item it is highlighting. The default
		/// is false.
		/// </param>
		/// <attr>ref android.R.styleable#AbsListView_drawSelectorOnTop</attr>
		public virtual void setDrawSelectorOnTop(bool onTop)
		{
			mDrawSelectorOnTop = onTop;
		}

		/// <summary>Set a Drawable that should be used to highlight the currently selected item.
		/// 	</summary>
		/// <remarks>Set a Drawable that should be used to highlight the currently selected item.
		/// 	</remarks>
		/// <param name="resID">A Drawable resource to use as the selection highlight.</param>
		/// <attr>ref android.R.styleable#AbsListView_listSelector</attr>
		public virtual void setSelector(int resID)
		{
			setSelector(getResources().getDrawable(resID));
		}

		public virtual void setSelector(android.graphics.drawable.Drawable sel)
		{
			if (mSelector != null)
			{
				mSelector.setCallback(null);
				unscheduleDrawable(mSelector);
			}
			mSelector = sel;
			android.graphics.Rect padding = new android.graphics.Rect();
			sel.getPadding(padding);
			mSelectionLeftPadding = padding.left;
			mSelectionTopPadding = padding.top;
			mSelectionRightPadding = padding.right;
			mSelectionBottomPadding = padding.bottom;
			sel.setCallback(this);
			updateSelectorState();
		}

		/// <summary>
		/// Returns the selector
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// that is used to draw the
		/// selection in the list.
		/// </summary>
		/// <returns>the drawable used to display the selector</returns>
		public virtual android.graphics.drawable.Drawable getSelector()
		{
			return mSelector;
		}

		/// <summary>
		/// Sets the selector state to "pressed" and posts a CheckForKeyLongPress to see if
		/// this is a long press.
		/// </summary>
		/// <remarks>
		/// Sets the selector state to "pressed" and posts a CheckForKeyLongPress to see if
		/// this is a long press.
		/// </remarks>
		internal virtual void keyPressed()
		{
			if (!isEnabled() || !isClickable())
			{
				return;
			}
			android.graphics.drawable.Drawable selector = mSelector;
			android.graphics.Rect selectorRect = mSelectorRect;
			if (selector != null && (isFocused() || touchModeDrawsInPressedState()) && !selectorRect
				.isEmpty())
			{
				android.view.View v = getChildAt(mSelectedPosition - mFirstPosition);
				if (v != null)
				{
					if (v.hasFocusable())
					{
						return;
					}
					v.setPressed(true);
				}
				setPressed(true);
				bool longClickable = isLongClickable();
				android.graphics.drawable.Drawable d = selector.getCurrent();
				if (d != null && d is android.graphics.drawable.TransitionDrawable)
				{
					if (longClickable)
					{
						((android.graphics.drawable.TransitionDrawable)d).startTransition(android.view.ViewConfiguration
							.getLongPressTimeout());
					}
					else
					{
						((android.graphics.drawable.TransitionDrawable)d).resetTransition();
					}
				}
				if (longClickable && !mDataChanged)
				{
					if (mPendingCheckForKeyLongPress == null)
					{
						mPendingCheckForKeyLongPress = new android.widget.AbsListView.CheckForKeyLongPress
							(this);
					}
					mPendingCheckForKeyLongPress.rememberWindowAttachCount();
					postDelayed(mPendingCheckForKeyLongPress, android.view.ViewConfiguration.getLongPressTimeout
						());
				}
			}
		}

		public virtual void setScrollIndicators(android.view.View up, android.view.View down
			)
		{
			mScrollUp = up;
			mScrollDown = down;
		}

		internal virtual void updateSelectorState()
		{
			if (mSelector != null)
			{
				if (shouldShowSelector())
				{
					mSelector.setState(getDrawableState());
				}
				else
				{
					mSelector.setState(android.util.StateSet.NOTHING);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			updateSelectorState();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int[] onCreateDrawableState(int extraSpace)
		{
			// If the child view is enabled then do the default behavior.
			if (mIsChildViewEnabled)
			{
				// Common case
				return base.onCreateDrawableState(extraSpace);
			}
			// The selector uses this View's drawable state. The selected child view
			// is disabled, so we need to remove the enabled state from the drawable
			// states.
			int enabledState = ENABLED_STATE_SET[0];
			// If we don't have any extra space, it will return one of the static state arrays,
			// and clearing the enabled state on those arrays is a bad thing!  If we specify
			// we need extra space, it will create+copy into a new array that safely mutable.
			int[] state = base.onCreateDrawableState(extraSpace + 1);
			int enabledPos = -1;
			{
				for (int i = state.Length - 1; i >= 0; i--)
				{
					if (state[i] == enabledState)
					{
						enabledPos = i;
						break;
					}
				}
			}
			// Remove the enabled state
			if (enabledPos >= 0)
			{
				System.Array.Copy(state, enabledPos + 1, state, enabledPos, state.Length - enabledPos
					 - 1);
			}
			return state;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 dr)
		{
			return mSelector == dr || base.verifyDrawable(dr);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mSelector != null)
			{
				mSelector.jumpToCurrentState();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			android.view.ViewTreeObserver treeObserver = getViewTreeObserver();
			treeObserver.addOnTouchModeChangeListener(this);
			if (mTextFilterEnabled && mPopup != null && !mGlobalLayoutListenerAddedFilter)
			{
				treeObserver.addOnGlobalLayoutListener(this);
			}
			if (mAdapter != null && mDataSetObserver == null)
			{
				mDataSetObserver = new android.widget.AbsListView.AdapterDataSetObserver(this);
				mAdapter.registerDataSetObserver(mDataSetObserver);
				// Data may have changed while we were detached. Refresh.
				mDataChanged = true;
				mOldItemCount = mItemCount;
				mItemCount = mAdapter.getCount();
			}
			mIsAttached = true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			// Dismiss the popup in case onSaveInstanceState() was not invoked
			dismissPopup();
			// Detach any view left in the scrap heap
			mRecycler.clear();
			android.view.ViewTreeObserver treeObserver = getViewTreeObserver();
			treeObserver.removeOnTouchModeChangeListener(this);
			if (mTextFilterEnabled && mPopup != null)
			{
				treeObserver.removeGlobalOnLayoutListener(this);
				mGlobalLayoutListenerAddedFilter = false;
			}
			if (mAdapter != null)
			{
				mAdapter.unregisterDataSetObserver(mDataSetObserver);
				mDataSetObserver = null;
			}
			if (mScrollStrictSpan != null)
			{
				mScrollStrictSpan.finish();
				mScrollStrictSpan = null;
			}
			if (mFlingStrictSpan != null)
			{
				mFlingStrictSpan.finish();
				mFlingStrictSpan = null;
			}
			if (mFlingRunnable != null)
			{
				removeCallbacks(mFlingRunnable);
			}
			if (mPositionScroller != null)
			{
				mPositionScroller.stop();
			}
			if (mClearScrollingCache != null)
			{
				removeCallbacks(mClearScrollingCache);
			}
			if (mPerformClick != null)
			{
				removeCallbacks(mPerformClick);
			}
			if (mTouchModeReset != null)
			{
				removeCallbacks(mTouchModeReset);
				mTouchModeReset = null;
			}
			mIsAttached = false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onWindowFocusChanged(bool hasWindowFocus_1)
		{
			base.onWindowFocusChanged(hasWindowFocus_1);
			int touchMode = isInTouchMode() ? TOUCH_MODE_ON : TOUCH_MODE_OFF;
			if (!hasWindowFocus_1)
			{
				setChildrenDrawingCacheEnabled(false);
				if (mFlingRunnable != null)
				{
					removeCallbacks(mFlingRunnable);
					// let the fling runnable report it's new state which
					// should be idle
					mFlingRunnable.endFling();
					if (mPositionScroller != null)
					{
						mPositionScroller.stop();
					}
					if (mScrollY != 0)
					{
						mScrollY = 0;
						invalidateParentCaches();
						finishGlows();
						invalidate();
					}
				}
				// Always hide the type filter
				dismissPopup();
				if (touchMode == TOUCH_MODE_OFF)
				{
					// Remember the last selected element
					mResurrectToPosition = mSelectedPosition;
				}
			}
			else
			{
				if (mFiltered && !mPopupHidden)
				{
					// Show the type filter only if a filter is in effect
					showPopup();
				}
				// If we changed touch mode since the last time we had focus
				if (touchMode != mLastTouchMode && mLastTouchMode != TOUCH_MODE_UNKNOWN)
				{
					// If we come back in trackball mode, we bring the selection back
					if (touchMode == TOUCH_MODE_OFF)
					{
						// This will trigger a layout
						resurrectSelection();
					}
					else
					{
						// If we come back in touch mode, then we want to hide the selector
						hideSelector();
						mLayoutMode = LAYOUT_NORMAL;
						layoutChildren();
					}
				}
			}
			mLastTouchMode = touchMode;
		}

		/// <summary>
		/// Creates the ContextMenuInfo returned from
		/// <see cref="getContextMenuInfo()">getContextMenuInfo()</see>
		/// . This
		/// methods knows the view, position and ID of the item that received the
		/// long press.
		/// </summary>
		/// <param name="view">The view that received the long press.</param>
		/// <param name="position">The position of the item that received the long press.</param>
		/// <param name="id">The ID of the item that received the long press.</param>
		/// <returns>
		/// The extra information that should be returned by
		/// <see cref="getContextMenuInfo()">getContextMenuInfo()</see>
		/// .
		/// </returns>
		internal virtual android.view.ContextMenuClass.ContextMenuInfo createContextMenuInfo
			(android.view.View view, int position, long id)
		{
			return new android.widget.AdapterView.AdapterContextMenuInfo(view, position, id);
		}

		/// <summary>
		/// A base class for Runnables that will check that their view is still attached to
		/// the original window as when the Runnable was created.
		/// </summary>
		/// <remarks>
		/// A base class for Runnables that will check that their view is still attached to
		/// the original window as when the Runnable was created.
		/// </remarks>
		private class WindowRunnnable
		{
			internal int mOriginalAttachCount;

			public virtual void rememberWindowAttachCount()
			{
				this.mOriginalAttachCount = this._enclosing.getWindowAttachCount();
			}

			public virtual bool sameWindow()
			{
				return this._enclosing.hasWindowFocus() && this._enclosing.getWindowAttachCount()
					 == this.mOriginalAttachCount;
			}

			internal WindowRunnnable(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		private class PerformClick : android.widget.AbsListView.WindowRunnnable, java.lang.Runnable
		{
			internal int mClickMotionPosition;

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				// The data has changed since we posted this action in the event queue,
				// bail out before bad things happen
				if (this._enclosing.mDataChanged)
				{
					return;
				}
				android.widget.ListAdapter adapter = this._enclosing.mAdapter;
				int motionPosition = this.mClickMotionPosition;
				if (adapter != null && this._enclosing.mItemCount > 0 && motionPosition != android.widget.AdapterView.INVALID_POSITION
					 && motionPosition < adapter.getCount() && this.sameWindow())
				{
					android.view.View view = this._enclosing.getChildAt(motionPosition - this._enclosing
						.mFirstPosition);
					// If there is no view, something bad happened (the view scrolled off the
					// screen, etc.) and we should cancel the click
					if (view != null)
					{
						this._enclosing.performItemClick(view, motionPosition, adapter.getItemId(motionPosition
							));
					}
				}
			}

			internal PerformClick(AbsListView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		private class CheckForLongPress : android.widget.AbsListView.WindowRunnnable, java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				int motionPosition = this._enclosing.mMotionPosition;
				android.view.View child = this._enclosing.getChildAt(motionPosition - this._enclosing
					.mFirstPosition);
				if (child != null)
				{
					int longPressPosition = this._enclosing.mMotionPosition;
					long longPressId = this._enclosing.mAdapter.getItemId(this._enclosing.mMotionPosition
						);
					bool handled = false;
					if (this.sameWindow() && !this._enclosing.mDataChanged)
					{
						handled = this._enclosing.performLongPress(child, longPressPosition, longPressId);
					}
					if (handled)
					{
						this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_REST;
						this._enclosing.setPressed(false);
						child.setPressed(false);
					}
					else
					{
						this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_DONE_WAITING;
					}
				}
			}

			internal CheckForLongPress(AbsListView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		private class CheckForKeyLongPress : android.widget.AbsListView.WindowRunnnable, 
			java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.isPressed() && this._enclosing.mSelectedPosition >= 0)
				{
					int index = this._enclosing.mSelectedPosition - this._enclosing.mFirstPosition;
					android.view.View v = this._enclosing.getChildAt(index);
					if (!this._enclosing.mDataChanged)
					{
						bool handled = false;
						if (this.sameWindow())
						{
							handled = this._enclosing.performLongPress(v, this._enclosing.mSelectedPosition, 
								this._enclosing.mSelectedRowId);
						}
						if (handled)
						{
							this._enclosing.setPressed(false);
							v.setPressed(false);
						}
					}
					else
					{
						this._enclosing.setPressed(false);
						if (v != null)
						{
							v.setPressed(false);
						}
					}
				}
			}

			internal CheckForKeyLongPress(AbsListView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		internal virtual bool performLongPress(android.view.View child, int longPressPosition
			, long longPressId)
		{
			// CHOICE_MODE_MULTIPLE_MODAL takes over long press.
			if (mChoiceMode == CHOICE_MODE_MULTIPLE_MODAL)
			{
				if (mChoiceActionMode == null && (mChoiceActionMode = startActionMode(mMultiChoiceModeCallback
					)) != null)
				{
					setItemChecked(longPressPosition, true);
					performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
				}
				return true;
			}
			bool handled = false;
			if (mOnItemLongClickListener != null)
			{
				handled = mOnItemLongClickListener.onItemLongClick(this, child, longPressPosition
					, longPressId);
			}
			if (!handled)
			{
				mContextMenuInfo = createContextMenuInfo(child, longPressPosition, longPressId);
				handled = base.showContextMenuForChild(this);
			}
			if (handled)
			{
				performHapticFeedback(android.view.HapticFeedbackConstants.LONG_PRESS);
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.view.ContextMenuClass.ContextMenuInfo getContextMenuInfo
			()
		{
			return mContextMenuInfo;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool showContextMenu(float x, float y, int metaState)
		{
			int position = pointToPosition((int)x, (int)y);
			if (position != android.widget.AdapterView.INVALID_POSITION)
			{
				long id = mAdapter.getItemId(position);
				android.view.View child = getChildAt(position - mFirstPosition);
				if (child != null)
				{
					mContextMenuInfo = createContextMenuInfo(child, position, id);
					return base.showContextMenuForChild(this);
				}
			}
			return base.showContextMenu(x, y, metaState);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool showContextMenuForChild(android.view.View originalView)
		{
			int longPressPosition = getPositionForView(originalView);
			if (longPressPosition >= 0)
			{
				long longPressId = mAdapter.getItemId(longPressPosition);
				bool handled = false;
				if (mOnItemLongClickListener != null)
				{
					handled = mOnItemLongClickListener.onItemLongClick(this, originalView, longPressPosition
						, longPressId);
				}
				if (!handled)
				{
					mContextMenuInfo = createContextMenuInfo(getChildAt(longPressPosition - mFirstPosition
						), longPressPosition, longPressId);
					handled = base.showContextMenuForChild(originalView);
				}
				return handled;
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					if (!isEnabled())
					{
						return true;
					}
					if (isClickable() && isPressed() && mSelectedPosition >= 0 && mAdapter != null &&
						 mSelectedPosition < mAdapter.getCount())
					{
						android.view.View view = getChildAt(mSelectedPosition - mFirstPosition);
						if (view != null)
						{
							performItemClick(view, mSelectedPosition, mSelectedRowId);
							view.setPressed(false);
						}
						setPressed(false);
						return true;
					}
					break;
				}
			}
			return base.onKeyUp(keyCode, @event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchSetPressed(bool pressed)
		{
		}

		// Don't dispatch setPressed to our children. We call setPressed on ourselves to
		// get the selector in the right state, but we don't want to press each child.
		/// <summary>Maps a point to a position in the list.</summary>
		/// <remarks>Maps a point to a position in the list.</remarks>
		/// <param name="x">X in local coordinate</param>
		/// <param name="y">Y in local coordinate</param>
		/// <returns>
		/// The position of the item which contains the specified point, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if the point does not intersect an item.
		/// </returns>
		public virtual int pointToPosition(int x, int y)
		{
			android.graphics.Rect frame = mTouchFrame;
			if (frame == null)
			{
				mTouchFrame = new android.graphics.Rect();
				frame = mTouchFrame;
			}
			int count = getChildCount();
			{
				for (int i = count - 1; i >= 0; i--)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() == android.view.View.VISIBLE)
					{
						child.getHitRect(frame);
						if (frame.contains(x, y))
						{
							return mFirstPosition + i;
						}
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		/// <summary>Maps a point to a the rowId of the item which intersects that point.</summary>
		/// <remarks>Maps a point to a the rowId of the item which intersects that point.</remarks>
		/// <param name="x">X in local coordinate</param>
		/// <param name="y">Y in local coordinate</param>
		/// <returns>
		/// The rowId of the item which contains the specified point, or
		/// <see cref="android.widget.AdapterView.INVALID_ROW_ID">android.widget.AdapterView.INVALID_ROW_ID
		/// 	</see>
		/// if the point does not intersect an item.
		/// </returns>
		public virtual long pointToRowId(int x, int y)
		{
			int position = pointToPosition(x, y);
			if (position >= 0)
			{
				return mAdapter.getItemId(position);
			}
			return android.widget.AdapterView.INVALID_ROW_ID;
		}

		internal sealed class CheckForTap : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				if (this._enclosing.mTouchMode == android.widget.AbsListView.TOUCH_MODE_DOWN)
				{
					this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_TAP;
					android.view.View child = this._enclosing.getChildAt(this._enclosing.mMotionPosition
						 - this._enclosing.mFirstPosition);
					if (child != null && !child.hasFocusable())
					{
						this._enclosing.mLayoutMode = android.widget.AbsListView.LAYOUT_NORMAL;
						if (!this._enclosing.mDataChanged)
						{
							child.setPressed(true);
							this._enclosing.setPressed(true);
							this._enclosing.layoutChildren();
							this._enclosing.positionSelector(this._enclosing.mMotionPosition, child);
							this._enclosing.refreshDrawableState();
							int longPressTimeout = android.view.ViewConfiguration.getLongPressTimeout();
							bool longClickable = this._enclosing.isLongClickable();
							if (this._enclosing.mSelector != null)
							{
								android.graphics.drawable.Drawable d = this._enclosing.mSelector.getCurrent();
								if (d != null && d is android.graphics.drawable.TransitionDrawable)
								{
									if (longClickable)
									{
										((android.graphics.drawable.TransitionDrawable)d).startTransition(longPressTimeout
											);
									}
									else
									{
										((android.graphics.drawable.TransitionDrawable)d).resetTransition();
									}
								}
							}
							if (longClickable)
							{
								if (this._enclosing.mPendingCheckForLongPress == null)
								{
									this._enclosing.mPendingCheckForLongPress = new android.widget.AbsListView.CheckForLongPress
										(this._enclosing);
								}
								this._enclosing.mPendingCheckForLongPress.rememberWindowAttachCount();
								this._enclosing.postDelayed(this._enclosing.mPendingCheckForLongPress, longPressTimeout
									);
							}
							else
							{
								this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_DONE_WAITING;
							}
						}
						else
						{
							this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_DONE_WAITING;
						}
					}
				}
			}

			internal CheckForTap(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		private bool startScrollIfNeeded(int y)
		{
			// Check if we have moved far enough that it looks more like a
			// scroll than a tap
			int deltaY = y - mMotionY;
			int distance = System.Math.Abs(deltaY);
			bool overscroll = mScrollY != 0;
			if (overscroll || distance > mTouchSlop)
			{
				createScrollingCache();
				if (overscroll)
				{
					mTouchMode = TOUCH_MODE_OVERSCROLL;
					mMotionCorrection = 0;
				}
				else
				{
					mTouchMode = TOUCH_MODE_SCROLL;
					mMotionCorrection = deltaY > 0 ? mTouchSlop : -mTouchSlop;
				}
				android.os.Handler handler = getHandler();
				// Handler should not be null unless the AbsListView is not attached to a
				// window, which would make it very hard to scroll it... but the monkeys
				// say it's possible.
				if (handler != null)
				{
					handler.removeCallbacks(mPendingCheckForLongPress);
				}
				setPressed(false);
				android.view.View motionView = getChildAt(mMotionPosition - mFirstPosition);
				if (motionView != null)
				{
					motionView.setPressed(false);
				}
				reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
					);
				// Time to start stealing events! Once we've stolen them, don't let anyone
				// steal from us
				android.view.ViewParent parent = getParent();
				if (parent != null)
				{
					parent.requestDisallowInterceptTouchEvent(true);
				}
				scrollIfNeeded(y);
				return true;
			}
			return false;
		}

		private void scrollIfNeeded(int y)
		{
			int rawDeltaY = y - mMotionY;
			int deltaY = rawDeltaY - mMotionCorrection;
			int incrementalDeltaY = mLastY != int.MinValue ? y - mLastY : deltaY;
			if (mTouchMode == TOUCH_MODE_SCROLL)
			{
				if (mScrollStrictSpan == null)
				{
					// If it's non-null, we're already in a scroll.
					mScrollStrictSpan = android.os.StrictMode.enterCriticalSpan("AbsListView-scroll");
				}
				if (y != mLastY)
				{
					// We may be here after stopping a fling and continuing to scroll.
					// If so, we haven't disallowed intercepting touch events yet.
					// Make sure that we do so in case we're in a parent that can intercept.
					if ((mGroupFlags & FLAG_DISALLOW_INTERCEPT) == 0 && System.Math.Abs(rawDeltaY) > 
						mTouchSlop)
					{
						android.view.ViewParent parent = getParent();
						if (parent != null)
						{
							parent.requestDisallowInterceptTouchEvent(true);
						}
					}
					int motionIndex;
					if (mMotionPosition >= 0)
					{
						motionIndex = mMotionPosition - mFirstPosition;
					}
					else
					{
						// If we don't have a motion position that we can reliably track,
						// pick something in the middle to make a best guess at things below.
						motionIndex = getChildCount() / 2;
					}
					int motionViewPrevTop = 0;
					android.view.View motionView = this.getChildAt(motionIndex);
					if (motionView != null)
					{
						motionViewPrevTop = motionView.getTop();
					}
					// No need to do all this work if we're not going to move anyway
					bool atEdge = false;
					if (incrementalDeltaY != 0)
					{
						atEdge = trackMotionScroll(deltaY, incrementalDeltaY);
					}
					// Check to see if we have bumped into the scroll limit
					motionView = this.getChildAt(motionIndex);
					if (motionView != null)
					{
						// Check if the top of the motion view is where it is
						// supposed to be
						int motionViewRealTop = motionView.getTop();
						if (atEdge)
						{
							// Apply overscroll
							int overscroll = -incrementalDeltaY - (motionViewRealTop - motionViewPrevTop);
							overScrollBy(0, overscroll, 0, mScrollY, 0, 0, 0, mOverscrollDistance, true);
							if (System.Math.Abs(mOverscrollDistance) == System.Math.Abs(mScrollY))
							{
								// Don't allow overfling if we're at the edge.
								if (mVelocityTracker != null)
								{
									mVelocityTracker.clear();
								}
							}
							int overscrollMode = getOverScrollMode();
							if (overscrollMode == OVER_SCROLL_ALWAYS || (overscrollMode == OVER_SCROLL_IF_CONTENT_SCROLLS
								 && !contentFits()))
							{
								mDirection = 0;
								// Reset when entering overscroll.
								mTouchMode = TOUCH_MODE_OVERSCROLL;
								if (rawDeltaY > 0)
								{
									mEdgeGlowTop.onPull((float)overscroll / getHeight());
									if (!mEdgeGlowBottom.isFinished())
									{
										mEdgeGlowBottom.onRelease();
									}
								}
								else
								{
									if (rawDeltaY < 0)
									{
										mEdgeGlowBottom.onPull((float)overscroll / getHeight());
										if (!mEdgeGlowTop.isFinished())
										{
											mEdgeGlowTop.onRelease();
										}
									}
								}
							}
						}
						mMotionY = y;
						invalidate();
					}
					mLastY = y;
				}
			}
			else
			{
				if (mTouchMode == TOUCH_MODE_OVERSCROLL)
				{
					if (y != mLastY)
					{
						int oldScroll = mScrollY;
						int newScroll = oldScroll - incrementalDeltaY;
						int newDirection = y > mLastY ? 1 : -1;
						if (mDirection == 0)
						{
							mDirection = newDirection;
						}
						int overScrollDistance = -incrementalDeltaY;
						if ((newScroll < 0 && oldScroll >= 0) || (newScroll > 0 && oldScroll <= 0))
						{
							overScrollDistance = -oldScroll;
							incrementalDeltaY += overScrollDistance;
						}
						else
						{
							incrementalDeltaY = 0;
						}
						if (overScrollDistance != 0)
						{
							overScrollBy(0, overScrollDistance, 0, mScrollY, 0, 0, 0, mOverscrollDistance, true
								);
							int overscrollMode = getOverScrollMode();
							if (overscrollMode == OVER_SCROLL_ALWAYS || (overscrollMode == OVER_SCROLL_IF_CONTENT_SCROLLS
								 && !contentFits()))
							{
								if (rawDeltaY > 0)
								{
									mEdgeGlowTop.onPull((float)overScrollDistance / getHeight());
									if (!mEdgeGlowBottom.isFinished())
									{
										mEdgeGlowBottom.onRelease();
									}
								}
								else
								{
									if (rawDeltaY < 0)
									{
										mEdgeGlowBottom.onPull((float)overScrollDistance / getHeight());
										if (!mEdgeGlowTop.isFinished())
										{
											mEdgeGlowTop.onRelease();
										}
									}
								}
								invalidate();
							}
						}
						if (incrementalDeltaY != 0)
						{
							// Coming back to 'real' list scrolling
							mScrollY = 0;
							invalidateParentIfNeeded();
							// No need to do all this work if we're not going to move anyway
							if (incrementalDeltaY != 0)
							{
								trackMotionScroll(incrementalDeltaY, incrementalDeltaY);
							}
							mTouchMode = TOUCH_MODE_SCROLL;
							// We did not scroll the full amount. Treat this essentially like the
							// start of a new touch scroll
							int motionPosition = findClosestMotionRow(y);
							mMotionCorrection = 0;
							android.view.View motionView = getChildAt(motionPosition - mFirstPosition);
							mMotionViewOriginalTop = motionView != null ? motionView.getTop() : 0;
							mMotionY = y;
							mMotionPosition = motionPosition;
						}
						mLastY = y;
						mDirection = newDirection;
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnTouchModeChangeListener"
			)]
		public virtual void onTouchModeChanged(bool isInTouchMode_1)
		{
			if (isInTouchMode_1)
			{
				// Get rid of the selection when we enter touch mode
				hideSelector();
				// Layout, but only if we already have done so previously.
				// (Otherwise may clobber a LAYOUT_SYNC layout that was requested to restore
				// state.)
				if (getHeight() > 0 && getChildCount() > 0)
				{
					// We do not lose focus initiating a touch (since AbsListView is focusable in
					// touch mode). Force an initial layout to get rid of the selection.
					layoutChildren();
				}
				updateSelectorState();
			}
			else
			{
				int touchMode = mTouchMode;
				if (touchMode == TOUCH_MODE_OVERSCROLL || touchMode == TOUCH_MODE_OVERFLING)
				{
					if (mFlingRunnable != null)
					{
						mFlingRunnable.endFling();
					}
					if (mPositionScroller != null)
					{
						mPositionScroller.stop();
					}
					if (mScrollY != 0)
					{
						mScrollY = 0;
						invalidateParentCaches();
						finishGlows();
						invalidate();
					}
				}
			}
		}

		private sealed class _Runnable_3161 : java.lang.Runnable
		{
			public _Runnable_3161(AbsListView _enclosing, android.view.View child, android.widget.AbsListView
				.PerformClick performClick_1)
			{
				this._enclosing = _enclosing;
				this.child = child;
				this.performClick_1 = performClick_1;
			}

			// A disabled view that is clickable still consumes the touch
			// events, it just doesn't respond to them.
			// User clicked on an actual view (and was not stopping a fling).
			// It might be a click or a scroll. Assume it is a click until
			// proven otherwise
			// FIXME Debounce
			// Stopped a fling. It is a scroll.
			// Remember where the motion event started
			// Check if we have moved far enough that it looks more like a
			// scroll than a tap
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_REST;
				child.setPressed(false);
				this._enclosing.setPressed(false);
				if (!this._enclosing.mDataChanged)
				{
					performClick_1.run();
				}
			}

			private readonly AbsListView _enclosing;

			private readonly android.view.View child;

			private readonly android.widget.AbsListView.PerformClick performClick_1;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			if (!isEnabled())
			{
				return isClickable() || isLongClickable();
			}
			if (mFastScroller != null)
			{
				bool intercepted = mFastScroller.onTouchEvent(ev);
				if (intercepted)
				{
					return true;
				}
			}
			int action = ev.getAction();
			android.view.View v;
			initVelocityTrackerIfNotExists();
			mVelocityTracker.addMovement(ev);
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					switch (mTouchMode)
					{
						case TOUCH_MODE_OVERFLING:
						{
							mFlingRunnable.endFling();
							if (mPositionScroller != null)
							{
								mPositionScroller.stop();
							}
							mTouchMode = TOUCH_MODE_OVERSCROLL;
							mMotionX = (int)ev.getX();
							mMotionY = mLastY = (int)ev.getY();
							mMotionCorrection = 0;
							mActivePointerId = ev.getPointerId(0);
							mDirection = 0;
							break;
						}

						default:
						{
							mActivePointerId = ev.getPointerId(0);
							int x = (int)ev.getX();
							int y = (int)ev.getY();
							int motionPosition = pointToPosition(x, y);
							if (!mDataChanged)
							{
								if ((mTouchMode != TOUCH_MODE_FLING) && (motionPosition >= 0) && (getAdapter().isEnabled
									(motionPosition)))
								{
									mTouchMode = TOUCH_MODE_DOWN;
									if (mPendingCheckForTap == null)
									{
										mPendingCheckForTap = new android.widget.AbsListView.CheckForTap(this);
									}
									postDelayed(mPendingCheckForTap, android.view.ViewConfiguration.getTapTimeout());
								}
								else
								{
									if (mTouchMode == TOUCH_MODE_FLING)
									{
										createScrollingCache();
										mTouchMode = TOUCH_MODE_SCROLL;
										mMotionCorrection = 0;
										motionPosition = findMotionRow(y);
										mFlingRunnable.flywheelTouch();
									}
								}
							}
							if (motionPosition >= 0)
							{
								v = getChildAt(motionPosition - mFirstPosition);
								mMotionViewOriginalTop = v.getTop();
							}
							mMotionX = x;
							mMotionY = y;
							mMotionPosition = motionPosition;
							mLastY = int.MinValue;
							break;
						}
					}
					if (performButtonActionOnTouchDown(ev))
					{
						if (mTouchMode == TOUCH_MODE_DOWN)
						{
							removeCallbacks(mPendingCheckForTap);
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					int pointerIndex = ev.findPointerIndex(mActivePointerId);
					if (pointerIndex == -1)
					{
						pointerIndex = 0;
						mActivePointerId = ev.getPointerId(pointerIndex);
					}
					int y = (int)ev.getY(pointerIndex);
					switch (mTouchMode)
					{
						case TOUCH_MODE_DOWN:
						case TOUCH_MODE_TAP:
						case TOUCH_MODE_DONE_WAITING:
						{
							startScrollIfNeeded(y);
							break;
						}

						case TOUCH_MODE_SCROLL:
						case TOUCH_MODE_OVERSCROLL:
						{
							scrollIfNeeded(y);
							break;
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					switch (mTouchMode)
					{
						case TOUCH_MODE_DOWN:
						case TOUCH_MODE_TAP:
						case TOUCH_MODE_DONE_WAITING:
						{
							int motionPosition = mMotionPosition;
							android.view.View child = getChildAt(motionPosition - mFirstPosition);
							float x = ev.getX();
							bool inList = x > mListPadding.left && x < getWidth() - mListPadding.right;
							if (child != null && !child.hasFocusable() && inList)
							{
								if (mTouchMode != TOUCH_MODE_DOWN)
								{
									child.setPressed(false);
								}
								if (mPerformClick == null)
								{
									mPerformClick = new android.widget.AbsListView.PerformClick(this);
								}
								android.widget.AbsListView.PerformClick performClick_1 = mPerformClick;
								performClick_1.mClickMotionPosition = motionPosition;
								performClick_1.rememberWindowAttachCount();
								mResurrectToPosition = motionPosition;
								if (mTouchMode == TOUCH_MODE_DOWN || mTouchMode == TOUCH_MODE_TAP)
								{
									android.os.Handler handler = getHandler();
									if (handler != null)
									{
										handler.removeCallbacks(mTouchMode == TOUCH_MODE_DOWN ? mPendingCheckForTap : mPendingCheckForLongPress
											);
									}
									mLayoutMode = LAYOUT_NORMAL;
									if (!mDataChanged && mAdapter.isEnabled(motionPosition))
									{
										mTouchMode = TOUCH_MODE_TAP;
										setSelectedPositionInt(mMotionPosition);
										layoutChildren();
										child.setPressed(true);
										positionSelector(mMotionPosition, child);
										setPressed(true);
										if (mSelector != null)
										{
											android.graphics.drawable.Drawable d = mSelector.getCurrent();
											if (d != null && d is android.graphics.drawable.TransitionDrawable)
											{
												((android.graphics.drawable.TransitionDrawable)d).resetTransition();
											}
										}
										if (mTouchModeReset != null)
										{
											removeCallbacks(mTouchModeReset);
										}
										mTouchModeReset = new _Runnable_3161(this, child, performClick_1);
										postDelayed(mTouchModeReset, android.view.ViewConfiguration.getPressedStateDuration
											());
									}
									else
									{
										mTouchMode = TOUCH_MODE_REST;
										updateSelectorState();
									}
									return true;
								}
								else
								{
									if (!mDataChanged && mAdapter.isEnabled(motionPosition))
									{
										performClick_1.run();
									}
								}
							}
							mTouchMode = TOUCH_MODE_REST;
							updateSelectorState();
							break;
						}

						case TOUCH_MODE_SCROLL:
						{
							int childCount = getChildCount();
							if (childCount > 0)
							{
								int firstChildTop = getChildAt(0).getTop();
								int lastChildBottom = getChildAt(childCount - 1).getBottom();
								int contentTop = mListPadding.top;
								int contentBottom = getHeight() - mListPadding.bottom;
								if (mFirstPosition == 0 && firstChildTop >= contentTop && mFirstPosition + childCount
									 < mItemCount && lastChildBottom <= getHeight() - contentBottom)
								{
									mTouchMode = TOUCH_MODE_REST;
									reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
										);
								}
								else
								{
									android.view.VelocityTracker velocityTracker = mVelocityTracker;
									velocityTracker.computeCurrentVelocity(1000, mMaximumVelocity);
									int initialVelocity = (int)(velocityTracker.getYVelocity(mActivePointerId) * mVelocityScale
										);
									// Fling if we have enough velocity and we aren't at a boundary.
									// Since we can potentially overfling more than we can overscroll, don't
									// allow the weird behavior where you can scroll to a boundary then
									// fling further.
									if (System.Math.Abs(initialVelocity) > mMinimumVelocity && !((mFirstPosition == 0
										 && firstChildTop == contentTop - mOverscrollDistance) || (mFirstPosition + childCount
										 == mItemCount && lastChildBottom == contentBottom + mOverscrollDistance)))
									{
										if (mFlingRunnable == null)
										{
											mFlingRunnable = new android.widget.AbsListView.FlingRunnable(this);
										}
										reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_FLING
											);
										mFlingRunnable.start(-initialVelocity);
									}
									else
									{
										mTouchMode = TOUCH_MODE_REST;
										reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
											);
										if (mFlingRunnable != null)
										{
											mFlingRunnable.endFling();
										}
										if (mPositionScroller != null)
										{
											mPositionScroller.stop();
										}
									}
								}
							}
							else
							{
								mTouchMode = TOUCH_MODE_REST;
								reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
									);
							}
							break;
						}

						case TOUCH_MODE_OVERSCROLL:
						{
							if (mFlingRunnable == null)
							{
								mFlingRunnable = new android.widget.AbsListView.FlingRunnable(this);
							}
							android.view.VelocityTracker velocityTracker_1 = mVelocityTracker;
							velocityTracker_1.computeCurrentVelocity(1000, mMaximumVelocity);
							int initialVelocity_1 = (int)velocityTracker_1.getYVelocity(mActivePointerId);
							reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_FLING
								);
							if (System.Math.Abs(initialVelocity_1) > mMinimumVelocity)
							{
								mFlingRunnable.startOverfling(-initialVelocity_1);
							}
							else
							{
								mFlingRunnable.startSpringback();
							}
							break;
						}
					}
					setPressed(false);
					if (mEdgeGlowTop != null)
					{
						mEdgeGlowTop.onRelease();
						mEdgeGlowBottom.onRelease();
					}
					// Need to redraw since we probably aren't drawing the selector anymore
					invalidate();
					android.os.Handler handler_1 = getHandler();
					if (handler_1 != null)
					{
						handler_1.removeCallbacks(mPendingCheckForLongPress);
					}
					recycleVelocityTracker();
					mActivePointerId = INVALID_POINTER;
					if (mScrollStrictSpan != null)
					{
						mScrollStrictSpan.finish();
						mScrollStrictSpan = null;
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					switch (mTouchMode)
					{
						case TOUCH_MODE_OVERSCROLL:
						{
							if (mFlingRunnable == null)
							{
								mFlingRunnable = new android.widget.AbsListView.FlingRunnable(this);
							}
							mFlingRunnable.startSpringback();
							break;
						}

						case TOUCH_MODE_OVERFLING:
						{
							// Do nothing - let it play out.
							break;
						}

						default:
						{
							mTouchMode = TOUCH_MODE_REST;
							setPressed(false);
							android.view.View motionView = this.getChildAt(mMotionPosition - mFirstPosition);
							if (motionView != null)
							{
								motionView.setPressed(false);
							}
							clearScrollingCache();
							android.os.Handler handler = getHandler();
							if (handler != null)
							{
								handler.removeCallbacks(mPendingCheckForLongPress);
							}
							recycleVelocityTracker();
							break;
						}
					}
					if (mEdgeGlowTop != null)
					{
						mEdgeGlowTop.onRelease();
						mEdgeGlowBottom.onRelease();
					}
					mActivePointerId = INVALID_POINTER;
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					int x = mMotionX;
					int y = mMotionY;
					int motionPosition = pointToPosition(x, y);
					if (motionPosition >= 0)
					{
						// Remember where the motion event started
						v = getChildAt(motionPosition - mFirstPosition);
						mMotionViewOriginalTop = v.getTop();
						mMotionPosition = motionPosition;
					}
					mLastY = y;
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_DOWN:
				{
					// New pointers take over dragging duties
					int index = ev.getActionIndex();
					int id = ev.getPointerId(index);
					int x = (int)ev.getX(index);
					int y = (int)ev.getY(index);
					mMotionCorrection = 0;
					mActivePointerId = id;
					mMotionX = x;
					mMotionY = y;
					int motionPosition = pointToPosition(x, y);
					if (motionPosition >= 0)
					{
						// Remember where the motion event started
						v = getChildAt(motionPosition - mFirstPosition);
						mMotionViewOriginalTop = v.getTop();
						mMotionPosition = motionPosition;
					}
					mLastY = y;
					break;
				}
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onOverScrolled(int scrollX, int scrollY, bool clampedX
			, bool clampedY)
		{
			if (mScrollY != scrollY)
			{
				onScrollChanged(mScrollX, scrollY, mScrollX, mScrollY);
				mScrollY = scrollY;
				invalidateParentIfNeeded();
				awakenScrollBars();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			if ((@event.getSource() & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
			{
				switch (@event.getAction())
				{
					case android.view.MotionEvent.ACTION_SCROLL:
					{
						if (mTouchMode == TOUCH_MODE_REST)
						{
							float vscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
							if (vscroll != 0)
							{
								int delta = (int)(vscroll * getVerticalScrollFactor());
								if (!trackMotionScroll(delta, delta))
								{
									return true;
								}
							}
						}
						break;
					}
				}
			}
			return base.onGenericMotionEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			base.draw(canvas);
			if (mEdgeGlowTop != null)
			{
				int scrollY = mScrollY;
				if (!mEdgeGlowTop.isFinished())
				{
					int restoreCount = canvas.save();
					int leftPadding = mListPadding.left + mGlowPaddingLeft;
					int rightPadding = mListPadding.right + mGlowPaddingRight;
					int width = getWidth() - leftPadding - rightPadding;
					canvas.translate(leftPadding, System.Math.Min(0, scrollY + mFirstPositionDistanceGuess
						));
					mEdgeGlowTop.setSize(width, getHeight());
					if (mEdgeGlowTop.draw(canvas))
					{
						invalidate();
					}
					canvas.restoreToCount(restoreCount);
				}
				if (!mEdgeGlowBottom.isFinished())
				{
					int restoreCount = canvas.save();
					int leftPadding = mListPadding.left + mGlowPaddingLeft;
					int rightPadding = mListPadding.right + mGlowPaddingRight;
					int width = getWidth() - leftPadding - rightPadding;
					int height = getHeight();
					canvas.translate(-width + leftPadding, System.Math.Max(height, scrollY + mLastPositionDistanceGuess
						));
					canvas.rotate(180, width, 0);
					mEdgeGlowBottom.setSize(width, height);
					if (mEdgeGlowBottom.draw(canvas))
					{
						invalidate();
					}
					canvas.restoreToCount(restoreCount);
				}
			}
			if (mFastScroller != null)
			{
				int scrollY = mScrollY;
				if (scrollY != 0)
				{
					// Pin to the top/bottom during overscroll
					int restoreCount = canvas.save();
					canvas.translate(0, (float)scrollY);
					mFastScroller.draw(canvas);
					canvas.restoreToCount(restoreCount);
				}
				else
				{
					mFastScroller.draw(canvas);
				}
			}
		}

		/// <hide></hide>
		public virtual void setOverScrollEffectPadding(int leftPadding, int rightPadding)
		{
			mGlowPaddingLeft = leftPadding;
			mGlowPaddingRight = rightPadding;
		}

		private void initOrResetVelocityTracker()
		{
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
			else
			{
				mVelocityTracker.clear();
			}
		}

		private void initVelocityTrackerIfNotExists()
		{
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
		}

		private void recycleVelocityTracker()
		{
			if (mVelocityTracker != null)
			{
				mVelocityTracker.recycle();
				mVelocityTracker = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void requestDisallowInterceptTouchEvent(bool disallowIntercept)
		{
			if (disallowIntercept)
			{
				recycleVelocityTracker();
			}
			base.requestDisallowInterceptTouchEvent(disallowIntercept);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			int action = ev.getAction();
			android.view.View v;
			if (mFastScroller != null)
			{
				bool intercepted = mFastScroller.onInterceptTouchEvent(ev);
				if (intercepted)
				{
					return true;
				}
			}
			switch (action & android.view.MotionEvent.ACTION_MASK)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					int touchMode = mTouchMode;
					if (touchMode == TOUCH_MODE_OVERFLING || touchMode == TOUCH_MODE_OVERSCROLL)
					{
						mMotionCorrection = 0;
						return true;
					}
					int x = (int)ev.getX();
					int y = (int)ev.getY();
					mActivePointerId = ev.getPointerId(0);
					int motionPosition = findMotionRow(y);
					if (touchMode != TOUCH_MODE_FLING && motionPosition >= 0)
					{
						// User clicked on an actual view (and was not stopping a fling).
						// Remember where the motion event started
						v = getChildAt(motionPosition - mFirstPosition);
						mMotionViewOriginalTop = v.getTop();
						mMotionX = x;
						mMotionY = y;
						mMotionPosition = motionPosition;
						mTouchMode = TOUCH_MODE_DOWN;
						clearScrollingCache();
					}
					mLastY = int.MinValue;
					initOrResetVelocityTracker();
					mVelocityTracker.addMovement(ev);
					if (touchMode == TOUCH_MODE_FLING)
					{
						return true;
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					switch (mTouchMode)
					{
						case TOUCH_MODE_DOWN:
						{
							int pointerIndex = ev.findPointerIndex(mActivePointerId);
							if (pointerIndex == -1)
							{
								pointerIndex = 0;
								mActivePointerId = ev.getPointerId(pointerIndex);
							}
							int y = (int)ev.getY(pointerIndex);
							initVelocityTrackerIfNotExists();
							mVelocityTracker.addMovement(ev);
							if (startScrollIfNeeded(y))
							{
								return true;
							}
							break;
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				case android.view.MotionEvent.ACTION_UP:
				{
					mTouchMode = TOUCH_MODE_REST;
					mActivePointerId = INVALID_POINTER;
					recycleVelocityTracker();
					reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
						);
					break;
				}

				case android.view.MotionEvent.ACTION_POINTER_UP:
				{
					onSecondaryPointerUp(ev);
					break;
				}
			}
			return false;
		}

		private void onSecondaryPointerUp(android.view.MotionEvent ev)
		{
			int pointerIndex = (ev.getAction() & android.view.MotionEvent.ACTION_POINTER_INDEX_MASK
				) >> android.view.MotionEvent.ACTION_POINTER_INDEX_SHIFT;
			int pointerId = ev.getPointerId(pointerIndex);
			if (pointerId == mActivePointerId)
			{
				// This was our active pointer going up. Choose a new
				// active pointer and adjust accordingly.
				// TODO: Make this decision more intelligent.
				int newPointerIndex = pointerIndex == 0 ? 1 : 0;
				mMotionX = (int)ev.getX(newPointerIndex);
				mMotionY = (int)ev.getY(newPointerIndex);
				mMotionCorrection = 0;
				mActivePointerId = ev.getPointerId(newPointerIndex);
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void addTouchables(java.util.ArrayList<android.view.View> views)
		{
			int count = getChildCount();
			int firstPosition = mFirstPosition;
			android.widget.ListAdapter adapter = mAdapter;
			if (adapter == null)
			{
				return;
			}
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (adapter.isEnabled(firstPosition + i))
					{
						views.add(child);
					}
					child.addTouchables(views);
				}
			}
		}

		/// <summary>
		/// Fires an "on scroll state changed" event to the registered
		/// <see cref="OnScrollListener">OnScrollListener</see>
		/// , if any. The state change
		/// is fired only if the specified state is different from the previously known state.
		/// </summary>
		/// <param name="newState">The new scroll state.</param>
		internal virtual void reportScrollStateChange(int newState)
		{
			if (newState != mLastScrollState)
			{
				if (mOnScrollListener != null)
				{
					mLastScrollState = newState;
					mOnScrollListener.onScrollStateChanged(this, newState);
				}
			}
		}

		/// <summary>Responsible for fling behavior.</summary>
		/// <remarks>
		/// Responsible for fling behavior. Use
		/// <see cref="start(int)">start(int)</see>
		/// to
		/// initiate a fling. Each frame of the fling is handled in
		/// <see cref="run()">run()</see>
		/// .
		/// A FlingRunnable will keep re-posting itself until the fling is done.
		/// </remarks>
		private class FlingRunnable : java.lang.Runnable
		{
			/// <summary>Tracks the decay of a fling scroll</summary>
			internal readonly android.widget.OverScroller mScroller;

			/// <summary>Y value reported by mScroller on the previous fling</summary>
			internal int mLastFlingY;

			internal sealed class _Runnable_3636 : java.lang.Runnable
			{
				public _Runnable_3636(FlingRunnable _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
				public void run()
				{
					int activeId = this._enclosing._enclosing.mActivePointerId;
					android.view.VelocityTracker vt = this._enclosing._enclosing.mVelocityTracker;
					android.widget.OverScroller scroller = this._enclosing.mScroller;
					if (vt == null || activeId == android.widget.AbsListView.INVALID_POINTER)
					{
						return;
					}
					vt.computeCurrentVelocity(1000, this._enclosing._enclosing.mMaximumVelocity);
					float yvel = -vt.getYVelocity(activeId);
					if (System.Math.Abs(yvel) >= this._enclosing._enclosing.mMinimumVelocity && scroller
						.isScrollingInDirection(0, yvel))
					{
						// Keep the fling alive a little longer
						this._enclosing._enclosing.postDelayed(this, android.widget.AbsListView.FlingRunnable
							.FLYWHEEL_TIMEOUT);
					}
					else
					{
						this._enclosing.endFling();
						this._enclosing._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_SCROLL;
						this._enclosing._enclosing.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
							);
					}
				}

				private readonly FlingRunnable _enclosing;
			}

			internal readonly java.lang.Runnable mCheckFlywheel;

			internal const int FLYWHEEL_TIMEOUT = 40;

			internal FlingRunnable(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
				mCheckFlywheel = new _Runnable_3636(this);
				// milliseconds
				this.mScroller = new android.widget.OverScroller(this._enclosing.getContext());
			}

			internal virtual void start(int initialVelocity)
			{
				int initialY = initialVelocity < 0 ? int.MaxValue : 0;
				this.mLastFlingY = initialY;
				this.mScroller.fling(0, initialY, 0, initialVelocity, 0, int.MaxValue, 0, int.MaxValue
					);
				this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_FLING;
				this._enclosing.post(this);
				if (this._enclosing.mFlingStrictSpan == null)
				{
					this._enclosing.mFlingStrictSpan = android.os.StrictMode.enterCriticalSpan("AbsListView-fling"
						);
				}
			}

			internal virtual void startSpringback()
			{
				if (this.mScroller.springBack(0, this._enclosing.mScrollY, 0, 0, 0, 0))
				{
					this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_OVERFLING;
					this._enclosing.invalidate();
					this._enclosing.post(this);
				}
				else
				{
					this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_REST;
					this._enclosing.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
						);
				}
			}

			internal virtual void startOverfling(int initialVelocity)
			{
				this.mScroller.fling(0, this._enclosing.mScrollY, 0, initialVelocity, 0, 0, int.MinValue
					, int.MaxValue, 0, this._enclosing.getHeight());
				this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_OVERFLING;
				this._enclosing.invalidate();
				this._enclosing.post(this);
			}

			internal virtual void edgeReached(int delta)
			{
				this.mScroller.notifyVerticalEdgeReached(this._enclosing.mScrollY, 0, this._enclosing
					.mOverflingDistance);
				int overscrollMode = this._enclosing.getOverScrollMode();
				if (overscrollMode == android.view.View.OVER_SCROLL_ALWAYS || (overscrollMode == 
					android.view.View.OVER_SCROLL_IF_CONTENT_SCROLLS && !this._enclosing.contentFits
					()))
				{
					this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_OVERFLING;
					int vel = (int)this.mScroller.getCurrVelocity();
					if (delta > 0)
					{
						this._enclosing.mEdgeGlowTop.onAbsorb(vel);
					}
					else
					{
						this._enclosing.mEdgeGlowBottom.onAbsorb(vel);
					}
				}
				else
				{
					this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_REST;
					if (this._enclosing.mPositionScroller != null)
					{
						this._enclosing.mPositionScroller.stop();
					}
				}
				this._enclosing.invalidate();
				this._enclosing.post(this);
			}

			internal virtual void startScroll(int distance, int duration)
			{
				int initialY = distance < 0 ? int.MaxValue : 0;
				this.mLastFlingY = initialY;
				this.mScroller.startScroll(0, initialY, 0, distance, duration);
				this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_FLING;
				this._enclosing.post(this);
			}

			internal virtual void endFling()
			{
				this._enclosing.mTouchMode = android.widget.AbsListView.TOUCH_MODE_REST;
				this._enclosing.removeCallbacks(this);
				this._enclosing.removeCallbacks(this.mCheckFlywheel);
				this._enclosing.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
					);
				this._enclosing.clearScrollingCache();
				this.mScroller.abortAnimation();
				if (this._enclosing.mFlingStrictSpan != null)
				{
					this._enclosing.mFlingStrictSpan.finish();
					this._enclosing.mFlingStrictSpan = null;
				}
			}

			internal virtual void flywheelTouch()
			{
				this._enclosing.postDelayed(this.mCheckFlywheel, FLYWHEEL_TIMEOUT);
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				switch (this._enclosing.mTouchMode)
				{
					default:
					{
						this.endFling();
						return;
					}

					case android.widget.AbsListView.TOUCH_MODE_SCROLL:
					{
						if (this.mScroller.isFinished())
						{
							return;
						}
						goto case android.widget.AbsListView.TOUCH_MODE_FLING;
					}

					case android.widget.AbsListView.TOUCH_MODE_FLING:
					{
						// Fall through
						if (this._enclosing.mDataChanged)
						{
							this._enclosing.layoutChildren();
						}
						if (this._enclosing.mItemCount == 0 || this._enclosing.getChildCount() == 0)
						{
							this.endFling();
							return;
						}
						android.widget.OverScroller scroller = this.mScroller;
						bool more = scroller.computeScrollOffset();
						int y = scroller.getCurrY();
						// Flip sign to convert finger direction to list items direction
						// (e.g. finger moving down means list is moving towards the top)
						int delta = this.mLastFlingY - y;
						// Pretend that each frame of a fling scroll is a touch scroll
						if (delta > 0)
						{
							// List is moving towards the top. Use first view as mMotionPosition
							this._enclosing.mMotionPosition = this._enclosing.mFirstPosition;
							android.view.View firstView = this._enclosing.getChildAt(0);
							this._enclosing.mMotionViewOriginalTop = firstView.getTop();
							// Don't fling more than 1 screen
							delta = System.Math.Min(this._enclosing.getHeight() - this._enclosing.mPaddingBottom
								 - this._enclosing.mPaddingTop - 1, delta);
						}
						else
						{
							// List is moving towards the bottom. Use last view as mMotionPosition
							int offsetToLast = this._enclosing.getChildCount() - 1;
							this._enclosing.mMotionPosition = this._enclosing.mFirstPosition + offsetToLast;
							android.view.View lastView = this._enclosing.getChildAt(offsetToLast);
							this._enclosing.mMotionViewOriginalTop = lastView.getTop();
							// Don't fling more than 1 screen
							delta = System.Math.Max(-(this._enclosing.getHeight() - this._enclosing.mPaddingBottom
								 - this._enclosing.mPaddingTop - 1), delta);
						}
						// Check to see if we have bumped into the scroll limit
						android.view.View motionView = this._enclosing.getChildAt(this._enclosing.mMotionPosition
							 - this._enclosing.mFirstPosition);
						int oldTop = 0;
						if (motionView != null)
						{
							oldTop = motionView.getTop();
						}
						// Don't stop just because delta is zero (it could have been rounded)
						bool atEnd = this._enclosing.trackMotionScroll(delta, delta) && (delta != 0);
						if (atEnd)
						{
							if (motionView != null)
							{
								// Tweak the scroll for how far we overshot
								int overshoot = -(delta - (motionView.getTop() - oldTop));
								this._enclosing.overScrollBy(0, overshoot, 0, this._enclosing.mScrollY, 0, 0, 0, 
									this._enclosing.mOverflingDistance, false);
							}
							if (more)
							{
								this.edgeReached(delta);
							}
							break;
						}
						if (more && !atEnd)
						{
							this._enclosing.invalidate();
							this.mLastFlingY = y;
							this._enclosing.post(this);
						}
						else
						{
							this.endFling();
						}
						break;
					}

					case android.widget.AbsListView.TOUCH_MODE_OVERFLING:
					{
						android.widget.OverScroller scroller = this.mScroller;
						if (scroller.computeScrollOffset())
						{
							int scrollY = this._enclosing.mScrollY;
							int currY = scroller.getCurrY();
							int deltaY = currY - scrollY;
							if (this._enclosing.overScrollBy(0, deltaY, 0, scrollY, 0, 0, 0, this._enclosing.
								mOverflingDistance, false))
							{
								bool crossDown = scrollY <= 0 && currY > 0;
								bool crossUp = scrollY >= 0 && currY < 0;
								if (crossDown || crossUp)
								{
									int velocity = (int)scroller.getCurrVelocity();
									if (crossUp)
									{
										velocity = -velocity;
									}
									// Don't flywheel from this; we're just continuing things.
									scroller.abortAnimation();
									this.start(velocity);
								}
								else
								{
									this.startSpringback();
								}
							}
							else
							{
								this._enclosing.invalidate();
								this._enclosing.post(this);
							}
						}
						else
						{
							this.endFling();
						}
						break;
					}
				}
			}

			private readonly AbsListView _enclosing;
		}

		internal class PositionScroller : java.lang.Runnable
		{
			internal const int SCROLL_DURATION = 400;

			internal const int MOVE_DOWN_POS = 1;

			internal const int MOVE_UP_POS = 2;

			internal const int MOVE_DOWN_BOUND = 3;

			internal const int MOVE_UP_BOUND = 4;

			internal const int MOVE_OFFSET = 5;

			private int mMode;

			private int mTargetPos;

			private int mBoundPos;

			private int mLastSeenPos;

			private int mScrollDuration;

			private readonly int mExtraScroll;

			private int mOffsetFromTop;

			internal PositionScroller(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
				this.mExtraScroll = android.view.ViewConfiguration.get(this._enclosing.mContext).
					getScaledFadingEdgeLength();
			}

			internal virtual void start(int position)
			{
				this.stop();
				int firstPos = this._enclosing.mFirstPosition;
				int lastPos = firstPos + this._enclosing.getChildCount() - 1;
				int viewTravelCount;
				if (position <= firstPos)
				{
					viewTravelCount = firstPos - position + 1;
					this.mMode = MOVE_UP_POS;
				}
				else
				{
					if (position >= lastPos)
					{
						viewTravelCount = position - lastPos + 1;
						this.mMode = MOVE_DOWN_POS;
					}
					else
					{
						// Already on screen, nothing to do
						return;
					}
				}
				if (viewTravelCount > 0)
				{
					this.mScrollDuration = SCROLL_DURATION / viewTravelCount;
				}
				else
				{
					this.mScrollDuration = SCROLL_DURATION;
				}
				this.mTargetPos = position;
				this.mBoundPos = android.widget.AdapterView.INVALID_POSITION;
				this.mLastSeenPos = android.widget.AdapterView.INVALID_POSITION;
				this._enclosing.post(this);
			}

			internal virtual void start(int position, int boundPosition)
			{
				this.stop();
				if (boundPosition == android.widget.AdapterView.INVALID_POSITION)
				{
					this.start(position);
					return;
				}
				int firstPos = this._enclosing.mFirstPosition;
				int lastPos = firstPos + this._enclosing.getChildCount() - 1;
				int viewTravelCount;
				if (position <= firstPos)
				{
					int boundPosFromLast = lastPos - boundPosition;
					if (boundPosFromLast < 1)
					{
						// Moving would shift our bound position off the screen. Abort.
						return;
					}
					int posTravel = firstPos - position + 1;
					int boundTravel = boundPosFromLast - 1;
					if (boundTravel < posTravel)
					{
						viewTravelCount = boundTravel;
						this.mMode = MOVE_UP_BOUND;
					}
					else
					{
						viewTravelCount = posTravel;
						this.mMode = MOVE_UP_POS;
					}
				}
				else
				{
					if (position >= lastPos)
					{
						int boundPosFromFirst = boundPosition - firstPos;
						if (boundPosFromFirst < 1)
						{
							// Moving would shift our bound position off the screen. Abort.
							return;
						}
						int posTravel = position - lastPos + 1;
						int boundTravel = boundPosFromFirst - 1;
						if (boundTravel < posTravel)
						{
							viewTravelCount = boundTravel;
							this.mMode = MOVE_DOWN_BOUND;
						}
						else
						{
							viewTravelCount = posTravel;
							this.mMode = MOVE_DOWN_POS;
						}
					}
					else
					{
						// Already on screen, nothing to do
						return;
					}
				}
				if (viewTravelCount > 0)
				{
					this.mScrollDuration = SCROLL_DURATION / viewTravelCount;
				}
				else
				{
					this.mScrollDuration = SCROLL_DURATION;
				}
				this.mTargetPos = position;
				this.mBoundPos = boundPosition;
				this.mLastSeenPos = android.widget.AdapterView.INVALID_POSITION;
				this._enclosing.post(this);
			}

			internal virtual void startWithOffset(int position, int offset)
			{
				this.startWithOffset(position, offset, SCROLL_DURATION);
			}

			internal virtual void startWithOffset(int position, int offset, int duration)
			{
				this.stop();
				this.mTargetPos = position;
				this.mOffsetFromTop = offset;
				this.mBoundPos = android.widget.AdapterView.INVALID_POSITION;
				this.mLastSeenPos = android.widget.AdapterView.INVALID_POSITION;
				this.mMode = MOVE_OFFSET;
				int firstPos = this._enclosing.mFirstPosition;
				int childCount = this._enclosing.getChildCount();
				int lastPos = firstPos + childCount - 1;
				int viewTravelCount;
				if (position < firstPos)
				{
					viewTravelCount = firstPos - position;
				}
				else
				{
					if (position > lastPos)
					{
						viewTravelCount = position - lastPos;
					}
					else
					{
						// On-screen, just scroll.
						int targetTop = this._enclosing.getChildAt(position - firstPos).getTop();
						this._enclosing.smoothScrollBy(targetTop - offset, duration);
						return;
					}
				}
				// Estimate how many screens we should travel
				float screenTravelCount = (float)viewTravelCount / childCount;
				this.mScrollDuration = screenTravelCount < 1 ? (int)(screenTravelCount * duration
					) : (int)(duration / screenTravelCount);
				this.mLastSeenPos = android.widget.AdapterView.INVALID_POSITION;
				this._enclosing.post(this);
			}

			internal virtual void stop()
			{
				this._enclosing.removeCallbacks(this);
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.mTouchMode != android.widget.AbsListView.TOUCH_MODE_FLING && 
					this.mLastSeenPos != android.widget.AdapterView.INVALID_POSITION)
				{
					return;
				}
				int listHeight = this._enclosing.getHeight();
				int firstPos = this._enclosing.mFirstPosition;
				switch (this.mMode)
				{
					case MOVE_DOWN_POS:
					{
						int lastViewIndex = this._enclosing.getChildCount() - 1;
						int lastPos = firstPos + lastViewIndex;
						if (lastViewIndex < 0)
						{
							return;
						}
						if (lastPos == this.mLastSeenPos)
						{
							// No new views, let things keep going.
							this._enclosing.post(this);
							return;
						}
						android.view.View lastView = this._enclosing.getChildAt(lastViewIndex);
						int lastViewHeight = lastView.getHeight();
						int lastViewTop = lastView.getTop();
						int lastViewPixelsShowing = listHeight - lastViewTop;
						int extraScroll = lastPos < this._enclosing.mItemCount - 1 ? this.mExtraScroll : 
							this._enclosing.mListPadding.bottom;
						this._enclosing.smoothScrollBy(lastViewHeight - lastViewPixelsShowing + extraScroll
							, this.mScrollDuration);
						this.mLastSeenPos = lastPos;
						if (lastPos < this.mTargetPos)
						{
							this._enclosing.post(this);
						}
						break;
					}

					case MOVE_DOWN_BOUND:
					{
						int nextViewIndex = 1;
						int childCount = this._enclosing.getChildCount();
						if (firstPos == this.mBoundPos || childCount <= nextViewIndex || firstPos + childCount
							 >= this._enclosing.mItemCount)
						{
							return;
						}
						int nextPos = firstPos + nextViewIndex;
						if (nextPos == this.mLastSeenPos)
						{
							// No new views, let things keep going.
							this._enclosing.post(this);
							return;
						}
						android.view.View nextView = this._enclosing.getChildAt(nextViewIndex);
						int nextViewHeight = nextView.getHeight();
						int nextViewTop = nextView.getTop();
						int extraScroll = this.mExtraScroll;
						if (nextPos < this.mBoundPos)
						{
							this._enclosing.smoothScrollBy(System.Math.Max(0, nextViewHeight + nextViewTop - 
								extraScroll), this.mScrollDuration);
							this.mLastSeenPos = nextPos;
							this._enclosing.post(this);
						}
						else
						{
							if (nextViewTop > extraScroll)
							{
								this._enclosing.smoothScrollBy(nextViewTop - extraScroll, this.mScrollDuration);
							}
						}
						break;
					}

					case MOVE_UP_POS:
					{
						if (firstPos == this.mLastSeenPos)
						{
							// No new views, let things keep going.
							this._enclosing.post(this);
							return;
						}
						android.view.View firstView = this._enclosing.getChildAt(0);
						if (firstView == null)
						{
							return;
						}
						int firstViewTop = firstView.getTop();
						int extraScroll = firstPos > 0 ? this.mExtraScroll : this._enclosing.mListPadding
							.top;
						this._enclosing.smoothScrollBy(firstViewTop - extraScroll, this.mScrollDuration);
						this.mLastSeenPos = firstPos;
						if (firstPos > this.mTargetPos)
						{
							this._enclosing.post(this);
						}
						break;
					}

					case MOVE_UP_BOUND:
					{
						int lastViewIndex = this._enclosing.getChildCount() - 2;
						if (lastViewIndex < 0)
						{
							return;
						}
						int lastPos = firstPos + lastViewIndex;
						if (lastPos == this.mLastSeenPos)
						{
							// No new views, let things keep going.
							this._enclosing.post(this);
							return;
						}
						android.view.View lastView = this._enclosing.getChildAt(lastViewIndex);
						int lastViewHeight = lastView.getHeight();
						int lastViewTop = lastView.getTop();
						int lastViewPixelsShowing = listHeight - lastViewTop;
						this.mLastSeenPos = lastPos;
						if (lastPos > this.mBoundPos)
						{
							this._enclosing.smoothScrollBy(-(lastViewPixelsShowing - this.mExtraScroll), this
								.mScrollDuration);
							this._enclosing.post(this);
						}
						else
						{
							int bottom = listHeight - this.mExtraScroll;
							int lastViewBottom = lastViewTop + lastViewHeight;
							if (bottom > lastViewBottom)
							{
								this._enclosing.smoothScrollBy(-(bottom - lastViewBottom), this.mScrollDuration);
							}
						}
						break;
					}

					case MOVE_OFFSET:
					{
						if (this.mLastSeenPos == firstPos)
						{
							// No new views, let things keep going.
							this._enclosing.post(this);
							return;
						}
						this.mLastSeenPos = firstPos;
						int childCount = this._enclosing.getChildCount();
						int position = this.mTargetPos;
						int lastPos = firstPos + childCount - 1;
						int viewTravelCount = 0;
						if (position < firstPos)
						{
							viewTravelCount = firstPos - position + 1;
						}
						else
						{
							if (position > lastPos)
							{
								viewTravelCount = position - lastPos;
							}
						}
						// Estimate how many screens we should travel
						float screenTravelCount = (float)viewTravelCount / childCount;
						float modifier = System.Math.Min(System.Math.Abs(screenTravelCount), 1.0f);
						if (position < firstPos)
						{
							this._enclosing.smoothScrollBy((int)(-this._enclosing.getHeight() * modifier), this
								.mScrollDuration);
							this._enclosing.post(this);
						}
						else
						{
							if (position > lastPos)
							{
								this._enclosing.smoothScrollBy((int)(this._enclosing.getHeight() * modifier), this
									.mScrollDuration);
								this._enclosing.post(this);
							}
							else
							{
								// On-screen, just scroll.
								int targetTop = this._enclosing.getChildAt(position - firstPos).getTop();
								int distance = targetTop - this.mOffsetFromTop;
								this._enclosing.smoothScrollBy(distance, (int)(this.mScrollDuration * ((float)distance
									 / this._enclosing.getHeight())));
							}
						}
						break;
					}

					default:
					{
						break;
					}
				}
			}

			private readonly AbsListView _enclosing;
		}

		/// <summary>The amount of friction applied to flings.</summary>
		/// <remarks>
		/// The amount of friction applied to flings. The default value
		/// is
		/// <see cref="android.view.ViewConfiguration.getScrollFriction()">android.view.ViewConfiguration.getScrollFriction()
		/// 	</see>
		/// .
		/// </remarks>
		/// <returns>
		/// A scalar dimensionless value representing the coefficient of
		/// friction.
		/// </returns>
		public virtual void setFriction(float friction)
		{
			if (mFlingRunnable == null)
			{
				mFlingRunnable = new android.widget.AbsListView.FlingRunnable(this);
			}
			mFlingRunnable.mScroller.setFriction(friction);
		}

		/// <summary>Sets a scale factor for the fling velocity.</summary>
		/// <remarks>
		/// Sets a scale factor for the fling velocity. The initial scale
		/// factor is 1.0.
		/// </remarks>
		/// <param name="scale">The scale factor to multiply the velocity by.</param>
		public virtual void setVelocityScale(float scale)
		{
			mVelocityScale = scale;
		}

		/// <summary>Smoothly scroll to the specified adapter position.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position. The view will
		/// scroll such that the indicated position is displayed.
		/// </remarks>
		/// <param name="position">Scroll to this adapter position.</param>
		public virtual void smoothScrollToPosition(int position)
		{
			if (mPositionScroller == null)
			{
				mPositionScroller = new android.widget.AbsListView.PositionScroller(this);
			}
			mPositionScroller.start(position);
		}

		/// <summary>Smoothly scroll to the specified adapter position.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position. The view will scroll
		/// such that the indicated position is displayed <code>offset</code> pixels from
		/// the top edge of the view. If this is impossible, (e.g. the offset would scroll
		/// the first or last item beyond the boundaries of the list) it will get as close
		/// as possible. The scroll will take <code>duration</code> milliseconds to complete.
		/// </remarks>
		/// <param name="position">Position to scroll to</param>
		/// <param name="offset">
		/// Desired distance in pixels of <code>position</code> from the top
		/// of the view when scrolling is finished
		/// </param>
		/// <param name="duration">Number of milliseconds to use for the scroll</param>
		public virtual void smoothScrollToPositionFromTop(int position, int offset, int duration
			)
		{
			if (mPositionScroller == null)
			{
				mPositionScroller = new android.widget.AbsListView.PositionScroller(this);
			}
			mPositionScroller.startWithOffset(position, offset, duration);
		}

		/// <summary>Smoothly scroll to the specified adapter position.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position. The view will scroll
		/// such that the indicated position is displayed <code>offset</code> pixels from
		/// the top edge of the view. If this is impossible, (e.g. the offset would scroll
		/// the first or last item beyond the boundaries of the list) it will get as close
		/// as possible.
		/// </remarks>
		/// <param name="position">Position to scroll to</param>
		/// <param name="offset">
		/// Desired distance in pixels of <code>position</code> from the top
		/// of the view when scrolling is finished
		/// </param>
		public virtual void smoothScrollToPositionFromTop(int position, int offset)
		{
			if (mPositionScroller == null)
			{
				mPositionScroller = new android.widget.AbsListView.PositionScroller(this);
			}
			mPositionScroller.startWithOffset(position, offset);
		}

		/// <summary>Smoothly scroll to the specified adapter position.</summary>
		/// <remarks>
		/// Smoothly scroll to the specified adapter position. The view will
		/// scroll such that the indicated position is displayed, but it will
		/// stop early if scrolling further would scroll boundPosition out of
		/// view.
		/// </remarks>
		/// <param name="position">Scroll to this adapter position.</param>
		/// <param name="boundPosition">
		/// Do not scroll if it would move this adapter
		/// position out of view.
		/// </param>
		public virtual void smoothScrollToPosition(int position, int boundPosition)
		{
			if (mPositionScroller == null)
			{
				mPositionScroller = new android.widget.AbsListView.PositionScroller(this);
			}
			mPositionScroller.start(position, boundPosition);
		}

		/// <summary>Smoothly scroll by distance pixels over duration milliseconds.</summary>
		/// <remarks>Smoothly scroll by distance pixels over duration milliseconds.</remarks>
		/// <param name="distance">Distance to scroll in pixels.</param>
		/// <param name="duration">Duration of the scroll animation in milliseconds.</param>
		public virtual void smoothScrollBy(int distance, int duration)
		{
			if (mFlingRunnable == null)
			{
				mFlingRunnable = new android.widget.AbsListView.FlingRunnable(this);
			}
			// No sense starting to scroll if we're not going anywhere
			int firstPos = mFirstPosition;
			int childCount = getChildCount();
			int lastPos = firstPos + childCount;
			int topLimit = getPaddingTop();
			int bottomLimit = getHeight() - getPaddingBottom();
			if (distance == 0 || mItemCount == 0 || childCount == 0 || (firstPos == 0 && getChildAt
				(0).getTop() == topLimit && distance < 0) || (lastPos == mItemCount - 1 && getChildAt
				(childCount - 1).getBottom() == bottomLimit && distance > 0))
			{
				mFlingRunnable.endFling();
				if (mPositionScroller != null)
				{
					mPositionScroller.stop();
				}
			}
			else
			{
				reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_FLING
					);
				mFlingRunnable.startScroll(distance, duration);
			}
		}

		/// <summary>Allows RemoteViews to scroll relatively to a position.</summary>
		/// <remarks>Allows RemoteViews to scroll relatively to a position.</remarks>
		internal virtual void smoothScrollByOffset(int position)
		{
			int index = -1;
			if (position < 0)
			{
				index = getFirstVisiblePosition();
			}
			else
			{
				if (position > 0)
				{
					index = getLastVisiblePosition();
				}
			}
			if (index > -1)
			{
				android.view.View child = getChildAt(index - getFirstVisiblePosition());
				if (child != null)
				{
					android.graphics.Rect visibleRect = new android.graphics.Rect();
					if (child.getGlobalVisibleRect(visibleRect))
					{
						// the child is partially visible
						int childRectArea = child.getWidth() * child.getHeight();
						int visibleRectArea = visibleRect.width() * visibleRect.height();
						float visibleArea = (visibleRectArea / (float)childRectArea);
						float visibleThreshold = 0.75f;
						if ((position < 0) && (visibleArea < visibleThreshold))
						{
							// the top index is not perceivably visible so offset
							// to account for showing that top index as well
							++index;
						}
						else
						{
							if ((position > 0) && (visibleArea < visibleThreshold))
							{
								// the bottom index is not perceivably visible so offset
								// to account for showing that bottom index as well
								--index;
							}
						}
					}
					smoothScrollToPosition(System.Math.Max(0, System.Math.Min(getCount(), index + position
						)));
				}
			}
		}

		private void createScrollingCache()
		{
			if (mScrollingCacheEnabled && !mCachingStarted)
			{
				setChildrenDrawnWithCacheEnabled(true);
				setChildrenDrawingCacheEnabled(true);
				mCachingStarted = mCachingActive = true;
			}
		}

		private sealed class _Runnable_4379 : java.lang.Runnable
		{
			public _Runnable_4379(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				if (this._enclosing.mCachingStarted)
				{
					this._enclosing.mCachingStarted = this._enclosing.mCachingActive = false;
					this._enclosing.setChildrenDrawnWithCacheEnabled(false);
					if ((this._enclosing.mPersistentDrawingCache & android.view.ViewGroup.PERSISTENT_SCROLLING_CACHE
						) == 0)
					{
						this._enclosing.setChildrenDrawingCacheEnabled(false);
					}
					if (!this._enclosing.isAlwaysDrawnWithCacheEnabled())
					{
						this._enclosing.invalidate();
					}
				}
			}

			private readonly AbsListView _enclosing;
		}

		private void clearScrollingCache()
		{
			if (mClearScrollingCache == null)
			{
				mClearScrollingCache = new _Runnable_4379(this);
			}
			post(mClearScrollingCache);
		}

		/// <summary>Track a motion scroll</summary>
		/// <param name="deltaY">
		/// Amount to offset mMotionView. This is the accumulated delta since the motion
		/// began. Positive numbers mean the user's finger is moving down the screen.
		/// </param>
		/// <param name="incrementalDeltaY">Change in deltaY from the previous event.</param>
		/// <returns>true if we're already at the beginning/end of the list and have nothing to do.
		/// 	</returns>
		internal virtual bool trackMotionScroll(int deltaY, int incrementalDeltaY)
		{
			int childCount = getChildCount();
			if (childCount == 0)
			{
				return true;
			}
			int firstTop = getChildAt(0).getTop();
			int lastBottom = getChildAt(childCount - 1).getBottom();
			android.graphics.Rect listPadding = mListPadding;
			// "effective padding" In this case is the amount of padding that affects
			// how much space should not be filled by items. If we don't clip to padding
			// there is no effective padding.
			int effectivePaddingTop = 0;
			int effectivePaddingBottom = 0;
			if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
			{
				effectivePaddingTop = listPadding.top;
				effectivePaddingBottom = listPadding.bottom;
			}
			// FIXME account for grid vertical spacing too?
			int spaceAbove = effectivePaddingTop - firstTop;
			int end = getHeight() - effectivePaddingBottom;
			int spaceBelow = lastBottom - end;
			int height = getHeight() - mPaddingBottom - mPaddingTop;
			if (deltaY < 0)
			{
				deltaY = System.Math.Max(-(height - 1), deltaY);
			}
			else
			{
				deltaY = System.Math.Min(height - 1, deltaY);
			}
			if (incrementalDeltaY < 0)
			{
				incrementalDeltaY = System.Math.Max(-(height - 1), incrementalDeltaY);
			}
			else
			{
				incrementalDeltaY = System.Math.Min(height - 1, incrementalDeltaY);
			}
			int firstPosition = mFirstPosition;
			// Update our guesses for where the first and last views are
			if (firstPosition == 0)
			{
				mFirstPositionDistanceGuess = firstTop - listPadding.top;
			}
			else
			{
				mFirstPositionDistanceGuess += incrementalDeltaY;
			}
			if (firstPosition + childCount == mItemCount)
			{
				mLastPositionDistanceGuess = lastBottom + listPadding.bottom;
			}
			else
			{
				mLastPositionDistanceGuess += incrementalDeltaY;
			}
			bool cannotScrollDown = (firstPosition == 0 && firstTop >= listPadding.top && incrementalDeltaY
				 >= 0);
			bool cannotScrollUp = (firstPosition + childCount == mItemCount && lastBottom <= 
				getHeight() - listPadding.bottom && incrementalDeltaY <= 0);
			if (cannotScrollDown || cannotScrollUp)
			{
				return incrementalDeltaY != 0;
			}
			bool down = incrementalDeltaY < 0;
			bool inTouchMode = isInTouchMode();
			if (inTouchMode)
			{
				hideSelector();
			}
			int headerViewsCount = getHeaderViewsCount();
			int footerViewsStart = mItemCount - getFooterViewsCount();
			int start = 0;
			int count = 0;
			if (down)
			{
				int top = -incrementalDeltaY;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					top += listPadding.top;
				}
				{
					for (int i = 0; i < childCount; i++)
					{
						android.view.View child = getChildAt(i);
						if (child.getBottom() >= top)
						{
							break;
						}
						else
						{
							count++;
							int position = firstPosition + i;
							if (position >= headerViewsCount && position < footerViewsStart)
							{
								mRecycler.addScrapView(child, position);
							}
						}
					}
				}
			}
			else
			{
				int bottom = getHeight() - incrementalDeltaY;
				if ((mGroupFlags & CLIP_TO_PADDING_MASK) == CLIP_TO_PADDING_MASK)
				{
					bottom -= listPadding.bottom;
				}
				{
					for (int i = childCount - 1; i >= 0; i--)
					{
						android.view.View child = getChildAt(i);
						if (child.getTop() <= bottom)
						{
							break;
						}
						else
						{
							start = i;
							count++;
							int position = firstPosition + i;
							if (position >= headerViewsCount && position < footerViewsStart)
							{
								mRecycler.addScrapView(child, position);
							}
						}
					}
				}
			}
			mMotionViewNewTop = mMotionViewOriginalTop + deltaY;
			mBlockLayoutRequests = true;
			if (count > 0)
			{
				detachViewsFromParent(start, count);
			}
			offsetChildrenTopAndBottom(incrementalDeltaY);
			if (down)
			{
				mFirstPosition += count;
			}
			invalidate();
			int absIncrementalDeltaY = System.Math.Abs(incrementalDeltaY);
			if (spaceAbove < absIncrementalDeltaY || spaceBelow < absIncrementalDeltaY)
			{
				fillGap(down);
			}
			if (!inTouchMode && mSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
			{
				int childIndex = mSelectedPosition - mFirstPosition;
				if (childIndex >= 0 && childIndex < getChildCount())
				{
					positionSelector(mSelectedPosition, getChildAt(childIndex));
				}
			}
			else
			{
				if (mSelectorPosition != android.widget.AdapterView.INVALID_POSITION)
				{
					int childIndex = mSelectorPosition - mFirstPosition;
					if (childIndex >= 0 && childIndex < getChildCount())
					{
						positionSelector(android.widget.AdapterView.INVALID_POSITION, getChildAt(childIndex
							));
					}
				}
				else
				{
					mSelectorRect.setEmpty();
				}
			}
			mBlockLayoutRequests = false;
			invokeOnItemScrollListener();
			awakenScrollBars();
			return false;
		}

		/// <summary>Returns the number of header views in the list.</summary>
		/// <remarks>
		/// Returns the number of header views in the list. Header views are special views
		/// at the top of the list that should not be recycled during a layout.
		/// </remarks>
		/// <returns>The number of header views, 0 in the default implementation.</returns>
		internal virtual int getHeaderViewsCount()
		{
			return 0;
		}

		/// <summary>Returns the number of footer views in the list.</summary>
		/// <remarks>
		/// Returns the number of footer views in the list. Footer views are special views
		/// at the bottom of the list that should not be recycled during a layout.
		/// </remarks>
		/// <returns>The number of footer views, 0 in the default implementation.</returns>
		internal virtual int getFooterViewsCount()
		{
			return 0;
		}

		/// <summary>Fills the gap left open by a touch-scroll.</summary>
		/// <remarks>
		/// Fills the gap left open by a touch-scroll. During a touch scroll, children that
		/// remain on screen are shifted and the other ones are discarded. The role of this
		/// method is to fill the gap thus created by performing a partial layout in the
		/// empty space.
		/// </remarks>
		/// <param name="down">true if the scroll is going down, false if it is going up</param>
		internal abstract void fillGap(bool down);

		internal virtual void hideSelector()
		{
			if (mSelectedPosition != android.widget.AdapterView.INVALID_POSITION)
			{
				if (mLayoutMode != LAYOUT_SPECIFIC)
				{
					mResurrectToPosition = mSelectedPosition;
				}
				if (mNextSelectedPosition >= 0 && mNextSelectedPosition != mSelectedPosition)
				{
					mResurrectToPosition = mNextSelectedPosition;
				}
				setSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
				setNextSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
				mSelectedTop = 0;
			}
		}

		/// <returns>
		/// A position to select. First we try mSelectedPosition. If that has been clobbered by
		/// entering touch mode, we then try mResurrectToPosition. Values are pinned to the range
		/// of items available in the adapter
		/// </returns>
		internal virtual int reconcileSelectedPosition()
		{
			int position = mSelectedPosition;
			if (position < 0)
			{
				position = mResurrectToPosition;
			}
			position = System.Math.Max(0, position);
			position = System.Math.Min(position, mItemCount - 1);
			return position;
		}

		/// <summary>Find the row closest to y.</summary>
		/// <remarks>Find the row closest to y. This row will be used as the motion row when scrolling
		/// 	</remarks>
		/// <param name="y">Where the user touched</param>
		/// <returns>The position of the first (or only) item in the row containing y</returns>
		internal abstract int findMotionRow(int y);

		/// <summary>Find the row closest to y.</summary>
		/// <remarks>Find the row closest to y. This row will be used as the motion row when scrolling.
		/// 	</remarks>
		/// <param name="y">Where the user touched</param>
		/// <returns>The position of the first (or only) item in the row closest to y</returns>
		internal virtual int findClosestMotionRow(int y)
		{
			int childCount = getChildCount();
			if (childCount == 0)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			int motionRow = findMotionRow(y);
			return motionRow != android.widget.AdapterView.INVALID_POSITION ? motionRow : mFirstPosition
				 + childCount - 1;
		}

		/// <summary>Causes all the views to be rebuilt and redrawn.</summary>
		/// <remarks>Causes all the views to be rebuilt and redrawn.</remarks>
		public virtual void invalidateViews()
		{
			mDataChanged = true;
			rememberSyncState();
			requestLayout();
			invalidate();
		}

		/// <summary>If there is a selection returns false.</summary>
		/// <remarks>
		/// If there is a selection returns false.
		/// Otherwise resurrects the selection and returns true if resurrected.
		/// </remarks>
		internal virtual bool resurrectSelectionIfNeeded()
		{
			if (mSelectedPosition < 0 && resurrectSelection())
			{
				updateSelectorState();
				return true;
			}
			return false;
		}

		/// <summary>Makes the item at the supplied position selected.</summary>
		/// <remarks>Makes the item at the supplied position selected.</remarks>
		/// <param name="position">the position of the new selection</param>
		internal abstract void setSelectionInt(int position);

		/// <summary>
		/// Attempt to bring the selection back if the user is switching from touch
		/// to trackball mode
		/// </summary>
		/// <returns>Whether selection was set to something.</returns>
		internal virtual bool resurrectSelection()
		{
			int childCount = getChildCount();
			if (childCount <= 0)
			{
				return false;
			}
			int selectedTop = 0;
			int selectedPos;
			int childrenTop = mListPadding.top;
			int childrenBottom = mBottom - mTop - mListPadding.bottom;
			int firstPosition = mFirstPosition;
			int toPosition = mResurrectToPosition;
			bool down = true;
			if (toPosition >= firstPosition && toPosition < firstPosition + childCount)
			{
				selectedPos = toPosition;
				android.view.View selected = getChildAt(selectedPos - mFirstPosition);
				selectedTop = selected.getTop();
				int selectedBottom = selected.getBottom();
				// We are scrolled, don't get in the fade
				if (selectedTop < childrenTop)
				{
					selectedTop = childrenTop + getVerticalFadingEdgeLength();
				}
				else
				{
					if (selectedBottom > childrenBottom)
					{
						selectedTop = childrenBottom - selected.getMeasuredHeight() - getVerticalFadingEdgeLength
							();
					}
				}
			}
			else
			{
				if (toPosition < firstPosition)
				{
					// Default to selecting whatever is first
					selectedPos = firstPosition;
					{
						for (int i = 0; i < childCount; i++)
						{
							android.view.View v = getChildAt(i);
							int top = v.getTop();
							if (i == 0)
							{
								// Remember the position of the first item
								selectedTop = top;
								// See if we are scrolled at all
								if (firstPosition > 0 || top < childrenTop)
								{
									// If we are scrolled, don't select anything that is
									// in the fade region
									childrenTop += getVerticalFadingEdgeLength();
								}
							}
							if (top >= childrenTop)
							{
								// Found a view whose top is fully visisble
								selectedPos = firstPosition + i;
								selectedTop = top;
								break;
							}
						}
					}
				}
				else
				{
					int itemCount = mItemCount;
					down = false;
					selectedPos = firstPosition + childCount - 1;
					{
						for (int i = childCount - 1; i >= 0; i--)
						{
							android.view.View v = getChildAt(i);
							int top = v.getTop();
							int bottom = v.getBottom();
							if (i == childCount - 1)
							{
								selectedTop = top;
								if (firstPosition + childCount < itemCount || bottom > childrenBottom)
								{
									childrenBottom -= getVerticalFadingEdgeLength();
								}
							}
							if (bottom <= childrenBottom)
							{
								selectedPos = firstPosition + i;
								selectedTop = top;
								break;
							}
						}
					}
				}
			}
			mResurrectToPosition = android.widget.AdapterView.INVALID_POSITION;
			removeCallbacks(mFlingRunnable);
			if (mPositionScroller != null)
			{
				mPositionScroller.stop();
			}
			mTouchMode = TOUCH_MODE_REST;
			clearScrollingCache();
			mSpecificTop = selectedTop;
			selectedPos = lookForSelectablePosition(selectedPos, down);
			if (selectedPos >= firstPosition && selectedPos <= getLastVisiblePosition())
			{
				mLayoutMode = LAYOUT_SPECIFIC;
				updateSelectorState();
				setSelectionInt(selectedPos);
				invokeOnItemScrollListener();
			}
			else
			{
				selectedPos = android.widget.AdapterView.INVALID_POSITION;
			}
			reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
				);
			return selectedPos >= 0;
		}

		internal virtual void confirmCheckedPositionsById()
		{
			// Clear out the positional check states, we'll rebuild it below from IDs.
			mCheckStates.clear();
			bool checkedCountChanged = false;
			{
				for (int checkedIndex = 0; checkedIndex < mCheckedIdStates.size(); checkedIndex++)
				{
					long id = mCheckedIdStates.keyAt(checkedIndex);
					int lastPos = mCheckedIdStates.valueAt(checkedIndex);
					long lastPosId = mAdapter.getItemId(lastPos);
					if (id != lastPosId)
					{
						// Look around to see if the ID is nearby. If not, uncheck it.
						int start = System.Math.Max(0, lastPos - CHECK_POSITION_SEARCH_DISTANCE);
						int end = System.Math.Min(lastPos + CHECK_POSITION_SEARCH_DISTANCE, mItemCount);
						bool found = false;
						{
							for (int searchPos = start; searchPos < end; searchPos++)
							{
								long searchId = mAdapter.getItemId(searchPos);
								if (id == searchId)
								{
									found = true;
									mCheckStates.put(searchPos, true);
									mCheckedIdStates.setValueAt(checkedIndex, searchPos);
									break;
								}
							}
						}
						if (!found)
						{
							mCheckedIdStates.delete(id);
							checkedIndex--;
							mCheckedItemCount--;
							checkedCountChanged = true;
							if (mChoiceActionMode != null && mMultiChoiceModeCallback != null)
							{
								mMultiChoiceModeCallback.onItemCheckedStateChanged(mChoiceActionMode, lastPos, id
									, false);
							}
						}
					}
					else
					{
						mCheckStates.put(lastPos, true);
					}
				}
			}
			if (checkedCountChanged && mChoiceActionMode != null)
			{
				mChoiceActionMode.invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override void handleDataChanged()
		{
			int count = mItemCount;
			int lastHandledItemCount = mLastHandledItemCount;
			mLastHandledItemCount = mItemCount;
			if (mChoiceMode != CHOICE_MODE_NONE && mAdapter != null && mAdapter.hasStableIds(
				))
			{
				confirmCheckedPositionsById();
			}
			if (count > 0)
			{
				int newPos;
				int selectablePos;
				// Find the row we are supposed to sync to
				if (mNeedSync)
				{
					// Update this first, since setNextSelectedPositionInt inspects it
					mNeedSync = false;
					if (mTranscriptMode == TRANSCRIPT_MODE_ALWAYS_SCROLL)
					{
						mLayoutMode = LAYOUT_FORCE_BOTTOM;
						return;
					}
					else
					{
						if (mTranscriptMode == TRANSCRIPT_MODE_NORMAL)
						{
							if (mForceTranscriptScroll)
							{
								mForceTranscriptScroll = false;
								mLayoutMode = LAYOUT_FORCE_BOTTOM;
								return;
							}
							int childCount = getChildCount();
							int listBottom = getHeight() - getPaddingBottom();
							android.view.View lastChild = getChildAt(childCount - 1);
							int lastBottom = lastChild != null ? lastChild.getBottom() : listBottom;
							if (mFirstPosition + childCount >= lastHandledItemCount && lastBottom <= listBottom)
							{
								mLayoutMode = LAYOUT_FORCE_BOTTOM;
								return;
							}
							// Something new came in and we didn't scroll; give the user a clue that
							// there's something new.
							awakenScrollBars();
						}
					}
					switch (mSyncMode)
					{
						case android.widget.AdapterView.SYNC_SELECTED_POSITION:
						{
							if (isInTouchMode())
							{
								// We saved our state when not in touch mode. (We know this because
								// mSyncMode is SYNC_SELECTED_POSITION.) Now we are trying to
								// restore in touch mode. Just leave mSyncPosition as it is (possibly
								// adjusting if the available range changed) and return.
								mLayoutMode = LAYOUT_SYNC;
								mSyncPosition = System.Math.Min(System.Math.Max(0, mSyncPosition), count - 1);
								return;
							}
							else
							{
								// See if we can find a position in the new data with the same
								// id as the old selection. This will change mSyncPosition.
								newPos = findSyncPosition();
								if (newPos >= 0)
								{
									// Found it. Now verify that new selection is still selectable
									selectablePos = lookForSelectablePosition(newPos, true);
									if (selectablePos == newPos)
									{
										// Same row id is selected
										mSyncPosition = newPos;
										if (mSyncHeight == getHeight())
										{
											// If we are at the same height as when we saved state, try
											// to restore the scroll position too.
											mLayoutMode = LAYOUT_SYNC;
										}
										else
										{
											// We are not the same height as when the selection was saved, so
											// don't try to restore the exact position
											mLayoutMode = LAYOUT_SET_SELECTION;
										}
										// Restore selection
										setNextSelectedPositionInt(newPos);
										return;
									}
								}
							}
							break;
						}

						case android.widget.AdapterView.SYNC_FIRST_POSITION:
						{
							// Leave mSyncPosition as it is -- just pin to available range
							mLayoutMode = LAYOUT_SYNC;
							mSyncPosition = System.Math.Min(System.Math.Max(0, mSyncPosition), count - 1);
							return;
						}
					}
				}
				if (!isInTouchMode())
				{
					// We couldn't find matching data -- try to use the same position
					newPos = getSelectedItemPosition();
					// Pin position to the available range
					if (newPos >= count)
					{
						newPos = count - 1;
					}
					if (newPos < 0)
					{
						newPos = 0;
					}
					// Make sure we select something selectable -- first look down
					selectablePos = lookForSelectablePosition(newPos, true);
					if (selectablePos >= 0)
					{
						setNextSelectedPositionInt(selectablePos);
						return;
					}
					else
					{
						// Looking down didn't work -- try looking up
						selectablePos = lookForSelectablePosition(newPos, false);
						if (selectablePos >= 0)
						{
							setNextSelectedPositionInt(selectablePos);
							return;
						}
					}
				}
				else
				{
					// We already know where we want to resurrect the selection
					if (mResurrectToPosition >= 0)
					{
						return;
					}
				}
			}
			// Nothing is selected. Give up and reset everything.
			mLayoutMode = mStackFromBottom ? LAYOUT_FORCE_BOTTOM : LAYOUT_FORCE_TOP;
			mSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			mNextSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mNextSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			mNeedSync = false;
			mSelectorPosition = android.widget.AdapterView.INVALID_POSITION;
			checkSelectionChanged();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDisplayHint(int hint)
		{
			base.onDisplayHint(hint);
			switch (hint)
			{
				case INVISIBLE:
				{
					if (mPopup != null && mPopup.isShowing())
					{
						dismissPopup();
					}
					break;
				}

				case VISIBLE:
				{
					if (mFiltered && mPopup != null && !mPopup.isShowing())
					{
						showPopup();
					}
					break;
				}
			}
			mPopupHidden = hint == INVISIBLE;
		}

		/// <summary>Removes the filter window</summary>
		private void dismissPopup()
		{
			if (mPopup != null)
			{
				mPopup.dismiss();
			}
		}

		/// <summary>Shows the filter window</summary>
		private void showPopup()
		{
			// Make sure we have a window before showing the popup
			if (getWindowVisibility() == android.view.View.VISIBLE)
			{
				createTextFilter(true);
				positionPopup();
				// Make sure we get focus if we are showing the popup
				checkFocus();
			}
		}

		private void positionPopup()
		{
			int screenHeight = getResources().getDisplayMetrics().heightPixels;
			int[] xy = new int[2];
			getLocationOnScreen(xy);
			// TODO: The 20 below should come from the theme
			// TODO: And the gravity should be defined in the theme as well
			int bottomGap = screenHeight - xy[1] - getHeight() + (int)(mDensityScale * 20);
			if (!mPopup.isShowing())
			{
				mPopup.showAtLocation(this, android.view.Gravity.BOTTOM | android.view.Gravity.CENTER_HORIZONTAL
					, xy[0], bottomGap);
			}
			else
			{
				mPopup.update(xy[0], bottomGap, -1, -1);
			}
		}

		/// <summary>
		/// What is the distance between the source and destination rectangles given the direction of
		/// focus navigation between them? The direction basically helps figure out more quickly what is
		/// self evident by the relationship between the rects...
		/// </summary>
		/// <remarks>
		/// What is the distance between the source and destination rectangles given the direction of
		/// focus navigation between them? The direction basically helps figure out more quickly what is
		/// self evident by the relationship between the rects...
		/// </remarks>
		/// <param name="source">the source rectangle</param>
		/// <param name="dest">the destination rectangle</param>
		/// <param name="direction">the direction</param>
		/// <returns>the distance between the rectangles</returns>
		internal static int getDistance(android.graphics.Rect source, android.graphics.Rect
			 dest, int direction)
		{
			int sX;
			int sY;
			// source x, y
			int dX;
			int dY;
			switch (direction)
			{
				case android.view.View.FOCUS_RIGHT:
				{
					// dest x, y
					sX = source.right;
					sY = source.top + source.height() / 2;
					dX = dest.left;
					dY = dest.top + dest.height() / 2;
					break;
				}

				case android.view.View.FOCUS_DOWN:
				{
					sX = source.left + source.width() / 2;
					sY = source.bottom;
					dX = dest.left + dest.width() / 2;
					dY = dest.top;
					break;
				}

				case android.view.View.FOCUS_LEFT:
				{
					sX = source.left;
					sY = source.top + source.height() / 2;
					dX = dest.right;
					dY = dest.top + dest.height() / 2;
					break;
				}

				case android.view.View.FOCUS_UP:
				{
					sX = source.left + source.width() / 2;
					sY = source.top;
					dX = dest.left + dest.width() / 2;
					dY = dest.bottom;
					break;
				}

				case android.view.View.FOCUS_FORWARD:
				case android.view.View.FOCUS_BACKWARD:
				{
					sX = source.right + source.width() / 2;
					sY = source.top + source.height() / 2;
					dX = dest.left + dest.width() / 2;
					dY = dest.top + dest.height() / 2;
					break;
				}

				default:
				{
					throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT, "
						 + "FOCUS_FORWARD, FOCUS_BACKWARD}.");
				}
			}
			int deltaX = dX - sX;
			int deltaY = dY - sY;
			return deltaY * deltaY + deltaX * deltaX;
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		internal override bool isInFilterMode()
		{
			return mFiltered;
		}

		/// <summary>Sends a key to the text filter window</summary>
		/// <param name="keyCode">The keycode for the event</param>
		/// <param name="event">The actual key event</param>
		/// <returns>True if the text filter handled the event, false otherwise.</returns>
		internal virtual bool sendToTextFilter(int keyCode, int count, android.view.KeyEvent
			 @event)
		{
			if (!acceptFilter())
			{
				return false;
			}
			bool handled = false;
			bool okToSend = true;
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_UP:
				case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
				case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
				case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				case android.view.KeyEvent.KEYCODE_ENTER:
				{
					okToSend = false;
					break;
				}

				case android.view.KeyEvent.KEYCODE_BACK:
				{
					if (mFiltered && mPopup != null && mPopup.isShowing())
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
							() == 0)
						{
							android.view.KeyEvent.DispatcherState state = getKeyDispatcherState();
							if (state != null)
							{
								state.startTracking(@event, this);
							}
							handled = true;
						}
						else
						{
							if (@event.getAction() == android.view.KeyEvent.ACTION_UP && @event.isTracking() 
								&& !@event.isCanceled())
							{
								handled = true;
								mTextFilter.setText(java.lang.CharSequenceProxy.Wrap(string.Empty));
							}
						}
					}
					okToSend = false;
					break;
				}

				case android.view.KeyEvent.KEYCODE_SPACE:
				{
					// Only send spaces once we are filtered
					okToSend = mFiltered;
					break;
				}
			}
			if (okToSend)
			{
				createTextFilter(true);
				android.view.KeyEvent forwardEvent = @event;
				if (forwardEvent.getRepeatCount() > 0)
				{
					forwardEvent = android.view.KeyEvent.changeTimeRepeat(@event, @event.getEventTime
						(), 0);
				}
				int action = @event.getAction();
				switch (action)
				{
					case android.view.KeyEvent.ACTION_DOWN:
					{
						handled = mTextFilter.onKeyDown(keyCode, forwardEvent);
						break;
					}

					case android.view.KeyEvent.ACTION_UP:
					{
						handled = mTextFilter.onKeyUp(keyCode, forwardEvent);
						break;
					}

					case android.view.KeyEvent.ACTION_MULTIPLE:
					{
						handled = mTextFilter.onKeyMultiple(keyCode, count, @event);
						break;
					}
				}
			}
			return handled;
		}

		private sealed class _InputConnectionWrapper_5173 : android.view.inputmethod.InputConnectionWrapper
		{
			public _InputConnectionWrapper_5173(AbsListView _enclosing, android.view.inputmethod.InputConnection
				 baseArg1, bool baseArg2) : base(baseArg1, baseArg2)
			{
				this._enclosing = _enclosing;
			}

			// XXX we need to have the text filter created, so we can get an
			// InputConnection to proxy to.  Unfortunately this means we pretty
			// much need to make it as soon as a list view gets focus.
			[Sharpen.OverridesMethod(@"android.view.inputmethod.InputConnectionWrapper")]
			public override bool reportFullscreenMode(bool enabled)
			{
				// Use our own input connection, since it is
				// the "real" one the IME is talking with.
				return this._enclosing.mDefInputConnection.reportFullscreenMode(enabled);
			}

			[Sharpen.OverridesMethod(@"android.view.inputmethod.InputConnectionWrapper")]
			public override bool performEditorAction(int editorAction)
			{
				// The editor is off in its own window; we need to be
				// the one that does this.
				if (editorAction == android.view.inputmethod.EditorInfo.IME_ACTION_DONE)
				{
					android.view.inputmethod.InputMethodManager imm = (android.view.inputmethod.InputMethodManager
						)this._enclosing.getContext().getSystemService(android.content.Context.INPUT_METHOD_SERVICE
						);
					if (imm != null)
					{
						imm.hideSoftInputFromWindow(this._enclosing.getWindowToken(), 0);
					}
					return true;
				}
				return false;
			}

			[Sharpen.OverridesMethod(@"android.view.inputmethod.InputConnectionWrapper")]
			public override bool sendKeyEvent(android.view.KeyEvent @event)
			{
				// Use our own input connection, since the filter
				// text view may not be shown in a window so has
				// no ViewAncestor to dispatch events with.
				return this._enclosing.mDefInputConnection.sendKeyEvent(@event);
			}

			private readonly AbsListView _enclosing;
		}

		/// <summary>Return an InputConnection for editing of the filter text.</summary>
		/// <remarks>Return an InputConnection for editing of the filter text.</remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override android.view.inputmethod.InputConnection onCreateInputConnection(
			android.view.inputmethod.EditorInfo outAttrs)
		{
			if (isTextFilterEnabled())
			{
				createTextFilter(false);
				if (mPublicInputConnection == null)
				{
					mDefInputConnection = new android.view.inputmethod.BaseInputConnection(this, false
						);
					mPublicInputConnection = new _InputConnectionWrapper_5173(this, mTextFilter.onCreateInputConnection
						(outAttrs), true);
				}
				outAttrs.inputType = android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_FILTER;
				outAttrs.imeOptions = android.view.inputmethod.EditorInfo.IME_ACTION_DONE;
				return mPublicInputConnection;
			}
			return null;
		}

		/// <summary>
		/// For filtering we proxy an input connection to an internal text editor,
		/// and this allows the proxying to happen.
		/// </summary>
		/// <remarks>
		/// For filtering we proxy an input connection to an internal text editor,
		/// and this allows the proxying to happen.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool checkInputConnectionProxy(android.view.View view)
		{
			return view == mTextFilter;
		}

		/// <summary>Creates the window for the text filter and populates it with an EditText field;
		/// 	</summary>
		/// <param name="animateEntrance">true if the window should appear with an animation</param>
		private void createTextFilter(bool animateEntrance)
		{
			if (mPopup == null)
			{
				android.content.Context c = getContext();
				android.widget.PopupWindow p = new android.widget.PopupWindow(c);
				android.view.LayoutInflater layoutInflater = (android.view.LayoutInflater)c.getSystemService
					(android.content.Context.LAYOUT_INFLATER_SERVICE);
				mTextFilter = (android.widget.EditText)layoutInflater.inflate(android.@internal.R
					.layout.typing_filter, null);
				// For some reason setting this as the "real" input type changes
				// the text view in some way that it doesn't work, and I don't
				// want to figure out why this is.
				mTextFilter.setRawInputType(android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_VARIATION_FILTER
					);
				mTextFilter.setImeOptions(android.view.inputmethod.EditorInfo.IME_FLAG_NO_EXTRACT_UI
					);
				mTextFilter.addTextChangedListener(this);
				p.setFocusable(false);
				p.setTouchable(false);
				p.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED);
				p.setContentView(mTextFilter);
				p.setWidth(android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
				p.setHeight(android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
				p.setBackgroundDrawable(null);
				mPopup = p;
				getViewTreeObserver().addOnGlobalLayoutListener(this);
				mGlobalLayoutListenerAddedFilter = true;
			}
			if (animateEntrance)
			{
				mPopup.setAnimationStyle(android.@internal.R.style.Animation_TypingFilter);
			}
			else
			{
				mPopup.setAnimationStyle(android.@internal.R.style.Animation_TypingFilterRestore);
			}
		}

		/// <summary>Clear the text filter.</summary>
		/// <remarks>Clear the text filter.</remarks>
		public virtual void clearTextFilter()
		{
			if (mFiltered)
			{
				mTextFilter.setText(java.lang.CharSequenceProxy.Wrap(string.Empty));
				mFiltered = false;
				if (mPopup != null && mPopup.isShowing())
				{
					dismissPopup();
				}
			}
		}

		/// <summary>Returns if the ListView currently has a text filter.</summary>
		/// <remarks>Returns if the ListView currently has a text filter.</remarks>
		public virtual bool hasTextFilter()
		{
			return mFiltered;
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnGlobalLayoutListener"
			)]
		public virtual void onGlobalLayout()
		{
			if (isShown())
			{
				// Show the popup if we are filtered
				if (mFiltered && mPopup != null && !mPopup.isShowing() && !mPopupHidden)
				{
					showPopup();
				}
			}
			else
			{
				// Hide the popup when we are no longer visible
				if (mPopup != null && mPopup.isShowing())
				{
					dismissPopup();
				}
			}
		}

		/// <summary>For our text watcher that is associated with the text filter.</summary>
		/// <remarks>
		/// For our text watcher that is associated with the text filter.  Does
		/// nothing.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void beforeTextChanged(java.lang.CharSequence s, int start, int count
			, int after)
		{
		}

		/// <summary>For our text watcher that is associated with the text filter.</summary>
		/// <remarks>
		/// For our text watcher that is associated with the text filter. Performs
		/// the actual filtering as the text changes, and takes care of hiding and
		/// showing the popup displaying the currently entered filter text.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void onTextChanged(java.lang.CharSequence s, int start, int before
			, int count)
		{
			if (mPopup != null && isTextFilterEnabled())
			{
				int length = s.Length;
				bool showing = mPopup.isShowing();
				if (!showing && length > 0)
				{
					// Show the filter popup if necessary
					showPopup();
					mFiltered = true;
				}
				else
				{
					if (showing && length == 0)
					{
						// Remove the filter popup if the user has cleared all text
						dismissPopup();
						mFiltered = false;
					}
				}
				if (mAdapter is android.widget.Filterable)
				{
					android.widget.Filter f = ((android.widget.Filterable)mAdapter).getFilter();
					// Filter should not be null when we reach this part
					if (f != null)
					{
						f.filter(s, this);
					}
					else
					{
						throw new System.InvalidOperationException("You cannot call onTextChanged with a non "
							 + "filterable adapter");
					}
				}
			}
		}

		/// <summary>For our text watcher that is associated with the text filter.</summary>
		/// <remarks>
		/// For our text watcher that is associated with the text filter.  Does
		/// nothing.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.TextWatcher")]
		public virtual void afterTextChanged(android.text.Editable s)
		{
		}

		[Sharpen.ImplementsInterface(@"android.widget.Filter.FilterListener")]
		public virtual void onFilterComplete(int count)
		{
			if (mSelectedPosition < 0 && count > 0)
			{
				mResurrectToPosition = android.widget.AdapterView.INVALID_POSITION;
				resurrectSelection();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateLayoutParams
			(android.view.ViewGroup.LayoutParams p)
		{
			return new android.widget.AbsListView.LayoutParams(p);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ViewGroup.LayoutParams generateLayoutParams(android.util.AttributeSet
			 attrs)
		{
			return new android.widget.AbsListView.LayoutParams(getContext(), attrs);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override bool checkLayoutParams(android.view.ViewGroup.LayoutParams
			 p)
		{
			return p is android.widget.AbsListView.LayoutParams;
		}

		/// <summary>Puts the list or grid into transcript mode.</summary>
		/// <remarks>
		/// Puts the list or grid into transcript mode. In this mode the list or grid will always scroll
		/// to the bottom to show new items.
		/// </remarks>
		/// <param name="mode">the transcript mode to set</param>
		/// <seealso cref="TRANSCRIPT_MODE_DISABLED">TRANSCRIPT_MODE_DISABLED</seealso>
		/// <seealso cref="TRANSCRIPT_MODE_NORMAL">TRANSCRIPT_MODE_NORMAL</seealso>
		/// <seealso cref="TRANSCRIPT_MODE_ALWAYS_SCROLL">TRANSCRIPT_MODE_ALWAYS_SCROLL</seealso>
		public virtual void setTranscriptMode(int mode)
		{
			mTranscriptMode = mode;
		}

		/// <summary>Returns the current transcript mode.</summary>
		/// <remarks>Returns the current transcript mode.</remarks>
		/// <returns>
		/// 
		/// <see cref="TRANSCRIPT_MODE_DISABLED">TRANSCRIPT_MODE_DISABLED</see>
		/// ,
		/// <see cref="TRANSCRIPT_MODE_NORMAL">TRANSCRIPT_MODE_NORMAL</see>
		/// or
		/// <see cref="TRANSCRIPT_MODE_ALWAYS_SCROLL">TRANSCRIPT_MODE_ALWAYS_SCROLL</see>
		/// </returns>
		public virtual int getTranscriptMode()
		{
			return mTranscriptMode;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getSolidColor()
		{
			return mCacheColorHint;
		}

		/// <summary>
		/// When set to a non-zero value, the cache color hint indicates that this list is always drawn
		/// on top of a solid, single-color, opaque background.
		/// </summary>
		/// <remarks>
		/// When set to a non-zero value, the cache color hint indicates that this list is always drawn
		/// on top of a solid, single-color, opaque background.
		/// Zero means that what's behind this object is translucent (non solid) or is not made of a
		/// single color. This hint will not affect any existing background drawable set on this view (
		/// typically set via
		/// <see cref="android.view.View.setBackgroundDrawable(android.graphics.drawable.Drawable)
		/// 	">android.view.View.setBackgroundDrawable(android.graphics.drawable.Drawable)</see>
		/// ).
		/// </remarks>
		/// <param name="color">The background color</param>
		public virtual void setCacheColorHint(int color)
		{
			if (color != mCacheColorHint)
			{
				mCacheColorHint = color;
				int count = getChildCount();
				{
					for (int i = 0; i < count; i++)
					{
						getChildAt(i).setDrawingCacheBackgroundColor(color);
					}
				}
				mRecycler.setCacheColorHint(color);
			}
		}

		/// <summary>
		/// When set to a non-zero value, the cache color hint indicates that this list is always drawn
		/// on top of a solid, single-color, opaque background
		/// </summary>
		/// <returns>The cache color hint</returns>
		public virtual int getCacheColorHint()
		{
			return mCacheColorHint;
		}

		/// <summary>
		/// Move all views (excluding headers and footers) held by this AbsListView into the supplied
		/// List.
		/// </summary>
		/// <remarks>
		/// Move all views (excluding headers and footers) held by this AbsListView into the supplied
		/// List. This includes views displayed on the screen as well as views stored in AbsListView's
		/// internal view recycler.
		/// </remarks>
		/// <param name="views">A list into which to put the reclaimed views</param>
		public virtual void reclaimViews(java.util.List<android.view.View> views)
		{
			int childCount = getChildCount();
			android.widget.AbsListView.RecyclerListener listener = mRecycler.mRecyclerListener;
			{
				// Reclaim views on screen
				for (int i = 0; i < childCount; i++)
				{
					android.view.View child = getChildAt(i);
					android.widget.AbsListView.LayoutParams lp = (android.widget.AbsListView.LayoutParams
						)child.getLayoutParams();
					// Don't reclaim header or footer views, or views that should be ignored
					if (lp != null && mRecycler.shouldRecycleViewType(lp.viewType))
					{
						views.add(child);
						if (listener != null)
						{
							// Pretend they went through the scrap heap
							listener.onMovedToScrapHeap(child);
						}
					}
				}
			}
			mRecycler.reclaimScrapViews(views);
			removeAllViewsInLayout();
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool onConsistencyCheck(int consistency)
		{
			bool result = base.onConsistencyCheck(consistency);
			bool checkLayout = (consistency & android.view.ViewDebug.CONSISTENCY_LAYOUT) != 0;
			if (checkLayout)
			{
				// The active recycler must be empty
				android.view.View[] activeViews = mRecycler.mActiveViews;
				int count = activeViews.Length;
				{
					for (int i = 0; i < count; i++)
					{
						if (activeViews[i] != null)
						{
							result = false;
							android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "AbsListView " + this
								 + " has a view in its active recycler: " + activeViews[i]);
						}
					}
				}
				// All views in the recycler must NOT be on screen and must NOT have a parent
				java.util.ArrayList<android.view.View> scrap = mRecycler.mCurrentScrap;
				if (!checkScrap(scrap))
				{
					result = false;
				}
				java.util.ArrayList<android.view.View>[] scraps = mRecycler.mScrapViews;
				count = scraps.Length;
				{
					for (int i_1 = 0; i_1 < count; i_1++)
					{
						if (!checkScrap(scraps[i_1]))
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		private bool checkScrap(java.util.ArrayList<android.view.View> scrap)
		{
			if (scrap == null)
			{
				return true;
			}
			bool result = true;
			int count = scrap.size();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View view = scrap.get(i);
					if (view.getParent() != null)
					{
						result = false;
						android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "AbsListView " + this
							 + " has a view in its scrap heap still attached to a parent: " + view);
					}
					if (indexOfChild(view) >= 0)
					{
						result = false;
						android.util.Log.d(android.view.ViewDebug.CONSISTENCY_LOG_TAG, "AbsListView " + this
							 + " has a view in its scrap heap that is also a direct child: " + view);
					}
				}
			}
			return result;
		}

		private void finishGlows()
		{
			if (mEdgeGlowTop != null)
			{
				mEdgeGlowTop.finish();
				mEdgeGlowBottom.finish();
			}
		}

		/// <summary>
		/// Sets up this AbsListView to use a remote views adapter which connects to a RemoteViewsService
		/// through the specified intent.
		/// </summary>
		/// <remarks>
		/// Sets up this AbsListView to use a remote views adapter which connects to a RemoteViewsService
		/// through the specified intent.
		/// </remarks>
		/// <param name="intent">the intent used to identify the RemoteViewsService for the adapter to connect to.
		/// 	</param>
		public virtual void setRemoteViewsAdapter(android.content.Intent intent)
		{
			// Ensure that we don't already have a RemoteViewsAdapter that is bound to an existing
			// service handling the specified intent.
			if (mRemoteAdapter != null)
			{
				android.content.Intent.FilterComparison fcNew = new android.content.Intent.FilterComparison
					(intent);
				android.content.Intent.FilterComparison fcOld = new android.content.Intent.FilterComparison
					(mRemoteAdapter.getRemoteViewsServiceIntent());
				if (fcNew.Equals(fcOld))
				{
					return;
				}
			}
			mDeferNotifyDataSetChanged = false;
			// Otherwise, create a new RemoteViewsAdapter for binding
			mRemoteAdapter = new android.widget.RemoteViewsAdapter(getContext(), intent, this
				);
		}

		/// <summary>
		/// This defers a notifyDataSetChanged on the pending RemoteViewsAdapter if it has not
		/// connected yet.
		/// </summary>
		/// <remarks>
		/// This defers a notifyDataSetChanged on the pending RemoteViewsAdapter if it has not
		/// connected yet.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual void deferNotifyDataSetChanged()
		{
			mDeferNotifyDataSetChanged = true;
		}

		/// <summary>Called back when the adapter connects to the RemoteViewsService.</summary>
		/// <remarks>Called back when the adapter connects to the RemoteViewsService.</remarks>
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual bool onRemoteAdapterConnected()
		{
			if (mRemoteAdapter != mAdapter)
			{
				setAdapter(mRemoteAdapter);
				if (mDeferNotifyDataSetChanged)
				{
					mRemoteAdapter.notifyDataSetChanged();
					mDeferNotifyDataSetChanged = false;
				}
				return false;
			}
			else
			{
				if (mRemoteAdapter != null)
				{
					mRemoteAdapter.superNotifyDataSetChanged();
					return true;
				}
			}
			return false;
		}

		/// <summary>Called back when the adapter disconnects from the RemoteViewsService.</summary>
		/// <remarks>Called back when the adapter disconnects from the RemoteViewsService.</remarks>
		[Sharpen.ImplementsInterface(@"android.widget.RemoteViewsAdapter.RemoteAdapterConnectionCallback"
			)]
		public virtual void onRemoteAdapterDisconnected()
		{
		}

		// If the remote adapter disconnects, we keep it around
		// since the currently displayed items are still cached.
		// Further, we want the service to eventually reconnect
		// when necessary, as triggered by this view requesting
		// items from the Adapter.
		/// <summary>
		/// Sets the recycler listener to be notified whenever a View is set aside in
		/// the recycler for later reuse.
		/// </summary>
		/// <remarks>
		/// Sets the recycler listener to be notified whenever a View is set aside in
		/// the recycler for later reuse. This listener can be used to free resources
		/// associated to the View.
		/// </remarks>
		/// <param name="listener">
		/// The recycler listener to be notified of views set aside
		/// in the recycler.
		/// </param>
		/// <seealso cref="RecycleBin">RecycleBin</seealso>
		/// <seealso cref="RecyclerListener">RecyclerListener</seealso>
		public virtual void setRecyclerListener(android.widget.AbsListView.RecyclerListener
			 listener)
		{
			mRecycler.mRecyclerListener = listener;
		}

		internal class AdapterDataSetObserver : android.widget.AdapterView<android.widget.ListAdapter
			>.AdapterDataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				base.onChanged();
				if (this._enclosing.mFastScroller != null)
				{
					this._enclosing.mFastScroller.onSectionsChanged();
				}
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				base.onInvalidated();
				if (this._enclosing.mFastScroller != null)
				{
					this._enclosing.mFastScroller.onSectionsChanged();
				}
			}

			internal AdapterDataSetObserver(AbsListView _enclosing) : base(_enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		/// <summary>
		/// A MultiChoiceModeListener receives events for
		/// <see cref="AbsListView.CHOICE_MODE_MULTIPLE_MODAL">AbsListView.CHOICE_MODE_MULTIPLE_MODAL
		/// 	</see>
		/// .
		/// It acts as the
		/// <see cref="android.view.ActionMode.Callback">android.view.ActionMode.Callback</see>
		/// for the selection mode and also receives
		/// <see cref="onItemCheckedStateChanged(android.view.ActionMode, int, long, bool)">onItemCheckedStateChanged(android.view.ActionMode, int, long, bool)
		/// 	</see>
		/// events when the user
		/// selects and deselects list items.
		/// </summary>
		public interface MultiChoiceModeListener : android.view.ActionMode.Callback
		{
			/// <summary>Called when an item is checked or unchecked during selection mode.</summary>
			/// <remarks>Called when an item is checked or unchecked during selection mode.</remarks>
			/// <param name="mode">
			/// The
			/// <see cref="android.view.ActionMode">android.view.ActionMode</see>
			/// providing the selection mode
			/// </param>
			/// <param name="position">Adapter position of the item that was checked or unchecked
			/// 	</param>
			/// <param name="id">Adapter ID of the item that was checked or unchecked</param>
			/// <param name="checked">
			/// <code>true</code> if the item is now checked, <code>false</code>
			/// if the item is now unchecked.
			/// </param>
			void onItemCheckedStateChanged(android.view.ActionMode mode, int position, long id
				, bool @checked);
		}

		internal class MultiChoiceModeWrapper : android.widget.AbsListView.MultiChoiceModeListener
		{
			private android.widget.AbsListView.MultiChoiceModeListener mWrapped;

			public virtual void setWrapped(android.widget.AbsListView.MultiChoiceModeListener
				 wrapped)
			{
				this.mWrapped = wrapped;
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onCreateActionMode(android.view.ActionMode mode, android.view.Menu
				 menu)
			{
				if (this.mWrapped.onCreateActionMode(mode, menu))
				{
					// Initialize checked graphic state?
					this._enclosing.setLongClickable(false);
					return true;
				}
				return false;
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onPrepareActionMode(android.view.ActionMode mode, android.view.Menu
				 menu)
			{
				return this.mWrapped.onPrepareActionMode(mode, menu);
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual bool onActionItemClicked(android.view.ActionMode mode, android.view.MenuItem
				 item)
			{
				return this.mWrapped.onActionItemClicked(mode, item);
			}

			[Sharpen.ImplementsInterface(@"android.view.ActionMode.Callback")]
			public virtual void onDestroyActionMode(android.view.ActionMode mode)
			{
				this.mWrapped.onDestroyActionMode(mode);
				this._enclosing.mChoiceActionMode = null;
				// Ending selection mode means deselecting everything.
				this._enclosing.clearChoices();
				this._enclosing.mDataChanged = true;
				this._enclosing.rememberSyncState();
				this._enclosing.requestLayout();
				this._enclosing.setLongClickable(true);
			}

			[Sharpen.ImplementsInterface(@"android.widget.AbsListView.MultiChoiceModeListener"
				)]
			public virtual void onItemCheckedStateChanged(android.view.ActionMode mode, int position
				, long id, bool @checked)
			{
				this.mWrapped.onItemCheckedStateChanged(mode, position, id, @checked);
				// If there are no items selected we no longer need the selection mode.
				if (this._enclosing.getCheckedItemCount() == 0)
				{
					mode.finish();
				}
			}

			internal MultiChoiceModeWrapper(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbsListView _enclosing;
		}

		/// <summary>AbsListView extends LayoutParams to provide a place to hold the view type.
		/// 	</summary>
		/// <remarks>AbsListView extends LayoutParams to provide a place to hold the view type.
		/// 	</remarks>
		public class LayoutParams : android.view.ViewGroup.LayoutParams
		{
			/// <summary>
			/// View type for this view, as returned by
			/// <see cref="Adapter.getItemViewType(int)"></see>
			/// </summary>
			internal int viewType;

			/// <summary>
			/// When this boolean is set, the view has been added to the AbsListView
			/// at least once.
			/// </summary>
			/// <remarks>
			/// When this boolean is set, the view has been added to the AbsListView
			/// at least once. It is used to know whether headers/footers have already
			/// been added to the list view and whether they should be treated as
			/// recycled views or not.
			/// </remarks>
			internal bool recycledHeaderFooter;

			/// <summary>
			/// When an AbsListView is measured with an AT_MOST measure spec, it needs
			/// to obtain children views to measure itself.
			/// </summary>
			/// <remarks>
			/// When an AbsListView is measured with an AT_MOST measure spec, it needs
			/// to obtain children views to measure itself. When doing so, the children
			/// are not attached to the window, but put in the recycler which assumes
			/// they've been attached before. Setting this flag will force the reused
			/// view to be attached to the window rather than just attached to the
			/// parent.
			/// </remarks>
			internal bool forceAdd;

			/// <summary>
			/// The position the view was removed from when pulled out of the
			/// scrap heap.
			/// </summary>
			/// <remarks>
			/// The position the view was removed from when pulled out of the
			/// scrap heap.
			/// </remarks>
			/// <hide></hide>
			internal int scrappedFromPosition;

			public LayoutParams(android.content.Context c, android.util.AttributeSet attrs) : 
				base(c, attrs)
			{
			}

			public LayoutParams(int w, int h) : base(w, h)
			{
			}

			public LayoutParams(int w, int h, int viewType) : base(w, h)
			{
				this.viewType = viewType;
			}

			public LayoutParams(android.view.ViewGroup.LayoutParams source) : base(source)
			{
			}
		}

		/// <summary>
		/// A RecyclerListener is used to receive a notification whenever a View is placed
		/// inside the RecycleBin's scrap heap.
		/// </summary>
		/// <remarks>
		/// A RecyclerListener is used to receive a notification whenever a View is placed
		/// inside the RecycleBin's scrap heap. This listener is used to free resources
		/// associated to Views placed in the RecycleBin.
		/// </remarks>
		/// <seealso cref="RecycleBin">RecycleBin</seealso>
		/// <seealso cref="AbsListView.setRecyclerListener(RecyclerListener)">AbsListView.setRecyclerListener(RecyclerListener)
		/// 	</seealso>
		public interface RecyclerListener
		{
			/// <summary>Indicates that the specified View was moved into the recycler's scrap heap.
			/// 	</summary>
			/// <remarks>
			/// Indicates that the specified View was moved into the recycler's scrap heap.
			/// The view is not displayed on screen any more and any expensive resource
			/// associated with the view should be discarded.
			/// </remarks>
			/// <param name="view"></param>
			void onMovedToScrapHeap(android.view.View view);
		}

		/// <summary>The RecycleBin facilitates reuse of views across layouts.</summary>
		/// <remarks>
		/// The RecycleBin facilitates reuse of views across layouts. The RecycleBin has two levels of
		/// storage: ActiveViews and ScrapViews. ActiveViews are those views which were onscreen at the
		/// start of a layout. By construction, they are displaying current information. At the end of
		/// layout, all views in ActiveViews are demoted to ScrapViews. ScrapViews are old views that
		/// could potentially be used by the adapter to avoid allocating views unnecessarily.
		/// </remarks>
		/// <seealso cref="AbsListView.setRecyclerListener(RecyclerListener)">AbsListView.setRecyclerListener(RecyclerListener)
		/// 	</seealso>
		/// <seealso cref="RecyclerListener">RecyclerListener</seealso>
		internal class RecycleBin
		{
			internal android.widget.AbsListView.RecyclerListener mRecyclerListener;

			/// <summary>The position of the first view stored in mActiveViews.</summary>
			/// <remarks>The position of the first view stored in mActiveViews.</remarks>
			internal int mFirstActivePosition;

			/// <summary>Views that were on screen at the start of layout.</summary>
			/// <remarks>
			/// Views that were on screen at the start of layout. This array is populated at the start of
			/// layout, and at the end of layout all view in mActiveViews are moved to mScrapViews.
			/// Views in mActiveViews represent a contiguous range of Views, with position of the first
			/// view store in mFirstActivePosition.
			/// </remarks>
			internal android.view.View[] mActiveViews;

			/// <summary>Unsorted views that can be used by the adapter as a convert view.</summary>
			/// <remarks>Unsorted views that can be used by the adapter as a convert view.</remarks>
			internal java.util.ArrayList<android.view.View>[] mScrapViews;

			internal int mViewTypeCount;

			internal java.util.ArrayList<android.view.View> mCurrentScrap;

			public virtual void setViewTypeCount(int viewTypeCount)
			{
				if (viewTypeCount < 1)
				{
					throw new System.ArgumentException("Can't have a viewTypeCount < 1");
				}
				//noinspection unchecked
				java.util.ArrayList<android.view.View>[] scrapViews = new java.util.ArrayList<android.view.View
					>[viewTypeCount];
				{
					for (int i = 0; i < viewTypeCount; i++)
					{
						scrapViews[i] = new java.util.ArrayList<android.view.View>();
					}
				}
				this.mViewTypeCount = viewTypeCount;
				this.mCurrentScrap = scrapViews[0];
				this.mScrapViews = scrapViews;
			}

			public virtual void markChildrenDirty()
			{
				if (this.mViewTypeCount == 1)
				{
					java.util.ArrayList<android.view.View> scrap = this.mCurrentScrap;
					int scrapCount = scrap.size();
					{
						for (int i = 0; i < scrapCount; i++)
						{
							scrap.get(i).forceLayout();
						}
					}
				}
				else
				{
					int typeCount = this.mViewTypeCount;
					{
						for (int i = 0; i < typeCount; i++)
						{
							java.util.ArrayList<android.view.View> scrap = this.mScrapViews[i];
							int scrapCount = scrap.size();
							{
								for (int j = 0; j < scrapCount; j++)
								{
									scrap.get(j).forceLayout();
								}
							}
						}
					}
				}
			}

			public virtual bool shouldRecycleViewType(int viewType)
			{
				return viewType >= 0;
			}

			/// <summary>Clears the scrap heap.</summary>
			/// <remarks>Clears the scrap heap.</remarks>
			internal virtual void clear()
			{
				if (this.mViewTypeCount == 1)
				{
					java.util.ArrayList<android.view.View> scrap = this.mCurrentScrap;
					int scrapCount = scrap.size();
					{
						for (int i = 0; i < scrapCount; i++)
						{
							this._enclosing.removeDetachedView(scrap.remove(scrapCount - 1 - i), false);
						}
					}
				}
				else
				{
					int typeCount = this.mViewTypeCount;
					{
						for (int i = 0; i < typeCount; i++)
						{
							java.util.ArrayList<android.view.View> scrap = this.mScrapViews[i];
							int scrapCount = scrap.size();
							{
								for (int j = 0; j < scrapCount; j++)
								{
									this._enclosing.removeDetachedView(scrap.remove(scrapCount - 1 - j), false);
								}
							}
						}
					}
				}
			}

			/// <summary>Fill ActiveViews with all of the children of the AbsListView.</summary>
			/// <remarks>Fill ActiveViews with all of the children of the AbsListView.</remarks>
			/// <param name="childCount">The minimum number of views mActiveViews should hold</param>
			/// <param name="firstActivePosition">
			/// The position of the first view that will be stored in
			/// mActiveViews
			/// </param>
			internal virtual void fillActiveViews(int childCount, int firstActivePosition)
			{
				if (this.mActiveViews.Length < childCount)
				{
					this.mActiveViews = new android.view.View[childCount];
				}
				this.mFirstActivePosition = firstActivePosition;
				android.view.View[] activeViews = this.mActiveViews;
				{
					for (int i = 0; i < childCount; i++)
					{
						android.view.View child = this._enclosing.getChildAt(i);
						android.widget.AbsListView.LayoutParams lp = (android.widget.AbsListView.LayoutParams
							)child.getLayoutParams();
						// Don't put header or footer views into the scrap heap
						if (lp != null && lp.viewType != android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER)
						{
							// Note:  We do place AdapterView.ITEM_VIEW_TYPE_IGNORE in active views.
							//        However, we will NOT place them into scrap views.
							activeViews[i] = child;
						}
					}
				}
			}

			/// <summary>Get the view corresponding to the specified position.</summary>
			/// <remarks>
			/// Get the view corresponding to the specified position. The view will be removed from
			/// mActiveViews if it is found.
			/// </remarks>
			/// <param name="position">The position to look up in mActiveViews</param>
			/// <returns>The view if it is found, null otherwise</returns>
			internal virtual android.view.View getActiveView(int position)
			{
				int index = position - this.mFirstActivePosition;
				android.view.View[] activeViews = this.mActiveViews;
				if (index >= 0 && index < activeViews.Length)
				{
					android.view.View match = activeViews[index];
					activeViews[index] = null;
					return match;
				}
				return null;
			}

			/// <returns>A view from the ScrapViews collection. These are unordered.</returns>
			internal virtual android.view.View getScrapView(int position)
			{
				if (this.mViewTypeCount == 1)
				{
					return android.widget.AbsListView.retrieveFromScrap(this.mCurrentScrap, position);
				}
				else
				{
					int whichScrap = this._enclosing.mAdapter.getItemViewType(position);
					if (whichScrap >= 0 && whichScrap < this.mScrapViews.Length)
					{
						return android.widget.AbsListView.retrieveFromScrap(this.mScrapViews[whichScrap], 
							position);
					}
				}
				return null;
			}

			/// <summary>Put a view into the ScapViews list.</summary>
			/// <remarks>Put a view into the ScapViews list. These views are unordered.</remarks>
			/// <param name="scrap">The view to add</param>
			internal virtual void addScrapView(android.view.View scrap, int position)
			{
				android.widget.AbsListView.LayoutParams lp = (android.widget.AbsListView.LayoutParams
					)scrap.getLayoutParams();
				if (lp == null)
				{
					return;
				}
				// Don't put header or footer views or views that should be ignored
				// into the scrap heap
				int viewType = lp.viewType;
				if (!this.shouldRecycleViewType(viewType))
				{
					if (viewType != android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER)
					{
						this._enclosing.removeDetachedView(scrap, false);
					}
					return;
				}
				lp.scrappedFromPosition = position;
				if (this.mViewTypeCount == 1)
				{
					scrap.dispatchStartTemporaryDetach();
					this.mCurrentScrap.add(scrap);
				}
				else
				{
					scrap.dispatchStartTemporaryDetach();
					this.mScrapViews[viewType].add(scrap);
				}
				if (this.mRecyclerListener != null)
				{
					this.mRecyclerListener.onMovedToScrapHeap(scrap);
				}
			}

			/// <summary>Move all views remaining in mActiveViews to mScrapViews.</summary>
			/// <remarks>Move all views remaining in mActiveViews to mScrapViews.</remarks>
			internal virtual void scrapActiveViews()
			{
				android.view.View[] activeViews = this.mActiveViews;
				bool hasListener = this.mRecyclerListener != null;
				bool multipleScraps = this.mViewTypeCount > 1;
				java.util.ArrayList<android.view.View> scrapViews = this.mCurrentScrap;
				int count = activeViews.Length;
				{
					for (int i = count - 1; i >= 0; i--)
					{
						android.view.View victim = activeViews[i];
						if (victim != null)
						{
							android.widget.AbsListView.LayoutParams lp = (android.widget.AbsListView.LayoutParams
								)victim.getLayoutParams();
							int whichScrap = lp.viewType;
							activeViews[i] = null;
							if (!this.shouldRecycleViewType(whichScrap))
							{
								// Do not move views that should be ignored
								if (whichScrap != android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER)
								{
									this._enclosing.removeDetachedView(victim, false);
								}
								continue;
							}
							if (multipleScraps)
							{
								scrapViews = this.mScrapViews[whichScrap];
							}
							victim.dispatchStartTemporaryDetach();
							lp.scrappedFromPosition = this.mFirstActivePosition + i;
							scrapViews.add(victim);
							if (hasListener)
							{
								this.mRecyclerListener.onMovedToScrapHeap(victim);
							}
						}
					}
				}
				this.pruneScrapViews();
			}

			/// <summary>Makes sure that the size of mScrapViews does not exceed the size of mActiveViews.
			/// 	</summary>
			/// <remarks>
			/// Makes sure that the size of mScrapViews does not exceed the size of mActiveViews.
			/// (This can happen if an adapter does not recycle its views).
			/// </remarks>
			private void pruneScrapViews()
			{
				int maxViews = this.mActiveViews.Length;
				int viewTypeCount = this.mViewTypeCount;
				java.util.ArrayList<android.view.View>[] scrapViews = this.mScrapViews;
				{
					for (int i = 0; i < viewTypeCount; ++i)
					{
						java.util.ArrayList<android.view.View> scrapPile = scrapViews[i];
						int size = scrapPile.size();
						int extras = size - maxViews;
						size--;
						{
							for (int j = 0; j < extras; j++)
							{
								this._enclosing.removeDetachedView(scrapPile.remove(size--), false);
							}
						}
					}
				}
			}

			/// <summary>Puts all views in the scrap heap into the supplied list.</summary>
			/// <remarks>Puts all views in the scrap heap into the supplied list.</remarks>
			internal virtual void reclaimScrapViews(java.util.List<android.view.View> views)
			{
				if (this.mViewTypeCount == 1)
				{
					views.addAll(this.mCurrentScrap);
				}
				else
				{
					int viewTypeCount = this.mViewTypeCount;
					java.util.ArrayList<android.view.View>[] scrapViews = this.mScrapViews;
					{
						for (int i = 0; i < viewTypeCount; ++i)
						{
							java.util.ArrayList<android.view.View> scrapPile = scrapViews[i];
							views.addAll(scrapPile);
						}
					}
				}
			}

			/// <summary>Updates the cache color hint of all known views.</summary>
			/// <remarks>Updates the cache color hint of all known views.</remarks>
			/// <param name="color">The new cache color hint.</param>
			internal virtual void setCacheColorHint(int color)
			{
				if (this.mViewTypeCount == 1)
				{
					java.util.ArrayList<android.view.View> scrap = this.mCurrentScrap;
					int scrapCount = scrap.size();
					{
						for (int i = 0; i < scrapCount; i++)
						{
							scrap.get(i).setDrawingCacheBackgroundColor(color);
						}
					}
				}
				else
				{
					int typeCount = this.mViewTypeCount;
					{
						for (int i = 0; i < typeCount; i++)
						{
							java.util.ArrayList<android.view.View> scrap = this.mScrapViews[i];
							int scrapCount = scrap.size();
							{
								for (int j = 0; j < scrapCount; j++)
								{
									scrap.get(j).setDrawingCacheBackgroundColor(color);
								}
							}
						}
					}
				}
				// Just in case this is called during a layout pass
				android.view.View[] activeViews = this.mActiveViews;
				int count = activeViews.Length;
				{
					for (int i_1 = 0; i_1 < count; ++i_1)
					{
						android.view.View victim = activeViews[i_1];
						if (victim != null)
						{
							victim.setDrawingCacheBackgroundColor(color);
						}
					}
				}
			}

			public RecycleBin(AbsListView _enclosing)
			{
				this._enclosing = _enclosing;
				mActiveViews = new android.view.View[0];
			}

			private readonly AbsListView _enclosing;
		}

		internal static android.view.View retrieveFromScrap(java.util.ArrayList<android.view.View
			> scrapViews, int position)
		{
			int size = scrapViews.size();
			if (size > 0)
			{
				{
					// See if we still have a view for this position.
					for (int i = 0; i < size; i++)
					{
						android.view.View view = scrapViews.get(i);
						if (((android.widget.AbsListView.LayoutParams)view.getLayoutParams()).scrappedFromPosition
							 == position)
						{
							scrapViews.remove(i);
							return view;
						}
					}
				}
				return scrapViews.remove(size - 1);
			}
			else
			{
				return null;
			}
		}
	}
}
