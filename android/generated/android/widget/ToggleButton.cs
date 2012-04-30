using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Displays checked/unchecked states as a button
	/// with a "light" indicator and by default accompanied with the text "ON" or "OFF".
	/// </summary>
	/// <remarks>
	/// Displays checked/unchecked states as a button
	/// with a "light" indicator and by default accompanied with the text "ON" or "OFF".
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ToggleButton_textOn</attr>
	/// <attr>ref android.R.styleable#ToggleButton_textOff</attr>
	/// <attr>ref android.R.styleable#ToggleButton_disabledAlpha</attr>
	[Sharpen.Sharpened]
	public class ToggleButton : android.widget.CompoundButton
	{
		private java.lang.CharSequence mTextOn;

		private java.lang.CharSequence mTextOff;

		private android.graphics.drawable.Drawable mIndicatorDrawable;

		internal const int NO_ALPHA = unchecked((int)(0xFF));

		private float mDisabledAlpha;

		public ToggleButton(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ToggleButton, defStyle, 0);
			mTextOn = a.getText(android.@internal.R.styleable.ToggleButton_textOn);
			mTextOff = a.getText(android.@internal.R.styleable.ToggleButton_textOff);
			mDisabledAlpha = a.getFloat(android.@internal.R.styleable.ToggleButton_disabledAlpha
				, 0.5f);
			syncTextState();
			a.recycle();
		}

		public ToggleButton(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.buttonStyleToggle)
		{
		}

		public ToggleButton(android.content.Context context) : this(context, null)
		{
		}

		[Sharpen.OverridesMethod(@"android.widget.CompoundButton")]
		public override void setChecked(bool @checked)
		{
			base.setChecked(@checked);
			syncTextState();
		}

		private void syncTextState()
		{
			bool @checked = isChecked();
			if (@checked && mTextOn != null)
			{
				setText(mTextOn);
			}
			else
			{
				if (!@checked && mTextOff != null)
				{
					setText(mTextOff);
				}
			}
		}

		/// <summary>Returns the text for when the button is in the checked state.</summary>
		/// <remarks>Returns the text for when the button is in the checked state.</remarks>
		/// <returns>The text.</returns>
		public virtual java.lang.CharSequence getTextOn()
		{
			return mTextOn;
		}

		/// <summary>Sets the text for when the button is in the checked state.</summary>
		/// <remarks>Sets the text for when the button is in the checked state.</remarks>
		/// <param name="textOn">The text.</param>
		public virtual void setTextOn(java.lang.CharSequence textOn)
		{
			mTextOn = textOn;
		}

		/// <summary>Returns the text for when the button is not in the checked state.</summary>
		/// <remarks>Returns the text for when the button is not in the checked state.</remarks>
		/// <returns>The text.</returns>
		public virtual java.lang.CharSequence getTextOff()
		{
			return mTextOff;
		}

		/// <summary>Sets the text for when the button is not in the checked state.</summary>
		/// <remarks>Sets the text for when the button is not in the checked state.</remarks>
		/// <param name="textOff">The text.</param>
		public virtual void setTextOff(java.lang.CharSequence textOff)
		{
			mTextOff = textOff;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			updateReferenceToIndicatorDrawable(getBackground());
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setBackgroundDrawable(android.graphics.drawable.Drawable d)
		{
			base.setBackgroundDrawable(d);
			updateReferenceToIndicatorDrawable(d);
		}

		private void updateReferenceToIndicatorDrawable(android.graphics.drawable.Drawable
			 backgroundDrawable)
		{
			if (backgroundDrawable is android.graphics.drawable.LayerDrawable)
			{
				android.graphics.drawable.LayerDrawable layerDrawable = (android.graphics.drawable.LayerDrawable
					)backgroundDrawable;
				mIndicatorDrawable = layerDrawable.findDrawableByLayerId(android.@internal.R.id.toggle
					);
			}
			else
			{
				mIndicatorDrawable = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			if (mIndicatorDrawable != null)
			{
				mIndicatorDrawable.setAlpha(isEnabled() ? NO_ALPHA : (int)(NO_ALPHA * mDisabledAlpha
					));
			}
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}
	}
}
