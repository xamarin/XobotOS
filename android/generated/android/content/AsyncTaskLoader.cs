using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public static class AsyncTaskLoader
	{
		internal const string TAG = "AsyncTaskLoader";

		internal const bool DEBUG = false;
	}

	[Sharpen.Stub]
	public abstract class AsyncTaskLoader<D> : android.content.Loader<D>
	{
		[Sharpen.Stub]
		internal sealed class LoadTask : android.os.AsyncTask<object, object, D>, java.lang.Runnable
		{
			internal D result;

			internal bool waiting;

			private java.util.concurrent.CountDownLatch done;

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.AsyncTask")]
			protected internal override D doInBackground(params object[] @params)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.AsyncTask")]
			protected internal override void onPostExecute(D data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.AsyncTask")]
			protected internal override void onCancelled()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				throw new System.NotImplementedException();
			}

			public LoadTask(AsyncTaskLoader<D> _enclosing)
			{
				this._enclosing = _enclosing;
				done = null;
			}

			private readonly AsyncTaskLoader<D> _enclosing;
		}

		internal volatile android.content.AsyncTaskLoader<D>.LoadTask mTask;

		internal volatile android.content.AsyncTaskLoader<D>.LoadTask mCancellingTask;

		internal long mUpdateThrottle;

		internal long mLastLoadCompleteTime = -10000;

		internal android.os.Handler mHandler;

		[Sharpen.Stub]
		public AsyncTaskLoader(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setUpdateThrottle(long delayMS)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		protected internal override void onForceLoad()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool cancelLoad()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onCanceled(D data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void executePendingTask()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void dispatchOnCancelled(android.content.AsyncTaskLoader<D>.LoadTask
			 task, D data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void dispatchOnLoadComplete(android.content.AsyncTaskLoader<D>.LoadTask
			 task, D data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract D loadInBackground();

		[Sharpen.Stub]
		protected internal virtual D onLoadInBackground()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void waitForLoader()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.content.Loader")]
		public override void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}
