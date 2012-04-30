using Sharpen;

namespace android.view.inputmethod
{
	[Sharpen.Stub]
	public interface InputMethod
	{
		[Sharpen.Stub]
		void attachToken(android.os.IBinder token);

		[Sharpen.Stub]
		void bindInput(android.view.inputmethod.InputBinding binding);

		[Sharpen.Stub]
		void unbindInput();

		[Sharpen.Stub]
		void startInput(android.view.inputmethod.InputConnection inputConnection, android.view.inputmethod.EditorInfo
			 info);

		[Sharpen.Stub]
		void restartInput(android.view.inputmethod.InputConnection inputConnection, android.view.inputmethod.EditorInfo
			 attribute);

		[Sharpen.Stub]
		void createSession(android.view.inputmethod.InputMethodClass.SessionCallback callback
			);

		[Sharpen.Stub]
		void setSessionEnabled(android.view.inputmethod.InputMethodSession session, bool 
			enabled);

		[Sharpen.Stub]
		void revokeSession(android.view.inputmethod.InputMethodSession session);

		[Sharpen.Stub]
		void showSoftInput(int flags, android.os.ResultReceiver resultReceiver);

		[Sharpen.Stub]
		void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver);

		[Sharpen.Stub]
		void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype
			);
	}

	[Sharpen.Stub]
	public static class InputMethodClass
	{
		public const string SERVICE_INTERFACE = "android.view.InputMethod";

		public const string SERVICE_META_DATA = "android.view.im";

		[Sharpen.Stub]
		public interface SessionCallback
		{
			[Sharpen.Stub]
			void sessionCreated(android.view.inputmethod.InputMethodSession session);
		}

		public const int SHOW_EXPLICIT = unchecked((int)(0x00001));

		public const int SHOW_FORCED = unchecked((int)(0x00002));
	}
}
