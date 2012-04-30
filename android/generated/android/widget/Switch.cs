using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A Switch is a two-state toggle switch widget that can select between two
	/// options.
	/// </summary>
	/// <remarks>
	/// A Switch is a two-state toggle switch widget that can select between two
	/// options. The user may drag the "thumb" back and forth to choose the selected option,
	/// or simply tap to toggle as if it were a checkbox. The
	/// <see cref="TextView.setText(java.lang.CharSequence)">text</see>
	/// property controls the text displayed in the label for the switch, whereas the
	/// <see cref="setTextOff(java.lang.CharSequence)">off</see>
	/// and
	/// <see cref="setTextOn(java.lang.CharSequence)">on</see>
	/// text
	/// controls the text on the thumb. Similarly, the
	/// <see cref="TextView.setTextAppearance(android.content.Context, int)">textAppearance
	/// 	</see>
	/// and the related
	/// setTypeface() methods control the typeface and style of label text, whereas the
	/// <see cref="setSwitchTextAppearance(android.content.Context, int)">switchTextAppearance
	/// 	</see>
	/// and
	/// the related seSwitchTypeface() methods control that of the thumb.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Switch : android.widget.CompoundButton
	{
		internal const int TOUCH_MODE_IDLE = 0;

		internal const int TOUCH_MODE_DOWN = 1;

		internal const int TOUCH_MODE_DRAGGING = 2;

		internal const int SANS = 1;

		internal const int SERIF = 2;

		internal const int MONOSPACE = 3;

		private android.graphics.drawable.Drawable mThumbDrawable;

		private android.graphics.drawable.Drawable mTrackDrawable;

		private int mThumbTextPadding;

		private int mSwitchMinWidth;

		private int mSwitchPadding;

		private java.lang.CharSequence mTextOn;

		private java.lang.CharSequence mTextOff;

		private int mTouchMode;

		private int mTouchSlop;

		private float mTouchX;

		private float mTouchY;

		private android.view.VelocityTracker mVelocityTracker = android.view.VelocityTracker
			.obtain();

		private int mMinFlingVelocity;

		private float mThumbPosition;

		private int mSwitchWidth;

		private int mSwitchHeight;

		private int mThumbWidth;

		private int mSwitchLeft;

		private int mSwitchTop;

		private int mSwitchRight;

		private int mSwitchBottom;

		private android.text.TextPaint mTextPaint;

		private android.content.res.ColorStateList mTextColors;

		private android.text.Layout mOnLayout;

		private android.text.Layout mOffLayout;

		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private static readonly int[] CHECKED_STATE_SET = new int[] { android.@internal.R
			.attr.state_checked };

		/// <summary>Construct a new Switch with default styling.</summary>
		/// <remarks>Construct a new Switch with default styling.</remarks>
		/// <param name="context">The Context that will determine this widget's theming.</param>
		public Switch(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>
		/// Construct a new Switch with default styling, overriding specific style
		/// attributes as requested.
		/// </summary>
		/// <remarks>
		/// Construct a new Switch with default styling, overriding specific style
		/// attributes as requested.
		/// </remarks>
		/// <param name="context">The Context that will determine this widget's theming.</param>
		/// <param name="attrs">Specification of attributes that should deviate from default styling.
		/// 	</param>
		public Switch(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, android.@internal.R.attr.switchStyle)
		{
		}

		/// <summary>
		/// Construct a new Switch with a default style determined by the given theme attribute,
		/// overriding specific style attributes as requested.
		/// </summary>
		/// <remarks>
		/// Construct a new Switch with a default style determined by the given theme attribute,
		/// overriding specific style attributes as requested.
		/// </remarks>
		/// <param name="context">The Context that will determine this widget's theming.</param>
		/// <param name="attrs">Specification of attributes that should deviate from the default styling.
		/// 	</param>
		/// <param name="defStyle">
		/// An attribute ID within the active theme containing a reference to the
		/// default style for this widget. e.g. android.R.attr.switchStyle.
		/// </param>
		public Switch(android.content.Context context, android.util.AttributeSet attrs, int
			 defStyle) : base(context, attrs, defStyle)
		{
			// Enum for the "typeface" XML parameter.
			// Does not include padding
			mTextPaint = new android.text.TextPaint(android.graphics.Paint.ANTI_ALIAS_FLAG);
			android.content.res.Resources res = getResources();
			mTextPaint.density = res.getDisplayMetrics().density;
			mTextPaint.setCompatibilityScaling(res.getCompatibilityInfo().applicationScale);
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Switch, defStyle, 0);
			mThumbDrawable = a.getDrawable(android.@internal.R.styleable.Switch_thumb);
			mTrackDrawable = a.getDrawable(android.@internal.R.styleable.Switch_track);
			mTextOn = a.getText(android.@internal.R.styleable.Switch_textOn);
			mTextOff = a.getText(android.@internal.R.styleable.Switch_textOff);
			mThumbTextPadding = a.getDimensionPixelSize(android.@internal.R.styleable.Switch_thumbTextPadding
				, 0);
			mSwitchMinWidth = a.getDimensionPixelSize(android.@internal.R.styleable.Switch_switchMinWidth
				, 0);
			mSwitchPadding = a.getDimensionPixelSize(android.@internal.R.styleable.Switch_switchPadding
				, 0);
			int appearance = a.getResourceId(android.@internal.R.styleable.Switch_switchTextAppearance
				, 0);
			if (appearance != 0)
			{
				setSwitchTextAppearance(context, appearance);
			}
			a.recycle();
			android.view.ViewConfiguration config = android.view.ViewConfiguration.get(context
				);
			mTouchSlop = config.getScaledTouchSlop();
			mMinFlingVelocity = config.getScaledMinimumFlingVelocity();
			// Refresh display with current params
			refreshDrawableState();
			setChecked(isChecked());
		}

		/// <summary>
		/// Sets the switch text color, size, style, hint color, and highlight color
		/// from the specified TextAppearance resource.
		/// </summary>
		/// <remarks>
		/// Sets the switch text color, size, style, hint color, and highlight color
		/// from the specified TextAppearance resource.
		/// </remarks>
		public virtual void setSwitchTextAppearance(android.content.Context context, int 
			resid)
		{
			android.content.res.TypedArray appearance = context.obtainStyledAttributes(resid, 
				android.@internal.R.styleable.TextAppearance);
			android.content.res.ColorStateList colors;
			int ts;
			colors = appearance.getColorStateList(android.@internal.R.styleable.TextAppearance_textColor
				);
			if (colors != null)
			{
				mTextColors = colors;
			}
			else
			{
				// If no color set in TextAppearance, default to the view's textColor
				mTextColors = getTextColors();
			}
			ts = appearance.getDimensionPixelSize(android.@internal.R.styleable.TextAppearance_textSize
				, 0);
			if (ts != 0)
			{
				if (ts != mTextPaint.getTextSize())
				{
					mTextPaint.setTextSize(ts);
					requestLayout();
				}
			}
			int typefaceIndex;
			int styleIndex;
			typefaceIndex = appearance.getInt(android.@internal.R.styleable.TextAppearance_typeface
				, -1);
			styleIndex = appearance.getInt(android.@internal.R.styleable.TextAppearance_textStyle
				, -1);
			setSwitchTypefaceByIndex(typefaceIndex, styleIndex);
			appearance.recycle();
		}

		private void setSwitchTypefaceByIndex(int typefaceIndex, int styleIndex)
		{
			android.graphics.Typeface tf = null;
			switch (typefaceIndex)
			{
				case SANS:
				{
					tf = android.graphics.Typeface.SANS_SERIF;
					break;
				}

				case SERIF:
				{
					tf = android.graphics.Typeface.SERIF;
					break;
				}

				case MONOSPACE:
				{
					tf = android.graphics.Typeface.MONOSPACE;
					break;
				}
			}
			setSwitchTypeface(tf, styleIndex);
		}

		/// <summary>
		/// Sets the typeface and style in which the text should be displayed on the
		/// switch, and turns on the fake bold and italic bits in the Paint if the
		/// Typeface that you provided does not have all the bits in the
		/// style that you specified.
		/// </summary>
		/// <remarks>
		/// Sets the typeface and style in which the text should be displayed on the
		/// switch, and turns on the fake bold and italic bits in the Paint if the
		/// Typeface that you provided does not have all the bits in the
		/// style that you specified.
		/// </remarks>
		public virtual void setSwitchTypeface(android.graphics.Typeface tf, int style)
		{
			if (style > 0)
			{
				if (tf == null)
				{
					tf = android.graphics.Typeface.defaultFromStyle(style);
				}
				else
				{
					tf = android.graphics.Typeface.create(tf, style);
				}
				setSwitchTypeface(tf);
				// now compute what (if any) algorithmic styling is needed
				int typefaceStyle = tf != null ? tf.getStyle() : 0;
				int need = style & ~typefaceStyle;
				mTextPaint.setFakeBoldText((need & android.graphics.Typeface.BOLD) != 0);
				mTextPaint.setTextSkewX((need & android.graphics.Typeface.ITALIC) != 0 ? -0.25f : 
					0);
			}
			else
			{
				mTextPaint.setFakeBoldText(false);
				mTextPaint.setTextSkewX(0);
				setSwitchTypeface(tf);
			}
		}

		/// <summary>Sets the typeface in which the text should be displayed on the switch.</summary>
		/// <remarks>
		/// Sets the typeface in which the text should be displayed on the switch.
		/// Note that not all Typeface families actually have bold and italic
		/// variants, so you may need to use
		/// <see cref="setSwitchTypeface(android.graphics.Typeface, int)">setSwitchTypeface(android.graphics.Typeface, int)
		/// 	</see>
		/// to get the appearance
		/// that you actually want.
		/// </remarks>
		/// <attr>ref android.R.styleable#TextView_typeface</attr>
		/// <attr>ref android.R.styleable#TextView_textStyle</attr>
		public virtual void setSwitchTypeface(android.graphics.Typeface tf)
		{
			if (mTextPaint.getTypeface() != tf)
			{
				mTextPaint.setTypeface(tf);
				requestLayout();
				invalidate();
			}
		}

		/// <summary>Returns the text displayed when the button is in the checked state.</summary>
		/// <remarks>Returns the text displayed when the button is in the checked state.</remarks>
		public virtual java.lang.CharSequence getTextOn()
		{
			return mTextOn;
		}

		/// <summary>Sets the text displayed when the button is in the checked state.</summary>
		/// <remarks>Sets the text displayed when the button is in the checked state.</remarks>
		public virtual void setTextOn(java.lang.CharSequence textOn)
		{
			mTextOn = textOn;
			requestLayout();
		}

		/// <summary>Returns the text displayed when the button is not in the checked state.</summary>
		/// <remarks>Returns the text displayed when the button is not in the checked state.</remarks>
		public virtual java.lang.CharSequence getTextOff()
		{
			return mTextOff;
		}

		/// <summary>Sets the text displayed when the button is not in the checked state.</summary>
		/// <remarks>Sets the text displayed when the button is not in the checked state.</remarks>
		public virtual void setTextOff(java.lang.CharSequence textOff)
		{
			mTextOff = textOff;
			requestLayout();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int heightMode = android.view.View.MeasureSpec.getMode(heightMeasureSpec);
			int widthSize = android.view.View.MeasureSpec.getSize(widthMeasureSpec);
			int heightSize = android.view.View.MeasureSpec.getSize(heightMeasureSpec);
			if (mOnLayout == null)
			{
				mOnLayout = makeLayout(mTextOn);
			}
			if (mOffLayout == null)
			{
				mOffLayout = makeLayout(mTextOff);
			}
			mTrackDrawable.getPadding(mTempRect);
			int maxTextWidth = System.Math.Max(mOnLayout.getWidth(), mOffLayout.getWidth());
			int switchWidth = System.Math.Max(mSwitchMinWidth, maxTextWidth * 2 + mThumbTextPadding
				 * 4 + mTempRect.left + mTempRect.right);
			int switchHeight = mTrackDrawable.getIntrinsicHeight();
			mThumbWidth = maxTextWidth + mThumbTextPadding * 2;
			switch (widthMode)
			{
				case android.view.View.MeasureSpec.AT_MOST:
				{
					widthSize = System.Math.Min(widthSize, switchWidth);
					break;
				}

				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					widthSize = switchWidth;
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					// Just use what we were given
					break;
				}
			}
			switch (heightMode)
			{
				case android.view.View.MeasureSpec.AT_MOST:
				{
					heightSize = System.Math.Min(heightSize, switchHeight);
					break;
				}

				case android.view.View.MeasureSpec.UNSPECIFIED:
				{
					heightSize = switchHeight;
					break;
				}

				case android.view.View.MeasureSpec.EXACTLY:
				{
					// Just use what we were given
					break;
				}
			}
			mSwitchWidth = switchWidth;
			mSwitchHeight = switchHeight;
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			int measuredHeight = getMeasuredHeight();
			if (measuredHeight < switchHeight)
			{
				setMeasuredDimension(getMeasuredWidthAndState(), switchHeight);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			if (isChecked())
			{
				java.lang.CharSequence text = mOnLayout.getText();
				if (android.text.TextUtils.isEmpty(text))
				{
					text = java.lang.CharSequenceProxy.Wrap(mContext.getString(android.@internal.R.@string
						.switch_on));
				}
				@event.getText().add(text);
			}
			else
			{
				java.lang.CharSequence text = mOffLayout.getText();
				if (android.text.TextUtils.isEmpty(text))
				{
					text = java.lang.CharSequenceProxy.Wrap(mContext.getString(android.@internal.R.@string
						.switch_off));
				}
				@event.getText().add(text);
			}
		}

		private android.text.Layout makeLayout(java.lang.CharSequence text)
		{
			return new android.text.StaticLayout(text, mTextPaint, (int)System.Math.Ceiling(android.text.Layout
				.getDesiredWidth(text, mTextPaint)), android.text.Layout.Alignment.ALIGN_NORMAL, 
				1.0f, 0, true);
		}

		/// <returns>true if (x, y) is within the target area of the switch thumb</returns>
		private bool hitThumb(float x, float y)
		{
			mThumbDrawable.getPadding(mTempRect);
			int thumbTop = mSwitchTop - mTouchSlop;
			int thumbLeft = mSwitchLeft + (int)(mThumbPosition + 0.5f) - mTouchSlop;
			int thumbRight = thumbLeft + mThumbWidth + mTempRect.left + mTempRect.right + mTouchSlop;
			int thumbBottom = mSwitchBottom + mTouchSlop;
			return x > thumbLeft && x < thumbRight && y > thumbTop && y < thumbBottom;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent ev)
		{
			mVelocityTracker.addMovement(ev);
			int action = ev.getActionMasked();
			switch (action)
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					float x = ev.getX();
					float y = ev.getY();
					if (isEnabled() && hitThumb(x, y))
					{
						mTouchMode = TOUCH_MODE_DOWN;
						mTouchX = x;
						mTouchY = y;
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					switch (mTouchMode)
					{
						case TOUCH_MODE_IDLE:
						{
							// Didn't target the thumb, treat normally.
							break;
						}

						case TOUCH_MODE_DOWN:
						{
							float x = ev.getX();
							float y = ev.getY();
							if (System.Math.Abs(x - mTouchX) > mTouchSlop || System.Math.Abs(y - mTouchY) > mTouchSlop)
							{
								mTouchMode = TOUCH_MODE_DRAGGING;
								getParent().requestDisallowInterceptTouchEvent(true);
								mTouchX = x;
								mTouchY = y;
								return true;
							}
							break;
						}

						case TOUCH_MODE_DRAGGING:
						{
							float x = ev.getX();
							float dx = x - mTouchX;
							float newPos = System.Math.Max(0, System.Math.Min(mThumbPosition + dx, getThumbScrollRange
								()));
							if (newPos != mThumbPosition)
							{
								mThumbPosition = newPos;
								mTouchX = x;
								invalidate();
							}
							return true;
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				case android.view.MotionEvent.ACTION_CANCEL:
				{
					if (mTouchMode == TOUCH_MODE_DRAGGING)
					{
						stopDrag(ev);
						return true;
					}
					mTouchMode = TOUCH_MODE_IDLE;
					mVelocityTracker.clear();
					break;
				}
			}
			return base.onTouchEvent(ev);
		}

		private void cancelSuperTouch(android.view.MotionEvent ev)
		{
			android.view.MotionEvent cancel = android.view.MotionEvent.obtain(ev);
			cancel.setAction(android.view.MotionEvent.ACTION_CANCEL);
			base.onTouchEvent(cancel);
			cancel.recycle();
		}

		/// <summary>Called from onTouchEvent to end a drag operation.</summary>
		/// <remarks>Called from onTouchEvent to end a drag operation.</remarks>
		/// <param name="ev">Event that triggered the end of drag mode - ACTION_UP or ACTION_CANCEL
		/// 	</param>
		private void stopDrag(android.view.MotionEvent ev)
		{
			mTouchMode = TOUCH_MODE_IDLE;
			// Up and not canceled, also checks the switch has not been disabled during the drag
			bool commitChange = ev.getAction() == android.view.MotionEvent.ACTION_UP && isEnabled
				();
			cancelSuperTouch(ev);
			if (commitChange)
			{
				bool newState;
				mVelocityTracker.computeCurrentVelocity(1000);
				float xvel = mVelocityTracker.getXVelocity();
				if (System.Math.Abs(xvel) > mMinFlingVelocity)
				{
					newState = xvel > 0;
				}
				else
				{
					newState = getTargetCheckedState();
				}
				animateThumbToCheckedState(newState);
			}
			else
			{
				animateThumbToCheckedState(isChecked());
			}
		}

		private void animateThumbToCheckedState(bool newCheckedState)
		{
			// TODO animate!
			//float targetPos = newCheckedState ? 0 : getThumbScrollRange();
			//mThumbPosition = targetPos;
			setChecked(newCheckedState);
		}

		private bool getTargetCheckedState()
		{
			return mThumbPosition >= getThumbScrollRange() / 2;
		}

		[Sharpen.OverridesMethod(@"android.widget.CompoundButton")]
		public override void setChecked(bool @checked)
		{
			base.setChecked(@checked);
			mThumbPosition = @checked ? getThumbScrollRange() : 0;
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			base.onLayout(changed, left, top, right, bottom);
			mThumbPosition = isChecked() ? getThumbScrollRange() : 0;
			int switchRight = getWidth() - getPaddingRight();
			int switchLeft = switchRight - mSwitchWidth;
			int switchTop = 0;
			int switchBottom = 0;
			switch (getGravity() & android.view.Gravity.VERTICAL_GRAVITY_MASK)
			{
				case android.view.Gravity.TOP:
				default:
				{
					switchTop = getPaddingTop();
					switchBottom = switchTop + mSwitchHeight;
					break;
				}

				case android.view.Gravity.CENTER_VERTICAL:
				{
					switchTop = (getPaddingTop() + getHeight() - getPaddingBottom()) / 2 - mSwitchHeight
						 / 2;
					switchBottom = switchTop + mSwitchHeight;
					break;
				}

				case android.view.Gravity.BOTTOM:
				{
					switchBottom = getHeight() - getPaddingBottom();
					switchTop = switchBottom - mSwitchHeight;
					break;
				}
			}
			mSwitchLeft = switchLeft;
			mSwitchTop = switchTop;
			mSwitchBottom = switchBottom;
			mSwitchRight = switchRight;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
			// Draw the switch
			int switchLeft = mSwitchLeft;
			int switchTop = mSwitchTop;
			int switchRight = mSwitchRight;
			int switchBottom = mSwitchBottom;
			mTrackDrawable.setBounds(switchLeft, switchTop, switchRight, switchBottom);
			mTrackDrawable.draw(canvas);
			canvas.save();
			mTrackDrawable.getPadding(mTempRect);
			int switchInnerLeft = switchLeft + mTempRect.left;
			int switchInnerTop = switchTop + mTempRect.top;
			int switchInnerRight = switchRight - mTempRect.right;
			int switchInnerBottom = switchBottom - mTempRect.bottom;
			canvas.clipRect(switchInnerLeft, switchTop, switchInnerRight, switchBottom);
			mThumbDrawable.getPadding(mTempRect);
			int thumbPos = (int)(mThumbPosition + 0.5f);
			int thumbLeft = switchInnerLeft - mTempRect.left + thumbPos;
			int thumbRight = switchInnerLeft + thumbPos + mThumbWidth + mTempRect.right;
			mThumbDrawable.setBounds(thumbLeft, switchTop, thumbRight, switchBottom);
			mThumbDrawable.draw(canvas);
			// mTextColors should not be null, but just in case
			if (mTextColors != null)
			{
				mTextPaint.setColor(mTextColors.getColorForState(getDrawableState(), mTextColors.
					getDefaultColor()));
			}
			mTextPaint.drawableState = getDrawableState();
			android.text.Layout switchText = getTargetCheckedState() ? mOnLayout : mOffLayout;
			canvas.translate((thumbLeft + thumbRight) / 2 - switchText.getWidth() / 2, (switchInnerTop
				 + switchInnerBottom) / 2 - switchText.getHeight() / 2);
			switchText.draw(canvas);
			canvas.restore();
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		public override int getCompoundPaddingRight()
		{
			int padding = base.getCompoundPaddingRight() + mSwitchWidth;
			if (!android.text.TextUtils.isEmpty(getText()))
			{
				padding += mSwitchPadding;
			}
			return padding;
		}

		private int getThumbScrollRange()
		{
			if (mTrackDrawable == null)
			{
				return 0;
			}
			mTrackDrawable.getPadding(mTempRect);
			return mSwitchWidth - mThumbWidth - mTempRect.left - mTempRect.right;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int[] onCreateDrawableState(int extraSpace)
		{
			int[] drawableState = base.onCreateDrawableState(extraSpace + 1);
			if (isChecked())
			{
				mergeDrawableStates(drawableState, CHECKED_STATE_SET);
			}
			return drawableState;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			int[] myDrawableState = getDrawableState();
			// Set the state of the Drawable
			// Drawable may be null when checked state is set from XML, from super constructor
			if (mThumbDrawable != null)
			{
				mThumbDrawable.setState(myDrawableState);
			}
			if (mTrackDrawable != null)
			{
				mTrackDrawable.setState(myDrawableState);
			}
			invalidate();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return base.verifyDrawable(who) || who == mThumbDrawable || who == mTrackDrawable;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			mThumbDrawable.jumpToCurrentState();
			mTrackDrawable.jumpToCurrentState();
		}
	}
}
