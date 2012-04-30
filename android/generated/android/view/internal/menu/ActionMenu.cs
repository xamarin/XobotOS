using Sharpen;

namespace android.view.@internal.menu
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionMenu : android.view.Menu
	{
		private android.content.Context mContext;

		private bool mIsQwerty;

		private java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> mItems;

		public ActionMenu(android.content.Context context)
		{
			mContext = context;
			mItems = new java.util.ArrayList<android.view.@internal.menu.ActionMenuItem>();
		}

		public virtual android.content.Context getContext()
		{
			return mContext;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem add(java.lang.CharSequence title)
		{
			return add(0, 0, 0, title);
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem add(int titleRes)
		{
			return add(0, 0, 0, titleRes);
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem add(int groupId, int itemId, int order, int 
			titleRes)
		{
			return add(groupId, itemId, order, java.lang.CharSequenceProxy.Wrap(mContext.getResources
				().getString(titleRes)));
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem add(int groupId, int itemId, int order, java.lang.CharSequence
			 title)
		{
			android.view.@internal.menu.ActionMenuItem item = new android.view.@internal.menu.ActionMenuItem
				(getContext(), groupId, itemId, 0, order, title);
			mItems.add(order, item);
			return item;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual int addIntentOptions(int groupId, int itemId, int order, android.content.ComponentName
			 caller, android.content.Intent[] specifics, android.content.Intent intent, int 
			flags, android.view.MenuItem[] outSpecificItems)
		{
			android.content.pm.PackageManager pm = mContext.getPackageManager();
			java.util.List<android.content.pm.ResolveInfo> lri = pm.queryIntentActivityOptions
				(caller, specifics, intent, 0);
			int N = lri != null ? lri.size() : 0;
			if ((flags & android.view.MenuClass.FLAG_APPEND_TO_GROUP) == 0)
			{
				removeGroup(groupId);
			}
			{
				for (int i = 0; i < N; i++)
				{
					android.content.pm.ResolveInfo ri = lri.get(i);
					android.content.Intent rintent = new android.content.Intent(ri.specificIndex < 0 ? 
						intent : specifics[ri.specificIndex]);
					rintent.setComponent(new android.content.ComponentName(ri.activityInfo.applicationInfo
						.packageName, ri.activityInfo.name));
					android.view.MenuItem item = add(groupId, itemId, order, ri.loadLabel(pm)).setIcon
						(ri.loadIcon(pm)).setIntent(rintent);
					if (outSpecificItems != null && ri.specificIndex >= 0)
					{
						outSpecificItems[ri.specificIndex] = item;
					}
				}
			}
			return N;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.SubMenu addSubMenu(java.lang.CharSequence title)
		{
			// TODO Implement submenus
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.SubMenu addSubMenu(int titleRes)
		{
			// TODO Implement submenus
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.SubMenu addSubMenu(int groupId, int itemId, int order
			, java.lang.CharSequence title)
		{
			// TODO Implement submenus
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.SubMenu addSubMenu(int groupId, int itemId, int order
			, int titleRes)
		{
			// TODO Implement submenus
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void clear()
		{
			mItems.clear();
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void close()
		{
		}

		private int findItemIndex(int id)
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					if (items.get(i).getItemId() == id)
					{
						return i;
					}
				}
			}
			return -1;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem findItem(int id)
		{
			return mItems.get(findItemIndex(id));
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual android.view.MenuItem getItem(int index)
		{
			return mItems.get(index);
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual bool hasVisibleItems()
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					if (items.get(i).isVisible())
					{
						return true;
					}
				}
			}
			return false;
		}

		private android.view.@internal.menu.ActionMenuItem findItemWithShortcut(int keyCode
			, android.view.KeyEvent @event)
		{
			// TODO Make this smarter.
			bool qwerty = mIsQwerty;
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					android.view.@internal.menu.ActionMenuItem item = items.get(i);
					char shortcut = qwerty ? item.getAlphabeticShortcut() : item.getNumericShortcut();
					if (keyCode == shortcut)
					{
						return item;
					}
				}
			}
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual bool isShortcutKey(int keyCode, android.view.KeyEvent @event)
		{
			return findItemWithShortcut(keyCode, @event) != null;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual bool performIdentifierAction(int id, int flags)
		{
			int index = findItemIndex(id);
			if (index < 0)
			{
				return false;
			}
			return mItems.get(index).invoke();
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual bool performShortcut(int keyCode, android.view.KeyEvent @event, int
			 flags)
		{
			android.view.@internal.menu.ActionMenuItem item = findItemWithShortcut(keyCode, @event
				);
			if (item == null)
			{
				return false;
			}
			return item.invoke();
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void removeGroup(int groupId)
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			int i = 0;
			while (i < itemCount)
			{
				if (items.get(i).getGroupId() == groupId)
				{
					items.remove(i);
					itemCount--;
				}
				else
				{
					i++;
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void removeItem(int id)
		{
			mItems.remove(findItemIndex(id));
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void setGroupCheckable(int group, bool checkable, bool exclusive)
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					android.view.@internal.menu.ActionMenuItem item = items.get(i);
					if (item.getGroupId() == group)
					{
						item.setCheckable(checkable);
						item.setExclusiveCheckable(exclusive);
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void setGroupEnabled(int group, bool enabled)
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					android.view.@internal.menu.ActionMenuItem item = items.get(i);
					if (item.getGroupId() == group)
					{
						item.setEnabled(enabled);
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void setGroupVisible(int group, bool visible)
		{
			java.util.ArrayList<android.view.@internal.menu.ActionMenuItem> items = mItems;
			int itemCount = items.size();
			{
				for (int i = 0; i < itemCount; i++)
				{
					android.view.@internal.menu.ActionMenuItem item = items.get(i);
					if (item.getGroupId() == group)
					{
						item.setVisible(visible);
					}
				}
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual void setQwertyMode(bool isQwerty)
		{
			mIsQwerty = isQwerty;
		}

		[Sharpen.ImplementsInterface(@"android.view.Menu")]
		public virtual int size()
		{
			return mItems.size();
		}
	}
}
