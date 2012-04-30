using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>
	/// A checkbox is a specific type of two-states button that can be either
	/// checked or unchecked.
	/// </summary>
	/// <remarks>
	/// <p>
	/// A checkbox is a specific type of two-states button that can be either
	/// checked or unchecked. A example usage of a checkbox inside your activity
	/// would be the following:
	/// </p>
	/// <pre class="prettyprint">
	/// public class MyActivity extends Activity {
	/// protected void onCreate(Bundle icicle) {
	/// super.onCreate(icicle);
	/// setContentView(R.layout.content_layout_id);
	/// final CheckBox checkBox = (CheckBox) findViewById(R.id.checkbox_id);
	/// if (checkBox.isChecked()) {
	/// checkBox.setChecked(false);
	/// }
	/// }
	/// }
	/// </pre>
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
	public class CheckBox : android.widget.CompoundButton
	{
		public CheckBox(android.content.Context context) : this(context, null)
		{
		}

		public CheckBox(android.content.Context context, android.util.AttributeSet attrs)
			 : this(context, attrs, android.@internal.R.attr.checkboxStyle)
		{
		}

		public CheckBox(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
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
