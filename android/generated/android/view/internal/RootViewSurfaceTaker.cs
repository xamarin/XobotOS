using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public interface RootViewSurfaceTaker
	{
		[Sharpen.Stub]
		android.view.SurfaceHolderClass.Callback2 willYouTakeTheSurface();

		[Sharpen.Stub]
		void setSurfaceType(int type);

		[Sharpen.Stub]
		void setSurfaceFormat(int format);

		[Sharpen.Stub]
		void setSurfaceKeepScreenOn(bool keepOn);

		[Sharpen.Stub]
		android.view.InputQueue.Callback willYouTakeTheInputQueue();
	}
}
