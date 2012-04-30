using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public interface IAccessibilityInteractionConnection : android.os.IInterface
	{
		[Sharpen.Stub]
		void findAccessibilityNodeInfoByAccessibilityId(int accessibilityViewId, int interactionId
			, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback
			, int interrogatingPid, long interrogatingTid);

		[Sharpen.Stub]
		void findAccessibilityNodeInfoByViewId(int id, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
			 callback, int interrogatingPid, long interrogatingTid);

		[Sharpen.Stub]
		void findAccessibilityNodeInfosByViewText(string text, int accessibilityViewId, int
			 interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
			 callback, int interrogatingPid, long interrogatingTid);

		[Sharpen.Stub]
		void performAccessibilityAction(int accessibilityId, int action, int interactionId
			, android.view.accessibility.IAccessibilityInteractionConnectionCallback callback
			, int interrogatingPid, long interrogatingTid);
	}

	[Sharpen.Stub]
	public static class IAccessibilityInteractionConnectionClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.accessibility.IAccessibilityInteractionConnection
		{
			internal const string DESCRIPTOR = "android.view.accessibility.IAccessibilityInteractionConnection";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.accessibility.IAccessibilityInteractionConnection asInterface
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
			private class Proxy : android.view.accessibility.IAccessibilityInteractionConnection
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
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
					)]
				public virtual void findAccessibilityNodeInfoByAccessibilityId(int accessibilityViewId
					, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
					 callback, int interrogatingPid, long interrogatingTid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
					)]
				public virtual void findAccessibilityNodeInfoByViewId(int id, int interactionId, 
					android.view.accessibility.IAccessibilityInteractionConnectionCallback callback, 
					int interrogatingPid, long interrogatingTid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
					)]
				public virtual void findAccessibilityNodeInfosByViewText(string text, int accessibilityViewId
					, int interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
					 callback, int interrogatingPid, long interrogatingTid)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnection"
					)]
				public virtual void performAccessibilityAction(int accessibilityId, int action, int
					 interactionId, android.view.accessibility.IAccessibilityInteractionConnectionCallback
					 callback, int interrogatingPid, long interrogatingTid)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_findAccessibilityNodeInfoByAccessibilityId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_findAccessibilityNodeInfoByViewId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_findAccessibilityNodeInfosByViewText = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_performAccessibilityAction = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			public abstract void findAccessibilityNodeInfoByAccessibilityId(int arg1, int arg2
				, android.view.accessibility.IAccessibilityInteractionConnectionCallback arg3, int
				 arg4, long arg5);

			public abstract void findAccessibilityNodeInfoByViewId(int arg1, int arg2, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 arg3, int arg4, long arg5);

			public abstract void findAccessibilityNodeInfosByViewText(string arg1, int arg2, 
				int arg3, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 arg4, int arg5, long arg6);

			public abstract void performAccessibilityAction(int arg1, int arg2, int arg3, android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 arg4, int arg5, long arg6);
		}
	}
}
