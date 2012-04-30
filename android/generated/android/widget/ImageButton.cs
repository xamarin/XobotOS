using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>
	/// Displays a button with an image (instead of text) that can be pressed
	/// or clicked by the user.
	/// </summary>
	/// <remarks>
	/// <p>
	/// Displays a button with an image (instead of text) that can be pressed
	/// or clicked by the user. By default, an ImageButton looks like a regular
	/// <see cref="Button">Button</see>
	/// , with the standard button background
	/// that changes color during different button states. The image on the surface
	/// of the button is defined either by the
	/// <code>android:src</code>
	/// attribute in the
	/// <code><ImageButton></code>
	/// XML element or by the
	/// <see cref="ImageView.setImageResource(int)">ImageView.setImageResource(int)</see>
	/// method.</p>
	/// <p>To remove the standard button background image, define your own
	/// background image or set the background color to be transparent.</p>
	/// <p>To indicate the different button states (focused, selected, etc.), you can
	/// define a different image for each state. E.g., a blue image by default, an
	/// orange one for when focused, and a yellow one for when pressed. An easy way to
	/// do this is with an XML drawable "selector." For example:</p>
	/// <pre>
	/// &lt;?xml version="1.0" encoding="utf-8"?&gt;
	/// &lt;selector xmlns:android="http://schemas.android.com/apk/res/android"&gt;
	/// &lt;item android:state_pressed="true"
	/// android:drawable="@drawable/button_pressed" /&gt; &lt;!-- pressed --&gt;
	/// &lt;item android:state_focused="true"
	/// android:drawable="@drawable/button_focused" /&gt; &lt;!-- focused --&gt;
	/// &lt;item android:drawable="@drawable/button_normal" /&gt; &lt;!-- default --&gt;
	/// &lt;/selector&gt;</pre>
	/// <p>Save the XML file in your project
	/// <code>res/drawable/</code>
	/// folder and then
	/// reference it as a drawable for the source of your ImageButton (in the
	/// <code>android:src</code>
	/// attribute). Android will automatically change the image
	/// based on the state of the button and the corresponding images
	/// defined in the XML.</p>
	/// <p>The order of the
	/// <code><item></code>
	/// elements is important because they are
	/// evaluated in order. This is why the "normal" button image comes last, because
	/// it will only be applied after
	/// <code>android:state_pressed</code>
	/// and
	/// <code>android:state_focused</code>
	/// have both evaluated false.</p>
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a>.</p>
	/// <p><strong>XML attributes</strong></p>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.ImageView">Button Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class ImageButton : android.widget.ImageView
	{
		public ImageButton(android.content.Context context) : this(context, null)
		{
		}

		public ImageButton(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.imageButtonStyle)
		{
		}

		public ImageButton(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			setFocusable(true);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool onSetAlpha(int alpha)
		{
			return false;
		}
	}
}
