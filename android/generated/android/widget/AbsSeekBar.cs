using Sharpen;

namespace android.widget
{
	[Sharpen.Sharpened]
	public abstract class AbsSeekBar : android.widget.ProgressBar
	{
		private android.graphics.drawable.Drawable mThumb;

		private int mThumbOffset;

		/// <summary>
		/// On touch, this offset plus the scaled value from the position of the
		/// touch will form the progress value.
		/// </summary>
		/// <remarks>
		/// On touch, this offset plus the scaled value from the position of the
		/// touch will form the progress value. Usually 0.
		/// </remarks>
		internal float mTouchProgressOffset;

		/// <summary>Whether this is user seekable.</summary>
		/// <remarks>Whether this is user seekable.</remarks>
		internal bool mIsUserSeekable = true;

		/// <summary>
		/// On key presses (right or left), the amount to increment/decrement the
		/// progress.
		/// </summary>
		/// <remarks>
		/// On key presses (right or left), the amount to increment/decrement the
		/// progress.
		/// </remarks>
		private int mKeyProgressIncrement = 1;

		internal const int NO_ALPHA = unchecked((int)(0xFF));

		private float mDisabledAlpha;

		private int mScaledTouchSlop;

		private float mTouchDownX;

		private bool mIsDragging;

		public AbsSeekBar(android.content.Context context) : base(context)
		{
		}

		public AbsSeekBar(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
		}

		public AbsSeekBar(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.SeekBar, defStyle, 0);
			android.graphics.drawable.Drawable thumb = a.getDrawable(android.@internal.R.styleable
				.SeekBar_thumb);
			setThumb(thumb);
			// will guess mThumbOffset if thumb != null...
			// ...but allow layout to override this
			int thumbOffset = a.getDimensionPixelOffset(android.@internal.R.styleable.SeekBar_thumbOffset
				, getThumbOffset());
			setThumbOffset(thumbOffset);
			a.recycle();
			a = context.obtainStyledAttributes(attrs, android.@internal.R.styleable.Theme, 0, 
				0);
			mDisabledAlpha = a.getFloat(android.@internal.R.styleable.Theme_disabledAlpha, 0.5f
				);
			a.recycle();
			mScaledTouchSlop = android.view.ViewConfiguration.get(context).getScaledTouchSlop
				();
		}

		/// <summary>Sets the thumb that will be drawn at the end of the progress meter within the SeekBar.
		/// 	</summary>
		/// <remarks>
		/// Sets the thumb that will be drawn at the end of the progress meter within the SeekBar.
		/// <p>
		/// If the thumb is a valid drawable (i.e. not null), half its width will be
		/// used as the new thumb offset (@see #setThumbOffset(int)).
		/// </remarks>
		/// <param name="thumb">Drawable representing the thumb</param>
		public virtual void setThumb(android.graphics.drawable.Drawable thumb)
		{
			bool needUpdate;
			// This way, calling setThumb again with the same bitmap will result in
			// it recalcuating mThumbOffset (if for example it the bounds of the
			// drawable changed)
			if (mThumb != null && thumb != mThumb)
			{
				mThumb.setCallback(null);
				needUpdate = true;
			}
			else
			{
				needUpdate = false;
			}
			if (thumb != null)
			{
				thumb.setCallback(this);
				// Assuming the thumb drawable is symmetric, set the thumb offset
				// such that the thumb will hang halfway off either edge of the
				// progress bar.
				mThumbOffset = thumb.getIntrinsicWidth() / 2;
				// If we're updating get the new states
				if (needUpdate && (thumb.getIntrinsicWidth() != mThumb.getIntrinsicWidth() || thumb
					.getIntrinsicHeight() != mThumb.getIntrinsicHeight()))
				{
					requestLayout();
				}
			}
			mThumb = thumb;
			invalidate();
			if (needUpdate)
			{
				updateThumbPos(getWidth(), getHeight());
				if (thumb.isStateful())
				{
					// Note that if the states are different this won't work.
					// For now, let's consider that an app bug.
					int[] state = getDrawableState();
					thumb.setState(state);
				}
			}
		}

		/// <seealso cref="setThumbOffset(int)">setThumbOffset(int)</seealso>
		public virtual int getThumbOffset()
		{
			return mThumbOffset;
		}

		/// <summary>
		/// Sets the thumb offset that allows the thumb to extend out of the range of
		/// the track.
		/// </summary>
		/// <remarks>
		/// Sets the thumb offset that allows the thumb to extend out of the range of
		/// the track.
		/// </remarks>
		/// <param name="thumbOffset">The offset amount in pixels.</param>
		public virtual void setThumbOffset(int thumbOffset)
		{
			mThumbOffset = thumbOffset;
			invalidate();
		}

		/// <summary>Sets the amount of progress changed via the arrow keys.</summary>
		/// <remarks>Sets the amount of progress changed via the arrow keys.</remarks>
		/// <param name="increment">
		/// The amount to increment or decrement when the user
		/// presses the arrow keys.
		/// </param>
		public virtual void setKeyProgressIncrement(int increment)
		{
			mKeyProgressIncrement = increment < 0 ? -increment : increment;
		}

		/// <summary>Returns the amount of progress changed via the arrow keys.</summary>
		/// <remarks>
		/// Returns the amount of progress changed via the arrow keys.
		/// <p>
		/// By default, this will be a value that is derived from the max progress.
		/// </remarks>
		/// <returns>
		/// The amount to increment or decrement when the user presses the
		/// arrow keys. This will be positive.
		/// </returns>
		public virtual int getKeyProgressIncrement()
		{
			return mKeyProgressIncrement;
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		public override void setMax(int max)
		{
			lock (this)
			{
				base.setMax(max);
				if ((mKeyProgressIncrement == 0) || (getMax() / mKeyProgressIncrement > 20))
				{
					// It will take the user too long to change this via keys, change it
					// to something more reasonable
					setKeyProgressIncrement(System.Math.Max(1, Sharpen.Util.Round((float)getMax() / 20
						)));
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return who == mThumb || base.verifyDrawable(who);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mThumb != null)
			{
				mThumb.jumpToCurrentState();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			android.graphics.drawable.Drawable progressDrawable = getProgressDrawable();
			if (progressDrawable != null)
			{
				progressDrawable.setAlpha(isEnabled() ? NO_ALPHA : (int)(NO_ALPHA * mDisabledAlpha
					));
			}
			if (mThumb != null && mThumb.isStateful())
			{
				int[] state = getDrawableState();
				mThumb.setState(state);
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		internal override void onProgressRefresh(float scale, bool fromUser)
		{
			base.onProgressRefresh(scale, fromUser);
			android.graphics.drawable.Drawable thumb = mThumb;
			if (thumb != null)
			{
				setThumbPos(getWidth(), thumb, scale, int.MinValue);
				invalidate();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			updateThumbPos(w, h);
		}

		private void updateThumbPos(int w, int h)
		{
			android.graphics.drawable.Drawable d = getCurrentDrawable();
			android.graphics.drawable.Drawable thumb = mThumb;
			int thumbHeight = thumb == null ? 0 : thumb.getIntrinsicHeight();
			// The max height does not incorporate padding, whereas the height
			// parameter does
			int trackHeight = System.Math.Min(mMaxHeight, h - mPaddingTop - mPaddingBottom);
			int max = getMax();
			float scale = max > 0 ? (float)getProgress() / (float)max : 0;
			if (thumbHeight > trackHeight)
			{
				if (thumb != null)
				{
					setThumbPos(w, thumb, scale, 0);
				}
				int gapForCenteringTrack = (thumbHeight - trackHeight) / 2;
				if (d != null)
				{
					// Canvas will be translated by the padding, so 0,0 is where we start drawing
					d.setBounds(0, gapForCenteringTrack, w - mPaddingRight - mPaddingLeft, h - mPaddingBottom
						 - gapForCenteringTrack - mPaddingTop);
				}
			}
			else
			{
				if (d != null)
				{
					// Canvas will be translated by the padding, so 0,0 is where we start drawing
					d.setBounds(0, 0, w - mPaddingRight - mPaddingLeft, h - mPaddingBottom - mPaddingTop
						);
				}
				int gap = (trackHeight - thumbHeight) / 2;
				if (thumb != null)
				{
					setThumbPos(w, thumb, scale, gap);
				}
			}
		}

		/// <param name="gap">
		/// If set to
		/// <see cref="int.MinValue">int.MinValue</see>
		/// , this will be ignored and
		/// </param>
		private void setThumbPos(int w, android.graphics.drawable.Drawable thumb, float scale
			, int gap)
		{
			int available = w - mPaddingLeft - mPaddingRight;
			int thumbWidth = thumb.getIntrinsicWidth();
			int thumbHeight = thumb.getIntrinsicHeight();
			available -= thumbWidth;
			// The extra space for the thumb to move on the track
			available += mThumbOffset * 2;
			int thumbPos = (int)(scale * available);
			int topBound;
			int bottomBound;
			if (gap == int.MinValue)
			{
				android.graphics.Rect oldBounds = thumb.getBounds();
				topBound = oldBounds.top;
				bottomBound = oldBounds.bottom;
			}
			else
			{
				topBound = gap;
				bottomBound = gap + thumbHeight;
			}
			// Canvas will be translated, so 0,0 is where we start drawing
			thumb.setBounds(thumbPos, topBound, thumbPos + thumbWidth, bottomBound);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			lock (this)
			{
				base.onDraw(canvas);
				if (mThumb != null)
				{
					canvas.save();
					// Translate the padding. For the x, we need to allow the thumb to
					// draw in its extra space
					canvas.translate(mPaddingLeft - mThumbOffset, mPaddingTop);
					mThumb.draw(canvas);
					canvas.restore();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			lock (this)
			{
				android.graphics.drawable.Drawable d = getCurrentDrawable();
				int thumbHeight = mThumb == null ? 0 : mThumb.getIntrinsicHeight();
				int dw = 0;
				int dh = 0;
				if (d != null)
				{
					dw = System.Math.Max(mMinWidth, System.Math.Min(mMaxWidth, d.getIntrinsicWidth())
						);
					dh = System.Math.Max(mMinHeight, System.Math.Min(mMaxHeight, d.getIntrinsicHeight
						()));
					dh = System.Math.Max(thumbHeight, dh);
				}
				dw += mPaddingLeft + mPaddingRight;
				dh += mPaddingTop + mPaddingBottom;
				setMeasuredDimension(resolveSizeAndState(dw, widthMeasureSpec, 0), resolveSizeAndState
					(dh, heightMeasureSpec, 0));
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			if (!mIsUserSeekable || !isEnabled())
			{
				return false;
			}
			switch (@event.getAction())
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					if (isInScrollingContainer())
					{
						mTouchDownX = @event.getX();
					}
					else
					{
						setPressed(true);
						if (mThumb != null)
						{
							invalidate(mThumb.getBounds());
						}
						// This may be within the padding region
						onStartTrackingTouch();
						trackTouchEvent(@event);
						attemptClaimDrag();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_MOVE:
				{
					if (mIsDragging)
					{
						trackTouchEvent(@event);
					}
					else
					{
						float x = @event.getX();
						if (System.Math.Abs(x - mTouchDownX) > mScaledTouchSlop)
						{
							setPressed(true);
							if (mThumb != null)
							{
								invalidate(mThumb.getBounds());
							}
							// This may be within the padding region
							onStartTrackingTouch();
							trackTouchEvent(@event);
							attemptClaimDrag();
						}
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				{
					if (mIsDragging)
					{
						trackTouchEvent(@event);
						onStopTrackingTouch();
						setPressed(false);
					}
					else
					{
						// Touch up when we never crossed the touch slop threshold should
						// be interpreted as a tap-seek to that location.
						onStartTrackingTouch();
						trackTouchEvent(@event);
						onStopTrackingTouch();
					}
					// ProgressBar doesn't know to repaint the thumb drawable
					// in its inactive state when the touch stops (because the
					// value has not apparently changed)
					invalidate();
					break;
				}

				case android.view.MotionEvent.ACTION_CANCEL:
				{
					if (mIsDragging)
					{
						onStopTrackingTouch();
						setPressed(false);
					}
					invalidate();
					// see above explanation
					break;
				}
			}
			return true;
		}

		private void trackTouchEvent(android.view.MotionEvent @event)
		{
			int width = getWidth();
			int available = width - mPaddingLeft - mPaddingRight;
			int x = (int)@event.getX();
			float scale;
			float progress = 0;
			if (x < mPaddingLeft)
			{
				scale = 0.0f;
			}
			else
			{
				if (x > width - mPaddingRight)
				{
					scale = 1.0f;
				}
				else
				{
					scale = (float)(x - mPaddingLeft) / (float)available;
					progress = mTouchProgressOffset;
				}
			}
			int max = getMax();
			progress += scale * max;
			setProgress((int)progress, true);
		}

		/// <summary>
		/// Tries to claim the user's drag motion, and requests disallowing any
		/// ancestors from stealing events in the drag.
		/// </summary>
		/// <remarks>
		/// Tries to claim the user's drag motion, and requests disallowing any
		/// ancestors from stealing events in the drag.
		/// </remarks>
		private void attemptClaimDrag()
		{
			if (mParent != null)
			{
				mParent.requestDisallowInterceptTouchEvent(true);
			}
		}

		/// <summary>This is called when the user has started touching this widget.</summary>
		/// <remarks>This is called when the user has started touching this widget.</remarks>
		internal virtual void onStartTrackingTouch()
		{
			mIsDragging = true;
		}

		/// <summary>
		/// This is called when the user either releases his touch or the touch is
		/// canceled.
		/// </summary>
		/// <remarks>
		/// This is called when the user either releases his touch or the touch is
		/// canceled.
		/// </remarks>
		internal virtual void onStopTrackingTouch()
		{
			mIsDragging = false;
		}

		/// <summary>Called when the user changes the seekbar's progress by using a key event.
		/// 	</summary>
		/// <remarks>Called when the user changes the seekbar's progress by using a key event.
		/// 	</remarks>
		internal virtual void onKeyChange()
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			if (isEnabled())
			{
				int progress = getProgress();
				switch (keyCode)
				{
					case android.view.KeyEvent.KEYCODE_DPAD_LEFT:
					{
						if (progress <= 0)
						{
							break;
						}
						setProgress(progress - mKeyProgressIncrement, true);
						onKeyChange();
						return true;
					}

					case android.view.KeyEvent.KEYCODE_DPAD_RIGHT:
					{
						if (progress >= getMax())
						{
							break;
						}
						setProgress(progress + mKeyProgressIncrement, true);
						onKeyChange();
						return true;
					}
				}
			}
			return base.onKeyDown(keyCode, @event);
		}
	}
}
