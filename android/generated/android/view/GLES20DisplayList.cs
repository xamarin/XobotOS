using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	internal class GLES20DisplayList : android.view.DisplayList
	{
		internal readonly java.util.ArrayList<android.graphics.Bitmap> mBitmaps = new java.util.ArrayList
			<android.graphics.Bitmap>(5);

		private android.view.GLES20RecordingCanvas mCanvas;

		private bool mValid;

		private android.view.GLES20DisplayList.DisplayListFinalizer mFinalizer;

		[Sharpen.Stub]
		internal virtual int getNativeDisplayList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.DisplayList")]
		internal override android.view.HardwareCanvas start()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.DisplayList")]
		internal override void invalidate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.DisplayList")]
		internal override bool isValid()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.DisplayList")]
		internal override void end()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.DisplayList")]
		internal override int getSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class DisplayListFinalizer
		{
			internal readonly int mNativeDisplayList;

			[Sharpen.Stub]
			public DisplayListFinalizer(int nativeDisplayList)
			{
				throw new System.NotImplementedException();
			}

			~DisplayListFinalizer()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
