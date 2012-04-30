using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public interface IAccessibilityInteractionConnectionCallback : android.os.IInterface
	{
		[Sharpen.Stub]
		void setFindAccessibilityNodeInfoResult(android.view.accessibility.AccessibilityNodeInfo
			 info, int interactionId);

		[Sharpen.Stub]
		void setFindAccessibilityNodeInfosResult(java.util.List<android.view.accessibility.AccessibilityNodeInfo
			> infos, int interactionId);

		[Sharpen.Stub]
		void setPerformAccessibilityActionResult(bool succeeded, int interactionId);
	}

	[Sharpen.Stub]
	public static class IAccessibilityInteractionConnectionCallbackClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.accessibility.IAccessibilityInteractionConnectionCallback
		{
			internal const string DESCRIPTOR = "android.view.accessibility.IAccessibilityInteractionConnectionCallback";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.accessibility.IAccessibilityInteractionConnectionCallback
				 asInterface(android.os.IBinder obj)
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
			private class Proxy : android.view.accessibility.IAccessibilityInteractionConnectionCallback
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
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
					)]
				public virtual void setFindAccessibilityNodeInfoResult(android.view.accessibility.AccessibilityNodeInfo
					 info, int interactionId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
					)]
				public virtual void setFindAccessibilityNodeInfosResult(java.util.List<android.view.accessibility.AccessibilityNodeInfo
					> infos, int interactionId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
					)]
				public virtual void setPerformAccessibilityActionResult(bool succeeded, int interactionId
					)
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_setFindAccessibilityNodeInfoResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_setFindAccessibilityNodeInfosResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_setPerformAccessibilityActionResult = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			public abstract void setFindAccessibilityNodeInfoResult(android.view.accessibility.AccessibilityNodeInfo
				 arg1, int arg2);

			public abstract void setFindAccessibilityNodeInfosResult(java.util.List<android.view.accessibility.AccessibilityNodeInfo
				> arg1, int arg2);

			public abstract void setPerformAccessibilityActionResult(bool arg1, int arg2);
		}
	}
}
