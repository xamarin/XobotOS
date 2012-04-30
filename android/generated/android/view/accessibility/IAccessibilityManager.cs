using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public interface IAccessibilityManager : android.os.IInterface
	{
		[Sharpen.Stub]
		int addClient(android.view.accessibility.IAccessibilityManagerClient client);

		[Sharpen.Stub]
		bool sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent uiEvent
			);

		[Sharpen.Stub]
		java.util.List<android.accessibilityservice.AccessibilityServiceInfo> getInstalledAccessibilityServiceList
			();

		[Sharpen.Stub]
		java.util.List<android.accessibilityservice.AccessibilityServiceInfo> getEnabledAccessibilityServiceList
			(int feedbackType);

		[Sharpen.Stub]
		void interrupt();

		[Sharpen.Stub]
		int addAccessibilityInteractionConnection(android.view.IWindow windowToken, android.view.accessibility.IAccessibilityInteractionConnection
			 connection);

		[Sharpen.Stub]
		void removeAccessibilityInteractionConnection(android.view.IWindow windowToken);

		[Sharpen.Stub]
		android.accessibilityservice.IAccessibilityServiceConnection registerEventListener
			(android.accessibilityservice.IEventListener client);
	}

	[Sharpen.Stub]
	public static class IAccessibilityManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.accessibility.IAccessibilityManager
		{
			internal const string DESCRIPTOR = "android.view.accessibility.IAccessibilityManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.accessibility.IAccessibilityManager asInterface(android.os.IBinder
				 obj)
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
			private class Proxy : android.view.accessibility.IAccessibilityManager
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
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual int addClient(android.view.accessibility.IAccessibilityManagerClient
					 client)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual bool sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
					 uiEvent)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual java.util.List<android.accessibilityservice.AccessibilityServiceInfo
					> getInstalledAccessibilityServiceList()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual java.util.List<android.accessibilityservice.AccessibilityServiceInfo
					> getEnabledAccessibilityServiceList(int feedbackType)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual void interrupt()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual int addAccessibilityInteractionConnection(android.view.IWindow windowToken
					, android.view.accessibility.IAccessibilityInteractionConnection connection)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual void removeAccessibilityInteractionConnection(android.view.IWindow
					 windowToken)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManager")]
				public virtual android.accessibilityservice.IAccessibilityServiceConnection registerEventListener
					(android.accessibilityservice.IEventListener client)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_addClient = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_sendAccessibilityEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_getInstalledAccessibilityServiceList = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_getEnabledAccessibilityServiceList = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_interrupt = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_addAccessibilityInteractionConnection = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_removeAccessibilityInteractionConnection = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_registerEventListener = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			public abstract int addAccessibilityInteractionConnection(android.view.IWindow arg1
				, android.view.accessibility.IAccessibilityInteractionConnection arg2);

			public abstract int addClient(android.view.accessibility.IAccessibilityManagerClient
				 arg1);

			public abstract java.util.List<android.accessibilityservice.AccessibilityServiceInfo
				> getEnabledAccessibilityServiceList(int arg1);

			public abstract java.util.List<android.accessibilityservice.AccessibilityServiceInfo
				> getInstalledAccessibilityServiceList();

			public abstract void interrupt();

			public abstract android.accessibilityservice.IAccessibilityServiceConnection registerEventListener
				(android.accessibilityservice.IEventListener arg1);

			public abstract void removeAccessibilityInteractionConnection(android.view.IWindow
				 arg1);

			public abstract bool sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
				 arg1);
		}
	}
}
