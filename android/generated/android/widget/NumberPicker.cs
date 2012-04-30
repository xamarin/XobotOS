using Sharpen;

namespace android.widget
{
	/// <summary>A widget that enables the user to select a number form a predefined range.
	/// 	</summary>
	/// <remarks>
	/// A widget that enables the user to select a number form a predefined range.
	/// The widget presents an input filed and up and down buttons for selecting the
	/// current value. Pressing/long pressing the up and down buttons increments and
	/// decrements the current value respectively. Touching the input filed shows a
	/// scroll wheel, tapping on which while shown and not moving allows direct edit
	/// of the current value. Sliding motions up or down hide the buttons and the
	/// input filed, show the scroll wheel, and rotate the latter. Flinging is
	/// also supported. The widget enables mapping from positions to strings such
	/// that instead the position index the corresponding string is displayed.
	/// <p>
	/// For an example of using this widget, see
	/// <see cref="TimePicker">TimePicker</see>
	/// .
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class NumberPicker : android.widget.LinearLayout
	{
		/// <summary>The default update interval during long press.</summary>
		/// <remarks>The default update interval during long press.</remarks>
		internal const long DEFAULT_LONG_PRESS_UPDATE_INTERVAL = 300;

		/// <summary>The index of the middle selector item.</summary>
		/// <remarks>The index of the middle selector item.</remarks>
		internal const int SELECTOR_MIDDLE_ITEM_INDEX = 2;

		/// <summary>The coefficient by which to adjust (divide) the max fling velocity.</summary>
		/// <remarks>The coefficient by which to adjust (divide) the max fling velocity.</remarks>
		internal const int SELECTOR_MAX_FLING_VELOCITY_ADJUSTMENT = 8;

		/// <summary>The the duration for adjusting the selector wheel.</summary>
		/// <remarks>The the duration for adjusting the selector wheel.</remarks>
		internal const int SELECTOR_ADJUSTMENT_DURATION_MILLIS = 800;

		/// <summary>
		/// The duration of scrolling to the next/previous value while changing
		/// the current value by one, i.e.
		/// </summary>
		/// <remarks>
		/// The duration of scrolling to the next/previous value while changing
		/// the current value by one, i.e. increment or decrement.
		/// </remarks>
		internal const int CHANGE_CURRENT_BY_ONE_SCROLL_DURATION = 300;

		/// <summary>
		/// The the delay for showing the input controls after a single tap on the
		/// input text.
		/// </summary>
		/// <remarks>
		/// The the delay for showing the input controls after a single tap on the
		/// input text.
		/// </remarks>
		private static readonly int SHOW_INPUT_CONTROLS_DELAY_MILLIS = android.view.ViewConfiguration
			.getDoubleTapTimeout();

		/// <summary>The strength of fading in the top and bottom while drawing the selector.
		/// 	</summary>
		/// <remarks>The strength of fading in the top and bottom while drawing the selector.
		/// 	</remarks>
		internal const float TOP_AND_BOTTOM_FADING_EDGE_STRENGTH = 0.9f;

		/// <summary>The default unscaled height of the selection divider.</summary>
		/// <remarks>The default unscaled height of the selection divider.</remarks>
		internal const int UNSCALED_DEFAULT_SELECTION_DIVIDER_HEIGHT = 2;

		/// <summary>In this state the selector wheel is not shown.</summary>
		/// <remarks>In this state the selector wheel is not shown.</remarks>
		internal const int SELECTOR_WHEEL_STATE_NONE = 0;

		/// <summary>In this state the selector wheel is small.</summary>
		/// <remarks>In this state the selector wheel is small.</remarks>
		internal const int SELECTOR_WHEEL_STATE_SMALL = 1;

		/// <summary>In this state the selector wheel is large.</summary>
		/// <remarks>In this state the selector wheel is large.</remarks>
		internal const int SELECTOR_WHEEL_STATE_LARGE = 2;

		/// <summary>The alpha of the selector wheel when it is bright.</summary>
		/// <remarks>The alpha of the selector wheel when it is bright.</remarks>
		internal const int SELECTOR_WHEEL_BRIGHT_ALPHA = 255;

		/// <summary>The alpha of the selector wheel when it is dimmed.</summary>
		/// <remarks>The alpha of the selector wheel when it is dimmed.</remarks>
		internal const int SELECTOR_WHEEL_DIM_ALPHA = 60;

		/// <summary>The alpha for the increment/decrement button when it is transparent.</summary>
		/// <remarks>The alpha for the increment/decrement button when it is transparent.</remarks>
		internal const int BUTTON_ALPHA_TRANSPARENT = 0;

		/// <summary>The alpha for the increment/decrement button when it is opaque.</summary>
		/// <remarks>The alpha for the increment/decrement button when it is opaque.</remarks>
		internal const int BUTTON_ALPHA_OPAQUE = 1;

		/// <summary>The property for setting the selector paint.</summary>
		/// <remarks>The property for setting the selector paint.</remarks>
		internal const string PROPERTY_SELECTOR_PAINT_ALPHA = "selectorPaintAlpha";

		/// <summary>The property for setting the increment/decrement button alpha.</summary>
		/// <remarks>The property for setting the increment/decrement button alpha.</remarks>
		internal const string PROPERTY_BUTTON_ALPHA = "alpha";

		/// <summary>
		/// The numbers accepted by the input text's
		/// <see cref="android.view.LayoutInflater.Filter">android.view.LayoutInflater.Filter
		/// 	</see>
		/// </summary>
		private static readonly char[] DIGIT_CHARACTERS = new char[] { '0', '1', '2', '3'
			, '4', '5', '6', '7', '8', '9' };

		private sealed class _Formatter_175 : android.widget.NumberPicker.Formatter
		{
			public _Formatter_175()
			{
				this.mBuilder = new java.lang.StringBuilder();
				this.mFmt = new java.util.Formatter(this.mBuilder, System.Globalization.CultureInfo.InvariantCulture
					);
				this.mArgs = new object[1];
			}

			internal readonly java.lang.StringBuilder mBuilder;

			internal readonly java.util.Formatter mFmt;

			internal readonly object[] mArgs;

			[Sharpen.ImplementsInterface(@"android.widget.NumberPicker.Formatter")]
			public string format(int value)
			{
				this.mArgs[0] = value;
				this.mBuilder.delete(0, this.mBuilder.Length);
				this.mFmt.format("%02d", this.mArgs);
				return this.mFmt.ToString();
			}
		}

		/// <summary>
		/// Use a custom NumberPicker formatting callback to use two-digit minutes
		/// strings like "01".
		/// </summary>
		/// <remarks>
		/// Use a custom NumberPicker formatting callback to use two-digit minutes
		/// strings like "01". Keeping a static formatter etc. is the most efficient
		/// way to do this; it avoids creating temporary objects on every call to
		/// format().
		/// </remarks>
		/// <hide></hide>
		public static readonly android.widget.NumberPicker.Formatter TWO_DIGIT_FORMATTER = 
			new _Formatter_175();

		/// <summary>The increment button.</summary>
		/// <remarks>The increment button.</remarks>
		private readonly android.widget.ImageButton mIncrementButton;

		/// <summary>The decrement button.</summary>
		/// <remarks>The decrement button.</remarks>
		private readonly android.widget.ImageButton mDecrementButton;

		/// <summary>The text for showing the current value.</summary>
		/// <remarks>The text for showing the current value.</remarks>
		private readonly android.widget.EditText mInputText;

		/// <summary>The height of the text.</summary>
		/// <remarks>The height of the text.</remarks>
		private readonly int mTextSize;

		/// <summary>The height of the gap between text elements if the selector wheel.</summary>
		/// <remarks>The height of the gap between text elements if the selector wheel.</remarks>
		private int mSelectorTextGapHeight;

		/// <summary>The values to be displayed instead the indices.</summary>
		/// <remarks>The values to be displayed instead the indices.</remarks>
		private string[] mDisplayedValues;

		/// <summary>Lower value of the range of numbers allowed for the NumberPicker</summary>
		private int mMinValue;

		/// <summary>Upper value of the range of numbers allowed for the NumberPicker</summary>
		private int mMaxValue;

		/// <summary>Current value of this NumberPicker</summary>
		private int mValue;

		/// <summary>Listener to be notified upon current value change.</summary>
		/// <remarks>Listener to be notified upon current value change.</remarks>
		private android.widget.NumberPicker.OnValueChangeListener mOnValueChangeListener;

		/// <summary>Listener to be notified upon scroll state change.</summary>
		/// <remarks>Listener to be notified upon scroll state change.</remarks>
		private android.widget.NumberPicker.OnScrollListener mOnScrollListener;

		/// <summary>Formatter for for displaying the current value.</summary>
		/// <remarks>Formatter for for displaying the current value.</remarks>
		private android.widget.NumberPicker.Formatter mFormatter;

		/// <summary>The speed for updating the value form long press.</summary>
		/// <remarks>The speed for updating the value form long press.</remarks>
		private long mLongPressUpdateInterval = DEFAULT_LONG_PRESS_UPDATE_INTERVAL;

		/// <summary>Cache for the string representation of selector indices.</summary>
		/// <remarks>Cache for the string representation of selector indices.</remarks>
		private readonly android.util.SparseArray<string> mSelectorIndexToStringCache = new 
			android.util.SparseArray<string>();

		/// <summary>The selector indices whose value are show by the selector.</summary>
		/// <remarks>The selector indices whose value are show by the selector.</remarks>
		private readonly int[] mSelectorIndices = new int[] { int.MinValue, int.MinValue, 
			int.MinValue, int.MinValue, int.MinValue };

		/// <summary>
		/// The
		/// <see cref="android.graphics.Paint">android.graphics.Paint</see>
		/// for drawing the selector.
		/// </summary>
		private readonly android.graphics.Paint mSelectorWheelPaint;

		/// <summary>The height of a selector element (text + gap).</summary>
		/// <remarks>The height of a selector element (text + gap).</remarks>
		private int mSelectorElementHeight;

		/// <summary>The initial offset of the scroll selector.</summary>
		/// <remarks>The initial offset of the scroll selector.</remarks>
		private int mInitialScrollOffset = int.MinValue;

		/// <summary>The current offset of the scroll selector.</summary>
		/// <remarks>The current offset of the scroll selector.</remarks>
		private int mCurrentScrollOffset;

		/// <summary>
		/// The
		/// <see cref="Scroller">Scroller</see>
		/// responsible for flinging the selector.
		/// </summary>
		private readonly android.widget.Scroller mFlingScroller;

		/// <summary>
		/// The
		/// <see cref="Scroller">Scroller</see>
		/// responsible for adjusting the selector.
		/// </summary>
		private readonly android.widget.Scroller mAdjustScroller;

		/// <summary>The previous Y coordinate while scrolling the selector.</summary>
		/// <remarks>The previous Y coordinate while scrolling the selector.</remarks>
		private int mPreviousScrollerY;

		/// <summary>Handle to the reusable command for setting the input text selection.</summary>
		/// <remarks>Handle to the reusable command for setting the input text selection.</remarks>
		private android.widget.NumberPicker.SetSelectionCommand mSetSelectionCommand;

		/// <summary>Handle to the reusable command for adjusting the scroller.</summary>
		/// <remarks>Handle to the reusable command for adjusting the scroller.</remarks>
		private android.widget.NumberPicker.AdjustScrollerCommand mAdjustScrollerCommand;

		/// <summary>
		/// Handle to the reusable command for changing the current value from long
		/// press by one.
		/// </summary>
		/// <remarks>
		/// Handle to the reusable command for changing the current value from long
		/// press by one.
		/// </remarks>
		private android.widget.NumberPicker.ChangeCurrentByOneFromLongPressCommand mChangeCurrentByOneFromLongPressCommand;

		/// <summary>
		/// <see cref="android.animation.Animator">android.animation.Animator</see>
		/// for showing the up/down arrows.
		/// </summary>
		private readonly android.animation.AnimatorSet mShowInputControlsAnimator;

		/// <summary>
		/// <see cref="android.animation.Animator">android.animation.Animator</see>
		/// for dimming the selector wheel.
		/// </summary>
		private readonly android.animation.Animator mDimSelectorWheelAnimator;

		/// <summary>The Y position of the last down event.</summary>
		/// <remarks>The Y position of the last down event.</remarks>
		private float mLastDownEventY;

		/// <summary>The Y position of the last motion event.</summary>
		/// <remarks>The Y position of the last motion event.</remarks>
		private float mLastMotionEventY;

		/// <summary>Flag if to begin edit on next up event.</summary>
		/// <remarks>Flag if to begin edit on next up event.</remarks>
		private bool mBeginEditOnUpEvent;

		/// <summary>Flag if to adjust the selector wheel on next up event.</summary>
		/// <remarks>Flag if to adjust the selector wheel on next up event.</remarks>
		private bool mAdjustScrollerOnUpEvent;

		/// <summary>The state of the selector wheel.</summary>
		/// <remarks>The state of the selector wheel.</remarks>
		private int mSelectorWheelState;

		/// <summary>Determines speed during touch scrolling.</summary>
		/// <remarks>Determines speed during touch scrolling.</remarks>
		private android.view.VelocityTracker mVelocityTracker;

		/// <seealso cref="android.view.ViewConfiguration.getScaledTouchSlop()">android.view.ViewConfiguration.getScaledTouchSlop()
		/// 	</seealso>
		private int mTouchSlop;

		/// <seealso cref="android.view.ViewConfiguration.getScaledMinimumFlingVelocity()">android.view.ViewConfiguration.getScaledMinimumFlingVelocity()
		/// 	</seealso>
		private int mMinimumFlingVelocity;

		/// <seealso cref="android.view.ViewConfiguration.getScaledMaximumFlingVelocity()">android.view.ViewConfiguration.getScaledMaximumFlingVelocity()
		/// 	</seealso>
		private int mMaximumFlingVelocity;

		/// <summary>Flag whether the selector should wrap around.</summary>
		/// <remarks>Flag whether the selector should wrap around.</remarks>
		private bool mWrapSelectorWheel;

		/// <summary>The back ground color used to optimize scroller fading.</summary>
		/// <remarks>The back ground color used to optimize scroller fading.</remarks>
		private readonly int mSolidColor;

		/// <summary>Flag indicating if this widget supports flinging.</summary>
		/// <remarks>Flag indicating if this widget supports flinging.</remarks>
		private readonly bool mFlingable;

		/// <summary>Divider for showing item to be selected while scrolling</summary>
		private readonly android.graphics.drawable.Drawable mSelectionDivider;

		/// <summary>The height of the selection divider.</summary>
		/// <remarks>The height of the selection divider.</remarks>
		private readonly int mSelectionDividerHeight;

		/// <summary>
		/// Reusable
		/// <see cref="android.graphics.Rect">android.graphics.Rect</see>
		/// instance.
		/// </summary>
		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		/// <summary>The current scroll state of the number picker.</summary>
		/// <remarks>The current scroll state of the number picker.</remarks>
		private int mScrollState = android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE;

		/// <summary>The duration of the animation for showing the input controls.</summary>
		/// <remarks>The duration of the animation for showing the input controls.</remarks>
		private readonly long mShowInputControlsAnimimationDuration;

		/// <summary>Flag whether the scoll wheel and the fading edges have been initialized.
		/// 	</summary>
		/// <remarks>Flag whether the scoll wheel and the fading edges have been initialized.
		/// 	</remarks>
		private bool mScrollWheelAndFadingEdgesInitialized;

		/// <summary>Interface to listen for changes of the current value.</summary>
		/// <remarks>Interface to listen for changes of the current value.</remarks>
		public interface OnValueChangeListener
		{
			/// <summary>Called upon a change of the current value.</summary>
			/// <remarks>Called upon a change of the current value.</remarks>
			/// <param name="picker">The NumberPicker associated with this listener.</param>
			/// <param name="oldVal">The previous value.</param>
			/// <param name="newVal">The new value.</param>
			void onValueChange(android.widget.NumberPicker picker, int oldVal, int newVal);
		}

		/// <summary>Interface to listen for the picker scroll state.</summary>
		/// <remarks>Interface to listen for the picker scroll state.</remarks>
		public interface OnScrollListener
		{
			/// <summary>Callback invoked while the number picker scroll state has changed.</summary>
			/// <remarks>Callback invoked while the number picker scroll state has changed.</remarks>
			/// <param name="view">The view whose scroll state is being reported.</param>
			/// <param name="scrollState">
			/// The current scroll state. One of
			/// <see cref="android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE">android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE
			/// 	</see>
			/// ,
			/// <see cref="android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
			/// 	">android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL</see>
			/// or
			/// <see cref="android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE">android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE
			/// 	</see>
			/// .
			/// </param>
			void onScrollStateChange(android.widget.NumberPicker view, int scrollState);
		}

		/// <summary>Interface to listen for the picker scroll state.</summary>
		/// <remarks>Interface to listen for the picker scroll state.</remarks>
		public static class OnScrollListenerClass
		{
			/// <summary>The view is not scrolling.</summary>
			/// <remarks>The view is not scrolling.</remarks>
			public const int SCROLL_STATE_IDLE = 0;

			/// <summary>The user is scrolling using touch, and their finger is still on the screen.
			/// 	</summary>
			/// <remarks>The user is scrolling using touch, and their finger is still on the screen.
			/// 	</remarks>
			public const int SCROLL_STATE_TOUCH_SCROLL = 1;

			/// <summary>The user had previously been scrolling using touch and performed a fling.
			/// 	</summary>
			/// <remarks>The user had previously been scrolling using touch and performed a fling.
			/// 	</remarks>
			public const int SCROLL_STATE_FLING = 2;
		}

		/// <summary>Interface used to format current value into a string for presentation.</summary>
		/// <remarks>Interface used to format current value into a string for presentation.</remarks>
		public interface Formatter
		{
			/// <summary>Formats a string representation of the current value.</summary>
			/// <remarks>Formats a string representation of the current value.</remarks>
			/// <param name="value">The currently selected value.</param>
			/// <returns>A formatted string representation.</returns>
			string format(int value);
		}

		/// <summary>Create a new number picker.</summary>
		/// <remarks>Create a new number picker.</remarks>
		/// <param name="context">The application environment.</param>
		public NumberPicker(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>Create a new number picker.</summary>
		/// <remarks>Create a new number picker.</remarks>
		/// <param name="context">The application environment.</param>
		/// <param name="attrs">A collection of attributes.</param>
		public NumberPicker(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.numberPickerStyle)
		{
		}

		private sealed class _OnClickListener_537 : android.view.View.OnClickListener
		{
			public _OnClickListener_537(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// process style attributes
			// By default Linearlayout that we extend is not drawn. This is
			// its draw() method is not called but dispatchDraw() is called
			// directly (see ViewGroup.drawChild()). However, this class uses
			// the fading edge effect implemented by View and we need our
			// draw() method to be called. Therefore, we declare we will draw.
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				android.view.inputmethod.InputMethodManager inputMethodManager = android.view.inputmethod.InputMethodManager
					.peekInstance();
				if (inputMethodManager != null && inputMethodManager.isActive(this._enclosing.mInputText
					))
				{
					inputMethodManager.hideSoftInputFromWindow(this._enclosing.getWindowToken(), 0);
				}
				this._enclosing.mInputText.clearFocus();
				if (v.getId() == android.@internal.R.id.increment)
				{
					this._enclosing.changeCurrentByOne(true);
				}
				else
				{
					this._enclosing.changeCurrentByOne(false);
				}
			}

			private readonly NumberPicker _enclosing;
		}

		private sealed class _OnLongClickListener_552 : android.view.View.OnLongClickListener
		{
			public _OnLongClickListener_552(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnLongClickListener")]
			public bool onLongClick(android.view.View v)
			{
				this._enclosing.mInputText.clearFocus();
				if (v.getId() == android.@internal.R.id.increment)
				{
					this._enclosing.postChangeCurrentByOneFromLongPress(true);
				}
				else
				{
					this._enclosing.postChangeCurrentByOneFromLongPress(false);
				}
				return true;
			}

			private readonly NumberPicker _enclosing;
		}

		private sealed class _OnFocusChangeListener_576 : android.view.View.OnFocusChangeListener
		{
			public _OnFocusChangeListener_576(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// increment button
			// decrement button
			// input text
			[Sharpen.ImplementsInterface(@"android.view.View.OnFocusChangeListener")]
			public void onFocusChange(android.view.View v, bool hasFocus_1)
			{
				if (hasFocus_1)
				{
					this._enclosing.mInputText.selectAll();
					android.view.inputmethod.InputMethodManager inputMethodManager = android.view.inputmethod.InputMethodManager
						.peekInstance();
					if (inputMethodManager != null)
					{
						inputMethodManager.showSoftInput(this._enclosing.mInputText, 0);
					}
				}
				else
				{
					this._enclosing.mInputText.setSelection(0, 0);
					this._enclosing.validateInputTextView(v);
				}
			}

			private readonly NumberPicker _enclosing;
		}

		private sealed class _AnimatorListenerAdapter_626 : android.animation.AnimatorListenerAdapter
		{
			public _AnimatorListenerAdapter_626(NumberPicker _enclosing)
			{
				this.mCanceled = false;
				this._enclosing = _enclosing;
			}

			private bool mCanceled;

			// initialize constants
			// create the selector wheel paint
			// create the animator for showing the input controls
			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationEnd(android.animation.Animator animation)
			{
				if (!this.mCanceled)
				{
					// if canceled => we still want the wheel drawn
					this._enclosing.setSelectorWheelState(android.widget.NumberPicker.SELECTOR_WHEEL_STATE_SMALL
						);
				}
				this.mCanceled = false;
			}

			[Sharpen.OverridesMethod(@"android.animation.AnimatorListenerAdapter")]
			public override void onAnimationCancel(android.animation.Animator animation)
			{
				if (this._enclosing.mShowInputControlsAnimator.isRunning())
				{
					this.mCanceled = true;
				}
			}

			private readonly NumberPicker _enclosing;
		}

		/// <summary>Create a new number picker</summary>
		/// <param name="context">the application environment.</param>
		/// <param name="attrs">a collection of attributes.</param>
		/// <param name="defStyle">The default style to apply to this view.</param>
		public NumberPicker(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray attributesArray = context.obtainStyledAttributes(attrs
				, android.@internal.R.styleable.NumberPicker, defStyle, 0);
			mSolidColor = attributesArray.getColor(android.@internal.R.styleable.NumberPicker_solidColor
				, 0);
			mFlingable = attributesArray.getBoolean(android.@internal.R.styleable.NumberPicker_flingable
				, true);
			mSelectionDivider = attributesArray.getDrawable(android.@internal.R.styleable.NumberPicker_selectionDivider
				);
			int defSelectionDividerHeight = (int)android.util.TypedValue.applyDimension(android.util.TypedValue
				.COMPLEX_UNIT_DIP, UNSCALED_DEFAULT_SELECTION_DIVIDER_HEIGHT, getResources().getDisplayMetrics
				());
			mSelectionDividerHeight = attributesArray.getDimensionPixelSize(android.@internal.R
				.styleable.NumberPicker_selectionDividerHeight, defSelectionDividerHeight);
			attributesArray.recycle();
			mShowInputControlsAnimimationDuration = getResources().getInteger(android.@internal.R
				.integer.config_longAnimTime);
			setWillNotDraw(false);
			setSelectorWheelState(SELECTOR_WHEEL_STATE_NONE);
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)getContext().
				getSystemService(android.content.Context.LAYOUT_INFLATER_SERVICE);
			inflater.inflate(android.@internal.R.layout.number_picker, this, true);
			android.view.View.OnClickListener onClickListener = new _OnClickListener_537(this
				);
			android.view.View.OnLongClickListener onLongClickListener = new _OnLongClickListener_552
				(this);
			mIncrementButton = (android.widget.ImageButton)findViewById(android.@internal.R.id
				.increment);
			mIncrementButton.setOnClickListener(onClickListener);
			mIncrementButton.setOnLongClickListener(onLongClickListener);
			mDecrementButton = (android.widget.ImageButton)findViewById(android.@internal.R.id
				.decrement);
			mDecrementButton.setOnClickListener(onClickListener);
			mDecrementButton.setOnLongClickListener(onLongClickListener);
			mInputText = (android.widget.EditText)findViewById(android.@internal.R.id.numberpicker_input
				);
			mInputText.setOnFocusChangeListener(new _OnFocusChangeListener_576(this));
			mInputText.setFilters(new android.text.InputFilter[] { new android.widget.NumberPicker
				.InputTextFilter(this) });
			mInputText.setRawInputType(android.text.InputTypeClass.TYPE_CLASS_NUMBER);
			mTouchSlop = android.view.ViewConfiguration.getTapTimeout();
			android.view.ViewConfiguration configuration = android.view.ViewConfiguration.get
				(context);
			mTouchSlop = configuration.getScaledTouchSlop();
			mMinimumFlingVelocity = configuration.getScaledMinimumFlingVelocity();
			mMaximumFlingVelocity = configuration.getScaledMaximumFlingVelocity() / SELECTOR_MAX_FLING_VELOCITY_ADJUSTMENT;
			mTextSize = (int)mInputText.getTextSize();
			android.graphics.Paint paint = new android.graphics.Paint();
			paint.setAntiAlias(true);
			paint.setTextAlign(android.graphics.Paint.Align.CENTER);
			paint.setTextSize(mTextSize);
			paint.setTypeface(mInputText.getTypeface());
			android.content.res.ColorStateList colors = mInputText.getTextColors();
			int color = colors.getColorForState(ENABLED_STATE_SET, android.graphics.Color.WHITE
				);
			paint.setColor(color);
			mSelectorWheelPaint = paint;
			mDimSelectorWheelAnimator = android.animation.ObjectAnimator.ofInt(this, PROPERTY_SELECTOR_PAINT_ALPHA
				, SELECTOR_WHEEL_BRIGHT_ALPHA, SELECTOR_WHEEL_DIM_ALPHA);
			android.animation.ObjectAnimator showIncrementButton = android.animation.ObjectAnimator
				.ofFloat(mIncrementButton, PROPERTY_BUTTON_ALPHA, BUTTON_ALPHA_TRANSPARENT, BUTTON_ALPHA_OPAQUE
				);
			android.animation.ObjectAnimator showDecrementButton = android.animation.ObjectAnimator
				.ofFloat(mDecrementButton, PROPERTY_BUTTON_ALPHA, BUTTON_ALPHA_TRANSPARENT, BUTTON_ALPHA_OPAQUE
				);
			mShowInputControlsAnimator = new android.animation.AnimatorSet();
			mShowInputControlsAnimator.playTogether(mDimSelectorWheelAnimator, showIncrementButton
				, showDecrementButton);
			mShowInputControlsAnimator.addListener(new _AnimatorListenerAdapter_626(this));
			// create the fling and adjust scrollers
			mFlingScroller = new android.widget.Scroller(getContext(), null, true);
			mAdjustScroller = new android.widget.Scroller(getContext(), new android.view.animation.DecelerateInterpolator
				(2.5f));
			updateInputTextView();
			updateIncrementAndDecrementButtonsVisibilityState();
			if (mFlingable)
			{
				if (isInEditMode())
				{
					setSelectorWheelState(SELECTOR_WHEEL_STATE_SMALL);
				}
				else
				{
					// Start with shown selector wheel and hidden controls. When made
					// visible hide the selector and fade-in the controls to suggest
					// fling interaction.
					setSelectorWheelState(SELECTOR_WHEEL_STATE_LARGE);
					hideInputControls();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			base.onLayout(changed, left, top, right, bottom);
			if (!mScrollWheelAndFadingEdgesInitialized)
			{
				mScrollWheelAndFadingEdgesInitialized = true;
				// need to do all this when we know our size
				initializeSelectorWheel();
				initializeFadingEdges();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override bool onInterceptTouchEvent(android.view.MotionEvent @event)
		{
			if (!isEnabled() || !mFlingable)
			{
				return false;
			}
			switch (@event.getActionMasked())
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					mLastMotionEventY = mLastDownEventY = @event.getY();
					removeAllCallbacks();
					mShowInputControlsAnimator.cancel();
					mDimSelectorWheelAnimator.cancel();
					mBeginEditOnUpEvent = false;
					mAdjustScrollerOnUpEvent = true;
					if (mSelectorWheelState == SELECTOR_WHEEL_STATE_LARGE)
					{
						bool scrollersFinished = mFlingScroller.isFinished() && mAdjustScroller.isFinished
							();
						if (!scrollersFinished)
						{
							mFlingScroller.forceFinished(true);
							mAdjustScroller.forceFinished(true);
							onScrollStateChange(android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE
								);
						}
						mBeginEditOnUpEvent = scrollersFinished;
						mAdjustScrollerOnUpEvent = true;
						hideInputControls();
						return true;
					}
					if (isEventInViewHitRect(@event, mInputText) || (!mIncrementButton.isShown() && isEventInViewHitRect
						(@event, mIncrementButton)) || (!mDecrementButton.isShown() && isEventInViewHitRect
						(@event, mDecrementButton)))
					{
						mAdjustScrollerOnUpEvent = false;
						setSelectorWheelState(SELECTOR_WHEEL_STATE_LARGE);
						hideInputControls();
						return true;
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					float currentMoveY = @event.getY();
					int deltaDownY = (int)System.Math.Abs(currentMoveY - mLastDownEventY);
					if (deltaDownY > mTouchSlop)
					{
						mBeginEditOnUpEvent = false;
						onScrollStateChange(android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
							);
						setSelectorWheelState(SELECTOR_WHEEL_STATE_LARGE);
						hideInputControls();
						return true;
					}
					break;
				}
			}
			return false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			if (!isEnabled())
			{
				return false;
			}
			if (mVelocityTracker == null)
			{
				mVelocityTracker = android.view.VelocityTracker.obtain();
			}
			mVelocityTracker.addMovement(ev);
			int action = ev.getActionMasked();
			switch (action)
			{
				case android.view.MotionEvent.ACTION_MOVE:
				{
					float currentMoveY = ev.getY();
					if (mBeginEditOnUpEvent || mScrollState != android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL)
					{
						int deltaDownY = (int)System.Math.Abs(currentMoveY - mLastDownEventY);
						if (deltaDownY > mTouchSlop)
						{
							mBeginEditOnUpEvent = false;
							onScrollStateChange(android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
								);
						}
					}
					int deltaMoveY = (int)(currentMoveY - mLastMotionEventY);
					scrollBy(0, deltaMoveY);
					invalidate();
					mLastMotionEventY = currentMoveY;
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					if (mBeginEditOnUpEvent)
					{
						setSelectorWheelState(SELECTOR_WHEEL_STATE_SMALL);
						showInputControls(mShowInputControlsAnimimationDuration);
						mInputText.requestFocus();
						return true;
					}
					android.view.VelocityTracker velocityTracker = mVelocityTracker;
					velocityTracker.computeCurrentVelocity(1000, mMaximumFlingVelocity);
					int initialVelocity = (int)velocityTracker.getYVelocity();
					if (System.Math.Abs(initialVelocity) > mMinimumFlingVelocity)
					{
						fling(initialVelocity);
						onScrollStateChange(android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_FLING
							);
					}
					else
					{
						if (mAdjustScrollerOnUpEvent)
						{
							if (mFlingScroller.isFinished() && mAdjustScroller.isFinished())
							{
								postAdjustScrollerCommand(0);
							}
						}
						else
						{
							postAdjustScrollerCommand(SHOW_INPUT_CONTROLS_DELAY_MILLIS);
						}
					}
					mVelocityTracker.recycle();
					mVelocityTracker = null;
					break;
				}
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchTouchEvent(android.view.MotionEvent @event)
		{
			int action = @event.getActionMasked();
			switch (action)
			{
				case android.view.MotionEvent.ACTION_MOVE:
				{
					if (mSelectorWheelState == SELECTOR_WHEEL_STATE_LARGE)
					{
						removeAllCallbacks();
						forceCompleteChangeCurrentByOneViaScroll();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				case android.view.MotionEvent.ACTION_UP:
				{
					removeAllCallbacks();
					break;
				}
			}
			return base.dispatchTouchEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchKeyEvent(android.view.KeyEvent @event)
		{
			int keyCode = @event.getKeyCode();
			if (keyCode == android.view.KeyEvent.KEYCODE_DPAD_CENTER || keyCode == android.view.KeyEvent
				.KEYCODE_ENTER)
			{
				removeAllCallbacks();
			}
			return base.dispatchKeyEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchTrackballEvent(android.view.MotionEvent @event)
		{
			int action = @event.getActionMasked();
			if (action == android.view.MotionEvent.ACTION_CANCEL || action == android.view.MotionEvent
				.ACTION_UP)
			{
				removeAllCallbacks();
			}
			return base.dispatchTrackballEvent(@event);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void computeScroll()
		{
			if (mSelectorWheelState == SELECTOR_WHEEL_STATE_NONE)
			{
				return;
			}
			android.widget.Scroller scroller = mFlingScroller;
			if (scroller.isFinished())
			{
				scroller = mAdjustScroller;
				if (scroller.isFinished())
				{
					return;
				}
			}
			scroller.computeScrollOffset();
			int currentScrollerY = scroller.getCurrY();
			if (mPreviousScrollerY == 0)
			{
				mPreviousScrollerY = scroller.getStartY();
			}
			scrollBy(0, currentScrollerY - mPreviousScrollerY);
			mPreviousScrollerY = currentScrollerY;
			if (scroller.isFinished())
			{
				onScrollerFinished(scroller);
			}
			else
			{
				invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			base.setEnabled(enabled);
			mIncrementButton.setEnabled(enabled);
			mDecrementButton.setEnabled(enabled);
			mInputText.setEnabled(enabled);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void scrollBy(int x, int y)
		{
			if (mSelectorWheelState == SELECTOR_WHEEL_STATE_NONE)
			{
				return;
			}
			int[] selectorIndices = mSelectorIndices;
			if (!mWrapSelectorWheel && y > 0 && selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX] <=
				 mMinValue)
			{
				mCurrentScrollOffset = mInitialScrollOffset;
				return;
			}
			if (!mWrapSelectorWheel && y < 0 && selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX] >=
				 mMaxValue)
			{
				mCurrentScrollOffset = mInitialScrollOffset;
				return;
			}
			mCurrentScrollOffset += y;
			while (mCurrentScrollOffset - mInitialScrollOffset > mSelectorTextGapHeight)
			{
				mCurrentScrollOffset -= mSelectorElementHeight;
				decrementSelectorIndices(selectorIndices);
				changeCurrent(selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX]);
				if (!mWrapSelectorWheel && selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX] <= mMinValue)
				{
					mCurrentScrollOffset = mInitialScrollOffset;
				}
			}
			while (mCurrentScrollOffset - mInitialScrollOffset < -mSelectorTextGapHeight)
			{
				mCurrentScrollOffset += mSelectorElementHeight;
				incrementSelectorIndices(selectorIndices);
				changeCurrent(selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX]);
				if (!mWrapSelectorWheel && selectorIndices[SELECTOR_MIDDLE_ITEM_INDEX] >= mMaxValue)
				{
					mCurrentScrollOffset = mInitialScrollOffset;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getSolidColor()
		{
			return mSolidColor;
		}

		/// <summary>Sets the listener to be notified on change of the current value.</summary>
		/// <remarks>Sets the listener to be notified on change of the current value.</remarks>
		/// <param name="onValueChangedListener">The listener.</param>
		public virtual void setOnValueChangedListener(android.widget.NumberPicker.OnValueChangeListener
			 onValueChangedListener)
		{
			mOnValueChangeListener = onValueChangedListener;
		}

		/// <summary>Set listener to be notified for scroll state changes.</summary>
		/// <remarks>Set listener to be notified for scroll state changes.</remarks>
		/// <param name="onScrollListener">The listener.</param>
		public virtual void setOnScrollListener(android.widget.NumberPicker.OnScrollListener
			 onScrollListener)
		{
			mOnScrollListener = onScrollListener;
		}

		/// <summary>Set the formatter to be used for formatting the current value.</summary>
		/// <remarks>
		/// Set the formatter to be used for formatting the current value.
		/// <p>
		/// Note: If you have provided alternative values for the values this
		/// formatter is never invoked.
		/// </p>
		/// </remarks>
		/// <param name="formatter">
		/// The formatter object. If formatter is <code>null</code>,
		/// <see cref="string.ToString(int)">string.ToString(int)</see>
		/// will be used.
		/// </param>
		/// <seealso cref="setDisplayedValues(string[])">setDisplayedValues(string[])</seealso>
		public virtual void setFormatter(android.widget.NumberPicker.Formatter formatter)
		{
			if (formatter == mFormatter)
			{
				return;
			}
			mFormatter = formatter;
			initializeSelectorWheelIndices();
			updateInputTextView();
		}

		/// <summary>Set the current value for the number picker.</summary>
		/// <remarks>
		/// Set the current value for the number picker.
		/// <p>
		/// If the argument is less than the
		/// <see cref="getMinValue()">getMinValue()</see>
		/// and
		/// <see cref="getWrapSelectorWheel()">getWrapSelectorWheel()</see>
		/// is <code>false</code> the
		/// current value is set to the
		/// <see cref="getMinValue()">getMinValue()</see>
		/// value.
		/// </p>
		/// <p>
		/// If the argument is less than the
		/// <see cref="getMinValue()">getMinValue()</see>
		/// and
		/// <see cref="getWrapSelectorWheel()">getWrapSelectorWheel()</see>
		/// is <code>true</code> the
		/// current value is set to the
		/// <see cref="getMaxValue()">getMaxValue()</see>
		/// value.
		/// </p>
		/// <p>
		/// If the argument is less than the
		/// <see cref="getMaxValue()">getMaxValue()</see>
		/// and
		/// <see cref="getWrapSelectorWheel()">getWrapSelectorWheel()</see>
		/// is <code>false</code> the
		/// current value is set to the
		/// <see cref="getMaxValue()">getMaxValue()</see>
		/// value.
		/// </p>
		/// <p>
		/// If the argument is less than the
		/// <see cref="getMaxValue()">getMaxValue()</see>
		/// and
		/// <see cref="getWrapSelectorWheel()">getWrapSelectorWheel()</see>
		/// is <code>true</code> the
		/// current value is set to the
		/// <see cref="getMinValue()">getMinValue()</see>
		/// value.
		/// </p>
		/// </remarks>
		/// <param name="value">The current value.</param>
		/// <seealso cref="setWrapSelectorWheel(bool)">setWrapSelectorWheel(bool)</seealso>
		/// <seealso cref="setMinValue(int)">setMinValue(int)</seealso>
		/// <seealso cref="setMaxValue(int)">setMaxValue(int)</seealso>
		public virtual void setValue(int value)
		{
			if (mValue == value)
			{
				return;
			}
			if (value < mMinValue)
			{
				value = mWrapSelectorWheel ? mMaxValue : mMinValue;
			}
			if (value > mMaxValue)
			{
				value = mWrapSelectorWheel ? mMinValue : mMaxValue;
			}
			mValue = value;
			initializeSelectorWheelIndices();
			updateInputTextView();
			updateIncrementAndDecrementButtonsVisibilityState();
			invalidate();
		}

		/// <summary>Gets whether the selector wheel wraps when reaching the min/max value.</summary>
		/// <remarks>Gets whether the selector wheel wraps when reaching the min/max value.</remarks>
		/// <returns>True if the selector wheel wraps.</returns>
		/// <seealso cref="getMinValue()">getMinValue()</seealso>
		/// <seealso cref="getMaxValue()">getMaxValue()</seealso>
		public virtual bool getWrapSelectorWheel()
		{
			return mWrapSelectorWheel;
		}

		/// <summary>
		/// Sets whether the selector wheel shown during flinging/scrolling should
		/// wrap around the
		/// <see cref="getMinValue()">getMinValue()</see>
		/// and
		/// <see cref="getMaxValue()">getMaxValue()</see>
		/// values.
		/// <p>
		/// By default if the range (max - min) is more than five (the number of
		/// items shown on the selector wheel) the selector wheel wrapping is
		/// enabled.
		/// </p>
		/// </summary>
		/// <param name="wrapSelectorWheel">Whether to wrap.</param>
		public virtual void setWrapSelectorWheel(bool wrapSelectorWheel)
		{
			if (wrapSelectorWheel && (mMaxValue - mMinValue) < mSelectorIndices.Length)
			{
				throw new System.InvalidOperationException("Range less than selector items count."
					);
			}
			if (wrapSelectorWheel != mWrapSelectorWheel)
			{
				mWrapSelectorWheel = wrapSelectorWheel;
				updateIncrementAndDecrementButtonsVisibilityState();
			}
		}

		/// <summary>
		/// Sets the speed at which the numbers be incremented and decremented when
		/// the up and down buttons are long pressed respectively.
		/// </summary>
		/// <remarks>
		/// Sets the speed at which the numbers be incremented and decremented when
		/// the up and down buttons are long pressed respectively.
		/// <p>
		/// The default value is 300 ms.
		/// </p>
		/// </remarks>
		/// <param name="intervalMillis">
		/// The speed (in milliseconds) at which the numbers
		/// will be incremented and decremented.
		/// </param>
		public virtual void setOnLongPressUpdateInterval(long intervalMillis)
		{
			mLongPressUpdateInterval = intervalMillis;
		}

		/// <summary>Returns the value of the picker.</summary>
		/// <remarks>Returns the value of the picker.</remarks>
		/// <returns>The value.</returns>
		public virtual int getValue()
		{
			return mValue;
		}

		/// <summary>Returns the min value of the picker.</summary>
		/// <remarks>Returns the min value of the picker.</remarks>
		/// <returns>The min value</returns>
		public virtual int getMinValue()
		{
			return mMinValue;
		}

		/// <summary>Sets the min value of the picker.</summary>
		/// <remarks>Sets the min value of the picker.</remarks>
		/// <param name="minValue">The min value.</param>
		public virtual void setMinValue(int minValue)
		{
			if (mMinValue == minValue)
			{
				return;
			}
			if (minValue < 0)
			{
				throw new System.ArgumentException("minValue must be >= 0");
			}
			mMinValue = minValue;
			if (mMinValue > mValue)
			{
				mValue = mMinValue;
			}
			bool wrapSelectorWheel = mMaxValue - mMinValue > mSelectorIndices.Length;
			setWrapSelectorWheel(wrapSelectorWheel);
			initializeSelectorWheelIndices();
			updateInputTextView();
		}

		/// <summary>Returns the max value of the picker.</summary>
		/// <remarks>Returns the max value of the picker.</remarks>
		/// <returns>The max value.</returns>
		public virtual int getMaxValue()
		{
			return mMaxValue;
		}

		/// <summary>Sets the max value of the picker.</summary>
		/// <remarks>Sets the max value of the picker.</remarks>
		/// <param name="maxValue">The max value.</param>
		public virtual void setMaxValue(int maxValue)
		{
			if (mMaxValue == maxValue)
			{
				return;
			}
			if (maxValue < 0)
			{
				throw new System.ArgumentException("maxValue must be >= 0");
			}
			mMaxValue = maxValue;
			if (mMaxValue < mValue)
			{
				mValue = mMaxValue;
			}
			bool wrapSelectorWheel = mMaxValue - mMinValue > mSelectorIndices.Length;
			setWrapSelectorWheel(wrapSelectorWheel);
			initializeSelectorWheelIndices();
			updateInputTextView();
		}

		/// <summary>Gets the values to be displayed instead of string values.</summary>
		/// <remarks>Gets the values to be displayed instead of string values.</remarks>
		/// <returns>The displayed values.</returns>
		public virtual string[] getDisplayedValues()
		{
			return mDisplayedValues;
		}

		/// <summary>Sets the values to be displayed.</summary>
		/// <remarks>Sets the values to be displayed.</remarks>
		/// <param name="displayedValues">The displayed values.</param>
		public virtual void setDisplayedValues(string[] displayedValues)
		{
			if (mDisplayedValues == displayedValues)
			{
				return;
			}
			mDisplayedValues = displayedValues;
			if (mDisplayedValues != null)
			{
				// Allow text entry rather than strictly numeric entry.
				mInputText.setRawInputType(android.text.InputTypeClass.TYPE_CLASS_TEXT | android.text.InputTypeClass.TYPE_TEXT_FLAG_NO_SUGGESTIONS
					);
			}
			else
			{
				mInputText.setRawInputType(android.text.InputTypeClass.TYPE_CLASS_NUMBER);
			}
			updateInputTextView();
			initializeSelectorWheelIndices();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getTopFadingEdgeStrength()
		{
			return TOP_AND_BOTTOM_FADING_EDGE_STRENGTH;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override float getBottomFadingEdgeStrength()
		{
			return TOP_AND_BOTTOM_FADING_EDGE_STRENGTH;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			// make sure we show the controls only the very
			// first time the user sees this widget
			if (mFlingable && !isInEditMode())
			{
				// animate a bit slower the very first time
				showInputControls(mShowInputControlsAnimimationDuration * 2);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			removeAllCallbacks();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void dispatchDraw(android.graphics.Canvas canvas)
		{
		}

		// There is a good reason for doing this. See comments in draw().
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void draw(android.graphics.Canvas canvas)
		{
			// Dispatch draw to our children only if we are not currently running
			// the animation for simultaneously dimming the scroll wheel and
			// showing in the buttons. This class takes advantage of the View
			// implementation of fading edges effect to draw the selector wheel.
			// However, in View.draw(), the fading is applied after all the children
			// have been drawn and we do not want this fading to be applied to the
			// buttons. Therefore, we draw our children after we have completed
			// drawing ourselves.
			base.draw(canvas);
			// Draw our children if we are not showing the selector wheel of fading
			// it out
			if (mShowInputControlsAnimator.isRunning() || mSelectorWheelState != SELECTOR_WHEEL_STATE_LARGE)
			{
				long drawTime = getDrawingTime();
				{
					int i = 0;
					int count = getChildCount();
					for (; i < count; i++)
					{
						android.view.View child = getChildAt(i);
						if (!child.isShown())
						{
							continue;
						}
						drawChild(canvas, getChildAt(i), drawTime);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			if (mSelectorWheelState == SELECTOR_WHEEL_STATE_NONE)
			{
				return;
			}
			float x = (mRight - mLeft) / 2;
			float y = mCurrentScrollOffset;
			int restoreCount = canvas.save();
			if (mSelectorWheelState == SELECTOR_WHEEL_STATE_SMALL)
			{
				android.graphics.Rect clipBounds = canvas.getClipBounds();
				clipBounds.inset(0, mSelectorElementHeight);
				canvas.clipRect(clipBounds);
			}
			// draw the selector wheel
			int[] selectorIndices = mSelectorIndices;
			{
				for (int i = 0; i < selectorIndices.Length; i++)
				{
					int selectorIndex = selectorIndices[i];
					string scrollSelectorValue = mSelectorIndexToStringCache.get(selectorIndex);
					// Do not draw the middle item if input is visible since the input is shown only
					// if the wheel is static and it covers the middle item. Otherwise, if the user
					// starts editing the text via the IME he may see a dimmed version of the old
					// value intermixed with the new one.
					if (i != SELECTOR_MIDDLE_ITEM_INDEX || mInputText.getVisibility() != VISIBLE)
					{
						canvas.drawText(scrollSelectorValue, x, y, mSelectorWheelPaint);
					}
					y += mSelectorElementHeight;
				}
			}
			// draw the selection dividers (only if scrolling and drawable specified)
			if (mSelectionDivider != null)
			{
				// draw the top divider
				int topOfTopDivider = (getHeight() - mSelectorElementHeight - mSelectionDividerHeight
					) / 2;
				int bottomOfTopDivider = topOfTopDivider + mSelectionDividerHeight;
				mSelectionDivider.setBounds(0, topOfTopDivider, mRight, bottomOfTopDivider);
				mSelectionDivider.draw(canvas);
				// draw the bottom divider
				int topOfBottomDivider = topOfTopDivider + mSelectorElementHeight;
				int bottomOfBottomDivider = bottomOfTopDivider + mSelectorElementHeight;
				mSelectionDivider.setBounds(0, topOfBottomDivider, mRight, bottomOfBottomDivider);
				mSelectionDivider.draw(canvas);
			}
			canvas.restoreToCount(restoreCount);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void sendAccessibilityEvent(int eventType)
		{
		}

		// Do not send accessibility events - we want the user to
		// perceive this widget as several controls rather as a whole.
		/// <summary>
		/// Resets the selector indices and clear the cached
		/// string representation of these indices.
		/// </summary>
		/// <remarks>
		/// Resets the selector indices and clear the cached
		/// string representation of these indices.
		/// </remarks>
		private void initializeSelectorWheelIndices()
		{
			mSelectorIndexToStringCache.clear();
			int[] selectorIdices = mSelectorIndices;
			int current = getValue();
			{
				for (int i = 0; i < mSelectorIndices.Length; i++)
				{
					int selectorIndex = current + (i - SELECTOR_MIDDLE_ITEM_INDEX);
					if (mWrapSelectorWheel)
					{
						selectorIndex = getWrappedSelectorIndex(selectorIndex);
					}
					mSelectorIndices[i] = selectorIndex;
					ensureCachedScrollSelectorValue(mSelectorIndices[i]);
				}
			}
		}

		/// <summary>
		/// Sets the current value of this NumberPicker, and sets mPrevious to the
		/// previous value.
		/// </summary>
		/// <remarks>
		/// Sets the current value of this NumberPicker, and sets mPrevious to the
		/// previous value. If current is greater than mEnd less than mStart, the
		/// value of mCurrent is wrapped around. Subclasses can override this to
		/// change the wrapping behavior
		/// </remarks>
		/// <param name="current">the new value of the NumberPicker</param>
		private void changeCurrent(int current)
		{
			if (mValue == current)
			{
				return;
			}
			// Wrap around the values if we go past the start or end
			if (mWrapSelectorWheel)
			{
				current = getWrappedSelectorIndex(current);
			}
			int previous = mValue;
			setValue(current);
			notifyChange(previous, current);
		}

		/// <summary>
		/// Changes the current value by one which is increment or
		/// decrement based on the passes argument.
		/// </summary>
		/// <remarks>
		/// Changes the current value by one which is increment or
		/// decrement based on the passes argument.
		/// </remarks>
		/// <param name="increment">True to increment, false to decrement.</param>
		private void changeCurrentByOne(bool increment)
		{
			if (mFlingable)
			{
				mDimSelectorWheelAnimator.cancel();
				mInputText.setVisibility(android.view.View.INVISIBLE);
				mSelectorWheelPaint.setAlpha(SELECTOR_WHEEL_BRIGHT_ALPHA);
				mPreviousScrollerY = 0;
				forceCompleteChangeCurrentByOneViaScroll();
				if (increment)
				{
					mFlingScroller.startScroll(0, 0, 0, -mSelectorElementHeight, CHANGE_CURRENT_BY_ONE_SCROLL_DURATION
						);
				}
				else
				{
					mFlingScroller.startScroll(0, 0, 0, mSelectorElementHeight, CHANGE_CURRENT_BY_ONE_SCROLL_DURATION
						);
				}
				invalidate();
			}
			else
			{
				if (increment)
				{
					changeCurrent(mValue + 1);
				}
				else
				{
					changeCurrent(mValue - 1);
				}
			}
		}

		/// <summary>
		/// Ensures that if we are in the process of changing the current value
		/// by one via scrolling the scroller gets to its final state and the
		/// value is updated.
		/// </summary>
		/// <remarks>
		/// Ensures that if we are in the process of changing the current value
		/// by one via scrolling the scroller gets to its final state and the
		/// value is updated.
		/// </remarks>
		private void forceCompleteChangeCurrentByOneViaScroll()
		{
			android.widget.Scroller scroller = mFlingScroller;
			if (!scroller.isFinished())
			{
				int yBeforeAbort = scroller.getCurrY();
				scroller.abortAnimation();
				int yDelta = scroller.getCurrY() - yBeforeAbort;
				scrollBy(0, yDelta);
			}
		}

		/// <summary>
		/// Sets the <code>alpha</code> of the
		/// <see cref="android.graphics.Paint">android.graphics.Paint</see>
		/// for drawing the selector
		/// wheel.
		/// </summary>
		private void setSelectorPaintAlpha(int alpha)
		{
			// Called via reflection
			mSelectorWheelPaint.setAlpha(alpha);
			invalidate();
		}

		/// <returns>If the <code>event</code> is in the <code>view</code>.</returns>
		private bool isEventInViewHitRect(android.view.MotionEvent @event, android.view.View
			 view)
		{
			view.getHitRect(mTempRect);
			return mTempRect.contains((int)@event.getX(), (int)@event.getY());
		}

		/// <summary>Sets the <code>selectorWheelState</code>.</summary>
		/// <remarks>Sets the <code>selectorWheelState</code>.</remarks>
		private void setSelectorWheelState(int selectorWheelState)
		{
			mSelectorWheelState = selectorWheelState;
			if (selectorWheelState == SELECTOR_WHEEL_STATE_LARGE)
			{
				mSelectorWheelPaint.setAlpha(SELECTOR_WHEEL_BRIGHT_ALPHA);
			}
			if (mFlingable && selectorWheelState == SELECTOR_WHEEL_STATE_LARGE && android.view.accessibility.AccessibilityManager
				.getInstance(mContext).isEnabled())
			{
				android.view.accessibility.AccessibilityManager.getInstance(mContext).interrupt();
				string text = mContext.getString(android.@internal.R.@string.number_picker_increment_scroll_action
					);
				mInputText.setContentDescription(java.lang.CharSequenceProxy.Wrap(text));
				mInputText.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent.TYPE_VIEW_SELECTED
					);
				mInputText.setContentDescription(null);
			}
		}

		private void initializeSelectorWheel()
		{
			initializeSelectorWheelIndices();
			int[] selectorIndices = mSelectorIndices;
			int totalTextHeight = selectorIndices.Length * mTextSize;
			float totalTextGapHeight = (mBottom - mTop) - totalTextHeight;
			float textGapCount = selectorIndices.Length - 1;
			mSelectorTextGapHeight = (int)(totalTextGapHeight / textGapCount + 0.5f);
			mSelectorElementHeight = mTextSize + mSelectorTextGapHeight;
			// Ensure that the middle item is positioned the same as the text in mInputText
			int editTextTextPosition = mInputText.getBaseline() + mInputText.getTop();
			mInitialScrollOffset = editTextTextPosition - (mSelectorElementHeight * SELECTOR_MIDDLE_ITEM_INDEX
				);
			mCurrentScrollOffset = mInitialScrollOffset;
			updateInputTextView();
		}

		private void initializeFadingEdges()
		{
			setVerticalFadingEdgeEnabled(true);
			setFadingEdgeLength((mBottom - mTop - mTextSize) / 2);
		}

		/// <summary>Callback invoked upon completion of a given <code>scroller</code>.</summary>
		/// <remarks>Callback invoked upon completion of a given <code>scroller</code>.</remarks>
		private void onScrollerFinished(android.widget.Scroller scroller)
		{
			if (scroller == mFlingScroller)
			{
				if (mSelectorWheelState == SELECTOR_WHEEL_STATE_LARGE)
				{
					postAdjustScrollerCommand(0);
					onScrollStateChange(android.widget.NumberPicker.OnScrollListenerClass.SCROLL_STATE_IDLE
						);
				}
				else
				{
					updateInputTextView();
					fadeSelectorWheel(mShowInputControlsAnimimationDuration);
				}
			}
			else
			{
				updateInputTextView();
				showInputControls(mShowInputControlsAnimimationDuration);
			}
		}

		/// <summary>Handles transition to a given <code>scrollState</code></summary>
		private void onScrollStateChange(int scrollState)
		{
			if (mScrollState == scrollState)
			{
				return;
			}
			mScrollState = scrollState;
			if (mOnScrollListener != null)
			{
				mOnScrollListener.onScrollStateChange(this, scrollState);
			}
		}

		/// <summary>Flings the selector with the given <code>velocityY</code>.</summary>
		/// <remarks>Flings the selector with the given <code>velocityY</code>.</remarks>
		private void fling(int velocityY)
		{
			mPreviousScrollerY = 0;
			android.widget.Scroller flingScroller = mFlingScroller;
			if (mWrapSelectorWheel)
			{
				if (velocityY > 0)
				{
					flingScroller.fling(0, 0, 0, velocityY, 0, 0, 0, int.MaxValue);
				}
				else
				{
					flingScroller.fling(0, int.MaxValue, 0, velocityY, 0, 0, 0, int.MaxValue);
				}
			}
			else
			{
				if (velocityY > 0)
				{
					int maxY = mTextSize * (mValue - mMinValue);
					flingScroller.fling(0, 0, 0, velocityY, 0, 0, 0, maxY);
				}
				else
				{
					int startY = mTextSize * (mMaxValue - mValue);
					int maxY = startY;
					flingScroller.fling(0, startY, 0, velocityY, 0, 0, 0, maxY);
				}
			}
			invalidate();
		}

		/// <summary>Hides the input controls which is the up/down arrows and the text field.
		/// 	</summary>
		/// <remarks>Hides the input controls which is the up/down arrows and the text field.
		/// 	</remarks>
		private void hideInputControls()
		{
			mShowInputControlsAnimator.cancel();
			mIncrementButton.setVisibility(INVISIBLE);
			mDecrementButton.setVisibility(INVISIBLE);
			mInputText.setVisibility(INVISIBLE);
		}

		/// <summary>
		/// Show the input controls by making them visible and animating the alpha
		/// property up/down arrows.
		/// </summary>
		/// <remarks>
		/// Show the input controls by making them visible and animating the alpha
		/// property up/down arrows.
		/// </remarks>
		/// <param name="animationDuration">The duration of the animation.</param>
		private void showInputControls(long animationDuration)
		{
			updateIncrementAndDecrementButtonsVisibilityState();
			mInputText.setVisibility(VISIBLE);
			mShowInputControlsAnimator.setDuration(animationDuration);
			mShowInputControlsAnimator.start();
		}

		/// <summary>Fade the selector wheel via an animation.</summary>
		/// <remarks>Fade the selector wheel via an animation.</remarks>
		/// <param name="animationDuration">The duration of the animation.</param>
		private void fadeSelectorWheel(long animationDuration)
		{
			mInputText.setVisibility(VISIBLE);
			mDimSelectorWheelAnimator.setDuration(animationDuration);
			mDimSelectorWheelAnimator.start();
		}

		/// <summary>Updates the visibility state of the increment and decrement buttons.</summary>
		/// <remarks>Updates the visibility state of the increment and decrement buttons.</remarks>
		private void updateIncrementAndDecrementButtonsVisibilityState()
		{
			if (mWrapSelectorWheel || mValue < mMaxValue)
			{
				mIncrementButton.setVisibility(VISIBLE);
			}
			else
			{
				mIncrementButton.setVisibility(INVISIBLE);
			}
			if (mWrapSelectorWheel || mValue > mMinValue)
			{
				mDecrementButton.setVisibility(VISIBLE);
			}
			else
			{
				mDecrementButton.setVisibility(INVISIBLE);
			}
		}

		/// <returns>The wrapped index <code>selectorIndex</code> value.</returns>
		private int getWrappedSelectorIndex(int selectorIndex)
		{
			if (selectorIndex > mMaxValue)
			{
				return mMinValue + (selectorIndex - mMaxValue) % (mMaxValue - mMinValue) - 1;
			}
			else
			{
				if (selectorIndex < mMinValue)
				{
					return mMaxValue - (mMinValue - selectorIndex) % (mMaxValue - mMinValue) + 1;
				}
			}
			return selectorIndex;
		}

		/// <summary>
		/// Increments the <code>selectorIndices</code> whose string representations
		/// will be displayed in the selector.
		/// </summary>
		/// <remarks>
		/// Increments the <code>selectorIndices</code> whose string representations
		/// will be displayed in the selector.
		/// </remarks>
		private void incrementSelectorIndices(int[] selectorIndices)
		{
			{
				for (int i = 0; i < selectorIndices.Length - 1; i++)
				{
					selectorIndices[i] = selectorIndices[i + 1];
				}
			}
			int nextScrollSelectorIndex = selectorIndices[selectorIndices.Length - 2] + 1;
			if (mWrapSelectorWheel && nextScrollSelectorIndex > mMaxValue)
			{
				nextScrollSelectorIndex = mMinValue;
			}
			selectorIndices[selectorIndices.Length - 1] = nextScrollSelectorIndex;
			ensureCachedScrollSelectorValue(nextScrollSelectorIndex);
		}

		/// <summary>
		/// Decrements the <code>selectorIndices</code> whose string representations
		/// will be displayed in the selector.
		/// </summary>
		/// <remarks>
		/// Decrements the <code>selectorIndices</code> whose string representations
		/// will be displayed in the selector.
		/// </remarks>
		private void decrementSelectorIndices(int[] selectorIndices)
		{
			{
				for (int i = selectorIndices.Length - 1; i > 0; i--)
				{
					selectorIndices[i] = selectorIndices[i - 1];
				}
			}
			int nextScrollSelectorIndex = selectorIndices[1] - 1;
			if (mWrapSelectorWheel && nextScrollSelectorIndex < mMinValue)
			{
				nextScrollSelectorIndex = mMaxValue;
			}
			selectorIndices[0] = nextScrollSelectorIndex;
			ensureCachedScrollSelectorValue(nextScrollSelectorIndex);
		}

		/// <summary>
		/// Ensures we have a cached string representation of the given <code>
		/// selectorIndex</code>
		/// to avoid multiple instantiations of the same string.
		/// </summary>
		/// <remarks>
		/// Ensures we have a cached string representation of the given <code>
		/// selectorIndex</code>
		/// to avoid multiple instantiations of the same string.
		/// </remarks>
		private void ensureCachedScrollSelectorValue(int selectorIndex)
		{
			android.util.SparseArray<string> cache = mSelectorIndexToStringCache;
			string scrollSelectorValue = cache.get(selectorIndex);
			if (scrollSelectorValue != null)
			{
				return;
			}
			if (selectorIndex < mMinValue || selectorIndex > mMaxValue)
			{
				scrollSelectorValue = string.Empty;
			}
			else
			{
				if (mDisplayedValues != null)
				{
					int displayedValueIndex = selectorIndex - mMinValue;
					scrollSelectorValue = mDisplayedValues[displayedValueIndex];
				}
				else
				{
					scrollSelectorValue = formatNumber(selectorIndex);
				}
			}
			cache.put(selectorIndex, scrollSelectorValue);
		}

		private string formatNumber(int value)
		{
			return (mFormatter != null) ? mFormatter.format(value) : value.ToString();
		}

		private void validateInputTextView(android.view.View v)
		{
			string str = Sharpen.StringHelper.GetValueOf(((android.widget.TextView)v).getText
				());
			if (android.text.TextUtils.isEmpty(java.lang.CharSequenceProxy.Wrap(str)))
			{
				// Restore to the old value as we don't allow empty values
				updateInputTextView();
			}
			else
			{
				// Check the new value and ensure it's in range
				int current = getSelectedPos(str.ToString());
				changeCurrent(current);
			}
		}

		/// <summary>Updates the view of this NumberPicker.</summary>
		/// <remarks>
		/// Updates the view of this NumberPicker. If displayValues were specified in
		/// the string corresponding to the index specified by the current value will
		/// be returned. Otherwise, the formatter specified in
		/// <see cref="setFormatter(Formatter)">setFormatter(Formatter)</see>
		/// will be used to format the number.
		/// </remarks>
		private void updateInputTextView()
		{
			if (mDisplayedValues == null)
			{
				mInputText.setText(java.lang.CharSequenceProxy.Wrap(formatNumber(mValue)));
			}
			else
			{
				mInputText.setText(java.lang.CharSequenceProxy.Wrap(mDisplayedValues[mValue - mMinValue
					]));
			}
			mInputText.setSelection(((android.text.Editable)mInputText.getText()).Length);
			if (mFlingable && android.view.accessibility.AccessibilityManager.getInstance(mContext
				).isEnabled())
			{
				string text = mContext.getString(android.@internal.R.@string.number_picker_increment_scroll_mode
					, ((android.text.Editable)mInputText.getText()));
				mInputText.setContentDescription(java.lang.CharSequenceProxy.Wrap(text));
			}
		}

		/// <summary>
		/// Notifies the listener, if registered, of a change of the value of this
		/// NumberPicker.
		/// </summary>
		/// <remarks>
		/// Notifies the listener, if registered, of a change of the value of this
		/// NumberPicker.
		/// </remarks>
		private void notifyChange(int previous, int current)
		{
			if (mOnValueChangeListener != null)
			{
				mOnValueChangeListener.onValueChange(this, previous, mValue);
			}
		}

		/// <summary>Posts a command for changing the current value by one.</summary>
		/// <remarks>Posts a command for changing the current value by one.</remarks>
		/// <param name="increment">Whether to increment or decrement the value.</param>
		private void postChangeCurrentByOneFromLongPress(bool increment)
		{
			mInputText.clearFocus();
			removeAllCallbacks();
			if (mChangeCurrentByOneFromLongPressCommand == null)
			{
				mChangeCurrentByOneFromLongPressCommand = new android.widget.NumberPicker.ChangeCurrentByOneFromLongPressCommand
					(this);
			}
			mChangeCurrentByOneFromLongPressCommand.setIncrement(increment);
			post(mChangeCurrentByOneFromLongPressCommand);
		}

		/// <summary>Removes all pending callback from the message queue.</summary>
		/// <remarks>Removes all pending callback from the message queue.</remarks>
		private void removeAllCallbacks()
		{
			if (mChangeCurrentByOneFromLongPressCommand != null)
			{
				removeCallbacks(mChangeCurrentByOneFromLongPressCommand);
			}
			if (mAdjustScrollerCommand != null)
			{
				removeCallbacks(mAdjustScrollerCommand);
			}
			if (mSetSelectionCommand != null)
			{
				removeCallbacks(mSetSelectionCommand);
			}
		}

		/// <returns>The selected index given its displayed <code>value</code>.</returns>
		private int getSelectedPos(string value)
		{
			if (mDisplayedValues == null)
			{
				try
				{
					return System.Convert.ToInt32(value);
				}
				catch (System.ArgumentException)
				{
				}
			}
			else
			{
				{
					// Ignore as if it's not a number we don't care
					for (int i = 0; i < mDisplayedValues.Length; i++)
					{
						// Don't force the user to type in jan when ja will do
						value = value.ToLower();
						if (mDisplayedValues[i].ToLower().StartsWith(value))
						{
							return mMinValue + i;
						}
					}
				}
				try
				{
					return System.Convert.ToInt32(value);
				}
				catch (System.ArgumentException)
				{
				}
			}
			// Ignore as if it's not a number we don't care
			return mMinValue;
		}

		/// <summary>
		/// Posts an
		/// <see cref="SetSelectionCommand">SetSelectionCommand</see>
		/// from the given <code>selectionStart
		/// </code> to
		/// <code>selectionEnd</code>.
		/// </summary>
		private void postSetSelectionCommand(int selectionStart, int selectionEnd)
		{
			if (mSetSelectionCommand == null)
			{
				mSetSelectionCommand = new android.widget.NumberPicker.SetSelectionCommand(this);
			}
			else
			{
				removeCallbacks(mSetSelectionCommand);
			}
			mSetSelectionCommand.mSelectionStart = selectionStart;
			mSetSelectionCommand.mSelectionEnd = selectionEnd;
			post(mSetSelectionCommand);
		}

		/// <summary>
		/// Posts an
		/// <see cref="AdjustScrollerCommand">AdjustScrollerCommand</see>
		/// within the given <code>
		/// delayMillis</code>
		/// .
		/// </summary>
		private void postAdjustScrollerCommand(int delayMillis)
		{
			if (mAdjustScrollerCommand == null)
			{
				mAdjustScrollerCommand = new android.widget.NumberPicker.AdjustScrollerCommand(this
					);
			}
			else
			{
				removeCallbacks(mAdjustScrollerCommand);
			}
			postDelayed(mAdjustScrollerCommand, delayMillis);
		}

		/// <summary>
		/// Filter for accepting only valid indices or prefixes of the string
		/// representation of valid indices.
		/// </summary>
		/// <remarks>
		/// Filter for accepting only valid indices or prefixes of the string
		/// representation of valid indices.
		/// </remarks>
		internal class InputTextFilter : android.text.method.NumberKeyListener
		{
			// XXX This doesn't allow for range limits when controlled by a
			// soft input method!
			[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
			public override int getInputType()
			{
				return android.text.InputTypeClass.TYPE_CLASS_TEXT;
			}

			[Sharpen.OverridesMethod(@"android.text.method.NumberKeyListener")]
			protected internal override char[] getAcceptedChars()
			{
				return android.widget.NumberPicker.DIGIT_CHARACTERS;
			}

			[Sharpen.OverridesMethod(@"android.text.method.NumberKeyListener")]
			public override java.lang.CharSequence filter(java.lang.CharSequence source, int 
				start, int end, android.text.Spanned dest, int dstart, int dend)
			{
				if (this._enclosing.mDisplayedValues == null)
				{
					java.lang.CharSequence filtered = base.filter(source, start, end, dest, dstart, dend
						);
					if (filtered == null)
					{
						filtered = source.SubSequence(start, end);
					}
					string result = Sharpen.StringHelper.GetValueOf(dest.SubSequence(0, dstart)) + filtered
						 + dest.SubSequence(dend, dest.Length);
					if (string.Empty.Equals(result))
					{
						return java.lang.CharSequenceProxy.Wrap(result);
					}
					int val = this._enclosing.getSelectedPos(result);
					if (val > this._enclosing.mMaxValue)
					{
						return java.lang.CharSequenceProxy.Wrap(string.Empty);
					}
					else
					{
						return filtered;
					}
				}
				else
				{
					java.lang.CharSequence filtered = java.lang.CharSequenceProxy.Wrap(Sharpen.StringHelper.GetValueOf
						(source.SubSequence(start, end)));
					if (android.text.TextUtils.isEmpty(filtered))
					{
						return java.lang.CharSequenceProxy.Wrap(string.Empty);
					}
					string result = Sharpen.StringHelper.GetValueOf(dest.SubSequence(0, dstart)) + filtered
						 + dest.SubSequence(dend, dest.Length);
					string str = Sharpen.StringHelper.GetValueOf(result).ToLower();
					foreach (string val in this._enclosing.mDisplayedValues)
					{
						string valLowerCase = val.ToLower();
						if (valLowerCase.StartsWith(str))
						{
							this._enclosing.postSetSelectionCommand(result.Length, val.Length);
							return val.SubSequence(dstart, val.Length);
						}
					}
					return java.lang.CharSequenceProxy.Wrap(string.Empty);
				}
			}

			internal InputTextFilter(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly NumberPicker _enclosing;
		}

		/// <summary>Command for setting the input text selection.</summary>
		/// <remarks>Command for setting the input text selection.</remarks>
		internal class SetSelectionCommand : java.lang.Runnable
		{
			internal int mSelectionStart;

			internal int mSelectionEnd;

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.mInputText.setSelection(this.mSelectionStart, this.mSelectionEnd);
			}

			internal SetSelectionCommand(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly NumberPicker _enclosing;
		}

		/// <summary>
		/// Command for adjusting the scroller to show in its center the closest of
		/// the displayed items.
		/// </summary>
		/// <remarks>
		/// Command for adjusting the scroller to show in its center the closest of
		/// the displayed items.
		/// </remarks>
		internal class AdjustScrollerCommand : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.mPreviousScrollerY = 0;
				if (this._enclosing.mInitialScrollOffset == this._enclosing.mCurrentScrollOffset)
				{
					this._enclosing.updateInputTextView();
					this._enclosing.showInputControls(this._enclosing.mShowInputControlsAnimimationDuration
						);
					return;
				}
				// adjust to the closest value
				int deltaY = this._enclosing.mInitialScrollOffset - this._enclosing.mCurrentScrollOffset;
				if (System.Math.Abs(deltaY) > this._enclosing.mSelectorElementHeight / 2)
				{
					deltaY += (deltaY > 0) ? -this._enclosing.mSelectorElementHeight : this._enclosing
						.mSelectorElementHeight;
				}
				this._enclosing.mAdjustScroller.startScroll(0, 0, 0, deltaY, android.widget.NumberPicker
					.SELECTOR_ADJUSTMENT_DURATION_MILLIS);
				this._enclosing.invalidate();
			}

			internal AdjustScrollerCommand(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly NumberPicker _enclosing;
		}

		/// <summary>Command for changing the current value from a long press by one.</summary>
		/// <remarks>Command for changing the current value from a long press by one.</remarks>
		internal class ChangeCurrentByOneFromLongPressCommand : java.lang.Runnable
		{
			private bool mIncrement;

			internal void setIncrement(bool increment)
			{
				this.mIncrement = increment;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.changeCurrentByOne(this.mIncrement);
				this._enclosing.postDelayed(this, this._enclosing.mLongPressUpdateInterval);
			}

			internal ChangeCurrentByOneFromLongPressCommand(NumberPicker _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly NumberPicker _enclosing;
		}
	}
}
