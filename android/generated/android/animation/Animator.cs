using Sharpen;

namespace android.animation
{
	/// <summary>
	/// This is the superclass for classes which provide basic support for animations which can be
	/// started, ended, and have <code>AnimatorListeners</code> added to them.
	/// </summary>
	/// <remarks>
	/// This is the superclass for classes which provide basic support for animations which can be
	/// started, ended, and have <code>AnimatorListeners</code> added to them.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class Animator : System.ICloneable
	{
		/// <summary>The set of listeners to be sent events through the life of an animation.
		/// 	</summary>
		/// <remarks>The set of listeners to be sent events through the life of an animation.
		/// 	</remarks>
		internal java.util.ArrayList<android.animation.Animator.AnimatorListener> mListeners
			 = null;

		/// <summary>Starts this animation.</summary>
		/// <remarks>
		/// Starts this animation. If the animation has a nonzero startDelay, the animation will start
		/// running after that delay elapses. A non-delayed animation will have its initial
		/// value(s) set immediately, followed by calls to
		/// <see cref="AnimatorListener.onAnimationStart(Animator)">AnimatorListener.onAnimationStart(Animator)
		/// 	</see>
		/// for any listeners of this animator.
		/// <p>The animation started by calling this method will be run on the thread that called
		/// this method. This thread should have a Looper on it (a runtime exception will be thrown if
		/// this is not the case). Also, if the animation will animate
		/// properties of objects in the view hierarchy, then the calling thread should be the UI
		/// thread for that view hierarchy.</p>
		/// </remarks>
		public virtual void start()
		{
		}

		/// <summary>Cancels the animation.</summary>
		/// <remarks>
		/// Cancels the animation. Unlike
		/// <see cref="end()">end()</see>
		/// , <code>cancel()</code> causes the animation to
		/// stop in its tracks, sending an
		/// <see cref="AnimatorListener.onAnimationCancel(Animator)">AnimatorListener.onAnimationCancel(Animator)
		/// 	</see>
		/// to
		/// its listeners, followed by an
		/// <see cref="AnimatorListener.onAnimationEnd(Animator)">AnimatorListener.onAnimationEnd(Animator)
		/// 	</see>
		/// message.
		/// <p>This method must be called on the thread that is running the animation.</p>
		/// </remarks>
		public virtual void cancel()
		{
		}

		/// <summary>Ends the animation.</summary>
		/// <remarks>
		/// Ends the animation. This causes the animation to assign the end value of the property being
		/// animated, then calling the
		/// <see cref="AnimatorListener.onAnimationEnd(Animator)">AnimatorListener.onAnimationEnd(Animator)
		/// 	</see>
		/// method on
		/// its listeners.
		/// <p>This method must be called on the thread that is running the animation.</p>
		/// </remarks>
		public virtual void end()
		{
		}

		/// <summary>
		/// The amount of time, in milliseconds, to delay starting the animation after
		/// <see cref="start()">start()</see>
		/// is called.
		/// </summary>
		/// <returns>the number of milliseconds to delay running the animation</returns>
		public abstract long getStartDelay();

		/// <summary>
		/// The amount of time, in milliseconds, to delay starting the animation after
		/// <see cref="start()">start()</see>
		/// is called.
		/// </summary>
		/// <param name="startDelay">The amount of the delay, in milliseconds</param>
		public abstract void setStartDelay(long startDelay);

		/// <summary>Sets the length of the animation.</summary>
		/// <remarks>Sets the length of the animation.</remarks>
		/// <param name="duration">The length of the animation, in milliseconds.</param>
		public abstract android.animation.Animator setDuration(long duration);

		/// <summary>Gets the length of the animation.</summary>
		/// <remarks>Gets the length of the animation.</remarks>
		/// <returns>The length of the animation, in milliseconds.</returns>
		public abstract long getDuration();

		/// <summary>The time interpolator used in calculating the elapsed fraction of this animation.
		/// 	</summary>
		/// <remarks>
		/// The time interpolator used in calculating the elapsed fraction of this animation. The
		/// interpolator determines whether the animation runs with linear or non-linear motion,
		/// such as acceleration and deceleration. The default value is
		/// <see cref="android.view.animation.AccelerateDecelerateInterpolator">android.view.animation.AccelerateDecelerateInterpolator
		/// 	</see>
		/// </remarks>
		/// <param name="value">the interpolator to be used by this animation</param>
		public abstract void setInterpolator(android.animation.TimeInterpolator value);

		/// <summary>
		/// Returns whether this Animator is currently running (having been started and gone past any
		/// initial startDelay period and not yet ended).
		/// </summary>
		/// <remarks>
		/// Returns whether this Animator is currently running (having been started and gone past any
		/// initial startDelay period and not yet ended).
		/// </remarks>
		/// <returns>Whether the Animator is running.</returns>
		public abstract bool isRunning();

		/// <summary>Returns whether this Animator has been started and not yet ended.</summary>
		/// <remarks>
		/// Returns whether this Animator has been started and not yet ended. This state is a superset
		/// of the state of
		/// <see cref="isRunning()">isRunning()</see>
		/// , because an Animator with a nonzero
		/// <see cref="getStartDelay()">startDelay</see>
		/// will return true for
		/// <see cref="isStarted()">isStarted()</see>
		/// during the
		/// delay phase, whereas
		/// <see cref="isRunning()">isRunning()</see>
		/// will return true only after the delay phase
		/// is complete.
		/// </remarks>
		/// <returns>Whether the Animator has been started and not yet ended.</returns>
		public virtual bool isStarted()
		{
			// Default method returns value for isRunning(). Subclasses should override to return a
			// real value.
			return isRunning();
		}

		/// <summary>
		/// Adds a listener to the set of listeners that are sent events through the life of an
		/// animation, such as start, repeat, and end.
		/// </summary>
		/// <remarks>
		/// Adds a listener to the set of listeners that are sent events through the life of an
		/// animation, such as start, repeat, and end.
		/// </remarks>
		/// <param name="listener">the listener to be added to the current set of listeners for this animation.
		/// 	</param>
		public virtual void addListener(android.animation.Animator.AnimatorListener listener
			)
		{
			if (mListeners == null)
			{
				mListeners = new java.util.ArrayList<android.animation.Animator.AnimatorListener>
					();
			}
			mListeners.add(listener);
		}

		/// <summary>Removes a listener from the set listening to this animation.</summary>
		/// <remarks>Removes a listener from the set listening to this animation.</remarks>
		/// <param name="listener">
		/// the listener to be removed from the current set of listeners for this
		/// animation.
		/// </param>
		public virtual void removeListener(android.animation.Animator.AnimatorListener listener
			)
		{
			if (mListeners == null)
			{
				return;
			}
			mListeners.remove(listener);
			if (mListeners.size() == 0)
			{
				mListeners = null;
			}
		}

		/// <summary>
		/// Gets the set of
		/// <see cref="AnimatorListener">AnimatorListener</see>
		/// objects that are currently
		/// listening for events on this <code>Animator</code> object.
		/// </summary>
		/// <returns>ArrayList<AnimatorListener> The set of listeners.</returns>
		public virtual java.util.ArrayList<android.animation.Animator.AnimatorListener> getListeners
			()
		{
			return mListeners;
		}

		/// <summary>Removes all listeners from this object.</summary>
		/// <remarks>
		/// Removes all listeners from this object. This is equivalent to calling
		/// <code>getListeners()</code> followed by calling <code>clear()</code> on the
		/// returned list of listeners.
		/// </remarks>
		public virtual void removeAllListeners()
		{
			if (mListeners != null)
			{
				mListeners.clear();
				mListeners = null;
			}
		}

		public virtual android.animation.Animator clone()
		{
			android.animation.Animator anim = (android.animation.Animator)base.MemberwiseClone
				();
			if (mListeners != null)
			{
				java.util.ArrayList<android.animation.Animator.AnimatorListener> oldListeners = mListeners;
				anim.mListeners = new java.util.ArrayList<android.animation.Animator.AnimatorListener
					>();
				int numListeners = oldListeners.size();
				{
					for (int i = 0; i < numListeners; ++i)
					{
						anim.mListeners.add(oldListeners.get(i));
					}
				}
			}
			return anim;
		}

		/// <summary>
		/// This method tells the object to use appropriate information to extract
		/// starting values for the animation.
		/// </summary>
		/// <remarks>
		/// This method tells the object to use appropriate information to extract
		/// starting values for the animation. For example, a AnimatorSet object will pass
		/// this call to its child objects to tell them to set up the values. A
		/// ObjectAnimator object will use the information it has about its target object
		/// and PropertyValuesHolder objects to get the start values for its properties.
		/// An ValueAnimator object will ignore the request since it does not have enough
		/// information (such as a target object) to gather these values.
		/// </remarks>
		public virtual void setupStartValues()
		{
		}

		/// <summary>
		/// This method tells the object to use appropriate information to extract
		/// ending values for the animation.
		/// </summary>
		/// <remarks>
		/// This method tells the object to use appropriate information to extract
		/// ending values for the animation. For example, a AnimatorSet object will pass
		/// this call to its child objects to tell them to set up the values. A
		/// ObjectAnimator object will use the information it has about its target object
		/// and PropertyValuesHolder objects to get the start values for its properties.
		/// An ValueAnimator object will ignore the request since it does not have enough
		/// information (such as a target object) to gather these values.
		/// </remarks>
		public virtual void setupEndValues()
		{
		}

		/// <summary>Sets the target object whose property will be animated by this animation.
		/// 	</summary>
		/// <remarks>
		/// Sets the target object whose property will be animated by this animation. Not all subclasses
		/// operate on target objects (for example,
		/// <see cref="ValueAnimator">ValueAnimator</see>
		/// , but this method
		/// is on the superclass for the convenience of dealing generically with those subclasses
		/// that do handle targets.
		/// </remarks>
		/// <param name="target">The object being animated</param>
		public virtual void setTarget(object target)
		{
		}

		/// <summary><p>An animation listener receives notifications from an animation.</summary>
		/// <remarks>
		/// <p>An animation listener receives notifications from an animation.
		/// Notifications indicate animation related events, such as the end or the
		/// repetition of the animation.</p>
		/// </remarks>
		public interface AnimatorListener
		{
			/// <summary><p>Notifies the start of the animation.</p></summary>
			/// <param name="animation">The started animation.</param>
			void onAnimationStart(android.animation.Animator animation);

			/// <summary><p>Notifies the end of the animation.</summary>
			/// <remarks>
			/// <p>Notifies the end of the animation. This callback is not invoked
			/// for animations with repeat count set to INFINITE.</p>
			/// </remarks>
			/// <param name="animation">The animation which reached its end.</param>
			void onAnimationEnd(android.animation.Animator animation);

			/// <summary><p>Notifies the cancellation of the animation.</summary>
			/// <remarks>
			/// <p>Notifies the cancellation of the animation. This callback is not invoked
			/// for animations with repeat count set to INFINITE.</p>
			/// </remarks>
			/// <param name="animation">The animation which was canceled.</param>
			void onAnimationCancel(android.animation.Animator animation);

			/// <summary><p>Notifies the repetition of the animation.</p></summary>
			/// <param name="animation">The animation which was repeated.</param>
			void onAnimationRepeat(android.animation.Animator animation);
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
