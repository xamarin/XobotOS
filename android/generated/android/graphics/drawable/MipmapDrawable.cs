using Sharpen;

namespace android.graphics.drawable
{
	/// <hide>
	/// -- we are probably moving to do MipMaps in another way (more integrated
	/// with the resource system).
	/// A resource that manages a number of alternate Drawables, and which actually draws the one which
	/// size matches the most closely the drawing bounds. Providing several pre-scaled version of the
	/// drawable helps minimizing the aliasing artifacts that can be introduced by the scaling.
	/// <p>
	/// Use
	/// <see cref="addDrawable(Drawable)">addDrawable(Drawable)</see>
	/// to define the different Drawables that will represent the
	/// mipmap levels of this MipmapDrawable. The mipmap Drawable that will actually be used when this
	/// MipmapDrawable is drawn is the one which has the smallest intrinsic height greater or equal than
	/// the bounds' height. This selection ensures that the best available mipmap level is scaled down to
	/// draw this MipmapDrawable.
	/// </p>
	/// If the bounds' height is larger than the largest mipmap, the largest mipmap will be scaled up.
	/// Note that Drawables without intrinsic height (i.e. with a negative value, such as Color) will
	/// only be used if no other mipmap Drawable are provided. The Drawables' intrinsic heights should
	/// not be changed after the Drawable has been added to this MipmapDrawable.
	/// <p>
	/// The different mipmaps' parameters (opacity, padding, color filter, gravity...) should typically
	/// be similar to ensure a continuous visual appearance when the MipmapDrawable is scaled. The aspect
	/// ratio of the different mipmaps should especially be equal.
	/// </p>
	/// A typical example use of a MipmapDrawable would be for an image which is intended to be scaled at
	/// various sizes, and for which one wants to provide pre-scaled versions to precisely control its
	/// appearance.
	/// <p>
	/// The intrinsic size of a MipmapDrawable are inferred from those of the largest mipmap (in terms of
	/// <see cref="Drawable.getIntrinsicHeight()">Drawable.getIntrinsicHeight()</see>
	/// ). On the opposite, its minimum
	/// size is defined by the smallest provided mipmap.
	/// </p>
	/// It can be defined in an XML file with the <code>&lt;mipmap&gt;</code> element.
	/// Each mipmap Drawable is defined in a nested <code>&lt;item&gt;</code>. For example:
	/// <pre>
	/// &lt;mipmap xmlns:android="http://schemas.android.com/apk/res/android"&gt;
	/// &lt;item android:drawable="@drawable/my_image_8" /&gt;
	/// &lt;item android:drawable="@drawable/my_image_32" /&gt;
	/// &lt;item android:drawable="@drawable/my_image_128" /&gt;
	/// &lt;/mipmap&gt;
	/// </pre>
	/// <p>
	/// With this XML saved into the res/drawable/ folder of the project, it can be referenced as
	/// the drawable for an
	/// <see cref="android.widget.ImageView">android.widget.ImageView</see>
	/// . Assuming that the heights of the provided
	/// drawables are respectively 8, 32 and 128 pixels, the first one will be scaled down when the
	/// bounds' height is lower or equal than 8 pixels. The second drawable will then be used up to a
	/// height of 32 pixels and the largest drawable will be used for greater heights.
	/// </p>
	/// </hide>
	/// <attr>ref android.R.styleable#MipmapDrawableItem_drawable</attr>
	[Sharpen.Sharpened]
	public class MipmapDrawable : android.graphics.drawable.DrawableContainer
	{
		private readonly android.graphics.drawable.MipmapDrawable.MipmapContainerState mMipmapContainerState;

		private bool mMutated;

		public MipmapDrawable() : this(null, null)
		{
		}

		/// <summary>Adds a Drawable to the list of available mipmap Drawables.</summary>
		/// <remarks>
		/// Adds a Drawable to the list of available mipmap Drawables. The Drawable actually used when
		/// this MipmapDrawable is drawn is determined from its bounds.
		/// This method has no effect if drawable is null.
		/// </remarks>
		/// <param name="drawable">The Drawable that will be added to list of available mipmap Drawables.
		/// 	</param>
		public virtual void addDrawable(android.graphics.drawable.Drawable drawable)
		{
			if (drawable != null)
			{
				mMipmapContainerState.addDrawable(drawable);
				onDrawableAdded();
			}
		}

		private void onDrawableAdded()
		{
			// selectDrawable assumes that the container content does not change.
			// When a Drawable is added, the same index can correspond to a new Drawable, and since
			// selectDrawable has a fast exit case when oldIndex==newIndex, the new drawable could end
			// up not being used in place of the previous one if they happen to share the same index.
			// This make sure the new computed index can actually replace the previous one.
			selectDrawable(-1);
			onBoundsChange(getBounds());
		}

		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			int index = mMipmapContainerState.indexForBounds(bounds);
			// Will call invalidateSelf() if needed
			selectDrawable(index);
			base.onBoundsChange(bounds);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
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
				android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
					styleable.MipmapDrawableItem);
				int drawableRes = a.getResourceId(android.@internal.R.styleable.MipmapDrawableItem_drawable
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
					if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
					{
						throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
							 ": <item> tag requires a 'drawable' attribute or " + "child tag defining a drawable"
							);
					}
					dr = android.graphics.drawable.Drawable.createFromXmlInner(r, parser, attrs);
				}
				mMipmapContainerState.addDrawable(dr);
			}
			onDrawableAdded();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				mMipmapContainerState.mMipmapHeights = (int[])mMipmapContainerState.mMipmapHeights
					.Clone();
				mMutated = true;
			}
			return this;
		}

		private sealed class MipmapContainerState : android.graphics.drawable.DrawableContainer
			.DrawableContainerState
		{
			internal int[] mMipmapHeights;

			internal MipmapContainerState(android.graphics.drawable.MipmapDrawable.MipmapContainerState
				 orig, android.graphics.drawable.MipmapDrawable owner, android.content.res.Resources
				 res) : base(orig, owner, res)
			{
				if (orig != null)
				{
					mMipmapHeights = orig.mMipmapHeights;
				}
				else
				{
					mMipmapHeights = new int[getChildren().Length];
				}
				// Change the default value
				setConstantSize(true);
			}

			/// <summary>Returns the index of the child mipmap drawable that will best fit the provided bounds.
			/// 	</summary>
			/// <remarks>
			/// Returns the index of the child mipmap drawable that will best fit the provided bounds.
			/// This index is determined by comparing bounds' height and children intrinsic heights.
			/// The returned mipmap index is the smallest mipmap which height is greater or equal than
			/// the bounds' height. If the bounds' height is larger than the largest mipmap, the largest
			/// mipmap index is returned.
			/// </remarks>
			/// <param name="bounds">The bounds of the MipMapDrawable.</param>
			/// <returns>
			/// The index of the child Drawable that will best fit these bounds, or -1 if there
			/// are no children mipmaps.
			/// </returns>
			public int indexForBounds(android.graphics.Rect bounds)
			{
				int boundsHeight = bounds.height();
				int N = getChildCount();
				{
					for (int i = 0; i < N; i++)
					{
						if (boundsHeight <= mMipmapHeights[i])
						{
							return i;
						}
					}
				}
				// No mipmap larger than bounds found. Use largest one which will be scaled up.
				if (N > 0)
				{
					return N - 1;
				}
				// No Drawable mipmap at all
				return -1;
			}

			/// <summary>Adds a Drawable to the list of available mipmap Drawables.</summary>
			/// <remarks>
			/// Adds a Drawable to the list of available mipmap Drawables. This list can be retrieved
			/// using
			/// <see cref="DrawableContainerState.getChildren()">DrawableContainerState.getChildren()
			/// 	</see>
			/// and this method
			/// ensures that it is always sorted by increasing
			/// <see cref="Drawable.getIntrinsicHeight()">Drawable.getIntrinsicHeight()</see>
			/// .
			/// </remarks>
			/// <param name="drawable">The Drawable that will be added to children list</param>
			public void addDrawable(android.graphics.drawable.Drawable drawable)
			{
				// Insert drawable in last position, correctly resetting cached values and
				// especially mComputedConstantSize
				int pos = addChild(drawable);
				// Bubble sort the last drawable to restore the sort by intrinsic height
				int drawableHeight = drawable.getIntrinsicHeight();
				while (pos > 0)
				{
					android.graphics.drawable.Drawable previousDrawable = mDrawables[pos - 1];
					int previousIntrinsicHeight = previousDrawable.getIntrinsicHeight();
					if (drawableHeight < previousIntrinsicHeight)
					{
						mDrawables[pos] = previousDrawable;
						mMipmapHeights[pos] = previousIntrinsicHeight;
						mDrawables[pos - 1] = drawable;
						mMipmapHeights[pos - 1] = drawableHeight;
						pos--;
					}
					else
					{
						break;
					}
				}
			}

			/// <summary>Intrinsic sizes are those of the largest available mipmap.</summary>
			/// <remarks>
			/// Intrinsic sizes are those of the largest available mipmap.
			/// Minimum sizes are those of the smallest available mipmap.
			/// </remarks>
			[Sharpen.OverridesMethod(@"android.graphics.drawable.DrawableContainer.DrawableContainerState"
				)]
			protected internal override void computeConstantSize()
			{
				int N = getChildCount();
				if (N > 0)
				{
					android.graphics.drawable.Drawable smallestDrawable = mDrawables[0];
					mConstantMinimumWidth = smallestDrawable.getMinimumWidth();
					mConstantMinimumHeight = smallestDrawable.getMinimumHeight();
					android.graphics.drawable.Drawable largestDrawable = mDrawables[N - 1];
					mConstantWidth = largestDrawable.getIntrinsicWidth();
					mConstantHeight = largestDrawable.getIntrinsicHeight();
				}
				else
				{
					mConstantWidth = mConstantHeight = -1;
					mConstantMinimumWidth = mConstantMinimumHeight = 0;
				}
				mComputedConstantSize = true;
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.MipmapDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.MipmapDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.DrawableContainer.DrawableContainerState"
				)]
			public override void growArray(int oldSize, int newSize)
			{
				base.growArray(oldSize, newSize);
				int[] newInts = new int[newSize];
				System.Array.Copy(mMipmapHeights, 0, newInts, 0, oldSize);
				mMipmapHeights = newInts;
			}
		}

		private MipmapDrawable(android.graphics.drawable.MipmapDrawable.MipmapContainerState
			 state, android.content.res.Resources res)
		{
			android.graphics.drawable.MipmapDrawable.MipmapContainerState @as = new android.graphics.drawable.MipmapDrawable
				.MipmapContainerState(state, this, res);
			mMipmapContainerState = @as;
			setConstantState(@as);
			onDrawableAdded();
		}
	}
}
