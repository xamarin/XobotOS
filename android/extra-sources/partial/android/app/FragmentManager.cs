using System;
using XobotOS.Runtime;

namespace android.app
{
	partial class FragmentManagerImpl
	{
		/// <summary>Only call from main thread!</summary>
		public bool execPendingActions ()
		{
			if (mExecutingActions)
				throw new InvalidOperationException ("Recursive entry to executePendingTransactions");
			if (!XobotActivityManager.IsMainThread)
				throw new InvalidOperationException ("Must be called from main thread of process");

			bool didSomething = false;
			while (true) {
				int numActions;
				lock (this) {
					if (mPendingActions == null || mPendingActions.size () == 0)
						return didSomething;
					numActions = mPendingActions.size ();
					if (mTmpActions == null || mTmpActions.Length < numActions) {
						mTmpActions = new java.lang.Runnable[numActions];
					}
					mPendingActions.toArray (mTmpActions);
					mPendingActions.clear ();
					mActivity.mHandler.removeCallbacks (mExecCommit);
				}
				mExecutingActions = true;
				{
					for (int i = 0; i < numActions; i++) {
						mTmpActions [i].run ();
						mTmpActions [i] = null;
					}
				}
				mExecutingActions = false;
				didSomething = true;
			}
		}

	}
}
