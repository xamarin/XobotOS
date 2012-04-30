using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A resource that manages a number of alternate Drawables, each assigned a maximum numerical value.
	/// 	</summary>
	/// <remarks>
	/// A resource that manages a number of alternate Drawables, each assigned a maximum numerical value.
	/// Setting the level value of the object with
	/// <see cref="Drawable.setLevel(int)">Drawable.setLevel(int)</see>
	/// will load the image with the next
	/// greater or equal value assigned to its max attribute.
	/// A good example use of
	/// a LevelListDrawable would be a battery level indicator icon, with different images to indicate the current
	/// battery level.
	/// <p>
	/// It can be defined in an XML file with the <code>&lt;level-list&gt;</code> element.
	/// Each Drawable level is defined in a nested <code>&lt;item&gt;</code>. For example:
	/// </p>
	/// <pre>
	/// &lt;level-list xmlns:android="http://schemas.android.com/apk/res/android"&gt;
	/// &lt;item android:maxLevel="0" android:drawable="@drawable/ic_wifi_signal_1" /&gt;
	/// &lt;item android:maxLevel="1" android:drawable="@drawable/ic_wifi_signal_2" /&gt;
	/// &lt;item android:maxLevel="2" android:drawable="@drawable/ic_wifi_signal_3" /&gt;
	/// &lt;item android:maxLevel="3" android:drawable="@drawable/ic_wifi_signal_4" /&gt;
	/// &lt;/level-list&gt;
	/// </pre>
	/// <p>With this XML saved into the res/drawable/ folder of the project, it can be referenced as
	/// the drawable for an
	/// <see cref="android.widget.ImageView">android.widget.ImageView</see>
	/// . The default image is the first in the list.
	/// It can then be changed to one of the other levels with
	/// <see cref="android.widget.ImageView.setImageLevel(int)">android.widget.ImageView.setImageLevel(int)
	/// 	</see>
	/// . For more
	/// information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/drawable-resource.html"&gt;Drawable Resources</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#LevelListDrawableItem_minLevel</attr>
	/// <attr>ref android.R.styleable#LevelListDrawableItem_maxLevel</attr>
	/// <attr>ref android.R.styleable#LevelListDrawableItem_drawable</attr>
	[Sharpen.Sharpened]
	public class LevelListDrawable : android.graphics.drawable.DrawableContainer
	{
		private readonly android.graphics.drawable.LevelListDrawable.LevelListState mLevelListState;

		private bool mMutated;

		public LevelListDrawable() : this(null, null)
		{
		}

		public virtual void addLevel(int low, int high, android.graphics.drawable.Drawable
			 drawable)
		{
			if (drawable != null)
			{
				mLevelListState.addLevel(low, high, drawable);
				// in case the new state matches our current state...
				onLevelChange(getLevel());
			}
		}

		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			int idx = mLevelListState.indexOfLevel(level);
			if (selectDrawable(idx))
			{
				return true;
			}
			return base.onLevelChange(level);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			int type;
			int low = 0;
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
				android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
					styleable.LevelListDrawableItem);
				low = a.getInt(android.@internal.R.styleable.LevelListDrawableItem_minLevel, 0);
				int high = a.getInt(android.@internal.R.styleable.LevelListDrawableItem_maxLevel, 
					0);
				int drawableRes = a.getResourceId(android.@internal.R.styleable.LevelListDrawableItem_drawable
					, 0);
				a.recycle();
				if (high < 0)
				{
					throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
						 ": <item> tag requires a 'maxLevel' attribute");
				}
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
				mLevelListState.addLevel(low, high, dr);
			}
			onLevelChange(getLevel());
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mLevelListState.mLows = (int[])mLevelListState.mLows.Clone();
				mLevelListState.mHighs = (int[])mLevelListState.mHighs.Clone();
				mMutated = true;
			}
			return this;
		}

		private sealed class LevelListState : android.graphics.drawable.DrawableContainer
			.DrawableContainerState
		{
			internal int[] mLows;

			internal int[] mHighs;

			internal LevelListState(android.graphics.drawable.LevelListDrawable.LevelListState
				 orig, android.graphics.drawable.LevelListDrawable owner, android.content.res.Resources
				 res) : base(orig, owner, res)
			{
				if (orig != null)
				{
					mLows = orig.mLows;
					mHighs = orig.mHighs;
				}
				else
				{
					mLows = new int[getChildren().Length];
					mHighs = new int[getChildren().Length];
				}
			}

			public void addLevel(int low, int high, android.graphics.drawable.Drawable drawable
				)
			{
				int pos = addChild(drawable);
				mLows[pos] = low;
				mHighs[pos] = high;
			}

			public int indexOfLevel(int level)
			{
				int[] lows = mLows;
				int[] highs = mHighs;
				int N = getChildCount();
				{
					for (int i = 0; i < N; i++)
					{
						if (level >= lows[i] && level <= highs[i])
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
				return new android.graphics.drawable.LevelListDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.LevelListDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.DrawableContainer.DrawableContainerState"
				)]
			public override void growArray(int oldSize, int newSize)
			{
				base.growArray(oldSize, newSize);
				int[] newInts = new int[newSize];
				System.Array.Copy(mLows, 0, newInts, 0, oldSize);
				mLows = newInts;
				newInts = new int[newSize];
				System.Array.Copy(mHighs, 0, newInts, 0, oldSize);
				mHighs = newInts;
			}
		}

		private LevelListDrawable(android.graphics.drawable.LevelListDrawable.LevelListState
			 state, android.content.res.Resources res)
		{
			android.graphics.drawable.LevelListDrawable.LevelListState @as = new android.graphics.drawable.LevelListDrawable
				.LevelListState(state, this, res);
			mLevelListState = @as;
			setConstantState(@as);
			onLevelChange(getLevel());
		}
	}
}
