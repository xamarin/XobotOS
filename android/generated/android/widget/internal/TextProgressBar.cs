using Sharpen;

namespace android.widget.@internal
{
	/// <summary>
	/// Container that links together a
	/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
	/// and
	/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
	/// as children. It subscribes to
	/// <see cref="Chronometer#OnChronometerTickListener">Chronometer#OnChronometerTickListener
	/// 	</see>
	/// and updates the
	/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
	/// based on a preset finishing time.
	/// <p>
	/// This widget expects to contain two children with specific ids
	/// <see cref="android.R.id.progress">android.R.id.progress</see>
	/// and
	/// <see cref="android.R.id.text1">android.R.id.text1</see>
	/// .
	/// <p>
	/// If the
	/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
	/// 
	/// <see cref="android.R.attr.layout_width">android.R.attr.layout_width</see>
	/// is
	/// <see cref="android.view.ViewGroup.LayoutParams.WRAP_CONTENT">android.view.ViewGroup.LayoutParams.WRAP_CONTENT
	/// 	</see>
	/// , then the
	/// <see cref="android.R.attr.gravity">android.R.attr.gravity</see>
	/// will be used to automatically move it with
	/// respect to the
	/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
	/// position. For example, if
	/// <see cref="android.view.Gravity.LEFT">android.view.Gravity.LEFT</see>
	/// then the
	/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
	/// will be placed
	/// just ahead of the leading edge of the
	/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
	/// position.
	/// </summary>
	[Sharpen.Sharpened]
	public class TextProgressBar : android.widget.RelativeLayout, android.widget.Chronometer
		.OnChronometerTickListener
	{
		public const string TAG = "TextProgressBar";

		internal const int CHRONOMETER_ID = android.R.id.text1;

		internal const int PROGRESSBAR_ID = android.R.id.progress;

		internal android.widget.Chronometer mChronometer = null;

		internal android.widget.ProgressBar mProgressBar = null;

		internal long mDurationBase = -1;

		internal int mDuration = -1;

		internal bool mChronometerFollow = false;

		internal int mChronometerGravity = android.view.Gravity.NO_GRAVITY;

		public TextProgressBar(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		public TextProgressBar(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
		}

		public TextProgressBar(android.content.Context context) : base(context)
		{
		}

		/// <summary>Catch any interesting children when they are added.</summary>
		/// <remarks>Catch any interesting children when they are added.</remarks>
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			base.addView(child, index, @params);
			int childId = child.getId();
			if (childId == CHRONOMETER_ID && child is android.widget.Chronometer)
			{
				mChronometer = (android.widget.Chronometer)child;
				mChronometer.setOnChronometerTickListener(this);
				// Check if Chronometer should move with with ProgressBar 
				mChronometerFollow = (@params.width == android.view.ViewGroup.LayoutParams.WRAP_CONTENT
					);
				mChronometerGravity = (mChronometer.getGravity() & android.view.Gravity.RELATIVE_HORIZONTAL_GRAVITY_MASK
					);
			}
			else
			{
				if (childId == PROGRESSBAR_ID && child is android.widget.ProgressBar)
				{
					mProgressBar = (android.widget.ProgressBar)child;
				}
			}
		}

		/// <summary>
		/// Set the expected termination time of the running
		/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
		/// .
		/// This value is used to adjust the
		/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
		/// against the elapsed
		/// time.
		/// <p>
		/// Call this <b>after</b> adjusting the
		/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
		/// base, if
		/// necessary.
		/// </summary>
		/// <param name="durationBase">
		/// Use the
		/// <see cref="android.os.SystemClock.elapsedRealtime()">android.os.SystemClock.elapsedRealtime()
		/// 	</see>
		/// time
		/// base.
		/// </param>
		[android.view.RemotableViewMethod]
		public virtual void setDurationBase(long durationBase)
		{
			mDurationBase = durationBase;
			if (mProgressBar == null || mChronometer == null)
			{
				throw new java.lang.RuntimeException("Expecting child ProgressBar with id " + "'android.R.id.progress' and Chronometer id 'android.R.id.text1'"
					);
			}
			// Update the ProgressBar maximum relative to Chronometer base
			mDuration = (int)(durationBase - mChronometer.getBase());
			if (mDuration <= 0)
			{
				mDuration = 1;
			}
			mProgressBar.setMax(mDuration);
		}

		/// <summary>
		/// Callback when
		/// <see cref="android.widget.Chronometer">android.widget.Chronometer</see>
		/// changes, indicating that we should
		/// update the
		/// <see cref="android.widget.ProgressBar">android.widget.ProgressBar</see>
		/// and change the layout if necessary.
		/// </summary>
		[Sharpen.ImplementsInterface(@"android.widget.Chronometer.OnChronometerTickListener"
			)]
		public virtual void onChronometerTick(android.widget.Chronometer chronometer)
		{
			if (mProgressBar == null)
			{
				throw new java.lang.RuntimeException("Expecting child ProgressBar with id 'android.R.id.progress'"
					);
			}
			// Stop Chronometer if we're past duration
			long now = android.os.SystemClock.elapsedRealtime();
			if (now >= mDurationBase)
			{
				mChronometer.stop();
			}
			// Update the ProgressBar status
			int remaining = (int)(mDurationBase - now);
			mProgressBar.setProgress(mDuration - remaining);
			// Move the Chronometer if gravity is set correctly
			if (mChronometerFollow)
			{
				android.widget.RelativeLayout.LayoutParams @params;
				// Calculate estimate of ProgressBar leading edge position
				@params = (android.widget.RelativeLayout.LayoutParams)mProgressBar.getLayoutParams
					();
				int contentWidth = mProgressBar.getWidth() - (@params.leftMargin + @params.rightMargin
					);
				int leadingEdge = ((contentWidth * mProgressBar.getProgress()) / mProgressBar.getMax
					()) + @params.leftMargin;
				// Calculate any adjustment based on gravity
				int adjustLeft = 0;
				int textWidth = mChronometer.getWidth();
				if (mChronometerGravity == android.view.Gravity.RIGHT)
				{
					adjustLeft = -textWidth;
				}
				else
				{
					if (mChronometerGravity == android.view.Gravity.CENTER_HORIZONTAL)
					{
						adjustLeft = -(textWidth / 2);
					}
				}
				// Limit margin to keep text inside ProgressBar bounds
				leadingEdge += adjustLeft;
				int rightLimit = contentWidth - @params.rightMargin - textWidth;
				if (leadingEdge < @params.leftMargin)
				{
					leadingEdge = @params.leftMargin;
				}
				else
				{
					if (leadingEdge > rightLimit)
					{
						leadingEdge = rightLimit;
					}
				}
				@params = (android.widget.RelativeLayout.LayoutParams)mChronometer.getLayoutParams
					();
				@params.leftMargin = leadingEdge;
				// Request layout to move Chronometer
				mChronometer.requestLayout();
			}
		}
	}
}
