using Sharpen;

namespace android.os.@internal
{
	[Sharpen.Stub]
	public interface IResultReceiver : android.os.IInterface
	{
		[Sharpen.Stub]
		void send(int resultCode, android.os.Bundle resultData);
	}

	[Sharpen.Stub]
	public static class IResultReceiverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.os.@internal.IResultReceiver
		{
			internal const string DESCRIPTOR = "com.android.internal.os.IResultReceiver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.os.@internal.IResultReceiver asInterface(android.os.IBinder
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
			private class Proxy : android.os.@internal.IResultReceiver
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
				[Sharpen.ImplementsInterface(@"com.android.internal.os.IResultReceiver")]
				public virtual void send(int resultCode, android.os.Bundle resultData)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_send = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void send(int arg1, android.os.Bundle arg2);
		}
	}
}
