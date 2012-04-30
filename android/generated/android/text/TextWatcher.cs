using Sharpen;

namespace android.text
{
	/// <summary>
	/// When an object of a type is attached to an Editable, its methods will
	/// be called when the text is changed.
	/// </summary>
	/// <remarks>
	/// When an object of a type is attached to an Editable, its methods will
	/// be called when the text is changed.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface TextWatcher : android.text.NoCopySpan
	{
		/// <summary>
		/// This method is called to notify you that, within <code>s</code>,
		/// the <code>count</code> characters beginning at <code>start</code>
		/// are about to be replaced by new text with length <code>after</code>.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that, within <code>s</code>,
		/// the <code>count</code> characters beginning at <code>start</code>
		/// are about to be replaced by new text with length <code>after</code>.
		/// It is an error to attempt to make changes to <code>s</code> from
		/// this callback.
		/// </remarks>
		void beforeTextChanged(java.lang.CharSequence s, int start, int count, int after);

		/// <summary>
		/// This method is called to notify you that, within <code>s</code>,
		/// the <code>count</code> characters beginning at <code>start</code>
		/// have just replaced old text that had length <code>before</code>.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that, within <code>s</code>,
		/// the <code>count</code> characters beginning at <code>start</code>
		/// have just replaced old text that had length <code>before</code>.
		/// It is an error to attempt to make changes to <code>s</code> from
		/// this callback.
		/// </remarks>
		void onTextChanged(java.lang.CharSequence s, int start, int before, int count);

		/// <summary>
		/// This method is called to notify you that, somewhere within
		/// <code>s</code>, the text has been changed.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that, somewhere within
		/// <code>s</code>, the text has been changed.
		/// It is legitimate to make further changes to <code>s</code> from
		/// this callback, but be careful not to get yourself into an infinite
		/// loop, because any changes you make will cause this method to be
		/// called again recursively.
		/// (You are not told where the change took place because other
		/// afterTextChanged() methods may already have made other changes
		/// and invalidated the offsets.  But if you need to know here,
		/// you can use
		/// <see cref="Spannable.setSpan(object, int, int, int)">Spannable.setSpan(object, int, int, int)
		/// 	</see>
		/// in
		/// <see cref="onTextChanged(java.lang.CharSequence, int, int, int)">onTextChanged(java.lang.CharSequence, int, int, int)
		/// 	</see>
		/// to mark your place and then look up from here where the span
		/// ended up.
		/// </remarks>
		void afterTextChanged(android.text.Editable s);
	}
}
