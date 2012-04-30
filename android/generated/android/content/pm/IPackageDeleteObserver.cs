using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageDeleteObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void packageDeleted(string packageName, int returnCode);
	}

	[Sharpen.Stub]
	public static class IPackageDeleteObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageDeleteObserver
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageDeleteObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageDeleteObserver asInterface(android.os.IBinder
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
			private class Proxy : android.content.pm.IPackageDeleteObserver
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
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageDeleteObserver")]
				public virtual void packageDeleted(string packageName, int returnCode)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_packageDeleted = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void packageDeleted(string arg1, int arg2);
		}
	}
}
