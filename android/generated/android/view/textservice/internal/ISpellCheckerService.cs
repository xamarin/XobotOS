using Sharpen;

namespace android.view.textservice.@internal
{
	[Sharpen.Stub]
	public interface ISpellCheckerService : android.os.IInterface
	{
		[Sharpen.Stub]
		android.view.textservice.@internal.ISpellCheckerSession getISpellCheckerSession(string
			 locale, android.view.textservice.@internal.ISpellCheckerSessionListener listener
			, android.os.Bundle bundle);
	}

	[Sharpen.Stub]
	public static class ISpellCheckerServiceClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.textservice.@internal.ISpellCheckerService
		{
			internal const string DESCRIPTOR = "com.android.internal.textservice.ISpellCheckerService";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.textservice.@internal.ISpellCheckerService asInterface
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
			private class Proxy : android.view.textservice.@internal.ISpellCheckerService
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
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ISpellCheckerService"
					)]
				public virtual android.view.textservice.@internal.ISpellCheckerSession getISpellCheckerSession
					(string locale, android.view.textservice.@internal.ISpellCheckerSessionListener 
					listener, android.os.Bundle bundle)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getISpellCheckerSession = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract android.view.textservice.@internal.ISpellCheckerSession getISpellCheckerSession
				(string arg1, android.view.textservice.@internal.ISpellCheckerSessionListener arg2
				, android.os.Bundle arg3);
		}
	}
}
