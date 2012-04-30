using Sharpen;

namespace android.widget
{
	[Sharpen.Sharpened]
	public class DialerFilter : android.widget.RelativeLayout
	{
		public DialerFilter(android.content.Context context) : base(context)
		{
		}

		public DialerFilter(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			// Setup the filter view
			mInputFilters = new android.text.InputFilter[] { new android.text.InputFilterClass
				.AllCaps() };
			mHint = (android.widget.EditText)findViewById(android.@internal.R.id.hint);
			if (mHint == null)
			{
				throw new System.InvalidOperationException("DialerFilter must have a child EditText named hint"
					);
			}
			mHint.setFilters(mInputFilters);
			mLetters = mHint;
			mLetters.setKeyListener(android.text.method.TextKeyListener.getInstance());
			mLetters.setMovementMethod(null);
			mLetters.setFocusable(false);
			// Setup the digits view
			mPrimary = (android.widget.EditText)findViewById(android.@internal.R.id.primary);
			if (mPrimary == null)
			{
				throw new System.InvalidOperationException("DialerFilter must have a child EditText named primary"
					);
			}
			mPrimary.setFilters(mInputFilters);
			mDigits = mPrimary;
			mDigits.setKeyListener(android.text.method.DialerKeyListener.getInstance());
			mDigits.setMovementMethod(null);
			mDigits.setFocusable(false);
			// Look for an icon
			mIcon = (android.widget.ImageView)findViewById(android.@internal.R.id.icon);
			// Setup focus & highlight for this view
			setFocusable(true);
			// XXX Force the mode to QWERTY for now, since 12-key isn't supported
			mIsQwerty = true;
			setMode(DIGITS_AND_LETTERS);
		}

		/// <summary>Only show the icon view when focused, if there is one.</summary>
		/// <remarks>Only show the icon view when focused, if there is one.</remarks>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFocusChanged(bool focused, int direction, android.graphics.Rect
			 previouslyFocusedRect)
		{
			base.onFocusChanged(focused, direction, previouslyFocusedRect);
			if (mIcon != null)
			{
				mIcon.setVisibility(focused ? android.view.View.VISIBLE : android.view.View.GONE);
			}
		}

		public virtual bool isQwertyKeyboard()
		{
			return mIsQwerty;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			bool handled = false;
			switch (keyCode)
			{
				case android.view.KeyEvent.KEYCODE_DPAD_UP:
				case android.view.KeyEvent.KEYCODE_DPAD_DOWN:
				case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
				case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
				case android.view.KeyEvent.KEYCODE_ENTER:
				case android.view.KeyEvent.KEYCODE_DPAD_CENTER:
				{
					break;
				}

				case android.view.KeyEvent.KEYCODE_DEL:
				{
					switch (mMode)
					{
						case DIGITS_AND_LETTERS:
						{
							handled = mDigits.onKeyDown(keyCode, @event);
							handled &= mLetters.onKeyDown(keyCode, @event);
							break;
						}

						case DIGITS_AND_LETTERS_NO_DIGITS:
						{
							handled = mLetters.onKeyDown(keyCode, @event);
							if (((android.text.Editable)mLetters.getText()).Length == ((android.text.Editable
								)mDigits.getText()).Length)
							{
								setMode(DIGITS_AND_LETTERS);
							}
							break;
						}

						case DIGITS_AND_LETTERS_NO_LETTERS:
						{
							if (((android.text.Editable)mDigits.getText()).Length == ((android.text.Editable)
								mLetters.getText()).Length)
							{
								mLetters.onKeyDown(keyCode, @event);
								setMode(DIGITS_AND_LETTERS);
							}
							handled = mDigits.onKeyDown(keyCode, @event);
							break;
						}

						case DIGITS_ONLY:
						{
							handled = mDigits.onKeyDown(keyCode, @event);
							break;
						}

						case LETTERS_ONLY:
						{
							handled = mLetters.onKeyDown(keyCode, @event);
							break;
						}
					}
					break;
				}

				default:
				{
					switch (mMode)
					{
						case DIGITS_AND_LETTERS:
						{
							//mIsQwerty = msg.getKeyIsQwertyKeyboard();
							handled = mLetters.onKeyDown(keyCode, @event);
							// pass this throw so the shift state is correct (for example,
							// on a standard QWERTY keyboard, * and 8 are on the same key)
							if (android.view.KeyEvent.isModifierKey(keyCode))
							{
								mDigits.onKeyDown(keyCode, @event);
								handled = true;
								break;
							}
							// Only check to see if the digit is valid if the key is a printing key
							// in the TextKeyListener. This prevents us from hiding the digits
							// line when keys like UP and DOWN are hit.
							// XXX note that KEYCODE_TAB is special-cased here for 
							// devices that share tab and 0 on a single key.
							bool isPrint = @event.isPrintingKey();
							if (isPrint || keyCode == android.view.KeyEvent.KEYCODE_SPACE || keyCode == android.view.KeyEvent
								.KEYCODE_TAB)
							{
								char c = @event.getMatch(android.text.method.DialerKeyListener.CHARACTERS);
								if (c != 0)
								{
									handled &= mDigits.onKeyDown(keyCode, @event);
								}
								else
								{
									setMode(DIGITS_AND_LETTERS_NO_DIGITS);
								}
							}
							break;
						}

						case DIGITS_AND_LETTERS_NO_LETTERS:
						case DIGITS_ONLY:
						{
							handled = mDigits.onKeyDown(keyCode, @event);
							break;
						}

						case DIGITS_AND_LETTERS_NO_DIGITS:
						case LETTERS_ONLY:
						{
							handled = mLetters.onKeyDown(keyCode, @event);
							break;
						}
					}
					break;
				}
			}
			if (!handled)
			{
				return base.onKeyDown(keyCode, @event);
			}
			else
			{
				return true;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			bool a = mLetters.onKeyUp(keyCode, @event);
			bool b = mDigits.onKeyUp(keyCode, @event);
			return a || b;
		}

		public virtual int getMode()
		{
			return mMode;
		}

		/// <summary>Change the mode of the widget.</summary>
		/// <remarks>Change the mode of the widget.</remarks>
		/// <param name="newMode">The mode to switch to.</param>
		public virtual void setMode(int newMode)
		{
			switch (newMode)
			{
				case DIGITS_AND_LETTERS:
				{
					makeDigitsPrimary();
					mLetters.setVisibility(android.view.View.VISIBLE);
					mDigits.setVisibility(android.view.View.VISIBLE);
					break;
				}

				case DIGITS_ONLY:
				{
					makeDigitsPrimary();
					mLetters.setVisibility(android.view.View.GONE);
					mDigits.setVisibility(android.view.View.VISIBLE);
					break;
				}

				case LETTERS_ONLY:
				{
					makeLettersPrimary();
					mLetters.setVisibility(android.view.View.VISIBLE);
					mDigits.setVisibility(android.view.View.GONE);
					break;
				}

				case DIGITS_AND_LETTERS_NO_LETTERS:
				{
					makeDigitsPrimary();
					mLetters.setVisibility(android.view.View.INVISIBLE);
					mDigits.setVisibility(android.view.View.VISIBLE);
					break;
				}

				case DIGITS_AND_LETTERS_NO_DIGITS:
				{
					makeLettersPrimary();
					mLetters.setVisibility(android.view.View.VISIBLE);
					mDigits.setVisibility(android.view.View.INVISIBLE);
					break;
				}
			}
			int oldMode = mMode;
			mMode = newMode;
			onModeChange(oldMode, newMode);
		}

		private void makeLettersPrimary()
		{
			if (mPrimary == mDigits)
			{
				swapPrimaryAndHint(true);
			}
		}

		private void makeDigitsPrimary()
		{
			if (mPrimary == mLetters)
			{
				swapPrimaryAndHint(false);
			}
		}

		private void swapPrimaryAndHint(bool makeLettersPrimary_1)
		{
			android.text.Editable lettersText = ((android.text.Editable)mLetters.getText());
			android.text.Editable digitsText = ((android.text.Editable)mDigits.getText());
			android.text.method.KeyListener lettersInput = mLetters.getKeyListener();
			android.text.method.KeyListener digitsInput = mDigits.getKeyListener();
			if (makeLettersPrimary_1)
			{
				mLetters = mPrimary;
				mDigits = mHint;
			}
			else
			{
				mLetters = mHint;
				mDigits = mPrimary;
			}
			mLetters.setKeyListener(lettersInput);
			mLetters.setText(lettersText);
			lettersText = ((android.text.Editable)mLetters.getText());
			android.text.Selection.setSelection(lettersText, lettersText.Length);
			mDigits.setKeyListener(digitsInput);
			mDigits.setText(digitsText);
			digitsText = ((android.text.Editable)mDigits.getText());
			android.text.Selection.setSelection(digitsText, digitsText.Length);
			// Reset the filters
			mPrimary.setFilters(mInputFilters);
			mHint.setFilters(mInputFilters);
		}

		public virtual java.lang.CharSequence getLetters()
		{
			if (mLetters.getVisibility() == android.view.View.VISIBLE)
			{
				return ((android.text.Editable)mLetters.getText());
			}
			else
			{
				return java.lang.CharSequenceProxy.Wrap(string.Empty);
			}
		}

		public virtual java.lang.CharSequence getDigits()
		{
			if (mDigits.getVisibility() == android.view.View.VISIBLE)
			{
				return ((android.text.Editable)mDigits.getText());
			}
			else
			{
				return java.lang.CharSequenceProxy.Wrap(string.Empty);
			}
		}

		public virtual java.lang.CharSequence getFilterText()
		{
			if (mMode != DIGITS_ONLY)
			{
				return getLetters();
			}
			else
			{
				return getDigits();
			}
		}

		public virtual void append(string text)
		{
			switch (mMode)
			{
				case DIGITS_AND_LETTERS:
				{
					((android.text.Editable)mDigits.getText()).append(java.lang.CharSequenceProxy.Wrap
						(text));
					((android.text.Editable)mLetters.getText()).append(java.lang.CharSequenceProxy.Wrap
						(text));
					break;
				}

				case DIGITS_AND_LETTERS_NO_LETTERS:
				case DIGITS_ONLY:
				{
					((android.text.Editable)mDigits.getText()).append(java.lang.CharSequenceProxy.Wrap
						(text));
					break;
				}

				case DIGITS_AND_LETTERS_NO_DIGITS:
				case LETTERS_ONLY:
				{
					((android.text.Editable)mLetters.getText()).append(java.lang.CharSequenceProxy.Wrap
						(text));
					break;
				}
			}
		}

		/// <summary>Clears both the digits and the filter text.</summary>
		/// <remarks>Clears both the digits and the filter text.</remarks>
		public virtual void clearText()
		{
			android.text.Editable text;
			text = ((android.text.Editable)mLetters.getText());
			text.clear();
			text = ((android.text.Editable)mDigits.getText());
			text.clear();
			// Reset the mode based on the hardware type
			if (mIsQwerty)
			{
				setMode(DIGITS_AND_LETTERS);
			}
			else
			{
				setMode(DIGITS_ONLY);
			}
		}

		public virtual void setLettersWatcher(android.text.TextWatcher watcher)
		{
			java.lang.CharSequence text = ((android.text.Editable)mLetters.getText());
			android.text.Spannable span = (android.text.Spannable)text;
			span.setSpan(watcher, 0, text.Length, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
				);
		}

		public virtual void setDigitsWatcher(android.text.TextWatcher watcher)
		{
			java.lang.CharSequence text = ((android.text.Editable)mDigits.getText());
			android.text.Spannable span = (android.text.Spannable)text;
			span.setSpan(watcher, 0, text.Length, android.text.SpannedClass.SPAN_INCLUSIVE_INCLUSIVE
				);
		}

		public virtual void setFilterWatcher(android.text.TextWatcher watcher)
		{
			if (mMode != DIGITS_ONLY)
			{
				setLettersWatcher(watcher);
			}
			else
			{
				setDigitsWatcher(watcher);
			}
		}

		public virtual void removeFilterWatcher(android.text.TextWatcher watcher)
		{
			android.text.Spannable text;
			if (mMode != DIGITS_ONLY)
			{
				text = ((android.text.Editable)mLetters.getText());
			}
			else
			{
				text = ((android.text.Editable)mDigits.getText());
			}
			text.removeSpan(watcher);
		}

		/// <summary>
		/// Called right after the mode changes to give subclasses the option to
		/// restyle, etc.
		/// </summary>
		/// <remarks>
		/// Called right after the mode changes to give subclasses the option to
		/// restyle, etc.
		/// </remarks>
		protected internal virtual void onModeChange(int oldMode, int newMode)
		{
		}

		/// <summary>This mode has both lines</summary>
		public const int DIGITS_AND_LETTERS = 1;

		/// <summary>
		/// This mode is when after starting in
		/// <see cref="DIGITS_AND_LETTERS">DIGITS_AND_LETTERS</see>
		/// mode the filter
		/// has removed all possibility of the digits matching, leaving only the letters line
		/// </summary>
		public const int DIGITS_AND_LETTERS_NO_DIGITS = 2;

		/// <summary>
		/// This mode is when after starting in
		/// <see cref="DIGITS_AND_LETTERS">DIGITS_AND_LETTERS</see>
		/// mode the filter
		/// has removed all possibility of the letters matching, leaving only the digits line
		/// </summary>
		public const int DIGITS_AND_LETTERS_NO_LETTERS = 3;

		/// <summary>This mode has only the digits line</summary>
		public const int DIGITS_ONLY = 4;

		/// <summary>This mode has only the letters line</summary>
		public const int LETTERS_ONLY = 5;

		internal android.widget.EditText mLetters;

		internal android.widget.EditText mDigits;

		internal android.widget.EditText mPrimary;

		internal android.widget.EditText mHint;

		internal android.text.InputFilter[] mInputFilters;

		internal android.widget.ImageView mIcon;

		internal int mMode;

		private bool mIsQwerty;
	}
}
