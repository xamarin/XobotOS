using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An extension to TextView that supports the
	/// <see cref="Checkable">Checkable</see>
	/// interface.
	/// This is useful when used in a
	/// <see cref="ListView">ListView</see>
	/// where the it's
	/// <see cref="AbsListView.setChoiceMode(int)">setChoiceMode</see>
	/// has been set to
	/// something other than
	/// <see cref="AbsListView.CHOICE_MODE_NONE">CHOICE_MODE_NONE</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public class CheckedTextView : android.widget.TextView, android.widget.Checkable
	{
		private bool mChecked;

		private int mCheckMarkResource;

		private android.graphics.drawable.Drawable mCheckMarkDrawable;

		private int mBasePadding;

		private int mCheckMarkWidth;

		private bool mNeedRequestlayout;

		private static readonly int[] CHECKED_STATE_SET = new int[] { android.@internal.R
			.attr.state_checked };

		public CheckedTextView(android.content.Context context) : this(context, null)
		{
		}

		public CheckedTextView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
		}

		public CheckedTextView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.CheckedTextView, defStyle, 0);
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.CheckedTextView_checkMark);
			if (d != null)
			{
				setCheckMarkDrawable(d);
			}
			bool @checked = a.getBoolean(android.@internal.R.styleable.CheckedTextView_checked
				, false);
			setChecked(@checked);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual void toggle()
		{
			setChecked(!mChecked);
		}

		[android.view.ViewDebug.ExportedProperty]
		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual bool isChecked()
		{
			return mChecked;
		}

		/// <summary><p>Changes the checked state of this text view.</p></summary>
		/// <param name="checked">true to check the text, false to uncheck it</param>
		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual void setChecked(bool @checked)
		{
			if (mChecked != @checked)
			{
				mChecked = @checked;
				refreshDrawableState();
			}
		}

		/// <summary>Set the checkmark to a given Drawable, identified by its resourece id.</summary>
		/// <remarks>
		/// Set the checkmark to a given Drawable, identified by its resourece id. This will be drawn
		/// when
		/// <see cref="isChecked()">isChecked()</see>
		/// is true.
		/// </remarks>
		/// <param name="resid">The Drawable to use for the checkmark.</param>
		public virtual void setCheckMarkDrawable(int resid)
		{
			if (resid != 0 && resid == mCheckMarkResource)
			{
				return;
			}
			mCheckMarkResource = resid;
			android.graphics.drawable.Drawable d = null;
			if (mCheckMarkResource != 0)
			{
				d = getResources().getDrawable(mCheckMarkResource);
			}
			setCheckMarkDrawable(d);
		}

		/// <summary>Set the checkmark to a given Drawable.</summary>
		/// <remarks>
		/// Set the checkmark to a given Drawable. This will be drawn when
		/// <see cref="isChecked()">isChecked()</see>
		/// is true.
		/// </remarks>
		/// <param name="d">The Drawable to use for the checkmark.</param>
		public virtual void setCheckMarkDrawable(android.graphics.drawable.Drawable d)
		{
			if (mCheckMarkDrawable != null)
			{
				mCheckMarkDrawable.setCallback(null);
				unscheduleDrawable(mCheckMarkDrawable);
			}
			mNeedRequestlayout = (d != mCheckMarkDrawable);
			if (d != null)
			{
				d.setCallback(this);
				d.setVisible(getVisibility() == VISIBLE, false);
				d.setState(CHECKED_STATE_SET);
				setMinHeight(d.getIntrinsicHeight());
				mCheckMarkWidth = d.getIntrinsicWidth();
				d.setState(getDrawableState());
			}
			else
			{
				mCheckMarkWidth = 0;
			}
			mCheckMarkDrawable = d;
			// Do padding resolution. This will call setPadding() and do a requestLayout() if needed.
			resolvePadding();
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void resolvePadding()
		{
			base.resolvePadding();
			int newPadding = (mCheckMarkDrawable != null) ? mCheckMarkWidth + mBasePadding : 
				mBasePadding;
			mNeedRequestlayout |= (mPaddingRight != newPadding);
			mPaddingRight = newPadding;
			if (mNeedRequestlayout)
			{
				requestLayout();
				mNeedRequestlayout = false;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setPadding(int left, int top, int right, int bottom)
		{
			base.setPadding(left, top, right, bottom);
			mBasePadding = mPaddingRight;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
			android.graphics.drawable.Drawable checkMarkDrawable = mCheckMarkDrawable;
			if (checkMarkDrawable != null)
			{
				int verticalGravity = getGravity() & android.view.Gravity.VERTICAL_GRAVITY_MASK;
				int height = checkMarkDrawable.getIntrinsicHeight();
				int y = 0;
				switch (verticalGravity)
				{
					case android.view.Gravity.BOTTOM:
					{
						y = getHeight() - height;
						break;
					}

					case android.view.Gravity.CENTER_VERTICAL:
					{
						y = (getHeight() - height) / 2;
						break;
					}
				}
				int right = getWidth();
				checkMarkDrawable.setBounds(right - mPaddingRight, y, right - mPaddingRight + mCheckMarkWidth
					, y + height);
				checkMarkDrawable.draw(canvas);
			}
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
			if (mCheckMarkDrawable != null)
			{
				int[] myDrawableState = getDrawableState();
				// Set the state of the Drawable
				mCheckMarkDrawable.setState(myDrawableState);
				invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			@event.setChecked(mChecked);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			if (isChecked())
			{
				@event.getText().add(java.lang.CharSequenceProxy.Wrap(mContext.getString(android.@internal.R
					.@string.radiobutton_selected)));
			}
			else
			{
				@event.getText().add(java.lang.CharSequenceProxy.Wrap(mContext.getString(android.@internal.R
					.@string.radiobutton_not_selected)));
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfo(info);
			info.setChecked(mChecked);
		}
	}
}
