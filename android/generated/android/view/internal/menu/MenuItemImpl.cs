using Sharpen;

namespace android.view.@internal.menu
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public sealed class MenuItemImpl : android.view.MenuItem
	{
		internal const string TAG = "MenuItemImpl";

		internal const int SHOW_AS_ACTION_MASK = android.view.MenuItemClass.SHOW_AS_ACTION_NEVER
			 | android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM | android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS;

		private readonly int mId;

		private readonly int mGroup;

		private readonly int mCategoryOrder;

		private readonly int mOrdering;

		private java.lang.CharSequence mTitle;

		private java.lang.CharSequence mTitleCondensed;

		private android.content.Intent mIntent;

		private char mShortcutNumericChar;

		private char mShortcutAlphabeticChar;

		/// <summary>The icon's drawable which is only created as needed</summary>
		private android.graphics.drawable.Drawable mIconDrawable;

		/// <summary>
		/// The icon's resource ID which is used to get the Drawable when it is
		/// needed (if the Drawable isn't already obtained--only one of the two is
		/// needed).
		/// </summary>
		/// <remarks>
		/// The icon's resource ID which is used to get the Drawable when it is
		/// needed (if the Drawable isn't already obtained--only one of the two is
		/// needed).
		/// </remarks>
		private int mIconResId = NO_ICON;

		/// <summary>The menu to which this item belongs</summary>
		private android.view.@internal.menu.MenuBuilder mMenu;

		/// <summary>If this item should launch a sub menu, this is the sub menu to launch</summary>
		private android.view.@internal.menu.SubMenuBuilder mSubMenu;

		private java.lang.Runnable mItemCallback;

		private android.view.MenuItemClass.OnMenuItemClickListener mClickListener;

		private int mFlags = ENABLED;

		internal const int CHECKABLE = unchecked((int)(0x00000001));

		internal const int CHECKED = unchecked((int)(0x00000002));

		internal const int EXCLUSIVE = unchecked((int)(0x00000004));

		internal const int HIDDEN = unchecked((int)(0x00000008));

		internal const int ENABLED = unchecked((int)(0x00000010));

		internal const int IS_ACTION = unchecked((int)(0x00000020));

		private int mShowAsAction = android.view.MenuItemClass.SHOW_AS_ACTION_NEVER;

		private android.view.View mActionView;

		private android.view.ActionProvider mActionProvider;

		private android.view.MenuItemClass.OnActionExpandListener mOnActionExpandListener;

		private bool mIsActionViewExpanded = false;

		/// <summary>Used for the icon resource ID if this item does not have an icon</summary>
		internal const int NO_ICON = 0;

		/// <summary>
		/// Current use case is for context menu: Extra information linked to the
		/// View that added this item to the context menu.
		/// </summary>
		/// <remarks>
		/// Current use case is for context menu: Extra information linked to the
		/// View that added this item to the context menu.
		/// </remarks>
		private android.view.ContextMenuClass.ContextMenuInfo mMenuInfo;

		private static string sPrependShortcutLabel;

		private static string sEnterShortcutLabel;

		private static string sDeleteShortcutLabel;

		private static string sSpaceShortcutLabel;

		/// <summary>Instantiates this menu item.</summary>
		/// <remarks>Instantiates this menu item.</remarks>
		/// <param name="menu"></param>
		/// <param name="group">
		/// Item ordering grouping control. The item will be added after
		/// all other items whose order is &lt;= this number, and before any
		/// that are larger than it. This can also be used to define
		/// groups of items for batch state changes. Normally use 0.
		/// </param>
		/// <param name="id">Unique item ID. Use 0 if you do not need a unique ID.</param>
		/// <param name="categoryOrder">The ordering for this item.</param>
		/// <param name="title">The text to display for the item.</param>
		internal MenuItemImpl(android.view.@internal.menu.MenuBuilder menu, int group, int
			 id, int categoryOrder, int ordering, java.lang.CharSequence title, int showAsAction
			)
		{
			if (sPrependShortcutLabel == null)
			{
				// This is instantiated from the UI thread, so no chance of sync issues 
				sPrependShortcutLabel = menu.getContext().getResources().getString(android.@internal.R
					.@string.prepend_shortcut_label);
				sEnterShortcutLabel = menu.getContext().getResources().getString(android.@internal.R
					.@string.menu_enter_shortcut_label);
				sDeleteShortcutLabel = menu.getContext().getResources().getString(android.@internal.R
					.@string.menu_delete_shortcut_label);
				sSpaceShortcutLabel = menu.getContext().getResources().getString(android.@internal.R
					.@string.menu_space_shortcut_label);
			}
			mMenu = menu;
			mId = id;
			mGroup = group;
			mCategoryOrder = categoryOrder;
			mOrdering = ordering;
			mTitle = title;
			mShowAsAction = showAsAction;
		}

		/// <summary>Invokes the item by calling various listeners or callbacks.</summary>
		/// <remarks>Invokes the item by calling various listeners or callbacks.</remarks>
		/// <returns>true if the invocation was handled, false otherwise</returns>
		public bool invoke()
		{
			if (mClickListener != null && mClickListener.onMenuItemClick(this))
			{
				return true;
			}
			if (mMenu.dispatchMenuItemSelected(mMenu.getRootMenu(), this))
			{
				return true;
			}
			if (mItemCallback != null)
			{
				mItemCallback.run();
				return true;
			}
			if (mIntent != null)
			{
				try
				{
					mMenu.getContext().startActivity(mIntent);
					return true;
				}
				catch (android.content.ActivityNotFoundException e)
				{
					android.util.Log.e(TAG, "Can't find activity to handle intent; ignoring", e);
				}
			}
			if (mActionProvider != null && mActionProvider.onPerformDefaultAction())
			{
				return true;
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool isEnabled()
		{
			return (mFlags & ENABLED) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setEnabled(bool enabled)
		{
			if (enabled)
			{
				mFlags |= ENABLED;
			}
			else
			{
				mFlags &= ~ENABLED;
			}
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public int getGroupId()
		{
			return mGroup;
		}

		[android.view.ViewDebug.CapturedViewProperty]
		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public int getItemId()
		{
			return mId;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public int getOrder()
		{
			return mCategoryOrder;
		}

		public int getOrdering()
		{
			return mOrdering;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.content.Intent getIntent()
		{
			return mIntent;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setIntent(android.content.Intent intent)
		{
			mIntent = intent;
			return this;
		}

		internal java.lang.Runnable getCallback()
		{
			return mItemCallback;
		}

		public android.view.MenuItem setCallback(java.lang.Runnable callback)
		{
			mItemCallback = callback;
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public char getAlphabeticShortcut()
		{
			return mShortcutAlphabeticChar;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setAlphabeticShortcut(char alphaChar)
		{
			if (mShortcutAlphabeticChar == alphaChar)
			{
				return this;
			}
			mShortcutAlphabeticChar = System.Char.ToLower(alphaChar);
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public char getNumericShortcut()
		{
			return mShortcutNumericChar;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setNumericShortcut(char numericChar)
		{
			if (mShortcutNumericChar == numericChar)
			{
				return this;
			}
			mShortcutNumericChar = numericChar;
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setShortcut(char numericChar, char alphaChar)
		{
			mShortcutNumericChar = numericChar;
			mShortcutAlphabeticChar = System.Char.ToLower(alphaChar);
			mMenu.onItemsChanged(false);
			return this;
		}

		/// <returns>The active shortcut (based on QWERTY-mode of the menu).</returns>
		internal char getShortcut()
		{
			return (mMenu.isQwertyMode() ? mShortcutAlphabeticChar : mShortcutNumericChar);
		}

		/// <returns>
		/// The label to show for the shortcut. This includes the chording
		/// key (for example 'Menu+a'). Also, any non-human readable
		/// characters should be human readable (for example 'Menu+enter').
		/// </returns>
		internal string getShortcutLabel()
		{
			char shortcut = getShortcut();
			if (shortcut == 0)
			{
				return string.Empty;
			}
			java.lang.StringBuilder sb = new java.lang.StringBuilder(sPrependShortcutLabel);
			switch (shortcut)
			{
				case '\n':
				{
					sb.append(sEnterShortcutLabel);
					break;
				}

				case '\b':
				{
					sb.append(sDeleteShortcutLabel);
					break;
				}

				case ' ':
				{
					sb.append(sSpaceShortcutLabel);
					break;
				}

				default:
				{
					sb.append(shortcut);
					break;
				}
			}
			return sb.ToString();
		}

		/// <returns>
		/// Whether this menu item should be showing shortcuts (depends on
		/// whether the menu should show shortcuts and whether this item has
		/// a shortcut defined)
		/// </returns>
		internal bool shouldShowShortcut()
		{
			// Show shortcuts if the menu is supposed to show shortcuts AND this item has a shortcut
			return mMenu.isShortcutsVisible() && (getShortcut() != 0);
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.SubMenu getSubMenu()
		{
			return mSubMenu;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool hasSubMenu()
		{
			return mSubMenu != null;
		}

		internal void setSubMenu(android.view.@internal.menu.SubMenuBuilder subMenu)
		{
			mSubMenu = subMenu;
			subMenu.setHeaderTitle(getTitle());
		}

		[android.view.ViewDebug.CapturedViewProperty]
		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public java.lang.CharSequence getTitle()
		{
			return mTitle;
		}

		/// <summary>
		/// Gets the title for a particular
		/// <see cref="ItemView">ItemView</see>
		/// </summary>
		/// <param name="itemView">The ItemView that is receiving the title</param>
		/// <returns>
		/// Either the title or condensed title based on what the ItemView
		/// prefers
		/// </returns>
		internal java.lang.CharSequence getTitleForItemView(android.view.@internal.menu.MenuViewClass
			.ItemView itemView)
		{
			return ((itemView != null) && itemView.prefersCondensedTitle()) ? getTitleCondensed
				() : getTitle();
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			mMenu.onItemsChanged(false);
			if (mSubMenu != null)
			{
				mSubMenu.setHeaderTitle(title);
			}
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setTitle(int title)
		{
			return setTitle(java.lang.CharSequenceProxy.Wrap(mMenu.getContext().getString(title
				)));
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public java.lang.CharSequence getTitleCondensed()
		{
			return mTitleCondensed != null ? mTitleCondensed : mTitle;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setTitleCondensed(java.lang.CharSequence title)
		{
			mTitleCondensed = title;
			// Could use getTitle() in the loop below, but just cache what it would do here 
			if (title == null)
			{
				title = mTitle;
			}
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.graphics.drawable.Drawable getIcon()
		{
			if (mIconDrawable != null)
			{
				return mIconDrawable;
			}
			if (mIconResId != NO_ICON)
			{
				return mMenu.getResources().getDrawable(mIconResId);
			}
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setIcon(android.graphics.drawable.Drawable icon)
		{
			mIconResId = NO_ICON;
			mIconDrawable = icon;
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setIcon(int iconResId)
		{
			mIconDrawable = null;
			mIconResId = iconResId;
			// If we have a view, we need to push the Drawable to them
			mMenu.onItemsChanged(false);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool isCheckable()
		{
			return (mFlags & CHECKABLE) == CHECKABLE;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setCheckable(bool checkable)
		{
			int oldFlags = mFlags;
			mFlags = (mFlags & ~CHECKABLE) | (checkable ? CHECKABLE : 0);
			if (oldFlags != mFlags)
			{
				mMenu.onItemsChanged(false);
			}
			return this;
		}

		public void setExclusiveCheckable(bool exclusive)
		{
			mFlags = (mFlags & ~EXCLUSIVE) | (exclusive ? EXCLUSIVE : 0);
		}

		public bool isExclusiveCheckable()
		{
			return (mFlags & EXCLUSIVE) != 0;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool isChecked()
		{
			return (mFlags & CHECKED) == CHECKED;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setChecked(bool @checked)
		{
			if ((mFlags & EXCLUSIVE) != 0)
			{
				// Call the method on the Menu since it knows about the others in this
				// exclusive checkable group
				mMenu.setExclusiveItemChecked(this);
			}
			else
			{
				setCheckedInt(@checked);
			}
			return this;
		}

		internal void setCheckedInt(bool @checked)
		{
			int oldFlags = mFlags;
			mFlags = (mFlags & ~CHECKED) | (@checked ? CHECKED : 0);
			if (oldFlags != mFlags)
			{
				mMenu.onItemsChanged(false);
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool isVisible()
		{
			return (mFlags & HIDDEN) == 0;
		}

		/// <summary>Changes the visibility of the item.</summary>
		/// <remarks>
		/// Changes the visibility of the item. This method DOES NOT notify the
		/// parent menu of a change in this item, so this should only be called from
		/// methods that will eventually trigger this change.  If unsure, use
		/// <see cref="setVisible(bool)">setVisible(bool)</see>
		/// instead.
		/// </remarks>
		/// <param name="shown">Whether to show (true) or hide (false).</param>
		/// <returns>Whether the item's shown state was changed</returns>
		internal bool setVisibleInt(bool shown)
		{
			int oldFlags = mFlags;
			mFlags = (mFlags & ~HIDDEN) | (shown ? 0 : HIDDEN);
			return oldFlags != mFlags;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setVisible(bool shown)
		{
			// Try to set the shown state to the given state. If the shown state was changed
			// (i.e. the previous state isn't the same as given state), notify the parent menu that
			// the shown state has changed for this item
			if (setVisibleInt(shown))
			{
				mMenu.onItemVisibleChanged(this);
			}
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setOnMenuItemClickListener(android.view.MenuItemClass
			.OnMenuItemClickListener clickListener)
		{
			mClickListener = clickListener;
			return this;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return mTitle.ToString();
		}

		internal void setMenuInfo(android.view.ContextMenuClass.ContextMenuInfo menuInfo)
		{
			mMenuInfo = menuInfo;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.ContextMenuClass.ContextMenuInfo getMenuInfo()
		{
			return mMenuInfo;
		}

		public void actionFormatChanged()
		{
			mMenu.onItemActionRequestChanged(this);
		}

		/// <returns>Whether the menu should show icons for menu items.</returns>
		public bool shouldShowIcon()
		{
			return mMenu.getOptionalIconsVisible();
		}

		public bool isActionButton()
		{
			return (mFlags & IS_ACTION) == IS_ACTION;
		}

		public bool requestsActionButton()
		{
			return (mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM) == android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM;
		}

		public bool requiresActionButton()
		{
			return (mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS) == android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS;
		}

		public void setIsActionButton(bool isActionButton_1)
		{
			if (isActionButton_1)
			{
				mFlags |= IS_ACTION;
			}
			else
			{
				mFlags &= ~IS_ACTION;
			}
		}

		public bool showsTextAsAction()
		{
			return (mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT) == android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public void setShowAsAction(int actionEnum)
		{
			switch (actionEnum & SHOW_AS_ACTION_MASK)
			{
				case android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS:
				case android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM:
				case android.view.MenuItemClass.SHOW_AS_ACTION_NEVER:
				{
					// Looks good!
					break;
				}

				default:
				{
					// Mutually exclusive options selected!
					throw new System.ArgumentException("SHOW_AS_ACTION_ALWAYS, SHOW_AS_ACTION_IF_ROOM,"
						 + " and SHOW_AS_ACTION_NEVER are mutually exclusive.");
				}
			}
			mShowAsAction = actionEnum;
			mMenu.onItemActionRequestChanged(this);
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setActionView(android.view.View view)
		{
			mActionView = view;
			mActionProvider = null;
			if (view != null && view.getId() == android.view.View.NO_ID && mId > 0)
			{
				view.setId(mId);
			}
			mMenu.onItemActionRequestChanged(this);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setActionView(int resId)
		{
			android.content.Context context = mMenu.getContext();
			android.view.LayoutInflater inflater = android.view.LayoutInflater.from(context);
			setActionView(inflater.inflate(resId, new android.widget.LinearLayout(context), false
				));
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.View getActionView()
		{
			if (mActionView != null)
			{
				return mActionView;
			}
			else
			{
				if (mActionProvider != null)
				{
					mActionView = mActionProvider.onCreateActionView();
					return mActionView;
				}
				else
				{
					return null;
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.ActionProvider getActionProvider()
		{
			return mActionProvider;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setActionProvider(android.view.ActionProvider actionProvider
			)
		{
			mActionView = null;
			mActionProvider = actionProvider;
			mMenu.onItemsChanged(true);
			// Measurement can be changed
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setShowAsActionFlags(int actionEnum)
		{
			setShowAsAction(actionEnum);
			return this;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool expandActionView()
		{
			if ((mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
				) == 0 || mActionView == null)
			{
				return false;
			}
			if (mOnActionExpandListener == null || mOnActionExpandListener.onMenuItemActionExpand
				(this))
			{
				return mMenu.expandItemActionView(this);
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool collapseActionView()
		{
			if ((mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
				) == 0)
			{
				return false;
			}
			if (mActionView == null)
			{
				// We're already collapsed if we have no action view.
				return true;
			}
			if (mOnActionExpandListener == null || mOnActionExpandListener.onMenuItemActionCollapse
				(this))
			{
				return mMenu.collapseItemActionView(this);
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public android.view.MenuItem setOnActionExpandListener(android.view.MenuItemClass
			.OnActionExpandListener listener)
		{
			mOnActionExpandListener = listener;
			return this;
		}

		public bool hasCollapsibleActionView()
		{
			return (mShowAsAction & android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
				) != 0 && mActionView != null;
		}

		public void setActionViewExpanded(bool isExpanded)
		{
			mIsActionViewExpanded = isExpanded;
			mMenu.onItemsChanged(false);
		}

		[Sharpen.ImplementsInterface(@"android.view.MenuItem")]
		public bool isActionViewExpanded()
		{
			return mIsActionViewExpanded;
		}
	}
}
