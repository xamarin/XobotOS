using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Specialized
	/// <see cref="ViewSwitcher">ViewSwitcher</see>
	/// that contains
	/// only children of type
	/// <see cref="TextView">TextView</see>
	/// .
	/// A TextSwitcher is useful to animate a label on screen. Whenever
	/// <see cref="setText(java.lang.CharSequence)">setText(java.lang.CharSequence)</see>
	/// is called, TextSwitcher animates the current text
	/// out and animates the new text in.
	/// </summary>
	[Sharpen.Sharpened]
	public class TextSwitcher : android.widget.ViewSwitcher
	{
		/// <summary>Creates a new empty TextSwitcher.</summary>
		/// <remarks>Creates a new empty TextSwitcher.</remarks>
		/// <param name="context">the application's environment</param>
		public TextSwitcher(android.content.Context context) : base(context)
		{
		}

		/// <summary>
		/// Creates a new empty TextSwitcher for the given context and with the
		/// specified set attributes.
		/// </summary>
		/// <remarks>
		/// Creates a new empty TextSwitcher for the given context and with the
		/// specified set attributes.
		/// </remarks>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">a collection of attributes</param>
		public TextSwitcher(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		/// <exception cref="System.ArgumentException">
		/// if child is not an instance of
		/// <see cref="TextView">TextView</see>
		/// </exception>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			if (!(child is android.widget.TextView))
			{
				throw new System.ArgumentException("TextSwitcher children must be instances of TextView"
					);
			}
			base.addView(child, index, @params);
		}

		/// <summary>Sets the text of the next view and switches to the next view.</summary>
		/// <remarks>
		/// Sets the text of the next view and switches to the next view. This can
		/// be used to animate the old text out and animate the next text in.
		/// </remarks>
		/// <param name="text">the new text to display</param>
		public virtual void setText(java.lang.CharSequence text)
		{
			android.widget.TextView t = (android.widget.TextView)getNextView();
			t.setText(text);
			showNext();
		}

		/// <summary>Sets the text of the text view that is currently showing.</summary>
		/// <remarks>
		/// Sets the text of the text view that is currently showing.  This does
		/// not perform the animations.
		/// </remarks>
		/// <param name="text">the new text to display</param>
		public virtual void setCurrentText(java.lang.CharSequence text)
		{
			((android.widget.TextView)getCurrentView()).setText(text);
		}
	}
}
