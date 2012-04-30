using Sharpen;

namespace android.text
{
	/// <summary>
	/// This is the interface for text that has markup objects attached to
	/// ranges of it.
	/// </summary>
	/// <remarks>
	/// This is the interface for text that has markup objects attached to
	/// ranges of it.  Not all text classes have mutable markup or text;
	/// see
	/// <see cref="Spannable">Spannable</see>
	/// for mutable markup and
	/// <see cref="Editable">Editable</see>
	/// for
	/// mutable text.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Spanned : java.lang.CharSequence
	{
		/// <summary>
		/// Return an array of the markup objects attached to the specified
		/// slice of this CharSequence and whose type is the specified type
		/// or a subclass of it.
		/// </summary>
		/// <remarks>
		/// Return an array of the markup objects attached to the specified
		/// slice of this CharSequence and whose type is the specified type
		/// or a subclass of it.  Specify Object.class for the type if you
		/// want all the objects regardless of type.
		/// </remarks>
		T[] getSpans<T>(int start, int end);

		/// <summary>
		/// Return the beginning of the range of text to which the specified
		/// markup object is attached, or -1 if the object is not attached.
		/// </summary>
		/// <remarks>
		/// Return the beginning of the range of text to which the specified
		/// markup object is attached, or -1 if the object is not attached.
		/// </remarks>
		int getSpanStart(object tag);

		/// <summary>
		/// Return the end of the range of text to which the specified
		/// markup object is attached, or -1 if the object is not attached.
		/// </summary>
		/// <remarks>
		/// Return the end of the range of text to which the specified
		/// markup object is attached, or -1 if the object is not attached.
		/// </remarks>
		int getSpanEnd(object tag);

		/// <summary>
		/// Return the flags that were specified when
		/// <see cref="Spannable.setSpan(object, int, int, int)">Spannable.setSpan(object, int, int, int)
		/// 	</see>
		/// was
		/// used to attach the specified markup object, or 0 if the specified
		/// object has not been attached.
		/// </summary>
		int getSpanFlags(object tag);

		/// <summary>
		/// Return the first offset greater than or equal to <code>start</code>
		/// where a markup object of class <code>type</code> begins or ends,
		/// or <code>limit</code> if there are no starts or ends greater than or
		/// equal to <code>start</code> but less than <code>limit</code>.
		/// </summary>
		/// <remarks>
		/// Return the first offset greater than or equal to <code>start</code>
		/// where a markup object of class <code>type</code> begins or ends,
		/// or <code>limit</code> if there are no starts or ends greater than or
		/// equal to <code>start</code> but less than <code>limit</code>.  Specify
		/// <code>null</code> or Object.class for the type if you want every
		/// transition regardless of type.
		/// </remarks>
		int nextSpanTransition(int start, int limit, System.Type type);
	}

	/// <summary>
	/// This is the interface for text that has markup objects attached to
	/// ranges of it.
	/// </summary>
	/// <remarks>
	/// This is the interface for text that has markup objects attached to
	/// ranges of it.  Not all text classes have mutable markup or text;
	/// see
	/// <see cref="Spannable">Spannable</see>
	/// for mutable markup and
	/// <see cref="Editable">Editable</see>
	/// for
	/// mutable text.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class SpannedClass
	{
		/// <summary>
		/// Bitmask of bits that are relevent for controlling point/mark behavior
		/// of spans.
		/// </summary>
		/// <remarks>
		/// Bitmask of bits that are relevent for controlling point/mark behavior
		/// of spans.
		/// </remarks>
		public const int SPAN_POINT_MARK_MASK = unchecked((int)(0x33));

		/// <summary>
		/// 0-length spans with type SPAN_MARK_MARK behave like text marks:
		/// they remain at their original offset when text is inserted
		/// at that offset.
		/// </summary>
		/// <remarks>
		/// 0-length spans with type SPAN_MARK_MARK behave like text marks:
		/// they remain at their original offset when text is inserted
		/// at that offset.
		/// </remarks>
		public const int SPAN_MARK_MARK = unchecked((int)(0x11));

		/// <summary>
		/// SPAN_MARK_POINT is a synonym for
		/// <see cref="android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE">android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
		/// 	</see>
		/// .
		/// </summary>
		public const int SPAN_MARK_POINT = unchecked((int)(0x12));

		/// <summary>
		/// SPAN_POINT_MARK is a synonym for
		/// <see cref="android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE">android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
		/// 	</see>
		/// .
		/// </summary>
		public const int SPAN_POINT_MARK = unchecked((int)(0x21));

		/// <summary>
		/// 0-length spans with type SPAN_POINT_POINT behave like cursors:
		/// they are pushed forward by the length of the insertion when text
		/// is inserted at their offset.
		/// </summary>
		/// <remarks>
		/// 0-length spans with type SPAN_POINT_POINT behave like cursors:
		/// they are pushed forward by the length of the insertion when text
		/// is inserted at their offset.
		/// </remarks>
		public const int SPAN_POINT_POINT = unchecked((int)(0x22));

		/// <summary>
		/// SPAN_PARAGRAPH behaves like SPAN_INCLUSIVE_EXCLUSIVE
		/// (SPAN_MARK_MARK), except that if either end of the span is
		/// at the end of the buffer, that end behaves like _POINT
		/// instead (so SPAN_INCLUSIVE_INCLUSIVE if it starts in the
		/// middle and ends at the end, or SPAN_EXCLUSIVE_INCLUSIVE
		/// if it both starts and ends at the end).
		/// </summary>
		/// <remarks>
		/// SPAN_PARAGRAPH behaves like SPAN_INCLUSIVE_EXCLUSIVE
		/// (SPAN_MARK_MARK), except that if either end of the span is
		/// at the end of the buffer, that end behaves like _POINT
		/// instead (so SPAN_INCLUSIVE_INCLUSIVE if it starts in the
		/// middle and ends at the end, or SPAN_EXCLUSIVE_INCLUSIVE
		/// if it both starts and ends at the end).
		/// <p>
		/// Its endpoints must be the start or end of the buffer or
		/// immediately after a \n character, and if the \n
		/// that anchors it is deleted, the endpoint is pulled to the
		/// next \n that follows in the buffer (or to the end of
		/// the buffer).
		/// </remarks>
		public const int SPAN_PARAGRAPH = unchecked((int)(0x33));

		/// <summary>
		/// Non-0-length spans of type SPAN_INCLUSIVE_EXCLUSIVE expand
		/// to include text inserted at their starting point but not at their
		/// ending point.
		/// </summary>
		/// <remarks>
		/// Non-0-length spans of type SPAN_INCLUSIVE_EXCLUSIVE expand
		/// to include text inserted at their starting point but not at their
		/// ending point.  When 0-length, they behave like marks.
		/// </remarks>
		public const int SPAN_INCLUSIVE_EXCLUSIVE = android.text.SpannedClass.SPAN_MARK_MARK;

		/// <summary>
		/// Spans of type SPAN_INCLUSIVE_INCLUSIVE expand
		/// to include text inserted at either their starting or ending point.
		/// </summary>
		/// <remarks>
		/// Spans of type SPAN_INCLUSIVE_INCLUSIVE expand
		/// to include text inserted at either their starting or ending point.
		/// </remarks>
		public const int SPAN_INCLUSIVE_INCLUSIVE = android.text.SpannedClass.SPAN_MARK_POINT;

		/// <summary>
		/// Spans of type SPAN_EXCLUSIVE_EXCLUSIVE do not expand
		/// to include text inserted at either their starting or ending point.
		/// </summary>
		/// <remarks>
		/// Spans of type SPAN_EXCLUSIVE_EXCLUSIVE do not expand
		/// to include text inserted at either their starting or ending point.
		/// They can never have a length of 0 and are automatically removed
		/// from the buffer if all the text they cover is removed.
		/// </remarks>
		public const int SPAN_EXCLUSIVE_EXCLUSIVE = android.text.SpannedClass.SPAN_POINT_MARK;

		/// <summary>
		/// Non-0-length spans of type SPAN_EXCLUSIVE_INCLUSIVE expand
		/// to include text inserted at their ending point but not at their
		/// starting point.
		/// </summary>
		/// <remarks>
		/// Non-0-length spans of type SPAN_EXCLUSIVE_INCLUSIVE expand
		/// to include text inserted at their ending point but not at their
		/// starting point.  When 0-length, they behave like points.
		/// </remarks>
		public const int SPAN_EXCLUSIVE_INCLUSIVE = android.text.SpannedClass.SPAN_POINT_POINT;

		/// <summary>
		/// This flag is set on spans that are being used to apply temporary
		/// styling information on the composing text of an input method, so that
		/// they can be found and removed when the composing text is being
		/// replaced.
		/// </summary>
		/// <remarks>
		/// This flag is set on spans that are being used to apply temporary
		/// styling information on the composing text of an input method, so that
		/// they can be found and removed when the composing text is being
		/// replaced.
		/// </remarks>
		public const int SPAN_COMPOSING = unchecked((int)(0x100));

		/// <summary>
		/// This flag will be set for intermediate span changes, meaning there
		/// is guaranteed to be another change following it.
		/// </summary>
		/// <remarks>
		/// This flag will be set for intermediate span changes, meaning there
		/// is guaranteed to be another change following it.  Typically it is
		/// used for
		/// <see cref="Selection">Selection</see>
		/// which automatically uses this with the first
		/// offset it sets when updating the selection.
		/// </remarks>
		public const int SPAN_INTERMEDIATE = unchecked((int)(0x200));

		/// <summary>
		/// The bits numbered SPAN_USER_SHIFT and above are available
		/// for callers to use to store scalar data associated with their
		/// span object.
		/// </summary>
		/// <remarks>
		/// The bits numbered SPAN_USER_SHIFT and above are available
		/// for callers to use to store scalar data associated with their
		/// span object.
		/// </remarks>
		public const int SPAN_USER_SHIFT = 24;

		/// <summary>
		/// The bits specified by the SPAN_USER bitfield are available
		/// for callers to use to store scalar data associated with their
		/// span object.
		/// </summary>
		/// <remarks>
		/// The bits specified by the SPAN_USER bitfield are available
		/// for callers to use to store scalar data associated with their
		/// span object.
		/// </remarks>
		public const int SPAN_USER = unchecked((int)(0xFFFFFFFF)) << android.text.SpannedClass.SPAN_USER_SHIFT;

		/// <summary>
		/// The bits numbered just above SPAN_PRIORITY_SHIFT determine the order
		/// of change notifications -- higher numbers go first.
		/// </summary>
		/// <remarks>
		/// The bits numbered just above SPAN_PRIORITY_SHIFT determine the order
		/// of change notifications -- higher numbers go first.  You probably
		/// don't need to set this; it is used so that when text changes, the
		/// text layout gets the chance to update itself before any other
		/// callbacks can inquire about the layout of the text.
		/// </remarks>
		public const int SPAN_PRIORITY_SHIFT = 16;

		/// <summary>
		/// The bits specified by the SPAN_PRIORITY bitmap determine the order
		/// of change notifications -- higher numbers go first.
		/// </summary>
		/// <remarks>
		/// The bits specified by the SPAN_PRIORITY bitmap determine the order
		/// of change notifications -- higher numbers go first.  You probably
		/// don't need to set this; it is used so that when text changes, the
		/// text layout gets the chance to update itself before any other
		/// callbacks can inquire about the layout of the text.
		/// </remarks>
		public const int SPAN_PRIORITY = unchecked((int)(0xFF)) << android.text.SpannedClass.SPAN_PRIORITY_SHIFT;
	}
}
