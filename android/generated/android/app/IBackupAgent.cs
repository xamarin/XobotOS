using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IBackupAgent : android.os.IInterface
	{
		[Sharpen.Stub]
		void doBackup(android.os.ParcelFileDescriptor oldState, android.os.ParcelFileDescriptor
			 data, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager
			 callbackBinder);

		[Sharpen.Stub]
		void doRestore(android.os.ParcelFileDescriptor data, int appVersionCode, android.os.ParcelFileDescriptor
			 newState, int token, android.app.backup.IBackupManager callbackBinder);

		[Sharpen.Stub]
		void doFullBackup(android.os.ParcelFileDescriptor data, int token, android.app.backup.IBackupManager
			 callbackBinder);

		[Sharpen.Stub]
		void doRestoreFile(android.os.ParcelFileDescriptor data, long size, int type, string
			 domain, string path, long mode, long mtime, int token, android.app.backup.IBackupManager
			 callbackBinder);
	}

	[Sharpen.Stub]
	public static class IBackupAgentClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IBackupAgent
		{
			internal const string DESCRIPTOR = "android.app.IBackupAgent";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IBackupAgent asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IBackupAgent
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
				[Sharpen.ImplementsInterface(@"android.app.IBackupAgent")]
				public virtual void doBackup(android.os.ParcelFileDescriptor oldState, android.os.ParcelFileDescriptor
					 data, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager
					 callbackBinder)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IBackupAgent")]
				public virtual void doRestore(android.os.ParcelFileDescriptor data, int appVersionCode
					, android.os.ParcelFileDescriptor newState, int token, android.app.backup.IBackupManager
					 callbackBinder)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IBackupAgent")]
				public virtual void doFullBackup(android.os.ParcelFileDescriptor data, int token, 
					android.app.backup.IBackupManager callbackBinder)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IBackupAgent")]
				public virtual void doRestoreFile(android.os.ParcelFileDescriptor data, long size
					, int type, string domain, string path, long mode, long mtime, int token, android.app.backup.IBackupManager
					 callbackBinder)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_doBackup = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_doRestore = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_doFullBackup = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_doRestoreFile = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			public abstract void doBackup(android.os.ParcelFileDescriptor arg1, android.os.ParcelFileDescriptor
				 arg2, android.os.ParcelFileDescriptor arg3, int arg4, android.app.backup.IBackupManager
				 arg5);

			public abstract void doFullBackup(android.os.ParcelFileDescriptor arg1, int arg2, 
				android.app.backup.IBackupManager arg3);

			public abstract void doRestore(android.os.ParcelFileDescriptor arg1, int arg2, android.os.ParcelFileDescriptor
				 arg3, int arg4, android.app.backup.IBackupManager arg5);

			public abstract void doRestoreFile(android.os.ParcelFileDescriptor arg1, long arg2
				, int arg3, string arg4, string arg5, long arg6, long arg7, int arg8, android.app.backup.IBackupManager
				 arg9);
		}
	}
}
