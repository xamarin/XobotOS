using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Base class for a
	/// <see cref="FrameLayout">FrameLayout</see>
	/// container that will perform animations
	/// when switching between its views.
	/// </summary>
	/// <attr>ref android.R.styleable#ViewAnimator_inAnimation</attr>
	/// <attr>ref android.R.styleable#ViewAnimator_outAnimation</attr>
	/// <attr>ref android.R.styleable#ViewAnimator_animateFirstView</attr>
	[Sharpen.Sharpened]
	public class ViewAnimator : android.widget.FrameLayout
	{
		internal int mWhichChild = 0;

		internal bool mFirstTime = true;

		internal bool mAnimateFirstTime = true;

		internal android.view.animation.Animation mInAnimation;

		internal android.view.animation.Animation mOutAnimation;

		public ViewAnimator(android.content.Context context) : base(context)
		{
			initViewAnimator(context, null);
		}

		public ViewAnimator(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.ViewAnimator);
			int resource = a.getResourceId(android.@internal.R.styleable.ViewAnimator_inAnimation
				, 0);
			if (resource > 0)
			{
				setInAnimation(context, resource);
			}
			resource = a.getResourceId(android.@internal.R.styleable.ViewAnimator_outAnimation
				, 0);
			if (resource > 0)
			{
				setOutAnimation(context, resource);
			}
			bool flag = a.getBoolean(android.@internal.R.styleable.ViewAnimator_animateFirstView
				, true);
			setAnimateFirstView(flag);
			a.recycle();
			initViewAnimator(context, attrs);
		}

		/// <summary>
		/// Initialize this
		/// <see cref="ViewAnimator">ViewAnimator</see>
		/// , possibly setting
		/// <see cref="FrameLayout.setMeasureAllChildren(bool)">FrameLayout.setMeasureAllChildren(bool)
		/// 	</see>
		/// based on
		/// <see cref="FrameLayout">FrameLayout</see>
		/// flags.
		/// </summary>
		private void initViewAnimator(android.content.Context context, android.util.AttributeSet
			 attrs)
		{
			if (attrs == null)
			{
				// For compatibility, always measure children when undefined.
				mMeasureAllChildren = true;
				return;
			}
			// For compatibility, default to measure children, but allow XML
			// attribute to override.
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.FrameLayout);
			bool measureAllChildren = a.getBoolean(android.@internal.R.styleable.FrameLayout_measureAllChildren
				, true);
			setMeasureAllChildren(measureAllChildren);
			a.recycle();
		}

		/// <summary>Sets which child view will be displayed.</summary>
		/// <remarks>Sets which child view will be displayed.</remarks>
		/// <param name="whichChild">the index of the child view to display</param>
		[android.view.RemotableViewMethod]
		public virtual void setDisplayedChild(int whichChild)
		{
			mWhichChild = whichChild;
			if (whichChild >= getChildCount())
			{
				mWhichChild = 0;
			}
			else
			{
				if (whichChild < 0)
				{
					mWhichChild = getChildCount() - 1;
				}
			}
			bool hasFocus_1 = getFocusedChild() != null;
			// This will clear old focus if we had it
			showOnly(mWhichChild);
			if (hasFocus_1)
			{
				// Try to retake focus if we had it
				requestFocus(FOCUS_FORWARD);
			}
		}

		/// <summary>Returns the index of the currently displayed child view.</summary>
		/// <remarks>Returns the index of the currently displayed child view.</remarks>
		public virtual int getDisplayedChild()
		{
			return mWhichChild;
		}

		/// <summary>Manually shows the next child.</summary>
		/// <remarks>Manually shows the next child.</remarks>
		[android.view.RemotableViewMethod]
		public virtual void showNext()
		{
			setDisplayedChild(mWhichChild + 1);
		}

		/// <summary>Manually shows the previous child.</summary>
		/// <remarks>Manually shows the previous child.</remarks>
		[android.view.RemotableViewMethod]
		public virtual void showPrevious()
		{
			setDisplayedChild(mWhichChild - 1);
		}

		/// <summary>Shows only the specified child.</summary>
		/// <remarks>
		/// Shows only the specified child. The other displays Views exit the screen,
		/// optionally with the with the
		/// <see cref="getOutAnimation()">out animation</see>
		/// and
		/// the specified child enters the screen, optionally with the
		/// <see cref="getInAnimation()">in animation</see>
		/// .
		/// </remarks>
		/// <param name="childIndex">The index of the child to be shown.</param>
		/// <param name="animate">
		/// Whether or not to use the in and out animations, defaults
		/// to true.
		/// </param>
		internal virtual void showOnly(int childIndex, bool animate_1)
		{
			int count = getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = getChildAt(i);
					if (i == childIndex)
					{
						if (animate_1 && mInAnimation != null)
						{
							child.startAnimation(mInAnimation);
						}
						child.setVisibility(android.view.View.VISIBLE);
						mFirstTime = false;
					}
					else
					{
						if (animate_1 && mOutAnimation != null && child.getVisibility() == android.view.View
							.VISIBLE)
						{
							child.startAnimation(mOutAnimation);
						}
						else
						{
							if (child.getAnimation() == mInAnimation)
							{
								child.clearAnimation();
							}
						}
						child.setVisibility(android.view.View.GONE);
					}
				}
			}
		}

		/// <summary>Shows only the specified child.</summary>
		/// <remarks>
		/// Shows only the specified child. The other displays Views exit the screen
		/// with the
		/// <see cref="getOutAnimation()">out animation</see>
		/// and the specified child
		/// enters the screen with the
		/// <see cref="getInAnimation()">in animation</see>
		/// .
		/// </remarks>
		/// <param name="childIndex">The index of the child to be shown.</param>
		internal virtual void showOnly(int childIndex)
		{
			bool animate_1 = (!mFirstTime || mAnimateFirstTime);
			showOnly(childIndex, animate_1);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void addView(android.view.View child, int index, android.view.ViewGroup
			.LayoutParams @params)
		{
			base.addView(child, index, @params);
			if (getChildCount() == 1)
			{
				child.setVisibility(android.view.View.VISIBLE);
			}
			else
			{
				child.setVisibility(android.view.View.GONE);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeAllViews()
		{
			base.removeAllViews();
			mWhichChild = 0;
			mFirstTime = true;
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeView(android.view.View view)
		{
			int index = indexOfChild(view);
			if (index >= 0)
			{
				removeViewAt(index);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeViewAt(int index)
		{
			base.removeViewAt(index);
			int childCount = getChildCount();
			if (childCount == 0)
			{
				mWhichChild = 0;
				mFirstTime = true;
			}
			else
			{
				if (mWhichChild >= childCount)
				{
					// Displayed is above child count, so float down to top of stack
					setDisplayedChild(childCount - 1);
				}
				else
				{
					if (mWhichChild == index)
					{
						// Displayed was removed, so show the new child living in its place
						setDisplayedChild(mWhichChild);
					}
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeViewInLayout(android.view.View view)
		{
			removeView(view);
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeViews(int start, int count)
		{
			base.removeViews(start, count);
			if (getChildCount() == 0)
			{
				mWhichChild = 0;
				mFirstTime = true;
			}
			else
			{
				if (mWhichChild >= start && mWhichChild < start + count)
				{
					// Try showing new displayed child, wrapping if needed
					setDisplayedChild(mWhichChild);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override void removeViewsInLayout(int start, int count)
		{
			removeViews(start, count);
		}

		/// <summary>Returns the View corresponding to the currently displayed child.</summary>
		/// <remarks>Returns the View corresponding to the currently displayed child.</remarks>
		/// <returns>The View currently displayed.</returns>
		/// <seealso cref="getDisplayedChild()">getDisplayedChild()</seealso>
		public virtual android.view.View getCurrentView()
		{
			return getChildAt(mWhichChild);
		}

		/// <summary>Returns the current animation used to animate a View that enters the screen.
		/// 	</summary>
		/// <remarks>Returns the current animation used to animate a View that enters the screen.
		/// 	</remarks>
		/// <returns>An Animation or null if none is set.</returns>
		/// <seealso cref="setInAnimation(android.view.animation.Animation)">setInAnimation(android.view.animation.Animation)
		/// 	</seealso>
		/// <seealso cref="setInAnimation(android.content.Context, int)">setInAnimation(android.content.Context, int)
		/// 	</seealso>
		public virtual android.view.animation.Animation getInAnimation()
		{
			return mInAnimation;
		}

		/// <summary>Specifies the animation used to animate a View that enters the screen.</summary>
		/// <remarks>Specifies the animation used to animate a View that enters the screen.</remarks>
		/// <param name="inAnimation">The animation started when a View enters the screen.</param>
		/// <seealso cref="getInAnimation()">getInAnimation()</seealso>
		/// <seealso cref="setInAnimation(android.content.Context, int)">setInAnimation(android.content.Context, int)
		/// 	</seealso>
		public virtual void setInAnimation(android.view.animation.Animation inAnimation)
		{
			mInAnimation = inAnimation;
		}

		/// <summary>Returns the current animation used to animate a View that exits the screen.
		/// 	</summary>
		/// <remarks>Returns the current animation used to animate a View that exits the screen.
		/// 	</remarks>
		/// <returns>An Animation or null if none is set.</returns>
		/// <seealso cref="setOutAnimation(android.view.animation.Animation)">setOutAnimation(android.view.animation.Animation)
		/// 	</seealso>
		/// <seealso cref="setOutAnimation(android.content.Context, int)">setOutAnimation(android.content.Context, int)
		/// 	</seealso>
		public virtual android.view.animation.Animation getOutAnimation()
		{
			return mOutAnimation;
		}

		/// <summary>Specifies the animation used to animate a View that exit the screen.</summary>
		/// <remarks>Specifies the animation used to animate a View that exit the screen.</remarks>
		/// <param name="outAnimation">The animation started when a View exit the screen.</param>
		/// <seealso cref="getOutAnimation()">getOutAnimation()</seealso>
		/// <seealso cref="setOutAnimation(android.content.Context, int)">setOutAnimation(android.content.Context, int)
		/// 	</seealso>
		public virtual void setOutAnimation(android.view.animation.Animation outAnimation
			)
		{
			mOutAnimation = outAnimation;
		}

		/// <summary>Specifies the animation used to animate a View that enters the screen.</summary>
		/// <remarks>Specifies the animation used to animate a View that enters the screen.</remarks>
		/// <param name="context">The application's environment.</param>
		/// <param name="resourceID">The resource id of the animation.</param>
		/// <seealso cref="getInAnimation()">getInAnimation()</seealso>
		/// <seealso cref="setInAnimation(android.view.animation.Animation)">setInAnimation(android.view.animation.Animation)
		/// 	</seealso>
		public virtual void setInAnimation(android.content.Context context, int resourceID
			)
		{
			setInAnimation(android.view.animation.AnimationUtils.loadAnimation(context, resourceID
				));
		}

		/// <summary>Specifies the animation used to animate a View that exit the screen.</summary>
		/// <remarks>Specifies the animation used to animate a View that exit the screen.</remarks>
		/// <param name="context">The application's environment.</param>
		/// <param name="resourceID">The resource id of the animation.</param>
		/// <seealso cref="getOutAnimation()">getOutAnimation()</seealso>
		/// <seealso cref="setOutAnimation(android.view.animation.Animation)">setOutAnimation(android.view.animation.Animation)
		/// 	</seealso>
		public virtual void setOutAnimation(android.content.Context context, int resourceID
			)
		{
			setOutAnimation(android.view.animation.AnimationUtils.loadAnimation(context, resourceID
				));
		}

		/// <summary>
		/// Indicates whether the current View should be animated the first time
		/// the ViewAnimation is displayed.
		/// </summary>
		/// <remarks>
		/// Indicates whether the current View should be animated the first time
		/// the ViewAnimation is displayed.
		/// </remarks>
		/// <param name="animate">
		/// True to animate the current View the first time it is displayed,
		/// false otherwise.
		/// </param>
		public virtual void setAnimateFirstView(bool animate_1)
		{
			mAnimateFirstTime = animate_1;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			return (getCurrentView() != null) ? getCurrentView().getBaseline() : base.getBaseline
				();
		}
	}
}
