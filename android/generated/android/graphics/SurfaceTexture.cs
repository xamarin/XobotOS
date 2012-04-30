using Sharpen;

namespace android.graphics
{
	[Sharpen.Stub]
	[Sharpen.Comment(@"This is using native code outside of Skia for 3D rendering.")]
	public class SurfaceTexture
	{
		private android.graphics.SurfaceTexture.EventHandler mEventHandler;

		private android.graphics.SurfaceTexture.OnFrameAvailableListener mOnFrameAvailableListener;

		private int mSurfaceTexture;

		[Sharpen.Stub]
		public interface OnFrameAvailableListener
		{
			[Sharpen.Stub]
			void onFrameAvailable(android.graphics.SurfaceTexture surfaceTexture);
		}

		[System.Serializable]
		[Sharpen.Stub]
		public class OutOfResourcesException : System.Exception
		{
			[Sharpen.Stub]
			public OutOfResourcesException()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public OutOfResourcesException(string name) : base(name)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public SurfaceTexture(int texName) : this(texName, false)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public SurfaceTexture(int texName, bool allowSynchronousMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnFrameAvailableListener(android.graphics.SurfaceTexture.OnFrameAvailableListener
			 l)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDefaultBufferSize(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void updateTexImage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getTransformMatrix(float[] mtx)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual long getTimestamp()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void release()
		{
			throw new System.NotImplementedException();
		}

		~SurfaceTexture()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class EventHandler : android.os.Handler
		{
			[Sharpen.Stub]
			public EventHandler(SurfaceTexture _enclosing, android.os.Looper looper) : base(looper
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly SurfaceTexture _enclosing;
		}

		[Sharpen.Stub]
		private static void postEventFromNative(object selfRef)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeInit(int texName, object weakSelf, bool allowSynchronousMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeFinalize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeGetTransformMatrix(float[] mtx)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private long nativeGetTimestamp()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeSetDefaultBufferSize(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeUpdateTexImage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int nativeGetQueuedCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void nativeRelease()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void nativeClassInit()
		{
			throw new System.NotImplementedException();
		}

		static SurfaceTexture()
		{
			throw new System.NotImplementedException();
		}
	}
}
