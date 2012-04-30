using System;
using XobotOS.Runtime;
using android.content;
using android.view;

namespace android.app
{
	partial class Activity
	{
		internal void attach (Context context, Application application, Window window)
		{
			mApplication = application;
			mWindow = window;

			attachBaseContext (context);
			mFragments.attachActivity (this);

			mWindow.setCallback (this);
		}

		public virtual void finish ()
		{
			if (mParent == null) {
				int resultCode;
				Intent resultData;
				lock (this) {
					resultCode = mResultCode;
					resultData = mResultData;
				}
				if (resultData != null) {
					resultData.setAllowFds (false);
				}
				XobotActivityManager.FinishActivity (this, resultCode, resultData);
				mFinished = true;
			} else {
				mParent.finishFromChild (this);
			}
		}
	}
}
