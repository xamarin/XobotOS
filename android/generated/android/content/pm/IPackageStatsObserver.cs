using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageStatsObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void onGetStatsCompleted(android.content.pm.PackageStats pStats, bool succeeded);
	}

	[Sharpen.Stub]
	public static class IPackageStatsObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageStatsObserver
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageStatsObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageStatsObserver asInterface(android.os.IBinder
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
			private class Proxy : android.content.pm.IPackageStatsObserver
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
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageStatsObserver")]
				public virtual void onGetStatsCompleted(android.content.pm.PackageStats pStats, bool
					 succeeded)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onGetStatsCompleted = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onGetStatsCompleted(android.content.pm.PackageStats arg1, bool
				 arg2);
		}
	}
}
