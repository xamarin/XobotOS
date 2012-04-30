using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ISyncAdapter : android.os.IInterface
	{
		[Sharpen.Stub]
		void startSync(android.content.ISyncContext syncContext, string authority, android.accounts.Account
			 account, android.os.Bundle extras);

		[Sharpen.Stub]
		void cancelSync(android.content.ISyncContext syncContext);

		[Sharpen.Stub]
		void initialize(android.accounts.Account account, string authority);
	}

	[Sharpen.Stub]
	public static class ISyncAdapterClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.ISyncAdapter
		{
			internal const string DESCRIPTOR = "android.content.ISyncAdapter";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.ISyncAdapter asInterface(android.os.IBinder obj)
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
			private class Proxy : android.content.ISyncAdapter
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
				[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
				public virtual void startSync(android.content.ISyncContext syncContext, string authority
					, android.accounts.Account account, android.os.Bundle extras)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
				public virtual void cancelSync(android.content.ISyncContext syncContext)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.ISyncAdapter")]
				public virtual void initialize(android.accounts.Account account, string authority
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_startSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_cancelSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_initialize = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			public abstract void cancelSync(android.content.ISyncContext arg1);

			public abstract void initialize(android.accounts.Account arg1, string arg2);

			public abstract void startSync(android.content.ISyncContext arg1, string arg2, android.accounts.Account
				 arg3, android.os.Bundle arg4);
		}
	}
}
