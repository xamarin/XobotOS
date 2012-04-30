using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class PasswordEntryKeyboardHelper : android.inputmethodservice.KeyboardView
		.OnKeyboardActionListener
	{
		public const int KEYBOARD_MODE_ALPHA = 0;

		public const int KEYBOARD_MODE_NUMERIC = 1;

		internal const int KEYBOARD_STATE_NORMAL = 0;

		internal const int KEYBOARD_STATE_SHIFTED = 1;

		internal const int KEYBOARD_STATE_CAPSLOCK = 2;

		internal const string TAG = "PasswordEntryKeyboardHelper";

		private int mKeyboardMode = KEYBOARD_MODE_ALPHA;

		private int mKeyboardState = KEYBOARD_STATE_NORMAL;

		private android.widget.@internal.PasswordEntryKeyboard mQwertyKeyboard;

		private android.widget.@internal.PasswordEntryKeyboard mQwertyKeyboardShifted;

		private android.widget.@internal.PasswordEntryKeyboard mSymbolsKeyboard;

		private android.widget.@internal.PasswordEntryKeyboard mSymbolsKeyboardShifted;

		private android.widget.@internal.PasswordEntryKeyboard mNumericKeyboard;

		private readonly android.content.Context mContext;

		private readonly android.view.View mTargetView;

		private readonly android.inputmethodservice.KeyboardView mKeyboardView;

		private long[] mVibratePattern;

		private bool mEnableHaptics = false;

		[Sharpen.Stub]
		public PasswordEntryKeyboardHelper(android.content.Context context, android.inputmethodservice.KeyboardView
			 keyboardView, android.view.View targetView) : this(context, keyboardView, targetView
			, true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public PasswordEntryKeyboardHelper(android.content.Context context, android.inputmethodservice.KeyboardView
			 keyboardView, android.view.View targetView, bool useFullScreenWidth)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEnableHaptics(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isAlpha()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void createKeyboardsWithSpecificSize(int viewWidth, int viewHeight)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void createKeyboards()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setKeyboardMode(int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendKeyEventsToTarget(int character)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void sendDownUpKeyEvents(int keyEventCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void onKey(int primaryCode, int[] keyCodes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVibratePattern(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleModeChange()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void handleBackspace()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleShift()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleCharacter(int primaryCode, int[] keyCodes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleClose()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void onPress(int primaryCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performHapticFeedback()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void onRelease(int primaryCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void onText(java.lang.CharSequence text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void swipeDown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void swipeLeft()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void swipeRight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.inputmethodservice.KeyboardView.OnKeyboardActionListener"
			)]
		public virtual void swipeUp()
		{
			throw new System.NotImplementedException();
		}
	}
}
