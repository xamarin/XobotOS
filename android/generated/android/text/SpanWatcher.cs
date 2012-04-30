using Sharpen;

namespace android.text
{
	/// <summary>
	/// When an object of this type is attached to a Spannable, its methods
	/// will be called to notify it that other markup objects have been
	/// added, changed, or removed.
	/// </summary>
	/// <remarks>
	/// When an object of this type is attached to a Spannable, its methods
	/// will be called to notify it that other markup objects have been
	/// added, changed, or removed.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface SpanWatcher : android.text.NoCopySpan
	{
		/// <summary>
		/// This method is called to notify you that the specified object
		/// has been attached to the specified range of the text.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that the specified object
		/// has been attached to the specified range of the text.
		/// </remarks>
		void onSpanAdded(android.text.Spannable text, object what, int start, int end);

		/// <summary>
		/// This method is called to notify you that the specified object
		/// has been detached from the specified range of the text.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that the specified object
		/// has been detached from the specified range of the text.
		/// </remarks>
		void onSpanRemoved(android.text.Spannable text, object what, int start, int end);

		/// <summary>
		/// This method is called to notify you that the specified object
		/// has been relocated from the range <code>ostart&hellip;oend</code>
		/// to the new range <code>nstart&hellip;nend</code> of the text.
		/// </summary>
		/// <remarks>
		/// This method is called to notify you that the specified object
		/// has been relocated from the range <code>ostart&hellip;oend</code>
		/// to the new range <code>nstart&hellip;nend</code> of the text.
		/// </remarks>
		void onSpanChanged(android.text.Spannable text, object what, int ostart, int oend
			, int nstart, int nend);
	}
}
