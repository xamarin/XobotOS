using Sharpen;

namespace android.view.textservice.@internal
{
	[Sharpen.Stub]
	public interface ITextServicesManager : android.os.IInterface
	{
		[Sharpen.Stub]
		android.view.textservice.SpellCheckerInfo getCurrentSpellChecker(string locale);

		[Sharpen.Stub]
		android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype(string
			 locale, bool allowImplicitlySelectedSubtype);

		[Sharpen.Stub]
		void getSpellCheckerService(string sciId, string locale, android.view.textservice.@internal.ITextServicesSessionListener
			 tsListener, android.view.textservice.@internal.ISpellCheckerSessionListener scListener
			, android.os.Bundle bundle);

		[Sharpen.Stub]
		void finishSpellCheckerService(android.view.textservice.@internal.ISpellCheckerSessionListener
			 listener);

		[Sharpen.Stub]
		void setCurrentSpellChecker(string locale, string sciId);

		[Sharpen.Stub]
		void setCurrentSpellCheckerSubtype(string locale, int hashCode);

		[Sharpen.Stub]
		void setSpellCheckerEnabled(bool enabled);

		[Sharpen.Stub]
		bool isSpellCheckerEnabled();

		[Sharpen.Stub]
		android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers();
	}

	[Sharpen.Stub]
	public static class ITextServicesManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.textservice.@internal.ITextServicesManager
		{
			internal const string DESCRIPTOR = "com.android.internal.textservice.ITextServicesManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.textservice.@internal.ITextServicesManager asInterface
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
			private class Proxy : android.view.textservice.@internal.ITextServicesManager
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
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual android.view.textservice.SpellCheckerInfo getCurrentSpellChecker(string
					 locale)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype
					(string locale, bool allowImplicitlySelectedSubtype)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual void getSpellCheckerService(string sciId, string locale, android.view.textservice.@internal.ITextServicesSessionListener
					 tsListener, android.view.textservice.@internal.ISpellCheckerSessionListener scListener
					, android.os.Bundle bundle)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual void finishSpellCheckerService(android.view.textservice.@internal.ISpellCheckerSessionListener
					 listener)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual void setCurrentSpellChecker(string locale, string sciId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual void setCurrentSpellCheckerSubtype(string locale, int hashCode_1)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual void setSpellCheckerEnabled(bool enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual bool isSpellCheckerEnabled()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesManager"
					)]
				public virtual android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers
					()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getCurrentSpellChecker = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getCurrentSpellCheckerSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getSpellCheckerService = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_finishSpellCheckerService = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_setCurrentSpellChecker = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_setCurrentSpellCheckerSubtype = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_setSpellCheckerEnabled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_isSpellCheckerEnabled = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_getEnabledSpellCheckers = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			public abstract void finishSpellCheckerService(android.view.textservice.@internal.ISpellCheckerSessionListener
				 arg1);

			public abstract android.view.textservice.SpellCheckerInfo getCurrentSpellChecker(
				string arg1);

			public abstract android.view.textservice.SpellCheckerSubtype getCurrentSpellCheckerSubtype
				(string arg1, bool arg2);

			public abstract android.view.textservice.SpellCheckerInfo[] getEnabledSpellCheckers
				();

			public abstract void getSpellCheckerService(string arg1, string arg2, android.view.textservice.@internal.ITextServicesSessionListener
				 arg3, android.view.textservice.@internal.ISpellCheckerSessionListener arg4, android.os.Bundle
				 arg5);

			public abstract bool isSpellCheckerEnabled();

			public abstract void setCurrentSpellChecker(string arg1, string arg2);

			public abstract void setCurrentSpellCheckerSubtype(string arg1, int arg2);

			public abstract void setSpellCheckerEnabled(bool arg1);
		}
	}
}
