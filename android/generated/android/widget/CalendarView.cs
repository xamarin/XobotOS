using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class CalendarView : android.widget.FrameLayout
	{
		private static readonly string LOG_TAG = typeof(android.widget.CalendarView).Name;

		internal const bool DEFAULT_SHOW_WEEK_NUMBER = true;

		internal const long MILLIS_IN_DAY = 86400000L;

		internal const int DAYS_PER_WEEK = 7;

		internal const long MILLIS_IN_WEEK = DAYS_PER_WEEK * MILLIS_IN_DAY;

		internal const int SCROLL_HYST_WEEKS = 2;

		internal const int GOTO_SCROLL_DURATION = 1000;

		internal const int ADJUSTMENT_SCROLL_DURATION = 500;

		internal const int SCROLL_CHANGE_DELAY = 40;

		internal const string FORMAT_MONTH_NAME = "MMMM, yyyy";

		internal const string DATE_FORMAT = "MM/dd/yyyy";

		internal const string DEFAULT_MIN_DATE = "01/01/1900";

		internal const string DEFAULT_MAX_DATE = "01/01/2100";

		internal const int DEFAULT_SHOWN_WEEK_COUNT = 6;

		internal const int DEFAULT_DATE_TEXT_SIZE = 14;

		internal const int UNSCALED_SELECTED_DATE_VERTICAL_BAR_WIDTH = 6;

		internal const int UNSCALED_WEEK_MIN_VISIBLE_HEIGHT = 12;

		internal const int UNSCALED_LIST_SCROLL_TOP_OFFSET = 2;

		internal const int UNSCALED_BOTTOM_BUFFER = 20;

		internal const int UNSCALED_WEEK_SEPARATOR_LINE_WIDTH = 1;

		internal const int DEFAULT_WEEK_DAY_TEXT_APPEARANCE_RES_ID = -1;

		private readonly int mWeekSeperatorLineWidth;

		private readonly int mDateTextSize;

		private readonly android.graphics.drawable.Drawable mSelectedDateVerticalBar;

		private readonly int mSelectedDateVerticalBarWidth;

		private readonly int mSelectedWeekBackgroundColor;

		private readonly int mFocusedMonthDateColor;

		private readonly int mUnfocusedMonthDateColor;

		private readonly int mWeekSeparatorLineColor;

		private readonly int mWeekNumberColor;

		private int mListScrollTopOffset = 2;

		private int mWeekMinVisibleHeight = 12;

		private int mBottomBuffer = 20;

		private int mShownWeekCount;

		private bool mShowWeekNumber;

		private int mDaysPerWeek = 7;

		private float mFriction = .05f;

		private float mVelocityScale = 0.333f;

		private android.widget.CalendarView.WeeksAdapter mAdapter;

		private android.widget.ListView mListView;

		private android.widget.TextView mMonthName;

		private android.view.ViewGroup mDayNamesHeader;

		private string[] mDayLabels;

		private int mFirstDayOfWeek;

		private int mCurrentMonthDisplayed;

		private long mPreviousScrollPosition;

		private bool mIsScrollingUp = false;

		private int mPreviousScrollState = android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE;

		private int mCurrentScrollState = android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE;

		private android.widget.CalendarView.OnDateChangeListener mOnDateChangeListener;

		private android.widget.CalendarView.ScrollStateRunnable mScrollStateChangedRunnable;

		private java.util.Calendar mTempDate;

		private java.util.Calendar mFirstDayOfMonth;

		private java.util.Calendar mMinDate;

		private java.util.Calendar mMaxDate;

		private readonly java.text.DateFormat mDateFormat = new java.text.SimpleDateFormat
			(DATE_FORMAT);

		private System.Globalization.CultureInfo mCurrentLocale;

		[Sharpen.Stub]
		public interface OnDateChangeListener
		{
			[Sharpen.Stub]
			void onSelectedDayChange(android.widget.CalendarView view, int year, int month, int
				 dayOfMonth);
		}

		[Sharpen.Stub]
		public CalendarView(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CalendarView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public CalendarView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, 0)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool isEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getMinDate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMinDate(long minDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getMaxDate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaxDate(long maxDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setShowWeekNumber(bool showWeekNumber)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getShowWeekNumber()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFirstDayOfWeek()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFirstDayOfWeek(int firstDayOfWeek)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnDateChangeListener(android.widget.CalendarView.OnDateChangeListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getDate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDate(long date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDate(long date, bool animate_1, bool center)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setCurrentLocale(System.Globalization.CultureInfo locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.util.Calendar getCalendarForLocale(java.util.Calendar oldCalendar, System.Globalization.CultureInfo
			 locale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isSameDate(java.util.Calendar firstDate, java.util.Calendar secondDate
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setUpAdapter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setUpHeader(int weekDayTextAppearanceResId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setUpListView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void goTo(java.util.Calendar date, bool animate_1, bool setSelected_1, bool
			 forceScroll)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool parseDate(string date, java.util.Calendar outDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onScrollStateChanged(android.widget.AbsListView view, int scrollState
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onScroll(android.widget.AbsListView view, int firstVisibleItem, int 
			visibleItemCount, int totalItemCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setMonthDisplayed(java.util.Calendar calendar)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getWeeksSinceMinDate(java.util.Calendar date)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class ScrollStateRunnable : java.lang.Runnable
		{
			internal android.widget.AbsListView mView;

			internal int mNewState;

			[Sharpen.Stub]
			public virtual void doScrollStateChange(android.widget.AbsListView view, int scrollState
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				throw new System.NotImplementedException();
			}

			internal ScrollStateRunnable(CalendarView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly CalendarView _enclosing;
		}

		[Sharpen.Stub]
		private class WeeksAdapter : android.widget.BaseAdapter, android.view.View.OnTouchListener
		{
			internal int mSelectedWeek;

			internal android.view.GestureDetector mGestureDetector;

			internal int mFocusedMonth;

			internal readonly java.util.Calendar mSelectedDate;

			internal int mTotalWeekCount;

			[Sharpen.Stub]
			public WeeksAdapter(CalendarView _enclosing, android.content.Context context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void init()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setSelectedDay(java.util.Calendar selectedDay)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual java.util.Calendar getSelectedDay()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setFocusMonth(int month)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnTouchListener")]
			public virtual bool onTouch(android.view.View v, android.view.MotionEvent @event)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void onDateTapped(java.util.Calendar day)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal class CalendarGestureListener : android.view.GestureDetector.SimpleOnGestureListener
			{
				[Sharpen.Stub]
				[Sharpen.OverridesMethod(@"android.view.GestureDetector.SimpleOnGestureListener")]
				public override bool onSingleTapUp(android.view.MotionEvent e)
				{
					throw new System.NotImplementedException();
				}

				internal CalendarGestureListener(WeeksAdapter _enclosing)
				{
					this._enclosing = _enclosing;
				}

				private readonly WeeksAdapter _enclosing;
			}

			private readonly CalendarView _enclosing;
		}

		[Sharpen.Stub]
		private class WeekView : android.view.View
		{
			internal readonly android.graphics.Rect mTempRect;

			internal readonly android.graphics.Paint mDrawPaint;

			internal readonly android.graphics.Paint mMonthNumDrawPaint;

			internal string[] mDayNumbers;

			internal bool[] mFocusDay;

			internal java.util.Calendar mFirstDay;

			internal int mMonthOfFirstWeekDay;

			internal int mLastWeekDayMonth;

			internal int mWeek;

			internal int mWidth;

			internal int mHeight;

			internal bool mHasSelectedDay;

			internal int mSelectedDay;

			internal int mNumCells;

			internal int mSelectedLeft;

			internal int mSelectedRight;

			[Sharpen.Stub]
			public WeekView(CalendarView _enclosing, android.content.Context context) : base(
				context)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void init(int weekNumber, int selectedWeekDay, int focusedMonth)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void setPaintProperties()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getMonthOfFirstWeekDay()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getMonthOfLastWeekDay()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual java.util.Calendar getFirstDay()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool getDayFromLocation(float x, java.util.Calendar outCalendar)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onDraw(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void drawBackground(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void drawWeekNumbers(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void drawWeekSeparators(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void drawSelectedDateVerticalBars(android.graphics.Canvas canvas)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void updateSelectionPositions()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
				)
			{
				throw new System.NotImplementedException();
			}

			private readonly CalendarView _enclosing;
		}
	}
}
