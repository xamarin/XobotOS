using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// An extension of LayerDrawables that is intended to cross-fade between
	/// the first and second layer.
	/// </summary>
	/// <remarks>
	/// An extension of LayerDrawables that is intended to cross-fade between
	/// the first and second layer. To start the transition, call
	/// <see cref="startTransition(int)">startTransition(int)</see>
	/// . To
	/// display just the first layer, call
	/// <see cref="resetTransition()">resetTransition()</see>
	/// .
	/// <p>
	/// It can be defined in an XML file with the <code>&lt;transition&gt;</code> element.
	/// Each Drawable in the transition is defined in a nested <code>&lt;item&gt;</code>. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#LayerDrawableItem_left</attr>
	/// <attr>ref android.R.styleable#LayerDrawableItem_top</attr>
	/// <attr>ref android.R.styleable#LayerDrawableItem_right</attr>
	/// <attr>ref android.R.styleable#LayerDrawableItem_bottom</attr>
	/// <attr>ref android.R.styleable#LayerDrawableItem_drawable</attr>
	/// <attr>ref android.R.styleable#LayerDrawableItem_id</attr>
	[Sharpen.Sharpened]
	public class TransitionDrawable : android.graphics.drawable.LayerDrawable, android.graphics.drawable.Drawable
		.Callback
	{
		/// <summary>A transition is about to start.</summary>
		/// <remarks>A transition is about to start.</remarks>
		internal const int TRANSITION_STARTING = 0;

		/// <summary>The transition has started and the animation is in progress</summary>
		internal const int TRANSITION_RUNNING = 1;

		/// <summary>No transition will be applied</summary>
		internal const int TRANSITION_NONE = 2;

		/// <summary>The current state of the transition.</summary>
		/// <remarks>
		/// The current state of the transition. One of
		/// <see cref="TRANSITION_STARTING">TRANSITION_STARTING</see>
		/// ,
		/// <see cref="TRANSITION_RUNNING">TRANSITION_RUNNING</see>
		/// and
		/// <see cref="TRANSITION_NONE">TRANSITION_NONE</see>
		/// </remarks>
		private int mTransitionState = TRANSITION_NONE;

		private bool mReverse;

		private long mStartTimeMillis;

		private int mFrom;

		private int mTo;

		private int mDuration;

		private int mOriginalDuration;

		private int mAlpha = 0;

		private bool mCrossFade;

		/// <summary>Create a new transition drawable with the specified list of layers.</summary>
		/// <remarks>
		/// Create a new transition drawable with the specified list of layers. At least
		/// 2 layers are required for this drawable to work properly.
		/// </remarks>
		public TransitionDrawable(android.graphics.drawable.Drawable[] layers) : this(new 
			android.graphics.drawable.TransitionDrawable.TransitionState(null, null, null), 
			layers)
		{
		}

		/// <summary>Create a new transition drawable with no layer.</summary>
		/// <remarks>
		/// Create a new transition drawable with no layer. To work correctly, at least 2
		/// layers must be added to this drawable.
		/// </remarks>
		/// <seealso cref="TransitionDrawable(Drawable[])">TransitionDrawable(Drawable[])</seealso>
		internal TransitionDrawable() : this(new android.graphics.drawable.TransitionDrawable
			.TransitionState(null, null, null), (android.content.res.Resources)null)
		{
		}

		internal TransitionDrawable(android.graphics.drawable.TransitionDrawable.TransitionState
			 state, android.content.res.Resources res) : base(state, res)
		{
		}

		internal TransitionDrawable(android.graphics.drawable.TransitionDrawable.TransitionState
			 state, android.graphics.drawable.Drawable[] layers) : base(layers, state)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.LayerDrawable")]
		internal override android.graphics.drawable.LayerDrawable.LayerState createConstantState
			(android.graphics.drawable.LayerDrawable.LayerState state, android.content.res.Resources
			 res)
		{
			return new android.graphics.drawable.TransitionDrawable.TransitionState((android.graphics.drawable.TransitionDrawable
				.TransitionState)state, this, res);
		}

		/// <summary>Begin the second layer on top of the first layer.</summary>
		/// <remarks>Begin the second layer on top of the first layer.</remarks>
		/// <param name="durationMillis">The length of the transition in milliseconds</param>
		public virtual void startTransition(int durationMillis)
		{
			mFrom = 0;
			mTo = 255;
			mAlpha = 0;
			mDuration = mOriginalDuration = durationMillis;
			mReverse = false;
			mTransitionState = TRANSITION_STARTING;
			invalidateSelf();
		}

		/// <summary>Show only the first layer.</summary>
		/// <remarks>Show only the first layer.</remarks>
		public virtual void resetTransition()
		{
			mAlpha = 0;
			mTransitionState = TRANSITION_NONE;
			invalidateSelf();
		}

		/// <summary>Reverses the transition, picking up where the transition currently is.</summary>
		/// <remarks>
		/// Reverses the transition, picking up where the transition currently is.
		/// If the transition is not currently running, this will start the transition
		/// with the specified duration. If the transition is already running, the last
		/// known duration will be used.
		/// </remarks>
		/// <param name="duration">The duration to use if no transition is running.</param>
		public virtual void reverseTransition(int duration)
		{
			long time = android.os.SystemClock.uptimeMillis();
			// Animation is over
			if (time - mStartTimeMillis > mDuration)
			{
				if (mTo == 0)
				{
					mFrom = 0;
					mTo = 255;
					mAlpha = 0;
					mReverse = false;
				}
				else
				{
					mFrom = 255;
					mTo = 0;
					mAlpha = 255;
					mReverse = true;
				}
				mDuration = mOriginalDuration = duration;
				mTransitionState = TRANSITION_STARTING;
				invalidateSelf();
				return;
			}
			mReverse = !mReverse;
			mFrom = mAlpha;
			mTo = mReverse ? 0 : 255;
			mDuration = (int)(mReverse ? time - mStartTimeMillis : mOriginalDuration - (time 
				- mStartTimeMillis));
			mTransitionState = TRANSITION_STARTING;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			bool done = true;
			switch (mTransitionState)
			{
				case TRANSITION_STARTING:
				{
					mStartTimeMillis = android.os.SystemClock.uptimeMillis();
					done = false;
					mTransitionState = TRANSITION_RUNNING;
					break;
				}

				case TRANSITION_RUNNING:
				{
					if (mStartTimeMillis >= 0)
					{
						float normalized = (float)(android.os.SystemClock.uptimeMillis() - mStartTimeMillis
							) / mDuration;
						done = normalized >= 1.0f;
						normalized = System.Math.Min(normalized, 1.0f);
						mAlpha = (int)(mFrom + (mTo - mFrom) * normalized);
					}
					break;
				}
			}
			int alpha = mAlpha;
			bool crossFade = mCrossFade;
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			if (done)
			{
				// the setAlpha() calls below trigger invalidation and redraw. If we're done, just draw
				// the appropriate drawable[s] and return
				if (!crossFade || alpha == 0)
				{
					array[0].mDrawable.draw(canvas);
				}
				if (alpha == unchecked((int)(0xFF)))
				{
					array[1].mDrawable.draw(canvas);
				}
				return;
			}
			android.graphics.drawable.Drawable d;
			d = array[0].mDrawable;
			if (crossFade)
			{
				d.setAlpha(255 - alpha);
			}
			d.draw(canvas);
			if (crossFade)
			{
				d.setAlpha(unchecked((int)(0xFF)));
			}
			if (alpha > 0)
			{
				d = array[1].mDrawable;
				d.setAlpha(alpha);
				d.draw(canvas);
				d.setAlpha(unchecked((int)(0xFF)));
			}
			if (!done)
			{
				invalidateSelf();
			}
		}

		/// <summary>Enables or disables the cross fade of the drawables.</summary>
		/// <remarks>
		/// Enables or disables the cross fade of the drawables. When cross fade
		/// is disabled, the first drawable is always drawn opaque. With cross
		/// fade enabled, the first drawable is drawn with the opposite alpha of
		/// the second drawable. Cross fade is disabled by default.
		/// </remarks>
		/// <param name="enabled">True to enable cross fading, false otherwise.</param>
		public virtual void setCrossFadeEnabled(bool enabled)
		{
			mCrossFade = enabled;
		}

		/// <summary>Indicates whether the cross fade is enabled for this transition.</summary>
		/// <remarks>Indicates whether the cross fade is enabled for this transition.</remarks>
		/// <returns>True if cross fading is enabled, false otherwise.</returns>
		public virtual bool isCrossFadeEnabled()
		{
			return mCrossFade;
		}

		internal class TransitionState : android.graphics.drawable.LayerDrawable.LayerState
		{
			internal TransitionState(android.graphics.drawable.TransitionDrawable.TransitionState
				 orig, android.graphics.drawable.TransitionDrawable owner, android.content.res.Resources
				 res) : base(orig, owner, res)
			{
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.TransitionDrawable(this, (android.content.res.Resources
					)null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.TransitionDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}
		}
	}
}
