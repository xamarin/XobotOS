using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface IAlarmManager : android.os.IInterface
	{
		[Sharpen.Stub]
		void set(int type, long triggerAtTime, android.app.PendingIntent operation);

		[Sharpen.Stub]
		void setRepeating(int type, long triggerAtTime, long interval, android.app.PendingIntent
			 operation);

		[Sharpen.Stub]
		void setInexactRepeating(int type, long triggerAtTime, long interval, android.app.PendingIntent
			 operation);

		[Sharpen.Stub]
		void setTime(long millis);

		[Sharpen.Stub]
		void setTimeZone(string zone);

		[Sharpen.Stub]
		void remove(android.app.PendingIntent operation);
	}

	[Sharpen.Stub]
	public static class IAlarmManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.IAlarmManager
		{
			internal const string DESCRIPTOR = "android.app.IAlarmManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.IAlarmManager asInterface(android.os.IBinder obj)
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
			private class Proxy : android.app.IAlarmManager
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
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void set(int type, long triggerAtTime, android.app.PendingIntent operation
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void setRepeating(int type, long triggerAtTime, long interval, android.app.PendingIntent
					 operation)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void setInexactRepeating(int type, long triggerAtTime, long interval
					, android.app.PendingIntent operation)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void setTime(long millis)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void setTimeZone(string zone)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.IAlarmManager")]
				public virtual void remove(android.app.PendingIntent operation)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_set = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_setRepeating = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_setInexactRepeating = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_setTime = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_setTimeZone = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_remove = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			public abstract void remove(android.app.PendingIntent arg1);

			public abstract void set(int arg1, long arg2, android.app.PendingIntent arg3);

			public abstract void setInexactRepeating(int arg1, long arg2, long arg3, android.app.PendingIntent
				 arg4);

			public abstract void setRepeating(int arg1, long arg2, long arg3, android.app.PendingIntent
				 arg4);

			public abstract void setTime(long arg1);

			public abstract void setTimeZone(string arg1);
		}
	}
}
