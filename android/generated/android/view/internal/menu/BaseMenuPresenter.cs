using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>
	/// Base class for MenuPresenters that have a consistent container view and item
	/// views.
	/// </summary>
	/// <remarks>
	/// Base class for MenuPresenters that have a consistent container view and item
	/// views. Behaves similarly to an AdapterView in that existing item views will
	/// be reused if possible when items change.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class BaseMenuPresenter : android.view.@internal.menu.MenuPresenter
	{
		protected internal android.content.Context mSystemContext;

		protected internal android.content.Context mContext;

		protected internal android.view.@internal.menu.MenuBuilder mMenu;

		protected internal android.view.LayoutInflater mSystemInflater;

		protected internal android.view.LayoutInflater mInflater;

		private android.view.@internal.menu.MenuPresenterClass.Callback mCallback;

		private int mMenuLayoutRes;

		private int mItemLayoutRes;

		protected internal android.view.@internal.menu.MenuView mMenuView;

		private int mId;

		/// <summary>Construct a new BaseMenuPresenter.</summary>
		/// <remarks>Construct a new BaseMenuPresenter.</remarks>
		/// <param name="context">Context for generating system-supplied views</param>
		/// <param name="menuLayoutRes">Layout resource ID for the menu container view</param>
		/// <param name="itemLayoutRes">Layout resource ID for a single item view</param>
		public BaseMenuPresenter(android.content.Context context, int menuLayoutRes, int 
			itemLayoutRes)
		{
			mSystemContext = context;
			mSystemInflater = android.view.LayoutInflater.from(context);
			mMenuLayoutRes = menuLayoutRes;
			mItemLayoutRes = itemLayoutRes;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu)
		{
			mContext = context;
			mInflater = android.view.LayoutInflater.from(mContext);
			mMenu = menu;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup
			 root)
		{
			if (mMenuView == null)
			{
				mMenuView = (android.view.@internal.menu.MenuView)mSystemInflater.inflate(mMenuLayoutRes
					, root, false);
				mMenuView.initialize(mMenu);
				updateMenuView(true);
			}
			return mMenuView;
		}

		/// <summary>Reuses item views when it can</summary>
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void updateMenuView(bool cleared)
		{
			android.view.ViewGroup parent = (android.view.ViewGroup)mMenuView;
			if (parent == null)
			{
				return;
			}
			int childIndex = 0;
			if (mMenu != null)
			{
				mMenu.flagActionItems();
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> visibleItems = mMenu
					.getVisibleItems();
				int itemCount = visibleItems.size();
				{
					for (int i = 0; i < itemCount; i++)
					{
						android.view.@internal.menu.MenuItemImpl item = visibleItems.get(i);
						if (shouldIncludeItem(childIndex, item))
						{
							android.view.View convertView = parent.getChildAt(childIndex);
							android.view.View itemView = getItemView(item, convertView, parent);
							if (itemView != convertView)
							{
								addItemView(itemView, childIndex);
							}
							childIndex++;
						}
					}
				}
			}
			// Remove leftover views.
			while (childIndex < parent.getChildCount())
			{
				if (!filterLeftoverView(parent, childIndex))
				{
					childIndex++;
				}
			}
		}

		/// <summary>Add an item view at the given index.</summary>
		/// <remarks>Add an item view at the given index.</remarks>
		/// <param name="itemView">View to add</param>
		/// <param name="childIndex">Index within the parent to insert at</param>
		protected internal virtual void addItemView(android.view.View itemView, int childIndex
			)
		{
			android.view.ViewGroup currentParent = (android.view.ViewGroup)itemView.getParent
				();
			if (currentParent != null)
			{
				currentParent.removeView(itemView);
			}
			((android.view.ViewGroup)mMenuView).addView(itemView, childIndex);
		}

		/// <summary>Filter the child view at index and remove it if appropriate.</summary>
		/// <remarks>Filter the child view at index and remove it if appropriate.</remarks>
		/// <param name="parent">Parent to filter from</param>
		/// <param name="childIndex">Index to filter</param>
		/// <returns>true if the child view at index was removed</returns>
		protected internal virtual bool filterLeftoverView(android.view.ViewGroup parent, 
			int childIndex)
		{
			parent.removeViewAt(childIndex);
			return true;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void setCallback(android.view.@internal.menu.MenuPresenterClass.Callback
			 cb)
		{
			mCallback = cb;
		}

		/// <summary>Create a new item view that can be re-bound to other item data later.</summary>
		/// <remarks>Create a new item view that can be re-bound to other item data later.</remarks>
		/// <returns>The new item view</returns>
		public virtual android.view.@internal.menu.MenuViewClass.ItemView createItemView(
			android.view.ViewGroup parent)
		{
			return (android.view.@internal.menu.MenuViewClass.ItemView)mSystemInflater.inflate
				(mItemLayoutRes, parent, false);
		}

		/// <summary>Prepare an item view for use.</summary>
		/// <remarks>
		/// Prepare an item view for use. See AdapterView for the basic idea at work here.
		/// This may require creating a new item view, but well-behaved implementations will
		/// re-use the view passed as convertView if present. The returned view will be populated
		/// with data from the item parameter.
		/// </remarks>
		/// <param name="item">Item to present</param>
		/// <param name="convertView">Existing view to reuse</param>
		/// <param name="parent">Intended parent view - use for inflation.</param>
		/// <returns>View that presents the requested menu item</returns>
		public virtual android.view.View getItemView(android.view.@internal.menu.MenuItemImpl
			 item, android.view.View convertView, android.view.ViewGroup parent)
		{
			android.view.@internal.menu.MenuViewClass.ItemView itemView;
			if (convertView is android.view.@internal.menu.MenuViewClass.ItemView)
			{
				itemView = (android.view.@internal.menu.MenuViewClass.ItemView)convertView;
			}
			else
			{
				itemView = createItemView(parent);
			}
			bindItemView(item, itemView);
			return (android.view.View)itemView;
		}

		/// <summary>Bind item data to an existing item view.</summary>
		/// <remarks>Bind item data to an existing item view.</remarks>
		/// <param name="item">Item to bind</param>
		/// <param name="itemView">View to populate with item data</param>
		public abstract void bindItemView(android.view.@internal.menu.MenuItemImpl item, 
			android.view.@internal.menu.MenuViewClass.ItemView itemView);

		/// <summary>Filter item by child index and item data.</summary>
		/// <remarks>Filter item by child index and item data.</remarks>
		/// <param name="childIndex">Indended presentation index of this item</param>
		/// <param name="item">Item to present</param>
		/// <returns>true if this item should be included in this menu presentation; false otherwise
		/// 	</returns>
		public virtual bool shouldIncludeItem(int childIndex, android.view.@internal.menu.MenuItemImpl
			 item)
		{
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

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
			menu)
		{
			if (mCallback != null)
			{
				return mCallback.onOpenSubMenu(menu);
			}
			return false;
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

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual int getId()
		{
			return mId;
		}

		public virtual void setId(int id)
		{
			mId = id;
		}

		public abstract void onRestoreInstanceState(android.os.Parcelable arg1);

		public abstract android.os.Parcelable onSaveInstanceState();
	}
}
