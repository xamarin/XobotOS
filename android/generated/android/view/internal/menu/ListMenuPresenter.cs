using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>MenuPresenter for list-style menus.</summary>
	/// <remarks>MenuPresenter for list-style menus.</remarks>
	[Sharpen.Sharpened]
	public class ListMenuPresenter : android.view.@internal.menu.MenuPresenter, android.widget.AdapterView
		.OnItemClickListener
	{
		internal const string TAG = "ListMenuPresenter";

		internal android.content.Context mContext;

		internal android.view.LayoutInflater mInflater;

		internal android.view.@internal.menu.MenuBuilder mMenu;

		internal android.view.@internal.menu.ExpandedMenuView mMenuView;

		private int mItemIndexOffset;

		internal int mThemeRes;

		internal int mItemLayoutRes;

		private android.view.@internal.menu.MenuPresenterClass.Callback mCallback;

		private android.view.@internal.menu.ListMenuPresenter.MenuAdapter mAdapter;

		private int mId;

		public const string VIEWS_TAG = "android:menu:list";

		/// <summary>Construct a new ListMenuPresenter.</summary>
		/// <remarks>Construct a new ListMenuPresenter.</remarks>
		/// <param name="context">
		/// Context to use for theming. This will supersede the context provided
		/// to initForMenu when this presenter is added.
		/// </param>
		/// <param name="itemLayoutRes">Layout resource for individual item views.</param>
		public ListMenuPresenter(android.content.Context context, int itemLayoutRes) : this
			(itemLayoutRes, 0)
		{
			mContext = context;
			mInflater = android.view.LayoutInflater.from(mContext);
		}

		/// <summary>Construct a new ListMenuPresenter.</summary>
		/// <remarks>Construct a new ListMenuPresenter.</remarks>
		/// <param name="itemLayoutRes">Layout resource for individual item views.</param>
		/// <param name="themeRes">Resource ID of a theme to use for views.</param>
		public ListMenuPresenter(int itemLayoutRes, int themeRes)
		{
			mItemLayoutRes = itemLayoutRes;
			mThemeRes = themeRes;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu)
		{
			if (mThemeRes != 0)
			{
				mContext = new android.view.ContextThemeWrapper(context, mThemeRes);
				mInflater = android.view.LayoutInflater.from(mContext);
			}
			else
			{
				if (mContext != null)
				{
					mContext = context;
					if (mInflater == null)
					{
						mInflater = android.view.LayoutInflater.from(mContext);
					}
				}
			}
			mMenu = menu;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup
			 root)
		{
			if (mMenuView == null)
			{
				mMenuView = (android.view.@internal.menu.ExpandedMenuView)mInflater.inflate(android.@internal.R
					.layout.expanded_menu_layout, root, false);
				if (mAdapter == null)
				{
					mAdapter = new android.view.@internal.menu.ListMenuPresenter.MenuAdapter(this);
				}
				mMenuView.setAdapter(mAdapter);
				mMenuView.setOnItemClickListener(this);
			}
			return mMenuView;
		}

		/// <summary>Call this instead of getMenuView if you want to manage your own ListView.
		/// 	</summary>
		/// <remarks>
		/// Call this instead of getMenuView if you want to manage your own ListView.
		/// For proper operation, the ListView hosting this adapter should add
		/// this presenter as an OnItemClickListener.
		/// </remarks>
		/// <returns>A ListAdapter containing the items in the menu.</returns>
		public virtual android.widget.ListAdapter getAdapter()
		{
			if (mAdapter == null)
			{
				mAdapter = new android.view.@internal.menu.ListMenuPresenter.MenuAdapter(this);
			}
			return mAdapter;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void updateMenuView(bool cleared)
		{
			if (mAdapter != null)
			{
				mAdapter.notifyDataSetChanged();
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void setCallback(android.view.@internal.menu.MenuPresenterClass.Callback
			 cb)
		{
			mCallback = cb;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
			subMenu)
		{
			if (!subMenu.hasVisibleItems())
			{
				return false;
			}
			// The window manager will give us a token.
			new android.view.@internal.menu.MenuDialogHelper(subMenu).show(null);
			if (mCallback != null)
			{
				mCallback.onOpenSubMenu(subMenu);
			}
			return true;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			if (mCallback != null)
			{
				mCallback.onCloseMenu(menu, allMenusAreClosing);
			}
		}

		internal virtual int getItemIndexOffset()
		{
			return mItemIndexOffset;
		}

		public virtual void setItemIndexOffset(int offset)
		{
			mItemIndexOffset = offset;
			if (mMenuView != null)
			{
				updateMenuView(false);
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
		public virtual void onItemClick(object parent, android.view.View view, int position
			, long id)
		{
			mMenu.performItemAction(((android.view.@internal.menu.MenuItemImpl)mAdapter.getItem
				(position)), 0);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool flagActionItems()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool expandItemActionView(android.view.@internal.menu.MenuBuilder 
			menu, android.view.@internal.menu.MenuItemImpl item)
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool collapseItemActionView(android.view.@internal.menu.MenuBuilder
			 menu, android.view.@internal.menu.MenuItemImpl item)
		{
			return false;
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

		public virtual void setId(int id)
		{
			mId = id;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual int getId()
		{
			return mId;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual android.os.Parcelable onSaveInstanceState()
		{
			if (mMenuView == null)
			{
				return null;
			}
			android.os.Bundle state = new android.os.Bundle();
			saveHierarchyState(state);
			return state;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void onRestoreInstanceState(android.os.Parcelable state)
		{
			restoreHierarchyState((android.os.Bundle)state);
		}

		private class MenuAdapter : android.widget.BaseAdapter
		{
			internal int mExpandedIndex;

			public MenuAdapter(ListMenuPresenter _enclosing)
			{
				this._enclosing = _enclosing;
				mExpandedIndex = -1;
				this.registerDataSetObserver(new android.view.@internal.menu.ListMenuPresenter.ExpandedIndexObserver
					(this._enclosing));
				this.findExpandedIndex();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> items = this._enclosing
					.mMenu.getNonActionItems();
				int count = items.size() - this._enclosing.mItemIndexOffset;
				if (this.mExpandedIndex < 0)
				{
					return count;
				}
				return count - 1;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> items = this._enclosing
					.mMenu.getNonActionItems();
				position += this._enclosing.mItemIndexOffset;
				if (this.mExpandedIndex >= 0 && position >= this.mExpandedIndex)
				{
					position++;
				}
				return items.get(position);
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				// Since a menu item's ID is optional, we'll use the position as an
				// ID for the item in the AdapterView
				return position;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				if (convertView == null)
				{
					convertView = this._enclosing.mInflater.inflate(this._enclosing.mItemLayoutRes, parent
						, false);
				}
				android.view.@internal.menu.MenuViewClass.ItemView itemView = (android.view.@internal.menu.MenuViewClass
					.ItemView)convertView;
				itemView.initialize(((android.view.@internal.menu.MenuItemImpl)this.getItem(position
					)), 0);
				return convertView;
			}

			internal virtual void findExpandedIndex()
			{
				android.view.@internal.menu.MenuItemImpl expandedItem = this._enclosing.mMenu.getExpandedItem
					();
				if (expandedItem != null)
				{
					java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> items = this._enclosing
						.mMenu.getNonActionItems();
					int count = items.size();
					{
						for (int i = 0; i < count; i++)
						{
							android.view.@internal.menu.MenuItemImpl item = items.get(i);
							if (item == expandedItem)
							{
								this.mExpandedIndex = i;
								return;
							}
						}
					}
				}
				this.mExpandedIndex = -1;
			}

			private readonly ListMenuPresenter _enclosing;
		}

		private class ExpandedIndexObserver : android.database.DataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				this._enclosing.mAdapter.findExpandedIndex();
			}

			internal ExpandedIndexObserver(ListMenuPresenter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ListMenuPresenter _enclosing;
		}
	}
}
