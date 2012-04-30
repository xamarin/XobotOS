using Sharpen;

namespace android.view.animation
{
	/// <summary>
	/// A layout animation controller is used to animated a layout's, or a view
	/// group's, children.
	/// </summary>
	/// <remarks>
	/// A layout animation controller is used to animated a layout's, or a view
	/// group's, children. Each child uses the same animation but for every one of
	/// them, the animation starts at a different time. A layout animation controller
	/// is used by
	/// <see cref="android.view.ViewGroup">android.view.ViewGroup</see>
	/// to compute the delay by which each
	/// child's animation start must be offset. The delay is computed by using
	/// characteristics of each child, like its index in the view group.
	/// This standard implementation computes the delay by multiplying a fixed
	/// amount of miliseconds by the index of the child in its parent view group.
	/// Subclasses are supposed to override
	/// <see cref="getDelayForView(android.view.View)">getDelayForView(android.view.View)
	/// 	</see>
	/// to implement a different way
	/// of computing the delay. For instance, a
	/// <see cref="GridLayoutAnimationController">GridLayoutAnimationController</see>
	/// will compute the
	/// delay based on the column and row indices of the child in its parent view
	/// group.
	/// Information used to compute the animation delay of each child are stored
	/// in an instance of
	/// <see cref="AnimationParameters">AnimationParameters</see>
	/// ,
	/// itself stored in the
	/// <see cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
	/// 	</see>
	/// of the view.
	/// </remarks>
	/// <attr>ref android.R.styleable#LayoutAnimation_delay</attr>
	/// <attr>ref android.R.styleable#LayoutAnimation_animationOrder</attr>
	/// <attr>ref android.R.styleable#LayoutAnimation_interpolator</attr>
	/// <attr>ref android.R.styleable#LayoutAnimation_animation</attr>
	[Sharpen.Sharpened]
	public class LayoutAnimationController
	{
		/// <summary>
		/// Distributes the animation delays in the order in which view were added
		/// to their view group.
		/// </summary>
		/// <remarks>
		/// Distributes the animation delays in the order in which view were added
		/// to their view group.
		/// </remarks>
		public const int ORDER_NORMAL = 0;

		/// <summary>
		/// Distributes the animation delays in the reverse order in which view were
		/// added to their view group.
		/// </summary>
		/// <remarks>
		/// Distributes the animation delays in the reverse order in which view were
		/// added to their view group.
		/// </remarks>
		public const int ORDER_REVERSE = 1;

		/// <summary>Randomly distributes the animation delays.</summary>
		/// <remarks>Randomly distributes the animation delays.</remarks>
		public const int ORDER_RANDOM = 2;

		/// <summary>
		/// The animation applied on each child of the view group on which this
		/// layout animation controller is set.
		/// </summary>
		/// <remarks>
		/// The animation applied on each child of the view group on which this
		/// layout animation controller is set.
		/// </remarks>
		protected internal android.view.animation.Animation mAnimation;

		/// <summary>The randomizer used when the order is set to random.</summary>
		/// <remarks>
		/// The randomizer used when the order is set to random. Subclasses should
		/// use this object to avoid creating their own.
		/// </remarks>
		protected internal System.Random mRandomizer;

		/// <summary>The interpolator used to interpolate the delays.</summary>
		/// <remarks>The interpolator used to interpolate the delays.</remarks>
		protected internal android.view.animation.Interpolator mInterpolator;

		private float mDelay;

		private int mOrder;

		private long mDuration;

		private long mMaxDelay;

		/// <summary>Creates a new layout animation controller from external resources.</summary>
		/// <remarks>Creates a new layout animation controller from external resources.</remarks>
		/// <param name="context">
		/// the Context the view  group is running in, through which
		/// it can access the resources
		/// </param>
		/// <param name="attrs">
		/// the attributes of the XML tag that is inflating the
		/// layout animation controller
		/// </param>
		public LayoutAnimationController(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.LayoutAnimation);
			android.view.animation.Animation.Description d = android.view.animation.Animation
				.Description.parseValue(a.peekValue(android.@internal.R.styleable.LayoutAnimation_delay
				));
			mDelay = d.value;
			mOrder = a.getInt(android.@internal.R.styleable.LayoutAnimation_animationOrder, ORDER_NORMAL
				);
			int resource = a.getResourceId(android.@internal.R.styleable.LayoutAnimation_animation
				, 0);
			if (resource > 0)
			{
				setAnimation(context, resource);
			}
			resource = a.getResourceId(android.@internal.R.styleable.LayoutAnimation_interpolator
				, 0);
			if (resource > 0)
			{
				setInterpolator(context, resource);
			}
			a.recycle();
		}

		/// <summary>
		/// Creates a new layout animation controller with a delay of 50%
		/// and the specified animation.
		/// </summary>
		/// <remarks>
		/// Creates a new layout animation controller with a delay of 50%
		/// and the specified animation.
		/// </remarks>
		/// <param name="animation">the animation to use on each child of the view group</param>
		public LayoutAnimationController(android.view.animation.Animation animation) : this
			(animation, 0.5f)
		{
		}

		/// <summary>
		/// Creates a new layout animation controller with the specified delay
		/// and the specified animation.
		/// </summary>
		/// <remarks>
		/// Creates a new layout animation controller with the specified delay
		/// and the specified animation.
		/// </remarks>
		/// <param name="animation">the animation to use on each child of the view group</param>
		/// <param name="delay">the delay by which each child's animation must be offset</param>
		public LayoutAnimationController(android.view.animation.Animation animation, float
			 delay)
		{
			mDelay = delay;
			setAnimation(animation);
		}

		/// <summary>Returns the order used to compute the delay of each child's animation.</summary>
		/// <remarks>Returns the order used to compute the delay of each child's animation.</remarks>
		/// <returns>
		/// one of
		/// <see cref="ORDER_NORMAL">ORDER_NORMAL</see>
		/// ,
		/// <see cref="ORDER_REVERSE">ORDER_REVERSE</see>
		/// or
		/// <see>#ORDER_RANDOM)</see>
		/// </returns>
		/// <attr>ref android.R.styleable#LayoutAnimation_animationOrder</attr>
		public virtual int getOrder()
		{
			return mOrder;
		}

		/// <summary>Sets the order used to compute the delay of each child's animation.</summary>
		/// <remarks>Sets the order used to compute the delay of each child's animation.</remarks>
		/// <param name="order">
		/// one of
		/// <see cref="ORDER_NORMAL">ORDER_NORMAL</see>
		/// ,
		/// <see cref="ORDER_REVERSE">ORDER_REVERSE</see>
		/// or
		/// <see cref="ORDER_RANDOM">ORDER_RANDOM</see>
		/// </param>
		/// <attr>ref android.R.styleable#LayoutAnimation_animationOrder</attr>
		public virtual void setOrder(int order)
		{
			mOrder = order;
		}

		/// <summary>
		/// Sets the animation to be run on each child of the view group on which
		/// this layout animation controller is .
		/// </summary>
		/// <remarks>
		/// Sets the animation to be run on each child of the view group on which
		/// this layout animation controller is .
		/// </remarks>
		/// <param name="context">the context from which the animation must be inflated</param>
		/// <param name="resourceID">the resource identifier of the animation</param>
		/// <seealso cref="setAnimation(Animation)">setAnimation(Animation)</seealso>
		/// <seealso cref="getAnimation()"></seealso>
		/// <attr>ref android.R.styleable#LayoutAnimation_animation</attr>
		public virtual void setAnimation(android.content.Context context, int resourceID)
		{
			setAnimation(android.view.animation.AnimationUtils.loadAnimation(context, resourceID
				));
		}

		/// <summary>
		/// Sets the animation to be run on each child of the view group on which
		/// this layout animation controller is .
		/// </summary>
		/// <remarks>
		/// Sets the animation to be run on each child of the view group on which
		/// this layout animation controller is .
		/// </remarks>
		/// <param name="animation">the animation to run on each child of the view group</param>
		/// <seealso cref="setAnimation(android.content.Context, int)">setAnimation(android.content.Context, int)
		/// 	</seealso>
		/// <seealso cref="getAnimation()">getAnimation()</seealso>
		/// <attr>ref android.R.styleable#LayoutAnimation_animation</attr>
		public virtual void setAnimation(android.view.animation.Animation animation)
		{
			mAnimation = animation;
			mAnimation.setFillBefore(true);
		}

		/// <summary>
		/// Returns the animation applied to each child of the view group on which
		/// this controller is set.
		/// </summary>
		/// <remarks>
		/// Returns the animation applied to each child of the view group on which
		/// this controller is set.
		/// </remarks>
		/// <returns>
		/// an
		/// <see cref="Animation">Animation</see>
		/// instance
		/// </returns>
		/// <seealso cref="setAnimation(android.content.Context, int)">setAnimation(android.content.Context, int)
		/// 	</seealso>
		/// <seealso cref="setAnimation(Animation)">setAnimation(Animation)</seealso>
		public virtual android.view.animation.Animation getAnimation()
		{
			return mAnimation;
		}

		/// <summary>
		/// Sets the interpolator used to interpolate the delays between the
		/// children.
		/// </summary>
		/// <remarks>
		/// Sets the interpolator used to interpolate the delays between the
		/// children.
		/// </remarks>
		/// <param name="context">the context from which the interpolator must be inflated</param>
		/// <param name="resourceID">the resource identifier of the interpolator</param>
		/// <seealso cref="getInterpolator()">getInterpolator()</seealso>
		/// <seealso cref="setInterpolator(Interpolator)">setInterpolator(Interpolator)</seealso>
		/// <attr>ref android.R.styleable#LayoutAnimation_interpolator</attr>
		public virtual void setInterpolator(android.content.Context context, int resourceID
			)
		{
			setInterpolator(android.view.animation.AnimationUtils.loadInterpolator(context, resourceID
				));
		}

		/// <summary>
		/// Sets the interpolator used to interpolate the delays between the
		/// children.
		/// </summary>
		/// <remarks>
		/// Sets the interpolator used to interpolate the delays between the
		/// children.
		/// </remarks>
		/// <param name="interpolator">the interpolator</param>
		/// <seealso cref="getInterpolator()">getInterpolator()</seealso>
		/// <seealso cref="setInterpolator(Interpolator)">setInterpolator(Interpolator)</seealso>
		/// <attr>ref android.R.styleable#LayoutAnimation_interpolator</attr>
		public virtual void setInterpolator(android.view.animation.Interpolator interpolator
			)
		{
			mInterpolator = interpolator;
		}

		/// <summary>
		/// Returns the interpolator used to interpolate the delays between the
		/// children.
		/// </summary>
		/// <remarks>
		/// Returns the interpolator used to interpolate the delays between the
		/// children.
		/// </remarks>
		/// <returns>
		/// an
		/// <see cref="Interpolator">Interpolator</see>
		/// </returns>
		public virtual android.view.animation.Interpolator getInterpolator()
		{
			return mInterpolator;
		}

		/// <summary>Returns the delay by which the children's animation are offset.</summary>
		/// <remarks>
		/// Returns the delay by which the children's animation are offset. The
		/// delay is expressed as a fraction of the animation duration.
		/// </remarks>
		/// <returns>a fraction of the animation duration</returns>
		/// <seealso cref="setDelay(float)">setDelay(float)</seealso>
		public virtual float getDelay()
		{
			return mDelay;
		}

		/// <summary>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset.
		/// </summary>
		/// <remarks>
		/// Sets the delay, as a fraction of the animation duration, by which the
		/// children's animations are offset. The general formula is:
		/// <pre>
		/// child animation delay = child index * delay * animation duration
		/// </pre>
		/// </remarks>
		/// <param name="delay">a fraction of the animation duration</param>
		/// <seealso cref="getDelay()">getDelay()</seealso>
		public virtual void setDelay(float delay)
		{
			mDelay = delay;
		}

		/// <summary>Indicates whether two children's animations will overlap.</summary>
		/// <remarks>
		/// Indicates whether two children's animations will overlap. Animations
		/// overlap when the delay is lower than 100% (or 1.0).
		/// </remarks>
		/// <returns>true if animations will overlap, false otherwise</returns>
		public virtual bool willOverlap()
		{
			return mDelay < 1.0f;
		}

		/// <summary>Starts the animation.</summary>
		/// <remarks>Starts the animation.</remarks>
		public virtual void start()
		{
			mDuration = mAnimation.getDuration();
			mMaxDelay = long.MinValue;
			mAnimation.setStartTime(-1);
		}

		/// <summary>Returns the animation to be applied to the specified view.</summary>
		/// <remarks>
		/// Returns the animation to be applied to the specified view. The returned
		/// animation is delayed by an offset computed according to the information
		/// provided by
		/// <see cref="AnimationParameters">AnimationParameters</see>
		/// .
		/// This method is called by view groups to obtain the animation to set on
		/// a specific child.
		/// </remarks>
		/// <param name="view">the view to animate</param>
		/// <returns>
		/// an animation delayed by the number of milliseconds returned by
		/// <see cref="getDelayForView(android.view.View)">getDelayForView(android.view.View)
		/// 	</see>
		/// </returns>
		/// <seealso cref="getDelay()">getDelay()</seealso>
		/// <seealso cref="setDelay(float)">setDelay(float)</seealso>
		/// <seealso cref="getDelayForView(android.view.View)">getDelayForView(android.view.View)
		/// 	</seealso>
		public android.view.animation.Animation getAnimationForView(android.view.View view
			)
		{
			long delay = getDelayForView(view) + mAnimation.getStartOffset();
			mMaxDelay = System.Math.Max(mMaxDelay, delay);
			android.view.animation.Animation animation = mAnimation.clone();
			animation.setStartOffset(delay);
			return animation;
		}

		/// <summary>Indicates whether the layout animation is over or not.</summary>
		/// <remarks>
		/// Indicates whether the layout animation is over or not. A layout animation
		/// is considered done when the animation with the longest delay is done.
		/// </remarks>
		/// <returns>true if all of the children's animations are over, false otherwise</returns>
		public virtual bool isDone()
		{
			return android.view.animation.AnimationUtils.currentAnimationTimeMillis() > mAnimation
				.getStartTime() + mMaxDelay + mDuration;
		}

		/// <summary>
		/// Returns the amount of milliseconds by which the specified view's
		/// animation must be delayed or offset.
		/// </summary>
		/// <remarks>
		/// Returns the amount of milliseconds by which the specified view's
		/// animation must be delayed or offset. Subclasses should override this
		/// method to return a suitable value.
		/// This implementation returns <code>child animation delay</code>
		/// milliseconds where:
		/// <pre>
		/// child animation delay = child index * delay
		/// </pre>
		/// The index is retrieved from the
		/// <see cref="AnimationParameters">AnimationParameters</see>
		/// found in the view's
		/// <see cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="view">the view for which to obtain the animation's delay</param>
		/// <returns>a delay in milliseconds</returns>
		/// <seealso cref="getAnimationForView(android.view.View)">getAnimationForView(android.view.View)
		/// 	</seealso>
		/// <seealso cref="getDelay()">getDelay()</seealso>
		/// <seealso cref="getTransformedIndex(AnimationParameters)">getTransformedIndex(AnimationParameters)
		/// 	</seealso>
		/// <seealso cref="android.view.ViewGroup.LayoutParams">android.view.ViewGroup.LayoutParams
		/// 	</seealso>
		protected internal virtual long getDelayForView(android.view.View view)
		{
			android.view.ViewGroup.LayoutParams lp = view.getLayoutParams();
			android.view.animation.LayoutAnimationController.AnimationParameters @params = lp
				.layoutAnimationParameters;
			if (@params == null)
			{
				return 0;
			}
			float delay = mDelay * mAnimation.getDuration();
			long viewDelay = (long)(getTransformedIndex(@params) * delay);
			float totalDelay = delay * @params.count;
			if (mInterpolator == null)
			{
				mInterpolator = new android.view.animation.LinearInterpolator();
			}
			float normalizedDelay = viewDelay / totalDelay;
			normalizedDelay = mInterpolator.getInterpolation(normalizedDelay);
			return (long)(normalizedDelay * totalDelay);
		}

		/// <summary>
		/// Transforms the index stored in
		/// <see cref="AnimationParameters">AnimationParameters</see>
		/// by the order returned by
		/// <see cref="getOrder()">getOrder()</see>
		/// . Subclasses should override
		/// this method to provide additional support for other types of ordering.
		/// This method should be invoked by
		/// <see cref="getDelayForView(android.view.View)">getDelayForView(android.view.View)
		/// 	</see>
		/// prior to any computation.
		/// </summary>
		/// <param name="params">the animation parameters containing the index</param>
		/// <returns>a transformed index</returns>
		protected internal virtual int getTransformedIndex(android.view.animation.LayoutAnimationController
			.AnimationParameters @params)
		{
			switch (getOrder())
			{
				case ORDER_REVERSE:
				{
					return @params.count - 1 - @params.index;
				}

				case ORDER_RANDOM:
				{
					if (mRandomizer == null)
					{
						mRandomizer = new System.Random();
					}
					return (int)(@params.count * Sharpen.Util.Random_NextFloat(mRandomizer));
				}

				case ORDER_NORMAL:
				default:
				{
					return @params.index;
				}
			}
		}

		/// <summary>
		/// The set of parameters that has to be attached to each view contained in
		/// the view group animated by the layout animation controller.
		/// </summary>
		/// <remarks>
		/// The set of parameters that has to be attached to each view contained in
		/// the view group animated by the layout animation controller. These
		/// parameters are used to compute the start time of each individual view's
		/// animation.
		/// </remarks>
		public class AnimationParameters
		{
			/// <summary>
			/// The number of children in the view group containing the view to which
			/// these parameters are attached.
			/// </summary>
			/// <remarks>
			/// The number of children in the view group containing the view to which
			/// these parameters are attached.
			/// </remarks>
			public int count;

			/// <summary>
			/// The index of the view to which these parameters are attached in its
			/// containing view group.
			/// </summary>
			/// <remarks>
			/// The index of the view to which these parameters are attached in its
			/// containing view group.
			/// </remarks>
			public int index;
		}
	}
}
