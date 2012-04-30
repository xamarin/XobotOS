using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface ISearchManager : android.os.IInterface
	{
		[Sharpen.Stub]
		android.app.SearchableInfo getSearchableInfo(android.content.ComponentName launchActivity
			);

		[Sharpen.Stub]
		java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch();

		[Sharpen.Stub]
		java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities();

		[Sharpen.Stub]
		android.content.ComponentName getGlobalSearchActivity();

		[Sharpen.Stub]
		android.content.ComponentName getWebSearchActivity();
	}

	[Sharpen.Stub]
	public static class ISearchManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.ISearchManager
		{
			internal const string DESCRIPTOR = "android.app.ISearchManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.ISearchManager asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.ISearchManager
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
				[Sharpen.ImplementsInterface(@"android.app.ISearchManager")]
				public virtual android.app.SearchableInfo getSearchableInfo(android.content.ComponentName
					 launchActivity)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ISearchManager")]
				public virtual java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ISearchManager")]
				public virtual java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities
					()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ISearchManager")]
				public virtual android.content.ComponentName getGlobalSearchActivity()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.ISearchManager")]
				public virtual android.content.ComponentName getWebSearchActivity()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_getSearchableInfo = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_getSearchablesInGlobalSearch = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getGlobalSearchActivities = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getGlobalSearchActivity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_getWebSearchActivity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			public abstract java.util.List<android.content.pm.ResolveInfo> getGlobalSearchActivities
				();

			public abstract android.content.ComponentName getGlobalSearchActivity();

			public abstract android.app.SearchableInfo getSearchableInfo(android.content.ComponentName
				 arg1);

			public abstract java.util.List<android.app.SearchableInfo> getSearchablesInGlobalSearch
				();

			public abstract android.content.ComponentName getWebSearchActivity();
		}
	}
}
