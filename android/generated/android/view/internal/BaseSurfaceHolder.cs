using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public abstract class BaseSurfaceHolder : android.view.SurfaceHolder
	{
		internal const string TAG = "BaseSurfaceHolder";

		internal const bool DEBUG = false;

		public readonly java.util.ArrayList<android.view.SurfaceHolderClass.Callback> mCallbacks
			 = new java.util.ArrayList<android.view.SurfaceHolderClass.Callback>();

		internal android.view.SurfaceHolderClass.Callback[] mGottenCallbacks;

		internal bool mHaveGottenCallbacks;

		public readonly java.util.concurrent.locks.ReentrantLock mSurfaceLock = new java.util.concurrent.locks.ReentrantLock
			();

		public android.view.Surface mSurface = new android.view.Surface();

		internal int mRequestedWidth = -1;

		internal int mRequestedHeight = -1;

		protected internal int mRequestedFormat = android.graphics.PixelFormat.OPAQUE;

		internal int mRequestedType = -1;

		internal long mLastLockTime = 0;

		internal int mType = -1;

		internal readonly android.graphics.Rect mSurfaceFrame = new android.graphics.Rect
			();

		internal android.graphics.Rect mTmpDirty;

		[Sharpen.Stub]
		public abstract void onUpdateSurface();

		[Sharpen.Stub]
		public abstract void onRelayoutContainer();

		[Sharpen.Stub]
		public abstract bool onAllowLockCanvas();

		[Sharpen.Stub]
		public virtual int getRequestedWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedHeight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedFormat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRequestedType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void addCallback(android.view.SurfaceHolderClass.Callback callback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void removeCallback(android.view.SurfaceHolderClass.Callback callback
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.SurfaceHolderClass.Callback[] getCallbacks()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void ungetCallbacks()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void setFixedSize(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void setSizeFromLayout()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void setFormat(int format)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void setType(int type)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual android.graphics.Canvas lockCanvas()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual android.graphics.Canvas lockCanvas(android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.graphics.Canvas internalLockCanvas(android.graphics.Rect dirty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual void unlockCanvasAndPost(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual android.view.Surface getSurface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.SurfaceHolder")]
		public virtual android.graphics.Rect getSurfaceFrame()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSurfaceFrameSize(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		public abstract bool isCreating();

		public abstract void setKeepScreenOn(bool arg1);
	}
}
