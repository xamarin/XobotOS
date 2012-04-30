using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>The item view for each item in the ListView-based MenuViews.</summary>
	/// <remarks>The item view for each item in the ListView-based MenuViews.</remarks>
	[Sharpen.Sharpened]
	public class ListMenuItemView : android.widget.LinearLayout, android.view.@internal.menu.MenuViewClass
		.ItemView
	{
		private android.view.@internal.menu.MenuItemImpl mItemData;

		private android.widget.ImageView mIconView;

		private android.widget.RadioButton mRadioButton;

		private android.widget.TextView mTitleView;

		private android.widget.CheckBox mCheckBox;

		private android.widget.TextView mShortcutView;

		private android.graphics.drawable.Drawable mBackground;

		private int mTextAppearance;

		private android.content.Context mTextAppearanceContext;

		private bool mPreserveIconSpacing;

		private int mMenuType;

		private android.view.LayoutInflater mInflater;

		private bool mForceShowIcon;

		public ListMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.MenuView, defStyle, 0);
			mBackground = a.getDrawable(android.@internal.R.styleable.MenuView_itemBackground
				);
			mTextAppearance = a.getResourceId(android.@internal.R.styleable.MenuView_itemTextAppearance
				, -1);
			mPreserveIconSpacing = a.getBoolean(android.@internal.R.styleable.MenuView_preserveIconSpacing
				, false);
			mTextAppearanceContext = context;
			a.recycle();
		}

		public ListMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			base.onFinishInflate();
			setBackgroundDrawable(mBackground);
			mTitleView = (android.widget.TextView)findViewById(android.@internal.R.id.title);
			if (mTextAppearance != -1)
			{
				mTitleView.setTextAppearance(mTextAppearanceContext, mTextAppearance);
			}
			mShortcutView = (android.widget.TextView)findViewById(android.@internal.R.id.shortcut
				);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void initialize(android.view.@internal.menu.MenuItemImpl itemData, 
			int menuType)
		{
			mItemData = itemData;
			mMenuType = menuType;
			setVisibility(itemData.isVisible() ? android.view.View.VISIBLE : android.view.View
				.GONE);
			setTitle(itemData.getTitleForItemView(this));
			setCheckable(itemData.isCheckable());
			setShortcut(itemData.shouldShowShortcut(), itemData.getShortcut());
			setIcon(itemData.getIcon());
			setEnabled(itemData.isEnabled());
		}

		public virtual void setForceShowIcon(bool forceShow)
		{
			mPreserveIconSpacing = mForceShowIcon = forceShow;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setTitle(java.lang.CharSequence title)
		{
			if (title != null)
			{
				mTitleView.setText(title);
				if (mTitleView.getVisibility() != VISIBLE)
				{
					mTitleView.setVisibility(VISIBLE);
				}
			}
			else
			{
				if (mTitleView.getVisibility() != GONE)
				{
					mTitleView.setVisibility(GONE);
				}
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual android.view.@internal.menu.MenuItemImpl getItemData()
		{
			return mItemData;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setCheckable(bool checkable)
		{
			if (!checkable && mRadioButton == null && mCheckBox == null)
			{
				return;
			}
			if (mRadioButton == null)
			{
				insertRadioButton();
			}
			if (mCheckBox == null)
			{
				insertCheckBox();
			}
			// Depending on whether its exclusive check or not, the checkbox or
			// radio button will be the one in use (and the other will be otherCompoundButton)
			android.widget.CompoundButton compoundButton;
			android.widget.CompoundButton otherCompoundButton;
			if (mItemData.isExclusiveCheckable())
			{
				compoundButton = mRadioButton;
				otherCompoundButton = mCheckBox;
			}
			else
			{
				compoundButton = mCheckBox;
				otherCompoundButton = mRadioButton;
			}
			if (checkable)
			{
				compoundButton.setChecked(mItemData.isChecked());
				int newVisibility = checkable ? VISIBLE : GONE;
				if (compoundButton.getVisibility() != newVisibility)
				{
					compoundButton.setVisibility(newVisibility);
				}
				// Make sure the other compound button isn't visible
				if (otherCompoundButton.getVisibility() != GONE)
				{
					otherCompoundButton.setVisibility(GONE);
				}
			}
			else
			{
				mCheckBox.setVisibility(GONE);
				mRadioButton.setVisibility(GONE);
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setChecked(bool @checked)
		{
			android.widget.CompoundButton compoundButton;
			if (mItemData.isExclusiveCheckable())
			{
				if (mRadioButton == null)
				{
					insertRadioButton();
				}
				compoundButton = mRadioButton;
			}
			else
			{
				if (mCheckBox == null)
				{
					insertCheckBox();
				}
				compoundButton = mCheckBox;
			}
			compoundButton.setChecked(@checked);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setShortcut(bool showShortcut, char shortcutKey)
		{
			int newVisibility = (showShortcut && mItemData.shouldShowShortcut()) ? VISIBLE : 
				GONE;
			if (newVisibility == VISIBLE)
			{
				mShortcutView.setText(java.lang.CharSequenceProxy.Wrap(mItemData.getShortcutLabel
					()));
			}
			if (mShortcutView.getVisibility() != newVisibility)
			{
				mShortcutView.setVisibility(newVisibility);
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setIcon(android.graphics.drawable.Drawable icon)
		{
			bool showIcon = mItemData.shouldShowIcon() || mForceShowIcon;
			if (!showIcon && !mPreserveIconSpacing)
			{
				return;
			}
			if (mIconView == null && icon == null && !mPreserveIconSpacing)
			{
				return;
			}
			if (mIconView == null)
			{
				insertIconView();
			}
			if (icon != null || mPreserveIconSpacing)
			{
				mIconView.setImageDrawable(showIcon ? icon : null);
				if (mIconView.getVisibility() != VISIBLE)
				{
					mIconView.setVisibility(VISIBLE);
				}
			}
			else
			{
				mIconView.setVisibility(GONE);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			if (mIconView != null && mPreserveIconSpacing)
			{
				// Enforce minimum icon spacing
				android.view.ViewGroup.LayoutParams lp = getLayoutParams();
				android.widget.LinearLayout.LayoutParams iconLp = (android.widget.LinearLayout.LayoutParams
					)mIconView.getLayoutParams();
				if (lp.height > 0 && iconLp.width <= 0)
				{
					iconLp.width = lp.height;
				}
			}
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
		}

		private void insertIconView()
		{
			android.view.LayoutInflater inflater = getInflater();
			mIconView = (android.widget.ImageView)inflater.inflate(android.@internal.R.layout
				.list_menu_item_icon, this, false);
			addView(mIconView, 0);
		}

		private void insertRadioButton()
		{
			android.view.LayoutInflater inflater = getInflater();
			mRadioButton = (android.widget.RadioButton)inflater.inflate(android.@internal.R.layout
				.list_menu_item_radio, this, false);
			addView(mRadioButton);
		}

		private void insertCheckBox()
		{
			android.view.LayoutInflater inflater = getInflater();
			mCheckBox = (android.widget.CheckBox)inflater.inflate(android.@internal.R.layout.
				list_menu_item_checkbox, this, false);
			addView(mCheckBox);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual bool prefersCondensedTitle()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual bool showsIcon()
		{
			return mForceShowIcon;
		}

		private android.view.LayoutInflater getInflater()
		{
			if (mInflater == null)
			{
				mInflater = android.view.LayoutInflater.from(mContext);
			}
			return mInflater;
		}
	}
}
