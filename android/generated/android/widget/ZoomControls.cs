using Sharpen;

namespace android.widget
{
	/// <summary>
	/// The
	/// <code>ZoomControls</code>
	/// class displays a simple set of controls used for zooming and
	/// provides callbacks to register for events.
	/// </summary>
	[Sharpen.Sharpened]
	public class ZoomControls : android.widget.LinearLayout
	{
		private readonly android.widget.ZoomButton mZoomIn;

		private readonly android.widget.ZoomButton mZoomOut;

		public ZoomControls(android.content.Context context) : this(context, null)
		{
		}

		public ZoomControls(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			setFocusable(false);
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			inflater.inflate(android.@internal.R.layout.zoom_controls, this, true);
			// we are the parent
			mZoomIn = (android.widget.ZoomButton)findViewById(android.@internal.R.id.zoomIn);
			mZoomOut = (android.widget.ZoomButton)findViewById(android.@internal.R.id.zoomOut
				);
		}

		public virtual void setOnZoomInClickListener(android.view.View.OnClickListener listener
			)
		{
			mZoomIn.setOnClickListener(listener);
		}

		public virtual void setOnZoomOutClickListener(android.view.View.OnClickListener listener
			)
		{
			mZoomOut.setOnClickListener(listener);
		}

		public virtual void setZoomSpeed(long speed)
		{
			mZoomIn.setZoomSpeed(speed);
			mZoomOut.setZoomSpeed(speed);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			return true;
		}

		public virtual void show()
		{
			fade(android.view.View.VISIBLE, 0.0f, 1.0f);
		}

		public virtual void hide()
		{
			fade(android.view.View.GONE, 1.0f, 0.0f);
		}

		private void fade(int visibility, float startAlpha, float endAlpha)
		{
			android.view.animation.AlphaAnimation anim = new android.view.animation.AlphaAnimation
				(startAlpha, endAlpha);
			anim.setDuration(500);
			startAnimation(anim);
			setVisibility(visibility);
		}

		public virtual void setIsZoomInEnabled(bool isEnabled_1)
		{
			mZoomIn.setEnabled(isEnabled_1);
		}

		public virtual void setIsZoomOutEnabled(bool isEnabled_1)
		{
			mZoomOut.setEnabled(isEnabled_1);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool hasFocus()
		{
			return mZoomIn.hasFocus() || mZoomOut.hasFocus();
		}
	}
}
