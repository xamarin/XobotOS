using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// This base class encapsulates the behavior for tracking the state of
	/// meta keys such as SHIFT, ALT and SYM as well as the pseudo-meta state of selecting text.
	/// </summary>
	/// <remarks>
	/// This base class encapsulates the behavior for tracking the state of
	/// meta keys such as SHIFT, ALT and SYM as well as the pseudo-meta state of selecting text.
	/// <p>
	/// Key listeners that care about meta state should inherit from this class;
	/// you should not instantiate this class directly in a client.
	/// </p><p>
	/// This class provides two mechanisms for tracking meta state that can be used
	/// together or independently.
	/// </p>
	/// <ul>
	/// <li>Methods such as
	/// <see cref="handleKeyDown(long, int, android.view.KeyEvent)">handleKeyDown(long, int, android.view.KeyEvent)
	/// 	</see>
	/// and
	/// <see cref="getMetaState(long)">getMetaState(long)</see>
	/// operate on a meta key state bit mask.</li>
	/// <li>Methods such as
	/// <see cref="onKeyDown(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	">onKeyDown(android.view.View, android.text.Editable, int, android.view.KeyEvent)
	/// 	</see>
	/// and
	/// <see cref="getMetaState(java.lang.CharSequence, int)">getMetaState(java.lang.CharSequence, int)
	/// 	</see>
	/// operate on meta key state flags stored
	/// as spans in an
	/// <see cref="android.text.Editable">android.text.Editable</see>
	/// text buffer.  The spans only describe the current
	/// meta key state of the text editor; they do not carry any positional information.</li>
	/// </ul>
	/// <p>
	/// The behavior of this class varies according to the keyboard capabilities
	/// described by the
	/// <see cref="android.view.KeyCharacterMap">android.view.KeyCharacterMap</see>
	/// of the keyboard device such as
	/// the
	/// <see cref="android.view.KeyCharacterMap.getModifierBehavior()">key modifier behavior
	/// 	</see>
	/// .
	/// </p><p>
	/// <see cref="MetaKeyKeyListener">MetaKeyKeyListener</see>
	/// implements chorded and toggled key modifiers.
	/// When key modifiers are toggled into a latched or locked state, the state
	/// of the modifier is stored in the
	/// <see cref="android.text.Editable">android.text.Editable</see>
	/// text buffer or in a
	/// meta state integer managed by the client.  These latched or locked modifiers
	/// should be considered to be held <b>in addition to</b> those that the
	/// keyboard already reported as being pressed in
	/// <see cref="android.view.KeyEvent.getMetaState()">android.view.KeyEvent.getMetaState()
	/// 	</see>
	/// .
	/// In other words, the
	/// <see cref="MetaKeyKeyListener">MetaKeyKeyListener</see>
	/// augments the meta state
	/// provided by the keyboard; it does not replace it.  This distinction is important
	/// to ensure that meta keys not handled by
	/// <see cref="MetaKeyKeyListener">MetaKeyKeyListener</see>
	/// such as
	/// <see cref="android.view.KeyEvent.KEYCODE_CAPS_LOCK">android.view.KeyEvent.KEYCODE_CAPS_LOCK
	/// 	</see>
	/// or
	/// <see cref="android.view.KeyEvent.KEYCODE_NUM_LOCK">android.view.KeyEvent.KEYCODE_NUM_LOCK
	/// 	</see>
	/// are
	/// taken into consideration.
	/// </p><p>
	/// To ensure correct meta key behavior, the following pattern should be used
	/// when mapping key codes to characters:
	/// </p>
	/// <code>
	/// private char getUnicodeChar(TextKeyListener listener, KeyEvent event, Editable textBuffer) {
	/// // Use the combined meta states from the event and the key listener.
	/// int metaState = event.getMetaState() | listener.getMetaState(textBuffer);
	/// return event.getUnicodeChar(metaState);
	/// }
	/// </code>
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class MetaKeyKeyListener
	{
		/// <summary>Flag that indicates that the SHIFT key is on.</summary>
		/// <remarks>
		/// Flag that indicates that the SHIFT key is on.
		/// Value equals
		/// <see cref="android.view.KeyEvent.META_SHIFT_ON">android.view.KeyEvent.META_SHIFT_ON
		/// 	</see>
		/// .
		/// </remarks>
		public const int META_SHIFT_ON = android.view.KeyEvent.META_SHIFT_ON;

		/// <summary>Flag that indicates that the ALT key is on.</summary>
		/// <remarks>
		/// Flag that indicates that the ALT key is on.
		/// Value equals
		/// <see cref="android.view.KeyEvent.META_ALT_ON">android.view.KeyEvent.META_ALT_ON</see>
		/// .
		/// </remarks>
		public const int META_ALT_ON = android.view.KeyEvent.META_ALT_ON;

		/// <summary>Flag that indicates that the SYM key is on.</summary>
		/// <remarks>
		/// Flag that indicates that the SYM key is on.
		/// Value equals
		/// <see cref="android.view.KeyEvent.META_SYM_ON">android.view.KeyEvent.META_SYM_ON</see>
		/// .
		/// </remarks>
		public const int META_SYM_ON = android.view.KeyEvent.META_SYM_ON;

		/// <summary>Flag that indicates that the SHIFT key is locked in CAPS mode.</summary>
		/// <remarks>Flag that indicates that the SHIFT key is locked in CAPS mode.</remarks>
		public const int META_CAP_LOCKED = android.view.KeyEvent.META_CAP_LOCKED;

		/// <summary>Flag that indicates that the ALT key is locked.</summary>
		/// <remarks>Flag that indicates that the ALT key is locked.</remarks>
		public const int META_ALT_LOCKED = android.view.KeyEvent.META_ALT_LOCKED;

		/// <summary>Flag that indicates that the SYM key is locked.</summary>
		/// <remarks>Flag that indicates that the SYM key is locked.</remarks>
		public const int META_SYM_LOCKED = android.view.KeyEvent.META_SYM_LOCKED;

		/// <hide>pending API review</hide>
		public const int META_SELECTING = android.view.KeyEvent.META_SELECTING;

		internal const long META_CAP_USED = 1L << 32;

		internal const long META_ALT_USED = 1L << 33;

		internal const long META_SYM_USED = 1L << 34;

		internal const long META_CAP_PRESSED = 1L << 40;

		internal const long META_ALT_PRESSED = 1L << 41;

		internal const long META_SYM_PRESSED = 1L << 42;

		internal const long META_CAP_RELEASED = 1L << 48;

		internal const long META_ALT_RELEASED = 1L << 49;

		internal const long META_SYM_RELEASED = 1L << 50;

		internal const long META_SHIFT_MASK = META_SHIFT_ON | META_CAP_LOCKED | META_CAP_USED
			 | META_CAP_PRESSED | META_CAP_RELEASED;

		internal const long META_ALT_MASK = META_ALT_ON | META_ALT_LOCKED | META_ALT_USED
			 | META_ALT_PRESSED | META_ALT_RELEASED;

		internal const long META_SYM_MASK = META_SYM_ON | META_SYM_LOCKED | META_SYM_USED
			 | META_SYM_PRESSED | META_SYM_RELEASED;

		private static readonly object CAP = new android.text.NoCopySpanClass.Concrete();

		private static readonly object ALT = new android.text.NoCopySpanClass.Concrete();

		private static readonly object SYM = new android.text.NoCopySpanClass.Concrete();

		private static readonly object SELECTING = new android.text.NoCopySpanClass.Concrete
			();

		// These bits are privately used by the meta key key listener.
		// They are deliberately assigned values outside of the representable range of an 'int'
		// so as not to conflict with any meta key states publicly defined by KeyEvent.
		/// <summary>Resets all meta state to inactive.</summary>
		/// <remarks>Resets all meta state to inactive.</remarks>
		public static void resetMetaState(android.text.Spannable text)
		{
			text.removeSpan(CAP);
			text.removeSpan(ALT);
			text.removeSpan(SYM);
			text.removeSpan(SELECTING);
		}

		/// <summary>Gets the state of the meta keys.</summary>
		/// <remarks>Gets the state of the meta keys.</remarks>
		/// <param name="text">the buffer in which the meta key would have been pressed.</param>
		/// <returns>
		/// an integer in which each bit set to one represents a pressed
		/// or locked meta key.
		/// </returns>
		public static int getMetaState(java.lang.CharSequence text)
		{
			return getActive(text, CAP, META_SHIFT_ON, META_CAP_LOCKED) | getActive(text, ALT
				, META_ALT_ON, META_ALT_LOCKED) | getActive(text, SYM, META_SYM_ON, META_SYM_LOCKED
				) | getActive(text, SELECTING, META_SELECTING, META_SELECTING);
		}

		/// <summary>Gets the state of a particular meta key.</summary>
		/// <remarks>Gets the state of a particular meta key.</remarks>
		/// <param name="meta">META_SHIFT_ON, META_ALT_ON, META_SYM_ON, or META_SELECTING</param>
		/// <param name="text">the buffer in which the meta key would have been pressed.</param>
		/// <returns>0 if inactive, 1 if active, 2 if locked.</returns>
		public static int getMetaState(java.lang.CharSequence text, int meta)
		{
			switch (meta)
			{
				case META_SHIFT_ON:
				{
					return getActive(text, CAP, 1, 2);
				}

				case META_ALT_ON:
				{
					return getActive(text, ALT, 1, 2);
				}

				case META_SYM_ON:
				{
					return getActive(text, SYM, 1, 2);
				}

				case META_SELECTING:
				{
					return getActive(text, SELECTING, 1, 2);
				}

				default:
				{
					return 0;
				}
			}
		}

		private static int getActive(java.lang.CharSequence text, object meta, int on, int
			 @lock)
		{
			if (!(text is android.text.Spanned))
			{
				return 0;
			}
			android.text.Spanned sp = (android.text.Spanned)text;
			int flag = sp.getSpanFlags(meta);
			if (flag == LOCKED)
			{
				return @lock;
			}
			else
			{
				if (flag != 0)
				{
					return on;
				}
				else
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// Call this method after you handle a keypress so that the meta
		/// state will be reset to unshifted (if it is not still down)
		/// or primed to be reset to unshifted (once it is released).
		/// </summary>
		/// <remarks>
		/// Call this method after you handle a keypress so that the meta
		/// state will be reset to unshifted (if it is not still down)
		/// or primed to be reset to unshifted (once it is released).
		/// </remarks>
		public static void adjustMetaAfterKeypress(android.text.Spannable content)
		{
			adjust(content, CAP);
			adjust(content, ALT);
			adjust(content, SYM);
		}

		/// <summary>
		/// Returns true if this object is one that this class would use to
		/// keep track of any meta state in the specified text.
		/// </summary>
		/// <remarks>
		/// Returns true if this object is one that this class would use to
		/// keep track of any meta state in the specified text.
		/// </remarks>
		public static bool isMetaTracker(java.lang.CharSequence text, object what)
		{
			return what == CAP || what == ALT || what == SYM || what == SELECTING;
		}

		/// <summary>
		/// Returns true if this object is one that this class would use to
		/// keep track of the selecting meta state in the specified text.
		/// </summary>
		/// <remarks>
		/// Returns true if this object is one that this class would use to
		/// keep track of the selecting meta state in the specified text.
		/// </remarks>
		public static bool isSelectingMetaTracker(java.lang.CharSequence text, object what
			)
		{
			return what == SELECTING;
		}

		private static void adjust(android.text.Spannable content, object what)
		{
			int current = content.getSpanFlags(what);
			if (current == PRESSED)
			{
				content.setSpan(what, 0, 0, USED);
			}
			else
			{
				if (current == RELEASED)
				{
					content.removeSpan(what);
				}
			}
		}

		/// <summary>
		/// Call this if you are a method that ignores the locked meta state
		/// (arrow keys, for example) and you handle a key.
		/// </summary>
		/// <remarks>
		/// Call this if you are a method that ignores the locked meta state
		/// (arrow keys, for example) and you handle a key.
		/// </remarks>
		protected internal static void resetLockedMeta(android.text.Spannable content)
		{
			resetLock(content, CAP);
			resetLock(content, ALT);
			resetLock(content, SYM);
			resetLock(content, SELECTING);
		}

		private static void resetLock(android.text.Spannable content, object what)
		{
			int current = content.getSpanFlags(what);
			if (current == LOCKED)
			{
				content.removeSpan(what);
			}
		}

		/// <summary>Handles presses of the meta keys.</summary>
		/// <remarks>Handles presses of the meta keys.</remarks>
		public virtual bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_SHIFT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_SHIFT_RIGHT)
			{
				press(content, CAP);
				return true;
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_ALT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_ALT_RIGHT || keyCode == android.view.KeyEvent.KEYCODE_NUM)
			{
				press(content, ALT);
				return true;
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_SYM)
			{
				press(content, SYM);
				return true;
			}
			return false;
		}

		// no super to call through to
		private void press(android.text.Editable content, object what)
		{
			int state = content.getSpanFlags(what);
			if (state == PRESSED)
			{
			}
			else
			{
				// repeat before use
				if (state == RELEASED)
				{
					content.setSpan(what, 0, 0, LOCKED);
				}
				else
				{
					if (state == USED)
					{
					}
					else
					{
						// repeat after use
						if (state == LOCKED)
						{
							content.removeSpan(what);
						}
						else
						{
							content.setSpan(what, 0, 0, PRESSED);
						}
					}
				}
			}
		}

		/// <summary>Start selecting text.</summary>
		/// <remarks>Start selecting text.</remarks>
		/// <hide>pending API review</hide>
		public static void startSelecting(android.view.View view, android.text.Spannable 
			content)
		{
			content.setSpan(SELECTING, 0, 0, PRESSED);
		}

		/// <summary>Stop selecting text.</summary>
		/// <remarks>
		/// Stop selecting text.  This does not actually collapse the selection;
		/// call
		/// <see cref="android.text.Selection.setSelection(android.text.Spannable, int)">android.text.Selection.setSelection(android.text.Spannable, int)
		/// 	</see>
		/// too.
		/// </remarks>
		/// <hide>pending API review</hide>
		public static void stopSelecting(android.view.View view, android.text.Spannable content
			)
		{
			content.removeSpan(SELECTING);
		}

		/// <summary>Handles release of the meta keys.</summary>
		/// <remarks>Handles release of the meta keys.</remarks>
		public virtual bool onKeyUp(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_SHIFT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_SHIFT_RIGHT)
			{
				release(content, CAP, @event);
				return true;
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_ALT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_ALT_RIGHT || keyCode == android.view.KeyEvent.KEYCODE_NUM)
			{
				release(content, ALT, @event);
				return true;
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_SYM)
			{
				release(content, SYM, @event);
				return true;
			}
			return false;
		}

		// no super to call through to
		private void release(android.text.Editable content, object what, android.view.KeyEvent
			 @event)
		{
			int current = content.getSpanFlags(what);
			switch (@event.getKeyCharacterMap().getModifierBehavior())
			{
				case android.view.KeyCharacterMap.MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED:
				{
					if (current == USED)
					{
						content.removeSpan(what);
					}
					else
					{
						if (current == PRESSED)
						{
							content.setSpan(what, 0, 0, RELEASED);
						}
					}
					break;
				}

				default:
				{
					content.removeSpan(what);
					break;
				}
			}
		}

		public virtual void clearMetaKeyState(android.view.View view, android.text.Editable
			 content, int states)
		{
			clearMetaKeyState(content, states);
		}

		public static void clearMetaKeyState(android.text.Editable content, int states)
		{
			if ((states & META_SHIFT_ON) != 0)
			{
				content.removeSpan(CAP);
			}
			if ((states & META_ALT_ON) != 0)
			{
				content.removeSpan(ALT);
			}
			if ((states & META_SYM_ON) != 0)
			{
				content.removeSpan(SYM);
			}
			if ((states & META_SELECTING) != 0)
			{
				content.removeSpan(SELECTING);
			}
		}

		/// <summary>
		/// Call this if you are a method that ignores the locked meta state
		/// (arrow keys, for example) and you handle a key.
		/// </summary>
		/// <remarks>
		/// Call this if you are a method that ignores the locked meta state
		/// (arrow keys, for example) and you handle a key.
		/// </remarks>
		public static long resetLockedMeta(long state)
		{
			if ((state & META_CAP_LOCKED) != 0)
			{
				state &= ~META_SHIFT_MASK;
			}
			if ((state & META_ALT_LOCKED) != 0)
			{
				state &= ~META_ALT_MASK;
			}
			if ((state & META_SYM_LOCKED) != 0)
			{
				state &= ~META_SYM_MASK;
			}
			return state;
		}

		// ---------------------------------------------------------------------
		// Version of API that operates on a state bit mask
		// ---------------------------------------------------------------------
		/// <summary>Gets the state of the meta keys.</summary>
		/// <remarks>Gets the state of the meta keys.</remarks>
		/// <param name="state">the current meta state bits.</param>
		/// <returns>
		/// an integer in which each bit set to one represents a pressed
		/// or locked meta key.
		/// </returns>
		public static int getMetaState(long state)
		{
			int result = 0;
			if ((state & META_CAP_LOCKED) != 0)
			{
				result |= META_CAP_LOCKED;
			}
			else
			{
				if ((state & META_SHIFT_ON) != 0)
				{
					result |= META_SHIFT_ON;
				}
			}
			if ((state & META_ALT_LOCKED) != 0)
			{
				result |= META_ALT_LOCKED;
			}
			else
			{
				if ((state & META_ALT_ON) != 0)
				{
					result |= META_ALT_ON;
				}
			}
			if ((state & META_SYM_LOCKED) != 0)
			{
				result |= META_SYM_LOCKED;
			}
			else
			{
				if ((state & META_SYM_ON) != 0)
				{
					result |= META_SYM_ON;
				}
			}
			return result;
		}

		/// <summary>Gets the state of a particular meta key.</summary>
		/// <remarks>Gets the state of a particular meta key.</remarks>
		/// <param name="state">the current state bits.</param>
		/// <param name="meta">META_SHIFT_ON, META_ALT_ON, or META_SYM_ON</param>
		/// <returns>0 if inactive, 1 if active, 2 if locked.</returns>
		public static int getMetaState(long state, int meta)
		{
			switch (meta)
			{
				case META_SHIFT_ON:
				{
					if ((state & META_CAP_LOCKED) != 0)
					{
						return 2;
					}
					if ((state & META_SHIFT_ON) != 0)
					{
						return 1;
					}
					return 0;
				}

				case META_ALT_ON:
				{
					if ((state & META_ALT_LOCKED) != 0)
					{
						return 2;
					}
					if ((state & META_ALT_ON) != 0)
					{
						return 1;
					}
					return 0;
				}

				case META_SYM_ON:
				{
					if ((state & META_SYM_LOCKED) != 0)
					{
						return 2;
					}
					if ((state & META_SYM_ON) != 0)
					{
						return 1;
					}
					return 0;
				}

				default:
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// Call this method after you handle a keypress so that the meta
		/// state will be reset to unshifted (if it is not still down)
		/// or primed to be reset to unshifted (once it is released).
		/// </summary>
		/// <remarks>
		/// Call this method after you handle a keypress so that the meta
		/// state will be reset to unshifted (if it is not still down)
		/// or primed to be reset to unshifted (once it is released).  Takes
		/// the current state, returns the new state.
		/// </remarks>
		public static long adjustMetaAfterKeypress(long state)
		{
			if ((state & META_CAP_PRESSED) != 0)
			{
				state = (state & ~META_SHIFT_MASK) | META_SHIFT_ON | META_CAP_USED;
			}
			else
			{
				if ((state & META_CAP_RELEASED) != 0)
				{
					state &= ~META_SHIFT_MASK;
				}
			}
			if ((state & META_ALT_PRESSED) != 0)
			{
				state = (state & ~META_ALT_MASK) | META_ALT_ON | META_ALT_USED;
			}
			else
			{
				if ((state & META_ALT_RELEASED) != 0)
				{
					state &= ~META_ALT_MASK;
				}
			}
			if ((state & META_SYM_PRESSED) != 0)
			{
				state = (state & ~META_SYM_MASK) | META_SYM_ON | META_SYM_USED;
			}
			else
			{
				if ((state & META_SYM_RELEASED) != 0)
				{
					state &= ~META_SYM_MASK;
				}
			}
			return state;
		}

		/// <summary>Handles presses of the meta keys.</summary>
		/// <remarks>Handles presses of the meta keys.</remarks>
		public static long handleKeyDown(long state, int keyCode, android.view.KeyEvent @event
			)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_SHIFT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_SHIFT_RIGHT)
			{
				return press(state, META_SHIFT_ON, META_SHIFT_MASK, META_CAP_LOCKED, META_CAP_PRESSED
					, META_CAP_RELEASED, META_CAP_USED);
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_ALT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_ALT_RIGHT || keyCode == android.view.KeyEvent.KEYCODE_NUM)
			{
				return press(state, META_ALT_ON, META_ALT_MASK, META_ALT_LOCKED, META_ALT_PRESSED
					, META_ALT_RELEASED, META_ALT_USED);
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_SYM)
			{
				return press(state, META_SYM_ON, META_SYM_MASK, META_SYM_LOCKED, META_SYM_PRESSED
					, META_SYM_RELEASED, META_SYM_USED);
			}
			return state;
		}

		private static long press(long state, int what, long mask, long locked, long pressed
			, long released, long used)
		{
			if ((state & pressed) != 0)
			{
			}
			else
			{
				// repeat before use
				if ((state & released) != 0)
				{
					state = (state & ~mask) | what | locked;
				}
				else
				{
					if ((state & used) != 0)
					{
					}
					else
					{
						// repeat after use
						if ((state & locked) != 0)
						{
							state &= ~mask;
						}
						else
						{
							state |= what | pressed;
						}
					}
				}
			}
			return state;
		}

		/// <summary>Handles release of the meta keys.</summary>
		/// <remarks>Handles release of the meta keys.</remarks>
		public static long handleKeyUp(long state, int keyCode, android.view.KeyEvent @event
			)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_SHIFT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_SHIFT_RIGHT)
			{
				return release(state, META_SHIFT_ON, META_SHIFT_MASK, META_CAP_PRESSED, META_CAP_RELEASED
					, META_CAP_USED, @event);
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_ALT_LEFT || keyCode == android.view.KeyEvent
				.KEYCODE_ALT_RIGHT || keyCode == android.view.KeyEvent.KEYCODE_NUM)
			{
				return release(state, META_ALT_ON, META_ALT_MASK, META_ALT_PRESSED, META_ALT_RELEASED
					, META_ALT_USED, @event);
			}
			if (keyCode == android.view.KeyEvent.KEYCODE_SYM)
			{
				return release(state, META_SYM_ON, META_SYM_MASK, META_SYM_PRESSED, META_SYM_RELEASED
					, META_SYM_USED, @event);
			}
			return state;
		}

		private static long release(long state, int what, long mask, long pressed, long released
			, long used, android.view.KeyEvent @event)
		{
			switch (@event.getKeyCharacterMap().getModifierBehavior())
			{
				case android.view.KeyCharacterMap.MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED:
				{
					if ((state & used) != 0)
					{
						state &= ~mask;
					}
					else
					{
						if ((state & pressed) != 0)
						{
							state |= what | released;
						}
					}
					break;
				}

				default:
				{
					state &= ~mask;
					break;
				}
			}
			return state;
		}

		/// <summary>Clears the state of the specified meta key if it is locked.</summary>
		/// <remarks>Clears the state of the specified meta key if it is locked.</remarks>
		/// <param name="state">the meta key state</param>
		/// <param name="which">
		/// meta keys to clear, may be a combination of
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// ,
		/// <see cref="META_ALT_ON">META_ALT_ON</see>
		/// or
		/// <see cref="META_SYM_ON">META_SYM_ON</see>
		/// .
		/// </param>
		public virtual long clearMetaKeyState(long state, int which)
		{
			if ((which & META_SHIFT_ON) != 0 && (state & META_CAP_LOCKED) != 0)
			{
				state &= ~META_SHIFT_MASK;
			}
			if ((which & META_ALT_ON) != 0 && (state & META_ALT_LOCKED) != 0)
			{
				state &= ~META_ALT_MASK;
			}
			if ((which & META_SYM_ON) != 0 && (state & META_SYM_LOCKED) != 0)
			{
				state &= ~META_SYM_MASK;
			}
			return state;
		}

		/// <summary>The meta key has been pressed but has not yet been used.</summary>
		/// <remarks>The meta key has been pressed but has not yet been used.</remarks>
		internal const int PRESSED = android.text.SpannedClass.SPAN_MARK_MARK | (1 << android.text.SpannedClass.SPAN_USER_SHIFT
			);

		/// <summary>
		/// The meta key has been pressed and released but has still
		/// not yet been used.
		/// </summary>
		/// <remarks>
		/// The meta key has been pressed and released but has still
		/// not yet been used.
		/// </remarks>
		internal const int RELEASED = android.text.SpannedClass.SPAN_MARK_MARK | (2 << android.text.SpannedClass.SPAN_USER_SHIFT
			);

		/// <summary>The meta key has been pressed and used but has not yet been released.</summary>
		/// <remarks>The meta key has been pressed and used but has not yet been released.</remarks>
		internal const int USED = android.text.SpannedClass.SPAN_MARK_MARK | (3 << android.text.SpannedClass.SPAN_USER_SHIFT
			);

		/// <summary>
		/// The meta key has been pressed and released without use, and then
		/// pressed again; it may also have been released again.
		/// </summary>
		/// <remarks>
		/// The meta key has been pressed and released without use, and then
		/// pressed again; it may also have been released again.
		/// </remarks>
		internal const int LOCKED = android.text.SpannedClass.SPAN_MARK_MARK | (4 << android.text.SpannedClass.SPAN_USER_SHIFT
			);
	}
}
