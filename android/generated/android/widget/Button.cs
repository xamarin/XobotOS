using Sharpen;

namespace android.widget
{
	/// <summary>Represents a push-button widget.</summary>
	/// <remarks>
	/// Represents a push-button widget. Push-buttons can be
	/// pressed, or clicked, by the user to perform an action.
	/// <p>A typical use of a push-button in an activity would be the following:
	/// </p>
	/// <pre>
	/// public class MyActivity extends Activity {
	/// protected void onCreate(Bundle icicle) {
	/// super.onCreate(icicle);
	/// setContentView(R.layout.content_layout_id);
	/// final Button button = (Button) findViewById(R.id.button_id);
	/// button.setOnClickListener(new View.OnClickListener() {
	/// public void onClick(View v) {
	/// // Perform action on click
	/// }
	/// });
	/// }
	/// }</pre>
	/// <p>However, instead of applying an
	/// <see cref="android.view.View.OnClickListener">OnClickListener</see>
	/// to
	/// the button in your activity, you can assign a method to your button in the XML layout,
	/// using the
	/// <see cref="android.R.attr.onClick">android:onClick</see>
	/// attribute. For example:</p>
	/// <pre>
	/// &lt;Button
	/// android:layout_height="wrap_content"
	/// android:layout_width="wrap_content"
	/// android:text="@string/self_destruct"
	/// android:onClick="selfDestruct" /&gt;</pre>
	/// <p>Now, when a user clicks the button, the Android system calls the activity's
	/// <code>selfDestruct(View)</code>
	/// method. In order for this to work, the method must be public and accept
	/// a
	/// <see cref="android.view.View">android.view.View</see>
	/// as its only parameter. For example:</p>
	/// <pre>
	/// public void selfDestruct(View view) {
	/// // Kabloey
	/// }</pre>
	/// <p>The
	/// <see cref="android.view.View">android.view.View</see>
	/// passed into the method is a reference to the widget
	/// that was clicked.</p>
	/// <h3>Button style</h3>
	/// <p>Every Button is styled using the system's default button background, which is often different
	/// from one device to another and from one version of the platform to another. If you're not
	/// satisfied with the default button style and want to customize it to match the design of your
	/// application, then you can replace the button's background image with a &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html#StateList"&gt;state list drawable</a>.
	/// A state list drawable is a drawable resource defined in XML that changes its image based on
	/// the current state of the button. Once you've defined a state list drawable in XML, you can apply
	/// it to your Button with the
	/// <see cref="android.R.attr.background">android:background</see>
	/// attribute. For more information and an example, see &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html#StateList"&gt;State List
	/// Drawable</a>.</p>
	/// <p>Also see the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a> for an example implementation of a button.</p>
	/// <p><strong>XML attributes</strong></p>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.Button">Button Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.TextView">TextView Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class Button : android.widget.TextView
	{
		public Button(android.content.Context context) : this(context, null)
		{
		}

		public Button(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, android.@internal.R.attr.buttonStyle)
		{
		}

		public Button(android.content.Context context, android.util.AttributeSet attrs, int
			 defStyle) : base(context, attrs, defStyle)
		{
		}
	}
}
