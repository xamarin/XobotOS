using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IIntentSender : android.os.IInterface
	{
		[Sharpen.Stub]
		int send(int code, android.content.Intent intent, string resolvedType, android.content.IIntentReceiver
			 finishedReceiver, string requiredPermission);
	}

	[Sharpen.Stub]
	public static class IIntentSenderClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.IIntentSender
		{
			internal const string DESCRIPTOR = "android.content.IIntentSender";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.IIntentSender asInterface(android.os.IBinder obj)
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
			private class Proxy : android.content.IIntentSender
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
				[Sharpen.ImplementsInterface(@"android.content.IIntentSender")]
				public virtual int send(int code, android.content.Intent intent, string resolvedType
					, android.content.IIntentReceiver finishedReceiver, string requiredPermission)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_send = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract int send(int arg1, android.content.Intent arg2, string arg3, android.content.IIntentReceiver
				 arg4, string arg5);
		}
	}
}
