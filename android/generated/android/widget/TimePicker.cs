using Sharpen;

namespace android.widget
{
	/// <summary>A view for selecting the time of day, in either 24 hour or AM/PM mode.</summary>
	/// <remarks>
	/// A view for selecting the time of day, in either 24 hour or AM/PM mode. The
	/// hour, each minute digit, and AM/PM (if applicable) can be conrolled by
	/// vertical spinners. The hour can be entered by keyboard input. Entering in two
	/// digit hours can be accomplished by hitting two digits within a timeout of
	/// about a second (e.g. '1' then '2' to select 12). The minutes can be entered
	/// by entering single digits. Under AM/PM mode, the user can hit 'a', 'A", 'p'
	/// or 'P' to pick. For a dialog using this view, see
	/// <see cref="android.app.TimePickerDialog">android.app.TimePickerDialog</see>
	/// .
	/// <p>
	/// See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-timepicker.html"&gt;Time Picker
	/// tutorial</a>.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class TimePicker : android.widget.FrameLayout
	{
		internal const bool DEFAULT_ENABLED_STATE = true;

		internal const int HOURS_IN_HALF_DAY = 12;

		private sealed class _OnTimeChangedListener_65 : android.widget.TimePicker.OnTimeChangedListener
		{
			public _OnTimeChangedListener_65()
			{
			}

			[Sharpen.ImplementsInterface(@"android.widget.TimePicker.OnTimeChangedListener")]
			public void onTimeChanged(android.widget.TimePicker view, int hourOfDay, int minute
				)
			{
			}
		}

		/// <summary>
		/// A no-op callback used in the constructor to avoid null checks later in
		/// the code.
		/// </summary>
		/// <remarks>
		/// A no-op callback used in the constructor to avoid null checks later in
		/// the code.
		/// </remarks>
		private static readonly android.widget.TimePicker.OnTimeChangedListener NO_OP_CHANGE_LISTENER
			 = new _OnTimeChangedListener_65();

		private bool mIs24HourView;

		private bool mIsAm;

		private readonly android.widget.NumberPicker mHourSpinner;

		private readonly android.widget.NumberPicker mMinuteSpinner;

		private readonly android.widget.NumberPicker mAmPmSpinner;

		private readonly android.widget.EditText mHourSpinnerInput;

		private readonly android.widget.EditText mMinuteSpinnerInput;

		private readonly android.widget.EditText mAmPmSpinnerInput;

		private readonly android.widget.TextView mDivider;

		private readonly android.widget.Button mAmPmButton;

		private readonly string[] mAmPmStrings;

		private bool mIsEnabled = DEFAULT_ENABLED_STATE;

		private android.widget.TimePicker.OnTimeChangedListener mOnTimeChangedListener;

		private java.util.Calendar mTempCalendar;

		private System.Globalization.CultureInfo mCurrentLocale;

		/// <summary>The callback interface used to indicate the time has been adjusted.</summary>
		/// <remarks>The callback interface used to indicate the time has been adjusted.</remarks>
		public interface OnTimeChangedListener
		{
			// state
			// ui components
			// Note that the legacy implementation of the TimePicker is
			// using a button for toggling between AM/PM while the new
			// version uses a NumberPicker spinner. Therefore the code
			// accommodates these two cases to be backwards compatible.
			// callbacks
			/// <param name="view">The view associated with this listener.</param>
			/// <param name="hourOfDay">The current hour.</param>
			/// <param name="minute">The current minute.</param>
			void onTimeChanged(android.widget.TimePicker view, int hourOfDay, int minute);
		}

		public TimePicker(android.content.Context context) : this(context, null)
		{
		}

		public TimePicker(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.timePickerStyle)
		{
		}

		private sealed class _OnValueChangeListener_147 : android.widget.NumberPicker.OnValueChangeListener
		{
			public _OnValueChangeListener_147(TimePicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// initialization based on locale
			// process style attributes
			// hour
			[Sharpen.ImplementsInterface(@"android.widget.NumberPicker.OnValueChangeListener"
				)]
			public void onValueChange(android.widget.NumberPicker spinner, int oldVal, int newVal
				)
			{
				this._enclosing.updateInputState();
				if (!this._enclosing.is24HourView())
				{
					if ((oldVal == android.widget.TimePicker.HOURS_IN_HALF_DAY - 1 && newVal == android.widget.TimePicker
						.HOURS_IN_HALF_DAY) || (oldVal == android.widget.TimePicker.HOURS_IN_HALF_DAY &&
						 newVal == android.widget.TimePicker.HOURS_IN_HALF_DAY - 1))
					{
						this._enclosing.mIsAm = !this._enclosing.mIsAm;
						this._enclosing.updateAmPmControl();
					}
				}
				this._enclosing.onTimeChanged();
			}

			private readonly TimePicker _enclosing;
		}

		private sealed class _OnValueChangeListener_175 : android.widget.NumberPicker.OnValueChangeListener
		{
			public _OnValueChangeListener_175(TimePicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// divider (only for the new widget style)
			// minute
			[Sharpen.ImplementsInterface(@"android.widget.NumberPicker.OnValueChangeListener"
				)]
			public void onValueChange(android.widget.NumberPicker spinner, int oldVal, int newVal
				)
			{
				this._enclosing.updateInputState();
				int minValue = this._enclosing.mMinuteSpinner.getMinValue();
				int maxValue = this._enclosing.mMinuteSpinner.getMaxValue();
				if (oldVal == maxValue && newVal == minValue)
				{
					int newHour = this._enclosing.mHourSpinner.getValue() + 1;
					if (!this._enclosing.is24HourView() && newHour == android.widget.TimePicker.HOURS_IN_HALF_DAY)
					{
						this._enclosing.mIsAm = !this._enclosing.mIsAm;
						this._enclosing.updateAmPmControl();
					}
					this._enclosing.mHourSpinner.setValue(newHour);
				}
				else
				{
					if (oldVal == minValue && newVal == maxValue)
					{
						int newHour = this._enclosing.mHourSpinner.getValue() - 1;
						if (!this._enclosing.is24HourView() && newHour == android.widget.TimePicker.HOURS_IN_HALF_DAY
							 - 1)
						{
							this._enclosing.mIsAm = !this._enclosing.mIsAm;
							this._enclosing.updateAmPmControl();
						}
						this._enclosing.mHourSpinner.setValue(newHour);
					}
				}
				this._enclosing.onTimeChanged();
			}

			private readonly TimePicker _enclosing;
		}

		private sealed class _OnClickListener_210 : android.view.View.OnClickListener
		{
			public _OnClickListener_210(TimePicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// am/pm
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View button)
			{
				button.requestFocus();
				this._enclosing.mIsAm = !this._enclosing.mIsAm;
				this._enclosing.updateAmPmControl();
			}

			private readonly TimePicker _enclosing;
		}

		private sealed class _OnValueChangeListener_223 : android.widget.NumberPicker.OnValueChangeListener
		{
			public _OnValueChangeListener_223(TimePicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.NumberPicker.OnValueChangeListener"
				)]
			public void onValueChange(android.widget.NumberPicker picker, int oldVal, int newVal
				)
			{
				this._enclosing.updateInputState();
				picker.requestFocus();
				this._enclosing.mIsAm = !this._enclosing.mIsAm;
				this._enclosing.updateAmPmControl();
			}

			private readonly TimePicker _enclosing;
		}

		public TimePicker(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			setCurrentLocale(System.Globalization.CultureInfo.CurrentCulture);
			android.content.res.TypedArray attributesArray = context.obtainStyledAttributes(attrs
				, android.@internal.R.styleable.TimePicker, defStyle, 0);
			int layoutResourceId = attributesArray.getResourceId(android.@internal.R.styleable
				.TimePicker_layout, android.@internal.R.layout.time_picker);
			attributesArray.recycle();
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			inflater.inflate(layoutResourceId, this, true);
			mHourSpinner = (android.widget.NumberPicker)findViewById(android.@internal.R.id.hour
				);
			mHourSpinner.setOnValueChangedListener(new _OnValueChangeListener_147(this));
			mHourSpinnerInput = (android.widget.EditText)mHourSpinner.findViewById(android.@internal.R
				.id.numberpicker_input);
			mHourSpinnerInput.setImeOptions(android.view.inputmethod.EditorInfo.IME_ACTION_NEXT
				);
			mDivider = (android.widget.TextView)findViewById(android.@internal.R.id.divider);
			if (mDivider != null)
			{
				mDivider.setText(android.@internal.R.@string.time_picker_separator);
			}
			mMinuteSpinner = (android.widget.NumberPicker)findViewById(android.@internal.R.id
				.minute);
			mMinuteSpinner.setMinValue(0);
			mMinuteSpinner.setMaxValue(59);
			mMinuteSpinner.setOnLongPressUpdateInterval(100);
			mMinuteSpinner.setFormatter(android.widget.NumberPicker.TWO_DIGIT_FORMATTER);
			mMinuteSpinner.setOnValueChangedListener(new _OnValueChangeListener_175(this));
			mMinuteSpinnerInput = (android.widget.EditText)mMinuteSpinner.findViewById(android.@internal.R
				.id.numberpicker_input);
			mMinuteSpinnerInput.setImeOptions(android.view.inputmethod.EditorInfo.IME_ACTION_NEXT
				);
			mAmPmStrings = new java.text.DateFormatSymbols().getAmPmStrings();
			android.view.View amPmView = findViewById(android.@internal.R.id.amPm);
			if (amPmView is android.widget.Button)
			{
				mAmPmSpinner = null;
				mAmPmSpinnerInput = null;
				mAmPmButton = (android.widget.Button)amPmView;
				mAmPmButton.setOnClickListener(new _OnClickListener_210(this));
			}
			else
			{
				mAmPmButton = null;
				mAmPmSpinner = (android.widget.NumberPicker)amPmView;
				mAmPmSpinner.setMinValue(0);
				mAmPmSpinner.setMaxValue(1);
				mAmPmSpinner.setDisplayedValues(mAmPmStrings);
				mAmPmSpinner.setOnValueChangedListener(new _OnValueChangeListener_223(this));
				mAmPmSpinnerInput = (android.widget.EditText)mAmPmSpinner.findViewById(android.@internal.R
					.id.numberpicker_input);
				mAmPmSpinnerInput.setImeOptions(android.view.inputmethod.EditorInfo.IME_ACTION_DONE
					);
			}
			// update controls to initial state
			updateHourControl();
			updateAmPmControl();
			setOnTimeChangedListener(NO_OP_CHANGE_LISTENER);
			// set to current time
			setCurrentHour(mTempCalendar.get(java.util.Calendar.HOUR_OF_DAY));
			setCurrentMinute(mTempCalendar.get(java.util.Calendar.MINUTE));
			if (!isEnabled())
			{
				setEnabled(false);
			}
			// set the content descriptions
			setContentDescriptions();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			if (mIsEnabled == enabled)
			{
				return;
			}
			base.setEnabled(enabled);
			mMinuteSpinner.setEnabled(enabled);
			if (mDivider != null)
			{
				mDivider.setEnabled(enabled);
			}
			mHourSpinner.setEnabled(enabled);
			if (mAmPmSpinner != null)
			{
				mAmPmSpinner.setEnabled(enabled);
			}
			else
			{
				mAmPmButton.setEnabled(enabled);
			}
			mIsEnabled = enabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool isEnabled()
		{
			return mIsEnabled;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onConfigurationChanged(android.content.res.Configuration
			 newConfig)
		{
			base.onConfigurationChanged(newConfig);
			setCurrentLocale(newConfig.locale);
		}

		/// <summary>Sets the current locale.</summary>
		/// <remarks>Sets the current locale.</remarks>
		/// <param name="locale">The current locale.</param>
		private void setCurrentLocale(System.Globalization.CultureInfo locale)
		{
			if (locale.Equals(mCurrentLocale))
			{
				return;
			}
			mCurrentLocale = locale;
			mTempCalendar = java.util.Calendar.getInstance(locale);
		}

		/// <summary>Used to save / restore state of time picker</summary>
		private class SavedState : android.view.View.BaseSavedState
		{
			internal readonly int mHour;

			internal readonly int mMinute;

			internal SavedState(android.os.Parcelable superState, int hour, int minute) : base
				(superState)
			{
				mHour = hour;
				mMinute = minute;
			}

			internal SavedState(android.os.Parcel @in) : base(@in)
			{
				mHour = @in.readInt();
				mMinute = @in.readInt();
			}

			public virtual int getHour()
			{
				return mHour;
			}

			public virtual int getMinute()
			{
				return mMinute;
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				base.writeToParcel(dest, flags);
				dest.writeInt(mHour);
				dest.writeInt(mMinute);
			}

			internal sealed class _Creator_333 : android.os.ParcelableClass.Creator<android.widget.TimePicker
				.SavedState>
			{
				public _Creator_333()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.TimePicker.SavedState createFromParcel(android.os.Parcel @in
					)
				{
					return new android.widget.TimePicker.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.TimePicker.SavedState[] newArray(int size)
				{
					return new android.widget.TimePicker.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.TimePicker
				.SavedState> CREATOR = new _Creator_333();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			return new android.widget.TimePicker.SavedState(superState, getCurrentHour(), getCurrentMinute
				());
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.widget.TimePicker.SavedState ss = (android.widget.TimePicker.SavedState)state;
			base.onRestoreInstanceState(ss.getSuperState());
			setCurrentHour(ss.getHour());
			setCurrentMinute(ss.getMinute());
		}

		/// <summary>Set the callback that indicates the time has been adjusted by the user.</summary>
		/// <remarks>Set the callback that indicates the time has been adjusted by the user.</remarks>
		/// <param name="onTimeChangedListener">the callback, should not be null.</param>
		public virtual void setOnTimeChangedListener(android.widget.TimePicker.OnTimeChangedListener
			 onTimeChangedListener)
		{
			mOnTimeChangedListener = onTimeChangedListener;
		}

		/// <returns>The current hour in the range (0-23).</returns>
		public virtual int getCurrentHour()
		{
			int currentHour = mHourSpinner.getValue();
			if (is24HourView())
			{
				return currentHour;
			}
			else
			{
				if (mIsAm)
				{
					return currentHour % HOURS_IN_HALF_DAY;
				}
				else
				{
					return (currentHour % HOURS_IN_HALF_DAY) + HOURS_IN_HALF_DAY;
				}
			}
		}

		/// <summary>Set the current hour.</summary>
		/// <remarks>Set the current hour.</remarks>
		public virtual void setCurrentHour(int currentHour)
		{
			// why was Integer used in the first place?
			if (currentHour == null || currentHour == getCurrentHour())
			{
				return;
			}
			if (!is24HourView())
			{
				// convert [0,23] ordinal to wall clock display
				if (currentHour >= HOURS_IN_HALF_DAY)
				{
					mIsAm = false;
					if (currentHour > HOURS_IN_HALF_DAY)
					{
						currentHour = currentHour - HOURS_IN_HALF_DAY;
					}
				}
				else
				{
					mIsAm = true;
					if (currentHour == 0)
					{
						currentHour = HOURS_IN_HALF_DAY;
					}
				}
				updateAmPmControl();
			}
			mHourSpinner.setValue(currentHour);
			onTimeChanged();
		}

		/// <summary>Set whether in 24 hour or AM/PM mode.</summary>
		/// <remarks>Set whether in 24 hour or AM/PM mode.</remarks>
		/// <param name="is24HourView">True = 24 hour mode. False = AM/PM.</param>
		public virtual void setIs24HourView(bool is24HourView_1)
		{
			if (mIs24HourView == is24HourView_1)
			{
				return;
			}
			mIs24HourView = is24HourView_1;
			// cache the current hour since spinner range changes
			int currentHour = getCurrentHour();
			updateHourControl();
			// set value after spinner range is updated
			setCurrentHour(currentHour);
			updateAmPmControl();
		}

		/// <returns>true if this is in 24 hour view else false.</returns>
		public virtual bool is24HourView()
		{
			return mIs24HourView;
		}

		/// <returns>The current minute.</returns>
		public virtual int getCurrentMinute()
		{
			return mMinuteSpinner.getValue();
		}

		/// <summary>Set the current minute (0-59).</summary>
		/// <remarks>Set the current minute (0-59).</remarks>
		public virtual void setCurrentMinute(int currentMinute)
		{
			if (currentMinute == getCurrentMinute())
			{
				return;
			}
			mMinuteSpinner.setValue(currentMinute);
			onTimeChanged();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			return mHourSpinner.getBaseline();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			onPopulateAccessibilityEvent(@event);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			int flags = android.text.format.DateUtils.FORMAT_SHOW_TIME;
			if (mIs24HourView)
			{
				flags |= android.text.format.DateUtils.FORMAT_24HOUR;
			}
			else
			{
				flags |= android.text.format.DateUtils.FORMAT_12HOUR;
			}
			mTempCalendar.set(java.util.Calendar.HOUR_OF_DAY, getCurrentHour());
			mTempCalendar.set(java.util.Calendar.MINUTE, getCurrentMinute());
			string selectedDateUtterance = android.text.format.DateUtils.formatDateTime(mContext
				, mTempCalendar.getTimeInMillis(), flags);
			@event.getText().add(java.lang.CharSequenceProxy.Wrap(selectedDateUtterance));
		}

		private void updateHourControl()
		{
			if (is24HourView())
			{
				mHourSpinner.setMinValue(0);
				mHourSpinner.setMaxValue(23);
				mHourSpinner.setFormatter(android.widget.NumberPicker.TWO_DIGIT_FORMATTER);
			}
			else
			{
				mHourSpinner.setMinValue(1);
				mHourSpinner.setMaxValue(12);
				mHourSpinner.setFormatter(null);
			}
		}

		private void updateAmPmControl()
		{
			if (is24HourView())
			{
				if (mAmPmSpinner != null)
				{
					mAmPmSpinner.setVisibility(android.view.View.GONE);
				}
				else
				{
					mAmPmButton.setVisibility(android.view.View.GONE);
				}
			}
			else
			{
				int index = mIsAm ? java.util.Calendar.AM : java.util.Calendar.PM;
				if (mAmPmSpinner != null)
				{
					mAmPmSpinner.setValue(index);
					mAmPmSpinner.setVisibility(android.view.View.VISIBLE);
				}
				else
				{
					mAmPmButton.setText(java.lang.CharSequenceProxy.Wrap(mAmPmStrings[index]));
					mAmPmButton.setVisibility(android.view.View.VISIBLE);
				}
			}
			sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED
				);
		}

		private void onTimeChanged()
		{
			sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED
				);
			if (mOnTimeChangedListener != null)
			{
				mOnTimeChangedListener.onTimeChanged(this, getCurrentHour(), getCurrentMinute());
			}
		}

		private void setContentDescriptions()
		{
			// Minute
			string text = mContext.getString(android.@internal.R.@string.time_picker_increment_minute_button
				);
			mMinuteSpinner.findViewById(android.@internal.R.id.increment).setContentDescription
				(java.lang.CharSequenceProxy.Wrap(text));
			text = mContext.getString(android.@internal.R.@string.time_picker_decrement_minute_button
				);
			mMinuteSpinner.findViewById(android.@internal.R.id.decrement).setContentDescription
				(java.lang.CharSequenceProxy.Wrap(text));
			// Hour
			text = mContext.getString(android.@internal.R.@string.time_picker_increment_hour_button
				);
			mHourSpinner.findViewById(android.@internal.R.id.increment).setContentDescription
				(java.lang.CharSequenceProxy.Wrap(text));
			text = mContext.getString(android.@internal.R.@string.time_picker_decrement_hour_button
				);
			mHourSpinner.findViewById(android.@internal.R.id.decrement).setContentDescription
				(java.lang.CharSequenceProxy.Wrap(text));
			// AM/PM
			if (mAmPmSpinner != null)
			{
				text = mContext.getString(android.@internal.R.@string.time_picker_increment_set_pm_button
					);
				mAmPmSpinner.findViewById(android.@internal.R.id.increment).setContentDescription
					(java.lang.CharSequenceProxy.Wrap(text));
				text = mContext.getString(android.@internal.R.@string.time_picker_decrement_set_am_button
					);
				mAmPmSpinner.findViewById(android.@internal.R.id.decrement).setContentDescription
					(java.lang.CharSequenceProxy.Wrap(text));
			}
		}

		private void updateInputState()
		{
			// Make sure that if the user changes the value and the IME is active
			// for one of the inputs if this widget, the IME is closed. If the user
			// changed the value via the IME and there is a next input the IME will
			// be shown, otherwise the user chose another means of changing the
			// value and having the IME up makes no sense.
			android.view.inputmethod.InputMethodManager inputMethodManager = android.view.inputmethod.InputMethodManager
				.peekInstance();
			if (inputMethodManager != null)
			{
				if (inputMethodManager.isActive(mHourSpinnerInput))
				{
					mHourSpinnerInput.clearFocus();
					inputMethodManager.hideSoftInputFromWindow(getWindowToken(), 0);
				}
				else
				{
					if (inputMethodManager.isActive(mMinuteSpinnerInput))
					{
						mMinuteSpinnerInput.clearFocus();
						inputMethodManager.hideSoftInputFromWindow(getWindowToken(), 0);
					}
					else
					{
						if (inputMethodManager.isActive(mAmPmSpinnerInput))
						{
							mAmPmSpinnerInput.clearFocus();
							inputMethodManager.hideSoftInputFromWindow(getWindowToken(), 0);
						}
					}
				}
			}
		}
	}
}
