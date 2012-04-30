using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageDataObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onRemoveCompleted(string packageName, bool succeeded);
	}

	[Sharpen.Stub]
	public static class IPackageDataObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageDataObserver
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageDataObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageDataObserver asInterface(android.os.IBinder
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
			private class Proxy : android.content.pm.IPackageDataObserver
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
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageDataObserver")]
				public virtual void onRemoveCompleted(string packageName, bool succeeded)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onRemoveCompleted = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onRemoveCompleted(string arg1, bool arg2);
		}
	}
}
