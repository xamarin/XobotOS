using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputMethod : android.os.IInterface
	{
		[Sharpen.Stub]
		void attachToken(android.os.IBinder token);

		[Sharpen.Stub]
		void bindInput(android.view.inputmethod.InputBinding binding);

		[Sharpen.Stub]
		void unbindInput();

		[Sharpen.Stub]
		void startInput(android.view.@internal.IInputContext inputContext, android.view.inputmethod.EditorInfo
			 attribute);

		[Sharpen.Stub]
		void restartInput(android.view.@internal.IInputContext inputContext, android.view.inputmethod.EditorInfo
			 attribute);

		[Sharpen.Stub]
		void createSession(android.view.@internal.IInputMethodCallback callback);

		[Sharpen.Stub]
		void setSessionEnabled(android.view.@internal.IInputMethodSession session, bool enabled
			);

		[Sharpen.Stub]
		void revokeSession(android.view.@internal.IInputMethodSession session);

		[Sharpen.Stub]
		void showSoftInput(int flags, android.os.ResultReceiver resultReceiver);

		[Sharpen.Stub]
		void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver);

		[Sharpen.Stub]
		void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype subtype
			);
	}

	[Sharpen.Stub]
	public static class IInputMethodClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputMethod
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputMethod";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputMethod asInterface(android.os.IBinder 
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
			private class Proxy : android.view.@internal.IInputMethod
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
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void attachToken(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void bindInput(android.view.inputmethod.InputBinding binding)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void unbindInput()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void startInput(android.view.@internal.IInputContext inputContext, 
					android.view.inputmethod.EditorInfo attribute)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void restartInput(android.view.@internal.IInputContext inputContext
					, android.view.inputmethod.EditorInfo attribute)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void createSession(android.view.@internal.IInputMethodCallback callback
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void setSessionEnabled(android.view.@internal.IInputMethodSession 
					session, bool enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void revokeSession(android.view.@internal.IInputMethodSession session
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void showSoftInput(int flags, android.os.ResultReceiver resultReceiver
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void hideSoftInput(int flags, android.os.ResultReceiver resultReceiver
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethod")]
				public virtual void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
					 subtype)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_attachToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_bindInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_unbindInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_startInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_restartInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_createSession = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_setSessionEnabled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_revokeSession = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_showSoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_hideSoftInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_changeInputMethodSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			public abstract void attachToken(android.os.IBinder arg1);

			public abstract void bindInput(android.view.inputmethod.InputBinding arg1);

			public abstract void changeInputMethodSubtype(android.view.inputmethod.InputMethodSubtype
				 arg1);

			public abstract void createSession(android.view.@internal.IInputMethodCallback arg1
				);

			public abstract void hideSoftInput(int arg1, android.os.ResultReceiver arg2);

			public abstract void restartInput(android.view.@internal.IInputContext arg1, android.view.inputmethod.EditorInfo
				 arg2);

			public abstract void revokeSession(android.view.@internal.IInputMethodSession arg1
				);

			public abstract void setSessionEnabled(android.view.@internal.IInputMethodSession
				 arg1, bool arg2);

			public abstract void showSoftInput(int arg1, android.os.ResultReceiver arg2);

			public abstract void startInput(android.view.@internal.IInputContext arg1, android.view.inputmethod.EditorInfo
				 arg2);

			public abstract void unbindInput();
		}
	}
}
