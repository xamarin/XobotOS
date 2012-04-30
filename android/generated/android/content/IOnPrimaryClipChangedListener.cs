using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IOnPrimaryClipChangedListener : android.os.IInterface
	{
		[Sharpen.Stub]
		void dispatchPrimaryClipChanged();
	}

	[Sharpen.Stub]
	public static class IOnPrimaryClipChangedListenerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.IOnPrimaryClipChangedListener
		{
			internal const string DESCRIPTOR = "android.content.IOnPrimaryClipChangedListener";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.IOnPrimaryClipChangedListener asInterface(android.os.IBinder
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
			private class Proxy : android.content.IOnPrimaryClipChangedListener
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
				[Sharpen.ImplementsInterface(@"android.content.IOnPrimaryClipChangedListener")]
				public virtual void dispatchPrimaryClipChanged()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_dispatchPrimaryClipChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void dispatchPrimaryClipChanged();
		}
	}
}
