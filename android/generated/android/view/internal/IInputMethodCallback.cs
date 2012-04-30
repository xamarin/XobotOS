using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputMethodCallback : android.os.IInterface
	{
		[Sharpen.Stub]
		void finishedEvent(int seq, bool handled);

		[Sharpen.Stub]
		void sessionCreated(android.view.@internal.IInputMethodSession session);
	}

	[Sharpen.Stub]
	public static class IInputMethodCallbackClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputMethodCallback
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputMethodCallback";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputMethodCallback asInterface(android.os.IBinder
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
			private class Proxy : android.view.@internal.IInputMethodCallback
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
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
				public virtual void finishedEvent(int seq, bool handled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodCallback")]
				public virtual void sessionCreated(android.view.@internal.IInputMethodSession session
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_finishedEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_sessionCreated = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void finishedEvent(int arg1, bool arg2);

			public abstract void sessionCreated(android.view.@internal.IInputMethodSession arg1
				);
		}
	}
}
