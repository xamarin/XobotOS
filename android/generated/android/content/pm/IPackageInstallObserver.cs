using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageInstallObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void packageInstalled(string packageName, int returnCode);
	}

	[Sharpen.Stub]
	public static class IPackageInstallObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageInstallObserver
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageInstallObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageInstallObserver asInterface(android.os.IBinder
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
			private class Proxy : android.content.pm.IPackageInstallObserver
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
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageInstallObserver")]
				public virtual void packageInstalled(string packageName, int returnCode)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_packageInstalled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void packageInstalled(string arg1, int arg2);
		}
	}
}
