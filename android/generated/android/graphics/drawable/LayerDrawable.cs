using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>A Drawable that manages an array of other Drawables.</summary>
	/// <remarks>
	/// A Drawable that manages an array of other Drawables. These are drawn in array
	/// order, so the element with the largest index will be drawn on top.
	/// <p>
	/// It can be defined in an XML file with the <code>&lt;layer-list&gt;</code> element.
	/// Each Drawable in the layer is defined in a nested <code>&lt;item&gt;</code>. For more
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
	public class LayerDrawable : android.graphics.drawable.Drawable, android.graphics.drawable.Drawable
		.Callback
	{
		internal android.graphics.drawable.LayerDrawable.LayerState mLayerState;

		private int mOpacityOverride = android.graphics.PixelFormat.UNKNOWN;

		private int[] mPaddingL;

		private int[] mPaddingT;

		private int[] mPaddingR;

		private int[] mPaddingB;

		private readonly android.graphics.Rect mTmpRect = new android.graphics.Rect();

		private bool mMutated;

		/// <summary>Create a new layer drawable with the list of specified layers.</summary>
		/// <remarks>Create a new layer drawable with the list of specified layers.</remarks>
		/// <param name="layers">A list of drawables to use as layers in this new drawable.</param>
		public LayerDrawable(android.graphics.drawable.Drawable[] layers) : this(layers, 
			null)
		{
		}

		/// <summary>
		/// Create a new layer drawable with the specified list of layers and the specified
		/// constant state.
		/// </summary>
		/// <remarks>
		/// Create a new layer drawable with the specified list of layers and the specified
		/// constant state.
		/// </remarks>
		/// <param name="layers">The list of layers to add to this drawable.</param>
		/// <param name="state">The constant drawable state.</param>
		internal LayerDrawable(android.graphics.drawable.Drawable[] layers, android.graphics.drawable.LayerDrawable
			.LayerState state) : this(state, null)
		{
			int length = layers.Length;
			android.graphics.drawable.LayerDrawable.ChildDrawable[] r = new android.graphics.drawable.LayerDrawable
				.ChildDrawable[length];
			{
				for (int i = 0; i < length; i++)
				{
					r[i] = new android.graphics.drawable.LayerDrawable.ChildDrawable();
					r[i].mDrawable = layers[i];
					layers[i].setCallback(this);
					mLayerState.mChildrenChangingConfigurations |= layers[i].getChangingConfigurations
						();
				}
			}
			mLayerState.mNum = length;
			mLayerState.mChildren = r;
			ensurePadding();
		}

		internal LayerDrawable() : this((android.graphics.drawable.LayerDrawable.LayerState
			)null, null)
		{
		}

		internal LayerDrawable(android.graphics.drawable.LayerDrawable.LayerState state, 
			android.content.res.Resources res)
		{
			android.graphics.drawable.LayerDrawable.LayerState @as = createConstantState(state
				, res);
			mLayerState = @as;
			if (@as.mNum > 0)
			{
				ensurePadding();
			}
		}

		internal virtual android.graphics.drawable.LayerDrawable.LayerState createConstantState
			(android.graphics.drawable.LayerDrawable.LayerState state, android.content.res.Resources
			 res)
		{
			return new android.graphics.drawable.LayerDrawable.LayerState(state, this, res);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			base.inflate(r, parser, attrs);
			int type;
			android.content.res.TypedArray a = r.obtainAttributes(attrs, android.@internal.R.
				styleable.LayerDrawable);
			mOpacityOverride = a.getInt(android.@internal.R.styleable.LayerDrawable_opacity, 
				android.graphics.PixelFormat.UNKNOWN);
			a.recycle();
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
				a = r.obtainAttributes(attrs, android.@internal.R.styleable.LayerDrawableItem);
				int left = a.getDimensionPixelOffset(android.@internal.R.styleable.LayerDrawableItem_left
					, 0);
				int top = a.getDimensionPixelOffset(android.@internal.R.styleable.LayerDrawableItem_top
					, 0);
				int right = a.getDimensionPixelOffset(android.@internal.R.styleable.LayerDrawableItem_right
					, 0);
				int bottom = a.getDimensionPixelOffset(android.@internal.R.styleable.LayerDrawableItem_bottom
					, 0);
				int drawableRes = a.getResourceId(android.@internal.R.styleable.LayerDrawableItem_drawable
					, 0);
				int id = a.getResourceId(android.@internal.R.styleable.LayerDrawableItem_id, android.view.View
					.NO_ID);
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
				addLayer(dr, id, left, top, right, bottom);
			}
			ensurePadding();
			onStateChange(getState());
		}

		/// <summary>Add a new layer to this drawable.</summary>
		/// <remarks>Add a new layer to this drawable. The new layer is identified by an id.</remarks>
		/// <param name="layer">The drawable to add as a layer.</param>
		/// <param name="id">The id of the new layer.</param>
		/// <param name="left">The left padding of the new layer.</param>
		/// <param name="top">The top padding of the new layer.</param>
		/// <param name="right">The right padding of the new layer.</param>
		/// <param name="bottom">The bottom padding of the new layer.</param>
		private void addLayer(android.graphics.drawable.Drawable layer, int id, int left, 
			int top, int right, int bottom)
		{
			android.graphics.drawable.LayerDrawable.LayerState st = mLayerState;
			int N = st.mChildren != null ? st.mChildren.Length : 0;
			int i = st.mNum;
			if (i >= N)
			{
				android.graphics.drawable.LayerDrawable.ChildDrawable[] nu = new android.graphics.drawable.LayerDrawable
					.ChildDrawable[N + 10];
				if (i > 0)
				{
					System.Array.Copy(st.mChildren, 0, nu, 0, i);
				}
				st.mChildren = nu;
			}
			mLayerState.mChildrenChangingConfigurations |= layer.getChangingConfigurations();
			android.graphics.drawable.LayerDrawable.ChildDrawable childDrawable = new android.graphics.drawable.LayerDrawable
				.ChildDrawable();
			st.mChildren[i] = childDrawable;
			childDrawable.mId = id;
			childDrawable.mDrawable = layer;
			childDrawable.mInsetL = left;
			childDrawable.mInsetT = top;
			childDrawable.mInsetR = right;
			childDrawable.mInsetB = bottom;
			st.mNum++;
			layer.setCallback(this);
		}

		/// <summary>
		/// Look for a layer with the given id, and returns its
		/// <see cref="Drawable">Drawable</see>
		/// .
		/// </summary>
		/// <param name="id">The layer ID to search for.</param>
		/// <returns>
		/// The
		/// <see cref="Drawable">Drawable</see>
		/// of the layer that has the given id in the hierarchy or null.
		/// </returns>
		public virtual android.graphics.drawable.Drawable findDrawableByLayerId(int id)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] layers = mLayerState.mChildren;
			{
				for (int i = mLayerState.mNum - 1; i >= 0; i--)
				{
					if (layers[i].mId == id)
					{
						return layers[i].mDrawable;
					}
				}
			}
			return null;
		}

		/// <summary>Sets the ID of a layer.</summary>
		/// <remarks>Sets the ID of a layer.</remarks>
		/// <param name="index">The index of the layer which will received the ID.</param>
		/// <param name="id">The ID to assign to the layer.</param>
		public virtual void setId(int index, int id)
		{
			mLayerState.mChildren[index].mId = id;
		}

		/// <summary>Returns the number of layers contained within this.</summary>
		/// <remarks>Returns the number of layers contained within this.</remarks>
		/// <returns>The number of layers.</returns>
		public virtual int getNumberOfLayers()
		{
			return mLayerState.mNum;
		}

		/// <summary>Returns the drawable at the specified layer index.</summary>
		/// <remarks>Returns the drawable at the specified layer index.</remarks>
		/// <param name="index">The layer index of the drawable to retrieve.</param>
		/// <returns>
		/// The
		/// <see cref="Drawable">Drawable</see>
		/// at the specified layer index.
		/// </returns>
		public virtual android.graphics.drawable.Drawable getDrawable(int index)
		{
			return mLayerState.mChildren[index].mDrawable;
		}

		/// <summary>Returns the id of the specified layer.</summary>
		/// <remarks>Returns the id of the specified layer.</remarks>
		/// <param name="index">The index of the layer.</param>
		/// <returns>
		/// The id of the layer or
		/// <see cref="android.view.View.NO_ID">android.view.View.NO_ID</see>
		/// if the layer has no id.
		/// </returns>
		public virtual int getId(int index)
		{
			return mLayerState.mChildren[index].mId;
		}

		/// <summary>
		/// Sets (or replaces) the
		/// <see cref="Drawable">Drawable</see>
		/// for the layer with the given id.
		/// </summary>
		/// <param name="id">The layer ID to search for.</param>
		/// <param name="drawable">
		/// The replacement
		/// <see cref="Drawable">Drawable</see>
		/// .
		/// </param>
		/// <returns>
		/// Whether the
		/// <see cref="Drawable">Drawable</see>
		/// was replaced (could return false if
		/// the id was not found).
		/// </returns>
		public virtual bool setDrawableByLayerId(int id, android.graphics.drawable.Drawable
			 drawable)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] layers = mLayerState.mChildren;
			{
				for (int i = mLayerState.mNum - 1; i >= 0; i--)
				{
					if (layers[i].mId == id)
					{
						if (layers[i].mDrawable != null)
						{
							if (drawable != null)
							{
								android.graphics.Rect bounds = layers[i].mDrawable.getBounds();
								drawable.setBounds(bounds);
							}
							layers[i].mDrawable.setCallback(null);
						}
						if (drawable != null)
						{
							drawable.setCallback(this);
						}
						layers[i].mDrawable = drawable;
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Specify modifiers to the bounds for the drawable[index].</summary>
		/// <remarks>
		/// Specify modifiers to the bounds for the drawable[index].
		/// left += l
		/// top += t;
		/// right -= r;
		/// bottom -= b;
		/// </remarks>
		public virtual void setLayerInset(int index, int l, int t, int r, int b)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable childDrawable = mLayerState
				.mChildren[index];
			childDrawable.mInsetL = l;
			childDrawable.mInsetT = t;
			childDrawable.mInsetR = r;
			childDrawable.mInsetB = b;
		}

		// overrides from Drawable.Callback
		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void invalidateDrawable(android.graphics.drawable.Drawable who)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.invalidateDrawable(this);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void scheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what, long when)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.scheduleDrawable(this, what, when);
			}
		}

		[Sharpen.ImplementsInterface(@"android.graphics.drawable.Drawable.Callback")]
		public virtual void unscheduleDrawable(android.graphics.drawable.Drawable who, java.lang.Runnable
			 what)
		{
			android.graphics.drawable.Drawable.Callback callback = getCallback();
			if (callback != null)
			{
				callback.unscheduleDrawable(this, what);
			}
		}

		// overrides from Drawable
		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void draw(android.graphics.Canvas canvas)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					array[i].mDrawable.draw(canvas);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getChangingConfigurations()
		{
			return base.getChangingConfigurations() | mLayerState.mChangingConfigurations | mLayerState
				.mChildrenChangingConfigurations;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool getPadding(android.graphics.Rect padding)
		{
			// Arbitrarily get the padding from the first image.
			// Technically we should maybe do something more intelligent,
			// like take the max padding of all the images.
			padding.left = 0;
			padding.top = 0;
			padding.right = 0;
			padding.bottom = 0;
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					reapplyPadding(i, array[i]);
					padding.left += mPaddingL[i];
					padding.top += mPaddingT[i];
					padding.right += mPaddingR[i];
					padding.bottom += mPaddingB[i];
				}
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool setVisible(bool visible, bool restart)
		{
			bool changed = base.setVisible(visible, restart);
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					array[i].mDrawable.setVisible(visible, restart);
				}
			}
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setDither(bool dither)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					array[i].mDrawable.setDither(dither);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setAlpha(int alpha)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					array[i].mDrawable.setAlpha(alpha);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override void setColorFilter(android.graphics.ColorFilter cf)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			{
				for (int i = 0; i < N; i++)
				{
					array[i].mDrawable.setColorFilter(cf);
				}
			}
		}

		/// <summary>
		/// Sets the opacity of this drawable directly, instead of collecting the states from
		/// the layers
		/// </summary>
		/// <param name="opacity">
		/// The opacity to use, or
		/// <see cref="android.graphics.PixelFormat.UNKNOWN">PixelFormat.UNKNOWN</see>
		/// for the default behavior
		/// </param>
		/// <seealso cref="android.graphics.PixelFormat.UNKNOWN">android.graphics.PixelFormat.UNKNOWN
		/// 	</seealso>
		/// <seealso cref="android.graphics.PixelFormat.TRANSLUCENT">android.graphics.PixelFormat.TRANSLUCENT
		/// 	</seealso>
		/// <seealso cref="android.graphics.PixelFormat.TRANSPARENT">android.graphics.PixelFormat.TRANSPARENT
		/// 	</seealso>
		/// <seealso cref="android.graphics.PixelFormat.OPAQUE">android.graphics.PixelFormat.OPAQUE
		/// 	</seealso>
		public virtual void setOpacity(int opacity)
		{
			mOpacityOverride = opacity;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getOpacity()
		{
			if (mOpacityOverride != android.graphics.PixelFormat.UNKNOWN)
			{
				return mOpacityOverride;
			}
			return mLayerState.getOpacity();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override bool isStateful()
		{
			return mLayerState.isStateful();
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onStateChange(int[] state)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			bool paddingChanged = false;
			bool changed = false;
			{
				for (int i = 0; i < N; i++)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable r = array[i];
					if (r.mDrawable.setState(state))
					{
						changed = true;
					}
					if (reapplyPadding(i, r))
					{
						paddingChanged = true;
					}
				}
			}
			if (paddingChanged)
			{
				onBoundsChange(getBounds());
			}
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override bool onLevelChange(int level)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			bool paddingChanged = false;
			bool changed = false;
			{
				for (int i = 0; i < N; i++)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable r = array[i];
					if (r.mDrawable.setLevel(level))
					{
						changed = true;
					}
					if (reapplyPadding(i, r))
					{
						paddingChanged = true;
					}
				}
			}
			if (paddingChanged)
			{
				onBoundsChange(getBounds());
			}
			return changed;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		protected internal override void onBoundsChange(android.graphics.Rect bounds)
		{
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			int padL = 0;
			int padT = 0;
			int padR = 0;
			int padB = 0;
			{
				for (int i = 0; i < N; i++)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable r = array[i];
					r.mDrawable.setBounds(bounds.left + r.mInsetL + padL, bounds.top + r.mInsetT + padT
						, bounds.right - r.mInsetR - padR, bounds.bottom - r.mInsetB - padB);
					padL += mPaddingL[i];
					padR += mPaddingR[i];
					padT += mPaddingT[i];
					padB += mPaddingB[i];
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicWidth()
		{
			int width = -1;
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			int padL = 0;
			int padR = 0;
			{
				for (int i = 0; i < N; i++)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable r = array[i];
					int w = r.mDrawable.getIntrinsicWidth() + r.mInsetL + r.mInsetR + padL + padR;
					if (w > width)
					{
						width = w;
					}
					padL += mPaddingL[i];
					padR += mPaddingR[i];
				}
			}
			return width;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override int getIntrinsicHeight()
		{
			int height = -1;
			android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
			int N = mLayerState.mNum;
			int padT = 0;
			int padB = 0;
			{
				for (int i = 0; i < N; i++)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable r = array[i];
					int h = r.mDrawable.getIntrinsicHeight() + r.mInsetT + r.mInsetB + +padT + padB;
					if (h > height)
					{
						height = h;
					}
					padT += mPaddingT[i];
					padB += mPaddingB[i];
				}
			}
			return height;
		}

		internal bool reapplyPadding(int i, android.graphics.drawable.LayerDrawable.ChildDrawable
			 r)
		{
			android.graphics.Rect rect = mTmpRect;
			r.mDrawable.getPadding(rect);
			if (rect.left != mPaddingL[i] || rect.top != mPaddingT[i] || rect.right != mPaddingR
				[i] || rect.bottom != mPaddingB[i])
			{
				mPaddingL[i] = rect.left;
				mPaddingT[i] = rect.top;
				mPaddingR[i] = rect.right;
				mPaddingB[i] = rect.bottom;
				return true;
			}
			return false;
		}

		private void ensurePadding()
		{
			int N = mLayerState.mNum;
			if (mPaddingL != null && mPaddingL.Length >= N)
			{
				return;
			}
			mPaddingL = new int[N];
			mPaddingT = new int[N];
			mPaddingR = new int[N];
			mPaddingB = new int[N];
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable.ConstantState getConstantState
			()
		{
			if (mLayerState.canConstantState())
			{
				mLayerState.mChangingConfigurations = getChangingConfigurations();
				return mLayerState;
			}
			return null;
		}

		[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable")]
		public override android.graphics.drawable.Drawable mutate()
		{
			if (!mMutated && base.mutate() == this)
			{
				android.graphics.drawable.LayerDrawable.ChildDrawable[] array = mLayerState.mChildren;
				int N = mLayerState.mNum;
				{
					for (int i = 0; i < N; i++)
					{
						array[i].mDrawable.mutate();
					}
				}
				mMutated = true;
			}
			return this;
		}

		internal class ChildDrawable
		{
			public android.graphics.drawable.Drawable mDrawable;

			public int mInsetL;

			public int mInsetT;

			public int mInsetR;

			public int mInsetB;

			public int mId;
		}

		internal class LayerState : android.graphics.drawable.Drawable.ConstantState
		{
			internal int mNum;

			internal android.graphics.drawable.LayerDrawable.ChildDrawable[] mChildren;

			internal int mChangingConfigurations;

			internal int mChildrenChangingConfigurations;

			private bool mHaveOpacity = false;

			private int mOpacity;

			private bool mHaveStateful = false;

			private bool mStateful;

			private bool mCheckedConstantState;

			private bool mCanConstantState;

			internal LayerState(android.graphics.drawable.LayerDrawable.LayerState orig, android.graphics.drawable.LayerDrawable
				 owner, android.content.res.Resources res)
			{
				if (orig != null)
				{
					android.graphics.drawable.LayerDrawable.ChildDrawable[] origChildDrawable = orig.
						mChildren;
					int N = orig.mNum;
					mNum = N;
					mChildren = new android.graphics.drawable.LayerDrawable.ChildDrawable[N];
					mChangingConfigurations = orig.mChangingConfigurations;
					mChildrenChangingConfigurations = orig.mChildrenChangingConfigurations;
					{
						for (int i = 0; i < N; i++)
						{
							android.graphics.drawable.LayerDrawable.ChildDrawable r = mChildren[i] = new android.graphics.drawable.LayerDrawable
								.ChildDrawable();
							android.graphics.drawable.LayerDrawable.ChildDrawable or = origChildDrawable[i];
							if (res != null)
							{
								r.mDrawable = or.mDrawable.getConstantState().newDrawable(res);
							}
							else
							{
								r.mDrawable = or.mDrawable.getConstantState().newDrawable();
							}
							r.mDrawable.setCallback(owner);
							r.mInsetL = or.mInsetL;
							r.mInsetT = or.mInsetT;
							r.mInsetR = or.mInsetR;
							r.mInsetB = or.mInsetB;
							r.mId = or.mId;
						}
					}
					mHaveOpacity = orig.mHaveOpacity;
					mOpacity = orig.mOpacity;
					mHaveStateful = orig.mHaveStateful;
					mStateful = orig.mStateful;
					mCheckedConstantState = mCanConstantState = true;
				}
				else
				{
					mNum = 0;
					mChildren = null;
				}
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable()
			{
				return new android.graphics.drawable.LayerDrawable(this, null);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override android.graphics.drawable.Drawable newDrawable(android.content.res.Resources
				 res)
			{
				return new android.graphics.drawable.LayerDrawable(this, res);
			}

			[Sharpen.OverridesMethod(@"android.graphics.drawable.Drawable.ConstantState")]
			public override int getChangingConfigurations()
			{
				return mChangingConfigurations;
			}

			public int getOpacity()
			{
				if (mHaveOpacity)
				{
					return mOpacity;
				}
				int N = mNum;
				int op = N > 0 ? mChildren[0].mDrawable.getOpacity() : android.graphics.PixelFormat
					.TRANSPARENT;
				{
					for (int i = 1; i < N; i++)
					{
						op = android.graphics.drawable.Drawable.resolveOpacity(op, mChildren[i].mDrawable
							.getOpacity());
					}
				}
				mOpacity = op;
				mHaveOpacity = true;
				return op;
			}

			public bool isStateful()
			{
				if (mHaveStateful)
				{
					return mStateful;
				}
				bool stateful = false;
				int N = mNum;
				{
					for (int i = 0; i < N; i++)
					{
						if (mChildren[i].mDrawable.isStateful())
						{
							stateful = true;
							break;
						}
					}
				}
				mStateful = stateful;
				mHaveStateful = true;
				return stateful;
			}

			public virtual bool canConstantState()
			{
				lock (this)
				{
					if (!mCheckedConstantState && mChildren != null)
					{
						mCanConstantState = true;
						int N = mNum;
						{
							for (int i = 0; i < N; i++)
							{
								if (mChildren[i].mDrawable.getConstantState() == null)
								{
									mCanConstantState = false;
									break;
								}
							}
						}
						mCheckedConstantState = true;
					}
					return mCanConstantState;
				}
			}
		}
	}
}
