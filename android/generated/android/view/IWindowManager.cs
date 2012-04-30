using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public interface IWindowManager : android.os.IInterface
	{
		[Sharpen.Stub]
		bool startViewServer(int port);

		[Sharpen.Stub]
		bool stopViewServer();

		[Sharpen.Stub]
		bool isViewServerRunning();

		[Sharpen.Stub]
		android.view.IWindowSession openSession(android.view.@internal.IInputMethodClient
			 client, android.view.@internal.IInputContext inputContext);

		[Sharpen.Stub]
		bool inputMethodClientHasFocus(android.view.@internal.IInputMethodClient client);

		[Sharpen.Stub]
		void getDisplaySize(android.graphics.Point size);

		[Sharpen.Stub]
		void getRealDisplaySize(android.graphics.Point size);

		[Sharpen.Stub]
		int getMaximumSizeDimension();

		[Sharpen.Stub]
		void setForcedDisplaySize(int longDimen, int shortDimen);

		[Sharpen.Stub]
		void clearForcedDisplaySize();

		[Sharpen.Stub]
		bool canStatusBarHide();

		[Sharpen.Stub]
		bool injectKeyEvent(android.view.KeyEvent ev, bool sync);

		[Sharpen.Stub]
		bool injectPointerEvent(android.view.MotionEvent ev, bool sync);

		[Sharpen.Stub]
		bool injectTrackballEvent(android.view.MotionEvent ev, bool sync);

		[Sharpen.Stub]
		bool injectInputEventNoWait(android.view.InputEvent ev);

		[Sharpen.Stub]
		void pauseKeyDispatching(android.os.IBinder token);

		[Sharpen.Stub]
		void resumeKeyDispatching(android.os.IBinder token);

		[Sharpen.Stub]
		void setEventDispatching(bool enabled);

		[Sharpen.Stub]
		void addWindowToken(android.os.IBinder token, int type);

		[Sharpen.Stub]
		void removeWindowToken(android.os.IBinder token);

		[Sharpen.Stub]
		void addAppToken(int addPos, android.view.IApplicationToken token, int groupId, int
			 requestedOrientation, bool fullscreen);

		[Sharpen.Stub]
		void setAppGroupId(android.os.IBinder token, int groupId);

		[Sharpen.Stub]
		void setAppOrientation(android.view.IApplicationToken token, int requestedOrientation
			);

		[Sharpen.Stub]
		int getAppOrientation(android.view.IApplicationToken token);

		[Sharpen.Stub]
		void setFocusedApp(android.os.IBinder token, bool moveFocusNow);

		[Sharpen.Stub]
		void prepareAppTransition(int transit, bool alwaysKeepCurrent);

		[Sharpen.Stub]
		int getPendingAppTransition();

		[Sharpen.Stub]
		void overridePendingAppTransition(string packageName, int enterAnim, int exitAnim
			);

		[Sharpen.Stub]
		void executeAppTransition();

		[Sharpen.Stub]
		void setAppStartingWindow(android.os.IBinder token, string pkg, int theme, android.content.res.CompatibilityInfo
			 compatInfo, java.lang.CharSequence nonLocalizedLabel, int labelRes, int icon, int
			 windowFlags, android.os.IBinder transferFrom, bool createIfNeeded);

		[Sharpen.Stub]
		void setAppWillBeHidden(android.os.IBinder token);

		[Sharpen.Stub]
		void setAppVisibility(android.os.IBinder token, bool visible);

		[Sharpen.Stub]
		void startAppFreezingScreen(android.os.IBinder token, int configChanges);

		[Sharpen.Stub]
		void stopAppFreezingScreen(android.os.IBinder token, bool force);

		[Sharpen.Stub]
		void removeAppToken(android.os.IBinder token);

		[Sharpen.Stub]
		void moveAppToken(int index, android.os.IBinder token);

		[Sharpen.Stub]
		void moveAppTokensToTop(java.util.List<android.os.IBinder> tokens);

		[Sharpen.Stub]
		void moveAppTokensToBottom(java.util.List<android.os.IBinder> tokens);

		[Sharpen.Stub]
		android.content.res.Configuration updateOrientationFromAppTokens(android.content.res.Configuration
			 currentConfig, android.os.IBinder freezeThisOneIfNeeded);

		[Sharpen.Stub]
		void setNewConfiguration(android.content.res.Configuration config);

		[Sharpen.Stub]
		void disableKeyguard(android.os.IBinder token, string tag);

		[Sharpen.Stub]
		void reenableKeyguard(android.os.IBinder token);

		[Sharpen.Stub]
		void exitKeyguardSecurely(android.view.IOnKeyguardExitResult callback);

		[Sharpen.Stub]
		bool isKeyguardLocked();

		[Sharpen.Stub]
		bool isKeyguardSecure();

		[Sharpen.Stub]
		bool inKeyguardRestrictedInputMode();

		[Sharpen.Stub]
		void dismissKeyguard();

		[Sharpen.Stub]
		void closeSystemDialogs(string reason);

		[Sharpen.Stub]
		float getAnimationScale(int which);

		[Sharpen.Stub]
		float[] getAnimationScales();

		[Sharpen.Stub]
		void setAnimationScale(int which, float scale);

		[Sharpen.Stub]
		void setAnimationScales(float[] scales);

		[Sharpen.Stub]
		int getSwitchState(int sw);

		[Sharpen.Stub]
		int getSwitchStateForDevice(int devid, int sw);

		[Sharpen.Stub]
		int getScancodeState(int sw);

		[Sharpen.Stub]
		int getScancodeStateForDevice(int devid, int sw);

		[Sharpen.Stub]
		int getTrackballScancodeState(int sw);

		[Sharpen.Stub]
		int getDPadScancodeState(int sw);

		[Sharpen.Stub]
		int getKeycodeState(int sw);

		[Sharpen.Stub]
		int getKeycodeStateForDevice(int devid, int sw);

		[Sharpen.Stub]
		int getTrackballKeycodeState(int sw);

		[Sharpen.Stub]
		int getDPadKeycodeState(int sw);

		[Sharpen.Stub]
		android.view.InputChannel monitorInput(string inputChannelName);

		[Sharpen.Stub]
		bool hasKeys(int[] keycodes, bool[] keyExists);

		[Sharpen.Stub]
		android.view.InputDevice getInputDevice(int deviceId);

		[Sharpen.Stub]
		int[] getInputDeviceIds();

		[Sharpen.Stub]
		void setInTouchMode(bool showFocus);

		[Sharpen.Stub]
		void showStrictModeViolation(bool on);

		[Sharpen.Stub]
		void setStrictModeVisualIndicatorPreference(string enabled);

		[Sharpen.Stub]
		void updateRotation(bool alwaysSendConfiguration);

		[Sharpen.Stub]
		int getRotation();

		[Sharpen.Stub]
		int watchRotation(android.view.IRotationWatcher watcher);

		[Sharpen.Stub]
		int getPreferredOptionsPanelGravity();

		[Sharpen.Stub]
		void freezeRotation(int rotation);

		[Sharpen.Stub]
		void thawRotation();

		[Sharpen.Stub]
		android.graphics.Bitmap screenshotApplications(android.os.IBinder appToken, int maxWidth
			, int maxHeight);

		[Sharpen.Stub]
		void statusBarVisibilityChanged(int visibility);

		[Sharpen.Stub]
		void setPointerSpeed(int speed);

		[Sharpen.Stub]
		void waitForWindowDrawn(android.os.IBinder token, android.os.IRemoteCallback callback
			);

		[Sharpen.Stub]
		bool hasNavigationBar();
	}

	[Sharpen.Stub]
	public static class IWindowManagerClass
	{
		[Sharpen.Stub]
		public abstract class Stub : android.os.Binder, android.view.IWindowManager
		{
			internal const string DESCRIPTOR = "android.view.IWindowManager";

			[Sharpen.Stub]
			public Stub()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.view.IWindowManager asInterface(android.os.IBinder obj)
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
			private class Proxy : android.view.IWindowManager
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
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool startViewServer(int port)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool stopViewServer()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool isViewServerRunning()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual android.view.IWindowSession openSession(android.view.@internal.IInputMethodClient
					 client, android.view.@internal.IInputContext inputContext)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool inputMethodClientHasFocus(android.view.@internal.IInputMethodClient
					 client)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void getDisplaySize(android.graphics.Point size)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void getRealDisplaySize(android.graphics.Point size)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getMaximumSizeDimension()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setForcedDisplaySize(int longDimen, int shortDimen)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void clearForcedDisplaySize()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool canStatusBarHide()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool injectKeyEvent(android.view.KeyEvent ev, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool injectPointerEvent(android.view.MotionEvent ev, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool injectTrackballEvent(android.view.MotionEvent ev, bool sync)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool injectInputEventNoWait(android.view.InputEvent ev)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void pauseKeyDispatching(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void resumeKeyDispatching(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setEventDispatching(bool enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void addWindowToken(android.os.IBinder token, int type)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void removeWindowToken(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void addAppToken(int addPos, android.view.IApplicationToken token, 
					int groupId, int requestedOrientation, bool fullscreen)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAppGroupId(android.os.IBinder token, int groupId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAppOrientation(android.view.IApplicationToken token, int requestedOrientation
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getAppOrientation(android.view.IApplicationToken token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setFocusedApp(android.os.IBinder token, bool moveFocusNow)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void prepareAppTransition(int transit, bool alwaysKeepCurrent)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getPendingAppTransition()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void overridePendingAppTransition(string packageName, int enterAnim
					, int exitAnim)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void executeAppTransition()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAppStartingWindow(android.os.IBinder token, string pkg, int
					 theme, android.content.res.CompatibilityInfo compatInfo, java.lang.CharSequence
					 nonLocalizedLabel, int labelRes, int icon, int windowFlags, android.os.IBinder 
					transferFrom, bool createIfNeeded)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAppWillBeHidden(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAppVisibility(android.os.IBinder token, bool visible)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void startAppFreezingScreen(android.os.IBinder token, int configChanges
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void stopAppFreezingScreen(android.os.IBinder token, bool force)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void removeAppToken(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void moveAppToken(int index, android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void moveAppTokensToTop(java.util.List<android.os.IBinder> tokens)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void moveAppTokensToBottom(java.util.List<android.os.IBinder> tokens
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual android.content.res.Configuration updateOrientationFromAppTokens(android.content.res.Configuration
					 currentConfig, android.os.IBinder freezeThisOneIfNeeded)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setNewConfiguration(android.content.res.Configuration config)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void disableKeyguard(android.os.IBinder token, string tag)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void reenableKeyguard(android.os.IBinder token)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void exitKeyguardSecurely(android.view.IOnKeyguardExitResult callback
					)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool isKeyguardLocked()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool isKeyguardSecure()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool inKeyguardRestrictedInputMode()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void dismissKeyguard()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void closeSystemDialogs(string reason)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual float getAnimationScale(int which)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual float[] getAnimationScales()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAnimationScale(int which, float scale)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setAnimationScales(float[] scales)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getSwitchState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getSwitchStateForDevice(int devid, int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getScancodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getScancodeStateForDevice(int devid, int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getTrackballScancodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getDPadScancodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getKeycodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getKeycodeStateForDevice(int devid, int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getTrackballKeycodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getDPadKeycodeState(int sw)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual android.view.InputChannel monitorInput(string inputChannelName)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool hasKeys(int[] keycodes, bool[] keyExists)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual android.view.InputDevice getInputDevice(int deviceId)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int[] getInputDeviceIds()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setInTouchMode(bool showFocus)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void showStrictModeViolation(bool on)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setStrictModeVisualIndicatorPreference(string enabled)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void updateRotation(bool alwaysSendConfiguration)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getRotation()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int watchRotation(android.view.IRotationWatcher watcher)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual int getPreferredOptionsPanelGravity()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void freezeRotation(int rotation)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void thawRotation()
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual android.graphics.Bitmap screenshotApplications(android.os.IBinder 
					appToken, int maxWidth, int maxHeight)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void statusBarVisibilityChanged(int visibility)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void setPointerSpeed(int speed)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual void waitForWindowDrawn(android.os.IBinder token, android.os.IRemoteCallback
					 callback)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.view.IWindowManager")]
				public virtual bool hasNavigationBar()
				{
					throw new System.NotImplementedException();
				}
			}

			internal const int TRANSACTION_startViewServer = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 0);

			internal const int TRANSACTION_stopViewServer = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 1);

			internal const int TRANSACTION_isViewServerRunning = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 2);

			internal const int TRANSACTION_openSession = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 3);

			internal const int TRANSACTION_inputMethodClientHasFocus = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 4);

			internal const int TRANSACTION_getDisplaySize = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 5);

			internal const int TRANSACTION_getRealDisplaySize = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 6);

			internal const int TRANSACTION_getMaximumSizeDimension = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 7);

			internal const int TRANSACTION_setForcedDisplaySize = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 8);

			internal const int TRANSACTION_clearForcedDisplaySize = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 9);

			internal const int TRANSACTION_canStatusBarHide = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 10);

			internal const int TRANSACTION_injectKeyEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 11);

			internal const int TRANSACTION_injectPointerEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 12);

			internal const int TRANSACTION_injectTrackballEvent = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 13);

			internal const int TRANSACTION_injectInputEventNoWait = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 14);

			internal const int TRANSACTION_pauseKeyDispatching = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 15);

			internal const int TRANSACTION_resumeKeyDispatching = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 16);

			internal const int TRANSACTION_setEventDispatching = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 17);

			internal const int TRANSACTION_addWindowToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 18);

			internal const int TRANSACTION_removeWindowToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 19);

			internal const int TRANSACTION_addAppToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 20);

			internal const int TRANSACTION_setAppGroupId = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 21);

			internal const int TRANSACTION_setAppOrientation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 22);

			internal const int TRANSACTION_getAppOrientation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 23);

			internal const int TRANSACTION_setFocusedApp = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 24);

			internal const int TRANSACTION_prepareAppTransition = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 25);

			internal const int TRANSACTION_getPendingAppTransition = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 26);

			internal const int TRANSACTION_overridePendingAppTransition = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 27);

			internal const int TRANSACTION_executeAppTransition = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 28);

			internal const int TRANSACTION_setAppStartingWindow = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 29);

			internal const int TRANSACTION_setAppWillBeHidden = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 30);

			internal const int TRANSACTION_setAppVisibility = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 31);

			internal const int TRANSACTION_startAppFreezingScreen = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 32);

			internal const int TRANSACTION_stopAppFreezingScreen = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 33);

			internal const int TRANSACTION_removeAppToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 34);

			internal const int TRANSACTION_moveAppToken = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 35);

			internal const int TRANSACTION_moveAppTokensToTop = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 36);

			internal const int TRANSACTION_moveAppTokensToBottom = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 37);

			internal const int TRANSACTION_updateOrientationFromAppTokens = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 38);

			internal const int TRANSACTION_setNewConfiguration = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 39);

			internal const int TRANSACTION_disableKeyguard = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 40);

			internal const int TRANSACTION_reenableKeyguard = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 41);

			internal const int TRANSACTION_exitKeyguardSecurely = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 42);

			internal const int TRANSACTION_isKeyguardLocked = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 43);

			internal const int TRANSACTION_isKeyguardSecure = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 44);

			internal const int TRANSACTION_inKeyguardRestrictedInputMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 45);

			internal const int TRANSACTION_dismissKeyguard = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 46);

			internal const int TRANSACTION_closeSystemDialogs = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 47);

			internal const int TRANSACTION_getAnimationScale = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 48);

			internal const int TRANSACTION_getAnimationScales = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 49);

			internal const int TRANSACTION_setAnimationScale = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 50);

			internal const int TRANSACTION_setAnimationScales = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 51);

			internal const int TRANSACTION_getSwitchState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 52);

			internal const int TRANSACTION_getSwitchStateForDevice = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 53);

			internal const int TRANSACTION_getScancodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 54);

			internal const int TRANSACTION_getScancodeStateForDevice = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 55);

			internal const int TRANSACTION_getTrackballScancodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 56);

			internal const int TRANSACTION_getDPadScancodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 57);

			internal const int TRANSACTION_getKeycodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 58);

			internal const int TRANSACTION_getKeycodeStateForDevice = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 59);

			internal const int TRANSACTION_getTrackballKeycodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 60);

			internal const int TRANSACTION_getDPadKeycodeState = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 61);

			internal const int TRANSACTION_monitorInput = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 62);

			internal const int TRANSACTION_hasKeys = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 63);

			internal const int TRANSACTION_getInputDevice = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 64);

			internal const int TRANSACTION_getInputDeviceIds = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 65);

			internal const int TRANSACTION_setInTouchMode = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 66);

			internal const int TRANSACTION_showStrictModeViolation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 67);

			internal const int TRANSACTION_setStrictModeVisualIndicatorPreference = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 68);

			internal const int TRANSACTION_updateRotation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 69);

			internal const int TRANSACTION_getRotation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 70);

			internal const int TRANSACTION_watchRotation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 71);

			internal const int TRANSACTION_getPreferredOptionsPanelGravity = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 72);

			internal const int TRANSACTION_freezeRotation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 73);

			internal const int TRANSACTION_thawRotation = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 74);

			internal const int TRANSACTION_screenshotApplications = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 75);

			internal const int TRANSACTION_statusBarVisibilityChanged = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 76);

			internal const int TRANSACTION_setPointerSpeed = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 77);

			internal const int TRANSACTION_waitForWindowDrawn = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 78);

			internal const int TRANSACTION_hasNavigationBar = (android.os.IBinderClass.FIRST_CALL_TRANSACTION
				 + 79);

			public abstract void addAppToken(int arg1, android.view.IApplicationToken arg2, int
				 arg3, int arg4, bool arg5);

			public abstract void addWindowToken(android.os.IBinder arg1, int arg2);

			public abstract bool canStatusBarHide();

			public abstract void clearForcedDisplaySize();

			public abstract void closeSystemDialogs(string arg1);

			public abstract void disableKeyguard(android.os.IBinder arg1, string arg2);

			public abstract void dismissKeyguard();

			public abstract void executeAppTransition();

			public abstract void exitKeyguardSecurely(android.view.IOnKeyguardExitResult arg1
				);

			public abstract void freezeRotation(int arg1);

			public abstract float getAnimationScale(int arg1);

			public abstract float[] getAnimationScales();

			public abstract int getAppOrientation(android.view.IApplicationToken arg1);

			public abstract int getDPadKeycodeState(int arg1);

			public abstract int getDPadScancodeState(int arg1);

			public abstract void getDisplaySize(android.graphics.Point arg1);

			public abstract android.view.InputDevice getInputDevice(int arg1);

			public abstract int[] getInputDeviceIds();

			public abstract int getKeycodeState(int arg1);

			public abstract int getKeycodeStateForDevice(int arg1, int arg2);

			public abstract int getMaximumSizeDimension();

			public abstract int getPendingAppTransition();

			public abstract int getPreferredOptionsPanelGravity();

			public abstract void getRealDisplaySize(android.graphics.Point arg1);

			public abstract int getRotation();

			public abstract int getScancodeState(int arg1);

			public abstract int getScancodeStateForDevice(int arg1, int arg2);

			public abstract int getSwitchState(int arg1);

			public abstract int getSwitchStateForDevice(int arg1, int arg2);

			public abstract int getTrackballKeycodeState(int arg1);

			public abstract int getTrackballScancodeState(int arg1);

			public abstract bool hasKeys(int[] arg1, bool[] arg2);

			public abstract bool hasNavigationBar();

			public abstract bool inKeyguardRestrictedInputMode();

			public abstract bool injectInputEventNoWait(android.view.InputEvent arg1);

			public abstract bool injectKeyEvent(android.view.KeyEvent arg1, bool arg2);

			public abstract bool injectPointerEvent(android.view.MotionEvent arg1, bool arg2);

			public abstract bool injectTrackballEvent(android.view.MotionEvent arg1, bool arg2
				);

			public abstract bool inputMethodClientHasFocus(android.view.@internal.IInputMethodClient
				 arg1);

			public abstract bool isKeyguardLocked();

			public abstract bool isKeyguardSecure();

			public abstract bool isViewServerRunning();

			public abstract android.view.InputChannel monitorInput(string arg1);

			public abstract void moveAppToken(int arg1, android.os.IBinder arg2);

			public abstract void moveAppTokensToBottom(java.util.List<android.os.IBinder> arg1
				);

			public abstract void moveAppTokensToTop(java.util.List<android.os.IBinder> arg1);

			public abstract android.view.IWindowSession openSession(android.view.@internal.IInputMethodClient
				 arg1, android.view.@internal.IInputContext arg2);

			public abstract void overridePendingAppTransition(string arg1, int arg2, int arg3
				);

			public abstract void pauseKeyDispatching(android.os.IBinder arg1);

			public abstract void prepareAppTransition(int arg1, bool arg2);

			public abstract void reenableKeyguard(android.os.IBinder arg1);

			public abstract void removeAppToken(android.os.IBinder arg1);

			public abstract void removeWindowToken(android.os.IBinder arg1);

			public abstract void resumeKeyDispatching(android.os.IBinder arg1);

			public abstract android.graphics.Bitmap screenshotApplications(android.os.IBinder
				 arg1, int arg2, int arg3);

			public abstract void setAnimationScale(int arg1, float arg2);

			public abstract void setAnimationScales(float[] arg1);

			public abstract void setAppGroupId(android.os.IBinder arg1, int arg2);

			public abstract void setAppOrientation(android.view.IApplicationToken arg1, int arg2
				);

			public abstract void setAppStartingWindow(android.os.IBinder arg1, string arg2, int
				 arg3, android.content.res.CompatibilityInfo arg4, java.lang.CharSequence arg5, 
				int arg6, int arg7, int arg8, android.os.IBinder arg9, bool arg10);

			public abstract void setAppVisibility(android.os.IBinder arg1, bool arg2);

			public abstract void setAppWillBeHidden(android.os.IBinder arg1);

			public abstract void setEventDispatching(bool arg1);

			public abstract void setFocusedApp(android.os.IBinder arg1, bool arg2);

			public abstract void setForcedDisplaySize(int arg1, int arg2);

			public abstract void setInTouchMode(bool arg1);

			public abstract void setNewConfiguration(android.content.res.Configuration arg1);

			public abstract void setPointerSpeed(int arg1);

			public abstract void setStrictModeVisualIndicatorPreference(string arg1);

			public abstract void showStrictModeViolation(bool arg1);

			public abstract void startAppFreezingScreen(android.os.IBinder arg1, int arg2);

			public abstract bool startViewServer(int arg1);

			public abstract void statusBarVisibilityChanged(int arg1);

			public abstract void stopAppFreezingScreen(android.os.IBinder arg1, bool arg2);

			public abstract bool stopViewServer();

			public abstract void thawRotation();

			public abstract android.content.res.Configuration updateOrientationFromAppTokens(
				android.content.res.Configuration arg1, android.os.IBinder arg2);

			public abstract void updateRotation(bool arg1);

			public abstract void waitForWindowDrawn(android.os.IBinder arg1, android.os.IRemoteCallback
				 arg2);

			public abstract int watchRotation(android.view.IRotationWatcher arg1);
		}
	}
}
