using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface IContentService : android.os.IInterface
	{
		[Sharpen.Stub]
		void registerContentObserver(System.Uri uri, bool notifyForDescendentsn, android.database.IContentObserver
			 observer);

		[Sharpen.Stub]
		void unregisterContentObserver(android.database.IContentObserver observer);

		[Sharpen.Stub]
		void notifyChange(System.Uri uri, android.database.IContentObserver observer, bool
			 observerWantsSelfNotifications, bool syncToNetwork);

		[Sharpen.Stub]
		void requestSync(android.accounts.Account account, string authority, android.os.Bundle
			 extras);

		[Sharpen.Stub]
		void cancelSync(android.accounts.Account account, string authority);

		[Sharpen.Stub]
		bool getSyncAutomatically(android.accounts.Account account, string providerName);

		[Sharpen.Stub]
		void setSyncAutomatically(android.accounts.Account account, string providerName, 
			bool sync);

		[Sharpen.Stub]
		java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
			 account, string providerName);

		[Sharpen.Stub]
		void addPeriodicSync(android.accounts.Account account, string providerName, android.os.Bundle
			 extras, long pollFrequency);

		[Sharpen.Stub]
		void removePeriodicSync(android.accounts.Account account, string providerName, android.os.Bundle
			 extras);

		[Sharpen.Stub]
		int getIsSyncable(android.accounts.Account account, string providerName);

		[Sharpen.Stub]
		void setIsSyncable(android.accounts.Account account, string providerName, int syncable
			);

		[Sharpen.Stub]
		void setMasterSyncAutomatically(bool flag);

		[Sharpen.Stub]
		bool getMasterSyncAutomatically();

		[Sharpen.Stub]
		bool isSyncActive(android.accounts.Account account, string authority);

		[Sharpen.Stub]
		java.util.List<android.content.SyncInfo> getCurrentSyncs();

		[Sharpen.Stub]
		android.content.SyncAdapterType[] getSyncAdapterTypes();

		[Sharpen.Stub]
		android.content.SyncStatusInfo getSyncStatus(android.accounts.Account account, string
			 authority);

		[Sharpen.Stub]
		bool isSyncPending(android.accounts.Account account, string authority);

		[Sharpen.Stub]
		void addStatusChangeListener(int mask, android.content.ISyncStatusObserver callback
			);

		[Sharpen.Stub]
		void removeStatusChangeListener(android.content.ISyncStatusObserver callback);
	}

	[Sharpen.Stub]
	public static class IContentServiceClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.content.IContentService
		{
			internal const string DESCRIPTOR = "android.content.IContentService";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.content.IContentService asInterface(android.os.IBinder obj)
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
			private class Proxy : android.content.IContentService
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
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void registerContentObserver(System.Uri uri, bool notifyForDescendentsn
					, android.database.IContentObserver observer)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void unregisterContentObserver(android.database.IContentObserver observer
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void notifyChange(System.Uri uri, android.database.IContentObserver
					 observer, bool observerWantsSelfNotifications, bool syncToNetwork)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void requestSync(android.accounts.Account account, string authority
					, android.os.Bundle extras)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void cancelSync(android.accounts.Account account, string authority
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual bool getSyncAutomatically(android.accounts.Account account, string
					 providerName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void setSyncAutomatically(android.accounts.Account account, string
					 providerName, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
					 account, string providerName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void addPeriodicSync(android.accounts.Account account, string providerName
					, android.os.Bundle extras, long pollFrequency)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void removePeriodicSync(android.accounts.Account account, string providerName
					, android.os.Bundle extras)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual int getIsSyncable(android.accounts.Account account, string providerName
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void setIsSyncable(android.accounts.Account account, string providerName
					, int syncable)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void setMasterSyncAutomatically(bool flag)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual bool getMasterSyncAutomatically()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual bool isSyncActive(android.accounts.Account account, string authority
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual java.util.List<android.content.SyncInfo> getCurrentSyncs()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual android.content.SyncAdapterType[] getSyncAdapterTypes()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual android.content.SyncStatusInfo getSyncStatus(android.accounts.Account
					 account, string authority)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual bool isSyncPending(android.accounts.Account account, string authority
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void addStatusChangeListener(int mask, android.content.ISyncStatusObserver
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.content.IContentService")]
				public virtual void removeStatusChangeListener(android.content.ISyncStatusObserver
					 callback)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_registerContentObserver = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_unregisterContentObserver = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_notifyChange = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_requestSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_cancelSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_getSyncAutomatically = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_setSyncAutomatically = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_getPeriodicSyncs = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_addPeriodicSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_removePeriodicSync = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_getIsSyncable = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_setIsSyncable = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_setMasterSyncAutomatically = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_getMasterSyncAutomatically = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_isSyncActive = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_getCurrentSyncs = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_getSyncAdapterTypes = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_getSyncStatus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_isSyncPending = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_addStatusChangeListener = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_removeStatusChangeListener = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			public abstract void addPeriodicSync(android.accounts.Account arg1, string arg2, 
				android.os.Bundle arg3, long arg4);

			public abstract void addStatusChangeListener(int arg1, android.content.ISyncStatusObserver
				 arg2);

			public abstract void cancelSync(android.accounts.Account arg1, string arg2);

			public abstract java.util.List<android.content.SyncInfo> getCurrentSyncs();

			public abstract int getIsSyncable(android.accounts.Account arg1, string arg2);

			public abstract bool getMasterSyncAutomatically();

			public abstract java.util.List<android.content.PeriodicSync> getPeriodicSyncs(android.accounts.Account
				 arg1, string arg2);

			public abstract android.content.SyncAdapterType[] getSyncAdapterTypes();

			public abstract bool getSyncAutomatically(android.accounts.Account arg1, string arg2
				);

			public abstract android.content.SyncStatusInfo getSyncStatus(android.accounts.Account
				 arg1, string arg2);

			public abstract bool isSyncActive(android.accounts.Account arg1, string arg2);

			public abstract bool isSyncPending(android.accounts.Account arg1, string arg2);

			public abstract void notifyChange(System.Uri arg1, android.database.IContentObserver
				 arg2, bool arg3, bool arg4);

			public abstract void registerContentObserver(System.Uri arg1, bool arg2, android.database.IContentObserver
				 arg3);

			public abstract void removePeriodicSync(android.accounts.Account arg1, string arg2
				, android.os.Bundle arg3);

			public abstract void removeStatusChangeListener(android.content.ISyncStatusObserver
				 arg1);

			public abstract void requestSync(android.accounts.Account arg1, string arg2, android.os.Bundle
				 arg3);

			public abstract void setIsSyncable(android.accounts.Account arg1, string arg2, int
				 arg3);

			public abstract void setMasterSyncAutomatically(bool arg1);

			public abstract void setSyncAutomatically(android.accounts.Account arg1, string arg2
				, bool arg3);

			public abstract void unregisterContentObserver(android.database.IContentObserver 
				arg1);
		}
	}
}
