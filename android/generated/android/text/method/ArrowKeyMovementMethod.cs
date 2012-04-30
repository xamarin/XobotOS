using Sharpen;

namespace android.text.method
{
	/// <summary>A movement method that provides cursor movement and selection.</summary>
	/// <remarks>
	/// A movement method that provides cursor movement and selection.
	/// Supports displaying the context menu on DPad Center.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ArrowKeyMovementMethod : android.text.method.BaseMovementMethod, android.text.method.MovementMethod
	{
		private static bool isSelecting(android.text.Spannable buffer)
		{
			return ((android.text.method.MetaKeyKeyListener.getMetaState(buffer, android.text.method.MetaKeyKeyListener
				.META_SHIFT_ON) == 1) || (android.text.method.MetaKeyKeyListener.getMetaState(buffer
				, android.text.method.MetaKeyKeyListener.META_SELECTING) != 0));
		}

		private static int getCurrentLineTop(android.text.Spannable buffer, android.text.Layout
			 layout)
		{
			return layout.getLineTop(layout.getLineForOffset(android.text.Selection.getSelectionEnd
				(buffer)));
		}

		private static int getPageHeight(android.widget.TextView widget)
		{
			// This calculation does not take into account the view transformations that
			// may have been applied to the child or its containers.  In case of scaling or
			// rotation, the calculated page height may be incorrect.
			android.graphics.Rect rect = new android.graphics.Rect();
			return widget.getGlobalVisibleRect(rect) ? rect.height() : 0;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool handleMovementKey(android.widget.TextView widget
			, android.text.Spannable buffer, int keyCode, int movementMetaState, android.view.KeyEvent
			 @event)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				{
					if (android.view.KeyEvent.metaStateHasNoModifiers(movementMetaState))
					{
						if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
							() == 0 && android.text.method.MetaKeyKeyListener.getMetaState(buffer, android.text.method.MetaKeyKeyListener
							.META_SELECTING) != 0)
						{
							return widget.showContextMenu();
						}
					}
					break;
				}
			}
			return base.handleMovementKey(widget, buffer, keyCode, movementMetaState, @event);
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool left(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendLeft(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveLeft(buffer, layout);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool right(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendRight(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveRight(buffer, layout);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool up(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendUp(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveUp(buffer, layout);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool down(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendDown(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveDown(buffer, layout);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool pageUp(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			bool selecting = isSelecting(buffer);
			int targetY = getCurrentLineTop(buffer, layout) - getPageHeight(widget);
			bool handled = false;
			for (; ; )
			{
				int previousSelectionEnd = android.text.Selection.getSelectionEnd(buffer);
				if (selecting)
				{
					android.text.Selection.extendUp(buffer, layout);
				}
				else
				{
					android.text.Selection.moveUp(buffer, layout);
				}
				if (android.text.Selection.getSelectionEnd(buffer) == previousSelectionEnd)
				{
					break;
				}
				handled = true;
				if (getCurrentLineTop(buffer, layout) <= targetY)
				{
					break;
				}
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool pageDown(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			bool selecting = isSelecting(buffer);
			int targetY = getCurrentLineTop(buffer, layout) + getPageHeight(widget);
			bool handled = false;
			for (; ; )
			{
				int previousSelectionEnd = android.text.Selection.getSelectionEnd(buffer);
				if (selecting)
				{
					android.text.Selection.extendDown(buffer, layout);
				}
				else
				{
					android.text.Selection.moveDown(buffer, layout);
				}
				if (android.text.Selection.getSelectionEnd(buffer) == previousSelectionEnd)
				{
					break;
				}
				handled = true;
				if (getCurrentLineTop(buffer, layout) >= targetY)
				{
					break;
				}
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool top(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			if (isSelecting(buffer))
			{
				android.text.Selection.extendSelection(buffer, 0);
			}
			else
			{
				android.text.Selection.setSelection(buffer, 0);
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool bottom(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			if (isSelecting(buffer))
			{
				android.text.Selection.extendSelection(buffer, buffer.Length);
			}
			else
			{
				android.text.Selection.setSelection(buffer, buffer.Length);
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool lineStart(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendToLeftEdge(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveToLeftEdge(buffer, layout);
			}
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool lineEnd(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			android.text.Layout layout = widget.getLayout();
			if (isSelecting(buffer))
			{
				return android.text.Selection.extendToRightEdge(buffer, layout);
			}
			else
			{
				return android.text.Selection.moveToRightEdge(buffer, layout);
			}
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool leftWord(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			int selectionEnd = widget.getSelectionEnd();
			mWordIterator.setCharSequence(buffer, selectionEnd, selectionEnd);
			return android.text.Selection.moveToPreceding(buffer, mWordIterator, isSelecting(
				buffer));
		}

		/// <summary>
		/// <hide></hide>
		/// 
		/// </summary>
		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool rightWord(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			int selectionEnd = widget.getSelectionEnd();
			mWordIterator.setCharSequence(buffer, selectionEnd, selectionEnd);
			return android.text.Selection.moveToFollowing(buffer, mWordIterator, isSelecting(
				buffer));
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool home(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return lineStart(widget, buffer);
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		protected internal override bool end(android.widget.TextView widget, android.text.Spannable
			 buffer)
		{
			return lineEnd(widget, buffer);
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override bool onTouchEvent(android.widget.TextView widget, android.text.Spannable
			 buffer, android.view.MotionEvent @event)
		{
			int initialScrollX = -1;
			int initialScrollY = -1;
			int action = @event.getAction();
			if (action == android.view.MotionEvent.ACTION_UP)
			{
				initialScrollX = android.text.method.Touch.getInitialScrollX(widget, buffer);
				initialScrollY = android.text.method.Touch.getInitialScrollY(widget, buffer);
			}
			bool handled = android.text.method.Touch.onTouchEvent(widget, buffer, @event);
			if (widget.isFocused() && !widget.didTouchFocusSelect())
			{
				if (action == android.view.MotionEvent.ACTION_DOWN)
				{
					if (isSelecting(buffer))
					{
						int offset = widget.getOffsetForPosition(@event.getX(), @event.getY());
						buffer.setSpan(LAST_TAP_DOWN, offset, offset, android.text.SpannedClass.SPAN_POINT_POINT
							);
						// Disallow intercepting of the touch events, so that
						// users can scroll and select at the same time.
						// without this, users would get booted out of select
						// mode once the view detected it needed to scroll.
						widget.getParent().requestDisallowInterceptTouchEvent(true);
					}
				}
				else
				{
					if (action == android.view.MotionEvent.ACTION_MOVE)
					{
						if (isSelecting(buffer) && handled)
						{
							// Before selecting, make sure we've moved out of the "slop".
							// handled will be true, if we're in select mode AND we're
							// OUT of the slop
							// Turn long press off while we're selecting. User needs to
							// re-tap on the selection to enable long press
							widget.cancelLongPress();
							// Update selection as we're moving the selection area.
							// Get the current touch position
							int offset = widget.getOffsetForPosition(@event.getX(), @event.getY());
							android.text.Selection.extendSelection(buffer, offset);
							return true;
						}
					}
					else
					{
						if (action == android.view.MotionEvent.ACTION_UP)
						{
							// If we have scrolled, then the up shouldn't move the cursor,
							// but we do need to make sure the cursor is still visible at
							// the current scroll offset to avoid the scroll jumping later
							// to show it.
							if ((initialScrollY >= 0 && initialScrollY != widget.getScrollY()) || (initialScrollX
								 >= 0 && initialScrollX != widget.getScrollX()))
							{
								widget.moveCursorToVisibleOffset();
								return true;
							}
							int offset = widget.getOffsetForPosition(@event.getX(), @event.getY());
							if (isSelecting(buffer))
							{
								buffer.removeSpan(LAST_TAP_DOWN);
								android.text.Selection.extendSelection(buffer, offset);
							}
							else
							{
								if (!widget.shouldIgnoreActionUpEvent())
								{
									android.text.Selection.setSelection(buffer, offset);
								}
							}
							android.text.method.MetaKeyKeyListener.adjustMetaAfterKeypress(buffer);
							android.text.method.MetaKeyKeyListener.resetLockedMeta(buffer);
							return true;
						}
					}
				}
			}
			return handled;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override bool canSelectArbitrarily()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override void initialize(android.widget.TextView widget, android.text.Spannable
			 text)
		{
			android.text.Selection.setSelection(text, 0);
		}

		[Sharpen.OverridesMethod(@"android.text.method.BaseMovementMethod")]
		public override void onTakeFocus(android.widget.TextView view, android.text.Spannable
			 text, int dir)
		{
			if ((dir & (android.view.View.FOCUS_FORWARD | android.view.View.FOCUS_DOWN)) != 0)
			{
				if (view.getLayout() == null)
				{
					// This shouldn't be null, but do something sensible if it is.
					android.text.Selection.setSelection(text, text.Length);
				}
			}
			else
			{
				android.text.Selection.setSelection(text, text.Length);
			}
		}

		public static android.text.method.MovementMethod getInstance()
		{
			if (sInstance == null)
			{
				sInstance = new android.text.method.ArrowKeyMovementMethod();
			}
			return sInstance;
		}

		private android.text.method.WordIterator mWordIterator = new android.text.method.WordIterator
			();

		private static readonly object LAST_TAP_DOWN = new object();

		private static android.text.method.ArrowKeyMovementMethod sInstance;
	}
}
