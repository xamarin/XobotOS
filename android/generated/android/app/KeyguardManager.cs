using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class KeyguardManager
	{
		private android.view.IWindowManager mWM;

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use android.view.WindowManagerClass.LayoutParams.FLAG_DISMISS_KEYGUARD and/or android.view.WindowManagerClass.LayoutParams.FLAG_SHOW_WHEN_LOCKED instead; this allows you to seamlessly hide the keyguard as your application moves in and out of the foreground and does not require that any special permissions be requested. Handle returned by KeyguardManager.newKeyguardLock(string) that allows you to disable / reenable the keyguard."
			)]
		public class KeyguardLock
		{
			private android.os.IBinder mToken;

			private string mTag;

			[Sharpen.Stub]
			internal KeyguardLock(KeyguardManager _enclosing, string tag)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void disableKeyguard()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void reenableKeyguard()
			{
				throw new System.NotImplementedException();
			}

			private readonly KeyguardManager _enclosing;
		}

		[Sharpen.Stub]
		public interface OnKeyguardExitResult
		{
			[Sharpen.Stub]
			void onKeyguardExitResult(bool success);
		}

		[Sharpen.Stub]
		internal KeyguardManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use android.view.WindowManagerClass.LayoutParams.FLAG_DISMISS_KEYGUARD and/or android.view.WindowManagerClass.LayoutParams.FLAG_SHOW_WHEN_LOCKED instead; this allows you to seamlessly hide the keyguard as your application moves in and out of the foreground and does not require that any special permissions be requested. Enables you to lock or unlock the keyboard. Get an instance of this class by calling android.content.Context.getSystemService(string) Context.getSystemService() . This class is wrapped by KeyguardManager KeyguardManager ."
			)]
		public virtual android.app.KeyguardManager.KeyguardLock newKeyguardLock(string tag
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isKeyguardLocked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isKeyguardSecure()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool inKeyguardRestrictedInputMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute(@"Use android.view.WindowManagerClass.LayoutParams.FLAG_DISMISS_KEYGUARD and/or android.view.WindowManagerClass.LayoutParams.FLAG_SHOW_WHEN_LOCKED instead; this allows you to seamlessly hide the keyguard as your application moves in and out of the foreground and does not require that any special permissions be requested. Exit the keyguard securely.  The use case for this api is that, after disabling the keyguard, your app, which was granted permission to disable the keyguard and show a limited amount of information deemed safe without the user getting past the keyguard, needs to navigate to something that is not safe to view without getting past the keyguard. This will, if the keyguard is secure, bring up the unlock screen of the keyguard."
			)]
		public virtual void exitKeyguardSecurely(android.app.KeyguardManager.OnKeyguardExitResult
			 callback)
		{
			throw new System.NotImplementedException();
		}
	}
}
