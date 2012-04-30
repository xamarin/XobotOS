using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// Abstraction for an Animation that can be applied to Views, Surfaces, or
	/// other objects.
	/// </summary>
	/// <remarks>
	/// Abstraction for an Animation that can be applied to Views, Surfaces, or
	/// other objects. See the
	/// <see cref="android.view.animation">
	/// animation package
	/// description file
	/// </see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Animation : System.ICloneable
	{
		/// <summary>Repeat the animation indefinitely.</summary>
		/// <remarks>Repeat the animation indefinitely.</remarks>
		public const int INFINITE = -1;

		/// <summary>
		/// When the animation reaches the end and the repeat count is INFINTE_REPEAT
		/// or a positive value, the animation restarts from the beginning.
		/// </summary>
		/// <remarks>
		/// When the animation reaches the end and the repeat count is INFINTE_REPEAT
		/// or a positive value, the animation restarts from the beginning.
		/// </remarks>
		public const int RESTART = 1;

		/// <summary>
		/// When the animation reaches the end and the repeat count is INFINTE_REPEAT
		/// or a positive value, the animation plays backward (and then forward again).
		/// </summary>
		/// <remarks>
		/// When the animation reaches the end and the repeat count is INFINTE_REPEAT
		/// or a positive value, the animation plays backward (and then forward again).
		/// </remarks>
		public const int REVERSE = 2;

		/// <summary>
		/// Can be used as the start time to indicate the start time should be the current
		/// time when
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// is invoked for the
		/// first animation frame. This can is useful for short animations.
		/// </summary>
		public const int START_ON_FIRST_FRAME = -1;

		/// <summary>The specified dimension is an absolute number of pixels.</summary>
		/// <remarks>The specified dimension is an absolute number of pixels.</remarks>
		public const int ABSOLUTE = 0;

		/// <summary>
		/// The specified dimension holds a float and should be multiplied by the
		/// height or width of the object being animated.
		/// </summary>
		/// <remarks>
		/// The specified dimension holds a float and should be multiplied by the
		/// height or width of the object being animated.
		/// </remarks>
		public const int RELATIVE_TO_SELF = 1;

		/// <summary>
		/// The specified dimension holds a float and should be multiplied by the
		/// height or width of the parent of the object being animated.
		/// </summary>
		/// <remarks>
		/// The specified dimension holds a float and should be multiplied by the
		/// height or width of the parent of the object being animated.
		/// </remarks>
		public const int RELATIVE_TO_PARENT = 2;

		/// <summary>
		/// Requests that the content being animated be kept in its current Z
		/// order.
		/// </summary>
		/// <remarks>
		/// Requests that the content being animated be kept in its current Z
		/// order.
		/// </remarks>
		public const int ZORDER_NORMAL = 0;

		/// <summary>
		/// Requests that the content being animated be forced on top of all other
		/// content for the duration of the animation.
		/// </summary>
		/// <remarks>
		/// Requests that the content being animated be forced on top of all other
		/// content for the duration of the animation.
		/// </remarks>
		public const int ZORDER_TOP = 1;

		/// <summary>
		/// Requests that the content being animated be forced under all other
		/// content for the duration of the animation.
		/// </summary>
		/// <remarks>
		/// Requests that the content being animated be forced under all other
		/// content for the duration of the animation.
		/// </remarks>
		public const int ZORDER_BOTTOM = -1;

		private static readonly bool USE_CLOSEGUARD = android.os.SystemProperties.getBoolean
			("log.closeguard.Animation", false);

		/// <summary>
		/// Set by
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// when the animation ends.
		/// </summary>
		internal bool mEnded = false;

		/// <summary>
		/// Set by
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// when the animation starts.
		/// </summary>
		internal bool mStarted = false;

		/// <summary>
		/// Set by
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// when the animation repeats
		/// in REVERSE mode.
		/// </summary>
		internal bool mCycleFlip = false;

		/// <summary>
		/// This value must be set to true by
		/// <see cref="initialize(int, int, int, int)">initialize(int, int, int, int)</see>
		/// . It
		/// indicates the animation was successfully initialized and can be played.
		/// </summary>
		internal bool mInitialized = false;

		/// <summary>
		/// Indicates whether the animation transformation should be applied before the
		/// animation starts.
		/// </summary>
		/// <remarks>
		/// Indicates whether the animation transformation should be applied before the
		/// animation starts. The value of this variable is only relevant if mFillEnabled is true;
		/// otherwise it is assumed to be true.
		/// </remarks>
		internal bool mFillBefore = true;

		/// <summary>
		/// Indicates whether the animation transformation should be applied after the
		/// animation ends.
		/// </summary>
		/// <remarks>
		/// Indicates whether the animation transformation should be applied after the
		/// animation ends.
		/// </remarks>
		internal bool mFillAfter = false;

		/// <summary>Indicates whether fillBefore should be taken into account.</summary>
		/// <remarks>Indicates whether fillBefore should be taken into account.</remarks>
		internal bool mFillEnabled = false;

		/// <summary>The time in milliseconds at which the animation must start;</summary>
		internal long mStartTime = -1;

		/// <summary>The delay in milliseconds after which the animation must start.</summary>
		/// <remarks>
		/// The delay in milliseconds after which the animation must start. When the
		/// start offset is &gt; 0, the start time of the animation is startTime + startOffset.
		/// </remarks>
		internal long mStartOffset;

		/// <summary>The duration of one animation cycle in milliseconds.</summary>
		/// <remarks>The duration of one animation cycle in milliseconds.</remarks>
		internal long mDuration;

		/// <summary>The number of times the animation must repeat.</summary>
		/// <remarks>
		/// The number of times the animation must repeat. By default, an animation repeats
		/// indefinitely.
		/// </remarks>
		internal int mRepeatCount = 0;

		/// <summary>Indicates how many times the animation was repeated.</summary>
		/// <remarks>Indicates how many times the animation was repeated.</remarks>
		internal int mRepeated = 0;

		/// <summary>The behavior of the animation when it repeats.</summary>
		/// <remarks>
		/// The behavior of the animation when it repeats. The repeat mode is either
		/// <see cref="RESTART">RESTART</see>
		/// or
		/// <see cref="REVERSE">REVERSE</see>
		/// .
		/// </remarks>
		internal int mRepeatMode = RESTART;

		/// <summary>The interpolator used by the animation to smooth the movement.</summary>
		/// <remarks>The interpolator used by the animation to smooth the movement.</remarks>
		internal android.view.animation.Interpolator mInterpolator;

		/// <summary>The animation listener to be notified when the animation starts, ends or repeats.
		/// 	</summary>
		/// <remarks>The animation listener to be notified when the animation starts, ends or repeats.
		/// 	</remarks>
		internal android.view.animation.Animation.AnimationListener mListener;

		/// <summary>Desired Z order mode during animation.</summary>
		/// <remarks>Desired Z order mode during animation.</remarks>
		private int mZAdjustment;

		/// <summary>Desired background color behind animation.</summary>
		/// <remarks>Desired background color behind animation.</remarks>
		private int mBackgroundColor;

		/// <summary>scalefactor to apply to pivot points, etc.</summary>
		/// <remarks>
		/// scalefactor to apply to pivot points, etc. during animation. Subclasses retrieve the
		/// value via getScaleFactor().
		/// </remarks>
		private float mScaleFactor = 1f;

		/// <summary>Don't animate the wallpaper.</summary>
		/// <remarks>Don't animate the wallpaper.</remarks>
		private bool mDetachWallpaper = false;

		private bool mMore = true;

		private bool mOneMoreTime = true;

		internal android.graphics.RectF mPreviousRegion = new android.graphics.RectF();

		internal android.graphics.RectF mRegion = new android.graphics.RectF();

		internal android.view.animation.Transformation mTransformation = new android.view.animation.Transformation
			();

		internal android.view.animation.Transformation mPreviousTransformation = new android.view.animation.Transformation
			();

		private readonly dalvik.system.CloseGuard guard = dalvik.system.CloseGuard.get();

		/// <summary>
		/// Creates a new animation with a duration of 0ms, the default interpolator, with
		/// fillBefore set to true and fillAfter set to false
		/// </summary>
		public Animation()
		{
			ensureInterpolator();
		}

		/// <summary>
		/// Creates a new animation whose parameters come from the specified context and
		/// attributes set.
		/// </summary>
		/// <remarks>
		/// Creates a new animation whose parameters come from the specified context and
		/// attributes set.
		/// </remarks>
		/// <param name="context">the application environment</param>
		/// <param name="attrs">the set of attributes holding the animation parameters</param>
		public Animation(android.content.Context context, android.util.AttributeSet attrs
			)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Animation);
			setDuration((long)a.getInt(android.@internal.R.styleable.Animation_duration, 0));
			setStartOffset((long)a.getInt(android.@internal.R.styleable.Animation_startOffset
				, 0));
			setFillEnabled(a.getBoolean(android.@internal.R.styleable.Animation_fillEnabled, 
				mFillEnabled));
			setFillBefore(a.getBoolean(android.@internal.R.styleable.Animation_fillBefore, mFillBefore
				));
			setFillAfter(a.getBoolean(android.@internal.R.styleable.Animation_fillAfter, mFillAfter
				));
			setRepeatCount(a.getInt(android.@internal.R.styleable.Animation_repeatCount, mRepeatCount
				));
			setRepeatMode(a.getInt(android.@internal.R.styleable.Animation_repeatMode, RESTART
				));
			setZAdjustment(a.getInt(android.@internal.R.styleable.Animation_zAdjustment, ZORDER_NORMAL
				));
			setBackgroundColor(a.getInt(android.@internal.R.styleable.Animation_background, 0
				));
			setDetachWallpaper(a.getBoolean(android.@internal.R.styleable.Animation_detachWallpaper
				, false));
			int resID = a.getResourceId(android.@internal.R.styleable.Animation_interpolator, 
				0);
			a.recycle();
			if (resID > 0)
			{
				setInterpolator(context, resID);
			}
			ensureInterpolator();
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		protected internal virtual android.view.animation.Animation clone()
		{
			android.view.animation.Animation animation = (android.view.animation.Animation)base
				.MemberwiseClone();
			animation.mPreviousRegion = new android.graphics.RectF();
			animation.mRegion = new android.graphics.RectF();
			animation.mTransformation = new android.view.animation.Transformation();
			animation.mPreviousTransformation = new android.view.animation.Transformation();
			return animation;
		}

		/// <summary>Reset the initialization state of this animation.</summary>
		/// <remarks>Reset the initialization state of this animation.</remarks>
		/// <seealso cref="initialize(int, int, int, int)">initialize(int, int, int, int)</seealso>
		public virtual void reset()
		{
			mPreviousRegion.setEmpty();
			mPreviousTransformation.clear();
			mInitialized = false;
			mCycleFlip = false;
			mRepeated = 0;
			mMore = true;
			mOneMoreTime = true;
		}

		/// <summary>Cancel the animation.</summary>
		/// <remarks>
		/// Cancel the animation. Cancelling an animation invokes the animation
		/// listener, if set, to notify the end of the animation.
		/// If you cancel an animation manually, you must call
		/// <see cref="reset()">reset()</see>
		/// before starting the animation again.
		/// </remarks>
		/// <seealso cref="reset()"></seealso>
		/// <seealso cref="start()"></seealso>
		/// <seealso cref="startNow()"></seealso>
		public virtual void cancel()
		{
			if (mStarted && !mEnded)
			{
				if (mListener != null)
				{
					mListener.onAnimationEnd(this);
				}
				mEnded = true;
				guard.close();
			}
			// Make sure we move the animation to the end
			mStartTime = long.MinValue;
			mMore = mOneMoreTime = false;
		}

		/// <hide></hide>
		public virtual void detach()
		{
			if (mStarted && !mEnded)
			{
				mEnded = true;
				guard.close();
				if (mListener != null)
				{
					mListener.onAnimationEnd(this);
				}
			}
		}

		/// <summary>Whether or not the animation has been initialized.</summary>
		/// <remarks>Whether or not the animation has been initialized.</remarks>
		/// <returns>Has this animation been initialized.</returns>
		/// <seealso cref="initialize(int, int, int, int)">initialize(int, int, int, int)</seealso>
		public virtual bool isInitialized()
		{
			return mInitialized;
		}

		/// <summary>
		/// Initialize this animation with the dimensions of the object being
		/// animated as well as the objects parents.
		/// </summary>
		/// <remarks>
		/// Initialize this animation with the dimensions of the object being
		/// animated as well as the objects parents. (This is to support animation
		/// sizes being specifed relative to these dimensions.)
		/// <p>Objects that interpret Animations should call this method when
		/// the sizes of the object being animated and its parent are known, and
		/// before calling
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="width">Width of the object being animated</param>
		/// <param name="height">Height of the object being animated</param>
		/// <param name="parentWidth">Width of the animated object's parent</param>
		/// <param name="parentHeight">Height of the animated object's parent</param>
		public virtual void initialize(int width, int height, int parentWidth, int parentHeight
			)
		{
			reset();
			mInitialized = true;
		}

		/// <summary>Sets the acceleration curve for this animation.</summary>
		/// <remarks>
		/// Sets the acceleration curve for this animation. The interpolator is loaded as
		/// a resource from the specified context.
		/// </remarks>
		/// <param name="context">The application environment</param>
		/// <param name="resID">The resource identifier of the interpolator to load</param>
		/// <attr>ref android.R.styleable#Animation_interpolator</attr>
		public virtual void setInterpolator(android.content.Context context, int resID)
		{
			setInterpolator(android.view.animation.AnimationUtils.loadInterpolator(context, resID
				));
		}

		/// <summary>Sets the acceleration curve for this animation.</summary>
		/// <remarks>
		/// Sets the acceleration curve for this animation. Defaults to a linear
		/// interpolation.
		/// </remarks>
		/// <param name="i">The interpolator which defines the acceleration curve</param>
		/// <attr>ref android.R.styleable#Animation_interpolator</attr>
		public virtual void setInterpolator(android.view.animation.Interpolator i)
		{
			mInterpolator = i;
		}

		/// <summary>When this animation should start relative to the start time.</summary>
		/// <remarks>
		/// When this animation should start relative to the start time. This is most
		/// useful when composing complex animations using an
		/// <see cref="AnimationSet"></see>
		/// where some of the animations components start at different times.
		/// </remarks>
		/// <param name="startOffset">
		/// When this Animation should start, in milliseconds from
		/// the start time of the root AnimationSet.
		/// </param>
		/// <attr>ref android.R.styleable#Animation_startOffset</attr>
		public virtual void setStartOffset(long startOffset)
		{
			mStartOffset = startOffset;
		}

		/// <summary>How long this animation should last.</summary>
		/// <remarks>How long this animation should last. The duration cannot be negative.</remarks>
		/// <param name="durationMillis">Duration in milliseconds</param>
		/// <exception cref="System.ArgumentException">if the duration is &lt; 0</exception>
		/// <attr>ref android.R.styleable#Animation_duration</attr>
		public virtual void setDuration(long durationMillis)
		{
			if (durationMillis < 0)
			{
				throw new System.ArgumentException("Animation duration cannot be negative");
			}
			mDuration = durationMillis;
		}

		/// <summary>
		/// Ensure that the duration that this animation will run is not longer
		/// than <var>durationMillis</var>.
		/// </summary>
		/// <remarks>
		/// Ensure that the duration that this animation will run is not longer
		/// than <var>durationMillis</var>.  In addition to adjusting the duration
		/// itself, this ensures that the repeat count also will not make it run
		/// longer than the given time.
		/// </remarks>
		/// <param name="durationMillis">
		/// The maximum duration the animation is allowed
		/// to run.
		/// </param>
		public virtual void restrictDuration(long durationMillis)
		{
			// If we start after the duration, then we just won't run.
			if (mStartOffset > durationMillis)
			{
				mStartOffset = durationMillis;
				mDuration = 0;
				mRepeatCount = 0;
				return;
			}
			long dur = mDuration + mStartOffset;
			if (dur > durationMillis)
			{
				mDuration = durationMillis - mStartOffset;
				dur = durationMillis;
			}
			// If the duration is 0 or less, then we won't run.
			if (mDuration <= 0)
			{
				mDuration = 0;
				mRepeatCount = 0;
				return;
			}
			// Reduce the number of repeats to keep below the maximum duration.
			// The comparison between mRepeatCount and duration is to catch
			// overflows after multiplying them.
			if (mRepeatCount < 0 || mRepeatCount > durationMillis || (dur * mRepeatCount) > durationMillis)
			{
				// Figure out how many times to do the animation.  Subtract 1 since
				// repeat count is the number of times to repeat so 0 runs once.
				mRepeatCount = (int)(durationMillis / dur) - 1;
				if (mRepeatCount < 0)
				{
					mRepeatCount = 0;
				}
			}
		}

		/// <summary>How much to scale the duration by.</summary>
		/// <remarks>How much to scale the duration by.</remarks>
		/// <param name="scale">The amount to scale the duration.</param>
		public virtual void scaleCurrentDuration(float scale)
		{
			mDuration = (long)(mDuration * scale);
			mStartOffset = (long)(mStartOffset * scale);
		}

		/// <summary>When this animation should start.</summary>
		/// <remarks>
		/// When this animation should start. When the start time is set to
		/// <see cref="START_ON_FIRST_FRAME">START_ON_FIRST_FRAME</see>
		/// , the animation will start the first time
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// is invoked. The time passed
		/// to this method should be obtained by calling
		/// <see cref="AnimationUtils.currentAnimationTimeMillis()">AnimationUtils.currentAnimationTimeMillis()
		/// 	</see>
		/// instead of
		/// <see cref="Sharpen.Util.CurrentTimeMillis()">Sharpen.Util.CurrentTimeMillis()</see>
		/// .
		/// </remarks>
		/// <param name="startTimeMillis">the start time in milliseconds</param>
		public virtual void setStartTime(long startTimeMillis)
		{
			mStartTime = startTimeMillis;
			mStarted = mEnded = false;
			mCycleFlip = false;
			mRepeated = 0;
			mMore = true;
		}

		/// <summary>
		/// Convenience method to start the animation the first time
		/// <see cref="getTransformation(long, Transformation)">getTransformation(long, Transformation)
		/// 	</see>
		/// is invoked.
		/// </summary>
		public virtual void start()
		{
			setStartTime(-1);
		}

		/// <summary>
		/// Convenience method to start the animation at the current time in
		/// milliseconds.
		/// </summary>
		/// <remarks>
		/// Convenience method to start the animation at the current time in
		/// milliseconds.
		/// </remarks>
		public virtual void startNow()
		{
			setStartTime(android.view.animation.AnimationUtils.currentAnimationTimeMillis());
		}

		/// <summary>Defines what this animation should do when it reaches the end.</summary>
		/// <remarks>
		/// Defines what this animation should do when it reaches the end. This
		/// setting is applied only when the repeat count is either greater than
		/// 0 or
		/// <see cref="INFINITE">INFINITE</see>
		/// . Defaults to
		/// <see cref="RESTART">RESTART</see>
		/// .
		/// </remarks>
		/// <param name="repeatMode">
		/// 
		/// <see cref="RESTART">RESTART</see>
		/// or
		/// <see cref="REVERSE">REVERSE</see>
		/// </param>
		/// <attr>ref android.R.styleable#Animation_repeatMode</attr>
		public virtual void setRepeatMode(int repeatMode)
		{
			mRepeatMode = repeatMode;
		}

		/// <summary>Sets how many times the animation should be repeated.</summary>
		/// <remarks>
		/// Sets how many times the animation should be repeated. If the repeat
		/// count is 0, the animation is never repeated. If the repeat count is
		/// greater than 0 or
		/// <see cref="INFINITE">INFINITE</see>
		/// , the repeat mode will be taken
		/// into account. The repeat count is 0 by default.
		/// </remarks>
		/// <param name="repeatCount">the number of times the animation should be repeated</param>
		/// <attr>ref android.R.styleable#Animation_repeatCount</attr>
		public virtual void setRepeatCount(int repeatCount)
		{
			if (repeatCount < 0)
			{
				repeatCount = INFINITE;
			}
			mRepeatCount = repeatCount;
		}

		/// <summary>If fillEnabled is true, this animation will apply the value of fillBefore.
		/// 	</summary>
		/// <remarks>If fillEnabled is true, this animation will apply the value of fillBefore.
		/// 	</remarks>
		/// <returns>true if the animation will take fillBefore into account</returns>
		/// <attr>ref android.R.styleable#Animation_fillEnabled</attr>
		public virtual bool isFillEnabled()
		{
			return mFillEnabled;
		}

		/// <summary>If fillEnabled is true, the animation will apply the value of fillBefore.
		/// 	</summary>
		/// <remarks>
		/// If fillEnabled is true, the animation will apply the value of fillBefore.
		/// Otherwise, fillBefore is ignored and the animation
		/// transformation is always applied until the animation ends.
		/// </remarks>
		/// <param name="fillEnabled">true if the animation should take the value of fillBefore into account
		/// 	</param>
		/// <attr>ref android.R.styleable#Animation_fillEnabled</attr>
		/// <seealso cref="setFillBefore(bool)">setFillBefore(bool)</seealso>
		/// <seealso cref="setFillAfter(bool)">setFillAfter(bool)</seealso>
		public virtual void setFillEnabled(bool fillEnabled)
		{
			mFillEnabled = fillEnabled;
		}

		/// <summary>
		/// If fillBefore is true, this animation will apply its transformation
		/// before the start time of the animation.
		/// </summary>
		/// <remarks>
		/// If fillBefore is true, this animation will apply its transformation
		/// before the start time of the animation. Defaults to true if
		/// <see cref="setFillEnabled(bool)">setFillEnabled(bool)</see>
		/// is not set to true.
		/// Note that this applies when using an
		/// <see cref="AnimationSet">AnimationSet</see>
		/// to chain
		/// animations. The transformation is not applied before the AnimationSet
		/// itself starts.
		/// </remarks>
		/// <param name="fillBefore">true if the animation should apply its transformation before it starts
		/// 	</param>
		/// <attr>ref android.R.styleable#Animation_fillBefore</attr>
		/// <seealso cref="setFillEnabled(bool)">setFillEnabled(bool)</seealso>
		public virtual void setFillBefore(bool fillBefore)
		{
			mFillBefore = fillBefore;
		}

		/// <summary>
		/// If fillAfter is true, the transformation that this animation performed
		/// will persist when it is finished.
		/// </summary>
		/// <remarks>
		/// If fillAfter is true, the transformation that this animation performed
		/// will persist when it is finished. Defaults to false if not set.
		/// Note that this applies to individual animations and when using an
		/// <see cref="AnimationSet">AnimationSet</see>
		/// to chain
		/// animations.
		/// </remarks>
		/// <param name="fillAfter">true if the animation should apply its transformation after it ends
		/// 	</param>
		/// <attr>ref android.R.styleable#Animation_fillAfter</attr>
		/// <seealso cref="setFillEnabled(bool)"></seealso>
		public virtual void setFillAfter(bool fillAfter)
		{
			mFillAfter = fillAfter;
		}

		/// <summary>Set the Z ordering mode to use while running the animation.</summary>
		/// <remarks>Set the Z ordering mode to use while running the animation.</remarks>
		/// <param name="zAdjustment">
		/// The desired mode, one of
		/// <see cref="ZORDER_NORMAL">ZORDER_NORMAL</see>
		/// ,
		/// <see cref="ZORDER_TOP">ZORDER_TOP</see>
		/// , or
		/// <see cref="ZORDER_BOTTOM">ZORDER_BOTTOM</see>
		/// .
		/// </param>
		/// <attr>ref android.R.styleable#Animation_zAdjustment</attr>
		public virtual void setZAdjustment(int zAdjustment)
		{
			mZAdjustment = zAdjustment;
		}

		/// <summary>Set background behind animation.</summary>
		/// <remarks>Set background behind animation.</remarks>
		/// <param name="bg">
		/// The background color.  If 0, no background.  Currently must
		/// be black, with any desired alpha level.
		/// </param>
		public virtual void setBackgroundColor(int bg)
		{
			mBackgroundColor = bg;
		}

		/// <summary>The scale factor is set by the call to <code>getTransformation</code>.</summary>
		/// <remarks>
		/// The scale factor is set by the call to <code>getTransformation</code>. Overrides of
		/// <see cref="getTransformation(long, Transformation, float)">getTransformation(long, Transformation, float)
		/// 	</see>
		/// will get this value
		/// directly. Overrides of
		/// <see cref="applyTransformation(float, Transformation)">applyTransformation(float, Transformation)
		/// 	</see>
		/// can
		/// call this method to get the value.
		/// </remarks>
		/// <returns>
		/// float The scale factor that should be applied to pre-scaled values in
		/// an Animation such as the pivot points in
		/// <see cref="ScaleAnimation">ScaleAnimation</see>
		/// and
		/// <see cref="RotateAnimation">RotateAnimation</see>
		/// .
		/// </returns>
		protected internal virtual float getScaleFactor()
		{
			return mScaleFactor;
		}

		/// <summary>
		/// If detachWallpaper is true, and this is a window animation of a window
		/// that has a wallpaper background, then the window will be detached from
		/// the wallpaper while it runs.
		/// </summary>
		/// <remarks>
		/// If detachWallpaper is true, and this is a window animation of a window
		/// that has a wallpaper background, then the window will be detached from
		/// the wallpaper while it runs.  That is, the animation will only be applied
		/// to the window, and the wallpaper behind it will remain static.
		/// </remarks>
		/// <param name="detachWallpaper">true if the wallpaper should be detached from the animation
		/// 	</param>
		/// <attr>ref android.R.styleable#Animation_detachWallpaper</attr>
		public virtual void setDetachWallpaper(bool detachWallpaper)
		{
			mDetachWallpaper = detachWallpaper;
		}

		/// <summary>Gets the acceleration curve type for this animation.</summary>
		/// <remarks>Gets the acceleration curve type for this animation.</remarks>
		/// <returns>
		/// the
		/// <see cref="Interpolator">Interpolator</see>
		/// associated to this animation
		/// </returns>
		/// <attr>ref android.R.styleable#Animation_interpolator</attr>
		public virtual android.view.animation.Interpolator getInterpolator()
		{
			return mInterpolator;
		}

		/// <summary>When this animation should start.</summary>
		/// <remarks>
		/// When this animation should start. If the animation has not startet yet,
		/// this method might return
		/// <see cref="START_ON_FIRST_FRAME">START_ON_FIRST_FRAME</see>
		/// .
		/// </remarks>
		/// <returns>
		/// the time in milliseconds when the animation should start or
		/// <see cref="START_ON_FIRST_FRAME">START_ON_FIRST_FRAME</see>
		/// </returns>
		public virtual long getStartTime()
		{
			return mStartTime;
		}

		/// <summary>How long this animation should last</summary>
		/// <returns>the duration in milliseconds of the animation</returns>
		/// <attr>ref android.R.styleable#Animation_duration</attr>
		public virtual long getDuration()
		{
			return mDuration;
		}

		/// <summary>When this animation should start, relative to StartTime</summary>
		/// <returns>the start offset in milliseconds</returns>
		/// <attr>ref android.R.styleable#Animation_startOffset</attr>
		public virtual long getStartOffset()
		{
			return mStartOffset;
		}

		/// <summary>Defines what this animation should do when it reaches the end.</summary>
		/// <remarks>Defines what this animation should do when it reaches the end.</remarks>
		/// <returns>
		/// either one of
		/// <see cref="REVERSE">REVERSE</see>
		/// or
		/// <see cref="RESTART">RESTART</see>
		/// </returns>
		/// <attr>ref android.R.styleable#Animation_repeatMode</attr>
		public virtual int getRepeatMode()
		{
			return mRepeatMode;
		}

		/// <summary>Defines how many times the animation should repeat.</summary>
		/// <remarks>
		/// Defines how many times the animation should repeat. The default value
		/// is 0.
		/// </remarks>
		/// <returns>
		/// the number of times the animation should repeat, or
		/// <see cref="INFINITE">INFINITE</see>
		/// </returns>
		/// <attr>ref android.R.styleable#Animation_repeatCount</attr>
		public virtual int getRepeatCount()
		{
			return mRepeatCount;
		}

		/// <summary>
		/// If fillBefore is true, this animation will apply its transformation
		/// before the start time of the animation.
		/// </summary>
		/// <remarks>
		/// If fillBefore is true, this animation will apply its transformation
		/// before the start time of the animation. If fillBefore is false and
		/// <see cref="isFillEnabled()">fillEnabled</see>
		/// is true, the transformation will not be applied until
		/// the start time of the animation.
		/// </remarks>
		/// <returns>true if the animation applies its transformation before it starts</returns>
		/// <attr>ref android.R.styleable#Animation_fillBefore</attr>
		public virtual bool getFillBefore()
		{
			return mFillBefore;
		}

		/// <summary>
		/// If fillAfter is true, this animation will apply its transformation
		/// after the end time of the animation.
		/// </summary>
		/// <remarks>
		/// If fillAfter is true, this animation will apply its transformation
		/// after the end time of the animation.
		/// </remarks>
		/// <returns>true if the animation applies its transformation after it ends</returns>
		/// <attr>ref android.R.styleable#Animation_fillAfter</attr>
		public virtual bool getFillAfter()
		{
			return mFillAfter;
		}

		/// <summary>
		/// Returns the Z ordering mode to use while running the animation as
		/// previously set by
		/// <see cref="setZAdjustment(int)">setZAdjustment(int)</see>
		/// .
		/// </summary>
		/// <returns>
		/// Returns one of
		/// <see cref="ZORDER_NORMAL">ZORDER_NORMAL</see>
		/// ,
		/// <see cref="ZORDER_TOP">ZORDER_TOP</see>
		/// , or
		/// <see cref="ZORDER_BOTTOM">ZORDER_BOTTOM</see>
		/// .
		/// </returns>
		/// <attr>ref android.R.styleable#Animation_zAdjustment</attr>
		public virtual int getZAdjustment()
		{
			return mZAdjustment;
		}

		/// <summary>Returns the background color behind the animation.</summary>
		/// <remarks>Returns the background color behind the animation.</remarks>
		public virtual int getBackgroundColor()
		{
			return mBackgroundColor;
		}

		/// <summary>
		/// Return value of
		/// <see cref="setDetachWallpaper(bool)">setDetachWallpaper(bool)</see>
		/// .
		/// </summary>
		/// <attr>ref android.R.styleable#Animation_detachWallpaper</attr>
		public virtual bool getDetachWallpaper()
		{
			return mDetachWallpaper;
		}

		/// <summary>
		/// <p>Indicates whether or not this animation will affect the transformation
		/// matrix.
		/// </summary>
		/// <remarks>
		/// <p>Indicates whether or not this animation will affect the transformation
		/// matrix. For instance, a fade animation will not affect the matrix whereas
		/// a scale animation will.</p>
		/// </remarks>
		/// <returns>true if this animation will change the transformation matrix</returns>
		public virtual bool willChangeTransformationMatrix()
		{
			// assume we will change the matrix
			return true;
		}

		/// <summary>
		/// <p>Indicates whether or not this animation will affect the bounds of the
		/// animated view.
		/// </summary>
		/// <remarks>
		/// <p>Indicates whether or not this animation will affect the bounds of the
		/// animated view. For instance, a fade animation will not affect the bounds
		/// whereas a 200% scale animation will.</p>
		/// </remarks>
		/// <returns>true if this animation will change the view's bounds</returns>
		public virtual bool willChangeBounds()
		{
			// assume we will change the bounds
			return true;
		}

		/// <summary><p>Binds an animation listener to this animation.</summary>
		/// <remarks>
		/// <p>Binds an animation listener to this animation. The animation listener
		/// is notified of animation events such as the end of the animation or the
		/// repetition of the animation.</p>
		/// </remarks>
		/// <param name="listener">the animation listener to be notified</param>
		public virtual void setAnimationListener(android.view.animation.Animation.AnimationListener
			 listener)
		{
			mListener = listener;
		}

		/// <summary>Gurantees that this animation has an interpolator.</summary>
		/// <remarks>
		/// Gurantees that this animation has an interpolator. Will use
		/// a AccelerateDecelerateInterpolator is nothing else was specified.
		/// </remarks>
		protected internal virtual void ensureInterpolator()
		{
			if (mInterpolator == null)
			{
				mInterpolator = new android.view.animation.AccelerateDecelerateInterpolator();
			}
		}

		/// <summary>Compute a hint at how long the entire animation may last, in milliseconds.
		/// 	</summary>
		/// <remarks>
		/// Compute a hint at how long the entire animation may last, in milliseconds.
		/// Animations can be written to cause themselves to run for a different
		/// duration than what is computed here, but generally this should be
		/// accurate.
		/// </remarks>
		public virtual long computeDurationHint()
		{
			return (getStartOffset() + getDuration()) * (getRepeatCount() + 1);
		}

		/// <summary>Gets the transformation to apply at a specified point in time.</summary>
		/// <remarks>
		/// Gets the transformation to apply at a specified point in time. Implementations of this
		/// method should always replace the specified Transformation or document they are doing
		/// otherwise.
		/// </remarks>
		/// <param name="currentTime">Where we are in the animation. This is wall clock time.
		/// 	</param>
		/// <param name="outTransformation">
		/// A transformation object that is provided by the
		/// caller and will be filled in by the animation.
		/// </param>
		/// <returns>True if the animation is still running</returns>
		public virtual bool getTransformation(long currentTime, android.view.animation.Transformation
			 outTransformation)
		{
			if (mStartTime == -1)
			{
				mStartTime = currentTime;
			}
			long startOffset = getStartOffset();
			long duration = mDuration;
			float normalizedTime;
			if (duration != 0)
			{
				normalizedTime = ((float)(currentTime - (mStartTime + startOffset))) / (float)duration;
			}
			else
			{
				// time is a step-change with a zero duration
				normalizedTime = currentTime < mStartTime ? 0.0f : 1.0f;
			}
			bool expired = normalizedTime >= 1.0f;
			mMore = !expired;
			if (!mFillEnabled)
			{
				normalizedTime = System.Math.Max(System.Math.Min(normalizedTime, 1.0f), 0.0f);
			}
			if ((normalizedTime >= 0.0f || mFillBefore) && (normalizedTime <= 1.0f || mFillAfter
				))
			{
				if (!mStarted)
				{
					if (mListener != null)
					{
						mListener.onAnimationStart(this);
					}
					mStarted = true;
					if (USE_CLOSEGUARD)
					{
						guard.open("cancel or detach or getTransformation");
					}
				}
				if (mFillEnabled)
				{
					normalizedTime = System.Math.Max(System.Math.Min(normalizedTime, 1.0f), 0.0f);
				}
				if (mCycleFlip)
				{
					normalizedTime = 1.0f - normalizedTime;
				}
				float interpolatedTime = mInterpolator.getInterpolation(normalizedTime);
				applyTransformation(interpolatedTime, outTransformation);
			}
			if (expired)
			{
				if (mRepeatCount == mRepeated)
				{
					if (!mEnded)
					{
						mEnded = true;
						guard.close();
						if (mListener != null)
						{
							mListener.onAnimationEnd(this);
						}
					}
				}
				else
				{
					if (mRepeatCount > 0)
					{
						mRepeated++;
					}
					if (mRepeatMode == REVERSE)
					{
						mCycleFlip = !mCycleFlip;
					}
					mStartTime = -1;
					mMore = true;
					if (mListener != null)
					{
						mListener.onAnimationRepeat(this);
					}
				}
			}
			if (!mMore && mOneMoreTime)
			{
				mOneMoreTime = false;
				return true;
			}
			return mMore;
		}

		/// <summary>Gets the transformation to apply at a specified point in time.</summary>
		/// <remarks>
		/// Gets the transformation to apply at a specified point in time. Implementations of this
		/// method should always replace the specified Transformation or document they are doing
		/// otherwise.
		/// </remarks>
		/// <param name="currentTime">Where we are in the animation. This is wall clock time.
		/// 	</param>
		/// <param name="outTransformation">
		/// A tranformation object that is provided by the
		/// caller and will be filled in by the animation.
		/// </param>
		/// <param name="scale">
		/// Scaling factor to apply to any inputs to the transform operation, such
		/// pivot points being rotated or scaled around.
		/// </param>
		/// <returns>True if the animation is still running</returns>
		public virtual bool getTransformation(long currentTime, android.view.animation.Transformation
			 outTransformation, float scale)
		{
			mScaleFactor = scale;
			return getTransformation(currentTime, outTransformation);
		}

		/// <summary><p>Indicates whether this animation has started or not.</p></summary>
		/// <returns>true if the animation has started, false otherwise</returns>
		public virtual bool hasStarted()
		{
			return mStarted;
		}

		/// <summary><p>Indicates whether this animation has ended or not.</p></summary>
		/// <returns>true if the animation has ended, false otherwise</returns>
		public virtual bool hasEnded()
		{
			return mEnded;
		}

		/// <summary>Helper for getTransformation.</summary>
		/// <remarks>
		/// Helper for getTransformation. Subclasses should implement this to apply
		/// their transforms given an interpolation value.  Implementations of this
		/// method should always replace the specified Transformation or document
		/// they are doing otherwise.
		/// </remarks>
		/// <param name="interpolatedTime">
		/// The value of the normalized time (0.0 to 1.0)
		/// after it has been run through the interpolation function.
		/// </param>
		/// <param name="t">
		/// The Transofrmation object to fill in with the current
		/// transforms.
		/// </param>
		protected internal virtual void applyTransformation(float interpolatedTime, android.view.animation.Transformation
			 t)
		{
		}

		/// <summary>
		/// Convert the information in the description of a size to an actual
		/// dimension
		/// </summary>
		/// <param name="type">
		/// One of Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
		/// Animation.RELATIVE_TO_PARENT.
		/// </param>
		/// <param name="value">The dimension associated with the type parameter</param>
		/// <param name="size">The size of the object being animated</param>
		/// <param name="parentSize">The size of the parent of the object being animated</param>
		/// <returns>The dimension to use for the animation</returns>
		protected internal virtual float resolveSize(int type, float value, int size, int
			 parentSize)
		{
			switch (type)
			{
				case ABSOLUTE:
				{
					return value;
				}

				case RELATIVE_TO_SELF:
				{
					return size * value;
				}

				case RELATIVE_TO_PARENT:
				{
					return parentSize * value;
				}

				default:
				{
					return value;
				}
			}
		}

		/// <param name="left"></param>
		/// <param name="top"></param>
		/// <param name="right"></param>
		/// <param name="bottom"></param>
		/// <param name="invalidate"></param>
		/// <param name="transformation"></param>
		/// <hide></hide>
		public virtual void getInvalidateRegion(int left, int top, int right, int bottom, 
			android.graphics.RectF invalidate, android.view.animation.Transformation transformation
			)
		{
			android.graphics.RectF tempRegion = mRegion;
			android.graphics.RectF previousRegion = mPreviousRegion;
			invalidate.set(left, top, right, bottom);
			transformation.getMatrix().mapRect(invalidate);
			// Enlarge the invalidate region to account for rounding errors
			invalidate.inset(-1.0f, -1.0f);
			tempRegion.set(invalidate);
			invalidate.union(previousRegion);
			previousRegion.set(tempRegion);
			android.view.animation.Transformation tempTransformation = mTransformation;
			android.view.animation.Transformation previousTransformation = mPreviousTransformation;
			tempTransformation.set(transformation);
			transformation.set(previousTransformation);
			previousTransformation.set(tempTransformation);
		}

		/// <param name="left"></param>
		/// <param name="top"></param>
		/// <param name="right"></param>
		/// <param name="bottom"></param>
		/// <hide></hide>
		public virtual void initializeInvalidateRegion(int left, int top, int right, int 
			bottom)
		{
			android.graphics.RectF region = mPreviousRegion;
			region.set(left, top, right, bottom);
			// Enlarge the invalidate region to account for rounding errors
			region.inset(-1.0f, -1.0f);
			if (mFillBefore)
			{
				android.view.animation.Transformation previousTransformation = mPreviousTransformation;
				applyTransformation(mInterpolator.getInterpolation(0.0f), previousTransformation);
			}
		}

		~Animation()
		{
			try
			{
				if (guard != null)
				{
					guard.warnIfOpen();
				}
			}
			finally
			{
				;
			}
		}

		/// <summary>Return true if this animation changes the view's alpha property.</summary>
		/// <remarks>Return true if this animation changes the view's alpha property.</remarks>
		/// <hide></hide>
		public virtual bool hasAlpha()
		{
			return false;
		}

		/// <summary>Utility class to parse a string description of a size.</summary>
		/// <remarks>Utility class to parse a string description of a size.</remarks>
		protected internal class Description
		{
			/// <summary>
			/// One of Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
			/// Animation.RELATIVE_TO_PARENT.
			/// </summary>
			/// <remarks>
			/// One of Animation.ABSOLUTE, Animation.RELATIVE_TO_SELF, or
			/// Animation.RELATIVE_TO_PARENT.
			/// </remarks>
			public int type;

			/// <summary>The absolute or relative dimension for this Description.</summary>
			/// <remarks>The absolute or relative dimension for this Description.</remarks>
			public float value;

			/// <summary>
			/// Size descriptions can appear inthree forms:
			/// <ol>
			/// <li>An absolute size.
			/// </summary>
			/// <remarks>
			/// Size descriptions can appear inthree forms:
			/// <ol>
			/// <li>An absolute size. This is represented by a number.</li>
			/// <li>A size relative to the size of the object being animated. This
			/// is represented by a number followed by "%".</li>
			/// <li>A size relative to the size of the parent of object being
			/// animated. This is represented by a number followed by "%p".</li>
			/// </ol>
			/// </remarks>
			/// <param name="value">The typed value to parse</param>
			/// <returns>The parsed version of the description</returns>
			internal static android.view.animation.Animation.Description parseValue(android.util.TypedValue
				 value)
			{
				android.view.animation.Animation.Description d = new android.view.animation.Animation
					.Description();
				if (value == null)
				{
					d.type = ABSOLUTE;
					d.value = 0;
				}
				else
				{
					if (value.type == android.util.TypedValue.TYPE_FRACTION)
					{
						d.type = (value.data & android.util.TypedValue.COMPLEX_UNIT_MASK) == android.util.TypedValue
							.COMPLEX_UNIT_FRACTION_PARENT ? RELATIVE_TO_PARENT : RELATIVE_TO_SELF;
						d.value = android.util.TypedValue.complexToFloat(value.data);
						return d;
					}
					else
					{
						if (value.type == android.util.TypedValue.TYPE_FLOAT)
						{
							d.type = ABSOLUTE;
							d.value = value.getFloat();
							return d;
						}
						else
						{
							if (value.type >= android.util.TypedValue.TYPE_FIRST_INT && value.type <= android.util.TypedValue
								.TYPE_LAST_INT)
							{
								d.type = ABSOLUTE;
								d.value = value.data;
								return d;
							}
						}
					}
				}
				d.type = ABSOLUTE;
				d.value = 0.0f;
				return d;
			}
		}

		/// <summary><p>An animation listener receives notifications from an animation.</summary>
		/// <remarks>
		/// <p>An animation listener receives notifications from an animation.
		/// Notifications indicate animation related events, such as the end or the
		/// repetition of the animation.</p>
		/// </remarks>
		public interface AnimationListener
		{
			/// <summary><p>Notifies the start of the animation.</p></summary>
			/// <param name="animation">The started animation.</param>
			void onAnimationStart(android.view.animation.Animation animation);

			/// <summary><p>Notifies the end of the animation.</summary>
			/// <remarks>
			/// <p>Notifies the end of the animation. This callback is not invoked
			/// for animations with repeat count set to INFINITE.</p>
			/// </remarks>
			/// <param name="animation">The animation which reached its end.</param>
			void onAnimationEnd(android.view.animation.Animation animation);

			/// <summary><p>Notifies the repetition of the animation.</p></summary>
			/// <param name="animation">The animation which was repeated.</param>
			void onAnimationRepeat(android.view.animation.Animation animation);
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
