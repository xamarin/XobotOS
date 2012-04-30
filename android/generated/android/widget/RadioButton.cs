using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>
	/// A radio button is a two-states button that can be either checked or
	/// unchecked.
	/// </summary>
	/// <remarks>
	/// <p>
	/// A radio button is a two-states button that can be either checked or
	/// unchecked. When the radio button is unchecked, the user can press or click it
	/// to check it. However, contrary to a
	/// <see cref="CheckBox">CheckBox</see>
	/// , a radio
	/// button cannot be unchecked by the user once checked.
	/// </p>
	/// <p>
	/// Radio buttons are normally used together in a
	/// <see cref="RadioGroup">RadioGroup</see>
	/// . When several radio buttons live inside
	/// a radio group, checking one radio button unchecks all the others.</p>
	/// </p>
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a>.</p>
	/// <p><strong>XML attributes</strong></p>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.CompoundButton">CompoundButton Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.Button">Button Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.TextView">TextView Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class RadioButton : android.widget.CompoundButton
	{
		public RadioButton(android.content.Context context) : this(context, null)
		{
		}

		public RadioButton(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.radioButtonStyle)
		{
		}

		public RadioButton(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// <p>
		/// If the radio button is already checked, this method will not toggle the radio button.
		/// </summary>
		[Sharpen.OverridesMethod(@"android.widget.CompoundButton")]
		public override void toggle()
		{
			// we override to prevent toggle when the radio is already
			// checked (as opposed to check boxes widgets)
			if (!isChecked())
			{
				base.toggle();
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
