using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	[System.ObsoleteAttribute(@"Use the new Fragment and FragmentManager APIs instead; these are also available on older platforms through the Android compatibility package."
		)]
	public class LocalActivityManager
	{
		internal const string TAG = "LocalActivityManager";

		internal const bool localLOGV = false;

		[Sharpen.Stub]
		private class LocalActivityRecord : android.os.Binder
		{
			[Sharpen.Stub]
			internal LocalActivityRecord(string _id, android.content.Intent _intent)
			{
				throw new System.NotImplementedException();
			}

			internal readonly string id;

			internal android.content.Intent intent;

			internal android.content.pm.ActivityInfo activityInfo;

			internal android.app.Activity activity;

			internal android.view.Window window;

			internal android.os.Bundle instanceState;

			internal int curState = RESTORED;
		}

		internal const int RESTORED = 0;

		internal const int INITIALIZING = 1;

		internal const int CREATED = 2;

		internal const int STARTED = 3;

		internal const int RESUMED = 4;

		internal const int DESTROYED = 5;

		private readonly android.app.ActivityThread mActivityThread;

		private readonly android.app.Activity mParent;

		private android.app.LocalActivityManager.LocalActivityRecord mResumed;

		private readonly java.util.Map<string, android.app.LocalActivityManager.LocalActivityRecord
			> mActivities = new java.util.HashMap<string, android.app.LocalActivityManager.LocalActivityRecord
			>();

		private readonly java.util.ArrayList<android.app.LocalActivityManager.LocalActivityRecord
			> mActivityArray = new java.util.ArrayList<android.app.LocalActivityManager.LocalActivityRecord
			>();

		private bool mSingleMode;

		private bool mFinishing;

		private int mCurState = INITIALIZING;

		[Sharpen.Stub]
		public LocalActivityManager(android.app.Activity parent, bool singleMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void moveToState(android.app.LocalActivityManager.LocalActivityRecord r, 
			int desiredState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void performPause(android.app.LocalActivityManager.LocalActivityRecord r, 
			bool finishing)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.Window startActivity(string id, android.content.Intent
			 intent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.view.Window performDestroy(android.app.LocalActivityManager.LocalActivityRecord
			 r, bool finish)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.Window destroyActivity(string id, bool finish)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity getCurrentActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string getCurrentId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity getActivity(string id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchCreate(android.os.Bundle state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Bundle saveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchResume()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchPause(bool finishing)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.HashMap<string, object> dispatchRetainNonConfigurationInstance
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void removeAllActivities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void dispatchDestroy(bool finishing)
		{
			throw new System.NotImplementedException();
		}
	}
}
