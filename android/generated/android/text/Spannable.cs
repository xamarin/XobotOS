using Sharpen;

namespace android.text
{
	/// <summary>
	/// This is the interface for text to which markup objects can be
	/// attached and detached.
	/// </summary>
	/// <remarks>
	/// This is the interface for text to which markup objects can be
	/// attached and detached.  Not all Spannable classes have mutable text;
	/// see
	/// <see cref="Editable">Editable</see>
	/// for that.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Spannable : android.text.Spanned
	{
		/// <summary>
		/// Attach the specified markup object to the range <code>start&hellip;end</code>
		/// of the text, or move the object to that range if it was already
		/// attached elsewhere.
		/// </summary>
		/// <remarks>
		/// Attach the specified markup object to the range <code>start&hellip;end</code>
		/// of the text, or move the object to that range if it was already
		/// attached elsewhere.  See
		/// <see cref="Spanned">Spanned</see>
		/// for an explanation of
		/// what the flags mean.  The object can be one that has meaning only
		/// within your application, or it can be one that the text system will
		/// use to affect text display or behavior.  Some noteworthy ones are
		/// the subclasses of
		/// <see cref="android.text.style.CharacterStyle">android.text.style.CharacterStyle</see>
		/// and
		/// <see cref="android.text.style.ParagraphStyle">android.text.style.ParagraphStyle</see>
		/// , and
		/// <see cref="TextWatcher">TextWatcher</see>
		/// and
		/// <see cref="SpanWatcher">SpanWatcher</see>
		/// .
		/// </remarks>
		void setSpan(object what, int start, int end, int flags);

		/// <summary>
		/// Remove the specified object from the range of text to which it
		/// was attached, if any.
		/// </summary>
		/// <remarks>
		/// Remove the specified object from the range of text to which it
		/// was attached, if any.  It is OK to remove an object that was never
		/// attached in the first place.
		/// </remarks>
		void removeSpan(object what);
	}

	/// <summary>
	/// This is the interface for text to which markup objects can be
	/// attached and detached.
	/// </summary>
	/// <remarks>
	/// This is the interface for text to which markup objects can be
	/// attached and detached.  Not all Spannable classes have mutable text;
	/// see
	/// <see cref="Editable">Editable</see>
	/// for that.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class SpannableClass
	{
		/// <summary>Factory used by TextView to create new Spannables.</summary>
		/// <remarks>
		/// Factory used by TextView to create new Spannables.  You can subclass
		/// it to provide something other than SpannableString.
		/// </remarks>
		public class Factory
		{
			private static android.text.SpannableClass.Factory sInstance = new android.text.SpannableClass
				.Factory();

			/// <summary>Returns the standard Spannable Factory.</summary>
			/// <remarks>Returns the standard Spannable Factory.</remarks>
			public static android.text.SpannableClass.Factory getInstance()
			{
				return sInstance;
			}

			/// <summary>Returns a new SpannableString from the specified CharSequence.</summary>
			/// <remarks>
			/// Returns a new SpannableString from the specified CharSequence.
			/// You can override this to provide a different kind of Spannable.
			/// </remarks>
			public virtual android.text.Spannable newSpannable(java.lang.CharSequence source)
			{
				return new android.text.SpannableString(source);
			}
		}
	}
}
