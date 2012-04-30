using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public static class Loader
	{
		[Sharpen.Stub]
		public interface OnLoadCompleteListener<D>
		{
			[Sharpen.Stub]
			void onLoadComplete(android.content.Loader<D> loader, D data);
		}
	}

	[Sharpen.Stub]
	public class Loader<D>
	{
		internal int mId;

		internal android.content.Loader.OnLoadCompleteListener<D> mListener;

		internal android.content.Context mContext;

		internal bool mStarted = false;

		internal bool mAbandoned = false;

		internal bool mReset = true;

		internal bool mContentChanged = false;

		[Sharpen.Stub]
		public sealed class ForceLoadContentObserver : android.database.ContentObserver
		{
			[Sharpen.Stub]
			public ForceLoadContentObserver(Loader<D> _enclosing) : base(new android.os.Handler
				())
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override bool deliverSelfNotifications()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.database.ContentObserver")]
			public override void onChange(bool selfChange)
			{
				throw new System.NotImplementedException();
			}

			private readonly Loader<D> _enclosing;
		}

		[Sharpen.Stub]
		public Loader(android.content.Context context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void deliverResult(D data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.Context getContext()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void registerListener(int id, android.content.Loader.OnLoadCompleteListener
			<D> listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void unregisterListener(android.content.Loader.OnLoadCompleteListener
			<D> listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isStarted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isAbandoned()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isReset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void startLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onStartLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void forceLoad()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onForceLoad()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void stopLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onStopLoading()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void abandon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onAbandon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void reset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onReset()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool takeContentChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onContentChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual string dataToString(D data)
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
		public virtual void dump(string prefix, java.io.FileDescriptor fd, java.io.PrintWriter
			 writer, string[] args)
		{
			throw new System.NotImplementedException();
		}
	}
}
