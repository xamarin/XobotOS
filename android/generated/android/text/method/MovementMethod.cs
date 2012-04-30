using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// Provides cursor positioning, scrolling and text selection functionality in a
	/// <see cref="android.widget.TextView">android.widget.TextView</see>
	/// .
	/// <p>
	/// The
	/// <see cref="android.widget.TextView">android.widget.TextView</see>
	/// delegates handling of key events, trackball motions and touches to
	/// the movement method for purposes of content navigation.  The framework automatically
	/// selects an appropriate movement method based on the content of the
	/// <see cref="android.widget.TextView">android.widget.TextView</see>
	/// .
	/// </p><p>
	/// This interface is intended for use by the framework; it should not be implemented
	/// directly by applications.
	/// </p>
	/// </summary>
	[Sharpen.Sharpened]
	public interface MovementMethod
	{
		void initialize(android.widget.TextView widget, android.text.Spannable text);

		bool onKeyDown(android.widget.TextView widget, android.text.Spannable text, int keyCode
			, android.view.KeyEvent @event);

		bool onKeyUp(android.widget.TextView widget, android.text.Spannable text, int keyCode
			, android.view.KeyEvent @event);

		/// <summary>
		/// If the key listener wants to other kinds of key events, return true,
		/// otherwise return false and the caller (i.e.
		/// </summary>
		/// <remarks>
		/// If the key listener wants to other kinds of key events, return true,
		/// otherwise return false and the caller (i.e. the widget host)
		/// will handle the key.
		/// </remarks>
		bool onKeyOther(android.widget.TextView view, android.text.Spannable text, android.view.KeyEvent
			 @event);

		void onTakeFocus(android.widget.TextView widget, android.text.Spannable text, int
			 direction);

		bool onTrackballEvent(android.widget.TextView widget, android.text.Spannable text
			, android.view.MotionEvent @event);

		bool onTouchEvent(android.widget.TextView widget, android.text.Spannable text, android.view.MotionEvent
			 @event);

		bool onGenericMotionEvent(android.widget.TextView widget, android.text.Spannable 
			text, android.view.MotionEvent @event);

		/// <summary>
		/// Returns true if this movement method allows arbitrary selection
		/// of any text; false if it has no selection (like a movement method
		/// that only scrolls) or a constrained selection (for example
		/// limited to links.
		/// </summary>
		/// <remarks>
		/// Returns true if this movement method allows arbitrary selection
		/// of any text; false if it has no selection (like a movement method
		/// that only scrolls) or a constrained selection (for example
		/// limited to links.  The "Select All" menu item is disabled
		/// if arbitrary selection is not allowed.
		/// </remarks>
		bool canSelectArbitrarily();
	}
}
