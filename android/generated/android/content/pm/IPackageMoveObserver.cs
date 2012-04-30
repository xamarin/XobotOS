using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface IPackageMoveObserver : android.os.IInterface
	{
		[Sharpen.Stub]
		void packageMoved(string packageName, int returnCode);
	}

	[Sharpen.Stub]
	public static class IPackageMoveObserverClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.pm.IPackageMoveObserver
		{
			internal const string DESCRIPTOR = "android.content.pm.IPackageMoveObserver";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.pm.IPackageMoveObserver asInterface(android.os.IBinder
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
			private class Proxy : android.content.pm.IPackageMoveObserver
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
				[Sharpen.ImplementsInterface(@"android.content.pm.IPackageMoveObserver")]
				public virtual void packageMoved(string packageName, int returnCode)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_packageMoved = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void packageMoved(string arg1, int arg2);
		}
	}
}
