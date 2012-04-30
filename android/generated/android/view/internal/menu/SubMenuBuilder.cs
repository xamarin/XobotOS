using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>The model for a sub menu, which is an extension of the menu.</summary>
	/// <remarks>
	/// The model for a sub menu, which is an extension of the menu.  Most methods are proxied to
	/// the parent menu.
	/// </remarks>
	[Sharpen.Sharpened]
	public class SubMenuBuilder : android.view.@internal.menu.MenuBuilder, android.view.SubMenu
	{
		private android.view.@internal.menu.MenuBuilder mParentMenu;

		private android.view.@internal.menu.MenuItemImpl mItem;

		public SubMenuBuilder(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 parentMenu, android.view.@internal.menu.MenuItemImpl item) : base(context)
		{
			mParentMenu = parentMenu;
			mItem = item;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override void setQwertyMode(bool isQwerty)
		{
			mParentMenu.setQwertyMode(isQwerty);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		internal override bool isQwertyMode()
		{
			return mParentMenu.isQwertyMode();
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override void setShortcutsVisible(bool shortcutsVisible)
		{
			mParentMenu.setShortcutsVisible(shortcutsVisible);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override bool isShortcutsVisible()
		{
			return mParentMenu.isShortcutsVisible();
		}

		public virtual android.view.Menu getParentMenu()
		{
			return mParentMenu;
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.MenuItem getItem()
		{
			return mItem;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override void setCallback(android.view.@internal.menu.MenuBuilder.Callback
			 callback)
		{
			mParentMenu.setCallback(callback);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override android.view.@internal.menu.MenuBuilder getRootMenu()
		{
			return mParentMenu;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		internal override bool dispatchMenuItemSelected(android.view.@internal.menu.MenuBuilder
			 menu, android.view.MenuItem item)
		{
			return base.dispatchMenuItemSelected(menu, item) || mParentMenu.dispatchMenuItemSelected
				(menu, item);
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setIcon(android.graphics.drawable.Drawable icon
			)
		{
			mItem.setIcon(icon);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setIcon(int iconRes)
		{
			mItem.setIcon(iconRes);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setHeaderIcon(android.graphics.drawable.Drawable
			 icon)
		{
			return (android.view.SubMenu)base.setHeaderIconInt(icon);
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setHeaderIcon(int iconRes)
		{
			return (android.view.SubMenu)base.setHeaderIconInt(iconRes);
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setHeaderTitle(java.lang.CharSequence title)
		{
			return (android.view.SubMenu)base.setHeaderTitleInt(title);
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setHeaderTitle(int titleRes)
		{
			return (android.view.SubMenu)base.setHeaderTitleInt(titleRes);
		}

		[Sharpen.ImplementsInterface(@"android.view.SubMenu")]
		public virtual android.view.SubMenu setHeaderView(android.view.View view)
		{
			return (android.view.SubMenu)base.setHeaderViewInt(view);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override bool expandItemActionView(android.view.@internal.menu.MenuItemImpl
			 item)
		{
			return mParentMenu.expandItemActionView(item);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		public override bool collapseItemActionView(android.view.@internal.menu.MenuItemImpl
			 item)
		{
			return mParentMenu.collapseItemActionView(item);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuBuilder")]
		protected internal override string getActionViewStatesKey()
		{
			int itemId = mItem != null ? mItem.getItemId() : 0;
			if (itemId == 0)
			{
				return null;
			}
			return base.getActionViewStatesKey() + ":" + itemId;
		}
	}
}
