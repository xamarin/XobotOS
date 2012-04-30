using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// An object used to create frame-by-frame animations, defined by a series of Drawable objects,
	/// which can be used as a View object's background.
	/// </summary>
	/// <remarks>
	/// An object used to create frame-by-frame animations, defined by a series of Drawable objects,
	/// which can be used as a View object's background.
	/// <p>
	/// The simplest way to create a frame-by-frame animation is to define the animation in an XML
	/// file, placed in the res/drawable/ folder, and set it as the background to a View object. Then, call
	/// <see cref="start()">start()</see>
	/// to run the animation.
	/// <p>
	/// An AnimationDrawable defined in XML consists of a single <code>&lt;animation-list&gt;</code> element,
	/// and a series of nested <code>&lt;item&gt;</code> tags. Each item defines a frame of the animation.
	/// See the example below.
	/// </p>
	/// <p>spin_animation.xml file in res/drawable/ folder:</p>
	/// <pre>&lt;!-- Animation frames are wheel0.png -- wheel5.png files inside the
	/// res/drawable/ folder --&gt;
	/// &lt;animation-list android:id=&quot;selected&quot; android:oneshot=&quot;false&quot;&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel0&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel1&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel2&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel3&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel4&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;item android:drawable=&quot;@drawable/wheel5&quot; android:duration=&quot;50&quot; /&gt;
	/// &lt;/animation-list&gt;</pre>
	/// <p>Here is the code to load and play this animation.</p>
	/// <pre>
	/// // Load the ImageView that will host the animation and
	/// // set its background to our AnimationDrawable XML resource.
	/// ImageView img = (ImageView)findViewById(R.id.spinning_wheel_image);
	/// img.setBackgroundResource(R.drawable.spin_animation);
	/// // Get the background, which has been compiled to an AnimationDrawable object.
	/// AnimationDrawable frameAnimation = (AnimationDrawable) img.getBackground();
	/// // Start the animation (looped playback by default).
	/// frameAnimation.start();
	/// </pre>
	/// <p>For more information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/animation-resource.html"&gt;Animation Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#AnimationDrawable_visible</attr>
	/// <attr>ref android.R.styleable#AnimationDrawable_variablePadding</attr>
	/// <attr>ref android.R.styleable#AnimationDrawable_oneshot</attr>
	/// <attr>ref android.R.styleable#AnimationDrawableItem_duration</attr>
	/// <attr>ref android.R.styleable#AnimationDrawableItem_drawable</attr>
	[Sharpen.Sharpened]
	public class AnimationDrawable : android.graphics.drawable.DrawableContainer, java.lang.Runnable
		, android.graphics.drawable.Animatable
	{
		private readonly android.graphics.drawable.AnimationDrawable.AnimationState mAnimationState;

		private int mCurFrame = -1;

		private bool mMutated;

		public AnimationDrawable() : this(null, null)
		{
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			bool changed = base.setVisible(visible, restart);
			if (visible)
			{
				if (changed || restart)
				{
					setFrame(0, true, true);
				}
			}
			else
			{
				unscheduleSelf(this);
			}
			return changed;
		}

		/// <summary><p>Starts the animation, looping if necessary.</summary>
		/// <remarks>
		/// <p>Starts the animation, looping if necessary. This method has no effect
		/// if the animation is running.</p>
		/// </remarks>
		/// <seealso cref="isRunning()">isRunning()</seealso>
		/// <seealso cref="stop()">stop()</seealso>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual void start()
		{
			if (!isRunning())
			{
				run();
			}
		}

		/// <summary><p>Stops the animation.</summary>
		/// <remarks>
		/// <p>Stops the animation. This method has no effect if the animation is
		/// not running.</p>
		/// </remarks>
		/// <seealso cref="isRunning()">isRunning()</seealso>
		/// <seealso cref="start()">start()</seealso>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual void stop()
		{
			if (isRunning())
			{
				unscheduleSelf(this);
			}
		}

		/// <summary><p>Indicates whether the animation is currently running or not.</p></summary>
		/// <returns>true if the animation is running, false otherwise</returns>
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Animatable")]
		public virtual bool isRunning()
		{
			return mCurFrame > -1;
		}

		/// <summary>
		/// <p>This method exists for implementation purpose only and should not be
		/// called directly.
		/// </summary>
		/// <remarks>
		/// <p>This method exists for implementation purpose only and should not be
		/// called directly. Invoke
		/// <see cref="start()">start()</see>
		/// instead.</p>
		/// </remarks>
		/// <seealso cref="start()">start()</seealso>
		[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
		public virtual void run()
		{
			nextFrame(false);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void unscheduleSelf(java.lang.Runnable what)
		{
			mCurFrame = -1;
			base.unscheduleSelf(what);
		}

		/// <returns>The number of frames in the animation</returns>
		public virtual int getNumberOfFrames()
		{
			return mAnimationState.getChildCount();
		}

		/// <returns>The Drawable at the specified frame index</returns>
		public virtual android.graphics.drawable.Drawable getFrame(int index)
		{
			return mAnimationState.getChildren()[index];
		}

		/// <returns>
		/// The duration in milliseconds of the frame at the
		/// specified index
		/// </returns>
		public virtual int getDuration(int i)
		{
			return mAnimationState.mDurations[i];
		}

		/// <returns>True of the animation will play once, false otherwise</returns>
		public virtual bool isOneShot()
		{
			return mAnimationState.mOneShot;
		}

		/// <summary>Sets whether the animation should play once or repeat.</summary>
		/// <remarks>Sets whether the animation should play once or repeat.</remarks>
		/// <param name="oneShot">Pass true if the animation should only play once</param>
		public virtual void setOneShot(bool oneShot)
		{
			mAnimationState.mOneShot = oneShot;
		}

		/// <summary>Add a frame to the animation</summary>
		/// <param name="frame">The frame to add</param>
		/// <param name="duration">How long in milliseconds the frame should appear</param>
		public virtual void addFrame(android.graphics.drawable.Drawable frame, int duration
			)
		{
			mAnimationState.addFrame(frame, duration);
			if (mCurFrame < 0)
			{
				setFrame(0, true, false);
			}
		}

		private void nextFrame(bool unschedule)
		{
			int next = mCurFrame + 1;
			int N = mAnimationState.getChildCount();
			if (next >= N)
			{
				next = 0;
			}
			setFrame(next, unschedule, !mAnimationState.mOneShot || next < (N - 1));
		}

		private void setFrame(int frame, bool unschedule, bool animate_1)
		{
			if (frame >= mAnimationState.getChildCount())
			{
				return;
			}
			mCurFrame = frame;
			selectDrawable(frame);
			if (unschedule)
			{
				unscheduleSelf(this);
			}
			if (animate_1)
			{
				scheduleSelf(this, android.os.SystemClock.uptimeMillis() + mAnimationState.mDurations
					[frame]);
			}
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.AnimationDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.AnimationDrawable_visible
				);
			mAnimationState.setVariablePadding(a.getBoolean(android.@internal.R.styleable.AnimationDrawable_variablePadding
				, false));
			mAnimationState.mOneShot = a.getBoolean(android.@internal.R.styleable.AnimationDrawable_oneshot
				, false);
			a.recycle();
			int type;
			int innerDepth = parser.getDepth() + 1;
			int depth;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 ((depth = parser.getDepth()) >= innerDepth || type != org.xmlpull.v1.XmlPullParserClass.END_TAG
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				if (depth > innerDepth || !parser.getName().Equals("item"))
				{
					continue;
				}
				a = r.obtainAttributes(attrs, android.@internal.R.styleable.AnimationDrawableItem
					);
				int duration = a.getInt(android.@internal.R.styleable.AnimationDrawableItem_duration
					, -1);
				if (duration < 0)
				{
					throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
						 ": <item> tag requires a 'duration' attribute");
				}
				int drawableRes = a.getResourceId(android.@internal.R.styleable.AnimationDrawableItem_drawable
					, 0);
				a.recycle();
				android.graphics.drawable.Drawable dr;
				if (drawableRes != 0)
				{
					dr = r.getDrawable(drawableRes);
				}
				else
				{
					while ((type = parser.next()) == org.xmlpull.v1.XmlPullParserClass.TEXT)
					{
					}
					// Empty
					if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
					{
						throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
							 ": <item> tag requires a 'drawable' attribute or child tag" + " defining a drawable"
							);
					}
					dr = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, attrs);
				}
				mAnimationState.addFrame(dr, duration);
				if (dr != null)
				{
					dr.setCallback(this);
				}
			}
			setFrame(0, true, false);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mAnimationState.mDurations = (int[])mAnimationState.mDurations.Clone();
				mMutated = true;
			}
			return this;
		}

		private sealed class AnimationState : android.graphics.drawable.DrawableContainer
			.DrawableContainerState
		{
			internal int[] mDurations;

			internal bool mOneShot;

			internal AnimationState(android.graphics.drawable.AnimationDrawable.AnimationState
				 orig, android.graphics.drawable.AnimationDrawable owner, android.content.res.Resources
				 res) : base(orig, owner, res)
			{
				if (orig != null)
				{
					mDurations = orig.mDurations;
					mOneShot = orig.mOneShot;
				}
				else
				{
					mDurations = new int[getChildren().Length];
					mOneShot = true;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.AnimationDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.AnimationDrawable(this, res);
			}

			public void addFrame(android.graphics.drawable.Drawable dr, int dur)
			{
				// Do not combine the following. The array index must be evaluated before 
				// the array is accessed because super.addChild(dr) has a side effect on mDurations.
				int pos = base.addChild(dr);
				mDurations[pos] = dur;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.DrawableContainer.DrawableContainerState"
				)]
			public override void growArray(int oldSize, int newSize)
			{
				base.growArray(oldSize, newSize);
				int[] newDurations = new int[newSize];
				System.Array.Copy(mDurations, 0, newDurations, 0, oldSize);
				mDurations = newDurations;
			}
		}

		private AnimationDrawable(android.graphics.drawable.AnimationDrawable.AnimationState
			 state, android.content.res.Resources res)
		{
			android.graphics.drawable.AnimationDrawable.AnimationState @as = new android.graphics.drawable.AnimationDrawable
				.AnimationState(state, this, res);
			mAnimationState = @as;
			setConstantState(@as);
			if (state != null)
			{
				setFrame(0, true, false);
			}
		}
	}
}
