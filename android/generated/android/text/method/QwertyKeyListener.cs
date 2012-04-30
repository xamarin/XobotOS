using Sharpen;

namespace android.text.method
{
	/// <summary>
	/// This is the standard key listener for alphabetic input on qwerty
	/// keyboards.
	/// </summary>
	/// <remarks>
	/// This is the standard key listener for alphabetic input on qwerty
	/// keyboards.  You should generally not need to instantiate this yourself;
	/// TextKeyListener will do it for you.
	/// </remarks>
	[Sharpen.Sharpened]
	public class QwertyKeyListener : android.text.method.BaseKeyListener
	{
		private static android.text.method.QwertyKeyListener[] sInstance = new android.text.method.QwertyKeyListener
			[System.Enum.GetValues(typeof(android.text.method.TextKeyListener.Capitalize)).Length
			 * 2];

		private static android.text.method.QwertyKeyListener sFullKeyboardInstance;

		private android.text.method.TextKeyListener.Capitalize mAutoCap;

		private bool mAutoText;

		private bool mFullKeyboard;

		private QwertyKeyListener(android.text.method.TextKeyListener.Capitalize cap, bool
			 autoText, bool fullKeyboard)
		{
			mAutoCap = cap;
			mAutoText = autoText;
			mFullKeyboard = fullKeyboard;
		}

		public QwertyKeyListener(android.text.method.TextKeyListener.Capitalize cap, bool
			 autoText) : this(cap, autoText, false)
		{
		}

		/// <summary>
		/// Returns a new or existing instance with the specified capitalization
		/// and correction properties.
		/// </summary>
		/// <remarks>
		/// Returns a new or existing instance with the specified capitalization
		/// and correction properties.
		/// </remarks>
		public static android.text.method.QwertyKeyListener getInstance(bool autoText, android.text.method.TextKeyListener
			.Capitalize cap)
		{
			int off = (int)(cap) * 2 + (autoText ? 1 : 0);
			if (sInstance[off] == null)
			{
				sInstance[off] = new android.text.method.QwertyKeyListener(cap, autoText);
			}
			return sInstance[off];
		}

		/// <summary>Gets an instance of the listener suitable for use with full keyboards.</summary>
		/// <remarks>
		/// Gets an instance of the listener suitable for use with full keyboards.
		/// Disables auto-capitalization, auto-text and long-press initiated on-screen
		/// character pickers.
		/// </remarks>
		public static android.text.method.QwertyKeyListener getInstanceForFullKeyboard()
		{
			if (sFullKeyboardInstance == null)
			{
				sFullKeyboardInstance = new android.text.method.QwertyKeyListener(android.text.method.TextKeyListener
					.Capitalize.NONE, false, true);
			}
			return sFullKeyboardInstance;
		}

		[Sharpen.ImplementsInterface(@"android.text.method.KeyListener")]
		public override int getInputType()
		{
			return makeTextContentType(mAutoCap, mAutoText);
		}

		[Sharpen.OverridesMethod(@"android.text.method.MetaKeyKeyListener")]
		public override bool onKeyDown(android.view.View view, android.text.Editable content
			, int keyCode, android.view.KeyEvent @event)
		{
			int selStart;
			int selEnd;
			int pref = 0;
			if (view != null)
			{
				pref = android.text.method.TextKeyListener.getInstance().getPrefs(view.getContext
					());
			}
			{
				int a = android.text.Selection.getSelectionStart(content);
				int b = android.text.Selection.getSelectionEnd(content);
				selStart = System.Math.Min(a, b);
				selEnd = System.Math.Max(a, b);
				if (selStart < 0 || selEnd < 0)
				{
					selStart = selEnd = 0;
					android.text.Selection.setSelection(content, 0, 0);
				}
			}
			int activeStart = content.getSpanStart(android.text.method.TextKeyListener.ACTIVE
				);
			int activeEnd = content.getSpanEnd(android.text.method.TextKeyListener.ACTIVE);
			// QWERTY keyboard normal case
			int i = @event.getUnicodeChar(@event.getMetaState() | getMetaState(content));
			if (!mFullKeyboard)
			{
				int count = @event.getRepeatCount();
				if (count > 0 && selStart == selEnd && selStart > 0)
				{
					char c = content[selStart - 1];
					if (c == i || c == Sharpen.CharHelper.ToUpper(i) && view != null)
					{
						if (showCharacterPicker(view, content, c, false, count))
						{
							resetMetaState(content);
							return true;
						}
					}
				}
			}
			if (i == android.view.KeyCharacterMap.PICKER_DIALOG_INPUT)
			{
				if (view != null)
				{
					showCharacterPicker(view, content, android.view.KeyCharacterMap.PICKER_DIALOG_INPUT
						, true, 1);
				}
				resetMetaState(content);
				return true;
			}
			if (i == android.view.KeyCharacterMap.HEX_INPUT)
			{
				int start;
				if (selStart == selEnd)
				{
					start = selEnd;
					while (start > 0 && selEnd - start < 4 && Sharpen.CharHelper.Digit(content[start 
						- 1], 16) >= 0)
					{
						start--;
					}
				}
				else
				{
					start = selStart;
				}
				int ch = -1;
				try
				{
					string hex = android.text.TextUtils.substring(content, start, selEnd);
					ch = System.Convert.ToInt32(hex, 16);
				}
				catch (System.ArgumentException)
				{
				}
				if (ch >= 0)
				{
					selStart = start;
					android.text.Selection.setSelection(content, selStart, selEnd);
					i = ch;
				}
				else
				{
					i = 0;
				}
			}
			if (i != 0)
			{
				bool dead = false;
				if ((i & android.view.KeyCharacterMap.COMBINING_ACCENT) != 0)
				{
					dead = true;
					i = i & android.view.KeyCharacterMap.COMBINING_ACCENT_MASK;
				}
				if (activeStart == selStart && activeEnd == selEnd)
				{
					bool replace = false;
					if (selEnd - selStart - 1 == 0)
					{
						char accent = content[selStart];
						int composed = android.view.KeyEvent.getDeadChar(accent, i);
						if (composed != 0)
						{
							i = composed;
							replace = true;
						}
					}
					if (!replace)
					{
						android.text.Selection.setSelection(content, selEnd);
						content.removeSpan(android.text.method.TextKeyListener.ACTIVE);
						selStart = selEnd;
					}
				}
				if ((pref & android.text.method.TextKeyListener.AUTO_CAP) != 0 && Sharpen.CharHelper.IsLower
					(i) && android.text.method.TextKeyListener.shouldCap(mAutoCap, content, selStart
					))
				{
					int where = content.getSpanEnd(android.text.method.TextKeyListener.CAPPED);
					int flags = content.getSpanFlags(android.text.method.TextKeyListener.CAPPED);
					if (where == selStart && (((flags >> 16) & unchecked((int)(0xFFFF))) == i))
					{
						content.removeSpan(android.text.method.TextKeyListener.CAPPED);
					}
					else
					{
						flags = i << 16;
						i = Sharpen.CharHelper.ToUpper(i);
						if (selStart == 0)
						{
							content.setSpan(android.text.method.TextKeyListener.CAPPED, 0, 0, android.text.SpannedClass.SPAN_MARK_MARK
								 | flags);
						}
						else
						{
							content.setSpan(android.text.method.TextKeyListener.CAPPED, selStart - 1, selStart
								, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE | flags);
						}
					}
				}
				if (selStart != selEnd)
				{
					android.text.Selection.setSelection(content, selEnd);
				}
				content.setSpan(OLD_SEL_START, selStart, selStart, android.text.SpannedClass.SPAN_MARK_MARK
					);
				content.replace(selStart, selEnd, java.lang.CharSequenceProxy.Wrap(((char)i).ToString
					()));
				int oldStart = content.getSpanStart(OLD_SEL_START);
				selEnd = android.text.Selection.getSelectionEnd(content);
				if (oldStart < selEnd)
				{
					content.setSpan(android.text.method.TextKeyListener.LAST_TYPED, oldStart, selEnd, 
						android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
					if (dead)
					{
						android.text.Selection.setSelection(content, oldStart, selEnd);
						content.setSpan(android.text.method.TextKeyListener.ACTIVE, oldStart, selEnd, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE
							);
					}
				}
				adjustMetaAfterKeypress(content);
				// potentially do autotext replacement if the character
				// that was typed was an autotext terminator
				if ((pref & android.text.method.TextKeyListener.AUTO_TEXT) != 0 && mAutoText && (
					i == ' ' || i == '\t' || i == '\n' || i == ',' || i == '.' || i == '!' || i == '?'
					 || i == '"' || Sharpen.CharHelper.GetType(i) == Sharpen.CharHelper.END_PUNCTUATION
					) && content.getSpanEnd(android.text.method.TextKeyListener.INHIBIT_REPLACEMENT)
					 != oldStart)
				{
					int x;
					for (x = oldStart; x > 0; x--)
					{
						char c = content[x - 1];
						if (c != '\'' && !System.Char.IsLetter(c))
						{
							break;
						}
					}
					string rep = getReplacement(content, x, oldStart, view);
					if (rep != null)
					{
						android.text.method.QwertyKeyListener.Replaced[] repl = content.getSpans<android.text.method.QwertyKeyListener
							.Replaced>(0, content.Length);
						{
							for (int a = 0; a < repl.Length; a++)
							{
								content.removeSpan(repl[a]);
							}
						}
						char[] orig = new char[oldStart - x];
						android.text.TextUtils.getChars(content, x, oldStart, orig, 0);
						content.setSpan(new android.text.method.QwertyKeyListener.Replaced(orig), x, oldStart
							, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
						content.replace(x, oldStart, java.lang.CharSequenceProxy.Wrap(rep));
					}
				}
				// Replace two spaces by a period and a space.
				if ((pref & android.text.method.TextKeyListener.AUTO_PERIOD) != 0 && mAutoText)
				{
					selEnd = android.text.Selection.getSelectionEnd(content);
					if (selEnd - 3 >= 0)
					{
						if (content[selEnd - 1] == ' ' && content[selEnd - 2] == ' ')
						{
							char c = content[selEnd - 3];
							{
								for (int j = selEnd - 3; j > 0; j--)
								{
									if (c == '"' || Sharpen.CharHelper.GetType(c) == Sharpen.CharHelper.END_PUNCTUATION)
									{
										c = content[j - 1];
									}
									else
									{
										break;
									}
								}
							}
							if (System.Char.IsLetter(c) || System.Char.IsDigit(c))
							{
								content.replace(selEnd - 2, selEnd - 1, java.lang.CharSequenceProxy.Wrap("."));
							}
						}
					}
				}
				return true;
			}
			else
			{
				if (keyCode == android.view.KeyEvent.KEYCODE_DEL && (@event.hasNoModifiers() || @event
					.hasModifiers(android.view.KeyEvent.META_ALT_ON)) && selStart == selEnd)
				{
					// special backspace case for undoing autotext
					int consider = 1;
					// if backspacing over the last typed character,
					// it undoes the autotext prior to that character
					// (unless the character typed was newline, in which
					// case this behavior would be confusing)
					if (content.getSpanEnd(android.text.method.TextKeyListener.LAST_TYPED) == selStart)
					{
						if (content[selStart - 1] != '\n')
						{
							consider = 2;
						}
					}
					android.text.method.QwertyKeyListener.Replaced[] repl = content.getSpans<android.text.method.QwertyKeyListener
						.Replaced>(selStart - consider, selStart);
					if (repl.Length > 0)
					{
						int st = content.getSpanStart(repl[0]);
						int en = content.getSpanEnd(repl[0]);
						string old = new string(repl[0].mText);
						content.removeSpan(repl[0]);
						// only cancel the autocomplete if the cursor is at the end of
						// the replaced span (or after it, because the user is
						// backspacing over the space after the word, not the word
						// itself).
						if (selStart >= en)
						{
							content.setSpan(android.text.method.TextKeyListener.INHIBIT_REPLACEMENT, en, en, 
								android.text.SpannedClass.SPAN_POINT_POINT);
							content.replace(st, en, java.lang.CharSequenceProxy.Wrap(old));
							en = content.getSpanStart(android.text.method.TextKeyListener.INHIBIT_REPLACEMENT
								);
							if (en - 1 >= 0)
							{
								content.setSpan(android.text.method.TextKeyListener.INHIBIT_REPLACEMENT, en - 1, 
									en, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
							}
							else
							{
								content.removeSpan(android.text.method.TextKeyListener.INHIBIT_REPLACEMENT);
							}
							adjustMetaAfterKeypress(content);
						}
						else
						{
							adjustMetaAfterKeypress(content);
							return base.onKeyDown(view, content, keyCode, @event);
						}
						return true;
					}
				}
			}
			return base.onKeyDown(view, content, keyCode, @event);
		}

		private string getReplacement(java.lang.CharSequence src, int start, int end, android.view.View
			 view)
		{
			int len = end - start;
			bool changecase = false;
			string replacement = android.text.AutoText.get(src, start, end, view);
			if (replacement == null)
			{
				string key = android.text.TextUtils.substring(src, start, end).ToLower();
				replacement = android.text.AutoText.get(java.lang.CharSequenceProxy.Wrap(key), 0, 
					end - start, view);
				changecase = true;
				if (replacement == null)
				{
					return null;
				}
			}
			int caps = 0;
			if (changecase)
			{
				{
					for (int j = start; j < end; j++)
					{
						if (System.Char.IsUpper(src[j]))
						{
							caps++;
						}
					}
				}
			}
			string @out;
			if (caps == 0)
			{
				@out = replacement;
			}
			else
			{
				if (caps == 1)
				{
					@out = toTitleCase(replacement);
				}
				else
				{
					if (caps == len)
					{
						@out = replacement.ToUpper();
					}
					else
					{
						@out = toTitleCase(replacement);
					}
				}
			}
			if (@out.Length == len && android.text.TextUtils.regionMatches(src, start, java.lang.CharSequenceProxy.Wrap
				(@out), 0, len))
			{
				return null;
			}
			return @out;
		}

		/// <summary>
		/// Marks the specified region of <code>content</code> as having
		/// contained <code>original</code> prior to AutoText replacement.
		/// </summary>
		/// <remarks>
		/// Marks the specified region of <code>content</code> as having
		/// contained <code>original</code> prior to AutoText replacement.
		/// Call this method when you have done or are about to do an
		/// AutoText-style replacement on a region of text and want to let
		/// the same mechanism (the user pressing DEL immediately after the
		/// change) undo the replacement.
		/// </remarks>
		/// <param name="content">the Editable text where the replacement was made</param>
		/// <param name="start">the start of the replaced region</param>
		/// <param name="end">the end of the replaced region; the location of the cursor</param>
		/// <param name="original">the text to be restored if the user presses DEL</param>
		public static void markAsReplaced(android.text.Spannable content, int start, int 
			end, string original)
		{
			android.text.method.QwertyKeyListener.Replaced[] repl = content.getSpans<android.text.method.QwertyKeyListener
				.Replaced>(0, content.Length);
			{
				for (int a = 0; a < repl.Length; a++)
				{
					content.removeSpan(repl[a]);
				}
			}
			int len = original.Length;
			char[] orig = new char[len];
			Sharpen.StringHelper.GetCharsForString(original, 0, len, orig, 0);
			content.setSpan(new android.text.method.QwertyKeyListener.Replaced(orig), start, 
				end, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
		}

		private static android.util.SparseArray<string> PICKER_SETS = new android.util.SparseArray
			<string>();

		static QwertyKeyListener()
		{
			PICKER_SETS.put('A', "\u00C0\u00C1\u00C2\u00C4\u00C6\u00C3\u00C5\u0104\u0100");
			PICKER_SETS.put('C', "\u00C7\u0106\u010C");
			PICKER_SETS.put('D', "\u010E");
			PICKER_SETS.put('E', "\u00C8\u00C9\u00CA\u00CB\u0118\u011A\u0112");
			PICKER_SETS.put('G', "\u011E");
			PICKER_SETS.put('L', "\u0141");
			PICKER_SETS.put('I', "\u00CC\u00CD\u00CE\u00CF\u012A\u0130");
			PICKER_SETS.put('N', "\u00D1\u0143\u0147");
			PICKER_SETS.put('O', "\u00D8\u0152\u00D5\u00D2\u00D3\u00D4\u00D6\u014C");
			PICKER_SETS.put('R', "\u0158");
			PICKER_SETS.put('S', "\u015A\u0160\u015E");
			PICKER_SETS.put('T', "\u0164");
			PICKER_SETS.put('U', "\u00D9\u00DA\u00DB\u00DC\u016E\u016A");
			PICKER_SETS.put('Y', "\u00DD\u0178");
			PICKER_SETS.put('Z', "\u0179\u017B\u017D");
			PICKER_SETS.put('a', "\u00E0\u00E1\u00E2\u00E4\u00E6\u00E3\u00E5\u0105\u0101");
			PICKER_SETS.put('c', "\u00E7\u0107\u010D");
			PICKER_SETS.put('d', "\u010F");
			PICKER_SETS.put('e', "\u00E8\u00E9\u00EA\u00EB\u0119\u011B\u0113");
			PICKER_SETS.put('g', "\u011F");
			PICKER_SETS.put('i', "\u00EC\u00ED\u00EE\u00EF\u012B\u0131");
			PICKER_SETS.put('l', "\u0142");
			PICKER_SETS.put('n', "\u00F1\u0144\u0148");
			PICKER_SETS.put('o', "\u00F8\u0153\u00F5\u00F2\u00F3\u00F4\u00F6\u014D");
			PICKER_SETS.put('r', "\u0159");
			PICKER_SETS.put('s', "\u00A7\u00DF\u015B\u0161\u015F");
			PICKER_SETS.put('t', "\u0165");
			PICKER_SETS.put('u', "\u00F9\u00FA\u00FB\u00FC\u016F\u016B");
			PICKER_SETS.put('y', "\u00FD\u00FF");
			PICKER_SETS.put('z', "\u017A\u017C\u017E");
			PICKER_SETS.put(android.view.KeyCharacterMap.PICKER_DIALOG_INPUT, "\u2026\u00A5\u2022\u00AE\u00A9\u00B1[]{}\\|"
				);
			PICKER_SETS.put('/', "\\");
			// From packages/inputmethods/LatinIME/res/xml/kbd_symbols.xml
			PICKER_SETS.put('1', "\u00b9\u00bd\u2153\u00bc\u215b");
			PICKER_SETS.put('2', "\u00b2\u2154");
			PICKER_SETS.put('3', "\u00b3\u00be\u215c");
			PICKER_SETS.put('4', "\u2074");
			PICKER_SETS.put('5', "\u215d");
			PICKER_SETS.put('7', "\u215e");
			PICKER_SETS.put('0', "\u207f\u2205");
			PICKER_SETS.put('$', "\u00a2\u00a3\u20ac\u00a5\u20a3\u20a4\u20b1");
			PICKER_SETS.put('%', "\u2030");
			PICKER_SETS.put('*', "\u2020\u2021");
			PICKER_SETS.put('-', "\u2013\u2014");
			PICKER_SETS.put('+', "\u00b1");
			PICKER_SETS.put('(', "[{<");
			PICKER_SETS.put(')', "]}>");
			PICKER_SETS.put('!', "\u00a1");
			PICKER_SETS.put('"', "\u201c\u201d\u00ab\u00bb\u02dd");
			PICKER_SETS.put('?', "\u00bf");
			PICKER_SETS.put(',', "\u201a\u201e");
			// From packages/inputmethods/LatinIME/res/xml/kbd_symbols_shift.xml
			PICKER_SETS.put('=', "\u2260\u2248\u221e");
			PICKER_SETS.put('<', "\u2264\u00ab\u2039");
			PICKER_SETS.put('>', "\u2265\u00bb\u203a");
		}

		private bool showCharacterPicker(android.view.View view, android.text.Editable content
			, char c, bool insert, int count)
		{
			string set = PICKER_SETS.get(c);
			if (set == null)
			{
				return false;
			}
			if (count == 1)
			{
				new android.text.method.CharacterPickerDialog(view.getContext(), view, content, set
					, insert).show();
			}
			return true;
		}

		private static string toTitleCase(string src)
		{
			return System.Char.ToUpper(src[0]) + Sharpen.StringHelper.Substring(src, 1);
		}

		internal class Replaced : android.text.NoCopySpan
		{
			public Replaced(char[] text)
			{
				mText = text;
			}

			internal char[] mText;
		}
	}
}
