using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	internal class GLES20TextureLayer : android.view.GLES20Layer
	{
		private int mTexture;

		private android.graphics.SurfaceTexture mSurface;

		[Sharpen.Stub]
		internal GLES20TextureLayer(bool isOpaque_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override bool isValid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override void resize(int width, int height)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override android.view.HardwareCanvas getCanvas()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override android.view.HardwareCanvas start(android.graphics.Canvas currentCanvas
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.HardwareLayer")]
		internal override void end(android.graphics.Canvas currentCanvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.graphics.SurfaceTexture getSurfaceTexture()
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
		internal override void setTransform(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}
	}
}
