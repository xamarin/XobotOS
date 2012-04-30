using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// Like a normal linear layout, but supports dispatching all otherwise unhandled
	/// touch events to a particular descendant.
	/// </summary>
	/// <remarks>
	/// Like a normal linear layout, but supports dispatching all otherwise unhandled
	/// touch events to a particular descendant.  This is for the unlock screen, so
	/// that a wider range of touch events than just the lock pattern widget can kick
	/// off a lock pattern if the finger is eventually dragged into the bounds of the
	/// lock pattern view.
	/// </remarks>
	[Sharpen.Sharpened]
	public class LinearLayoutWithDefaultTouchRecepient : android.widget.LinearLayout
	{
		private readonly android.graphics.Rect mTempRect = new android.graphics.Rect();

		private android.view.View mDefaultTouchRecepient;

		public LinearLayoutWithDefaultTouchRecepient(android.content.Context context) : base
			(context)
		{
		}

		public LinearLayoutWithDefaultTouchRecepient(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
		}

		public virtual void setDefaultTouchRecepient(android.view.View defaultTouchRecepient
			)
		{
			mDefaultTouchRecepient = defaultTouchRecepient;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchTouchEvent(android.view.MotionEvent ev)
		{
			if (mDefaultTouchRecepient == null)
			{
				return base.dispatchTouchEvent(ev);
			}
			if (base.dispatchTouchEvent(ev))
			{
				return true;
			}
			mTempRect.set(0, 0, 0, 0);
			offsetRectIntoDescendantCoords(mDefaultTouchRecepient, mTempRect);
			ev.setLocation(ev.getX() + mTempRect.left, ev.getY() + mTempRect.top);
			return mDefaultTouchRecepient.dispatchTouchEvent(ev);
		}
	}
}
