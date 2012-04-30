using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public interface IAccessibilityManagerClient : android.os.IInterface
	{
		[Sharpen.Stub]
		void setState(int stateFlags);
	}

	[Sharpen.Stub]
	public static class IAccessibilityManagerClientClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.accessibility.IAccessibilityManagerClient
		{
			internal const string DESCRIPTOR = "android.view.accessibility.IAccessibilityManagerClient";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.accessibility.IAccessibilityManagerClient asInterface(
				android.os.IBinder obj)
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
			private class Proxy : android.view.accessibility.IAccessibilityManagerClient
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
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManagerClient"
					)]
				public virtual void setState(int stateFlags)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void setState(int arg1);
		}
	}
}
