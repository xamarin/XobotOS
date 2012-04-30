using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface IInputMethodClient : android.os.IInterface
	{
		[Sharpen.Stub]
		void setUsingInputMethod(bool state);

		[Sharpen.Stub]
		void onBindMethod(android.view.@internal.InputBindResult res);

		[Sharpen.Stub]
		void onUnbindMethod(int sequence);

		[Sharpen.Stub]
		void setActive(bool active);
	}

	[Sharpen.Stub]
	public static class IInputMethodClientClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.@internal.IInputMethodClient
		{
			internal const string DESCRIPTOR = "com.android.internal.view.IInputMethodClient";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.@internal.IInputMethodClient asInterface(android.os.IBinder
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
			private class Proxy : android.view.@internal.IInputMethodClient
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
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
				public virtual void setUsingInputMethod(bool state)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
				public virtual void onBindMethod(android.view.@internal.InputBindResult res)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
				public virtual void onUnbindMethod(int sequence)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.view.IInputMethodClient")]
				public virtual void setActive(bool active)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setUsingInputMethod = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onBindMethod = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_onUnbindMethod = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setActive = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			public abstract void onBindMethod(android.view.@internal.InputBindResult arg1);

			public abstract void onUnbindMethod(int arg1);

			public abstract void setActive(bool arg1);

			public abstract void setUsingInputMethod(bool arg1);
		}
	}
}
