using Sharpen;

namespace android.view
{
	/// <summary>Defines the responsibilities for a class that will be a parent of a View.
	/// 	</summary>
	/// <remarks>
	/// Defines the responsibilities for a class that will be a parent of a View.
	/// This is the API that a view sees when it wants to interact with its parent.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface ViewParent
	{
		/// <summary>
		/// Called when something has changed which has invalidated the layout of a
		/// child of this view parent.
		/// </summary>
		/// <remarks>
		/// Called when something has changed which has invalidated the layout of a
		/// child of this view parent. This will schedule a layout pass of the view
		/// tree.
		/// </remarks>
		void requestLayout();

		/// <summary>Indicates whether layout was requested on this view parent.</summary>
		/// <remarks>Indicates whether layout was requested on this view parent.</remarks>
		/// <returns>true if layout was requested, false otherwise</returns>
		bool isLayoutRequested();

		/// <summary>
		/// Called when a child wants the view hierarchy to gather and report
		/// transparent regions to the window compositor.
		/// </summary>
		/// <remarks>
		/// Called when a child wants the view hierarchy to gather and report
		/// transparent regions to the window compositor. Views that "punch" holes in
		/// the view hierarchy, such as SurfaceView can use this API to improve
		/// performance of the system. When no such a view is present in the
		/// hierarchy, this optimization in unnecessary and might slightly reduce the
		/// view hierarchy performance.
		/// </remarks>
		/// <param name="child">the view requesting the transparent region computation</param>
		void requestTransparentRegion(android.view.View child);

		/// <summary>All or part of a child is dirty and needs to be redrawn.</summary>
		/// <remarks>All or part of a child is dirty and needs to be redrawn.</remarks>
		/// <param name="child">The child which is dirty</param>
		/// <param name="r">The area within the child that is invalid</param>
		void invalidateChild(android.view.View child, android.graphics.Rect r);

		/// <summary>All or part of a child is dirty and needs to be redrawn.</summary>
		/// <remarks>
		/// All or part of a child is dirty and needs to be redrawn.
		/// The location array is an array of two int values which respectively
		/// define the left and the top position of the dirty child.
		/// This method must return the parent of this ViewParent if the specified
		/// rectangle must be invalidated in the parent. If the specified rectangle
		/// does not require invalidation in the parent or if the parent does not
		/// exist, this method must return null.
		/// When this method returns a non-null value, the location array must
		/// have been updated with the left and top coordinates of this ViewParent.
		/// </remarks>
		/// <param name="location">
		/// An array of 2 ints containing the left and top
		/// coordinates of the child to invalidate
		/// </param>
		/// <param name="r">The area within the child that is invalid</param>
		/// <returns>the parent of this ViewParent or null</returns>
		android.view.ViewParent invalidateChildInParent(int[] location, android.graphics.Rect
			 r);

		/// <summary>Returns the parent if it exists, or null.</summary>
		/// <remarks>Returns the parent if it exists, or null.</remarks>
		/// <returns>a ViewParent or null if this ViewParent does not have a parent</returns>
		android.view.ViewParent getParent();

		/// <summary>Called when a child of this parent wants focus</summary>
		/// <param name="child">
		/// The child of this ViewParent that wants focus. This view
		/// will contain the focused view. It is not necessarily the view that
		/// actually has focus.
		/// </param>
		/// <param name="focused">
		/// The view that is a descendant of child that actually has
		/// focus
		/// </param>
		void requestChildFocus(android.view.View child, android.view.View focused);

		/// <summary>
		/// Tell view hierarchy that the global view attributes need to be
		/// re-evaluated.
		/// </summary>
		/// <remarks>
		/// Tell view hierarchy that the global view attributes need to be
		/// re-evaluated.
		/// </remarks>
		/// <param name="child">View whose attributes have changed.</param>
		void recomputeViewAttributes(android.view.View child);

		/// <summary>Called when a child of this parent is giving up focus</summary>
		/// <param name="child">The view that is giving up focus</param>
		void clearChildFocus(android.view.View child);

		bool getChildVisibleRect(android.view.View child, android.graphics.Rect r, android.graphics.Point
			 offset);

		/// <summary>Find the nearest view in the specified direction that wants to take focus
		/// 	</summary>
		/// <param name="v">The view that currently has focus</param>
		/// <param name="direction">One of FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, and FOCUS_RIGHT</param>
		android.view.View focusSearch(android.view.View v, int direction);

		/// <summary>Change the z order of the child so it's on top of all other children</summary>
		/// <param name="child"></param>
		void bringChildToFront(android.view.View child);

		/// <summary>Tells the parent that a new focusable view has become available.</summary>
		/// <remarks>
		/// Tells the parent that a new focusable view has become available. This is
		/// to handle transitions from the case where there are no focusable views to
		/// the case where the first focusable view appears.
		/// </remarks>
		/// <param name="v">The view that has become newly focusable</param>
		void focusableViewAvailable(android.view.View v);

		/// <summary>Bring up a context menu for the specified view or its ancestors.</summary>
		/// <remarks>
		/// Bring up a context menu for the specified view or its ancestors.
		/// <p>
		/// In most cases, a subclass does not need to override this.  However, if
		/// the subclass is added directly to the window manager (for example,
		/// <see cref="ViewManager.addView(View, LayoutParams)">ViewManager.addView(View, LayoutParams)
		/// 	</see>
		/// )
		/// then it should override this and show the context menu.
		/// </remarks>
		/// <param name="originalView">The source view where the context menu was first invoked
		/// 	</param>
		/// <returns>true if a context menu was displayed</returns>
		bool showContextMenuForChild(android.view.View originalView);

		/// <summary>
		/// Have the parent populate the specified context menu if it has anything to
		/// add (and then recurse on its parent).
		/// </summary>
		/// <remarks>
		/// Have the parent populate the specified context menu if it has anything to
		/// add (and then recurse on its parent).
		/// </remarks>
		/// <param name="menu">The menu to populate</param>
		void createContextMenu(android.view.ContextMenu menu);

		/// <summary>Start an action mode for the specified view.</summary>
		/// <remarks>
		/// Start an action mode for the specified view.
		/// <p>
		/// In most cases, a subclass does not need to override this. However, if the
		/// subclass is added directly to the window manager (for example,
		/// <see cref="ViewManager.addView(View, LayoutParams)">ViewManager.addView(View, LayoutParams)
		/// 	</see>
		/// )
		/// then it should override this and start the action mode.
		/// </remarks>
		/// <param name="originalView">The source view where the action mode was first invoked
		/// 	</param>
		/// <param name="callback">The callback that will handle lifecycle events for the action mode
		/// 	</param>
		/// <returns>The new action mode if it was started, null otherwise</returns>
		android.view.ActionMode startActionModeForChild(android.view.View originalView, android.view.ActionMode
			.Callback callback);

		/// <summary>
		/// This method is called on the parent when a child's drawable state
		/// has changed.
		/// </summary>
		/// <remarks>
		/// This method is called on the parent when a child's drawable state
		/// has changed.
		/// </remarks>
		/// <param name="child">The child whose drawable state has changed.</param>
		void childDrawableStateChanged(android.view.View child);

		/// <summary>
		/// Called when a child does not want this parent and its ancestors to
		/// intercept touch events with
		/// <see cref="ViewGroup.onInterceptTouchEvent(MotionEvent)">ViewGroup.onInterceptTouchEvent(MotionEvent)
		/// 	</see>
		/// .
		/// <p>
		/// This parent should pass this call onto its parents. This parent must obey
		/// this request for the duration of the touch (that is, only clear the flag
		/// after this parent has received an up or a cancel.
		/// </summary>
		/// <param name="disallowIntercept">
		/// True if the child does not want the parent to
		/// intercept touch events.
		/// </param>
		void requestDisallowInterceptTouchEvent(bool disallowIntercept);

		/// <summary>
		/// Called when a child of this group wants a particular rectangle to be
		/// positioned onto the screen.
		/// </summary>
		/// <remarks>
		/// Called when a child of this group wants a particular rectangle to be
		/// positioned onto the screen.
		/// <see cref="ViewGroup">ViewGroup</see>
		/// s overriding this can trust
		/// that:
		/// <ul>
		/// <li>child will be a direct child of this group</li>
		/// <li>rectangle will be in the child's coordinates</li>
		/// </ul>
		/// <p>
		/// <see cref="ViewGroup">ViewGroup</see>
		/// s overriding this should uphold the contract:</p>
		/// <ul>
		/// <li>nothing will change if the rectangle is already visible</li>
		/// <li>the view port will be scrolled only just enough to make the
		/// rectangle visible</li>
		/// <ul>
		/// </remarks>
		/// <param name="child">The direct child making the request.</param>
		/// <param name="rectangle">
		/// The rectangle in the child's coordinates the child
		/// wishes to be on the screen.
		/// </param>
		/// <param name="immediate">
		/// True to forbid animated or delayed scrolling,
		/// false otherwise
		/// </param>
		/// <returns>Whether the group scrolled to handle the operation</returns>
		bool requestChildRectangleOnScreen(android.view.View child, android.graphics.Rect
			 rectangle, bool immediate);

		/// <summary>
		/// Called by a child to request from its parent to send an
		/// <see cref="android.view.accessibility.AccessibilityEvent">android.view.accessibility.AccessibilityEvent
		/// 	</see>
		/// .
		/// The child has already populated a record for itself in the event and is delegating
		/// to its parent to send the event. The parent can optionally add a record for itself.
		/// <p>
		/// Note: An accessibility event is fired by an individual view which populates the
		/// event with a record for its state and requests from its parent to perform
		/// the sending. The parent can optionally add a record for itself before
		/// dispatching the request to its parent. A parent can also choose not to
		/// respect the request for sending the event. The accessibility event is sent
		/// by the topmost view in the view tree.
		/// </summary>
		/// <param name="child">The child which requests sending the event.</param>
		/// <param name="event">The event to be sent.</param>
		/// <returns>True if the event was sent.</returns>
		bool requestSendAccessibilityEvent(android.view.View child, android.view.accessibility.AccessibilityEvent
			 @event);
	}
}
