using Sharpen;

namespace android.text.method
{
	/// <summary>Base classes for movement methods.</summary>
	/// <remarks>Base classes for movement methods.</remarks>
	[Sharpen.Sharpened]
	public class BaseMovementMethod : android.text.method.MovementMethod
	{
		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool canSelectArbitrarily()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual void initialize(android.widget.TextView widget, android.text.Spannable
			 text)
		{
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onKeyDown(android.widget.TextView widget, android.text.Spannable
			 text, int keyCode, android.view.KeyEvent @event)
		{
			int movementMetaState = getMovementMetaState(text, @event);
			bool handled = handleMovementKey(widget, text, keyCode, movementMetaState, @event
				);
			if (handled)
			{
				android.text.method.MetaKeyKeyListener.adjustMetaAfterKeypress(text);
				android.text.method.MetaKeyKeyListener.resetLockedMeta(text);
			}
			return handled;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onKeyOther(android.widget.TextView widget, android.text.Spannable
			 text, android.view.KeyEvent @event)
		{
			int movementMetaState = getMovementMetaState(text, @event);
			int keyCode = @event.getKeyCode();
			if (keyCode != android.view.KeyEvent.KEYCODE_UNKNOWN && @event.getAction() == android.view.KeyEvent
				.ACTION_MULTIPLE)
			{
				int repeat = @event.getRepeatCount();
				bool handled = false;
				{
					for (int i = 0; i < repeat; i++)
					{
						if (!handleMovementKey(widget, text, keyCode, movementMetaState, @event))
						{
							break;
						}
						handled = true;
					}
				}
				if (handled)
				{
					android.text.method.MetaKeyKeyListener.adjustMetaAfterKeypress(text);
					android.text.method.MetaKeyKeyListener.resetLockedMeta(text);
				}
				return handled;
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onKeyUp(android.widget.TextView widget, android.text.Spannable
			 text, int keyCode, android.view.KeyEvent @event)
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual void onTakeFocus(android.widget.TextView widget, android.text.Spannable
			 text, int direction)
		{
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onTouchEvent(android.widget.TextView widget, android.text.Spannable
			 text, android.view.MotionEvent @event)
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onTrackballEvent(android.widget.TextView widget, android.text.Spannable
			 text, android.view.MotionEvent @event)
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.MovementMethod")]
		public virtual bool onGenericMotionEvent(android.widget.TextView widget, android.text.Spannable
			 text, android.view.MotionEvent @event)
		{
			if ((@event.getSource() & android.view.InputDevice.SOURCE_CLASS_POINTER) != 0)
			{
				switch (@event.getAction())
				{
					case android.view.MotionEvent.ACTION_SCROLL:
					{
						float vscroll;
						float hscroll;
						if ((@event.getMetaState() & android.view.KeyEvent.META_SHIFT_ON) != 0)
						{
							vscroll = 0;
							hscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
						}
						else
						{
							vscroll = -@event.getAxisValue(android.view.MotionEvent.AXIS_VSCROLL);
							hscroll = @event.getAxisValue(android.view.MotionEvent.AXIS_HSCROLL);
						}
						bool handled = false;
						if (hscroll < 0)
						{
							handled |= scrollLeft(widget, text, (int)System.Math.Ceiling(-hscroll));
						}
						else
						{
							if (hscroll > 0)
							{
								handled |= scrollRight(widget, text, (int)System.Math.Ceiling(hscroll));
							}
						}
						if (vscroll < 0)
						{
							handled |= scrollUp(widget, text, (int)System.Math.Ceiling(-vscroll));
						}
						else
						{
							if (vscroll > 0)
							{
								handled |= scrollDown(widget, text, (int)System.Math.Ceiling(vscroll));
							}
						}
						return handled;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Gets the meta state used for movement using the modifiers tracked by the text
		/// buffer as well as those present in the key event.
		/// </summary>
		/// <remarks>
		/// Gets the meta state used for movement using the modifiers tracked by the text
		/// buffer as well as those present in the key event.
		/// The movement meta state excludes the state of locked modifiers or the SHIFT key
		/// since they are not used by movement actions (but they may be used for selection).
		/// </remarks>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="event">The key event.</param>
		/// <returns>The keyboard meta states used for movement.</returns>
		protected internal virtual int getMovementMetaState(android.text.Spannable buffer
			, android.view.KeyEvent @event)
		{
			// We ignore locked modifiers and SHIFT.
			int metaState = (@event.getMetaState() | android.text.method.MetaKeyKeyListener.getMetaState
				(buffer)) & ~(android.text.method.MetaKeyKeyListener.META_ALT_LOCKED | android.text.method.MetaKeyKeyListener
				.META_SYM_LOCKED);
			return android.view.KeyEvent.normalizeMetaState(metaState) & ~android.view.KeyEvent
				.META_SHIFT_MASK;
		}

		/// <summary>Performs a movement key action.</summary>
		/// <remarks>
		/// Performs a movement key action.
		/// The default implementation decodes the key down and invokes movement actions
		/// such as
		/// <see cref="down(android.widget.TextView, android.text.Spannable)">down(android.widget.TextView, android.text.Spannable)
		/// 	</see>
		/// and
		/// <see cref="up(android.widget.TextView, android.text.Spannable)">up(android.widget.TextView, android.text.Spannable)
		/// 	</see>
		/// .
		/// <see cref="onKeyDown(android.widget.TextView, android.text.Spannable, int, android.view.KeyEvent)
		/// 	">onKeyDown(android.widget.TextView, android.text.Spannable, int, android.view.KeyEvent)
		/// 	</see>
		/// calls this method once
		/// to handle an
		/// <see cref="android.view.KeyEvent.ACTION_DOWN">android.view.KeyEvent.ACTION_DOWN</see>
		/// .
		/// <see cref="onKeyOther(android.widget.TextView, android.text.Spannable, android.view.KeyEvent)
		/// 	">onKeyOther(android.widget.TextView, android.text.Spannable, android.view.KeyEvent)
		/// 	</see>
		/// calls this method repeatedly
		/// to handle each repetition of an
		/// <see cref="android.view.KeyEvent.ACTION_MULTIPLE">android.view.KeyEvent.ACTION_MULTIPLE
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="event">The key event.</param>
		/// <param name="keyCode">The key code.</param>
		/// <param name="movementMetaState">The keyboard meta states used for movement.</param>
		/// <param name="event">The key event.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool handleMovementKey(android.widget.TextView widget, 
			android.text.Spannable buffer, int keyCode, int movementMetaState, android.view.KeyEvent
			 @event)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return left(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_CTRL_ON))
						{
							return leftWord(widget, buffer);
						}
						else
						{
							if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
								.META_ALT_ON))
							{
								return lineStart(widget, buffer);
							}
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return right(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_CTRL_ON))
						{
							return rightWord(widget, buffer);
						}
						else
						{
							if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
								.META_ALT_ON))
							{
								return lineEnd(widget, buffer);
							}
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_UP:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return up(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_ALT_ON))
						{
							return top(widget, buffer);
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return down(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_ALT_ON))
						{
							return bottom(widget, buffer);
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_PAGE_UP:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return pageUp(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_ALT_ON))
						{
							return top(widget, buffer);
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_PAGE_DOWN:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return pageDown(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_ALT_ON))
						{
							return bottom(widget, buffer);
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_MOVE_HOME:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return home(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_CTRL_ON))
						{
							return top(widget, buffer);
						}
					}
					break;
				}

				case android.view.KeyEvent.KEYCODE_MOVE_END:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						return end(widget, buffer);
					}
					else
					{
						if (android.view.KeyEvent.metaStateHasModifiers(movementMetaState, android.view.KeyEvent
							.META_CTRL_ON))
						{
							return bottom(widget, buffer);
						}
					}
					break;
				}
			}
			return false;
		}

		/// <summary>Performs a left movement action.</summary>
		/// <remarks>
		/// Performs a left movement action.
		/// Moves the cursor or scrolls left by one character.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool left(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a right movement action.</summary>
		/// <remarks>
		/// Performs a right movement action.
		/// Moves the cursor or scrolls right by one character.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool right(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs an up movement action.</summary>
		/// <remarks>
		/// Performs an up movement action.
		/// Moves the cursor or scrolls up by one line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool up(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a down movement action.</summary>
		/// <remarks>
		/// Performs a down movement action.
		/// Moves the cursor or scrolls down by one line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool down(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a page-up movement action.</summary>
		/// <remarks>
		/// Performs a page-up movement action.
		/// Moves the cursor or scrolls up by one page.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool pageUp(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a page-down movement action.</summary>
		/// <remarks>
		/// Performs a page-down movement action.
		/// Moves the cursor or scrolls down by one page.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool pageDown(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a top movement action.</summary>
		/// <remarks>
		/// Performs a top movement action.
		/// Moves the cursor or scrolls to the top of the buffer.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool top(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a bottom movement action.</summary>
		/// <remarks>
		/// Performs a bottom movement action.
		/// Moves the cursor or scrolls to the bottom of the buffer.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool bottom(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a line-start movement action.</summary>
		/// <remarks>
		/// Performs a line-start movement action.
		/// Moves the cursor or scrolls to the start of the line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool lineStart(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs an line-end movement action.</summary>
		/// <remarks>
		/// Performs an line-end movement action.
		/// Moves the cursor or scrolls to the end of the line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool lineEnd(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		protected internal virtual bool leftWord(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		protected internal virtual bool rightWord(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs a home movement action.</summary>
		/// <remarks>
		/// Performs a home movement action.
		/// Moves the cursor or scrolls to the start of the line or to the top of the
		/// document depending on whether the insertion point is being moved or
		/// the document is being scrolled.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool home(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		/// <summary>Performs an end movement action.</summary>
		/// <remarks>
		/// Performs an end movement action.
		/// Moves the cursor or scrolls to the start of the line or to the top of the
		/// document depending on whether the insertion point is being moved or
		/// the document is being scrolled.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		protected internal virtual bool end(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return false;
		}

		private int getTopLine(android.widget.TextView widget)
		{
			return widget.getLayout().getLineForVertical(widget.getScrollY());
		}

		private int getBottomLine(android.widget.TextView widget)
		{
			return widget.getLayout().getLineForVertical(widget.getScrollY() + getInnerHeight
				(widget));
		}

		private int getInnerWidth(android.widget.TextView widget)
		{
			return widget.getWidth() - widget.getTotalPaddingLeft() - widget.getTotalPaddingRight
				();
		}

		private int getInnerHeight(android.widget.TextView widget)
		{
			return widget.getHeight() - widget.getTotalPaddingTop() - widget.getTotalPaddingBottom
				();
		}

		private int getCharacterWidth(android.widget.TextView widget)
		{
			return (int)System.Math.Ceiling(widget.getPaint().getFontSpacing());
		}

		private int getScrollBoundsLeft(android.widget.TextView widget)
		{
			android.text.Layout layout = widget.getLayout();
			int topLine = getTopLine(widget);
			int bottomLine = getBottomLine(widget);
			if (topLine > bottomLine)
			{
				return 0;
			}
			int left_1 = int.MaxValue;
			{
				for (int line = topLine; line <= bottomLine; line++)
				{
					int lineLeft = (int)Sharpen.Util.Floor(layout.getLineLeft(line));
					if (lineLeft < left_1)
					{
						left_1 = lineLeft;
					}
				}
			}
			return left_1;
		}

		private int getScrollBoundsRight(android.widget.TextView widget)
		{
			android.text.Layout layout = widget.getLayout();
			int topLine = getTopLine(widget);
			int bottomLine = getBottomLine(widget);
			if (topLine > bottomLine)
			{
				return 0;
			}
			int right_1 = int.MinValue;
			{
				for (int line = topLine; line <= bottomLine; line++)
				{
					int lineRight = (int)System.Math.Ceiling(layout.getLineRight(line));
					if (lineRight > right_1)
					{
						right_1 = lineRight;
					}
				}
			}
			return right_1;
		}

		/// <summary>Performs a scroll left action.</summary>
		/// <remarks>
		/// Performs a scroll left action.
		/// Scrolls left by the specified number of characters.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="amount">The number of characters to scroll by.  Must be at least 1.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollLeft(android.widget.TextView widget, android.text.Spannable
			 buffer, int amount)
		{
			int minScrollX = getScrollBoundsLeft(widget);
			int scrollX = widget.getScrollX();
			if (scrollX > minScrollX)
			{
				scrollX = System.Math.Max(scrollX - getCharacterWidth(widget) * amount, minScrollX
					);
				widget.scrollTo(scrollX, widget.getScrollY());
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll right action.</summary>
		/// <remarks>
		/// Performs a scroll right action.
		/// Scrolls right by the specified number of characters.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="amount">The number of characters to scroll by.  Must be at least 1.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollRight(android.widget.TextView widget, android.text.Spannable
			 buffer, int amount)
		{
			int maxScrollX = getScrollBoundsRight(widget) - getInnerWidth(widget);
			int scrollX = widget.getScrollX();
			if (scrollX < maxScrollX)
			{
				scrollX = System.Math.Min(scrollX + getCharacterWidth(widget) * amount, maxScrollX
					);
				widget.scrollTo(scrollX, widget.getScrollY());
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll up action.</summary>
		/// <remarks>
		/// Performs a scroll up action.
		/// Scrolls up by the specified number of lines.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="amount">The number of lines to scroll by.  Must be at least 1.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollUp(android.widget.TextView widget, android.text.Spannable
			 buffer, int amount)
		{
			android.text.Layout layout = widget.getLayout();
			int top_1 = widget.getScrollY();
			int topLine = layout.getLineForVertical(top_1);
			if (layout.getLineTop(topLine) == top_1)
			{
				// If the top line is partially visible, bring it all the way
				// into view; otherwise, bring the previous line into view.
				topLine -= 1;
			}
			if (topLine >= 0)
			{
				topLine = System.Math.Max(topLine - amount + 1, 0);
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(topLine));
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll down action.</summary>
		/// <remarks>
		/// Performs a scroll down action.
		/// Scrolls down by the specified number of lines.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <param name="amount">The number of lines to scroll by.  Must be at least 1.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollDown(android.widget.TextView widget, android.text.Spannable
			 buffer, int amount)
		{
			android.text.Layout layout = widget.getLayout();
			int innerHeight = getInnerHeight(widget);
			int bottom_1 = widget.getScrollY() + innerHeight;
			int bottomLine = layout.getLineForVertical(bottom_1);
			if (layout.getLineTop(bottomLine + 1) < bottom_1 + 1)
			{
				// Less than a pixel of this line is out of view,
				// so we must have tried to make it entirely in view
				// and now want the next line to be in view instead.
				bottomLine += 1;
			}
			int limit = layout.getLineCount() - 1;
			if (bottomLine <= limit)
			{
				bottomLine = System.Math.Min(bottomLine + amount - 1, limit);
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(bottomLine + 1) - innerHeight);
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll page up action.</summary>
		/// <remarks>
		/// Performs a scroll page up action.
		/// Scrolls up by one page.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollPageUp(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			int top_1 = widget.getScrollY() - getInnerHeight(widget);
			int topLine = layout.getLineForVertical(top_1);
			if (topLine >= 0)
			{
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(topLine));
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll page up action.</summary>
		/// <remarks>
		/// Performs a scroll page up action.
		/// Scrolls down by one page.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollPageDown(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			int innerHeight = getInnerHeight(widget);
			int bottom_1 = widget.getScrollY() + innerHeight + innerHeight;
			int bottomLine = layout.getLineForVertical(bottom_1);
			if (bottomLine <= layout.getLineCount() - 1)
			{
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(bottomLine + 1) - innerHeight);
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll to top action.</summary>
		/// <remarks>
		/// Performs a scroll to top action.
		/// Scrolls to the top of the document.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollTop(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (getTopLine(widget) >= 0)
			{
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(0));
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll to bottom action.</summary>
		/// <remarks>
		/// Performs a scroll to bottom action.
		/// Scrolls to the bottom of the document.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollBottom(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			int lineCount = layout.getLineCount();
			if (getBottomLine(widget) <= lineCount - 1)
			{
				android.text.method.Touch.scrollTo(widget, layout, widget.getScrollX(), layout.getLineTop
					(lineCount) - getInnerHeight(widget));
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll to line start action.</summary>
		/// <remarks>
		/// Performs a scroll to line start action.
		/// Scrolls to the start of the line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollLineStart(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			int minScrollX = getScrollBoundsLeft(widget);
			int scrollX = widget.getScrollX();
			if (scrollX > minScrollX)
			{
				widget.scrollTo(minScrollX, widget.getScrollY());
				return true;
			}
			return false;
		}

		/// <summary>Performs a scroll to line end action.</summary>
		/// <remarks>
		/// Performs a scroll to line end action.
		/// Scrolls to the end of the line.
		/// </remarks>
		/// <param name="widget">The text view.</param>
		/// <param name="buffer">The text buffer.</param>
		/// <returns>True if the event was handled.</returns>
		/// <hide></hide>
		protected internal virtual bool scrollLineEnd(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			int maxScrollX = getScrollBoundsRight(widget) - getInnerWidth(widget);
			int scrollX = widget.getScrollX();
			if (scrollX < maxScrollX)
			{
				widget.scrollTo(maxScrollX, widget.getScrollY());
				return true;
			}
			return false;
		}
	}
}
