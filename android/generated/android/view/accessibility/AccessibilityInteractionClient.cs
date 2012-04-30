using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public sealed class AccessibilityInteractionClient : android.view.accessibility.IAccessibilityInteractionConnectionCallbackClass
		.Stub
	{
		internal const long TIMEOUT_INTERACTION_MILLIS = 5000;

		private static readonly object sStaticLock = new object();

		private static android.view.accessibility.AccessibilityInteractionClient sInstance;

		private readonly java.util.concurrent.atomic.AtomicInteger mInteractionIdCounter = 
			new java.util.concurrent.atomic.AtomicInteger();

		private readonly object mInstanceLock = new object();

		private int mInteractionId = -1;

		private android.view.accessibility.AccessibilityNodeInfo mFindAccessibilityNodeInfoResult;

		private java.util.List<android.view.accessibility.AccessibilityNodeInfo> mFindAccessibilityNodeInfosResult;

		private bool mPerformAccessibilityActionResult;

		private android.os.Message mSameThreadMessage;

		private readonly android.graphics.Rect mTempBounds = new android.graphics.Rect();

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityInteractionClient getInstance
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setSameThreadMessage(android.os.Message message)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.accessibility.AccessibilityNodeInfo findAccessibilityNodeInfoByAccessibilityId
			(android.accessibilityservice.IAccessibilityServiceConnection connection, int accessibilityWindowId
			, int accessibilityViewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.accessibility.AccessibilityNodeInfo findAccessibilityNodeInfoByViewIdInActiveWindow
			(android.accessibilityservice.IAccessibilityServiceConnection connection, int viewId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.List<android.view.accessibility.AccessibilityNodeInfo> findAccessibilityNodeInfosByViewTextInActiveWindow
			(android.accessibilityservice.IAccessibilityServiceConnection connection, string
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.List<android.view.accessibility.AccessibilityNodeInfo> findAccessibilityNodeInfosByViewText
			(android.accessibilityservice.IAccessibilityServiceConnection connection, string
			 text, int accessibilityWindowId, int accessibilityViewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool performAccessibilityAction(android.accessibilityservice.IAccessibilityServiceConnection
			 connection, int accessibilityWindowId, int accessibilityViewId, int action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.view.accessibility.AccessibilityNodeInfo getFindAccessibilityNodeInfoResultAndClear
			(int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
			)]
		public override void setFindAccessibilityNodeInfoResult(android.view.accessibility.AccessibilityNodeInfo
			 info, int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.util.List<android.view.accessibility.AccessibilityNodeInfo> getFindAccessibilityNodeInfosResultAndClear
			(int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
			)]
		public override void setFindAccessibilityNodeInfosResult(java.util.List<android.view.accessibility.AccessibilityNodeInfo
			> infos, int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool getPerformAccessibilityActionResult(int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityInteractionConnectionCallback"
			)]
		public override void setPerformAccessibilityActionResult(bool succeeded, int interactionId
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void clearResultLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool waitForResultTimedLocked(int interactionId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void applyCompatibilityScaleIfNeeded(android.view.accessibility.AccessibilityNodeInfo
			 info, float scale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finalizeAccessibilityNodeInfo(android.view.accessibility.AccessibilityNodeInfo
			 info, android.accessibilityservice.IAccessibilityServiceConnection connection, 
			float windowScale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void finalizeAccessibilityNodeInfos(java.util.List<android.view.accessibility.AccessibilityNodeInfo
			> infos, android.accessibilityservice.IAccessibilityServiceConnection connection
			, float windowScale)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.os.Message getSameProcessMessageAndClear()
		{
			throw new System.NotImplementedException();
		}
	}
}
