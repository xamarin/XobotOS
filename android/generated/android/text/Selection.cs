using Sharpen;

namespace android.text
{
	/// <summary>Utility class for manipulating cursors and selections in CharSequences.</summary>
	/// <remarks>
	/// Utility class for manipulating cursors and selections in CharSequences.
	/// A cursor is a selection where the start and end are at the same offset.
	/// </remarks>
	[Sharpen.Sharpened]
	public class Selection
	{
		private Selection()
		{
		}

		/// <summary>
		/// Return the offset of the selection anchor or cursor, or -1 if
		/// there is no selection or cursor.
		/// </summary>
		/// <remarks>
		/// Return the offset of the selection anchor or cursor, or -1 if
		/// there is no selection or cursor.
		/// </remarks>
		public static int getSelectionStart(java.lang.CharSequence text)
		{
			if (text is android.text.Spanned)
			{
				return ((android.text.Spanned)text).getSpanStart(SELECTION_START);
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// Return the offset of the selection edge or cursor, or -1 if
		/// there is no selection or cursor.
		/// </summary>
		/// <remarks>
		/// Return the offset of the selection edge or cursor, or -1 if
		/// there is no selection or cursor.
		/// </remarks>
		public static int getSelectionEnd(java.lang.CharSequence text)
		{
			if (text is android.text.Spanned)
			{
				return ((android.text.Spanned)text).getSpanStart(SELECTION_END);
			}
			else
			{
				return -1;
			}
		}

		// private static int pin(int value, int min, int max) {
		//     return value < min ? 0 : (value > max ? max : value);
		// }
		/// <summary>
		/// Set the selection anchor to <code>start</code> and the selection edge
		/// to <code>stop</code>.
		/// </summary>
		/// <remarks>
		/// Set the selection anchor to <code>start</code> and the selection edge
		/// to <code>stop</code>.
		/// </remarks>
		public static void setSelection(android.text.Spannable text, int start, int stop)
		{
			// int len = text.length();
			// start = pin(start, 0, len);  XXX remove unless we really need it
			// stop = pin(stop, 0, len);
			int ostart = getSelectionStart(text);
			int oend = getSelectionEnd(text);
			if (ostart != start || oend != stop)
			{
				text.setSpan(SELECTION_START, start, start, android.text.SpannedClass.SPAN_POINT_POINT
					 | android.text.SpannedClass.SPAN_INTERMEDIATE);
				text.setSpan(SELECTION_END, stop, stop, android.text.SpannedClass.SPAN_POINT_POINT
					);
			}
		}

		/// <summary>Move the cursor to offset <code>index</code>.</summary>
		/// <remarks>Move the cursor to offset <code>index</code>.</remarks>
		public static void setSelection(android.text.Spannable text, int index)
		{
			setSelection(text, index, index);
		}

		/// <summary>Select the entire text.</summary>
		/// <remarks>Select the entire text.</remarks>
		public static void selectAll(android.text.Spannable text)
		{
			setSelection(text, 0, text.Length);
		}

		/// <summary>Move the selection edge to offset <code>index</code>.</summary>
		/// <remarks>Move the selection edge to offset <code>index</code>.</remarks>
		public static void extendSelection(android.text.Spannable text, int index)
		{
			if (text.getSpanStart(SELECTION_END) != index)
			{
				text.setSpan(SELECTION_END, index, index, android.text.SpannedClass.SPAN_POINT_POINT
					);
			}
		}

		/// <summary>Remove the selection or cursor, if any, from the text.</summary>
		/// <remarks>Remove the selection or cursor, if any, from the text.</remarks>
		public static void removeSelection(android.text.Spannable text)
		{
			text.removeSpan(SELECTION_START);
			text.removeSpan(SELECTION_END);
		}

		/// <summary>
		/// Move the cursor to the buffer offset physically above the current
		/// offset, or return false if the cursor is already on the top line.
		/// </summary>
		/// <remarks>
		/// Move the cursor to the buffer offset physically above the current
		/// offset, or return false if the cursor is already on the top line.
		/// </remarks>
		public static bool moveUp(android.text.Spannable text, android.text.Layout layout
			)
		{
			int start = getSelectionStart(text);
			int end = getSelectionEnd(text);
			if (start != end)
			{
				int min = System.Math.Min(start, end);
				int max = System.Math.Max(start, end);
				setSelection(text, min);
				if (min == 0 && max == text.Length)
				{
					return false;
				}
				return true;
			}
			else
			{
				int line = layout.getLineForOffset(end);
				if (line > 0)
				{
					int move;
					if (layout.getParagraphDirection(line) == layout.getParagraphDirection(line - 1))
					{
						float h = layout.getPrimaryHorizontal(end);
						move = layout.getOffsetForHorizontal(line - 1, h);
					}
					else
					{
						move = layout.getLineStart(line - 1);
					}
					setSelection(text, move);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Move the cursor to the buffer offset physically below the current
		/// offset, or return false if the cursor is already on the bottom line.
		/// </summary>
		/// <remarks>
		/// Move the cursor to the buffer offset physically below the current
		/// offset, or return false if the cursor is already on the bottom line.
		/// </remarks>
		public static bool moveDown(android.text.Spannable text, android.text.Layout layout
			)
		{
			int start = getSelectionStart(text);
			int end = getSelectionEnd(text);
			if (start != end)
			{
				int min = System.Math.Min(start, end);
				int max = System.Math.Max(start, end);
				setSelection(text, max);
				if (min == 0 && max == text.Length)
				{
					return false;
				}
				return true;
			}
			else
			{
				int line = layout.getLineForOffset(end);
				if (line < layout.getLineCount() - 1)
				{
					int move;
					if (layout.getParagraphDirection(line) == layout.getParagraphDirection(line + 1))
					{
						float h = layout.getPrimaryHorizontal(end);
						move = layout.getOffsetForHorizontal(line + 1, h);
					}
					else
					{
						move = layout.getLineStart(line + 1);
					}
					setSelection(text, move);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Move the cursor to the buffer offset physically to the left of
		/// the current offset, or return false if the cursor is already
		/// at the left edge of the line and there is not another line to move it to.
		/// </summary>
		/// <remarks>
		/// Move the cursor to the buffer offset physically to the left of
		/// the current offset, or return false if the cursor is already
		/// at the left edge of the line and there is not another line to move it to.
		/// </remarks>
		public static bool moveLeft(android.text.Spannable text, android.text.Layout layout
			)
		{
			int start = getSelectionStart(text);
			int end = getSelectionEnd(text);
			if (start != end)
			{
				setSelection(text, chooseHorizontal(layout, -1, start, end));
				return true;
			}
			else
			{
				int to = layout.getOffsetToLeftOf(end);
				if (to != end)
				{
					setSelection(text, to);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Move the cursor to the buffer offset physically to the right of
		/// the current offset, or return false if the cursor is already at
		/// at the right edge of the line and there is not another line
		/// to move it to.
		/// </summary>
		/// <remarks>
		/// Move the cursor to the buffer offset physically to the right of
		/// the current offset, or return false if the cursor is already at
		/// at the right edge of the line and there is not another line
		/// to move it to.
		/// </remarks>
		public static bool moveRight(android.text.Spannable text, android.text.Layout layout
			)
		{
			int start = getSelectionStart(text);
			int end = getSelectionEnd(text);
			if (start != end)
			{
				setSelection(text, chooseHorizontal(layout, 1, start, end));
				return true;
			}
			else
			{
				int to = layout.getOffsetToRightOf(end);
				if (to != end)
				{
					setSelection(text, to);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Move the selection end to the buffer offset physically above
		/// the current selection end.
		/// </summary>
		/// <remarks>
		/// Move the selection end to the buffer offset physically above
		/// the current selection end.
		/// </remarks>
		public static bool extendUp(android.text.Spannable text, android.text.Layout layout
			)
		{
			int end = getSelectionEnd(text);
			int line = layout.getLineForOffset(end);
			if (line > 0)
			{
				int move;
				if (layout.getParagraphDirection(line) == layout.getParagraphDirection(line - 1))
				{
					float h = layout.getPrimaryHorizontal(end);
					move = layout.getOffsetForHorizontal(line - 1, h);
				}
				else
				{
					move = layout.getLineStart(line - 1);
				}
				extendSelection(text, move);
				return true;
			}
			else
			{
				if (end != 0)
				{
					extendSelection(text, 0);
					return true;
				}
			}
			return true;
		}

		/// <summary>
		/// Move the selection end to the buffer offset physically below
		/// the current selection end.
		/// </summary>
		/// <remarks>
		/// Move the selection end to the buffer offset physically below
		/// the current selection end.
		/// </remarks>
		public static bool extendDown(android.text.Spannable text, android.text.Layout layout
			)
		{
			int end = getSelectionEnd(text);
			int line = layout.getLineForOffset(end);
			if (line < layout.getLineCount() - 1)
			{
				int move;
				if (layout.getParagraphDirection(line) == layout.getParagraphDirection(line + 1))
				{
					float h = layout.getPrimaryHorizontal(end);
					move = layout.getOffsetForHorizontal(line + 1, h);
				}
				else
				{
					move = layout.getLineStart(line + 1);
				}
				extendSelection(text, move);
				return true;
			}
			else
			{
				if (end != text.Length)
				{
					extendSelection(text, text.Length);
					return true;
				}
			}
			return true;
		}

		/// <summary>
		/// Move the selection end to the buffer offset physically to the left of
		/// the current selection end.
		/// </summary>
		/// <remarks>
		/// Move the selection end to the buffer offset physically to the left of
		/// the current selection end.
		/// </remarks>
		public static bool extendLeft(android.text.Spannable text, android.text.Layout layout
			)
		{
			int end = getSelectionEnd(text);
			int to = layout.getOffsetToLeftOf(end);
			if (to != end)
			{
				extendSelection(text, to);
				return true;
			}
			return true;
		}

		/// <summary>
		/// Move the selection end to the buffer offset physically to the right of
		/// the current selection end.
		/// </summary>
		/// <remarks>
		/// Move the selection end to the buffer offset physically to the right of
		/// the current selection end.
		/// </remarks>
		public static bool extendRight(android.text.Spannable text, android.text.Layout layout
			)
		{
			int end = getSelectionEnd(text);
			int to = layout.getOffsetToRightOf(end);
			if (to != end)
			{
				extendSelection(text, to);
				return true;
			}
			return true;
		}

		public static bool extendToLeftEdge(android.text.Spannable text, android.text.Layout
			 layout)
		{
			int where = findEdge(text, layout, -1);
			extendSelection(text, where);
			return true;
		}

		public static bool extendToRightEdge(android.text.Spannable text, android.text.Layout
			 layout)
		{
			int where = findEdge(text, layout, 1);
			extendSelection(text, where);
			return true;
		}

		public static bool moveToLeftEdge(android.text.Spannable text, android.text.Layout
			 layout)
		{
			int where = findEdge(text, layout, -1);
			setSelection(text, where);
			return true;
		}

		public static bool moveToRightEdge(android.text.Spannable text, android.text.Layout
			 layout)
		{
			int where = findEdge(text, layout, 1);
			setSelection(text, where);
			return true;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public interface PositionIterator
		{
			int preceding(int position);

			int following(int position);
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public static class PositionIteratorClass
		{
			public const int DONE = java.text.BreakIterator.DONE;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public static bool moveToPreceding(android.text.Spannable text, android.text.Selection
			.PositionIterator iter, bool extendSelection_1)
		{
			int offset = iter.preceding(getSelectionEnd(text));
			if (offset != android.text.Selection.PositionIteratorClass.DONE)
			{
				if (extendSelection_1)
				{
					extendSelection(text, offset);
				}
				else
				{
					setSelection(text, offset);
				}
			}
			return true;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		public static bool moveToFollowing(android.text.Spannable text, android.text.Selection
			.PositionIterator iter, bool extendSelection_1)
		{
			int offset = iter.following(getSelectionEnd(text));
			if (offset != android.text.Selection.PositionIteratorClass.DONE)
			{
				if (extendSelection_1)
				{
					extendSelection(text, offset);
				}
				else
				{
					setSelection(text, offset);
				}
			}
			return true;
		}

		private static int findEdge(android.text.Spannable text, android.text.Layout layout
			, int dir)
		{
			int pt = getSelectionEnd(text);
			int line = layout.getLineForOffset(pt);
			int pdir = layout.getParagraphDirection(line);
			if (dir * pdir < 0)
			{
				return layout.getLineStart(line);
			}
			else
			{
				int end = layout.getLineEnd(line);
				if (line == layout.getLineCount() - 1)
				{
					return end;
				}
				else
				{
					return end - 1;
				}
			}
		}

		private static int chooseHorizontal(android.text.Layout layout, int direction, int
			 off1, int off2)
		{
			int line1 = layout.getLineForOffset(off1);
			int line2 = layout.getLineForOffset(off2);
			if (line1 == line2)
			{
				// same line, so it goes by pure physical direction
				float h1 = layout.getPrimaryHorizontal(off1);
				float h2 = layout.getPrimaryHorizontal(off2);
				if (direction < 0)
				{
					// to left
					if (h1 < h2)
					{
						return off1;
					}
					else
					{
						return off2;
					}
				}
				else
				{
					// to right
					if (h1 > h2)
					{
						return off1;
					}
					else
					{
						return off2;
					}
				}
			}
			else
			{
				// different line, so which line is "left" and which is "right"
				// depends upon the directionality of the text
				// This only checks at one end, but it's not clear what the
				// right thing to do is if the ends don't agree.  Even if it
				// is wrong it should still not be too bad.
				int line = layout.getLineForOffset(off1);
				int textdir = layout.getParagraphDirection(line);
				if (textdir == direction)
				{
					return System.Math.Max(off1, off2);
				}
				else
				{
					return System.Math.Min(off1, off2);
				}
			}
		}

		private sealed class START : android.text.NoCopySpan
		{
		}

		private sealed class END : android.text.NoCopySpan
		{
		}

		public static readonly object SELECTION_START = new android.text.Selection.START(
			);

		public static readonly object SELECTION_END = new android.text.Selection.END();
	}
}
