using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>MenuPresenter for the classic "six-pack" icon menu.</summary>
	/// <remarks>MenuPresenter for the classic "six-pack" icon menu.</remarks>
	[Sharpen.Sharpened]
	public class IconMenuPresenter : android.view.@internal.menu.BaseMenuPresenter
	{
		private android.view.@internal.menu.IconMenuItemView mMoreView;

		private int mMaxItems = -1;

		internal int mOpenSubMenuId;

		internal android.view.@internal.menu.IconMenuPresenter.SubMenuPresenterCallback mSubMenuPresenterCallback;

		internal android.view.@internal.menu.MenuDialogHelper mOpenSubMenu;

		internal const string VIEWS_TAG = "android:menu:icon";

		internal const string OPEN_SUBMENU_KEY = "android:menu:icon:submenu";

		public IconMenuPresenter(android.content.Context context) : base(new android.view.ContextThemeWrapper
			(context, android.@internal.R.style.Theme_IconMenu), android.@internal.R.layout.
			icon_menu_layout, android.@internal.R.layout.icon_menu_item_layout)
		{
			mSubMenuPresenterCallback = new android.view.@internal.menu.IconMenuPresenter.SubMenuPresenterCallback
				(this);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu)
		{
			base.initForMenu(context, menu);
			mMaxItems = -1;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void bindItemView(android.view.@internal.menu.MenuItemImpl item, 
			android.view.@internal.menu.MenuViewClass.ItemView itemView)
		{
			android.view.@internal.menu.IconMenuItemView view = (android.view.@internal.menu.IconMenuItemView
				)itemView;
			view.setItemData(item);
			view.initialize(item.getTitleForItemView(view), item.getIcon());
			view.setVisibility(item.isVisible() ? android.view.View.VISIBLE : android.view.View
				.GONE);
			view.setEnabled(view.isEnabled());
			view.setLayoutParams(view.getTextAppropriateLayoutParams());
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override bool shouldIncludeItem(int childIndex, android.view.@internal.menu.MenuItemImpl
			 item)
		{
			java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> itemsToShow = mMenu
				.getNonActionItems();
			bool fits = (itemsToShow.size() == mMaxItems && childIndex < mMaxItems) || childIndex
				 < mMaxItems - 1;
			return fits && !item.isActionButton();
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		protected internal override void addItemView(android.view.View itemView, int childIndex
			)
		{
			android.view.@internal.menu.IconMenuItemView v = (android.view.@internal.menu.IconMenuItemView
				)itemView;
			android.view.@internal.menu.IconMenuView parent = (android.view.@internal.menu.IconMenuView
				)mMenuView;
			v.setIconMenuView(parent);
			v.setItemInvoker(parent);
			v.setBackgroundDrawable(parent.getItemBackgroundDrawable());
			base.addItemView(itemView, childIndex);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder
			 subMenu)
		{
			if (!subMenu.hasVisibleItems())
			{
				return false;
			}
			// The window manager will give us a token.
			android.view.@internal.menu.MenuDialogHelper helper = new android.view.@internal.menu.MenuDialogHelper
				(subMenu);
			helper.setPresenterCallback(mSubMenuPresenterCallback);
			helper.show(null);
			mOpenSubMenu = helper;
			mOpenSubMenuId = subMenu.getItem().getItemId();
			base.onSubMenuSelected(subMenu);
			return true;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void updateMenuView(bool cleared)
		{
			android.view.@internal.menu.IconMenuView menuView = (android.view.@internal.menu.IconMenuView
				)mMenuView;
			if (mMaxItems < 0)
			{
				mMaxItems = menuView.getMaxItems();
			}
			java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> itemsToShow = mMenu
				.getNonActionItems();
			bool needsMore = itemsToShow.size() > mMaxItems;
			base.updateMenuView(cleared);
			if (needsMore && (mMoreView == null || mMoreView.getParent() != menuView))
			{
				if (mMoreView == null)
				{
					mMoreView = menuView.createMoreItemView();
					mMoreView.setBackgroundDrawable(menuView.getItemBackgroundDrawable());
				}
				menuView.addView(mMoreView);
			}
			else
			{
				if (!needsMore && mMoreView != null)
				{
					menuView.removeView(mMoreView);
				}
			}
			menuView.setNumActualItemsShown(needsMore ? mMaxItems - 1 : itemsToShow.size());
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		protected internal override bool filterLeftoverView(android.view.ViewGroup parent
			, int childIndex)
		{
			if (parent.getChildAt(childIndex) != mMoreView)
			{
				return base.filterLeftoverView(parent, childIndex);
			}
			return false;
		}

		public virtual int getNumActualItemsShown()
		{
			return ((android.view.@internal.menu.IconMenuView)mMenuView).getNumActualItemsShown
				();
		}

		[Sharpen.Stub]
		public virtual void saveHierarchyState(android.os.Bundle outState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void restoreHierarchyState(android.os.Bundle inState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public override android.os.Parcelable onSaveInstanceState()
		{
			if (mMenuView == null)
			{
				return null;
			}
			android.os.Bundle state = new android.os.Bundle();
			saveHierarchyState(state);
			if (mOpenSubMenuId > 0)
			{
				state.putInt(OPEN_SUBMENU_KEY, mOpenSubMenuId);
			}
			return state;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public override void onRestoreInstanceState(android.os.Parcelable state)
		{
			restoreHierarchyState((android.os.Bundle)state);
		}

		internal class SubMenuPresenterCallback : android.view.@internal.menu.MenuPresenterClass
			.Callback
		{
			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
				)]
			public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
				 allMenusAreClosing)
			{
				this._enclosing.mOpenSubMenuId = 0;
				if (this._enclosing.mOpenSubMenu != null)
				{
					this._enclosing.mOpenSubMenu.dismiss();
					this._enclosing.mOpenSubMenu = null;
				}
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
				)]
			public virtual bool onOpenSubMenu(android.view.@internal.menu.MenuBuilder subMenu
				)
			{
				if (subMenu != null)
				{
					this._enclosing.mOpenSubMenuId = ((android.view.@internal.menu.SubMenuBuilder)subMenu
						).getItem().getItemId();
				}
				return false;
			}

			internal SubMenuPresenterCallback(IconMenuPresenter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly IconMenuPresenter _enclosing;
		}
	}
}
