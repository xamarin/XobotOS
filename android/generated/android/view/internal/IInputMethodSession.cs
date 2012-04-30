using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputMethodSession : android.os.IInterface
	{
		[Sharpen.Stub]
		void finishInput();

		[Sharpen.Stub]
		void updateExtractedText(int token, android.view.inputmethod.ExtractedText text);

		[Sharpen.Stub]
		void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart, int newSelEnd
			, int candidatesStart, int candidatesEnd);

		[Sharpen.Stub]
		void viewClicked(bool focusChanged);

		[Sharpen.Stub]
		void updateCursor(android.graphics.Rect newCursor);

		[Sharpen.Stub]
		void displayCompletions(android.view.inputmethod.CompletionInfo[] completions);

		[Sharpen.Stub]
		void dispatchKeyEvent(int seq, android.view.KeyEvent @event, android.view.@internal.IInputMethodCallback
			 callback);

		[Sharpen.Stub]
		void dispatchTrackballEvent(int seq, android.view.MotionEvent @event, android.view.@internal.IInputMethodCallback
			 callback);

		[Sharpen.Stub]
		void appPrivateCommand(string action, android.os.Bundle data);

		[Sharpen.Stub]
		void toggleSoftInput(int showFlags, int hideFlags);

		[Sharpen.Stub]
		void finishSession();
	}

	[Sharpen.Stub]
	public static class IInputMethodSessionClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputMethodSession
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputMethodSession";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputMethodSession asInterface(android.os.IBinder
				 obj)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.IInterface")]
			public virtual android.os.IBinder asBinder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Binder")]
			protected internal override bool onTransact(int code, android.os.Parcel data, android.os.Parcel
				 reply, int flags)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class Proxy : android.view.@internal.IInputMethodSession
			{
				internal android.os.IBinder mRemote;

				[Sharpen.Stub]
				internal Proxy(android.os.IBinder remote)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.IInterface")]
				public virtual android.os.IBinder asBinder()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				public virtual string getInterfaceDescriptor()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void finishInput()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void updateExtractedText(int token, android.view.inputmethod.ExtractedText
					 text)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void updateSelection(int oldSelStart, int oldSelEnd, int newSelStart
					, int newSelEnd, int candidatesStart, int candidatesEnd)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void viewClicked(bool focusChanged)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void updateCursor(android.graphics.Rect newCursor)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void displayCompletions(android.view.inputmethod.CompletionInfo[] 
					completions)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void dispatchKeyEvent(int seq, android.view.KeyEvent @event, android.view.@internal.IInputMethodCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void dispatchTrackballEvent(int seq, android.view.MotionEvent @event
					, android.view.@internal.IInputMethodCallback callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void appPrivateCommand(string action, android.os.Bundle data)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void toggleSoftInput(int showFlags, int hideFlags)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodSession")]
				public virtual void finishSession()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_finishInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_updateExtractedText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_updateSelection = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_viewClicked = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_updateCursor = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_displayCompletions = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_dispatchKeyEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_dispatchTrackballEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_appPrivateCommand = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_toggleSoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_finishSession = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			public abstract void appPrivateCommand(string arg1, android.os.Bundle arg2);

			public abstract void dispatchKeyEvent(int arg1, android.view.KeyEvent arg2, android.view.@internal.IInputMethodCallback
				 arg3);

			public abstract void dispatchTrackballEvent(int arg1, android.view.MotionEvent arg2
				, android.view.@internal.IInputMethodCallback arg3);

			public abstract void displayCompletions(android.view.inputmethod.CompletionInfo[]
				 arg1);

			public abstract void finishInput();

			public abstract void finishSession();

			public abstract void toggleSoftInput(int arg1, int arg2);

			public abstract void updateCursor(android.graphics.Rect arg1);

			public abstract void updateExtractedText(int arg1, android.view.inputmethod.ExtractedText
				 arg2);

			public abstract void updateSelection(int arg1, int arg2, int arg3, int arg4, int 
				arg5, int arg6);

			public abstract void viewClicked(bool arg1);
		}
	}
}
