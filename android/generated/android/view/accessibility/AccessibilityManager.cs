using Sharpen;

namespace android.view.accessibility
{
	/// <summary>
	/// System level service that serves as an event dispatch for
	/// <see cref="AccessibilityEvent">AccessibilityEvent</see>
	/// s,
	/// and provides facilities for querying the accessibility state of the system.
	/// Accessibility events are generated when something notable happens in the user interface,
	/// for example an
	/// <see cref="android.app.Activity">android.app.Activity</see>
	/// starts, the focus or selection of a
	/// <see cref="android.view.View">android.view.View</see>
	/// changes etc. Parties interested in handling accessibility
	/// events implement and register an accessibility service which extends
	/// <see cref="android.accessibilityservice.AccessibilityService">android.accessibilityservice.AccessibilityService
	/// 	</see>
	/// .
	/// <p>
	/// To obtain a handle to the accessibility manager do the following:
	/// </p>
	/// <p>
	/// <code>
	/// <pre>AccessibilityManager accessibilityManager =
	/// (AccessibilityManager) context.getSystemService(Context.ACCESSIBILITY_SERVICE);</pre>
	/// </code>
	/// </p>
	/// </summary>
	/// <seealso cref="AccessibilityEvent">AccessibilityEvent</seealso>
	/// <seealso cref="AccessibilityNodeInfo">AccessibilityNodeInfo</seealso>
	/// <seealso cref="android.accessibilityservice.AccessibilityService">android.accessibilityservice.AccessibilityService
	/// 	</seealso>
	/// <seealso cref="android.content.Context.getSystemService(string)">android.content.Context.getSystemService(string)
	/// 	</seealso>
	/// <seealso cref="android.content.Context.ACCESSIBILITY_SERVICE">android.content.Context.ACCESSIBILITY_SERVICE
	/// 	</seealso>
	[Sharpen.Sharpened]
	public sealed partial class AccessibilityManager
	{
		internal const bool DEBUG = false;

		internal const string LOG_TAG = "AccessibilityManager";

		/// <hide></hide>
		public const int STATE_FLAG_ACCESSIBILITY_ENABLED = unchecked((int)(0x00000001));

		/// <hide></hide>
		public const int STATE_FLAG_TOUCH_EXPLORATION_ENABLED = unchecked((int)(0x00000002
			));

		internal static readonly object sInstanceSync = new object();

		private static android.view.accessibility.AccessibilityManager sInstance;

		internal const int DO_SET_STATE = 10;

		internal readonly android.view.accessibility.IAccessibilityManager mService;

		internal readonly android.os.Handler mHandler;

		internal bool mIsEnabled;

		internal bool mIsTouchExplorationEnabled;

		internal readonly java.util.concurrent.CopyOnWriteArrayList<android.view.accessibility.AccessibilityManager
			.AccessibilityStateChangeListener> mAccessibilityStateChangeListeners = new java.util.concurrent.CopyOnWriteArrayList
			<android.view.accessibility.AccessibilityManager.AccessibilityStateChangeListener
			>();

		/// <summary>Listener for the system accessibility state.</summary>
		/// <remarks>
		/// Listener for the system accessibility state. To listen for changes to the accessibility
		/// state on the device, implement this interface and register it with the system by
		/// calling
		/// <see cref="AccessibilityManager.addAccessibilityStateChangeListener(AccessibilityStateChangeListener)
		/// 	">addAccessibilityStateChangeListener()</see>
		/// .
		/// </remarks>
		public interface AccessibilityStateChangeListener
		{
			/// <summary>Called back on change in the accessibility state.</summary>
			/// <remarks>Called back on change in the accessibility state.</remarks>
			/// <param name="enabled">Whether accessibility is enabled.</param>
			void onAccessibilityStateChanged(bool enabled);
		}

		private sealed class _Stub_107 : android.view.accessibility.IAccessibilityManagerClientClass
			.Stub
		{
			public _Stub_107(AccessibilityManager _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.accessibility.IAccessibilityManagerClient"
				)]
			public override void setState(int state)
			{
				this._enclosing.mHandler.obtainMessage(android.view.accessibility.AccessibilityManager
					.DO_SET_STATE, state, 0).sendToTarget();
			}

			private readonly AccessibilityManager _enclosing;
		}

		internal readonly android.view.accessibility.IAccessibilityManagerClientClass.Stub
			 mClient;

		internal class MyHandler : android.os.Handler
		{
			internal MyHandler(AccessibilityManager _enclosing, android.os.Looper mainLooper)
				 : base(mainLooper)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message message)
			{
				switch (message.what)
				{
					case android.view.accessibility.AccessibilityManager.DO_SET_STATE:
					{
						this._enclosing.setState(message.arg1);
						return;
					}

					default:
					{
						android.util.Log.w(android.view.accessibility.AccessibilityManager.LOG_TAG, "Unknown message type: "
							 + message.what);
						break;
					}
				}
			}

			private readonly AccessibilityManager _enclosing;
		}

		[Sharpen.Stub]
		public bool isTouchExplorationEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.accessibility.IAccessibilityManagerClient getClient()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent 
			@event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void interrupt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use getInstalledAccessibilityServiceList()")]
		public java.util.List<android.content.pm.ServiceInfo> getAccessibilityServiceList
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.List<android.accessibilityservice.AccessibilityServiceInfo> getInstalledAccessibilityServiceList
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.List<android.accessibilityservice.AccessibilityServiceInfo> getEnabledAccessibilityServiceList
			(int feedbackTypeFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool addAccessibilityStateChangeListener(android.view.accessibility.AccessibilityManager
			.AccessibilityStateChangeListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool removeAccessibilityStateChangeListener(android.view.accessibility.AccessibilityManager
			.AccessibilityStateChangeListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setState(int stateFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setAccessibilityState(bool isEnabled_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyAccessibilityStateChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int addAccessibilityInteractionConnection(android.view.IWindow windowToken
			, android.view.accessibility.IAccessibilityInteractionConnection connection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void removeAccessibilityInteractionConnection(android.view.IWindow windowToken
			)
		{
			throw new System.NotImplementedException();
		}

		public AccessibilityManager()
		{
			mClient = new _Stub_107(this);
		}
		// it is possible that this manager is in the same process as the service but
		// client using it is called through Binder from another process. Example: MMS
		// app adds a SMS notification and the NotificationManagerService calls this method
	}
}
