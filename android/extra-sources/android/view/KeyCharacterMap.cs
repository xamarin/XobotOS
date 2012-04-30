using Sharpen;
using System;

namespace android.view
{
	/// <summary>Describes the keys provided by a keyboard device and their associated labels.
	/// 	</summary>
	/// <remarks>Describes the keys provided by a keyboard device and their associated labels.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public class KeyCharacterMap
	{
		/// <summary>The id of the device's primary built in keyboard is always 0.</summary>
		/// <remarks>The id of the device's primary built in keyboard is always 0.</remarks>
		[System.ObsoleteAttribute(@"This constant should no longer be used because there is no guarantee that a device has a built-in keyboard that can be used for typing text.  There might not be a built-in keyboard, the built-in keyboard might be a NUMERIC or SPECIAL_FUNCTION keyboard, or there might be multiple keyboards installed including external keyboards. When interpreting key presses received from the framework, applications should use the device id specified in the KeyEvent received. When synthesizing key presses for delivery elsewhere or when translating key presses from unknown keyboards, applications should use the special VIRTUAL_KEYBOARD device id.")]
		public const int BUILT_IN_KEYBOARD = 0;

		/// <summary>
		/// The id of a generic virtual keyboard with a full layout that can be used to
		/// synthesize key events.
		/// </summary>
		/// <remarks>
		/// The id of a generic virtual keyboard with a full layout that can be used to
		/// synthesize key events.  Typically used with
		/// <see cref="getEvents(char[])">getEvents(char[])</see>
		/// .
		/// </remarks>
		public const int VIRTUAL_KEYBOARD = -1;

		/// <summary>A numeric (12-key) keyboard.</summary>
		/// <remarks>
		/// A numeric (12-key) keyboard.
		/// <p>
		/// A numeric keyboard supports text entry using a multi-tap approach.
		/// It may be necessary to tap a key multiple times to generate the desired letter
		/// or symbol.
		/// </p><p>
		/// This type of keyboard is generally designed for thumb typing.
		/// </p>
		/// </remarks>
		public const int NUMERIC = 1;

		/// <summary>A keyboard with all the letters, but with more than one letter per key.</summary>
		/// <remarks>
		/// A keyboard with all the letters, but with more than one letter per key.
		/// <p>
		/// This type of keyboard is generally designed for thumb typing.
		/// </p>
		/// </remarks>
		public const int PREDICTIVE = 2;

		/// <summary>A keyboard with all the letters, and maybe some numbers.</summary>
		/// <remarks>
		/// A keyboard with all the letters, and maybe some numbers.
		/// <p>
		/// An alphabetic keyboard supports text entry directly but may have a condensed
		/// layout with a small form factor.  In contrast to a
		/// <see cref="FULL">full keyboard</see>
		/// , some
		/// symbols may only be accessible using special on-screen character pickers.
		/// In addition, to improve typing speed and accuracy, the framework provides
		/// special affordances for alphabetic keyboards such as auto-capitalization
		/// and toggled / locked shift and alt keys.
		/// </p><p>
		/// This type of keyboard is generally designed for thumb typing.
		/// </p>
		/// </remarks>
		public const int ALPHA = 3;

		/// <summary>A full PC-style keyboard.</summary>
		/// <remarks>
		/// A full PC-style keyboard.
		/// <p>
		/// A full keyboard behaves like a PC keyboard.  All symbols are accessed directly
		/// by pressing keys on the keyboard without on-screen support or affordances such
		/// as auto-capitalization.
		/// </p><p>
		/// This type of keyboard is generally designed for full two hand typing.
		/// </p>
		/// </remarks>
		public const int FULL = 4;

		/// <summary>A keyboard that is only used to control special functions rather than for typing.
		/// 	</summary>
		/// <remarks>
		/// A keyboard that is only used to control special functions rather than for typing.
		/// <p>
		/// A special function keyboard consists only of non-printing keys such as
		/// HOME and POWER that are not actually used for typing.
		/// </p>
		/// </remarks>
		public const int SPECIAL_FUNCTION = 5;

		/// <summary>
		/// This private-use character is used to trigger Unicode character
		/// input by hex digits.
		/// </summary>
		/// <remarks>
		/// This private-use character is used to trigger Unicode character
		/// input by hex digits.
		/// </remarks>
		public const char HEX_INPUT = '\uEF00';

		/// <summary>
		/// This private-use character is used to bring up a character picker for
		/// miscellaneous symbols.
		/// </summary>
		/// <remarks>
		/// This private-use character is used to bring up a character picker for
		/// miscellaneous symbols.
		/// </remarks>
		public const char PICKER_DIALOG_INPUT = '\uEF01';

		/// <summary>Modifier keys may be chorded with character keys.</summary>
		/// <remarks>Modifier keys may be chorded with character keys.</remarks>
		/// <seealso>{#link #getModifierBehavior()} for more details.</seealso>
		public const int MODIFIER_BEHAVIOR_CHORDED = 0;

		/// <summary>
		/// Modifier keys may be chorded with character keys or they may toggle
		/// into latched or locked states when pressed independently.
		/// </summary>
		/// <remarks>
		/// Modifier keys may be chorded with character keys or they may toggle
		/// into latched or locked states when pressed independently.
		/// </remarks>
		/// <seealso>{#link #getModifierBehavior()} for more details.</seealso>
		public const int MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED = 1;
		private static android.util.SparseArray<KeyCharacterMap> sInstances =
			new android.util.SparseArray<KeyCharacterMap> ();
		private readonly int mDeviceId;

		private KeyCharacterMap (int deviceId)
		{
			mDeviceId = deviceId;
		}

		/// <summary>Loads the key character maps for the keyboard with the specified device id.
		/// 	</summary>
		/// <remarks>Loads the key character maps for the keyboard with the specified device id.
		/// 	</remarks>
		/// <param name="deviceId">The device id of the keyboard.</param>
		/// <returns>The associated key character map.</returns>
		/// <exception>
		/// {@link UnavailableException} if the key character map
		/// could not be loaded because it was malformed or the default key character map
		/// is missing from the system.
		/// </exception>
		public static KeyCharacterMap load (int deviceId)
		{
			lock (sInstances) {
				KeyCharacterMap map = sInstances.get (deviceId);
				if (map == null) {
					map = new KeyCharacterMap (deviceId);
					sInstances.put (deviceId, map);
				}
				return map;
			}
		}

		/// <summary>
		/// Gets the Unicode character generated by the specified key and meta
		/// key state combination.
		/// </summary>
		/// <remarks>
		/// Gets the Unicode character generated by the specified key and meta
		/// key state combination.
		/// <p>
		/// Returns the Unicode character that the specified key would produce
		/// when the specified meta bits (see
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// )
		/// were active.
		/// </p><p>
		/// Returns 0 if the key is not one that is used to type Unicode
		/// characters.
		/// </p><p>
		/// If the return value has bit
		/// <see cref="COMBINING_ACCENT">COMBINING_ACCENT</see>
		/// set, the
		/// key is a "dead key" that should be combined with another to
		/// actually produce a character -- see
		/// <see cref="getDeadChar(int, int)">getDeadChar(int, int)</see>
		/// --
		/// after masking with
		/// <see cref="COMBINING_ACCENT_MASK">COMBINING_ACCENT_MASK</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <param name="metaState">The meta key modifier state.</param>
		/// <returns>The associated character or combining accent, or 0 if none.</returns>
		public virtual int get (int keyCode, int metaState)
		{
			int ch = KeyEvent.GetUnicodeChar (keyCode, metaState);
			int map = COMBINING.get (ch);
			if (map != 0) {
				return map;
			} else {
				return ch;
			}
		}

		/// <summary>
		/// Gets the fallback action to perform if the application does not
		/// handle the specified key.
		/// </summary>
		/// <remarks>
		/// Gets the fallback action to perform if the application does not
		/// handle the specified key.
		/// <p>
		/// When an application does not handle a particular key, the system may
		/// translate the key to an alternate fallback key (specified in the
		/// fallback action) and dispatch it to the application.
		/// The event containing the fallback key is flagged
		/// with
		/// <see cref="KeyEvent.FLAG_FALLBACK">KeyEvent.FLAG_FALLBACK</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <param name="metaState">The meta key modifier state.</param>
		/// <param name="outFallbackAction">The fallback action object to populate.</param>
		/// <returns>True if a fallback action was found, false otherwise.</returns>
		/// <hide></hide>
		[Sharpen.Stub]
		public virtual bool getFallbackAction (int keyCode, int metaState, KeyCharacterMap
			.FallbackAction outFallbackAction)
		{
			if (outFallbackAction == null) {
				throw new System.ArgumentException ("fallbackAction must not be null");
			}
			metaState = KeyEvent.normalizeMetaState (metaState);
			throw new NotImplementedException ();
		}

		/// <summary>Gets the number or symbol associated with the key.</summary>
		/// <remarks>
		/// Gets the number or symbol associated with the key.
		/// <p>
		/// The character value is returned, not the numeric value.
		/// If the key is not a number, but is a symbol, the symbol is retuned.
		/// </p><p>
		/// This method is intended to to support dial pads and other numeric or
		/// symbolic entry on keyboards where certain keys serve dual function
		/// as alphabetic and symbolic keys.  This method returns the number
		/// or symbol associated with the key independent of whether the user
		/// has pressed the required modifier.
		/// </p><p>
		/// For example, on one particular keyboard the keys on the top QWERTY row generate
		/// numbers when ALT is pressed such that ALT-Q maps to '1'.  So for that keyboard
		/// when
		/// <see cref="getNumber(int)">getNumber(int)</see>
		/// is called with
		/// <see cref="KeyEvent.KEYCODE_Q">KeyEvent.KEYCODE_Q</see>
		/// it returns '1'
		/// so that the user can type numbers without pressing ALT when it makes sense.
		/// </p>
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <returns>The associated numeric or symbolic character, or 0 if none.</returns>
		[Sharpen.Stub]
		public virtual char getNumber (int keyCode)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Gets the first character in the character array that can be generated
		/// by the specified key code.
		/// </summary>
		/// <remarks>
		/// Gets the first character in the character array that can be generated
		/// by the specified key code.
		/// <p>
		/// This is a convenience function that returns the same value as
		/// <see cref="getMatch(int, char[], int)">getMatch(keyCode, chars, 0)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="keyCode">The keycode.</param>
		/// <param name="chars">The array of matching characters to consider.</param>
		/// <returns>The matching associated character, or 0 if none.</returns>
		public virtual char getMatch (int keyCode, char[] chars)
		{
			return getMatch (keyCode, chars, 0);
		}

		/// <summary>
		/// Gets the first character in the character array that can be generated
		/// by the specified key code.
		/// </summary>
		/// <remarks>
		/// Gets the first character in the character array that can be generated
		/// by the specified key code.  If there are multiple choices, prefers
		/// the one that would be generated with the specified meta key modifier state.
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <param name="chars">The array of matching characters to consider.</param>
		/// <param name="metaState">The preferred meta key modifier state.</param>
		/// <returns>The matching associated character, or 0 if none.</returns>
		[Sharpen.Stub]
		public virtual char getMatch (int keyCode, char[] chars, int metaState)
		{
			if (chars == null) {
				throw new System.ArgumentException ("chars must not be null.");
			}
			metaState = KeyEvent.normalizeMetaState (metaState);
			throw new NotImplementedException ();
		}

		/// <summary>Gets the primary character for this key.</summary>
		/// <remarks>
		/// Gets the primary character for this key.
		/// In other words, the label that is physically printed on it.
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <returns>The display label character, or 0 if none (eg. for non-printing keys).</returns>
		[Sharpen.Stub]
		public virtual char getDisplayLabel (int keyCode)
		{
			throw new NotImplementedException ();
		}

		/// <summary>Get the character that is produced by putting accent on the character c.
		/// 	</summary>
		/// <remarks>
		/// Get the character that is produced by putting accent on the character c.
		/// For example, getDeadChar('`', 'e') returns &egrave;.
		/// </remarks>
		/// <param name="accent">The accent character.  eg. '`'</param>
		/// <param name="c">The basic character.</param>
		/// <returns>The combined character, or 0 if the characters cannot be combined.</returns>
		public static int getDeadChar (int accent, int c)
		{
			return DEAD.get ((accent << 16) | c);
		}

		/// <summary>Describes the character mappings associated with a key.</summary>
		/// <remarks>Describes the character mappings associated with a key.</remarks>
		[System.ObsoleteAttribute(@"instead use KeyCharacterMap.getDisplayLabel(int) ,KeyCharacterMap.getNumber(int) and KeyCharacterMap.get(int, int) ."
			)]
		public class KeyData
		{
			public const int META_LENGTH = 4;

			/// <summary>
			/// The display label (see
			/// <see cref="#getDisplayLabel">#getDisplayLabel</see>
			/// ).
			/// </summary>
			public char displayLabel;

			/// <summary>
			/// The "number" value (see
			/// <see cref="#getNumber">#getNumber</see>
			/// ).
			/// </summary>
			public char number;

			/// <summary>
			/// The character that will be generated in various meta states
			/// (the same ones used for
			/// <see cref="#get">#get</see>
			/// and defined as
			/// <see cref="KeyEvent.META_SHIFT_ON">KeyEvent.META_SHIFT_ON</see>
			/// and
			/// <see cref="KeyEvent.META_ALT_ON">KeyEvent.META_ALT_ON</see>
			/// ).
			/// <table>
			/// <tr><th>Index</th><th align="left">Value</th></tr>
			/// <tr><td>0</td><td>no modifiers</td></tr>
			/// <tr><td>1</td><td>caps</td></tr>
			/// <tr><td>2</td><td>alt</td></tr>
			/// <tr><td>3</td><td>caps + alt</td></tr>
			/// </table>
			/// </summary>
			public char[] meta = new char[META_LENGTH];
		}

		/// <summary>Get the character conversion data for a given key code.</summary>
		/// <remarks>Get the character conversion data for a given key code.</remarks>
		/// <param name="keyCode">The keyCode to query.</param>
		/// <param name="results">
		/// A
		/// <see cref="KeyData">KeyData</see>
		/// instance that will be filled with the results.
		/// </param>
		/// <returns>True if the key was mapped.  If the key was not mapped, results is not modified.
		/// 	</returns>
		[System.ObsoleteAttribute(@"instead use getDisplayLabel(int) ,getNumber(int) or get(int, int) .")]
		[Sharpen.Stub]
		public virtual bool getKeyData (int keyCode, KeyCharacterMap.KeyData results)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Get an array of KeyEvent objects that if put into the input stream
		/// could plausibly generate the provided sequence of characters.
		/// </summary>
		/// <remarks>
		/// Get an array of KeyEvent objects that if put into the input stream
		/// could plausibly generate the provided sequence of characters.  It is
		/// not guaranteed that the sequence is the only way to generate these
		/// events or that it is optimal.
		/// <p>
		/// This function is primarily offered for instrumentation and testing purposes.
		/// It may fail to map characters to key codes.  In particular, the key character
		/// map for the
		/// <see cref="BUILT_IN_KEYBOARD">built-in keyboard</see>
		/// device id may be empty.
		/// Consider using the key character map associated with the
		/// <see cref="VIRTUAL_KEYBOARD">virtual keyboard</see>
		/// device id instead.
		/// </p><p>
		/// For robust text entry, do not use this function.  Instead construct a
		/// <see cref="KeyEvent">KeyEvent</see>
		/// with action code
		/// <see cref="KeyEvent.ACTION_MULTIPLE">KeyEvent.ACTION_MULTIPLE</see>
		/// that contains
		/// the desired string using
		/// <see cref="KeyEvent.KeyEvent(long, string, int, int)">KeyEvent.KeyEvent(long, string, int, int)
		/// 	</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="chars">The sequence of characters to generate.</param>
		/// <returns>
		/// An array of
		/// <see cref="KeyEvent">KeyEvent</see>
		/// objects, or null if the given char array
		/// can not be generated using the current key character map.
		/// </returns>
		[Sharpen.Stub]
		public virtual KeyEvent[] getEvents (char[] chars)
		{
			if (chars == null) {
				throw new System.ArgumentException ("chars must not be null.");
			}
			throw new NotImplementedException ();
		}

		/// <summary>Returns true if the specified key produces a glyph.</summary>
		/// <remarks>Returns true if the specified key produces a glyph.</remarks>
		/// <param name="keyCode">The key code.</param>
		/// <returns>True if the key is a printing key.</returns>
		public virtual bool isPrintingKey (int keyCode)
		{
			int type = Sharpen.CharHelper.GetType (getDisplayLabel (keyCode));
			switch (type) {
			case Sharpen.CharHelper.SPACE_SEPARATOR:
			case Sharpen.CharHelper.LINE_SEPARATOR:
			case Sharpen.CharHelper.PARAGRAPH_SEPARATOR:
			case Sharpen.CharHelper.CONTROL:
			case Sharpen.CharHelper.FORMAT:
				{
					return false;
				}

			default:
				{
					return true;
					break;
				}
			}
		}

		/// <summary>Gets the keyboard type.</summary>
		/// <remarks>
		/// Gets the keyboard type.
		/// Returns
		/// <see cref="NUMERIC">NUMERIC</see>
		/// ,
		/// <see cref="PREDICTIVE">PREDICTIVE</see>
		/// ,
		/// <see cref="ALPHA">ALPHA</see>
		/// or
		/// <see cref="FULL">FULL</see>
		/// .
		/// <p>
		/// Different keyboard types have different semantics.  Refer to the documentation
		/// associated with the keyboard type constants for details.
		/// </p>
		/// </remarks>
		/// <returns>The keyboard type.</returns>
		[Sharpen.Stub]
		public virtual int getKeyboardType ()
		{
			return FULL;
		}

		/// <summary>
		/// Gets a constant that describes the behavior of this keyboard's modifier keys
		/// such as
		/// <see cref="KeyEvent.KEYCODE_SHIFT_LEFT">KeyEvent.KEYCODE_SHIFT_LEFT</see>
		/// .
		/// <p>
		/// Currently there are two behaviors that may be combined:
		/// </p>
		/// <ul>
		/// <li>Chorded behavior: When the modifier key is pressed together with one or more
		/// character keys, the keyboard inserts the modified keys and
		/// then resets the modifier state when the modifier key is released.</li>
		/// <li>Toggled behavior: When the modifier key is pressed and released on its own
		/// it first toggles into a latched state.  When latched, the modifier will apply
		/// to next character key that is pressed and will then reset itself to the initial state.
		/// If the modifier is already latched and the modifier key is pressed and release on
		/// its own again, then it toggles into a locked state.  When locked, the modifier will
		/// apply to all subsequent character keys that are pressed until unlocked by pressing
		/// the modifier key on its own one more time to reset it to the initial state.
		/// Toggled behavior is useful for small profile keyboards designed for thumb typing.
		/// </ul>
		/// <p>
		/// This function currently returns
		/// <see cref="MODIFIER_BEHAVIOR_CHORDED">MODIFIER_BEHAVIOR_CHORDED</see>
		/// when the
		/// <see cref="getKeyboardType()">keyboard type</see>
		/// is
		/// <see cref="FULL">FULL</see>
		/// or
		/// <see cref="SPECIAL_FUNCTION">SPECIAL_FUNCTION</see>
		/// and
		/// <see cref="MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED">MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED
		/// 	</see>
		/// otherwise.
		/// In the future, the function may also take into account global keyboard
		/// accessibility settings, other user preferences, or new device capabilities.
		/// </p>
		/// </summary>
		/// <returns>The modifier behavior for this keyboard.</returns>
		/// <seealso>
		/// 
		/// <see cref="MODIFIER_BEHAVIOR_CHORDED">MODIFIER_BEHAVIOR_CHORDED</see>
		/// </seealso>
		/// <seealso>
		/// 
		/// <see cref="MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED">MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED
		/// 	</see>
		/// </seealso>
		public virtual int getModifierBehavior ()
		{
			switch (getKeyboardType ()) {
			case FULL:
			case SPECIAL_FUNCTION:
				{
					return MODIFIER_BEHAVIOR_CHORDED;
				}

			default:
				{
					return MODIFIER_BEHAVIOR_CHORDED_OR_TOGGLED;
					break;
				}
			}
		}

		/// <summary>
		/// Queries the framework about whether any physical keys exist on the
		/// any keyboard attached to the device that are capable of producing the given key code.
		/// </summary>
		/// <remarks>
		/// Queries the framework about whether any physical keys exist on the
		/// any keyboard attached to the device that are capable of producing the given key code.
		/// </remarks>
		/// <param name="keyCode">The key code to query.</param>
		/// <returns>True if at least one attached keyboard supports the specified key code.</returns>
		public static bool deviceHasKey (int keyCode)
		{
			int[] codeArray = new int[1];
			codeArray [0] = keyCode;
			bool[] ret = deviceHasKeys (codeArray);
			return ret [0];
		}

		/// <summary>
		/// Queries the framework about whether any physical keys exist on the
		/// any keyboard attached to the device that are capable of producing the given
		/// array of key codes.
		/// </summary>
		/// <remarks>
		/// Queries the framework about whether any physical keys exist on the
		/// any keyboard attached to the device that are capable of producing the given
		/// array of key codes.
		/// </remarks>
		/// <param name="keyCodes">The array of key codes to query.</param>
		/// <returns>
		/// A new array of the same size as the key codes array whose elements
		/// are set to true if at least one attached keyboard supports the corresponding key code
		/// at the same index in the key codes array.
		/// </returns>
		public static bool[] deviceHasKeys (int[] keyCodes)
		{
			bool[] ret = new bool[keyCodes.Length];
			IWindowManager wm = Display.getWindowManager ();
			try {
				wm.hasKeys (keyCodes, ret);
			} catch (android.os.RemoteException) {
			}
			// no fallback; just return the empty array
			return ret;
		}

		/// <summary>
		/// Maps Unicode combining diacritical to display-form dead key
		/// (display character shifted left 16 bits).
		/// </summary>
		/// <remarks>
		/// Maps Unicode combining diacritical to display-form dead key
		/// (display character shifted left 16 bits).
		/// </remarks>
		private static android.util.SparseIntArray COMBINING = new android.util.SparseIntArray
			();

		/// <summary>
		/// Maps combinations of (display-form) dead key and second character
		/// to combined output character.
		/// </summary>
		/// <remarks>
		/// Maps combinations of (display-form) dead key and second character
		/// to combined output character.
		/// </remarks>
		private static android.util.SparseIntArray DEAD = new android.util.SparseIntArray
			();
		private const int ACUTE = '\u00B4' << 16;
		private const int GRAVE = '`' << 16;
		private const int CIRCUMFLEX = '^' << 16;
		private const int TILDE = '~' << 16;
		private const int UMLAUT = '\u00A8' << 16;
		public const int COMBINING_ACCENT = unchecked((int)(0x80000000));

		/// <summary>
		/// Mask the return value from
		/// <see cref="get(int, int)">get(int, int)</see>
		/// with this value to get
		/// a printable representation of the accent character of a "dead key."
		/// </summary>
		public const int COMBINING_ACCENT_MASK = unchecked((int)(0x7FFFFFFF));

		static KeyCharacterMap ()
		{
			COMBINING.put ('\u0300', (GRAVE >> 16) | COMBINING_ACCENT);
			COMBINING.put ('\u0301', (ACUTE >> 16) | COMBINING_ACCENT);
			COMBINING.put ('\u0302', (CIRCUMFLEX >> 16) | COMBINING_ACCENT);
			COMBINING.put ('\u0303', (TILDE >> 16) | COMBINING_ACCENT);
			COMBINING.put ('\u0308', (UMLAUT >> 16) | COMBINING_ACCENT);
			DEAD.put (ACUTE | 'A', '\u00C1');
			DEAD.put (ACUTE | 'C', '\u0106');
			DEAD.put (ACUTE | 'E', '\u00C9');
			DEAD.put (ACUTE | 'G', '\u01F4');
			DEAD.put (ACUTE | 'I', '\u00CD');
			DEAD.put (ACUTE | 'K', '\u1E30');
			DEAD.put (ACUTE | 'L', '\u0139');
			DEAD.put (ACUTE | 'M', '\u1E3E');
			DEAD.put (ACUTE | 'N', '\u0143');
			DEAD.put (ACUTE | 'O', '\u00D3');
			DEAD.put (ACUTE | 'P', '\u1E54');
			DEAD.put (ACUTE | 'R', '\u0154');
			DEAD.put (ACUTE | 'S', '\u015A');
			DEAD.put (ACUTE | 'U', '\u00DA');
			DEAD.put (ACUTE | 'W', '\u1E82');
			DEAD.put (ACUTE | 'Y', '\u00DD');
			DEAD.put (ACUTE | 'Z', '\u0179');
			DEAD.put (ACUTE | 'a', '\u00E1');
			DEAD.put (ACUTE | 'c', '\u0107');
			DEAD.put (ACUTE | 'e', '\u00E9');
			DEAD.put (ACUTE | 'g', '\u01F5');
			DEAD.put (ACUTE | 'i', '\u00ED');
			DEAD.put (ACUTE | 'k', '\u1E31');
			DEAD.put (ACUTE | 'l', '\u013A');
			DEAD.put (ACUTE | 'm', '\u1E3F');
			DEAD.put (ACUTE | 'n', '\u0144');
			DEAD.put (ACUTE | 'o', '\u00F3');
			DEAD.put (ACUTE | 'p', '\u1E55');
			DEAD.put (ACUTE | 'r', '\u0155');
			DEAD.put (ACUTE | 's', '\u015B');
			DEAD.put (ACUTE | 'u', '\u00FA');
			DEAD.put (ACUTE | 'w', '\u1E83');
			DEAD.put (ACUTE | 'y', '\u00FD');
			DEAD.put (ACUTE | 'z', '\u017A');
			DEAD.put (CIRCUMFLEX | 'A', '\u00C2');
			DEAD.put (CIRCUMFLEX | 'C', '\u0108');
			DEAD.put (CIRCUMFLEX | 'E', '\u00CA');
			DEAD.put (CIRCUMFLEX | 'G', '\u011C');
			DEAD.put (CIRCUMFLEX | 'H', '\u0124');
			DEAD.put (CIRCUMFLEX | 'I', '\u00CE');
			DEAD.put (CIRCUMFLEX | 'J', '\u0134');
			DEAD.put (CIRCUMFLEX | 'O', '\u00D4');
			DEAD.put (CIRCUMFLEX | 'S', '\u015C');
			DEAD.put (CIRCUMFLEX | 'U', '\u00DB');
			DEAD.put (CIRCUMFLEX | 'W', '\u0174');
			DEAD.put (CIRCUMFLEX | 'Y', '\u0176');
			DEAD.put (CIRCUMFLEX | 'Z', '\u1E90');
			DEAD.put (CIRCUMFLEX | 'a', '\u00E2');
			DEAD.put (CIRCUMFLEX | 'c', '\u0109');
			DEAD.put (CIRCUMFLEX | 'e', '\u00EA');
			DEAD.put (CIRCUMFLEX | 'g', '\u011D');
			DEAD.put (CIRCUMFLEX | 'h', '\u0125');
			DEAD.put (CIRCUMFLEX | 'i', '\u00EE');
			DEAD.put (CIRCUMFLEX | 'j', '\u0135');
			DEAD.put (CIRCUMFLEX | 'o', '\u00F4');
			DEAD.put (CIRCUMFLEX | 's', '\u015D');
			DEAD.put (CIRCUMFLEX | 'u', '\u00FB');
			DEAD.put (CIRCUMFLEX | 'w', '\u0175');
			DEAD.put (CIRCUMFLEX | 'y', '\u0177');
			DEAD.put (CIRCUMFLEX | 'z', '\u1E91');
			DEAD.put (GRAVE | 'A', '\u00C0');
			DEAD.put (GRAVE | 'E', '\u00C8');
			DEAD.put (GRAVE | 'I', '\u00CC');
			DEAD.put (GRAVE | 'N', '\u01F8');
			DEAD.put (GRAVE | 'O', '\u00D2');
			DEAD.put (GRAVE | 'U', '\u00D9');
			DEAD.put (GRAVE | 'W', '\u1E80');
			DEAD.put (GRAVE | 'Y', '\u1EF2');
			DEAD.put (GRAVE | 'a', '\u00E0');
			DEAD.put (GRAVE | 'e', '\u00E8');
			DEAD.put (GRAVE | 'i', '\u00EC');
			DEAD.put (GRAVE | 'n', '\u01F9');
			DEAD.put (GRAVE | 'o', '\u00F2');
			DEAD.put (GRAVE | 'u', '\u00F9');
			DEAD.put (GRAVE | 'w', '\u1E81');
			DEAD.put (GRAVE | 'y', '\u1EF3');
			DEAD.put (TILDE | 'A', '\u00C3');
			DEAD.put (TILDE | 'E', '\u1EBC');
			DEAD.put (TILDE | 'I', '\u0128');
			DEAD.put (TILDE | 'N', '\u00D1');
			DEAD.put (TILDE | 'O', '\u00D5');
			DEAD.put (TILDE | 'U', '\u0168');
			DEAD.put (TILDE | 'V', '\u1E7C');
			DEAD.put (TILDE | 'Y', '\u1EF8');
			DEAD.put (TILDE | 'a', '\u00E3');
			DEAD.put (TILDE | 'e', '\u1EBD');
			DEAD.put (TILDE | 'i', '\u0129');
			DEAD.put (TILDE | 'n', '\u00F1');
			DEAD.put (TILDE | 'o', '\u00F5');
			DEAD.put (TILDE | 'u', '\u0169');
			DEAD.put (TILDE | 'v', '\u1E7D');
			DEAD.put (TILDE | 'y', '\u1EF9');
			DEAD.put (UMLAUT | 'A', '\u00C4');
			DEAD.put (UMLAUT | 'E', '\u00CB');
			DEAD.put (UMLAUT | 'H', '\u1E26');
			DEAD.put (UMLAUT | 'I', '\u00CF');
			DEAD.put (UMLAUT | 'O', '\u00D6');
			DEAD.put (UMLAUT | 'U', '\u00DC');
			DEAD.put (UMLAUT | 'W', '\u1E84');
			DEAD.put (UMLAUT | 'X', '\u1E8C');
			DEAD.put (UMLAUT | 'Y', '\u0178');
			DEAD.put (UMLAUT | 'a', '\u00E4');
			DEAD.put (UMLAUT | 'e', '\u00EB');
			DEAD.put (UMLAUT | 'h', '\u1E27');
			DEAD.put (UMLAUT | 'i', '\u00EF');
			DEAD.put (UMLAUT | 'o', '\u00F6');
			DEAD.put (UMLAUT | 't', '\u1E97');
			DEAD.put (UMLAUT | 'u', '\u00FC');
			DEAD.put (UMLAUT | 'w', '\u1E85');
			DEAD.put (UMLAUT | 'x', '\u1E8D');
			DEAD.put (UMLAUT | 'y', '\u00FF');
		}

		/// <summary>
		/// Thrown by
		/// <see cref="KeyCharacterMap.load(int)">KeyCharacterMap.load(int)</see>
		/// when a key character map could not be loaded.
		/// </summary>
		[System.Serializable]
		public class UnavailableException : android.util.AndroidRuntimeException
		{
			public UnavailableException (string msg) : base(msg)
			{
			}
		}

		/// <summary>
		/// Specifies a substitute key code and meta state as a fallback action
		/// for an unhandled key.
		/// </summary>
		/// <remarks>
		/// Specifies a substitute key code and meta state as a fallback action
		/// for an unhandled key.
		/// </remarks>
		/// <hide></hide>
		public sealed class FallbackAction
		{
			public int keyCode;
			public int metaState;
		}
	}
}
