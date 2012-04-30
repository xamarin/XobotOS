using System;
using SWF = System.Windows.Forms;

namespace android.view
{
	partial class KeyEvent
	{
		readonly SWF.KeyEventArgs e;

		internal KeyEvent (int action, SWF.KeyEventArgs e)
		{
			this.e = e;
			this.mAction = action;
			this.mKeyCode = GetKeyCode (e);
			this.mRepeatCount = 0;
			this.mDeviceId = KeyCharacterMap.VIRTUAL_KEYBOARD;

			if (e.Alt)
				mMetaState |= META_ALT_ON;
			if (e.Control)
				mMetaState |= META_CTRL_ON;
			if (e.Shift)
				mMetaState |= META_SHIFT_ON;
		}

		static int GetKeyCode (SWF.KeyEventArgs e)
		{
			SWF.Keys code = e.KeyData & SWF.Keys.KeyCode;
			if ((code >= SWF.Keys.A) && (code <= SWF.Keys.Z))
				return KEYCODE_A + (code - SWF.Keys.A);
			else if ((code >= SWF.Keys.D0) && (code <= SWF.Keys.D9))
				return KEYCODE_0 + (code - SWF.Keys.D0);
			else if ((code >= SWF.Keys.NumPad0) && (code <= SWF.Keys.NumPad9))
				return KEYCODE_NUMPAD_0 + (code - SWF.Keys.NumPad9);
			else if ((code >= SWF.Keys.F1) && (code <= SWF.Keys.F24))
				return KEYCODE_F1 + (code - SWF.Keys.F1);
			switch (code) {
			case SWF.Keys.Back:
				return KEYCODE_BACK;
			case SWF.Keys.Tab:
				return KEYCODE_TAB;
			case SWF.Keys.Clear:
				return KEYCODE_CLEAR;
			case SWF.Keys.Enter:
				return KEYCODE_ENTER;
			case SWF.Keys.Escape:
				return KEYCODE_ESCAPE;
			case SWF.Keys.PageUp:
				return KEYCODE_PAGE_UP;
			case SWF.Keys.PageDown:
				return KEYCODE_PAGE_DOWN;
			case SWF.Keys.Home:
				return KEYCODE_HOME;
			case SWF.Keys.Left:
				return KEYCODE_DPAD_LEFT;
			case SWF.Keys.Right:
				return KEYCODE_DPAD_RIGHT;
			case SWF.Keys.Up:
				return KEYCODE_DPAD_UP;
			case SWF.Keys.Down:
				return KEYCODE_DPAD_DOWN;
			case SWF.Keys.Insert:
				return KEYCODE_INSERT;
			case SWF.Keys.Delete:
				return KEYCODE_FORWARD_DEL;
			case SWF.Keys.Multiply:
				return KEYCODE_NUMPAD_MULTIPLY;
			case SWF.Keys.Add:
				return KEYCODE_NUMPAD_ADD;
			case SWF.Keys.Subtract:
				return KEYCODE_NUMPAD_SUBTRACT;
			case SWF.Keys.Divide:
				return KEYCODE_NUMPAD_DIVIDE;
			case SWF.Keys.Space:
				return KEYCODE_SPACE;
			case SWF.Keys.OemBackslash:
				return KEYCODE_BACKSLASH;
			case SWF.Keys.Oemcomma:
				return KEYCODE_COMMA;
			case SWF.Keys.OemPeriod:
				return KEYCODE_PERIOD;
			case SWF.Keys.OemQuestion:
				return KEYCODE_SLASH;
			case SWF.Keys.OemMinus:
				return KEYCODE_MINUS;
			case SWF.Keys.Oemplus:
				return KEYCODE_PLUS;
			case SWF.Keys.Oem4:
				return KEYCODE_LEFT_BRACKET;
			case SWF.Keys.OemCloseBrackets:
				return KEYCODE_RIGHT_BRACKET;
			case SWF.Keys.OemSemicolon:
				return KEYCODE_SEMICOLON;
			case SWF.Keys.Oem7:
				return KEYCODE_APOSTROPHE;
			case SWF.Keys.OemPipe:
				return KEYCODE_POUND;
			case SWF.Keys.Oem3:
				return KEYCODE_GRAVE;
			default:
				Console.WriteLine ("GET KEY CODE: {0} {1}", code, (int)code);
				return -1;
			}
		}

		static char[] symbols = { ')', '!', '@', '#', '$', '%', '^', '&', '*', '(' };

		internal static int GetUnicodeChar (int keyCode, int metaState)
		{
			metaState = normalizeMetaState (metaState);
			bool shift = (metaState & META_SHIFT_ON) != 0;

			if ((keyCode >= KEYCODE_A) && (keyCode <= KEYCODE_Z)) {
				if (shift)
					return 'A' + keyCode - KEYCODE_A;
				else
					return 'a' + keyCode - KEYCODE_A;
			} else if ((keyCode >= KEYCODE_0) && (keyCode <= KEYCODE_9)) {
				if (shift)
					return symbols [keyCode - KEYCODE_0];
				else
					return '0' + keyCode - KEYCODE_0;
			} else if ((keyCode >= KEYCODE_NUMPAD_0) && (keyCode <= KEYCODE_NUMPAD_9)) {
				return '0' + keyCode - KEYCODE_NUMPAD_0;
			}

			switch (keyCode) {
			case KEYCODE_SPACE:
				return ' ';
			case KEYCODE_ENTER:
				return '\n';
			case KEYCODE_NUMPAD_MULTIPLY:
				return '*';
			case KEYCODE_NUMPAD_ADD:
				return '+';
			case KEYCODE_NUMPAD_SUBTRACT:
				return '-';
			case KEYCODE_NUMPAD_DIVIDE:
				return '/';
			case KEYCODE_BACKSLASH:
				return shift ? '>' : '<';
			case KEYCODE_COMMA:
				return shift ? '<' : ',';
			case KEYCODE_PERIOD:
				return shift ? '>' : '.';
			case KEYCODE_SLASH:
				return shift ? '?' : '/';
			case KEYCODE_MINUS:
				return shift ? '_' : '-';
			case KEYCODE_PLUS:
				return shift ? '+' : '=';
			case KEYCODE_LEFT_BRACKET:
				return shift ? '{' : '[';
			case KEYCODE_RIGHT_BRACKET:
				return shift ? '}' : ']';
			case KEYCODE_SEMICOLON:
				return shift ? ':' : ';';
			case KEYCODE_APOSTROPHE:
				return shift ? '"' : '\'';
			case KEYCODE_POUND:
				return shift ? '|' : '\\';
			case KEYCODE_GRAVE:
				return shift ? '~' : '`';
			default:
				return 0;
			}
		}

	}
}

