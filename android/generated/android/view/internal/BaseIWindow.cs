using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public class BaseIWindow : android.view.IWindowClass.Stub
	{
		private android.view.IWindowSession mSession;

		public int mSeq;

		[Sharpen.Stub]
		public virtual void setSession(android.view.IWindowSession session)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void resized(int w, int h, android.graphics.Rect coveredInsets, android.graphics.Rect
			 visibleInsets, bool reportDraw, android.content.res.Configuration newConfig)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchAppVisibility(bool visible)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchGetNewSurface()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void windowFocusChanged(bool hasFocus, bool touchEnabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void executeCommand(string command, string parameters, android.os.ParcelFileDescriptor
			 @out)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void closeSystemDialogs(string reason)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchWallpaperOffsets(float x, float y, float xStep, float
			 yStep, bool sync)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchDragEvent(android.view.DragEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchSystemUiVisibilityChanged(int seq, int globalUi, int
			 localValue, int localChanges)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.IWindow")]
		public override void dispatchWallpaperCommand(string action, int x, int y, int z, 
			android.os.Bundle extras, bool sync)
		{
			throw new System.NotImplementedException();
		}
	}
}
