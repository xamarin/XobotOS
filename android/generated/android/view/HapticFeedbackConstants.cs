using Sharpen;

namespace android.view
{
	/// <summary>
	/// Constants to be used to perform haptic feedback effects via
	/// <see cref="View.performHapticFeedback(int)">View.performHapticFeedback(int)</see>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public class HapticFeedbackConstants
	{
		private HapticFeedbackConstants()
		{
		}

		/// <summary>
		/// The user has performed a long press on an object that is resulting
		/// in an action being performed.
		/// </summary>
		/// <remarks>
		/// The user has performed a long press on an object that is resulting
		/// in an action being performed.
		/// </remarks>
		public const int LONG_PRESS = 0;

		/// <summary>The user has pressed on a virtual on-screen key.</summary>
		/// <remarks>The user has pressed on a virtual on-screen key.</remarks>
		public const int VIRTUAL_KEY = 1;

		/// <summary>The user has pressed a soft keyboard key.</summary>
		/// <remarks>The user has pressed a soft keyboard key.</remarks>
		public const int KEYBOARD_TAP = 3;

		/// <summary>This is a private constant.</summary>
		/// <remarks>This is a private constant.  Feel free to renumber as desired.</remarks>
		/// <hide></hide>
		public const int SAFE_MODE_DISABLED = 10000;

		/// <summary>This is a private constant.</summary>
		/// <remarks>This is a private constant.  Feel free to renumber as desired.</remarks>
		/// <hide></hide>
		public const int SAFE_MODE_ENABLED = 10001;

		/// <summary>
		/// Flag for
		/// <see cref="View.performHapticFeedback(int, int)">View.performHapticFeedback(int, int)
		/// 	</see>
		/// : Ignore the setting in the
		/// view for whether to perform haptic feedback, do it always.
		/// </summary>
		public const int FLAG_IGNORE_VIEW_SETTING = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="View.performHapticFeedback(int, int)">View.performHapticFeedback(int, int)
		/// 	</see>
		/// : Ignore the global setting
		/// for whether to perform haptic feedback, do it always.
		/// </summary>
		public const int FLAG_IGNORE_GLOBAL_SETTING = unchecked((int)(0x0002));
	}
}
