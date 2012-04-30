using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IActivityPendingResult : android.os.IInterface
	{
		[Sharpen.Stub]
		bool sendResult(int code, string data, android.os.Bundle ex);
	}

	[Sharpen.Stub]
	public static class IActivityPendingResultClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IActivityPendingResult
		{
			internal const string DESCRIPTOR = "android.app.IActivityPendingResult";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IActivityPendingResult asInterface(android.os.IBinder obj
				)
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
			private class Proxy : android.app.IActivityPendingResult
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
				[Sharpen.ImplementsInterface(@"android.app.IActivityPendingResult")]
				public virtual bool sendResult(int code, string data, android.os.Bundle ex)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_sendResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract bool sendResult(int arg1, string arg2, android.os.Bundle arg3);
		}
	}
}
