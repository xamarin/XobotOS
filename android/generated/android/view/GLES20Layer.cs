using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	internal abstract class GLES20Layer : android.view.HardwareLayer
	{
		internal int mLayer;

		internal android.view.GLES20Layer.Finalizer mFinalizer;

		[Sharpen.Stub]
		internal GLES20Layer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal GLES20Layer(int width, int height, bool opaque) : base(width, height, opaque
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getLayer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override bool copyInto(android.graphics.Bitmap bitmap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override void update(int width, int height, bool isOpaque_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override void destroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class Finalizer
		{
			private int mLayerId;

			[Sharpen.Stub]
			public Finalizer(int layerId)
			{
				throw new System.NotImplementedException();
			}

			~Finalizer()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void destroy()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
