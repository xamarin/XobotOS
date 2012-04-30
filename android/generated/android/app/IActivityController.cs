using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IActivityController : android.os.IInterface
	{
		[Sharpen.Stub]
		bool activityStarting(android.content.Intent intent, string pkg);

		[Sharpen.Stub]
		bool activityResuming(string pkg);

		[Sharpen.Stub]
		bool appCrashed(string processName, int pid, string shortMsg, string longMsg, long
			 timeMillis, string stackTrace);

		[Sharpen.Stub]
		int appEarlyNotResponding(string processName, int pid, string annotation);

		[Sharpen.Stub]
		int appNotResponding(string processName, int pid, string processStats);
	}

	[Sharpen.Stub]
	public static class IActivityControllerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IActivityController
		{
			internal const string DESCRIPTOR = "android.app.IActivityController";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IActivityController asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IActivityController
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
				[Sharpen.ImplementsInterface(@"android.app.IActivityController")]
				public virtual bool activityStarting(android.content.Intent intent, string pkg)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IActivityController")]
				public virtual bool activityResuming(string pkg)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IActivityController")]
				public virtual bool appCrashed(string processName, int pid, string shortMsg, string
					 longMsg, long timeMillis, string stackTrace)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IActivityController")]
				public virtual int appEarlyNotResponding(string processName, int pid, string annotation
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IActivityController")]
				public virtual int appNotResponding(string processName, int pid, string processStats
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_activityStarting = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_activityResuming = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_appCrashed = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_appEarlyNotResponding = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_appNotResponding = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			public abstract bool activityResuming(string arg1);

			public abstract bool activityStarting(android.content.Intent arg1, string arg2);

			public abstract bool appCrashed(string arg1, int arg2, string arg3, string arg4, 
				long arg5, string arg6);

			public abstract int appEarlyNotResponding(string arg1, int arg2, string arg3);

			public abstract int appNotResponding(string arg1, int arg2, string arg3);
		}
	}
}
