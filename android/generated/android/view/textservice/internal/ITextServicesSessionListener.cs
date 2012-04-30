using Sharpen;

namespace android.view.textservice.@internal
{
	[Sharpen.Stub]
	public interface ITextServicesSessionListener : android.os.IInterface
	{
		[Sharpen.Stub]
		void onServiceConnected(android.view.textservice.@internal.ISpellCheckerSession spellCheckerSession
			);
	}

	[Sharpen.Stub]
	public static class ITextServicesSessionListenerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.textservice.@internal.ITextServicesSessionListener
		{
			internal const string DESCRIPTOR = "com.android.internal.textservice.ITextServicesSessionListener";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.textservice.@internal.ITextServicesSessionListener asInterface
				(android.os.IBinder obj)
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
			private class Proxy : android.view.textservice.@internal.ITextServicesSessionListener
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
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesSessionListener"
					)]
				public virtual void onServiceConnected(android.view.textservice.@internal.ISpellCheckerSession
					 spellCheckerSession)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onServiceConnected = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onServiceConnected(android.view.textservice.@internal.ISpellCheckerSession
				 arg1);
		}
	}
}
