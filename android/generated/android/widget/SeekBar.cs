using Sharpen;

namespace android.widget
{
	/// <summary>A SeekBar is an extension of ProgressBar that adds a draggable thumb.</summary>
	/// <remarks>
	/// A SeekBar is an extension of ProgressBar that adds a draggable thumb. The user can touch
	/// the thumb and drag left or right to set the current progress level or use the arrow keys.
	/// Placing focusable widgets to the left or right of a SeekBar is discouraged.
	/// <p>
	/// Clients of the SeekBar can attach a
	/// <see cref="OnSeekBarChangeListener">OnSeekBarChangeListener</see>
	/// to
	/// be notified of the user's actions.
	/// </remarks>
	/// <attr>ref android.R.styleable#SeekBar_thumb</attr>
	[Sharpen.Sharpened]
	public class SeekBar : android.widget.AbsSeekBar
	{
		/// <summary>
		/// A callback that notifies clients when the progress level has been
		/// changed.
		/// </summary>
		/// <remarks>
		/// A callback that notifies clients when the progress level has been
		/// changed. This includes changes that were initiated by the user through a
		/// touch gesture or arrow key/trackball as well as changes that were initiated
		/// programmatically.
		/// </remarks>
		public interface OnSeekBarChangeListener
		{
			/// <summary>Notification that the progress level has changed.</summary>
			/// <remarks>
			/// Notification that the progress level has changed. Clients can use the fromUser parameter
			/// to distinguish user-initiated changes from those that occurred programmatically.
			/// </remarks>
			/// <param name="seekBar">The SeekBar whose progress has changed</param>
			/// <param name="progress">
			/// The current progress level. This will be in the range 0..max where max
			/// was set by
			/// <see cref="ProgressBar.setMax(int)">ProgressBar.setMax(int)</see>
			/// . (The default value for max is 100.)
			/// </param>
			/// <param name="fromUser">True if the progress change was initiated by the user.</param>
			void onProgressChanged(android.widget.SeekBar seekBar, int progress, bool fromUser
				);

			/// <summary>Notification that the user has started a touch gesture.</summary>
			/// <remarks>
			/// Notification that the user has started a touch gesture. Clients may want to use this
			/// to disable advancing the seekbar.
			/// </remarks>
			/// <param name="seekBar">The SeekBar in which the touch gesture began</param>
			void onStartTrackingTouch(android.widget.SeekBar seekBar);

			/// <summary>Notification that the user has finished a touch gesture.</summary>
			/// <remarks>
			/// Notification that the user has finished a touch gesture. Clients may want to use this
			/// to re-enable advancing the seekbar.
			/// </remarks>
			/// <param name="seekBar">The SeekBar in which the touch gesture began</param>
			void onStopTrackingTouch(android.widget.SeekBar seekBar);
		}

		private android.widget.SeekBar.OnSeekBarChangeListener mOnSeekBarChangeListener;

		public SeekBar(android.content.Context context) : this(context, null)
		{
		}

		public SeekBar(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, android.@internal.R.attr.seekBarStyle)
		{
		}

		public SeekBar(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : base(context, attrs, defStyle)
		{
		}

		[Sharpen.OverridesMethod(@"android.widget.ProgressBar")]
		internal override void onProgressRefresh(float scale, bool fromUser)
		{
			base.onProgressRefresh(scale, fromUser);
			if (mOnSeekBarChangeListener != null)
			{
				mOnSeekBarChangeListener.onProgressChanged(this, getProgress(), fromUser);
			}
		}

		/// <summary>Sets a listener to receive notifications of changes to the SeekBar's progress level.
		/// 	</summary>
		/// <remarks>
		/// Sets a listener to receive notifications of changes to the SeekBar's progress level. Also
		/// provides notifications of when the user starts and stops a touch gesture within the SeekBar.
		/// </remarks>
		/// <param name="l">The seek bar notification listener</param>
		/// <seealso cref="OnSeekBarChangeListener">OnSeekBarChangeListener</seealso>
		public virtual void setOnSeekBarChangeListener(android.widget.SeekBar.OnSeekBarChangeListener
			 l)
		{
			mOnSeekBarChangeListener = l;
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSeekBar")]
		internal override void onStartTrackingTouch()
		{
			base.onStartTrackingTouch();
			if (mOnSeekBarChangeListener != null)
			{
				mOnSeekBarChangeListener.onStartTrackingTouch(this);
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AbsSeekBar")]
		internal override void onStopTrackingTouch()
		{
			base.onStopTrackingTouch();
			if (mOnSeekBarChangeListener != null)
			{
				mOnSeekBarChangeListener.onStopTrackingTouch(this);
			}
		}
	}
}
