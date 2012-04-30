namespace android.view
{
	partial class ViewConfiguration
	{
		/// <summary>Creates a new configuration for the specified context.</summary>
		/// <remarks>
		/// Creates a new configuration for the specified context. The configuration depends on
		/// various parameters of the context, like the dimension of the display or the density
		/// of the display.
		/// </remarks>
		/// <param name="context">The application context used to initialize this view configuration.
		/// 	</param>
		/// <seealso cref="get(android.content.Context)"></seealso>
		/// <seealso cref="android.util.DisplayMetrics">android.util.DisplayMetrics</seealso>
		private ViewConfiguration (android.content.Context context)
		{
			android.content.res.Resources res = context.getResources ();
			android.util.DisplayMetrics metrics = res.getDisplayMetrics ();
			android.content.res.Configuration config = res.getConfiguration ();
			float density = metrics.density;
			float sizeAndDensity;
			if (config.isLayoutSizeAtLeast (android.content.res.Configuration.SCREENLAYOUT_SIZE_XLARGE))
				sizeAndDensity = density * 1.5f;
			else
				sizeAndDensity = density;
			mEdgeSlop = (int)(sizeAndDensity * EDGE_SLOP + 0.5f);
			mFadingEdgeLength = (int)(sizeAndDensity * FADING_EDGE_LENGTH + 0.5f);
			mMinimumFlingVelocity = (int)(density * MINIMUM_FLING_VELOCITY + 0.5f);
			mMaximumFlingVelocity = (int)(density * MAXIMUM_FLING_VELOCITY + 0.5f);
			mScrollbarSize = (int)(density * SCROLL_BAR_SIZE + 0.5f);
			mTouchSlop = (int)(sizeAndDensity * TOUCH_SLOP + 0.5f);
			mPagingTouchSlop = (int)(sizeAndDensity * PAGING_TOUCH_SLOP + 0.5f);
			mDoubleTapSlop = (int)(sizeAndDensity * DOUBLE_TAP_SLOP + 0.5f);
			mScaledTouchExplorationTapSlop = (int)(density * TOUCH_EXPLORATION_TAP_SLOP + 0.5f
				);
			mWindowTouchSlop = (int)(sizeAndDensity * WINDOW_TOUCH_SLOP + 0.5f);
			// Size of the screen in bytes, in ARGB_8888 format
			mMaximumDrawingCacheSize = 4 * metrics.widthPixels * metrics.heightPixels;
			mOverscrollDistance = (int)(sizeAndDensity * OVERSCROLL_DISTANCE + 0.5f);
			mOverflingDistance = (int)(sizeAndDensity * OVERFLING_DISTANCE + 0.5f);
			mFadingMarqueeEnabled = false;
		}

	}
}

