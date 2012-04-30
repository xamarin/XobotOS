using Sharpen;

namespace android.text
{
	/// <summary>
	/// This is the interface for text whose content and markup
	/// can be changed (as opposed
	/// to immutable text like Strings).
	/// </summary>
	/// <remarks>
	/// This is the interface for text whose content and markup
	/// can be changed (as opposed
	/// to immutable text like Strings).  If you make a
	/// <see cref="DynamicLayout">DynamicLayout</see>
	/// of an Editable, the layout will be reflowed as the text is changed.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Editable : java.lang.CharSequence, android.text.GetChars, android.text.Spannable
		, java.lang.Appendable
	{
		/// <summary>
		/// Replaces the specified range (<code>st&hellip;en</code>) of text in this
		/// Editable with a copy of the slice <code>start&hellip;end</code> from
		/// <code>source</code>.
		/// </summary>
		/// <remarks>
		/// Replaces the specified range (<code>st&hellip;en</code>) of text in this
		/// Editable with a copy of the slice <code>start&hellip;end</code> from
		/// <code>source</code>.  The destination slice may be empty, in which case
		/// the operation is an insertion, or the source slice may be empty,
		/// in which case the operation is a deletion.
		/// <p>
		/// Before the change is committed, each filter that was set with
		/// <see cref="setFilters(InputFilter[])">setFilters(InputFilter[])</see>
		/// is given the opportunity to modify the
		/// <code>source</code> text.
		/// <p>
		/// If <code>source</code>
		/// is Spanned, the spans from it are preserved into the Editable.
		/// Existing spans within the Editable that entirely cover the replaced
		/// range are retained, but any that were strictly within the range
		/// that was replaced are removed.  As a special case, the cursor
		/// position is preserved even when the entire range where it is
		/// located is replaced.
		/// </remarks>
		/// <returns>a reference to this object.</returns>
		android.text.Editable replace(int st, int en, java.lang.CharSequence source, int 
			start, int end);

		/// <summary>Convenience for replace(st, en, text, 0, text.length())</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable replace(int st, int en, java.lang.CharSequence text);

		/// <summary>Convenience for replace(where, where, text, start, end)</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable insert(int where, java.lang.CharSequence text, int start, int
			 end);

		/// <summary>Convenience for replace(where, where, text, 0, text.length());</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable insert(int where, java.lang.CharSequence text);

		/// <summary>Convenience for replace(st, en, "", 0, 0)</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable delete(int st, int en);

		/// <summary>Convenience for replace(length(), length(), text, 0, text.length())</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable append(java.lang.CharSequence text);

		/// <summary>Convenience for replace(length(), length(), text, start, end)</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable append(java.lang.CharSequence text, int start, int end);

		/// <summary>Convenience for append(String.valueOf(text)).</summary>
		/// <remarks>Convenience for append(String.valueOf(text)).</remarks>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">replace(int, int, java.lang.CharSequence, int, int)
		/// 	</seealso>
		android.text.Editable append(char text);

		/// <summary>Convenience for replace(0, length(), "", 0, 0)</summary>
		/// <seealso cref="replace(int, int, java.lang.CharSequence, int, int)">
		/// Note that this clears the text, not the spans;
		/// use
		/// <see cref="clearSpans()">clearSpans()</see>
		/// if you need that.
		/// </seealso>
		void clear();

		/// <summary>
		/// Removes all spans from the Editable, as if by calling
		/// <see cref="Spannable.removeSpan(object)">Spannable.removeSpan(object)</see>
		/// on each of them.
		/// </summary>
		void clearSpans();

		/// <summary>
		/// Sets the series of filters that will be called in succession
		/// whenever the text of this Editable is changed, each of which has
		/// the opportunity to limit or transform the text that is being inserted.
		/// </summary>
		/// <remarks>
		/// Sets the series of filters that will be called in succession
		/// whenever the text of this Editable is changed, each of which has
		/// the opportunity to limit or transform the text that is being inserted.
		/// </remarks>
		void setFilters(android.text.InputFilter[] filters);

		/// <summary>
		/// Returns the array of input filters that are currently applied
		/// to changes to this Editable.
		/// </summary>
		/// <remarks>
		/// Returns the array of input filters that are currently applied
		/// to changes to this Editable.
		/// </remarks>
		android.text.InputFilter[] getFilters();
	}

	/// <summary>
	/// This is the interface for text whose content and markup
	/// can be changed (as opposed
	/// to immutable text like Strings).
	/// </summary>
	/// <remarks>
	/// This is the interface for text whose content and markup
	/// can be changed (as opposed
	/// to immutable text like Strings).  If you make a
	/// <see cref="DynamicLayout">DynamicLayout</see>
	/// of an Editable, the layout will be reflowed as the text is changed.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class EditableClass
	{
		/// <summary>Factory used by TextView to create new Editables.</summary>
		/// <remarks>
		/// Factory used by TextView to create new Editables.  You can subclass
		/// it to provide something other than SpannableStringBuilder.
		/// </remarks>
		public class Factory
		{
			private static android.text.EditableClass.Factory sInstance = new android.text.EditableClass
				.Factory();

			/// <summary>Returns the standard Editable Factory.</summary>
			/// <remarks>Returns the standard Editable Factory.</remarks>
			public static android.text.EditableClass.Factory getInstance()
			{
				return sInstance;
			}

			/// <summary>
			/// Returns a new SpannedStringBuilder from the specified
			/// CharSequence.
			/// </summary>
			/// <remarks>
			/// Returns a new SpannedStringBuilder from the specified
			/// CharSequence.  You can override this to provide
			/// a different kind of Spanned.
			/// </remarks>
			public virtual android.text.Editable newEditable(java.lang.CharSequence source)
			{
				return new android.text.SpannableStringBuilder(source);
			}
		}
	}
}
