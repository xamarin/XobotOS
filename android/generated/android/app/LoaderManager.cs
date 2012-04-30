using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public abstract class LoaderManager
	{
		[Sharpen.Stub]
		public interface LoaderCallbacks<D>
		{
			[Sharpen.Stub]
			android.content.Loader<D> onCreateLoader(int id, android.os.Bundle args);

			[Sharpen.Stub]
			void onLoadFinished(android.content.Loader<D> loader, D data);

			[Sharpen.Stub]
			void onLoaderReset(android.content.Loader<D> loader);
		}

		[Sharpen.Stub]
		public abstract android.content.Loader<D> initLoader<D>(int id, android.os.Bundle
			 args, android.app.LoaderManager.LoaderCallbacks<D> callback);

		[Sharpen.Stub]
		public abstract android.content.Loader<D> restartLoader<D>(int id, android.os.Bundle
			 args, android.app.LoaderManager.LoaderCallbacks<D> callback);

		[Sharpen.Stub]
		public abstract void destroyLoader(int id);

		[Sharpen.Stub]
		public abstract android.content.Loader<D> getLoader<D>(int id);

		[Sharpen.Stub]
		public abstract void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args);

		[Sharpen.Stub]
		public static void enableDebugLogging(bool enabled)
		{
			throw new System.NotImplementedException();
		}
	}

	[Sharpen.Stub]
	internal class LoaderManagerImpl : android.app.LoaderManager
	{
		internal const string TAG = "LoaderManager";

		internal static bool DEBUG = false;

		internal readonly android.util.SparseArray<android.app.LoaderManagerImpl.LoaderInfo
			> mLoaders = new android.util.SparseArray<android.app.LoaderManagerImpl.LoaderInfo
			>();

		internal readonly android.util.SparseArray<android.app.LoaderManagerImpl.LoaderInfo
			> mInactiveLoaders = new android.util.SparseArray<android.app.LoaderManagerImpl.
			LoaderInfo>();

		internal android.app.Activity mActivity;

		internal bool mStarted;

		internal bool mRetaining;

		internal bool mRetainingStarted;

		internal bool mCreatingLoader;

		[Sharpen.Stub]
		internal sealed class LoaderInfo : android.content.Loader.OnLoadCompleteListener<
			object>
		{
			internal readonly int mId;

			internal readonly android.os.Bundle mArgs;

			internal android.app.LoaderManager.LoaderCallbacks<object> mCallbacks;

			internal android.content.Loader<object> mLoader;

			internal bool mHaveData;

			internal bool mDeliveredData;

			internal object mData;

			internal bool mStarted;

			internal bool mRetaining;

			internal bool mRetainingStarted;

			internal bool mReportNextStart;

			internal bool mDestroyed;

			internal bool mListenerRegistered;

			internal android.app.LoaderManagerImpl.LoaderInfo mPendingLoader;

			[Sharpen.Stub]
			public LoaderInfo(LoaderManagerImpl _enclosing, int id, android.os.Bundle args, android.app.LoaderManager
				.LoaderCallbacks<object> callbacks)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void start()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void retain()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void finishRetain()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void reportStart()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void stop()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void destroy()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.content.Loader.OnLoadCompleteListener")]
			public void onLoadComplete(android.content.Loader<object> loader, object data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void callOnLoadFinished(android.content.Loader<object> loader, object data
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter writer
				, string[] args)
			{
				throw new System.NotImplementedException();
			}

			private readonly LoaderManagerImpl _enclosing;
		}

		[Sharpen.Stub]
		internal LoaderManagerImpl(android.app.Activity activity, bool started)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void updateActivity(android.app.Activity activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.app.LoaderManagerImpl.LoaderInfo createLoader(int id, android.os.Bundle
			 args, android.app.LoaderManager.LoaderCallbacks<object> callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.app.LoaderManagerImpl.LoaderInfo createAndInstallLoader(int id, 
			android.os.Bundle args, android.app.LoaderManager.LoaderCallbacks<object> callback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void installLoader(android.app.LoaderManagerImpl.LoaderInfo info
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.LoaderManager")]
		public override android.content.Loader<D> initLoader<D>(int id, android.os.Bundle
			 args, android.app.LoaderManager.LoaderCallbacks<D> callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.LoaderManager")]
		public override android.content.Loader<D> restartLoader<D>(int id, android.os.Bundle
			 args, android.app.LoaderManager.LoaderCallbacks<D> callback)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.LoaderManager")]
		public override void destroyLoader(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.LoaderManager")]
		public override android.content.Loader<D> getLoader<D>(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doRetain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void finishRetain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doReportNextStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doReportStart()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void doDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.LoaderManager")]
		public override void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}
