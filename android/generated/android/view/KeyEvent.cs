using Sharpen;

namespace android.view
{
	/// <summary>Object used to report key and button events.</summary>
	/// <remarks>
	/// Object used to report key and button events.
	/// <p>
	/// Each key press is described by a sequence of key events.  A key press
	/// starts with a key event with
	/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
	/// .  If the key is held
	/// sufficiently long that it repeats, then the initial down is followed
	/// additional key events with
	/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
	/// and a non-zero value for
	/// <see cref="getRepeatCount()">getRepeatCount()</see>
	/// .  The last key event is a
	/// <see cref="ACTION_UP">ACTION_UP</see>
	/// for the key up.  If the key press is canceled, the key up event will have the
	/// <see cref="FLAG_CANCELED">FLAG_CANCELED</see>
	/// flag set.
	/// </p><p>
	/// Key events are generally accompanied by a key code (
	/// <see cref="getKeyCode()">getKeyCode()</see>
	/// ),
	/// scan code (
	/// <see cref="getScanCode()">getScanCode()</see>
	/// ) and meta state (
	/// <see cref="getMetaState()">getMetaState()</see>
	/// ).
	/// Key code constants are defined in this class.  Scan code constants are raw
	/// device-specific codes obtained from the OS and so are not generally meaningful
	/// to applications unless interpreted using the
	/// <see cref="KeyCharacterMap">KeyCharacterMap</see>
	/// .
	/// Meta states describe the pressed state of key modifiers
	/// such as
	/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
	/// or
	/// <see cref="META_ALT_ON">META_ALT_ON</see>
	/// .
	/// </p><p>
	/// Key codes typically correspond one-to-one with individual keys on an input device.
	/// Many keys and key combinations serve quite different functions on different
	/// input devices so care must be taken when interpreting them.  Always use the
	/// <see cref="KeyCharacterMap">KeyCharacterMap</see>
	/// associated with the input device when mapping keys
	/// to characters.  Be aware that there may be multiple key input devices active
	/// at the same time and each will have its own key character map.
	/// </p><p>
	/// When interacting with an IME, the framework may deliver key events
	/// with the special action
	/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
	/// that either specifies
	/// that single repeated key code or a sequence of characters to insert.
	/// </p><p>
	/// In general, the framework cannot guarantee that the key events it delivers
	/// to a view always constitute complete key sequences since some events may be dropped
	/// or modified by containing views before they are delivered.  The view implementation
	/// should be prepared to handle
	/// <see cref="FLAG_CANCELED">FLAG_CANCELED</see>
	/// and should tolerate anomalous
	/// situations such as receiving a new
	/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
	/// without first having
	/// received an
	/// <see cref="ACTION_UP">ACTION_UP</see>
	/// for the prior key press.
	/// </p><p>
	/// Refer to
	/// <see cref="InputDevice">InputDevice</see>
	/// for more information about how different kinds of
	/// input devices and sources represent keys and buttons.
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class KeyEvent : android.view.InputEvent, android.os.Parcelable
	{
		/// <summary>Key code constant: Unknown key code.</summary>
		/// <remarks>Key code constant: Unknown key code.</remarks>
		public const int KEYCODE_UNKNOWN = 0;

		/// <summary>Key code constant: Soft Left key.</summary>
		/// <remarks>
		/// Key code constant: Soft Left key.
		/// Usually situated below the display on phones and used as a multi-function
		/// feature key for selecting a software defined function shown on the bottom left
		/// of the display.
		/// </remarks>
		public const int KEYCODE_SOFT_LEFT = 1;

		/// <summary>Key code constant: Soft Right key.</summary>
		/// <remarks>
		/// Key code constant: Soft Right key.
		/// Usually situated below the display on phones and used as a multi-function
		/// feature key for selecting a software defined function shown on the bottom right
		/// of the display.
		/// </remarks>
		public const int KEYCODE_SOFT_RIGHT = 2;

		/// <summary>Key code constant: Home key.</summary>
		/// <remarks>
		/// Key code constant: Home key.
		/// This key is handled by the framework and is never delivered to applications.
		/// </remarks>
		public const int KEYCODE_HOME = 3;

		/// <summary>Key code constant: Back key.</summary>
		/// <remarks>Key code constant: Back key.</remarks>
		public const int KEYCODE_BACK = 4;

		/// <summary>Key code constant: Call key.</summary>
		/// <remarks>Key code constant: Call key.</remarks>
		public const int KEYCODE_CALL = 5;

		/// <summary>Key code constant: End Call key.</summary>
		/// <remarks>Key code constant: End Call key.</remarks>
		public const int KEYCODE_ENDCALL = 6;

		/// <summary>Key code constant: '0' key.</summary>
		/// <remarks>Key code constant: '0' key.</remarks>
		public const int KEYCODE_0 = 7;

		/// <summary>Key code constant: '1' key.</summary>
		/// <remarks>Key code constant: '1' key.</remarks>
		public const int KEYCODE_1 = 8;

		/// <summary>Key code constant: '2' key.</summary>
		/// <remarks>Key code constant: '2' key.</remarks>
		public const int KEYCODE_2 = 9;

		/// <summary>Key code constant: '3' key.</summary>
		/// <remarks>Key code constant: '3' key.</remarks>
		public const int KEYCODE_3 = 10;

		/// <summary>Key code constant: '4' key.</summary>
		/// <remarks>Key code constant: '4' key.</remarks>
		public const int KEYCODE_4 = 11;

		/// <summary>Key code constant: '5' key.</summary>
		/// <remarks>Key code constant: '5' key.</remarks>
		public const int KEYCODE_5 = 12;

		/// <summary>Key code constant: '6' key.</summary>
		/// <remarks>Key code constant: '6' key.</remarks>
		public const int KEYCODE_6 = 13;

		/// <summary>Key code constant: '7' key.</summary>
		/// <remarks>Key code constant: '7' key.</remarks>
		public const int KEYCODE_7 = 14;

		/// <summary>Key code constant: '8' key.</summary>
		/// <remarks>Key code constant: '8' key.</remarks>
		public const int KEYCODE_8 = 15;

		/// <summary>Key code constant: '9' key.</summary>
		/// <remarks>Key code constant: '9' key.</remarks>
		public const int KEYCODE_9 = 16;

		/// <summary>Key code constant: '*' key.</summary>
		/// <remarks>Key code constant: '*' key.</remarks>
		public const int KEYCODE_STAR = 17;

		/// <summary>Key code constant: '#' key.</summary>
		/// <remarks>Key code constant: '#' key.</remarks>
		public const int KEYCODE_POUND = 18;

		/// <summary>Key code constant: Directional Pad Up key.</summary>
		/// <remarks>
		/// Key code constant: Directional Pad Up key.
		/// May also be synthesized from trackball motions.
		/// </remarks>
		public const int KEYCODE_DPAD_UP = 19;

		/// <summary>Key code constant: Directional Pad Down key.</summary>
		/// <remarks>
		/// Key code constant: Directional Pad Down key.
		/// May also be synthesized from trackball motions.
		/// </remarks>
		public const int KEYCODE_DPAD_DOWN = 20;

		/// <summary>Key code constant: Directional Pad Left key.</summary>
		/// <remarks>
		/// Key code constant: Directional Pad Left key.
		/// May also be synthesized from trackball motions.
		/// </remarks>
		public const int KEYCODE_DPAD_LEFT = 21;

		/// <summary>Key code constant: Directional Pad Right key.</summary>
		/// <remarks>
		/// Key code constant: Directional Pad Right key.
		/// May also be synthesized from trackball motions.
		/// </remarks>
		public const int KEYCODE_DPAD_RIGHT = 22;

		/// <summary>Key code constant: Directional Pad Center key.</summary>
		/// <remarks>
		/// Key code constant: Directional Pad Center key.
		/// May also be synthesized from trackball motions.
		/// </remarks>
		public const int KEYCODE_DPAD_CENTER = 23;

		/// <summary>Key code constant: Volume Up key.</summary>
		/// <remarks>
		/// Key code constant: Volume Up key.
		/// Adjusts the speaker volume up.
		/// </remarks>
		public const int KEYCODE_VOLUME_UP = 24;

		/// <summary>Key code constant: Volume Down key.</summary>
		/// <remarks>
		/// Key code constant: Volume Down key.
		/// Adjusts the speaker volume down.
		/// </remarks>
		public const int KEYCODE_VOLUME_DOWN = 25;

		/// <summary>Key code constant: Power key.</summary>
		/// <remarks>Key code constant: Power key.</remarks>
		public const int KEYCODE_POWER = 26;

		/// <summary>Key code constant: Camera key.</summary>
		/// <remarks>
		/// Key code constant: Camera key.
		/// Used to launch a camera application or take pictures.
		/// </remarks>
		public const int KEYCODE_CAMERA = 27;

		/// <summary>Key code constant: Clear key.</summary>
		/// <remarks>Key code constant: Clear key.</remarks>
		public const int KEYCODE_CLEAR = 28;

		/// <summary>Key code constant: 'A' key.</summary>
		/// <remarks>Key code constant: 'A' key.</remarks>
		public const int KEYCODE_A = 29;

		/// <summary>Key code constant: 'B' key.</summary>
		/// <remarks>Key code constant: 'B' key.</remarks>
		public const int KEYCODE_B = 30;

		/// <summary>Key code constant: 'C' key.</summary>
		/// <remarks>Key code constant: 'C' key.</remarks>
		public const int KEYCODE_C = 31;

		/// <summary>Key code constant: 'D' key.</summary>
		/// <remarks>Key code constant: 'D' key.</remarks>
		public const int KEYCODE_D = 32;

		/// <summary>Key code constant: 'E' key.</summary>
		/// <remarks>Key code constant: 'E' key.</remarks>
		public const int KEYCODE_E = 33;

		/// <summary>Key code constant: 'F' key.</summary>
		/// <remarks>Key code constant: 'F' key.</remarks>
		public const int KEYCODE_F = 34;

		/// <summary>Key code constant: 'G' key.</summary>
		/// <remarks>Key code constant: 'G' key.</remarks>
		public const int KEYCODE_G = 35;

		/// <summary>Key code constant: 'H' key.</summary>
		/// <remarks>Key code constant: 'H' key.</remarks>
		public const int KEYCODE_H = 36;

		/// <summary>Key code constant: 'I' key.</summary>
		/// <remarks>Key code constant: 'I' key.</remarks>
		public const int KEYCODE_I = 37;

		/// <summary>Key code constant: 'J' key.</summary>
		/// <remarks>Key code constant: 'J' key.</remarks>
		public const int KEYCODE_J = 38;

		/// <summary>Key code constant: 'K' key.</summary>
		/// <remarks>Key code constant: 'K' key.</remarks>
		public const int KEYCODE_K = 39;

		/// <summary>Key code constant: 'L' key.</summary>
		/// <remarks>Key code constant: 'L' key.</remarks>
		public const int KEYCODE_L = 40;

		/// <summary>Key code constant: 'M' key.</summary>
		/// <remarks>Key code constant: 'M' key.</remarks>
		public const int KEYCODE_M = 41;

		/// <summary>Key code constant: 'N' key.</summary>
		/// <remarks>Key code constant: 'N' key.</remarks>
		public const int KEYCODE_N = 42;

		/// <summary>Key code constant: 'O' key.</summary>
		/// <remarks>Key code constant: 'O' key.</remarks>
		public const int KEYCODE_O = 43;

		/// <summary>Key code constant: 'P' key.</summary>
		/// <remarks>Key code constant: 'P' key.</remarks>
		public const int KEYCODE_P = 44;

		/// <summary>Key code constant: 'Q' key.</summary>
		/// <remarks>Key code constant: 'Q' key.</remarks>
		public const int KEYCODE_Q = 45;

		/// <summary>Key code constant: 'R' key.</summary>
		/// <remarks>Key code constant: 'R' key.</remarks>
		public const int KEYCODE_R = 46;

		/// <summary>Key code constant: 'S' key.</summary>
		/// <remarks>Key code constant: 'S' key.</remarks>
		public const int KEYCODE_S = 47;

		/// <summary>Key code constant: 'T' key.</summary>
		/// <remarks>Key code constant: 'T' key.</remarks>
		public const int KEYCODE_T = 48;

		/// <summary>Key code constant: 'U' key.</summary>
		/// <remarks>Key code constant: 'U' key.</remarks>
		public const int KEYCODE_U = 49;

		/// <summary>Key code constant: 'V' key.</summary>
		/// <remarks>Key code constant: 'V' key.</remarks>
		public const int KEYCODE_V = 50;

		/// <summary>Key code constant: 'W' key.</summary>
		/// <remarks>Key code constant: 'W' key.</remarks>
		public const int KEYCODE_W = 51;

		/// <summary>Key code constant: 'X' key.</summary>
		/// <remarks>Key code constant: 'X' key.</remarks>
		public const int KEYCODE_X = 52;

		/// <summary>Key code constant: 'Y' key.</summary>
		/// <remarks>Key code constant: 'Y' key.</remarks>
		public const int KEYCODE_Y = 53;

		/// <summary>Key code constant: 'Z' key.</summary>
		/// <remarks>Key code constant: 'Z' key.</remarks>
		public const int KEYCODE_Z = 54;

		/// <summary>Key code constant: ',' key.</summary>
		/// <remarks>Key code constant: ',' key.</remarks>
		public const int KEYCODE_COMMA = 55;

		/// <summary>Key code constant: '.' key.</summary>
		/// <remarks>Key code constant: '.' key.</remarks>
		public const int KEYCODE_PERIOD = 56;

		/// <summary>Key code constant: Left Alt modifier key.</summary>
		/// <remarks>Key code constant: Left Alt modifier key.</remarks>
		public const int KEYCODE_ALT_LEFT = 57;

		/// <summary>Key code constant: Right Alt modifier key.</summary>
		/// <remarks>Key code constant: Right Alt modifier key.</remarks>
		public const int KEYCODE_ALT_RIGHT = 58;

		/// <summary>Key code constant: Left Shift modifier key.</summary>
		/// <remarks>Key code constant: Left Shift modifier key.</remarks>
		public const int KEYCODE_SHIFT_LEFT = 59;

		/// <summary>Key code constant: Right Shift modifier key.</summary>
		/// <remarks>Key code constant: Right Shift modifier key.</remarks>
		public const int KEYCODE_SHIFT_RIGHT = 60;

		/// <summary>Key code constant: Tab key.</summary>
		/// <remarks>Key code constant: Tab key.</remarks>
		public const int KEYCODE_TAB = 61;

		/// <summary>Key code constant: Space key.</summary>
		/// <remarks>Key code constant: Space key.</remarks>
		public const int KEYCODE_SPACE = 62;

		/// <summary>Key code constant: Symbol modifier key.</summary>
		/// <remarks>
		/// Key code constant: Symbol modifier key.
		/// Used to enter alternate symbols.
		/// </remarks>
		public const int KEYCODE_SYM = 63;

		/// <summary>Key code constant: Explorer special function key.</summary>
		/// <remarks>
		/// Key code constant: Explorer special function key.
		/// Used to launch a browser application.
		/// </remarks>
		public const int KEYCODE_EXPLORER = 64;

		/// <summary>Key code constant: Envelope special function key.</summary>
		/// <remarks>
		/// Key code constant: Envelope special function key.
		/// Used to launch a mail application.
		/// </remarks>
		public const int KEYCODE_ENVELOPE = 65;

		/// <summary>Key code constant: Enter key.</summary>
		/// <remarks>Key code constant: Enter key.</remarks>
		public const int KEYCODE_ENTER = 66;

		/// <summary>Key code constant: Backspace key.</summary>
		/// <remarks>
		/// Key code constant: Backspace key.
		/// Deletes characters before the insertion point, unlike
		/// <see cref="KEYCODE_FORWARD_DEL">KEYCODE_FORWARD_DEL</see>
		/// .
		/// </remarks>
		public const int KEYCODE_DEL = 67;

		/// <summary>Key code constant: '`' (backtick) key.</summary>
		/// <remarks>Key code constant: '`' (backtick) key.</remarks>
		public const int KEYCODE_GRAVE = 68;

		/// <summary>Key code constant: '-'.</summary>
		/// <remarks>Key code constant: '-'.</remarks>
		public const int KEYCODE_MINUS = 69;

		/// <summary>Key code constant: '=' key.</summary>
		/// <remarks>Key code constant: '=' key.</remarks>
		public const int KEYCODE_EQUALS = 70;

		/// <summary>Key code constant: '[' key.</summary>
		/// <remarks>Key code constant: '[' key.</remarks>
		public const int KEYCODE_LEFT_BRACKET = 71;

		/// <summary>Key code constant: ']' key.</summary>
		/// <remarks>Key code constant: ']' key.</remarks>
		public const int KEYCODE_RIGHT_BRACKET = 72;

		/// <summary>Key code constant: '\' key.</summary>
		/// <remarks>Key code constant: '\' key.</remarks>
		public const int KEYCODE_BACKSLASH = 73;

		/// <summary>Key code constant: ';' key.</summary>
		/// <remarks>Key code constant: ';' key.</remarks>
		public const int KEYCODE_SEMICOLON = 74;

		/// <summary>Key code constant: ''' (apostrophe) key.</summary>
		/// <remarks>Key code constant: ''' (apostrophe) key.</remarks>
		public const int KEYCODE_APOSTROPHE = 75;

		/// <summary>Key code constant: '/' key.</summary>
		/// <remarks>Key code constant: '/' key.</remarks>
		public const int KEYCODE_SLASH = 76;

		/// <summary>Key code constant: '@' key.</summary>
		/// <remarks>Key code constant: '@' key.</remarks>
		public const int KEYCODE_AT = 77;

		/// <summary>Key code constant: Number modifier key.</summary>
		/// <remarks>
		/// Key code constant: Number modifier key.
		/// Used to enter numeric symbols.
		/// This key is not Num Lock; it is more like
		/// <see cref="KEYCODE_ALT_LEFT">KEYCODE_ALT_LEFT</see>
		/// and is
		/// interpreted as an ALT key by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// .
		/// </remarks>
		public const int KEYCODE_NUM = 78;

		/// <summary>Key code constant: Headset Hook key.</summary>
		/// <remarks>
		/// Key code constant: Headset Hook key.
		/// Used to hang up calls and stop media.
		/// </remarks>
		public const int KEYCODE_HEADSETHOOK = 79;

		/// <summary>Key code constant: Camera Focus key.</summary>
		/// <remarks>
		/// Key code constant: Camera Focus key.
		/// Used to focus the camera.
		/// </remarks>
		public const int KEYCODE_FOCUS = 80;

		/// <summary>Key code constant: '+' key.</summary>
		/// <remarks>Key code constant: '+' key.</remarks>
		public const int KEYCODE_PLUS = 81;

		/// <summary>Key code constant: Menu key.</summary>
		/// <remarks>Key code constant: Menu key.</remarks>
		public const int KEYCODE_MENU = 82;

		/// <summary>Key code constant: Notification key.</summary>
		/// <remarks>Key code constant: Notification key.</remarks>
		public const int KEYCODE_NOTIFICATION = 83;

		/// <summary>Key code constant: Search key.</summary>
		/// <remarks>Key code constant: Search key.</remarks>
		public const int KEYCODE_SEARCH = 84;

		/// <summary>Key code constant: Play/Pause media key.</summary>
		/// <remarks>Key code constant: Play/Pause media key.</remarks>
		public const int KEYCODE_MEDIA_PLAY_PAUSE = 85;

		/// <summary>Key code constant: Stop media key.</summary>
		/// <remarks>Key code constant: Stop media key.</remarks>
		public const int KEYCODE_MEDIA_STOP = 86;

		/// <summary>Key code constant: Play Next media key.</summary>
		/// <remarks>Key code constant: Play Next media key.</remarks>
		public const int KEYCODE_MEDIA_NEXT = 87;

		/// <summary>Key code constant: Play Previous media key.</summary>
		/// <remarks>Key code constant: Play Previous media key.</remarks>
		public const int KEYCODE_MEDIA_PREVIOUS = 88;

		/// <summary>Key code constant: Rewind media key.</summary>
		/// <remarks>Key code constant: Rewind media key.</remarks>
		public const int KEYCODE_MEDIA_REWIND = 89;

		/// <summary>Key code constant: Fast Forward media key.</summary>
		/// <remarks>Key code constant: Fast Forward media key.</remarks>
		public const int KEYCODE_MEDIA_FAST_FORWARD = 90;

		/// <summary>Key code constant: Mute key.</summary>
		/// <remarks>
		/// Key code constant: Mute key.
		/// Mutes the microphone, unlike
		/// <see cref="KEYCODE_VOLUME_MUTE">KEYCODE_VOLUME_MUTE</see>
		/// .
		/// </remarks>
		public const int KEYCODE_MUTE = 91;

		/// <summary>Key code constant: Page Up key.</summary>
		/// <remarks>Key code constant: Page Up key.</remarks>
		public const int KEYCODE_PAGE_UP = 92;

		/// <summary>Key code constant: Page Down key.</summary>
		/// <remarks>Key code constant: Page Down key.</remarks>
		public const int KEYCODE_PAGE_DOWN = 93;

		/// <summary>Key code constant: Picture Symbols modifier key.</summary>
		/// <remarks>
		/// Key code constant: Picture Symbols modifier key.
		/// Used to switch symbol sets (Emoji, Kao-moji).
		/// </remarks>
		public const int KEYCODE_PICTSYMBOLS = 94;

		/// <summary>Key code constant: Switch Charset modifier key.</summary>
		/// <remarks>
		/// Key code constant: Switch Charset modifier key.
		/// Used to switch character sets (Kanji, Katakana).
		/// </remarks>
		public const int KEYCODE_SWITCH_CHARSET = 95;

		/// <summary>Key code constant: A Button key.</summary>
		/// <remarks>
		/// Key code constant: A Button key.
		/// On a game controller, the A button should be either the button labeled A
		/// or the first button on the upper row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_A = 96;

		/// <summary>Key code constant: B Button key.</summary>
		/// <remarks>
		/// Key code constant: B Button key.
		/// On a game controller, the B button should be either the button labeled B
		/// or the second button on the upper row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_B = 97;

		/// <summary>Key code constant: C Button key.</summary>
		/// <remarks>
		/// Key code constant: C Button key.
		/// On a game controller, the C button should be either the button labeled C
		/// or the third button on the upper row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_C = 98;

		/// <summary>Key code constant: X Button key.</summary>
		/// <remarks>
		/// Key code constant: X Button key.
		/// On a game controller, the X button should be either the button labeled X
		/// or the first button on the lower row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_X = 99;

		/// <summary>Key code constant: Y Button key.</summary>
		/// <remarks>
		/// Key code constant: Y Button key.
		/// On a game controller, the Y button should be either the button labeled Y
		/// or the second button on the lower row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_Y = 100;

		/// <summary>Key code constant: Z Button key.</summary>
		/// <remarks>
		/// Key code constant: Z Button key.
		/// On a game controller, the Z button should be either the button labeled Z
		/// or the third button on the lower row of controller buttons.
		/// </remarks>
		public const int KEYCODE_BUTTON_Z = 101;

		/// <summary>Key code constant: L1 Button key.</summary>
		/// <remarks>
		/// Key code constant: L1 Button key.
		/// On a game controller, the L1 button should be either the button labeled L1 (or L)
		/// or the top left trigger button.
		/// </remarks>
		public const int KEYCODE_BUTTON_L1 = 102;

		/// <summary>Key code constant: R1 Button key.</summary>
		/// <remarks>
		/// Key code constant: R1 Button key.
		/// On a game controller, the R1 button should be either the button labeled R1 (or R)
		/// or the top right trigger button.
		/// </remarks>
		public const int KEYCODE_BUTTON_R1 = 103;

		/// <summary>Key code constant: L2 Button key.</summary>
		/// <remarks>
		/// Key code constant: L2 Button key.
		/// On a game controller, the L2 button should be either the button labeled L2
		/// or the bottom left trigger button.
		/// </remarks>
		public const int KEYCODE_BUTTON_L2 = 104;

		/// <summary>Key code constant: R2 Button key.</summary>
		/// <remarks>
		/// Key code constant: R2 Button key.
		/// On a game controller, the R2 button should be either the button labeled R2
		/// or the bottom right trigger button.
		/// </remarks>
		public const int KEYCODE_BUTTON_R2 = 105;

		/// <summary>Key code constant: Left Thumb Button key.</summary>
		/// <remarks>
		/// Key code constant: Left Thumb Button key.
		/// On a game controller, the left thumb button indicates that the left (or only)
		/// joystick is pressed.
		/// </remarks>
		public const int KEYCODE_BUTTON_THUMBL = 106;

		/// <summary>Key code constant: Right Thumb Button key.</summary>
		/// <remarks>
		/// Key code constant: Right Thumb Button key.
		/// On a game controller, the right thumb button indicates that the right
		/// joystick is pressed.
		/// </remarks>
		public const int KEYCODE_BUTTON_THUMBR = 107;

		/// <summary>Key code constant: Start Button key.</summary>
		/// <remarks>
		/// Key code constant: Start Button key.
		/// On a game controller, the button labeled Start.
		/// </remarks>
		public const int KEYCODE_BUTTON_START = 108;

		/// <summary>Key code constant: Select Button key.</summary>
		/// <remarks>
		/// Key code constant: Select Button key.
		/// On a game controller, the button labeled Select.
		/// </remarks>
		public const int KEYCODE_BUTTON_SELECT = 109;

		/// <summary>Key code constant: Mode Button key.</summary>
		/// <remarks>
		/// Key code constant: Mode Button key.
		/// On a game controller, the button labeled Mode.
		/// </remarks>
		public const int KEYCODE_BUTTON_MODE = 110;

		/// <summary>Key code constant: Escape key.</summary>
		/// <remarks>Key code constant: Escape key.</remarks>
		public const int KEYCODE_ESCAPE = 111;

		/// <summary>Key code constant: Forward Delete key.</summary>
		/// <remarks>
		/// Key code constant: Forward Delete key.
		/// Deletes characters ahead of the insertion point, unlike
		/// <see cref="KEYCODE_DEL">KEYCODE_DEL</see>
		/// .
		/// </remarks>
		public const int KEYCODE_FORWARD_DEL = 112;

		/// <summary>Key code constant: Left Control modifier key.</summary>
		/// <remarks>Key code constant: Left Control modifier key.</remarks>
		public const int KEYCODE_CTRL_LEFT = 113;

		/// <summary>Key code constant: Right Control modifier key.</summary>
		/// <remarks>Key code constant: Right Control modifier key.</remarks>
		public const int KEYCODE_CTRL_RIGHT = 114;

		/// <summary>Key code constant: Caps Lock key.</summary>
		/// <remarks>Key code constant: Caps Lock key.</remarks>
		public const int KEYCODE_CAPS_LOCK = 115;

		/// <summary>Key code constant: Scroll Lock key.</summary>
		/// <remarks>Key code constant: Scroll Lock key.</remarks>
		public const int KEYCODE_SCROLL_LOCK = 116;

		/// <summary>Key code constant: Left Meta modifier key.</summary>
		/// <remarks>Key code constant: Left Meta modifier key.</remarks>
		public const int KEYCODE_META_LEFT = 117;

		/// <summary>Key code constant: Right Meta modifier key.</summary>
		/// <remarks>Key code constant: Right Meta modifier key.</remarks>
		public const int KEYCODE_META_RIGHT = 118;

		/// <summary>Key code constant: Function modifier key.</summary>
		/// <remarks>Key code constant: Function modifier key.</remarks>
		public const int KEYCODE_FUNCTION = 119;

		/// <summary>Key code constant: System Request / Print Screen key.</summary>
		/// <remarks>Key code constant: System Request / Print Screen key.</remarks>
		public const int KEYCODE_SYSRQ = 120;

		/// <summary>Key code constant: Break / Pause key.</summary>
		/// <remarks>Key code constant: Break / Pause key.</remarks>
		public const int KEYCODE_BREAK = 121;

		/// <summary>Key code constant: Home Movement key.</summary>
		/// <remarks>
		/// Key code constant: Home Movement key.
		/// Used for scrolling or moving the cursor around to the start of a line
		/// or to the top of a list.
		/// </remarks>
		public const int KEYCODE_MOVE_HOME = 122;

		/// <summary>Key code constant: End Movement key.</summary>
		/// <remarks>
		/// Key code constant: End Movement key.
		/// Used for scrolling or moving the cursor around to the end of a line
		/// or to the bottom of a list.
		/// </remarks>
		public const int KEYCODE_MOVE_END = 123;

		/// <summary>Key code constant: Insert key.</summary>
		/// <remarks>
		/// Key code constant: Insert key.
		/// Toggles insert / overwrite edit mode.
		/// </remarks>
		public const int KEYCODE_INSERT = 124;

		/// <summary>Key code constant: Forward key.</summary>
		/// <remarks>
		/// Key code constant: Forward key.
		/// Navigates forward in the history stack.  Complement of
		/// <see cref="KEYCODE_BACK">KEYCODE_BACK</see>
		/// .
		/// </remarks>
		public const int KEYCODE_FORWARD = 125;

		/// <summary>Key code constant: Play media key.</summary>
		/// <remarks>Key code constant: Play media key.</remarks>
		public const int KEYCODE_MEDIA_PLAY = 126;

		/// <summary>Key code constant: Pause media key.</summary>
		/// <remarks>Key code constant: Pause media key.</remarks>
		public const int KEYCODE_MEDIA_PAUSE = 127;

		/// <summary>Key code constant: Close media key.</summary>
		/// <remarks>
		/// Key code constant: Close media key.
		/// May be used to close a CD tray, for example.
		/// </remarks>
		public const int KEYCODE_MEDIA_CLOSE = 128;

		/// <summary>Key code constant: Eject media key.</summary>
		/// <remarks>
		/// Key code constant: Eject media key.
		/// May be used to eject a CD tray, for example.
		/// </remarks>
		public const int KEYCODE_MEDIA_EJECT = 129;

		/// <summary>Key code constant: Record media key.</summary>
		/// <remarks>Key code constant: Record media key.</remarks>
		public const int KEYCODE_MEDIA_RECORD = 130;

		/// <summary>Key code constant: F1 key.</summary>
		/// <remarks>Key code constant: F1 key.</remarks>
		public const int KEYCODE_F1 = 131;

		/// <summary>Key code constant: F2 key.</summary>
		/// <remarks>Key code constant: F2 key.</remarks>
		public const int KEYCODE_F2 = 132;

		/// <summary>Key code constant: F3 key.</summary>
		/// <remarks>Key code constant: F3 key.</remarks>
		public const int KEYCODE_F3 = 133;

		/// <summary>Key code constant: F4 key.</summary>
		/// <remarks>Key code constant: F4 key.</remarks>
		public const int KEYCODE_F4 = 134;

		/// <summary>Key code constant: F5 key.</summary>
		/// <remarks>Key code constant: F5 key.</remarks>
		public const int KEYCODE_F5 = 135;

		/// <summary>Key code constant: F6 key.</summary>
		/// <remarks>Key code constant: F6 key.</remarks>
		public const int KEYCODE_F6 = 136;

		/// <summary>Key code constant: F7 key.</summary>
		/// <remarks>Key code constant: F7 key.</remarks>
		public const int KEYCODE_F7 = 137;

		/// <summary>Key code constant: F8 key.</summary>
		/// <remarks>Key code constant: F8 key.</remarks>
		public const int KEYCODE_F8 = 138;

		/// <summary>Key code constant: F9 key.</summary>
		/// <remarks>Key code constant: F9 key.</remarks>
		public const int KEYCODE_F9 = 139;

		/// <summary>Key code constant: F10 key.</summary>
		/// <remarks>Key code constant: F10 key.</remarks>
		public const int KEYCODE_F10 = 140;

		/// <summary>Key code constant: F11 key.</summary>
		/// <remarks>Key code constant: F11 key.</remarks>
		public const int KEYCODE_F11 = 141;

		/// <summary>Key code constant: F12 key.</summary>
		/// <remarks>Key code constant: F12 key.</remarks>
		public const int KEYCODE_F12 = 142;

		/// <summary>Key code constant: Num Lock key.</summary>
		/// <remarks>
		/// Key code constant: Num Lock key.
		/// This is the Num Lock key; it is different from
		/// <see cref="KEYCODE_NUM">KEYCODE_NUM</see>
		/// .
		/// This key alters the behavior of other keys on the numeric keypad.
		/// </remarks>
		public const int KEYCODE_NUM_LOCK = 143;

		/// <summary>Key code constant: Numeric keypad '0' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '0' key.</remarks>
		public const int KEYCODE_NUMPAD_0 = 144;

		/// <summary>Key code constant: Numeric keypad '1' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '1' key.</remarks>
		public const int KEYCODE_NUMPAD_1 = 145;

		/// <summary>Key code constant: Numeric keypad '2' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '2' key.</remarks>
		public const int KEYCODE_NUMPAD_2 = 146;

		/// <summary>Key code constant: Numeric keypad '3' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '3' key.</remarks>
		public const int KEYCODE_NUMPAD_3 = 147;

		/// <summary>Key code constant: Numeric keypad '4' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '4' key.</remarks>
		public const int KEYCODE_NUMPAD_4 = 148;

		/// <summary>Key code constant: Numeric keypad '5' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '5' key.</remarks>
		public const int KEYCODE_NUMPAD_5 = 149;

		/// <summary>Key code constant: Numeric keypad '6' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '6' key.</remarks>
		public const int KEYCODE_NUMPAD_6 = 150;

		/// <summary>Key code constant: Numeric keypad '7' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '7' key.</remarks>
		public const int KEYCODE_NUMPAD_7 = 151;

		/// <summary>Key code constant: Numeric keypad '8' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '8' key.</remarks>
		public const int KEYCODE_NUMPAD_8 = 152;

		/// <summary>Key code constant: Numeric keypad '9' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '9' key.</remarks>
		public const int KEYCODE_NUMPAD_9 = 153;

		/// <summary>Key code constant: Numeric keypad '/' key (for division).</summary>
		/// <remarks>Key code constant: Numeric keypad '/' key (for division).</remarks>
		public const int KEYCODE_NUMPAD_DIVIDE = 154;

		/// <summary>Key code constant: Numeric keypad '*' key (for multiplication).</summary>
		/// <remarks>Key code constant: Numeric keypad '*' key (for multiplication).</remarks>
		public const int KEYCODE_NUMPAD_MULTIPLY = 155;

		/// <summary>Key code constant: Numeric keypad '-' key (for subtraction).</summary>
		/// <remarks>Key code constant: Numeric keypad '-' key (for subtraction).</remarks>
		public const int KEYCODE_NUMPAD_SUBTRACT = 156;

		/// <summary>Key code constant: Numeric keypad '+' key (for addition).</summary>
		/// <remarks>Key code constant: Numeric keypad '+' key (for addition).</remarks>
		public const int KEYCODE_NUMPAD_ADD = 157;

		/// <summary>Key code constant: Numeric keypad '.' key (for decimals or digit grouping).
		/// 	</summary>
		/// <remarks>Key code constant: Numeric keypad '.' key (for decimals or digit grouping).
		/// 	</remarks>
		public const int KEYCODE_NUMPAD_DOT = 158;

		/// <summary>Key code constant: Numeric keypad ',' key (for decimals or digit grouping).
		/// 	</summary>
		/// <remarks>Key code constant: Numeric keypad ',' key (for decimals or digit grouping).
		/// 	</remarks>
		public const int KEYCODE_NUMPAD_COMMA = 159;

		/// <summary>Key code constant: Numeric keypad Enter key.</summary>
		/// <remarks>Key code constant: Numeric keypad Enter key.</remarks>
		public const int KEYCODE_NUMPAD_ENTER = 160;

		/// <summary>Key code constant: Numeric keypad '=' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '=' key.</remarks>
		public const int KEYCODE_NUMPAD_EQUALS = 161;

		/// <summary>Key code constant: Numeric keypad '(' key.</summary>
		/// <remarks>Key code constant: Numeric keypad '(' key.</remarks>
		public const int KEYCODE_NUMPAD_LEFT_PAREN = 162;

		/// <summary>Key code constant: Numeric keypad ')' key.</summary>
		/// <remarks>Key code constant: Numeric keypad ')' key.</remarks>
		public const int KEYCODE_NUMPAD_RIGHT_PAREN = 163;

		/// <summary>Key code constant: Volume Mute key.</summary>
		/// <remarks>
		/// Key code constant: Volume Mute key.
		/// Mutes the speaker, unlike
		/// <see cref="KEYCODE_MUTE">KEYCODE_MUTE</see>
		/// .
		/// This key should normally be implemented as a toggle such that the first press
		/// mutes the speaker and the second press restores the original volume.
		/// </remarks>
		public const int KEYCODE_VOLUME_MUTE = 164;

		/// <summary>Key code constant: Info key.</summary>
		/// <remarks>
		/// Key code constant: Info key.
		/// Common on TV remotes to show additional information related to what is
		/// currently being viewed.
		/// </remarks>
		public const int KEYCODE_INFO = 165;

		/// <summary>Key code constant: Channel up key.</summary>
		/// <remarks>
		/// Key code constant: Channel up key.
		/// On TV remotes, increments the television channel.
		/// </remarks>
		public const int KEYCODE_CHANNEL_UP = 166;

		/// <summary>Key code constant: Channel down key.</summary>
		/// <remarks>
		/// Key code constant: Channel down key.
		/// On TV remotes, decrements the television channel.
		/// </remarks>
		public const int KEYCODE_CHANNEL_DOWN = 167;

		/// <summary>Key code constant: Zoom in key.</summary>
		/// <remarks>Key code constant: Zoom in key.</remarks>
		public const int KEYCODE_ZOOM_IN = 168;

		/// <summary>Key code constant: Zoom out key.</summary>
		/// <remarks>Key code constant: Zoom out key.</remarks>
		public const int KEYCODE_ZOOM_OUT = 169;

		/// <summary>Key code constant: TV key.</summary>
		/// <remarks>
		/// Key code constant: TV key.
		/// On TV remotes, switches to viewing live TV.
		/// </remarks>
		public const int KEYCODE_TV = 170;

		/// <summary>Key code constant: Window key.</summary>
		/// <remarks>
		/// Key code constant: Window key.
		/// On TV remotes, toggles picture-in-picture mode or other windowing functions.
		/// </remarks>
		public const int KEYCODE_WINDOW = 171;

		/// <summary>Key code constant: Guide key.</summary>
		/// <remarks>
		/// Key code constant: Guide key.
		/// On TV remotes, shows a programming guide.
		/// </remarks>
		public const int KEYCODE_GUIDE = 172;

		/// <summary>Key code constant: DVR key.</summary>
		/// <remarks>
		/// Key code constant: DVR key.
		/// On some TV remotes, switches to a DVR mode for recorded shows.
		/// </remarks>
		public const int KEYCODE_DVR = 173;

		/// <summary>Key code constant: Bookmark key.</summary>
		/// <remarks>
		/// Key code constant: Bookmark key.
		/// On some TV remotes, bookmarks content or web pages.
		/// </remarks>
		public const int KEYCODE_BOOKMARK = 174;

		/// <summary>Key code constant: Toggle captions key.</summary>
		/// <remarks>
		/// Key code constant: Toggle captions key.
		/// Switches the mode for closed-captioning text, for example during television shows.
		/// </remarks>
		public const int KEYCODE_CAPTIONS = 175;

		/// <summary>Key code constant: Settings key.</summary>
		/// <remarks>
		/// Key code constant: Settings key.
		/// Starts the system settings activity.
		/// </remarks>
		public const int KEYCODE_SETTINGS = 176;

		/// <summary>Key code constant: TV power key.</summary>
		/// <remarks>
		/// Key code constant: TV power key.
		/// On TV remotes, toggles the power on a television screen.
		/// </remarks>
		public const int KEYCODE_TV_POWER = 177;

		/// <summary>Key code constant: TV input key.</summary>
		/// <remarks>
		/// Key code constant: TV input key.
		/// On TV remotes, switches the input on a television screen.
		/// </remarks>
		public const int KEYCODE_TV_INPUT = 178;

		/// <summary>Key code constant: Set-top-box power key.</summary>
		/// <remarks>
		/// Key code constant: Set-top-box power key.
		/// On TV remotes, toggles the power on an external Set-top-box.
		/// </remarks>
		public const int KEYCODE_STB_POWER = 179;

		/// <summary>Key code constant: Set-top-box input key.</summary>
		/// <remarks>
		/// Key code constant: Set-top-box input key.
		/// On TV remotes, switches the input mode on an external Set-top-box.
		/// </remarks>
		public const int KEYCODE_STB_INPUT = 180;

		/// <summary>Key code constant: A/V Receiver power key.</summary>
		/// <remarks>
		/// Key code constant: A/V Receiver power key.
		/// On TV remotes, toggles the power on an external A/V Receiver.
		/// </remarks>
		public const int KEYCODE_AVR_POWER = 181;

		/// <summary>Key code constant: A/V Receiver input key.</summary>
		/// <remarks>
		/// Key code constant: A/V Receiver input key.
		/// On TV remotes, switches the input mode on an external A/V Receiver.
		/// </remarks>
		public const int KEYCODE_AVR_INPUT = 182;

		/// <summary>Key code constant: Red "programmable" key.</summary>
		/// <remarks>
		/// Key code constant: Red "programmable" key.
		/// On TV remotes, acts as a contextual/programmable key.
		/// </remarks>
		public const int KEYCODE_PROG_RED = 183;

		/// <summary>Key code constant: Green "programmable" key.</summary>
		/// <remarks>
		/// Key code constant: Green "programmable" key.
		/// On TV remotes, actsas a contextual/programmable key.
		/// </remarks>
		public const int KEYCODE_PROG_GREEN = 184;

		/// <summary>Key code constant: Yellow "programmable" key.</summary>
		/// <remarks>
		/// Key code constant: Yellow "programmable" key.
		/// On TV remotes, acts as a contextual/programmable key.
		/// </remarks>
		public const int KEYCODE_PROG_YELLOW = 185;

		/// <summary>Key code constant: Blue "programmable" key.</summary>
		/// <remarks>
		/// Key code constant: Blue "programmable" key.
		/// On TV remotes, acts as a contextual/programmable key.
		/// </remarks>
		public const int KEYCODE_PROG_BLUE = 186;

		/// <summary>Key code constant: App switch key.</summary>
		/// <remarks>
		/// Key code constant: App switch key.
		/// Should bring up the application switcher dialog.
		/// </remarks>
		public const int KEYCODE_APP_SWITCH = 187;

		/// <summary>Key code constant: Generic Game Pad Button #1.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #1.</remarks>
		public const int KEYCODE_BUTTON_1 = 188;

		/// <summary>Key code constant: Generic Game Pad Button #2.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #2.</remarks>
		public const int KEYCODE_BUTTON_2 = 189;

		/// <summary>Key code constant: Generic Game Pad Button #3.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #3.</remarks>
		public const int KEYCODE_BUTTON_3 = 190;

		/// <summary>Key code constant: Generic Game Pad Button #4.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #4.</remarks>
		public const int KEYCODE_BUTTON_4 = 191;

		/// <summary>Key code constant: Generic Game Pad Button #5.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #5.</remarks>
		public const int KEYCODE_BUTTON_5 = 192;

		/// <summary>Key code constant: Generic Game Pad Button #6.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #6.</remarks>
		public const int KEYCODE_BUTTON_6 = 193;

		/// <summary>Key code constant: Generic Game Pad Button #7.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #7.</remarks>
		public const int KEYCODE_BUTTON_7 = 194;

		/// <summary>Key code constant: Generic Game Pad Button #8.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #8.</remarks>
		public const int KEYCODE_BUTTON_8 = 195;

		/// <summary>Key code constant: Generic Game Pad Button #9.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #9.</remarks>
		public const int KEYCODE_BUTTON_9 = 196;

		/// <summary>Key code constant: Generic Game Pad Button #10.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #10.</remarks>
		public const int KEYCODE_BUTTON_10 = 197;

		/// <summary>Key code constant: Generic Game Pad Button #11.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #11.</remarks>
		public const int KEYCODE_BUTTON_11 = 198;

		/// <summary>Key code constant: Generic Game Pad Button #12.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #12.</remarks>
		public const int KEYCODE_BUTTON_12 = 199;

		/// <summary>Key code constant: Generic Game Pad Button #13.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #13.</remarks>
		public const int KEYCODE_BUTTON_13 = 200;

		/// <summary>Key code constant: Generic Game Pad Button #14.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #14.</remarks>
		public const int KEYCODE_BUTTON_14 = 201;

		/// <summary>Key code constant: Generic Game Pad Button #15.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #15.</remarks>
		public const int KEYCODE_BUTTON_15 = 202;

		/// <summary>Key code constant: Generic Game Pad Button #16.</summary>
		/// <remarks>Key code constant: Generic Game Pad Button #16.</remarks>
		public const int KEYCODE_BUTTON_16 = 203;

		/// <summary>Key code constant: Language Switch key.</summary>
		/// <remarks>
		/// Key code constant: Language Switch key.
		/// Toggles the current input language such as switching between English and Japanese on
		/// a QWERTY keyboard.  On some devices, the same function may be performed by
		/// pressing Shift+Spacebar.
		/// </remarks>
		public const int KEYCODE_LANGUAGE_SWITCH = 204;

		/// <summary>Key code constant: Manner Mode key.</summary>
		/// <remarks>
		/// Key code constant: Manner Mode key.
		/// Toggles silent or vibrate mode on and off to make the device behave more politely
		/// in certain settings such as on a crowded train.  On some devices, the key may only
		/// operate when long-pressed.
		/// </remarks>
		public const int KEYCODE_MANNER_MODE = 205;

		/// <summary>Key code constant: 3D Mode key.</summary>
		/// <remarks>
		/// Key code constant: 3D Mode key.
		/// Toggles the display between 2D and 3D mode.
		/// </remarks>
		public const int KEYCODE_3D_MODE = 206;

		internal const int LAST_KEYCODE = KEYCODE_BUTTON_16;

		private static readonly android.util.SparseArray<string> KEYCODE_SYMBOLIC_NAMES = 
			new android.util.SparseArray<string>();

		// *Camera* focus
		// switch symbol-sets (Emoji,Kao-moji)
		// switch char-sets (Kanji,Katakana)
		// NOTE: If you add a new keycode here you must also add it to:
		//  isSystem()
		//  native/include/android/keycodes.h
		//  frameworks/base/include/ui/KeycodeLabels.h
		//  external/webkit/WebKit/android/plugins/ANPKeyCodes.h
		//  frameworks/base/core/res/res/values/attrs.xml
		//  emulator?
		//
		//  Also Android currently does not reserve code ranges for vendor-
		//  specific key codes.  If you have new key codes to have, you
		//  MUST contribute a patch to the open source project to define
		//  those new codes.  This is intended to maintain a consistent
		//  set of key code definitions across all Android devices.
		// Symbolic names of all key codes.
		private static void populateKeycodeSymbolicNames()
		{
			android.util.SparseArray<string> names = KEYCODE_SYMBOLIC_NAMES;
			names.append(KEYCODE_UNKNOWN, "KEYCODE_UNKNOWN");
			names.append(KEYCODE_SOFT_LEFT, "KEYCODE_SOFT_LEFT");
			names.append(KEYCODE_SOFT_RIGHT, "KEYCODE_SOFT_RIGHT");
			names.append(KEYCODE_HOME, "KEYCODE_HOME");
			names.append(KEYCODE_BACK, "KEYCODE_BACK");
			names.append(KEYCODE_CALL, "KEYCODE_CALL");
			names.append(KEYCODE_ENDCALL, "KEYCODE_ENDCALL");
			names.append(KEYCODE_0, "KEYCODE_0");
			names.append(KEYCODE_1, "KEYCODE_1");
			names.append(KEYCODE_2, "KEYCODE_2");
			names.append(KEYCODE_3, "KEYCODE_3");
			names.append(KEYCODE_4, "KEYCODE_4");
			names.append(KEYCODE_5, "KEYCODE_5");
			names.append(KEYCODE_6, "KEYCODE_6");
			names.append(KEYCODE_7, "KEYCODE_7");
			names.append(KEYCODE_8, "KEYCODE_8");
			names.append(KEYCODE_9, "KEYCODE_9");
			names.append(KEYCODE_STAR, "KEYCODE_STAR");
			names.append(KEYCODE_POUND, "KEYCODE_POUND");
			names.append(KEYCODE_DPAD_UP, "KEYCODE_DPAD_UP");
			names.append(KEYCODE_DPAD_DOWN, "KEYCODE_DPAD_DOWN");
			names.append(KEYCODE_DPAD_LEFT, "KEYCODE_DPAD_LEFT");
			names.append(KEYCODE_DPAD_RIGHT, "KEYCODE_DPAD_RIGHT");
			names.append(KEYCODE_DPAD_CENTER, "KEYCODE_DPAD_CENTER");
			names.append(KEYCODE_VOLUME_UP, "KEYCODE_VOLUME_UP");
			names.append(KEYCODE_VOLUME_DOWN, "KEYCODE_VOLUME_DOWN");
			names.append(KEYCODE_POWER, "KEYCODE_POWER");
			names.append(KEYCODE_CAMERA, "KEYCODE_CAMERA");
			names.append(KEYCODE_CLEAR, "KEYCODE_CLEAR");
			names.append(KEYCODE_A, "KEYCODE_A");
			names.append(KEYCODE_B, "KEYCODE_B");
			names.append(KEYCODE_C, "KEYCODE_C");
			names.append(KEYCODE_D, "KEYCODE_D");
			names.append(KEYCODE_E, "KEYCODE_E");
			names.append(KEYCODE_F, "KEYCODE_F");
			names.append(KEYCODE_G, "KEYCODE_G");
			names.append(KEYCODE_H, "KEYCODE_H");
			names.append(KEYCODE_I, "KEYCODE_I");
			names.append(KEYCODE_J, "KEYCODE_J");
			names.append(KEYCODE_K, "KEYCODE_K");
			names.append(KEYCODE_L, "KEYCODE_L");
			names.append(KEYCODE_M, "KEYCODE_M");
			names.append(KEYCODE_N, "KEYCODE_N");
			names.append(KEYCODE_O, "KEYCODE_O");
			names.append(KEYCODE_P, "KEYCODE_P");
			names.append(KEYCODE_Q, "KEYCODE_Q");
			names.append(KEYCODE_R, "KEYCODE_R");
			names.append(KEYCODE_S, "KEYCODE_S");
			names.append(KEYCODE_T, "KEYCODE_T");
			names.append(KEYCODE_U, "KEYCODE_U");
			names.append(KEYCODE_V, "KEYCODE_V");
			names.append(KEYCODE_W, "KEYCODE_W");
			names.append(KEYCODE_X, "KEYCODE_X");
			names.append(KEYCODE_Y, "KEYCODE_Y");
			names.append(KEYCODE_Z, "KEYCODE_Z");
			names.append(KEYCODE_COMMA, "KEYCODE_COMMA");
			names.append(KEYCODE_PERIOD, "KEYCODE_PERIOD");
			names.append(KEYCODE_ALT_LEFT, "KEYCODE_ALT_LEFT");
			names.append(KEYCODE_ALT_RIGHT, "KEYCODE_ALT_RIGHT");
			names.append(KEYCODE_SHIFT_LEFT, "KEYCODE_SHIFT_LEFT");
			names.append(KEYCODE_SHIFT_RIGHT, "KEYCODE_SHIFT_RIGHT");
			names.append(KEYCODE_TAB, "KEYCODE_TAB");
			names.append(KEYCODE_SPACE, "KEYCODE_SPACE");
			names.append(KEYCODE_SYM, "KEYCODE_SYM");
			names.append(KEYCODE_EXPLORER, "KEYCODE_EXPLORER");
			names.append(KEYCODE_ENVELOPE, "KEYCODE_ENVELOPE");
			names.append(KEYCODE_ENTER, "KEYCODE_ENTER");
			names.append(KEYCODE_DEL, "KEYCODE_DEL");
			names.append(KEYCODE_GRAVE, "KEYCODE_GRAVE");
			names.append(KEYCODE_MINUS, "KEYCODE_MINUS");
			names.append(KEYCODE_EQUALS, "KEYCODE_EQUALS");
			names.append(KEYCODE_LEFT_BRACKET, "KEYCODE_LEFT_BRACKET");
			names.append(KEYCODE_RIGHT_BRACKET, "KEYCODE_RIGHT_BRACKET");
			names.append(KEYCODE_BACKSLASH, "KEYCODE_BACKSLASH");
			names.append(KEYCODE_SEMICOLON, "KEYCODE_SEMICOLON");
			names.append(KEYCODE_APOSTROPHE, "KEYCODE_APOSTROPHE");
			names.append(KEYCODE_SLASH, "KEYCODE_SLASH");
			names.append(KEYCODE_AT, "KEYCODE_AT");
			names.append(KEYCODE_NUM, "KEYCODE_NUM");
			names.append(KEYCODE_HEADSETHOOK, "KEYCODE_HEADSETHOOK");
			names.append(KEYCODE_FOCUS, "KEYCODE_FOCUS");
			names.append(KEYCODE_PLUS, "KEYCODE_PLUS");
			names.append(KEYCODE_MENU, "KEYCODE_MENU");
			names.append(KEYCODE_NOTIFICATION, "KEYCODE_NOTIFICATION");
			names.append(KEYCODE_SEARCH, "KEYCODE_SEARCH");
			names.append(KEYCODE_MEDIA_PLAY_PAUSE, "KEYCODE_MEDIA_PLAY_PAUSE");
			names.append(KEYCODE_MEDIA_STOP, "KEYCODE_MEDIA_STOP");
			names.append(KEYCODE_MEDIA_NEXT, "KEYCODE_MEDIA_NEXT");
			names.append(KEYCODE_MEDIA_PREVIOUS, "KEYCODE_MEDIA_PREVIOUS");
			names.append(KEYCODE_MEDIA_REWIND, "KEYCODE_MEDIA_REWIND");
			names.append(KEYCODE_MEDIA_FAST_FORWARD, "KEYCODE_MEDIA_FAST_FORWARD");
			names.append(KEYCODE_MUTE, "KEYCODE_MUTE");
			names.append(KEYCODE_PAGE_UP, "KEYCODE_PAGE_UP");
			names.append(KEYCODE_PAGE_DOWN, "KEYCODE_PAGE_DOWN");
			names.append(KEYCODE_PICTSYMBOLS, "KEYCODE_PICTSYMBOLS");
			names.append(KEYCODE_SWITCH_CHARSET, "KEYCODE_SWITCH_CHARSET");
			names.append(KEYCODE_BUTTON_A, "KEYCODE_BUTTON_A");
			names.append(KEYCODE_BUTTON_B, "KEYCODE_BUTTON_B");
			names.append(KEYCODE_BUTTON_C, "KEYCODE_BUTTON_C");
			names.append(KEYCODE_BUTTON_X, "KEYCODE_BUTTON_X");
			names.append(KEYCODE_BUTTON_Y, "KEYCODE_BUTTON_Y");
			names.append(KEYCODE_BUTTON_Z, "KEYCODE_BUTTON_Z");
			names.append(KEYCODE_BUTTON_L1, "KEYCODE_BUTTON_L1");
			names.append(KEYCODE_BUTTON_R1, "KEYCODE_BUTTON_R1");
			names.append(KEYCODE_BUTTON_L2, "KEYCODE_BUTTON_L2");
			names.append(KEYCODE_BUTTON_R2, "KEYCODE_BUTTON_R2");
			names.append(KEYCODE_BUTTON_THUMBL, "KEYCODE_BUTTON_THUMBL");
			names.append(KEYCODE_BUTTON_THUMBR, "KEYCODE_BUTTON_THUMBR");
			names.append(KEYCODE_BUTTON_START, "KEYCODE_BUTTON_START");
			names.append(KEYCODE_BUTTON_SELECT, "KEYCODE_BUTTON_SELECT");
			names.append(KEYCODE_BUTTON_MODE, "KEYCODE_BUTTON_MODE");
			names.append(KEYCODE_ESCAPE, "KEYCODE_ESCAPE");
			names.append(KEYCODE_FORWARD_DEL, "KEYCODE_FORWARD_DEL");
			names.append(KEYCODE_CTRL_LEFT, "KEYCODE_CTRL_LEFT");
			names.append(KEYCODE_CTRL_RIGHT, "KEYCODE_CTRL_RIGHT");
			names.append(KEYCODE_CAPS_LOCK, "KEYCODE_CAPS_LOCK");
			names.append(KEYCODE_SCROLL_LOCK, "KEYCODE_SCROLL_LOCK");
			names.append(KEYCODE_META_LEFT, "KEYCODE_META_LEFT");
			names.append(KEYCODE_META_RIGHT, "KEYCODE_META_RIGHT");
			names.append(KEYCODE_FUNCTION, "KEYCODE_FUNCTION");
			names.append(KEYCODE_SYSRQ, "KEYCODE_SYSRQ");
			names.append(KEYCODE_BREAK, "KEYCODE_BREAK");
			names.append(KEYCODE_MOVE_HOME, "KEYCODE_MOVE_HOME");
			names.append(KEYCODE_MOVE_END, "KEYCODE_MOVE_END");
			names.append(KEYCODE_INSERT, "KEYCODE_INSERT");
			names.append(KEYCODE_FORWARD, "KEYCODE_FORWARD");
			names.append(KEYCODE_MEDIA_PLAY, "KEYCODE_MEDIA_PLAY");
			names.append(KEYCODE_MEDIA_PAUSE, "KEYCODE_MEDIA_PAUSE");
			names.append(KEYCODE_MEDIA_CLOSE, "KEYCODE_MEDIA_CLOSE");
			names.append(KEYCODE_MEDIA_EJECT, "KEYCODE_MEDIA_EJECT");
			names.append(KEYCODE_MEDIA_RECORD, "KEYCODE_MEDIA_RECORD");
			names.append(KEYCODE_F1, "KEYCODE_F1");
			names.append(KEYCODE_F2, "KEYCODE_F2");
			names.append(KEYCODE_F3, "KEYCODE_F3");
			names.append(KEYCODE_F4, "KEYCODE_F4");
			names.append(KEYCODE_F5, "KEYCODE_F5");
			names.append(KEYCODE_F6, "KEYCODE_F6");
			names.append(KEYCODE_F7, "KEYCODE_F7");
			names.append(KEYCODE_F8, "KEYCODE_F8");
			names.append(KEYCODE_F9, "KEYCODE_F9");
			names.append(KEYCODE_F10, "KEYCODE_F10");
			names.append(KEYCODE_F11, "KEYCODE_F11");
			names.append(KEYCODE_F12, "KEYCODE_F12");
			names.append(KEYCODE_NUM_LOCK, "KEYCODE_NUM_LOCK");
			names.append(KEYCODE_NUMPAD_0, "KEYCODE_NUMPAD_0");
			names.append(KEYCODE_NUMPAD_1, "KEYCODE_NUMPAD_1");
			names.append(KEYCODE_NUMPAD_2, "KEYCODE_NUMPAD_2");
			names.append(KEYCODE_NUMPAD_3, "KEYCODE_NUMPAD_3");
			names.append(KEYCODE_NUMPAD_4, "KEYCODE_NUMPAD_4");
			names.append(KEYCODE_NUMPAD_5, "KEYCODE_NUMPAD_5");
			names.append(KEYCODE_NUMPAD_6, "KEYCODE_NUMPAD_6");
			names.append(KEYCODE_NUMPAD_7, "KEYCODE_NUMPAD_7");
			names.append(KEYCODE_NUMPAD_8, "KEYCODE_NUMPAD_8");
			names.append(KEYCODE_NUMPAD_9, "KEYCODE_NUMPAD_9");
			names.append(KEYCODE_NUMPAD_DIVIDE, "KEYCODE_NUMPAD_DIVIDE");
			names.append(KEYCODE_NUMPAD_MULTIPLY, "KEYCODE_NUMPAD_MULTIPLY");
			names.append(KEYCODE_NUMPAD_SUBTRACT, "KEYCODE_NUMPAD_SUBTRACT");
			names.append(KEYCODE_NUMPAD_ADD, "KEYCODE_NUMPAD_ADD");
			names.append(KEYCODE_NUMPAD_DOT, "KEYCODE_NUMPAD_DOT");
			names.append(KEYCODE_NUMPAD_COMMA, "KEYCODE_NUMPAD_COMMA");
			names.append(KEYCODE_NUMPAD_ENTER, "KEYCODE_NUMPAD_ENTER");
			names.append(KEYCODE_NUMPAD_EQUALS, "KEYCODE_NUMPAD_EQUALS");
			names.append(KEYCODE_NUMPAD_LEFT_PAREN, "KEYCODE_NUMPAD_LEFT_PAREN");
			names.append(KEYCODE_NUMPAD_RIGHT_PAREN, "KEYCODE_NUMPAD_RIGHT_PAREN");
			names.append(KEYCODE_VOLUME_MUTE, "KEYCODE_VOLUME_MUTE");
			names.append(KEYCODE_INFO, "KEYCODE_INFO");
			names.append(KEYCODE_CHANNEL_UP, "KEYCODE_CHANNEL_UP");
			names.append(KEYCODE_CHANNEL_DOWN, "KEYCODE_CHANNEL_DOWN");
			names.append(KEYCODE_ZOOM_IN, "KEYCODE_ZOOM_IN");
			names.append(KEYCODE_ZOOM_OUT, "KEYCODE_ZOOM_OUT");
			names.append(KEYCODE_TV, "KEYCODE_TV");
			names.append(KEYCODE_WINDOW, "KEYCODE_WINDOW");
			names.append(KEYCODE_GUIDE, "KEYCODE_GUIDE");
			names.append(KEYCODE_DVR, "KEYCODE_DVR");
			names.append(KEYCODE_BOOKMARK, "KEYCODE_BOOKMARK");
			names.append(KEYCODE_CAPTIONS, "KEYCODE_CAPTIONS");
			names.append(KEYCODE_SETTINGS, "KEYCODE_SETTINGS");
			names.append(KEYCODE_TV_POWER, "KEYCODE_TV_POWER");
			names.append(KEYCODE_TV_INPUT, "KEYCODE_TV_INPUT");
			names.append(KEYCODE_STB_INPUT, "KEYCODE_STB_INPUT");
			names.append(KEYCODE_STB_POWER, "KEYCODE_STB_POWER");
			names.append(KEYCODE_AVR_POWER, "KEYCODE_AVR_POWER");
			names.append(KEYCODE_AVR_INPUT, "KEYCODE_AVR_INPUT");
			names.append(KEYCODE_PROG_RED, "KEYCODE_PROG_RED");
			names.append(KEYCODE_PROG_GREEN, "KEYCODE_PROG_GREEN");
			names.append(KEYCODE_PROG_YELLOW, "KEYCODE_PROG_YELLOW");
			names.append(KEYCODE_PROG_BLUE, "KEYCODE_PROG_BLUE");
			names.append(KEYCODE_APP_SWITCH, "KEYCODE_APP_SWITCH");
			names.append(KEYCODE_BUTTON_1, "KEYCODE_BUTTON_1");
			names.append(KEYCODE_BUTTON_2, "KEYCODE_BUTTON_2");
			names.append(KEYCODE_BUTTON_3, "KEYCODE_BUTTON_3");
			names.append(KEYCODE_BUTTON_4, "KEYCODE_BUTTON_4");
			names.append(KEYCODE_BUTTON_5, "KEYCODE_BUTTON_5");
			names.append(KEYCODE_BUTTON_6, "KEYCODE_BUTTON_6");
			names.append(KEYCODE_BUTTON_7, "KEYCODE_BUTTON_7");
			names.append(KEYCODE_BUTTON_8, "KEYCODE_BUTTON_8");
			names.append(KEYCODE_BUTTON_9, "KEYCODE_BUTTON_9");
			names.append(KEYCODE_BUTTON_10, "KEYCODE_BUTTON_10");
			names.append(KEYCODE_BUTTON_11, "KEYCODE_BUTTON_11");
			names.append(KEYCODE_BUTTON_12, "KEYCODE_BUTTON_12");
			names.append(KEYCODE_BUTTON_13, "KEYCODE_BUTTON_13");
			names.append(KEYCODE_BUTTON_14, "KEYCODE_BUTTON_14");
			names.append(KEYCODE_BUTTON_15, "KEYCODE_BUTTON_15");
			names.append(KEYCODE_BUTTON_16, "KEYCODE_BUTTON_16");
			names.append(KEYCODE_LANGUAGE_SWITCH, "KEYCODE_LANGUAGE_SWITCH");
			names.append(KEYCODE_MANNER_MODE, "KEYCODE_MANNER_MODE");
			names.append(KEYCODE_3D_MODE, "KEYCODE_3D_MODE");
		}

		private static readonly string[] META_SYMBOLIC_NAMES = new string[] { "META_SHIFT_ON"
			, "META_ALT_ON", "META_SYM_ON", "META_FUNCTION_ON", "META_ALT_LEFT_ON", "META_ALT_RIGHT_ON"
			, "META_SHIFT_LEFT_ON", "META_SHIFT_RIGHT_ON", "META_CAP_LOCKED", "META_ALT_LOCKED"
			, "META_SYM_LOCKED", "0x00000800", "META_CTRL_ON", "META_CTRL_LEFT_ON", "META_CTRL_RIGHT_ON"
			, "0x00008000", "META_META_ON", "META_META_LEFT_ON", "META_META_RIGHT_ON", "0x00080000"
			, "META_CAPS_LOCK_ON", "META_NUM_LOCK_ON", "META_SCROLL_LOCK_ON", "0x00800000", 
			"0x01000000", "0x02000000", "0x04000000", "0x08000000", "0x10000000", "0x20000000"
			, "0x40000000", "0x80000000" };

		[System.ObsoleteAttribute(@"There are now more than MAX_KEYCODE keycodes. Use getMaxKeyCode() instead."
			)]
		public const int MAX_KEYCODE = 84;

		/// <summary>
		/// <see cref="getAction()">getAction()</see>
		/// value: the key has been pressed down.
		/// </summary>
		public const int ACTION_DOWN = 0;

		/// <summary>
		/// <see cref="getAction()">getAction()</see>
		/// value: the key has been released.
		/// </summary>
		public const int ACTION_UP = 1;

		/// <summary>
		/// <see cref="getAction()">getAction()</see>
		/// value: multiple duplicate key events have
		/// occurred in a row, or a complex string is being delivered.  If the
		/// key code is not {#link
		/// <see cref="KEYCODE_UNKNOWN">KEYCODE_UNKNOWN</see>
		/// then the
		/// {#link
		/// <see cref="getRepeatCount()">getRepeatCount()</see>
		/// method returns the number of times
		/// the given key code should be executed.
		/// Otherwise, if the key code is
		/// <see cref="KEYCODE_UNKNOWN">KEYCODE_UNKNOWN</see>
		/// , then
		/// this is a sequence of characters as returned by
		/// <see cref="getCharacters()">getCharacters()</see>
		/// .
		/// </summary>
		public const int ACTION_MULTIPLE = 2;

		/// <summary>SHIFT key locked in CAPS mode.</summary>
		/// <remarks>
		/// SHIFT key locked in CAPS mode.
		/// Reserved for use by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// for a published constant in its API.
		/// </remarks>
		/// <hide></hide>
		public const int META_CAP_LOCKED = unchecked((int)(0x100));

		/// <summary>ALT key locked.</summary>
		/// <remarks>
		/// ALT key locked.
		/// Reserved for use by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// for a published constant in its API.
		/// </remarks>
		/// <hide></hide>
		public const int META_ALT_LOCKED = unchecked((int)(0x200));

		/// <summary>SYM key locked.</summary>
		/// <remarks>
		/// SYM key locked.
		/// Reserved for use by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// for a published constant in its API.
		/// </remarks>
		/// <hide></hide>
		public const int META_SYM_LOCKED = unchecked((int)(0x400));

		/// <summary>Text is in selection mode.</summary>
		/// <remarks>
		/// Text is in selection mode.
		/// Reserved for use by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// for a private unpublished constant
		/// in its API that is currently being retained for legacy reasons.
		/// </remarks>
		/// <hide></hide>
		public const int META_SELECTING = unchecked((int)(0x800));

		/// <summary><p>This mask is used to check whether one of the ALT meta keys is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isAltPressed()">isAltPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_ALT_LEFT">KEYCODE_ALT_LEFT</seealso>
		/// <seealso cref="KEYCODE_ALT_RIGHT">KEYCODE_ALT_RIGHT</seealso>
		public const int META_ALT_ON = unchecked((int)(0x02));

		/// <summary><p>This mask is used to check whether the left ALT meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isAltPressed()">isAltPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_ALT_LEFT">KEYCODE_ALT_LEFT</seealso>
		public const int META_ALT_LEFT_ON = unchecked((int)(0x10));

		/// <summary><p>This mask is used to check whether the right the ALT meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isAltPressed()">isAltPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_ALT_RIGHT">KEYCODE_ALT_RIGHT</seealso>
		public const int META_ALT_RIGHT_ON = unchecked((int)(0x20));

		/// <summary><p>This mask is used to check whether one of the SHIFT meta keys is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isShiftPressed()">isShiftPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_SHIFT_LEFT">KEYCODE_SHIFT_LEFT</seealso>
		/// <seealso cref="KEYCODE_SHIFT_RIGHT">KEYCODE_SHIFT_RIGHT</seealso>
		public const int META_SHIFT_ON = unchecked((int)(0x1));

		/// <summary><p>This mask is used to check whether the left SHIFT meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isShiftPressed()">isShiftPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_SHIFT_LEFT">KEYCODE_SHIFT_LEFT</seealso>
		public const int META_SHIFT_LEFT_ON = unchecked((int)(0x40));

		/// <summary><p>This mask is used to check whether the right SHIFT meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isShiftPressed()">isShiftPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_SHIFT_RIGHT">KEYCODE_SHIFT_RIGHT</seealso>
		public const int META_SHIFT_RIGHT_ON = unchecked((int)(0x80));

		/// <summary><p>This mask is used to check whether the SYM meta key is pressed.</p></summary>
		/// <seealso cref="isSymPressed()">isSymPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		public const int META_SYM_ON = unchecked((int)(0x4));

		/// <summary><p>This mask is used to check whether the FUNCTION meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isFunctionPressed()">isFunctionPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		public const int META_FUNCTION_ON = unchecked((int)(0x8));

		/// <summary><p>This mask is used to check whether one of the CTRL meta keys is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isCtrlPressed()">isCtrlPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_CTRL_LEFT">KEYCODE_CTRL_LEFT</seealso>
		/// <seealso cref="KEYCODE_CTRL_RIGHT">KEYCODE_CTRL_RIGHT</seealso>
		public const int META_CTRL_ON = unchecked((int)(0x1000));

		/// <summary><p>This mask is used to check whether the left CTRL meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isCtrlPressed()">isCtrlPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_CTRL_LEFT">KEYCODE_CTRL_LEFT</seealso>
		public const int META_CTRL_LEFT_ON = unchecked((int)(0x2000));

		/// <summary><p>This mask is used to check whether the right CTRL meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isCtrlPressed()">isCtrlPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_CTRL_RIGHT">KEYCODE_CTRL_RIGHT</seealso>
		public const int META_CTRL_RIGHT_ON = unchecked((int)(0x4000));

		/// <summary><p>This mask is used to check whether one of the META meta keys is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isMetaPressed()">isMetaPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_META_LEFT">KEYCODE_META_LEFT</seealso>
		/// <seealso cref="KEYCODE_META_RIGHT">KEYCODE_META_RIGHT</seealso>
		public const int META_META_ON = unchecked((int)(0x10000));

		/// <summary><p>This mask is used to check whether the left META meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isMetaPressed()">isMetaPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_META_LEFT">KEYCODE_META_LEFT</seealso>
		public const int META_META_LEFT_ON = unchecked((int)(0x20000));

		/// <summary><p>This mask is used to check whether the right META meta key is pressed.</p>
		/// 	</summary>
		/// <seealso cref="isMetaPressed()">isMetaPressed()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_META_RIGHT">KEYCODE_META_RIGHT</seealso>
		public const int META_META_RIGHT_ON = unchecked((int)(0x40000));

		/// <summary><p>This mask is used to check whether the CAPS LOCK meta key is on.</p></summary>
		/// <seealso cref="isCapsLockOn()">isCapsLockOn()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</seealso>
		public const int META_CAPS_LOCK_ON = unchecked((int)(0x100000));

		/// <summary><p>This mask is used to check whether the NUM LOCK meta key is on.</p></summary>
		/// <seealso cref="isNumLockOn()">isNumLockOn()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</seealso>
		public const int META_NUM_LOCK_ON = unchecked((int)(0x200000));

		/// <summary><p>This mask is used to check whether the SCROLL LOCK meta key is on.</p>
		/// 	</summary>
		/// <seealso cref="isScrollLockOn()">isScrollLockOn()</seealso>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		/// <seealso cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</seealso>
		public const int META_SCROLL_LOCK_ON = unchecked((int)(0x400000));

		/// <summary>
		/// This mask is a combination of
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// ,
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// and
		/// <see cref="META_SHIFT_RIGHT_ON">META_SHIFT_RIGHT_ON</see>
		/// .
		/// </summary>
		public const int META_SHIFT_MASK = META_SHIFT_ON | META_SHIFT_LEFT_ON | META_SHIFT_RIGHT_ON;

		/// <summary>
		/// This mask is a combination of
		/// <see cref="META_ALT_ON">META_ALT_ON</see>
		/// ,
		/// <see cref="META_ALT_LEFT_ON">META_ALT_LEFT_ON</see>
		/// and
		/// <see cref="META_ALT_RIGHT_ON">META_ALT_RIGHT_ON</see>
		/// .
		/// </summary>
		public const int META_ALT_MASK = META_ALT_ON | META_ALT_LEFT_ON | META_ALT_RIGHT_ON;

		/// <summary>
		/// This mask is a combination of
		/// <see cref="META_CTRL_ON">META_CTRL_ON</see>
		/// ,
		/// <see cref="META_CTRL_LEFT_ON">META_CTRL_LEFT_ON</see>
		/// and
		/// <see cref="META_CTRL_RIGHT_ON">META_CTRL_RIGHT_ON</see>
		/// .
		/// </summary>
		public const int META_CTRL_MASK = META_CTRL_ON | META_CTRL_LEFT_ON | META_CTRL_RIGHT_ON;

		/// <summary>
		/// This mask is a combination of
		/// <see cref="META_META_ON">META_META_ON</see>
		/// ,
		/// <see cref="META_META_LEFT_ON">META_META_LEFT_ON</see>
		/// and
		/// <see cref="META_META_RIGHT_ON">META_META_RIGHT_ON</see>
		/// .
		/// </summary>
		public const int META_META_MASK = META_META_ON | META_META_LEFT_ON | META_META_RIGHT_ON;

		/// <summary>This mask is set if the device woke because of this key event.</summary>
		/// <remarks>This mask is set if the device woke because of this key event.</remarks>
		public const int FLAG_WOKE_HERE = unchecked((int)(0x1));

		/// <summary>This mask is set if the key event was generated by a software keyboard.</summary>
		/// <remarks>This mask is set if the key event was generated by a software keyboard.</remarks>
		public const int FLAG_SOFT_KEYBOARD = unchecked((int)(0x2));

		/// <summary>
		/// This mask is set if we don't want the key event to cause us to leave
		/// touch mode.
		/// </summary>
		/// <remarks>
		/// This mask is set if we don't want the key event to cause us to leave
		/// touch mode.
		/// </remarks>
		public const int FLAG_KEEP_TOUCH_MODE = unchecked((int)(0x4));

		/// <summary>
		/// This mask is set if an event was known to come from a trusted part
		/// of the system.
		/// </summary>
		/// <remarks>
		/// This mask is set if an event was known to come from a trusted part
		/// of the system.  That is, the event is known to come from the user,
		/// and could not have been spoofed by a third party component.
		/// </remarks>
		public const int FLAG_FROM_SYSTEM = unchecked((int)(0x8));

		/// <summary>
		/// This mask is used for compatibility, to identify enter keys that are
		/// coming from an IME whose enter key has been auto-labelled "next" or
		/// "done".
		/// </summary>
		/// <remarks>
		/// This mask is used for compatibility, to identify enter keys that are
		/// coming from an IME whose enter key has been auto-labelled "next" or
		/// "done".  This allows TextView to dispatch these as normal enter keys
		/// for old applications, but still do the appropriate action when
		/// receiving them.
		/// </remarks>
		public const int FLAG_EDITOR_ACTION = unchecked((int)(0x10));

		/// <summary>
		/// When associated with up key events, this indicates that the key press
		/// has been canceled.
		/// </summary>
		/// <remarks>
		/// When associated with up key events, this indicates that the key press
		/// has been canceled.  Typically this is used with virtual touch screen
		/// keys, where the user can slide from the virtual key area on to the
		/// display: in that case, the application will receive a canceled up
		/// event and should not perform the action normally associated with the
		/// key.  Note that for this to work, the application can not perform an
		/// action for a key until it receives an up or the long press timeout has
		/// expired.
		/// </remarks>
		public const int FLAG_CANCELED = unchecked((int)(0x20));

		/// <summary>This key event was generated by a virtual (on-screen) hard key area.</summary>
		/// <remarks>
		/// This key event was generated by a virtual (on-screen) hard key area.
		/// Typically this is an area of the touchscreen, outside of the regular
		/// display, dedicated to "hardware" buttons.
		/// </remarks>
		public const int FLAG_VIRTUAL_HARD_KEY = unchecked((int)(0x40));

		/// <summary>
		/// This flag is set for the first key repeat that occurs after the
		/// long press timeout.
		/// </summary>
		/// <remarks>
		/// This flag is set for the first key repeat that occurs after the
		/// long press timeout.
		/// </remarks>
		public const int FLAG_LONG_PRESS = unchecked((int)(0x80));

		/// <summary>
		/// Set when a key event has
		/// <see cref="FLAG_CANCELED">FLAG_CANCELED</see>
		/// set because a long
		/// press action was executed while it was down.
		/// </summary>
		public const int FLAG_CANCELED_LONG_PRESS = unchecked((int)(0x100));

		/// <summary>
		/// Set for
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// when this event's key code is still being
		/// tracked from its initial down.  That is, somebody requested that tracking
		/// started on the key down and a long press has not caused
		/// the tracking to be canceled.
		/// </summary>
		public const int FLAG_TRACKING = unchecked((int)(0x200));

		/// <summary>
		/// Set when a key event has been synthesized to implement default behavior
		/// for an event that the application did not handle.
		/// </summary>
		/// <remarks>
		/// Set when a key event has been synthesized to implement default behavior
		/// for an event that the application did not handle.
		/// Fallback key events are generated by unhandled trackball motions
		/// (to emulate a directional keypad) and by certain unhandled key presses
		/// that are declared in the key map (such as special function numeric keypad
		/// keys when numlock is off).
		/// </remarks>
		public const int FLAG_FALLBACK = unchecked((int)(0x400));

		/// <summary>Private control to determine when an app is tracking a key sequence.</summary>
		/// <remarks>Private control to determine when an app is tracking a key sequence.</remarks>
		/// <hide></hide>
		public const int FLAG_START_TRACKING = unchecked((int)(0x40000000));

		/// <summary>
		/// Private flag that indicates when the system has detected that this key event
		/// may be inconsistent with respect to the sequence of previously delivered key events,
		/// such as when a key up event is sent but the key was not down.
		/// </summary>
		/// <remarks>
		/// Private flag that indicates when the system has detected that this key event
		/// may be inconsistent with respect to the sequence of previously delivered key events,
		/// such as when a key up event is sent but the key was not down.
		/// </remarks>
		/// <hide></hide>
		/// <seealso cref="isTainted()">isTainted()</seealso>
		/// <seealso cref="setTainted(bool)">setTainted(bool)</seealso>
		public const int FLAG_TAINTED = unchecked((int)(0x80000000));

		// Symbolic names of all metakeys in bit order from least significant to most significant.
		// Accordingly there are exactly 32 values in this table.
		/// <summary>Returns the maximum keycode.</summary>
		/// <remarks>Returns the maximum keycode.</remarks>
		public static int getMaxKeyCode()
		{
			return LAST_KEYCODE;
		}

		/// <summary>
		/// Get the character that is produced by putting accent on the character
		/// c.
		/// </summary>
		/// <remarks>
		/// Get the character that is produced by putting accent on the character
		/// c.
		/// For example, getDeadChar('`', 'e') returns &egrave;.
		/// </remarks>
		public static int getDeadChar(int accent, int c)
		{
			return android.view.KeyCharacterMap.getDeadChar(accent, c);
		}

		internal const bool DEBUG = false;

		internal const string TAG = "KeyEvent";

		internal const int MAX_RECYCLED = 10;

		private static readonly object gRecyclerLock = new object();

		private static int gRecyclerUsed;

		private static android.view.KeyEvent gRecyclerTop;

		private android.view.KeyEvent mNext;

		private bool mRecycled;

		private int mDeviceId;

		private int mSource;

		private int mMetaState;

		private int mAction;

		private int mKeyCode;

		private int mScanCode;

		private int mRepeatCount;

		private int mFlags;

		private long mDownTime;

		private long mEventTime;

		private string mCharacters;

		public interface Callback
		{
			/// <summary>Called when a key down event has occurred.</summary>
			/// <remarks>
			/// Called when a key down event has occurred.  If you return true,
			/// you can first call
			/// <see cref="KeyEvent.startTracking()">KeyEvent.startTracking()</see>
			/// to have the framework track the event
			/// through its
			/// <see cref="onKeyUp(int, KeyEvent)">onKeyUp(int, KeyEvent)</see>
			/// and also call your
			/// <see cref="onKeyLongPress(int, KeyEvent)">onKeyLongPress(int, KeyEvent)</see>
			/// if it occurs.
			/// </remarks>
			/// <param name="keyCode">The value in event.getKeyCode().</param>
			/// <param name="event">Description of the key event.</param>
			/// <returns>
			/// If you handled the event, return true.  If you want to allow
			/// the event to be handled by the next receiver, return false.
			/// </returns>
			bool onKeyDown(int keyCode, android.view.KeyEvent @event);

			/// <summary>Called when a long press has occurred.</summary>
			/// <remarks>
			/// Called when a long press has occurred.  If you return true,
			/// the final key up will have
			/// <see cref="KeyEvent.FLAG_CANCELED">KeyEvent.FLAG_CANCELED</see>
			/// and
			/// <see cref="KeyEvent.FLAG_CANCELED_LONG_PRESS">KeyEvent.FLAG_CANCELED_LONG_PRESS</see>
			/// set.  Note that in
			/// order to receive this callback, someone in the event change
			/// <em>must</em> return true from
			/// <see cref="onKeyDown(int, KeyEvent)">onKeyDown(int, KeyEvent)</see>
			/// <em>and</em>
			/// call
			/// <see cref="KeyEvent.startTracking()">KeyEvent.startTracking()</see>
			/// on the event.
			/// </remarks>
			/// <param name="keyCode">The value in event.getKeyCode().</param>
			/// <param name="event">Description of the key event.</param>
			/// <returns>
			/// If you handled the event, return true.  If you want to allow
			/// the event to be handled by the next receiver, return false.
			/// </returns>
			bool onKeyLongPress(int keyCode, android.view.KeyEvent @event);

			/// <summary>Called when a key up event has occurred.</summary>
			/// <remarks>Called when a key up event has occurred.</remarks>
			/// <param name="keyCode">The value in event.getKeyCode().</param>
			/// <param name="event">Description of the key event.</param>
			/// <returns>
			/// If you handled the event, return true.  If you want to allow
			/// the event to be handled by the next receiver, return false.
			/// </returns>
			bool onKeyUp(int keyCode, android.view.KeyEvent @event);

			/// <summary>
			/// Called when multiple down/up pairs of the same key have occurred
			/// in a row.
			/// </summary>
			/// <remarks>
			/// Called when multiple down/up pairs of the same key have occurred
			/// in a row.
			/// </remarks>
			/// <param name="keyCode">The value in event.getKeyCode().</param>
			/// <param name="count">Number of pairs as returned by event.getRepeatCount().</param>
			/// <param name="event">Description of the key event.</param>
			/// <returns>
			/// If you handled the event, return true.  If you want to allow
			/// the event to be handled by the next receiver, return false.
			/// </returns>
			bool onKeyMultiple(int keyCode, int count, android.view.KeyEvent @event);
		}

		static KeyEvent()
		{
			populateKeycodeSymbolicNames();
		}

		private KeyEvent()
		{
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		public KeyEvent(int action, int code)
		{
			mAction = action;
			mKeyCode = code;
			mRepeatCount = 0;
			mDeviceId = android.view.KeyCharacterMap.VIRTUAL_KEYBOARD;
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="downTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this key code originally went down.
		/// </param>
		/// <param name="eventTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event happened.
		/// </param>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		/// <param name="repeat">
		/// A repeat count for down events (&gt; 0 if this is after the
		/// initial down) or event count for multiple events.
		/// </param>
		public KeyEvent(long downTime, long eventTime, int action, int code, int repeat)
		{
			mDownTime = downTime;
			mEventTime = eventTime;
			mAction = action;
			mKeyCode = code;
			mRepeatCount = repeat;
			mDeviceId = android.view.KeyCharacterMap.VIRTUAL_KEYBOARD;
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="downTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this key code originally went down.
		/// </param>
		/// <param name="eventTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event happened.
		/// </param>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		/// <param name="repeat">
		/// A repeat count for down events (&gt; 0 if this is after the
		/// initial down) or event count for multiple events.
		/// </param>
		/// <param name="metaState">Flags indicating which meta keys are currently pressed.</param>
		public KeyEvent(long downTime, long eventTime, int action, int code, int repeat, 
			int metaState)
		{
			mDownTime = downTime;
			mEventTime = eventTime;
			mAction = action;
			mKeyCode = code;
			mRepeatCount = repeat;
			mMetaState = metaState;
			mDeviceId = android.view.KeyCharacterMap.VIRTUAL_KEYBOARD;
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="downTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this key code originally went down.
		/// </param>
		/// <param name="eventTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event happened.
		/// </param>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		/// <param name="repeat">
		/// A repeat count for down events (&gt; 0 if this is after the
		/// initial down) or event count for multiple events.
		/// </param>
		/// <param name="metaState">Flags indicating which meta keys are currently pressed.</param>
		/// <param name="deviceId">The device ID that generated the key event.</param>
		/// <param name="scancode">Raw device scan code of the event.</param>
		public KeyEvent(long downTime, long eventTime, int action, int code, int repeat, 
			int metaState, int deviceId, int scancode)
		{
			mDownTime = downTime;
			mEventTime = eventTime;
			mAction = action;
			mKeyCode = code;
			mRepeatCount = repeat;
			mMetaState = metaState;
			mDeviceId = deviceId;
			mScanCode = scancode;
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="downTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this key code originally went down.
		/// </param>
		/// <param name="eventTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event happened.
		/// </param>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		/// <param name="repeat">
		/// A repeat count for down events (&gt; 0 if this is after the
		/// initial down) or event count for multiple events.
		/// </param>
		/// <param name="metaState">Flags indicating which meta keys are currently pressed.</param>
		/// <param name="deviceId">The device ID that generated the key event.</param>
		/// <param name="scancode">Raw device scan code of the event.</param>
		/// <param name="flags">The flags for this key event</param>
		public KeyEvent(long downTime, long eventTime, int action, int code, int repeat, 
			int metaState, int deviceId, int scancode, int flags)
		{
			mDownTime = downTime;
			mEventTime = eventTime;
			mAction = action;
			mKeyCode = code;
			mRepeatCount = repeat;
			mMetaState = metaState;
			mDeviceId = deviceId;
			mScanCode = scancode;
			mFlags = flags;
		}

		/// <summary>Create a new key event.</summary>
		/// <remarks>Create a new key event.</remarks>
		/// <param name="downTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this key code originally went down.
		/// </param>
		/// <param name="eventTime">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event happened.
		/// </param>
		/// <param name="action">
		/// Action code: either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </param>
		/// <param name="code">The key code.</param>
		/// <param name="repeat">
		/// A repeat count for down events (&gt; 0 if this is after the
		/// initial down) or event count for multiple events.
		/// </param>
		/// <param name="metaState">Flags indicating which meta keys are currently pressed.</param>
		/// <param name="deviceId">The device ID that generated the key event.</param>
		/// <param name="scancode">Raw device scan code of the event.</param>
		/// <param name="flags">The flags for this key event</param>
		/// <param name="source">
		/// The input source such as
		/// <see cref="InputDevice.SOURCE_KEYBOARD">InputDevice.SOURCE_KEYBOARD</see>
		/// .
		/// </param>
		public KeyEvent(long downTime, long eventTime, int action, int code, int repeat, 
			int metaState, int deviceId, int scancode, int flags, int source)
		{
			mDownTime = downTime;
			mEventTime = eventTime;
			mAction = action;
			mKeyCode = code;
			mRepeatCount = repeat;
			mMetaState = metaState;
			mDeviceId = deviceId;
			mScanCode = scancode;
			mFlags = flags;
			mSource = source;
		}

		/// <summary>Create a new key event for a string of characters.</summary>
		/// <remarks>
		/// Create a new key event for a string of characters.  The key code,
		/// action, repeat count and source will automatically be set to
		/// <see cref="KEYCODE_UNKNOWN">KEYCODE_UNKNOWN</see>
		/// ,
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// , 0, and
		/// <see cref="InputDevice.SOURCE_KEYBOARD">InputDevice.SOURCE_KEYBOARD</see>
		/// for you.
		/// </remarks>
		/// <param name="time">
		/// The time (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// )
		/// at which this event occured.
		/// </param>
		/// <param name="characters">The string of characters.</param>
		/// <param name="deviceId">The device ID that generated the key event.</param>
		/// <param name="flags">The flags for this key event</param>
		public KeyEvent(long time, string characters, int deviceId, int flags)
		{
			mDownTime = time;
			mEventTime = time;
			mCharacters = characters;
			mAction = ACTION_MULTIPLE;
			mKeyCode = KEYCODE_UNKNOWN;
			mRepeatCount = 0;
			mDeviceId = deviceId;
			mFlags = flags;
			mSource = android.view.InputDevice.SOURCE_KEYBOARD;
		}

		/// <summary>Make an exact copy of an existing key event.</summary>
		/// <remarks>Make an exact copy of an existing key event.</remarks>
		public KeyEvent(android.view.KeyEvent origEvent)
		{
			mDownTime = origEvent.mDownTime;
			mEventTime = origEvent.mEventTime;
			mAction = origEvent.mAction;
			mKeyCode = origEvent.mKeyCode;
			mRepeatCount = origEvent.mRepeatCount;
			mMetaState = origEvent.mMetaState;
			mDeviceId = origEvent.mDeviceId;
			mSource = origEvent.mSource;
			mScanCode = origEvent.mScanCode;
			mFlags = origEvent.mFlags;
			mCharacters = origEvent.mCharacters;
		}

		/// <summary>Copy an existing key event, modifying its time and repeat count.</summary>
		/// <remarks>Copy an existing key event, modifying its time and repeat count.</remarks>
		/// <param name="origEvent">The existing event to be copied.</param>
		/// <param name="eventTime">
		/// The new event time
		/// (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// ) of the event.
		/// </param>
		/// <param name="newRepeat">The new repeat count of the event.</param>
		[System.ObsoleteAttribute(@"Use changeTimeRepeat(KeyEvent, long, int) instead.")]
		public KeyEvent(android.view.KeyEvent origEvent, long eventTime, int newRepeat)
		{
			mDownTime = origEvent.mDownTime;
			mEventTime = eventTime;
			mAction = origEvent.mAction;
			mKeyCode = origEvent.mKeyCode;
			mRepeatCount = newRepeat;
			mMetaState = origEvent.mMetaState;
			mDeviceId = origEvent.mDeviceId;
			mSource = origEvent.mSource;
			mScanCode = origEvent.mScanCode;
			mFlags = origEvent.mFlags;
			mCharacters = origEvent.mCharacters;
		}

		private static android.view.KeyEvent obtain()
		{
			android.view.KeyEvent ev;
			lock (gRecyclerLock)
			{
				ev = gRecyclerTop;
				if (ev == null)
				{
					return new android.view.KeyEvent();
				}
				gRecyclerTop = ev.mNext;
				gRecyclerUsed -= 1;
			}
			ev.mRecycled = false;
			ev.mNext = null;
			return ev;
		}

		/// <summary>Obtains a (potentially recycled) key event.</summary>
		/// <remarks>Obtains a (potentially recycled) key event.</remarks>
		/// <hide></hide>
		public static android.view.KeyEvent obtain(long downTime, long eventTime, int action
			, int code, int repeat, int metaState, int deviceId, int scancode, int flags, int
			 source, string characters)
		{
			android.view.KeyEvent ev = obtain();
			ev.mDownTime = downTime;
			ev.mEventTime = eventTime;
			ev.mAction = action;
			ev.mKeyCode = code;
			ev.mRepeatCount = repeat;
			ev.mMetaState = metaState;
			ev.mDeviceId = deviceId;
			ev.mScanCode = scancode;
			ev.mFlags = flags;
			ev.mSource = source;
			ev.mCharacters = characters;
			return ev;
		}

		/// <summary>Obtains a (potentially recycled) copy of another key event.</summary>
		/// <remarks>Obtains a (potentially recycled) copy of another key event.</remarks>
		/// <hide></hide>
		public static android.view.KeyEvent obtain(android.view.KeyEvent other)
		{
			android.view.KeyEvent ev = obtain();
			ev.mDownTime = other.mDownTime;
			ev.mEventTime = other.mEventTime;
			ev.mAction = other.mAction;
			ev.mKeyCode = other.mKeyCode;
			ev.mRepeatCount = other.mRepeatCount;
			ev.mMetaState = other.mMetaState;
			ev.mDeviceId = other.mDeviceId;
			ev.mScanCode = other.mScanCode;
			ev.mFlags = other.mFlags;
			ev.mSource = other.mSource;
			ev.mCharacters = other.mCharacters;
			return ev;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public override android.view.InputEvent copy()
		{
			return obtain(this);
		}

		/// <summary>Recycles a key event.</summary>
		/// <remarks>
		/// Recycles a key event.
		/// Key events should only be recycled if they are owned by the system since user
		/// code expects them to be essentially immutable, "tracking" notwithstanding.
		/// </remarks>
		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void recycle()
		{
			if (mRecycled)
			{
				throw new java.lang.RuntimeException(ToString() + " recycled twice!");
			}
			mRecycled = true;
			mCharacters = null;
			lock (gRecyclerLock)
			{
				if (gRecyclerUsed < MAX_RECYCLED)
				{
					gRecyclerUsed++;
					mNext = gRecyclerTop;
					gRecyclerTop = this;
				}
			}
		}

		/// <summary>
		/// Create a new key event that is the same as the given one, but whose
		/// event time and repeat count are replaced with the given value.
		/// </summary>
		/// <remarks>
		/// Create a new key event that is the same as the given one, but whose
		/// event time and repeat count are replaced with the given value.
		/// </remarks>
		/// <param name="event">The existing event to be copied.  This is not modified.</param>
		/// <param name="eventTime">
		/// The new event time
		/// (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// ) of the event.
		/// </param>
		/// <param name="newRepeat">The new repeat count of the event.</param>
		public static android.view.KeyEvent changeTimeRepeat(android.view.KeyEvent @event
			, long eventTime, int newRepeat)
		{
			return new android.view.KeyEvent(@event, eventTime, newRepeat);
		}

		/// <summary>
		/// Create a new key event that is the same as the given one, but whose
		/// event time and repeat count are replaced with the given value.
		/// </summary>
		/// <remarks>
		/// Create a new key event that is the same as the given one, but whose
		/// event time and repeat count are replaced with the given value.
		/// </remarks>
		/// <param name="event">The existing event to be copied.  This is not modified.</param>
		/// <param name="eventTime">
		/// The new event time
		/// (in
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// ) of the event.
		/// </param>
		/// <param name="newRepeat">The new repeat count of the event.</param>
		/// <param name="newFlags">
		/// New flags for the event, replacing the entire value
		/// in the original event.
		/// </param>
		public static android.view.KeyEvent changeTimeRepeat(android.view.KeyEvent @event
			, long eventTime, int newRepeat, int newFlags)
		{
			android.view.KeyEvent ret = new android.view.KeyEvent(@event);
			ret.mEventTime = eventTime;
			ret.mRepeatCount = newRepeat;
			ret.mFlags = newFlags;
			return ret;
		}

		/// <summary>Copy an existing key event, modifying its action.</summary>
		/// <remarks>Copy an existing key event, modifying its action.</remarks>
		/// <param name="origEvent">The existing event to be copied.</param>
		/// <param name="action">The new action code of the event.</param>
		private KeyEvent(android.view.KeyEvent origEvent, int action)
		{
			mDownTime = origEvent.mDownTime;
			mEventTime = origEvent.mEventTime;
			mAction = action;
			mKeyCode = origEvent.mKeyCode;
			mRepeatCount = origEvent.mRepeatCount;
			mMetaState = origEvent.mMetaState;
			mDeviceId = origEvent.mDeviceId;
			mSource = origEvent.mSource;
			mScanCode = origEvent.mScanCode;
			mFlags = origEvent.mFlags;
		}

		// Don't copy mCharacters, since one way or the other we'll lose it
		// when changing the action.
		/// <summary>
		/// Create a new key event that is the same as the given one, but whose
		/// action is replaced with the given value.
		/// </summary>
		/// <remarks>
		/// Create a new key event that is the same as the given one, but whose
		/// action is replaced with the given value.
		/// </remarks>
		/// <param name="event">The existing event to be copied.  This is not modified.</param>
		/// <param name="action">The new action code of the event.</param>
		public static android.view.KeyEvent changeAction(android.view.KeyEvent @event, int
			 action)
		{
			return new android.view.KeyEvent(@event, action);
		}

		/// <summary>
		/// Create a new key event that is the same as the given one, but whose
		/// flags are replaced with the given value.
		/// </summary>
		/// <remarks>
		/// Create a new key event that is the same as the given one, but whose
		/// flags are replaced with the given value.
		/// </remarks>
		/// <param name="event">The existing event to be copied.  This is not modified.</param>
		/// <param name="flags">The new flags constant.</param>
		public static android.view.KeyEvent changeFlags(android.view.KeyEvent @event, int
			 flags)
		{
			@event = new android.view.KeyEvent(@event);
			@event.mFlags = flags;
			return @event;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override bool isTainted()
		{
			return (mFlags & FLAG_TAINTED) != 0;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void setTainted(bool tainted)
		{
			mFlags = tainted ? mFlags | FLAG_TAINTED : mFlags & ~FLAG_TAINTED;
		}

		/// <summary>
		/// Don't use in new code, instead explicitly check
		/// <see cref="getAction()">getAction()</see>
		/// .
		/// </summary>
		/// <returns>If the action is ACTION_DOWN, returns true; else false.</returns>
		/// <hide></hide>
		[System.ObsoleteAttribute]
		public bool isDown()
		{
			return mAction == ACTION_DOWN;
		}

		/// <summary>Is this a system key?  System keys can not be used for menu shortcuts.</summary>
		/// <remarks>
		/// Is this a system key?  System keys can not be used for menu shortcuts.
		/// TODO: this information should come from a table somewhere.
		/// TODO: should the dpad keys be here?  arguably, because they also shouldn't be menu shortcuts
		/// </remarks>
		public bool isSystem()
		{
			return native_isSystemKey(mKeyCode);
		}

		/// <hide></hide>
		public bool hasDefaultAction()
		{
			return native_hasDefaultAction(mKeyCode);
		}

		/// <summary>Returns true if the specified keycode is a gamepad button.</summary>
		/// <remarks>Returns true if the specified keycode is a gamepad button.</remarks>
		/// <returns>
		/// True if the keycode is a gamepad button, such as
		/// <see cref="KEYCODE_BUTTON_A">KEYCODE_BUTTON_A</see>
		/// .
		/// </returns>
		public static bool isGamepadButton(int keyCode)
		{
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_BUTTON_A:
				case android.view.KeyEvent.KEYCODE_BUTTON_B:
				case android.view.KeyEvent.KEYCODE_BUTTON_C:
				case android.view.KeyEvent.KEYCODE_BUTTON_X:
				case android.view.KeyEvent.KEYCODE_BUTTON_Y:
				case android.view.KeyEvent.KEYCODE_BUTTON_Z:
				case android.view.KeyEvent.KEYCODE_BUTTON_L1:
				case android.view.KeyEvent.KEYCODE_BUTTON_R1:
				case android.view.KeyEvent.KEYCODE_BUTTON_L2:
				case android.view.KeyEvent.KEYCODE_BUTTON_R2:
				case android.view.KeyEvent.KEYCODE_BUTTON_THUMBL:
				case android.view.KeyEvent.KEYCODE_BUTTON_THUMBR:
				case android.view.KeyEvent.KEYCODE_BUTTON_START:
				case android.view.KeyEvent.KEYCODE_BUTTON_SELECT:
				case android.view.KeyEvent.KEYCODE_BUTTON_MODE:
				case android.view.KeyEvent.KEYCODE_BUTTON_1:
				case android.view.KeyEvent.KEYCODE_BUTTON_2:
				case android.view.KeyEvent.KEYCODE_BUTTON_3:
				case android.view.KeyEvent.KEYCODE_BUTTON_4:
				case android.view.KeyEvent.KEYCODE_BUTTON_5:
				case android.view.KeyEvent.KEYCODE_BUTTON_6:
				case android.view.KeyEvent.KEYCODE_BUTTON_7:
				case android.view.KeyEvent.KEYCODE_BUTTON_8:
				case android.view.KeyEvent.KEYCODE_BUTTON_9:
				case android.view.KeyEvent.KEYCODE_BUTTON_10:
				case android.view.KeyEvent.KEYCODE_BUTTON_11:
				case android.view.KeyEvent.KEYCODE_BUTTON_12:
				case android.view.KeyEvent.KEYCODE_BUTTON_13:
				case android.view.KeyEvent.KEYCODE_BUTTON_14:
				case android.view.KeyEvent.KEYCODE_BUTTON_15:
				case android.view.KeyEvent.KEYCODE_BUTTON_16:
				{
					return true;
				}

				default:
				{
					return false;
				}
			}
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override int getDeviceId()
		{
			return mDeviceId;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override int getSource()
		{
			return mSource;
		}

		/// <summary>
		/// <inheritDoc></inheritDoc>
		/// 
		/// </summary>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void setSource(int source)
		{
			mSource = source;
		}

		/// <summary><p>Returns the state of the meta keys.</p></summary>
		/// <returns>
		/// an integer in which each bit set to 1 represents a pressed
		/// meta key
		/// </returns>
		/// <seealso cref="isAltPressed()">isAltPressed()</seealso>
		/// <seealso cref="isShiftPressed()">isShiftPressed()</seealso>
		/// <seealso cref="isSymPressed()">isSymPressed()</seealso>
		/// <seealso cref="isCtrlPressed()">isCtrlPressed()</seealso>
		/// <seealso cref="isMetaPressed()">isMetaPressed()</seealso>
		/// <seealso cref="isFunctionPressed()">isFunctionPressed()</seealso>
		/// <seealso cref="isCapsLockOn()">isCapsLockOn()</seealso>
		/// <seealso cref="isNumLockOn()">isNumLockOn()</seealso>
		/// <seealso cref="isScrollLockOn()">isScrollLockOn()</seealso>
		/// <seealso cref="META_ALT_ON">META_ALT_ON</seealso>
		/// <seealso cref="META_ALT_LEFT_ON">META_ALT_LEFT_ON</seealso>
		/// <seealso cref="META_ALT_RIGHT_ON">META_ALT_RIGHT_ON</seealso>
		/// <seealso cref="META_SHIFT_ON">META_SHIFT_ON</seealso>
		/// <seealso cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</seealso>
		/// <seealso cref="META_SHIFT_RIGHT_ON">META_SHIFT_RIGHT_ON</seealso>
		/// <seealso cref="META_SYM_ON">META_SYM_ON</seealso>
		/// <seealso cref="META_FUNCTION_ON">META_FUNCTION_ON</seealso>
		/// <seealso cref="META_CTRL_ON">META_CTRL_ON</seealso>
		/// <seealso cref="META_CTRL_LEFT_ON">META_CTRL_LEFT_ON</seealso>
		/// <seealso cref="META_CTRL_RIGHT_ON">META_CTRL_RIGHT_ON</seealso>
		/// <seealso cref="META_META_ON">META_META_ON</seealso>
		/// <seealso cref="META_META_LEFT_ON">META_META_LEFT_ON</seealso>
		/// <seealso cref="META_META_RIGHT_ON">META_META_RIGHT_ON</seealso>
		/// <seealso cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</seealso>
		/// <seealso cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</seealso>
		/// <seealso cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</seealso>
		/// <seealso cref="getModifiers()">getModifiers()</seealso>
		public int getMetaState()
		{
			return mMetaState;
		}

		/// <summary>Returns the state of the modifier keys.</summary>
		/// <remarks>
		/// Returns the state of the modifier keys.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function specifically masks out
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p><p>
		/// The value returned consists of the meta state (from
		/// <see cref="getMetaState()">getMetaState()</see>
		/// )
		/// normalized using
		/// <see cref="normalizeMetaState(int)">normalizeMetaState(int)</see>
		/// and then masked with
		/// <see cref="getModifierMetaStateMask()">getModifierMetaStateMask()</see>
		/// so that only valid modifier bits are retained.
		/// </p>
		/// </remarks>
		/// <returns>An integer in which each bit set to 1 represents a pressed modifier key.
		/// 	</returns>
		/// <seealso cref="getMetaState()">getMetaState()</seealso>
		public int getModifiers()
		{
			return normalizeMetaState(mMetaState) & META_MODIFIER_MASK;
		}

		/// <summary>Returns the flags for this key event.</summary>
		/// <remarks>Returns the flags for this key event.</remarks>
		/// <seealso cref="FLAG_WOKE_HERE">FLAG_WOKE_HERE</seealso>
		public int getFlags()
		{
			return mFlags;
		}

		internal const int META_MODIFIER_MASK = META_SHIFT_ON | META_SHIFT_LEFT_ON | META_SHIFT_RIGHT_ON
			 | META_ALT_ON | META_ALT_LEFT_ON | META_ALT_RIGHT_ON | META_CTRL_ON | META_CTRL_LEFT_ON
			 | META_CTRL_RIGHT_ON | META_META_ON | META_META_LEFT_ON | META_META_RIGHT_ON | 
			META_SYM_ON | META_FUNCTION_ON;

		internal const int META_LOCK_MASK = META_CAPS_LOCK_ON | META_NUM_LOCK_ON | META_SCROLL_LOCK_ON;

		internal const int META_ALL_MASK = META_MODIFIER_MASK | META_LOCK_MASK;

		internal const int META_SYNTHETIC_MASK = META_CAP_LOCKED | META_ALT_LOCKED | META_SYM_LOCKED
			 | META_SELECTING;

		internal const int META_INVALID_MODIFIER_MASK = META_LOCK_MASK | META_SYNTHETIC_MASK;

		// Mask of all modifier key meta states.  Specifically excludes locked keys like caps lock.
		// Mask of all lock key meta states.
		// Mask of all valid meta states.
		// Mask of all synthetic meta states that are reserved for API compatibility with
		// historical uses in MetaKeyKeyListener.
		// Mask of all meta states that are not valid use in specifying a modifier key.
		// These bits are known to be used for purposes other than specifying modifiers.
		/// <summary>Gets a mask that includes all valid modifier key meta state bits.</summary>
		/// <remarks>
		/// Gets a mask that includes all valid modifier key meta state bits.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, the mask specifically excludes
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p>
		/// </remarks>
		/// <returns>
		/// The modifier meta state mask which is a combination of
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// ,
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// ,
		/// <see cref="META_SHIFT_RIGHT_ON">META_SHIFT_RIGHT_ON</see>
		/// ,
		/// <see cref="META_ALT_ON">META_ALT_ON</see>
		/// ,
		/// <see cref="META_ALT_LEFT_ON">META_ALT_LEFT_ON</see>
		/// ,
		/// <see cref="META_ALT_RIGHT_ON">META_ALT_RIGHT_ON</see>
		/// ,
		/// <see cref="META_CTRL_ON">META_CTRL_ON</see>
		/// ,
		/// <see cref="META_CTRL_LEFT_ON">META_CTRL_LEFT_ON</see>
		/// ,
		/// <see cref="META_CTRL_RIGHT_ON">META_CTRL_RIGHT_ON</see>
		/// ,
		/// <see cref="META_META_ON">META_META_ON</see>
		/// ,
		/// <see cref="META_META_LEFT_ON">META_META_LEFT_ON</see>
		/// ,
		/// <see cref="META_META_RIGHT_ON">META_META_RIGHT_ON</see>
		/// ,
		/// <see cref="META_SYM_ON">META_SYM_ON</see>
		/// ,
		/// <see cref="META_FUNCTION_ON">META_FUNCTION_ON</see>
		/// .
		/// </returns>
		public static int getModifierMetaStateMask()
		{
			return META_MODIFIER_MASK;
		}

		/// <summary>Returns true if this key code is a modifier key.</summary>
		/// <remarks>
		/// Returns true if this key code is a modifier key.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function return false
		/// for those keys.
		/// </p>
		/// </remarks>
		/// <returns>
		/// True if the key code is one of
		/// <see cref="KEYCODE_SHIFT_LEFT">KEYCODE_SHIFT_LEFT</see>
		/// 
		/// <see cref="KEYCODE_SHIFT_RIGHT">KEYCODE_SHIFT_RIGHT</see>
		/// ,
		/// <see cref="KEYCODE_ALT_LEFT">KEYCODE_ALT_LEFT</see>
		/// ,
		/// <see cref="KEYCODE_ALT_RIGHT">KEYCODE_ALT_RIGHT</see>
		/// ,
		/// <see cref="KEYCODE_CTRL_LEFT">KEYCODE_CTRL_LEFT</see>
		/// ,
		/// <see cref="KEYCODE_CTRL_RIGHT">KEYCODE_CTRL_RIGHT</see>
		/// ,
		/// <see cref="KEYCODE_META_LEFT">KEYCODE_META_LEFT</see>
		/// , or
		/// <see cref="KEYCODE_META_RIGHT">KEYCODE_META_RIGHT</see>
		/// ,
		/// <see cref="KEYCODE_SYM">KEYCODE_SYM</see>
		/// ,
		/// <see cref="KEYCODE_NUM">KEYCODE_NUM</see>
		/// ,
		/// <see cref="KEYCODE_FUNCTION">KEYCODE_FUNCTION</see>
		/// .
		/// </returns>
		public static bool isModifierKey(int keyCode)
		{
			switch (keyCode)
			{
				case KEYCODE_SHIFT_LEFT:
				case KEYCODE_SHIFT_RIGHT:
				case KEYCODE_ALT_LEFT:
				case KEYCODE_ALT_RIGHT:
				case KEYCODE_CTRL_LEFT:
				case KEYCODE_CTRL_RIGHT:
				case KEYCODE_META_LEFT:
				case KEYCODE_META_RIGHT:
				case KEYCODE_SYM:
				case KEYCODE_NUM:
				case KEYCODE_FUNCTION:
				{
					return true;
				}

				default:
				{
					return false;
				}
			}
		}

		/// <summary>Normalizes the specified meta state.</summary>
		/// <remarks>
		/// Normalizes the specified meta state.
		/// <p>
		/// The meta state is normalized such that if either the left or right modifier meta state
		/// bits are set then the result will also include the universal bit for that modifier.
		/// </p><p>
		/// If the specified meta state contains
		/// <see cref="META_ALT_LEFT_ON">META_ALT_LEFT_ON</see>
		/// then
		/// the result will also contain
		/// <see cref="META_ALT_ON">META_ALT_ON</see>
		/// in addition to
		/// <see cref="META_ALT_LEFT_ON">META_ALT_LEFT_ON</see>
		/// and the other bits that were specified in the input.  The same is process is
		/// performed for shift, control and meta.
		/// </p><p>
		/// If the specified meta state contains synthetic meta states defined by
		/// <see cref="android.text.method.MetaKeyKeyListener">android.text.method.MetaKeyKeyListener
		/// 	</see>
		/// , then those states are translated here and the original
		/// synthetic meta states are removed from the result.
		/// <see cref="android.text.method.MetaKeyKeyListener.META_CAP_LOCKED">android.text.method.MetaKeyKeyListener.META_CAP_LOCKED
		/// 	</see>
		/// is translated to
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// .
		/// <see cref="android.text.method.MetaKeyKeyListener.META_ALT_LOCKED">android.text.method.MetaKeyKeyListener.META_ALT_LOCKED
		/// 	</see>
		/// is translated to
		/// <see cref="META_ALT_ON">META_ALT_ON</see>
		/// .
		/// <see cref="android.text.method.MetaKeyKeyListener.META_SYM_LOCKED">android.text.method.MetaKeyKeyListener.META_SYM_LOCKED
		/// 	</see>
		/// is translated to
		/// <see cref="META_SYM_ON">META_SYM_ON</see>
		/// .
		/// </p><p>
		/// Undefined meta state bits are removed.
		/// </p>
		/// </remarks>
		/// <param name="metaState">The meta state.</param>
		/// <returns>The normalized meta state.</returns>
		public static int normalizeMetaState(int metaState)
		{
			if ((metaState & (META_SHIFT_LEFT_ON | META_SHIFT_RIGHT_ON)) != 0)
			{
				metaState |= META_SHIFT_ON;
			}
			if ((metaState & (META_ALT_LEFT_ON | META_ALT_RIGHT_ON)) != 0)
			{
				metaState |= META_ALT_ON;
			}
			if ((metaState & (META_CTRL_LEFT_ON | META_CTRL_RIGHT_ON)) != 0)
			{
				metaState |= META_CTRL_ON;
			}
			if ((metaState & (META_META_LEFT_ON | META_META_RIGHT_ON)) != 0)
			{
				metaState |= META_META_ON;
			}
			if ((metaState & android.text.method.MetaKeyKeyListener.META_CAP_LOCKED) != 0)
			{
				metaState |= META_CAPS_LOCK_ON;
			}
			if ((metaState & android.text.method.MetaKeyKeyListener.META_ALT_LOCKED) != 0)
			{
				metaState |= META_ALT_ON;
			}
			if ((metaState & android.text.method.MetaKeyKeyListener.META_SYM_LOCKED) != 0)
			{
				metaState |= META_SYM_ON;
			}
			return metaState & META_ALL_MASK;
		}

		/// <summary>Returns true if no modifiers keys are pressed according to the specified meta state.
		/// 	</summary>
		/// <remarks>
		/// Returns true if no modifiers keys are pressed according to the specified meta state.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function ignores
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p><p>
		/// The meta state is normalized prior to comparison using
		/// <see cref="normalizeMetaState(int)">normalizeMetaState(int)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="metaState">The meta state to consider.</param>
		/// <returns>True if no modifier keys are pressed.</returns>
		/// <seealso cref="hasNoModifiers()">hasNoModifiers()</seealso>
		public static bool metaStateHasNoModifiers(int metaState)
		{
			return (normalizeMetaState(metaState) & META_MODIFIER_MASK) == 0;
		}

		/// <summary>
		/// Returns true if only the specified modifier keys are pressed according to
		/// the specified meta state.
		/// </summary>
		/// <remarks>
		/// Returns true if only the specified modifier keys are pressed according to
		/// the specified meta state.  Returns false if a different combination of modifier
		/// keys are pressed.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function ignores
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p><p>
		/// If the specified modifier mask includes directional modifiers, such as
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// , then this method ensures that the
		/// modifier is pressed on that side.
		/// If the specified modifier mask includes non-directional modifiers, such as
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// , then this method ensures that the modifier
		/// is pressed on either side.
		/// If the specified modifier mask includes both directional and non-directional modifiers
		/// for the same type of key, such as
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// and
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// ,
		/// then this method throws an illegal argument exception.
		/// </p>
		/// </remarks>
		/// <param name="metaState">The meta state to consider.</param>
		/// <param name="modifiers">
		/// The meta state of the modifier keys to check.  May be a combination
		/// of modifier meta states as defined by
		/// <see cref="getModifierMetaStateMask()">getModifierMetaStateMask()</see>
		/// .  May be 0 to
		/// ensure that no modifier keys are pressed.
		/// </param>
		/// <returns>True if only the specified modifier keys are pressed.</returns>
		/// <exception cref="System.ArgumentException">if the modifiers parameter contains invalid modifiers
		/// 	</exception>
		/// <seealso cref="hasModifiers(int)">hasModifiers(int)</seealso>
		public static bool metaStateHasModifiers(int metaState, int modifiers)
		{
			// Note: For forward compatibility, we allow the parameter to contain meta states
			//       that we do not recognize but we explicitly disallow meta states that
			//       are not valid modifiers.
			if ((modifiers & META_INVALID_MODIFIER_MASK) != 0)
			{
				throw new System.ArgumentException("modifiers must not contain " + "META_CAPS_LOCK_ON, META_NUM_LOCK_ON, META_SCROLL_LOCK_ON, "
					 + "META_CAP_LOCKED, META_ALT_LOCKED, META_SYM_LOCKED, " + "or META_SELECTING");
			}
			metaState = normalizeMetaState(metaState) & META_MODIFIER_MASK;
			metaState = metaStateFilterDirectionalModifiers(metaState, modifiers, META_SHIFT_ON
				, META_SHIFT_LEFT_ON, META_SHIFT_RIGHT_ON);
			metaState = metaStateFilterDirectionalModifiers(metaState, modifiers, META_ALT_ON
				, META_ALT_LEFT_ON, META_ALT_RIGHT_ON);
			metaState = metaStateFilterDirectionalModifiers(metaState, modifiers, META_CTRL_ON
				, META_CTRL_LEFT_ON, META_CTRL_RIGHT_ON);
			metaState = metaStateFilterDirectionalModifiers(metaState, modifiers, META_META_ON
				, META_META_LEFT_ON, META_META_RIGHT_ON);
			return metaState == modifiers;
		}

		private static int metaStateFilterDirectionalModifiers(int metaState, int modifiers
			, int basic, int left, int right)
		{
			bool wantBasic = (modifiers & basic) != 0;
			int directional = left | right;
			bool wantLeftOrRight = (modifiers & directional) != 0;
			if (wantBasic)
			{
				if (wantLeftOrRight)
				{
					throw new System.ArgumentException("modifiers must not contain " + metaStateToString
						(basic) + " combined with " + metaStateToString(left) + " or " + metaStateToString
						(right));
				}
				return metaState & ~directional;
			}
			else
			{
				if (wantLeftOrRight)
				{
					return metaState & ~basic;
				}
				else
				{
					return metaState;
				}
			}
		}

		/// <summary>Returns true if no modifier keys are pressed.</summary>
		/// <remarks>
		/// Returns true if no modifier keys are pressed.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function ignores
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p><p>
		/// The meta state is normalized prior to comparison using
		/// <see cref="normalizeMetaState(int)">normalizeMetaState(int)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <returns>True if no modifier keys are pressed.</returns>
		/// <seealso cref="metaStateHasNoModifiers(int)">metaStateHasNoModifiers(int)</seealso>
		public bool hasNoModifiers()
		{
			return metaStateHasNoModifiers(mMetaState);
		}

		/// <summary>Returns true if only the specified modifiers keys are pressed.</summary>
		/// <remarks>
		/// Returns true if only the specified modifiers keys are pressed.
		/// Returns false if a different combination of modifier keys are pressed.
		/// <p>
		/// For the purposes of this function,
		/// <see cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</see>
		/// ,
		/// <see cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</see>
		/// , and
		/// <see cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</see>
		/// are
		/// not considered modifier keys.  Consequently, this function ignores
		/// <see cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</see>
		/// ,
		/// <see cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</see>
		/// and
		/// <see cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</see>
		/// .
		/// </p><p>
		/// If the specified modifier mask includes directional modifiers, such as
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// , then this method ensures that the
		/// modifier is pressed on that side.
		/// If the specified modifier mask includes non-directional modifiers, such as
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// , then this method ensures that the modifier
		/// is pressed on either side.
		/// If the specified modifier mask includes both directional and non-directional modifiers
		/// for the same type of key, such as
		/// <see cref="META_SHIFT_ON">META_SHIFT_ON</see>
		/// and
		/// <see cref="META_SHIFT_LEFT_ON">META_SHIFT_LEFT_ON</see>
		/// ,
		/// then this method throws an illegal argument exception.
		/// </p>
		/// </remarks>
		/// <param name="modifiers">
		/// The meta state of the modifier keys to check.  May be a combination
		/// of modifier meta states as defined by
		/// <see cref="getModifierMetaStateMask()">getModifierMetaStateMask()</see>
		/// .  May be 0 to
		/// ensure that no modifier keys are pressed.
		/// </param>
		/// <returns>True if only the specified modifier keys are pressed.</returns>
		/// <exception cref="System.ArgumentException">if the modifiers parameter contains invalid modifiers
		/// 	</exception>
		/// <seealso cref="metaStateHasModifiers(int, int)">metaStateHasModifiers(int, int)</seealso>
		public bool hasModifiers(int modifiers)
		{
			return metaStateHasModifiers(mMetaState, modifiers);
		}

		/// <summary><p>Returns the pressed state of the ALT meta key.</p></summary>
		/// <returns>true if the ALT key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_ALT_LEFT">KEYCODE_ALT_LEFT</seealso>
		/// <seealso cref="KEYCODE_ALT_RIGHT">KEYCODE_ALT_RIGHT</seealso>
		/// <seealso cref="META_ALT_ON">META_ALT_ON</seealso>
		public bool isAltPressed()
		{
			return (mMetaState & META_ALT_ON) != 0;
		}

		/// <summary><p>Returns the pressed state of the SHIFT meta key.</p></summary>
		/// <returns>true if the SHIFT key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_SHIFT_LEFT">KEYCODE_SHIFT_LEFT</seealso>
		/// <seealso cref="KEYCODE_SHIFT_RIGHT">KEYCODE_SHIFT_RIGHT</seealso>
		/// <seealso cref="META_SHIFT_ON">META_SHIFT_ON</seealso>
		public bool isShiftPressed()
		{
			return (mMetaState & META_SHIFT_ON) != 0;
		}

		/// <summary><p>Returns the pressed state of the SYM meta key.</p></summary>
		/// <returns>true if the SYM key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_SYM">KEYCODE_SYM</seealso>
		/// <seealso cref="META_SYM_ON">META_SYM_ON</seealso>
		public bool isSymPressed()
		{
			return (mMetaState & META_SYM_ON) != 0;
		}

		/// <summary><p>Returns the pressed state of the CTRL meta key.</p></summary>
		/// <returns>true if the CTRL key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_CTRL_LEFT">KEYCODE_CTRL_LEFT</seealso>
		/// <seealso cref="KEYCODE_CTRL_RIGHT">KEYCODE_CTRL_RIGHT</seealso>
		/// <seealso cref="META_CTRL_ON">META_CTRL_ON</seealso>
		public bool isCtrlPressed()
		{
			return (mMetaState & META_CTRL_ON) != 0;
		}

		/// <summary><p>Returns the pressed state of the META meta key.</p></summary>
		/// <returns>true if the META key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_META_LEFT">KEYCODE_META_LEFT</seealso>
		/// <seealso cref="KEYCODE_META_RIGHT">KEYCODE_META_RIGHT</seealso>
		/// <seealso cref="META_META_ON">META_META_ON</seealso>
		public bool isMetaPressed()
		{
			return (mMetaState & META_META_ON) != 0;
		}

		/// <summary><p>Returns the pressed state of the FUNCTION meta key.</p></summary>
		/// <returns>true if the FUNCTION key is pressed, false otherwise</returns>
		/// <seealso cref="KEYCODE_FUNCTION">KEYCODE_FUNCTION</seealso>
		/// <seealso cref="META_FUNCTION_ON">META_FUNCTION_ON</seealso>
		public bool isFunctionPressed()
		{
			return (mMetaState & META_FUNCTION_ON) != 0;
		}

		/// <summary><p>Returns the locked state of the CAPS LOCK meta key.</p></summary>
		/// <returns>true if the CAPS LOCK key is on, false otherwise</returns>
		/// <seealso cref="KEYCODE_CAPS_LOCK">KEYCODE_CAPS_LOCK</seealso>
		/// <seealso cref="META_CAPS_LOCK_ON">META_CAPS_LOCK_ON</seealso>
		public bool isCapsLockOn()
		{
			return (mMetaState & META_CAPS_LOCK_ON) != 0;
		}

		/// <summary><p>Returns the locked state of the NUM LOCK meta key.</p></summary>
		/// <returns>true if the NUM LOCK key is on, false otherwise</returns>
		/// <seealso cref="KEYCODE_NUM_LOCK">KEYCODE_NUM_LOCK</seealso>
		/// <seealso cref="META_NUM_LOCK_ON">META_NUM_LOCK_ON</seealso>
		public bool isNumLockOn()
		{
			return (mMetaState & META_NUM_LOCK_ON) != 0;
		}

		/// <summary><p>Returns the locked state of the SCROLL LOCK meta key.</p></summary>
		/// <returns>true if the SCROLL LOCK key is on, false otherwise</returns>
		/// <seealso cref="KEYCODE_SCROLL_LOCK">KEYCODE_SCROLL_LOCK</seealso>
		/// <seealso cref="META_SCROLL_LOCK_ON">META_SCROLL_LOCK_ON</seealso>
		public bool isScrollLockOn()
		{
			return (mMetaState & META_SCROLL_LOCK_ON) != 0;
		}

		/// <summary>Retrieve the action of this key event.</summary>
		/// <remarks>
		/// Retrieve the action of this key event.  May be either
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// ,
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// , or
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// .
		/// </remarks>
		/// <returns>The event action: ACTION_DOWN, ACTION_UP, or ACTION_MULTIPLE.</returns>
		public int getAction()
		{
			return mAction;
		}

		/// <summary>
		/// For
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// events, indicates that the event has been
		/// canceled as per
		/// <see cref="FLAG_CANCELED">FLAG_CANCELED</see>
		/// .
		/// </summary>
		public bool isCanceled()
		{
			return (mFlags & FLAG_CANCELED) != 0;
		}

		/// <summary>
		/// Call this during
		/// <see cref="Callback.onKeyDown(int, KeyEvent)">Callback.onKeyDown(int, KeyEvent)</see>
		/// to have the system track
		/// the key through its final up (possibly including a long press).  Note
		/// that only one key can be tracked at a time -- if another key down
		/// event is received while a previous one is being tracked, tracking is
		/// stopped on the previous event.
		/// </summary>
		public void startTracking()
		{
			mFlags |= FLAG_START_TRACKING;
		}

		/// <summary>
		/// For
		/// <see cref="ACTION_UP">ACTION_UP</see>
		/// events, indicates that the event is still being
		/// tracked from its initial down event as per
		/// <see cref="FLAG_TRACKING">FLAG_TRACKING</see>
		/// .
		/// </summary>
		public bool isTracking()
		{
			return (mFlags & FLAG_TRACKING) != 0;
		}

		/// <summary>
		/// For
		/// <see cref="ACTION_DOWN">ACTION_DOWN</see>
		/// events, indicates that the event has been
		/// canceled as per
		/// <see cref="FLAG_LONG_PRESS">FLAG_LONG_PRESS</see>
		/// .
		/// </summary>
		public bool isLongPress()
		{
			return (mFlags & FLAG_LONG_PRESS) != 0;
		}

		/// <summary>Retrieve the key code of the key event.</summary>
		/// <remarks>
		/// Retrieve the key code of the key event.  This is the physical key that
		/// was pressed, <em>not</em> the Unicode character.
		/// </remarks>
		/// <returns>The key code of the event.</returns>
		public int getKeyCode()
		{
			return mKeyCode;
		}

		/// <summary>
		/// For the special case of a
		/// <see cref="ACTION_MULTIPLE">ACTION_MULTIPLE</see>
		/// event with key
		/// code of
		/// <see cref="KEYCODE_UNKNOWN">KEYCODE_UNKNOWN</see>
		/// , this is a raw string of characters
		/// associated with the event.  In all other cases it is null.
		/// </summary>
		/// <returns>
		/// Returns a String of 1 or more characters associated with
		/// the event.
		/// </returns>
		public string getCharacters()
		{
			return mCharacters;
		}

		/// <summary>Retrieve the hardware key id of this key event.</summary>
		/// <remarks>
		/// Retrieve the hardware key id of this key event.  These values are not
		/// reliable and vary from device to device.
		/// <more></more>
		/// Mostly this is here for debugging purposes.
		/// </remarks>
		public int getScanCode()
		{
			return mScanCode;
		}

		/// <summary>Retrieve the repeat count of the event.</summary>
		/// <remarks>
		/// Retrieve the repeat count of the event.  For both key up and key down
		/// events, this is the number of times the key has repeated with the first
		/// down starting at 0 and counting up from there.  For multiple key
		/// events, this is the number of down/up pairs that have occurred.
		/// </remarks>
		/// <returns>The number of times the key has repeated.</returns>
		public int getRepeatCount()
		{
			return mRepeatCount;
		}

		/// <summary>
		/// Retrieve the time of the most recent key down event,
		/// in the
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// time base.  If this
		/// is a down event, this will be the same as
		/// <see cref="getEventTime()">getEventTime()</see>
		/// .
		/// Note that when chording keys, this value is the down time of the
		/// most recently pressed key, which may <em>not</em> be the same physical
		/// key of this event.
		/// </summary>
		/// <returns>
		/// Returns the most recent key down time, in the
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// time base
		/// </returns>
		public long getDownTime()
		{
			return mDownTime;
		}

		/// <summary>
		/// Retrieve the time this event occurred,
		/// in the
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// time base.
		/// </summary>
		/// <returns>
		/// Returns the time this event occurred,
		/// in the
		/// <see cref="android.os.SystemClock.uptimeMillis()">android.os.SystemClock.uptimeMillis()
		/// 	</see>
		/// time base.
		/// </returns>
		public long getEventTime()
		{
			return mEventTime;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override long getEventTimeNano()
		{
			return mEventTime * 1000000L;
		}

		/// <summary>
		/// Renamed to
		/// <see cref="getDeviceId()">getDeviceId()</see>
		/// .
		/// </summary>
		/// <hide></hide>
		[System.ObsoleteAttribute(@"use getDeviceId() instead.")]
		public int getKeyboardDevice()
		{
			return mDeviceId;
		}

		/// <summary>
		/// Gets the
		/// <see cref="KeyCharacterMap">KeyCharacterMap</see>
		/// associated with the keyboard device.
		/// </summary>
		/// <returns>The associated key character map.</returns>
		/// <exception>
		/// {@link KeyCharacterMap.UnavailableException} if the key character map
		/// could not be loaded because it was malformed or the default key character map
		/// is missing from the system.
		/// </exception>
		/// <seealso cref="KeyCharacterMap.load(int)">KeyCharacterMap.load(int)</seealso>
		public android.view.KeyCharacterMap getKeyCharacterMap()
		{
			return android.view.KeyCharacterMap.load(mDeviceId);
		}

		/// <summary>Gets the primary character for this key.</summary>
		/// <remarks>
		/// Gets the primary character for this key.
		/// In other words, the label that is physically printed on it.
		/// </remarks>
		/// <returns>The display label character, or 0 if none (eg. for non-printing keys).</returns>
		public virtual char getDisplayLabel()
		{
			return getKeyCharacterMap().getDisplayLabel(mKeyCode);
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
		/// <see cref="KeyCharacterMap.COMBINING_ACCENT">KeyCharacterMap.COMBINING_ACCENT</see>
		/// set, the
		/// key is a "dead key" that should be combined with another to
		/// actually produce a character -- see
		/// <see cref="KeyCharacterMap.getDeadChar(int, int)">KeyCharacterMap.getDeadChar(int, int)
		/// 	</see>
		/// --
		/// after masking with
		/// <see cref="KeyCharacterMap.COMBINING_ACCENT_MASK">KeyCharacterMap.COMBINING_ACCENT_MASK
		/// 	</see>
		/// .
		/// </p>
		/// </remarks>
		/// <returns>The associated character or combining accent, or 0 if none.</returns>
		public virtual int getUnicodeChar()
		{
			return getUnicodeChar(mMetaState);
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
		/// <see cref="KeyCharacterMap.COMBINING_ACCENT">KeyCharacterMap.COMBINING_ACCENT</see>
		/// set, the
		/// key is a "dead key" that should be combined with another to
		/// actually produce a character -- see
		/// <see cref="KeyCharacterMap.getDeadChar(int, int)">KeyCharacterMap.getDeadChar(int, int)
		/// 	</see>
		/// --
		/// after masking with
		/// <see cref="KeyCharacterMap.COMBINING_ACCENT_MASK">KeyCharacterMap.COMBINING_ACCENT_MASK
		/// 	</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="metaState">The meta key modifier state.</param>
		/// <returns>The associated character or combining accent, or 0 if none.</returns>
		public virtual int getUnicodeChar(int metaState)
		{
			return getKeyCharacterMap().get(mKeyCode, metaState);
		}

		/// <summary>Get the character conversion data for a given key code.</summary>
		/// <remarks>Get the character conversion data for a given key code.</remarks>
		/// <param name="results">
		/// A
		/// <see cref="KeyData">KeyData</see>
		/// instance that will be
		/// filled with the results.
		/// </param>
		/// <returns>True if the key was mapped.  If the key was not mapped, results is not modified.
		/// 	</returns>
		[System.ObsoleteAttribute(@"instead use getDisplayLabel() ,getNumber() or getUnicodeChar(int) ."
			)]
		public virtual bool getKeyData(android.view.KeyCharacterMap.KeyData results)
		{
			return getKeyCharacterMap().getKeyData(mKeyCode, results);
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
		/// <see cref="getMatch(char[], int)">getMatch(chars, 0)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="chars">The array of matching characters to consider.</param>
		/// <returns>The matching associated character, or 0 if none.</returns>
		public virtual char getMatch(char[] chars)
		{
			return getMatch(chars, 0);
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
		/// <param name="chars">The array of matching characters to consider.</param>
		/// <param name="metaState">The preferred meta key modifier state.</param>
		/// <returns>The matching associated character, or 0 if none.</returns>
		public virtual char getMatch(char[] chars, int metaState)
		{
			return getKeyCharacterMap().getMatch(mKeyCode, chars, metaState);
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
		/// <see cref="getNumber()">getNumber()</see>
		/// is called with
		/// <see cref="KEYCODE_Q">KEYCODE_Q</see>
		/// it returns '1'
		/// so that the user can type numbers without pressing ALT when it makes sense.
		/// </p>
		/// </remarks>
		/// <returns>The associated numeric or symbolic character, or 0 if none.</returns>
		public virtual char getNumber()
		{
			return getKeyCharacterMap().getNumber(mKeyCode);
		}

		/// <summary>Returns true if this key produces a glyph.</summary>
		/// <remarks>Returns true if this key produces a glyph.</remarks>
		/// <returns>True if the key is a printing key.</returns>
		public virtual bool isPrintingKey()
		{
			return getKeyCharacterMap().isPrintingKey(mKeyCode);
		}

		[System.ObsoleteAttribute(@"Use dispatch(Callback, DispatcherState, object) instead."
			)]
		public bool dispatch(android.view.KeyEvent.Callback receiver)
		{
			return dispatch(receiver, null, null);
		}

		/// <summary>
		/// Deliver this key event to a
		/// <see cref="Callback">Callback</see>
		/// interface.  If this is
		/// an ACTION_MULTIPLE event and it is not handled, then an attempt will
		/// be made to deliver a single normal event.
		/// </summary>
		/// <param name="receiver">The Callback that will be given the event.</param>
		/// <param name="state">State information retained across events.</param>
		/// <param name="target">The target of the dispatch, for use in tracking.</param>
		/// <returns>The return value from the Callback method that was called.</returns>
		public bool dispatch(android.view.KeyEvent.Callback receiver, android.view.KeyEvent
			.DispatcherState state, object target)
		{
			switch (mAction)
			{
				case ACTION_DOWN:
				{
					mFlags &= ~FLAG_START_TRACKING;
					bool res = receiver.onKeyDown(mKeyCode, this);
					if (state != null)
					{
						if (res && mRepeatCount == 0 && (mFlags & FLAG_START_TRACKING) != 0)
						{
							state.startTracking(this, target);
						}
						else
						{
							if (isLongPress() && state.isTracking(this))
							{
								try
								{
									if (receiver.onKeyLongPress(mKeyCode, this))
									{
										state.performedLongPress(this);
										res = true;
									}
								}
								catch (java.lang.AbstractMethodError)
								{
								}
							}
						}
					}
					return res;
				}

				case ACTION_UP:
				{
					if (state != null)
					{
						state.handleUpEvent(this);
					}
					return receiver.onKeyUp(mKeyCode, this);
				}

				case ACTION_MULTIPLE:
				{
					int count = mRepeatCount;
					int code = mKeyCode;
					if (receiver.onKeyMultiple(code, count, this))
					{
						return true;
					}
					if (code != android.view.KeyEvent.KEYCODE_UNKNOWN)
					{
						mAction = ACTION_DOWN;
						mRepeatCount = 0;
						bool handled = receiver.onKeyDown(code, this);
						if (handled)
						{
							mAction = ACTION_UP;
							receiver.onKeyUp(code, this);
						}
						mAction = ACTION_MULTIPLE;
						mRepeatCount = count;
						return handled;
					}
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Use with
		/// <see cref="KeyEvent.dispatch(Callback, DispatcherState, object)">KeyEvent.dispatch(Callback, DispatcherState, object)
		/// 	</see>
		/// for more advanced key dispatching, such as long presses.
		/// </summary>
		public class DispatcherState
		{
			internal int mDownKeyCode;

			internal object mDownTarget;

			internal android.util.SparseIntArray mActiveLongPresses = new android.util.SparseIntArray
				();

			/// <summary>Reset back to initial state.</summary>
			/// <remarks>Reset back to initial state.</remarks>
			public virtual void reset()
			{
				mDownKeyCode = 0;
				mDownTarget = null;
				mActiveLongPresses.clear();
			}

			/// <summary>Stop any tracking associated with this target.</summary>
			/// <remarks>Stop any tracking associated with this target.</remarks>
			public virtual void reset(object target)
			{
				if (mDownTarget == target)
				{
					mDownKeyCode = 0;
					mDownTarget = null;
				}
			}

			/// <summary>Start tracking the key code associated with the given event.</summary>
			/// <remarks>
			/// Start tracking the key code associated with the given event.  This
			/// can only be called on a key down.  It will allow you to see any
			/// long press associated with the key, and will result in
			/// <see cref="KeyEvent.isTracking()">KeyEvent.isTracking()</see>
			/// return true on the long press and up
			/// events.
			/// <p>This is only needed if you are directly dispatching events, rather
			/// than handling them in
			/// <see cref="Callback.onKeyDown(int, KeyEvent)">Callback.onKeyDown(int, KeyEvent)</see>
			/// .
			/// </remarks>
			public virtual void startTracking(android.view.KeyEvent @event, object target)
			{
				if (@event.getAction() != ACTION_DOWN)
				{
					throw new System.ArgumentException("Can only start tracking on a down event");
				}
				mDownKeyCode = @event.getKeyCode();
				mDownTarget = target;
			}

			/// <summary>
			/// Return true if the key event is for a key code that is currently
			/// being tracked by the dispatcher.
			/// </summary>
			/// <remarks>
			/// Return true if the key event is for a key code that is currently
			/// being tracked by the dispatcher.
			/// </remarks>
			public virtual bool isTracking(android.view.KeyEvent @event)
			{
				return mDownKeyCode == @event.getKeyCode();
			}

			/// <summary>
			/// Keep track of the given event's key code as having performed an
			/// action with a long press, so no action should occur on the up.
			/// </summary>
			/// <remarks>
			/// Keep track of the given event's key code as having performed an
			/// action with a long press, so no action should occur on the up.
			/// <p>This is only needed if you are directly dispatching events, rather
			/// than handling them in
			/// <see cref="Callback.onKeyLongPress(int, KeyEvent)">Callback.onKeyLongPress(int, KeyEvent)
			/// 	</see>
			/// .
			/// </remarks>
			public virtual void performedLongPress(android.view.KeyEvent @event)
			{
				mActiveLongPresses.put(@event.getKeyCode(), 1);
			}

			/// <summary>Handle key up event to stop tracking.</summary>
			/// <remarks>
			/// Handle key up event to stop tracking.  This resets the dispatcher state,
			/// and updates the key event state based on it.
			/// <p>This is only needed if you are directly dispatching events, rather
			/// than handling them in
			/// <see cref="Callback.onKeyUp(int, KeyEvent)">Callback.onKeyUp(int, KeyEvent)</see>
			/// .
			/// </remarks>
			public virtual void handleUpEvent(android.view.KeyEvent @event)
			{
				int keyCode = @event.getKeyCode();
				int index = mActiveLongPresses.indexOfKey(keyCode);
				if (index >= 0)
				{
					@event.mFlags |= FLAG_CANCELED | FLAG_CANCELED_LONG_PRESS;
					mActiveLongPresses.removeAt(index);
				}
				if (mDownKeyCode == keyCode)
				{
					@event.mFlags |= FLAG_TRACKING;
					mDownKeyCode = 0;
					mDownTarget = null;
				}
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder msg = new java.lang.StringBuilder();
			msg.append("KeyEvent { action=").append(actionToString(mAction));
			msg.append(", keyCode=").append(keyCodeToString(mKeyCode));
			msg.append(", scanCode=").append(mScanCode);
			if (mCharacters != null)
			{
				msg.append(", characters=\"").append(mCharacters).append("\"");
			}
			msg.append(", metaState=").append(metaStateToString(mMetaState));
			msg.append(", flags=0x").append(Sharpen.Util.IntToHexString(mFlags));
			msg.append(", repeatCount=").append(mRepeatCount);
			msg.append(", eventTime=").append(mEventTime);
			msg.append(", downTime=").append(mDownTime);
			msg.append(", deviceId=").append(mDeviceId);
			msg.append(", source=0x").append(Sharpen.Util.IntToHexString(mSource));
			msg.append(" }");
			return msg.ToString();
		}

		/// <summary>
		/// Returns a string that represents the symbolic name of the specified action
		/// such as "ACTION_DOWN", or an equivalent numeric constant such as "35" if unknown.
		/// </summary>
		/// <remarks>
		/// Returns a string that represents the symbolic name of the specified action
		/// such as "ACTION_DOWN", or an equivalent numeric constant such as "35" if unknown.
		/// </remarks>
		/// <param name="action">The action.</param>
		/// <returns>The symbolic name of the specified action.</returns>
		/// <hide></hide>
		public static string actionToString(int action)
		{
			switch (action)
			{
				case ACTION_DOWN:
				{
					return "ACTION_DOWN";
				}

				case ACTION_UP:
				{
					return "ACTION_UP";
				}

				case ACTION_MULTIPLE:
				{
					return "ACTION_MULTIPLE";
				}

				default:
				{
					return System.Convert.ToString(action);
				}
			}
		}

		/// <summary>
		/// Returns a string that represents the symbolic name of the specified keycode
		/// such as "KEYCODE_A", "KEYCODE_DPAD_UP", or an equivalent numeric constant
		/// such as "1001" if unknown.
		/// </summary>
		/// <remarks>
		/// Returns a string that represents the symbolic name of the specified keycode
		/// such as "KEYCODE_A", "KEYCODE_DPAD_UP", or an equivalent numeric constant
		/// such as "1001" if unknown.
		/// </remarks>
		/// <param name="keyCode">The key code.</param>
		/// <returns>The symbolic name of the specified keycode.</returns>
		/// <seealso cref="KeyCharacterMap.getDisplayLabel(int)">KeyCharacterMap.getDisplayLabel(int)
		/// 	</seealso>
		public static string keyCodeToString(int keyCode)
		{
			string symbolicName = KEYCODE_SYMBOLIC_NAMES.get(keyCode);
			return symbolicName != null ? symbolicName : System.Convert.ToString(keyCode);
		}

		/// <summary>
		/// Gets a keycode by its symbolic name such as "KEYCODE_A" or an equivalent
		/// numeric constant such as "1001".
		/// </summary>
		/// <remarks>
		/// Gets a keycode by its symbolic name such as "KEYCODE_A" or an equivalent
		/// numeric constant such as "1001".
		/// </remarks>
		/// <param name="symbolicName">The symbolic name of the keycode.</param>
		/// <returns>
		/// The keycode or
		/// <see cref="KEYCODE_UNKNOWN">KEYCODE_UNKNOWN</see>
		/// if not found.
		/// </returns>
		/// <seealso cref="#keycodeToString">#keycodeToString</seealso>
		public static int keyCodeFromString(string symbolicName)
		{
			if (symbolicName == null)
			{
				throw new System.ArgumentException("symbolicName must not be null");
			}
			int count = KEYCODE_SYMBOLIC_NAMES.size();
			{
				for (int i = 0; i < count; i++)
				{
					if (symbolicName.Equals(KEYCODE_SYMBOLIC_NAMES.valueAt(i)))
					{
						return i;
					}
				}
			}
			try
			{
				return System.Convert.ToInt32(symbolicName, 10);
			}
			catch (System.ArgumentException)
			{
				return KEYCODE_UNKNOWN;
			}
		}

		/// <summary>
		/// Returns a string that represents the symbolic name of the specified combined meta
		/// key modifier state flags such as "0", "META_SHIFT_ON",
		/// "META_ALT_ON|META_SHIFT_ON" or an equivalent numeric constant such as "0x10000000"
		/// if unknown.
		/// </summary>
		/// <remarks>
		/// Returns a string that represents the symbolic name of the specified combined meta
		/// key modifier state flags such as "0", "META_SHIFT_ON",
		/// "META_ALT_ON|META_SHIFT_ON" or an equivalent numeric constant such as "0x10000000"
		/// if unknown.
		/// </remarks>
		/// <param name="metaState">The meta state.</param>
		/// <returns>The symbolic name of the specified combined meta state flags.</returns>
		/// <hide></hide>
		public static string metaStateToString(int metaState)
		{
			if (metaState == 0)
			{
				return "0";
			}
			java.lang.StringBuilder result = null;
			int i = 0;
			while (metaState != 0)
			{
				bool isSet = (metaState & 1) != 0;
				(metaState) = (int)((uint)(metaState) >> 1);
				// unsigned shift!
				if (isSet)
				{
					string name = META_SYMBOLIC_NAMES[i];
					if (result == null)
					{
						if (metaState == 0)
						{
							return name;
						}
						result = new java.lang.StringBuilder(name);
					}
					else
					{
						result.append('|');
						result.append(name);
					}
				}
				i += 1;
			}
			return result.ToString();
		}

		private sealed class _Creator_2793 : android.os.ParcelableClass.Creator<android.view.KeyEvent
			>
		{
			public _Creator_2793()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.KeyEvent createFromParcel(android.os.Parcel @in)
			{
				@in.readInt();
				// skip token, we already know this is a KeyEvent
				return android.view.KeyEvent.createFromParcelBody(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.KeyEvent[] newArray(int size)
			{
				return new android.view.KeyEvent[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.KeyEvent> 
			CREATOR = new _Creator_2793();

		/// <hide></hide>
		public static android.view.KeyEvent createFromParcelBody(android.os.Parcel @in)
		{
			return new android.view.KeyEvent(@in);
		}

		private KeyEvent(android.os.Parcel @in)
		{
			mDeviceId = @in.readInt();
			mSource = @in.readInt();
			mAction = @in.readInt();
			mKeyCode = @in.readInt();
			mRepeatCount = @in.readInt();
			mMetaState = @in.readInt();
			mScanCode = @in.readInt();
			mFlags = @in.readInt();
			mDownTime = @in.readLong();
			mEventTime = @in.readLong();
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public override void writeToParcel(android.os.Parcel @out, int flags)
		{
			@out.writeInt(PARCEL_TOKEN_KEY_EVENT);
			@out.writeInt(mDeviceId);
			@out.writeInt(mSource);
			@out.writeInt(mAction);
			@out.writeInt(mKeyCode);
			@out.writeInt(mRepeatCount);
			@out.writeInt(mMetaState);
			@out.writeInt(mScanCode);
			@out.writeInt(mFlags);
			@out.writeLong(mDownTime);
			@out.writeLong(mEventTime);
		}

		[Sharpen.NativeStub]
		private bool native_isSystemKey(int keyCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.NativeStub]
		private bool native_hasDefaultAction(int keyCode)
		{
			throw new System.NotImplementedException();
		}
	}
}
