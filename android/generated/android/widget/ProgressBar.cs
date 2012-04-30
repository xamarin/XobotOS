using Sharpen;

namespace android.widget
{
	/// <summary>
	/// <p>
	/// Visual indicator of progress in some operation.
	/// </summary>
	/// <remarks>
	/// <p>
	/// Visual indicator of progress in some operation.  Displays a bar to the user
	/// representing how far the operation has progressed; the application can
	/// change the amount of progress (modifying the length of the bar) as it moves
	/// forward.  There is also a secondary progress displayable on a progress bar
	/// which is useful for displaying intermediate progress, such as the buffer
	/// level during a streaming playback progress bar.
	/// </p>
	/// <p>
	/// A progress bar can also be made indeterminate. In indeterminate mode, the
	/// progress bar shows a cyclic animation without an indication of progress. This mode is used by
	/// applications when the length of the task is unknown. The indeterminate progress bar can be either
	/// a spinning wheel or a horizontal bar.
	/// </p>
	/// <p>The following code example shows how a progress bar can be used from
	/// a worker thread to update the user interface to notify the user of progress:
	/// </p>
	/// <pre>
	/// public class MyActivity extends Activity {
	/// private static final int PROGRESS = 0x1;
	/// private ProgressBar mProgress;
	/// private int mProgressStatus = 0;
	/// private Handler mHandler = new Handler();
	/// protected void onCreate(Bundle icicle) {
	/// super.onCreate(icicle);
	/// setContentView(R.layout.progressbar_activity);
	/// mProgress = (ProgressBar) findViewById(R.id.progress_bar);
	/// // Start lengthy operation in a background thread
	/// new Thread(new Runnable() {
	/// public void run() {
	/// while (mProgressStatus &lt; 100) {
	/// mProgressStatus = doWork();
	/// // Update the progress bar
	/// mHandler.post(new Runnable() {
	/// public void run() {
	/// mProgress.setProgress(mProgressStatus);
	/// }
	/// });
	/// }
	/// }
	/// }).start();
	/// }
	/// }</pre>
	/// <p>To add a progress bar to a layout file, you can use the
	/// <code>&lt;ProgressBar&gt;</code>
	/// element.
	/// By default, the progress bar is a spinning wheel (an indeterminate indicator). To change to a
	/// horizontal progress bar, apply the
	/// <see cref="android.R.style.Widget_ProgressBar_Horizontal">Widget.ProgressBar.Horizontal
	/// 	</see>
	/// style, like so:</p>
	/// <pre>
	/// &lt;ProgressBar
	/// style="@android:style/Widget.ProgressBar.Horizontal"
	/// ... /&gt;</pre>
	/// <p>If you will use the progress bar to show real progress, you must use the horizontal bar. You
	/// can then increment the  progress with
	/// <see cref="incrementProgressBy(int)">incrementProgressBy()</see>
	/// or
	/// <see cref="setProgress(int)">setProgress()</see>
	/// . By default, the progress bar is full when it reaches 100. If
	/// necessary, you can adjust the maximum value (the value for a full bar) using the
	/// <see cref="android.R.styleable.ProgressBar_max">android:max</see>
	/// attribute. Other attributes available are listed
	/// below.</p>
	/// <p>Another common style to apply to the progress bar is
	/// <see cref="android.R.style.Widget_ProgressBar_Small">Widget.ProgressBar.Small</see>
	/// , which shows a smaller
	/// version of the spinning wheel&mdash;useful when waiting for content to load.
	/// For example, you can insert this kind of progress bar into your default layout for
	/// a view that will be populated by some content fetched from the Internet&mdash;the spinning wheel
	/// appears immediately and when your application receives the content, it replaces the progress bar
	/// with the loaded content. For example:</p>
	/// <pre>
	/// &lt;LinearLayout
	/// android:orientation="horizontal"
	/// ... &gt;
	/// &lt;ProgressBar
	/// android:layout_width="wrap_content"
	/// android:layout_height="wrap_content"
	/// style="@android:style/Widget.ProgressBar.Small"
	/// android:layout_marginRight="5dp" /&gt;
	/// &lt;TextView
	/// android:layout_width="wrap_content"
	/// android:layout_height="wrap_content"
	/// android:text="@string/loading" /&gt;
	/// &lt;/LinearLayout&gt;</pre>
	/// <p>Other progress bar styles provided by the system include:</p>
	/// <ul>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Horizontal">Widget.ProgressBar.Horizontal
	/// 	</see>
	/// </li>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Small">Widget.ProgressBar.Small</see>
	/// </li>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Large">Widget.ProgressBar.Large</see>
	/// </li>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Inverse">Widget.ProgressBar.Inverse
	/// 	</see>
	/// </li>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Small_Inverse">Widget.ProgressBar.Small.Inverse
	/// 	</see>
	/// </li>
	/// <li>
	/// <see cref="android.R.style.Widget_ProgressBar_Large_Inverse">Widget.ProgressBar.Large.Inverse
	/// 	</see>
	/// </li>
	/// </ul>
	/// <p>The "inverse" styles provide an inverse color scheme for the spinner, which may be necessary
	/// if your application uses a light colored theme (a white background).</p>
	/// <p><strong>XML attributes</b></strong>
	/// <p>
	/// See
	/// <see cref="android.R.styleable.ProgressBar">ProgressBar Attributes</see>
	/// ,
	/// <see cref="android.R.styleable.View">View Attributes</see>
	/// </p>
	/// </remarks>
	/// <attr>ref android.R.styleable#ProgressBar_animationResolution</attr>
	/// <attr>ref android.R.styleable#ProgressBar_indeterminate</attr>
	/// <attr>ref android.R.styleable#ProgressBar_indeterminateBehavior</attr>
	/// <attr>ref android.R.styleable#ProgressBar_indeterminateDrawable</attr>
	/// <attr>ref android.R.styleable#ProgressBar_indeterminateDuration</attr>
	/// <attr>ref android.R.styleable#ProgressBar_indeterminateOnly</attr>
	/// <attr>ref android.R.styleable#ProgressBar_interpolator</attr>
	/// <attr>ref android.R.styleable#ProgressBar_max</attr>
	/// <attr>ref android.R.styleable#ProgressBar_maxHeight</attr>
	/// <attr>ref android.R.styleable#ProgressBar_maxWidth</attr>
	/// <attr>ref android.R.styleable#ProgressBar_minHeight</attr>
	/// <attr>ref android.R.styleable#ProgressBar_minWidth</attr>
	/// <attr>ref android.R.styleable#ProgressBar_progress</attr>
	/// <attr>ref android.R.styleable#ProgressBar_progressDrawable</attr>
	/// <attr>ref android.R.styleable#ProgressBar_secondaryProgress</attr>
	[Sharpen.Sharpened]
	public class ProgressBar : android.view.View
	{
		internal const int MAX_LEVEL = 10000;

		internal const int ANIMATION_RESOLUTION = 200;

		internal const int TIMEOUT_SEND_ACCESSIBILITY_EVENT = 200;

		internal int mMinWidth;

		internal int mMaxWidth;

		internal int mMinHeight;

		internal int mMaxHeight;

		private int mProgress;

		private int mSecondaryProgress;

		private int mMax;

		private int mBehavior;

		private int mDuration;

		private bool mIndeterminate;

		private bool mOnlyIndeterminate;

		private android.view.animation.Transformation mTransformation;

		private android.view.animation.AlphaAnimation mAnimation;

		private android.graphics.drawable.Drawable mIndeterminateDrawable;

		private android.graphics.drawable.Drawable mProgressDrawable;

		private android.graphics.drawable.Drawable mCurrentDrawable;

		internal android.graphics.Bitmap mSampleTile;

		private bool mNoInvalidate;

		private android.view.animation.Interpolator mInterpolator;

		private android.widget.ProgressBar.RefreshProgressRunnable mRefreshProgressRunnable;

		private long mUiThreadId;

		private bool mShouldStartAnimationDrawable;

		private long mLastDrawTime;

		private bool mInDrawing;

		private int mAnimationResolution;

		private android.widget.ProgressBar.AccessibilityEventSender mAccessibilityEventSender;

		/// <summary>Create a new progress bar with range 0...100 and initial progress of 0.</summary>
		/// <remarks>Create a new progress bar with range 0...100 and initial progress of 0.</remarks>
		/// <param name="context">the application environment</param>
		public ProgressBar(android.content.Context context) : this(context, null)
		{
		}

		public ProgressBar(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.progressBarStyle)
		{
		}

		public ProgressBar(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : this(context, attrs, defStyle, 0)
		{
		}

		/// <hide></hide>
		public ProgressBar(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle, int styleRes) : base(context, attrs, defStyle)
		{
			mUiThreadId = java.lang.Thread.currentThread().getId();
			initProgressBar();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ProgressBar, defStyle, styleRes);
			mNoInvalidate = true;
			android.graphics.drawable.Drawable drawable = a.getDrawable(android.@internal.R.styleable
				.ProgressBar_progressDrawable);
			if (drawable != null)
			{
				drawable = tileify(drawable, false);
				// Calling this method can set mMaxHeight, make sure the corresponding
				// XML attribute for mMaxHeight is read after calling this method
				setProgressDrawable(drawable);
			}
			mDuration = a.getInt(android.@internal.R.styleable.ProgressBar_indeterminateDuration
				, mDuration);
			mMinWidth = a.getDimensionPixelSize(android.@internal.R.styleable.ProgressBar_minWidth
				, mMinWidth);
			mMaxWidth = a.getDimensionPixelSize(android.@internal.R.styleable.ProgressBar_maxWidth
				, mMaxWidth);
			mMinHeight = a.getDimensionPixelSize(android.@internal.R.styleable.ProgressBar_minHeight
				, mMinHeight);
			mMaxHeight = a.getDimensionPixelSize(android.@internal.R.styleable.ProgressBar_maxHeight
				, mMaxHeight);
			mBehavior = a.getInt(android.@internal.R.styleable.ProgressBar_indeterminateBehavior
				, mBehavior);
			int resID = a.getResourceId(android.@internal.R.styleable.ProgressBar_interpolator
				, android.R.anim.linear_interpolator);
			// default to linear interpolator
			if (resID > 0)
			{
				setInterpolator(context, resID);
			}
			setMax(a.getInt(android.@internal.R.styleable.ProgressBar_max, mMax));
			setProgress(a.getInt(android.@internal.R.styleable.ProgressBar_progress, mProgress
				));
			setSecondaryProgress(a.getInt(android.@internal.R.styleable.ProgressBar_secondaryProgress
				, mSecondaryProgress));
			drawable = a.getDrawable(android.@internal.R.styleable.ProgressBar_indeterminateDrawable
				);
			if (drawable != null)
			{
				drawable = tileifyIndeterminate(drawable);
				setIndeterminateDrawable(drawable);
			}
			mOnlyIndeterminate = a.getBoolean(android.@internal.R.styleable.ProgressBar_indeterminateOnly
				, mOnlyIndeterminate);
			mNoInvalidate = false;
			setIndeterminate(mOnlyIndeterminate || a.getBoolean(android.@internal.R.styleable
				.ProgressBar_indeterminate, mIndeterminate));
			mAnimationResolution = a.getInteger(android.@internal.R.styleable.ProgressBar_animationResolution
				, ANIMATION_RESOLUTION);
			a.recycle();
		}

		/// <summary>Converts a drawable to a tiled version of itself.</summary>
		/// <remarks>
		/// Converts a drawable to a tiled version of itself. It will recursively
		/// traverse layer and state list drawables.
		/// </remarks>
		private android.graphics.drawable.Drawable tileify(android.graphics.drawable.Drawable
			 drawable, bool clip)
		{
			if (drawable is android.graphics.drawable.LayerDrawable)
			{
				android.graphics.drawable.LayerDrawable background = (android.graphics.drawable.LayerDrawable
					)drawable;
				int N = background.getNumberOfLayers();
				android.graphics.drawable.Drawable[] outDrawables = new android.graphics.drawable.Drawable
					[N];
				{
					for (int i = 0; i < N; i++)
					{
						int id = background.getId(i);
						outDrawables[i] = tileify(background.getDrawable(i), (id == android.@internal.R.id
							.progress || id == android.@internal.R.id.secondaryProgress));
					}
				}
				android.graphics.drawable.LayerDrawable newBg = new android.graphics.drawable.LayerDrawable
					(outDrawables);
				{
					for (int i_1 = 0; i_1 < N; i_1++)
					{
						newBg.setId(i_1, background.getId(i_1));
					}
				}
				return newBg;
			}
			else
			{
				if (drawable is android.graphics.drawable.StateListDrawable)
				{
					android.graphics.drawable.StateListDrawable @in = (android.graphics.drawable.StateListDrawable
						)drawable;
					android.graphics.drawable.StateListDrawable @out = new android.graphics.drawable.StateListDrawable
						();
					int numStates = @in.getStateCount();
					{
						for (int i = 0; i < numStates; i++)
						{
							@out.addState(@in.getStateSet(i), tileify(@in.getStateDrawable(i), clip));
						}
					}
					return @out;
				}
				else
				{
					if (drawable is android.graphics.drawable.BitmapDrawable)
					{
						android.graphics.Bitmap tileBitmap = ((android.graphics.drawable.BitmapDrawable)drawable
							).getBitmap();
						if (mSampleTile == null)
						{
							mSampleTile = tileBitmap;
						}
						android.graphics.drawable.ShapeDrawable shapeDrawable = new android.graphics.drawable.ShapeDrawable
							(getDrawableShape());
						android.graphics.BitmapShader bitmapShader = new android.graphics.BitmapShader(tileBitmap
							, android.graphics.Shader.TileMode.REPEAT, android.graphics.Shader.TileMode.CLAMP
							);
						shapeDrawable.getPaint().setShader(bitmapShader);
						return (clip) ? (android.graphics.drawable.Drawable)new android.graphics.drawable.ClipDrawable
							(shapeDrawable, android.view.Gravity.LEFT, android.graphics.drawable.ClipDrawable
							.HORIZONTAL) : (android.graphics.drawable.Drawable)shapeDrawable;
					}
				}
			}
			return drawable;
		}

		internal virtual android.graphics.drawable.shapes.Shape getDrawableShape()
		{
			float[] roundedCorners = new float[] { 5, 5, 5, 5, 5, 5, 5, 5 };
			return new android.graphics.drawable.shapes.RoundRectShape(roundedCorners, null, 
				null);
		}

		/// <summary>Convert a AnimationDrawable for use as a barberpole animation.</summary>
		/// <remarks>
		/// Convert a AnimationDrawable for use as a barberpole animation.
		/// Each frame of the animation is wrapped in a ClipDrawable and
		/// given a tiling BitmapShader.
		/// </remarks>
		private android.graphics.drawable.Drawable tileifyIndeterminate(android.graphics.drawable.Drawable
			 drawable)
		{
			if (drawable is android.graphics.drawable.AnimationDrawable)
			{
				android.graphics.drawable.AnimationDrawable background = (android.graphics.drawable.AnimationDrawable
					)drawable;
				int N = background.getNumberOfFrames();
				android.graphics.drawable.AnimationDrawable newBg = new android.graphics.drawable.AnimationDrawable
					();
				newBg.setOneShot(background.isOneShot());
				{
					for (int i = 0; i < N; i++)
					{
						android.graphics.drawable.Drawable frame = tileify(background.getFrame(i), true);
						frame.setLevel(10000);
						newBg.addFrame(frame, background.getDuration(i));
					}
				}
				newBg.setLevel(10000);
				drawable = newBg;
			}
			return drawable;
		}

		/// <summary>
		/// <p>
		/// Initialize the progress bar's default values:
		/// </p>
		/// <ul>
		/// <li>progress = 0</li>
		/// <li>max = 100</li>
		/// <li>animation duration = 4000 ms</li>
		/// <li>indeterminate = false</li>
		/// <li>behavior = repeat</li>
		/// </ul>
		/// </summary>
		private void initProgressBar()
		{
			mMax = 100;
			mProgress = 0;
			mSecondaryProgress = 0;
			mIndeterminate = false;
			mOnlyIndeterminate = false;
			mDuration = 4000;
			mBehavior = android.view.animation.Animation.RESTART;
			mMinWidth = 24;
			mMaxWidth = 48;
			mMinHeight = 24;
			mMaxHeight = 48;
		}

		/// <summary><p>Indicate whether this progress bar is in indeterminate mode.</p></summary>
		/// <returns>true if the progress bar is in indeterminate mode</returns>
		public virtual bool isIndeterminate()
		{
			lock (this)
			{
				return mIndeterminate;
			}
		}

		/// <summary><p>Change the indeterminate mode for this progress bar.</summary>
		/// <remarks>
		/// <p>Change the indeterminate mode for this progress bar. In indeterminate
		/// mode, the progress is ignored and the progress bar shows an infinite
		/// animation instead.</p>
		/// If this progress bar's style only supports indeterminate mode (such as the circular
		/// progress bars), then this will be ignored.
		/// </remarks>
		/// <param name="indeterminate">true to enable the indeterminate mode</param>
		[android.view.RemotableViewMethod]
		public virtual void setIndeterminate(bool indeterminate)
		{
			lock (this)
			{
				if ((!mOnlyIndeterminate || !mIndeterminate) && indeterminate != mIndeterminate)
				{
					mIndeterminate = indeterminate;
					if (indeterminate)
					{
						// swap between indeterminate and regular backgrounds
						mCurrentDrawable = mIndeterminateDrawable;
						startAnimation();
					}
					else
					{
						mCurrentDrawable = mProgressDrawable;
						stopAnimation();
					}
				}
			}
		}

		/// <summary>
		/// <p>Get the drawable used to draw the progress bar in
		/// indeterminate mode.</p>
		/// </summary>
		/// <returns>
		/// a
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// instance
		/// </returns>
		/// <seealso cref="setIndeterminateDrawable(android.graphics.drawable.Drawable)">setIndeterminateDrawable(android.graphics.drawable.Drawable)
		/// 	</seealso>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		public virtual android.graphics.drawable.Drawable getIndeterminateDrawable()
		{
			return mIndeterminateDrawable;
		}

		/// <summary>
		/// <p>Define the drawable used to draw the progress bar in
		/// indeterminate mode.</p>
		/// </summary>
		/// <param name="d">the new drawable</param>
		/// <seealso cref="getIndeterminateDrawable()">getIndeterminateDrawable()</seealso>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		public virtual void setIndeterminateDrawable(android.graphics.drawable.Drawable d
			)
		{
			if (d != null)
			{
				d.setCallback(this);
			}
			mIndeterminateDrawable = d;
			if (mIndeterminate)
			{
				mCurrentDrawable = d;
				postInvalidate();
			}
		}

		/// <summary>
		/// <p>Get the drawable used to draw the progress bar in
		/// progress mode.</p>
		/// </summary>
		/// <returns>
		/// a
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// instance
		/// </returns>
		/// <seealso cref="setProgressDrawable(android.graphics.drawable.Drawable)">setProgressDrawable(android.graphics.drawable.Drawable)
		/// 	</seealso>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		public virtual android.graphics.drawable.Drawable getProgressDrawable()
		{
			return mProgressDrawable;
		}

		/// <summary>
		/// <p>Define the drawable used to draw the progress bar in
		/// progress mode.</p>
		/// </summary>
		/// <param name="d">the new drawable</param>
		/// <seealso cref="getProgressDrawable()">getProgressDrawable()</seealso>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		public virtual void setProgressDrawable(android.graphics.drawable.Drawable d)
		{
			bool needUpdate;
			if (mProgressDrawable != null && d != mProgressDrawable)
			{
				mProgressDrawable.setCallback(null);
				needUpdate = true;
			}
			else
			{
				needUpdate = false;
			}
			if (d != null)
			{
				d.setCallback(this);
				// Make sure the ProgressBar is always tall enough
				int drawableHeight = d.getMinimumHeight();
				if (mMaxHeight < drawableHeight)
				{
					mMaxHeight = drawableHeight;
					requestLayout();
				}
			}
			mProgressDrawable = d;
			if (!mIndeterminate)
			{
				mCurrentDrawable = d;
				postInvalidate();
			}
			if (needUpdate)
			{
				updateDrawableBounds(getWidth(), getHeight());
				updateDrawableState();
				doRefreshProgress(android.@internal.R.id.progress, mProgress, false, false);
				doRefreshProgress(android.@internal.R.id.secondaryProgress, mSecondaryProgress, false
					, false);
			}
		}

		/// <returns>The drawable currently used to draw the progress bar</returns>
		internal virtual android.graphics.drawable.Drawable getCurrentDrawable()
		{
			return mCurrentDrawable;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool verifyDrawable(android.graphics.drawable.Drawable
			 who)
		{
			return who == mProgressDrawable || who == mIndeterminateDrawable || base.verifyDrawable
				(who);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void jumpDrawablesToCurrentState()
		{
			base.jumpDrawablesToCurrentState();
			if (mProgressDrawable != null)
			{
				mProgressDrawable.jumpToCurrentState();
			}
			if (mIndeterminateDrawable != null)
			{
				mIndeterminateDrawable.jumpToCurrentState();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void postInvalidate()
		{
			if (!mNoInvalidate)
			{
				base.postInvalidate();
			}
		}

		private class RefreshProgressRunnable : java.lang.Runnable
		{
			internal int mId;

			internal int mProgress;

			internal bool mFromUser;

			internal RefreshProgressRunnable(ProgressBar _enclosing, int id, int progress, bool
				 fromUser)
			{
				this._enclosing = _enclosing;
				this.mId = id;
				this.mProgress = progress;
				this.mFromUser = fromUser;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.doRefreshProgress(this.mId, this.mProgress, this.mFromUser, true);
				// Put ourselves back in the cache when we are done
				this._enclosing.mRefreshProgressRunnable = this;
			}

			public virtual void setup(int id, int progress, bool fromUser)
			{
				this.mId = id;
				this.mProgress = progress;
				this.mFromUser = fromUser;
			}

			private readonly ProgressBar _enclosing;
		}

		private void doRefreshProgress(int id, int progress, bool fromUser, bool callBackToApp
			)
		{
			lock (this)
			{
				float scale = mMax > 0 ? (float)progress / (float)mMax : 0;
				android.graphics.drawable.Drawable d = mCurrentDrawable;
				if (d != null)
				{
					android.graphics.drawable.Drawable progressDrawable = null;
					if (d is android.graphics.drawable.LayerDrawable)
					{
						progressDrawable = ((android.graphics.drawable.LayerDrawable)d).findDrawableByLayerId
							(id);
					}
					int level = (int)(scale * MAX_LEVEL);
					(progressDrawable != null ? progressDrawable : d).setLevel(level);
				}
				else
				{
					invalidate();
				}
				if (callBackToApp && id == android.@internal.R.id.progress)
				{
					onProgressRefresh(scale, fromUser);
				}
			}
		}

		internal virtual void onProgressRefresh(float scale, bool fromUser)
		{
			if (android.view.accessibility.AccessibilityManager.getInstance(mContext).isEnabled
				())
			{
				scheduleAccessibilityEventSender();
			}
		}

		private void refreshProgress(int id, int progress, bool fromUser)
		{
			lock (this)
			{
				if (mUiThreadId == java.lang.Thread.currentThread().getId())
				{
					doRefreshProgress(id, progress, fromUser, true);
				}
				else
				{
					android.widget.ProgressBar.RefreshProgressRunnable r;
					if (mRefreshProgressRunnable != null)
					{
						// Use cached RefreshProgressRunnable if available
						r = mRefreshProgressRunnable;
						// Uncache it
						mRefreshProgressRunnable = null;
						r.setup(id, progress, fromUser);
					}
					else
					{
						// Make a new one
						r = new android.widget.ProgressBar.RefreshProgressRunnable(this, id, progress, fromUser
							);
					}
					post(r);
				}
			}
		}

		/// <summary><p>Set the current progress to the specified value.</summary>
		/// <remarks>
		/// <p>Set the current progress to the specified value. Does not do anything
		/// if the progress bar is in indeterminate mode.</p>
		/// </remarks>
		/// <param name="progress">
		/// the new progress, between 0 and
		/// <see cref="getMax()">getMax()</see>
		/// </param>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		/// <seealso cref="isIndeterminate()">isIndeterminate()</seealso>
		/// <seealso cref="getProgress()">getProgress()</seealso>
		/// <seealso cref="incrementProgressBy(int)"></seealso>
		[android.view.RemotableViewMethod]
		public virtual void setProgress(int progress)
		{
			lock (this)
			{
				setProgress(progress, false);
			}
		}

		[android.view.RemotableViewMethod]
		internal virtual void setProgress(int progress, bool fromUser)
		{
			lock (this)
			{
				if (mIndeterminate)
				{
					return;
				}
				if (progress < 0)
				{
					progress = 0;
				}
				if (progress > mMax)
				{
					progress = mMax;
				}
				if (progress != mProgress)
				{
					mProgress = progress;
					refreshProgress(android.@internal.R.id.progress, mProgress, fromUser);
				}
			}
		}

		/// <summary>
		/// <p>
		/// Set the current secondary progress to the specified value.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Set the current secondary progress to the specified value. Does not do
		/// anything if the progress bar is in indeterminate mode.
		/// </p>
		/// </remarks>
		/// <param name="secondaryProgress">
		/// the new secondary progress, between 0 and
		/// <see cref="getMax()">getMax()</see>
		/// </param>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		/// <seealso cref="isIndeterminate()">isIndeterminate()</seealso>
		/// <seealso cref="getSecondaryProgress()">getSecondaryProgress()</seealso>
		/// <seealso cref="incrementSecondaryProgressBy(int)">incrementSecondaryProgressBy(int)
		/// 	</seealso>
		[android.view.RemotableViewMethod]
		public virtual void setSecondaryProgress(int secondaryProgress)
		{
			lock (this)
			{
				if (mIndeterminate)
				{
					return;
				}
				if (secondaryProgress < 0)
				{
					secondaryProgress = 0;
				}
				if (secondaryProgress > mMax)
				{
					secondaryProgress = mMax;
				}
				if (secondaryProgress != mSecondaryProgress)
				{
					mSecondaryProgress = secondaryProgress;
					refreshProgress(android.@internal.R.id.secondaryProgress, mSecondaryProgress, false
						);
				}
			}
		}

		/// <summary><p>Get the progress bar's current level of progress.</summary>
		/// <remarks>
		/// <p>Get the progress bar's current level of progress. Return 0 when the
		/// progress bar is in indeterminate mode.</p>
		/// </remarks>
		/// <returns>
		/// the current progress, between 0 and
		/// <see cref="getMax()">getMax()</see>
		/// </returns>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		/// <seealso cref="isIndeterminate()">isIndeterminate()</seealso>
		/// <seealso cref="setProgress(int)">setProgress(int)</seealso>
		/// <seealso cref="setMax(int)">setMax(int)</seealso>
		/// <seealso cref="getMax()">getMax()</seealso>
		public virtual int getProgress()
		{
			lock (this)
			{
				return mIndeterminate ? 0 : mProgress;
			}
		}

		/// <summary><p>Get the progress bar's current level of secondary progress.</summary>
		/// <remarks>
		/// <p>Get the progress bar's current level of secondary progress. Return 0 when the
		/// progress bar is in indeterminate mode.</p>
		/// </remarks>
		/// <returns>
		/// the current secondary progress, between 0 and
		/// <see cref="getMax()">getMax()</see>
		/// </returns>
		/// <seealso cref="setIndeterminate(bool)">setIndeterminate(bool)</seealso>
		/// <seealso cref="isIndeterminate()">isIndeterminate()</seealso>
		/// <seealso cref="setSecondaryProgress(int)">setSecondaryProgress(int)</seealso>
		/// <seealso cref="setMax(int)">setMax(int)</seealso>
		/// <seealso cref="getMax()">getMax()</seealso>
		public virtual int getSecondaryProgress()
		{
			lock (this)
			{
				return mIndeterminate ? 0 : mSecondaryProgress;
			}
		}

		/// <summary><p>Return the upper limit of this progress bar's range.</p></summary>
		/// <returns>a positive integer</returns>
		/// <seealso cref="setMax(int)">setMax(int)</seealso>
		/// <seealso cref="getProgress()">getProgress()</seealso>
		/// <seealso cref="getSecondaryProgress()">getSecondaryProgress()</seealso>
		public virtual int getMax()
		{
			lock (this)
			{
				return mMax;
			}
		}

		/// <summary><p>Set the range of the progress bar to 0...<tt>max</tt>.</p></summary>
		/// <param name="max">the upper range of this progress bar</param>
		/// <seealso cref="getMax()">getMax()</seealso>
		/// <seealso cref="setProgress(int)"></seealso>
		/// <seealso cref="setSecondaryProgress(int)"></seealso>
		[android.view.RemotableViewMethod]
		public virtual void setMax(int max)
		{
			lock (this)
			{
				if (max < 0)
				{
					max = 0;
				}
				if (max != mMax)
				{
					mMax = max;
					postInvalidate();
					if (mProgress > max)
					{
						mProgress = max;
					}
					refreshProgress(android.@internal.R.id.progress, mProgress, false);
				}
			}
		}

		/// <summary><p>Increase the progress bar's progress by the specified amount.</p></summary>
		/// <param name="diff">the amount by which the progress must be increased</param>
		/// <seealso cref="setProgress(int)"></seealso>
		public void incrementProgressBy(int diff)
		{
			lock (this)
			{
				setProgress(mProgress + diff);
			}
		}

		/// <summary><p>Increase the progress bar's secondary progress by the specified amount.</p>
		/// 	</summary>
		/// <param name="diff">the amount by which the secondary progress must be increased</param>
		/// <seealso cref="setSecondaryProgress(int)"></seealso>
		public void incrementSecondaryProgressBy(int diff)
		{
			lock (this)
			{
				setSecondaryProgress(mSecondaryProgress + diff);
			}
		}

		/// <summary><p>Start the indeterminate progress animation.</p></summary>
		internal virtual void startAnimation()
		{
			if (getVisibility() != VISIBLE)
			{
				return;
			}
			if (mIndeterminateDrawable is android.graphics.drawable.Animatable)
			{
				mShouldStartAnimationDrawable = true;
				mAnimation = null;
			}
			else
			{
				if (mInterpolator == null)
				{
					mInterpolator = new android.view.animation.LinearInterpolator();
				}
				mTransformation = new android.view.animation.Transformation();
				mAnimation = new android.view.animation.AlphaAnimation(0.0f, 1.0f);
				mAnimation.setRepeatMode(mBehavior);
				mAnimation.setRepeatCount(android.view.animation.Animation.INFINITE);
				mAnimation.setDuration(mDuration);
				mAnimation.setInterpolator(mInterpolator);
				mAnimation.setStartTime(android.view.animation.Animation.START_ON_FIRST_FRAME);
			}
			postInvalidate();
		}

		/// <summary><p>Stop the indeterminate progress animation.</p></summary>
		internal virtual void stopAnimation()
		{
			mAnimation = null;
			mTransformation = null;
			if (mIndeterminateDrawable is android.graphics.drawable.Animatable)
			{
				((android.graphics.drawable.Animatable)mIndeterminateDrawable).stop();
				mShouldStartAnimationDrawable = false;
			}
			postInvalidate();
		}

		/// <summary>Sets the acceleration curve for the indeterminate animation.</summary>
		/// <remarks>
		/// Sets the acceleration curve for the indeterminate animation.
		/// The interpolator is loaded as a resource from the specified context.
		/// </remarks>
		/// <param name="context">The application environment</param>
		/// <param name="resID">The resource identifier of the interpolator to load</param>
		public virtual void setInterpolator(android.content.Context context, int resID)
		{
			setInterpolator(android.view.animation.AnimationUtils.loadInterpolator(context, resID
				));
		}

		/// <summary>Sets the acceleration curve for the indeterminate animation.</summary>
		/// <remarks>
		/// Sets the acceleration curve for the indeterminate animation.
		/// Defaults to a linear interpolation.
		/// </remarks>
		/// <param name="interpolator">The interpolator which defines the acceleration curve</param>
		public virtual void setInterpolator(android.view.animation.Interpolator interpolator
			)
		{
			mInterpolator = interpolator;
		}

		/// <summary>Gets the acceleration curve type for the indeterminate animation.</summary>
		/// <remarks>Gets the acceleration curve type for the indeterminate animation.</remarks>
		/// <returns>
		/// the
		/// <see cref="android.view.animation.Interpolator">android.view.animation.Interpolator
		/// 	</see>
		/// associated to this animation
		/// </returns>
		public virtual android.view.animation.Interpolator getInterpolator()
		{
			return mInterpolator;
		}

		[android.view.RemotableViewMethod]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVisibility(int v)
		{
			if (getVisibility() != v)
			{
				base.setVisibility(v);
				if (mIndeterminate)
				{
					// let's be nice with the UI thread
					if (v == GONE || v == INVISIBLE)
					{
						stopAnimation();
					}
					else
					{
						startAnimation();
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onVisibilityChanged(android.view.View changedView
			, int visibility)
		{
			base.onVisibilityChanged(changedView, visibility);
			if (mIndeterminate)
			{
				// let's be nice with the UI thread
				if (visibility == GONE || visibility == INVISIBLE)
				{
					stopAnimation();
				}
				else
				{
					startAnimation();
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void invalidateDrawable(android.graphics.drawable.Drawable dr)
		{
			if (!mInDrawing)
			{
				if (verifyDrawable(dr))
				{
					android.graphics.Rect dirty = dr.getBounds();
					int scrollX = mScrollX + mPaddingLeft;
					int scrollY = mScrollY + mPaddingTop;
					invalidate(dirty.left + scrollX, dirty.top + scrollY, dirty.right + scrollX, dirty
						.bottom + scrollY);
				}
				else
				{
					base.invalidateDrawable(dr);
				}
			}
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getResolvedLayoutDirection(android.graphics.drawable.Drawable
			 who)
		{
			return (who == mProgressDrawable || who == mIndeterminateDrawable) ? getResolvedLayoutDirection
				() : base.getResolvedLayoutDirection(who);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			updateDrawableBounds(w, h);
		}

		private void updateDrawableBounds(int w, int h)
		{
			// onDraw will translate the canvas so we draw starting at 0,0
			int right = w - mPaddingRight - mPaddingLeft;
			int bottom = h - mPaddingBottom - mPaddingTop;
			int top = 0;
			int left = 0;
			if (mIndeterminateDrawable != null)
			{
				// Aspect ratio logic does not apply to AnimationDrawables
				if (mOnlyIndeterminate && !(mIndeterminateDrawable is android.graphics.drawable.AnimationDrawable
					))
				{
					// Maintain aspect ratio. Certain kinds of animated drawables
					// get very confused otherwise.
					int intrinsicWidth = mIndeterminateDrawable.getIntrinsicWidth();
					int intrinsicHeight = mIndeterminateDrawable.getIntrinsicHeight();
					float intrinsicAspect = (float)intrinsicWidth / intrinsicHeight;
					float boundAspect = (float)w / h;
					if (intrinsicAspect != boundAspect)
					{
						if (boundAspect > intrinsicAspect)
						{
							// New width is larger. Make it smaller to match height.
							int width = (int)(h * intrinsicAspect);
							left = (w - width) / 2;
							right = left + width;
						}
						else
						{
							// New height is larger. Make it smaller to match width.
							int height = (int)(w * (1 / intrinsicAspect));
							top = (h - height) / 2;
							bottom = top + height;
						}
					}
				}
				mIndeterminateDrawable.setBounds(left, top, right, bottom);
			}
			if (mProgressDrawable != null)
			{
				mProgressDrawable.setBounds(0, 0, right, bottom);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			lock (this)
			{
				base.onDraw(canvas);
				android.graphics.drawable.Drawable d = mCurrentDrawable;
				if (d != null)
				{
					// Translate canvas so a indeterminate circular progress bar with padding
					// rotates properly in its animation
					canvas.save();
					canvas.translate(mPaddingLeft, mPaddingTop);
					long time = getDrawingTime();
					if (mAnimation != null)
					{
						mAnimation.getTransformation(time, mTransformation);
						float scale = mTransformation.getAlpha();
						try
						{
							mInDrawing = true;
							d.setLevel((int)(scale * MAX_LEVEL));
						}
						finally
						{
							mInDrawing = false;
						}
						if (android.os.SystemClock.uptimeMillis() - mLastDrawTime >= mAnimationResolution)
						{
							mLastDrawTime = android.os.SystemClock.uptimeMillis();
							postInvalidateDelayed(mAnimationResolution);
						}
					}
					d.draw(canvas);
					canvas.restore();
					if (mShouldStartAnimationDrawable && d is android.graphics.drawable.Animatable)
					{
						((android.graphics.drawable.Animatable)d).start();
						mShouldStartAnimationDrawable = false;
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			lock (this)
			{
				android.graphics.drawable.Drawable d = mCurrentDrawable;
				int dw = 0;
				int dh = 0;
				if (d != null)
				{
					dw = System.Math.Max(mMinWidth, System.Math.Min(mMaxWidth, d.getIntrinsicWidth())
						);
					dh = System.Math.Max(mMinHeight, System.Math.Min(mMaxHeight, d.getIntrinsicHeight
						()));
				}
				updateDrawableState();
				dw += mPaddingLeft + mPaddingRight;
				dh += mPaddingTop + mPaddingBottom;
				setMeasuredDimension(resolveSizeAndState(dw, widthMeasureSpec, 0), resolveSizeAndState
					(dh, heightMeasureSpec, 0));
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			updateDrawableState();
		}

		private void updateDrawableState()
		{
			int[] state = getDrawableState();
			if (mProgressDrawable != null && mProgressDrawable.isStateful())
			{
				mProgressDrawable.setState(state);
			}
			if (mIndeterminateDrawable != null && mIndeterminateDrawable.isStateful())
			{
				mIndeterminateDrawable.setState(state);
			}
		}

		internal class SavedState : android.view.View.BaseSavedState
		{
			internal int progress;

			internal int secondaryProgress;

			/// <summary>
			/// Constructor called from
			/// <see cref="ProgressBar.onSaveInstanceState()">ProgressBar.onSaveInstanceState()</see>
			/// </summary>
			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			/// <summary>
			/// Constructor called from
			/// <see cref="CREATOR">CREATOR</see>
			/// </summary>
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				progress = @in.readInt();
				secondaryProgress = @in.readInt();
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeInt(progress);
				@out.writeInt(secondaryProgress);
			}

			private sealed class _Creator_1068 : android.os.ParcelableClass.Creator<android.widget.ProgressBar
				.SavedState>
			{
				public _Creator_1068()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ProgressBar.SavedState createFromParcel(android.os.Parcel @in
					)
				{
					return new android.widget.ProgressBar.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ProgressBar.SavedState[] newArray(int size)
				{
					return new android.widget.ProgressBar.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.ProgressBar
				.SavedState> CREATOR = new _Creator_1068();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			// Force our ancestor class to save its state
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.widget.ProgressBar.SavedState ss = new android.widget.ProgressBar.SavedState
				(superState);
			ss.progress = mProgress;
			ss.secondaryProgress = mSecondaryProgress;
			return ss;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.widget.ProgressBar.SavedState ss = (android.widget.ProgressBar.SavedState
				)state;
			base.onRestoreInstanceState(ss.getSuperState());
			setProgress(ss.progress);
			setSecondaryProgress(ss.secondaryProgress);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			if (mIndeterminate)
			{
				startAnimation();
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			if (mIndeterminate)
			{
				stopAnimation();
			}
			if (mRefreshProgressRunnable != null)
			{
				removeCallbacks(mRefreshProgressRunnable);
			}
			if (mAccessibilityEventSender != null)
			{
				removeCallbacks(mAccessibilityEventSender);
			}
			// This should come after stopAnimation(), otherwise an invalidate message remains in the
			// queue, which can prevent the entire view hierarchy from being GC'ed during a rotation
			base.onDetachedFromWindow();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onInitializeAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onInitializeAccessibilityEvent(@event);
			@event.setItemCount(mMax);
			@event.setCurrentItemIndex(mProgress);
		}

		/// <summary>Schedule a command for sending an accessibility event.</summary>
		/// <remarks>
		/// Schedule a command for sending an accessibility event.
		/// </br>
		/// Note: A command is used to ensure that accessibility events
		/// are sent at most one in a given time frame to save
		/// system resources while the progress changes quickly.
		/// </remarks>
		private void scheduleAccessibilityEventSender()
		{
			if (mAccessibilityEventSender == null)
			{
				mAccessibilityEventSender = new android.widget.ProgressBar.AccessibilityEventSender
					(this);
			}
			else
			{
				removeCallbacks(mAccessibilityEventSender);
			}
			postDelayed(mAccessibilityEventSender, TIMEOUT_SEND_ACCESSIBILITY_EVENT);
		}

		/// <summary>Command for sending an accessibility event.</summary>
		/// <remarks>Command for sending an accessibility event.</remarks>
		private class AccessibilityEventSender : java.lang.Runnable
		{
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.sendAccessibilityEvent(android.view.accessibility.AccessibilityEvent
					.TYPE_VIEW_SELECTED);
			}

			internal AccessibilityEventSender(ProgressBar _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ProgressBar _enclosing;
		}
	}
}
