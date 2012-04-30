using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IInstrumentationWatcher : android.os.IInterface
	{
		[Sharpen.Stub]
		void instrumentationStatus(android.content.ComponentName name, int resultCode, android.os.Bundle
			 results);

		[Sharpen.Stub]
		void instrumentationFinished(android.content.ComponentName name, int resultCode, 
			android.os.Bundle results);
	}

	[Sharpen.Stub]
	public static class IInstrumentationWatcherClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IInstrumentationWatcher
		{
			internal const string DESCRIPTOR = "android.app.IInstrumentationWatcher";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IInstrumentationWatcher asInterface(android.os.IBinder 
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
			private class Proxy : android.app.IInstrumentationWatcher
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
				[Sharpen.ImplementsInterface(@"android.app.IInstrumentationWatcher")]
				public virtual void instrumentationStatus(android.content.ComponentName name, int
					 resultCode, android.os.Bundle results)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IInstrumentationWatcher")]
				public virtual void instrumentationFinished(android.content.ComponentName name, int
					 resultCode, android.os.Bundle results)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_instrumentationStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_instrumentationFinished = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void instrumentationFinished(android.content.ComponentName arg1, 
				int arg2, android.os.Bundle arg3);

			public abstract void instrumentationStatus(android.content.ComponentName arg1, int
				 arg2, android.os.Bundle arg3);
		}
	}
}
