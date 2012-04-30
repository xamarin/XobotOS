using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>
	/// The item view for each item in the
	/// <see cref="IconMenuView">IconMenuView</see>
	/// .
	/// </summary>
	[Sharpen.Sharpened]
	public sealed class IconMenuItemView : android.widget.TextView, android.view.@internal.menu.MenuViewClass
		.ItemView
	{
		internal const int NO_ALPHA = unchecked((int)(0xFF));

		private android.view.@internal.menu.IconMenuView mIconMenuView;

		private android.view.@internal.menu.MenuBuilder.ItemInvoker mItemInvoker;

		private android.view.@internal.menu.MenuItemImpl mItemData;

		private android.graphics.drawable.Drawable mIcon;

		private int mTextAppearance;

		private android.content.Context mTextAppearanceContext;

		private float mDisabledAlpha;

		private android.graphics.Rect mPositionIconAvailable = new android.graphics.Rect(
			);

		private android.graphics.Rect mPositionIconOutput = new android.graphics.Rect();

		private bool mShortcutCaptionMode;

		private string mShortcutCaption;

		private static string sPrependShortcutLabel;

		public IconMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs)
		{
			if (sPrependShortcutLabel == null)
			{
				sPrependShortcutLabel = getResources().getString(android.@internal.R.@string.prepend_shortcut_label
					);
			}
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.MenuView, defStyle, 0);
			mDisabledAlpha = a.getFloat(android.@internal.R.styleable.MenuView_itemIconDisabledAlpha
				, 0.8f);
			mTextAppearance = a.getResourceId(android.@internal.R.styleable.MenuView_itemTextAppearance
				, -1);
			mTextAppearanceContext = context;
			a.recycle();
		}

		public IconMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
		}

		/// <summary>Initializes with the provided title and icon</summary>
		/// <param name="title">The title of this item</param>
		/// <param name="icon">The icon of this item</param>
		internal void initialize(java.lang.CharSequence title, android.graphics.drawable.Drawable
			 icon)
		{
			setClickable(true);
			setFocusable(true);
			if (mTextAppearance != -1)
			{
				setTextAppearance(mTextAppearanceContext, mTextAppearance);
			}
			setTitle(title);
			setIcon(icon);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void initialize(android.view.@internal.menu.MenuItemImpl itemData, int menuType
			)
		{
			mItemData = itemData;
			initialize(itemData.getTitleForItemView(this), itemData.getIcon());
			setVisibility(itemData.isVisible() ? android.view.View.VISIBLE : android.view.View
				.GONE);
			setEnabled(itemData.isEnabled());
		}

		public void setItemData(android.view.@internal.menu.MenuItemImpl data)
		{
			mItemData = data;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool performClick()
		{
			// Let the view's click listener have top priority (the More button relies on this)
			if (base.performClick())
			{
				return true;
			}
			if ((mItemInvoker != null) && (mItemInvoker.invokeItem(mItemData)))
			{
				playSoundEffect(android.view.SoundEffectConstants.CLICK);
				return true;
			}
			else
			{
				return false;
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void setTitle(java.lang.CharSequence title)
		{
			if (mShortcutCaptionMode)
			{
				setCaptionMode(true);
			}
			else
			{
				if (title != null)
				{
					setText(title);
				}
			}
		}

		internal void setCaptionMode(bool shortcut)
		{
			if (mItemData == null)
			{
				return;
			}
			mShortcutCaptionMode = shortcut && (mItemData.shouldShowShortcut());
			java.lang.CharSequence text = mItemData.getTitleForItemView(this);
			if (mShortcutCaptionMode)
			{
				if (mShortcutCaption == null)
				{
					mShortcutCaption = mItemData.getShortcutLabel();
				}
				text = java.lang.CharSequenceProxy.Wrap(mShortcutCaption);
			}
			setText(text);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void setIcon(android.graphics.drawable.Drawable icon)
		{
			mIcon = icon;
			if (icon != null)
			{
				icon.setBounds(0, 0, icon.getIntrinsicWidth(), icon.getIntrinsicHeight());
				// Set the compound drawables
				setCompoundDrawables(null, icon, null, null);
				// When there is an icon, make sure the text is at the bottom
				setGravity(android.view.Gravity.BOTTOM | android.view.Gravity.CENTER_HORIZONTAL);
				requestLayout();
			}
			else
			{
				setCompoundDrawables(null, null, null, null);
				// When there is no icon, make sure the text is centered vertically
				setGravity(android.view.Gravity.CENTER_VERTICAL | android.view.Gravity.CENTER_HORIZONTAL
					);
			}
		}

		public void setItemInvoker(android.view.@internal.menu.MenuBuilder.ItemInvoker itemInvoker
			)
		{
			mItemInvoker = itemInvoker;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public android.view.@internal.menu.MenuItemImpl getItemData()
		{
			return mItemData;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setVisibility(int v)
		{
			base.setVisibility(v);
			if (mIconMenuView != null)
			{
				// On visibility change, mark the IconMenuView to refresh itself eventually
				mIconMenuView.markStaleChildren();
			}
		}

		internal void setIconMenuView(android.view.@internal.menu.IconMenuView iconMenuView
			)
		{
			mIconMenuView = iconMenuView;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void drawableStateChanged()
		{
			base.drawableStateChanged();
			if (mItemData != null && mIcon != null)
			{
				// When disabled, the not-focused state and the pressed state should
				// drop alpha on the icon
				bool isInAlphaState = !mItemData.isEnabled() && (isPressed() || !isFocused());
				mIcon.setAlpha(isInAlphaState ? (int)(mDisabledAlpha * NO_ALPHA) : NO_ALPHA);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			base.onLayout(changed, left, top, right, bottom);
			positionIcon();
		}

		[Sharpen.OverridesMethod(@"android.widget.TextView")]
		protected internal override void onTextChanged(java.lang.CharSequence text, int start
			, int before, int after)
		{
			base.onTextChanged(text, start, before, after);
			// our layout params depend on the length of the text
			setLayoutParams(getTextAppropriateLayoutParams());
		}

		/// <returns>
		/// layout params appropriate for this view.  If layout params already exist, it will
		/// augment them to be appropriate to the current text size.
		/// </returns>
		internal android.view.@internal.menu.IconMenuView.LayoutParams getTextAppropriateLayoutParams
			()
		{
			android.view.@internal.menu.IconMenuView.LayoutParams lp = (android.view.@internal.menu.IconMenuView
				.LayoutParams)getLayoutParams();
			if (lp == null)
			{
				// Default layout parameters
				lp = new android.view.@internal.menu.IconMenuView.LayoutParams(android.view.ViewGroup
					.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT);
			}
			// Set the desired width of item
			lp.desiredWidth = (int)android.text.Layout.getDesiredWidth(getText(), getPaint());
			return lp;
		}

		/// <summary>
		/// Positions the icon vertically (horizontal centering is taken care of by
		/// the TextView's gravity).
		/// </summary>
		/// <remarks>
		/// Positions the icon vertically (horizontal centering is taken care of by
		/// the TextView's gravity).
		/// </remarks>
		private void positionIcon()
		{
			if (mIcon == null)
			{
				return;
			}
			// We reuse the output rectangle as a temp rect
			android.graphics.Rect tmpRect = mPositionIconOutput;
			getLineBounds(0, tmpRect);
			mPositionIconAvailable.set(0, 0, getWidth(), tmpRect.top);
			int layoutDirection = getResolvedLayoutDirection();
			android.view.Gravity.apply(android.view.Gravity.CENTER_VERTICAL | android.view.Gravity
				.LEFT, mIcon.getIntrinsicWidth(), mIcon.getIntrinsicHeight(), mPositionIconAvailable
				, mPositionIconOutput, layoutDirection);
			mIcon.setBounds(mPositionIconOutput);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void setCheckable(bool checkable)
		{
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void setChecked(bool @checked)
		{
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public void setShortcut(bool showShortcut, char shortcutKey)
		{
			if (mShortcutCaptionMode)
			{
				mShortcutCaption = null;
				setCaptionMode(true);
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public bool prefersCondensedTitle()
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public bool showsIcon()
		{
			return true;
		}
	}
}
