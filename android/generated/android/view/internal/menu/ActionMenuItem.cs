using Sharpen;

namespace android.view.@internal.menu
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionMenuItem : android.view.MenuItem
	{
		private readonly int mId;

		private readonly int mGroup;

		private readonly int mCategoryOrder;

		private readonly int mOrdering;

		private java.lang.CharSequence mTitle;

		private java.lang.CharSequence mTitleCondensed;

		private android.content.Intent mIntent;

		private char mShortcutNumericChar;

		private char mShortcutAlphabeticChar;

		private android.graphics.drawable.Drawable mIconDrawable;

		private int mIconResId = NO_ICON;

		private android.content.Context mContext;

		private android.view.MenuItemClass.OnMenuItemClickListener mClickListener;

		internal const int NO_ICON = 0;

		private int mFlags = ENABLED;

		internal const int CHECKABLE = unchecked((int)(0x00000001));

		internal const int CHECKED = unchecked((int)(0x00000002));

		internal const int EXCLUSIVE = unchecked((int)(0x00000004));

		internal const int HIDDEN = unchecked((int)(0x00000008));

		internal const int ENABLED = unchecked((int)(0x00000010));

		public ActionMenuItem(android.content.Context context, int group, int id, int categoryOrder
			, int ordering, java.lang.CharSequence title)
		{
			mContext = context;
			mId = id;
			mGroup = group;
			mCategoryOrder = categoryOrder;
			mOrdering = ordering;
			mTitle = title;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual char getAlphabeticShortcut()
		{
			return mShortcutAlphabeticChar;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual int getGroupId()
		{
			return mGroup;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.graphics.drawable.Drawable getIcon()
		{
			return mIconDrawable;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.content.Intent getIntent()
		{
			return mIntent;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual int getItemId()
		{
			return mId;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.ContextMenuClass.ContextMenuInfo getMenuInfo()
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual char getNumericShortcut()
		{
			return mShortcutNumericChar;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual int getOrder()
		{
			return mOrdering;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.SubMenu getSubMenu()
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual java.lang.CharSequence getTitle()
		{
			return mTitle;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual java.lang.CharSequence getTitleCondensed()
		{
			return mTitleCondensed;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool hasSubMenu()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool isCheckable()
		{
			return (mFlags & CHECKABLE) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool isChecked()
		{
			return (mFlags & CHECKED) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool isEnabled()
		{
			return (mFlags & ENABLED) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool isVisible()
		{
			return (mFlags & HIDDEN) == 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setAlphabeticShortcut(char alphaChar)
		{
			mShortcutAlphabeticChar = alphaChar;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setCheckable(bool checkable)
		{
			mFlags = (mFlags & ~CHECKABLE) | (checkable ? CHECKABLE : 0);
			return this;
		}

		public virtual android.view.@internal.menu.ActionMenuItem setExclusiveCheckable(bool
			 exclusive)
		{
			mFlags = (mFlags & ~EXCLUSIVE) | (exclusive ? EXCLUSIVE : 0);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setChecked(bool @checked)
		{
			mFlags = (mFlags & ~CHECKED) | (@checked ? CHECKED : 0);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setEnabled(bool enabled)
		{
			mFlags = (mFlags & ~ENABLED) | (enabled ? ENABLED : 0);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setIcon(android.graphics.drawable.Drawable icon
			)
		{
			mIconDrawable = icon;
			mIconResId = NO_ICON;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setIcon(int iconRes)
		{
			mIconResId = iconRes;
			mIconDrawable = mContext.getResources().getDrawable(iconRes);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setIntent(android.content.Intent intent)
		{
			mIntent = intent;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setNumericShortcut(char numericChar)
		{
			mShortcutNumericChar = numericChar;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setOnMenuItemClickListener(android.view.MenuItemClass
			.OnMenuItemClickListener menuItemClickListener)
		{
			mClickListener = menuItemClickListener;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setShortcut(char numericChar, char alphaChar
			)
		{
			mShortcutNumericChar = numericChar;
			mShortcutAlphabeticChar = alphaChar;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setTitle(int title)
		{
			mTitle = java.lang.CharSequenceProxy.Wrap(mContext.getResources().getString(title
				));
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setTitleCondensed(java.lang.CharSequence title
			)
		{
			mTitleCondensed = title;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setVisible(bool visible)
		{
			mFlags = (mFlags & HIDDEN) | (visible ? 0 : HIDDEN);
			return this;
		}

		public virtual bool invoke()
		{
			if (mClickListener != null && mClickListener.onMenuItemClick(this))
			{
				return true;
			}
			if (mIntent != null)
			{
				mContext.startActivity(mIntent);
				return true;
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual void setShowAsAction(int show)
		{
		}

		// Do nothing. ActionMenuItems always show as action buttons.
		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setActionView(android.view.View actionView)
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.View getActionView()
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setActionView(int resId)
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.ActionProvider getActionProvider()
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setActionProvider(android.view.ActionProvider
			 actionProvider)
		{
			throw new System.NotSupportedException();
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setShowAsActionFlags(int actionEnum)
		{
			setShowAsAction(actionEnum);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool expandActionView()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool collapseActionView()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual bool isActionViewExpanded()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public virtual android.view.MenuItem setOnActionExpandListener(android.view.MenuItemClass
			.OnActionExpandListener listener)
		{
			// No need to save the listener; ActionMenuItem does not support collapsing items.
			return this;
		}
	}
}
