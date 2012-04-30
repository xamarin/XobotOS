using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>
	/// Lets you assign a number of graphic images to a single Drawable and swap out the visible item by a string
	/// ID value.
	/// </summary>
	/// <remarks>
	/// Lets you assign a number of graphic images to a single Drawable and swap out the visible item by a string
	/// ID value.
	/// <p/>
	/// <p>It can be defined in an XML file with the <code>&lt;selector&gt;</code> element.
	/// Each state Drawable is defined in a nested <code>&lt;item&gt;</code> element. For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#StateListDrawable_visible</attr>
	/// <attr>ref android.R.styleable#StateListDrawable_variablePadding</attr>
	/// <attr>ref android.R.styleable#StateListDrawable_constantSize</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_focused</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_window_focused</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_enabled</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_checkable</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_checked</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_selected</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_activated</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_active</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_single</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_first</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_middle</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_last</attr>
	/// <attr>ref android.R.styleable#DrawableStates_state_pressed</attr>
	[Sharpen.Sharpened]
	public class StateListDrawable : android.graphics.drawable.DrawableContainer
	{
		internal const bool DEBUG = false;

		internal const string TAG = "StateListDrawable";

		/// <summary>
		/// To be proper, we should have a getter for dither (and alpha, etc.)
		/// so that proxy classes like this can save/restore their delegates'
		/// values, but we don't have getters.
		/// </summary>
		/// <remarks>
		/// To be proper, we should have a getter for dither (and alpha, etc.)
		/// so that proxy classes like this can save/restore their delegates'
		/// values, but we don't have getters. Since we do have setters
		/// (e.g. setDither), which this proxy forwards on, we have to have some
		/// default/initial setting.
		/// The initial setting for dither is now true, since it almost always seems
		/// to improve the quality at negligible cost.
		/// </remarks>
		internal const bool DEFAULT_DITHER = true;

		private readonly android.graphics.drawable.StateListDrawable.StateListState mStateListState;

		private bool mMutated;

		public StateListDrawable() : this(null, null)
		{
		}

		/// <summary>Add a new image/string ID to the set of images.</summary>
		/// <remarks>Add a new image/string ID to the set of images.</remarks>
		/// <param name="stateSet">
		/// - An array of resource Ids to associate with the image.
		/// Switch to this image by calling setState().
		/// </param>
		/// <param name="drawable">-The image to show.</param>
		public virtual void addState(int[] stateSet, android.graphics.drawable.Drawable drawable
			)
		{
			if (drawable != null)
			{
				mStateListState.addStateSet(stateSet, drawable);
				// in case the new state matches our current state...
				onStateChange(getState());
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] stateSet)
		{
			int idx = mStateListState.indexOfStateSet(stateSet);
			if (idx < 0)
			{
				idx = mStateListState.indexOfStateSet(android.util.StateSet.WILD_CARD);
			}
			if (selectDrawable(idx))
			{
				return true;
			}
			return base.onStateChange(stateSet);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.StateListDrawable);
			base.inflateWithAttributes(r, parser, a, android.@internal.R.styleable.StateListDrawable_visible
				);
			mStateListState.setVariablePadding(a.getBoolean(android.@internal.R.styleable.StateListDrawable_variablePadding
				, false));
			mStateListState.setConstantSize(a.getBoolean(android.@internal.R.styleable.StateListDrawable_constantSize
				, false));
			mStateListState.setEnterFadeDuration(a.getInt(android.@internal.R.styleable.StateListDrawable_enterFadeDuration
				, 0));
			mStateListState.setExitFadeDuration(a.getInt(android.@internal.R.styleable.StateListDrawable_exitFadeDuration
				, 0));
			setDither(a.getBoolean(android.@internal.R.styleable.StateListDrawable_dither, DEFAULT_DITHER
				));
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
				int drawableRes = 0;
				int i;
				int j = 0;
				int numAttrs = attrs.getAttributeCount();
				int[] states = new int[numAttrs];
				for (i = 0; i < numAttrs; i++)
				{
					int stateResId = attrs.getAttributeNameResource(i);
					if (stateResId == 0)
					{
						break;
					}
					if (stateResId == android.@internal.R.attr.drawable)
					{
						drawableRes = attrs.getAttributeResourceValue(i, 0);
					}
					else
					{
						states[j++] = attrs.getAttributeBooleanValue(i, false) ? stateResId : -stateResId;
					}
				}
				states = android.util.StateSet.trimStateSet(states, j);
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
					if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
					{
						throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
							 ": <item> tag requires a 'drawable' attribute or " + "child tag defining a drawable"
							);
					}
					dr = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, attrs);
				}
				mStateListState.addStateSet(states, dr);
			}
			onStateChange(getState());
		}

		internal virtual android.graphics.drawable.StateListDrawable.StateListState getStateListState
			()
		{
			return mStateListState;
		}

		/// <summary>Gets the number of states contained in this drawable.</summary>
		/// <remarks>Gets the number of states contained in this drawable.</remarks>
		/// <returns>The number of states contained in this drawable.</returns>
		/// <hide>pending API council</hide>
		/// <seealso cref="getStateSet(int)">getStateSet(int)</seealso>
		/// <seealso cref="getStateDrawable(int)">getStateDrawable(int)</seealso>
		public virtual int getStateCount()
		{
			return mStateListState.getChildCount();
		}

		/// <summary>Gets the state set at an index.</summary>
		/// <remarks>Gets the state set at an index.</remarks>
		/// <param name="index">The index of the state set.</param>
		/// <returns>The state set at the index.</returns>
		/// <hide>pending API council</hide>
		/// <seealso cref="getStateCount()">getStateCount()</seealso>
		/// <seealso cref="getStateDrawable(int)">getStateDrawable(int)</seealso>
		public virtual int[] getStateSet(int index)
		{
			return mStateListState.mStateSets[index];
		}

		/// <summary>Gets the drawable at an index.</summary>
		/// <remarks>Gets the drawable at an index.</remarks>
		/// <param name="index">The index of the drawable.</param>
		/// <returns>The drawable at the index.</returns>
		/// <hide>pending API council</hide>
		/// <seealso cref="getStateCount()">getStateCount()</seealso>
		/// <seealso cref="getStateSet(int)">getStateSet(int)</seealso>
		public virtual android.graphics.drawable.Drawable getStateDrawable(int index)
		{
			return mStateListState.getChildren()[index];
		}

		/// <summary>Gets the index of the drawable with the provided state set.</summary>
		/// <remarks>Gets the index of the drawable with the provided state set.</remarks>
		/// <param name="stateSet">the state set to look up</param>
		/// <returns>the index of the provided state set, or -1 if not found</returns>
		/// <hide>pending API council</hide>
		/// <seealso cref="getStateDrawable(int)">getStateDrawable(int)</seealso>
		/// <seealso cref="getStateSet(int)">getStateSet(int)</seealso>
		public virtual int getStateDrawableIndex(int[] stateSet)
		{
			return mStateListState.indexOfStateSet(stateSet);
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				int[][] sets = mStateListState.mStateSets;
				int count = sets.Length;
				mStateListState.mStateSets = new int[count][];
				{
					for (int i = 0; i < count; i++)
					{
						int[] set = sets[i];
						if (set != null)
						{
							mStateListState.mStateSets[i] = (int[])set.Clone();
						}
					}
				}
				mMutated = true;
			}
			return this;
		}

		internal sealed class StateListState : android.graphics.drawable.DrawableContainer
			.DrawableContainerState
		{
			internal int[][] mStateSets;

			internal StateListState(android.graphics.drawable.StateListDrawable.StateListState
				 orig, android.graphics.drawable.StateListDrawable owner, android.content.res.Resources
				 res) : base(orig, owner, res)
			{
				if (orig != null)
				{
					mStateSets = orig.mStateSets;
				}
				else
				{
					mStateSets = new int[getChildren().Length][];
				}
			}

			internal int addStateSet(int[] stateSet, android.graphics.drawable.Drawable drawable
				)
			{
				int pos = addChild(drawable);
				mStateSets[pos] = stateSet;
				return pos;
			}

			internal int indexOfStateSet(int[] stateSet)
			{
				int[][] stateSets = mStateSets;
				int N = getChildCount();
				{
					for (int i = 0; i < N; i++)
					{
						if (android.util.StateSet.stateSetMatches(stateSets[i], stateSet))
						{
							return i;
						}
					}
				}
				return -1;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.StateListDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.StateListDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.DrawableContainer.DrawableContainerState"
				)]
			public override void growArray(int oldSize, int newSize)
			{
				base.growArray(oldSize, newSize);
				int[][] newStateSets = new int[newSize][];
				System.Array.Copy(mStateSets, 0, newStateSets, 0, oldSize);
				mStateSets = newStateSets;
			}
		}

		internal StateListDrawable(android.graphics.drawable.StateListDrawable.StateListState
			 state, android.content.res.Resources res)
		{
			android.graphics.drawable.StateListDrawable.StateListState @as = new android.graphics.drawable.StateListDrawable
				.StateListState(state, this, res);
			mStateListState = @as;
			setConstantState(@as);
			onStateChange(getState());
		}
	}
}
