using Sharpen;

namespace android.view
{
	/// <summary>
	/// Helper class to handle situations where you want a view to have a larger touch area than its
	/// actual view bounds.
	/// </summary>
	/// <remarks>
	/// Helper class to handle situations where you want a view to have a larger touch area than its
	/// actual view bounds. The view whose touch area is changed is called the delegate view. This
	/// class should be used by an ancestor of the delegate. To use a TouchDelegate, first create an
	/// instance that specifies the bounds that should be mapped to the delegate and the delegate
	/// view itself.
	/// <p>
	/// The ancestor should then forward all of its touch events received in its
	/// <see cref="View.onTouchEvent(MotionEvent)">View.onTouchEvent(MotionEvent)</see>
	/// to
	/// <see cref="onTouchEvent(MotionEvent)">onTouchEvent(MotionEvent)</see>
	/// .
	/// </p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class TouchDelegate
	{
		/// <summary>View that should receive forwarded touch events</summary>
		private android.view.View mDelegateView;

		/// <summary>
		/// Bounds in local coordinates of the containing view that should be mapped to the delegate
		/// view.
		/// </summary>
		/// <remarks>
		/// Bounds in local coordinates of the containing view that should be mapped to the delegate
		/// view. This rect is used for initial hit testing.
		/// </remarks>
		private android.graphics.Rect mBounds;

		/// <summary>mBounds inflated to include some slop.</summary>
		/// <remarks>
		/// mBounds inflated to include some slop. This rect is to track whether the motion events
		/// should be considered to be be within the delegate view.
		/// </remarks>
		private android.graphics.Rect mSlopBounds;

		/// <summary>True if the delegate had been targeted on a down event (intersected mBounds).
		/// 	</summary>
		/// <remarks>True if the delegate had been targeted on a down event (intersected mBounds).
		/// 	</remarks>
		private bool mDelegateTargeted;

		/// <summary>The touchable region of the View extends above its actual extent.</summary>
		/// <remarks>The touchable region of the View extends above its actual extent.</remarks>
		public const int ABOVE = 1;

		/// <summary>The touchable region of the View extends below its actual extent.</summary>
		/// <remarks>The touchable region of the View extends below its actual extent.</remarks>
		public const int BELOW = 2;

		/// <summary>
		/// The touchable region of the View extends to the left of its
		/// actual extent.
		/// </summary>
		/// <remarks>
		/// The touchable region of the View extends to the left of its
		/// actual extent.
		/// </remarks>
		public const int TO_LEFT = 4;

		/// <summary>
		/// The touchable region of the View extends to the right of its
		/// actual extent.
		/// </summary>
		/// <remarks>
		/// The touchable region of the View extends to the right of its
		/// actual extent.
		/// </remarks>
		public const int TO_RIGHT = 8;

		private int mSlop;

		/// <summary>Constructor</summary>
		/// <param name="bounds">
		/// Bounds in local coordinates of the containing view that should be mapped to
		/// the delegate view
		/// </param>
		/// <param name="delegateView">The view that should receive motion events</param>
		public TouchDelegate(android.graphics.Rect bounds, android.view.View delegateView
			)
		{
			mBounds = bounds;
			mSlop = android.view.ViewConfiguration.get(delegateView.getContext()).getScaledTouchSlop
				();
			mSlopBounds = new android.graphics.Rect(bounds);
			mSlopBounds.inset(-mSlop, -mSlop);
			mDelegateView = delegateView;
		}

		/// <summary>
		/// Will forward touch events to the delegate view if the event is within the bounds
		/// specified in the constructor.
		/// </summary>
		/// <remarks>
		/// Will forward touch events to the delegate view if the event is within the bounds
		/// specified in the constructor.
		/// </remarks>
		/// <param name="event">The touch event to forward</param>
		/// <returns>True if the event was forwarded to the delegate, false otherwise.</returns>
		public virtual bool onTouchEvent(android.view.MotionEvent @event)
		{
			int x = (int)@event.getX();
			int y = (int)@event.getY();
			bool sendToDelegate = false;
			bool hit = true;
			bool handled = false;
			switch (@event.getAction())
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					android.graphics.Rect bounds = mBounds;
					if (bounds.contains(x, y))
					{
						mDelegateTargeted = true;
						sendToDelegate = true;
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				case android.view.MotionEvent.ACTION_MOVE:
				{
					sendToDelegate = mDelegateTargeted;
					if (sendToDelegate)
					{
						android.graphics.Rect slopBounds = mSlopBounds;
						if (!slopBounds.contains(x, y))
						{
							hit = false;
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					sendToDelegate = mDelegateTargeted;
					mDelegateTargeted = false;
					break;
				}
			}
			if (sendToDelegate)
			{
				android.view.View delegateView = mDelegateView;
				if (hit)
				{
					// Offset event coordinates to be inside the target view
					@event.setLocation(delegateView.getWidth() / 2, delegateView.getHeight() / 2);
				}
				else
				{
					// Offset event coordinates to be outside the target view (in case it does
					// something like tracking pressed state)
					int slop = mSlop;
					@event.setLocation(-(slop * 2), -(slop * 2));
				}
				handled = delegateView.dispatchTouchEvent(@event);
			}
			return handled;
		}
	}
}
