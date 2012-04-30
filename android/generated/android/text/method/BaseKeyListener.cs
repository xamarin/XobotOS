using Sharpen;

namespace android.text.method
{
	/// <summary>Abstract base class for key listeners.</summary>
	/// <remarks>
	/// Abstract base class for key listeners.
	/// Provides a basic foundation for entering and editing text.
	/// Subclasses should override
	/// <see cref="onKeyDown(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	">onKeyDown(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	</see>
	/// and
	/// <see cref="MetaKeyKeyListener.onKeyUp(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	">MetaKeyKeyListener.onKeyUp(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	</see>
	/// to insert
	/// characters as keys are pressed.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class BaseKeyListener : android.text.method.MetaKeyKeyListener, android.text.method.KeyListener
	{
		internal static readonly object OLD_SEL_START = new android.text.NoCopySpanClass.
			Concrete();

		/// <summary>
		/// Performs the action that happens when you press the
		/// <see cref="android.view.KeyEvent.KEYCODE_DEL">android.view.KeyEvent.KEYCODE_DEL</see>
		/// key in
		/// a
		/// <see cref="android.widget.TextView">android.widget.TextView</see>
		/// .  If there is a selection, deletes the selection; otherwise,
		/// deletes the character before the cursor, if any; ALT+DEL deletes everything on
		/// the line the cursor is on.
		/// </summary>
		/// <returns>true if anything was deleted; false otherwise.</returns>
		public virtual bool backspace(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			return backspaceOrForwardDelete(view, content, keyCode, @event, false);
		}

		/// <summary>
		/// Performs the action that happens when you press the
		/// <see cref="android.view.KeyEvent.KEYCODE_FORWARD_DEL">android.view.KeyEvent.KEYCODE_FORWARD_DEL
		/// 	</see>
		/// key in a
		/// <see cref="android.widget.TextView">android.widget.TextView</see>
		/// .  If there is a selection, deletes the selection; otherwise,
		/// deletes the character before the cursor, if any; ALT+FORWARD_DEL deletes everything on
		/// the line the cursor is on.
		/// </summary>
		/// <returns>true if anything was deleted; false otherwise.</returns>
		public virtual bool forwardDelete(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			return backspaceOrForwardDelete(view, content, keyCode, @event, true);
		}

		private bool backspaceOrForwardDelete(android.view.View view, android.text.Editable
			 content, int keyCode, android.view.KeyEvent @event, bool isForwardDelete)
		{
			// Ensure the key event does not have modifiers except ALT or SHIFT.
			if (!android.view.KeyEvent.metaStateHasNoModifiers(@event.getMetaState() & ~(android.view.KeyEvent
				.META_SHIFT_MASK | android.view.KeyEvent.META_ALT_MASK)))
			{
				return false;
			}
			// If there is a current selection, delete it.
			if (deleteSelection(view, content))
			{
				return true;
			}
			// Alt+Backspace or Alt+ForwardDelete deletes the current line, if possible.
			if (@event.isAltPressed() || getMetaState(content, META_ALT_ON) == 1)
			{
				if (deleteLine(view, content))
				{
					return true;
				}
			}
			// Delete a character.
			int start = android.text.Selection.getSelectionEnd(content);
			int end;
			if (isForwardDelete || @event.isShiftPressed() || getMetaState(content, META_SHIFT_ON
				) == 1)
			{
				end = android.text.TextUtils.getOffsetAfter(content, start);
			}
			else
			{
				end = android.text.TextUtils.getOffsetBefore(content, start);
			}
			if (start != end)
			{
				content.delete(System.Math.Min(start, end), System.Math.Max(start, end));
				return true;
			}
			return false;
		}

		private bool deleteSelection(android.view.View view, android.text.Editable content
			)
		{
			int selectionStart = android.text.Selection.getSelectionStart(content);
			int selectionEnd = android.text.Selection.getSelectionEnd(content);
			if (selectionEnd < selectionStart)
			{
				int temp = selectionEnd;
				selectionEnd = selectionStart;
				selectionStart = temp;
			}
			if (selectionStart != selectionEnd)
			{
				content.delete(selectionStart, selectionEnd);
				return true;
			}
			return false;
		}

		private bool deleteLine(android.view.View view, android.text.Editable content)
		{
			if (view is android.widget.TextView)
			{
				android.text.Layout layout = ((android.widget.TextView)view).getLayout();
				if (layout != null)
				{
					int line = layout.getLineForOffset(android.text.Selection.getSelectionStart(content
						));
					int start = layout.getLineStart(line);
					int end = layout.getLineEnd(line);
					if (end != start)
					{
						content.delete(start, end);
						return true;
					}
				}
			}
			return false;
		}

		internal static int makeTextContentType(android.text.method.TextKeyListener.Capitalize
			 caps, bool autoText)
		{
			int contentType = android.text.InputTypeClass.TYPE_CLASS_TEXT;
			switch (caps)
			{
				case android.text.method.TextKeyListener.Capitalize.CHARACTERS:
				{
					contentType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_CHARACTERS;
					break;
				}

				case android.text.method.TextKeyListener.Capitalize.WORDS:
				{
					contentType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_WORDS;
					break;
				}

				case android.text.method.TextKeyListener.Capitalize.SENTENCES:
				{
					contentType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_CAP_SENTENCES;
					break;
				}
			}
			if (autoText)
			{
				contentType |= android.text.InputTypeClass.TYPE_TEXT_FLAG_AUTO_CORRECT;
			}
			return contentType;
		}

		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			bool handled;
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DEL:
				{
					handled = backspace(view, content, keyCode, @event);
					break;
				}

				case android.view.KeyEvent.KEYCODE_FORWARD_DEL:
				{
					handled = forwardDelete(view, content, keyCode, @event);
					break;
				}

				default:
				{
					handled = false;
					break;
				}
			}
			if (handled)
			{
				adjustMetaAfterKeypress(content);
			}
			return base.onKeyDown(view, content, keyCode, @event);
		}

		/// <summary>
		/// Base implementation handles ACTION_MULTIPLE KEYCODE_UNKNOWN by inserting
		/// the event's text into the content.
		/// </summary>
		/// <remarks>
		/// Base implementation handles ACTION_MULTIPLE KEYCODE_UNKNOWN by inserting
		/// the event's text into the content.
		/// </remarks>
		[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
		public virtual bool onKeyOther(android.view.View view, android.text.Editable content
			, android.view.KeyEvent @event)
		{
			if (@event.getAction() != android.view.KeyEvent.ACTION_MULTIPLE || @event.getKeyCode
				() != android.view.KeyEvent.KEYCODE_UNKNOWN)
			{
				// Not something we are interested in.
				return false;
			}
			int selectionStart = android.text.Selection.getSelectionStart(content);
			int selectionEnd = android.text.Selection.getSelectionEnd(content);
			if (selectionEnd < selectionStart)
			{
				int temp = selectionEnd;
				selectionEnd = selectionStart;
				selectionStart = temp;
			}
			java.lang.CharSequence text = java.lang.CharSequenceProxy.Wrap(@event.getCharacters
				());
			if (text == null)
			{
				return false;
			}
			content.replace(selectionStart, selectionEnd, text);
			return true;
		}

		public abstract int getInputType();
	}
}
