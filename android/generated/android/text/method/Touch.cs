using Sharpen;

namespace android.text.method
{
	[Sharpen.Sharpened]
	public partial class Touch
	{
		private Touch()
		{
		}

		/// <summary>
		/// Scrolls the specified widget to the specified coordinates, except
		/// constrains the X scrolling position to the horizontal regions of
		/// the text that will be visible after scrolling to the specified
		/// Y position.
		/// </summary>
		/// <remarks>
		/// Scrolls the specified widget to the specified coordinates, except
		/// constrains the X scrolling position to the horizontal regions of
		/// the text that will be visible after scrolling to the specified
		/// Y position.
		/// </remarks>
		public static void scrollTo(android.widget.TextView widget, android.text.Layout layout
			, int x, int y)
		{
			int verticalPadding = widget.getTotalPaddingTop() + widget.getTotalPaddingBottom(
				);
			int top = layout.getLineForVertical(y);
			int bottom = layout.getLineForVertical(y + widget.getHeight() - verticalPadding);
			int left = int.MaxValue;
			int right = 0;
			android.text.Layout.Alignment? a = layout.getParagraphAlignment(top);
			bool ltr = layout.getParagraphDirection(top) > 0;
			{
				for (int i = top; i <= bottom; i++)
				{
					left = (int)System.Math.Min(left, layout.getLineLeft(i));
					right = (int)System.Math.Max(right, layout.getLineRight(i));
				}
			}
			int hoizontalPadding = widget.getTotalPaddingLeft() + widget.getTotalPaddingRight
				();
			int availableWidth = widget.getWidth() - hoizontalPadding;
			int actualWidth = right - left;
			if (actualWidth < availableWidth)
			{
				if (a == android.text.Layout.Alignment.ALIGN_CENTER)
				{
					x = left - ((availableWidth - actualWidth) / 2);
				}
				else
				{
					if ((ltr && (a == android.text.Layout.Alignment.ALIGN_OPPOSITE)) || (a == android.text.Layout.Alignment
						.ALIGN_RIGHT))
					{
						// align_opposite does NOT mean align_right, we need the paragraph
						// direction to resolve it to left or right
						x = left - (availableWidth - actualWidth);
					}
					else
					{
						x = left;
					}
				}
			}
			else
			{
				x = System.Math.Min(x, right - availableWidth);
				x = System.Math.Max(x, left);
			}
			widget.scrollTo(x, y);
		}

		// if we're selecting, we want the scroll to go in
		// the direction of the drag
		// If we actually scrolled, then cancel the up action.
		public static int getInitialScrollX(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.method.Touch.DragState[] ds = buffer.getSpans<android.text.method.Touch
				.DragState>(0, buffer.Length);
			return ds.Length > 0 ? ds[0].mScrollX : -1;
		}

		public static int getInitialScrollY(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.method.Touch.DragState[] ds = buffer.getSpans<android.text.method.Touch
				.DragState>(0, buffer.Length);
			return ds.Length > 0 ? ds[0].mScrollY : -1;
		}

		private class DragState : android.text.NoCopySpan
		{
			public float mX;

			public float mY;

			public int mScrollX;

			public int mScrollY;

			public bool mFarEnough;

			public bool mUsed;

			public DragState(float x, float y, int scrollX, int scrollY)
			{
				mX = x;
				mY = y;
				mScrollX = scrollX;
				mScrollY = scrollY;
			}
		}
	}
}
