using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>
	/// A button with two states, checked and unchecked.
	/// </summary>
	/// <remarks>
	/// <p>
	/// A button with two states, checked and unchecked. When the button is pressed
	/// or clicked, the state changes automatically.
	/// </p>
	/// <p><strong>XML attributes</strong></p>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.CompoundButton">CompoundButton Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.Button">
	/// Button
	/// Attributes
	/// </see>
	/// ,
	/// <see cref="android.R.styleable.TextView">TextView Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class CompoundButton : android.widget.Button, android.widget.Checkable
	{
		private bool mChecked;

		private int mButtonResource;

		private bool mBroadcasting;

		private android.graphics.drawable.Drawable mButtonDrawable;

		private android.widget.CompoundButton.OnCheckedChangeListener mOnCheckedChangeListener;

		private android.widget.CompoundButton.OnCheckedChangeListener mOnCheckedChangeWidgetListener;

		private static readonly int[] CHECKED_STATE_SET = new int[] { android.@internal.R
			.attr.state_checked };

		public CompoundButton(android.content.Context context) : this(context, null)
		{
		}

		public CompoundButton(android.content.Context context, android.util.AttributeSet 
			attrs) : this(context, attrs, 0)
		{
		}

		public CompoundButton(android.content.Context context, android.util.AttributeSet 
			attrs, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.CompoundButton, defStyle, 0);
			android.graphics.drawable.Drawable d = a.getDrawable(android.@internal.R.styleable
				.CompoundButton_button);
			if (d != null)
			{
				setButtonDrawable(d);
			}
			bool @checked = a.getBoolean(android.@internal.R.styleable.CompoundButton_checked
				, false);
			setChecked(@checked);
			a.recycle();
		}

		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual void toggle()
		{
			setChecked(!mChecked);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool performClick()
		{
			toggle();
			return base.performClick();
		}

		[android.view.ViewDebug.ExportedProperty]
		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual bool isChecked()
		{
			return mChecked;
		}

		/// <summary><p>Changes the checked state of this button.</p></summary>
		/// <param name="checked">true to check the button, false to uncheck it</param>
		[Sharpen.ImplementsInterface(@"android.widget.Checkable")]
		public virtual void setChecked(bool @checked)
		{
			if (mChecked != @checked)
			{
				mChecked = @checked;
				refreshDrawableState();
				// Avoid infinite recursions if setChecked() is called from a listener
				if (mBroadcasting)
				{
					return;
				}
				mBroadcasting = true;
				if (mOnCheckedChangeListener != null)
				{
					mOnCheckedChangeListener.onCheckedChanged(this, mChecked);
				}
				if (mOnCheckedChangeWidgetListener != null)
				{
					mOnCheckedChangeWidgetListener.onCheckedChanged(this, mChecked);
				}
				mBroadcasting = false;
			}
		}

		/// <summary>
		/// Register a callback to be invoked when the checked state of this button
		/// changes.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when the checked state of this button
		/// changes.
		/// </remarks>
		/// <param name="listener">the callback to call on checked state change</param>
		public virtual void setOnCheckedChangeListener(android.widget.CompoundButton.OnCheckedChangeListener
			 listener)
		{
			mOnCheckedChangeListener = listener;
		}

		/// <summary>
		/// Register a callback to be invoked when the checked state of this button
		/// changes.
		/// </summary>
		/// <remarks>
		/// Register a callback to be invoked when the checked state of this button
		/// changes. This callback is used for internal purpose only.
		/// </remarks>
		/// <param name="listener">the callback to call on checked state change</param>
		/// <hide></hide>
		internal virtual void setOnCheckedChangeWidgetListener(android.widget.CompoundButton
			.OnCheckedChangeListener listener)
		{
			mOnCheckedChangeWidgetListener = listener;
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when the checked state
		/// of a compound button changed.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when the checked state
		/// of a compound button changed.
		/// </remarks>
		public interface OnCheckedChangeListener
		{
			/// <summary>Called when the checked state of a compound button has changed.</summary>
			/// <remarks>Called when the checked state of a compound button has changed.</remarks>
			/// <param name="buttonView">The compound button view whose state has changed.</param>
			/// <param name="isChecked">The new checked state of buttonView.</param>
			void onCheckedChanged(android.widget.CompoundButton buttonView, bool isChecked);
		}

		/// <summary>Set the background to a given Drawable, identified by its resource id.</summary>
		/// <remarks>Set the background to a given Drawable, identified by its resource id.</remarks>
		/// <param name="resid">the resource id of the drawable to use as the background</param>
		public virtual void setButtonDrawable(int resid)
		{
			if (resid != 0 && resid == mButtonResource)
			{
				return;
			}
			mButtonResource = resid;
			android.graphics.drawable.Drawable d = null;
			if (mButtonResource != 0)
			{
				d = getResources().getDrawable(mButtonResource);
			}
			setButtonDrawable(d);
		}

		/// <summary>Set the background to a given Drawable</summary>
		/// <param name="d">The Drawable to use as the background</param>
		public virtual void setButtonDrawable(android.graphics.drawable.Drawable d)
		{
			if (d != null)
			{
				if (mButtonDrawable != null)
				{
					mButtonDrawable.setCallback(null);
					unscheduleDrawable(mButtonDrawable);
				}
				d.setCallback(this);
				d.setState(getDrawableState());
				d.setVisible(getVisibility() == VISIBLE, false);
				mButtonDrawable = d;
				mButtonDrawable.setState(null);
				setMinHeight(mButtonDrawable.getIntrinsicHeight());
			}
			refreshDrawableState();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			@event.setChecked(mChecked);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			base.onInitializeAccessibilityNodeInfo(info);
			info.setCheckable(true);
			info.setChecked(mChecked);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			base.onDraw(canvas);
			android.graphics.drawable.Drawable buttonDrawable = mButtonDrawable;
			if (buttonDrawable != null)
			{
				int verticalGravity = getGravity() & android.view.Gravity.VERTICAL_GRAVITY_MASK;
				int height = buttonDrawable.getIntrinsicHeight();
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
				buttonDrawable.setBounds(0, y, buttonDrawable.getIntrinsicWidth(), y + height);
				buttonDrawable.draw(canvas);
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
			if (mButtonDrawable != null)
			{
				int[] myDrawableState = getDrawableState();
				// Set the state of the Drawable
				mButtonDrawable.setState(myDrawableState);
				invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return base.verifyDrawable(who) || who == mButtonDrawable;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mButtonDrawable != null)
			{
				mButtonDrawable.jumpToCurrentState();
			}
		}

		internal class SavedState : android.view.View.BaseSavedState
		{
			internal bool @checked;

			/// <summary>
			/// Constructor called from
			/// <see cref="CompoundButton.onSaveInstanceState()">CompoundButton.onSaveInstanceState()
			/// 	</see>
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
				@checked = (bool)@in.readValue(null);
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeValue(@checked);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "CompoundButton.SavedState{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " checked=" + @checked + "}";
			}

			private sealed class _Creator_315 : android.os.ParcelableClass.Creator<android.widget.CompoundButton
				.SavedState>
			{
				public _Creator_315()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.CompoundButton.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					return new android.widget.CompoundButton.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.CompoundButton.SavedState[] newArray(int size)
				{
					return new android.widget.CompoundButton.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.CompoundButton
				.SavedState> CREATOR = new _Creator_315();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			// Force our ancestor class to save its state
			setFreezesText(true);
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.widget.CompoundButton.SavedState ss = new android.widget.CompoundButton.SavedState
				(superState);
			ss.@checked = isChecked();
			return ss;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.widget.CompoundButton.SavedState ss = (android.widget.CompoundButton.SavedState
				)state;
			base.onRestoreInstanceState(ss.getSuperState());
			setChecked(ss.@checked);
			requestLayout();
		}
	}
}
