using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A RatingBar is an extension of SeekBar and ProgressBar that shows a rating in
	/// stars.
	/// </summary>
	/// <remarks>
	/// A RatingBar is an extension of SeekBar and ProgressBar that shows a rating in
	/// stars. The user can touch/drag or use arrow keys to set the rating when using
	/// the default size RatingBar. The smaller RatingBar style (
	/// <see cref="android.R.attr.ratingBarStyleSmall">android.R.attr.ratingBarStyleSmall
	/// 	</see>
	/// ) and the larger indicator-only
	/// style (
	/// <see cref="android.R.attr.ratingBarStyleIndicator">android.R.attr.ratingBarStyleIndicator
	/// 	</see>
	/// ) do not support user
	/// interaction and should only be used as indicators.
	/// <p>
	/// When using a RatingBar that supports user interaction, placing widgets to the
	/// left or right of the RatingBar is discouraged.
	/// <p>
	/// The number of stars set (via
	/// <see cref="setNumStars(int)">setNumStars(int)</see>
	/// or in an XML layout)
	/// will be shown when the layout width is set to wrap content (if another layout
	/// width is set, the results may be unpredictable).
	/// <p>
	/// The secondary progress should not be modified by the client as it is used
	/// internally as the background for a fractionally filled star.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-formstuff.html"&gt;Form Stuff
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#RatingBar_numStars</attr>
	/// <attr>ref android.R.styleable#RatingBar_rating</attr>
	/// <attr>ref android.R.styleable#RatingBar_stepSize</attr>
	/// <attr>ref android.R.styleable#RatingBar_isIndicator</attr>
	[Sharpen.Sharpened]
	public class RatingBar : android.widget.AbsSeekBar
	{
		/// <summary>A callback that notifies clients when the rating has been changed.</summary>
		/// <remarks>
		/// A callback that notifies clients when the rating has been changed. This
		/// includes changes that were initiated by the user through a touch gesture
		/// or arrow key/trackball as well as changes that were initiated
		/// programmatically.
		/// </remarks>
		public interface OnRatingBarChangeListener
		{
			/// <summary>Notification that the rating has changed.</summary>
			/// <remarks>
			/// Notification that the rating has changed. Clients can use the
			/// fromUser parameter to distinguish user-initiated changes from those
			/// that occurred programmatically. This will not be called continuously
			/// while the user is dragging, only when the user finalizes a rating by
			/// lifting the touch.
			/// </remarks>
			/// <param name="ratingBar">The RatingBar whose rating has changed.</param>
			/// <param name="rating">
			/// The current rating. This will be in the range
			/// 0..numStars.
			/// </param>
			/// <param name="fromUser">
			/// True if the rating change was initiated by a user's
			/// touch gesture or arrow key/horizontal trackbell movement.
			/// </param>
			void onRatingChanged(android.widget.RatingBar ratingBar, float rating, bool fromUser
				);
		}

		private int mNumStars = 5;

		private int mProgressOnStartTracking;

		private android.widget.RatingBar.OnRatingBarChangeListener mOnRatingBarChangeListener;

		public RatingBar(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.RatingBar, defStyle, 0);
			int numStars = a.getInt(android.@internal.R.styleable.RatingBar_numStars, mNumStars
				);
			setIsIndicator(a.getBoolean(android.@internal.R.styleable.RatingBar_isIndicator, 
				!mIsUserSeekable));
			float rating = a.getFloat(android.@internal.R.styleable.RatingBar_rating, -1);
			float stepSize = a.getFloat(android.@internal.R.styleable.RatingBar_stepSize, -1);
			a.recycle();
			if (numStars > 0 && numStars != mNumStars)
			{
				setNumStars(numStars);
			}
			if (stepSize >= 0)
			{
				setStepSize(stepSize);
			}
			else
			{
				setStepSize(0.5f);
			}
			if (rating >= 0)
			{
				setRating(rating);
			}
			// A touch inside a star fill up to that fractional area (slightly more
			// than 1 so boundaries round up).
			mTouchProgressOffset = 1.1f;
		}

		public RatingBar(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.ratingBarStyle)
		{
		}

		public RatingBar(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>Sets the listener to be called when the rating changes.</summary>
		/// <remarks>Sets the listener to be called when the rating changes.</remarks>
		/// <param name="listener">The listener.</param>
		public virtual void setOnRatingBarChangeListener(android.widget.RatingBar.OnRatingBarChangeListener
			 listener)
		{
			mOnRatingBarChangeListener = listener;
		}

		/// <returns>
		/// The listener (may be null) that is listening for rating change
		/// events.
		/// </returns>
		public virtual android.widget.RatingBar.OnRatingBarChangeListener getOnRatingBarChangeListener
			()
		{
			return mOnRatingBarChangeListener;
		}

		/// <summary>
		/// Whether this rating bar should only be an indicator (thus non-changeable
		/// by the user).
		/// </summary>
		/// <remarks>
		/// Whether this rating bar should only be an indicator (thus non-changeable
		/// by the user).
		/// </remarks>
		/// <param name="isIndicator">Whether it should be an indicator.</param>
		public virtual void setIsIndicator(bool isIndicator_1)
		{
			mIsUserSeekable = !isIndicator_1;
			setFocusable(!isIndicator_1);
		}

		/// <returns>Whether this rating bar is only an indicator.</returns>
		public virtual bool isIndicator()
		{
			return !mIsUserSeekable;
		}

		/// <summary>Sets the number of stars to show.</summary>
		/// <remarks>
		/// Sets the number of stars to show. In order for these to be shown
		/// properly, it is recommended the layout width of this widget be wrap
		/// content.
		/// </remarks>
		/// <param name="numStars">The number of stars.</param>
		public virtual void setNumStars(int numStars)
		{
			if (numStars <= 0)
			{
				return;
			}
			mNumStars = numStars;
			// This causes the width to change, so re-layout
			requestLayout();
		}

		/// <summary>Returns the number of stars shown.</summary>
		/// <remarks>Returns the number of stars shown.</remarks>
		/// <returns>The number of stars shown.</returns>
		public virtual int getNumStars()
		{
			return mNumStars;
		}

		/// <summary>Sets the rating (the number of stars filled).</summary>
		/// <remarks>Sets the rating (the number of stars filled).</remarks>
		/// <param name="rating">The rating to set.</param>
		public virtual void setRating(float rating)
		{
			setProgress(Sharpen.Util.Round(rating * getProgressPerStar()));
		}

		/// <summary>Gets the current rating (number of stars filled).</summary>
		/// <remarks>Gets the current rating (number of stars filled).</remarks>
		/// <returns>The current rating.</returns>
		public virtual float getRating()
		{
			return getProgress() / getProgressPerStar();
		}

		/// <summary>Sets the step size (granularity) of this rating bar.</summary>
		/// <remarks>Sets the step size (granularity) of this rating bar.</remarks>
		/// <param name="stepSize">
		/// The step size of this rating bar. For example, if
		/// half-star granularity is wanted, this would be 0.5.
		/// </param>
		public virtual void setStepSize(float stepSize)
		{
			if (stepSize <= 0)
			{
				return;
			}
			float newMax = mNumStars / stepSize;
			int newProgress = (int)(newMax / getMax() * getProgress());
			setMax((int)newMax);
			setProgress(newProgress);
		}

		/// <summary>Gets the step size of this rating bar.</summary>
		/// <remarks>Gets the step size of this rating bar.</remarks>
		/// <returns>The step size.</returns>
		public virtual float getStepSize()
		{
			return (float)getNumStars() / getMax();
		}

		/// <returns>The amount of progress that fits into a star</returns>
		private float getProgressPerStar()
		{
			if (mNumStars > 0)
			{
				return 1f * getMax() / mNumStars;
			}
			else
			{
				return 1;
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		internal override android.graphics.drawable.shapes.Shape getDrawableShape()
		{
			// TODO: Once ProgressBar's TODOs are fixed, this won't be needed
			return new android.graphics.drawable.shapes.RectShape();
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		internal override void onProgressRefresh(float scale, bool fromUser)
		{
			base.onProgressRefresh(scale, fromUser);
			// Keep secondary progress in sync with primary
			updateSecondaryProgress(getProgress());
			if (!fromUser)
			{
				// Callback for non-user rating changes
				dispatchRatingChange(false);
			}
		}

		/// <summary>
		/// The secondary progress is used to differentiate the background of a
		/// partially filled star.
		/// </summary>
		/// <remarks>
		/// The secondary progress is used to differentiate the background of a
		/// partially filled star. This method keeps the secondary progress in sync
		/// with the progress.
		/// </remarks>
		/// <param name="progress">The primary progress level.</param>
		private void updateSecondaryProgress(int progress)
		{
			float ratio = getProgressPerStar();
			if (ratio > 0)
			{
				float progressInStars = progress / ratio;
				int secondaryProgress = (int)(System.Math.Ceiling(progressInStars) * ratio);
				setSecondaryProgress(secondaryProgress);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			lock (this)
			{
				base.onMeasure(widthMeasureSpec, heightMeasureSpec);
				if (mSampleTile != null)
				{
					// TODO: Once ProgressBar's TODOs are gone, this can be done more
					// cleanly than mSampleTile
					int width = mSampleTile.getWidth() * mNumStars;
					setMeasuredDimension(resolveSizeAndState(width, widthMeasureSpec, 0), getMeasuredHeight
						());
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSeekBar")]
		internal override void onStartTrackingTouch()
		{
			mProgressOnStartTracking = getProgress();
			base.onStartTrackingTouch();
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSeekBar")]
		internal override void onStopTrackingTouch()
		{
			base.onStopTrackingTouch();
			if (getProgress() != mProgressOnStartTracking)
			{
				dispatchRatingChange(true);
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSeekBar")]
		internal override void onKeyChange()
		{
			base.onKeyChange();
			dispatchRatingChange(true);
		}

		internal virtual void dispatchRatingChange(bool fromUser)
		{
			if (mOnRatingBarChangeListener != null)
			{
				mOnRatingBarChangeListener.onRatingChanged(this, getRating(), fromUser);
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		public override void setMax(int max)
		{
			lock (this)
			{
				// Disallow max progress = 0
				if (max <= 0)
				{
					return;
				}
				base.setMax(max);
			}
		}
	}
}
