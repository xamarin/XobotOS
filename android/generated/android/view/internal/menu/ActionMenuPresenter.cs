using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>MenuPresenter for building action menus as seen in the action bar and action modes.
	/// 	</summary>
	/// <remarks>MenuPresenter for building action menus as seen in the action bar and action modes.
	/// 	</remarks>
	[Sharpen.Sharpened]
	public class ActionMenuPresenter : android.view.@internal.menu.BaseMenuPresenter, 
		android.view.ActionProvider.SubUiVisibilityListener
	{
		internal const string TAG = "ActionMenuPresenter";

		private android.view.View mOverflowButton;

		private bool mReserveOverflow;

		private bool mReserveOverflowSet;

		private int mWidthLimit;

		private int mActionItemWidthLimit;

		private int mMaxItems;

		private bool mMaxItemsSet;

		private bool mStrictWidthLimit;

		private bool mWidthLimitSet;

		private bool mExpandedActionViewsExclusive;

		private int mMinCellSize;

		private readonly android.util.SparseBooleanArray mActionButtonGroups = new android.util.SparseBooleanArray
			();

		private android.view.View mScrapActionButtonView;

		private android.view.@internal.menu.ActionMenuPresenter.OverflowPopup mOverflowPopup;

		private android.view.@internal.menu.ActionMenuPresenter.ActionButtonSubmenu mActionButtonPopup;

		private android.view.@internal.menu.ActionMenuPresenter.OpenOverflowRunnable mPostedOpenRunnable;

		private readonly android.view.@internal.menu.ActionMenuPresenter.PopupPresenterCallback
			 mPopupPresenterCallback;

		internal int mOpenSubMenuId;

		public ActionMenuPresenter(android.content.Context context) : base(context, android.@internal.R
			.layout.action_menu_layout, android.@internal.R.layout.action_menu_item_layout)
		{
			mPopupPresenterCallback = new android.view.@internal.menu.ActionMenuPresenter.PopupPresenterCallback
				(this);
		}

		// Group IDs that have been added as actions - used temporarily, allocated here for reuse.
		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu)
		{
			base.initForMenu(context, menu);
			android.content.res.Resources res = context.getResources();
			if (!mReserveOverflowSet)
			{
				mReserveOverflow = !android.view.ViewConfiguration.get(context).hasPermanentMenuKey
					();
			}
			if (!mWidthLimitSet)
			{
				mWidthLimit = res.getDisplayMetrics().widthPixels / 2;
			}
			// Measure for initial configuration
			if (!mMaxItemsSet)
			{
				mMaxItems = res.getInteger(android.@internal.R.integer.max_action_buttons);
			}
			int width = mWidthLimit;
			if (mReserveOverflow)
			{
				if (mOverflowButton == null)
				{
					mOverflowButton = new android.view.@internal.menu.ActionMenuPresenter.OverflowMenuButton
						(this, mSystemContext);
					int spec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View.MeasureSpec
						.UNSPECIFIED);
					mOverflowButton.measure(spec, spec);
				}
				width -= mOverflowButton.getMeasuredWidth();
			}
			else
			{
				mOverflowButton = null;
			}
			mActionItemWidthLimit = width;
			mMinCellSize = (int)(android.view.@internal.menu.ActionMenuView.MIN_CELL_SIZE * res
				.getDisplayMetrics().density);
			// Drop a scrap view as it may no longer reflect the proper context/config.
			mScrapActionButtonView = null;
		}

		public virtual void onConfigurationChanged(android.content.res.Configuration newConfig
			)
		{
			if (!mMaxItemsSet)
			{
				mMaxItems = mContext.getResources().getInteger(android.@internal.R.integer.max_action_buttons
					);
				if (mMenu != null)
				{
					mMenu.onItemsChanged(true);
				}
			}
		}

		public virtual void setWidthLimit(int width, bool strict)
		{
			mWidthLimit = width;
			mStrictWidthLimit = strict;
			mWidthLimitSet = true;
		}

		public virtual void setReserveOverflow(bool reserveOverflow)
		{
			mReserveOverflow = reserveOverflow;
			mReserveOverflowSet = true;
		}

		public virtual void setItemLimit(int itemCount)
		{
			mMaxItems = itemCount;
			mMaxItemsSet = true;
		}

		public virtual void setExpandedActionViewsExclusive(bool isExclusive)
		{
			mExpandedActionViewsExclusive = isExclusive;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup
			 root)
		{
			android.view.@internal.menu.MenuView result = base.getMenuView(root);
			((android.view.@internal.menu.ActionMenuView)result).setPresenter(this);
			return result;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override android.view.View getItemView(android.view.@internal.menu.MenuItemImpl
			 item, android.view.View convertView, android.view.ViewGroup parent)
		{
			android.view.View actionView = item.getActionView();
			if (actionView == null || item.hasCollapsibleActionView())
			{
				if (!(convertView is android.view.@internal.menu.ActionMenuItemView))
				{
					convertView = null;
				}
				actionView = base.getItemView(item, convertView, parent);
			}
			actionView.setVisibility(item.isActionViewExpanded() ? android.view.View.GONE : android.view.View
				.VISIBLE);
			android.view.@internal.menu.ActionMenuView menuParent = (android.view.@internal.menu.ActionMenuView
				)parent;
			android.view.ViewGroup.LayoutParams lp = actionView.getLayoutParams();
			if (!menuParent.checkLayoutParams(lp))
			{
				actionView.setLayoutParams(((android.view.@internal.menu.ActionMenuView.LayoutParams
					)menuParent.generateLayoutParams(lp)));
			}
			return actionView;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void bindItemView(android.view.@internal.menu.MenuItemImpl item, 
			android.view.@internal.menu.MenuViewClass.ItemView itemView)
		{
			itemView.initialize(item, 0);
			android.view.@internal.menu.ActionMenuView menuView = (android.view.@internal.menu.ActionMenuView
				)mMenuView;
			android.view.@internal.menu.ActionMenuItemView actionItemView = (android.view.@internal.menu.ActionMenuItemView
				)itemView;
			actionItemView.setItemInvoker(menuView);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override bool shouldIncludeItem(int childIndex, android.view.@internal.menu.MenuItemImpl
			 item)
		{
			return item.isActionButton();
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void updateMenuView(bool cleared)
		{
			base.updateMenuView(cleared);
			if (mMenu != null)
			{
				java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> actionItems = mMenu
					.getActionItems();
				int count = actionItems.size();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.ActionProvider provider = actionItems.get(i).getActionProvider();
						if (provider != null)
						{
							provider.setSubUiVisibilityListener(this);
						}
					}
				}
			}
			java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> nonActionItems = mMenu
				 != null ? mMenu.getNonActionItems() : null;
			bool hasOverflow = false;
			if (mReserveOverflow && nonActionItems != null)
			{
				int count = nonActionItems.size();
				if (count == 1)
				{
					hasOverflow = !nonActionItems.get(0).isActionViewExpanded();
				}
				else
				{
					hasOverflow = count > 0;
				}
			}
			if (hasOverflow)
			{
				if (mOverflowButton == null)
				{
					mOverflowButton = new android.view.@internal.menu.ActionMenuPresenter.OverflowMenuButton
						(this, mSystemContext);
				}
				android.view.ViewGroup parent = (android.view.ViewGroup)mOverflowButton.getParent
					();
				if (parent != mMenuView)
				{
					if (parent != null)
					{
						parent.removeView(mOverflowButton);
					}
					android.view.@internal.menu.ActionMenuView menuView = (android.view.@internal.menu.ActionMenuView
						)mMenuView;
					menuView.addView(mOverflowButton, menuView.generateOverflowButtonLayoutParams());
				}
			}
			else
			{
				if (mOverflowButton != null && mOverflowButton.getParent() == mMenuView)
				{
					((android.view.ViewGroup)mMenuView).removeView(mOverflowButton);
				}
			}
			((android.view.@internal.menu.ActionMenuView)mMenuView).setOverflowReserved(mReserveOverflow
				);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		protected internal override bool filterLeftoverView(android.view.ViewGroup parent
			, int childIndex)
		{
			if (parent.getChildAt(childIndex) == mOverflowButton)
			{
				return false;
			}
			return base.filterLeftoverView(parent, childIndex);
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder
			 subMenu)
		{
			if (!subMenu.hasVisibleItems())
			{
				return false;
			}
			android.view.@internal.menu.SubMenuBuilder topSubMenu = subMenu;
			while (topSubMenu.getParentMenu() != mMenu)
			{
				topSubMenu = (android.view.@internal.menu.SubMenuBuilder)topSubMenu.getParentMenu
					();
			}
			android.view.View anchor = findViewForItem(topSubMenu.getItem());
			if (anchor == null)
			{
				if (mOverflowButton == null)
				{
					return false;
				}
				anchor = mOverflowButton;
			}
			mOpenSubMenuId = subMenu.getItem().getItemId();
			mActionButtonPopup = new android.view.@internal.menu.ActionMenuPresenter.ActionButtonSubmenu
				(this, mContext, subMenu);
			mActionButtonPopup.setAnchorView(anchor);
			mActionButtonPopup.show();
			base.onSubMenuSelected(subMenu);
			return true;
		}

		private android.view.View findViewForItem(android.view.MenuItem item)
		{
			android.view.ViewGroup parent = (android.view.ViewGroup)mMenuView;
			if (parent == null)
			{
				return null;
			}
			int count = parent.getChildCount();
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View child = parent.getChildAt(i);
					if (child is android.view.@internal.menu.MenuViewClass.ItemView && ((android.view.@internal.menu.MenuViewClass
						.ItemView)child).getItemData() == item)
					{
						return child;
					}
				}
			}
			return null;
		}

		/// <summary>Display the overflow menu if one is present.</summary>
		/// <remarks>Display the overflow menu if one is present.</remarks>
		/// <returns>true if the overflow menu was shown, false otherwise.</returns>
		public virtual bool showOverflowMenu()
		{
			if (mReserveOverflow && !isOverflowMenuShowing() && mMenu != null && mMenuView !=
				 null && mPostedOpenRunnable == null)
			{
				android.view.@internal.menu.ActionMenuPresenter.OverflowPopup popup = new android.view.@internal.menu.ActionMenuPresenter
					.OverflowPopup(this, mContext, mMenu, mOverflowButton, true);
				mPostedOpenRunnable = new android.view.@internal.menu.ActionMenuPresenter.OpenOverflowRunnable
					(this, popup);
				// Post this for later; we might still need a layout for the anchor to be right.
				((android.view.View)mMenuView).post(mPostedOpenRunnable);
				// ActionMenuPresenter uses null as a callback argument here
				// to indicate overflow is opening.
				base.onSubMenuSelected(null);
				return true;
			}
			return false;
		}

		/// <summary>Hide the overflow menu if it is currently showing.</summary>
		/// <remarks>Hide the overflow menu if it is currently showing.</remarks>
		/// <returns>true if the overflow menu was hidden, false otherwise.</returns>
		public virtual bool hideOverflowMenu()
		{
			if (mPostedOpenRunnable != null && mMenuView != null)
			{
				((android.view.View)mMenuView).removeCallbacks(mPostedOpenRunnable);
				return true;
			}
			android.view.@internal.menu.MenuPopupHelper popup = mOverflowPopup;
			if (popup != null)
			{
				popup.dismiss();
				return true;
			}
			return false;
		}

		/// <summary>Dismiss all popup menus - overflow and submenus.</summary>
		/// <remarks>Dismiss all popup menus - overflow and submenus.</remarks>
		/// <returns>true if popups were dismissed, false otherwise. (This can be because none were open.)
		/// 	</returns>
		public virtual bool dismissPopupMenus()
		{
			bool result = hideOverflowMenu();
			result |= hideSubMenus();
			return result;
		}

		/// <summary>Dismiss all submenu popups.</summary>
		/// <remarks>Dismiss all submenu popups.</remarks>
		/// <returns>true if popups were dismissed, false otherwise. (This can be because none were open.)
		/// 	</returns>
		public virtual bool hideSubMenus()
		{
			if (mActionButtonPopup != null)
			{
				mActionButtonPopup.dismiss();
				return true;
			}
			return false;
		}

		/// <returns>true if the overflow menu is currently showing</returns>
		public virtual bool isOverflowMenuShowing()
		{
			return mOverflowPopup != null && mOverflowPopup.isShowing();
		}

		/// <returns>true if space has been reserved in the action menu for an overflow item.
		/// 	</returns>
		public virtual bool isOverflowReserved()
		{
			return mReserveOverflow;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override bool flagActionItems()
		{
			java.util.ArrayList<android.view.@internal.menu.MenuItemImpl> visibleItems = mMenu
				.getVisibleItems();
			int itemsSize = visibleItems.size();
			int maxActions = mMaxItems;
			int widthLimit = mActionItemWidthLimit;
			int querySpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			android.view.ViewGroup parent = (android.view.ViewGroup)mMenuView;
			int requiredItems = 0;
			int requestedItems = 0;
			int firstActionWidth = 0;
			bool hasOverflow = false;
			{
				for (int i = 0; i < itemsSize; i++)
				{
					android.view.@internal.menu.MenuItemImpl item = visibleItems.get(i);
					if (item.requiresActionButton())
					{
						requiredItems++;
					}
					else
					{
						if (item.requestsActionButton())
						{
							requestedItems++;
						}
						else
						{
							hasOverflow = true;
						}
					}
					if (mExpandedActionViewsExclusive && item.isActionViewExpanded())
					{
						// Overflow everything if we have an expanded action view and we're
						// space constrained.
						maxActions = 0;
					}
				}
			}
			// Reserve a spot for the overflow item if needed.
			if (mReserveOverflow && (hasOverflow || requiredItems + requestedItems > maxActions
				))
			{
				maxActions--;
			}
			maxActions -= requiredItems;
			android.util.SparseBooleanArray seenGroups = mActionButtonGroups;
			seenGroups.clear();
			int cellSize = 0;
			int cellsRemaining = 0;
			if (mStrictWidthLimit)
			{
				cellsRemaining = widthLimit / mMinCellSize;
				int cellSizeRemaining = widthLimit % mMinCellSize;
				cellSize = mMinCellSize + cellSizeRemaining / cellsRemaining;
			}
			{
				// Flag as many more requested items as will fit.
				for (int i_1 = 0; i_1 < itemsSize; i_1++)
				{
					android.view.@internal.menu.MenuItemImpl item = visibleItems.get(i_1);
					if (item.requiresActionButton())
					{
						android.view.View v = getItemView(item, mScrapActionButtonView, parent);
						if (mScrapActionButtonView == null)
						{
							mScrapActionButtonView = v;
						}
						if (mStrictWidthLimit)
						{
							cellsRemaining -= android.view.@internal.menu.ActionMenuView.measureChildForCells
								(v, cellSize, cellsRemaining, querySpec, 0);
						}
						else
						{
							v.measure(querySpec, querySpec);
						}
						int measuredWidth = v.getMeasuredWidth();
						widthLimit -= measuredWidth;
						if (firstActionWidth == 0)
						{
							firstActionWidth = measuredWidth;
						}
						int groupId = item.getGroupId();
						if (groupId != 0)
						{
							seenGroups.put(groupId, true);
						}
						item.setIsActionButton(true);
					}
					else
					{
						if (item.requestsActionButton())
						{
							// Items in a group with other items that already have an action slot
							// can break the max actions rule, but not the width limit.
							int groupId = item.getGroupId();
							bool inGroup = seenGroups.get(groupId);
							bool isAction = (maxActions > 0 || inGroup) && widthLimit > 0 && (!mStrictWidthLimit
								 || cellsRemaining > 0);
							if (isAction)
							{
								android.view.View v = getItemView(item, mScrapActionButtonView, parent);
								if (mScrapActionButtonView == null)
								{
									mScrapActionButtonView = v;
								}
								if (mStrictWidthLimit)
								{
									int cells = android.view.@internal.menu.ActionMenuView.measureChildForCells(v, cellSize
										, cellsRemaining, querySpec, 0);
									cellsRemaining -= cells;
									if (cells == 0)
									{
										isAction = false;
									}
								}
								else
								{
									v.measure(querySpec, querySpec);
								}
								int measuredWidth = v.getMeasuredWidth();
								widthLimit -= measuredWidth;
								if (firstActionWidth == 0)
								{
									firstActionWidth = measuredWidth;
								}
								if (mStrictWidthLimit)
								{
									isAction &= widthLimit >= 0;
								}
								else
								{
									// Did this push the entire first item past the limit?
									isAction &= widthLimit + firstActionWidth > 0;
								}
							}
							if (isAction && groupId != 0)
							{
								seenGroups.put(groupId, true);
							}
							else
							{
								if (inGroup)
								{
									// We broke the width limit. Demote the whole group, they all overflow now.
									seenGroups.put(groupId, false);
									{
										for (int j = 0; j < i_1; j++)
										{
											android.view.@internal.menu.MenuItemImpl areYouMyGroupie = visibleItems.get(j);
											if (areYouMyGroupie.getGroupId() == groupId)
											{
												// Give back the action slot
												if (areYouMyGroupie.isActionButton())
												{
													maxActions++;
												}
												areYouMyGroupie.setIsActionButton(false);
											}
										}
									}
								}
							}
							if (isAction)
							{
								maxActions--;
							}
							item.setIsActionButton(isAction);
						}
					}
				}
			}
			return true;
		}

		[Sharpen.OverridesMethod(@"com.android.internal.view.menu.BaseMenuPresenter")]
		public override void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			dismissPopupMenus();
			base.onCloseMenu(menu, allMenusAreClosing);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public override android.os.Parcelable onSaveInstanceState()
		{
			android.view.@internal.menu.ActionMenuPresenter.SavedState state = new android.view.@internal.menu.ActionMenuPresenter
				.SavedState();
			state.openSubMenuId = mOpenSubMenuId;
			return state;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter")]
		public override void onRestoreInstanceState(android.os.Parcelable state)
		{
			android.view.@internal.menu.ActionMenuPresenter.SavedState saved = (android.view.@internal.menu.ActionMenuPresenter
				.SavedState)state;
			if (saved.openSubMenuId > 0)
			{
				android.view.MenuItem item = mMenu.findItem(saved.openSubMenuId);
				if (item != null)
				{
					android.view.@internal.menu.SubMenuBuilder subMenu = (android.view.@internal.menu.SubMenuBuilder
						)item.getSubMenu();
					onSubMenuSelected(subMenu);
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.ActionProvider.SubUiVisibilityListener"
			)]
		public virtual void onSubUiVisibilityChanged(bool isVisible)
		{
			if (isVisible)
			{
				// Not a submenu, but treat it like one.
				base.onSubMenuSelected(null);
			}
			else
			{
				mMenu.close(false);
			}
		}

		private class SavedState : android.os.Parcelable
		{
			public int openSubMenuId;

			internal SavedState()
			{
			}

			internal SavedState(android.os.Parcel @in)
			{
				openSubMenuId = @in.readInt();
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				dest.writeInt(openSubMenuId);
			}

			internal sealed class _Creator_538 : android.os.ParcelableClass.Creator<android.view.@internal.menu.ActionMenuPresenter
				.SavedState>
			{
				public _Creator_538()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.@internal.menu.ActionMenuPresenter.SavedState createFromParcel
					(android.os.Parcel @in)
				{
					return new android.view.@internal.menu.ActionMenuPresenter.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.view.@internal.menu.ActionMenuPresenter.SavedState[] newArray(int 
					size)
				{
					return new android.view.@internal.menu.ActionMenuPresenter.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.view.@internal.menu.ActionMenuPresenter
				.SavedState> CREATOR = new _Creator_538();
		}

		private class OverflowMenuButton : android.widget.ImageButton, android.view.@internal.menu.ActionMenuView
			.ActionMenuChildView
		{
			public OverflowMenuButton(ActionMenuPresenter _enclosing, android.content.Context
				 context) : base(context, null, android.@internal.R.attr.actionOverflowButtonStyle
				)
			{
				this._enclosing = _enclosing;
				this.setClickable(true);
				this.setFocusable(true);
				this.setVisibility(android.view.View.VISIBLE);
				this.setEnabled(true);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			public override bool performClick()
			{
				if (base.performClick())
				{
					return true;
				}
				this.playSoundEffect(android.view.SoundEffectConstants.CLICK);
				this._enclosing.showOverflowMenu();
				return true;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.ActionMenuView.ActionMenuChildView"
				)]
			public virtual bool needsDividerBefore()
			{
				return false;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.ActionMenuView.ActionMenuChildView"
				)]
			public virtual bool needsDividerAfter()
			{
				return false;
			}

			private readonly ActionMenuPresenter _enclosing;
		}

		private class OverflowPopup : android.view.@internal.menu.MenuPopupHelper
		{
			public OverflowPopup(ActionMenuPresenter _enclosing, android.content.Context context
				, android.view.@internal.menu.MenuBuilder menu, android.view.View anchorView, bool
				 overflowOnly) : base(context, menu, anchorView, overflowOnly)
			{
				this._enclosing = _enclosing;
				this.setCallback(this._enclosing.mPopupPresenterCallback);
			}

			[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuPopupHelper")]
			public override void onDismiss()
			{
				base.onDismiss();
				this._enclosing.mMenu.close();
				this._enclosing.mOverflowPopup = null;
			}

			private readonly ActionMenuPresenter _enclosing;
		}

		private class ActionButtonSubmenu : android.view.@internal.menu.MenuPopupHelper
		{
			internal android.view.@internal.menu.SubMenuBuilder mSubMenu;

			public ActionButtonSubmenu(ActionMenuPresenter _enclosing, android.content.Context
				 context, android.view.@internal.menu.SubMenuBuilder subMenu) : base(context, subMenu
				)
			{
				this._enclosing = _enclosing;
				this.mSubMenu = subMenu;
				android.view.@internal.menu.MenuItemImpl item = (android.view.@internal.menu.MenuItemImpl
					)subMenu.getItem();
				if (!item.isActionButton())
				{
					// Give a reasonable anchor to nested submenus.
					this.setAnchorView(this._enclosing.mOverflowButton == null ? (android.view.View)this
						._enclosing.mMenuView : this._enclosing.mOverflowButton);
				}
				this.setCallback(this._enclosing.mPopupPresenterCallback);
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
				this.setForceShowIcon(preserveIconSpacing);
			}

			[Sharpen.OverridesMethod(@"com.android.internal.view.menu.MenuPopupHelper")]
			public override void onDismiss()
			{
				base.onDismiss();
				this._enclosing.mActionButtonPopup = null;
				this._enclosing.mOpenSubMenuId = 0;
			}

			private readonly ActionMenuPresenter _enclosing;
		}

		private class PopupPresenterCallback : android.view.@internal.menu.MenuPresenterClass
			.Callback
		{
			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
				)]
			public virtual bool onOpenSubMenu(android.view.@internal.menu.MenuBuilder subMenu
				)
			{
				if (subMenu == null)
				{
					return false;
				}
				this._enclosing.mOpenSubMenuId = ((android.view.@internal.menu.SubMenuBuilder)subMenu
					).getItem().getItemId();
				return false;
			}

			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
				)]
			public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
				 allMenusAreClosing)
			{
				if (menu is android.view.@internal.menu.SubMenuBuilder)
				{
					((android.view.@internal.menu.SubMenuBuilder)menu).getRootMenu().close(false);
				}
			}

			internal PopupPresenterCallback(ActionMenuPresenter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActionMenuPresenter _enclosing;
		}

		private class OpenOverflowRunnable : java.lang.Runnable
		{
			internal android.view.@internal.menu.ActionMenuPresenter.OverflowPopup mPopup;

			public OpenOverflowRunnable(ActionMenuPresenter _enclosing, android.view.@internal.menu.ActionMenuPresenter
				.OverflowPopup popup)
			{
				this._enclosing = _enclosing;
				this.mPopup = popup;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				this._enclosing.mMenu.changeMenuMode();
				if (this.mPopup.tryShow())
				{
					this._enclosing.mOverflowPopup = this.mPopup;
					this._enclosing.mPostedOpenRunnable = null;
				}
			}

			private readonly ActionMenuPresenter _enclosing;
		}
	}
}
