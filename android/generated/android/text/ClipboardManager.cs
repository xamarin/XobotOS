using Sharpen;

namespace android.text
{
	[Sharpen.Sharpened]
	[System.ObsoleteAttribute(@"Old text-only interface to the clipboard.  Seeandroid.content.ClipboardManager for the modern API."
		)]
	public abstract class ClipboardManager
	{
		/// <summary>Returns the text on the clipboard.</summary>
		/// <remarks>
		/// Returns the text on the clipboard.  It will eventually be possible
		/// to store types other than text too, in which case this will return
		/// null if the type cannot be coerced to text.
		/// </remarks>
		public abstract java.lang.CharSequence getText();

		/// <summary>Sets the contents of the clipboard to the specified text.</summary>
		/// <remarks>Sets the contents of the clipboard to the specified text.</remarks>
		public abstract void setText(java.lang.CharSequence text);

		/// <summary>Returns true if the clipboard contains text; false otherwise.</summary>
		/// <remarks>Returns true if the clipboard contains text; false otherwise.</remarks>
		public abstract bool hasText();
	}
}
