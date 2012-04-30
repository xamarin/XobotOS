using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface DialogInterface
	{
		[Sharpen.Stub]
		void cancel();

		[Sharpen.Stub]
		void dismiss();
	}

	[Sharpen.Stub]
	public static class DialogInterfaceClass
	{
		public const int BUTTON_POSITIVE = -1;

		public const int BUTTON_NEGATIVE = -2;

		public const int BUTTON_NEUTRAL = -3;

		[System.ObsoleteAttribute(@"Use android.content.DialogInterfaceClass.BUTTON_POSITIVE"
			)]
		public const int BUTTON1 = android.content.DialogInterfaceClass.BUTTON_POSITIVE;

		[System.ObsoleteAttribute(@"Use android.content.DialogInterfaceClass.BUTTON_NEGATIVE"
			)]
		public const int BUTTON2 = android.content.DialogInterfaceClass.BUTTON_NEGATIVE;

		[System.ObsoleteAttribute(@"Use android.content.DialogInterfaceClass.BUTTON_NEUTRAL"
			)]
		public const int BUTTON3 = android.content.DialogInterfaceClass.BUTTON_NEUTRAL;

		[Sharpen.Stub]
		public interface OnCancelListener
		{
			[Sharpen.Stub]
			void onCancel(android.content.DialogInterface dialog);
		}

		[Sharpen.Stub]
		public interface OnDismissListener
		{
			[Sharpen.Stub]
			void onDismiss(android.content.DialogInterface dialog);
		}

		[Sharpen.Stub]
		public interface OnShowListener
		{
			[Sharpen.Stub]
			void onShow(android.content.DialogInterface dialog);
		}

		[Sharpen.Stub]
		public interface OnClickListener
		{
			[Sharpen.Stub]
			void onClick(android.content.DialogInterface dialog, int which);
		}

		[Sharpen.Stub]
		public interface OnMultiChoiceClickListener
		{
			[Sharpen.Stub]
			void onClick(android.content.DialogInterface dialog, int which, bool isChecked);
		}

		[Sharpen.Stub]
		public interface OnKeyListener
		{
			[Sharpen.Stub]
			bool onKey(android.content.DialogInterface dialog, int keyCode, android.view.KeyEvent
				 @event);
		}
	}
}
