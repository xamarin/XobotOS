using Sharpen;

namespace android.view.textservice.@internal
{
	[Sharpen.Stub]
	public interface ISpellCheckerSession : android.os.IInterface
	{
		[Sharpen.Stub]
		void onGetSuggestionsMultiple(android.view.textservice.TextInfo[] textInfos, int 
			suggestionsLimit, bool multipleWords);

		[Sharpen.Stub]
		void onCancel();
	}

	[Sharpen.Stub]
	public static class ISpellCheckerSessionClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.textservice.@internal.ISpellCheckerSession
		{
			internal const string DESCRIPTOR = "com.android.internal.textservice.ISpellCheckerSession";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.textservice.@internal.ISpellCheckerSession asInterface
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
			private class Proxy : android.view.textservice.@internal.ISpellCheckerSession
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
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ISpellCheckerSession"
					)]
				public virtual void onGetSuggestionsMultiple(android.view.textservice.TextInfo[] 
					textInfos, int suggestionsLimit, bool multipleWords)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ISpellCheckerSession"
					)]
				public virtual void onCancel()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_onGetSuggestionsMultiple = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_onCancel = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			public abstract void onCancel();

			public abstract void onGetSuggestionsMultiple(android.view.textservice.TextInfo[]
				 arg1, int arg2, bool arg3);
		}
	}
}
