using Sharpen;

namespace android.widget.@internal
{
	/// <summary>A basic, embed-able keyboard designed for password entry.</summary>
	/// <remarks>
	/// A basic, embed-able keyboard designed for password entry. Allows entry of all Latin-1 characters.
	/// It has two modes: alpha and numeric. In alpha mode, it allows all Latin-1 characters and enables
	/// an additional keyboard with symbols.  In numeric mode, it shows a 12-key DTMF dialer-like
	/// keypad with alpha characters hints.
	/// </remarks>
	[Sharpen.Sharpened]
	public class PasswordEntryKeyboard : android.inputmethodservice.Keyboard
	{
		internal const int SHIFT_OFF = 0;

		internal const int SHIFT_ON = 1;

		internal const int SHIFT_LOCKED = 2;

		public const int KEYCODE_SPACE = ' ';

		private android.graphics.drawable.Drawable mShiftIcon;

		private android.graphics.drawable.Drawable mShiftLockIcon;

		private android.graphics.drawable.Drawable[] mOldShiftIcons = new android.graphics.drawable.Drawable
			[] { null, null };

		private android.inputmethodservice.Keyboard.Key[] mShiftKeys = new android.inputmethodservice.Keyboard
			.Key[] { null, null };

		private android.inputmethodservice.Keyboard.Key mEnterKey;

		private android.inputmethodservice.Keyboard.Key mF1Key;

		private android.inputmethodservice.Keyboard.Key mSpaceKey;

		private int mShiftState = SHIFT_OFF;

		internal static int sSpacebarVerticalCorrection;

		public PasswordEntryKeyboard(android.content.Context context, int xmlLayoutResId)
			 : this(context, xmlLayoutResId, 0)
		{
		}

		public PasswordEntryKeyboard(android.content.Context context, int xmlLayoutResId, 
			int width, int height) : this(context, xmlLayoutResId, 0, width, height)
		{
		}

		public PasswordEntryKeyboard(android.content.Context context, int xmlLayoutResId, 
			int mode) : base(context, xmlLayoutResId, mode)
		{
			// These two arrays must be the same length
			init(context);
		}

		public PasswordEntryKeyboard(android.content.Context context, int xmlLayoutResId, 
			int mode, int width, int height) : base(context, xmlLayoutResId, mode, width, height
			)
		{
			init(context);
		}

		private void init(android.content.Context context)
		{
			android.content.res.Resources res = context.getResources();
			mShiftIcon = res.getDrawable(android.@internal.R.drawable.sym_keyboard_shift);
			mShiftLockIcon = res.getDrawable(android.@internal.R.drawable.sym_keyboard_shift_locked
				);
			sSpacebarVerticalCorrection = res.getDimensionPixelOffset(android.@internal.R.dimen
				.password_keyboard_spacebar_vertical_correction);
		}

		public PasswordEntryKeyboard(android.content.Context context, int layoutTemplateResId
			, java.lang.CharSequence characters, int columns, int horizontalPadding) : base(
			context, layoutTemplateResId, characters, columns, horizontalPadding)
		{
		}

		[Sharpen.OverridesMethod(@"android.inputmethodservice.Keyboard")]
		protected internal override android.inputmethodservice.Keyboard.Key createKeyFromXml
			(android.content.res.Resources res, android.inputmethodservice.Keyboard.Row parent
			, int x, int y, android.content.res.XmlResourceParser parser)
		{
			android.widget.@internal.PasswordEntryKeyboard.LatinKey key = new android.widget.@internal.PasswordEntryKeyboard
				.LatinKey(res, parent, x, y, parser);
			int code = key.codes[0];
			if (code >= 0 && code != '\n' && (code < 32 || code > 127))
			{
				// Log.w(TAG, "Key code for " + key.label + " is not latin-1");
				key.label = java.lang.CharSequenceProxy.Wrap(" ");
				key.setEnabled(false);
			}
			switch (key.codes[0])
			{
				case 10:
				{
					mEnterKey = key;
					break;
				}

				case android.widget.@internal.PasswordEntryKeyboardView.KEYCODE_F1:
				{
					mF1Key = key;
					break;
				}

				case 32:
				{
					mSpaceKey = key;
					break;
				}
			}
			return key;
		}

		/// <summary>Allows enter key resources to be overridden</summary>
		/// <param name="res">resources to grab given items from</param>
		/// <param name="previewId">preview drawable shown on enter key</param>
		/// <param name="iconId">normal drawable shown on enter key</param>
		/// <param name="labelId">string shown on enter key</param>
		internal virtual void setEnterKeyResources(android.content.res.Resources res, int
			 previewId, int iconId, int labelId)
		{
			if (mEnterKey != null)
			{
				// Reset some of the rarely used attributes.
				mEnterKey.popupCharacters = null;
				mEnterKey.popupResId = 0;
				mEnterKey.text = null;
				mEnterKey.iconPreview = res.getDrawable(previewId);
				mEnterKey.icon = res.getDrawable(iconId);
				mEnterKey.label = res.getText(labelId);
				// Set the initial size of the preview icon
				if (mEnterKey.iconPreview != null)
				{
					mEnterKey.iconPreview.setBounds(0, 0, mEnterKey.iconPreview.getIntrinsicWidth(), 
						mEnterKey.iconPreview.getIntrinsicHeight());
				}
			}
		}

		/// <summary>Allows shiftlock to be turned on.</summary>
		/// <remarks>
		/// Allows shiftlock to be turned on.  See
		/// <see cref="setShiftLocked(bool)">setShiftLocked(bool)</see>
		/// </remarks>
		internal virtual void enableShiftLock()
		{
			int i = 0;
			foreach (int index in getShiftKeyIndices())
			{
				if (index >= 0 && i < mShiftKeys.Length)
				{
					mShiftKeys[i] = getKeys().get(index);
					if (mShiftKeys[i] is android.widget.@internal.PasswordEntryKeyboard.LatinKey)
					{
						((android.widget.@internal.PasswordEntryKeyboard.LatinKey)mShiftKeys[i]).enableShiftLock
							();
					}
					mOldShiftIcons[i] = mShiftKeys[i].icon;
					i++;
				}
			}
		}

		/// <summary>Turn on shift lock.</summary>
		/// <remarks>
		/// Turn on shift lock. This turns on the LED for this key, if it has one.
		/// It should be followed by a call to
		/// <see cref="android.inputmethodservice.KeyboardView.invalidateKey(int)">android.inputmethodservice.KeyboardView.invalidateKey(int)
		/// 	</see>
		/// or
		/// <see cref="android.inputmethodservice.KeyboardView.invalidateAllKeys()">android.inputmethodservice.KeyboardView.invalidateAllKeys()
		/// 	</see>
		/// </remarks>
		/// <param name="shiftLocked"></param>
		internal virtual void setShiftLocked(bool shiftLocked)
		{
			foreach (android.inputmethodservice.Keyboard.Key shiftKey in mShiftKeys)
			{
				if (shiftKey != null)
				{
					shiftKey.on = shiftLocked;
					shiftKey.icon = mShiftLockIcon;
				}
			}
			mShiftState = shiftLocked ? SHIFT_LOCKED : SHIFT_ON;
		}

		/// <summary>Turn on shift mode.</summary>
		/// <remarks>
		/// Turn on shift mode. Sets shift mode and turns on icon for shift key.
		/// It should be followed by a call to
		/// <see cref="android.inputmethodservice.KeyboardView.invalidateKey(int)">android.inputmethodservice.KeyboardView.invalidateKey(int)
		/// 	</see>
		/// or
		/// <see cref="android.inputmethodservice.KeyboardView.invalidateAllKeys()">android.inputmethodservice.KeyboardView.invalidateAllKeys()
		/// 	</see>
		/// </remarks>
		/// <param name="shiftLocked"></param>
		[Sharpen.OverridesMethod(@"android.inputmethodservice.Keyboard")]
		public override bool setShifted(bool shiftState)
		{
			bool shiftChanged = false;
			if (shiftState == false)
			{
				shiftChanged = mShiftState != SHIFT_OFF;
				mShiftState = SHIFT_OFF;
			}
			else
			{
				if (mShiftState == SHIFT_OFF)
				{
					shiftChanged = mShiftState == SHIFT_OFF;
					mShiftState = SHIFT_ON;
				}
			}
			{
				for (int i = 0; i < mShiftKeys.Length; i++)
				{
					if (mShiftKeys[i] != null)
					{
						if (shiftState == false)
						{
							mShiftKeys[i].on = false;
							mShiftKeys[i].icon = mOldShiftIcons[i];
						}
						else
						{
							if (mShiftState == SHIFT_OFF)
							{
								mShiftKeys[i].on = false;
								mShiftKeys[i].icon = mShiftIcon;
							}
						}
					}
				}
			}
			// return super.setShifted(shiftState);
			return shiftChanged;
		}

		/// <summary>Whether or not keyboard is shifted.</summary>
		/// <remarks>Whether or not keyboard is shifted.</remarks>
		/// <returns>true if keyboard state is shifted.</returns>
		[Sharpen.OverridesMethod(@"android.inputmethodservice.Keyboard")]
		public override bool isShifted()
		{
			if (mShiftKeys[0] != null)
			{
				return mShiftState != SHIFT_OFF;
			}
			else
			{
				return base.isShifted();
			}
		}

		internal class LatinKey : android.inputmethodservice.Keyboard.Key
		{
			private bool mShiftLockEnabled;

			private bool mEnabled = true;

			public LatinKey(android.content.res.Resources res, android.inputmethodservice.Keyboard
				.Row parent, int x, int y, android.content.res.XmlResourceParser parser) : base(
				res, parent, x, y, parser)
			{
				if (popupCharacters != null && popupCharacters.Length == 0)
				{
					// If there is a keyboard with no keys specified in popupCharacters
					popupResId = 0;
				}
			}

			internal virtual void setEnabled(bool enabled)
			{
				mEnabled = enabled;
			}

			internal virtual void enableShiftLock()
			{
				mShiftLockEnabled = true;
			}

			[Sharpen.OverridesMethod(@"android.inputmethodservice.Keyboard.Key")]
			public override void onReleased(bool inside)
			{
				if (!mShiftLockEnabled)
				{
					base.onReleased(inside);
				}
				else
				{
					pressed = !pressed;
				}
			}

			/// <summary>Overriding this method so that we can reduce the target area for certain keys.
			/// 	</summary>
			/// <remarks>Overriding this method so that we can reduce the target area for certain keys.
			/// 	</remarks>
			[Sharpen.OverridesMethod(@"android.inputmethodservice.Keyboard.Key")]
			public override bool isInside(int x, int y)
			{
				if (!mEnabled)
				{
					return false;
				}
				int code = codes[0];
				if (code == KEYCODE_SHIFT || code == KEYCODE_DELETE)
				{
					y -= height / 10;
					if (code == KEYCODE_SHIFT)
					{
						x += width / 6;
					}
					if (code == KEYCODE_DELETE)
					{
						x -= width / 6;
					}
				}
				else
				{
					if (code == KEYCODE_SPACE)
					{
						y += android.widget.@internal.PasswordEntryKeyboard.sSpacebarVerticalCorrection;
					}
				}
				return base.isInside(x, y);
			}
		}
	}
}
