using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>Presents a menu as a small, simple popup anchored to another view.</summary>
	/// <remarks>Presents a menu as a small, simple popup anchored to another view.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class MenuPopupHelper : android.widget.AdapterView.OnItemClickListener, android.view.View
		.OnKeyListener, android.view.ViewTreeObserver.OnGlobalLayoutListener, android.widget.PopupWindow
		.OnDismissListener, android.view.View.OnAttachStateChangeListener, android.view.@internal.menu.MenuPresenter
	{
		internal const string TAG = "MenuPopupHelper";

		internal const int ITEM_LAYOUT = android.@internal.R.layout.popup_menu_item_layout;

		private android.content.Context mContext;

		private android.view.LayoutInflater mInflater;

		private android.widget.ListPopupWindow mPopup;

		private android.view.@internal.menu.MenuBuilder mMenu;

		private int mPopupMaxWidth;

		private android.view.View mAnchorView;

		private bool mOverflowOnly;

		private android.view.ViewTreeObserver mTreeObserver;

		private android.view.@internal.menu.MenuPopupHelper.MenuAdapter mAdapter;

		private android.view.@internal.menu.MenuPresenterClass.Callback mPresenterCallback;

		internal bool mForceShowIcon;

		private android.view.ViewGroup mMeasureParent;

		public MenuPopupHelper(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu) : this(context, menu, null, false)
		{
		}

		public MenuPopupHelper(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu, android.view.View anchorView) : this(context, menu, anchorView, false)
		{
		}

		public MenuPopupHelper(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu, android.view.View anchorView, bool overflowOnly)
		{
			mContext = context;
			mInflater = android.view.LayoutInflater.from(context);
			mMenu = menu;
			mOverflowOnly = overflowOnly;
			android.content.res.Resources res = context.getResources();
			mPopupMaxWidth = System.Math.Max(res.getDisplayMetrics().widthPixels / 2, res.getDimensionPixelSize
				(android.@internal.R.dimen.config_prefDialogWidth));
			mAnchorView = anchorView;
			menu.addMenuPresenter(this);
		}

		public virtual void setAnchorView(android.view.View anchor)
		{
			mAnchorView = anchor;
		}

		public virtual void setForceShowIcon(bool forceShow)
		{
			mForceShowIcon = forceShow;
		}

		public virtual void show()
		{
			if (!tryShow())
			{
				throw new System.InvalidOperationException("MenuPopupHelper cannot be used without an anchor"
					);
			}
		}

		public virtual bool tryShow()
		{
			mPopup = new android.widget.ListPopupWindow(mContext, null, android.@internal.R.attr
				.popupMenuStyle);
			mPopup.setOnDismissListener(this);
			mPopup.setOnItemClickListener(this);
			mAdapter = new android.view.@internal.menu.MenuPopupHelper.MenuAdapter(this, mMenu
				);
			mPopup.setAdapter(mAdapter);
			mPopup.setModal(true);
			android.view.View anchor = mAnchorView;
			if (anchor != null)
			{
				bool addGlobalListener = mTreeObserver == null;
				mTreeObserver = anchor.getViewTreeObserver();
				// Refresh to latest
				if (addGlobalListener)
				{
					mTreeObserver.addOnGlobalLayoutListener(this);
				}
				anchor.addOnAttachStateChangeListener(this);
				mPopup.setAnchorView(anchor);
			}
			else
			{
				return false;
			}
			mPopup.setContentWidth(System.Math.Min(measureContentWidth(mAdapter), mPopupMaxWidth
				));
			mPopup.setInputMethodMode(android.widget.PopupWindow.INPUT_METHOD_NOT_NEEDED);
			mPopup.show();
			mPopup.getListView().setOnKeyListener(this);
			return true;
		}

		public virtual void dismiss()
		{
			if (isShowing())
			{
				mPopup.dismiss();
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.PopupWindow.OnDismissListener")]
		public virtual void onDismiss()
		{
			mPopup = null;
			mMenu.close();
			if (mTreeObserver != null)
			{
				if (!mTreeObserver.isAlive())
				{
					mTreeObserver = mAnchorView.getViewTreeObserver();
				}
				mTreeObserver.removeGlobalOnLayoutListener(this);
				mTreeObserver = null;
			}
			mAnchorView.removeOnAttachStateChangeListener(this);
		}

		public virtual bool isShowing()
		{
			return mPopup != null && mPopup.isShowing();
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
		public virtual void onItemClick(object parent, android.view.View view, int position
			, long id)
		{
			android.view.@internal.menu.MenuPopupHelper.MenuAdapter adapter = mAdapter;
			adapter.mAdapterMenu.performItemAction(((android.view.@internal.menu.MenuItemImpl
				)adapter.getItem(position)), 0);
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnKeyListener")]
		public virtual bool onKey(android.view.View v, int keyCode, android.view.KeyEvent
			 @event)
		{
			if (@event.getAction() == android.view.KeyEvent.ACTION_UP && keyCode == android.view.KeyEvent
				.KEYCODE_MENU)
			{
				dismiss();
				return true;
			}
			return false;
		}

		private int measureContentWidth(android.widget.ListAdapter adapter)
		{
			// Menus don't tend to be long, so this is more sane than it looks.
			int width = 0;
			android.view.View itemView = null;
			int itemType = 0;
			int widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			int heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			int count = adapter.getCount();
			{
				for (int i = 0; i < count; i++)
				{
					int positionType = adapter.getItemViewType(i);
					if (positionType != itemType)
					{
						itemType = positionType;
						itemView = null;
					}
					if (mMeasureParent == null)
					{
						mMeasureParent = new android.widget.FrameLayout(mContext);
					}
					itemView = adapter.getView(i, itemView, mMeasureParent);
					itemView.measure(widthMeasureSpec, heightMeasureSpec);
					width = System.Math.Max(width, itemView.getMeasuredWidth());
				}
			}
			return width;
		}

		[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnGlobalLayoutListener"
			)]
		public virtual void onGlobalLayout()
		{
			if (isShowing())
			{
				android.view.View anchor = mAnchorView;
				if (anchor == null || !anchor.isShown())
				{
					dismiss();
				}
				else
				{
					if (isShowing())
					{
						// Recompute window size and position
						mPopup.show();
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnAttachStateChangeListener")]
		public virtual void onViewAttachedToWindow(android.view.View v)
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnAttachStateChangeListener")]
		public virtual void onViewDetachedFromWindow(android.view.View v)
		{
			if (mTreeObserver != null)
			{
				if (!mTreeObserver.isAlive())
				{
					mTreeObserver = v.getViewTreeObserver();
				}
				mTreeObserver.removeGlobalOnLayoutListener(this);
			}
			v.removeOnAttachStateChangeListener(this);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu)
		{
		}

		// Don't need to do anything; we added as a presenter in the constructor.
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup
			 root)
		{
			throw new System.NotSupportedException("MenuPopupHelpers manage their own views");
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
			mPresenterCallback = cb;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
			subMenu)
		{
			if (subMenu.hasVisibleItems())
			{
				android.view.@internal.menu.MenuPopupHelper subPopup = new android.view.@internal.menu.MenuPopupHelper
					(mContext, subMenu, mAnchorView, false);
				subPopup.setCallback(mPresenterCallback);
				bool preserveIconSpacing = false;
				int count = subMenu.size();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.MenuItem childItem = subMenu.getItem(i);
						if (childItem.isVisible() && childItem.getIcon() != null)
						{
							preserveIconSpacing = true;
							break;
						}
					}
				}
				subPopup.setForceShowIcon(preserveIconSpacing);
				if (subPopup.tryShow())
				{
					if (mPresenterCallback != null)
					{
						mPresenterCallback.onOpenSubMenu(subMenu);
					}
					return true;
				}
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			// Only care about the (sub)menu we're presenting.
			if (menu != mMenu)
			{
				return;
			}
			dismiss();
			if (mPresenterCallback != null)
			{
				mPresenterCallback.onCloseMenu(menu, allMenusAreClosing);
			}
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
			return 0;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual android.os.Parcelable onSaveInstanceState()
		{
			return null;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public virtual void onRestoreInstanceState(android.os.Parcelable state)
		{
		}

		private class MenuAdapter : android.widget.BaseAdapter
		{
			internal android.view.@internal.menu.MenuBuilder mAdapterMenu;

			internal int mExpandedIndex;

			public MenuAdapter(MenuPopupHelper _enclosing, android.view.@internal.menu.MenuBuilder
				 menu)
			{
				this._enclosing = _enclosing;
				mExpandedIndex = -1;
				this.mAdapterMenu = menu;
				this.registerDataSetObserver(new android.view.@internal.menu.MenuPopupHelper.ExpandedIndexObserver
					(this._enclosing));
				this.findExpandedIndex();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> items = this._enclosing
					.mOverflowOnly ? this.mAdapterMenu.getNonActionItems() : this.mAdapterMenu.getVisibleItems
					();
				if (this.mExpandedIndex < 0)
				{
					return items.size();
				}
				return items.size() - 1;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> items = this._enclosing
					.mOverflowOnly ? this.mAdapterMenu.getNonActionItems() : this.mAdapterMenu.getVisibleItems
					();
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
					convertView = this._enclosing.mInflater.inflate(android.view.@internal.menu.MenuPopupHelper
						.ITEM_LAYOUT, parent, false);
				}
				android.view.@internal.menu.MenuViewClass.ItemView itemView = (android.view.@internal.menu.MenuViewClass
					.ItemView)convertView;
				if (this._enclosing.mForceShowIcon)
				{
					((android.view.@internal.menu.ListMenuItemView)convertView).setForceShowIcon(true
						);
				}
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

			private readonly MenuPopupHelper _enclosing;
		}

		private class ExpandedIndexObserver : android.database.DataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				this._enclosing.mAdapter.findExpandedIndex();
			}

			internal ExpandedIndexObserver(MenuPopupHelper _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly MenuPopupHelper _enclosing;
		}
	}
}
