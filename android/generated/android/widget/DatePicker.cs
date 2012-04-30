using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public class DatePicker : android.widget.FrameLayout
	{
		private static readonly string LOG_TAG = typeof(android.widget.DatePicker).Name;

		internal const string DATE_FORMAT = "MM/dd/yyyy";

		internal const int DEFAULT_START_YEAR = 1900;

		internal const int DEFAULT_END_YEAR = 2100;

		internal const bool DEFAULT_CALENDAR_VIEW_SHOWN = true;

		internal const bool DEFAULT_SPINNERS_SHOWN = true;

		internal const bool DEFAULT_ENABLED_STATE = true;

		private readonly android.widget.LinearLayout mSpinners;

		private readonly android.widget.NumberPicker mDaySpinner;

		private readonly android.widget.NumberPicker mMonthSpinner;

		private readonly android.widget.NumberPicker mYearSpinner;

		private readonly android.widget.EditText mDaySpinnerInput;

		private readonly android.widget.EditText mMonthSpinnerInput;

		private readonly android.widget.EditText mYearSpinnerInput;

		private readonly android.widget.CalendarView mCalendarView;

		private System.Globalization.CultureInfo mCurrentLocale;

		private android.widget.DatePicker.OnDateChangedListener mOnDateChangedListener;

		private string[] mShortMonths;

		private readonly java.text.DateFormat mDateFormat = new java.text.SimpleDateFormat
			(DATE_FORMAT);

		private int mNumberOfMonths;

		private java.util.Calendar mTempDate;

		private java.util.Calendar mMinDate;

		private java.util.Calendar mMaxDate;

		private java.util.Calendar mCurrentDate;

		private bool mIsEnabled = DEFAULT_ENABLED_STATE;

		[Sharpen.Stub]
		public interface OnDateChangedListener
		{
			[Sharpen.Stub]
			void onDateChanged(android.widget.DatePicker view, int year, int monthOfYear, int
				 dayOfMonth);
		}

		[Sharpen.Stub]
		public DatePicker(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DatePicker(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.datePickerStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public DatePicker(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
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
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
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
		public virtual bool getCalendarViewShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.CalendarView getCalendarView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCalendarViewShown(bool shown)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool getSpinnersShown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSpinnersShown(bool shown)
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
		private void reorderSpinners()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateDate(int year, int month, int dayOfMonth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchRestoreInstanceState(android.util.SparseArray
			<android.os.Parcelable> container)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void init(int year, int monthOfYear, int dayOfMonth, android.widget.DatePicker
			.OnDateChangedListener onDateChangedListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool parseDate(string date, java.util.Calendar outDate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool isNewDate(int year, int month, int dayOfMonth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setDate(int year, int month, int dayOfMonth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateSpinners()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateCalendarView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getYear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMonth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getDayOfMonth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyDateChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setImeOptions(android.widget.NumberPicker spinner, int spinnerCount, 
			int spinnerIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setContentDescriptions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void updateInputState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class SavedState : android.view.View.BaseSavedState
		{
			internal readonly int mYear;

			internal readonly int mMonth;

			internal readonly int mDay;

			[Sharpen.Stub]
			internal SavedState(android.os.Parcelable superState, int year, int month, int day
				) : base(superState)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal SavedState(android.os.Parcel @in) : base(@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			internal sealed class _Creator_785 : android.os.ParcelableClass.Creator<android.widget.DatePicker
				.SavedState>
			{
				public _Creator_785()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.DatePicker.SavedState createFromParcel(android.os.Parcel @in
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.DatePicker.SavedState[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.DatePicker
				.SavedState> CREATOR = new _Creator_785();
		}
	}
}
