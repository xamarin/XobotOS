using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public interface INotificationManager : android.os.IInterface
	{
		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use enqueueNotificationWithTag(string, string, int, Notification, int[]) instead"
			)]
		void enqueueNotification(string pkg, int id, android.app.Notification notification
			, int[] idReceived);

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"use cancelNotificationWithTag(string, string, int) instead"
			)]
		void cancelNotification(string pkg, int id);

		[Sharpen.Stub]
		void cancelAllNotifications(string pkg);

		[Sharpen.Stub]
		void enqueueToast(string pkg, android.app.ITransientNotification callback, int duration
			);

		[Sharpen.Stub]
		void cancelToast(string pkg, android.app.ITransientNotification callback);

		[Sharpen.Stub]
		void enqueueNotificationWithTag(string pkg, string tag, int id, android.app.Notification
			 notification, int[] idReceived);

		[Sharpen.Stub]
		void enqueueNotificationWithTagPriority(string pkg, string tag, int id, int priority
			, android.app.Notification notification, int[] idReceived);

		[Sharpen.Stub]
		void cancelNotificationWithTag(string pkg, string tag, int id);
	}

	[Sharpen.Stub]
	public static class INotificationManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.app.INotificationManager
		{
			internal const string DESCRIPTOR = "android.app.INotificationManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.app.INotificationManager asInterface(android.os.IBinder obj
				)
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
			private class Proxy : android.app.INotificationManager
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
				[System.ObsoleteAttribute(@"use enqueueNotificationWithTag(string, string, int, Notification, int[]) instead"
					)]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void enqueueNotification(string pkg, int id, android.app.Notification
					 notification, int[] idReceived)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[System.ObsoleteAttribute(@"use cancelNotificationWithTag(string, string, int) instead"
					)]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void cancelNotification(string pkg, int id)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void cancelAllNotifications(string pkg)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void enqueueToast(string pkg, android.app.ITransientNotification callback
					, int duration)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void cancelToast(string pkg, android.app.ITransientNotification callback
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void enqueueNotificationWithTag(string pkg, string tag, int id, android.app.Notification
					 notification, int[] idReceived)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void enqueueNotificationWithTagPriority(string pkg, string tag, int
					 id, int priority, android.app.Notification notification, int[] idReceived)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.app.INotificationManager")]
				public virtual void cancelNotificationWithTag(string pkg, string tag, int id)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_enqueueNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_cancelNotification = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_cancelAllNotifications = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_enqueueToast = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_cancelToast = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_enqueueNotificationWithTag = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_enqueueNotificationWithTagPriority = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_cancelNotificationWithTag = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			public abstract void cancelAllNotifications(string arg1);

			public abstract void cancelNotification(string arg1, int arg2);

			public abstract void cancelNotificationWithTag(string arg1, string arg2, int arg3
				);

			public abstract void cancelToast(string arg1, android.app.ITransientNotification 
				arg2);

			public abstract void enqueueNotification(string arg1, int arg2, android.app.Notification
				 arg3, int[] arg4);

			public abstract void enqueueNotificationWithTag(string arg1, string arg2, int arg3
				, android.app.Notification arg4, int[] arg5);

			public abstract void enqueueNotificationWithTagPriority(string arg1, string arg2, 
				int arg3, int arg4, android.app.Notification arg5, int[] arg6);

			public abstract void enqueueToast(string arg1, android.app.ITransientNotification
				 arg2, int arg3);
		}
	}
}
