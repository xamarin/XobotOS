using Sharpen;

namespace android.view.animation
{
	/// <summary>Represents a group of Animations that should be played together.</summary>
	/// <remarks>
	/// Represents a group of Animations that should be played together.
	/// The transformation of each individual animation are composed
	/// together into a single transform.
	/// If AnimationSet sets any properties that its children also set
	/// (for example, duration or fillBefore), the values of AnimationSet
	/// override the child values.
	/// <p>The way that AnimationSet inherits behavior from Animation is important to
	/// understand. Some of the Animation attributes applied to AnimationSet affect the
	/// AnimationSet itself, some are pushed down to the children, and some are ignored,
	/// as follows:
	/// <ul>
	/// <li>duration, repeatMode, fillBefore, fillAfter: These properties, when set
	/// on an AnimationSet object, will be pushed down to all child animations.</li>
	/// <li>repeatCount, fillEnabled: These properties are ignored for AnimationSet.</li>
	/// <li>startOffset, shareInterpolator: These properties apply to the AnimationSet itself.</li>
	/// </ul>
	/// Starting with
	/// <see cref="android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH">android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH
	/// 	</see>
	/// ,
	/// the behavior of these properties is the same in XML resources and at runtime (prior to that
	/// release, the values set in XML were ignored for AnimationSet). That is, calling
	/// <code>setDuration(500)</code> on an AnimationSet has the same effect as declaring
	/// <code>android:duration="500"</code> in an XML resource for an AnimationSet object.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public class AnimationSet : android.view.animation.Animation
	{
		internal const int PROPERTY_FILL_AFTER_MASK = unchecked((int)(0x1));

		internal const int PROPERTY_FILL_BEFORE_MASK = unchecked((int)(0x2));

		internal const int PROPERTY_REPEAT_MODE_MASK = unchecked((int)(0x4));

		internal const int PROPERTY_START_OFFSET_MASK = unchecked((int)(0x8));

		internal const int PROPERTY_SHARE_INTERPOLATOR_MASK = unchecked((int)(0x10));

		internal const int PROPERTY_DURATION_MASK = unchecked((int)(0x20));

		internal const int PROPERTY_MORPH_MATRIX_MASK = unchecked((int)(0x40));

		internal const int PROPERTY_CHANGE_BOUNDS_MASK = unchecked((int)(0x80));

		private int mFlags = 0;

		private bool mDirty;

		private bool mHasAlpha;

		private java.util.ArrayList<android.view.animation.Animation> mAnimations = new java.util.ArrayList
			<android.view.animation.Animation>();

		private android.view.animation.Transformation mTempTransformation = new android.view.animation.Transformation
			();

		private long mLastEnd;

		private long[] mStoredOffsets;

		/// <summary>Constructor used when an AnimationSet is loaded from a resource.</summary>
		/// <remarks>Constructor used when an AnimationSet is loaded from a resource.</remarks>
		/// <param name="context">Application context to use</param>
		/// <param name="attrs">Attribute set from which to read values</param>
		public AnimationSet(android.content.Context context, android.util.AttributeSet attrs
			) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AnimationSet);
			setFlag(PROPERTY_SHARE_INTERPOLATOR_MASK, a.getBoolean(android.@internal.R.styleable
				.AnimationSet_shareInterpolator, true));
			init();
			if (context.getApplicationInfo().targetSdkVersion >= android.os.Build.VERSION_CODES
				.ICE_CREAM_SANDWICH)
			{
				if (a.hasValue(android.@internal.R.styleable.AnimationSet_duration))
				{
					mFlags |= PROPERTY_DURATION_MASK;
				}
				if (a.hasValue(android.@internal.R.styleable.AnimationSet_fillBefore))
				{
					mFlags |= PROPERTY_FILL_BEFORE_MASK;
				}
				if (a.hasValue(android.@internal.R.styleable.AnimationSet_fillAfter))
				{
					mFlags |= PROPERTY_FILL_AFTER_MASK;
				}
				if (a.hasValue(android.@internal.R.styleable.AnimationSet_repeatMode))
				{
					mFlags |= PROPERTY_REPEAT_MODE_MASK;
				}
				if (a.hasValue(android.@internal.R.styleable.AnimationSet_startOffset))
				{
					mFlags |= PROPERTY_START_OFFSET_MASK;
				}
			}
			a.recycle();
		}

		/// <summary>Constructor to use when building an AnimationSet from code</summary>
		/// <param name="shareInterpolator">
		/// Pass true if all of the animations in this set
		/// should use the interpolator assocciated with this AnimationSet.
		/// Pass false if each animation should use its own interpolator.
		/// </param>
		public AnimationSet(bool shareInterpolator)
		{
			setFlag(PROPERTY_SHARE_INTERPOLATOR_MASK, shareInterpolator);
			init();
		}

		/// <exception cref="java.lang.CloneNotSupportedException"></exception>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		protected internal override android.view.animation.Animation clone()
		{
			android.view.animation.AnimationSet animation = (android.view.animation.AnimationSet
				)base.clone();
			animation.mTempTransformation = new android.view.animation.Transformation();
			animation.mAnimations = new java.util.ArrayList<android.view.animation.Animation>
				();
			int count = mAnimations.size();
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			{
				for (int i = 0; i < count; i++)
				{
					animation.mAnimations.add(animations.get(i).clone());
				}
			}
			return animation;
		}

		private void setFlag(int mask, bool value)
		{
			if (value)
			{
				mFlags |= mask;
			}
			else
			{
				mFlags &= ~mask;
			}
		}

		private void init()
		{
			mStartTime = 0;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setFillAfter(bool fillAfter)
		{
			mFlags |= PROPERTY_FILL_AFTER_MASK;
			base.setFillAfter(fillAfter);
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setFillBefore(bool fillBefore)
		{
			mFlags |= PROPERTY_FILL_BEFORE_MASK;
			base.setFillBefore(fillBefore);
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setRepeatMode(int repeatMode)
		{
			mFlags |= PROPERTY_REPEAT_MODE_MASK;
			base.setRepeatMode(repeatMode);
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setStartOffset(long startOffset)
		{
			mFlags |= PROPERTY_START_OFFSET_MASK;
			base.setStartOffset(startOffset);
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool hasAlpha()
		{
			if (mDirty)
			{
				mDirty = mHasAlpha = false;
				int count = mAnimations.size();
				java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
				{
					for (int i = 0; i < count; i++)
					{
						if (animations.get(i).hasAlpha())
						{
							mHasAlpha = true;
							break;
						}
					}
				}
			}
			return mHasAlpha;
		}

		/// <summary><p>Sets the duration of every child animation.</p></summary>
		/// <param name="durationMillis">
		/// the duration of the animation, in milliseconds, for
		/// every child in this set
		/// </param>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setDuration(long durationMillis)
		{
			mFlags |= PROPERTY_DURATION_MASK;
			base.setDuration(durationMillis);
			mLastEnd = mStartOffset + mDuration;
		}

		/// <summary>Add a child animation to this animation set.</summary>
		/// <remarks>
		/// Add a child animation to this animation set.
		/// The transforms of the child animations are applied in the order
		/// that they were added
		/// </remarks>
		/// <param name="a">Animation to add.</param>
		public virtual void addAnimation(android.view.animation.Animation a)
		{
			mAnimations.add(a);
			bool noMatrix = (mFlags & PROPERTY_MORPH_MATRIX_MASK) == 0;
			if (noMatrix && a.willChangeTransformationMatrix())
			{
				mFlags |= PROPERTY_MORPH_MATRIX_MASK;
			}
			bool changeBounds = (mFlags & PROPERTY_CHANGE_BOUNDS_MASK) == 0;
			if (changeBounds && a.willChangeTransformationMatrix())
			{
				mFlags |= PROPERTY_CHANGE_BOUNDS_MASK;
			}
			if ((mFlags & PROPERTY_DURATION_MASK) == PROPERTY_DURATION_MASK)
			{
				mLastEnd = mStartOffset + mDuration;
			}
			else
			{
				if (mAnimations.size() == 1)
				{
					mDuration = a.getStartOffset() + a.getDuration();
					mLastEnd = mStartOffset + mDuration;
				}
				else
				{
					mLastEnd = System.Math.Max(mLastEnd, a.getStartOffset() + a.getDuration());
					mDuration = mLastEnd - mStartOffset;
				}
			}
			mDirty = true;
		}

		/// <summary>Sets the start time of this animation and all child animations</summary>
		/// <seealso cref="Animation.setStartTime(long)">Animation.setStartTime(long)</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void setStartTime(long startTimeMillis)
		{
			base.setStartTime(startTimeMillis);
			int count = mAnimations.size();
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.animation.Animation a = animations.get(i);
					a.setStartTime(startTimeMillis);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override long getStartTime()
		{
			long startTime = long.MaxValue;
			int count = mAnimations.size();
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.animation.Animation a = animations.get(i);
					startTime = System.Math.Min(startTime, a.getStartTime());
				}
			}
			return startTime;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void restrictDuration(long durationMillis)
		{
			base.restrictDuration(durationMillis);
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			int count = animations.size();
			{
				for (int i = 0; i < count; i++)
				{
					animations.get(i).restrictDuration(durationMillis);
				}
			}
		}

		/// <summary>
		/// The duration of an AnimationSet is defined to be the
		/// duration of the longest child animation.
		/// </summary>
		/// <remarks>
		/// The duration of an AnimationSet is defined to be the
		/// duration of the longest child animation.
		/// </remarks>
		/// <seealso cref="Animation.getDuration()">Animation.getDuration()</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override long getDuration()
		{
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			int count = animations.size();
			long duration = 0;
			bool durationSet = (mFlags & PROPERTY_DURATION_MASK) == PROPERTY_DURATION_MASK;
			if (durationSet)
			{
				duration = mDuration;
			}
			else
			{
				{
					for (int i = 0; i < count; i++)
					{
						duration = System.Math.Max(duration, animations.get(i).getDuration());
					}
				}
			}
			return duration;
		}

		/// <summary>
		/// The duration hint of an animation set is the maximum of the duration
		/// hints of all of its component animations.
		/// </summary>
		/// <remarks>
		/// The duration hint of an animation set is the maximum of the duration
		/// hints of all of its component animations.
		/// </remarks>
		/// <seealso cref="Animation.computeDurationHint()">Animation.computeDurationHint()</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override long computeDurationHint()
		{
			long duration = 0;
			int count = mAnimations.size();
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			{
				for (int i = count - 1; i >= 0; --i)
				{
					long d = animations.get(i).computeDurationHint();
					if (d > duration)
					{
						duration = d;
					}
				}
			}
			return duration;
		}

		/// <hide></hide>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void initializeInvalidateRegion(int left, int top, int right, int
			 bottom)
		{
			android.graphics.RectF region = mPreviousRegion;
			region.set(left, top, right, bottom);
			region.inset(-1.0f, -1.0f);
			if (mFillBefore)
			{
				int count = mAnimations.size();
				java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
				android.view.animation.Transformation temp = mTempTransformation;
				android.view.animation.Transformation previousTransformation = mPreviousTransformation;
				{
					for (int i = count - 1; i >= 0; --i)
					{
						android.view.animation.Animation a = animations.get(i);
						temp.clear();
						android.view.animation.Interpolator interpolator = a.mInterpolator;
						a.applyTransformation(interpolator != null ? interpolator.getInterpolation(0.0f) : 
							0.0f, temp);
						previousTransformation.compose(temp);
					}
				}
			}
		}

		/// <summary>
		/// The transformation of an animation set is the concatenation of all of its
		/// component animations.
		/// </summary>
		/// <remarks>
		/// The transformation of an animation set is the concatenation of all of its
		/// component animations.
		/// </remarks>
		/// <seealso cref="Animation.getTransformation(long, Transformation)">Animation.getTransformation(long, Transformation)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool getTransformation(long currentTime, android.view.animation.Transformation
			 t)
		{
			int count = mAnimations.size();
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			android.view.animation.Transformation temp = mTempTransformation;
			bool more = false;
			bool started = false;
			bool ended = true;
			t.clear();
			{
				for (int i = count - 1; i >= 0; --i)
				{
					android.view.animation.Animation a = animations.get(i);
					temp.clear();
					more = a.getTransformation(currentTime, temp, getScaleFactor()) || more;
					t.compose(temp);
					started = started || a.hasStarted();
					ended = a.hasEnded() && ended;
				}
			}
			if (started && !mStarted)
			{
				if (mListener != null)
				{
					mListener.onAnimationStart(this);
				}
				mStarted = true;
			}
			if (ended != mEnded)
			{
				if (mListener != null)
				{
					mListener.onAnimationEnd(this);
				}
				mEnded = ended;
			}
			return more;
		}

		/// <seealso cref="Animation.scaleCurrentDuration(float)">Animation.scaleCurrentDuration(float)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void scaleCurrentDuration(float scale)
		{
			java.util.ArrayList<android.view.animation.Animation> animations = mAnimations;
			int count = animations.size();
			{
				for (int i = 0; i < count; i++)
				{
					animations.get(i).scaleCurrentDuration(scale);
				}
			}
		}

		/// <seealso cref="Animation.initialize(int, int, int, int)">Animation.initialize(int, int, int, int)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void initialize(int width, int height, int parentWidth, int parentHeight
			)
		{
			base.initialize(width, height, parentWidth, parentHeight);
			bool durationSet = (mFlags & PROPERTY_DURATION_MASK) == PROPERTY_DURATION_MASK;
			bool fillAfterSet = (mFlags & PROPERTY_FILL_AFTER_MASK) == PROPERTY_FILL_AFTER_MASK;
			bool fillBeforeSet = (mFlags & PROPERTY_FILL_BEFORE_MASK) == PROPERTY_FILL_BEFORE_MASK;
			bool repeatModeSet = (mFlags & PROPERTY_REPEAT_MODE_MASK) == PROPERTY_REPEAT_MODE_MASK;
			bool shareInterpolator = (mFlags & PROPERTY_SHARE_INTERPOLATOR_MASK) == PROPERTY_SHARE_INTERPOLATOR_MASK;
			bool startOffsetSet = (mFlags & PROPERTY_START_OFFSET_MASK) == PROPERTY_START_OFFSET_MASK;
			if (shareInterpolator)
			{
				ensureInterpolator();
			}
			java.util.ArrayList<android.view.animation.Animation> children = mAnimations;
			int count = children.size();
			long duration = mDuration;
			bool fillAfter = mFillAfter;
			bool fillBefore = mFillBefore;
			int repeatMode = mRepeatMode;
			android.view.animation.Interpolator interpolator = mInterpolator;
			long startOffset = mStartOffset;
			long[] storedOffsets = mStoredOffsets;
			if (startOffsetSet)
			{
				if (storedOffsets == null || storedOffsets.Length != count)
				{
					storedOffsets = mStoredOffsets = new long[count];
				}
			}
			else
			{
				if (storedOffsets != null)
				{
					storedOffsets = mStoredOffsets = null;
				}
			}
			{
				for (int i = 0; i < count; i++)
				{
					android.view.animation.Animation a = children.get(i);
					if (durationSet)
					{
						a.setDuration(duration);
					}
					if (fillAfterSet)
					{
						a.setFillAfter(fillAfter);
					}
					if (fillBeforeSet)
					{
						a.setFillBefore(fillBefore);
					}
					if (repeatModeSet)
					{
						a.setRepeatMode(repeatMode);
					}
					if (shareInterpolator)
					{
						a.setInterpolator(interpolator);
					}
					if (startOffsetSet)
					{
						long offset = a.getStartOffset();
						a.setStartOffset(offset + startOffset);
						storedOffsets[i] = offset;
					}
					a.initialize(width, height, parentWidth, parentHeight);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override void reset()
		{
			base.reset();
			restoreChildrenStartOffset();
		}

		/// <hide></hide>
		internal virtual void restoreChildrenStartOffset()
		{
			long[] offsets = mStoredOffsets;
			if (offsets == null)
			{
				return;
			}
			java.util.ArrayList<android.view.animation.Animation> children = mAnimations;
			int count = children.size();
			{
				for (int i = 0; i < count; i++)
				{
					children.get(i).setStartOffset(offsets[i]);
				}
			}
		}

		/// <returns>
		/// All the child animations in this AnimationSet. Note that
		/// this may include other AnimationSets, which are not expanded.
		/// </returns>
		public virtual java.util.List<android.view.animation.Animation> getAnimations()
		{
			return mAnimations;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool willChangeTransformationMatrix()
		{
			return (mFlags & PROPERTY_MORPH_MATRIX_MASK) == PROPERTY_MORPH_MATRIX_MASK;
		}

		[Sharpen.OverridesMethod(@"android.view.animation.Animation")]
		public override bool willChangeBounds()
		{
			return (mFlags & PROPERTY_CHANGE_BOUNDS_MASK) == PROPERTY_CHANGE_BOUNDS_MASK;
		}
	}
}
