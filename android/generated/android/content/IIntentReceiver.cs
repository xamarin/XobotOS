using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IIntentReceiver : android.os.IInterface
	{
		[Sharpen.Stub]
		void performReceive(android.content.Intent intent, int resultCode, string data, android.os.Bundle
			 extras, bool ordered, bool sticky);
	}

	[Sharpen.Stub]
	public static class IIntentReceiverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.IIntentReceiver
		{
			internal const string DESCRIPTOR = "android.content.IIntentReceiver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.IIntentReceiver asInterface(android.os.IBinder obj)
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
			private class Proxy : android.content.IIntentReceiver
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
				[Sharpen.ImplementsInterface(@"android.content.IIntentReceiver")]
				public virtual void performReceive(android.content.Intent intent, int resultCode, 
					string data, android.os.Bundle extras, bool ordered, bool sticky)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_performReceive = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void performReceive(android.content.Intent arg1, int arg2, string
				 arg3, android.os.Bundle arg4, bool arg5, bool arg6);
		}
	}
}
