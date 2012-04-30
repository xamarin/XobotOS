using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Sharpened]
	public class PasswordEntryKeyboardView : android.inputmethodservice.KeyboardView
	{
		internal const int KEYCODE_OPTIONS = -100;

		internal const int KEYCODE_SHIFT_LONGPRESS = -101;

		internal const int KEYCODE_VOICE = -102;

		internal const int KEYCODE_F1 = -103;

		internal const int KEYCODE_NEXT_LANGUAGE = -104;

		public PasswordEntryKeyboardView(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
		}

		public PasswordEntryKeyboardView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		[Sharpen.OverridesMethod(@"android.inputmethodservice.KeyboardView")]
		public override bool setShifted(bool shifted)
		{
			bool result = base.setShifted(shifted);
			// invalidate both shift keys
			int[] indices = getKeyboard().getShiftKeyIndices();
			foreach (int index in indices)
			{
				invalidateKey(index);
			}
			return result;
		}
	}
}
