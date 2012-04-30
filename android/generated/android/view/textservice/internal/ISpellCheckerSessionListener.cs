using Sharpen;

namespace android.view.textservice.@internal
{
	[Sharpen.Stub]
	public interface ISpellCheckerSessionListener : android.os.IInterface
	{
		[Sharpen.Stub]
		void onGetSuggestions(android.view.textservice.SuggestionsInfo[] results);
	}

	[Sharpen.Stub]
	public static class ISpellCheckerSessionListenerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.textservice.@internal.ISpellCheckerSessionListener
		{
			internal const string DESCRIPTOR = "com.android.internal.textservice.ISpellCheckerSessionListener";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.textservice.@internal.ISpellCheckerSessionListener asInterface
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
			private class Proxy : android.view.textservice.@internal.ISpellCheckerSessionListener
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
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ISpellCheckerSessionListener"
					)]
				public virtual void onGetSuggestions(android.view.textservice.SuggestionsInfo[] results
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onGetSuggestions = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			public abstract void onGetSuggestions(android.view.textservice.SuggestionsInfo[] 
				arg1);
		}
	}
}
