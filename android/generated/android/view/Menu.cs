using Sharpen;

namespace android.view
{
	/// <summary>Interface for managing the items in a menu.</summary>
	/// <remarks>
	/// Interface for managing the items in a menu.
	/// <p>
	/// By default, every Activity supports an options menu of actions or options.
	/// You can add items to this menu and handle clicks on your additions. The
	/// easiest way of adding menu items is inflating an XML file into the
	/// <see cref="Menu">Menu</see>
	/// via
	/// <see cref="MenuInflater">MenuInflater</see>
	/// . The easiest way of attaching code to
	/// clicks is via
	/// <see cref="android.app.Activity.onOptionsItemSelected(MenuItem)">android.app.Activity.onOptionsItemSelected(MenuItem)
	/// 	</see>
	/// and
	/// <see cref="android.app.Activity.onContextItemSelected(MenuItem)">android.app.Activity.onContextItemSelected(MenuItem)
	/// 	</see>
	/// .
	/// <p>
	/// Different menu types support different features:
	/// <ol>
	/// <li><b>Context menus</b>: Do not support item shortcuts and item icons.
	/// <li><b>Options menus</b>: The <b>icon menus</b> do not support item check
	/// marks and only show the item's
	/// <see cref="MenuItem.setTitleCondensed(java.lang.CharSequence)">condensed title</see>
	/// . The
	/// <b>expanded menus</b> (only available if six or more menu items are visible,
	/// reached via the 'More' item in the icon menu) do not show item icons, and
	/// item check marks are discouraged.
	/// <li><b>Sub menus</b>: Do not support item icons, or nested sub menus.
	/// </ol>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Menu
	{
		// Implementation note: Keep these CATEGORY_* in sync with the category enum
		// in attrs.xml
		/// <summary>Add a new item to the menu.</summary>
		/// <remarks>
		/// Add a new item to the menu. This item displays the given title for its
		/// label.
		/// </remarks>
		/// <param name="title">The text to display for the item.</param>
		/// <returns>The newly added menu item.</returns>
		android.view.MenuItem add(java.lang.CharSequence title);

		/// <summary>Add a new item to the menu.</summary>
		/// <remarks>
		/// Add a new item to the menu. This item displays the given title for its
		/// label.
		/// </remarks>
		/// <param name="titleRes">Resource identifier of title string.</param>
		/// <returns>The newly added menu item.</returns>
		android.view.MenuItem add(int titleRes);

		/// <summary>Add a new item to the menu.</summary>
		/// <remarks>
		/// Add a new item to the menu. This item displays the given title for its
		/// label.
		/// </remarks>
		/// <param name="groupId">
		/// The group identifier that this item should be part of.
		/// This can be used to define groups of items for batch state
		/// changes. Normally use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if an item should not be in a
		/// group.
		/// </param>
		/// <param name="itemId">
		/// Unique item ID. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not need a
		/// unique ID.
		/// </param>
		/// <param name="order">
		/// The order for the item. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not care
		/// about the order. See
		/// <see cref="MenuItem.getOrder()">MenuItem.getOrder()</see>
		/// .
		/// </param>
		/// <param name="title">The text to display for the item.</param>
		/// <returns>The newly added menu item.</returns>
		android.view.MenuItem add(int groupId, int itemId, int order, java.lang.CharSequence
			 title);

		/// <summary>
		/// Variation on
		/// <see cref="add(int, int, int, java.lang.CharSequence)">add(int, int, int, java.lang.CharSequence)
		/// 	</see>
		/// that takes a
		/// string resource identifier instead of the string itself.
		/// </summary>
		/// <param name="groupId">
		/// The group identifier that this item should be part of.
		/// This can also be used to define groups of items for batch state
		/// changes. Normally use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if an item should not be in a
		/// group.
		/// </param>
		/// <param name="itemId">
		/// Unique item ID. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not need a
		/// unique ID.
		/// </param>
		/// <param name="order">
		/// The order for the item. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not care
		/// about the order. See
		/// <see cref="MenuItem.getOrder()">MenuItem.getOrder()</see>
		/// .
		/// </param>
		/// <param name="titleRes">Resource identifier of title string.</param>
		/// <returns>The newly added menu item.</returns>
		android.view.MenuItem add(int groupId, int itemId, int order, int titleRes);

		/// <summary>Add a new sub-menu to the menu.</summary>
		/// <remarks>
		/// Add a new sub-menu to the menu. This item displays the given title for
		/// its label. To modify other attributes on the submenu's menu item, use
		/// <see cref="SubMenu.getItem()">SubMenu.getItem()</see>
		/// .
		/// </remarks>
		/// <param name="title">The text to display for the item.</param>
		/// <returns>The newly added sub-menu</returns>
		android.view.SubMenu addSubMenu(java.lang.CharSequence title);

		/// <summary>Add a new sub-menu to the menu.</summary>
		/// <remarks>
		/// Add a new sub-menu to the menu. This item displays the given title for
		/// its label. To modify other attributes on the submenu's menu item, use
		/// <see cref="SubMenu.getItem()">SubMenu.getItem()</see>
		/// .
		/// </remarks>
		/// <param name="titleRes">Resource identifier of title string.</param>
		/// <returns>The newly added sub-menu</returns>
		android.view.SubMenu addSubMenu(int titleRes);

		/// <summary>Add a new sub-menu to the menu.</summary>
		/// <remarks>
		/// Add a new sub-menu to the menu. This item displays the given
		/// <var>title</var> for its label. To modify other attributes on the
		/// submenu's menu item, use
		/// <see cref="SubMenu.getItem()">SubMenu.getItem()</see>
		/// .
		/// <p>
		/// Note that you can only have one level of sub-menus, i.e. you cannnot add
		/// a subMenu to a subMenu: An
		/// <see cref="System.NotSupportedException">System.NotSupportedException</see>
		/// will be
		/// thrown if you try.
		/// </remarks>
		/// <param name="groupId">
		/// The group identifier that this item should be part of.
		/// This can also be used to define groups of items for batch state
		/// changes. Normally use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if an item should not be in a
		/// group.
		/// </param>
		/// <param name="itemId">
		/// Unique item ID. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not need a
		/// unique ID.
		/// </param>
		/// <param name="order">
		/// The order for the item. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not care
		/// about the order. See
		/// <see cref="MenuItem.getOrder()">MenuItem.getOrder()</see>
		/// .
		/// </param>
		/// <param name="title">The text to display for the item.</param>
		/// <returns>The newly added sub-menu</returns>
		android.view.SubMenu addSubMenu(int groupId, int itemId, int order, java.lang.CharSequence
			 title);

		/// <summary>
		/// Variation on
		/// <see cref="addSubMenu(int, int, int, java.lang.CharSequence)">addSubMenu(int, int, int, java.lang.CharSequence)
		/// 	</see>
		/// that takes
		/// a string resource identifier for the title instead of the string itself.
		/// </summary>
		/// <param name="groupId">
		/// The group identifier that this item should be part of.
		/// This can also be used to define groups of items for batch state
		/// changes. Normally use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if an item should not be in a group.
		/// </param>
		/// <param name="itemId">
		/// Unique item ID. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not need a unique ID.
		/// </param>
		/// <param name="order">
		/// The order for the item. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not care about the
		/// order. See
		/// <see cref="MenuItem.getOrder()">MenuItem.getOrder()</see>
		/// .
		/// </param>
		/// <param name="titleRes">Resource identifier of title string.</param>
		/// <returns>The newly added sub-menu</returns>
		android.view.SubMenu addSubMenu(int groupId, int itemId, int order, int titleRes);

		/// <summary>
		/// Add a group of menu items corresponding to actions that can be performed
		/// for a particular Intent.
		/// </summary>
		/// <remarks>
		/// Add a group of menu items corresponding to actions that can be performed
		/// for a particular Intent. The Intent is most often configured with a null
		/// action, the data that the current activity is working with, and includes
		/// either the
		/// <see cref="android.content.Intent.CATEGORY_ALTERNATIVE">android.content.Intent.CATEGORY_ALTERNATIVE
		/// 	</see>
		/// or
		/// <see cref="android.content.Intent.CATEGORY_SELECTED_ALTERNATIVE">android.content.Intent.CATEGORY_SELECTED_ALTERNATIVE
		/// 	</see>
		/// to find activities that have
		/// said they would like to be included as optional action. You can, however,
		/// use any Intent you want.
		/// <p>
		/// See
		/// <see cref="android.content.pm.PackageManager.queryIntentActivityOptions(android.content.ComponentName, android.content.Intent[], android.content.Intent, int)
		/// 	">android.content.pm.PackageManager.queryIntentActivityOptions(android.content.ComponentName, android.content.Intent[], android.content.Intent, int)
		/// 	</see>
		/// for more * details on the <var>caller</var>, <var>specifics</var>, and
		/// <var>intent</var> arguments. The list returned by that function is used
		/// to populate the resulting menu items.
		/// <p>
		/// All of the menu items of possible options for the intent will be added
		/// with the given group and id. You can use the group to control ordering of
		/// the items in relation to other items in the menu. Normally this function
		/// will automatically remove any existing items in the menu in the same
		/// group and place a divider above and below the added items; this behavior
		/// can be modified with the <var>flags</var> parameter. For each of the
		/// generated items
		/// <see cref="MenuItem.setIntent(android.content.Intent)">MenuItem.setIntent(android.content.Intent)
		/// 	</see>
		/// is called to associate the
		/// appropriate Intent with the item; this means the activity will
		/// automatically be started for you without having to do anything else.
		/// </remarks>
		/// <param name="groupId">
		/// The group identifier that the items should be part of.
		/// This can also be used to define groups of items for batch state
		/// changes. Normally use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if the items should not be in
		/// a group.
		/// </param>
		/// <param name="itemId">
		/// Unique item ID. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not need a
		/// unique ID.
		/// </param>
		/// <param name="order">
		/// The order for the items. Use
		/// <see cref="android.view.MenuClass.NONE">android.view.MenuClass.NONE</see>
		/// if you do not
		/// care about the order. See
		/// <see cref="MenuItem.getOrder()">MenuItem.getOrder()</see>
		/// .
		/// </param>
		/// <param name="caller">
		/// The current activity component name as defined by
		/// queryIntentActivityOptions().
		/// </param>
		/// <param name="specifics">
		/// Specific items to place first as defined by
		/// queryIntentActivityOptions().
		/// </param>
		/// <param name="intent">
		/// Intent describing the kinds of items to populate in the
		/// list as defined by queryIntentActivityOptions().
		/// </param>
		/// <param name="flags">Additional options controlling how the items are added.</param>
		/// <param name="outSpecificItems">
		/// Optional array in which to place the menu items
		/// that were generated for each of the <var>specifics</var> that were
		/// requested. Entries may be null if no activity was found for that
		/// specific action.
		/// </param>
		/// <returns>The number of menu items that were added.</returns>
		/// <seealso cref="android.view.MenuClass.FLAG_APPEND_TO_GROUP">android.view.MenuClass.FLAG_APPEND_TO_GROUP
		/// 	</seealso>
		/// <seealso cref="MenuItem.setIntent(android.content.Intent)">MenuItem.setIntent(android.content.Intent)
		/// 	</seealso>
		/// <seealso cref="android.content.pm.PackageManager.queryIntentActivityOptions(android.content.ComponentName, android.content.Intent[], android.content.Intent, int)
		/// 	">android.content.pm.PackageManager.queryIntentActivityOptions(android.content.ComponentName, android.content.Intent[], android.content.Intent, int)
		/// 	</seealso>
		int addIntentOptions(int groupId, int itemId, int order, android.content.ComponentName
			 caller, android.content.Intent[] specifics, android.content.Intent intent, int 
			flags, android.view.MenuItem[] outSpecificItems);

		/// <summary>Remove the item with the given identifier.</summary>
		/// <remarks>Remove the item with the given identifier.</remarks>
		/// <param name="id">
		/// The item to be removed.  If there is no item with this
		/// identifier, nothing happens.
		/// </param>
		void removeItem(int id);

		/// <summary>Remove all items in the given group.</summary>
		/// <remarks>Remove all items in the given group.</remarks>
		/// <param name="groupId">
		/// The group to be removed.  If there are no items in this
		/// group, nothing happens.
		/// </param>
		void removeGroup(int groupId);

		/// <summary>
		/// Remove all existing items from the menu, leaving it empty as if it had
		/// just been created.
		/// </summary>
		/// <remarks>
		/// Remove all existing items from the menu, leaving it empty as if it had
		/// just been created.
		/// </remarks>
		void clear();

		/// <summary>Control whether a particular group of items can show a check mark.</summary>
		/// <remarks>
		/// Control whether a particular group of items can show a check mark.  This
		/// is similar to calling
		/// <see cref="MenuItem.setCheckable(bool)">MenuItem.setCheckable(bool)</see>
		/// on all of the menu items
		/// with the given group identifier, but in addition you can control whether
		/// this group contains a mutually-exclusive set items.  This should be called
		/// after the items of the group have been added to the menu.
		/// </remarks>
		/// <param name="group">The group of items to operate on.</param>
		/// <param name="checkable">
		/// Set to true to allow a check mark, false to
		/// disallow.  The default is false.
		/// </param>
		/// <param name="exclusive">
		/// If set to true, only one item in this group can be
		/// checked at a time; checking an item will automatically
		/// uncheck all others in the group.  If set to false, each
		/// item can be checked independently of the others.
		/// </param>
		/// <seealso cref="MenuItem.setCheckable(bool)">MenuItem.setCheckable(bool)</seealso>
		/// <seealso cref="MenuItem.setChecked(bool)">MenuItem.setChecked(bool)</seealso>
		void setGroupCheckable(int group, bool checkable, bool exclusive);

		/// <summary>Show or hide all menu items that are in the given group.</summary>
		/// <remarks>Show or hide all menu items that are in the given group.</remarks>
		/// <param name="group">The group of items to operate on.</param>
		/// <param name="visible">If true the items are visible, else they are hidden.</param>
		/// <seealso cref="MenuItem.setVisible(bool)">MenuItem.setVisible(bool)</seealso>
		void setGroupVisible(int group, bool visible);

		/// <summary>Enable or disable all menu items that are in the given group.</summary>
		/// <remarks>Enable or disable all menu items that are in the given group.</remarks>
		/// <param name="group">The group of items to operate on.</param>
		/// <param name="enabled">If true the items will be enabled, else they will be disabled.
		/// 	</param>
		/// <seealso cref="MenuItem.setEnabled(bool)">MenuItem.setEnabled(bool)</seealso>
		void setGroupEnabled(int group, bool enabled);

		/// <summary>Return whether the menu currently has item items that are visible.</summary>
		/// <remarks>Return whether the menu currently has item items that are visible.</remarks>
		/// <returns>
		/// True if there is one or more item visible,
		/// else false.
		/// </returns>
		bool hasVisibleItems();

		/// <summary>Return the menu item with a particular identifier.</summary>
		/// <remarks>Return the menu item with a particular identifier.</remarks>
		/// <param name="id">The identifier to find.</param>
		/// <returns>
		/// The menu item object, or null if there is no item with
		/// this identifier.
		/// </returns>
		android.view.MenuItem findItem(int id);

		/// <summary>Get the number of items in the menu.</summary>
		/// <remarks>
		/// Get the number of items in the menu.  Note that this will change any
		/// times items are added or removed from the menu.
		/// </remarks>
		/// <returns>The item count.</returns>
		int size();

		/// <summary>Gets the menu item at the given index.</summary>
		/// <remarks>Gets the menu item at the given index.</remarks>
		/// <param name="index">The index of the menu item to return.</param>
		/// <returns>The menu item.</returns>
		/// <exception>
		/// IndexOutOfBoundsException
		/// when
		/// <code>index &lt; 0 || &gt;= size()</code>
		/// </exception>
		android.view.MenuItem getItem(int index);

		/// <summary>Closes the menu, if open.</summary>
		/// <remarks>Closes the menu, if open.</remarks>
		void close();

		/// <summary>
		/// Execute the menu item action associated with the given shortcut
		/// character.
		/// </summary>
		/// <remarks>
		/// Execute the menu item action associated with the given shortcut
		/// character.
		/// </remarks>
		/// <param name="keyCode">The keycode of the shortcut key.</param>
		/// <param name="event">Key event message.</param>
		/// <param name="flags">Additional option flags or 0.</param>
		/// <returns>
		/// If the given shortcut exists and is shown, returns
		/// true; else returns false.
		/// </returns>
		/// <seealso cref="android.view.MenuClass.FLAG_PERFORM_NO_CLOSE">android.view.MenuClass.FLAG_PERFORM_NO_CLOSE
		/// 	</seealso>
		bool performShortcut(int keyCode, android.view.KeyEvent @event, int flags);

		/// <summary>Is a keypress one of the defined shortcut keys for this window.</summary>
		/// <remarks>Is a keypress one of the defined shortcut keys for this window.</remarks>
		/// <param name="keyCode">
		/// the key code from
		/// <see cref="KeyEvent">KeyEvent</see>
		/// to check.
		/// </param>
		/// <param name="event">
		/// the
		/// <see cref="KeyEvent">KeyEvent</see>
		/// to use to help check.
		/// </param>
		bool isShortcutKey(int keyCode, android.view.KeyEvent @event);

		/// <summary>Execute the menu item action associated with the given menu identifier.</summary>
		/// <remarks>Execute the menu item action associated with the given menu identifier.</remarks>
		/// <param name="id">Identifier associated with the menu item.</param>
		/// <param name="flags">Additional option flags or 0.</param>
		/// <returns>
		/// If the given identifier exists and is shown, returns
		/// true; else returns false.
		/// </returns>
		/// <seealso cref="android.view.MenuClass.FLAG_PERFORM_NO_CLOSE">android.view.MenuClass.FLAG_PERFORM_NO_CLOSE
		/// 	</seealso>
		bool performIdentifierAction(int id, int flags);

		/// <summary>
		/// Control whether the menu should be running in qwerty mode (alphabetic
		/// shortcuts) or 12-key mode (numeric shortcuts).
		/// </summary>
		/// <remarks>
		/// Control whether the menu should be running in qwerty mode (alphabetic
		/// shortcuts) or 12-key mode (numeric shortcuts).
		/// </remarks>
		/// <param name="isQwerty">
		/// If true the menu will use alphabetic shortcuts; else it
		/// will use numeric shortcuts.
		/// </param>
		void setQwertyMode(bool isQwerty);
	}

	/// <summary>Interface for managing the items in a menu.</summary>
	/// <remarks>
	/// Interface for managing the items in a menu.
	/// <p>
	/// By default, every Activity supports an options menu of actions or options.
	/// You can add items to this menu and handle clicks on your additions. The
	/// easiest way of adding menu items is inflating an XML file into the
	/// <see cref="Menu">Menu</see>
	/// via
	/// <see cref="MenuInflater">MenuInflater</see>
	/// . The easiest way of attaching code to
	/// clicks is via
	/// <see cref="android.app.Activity.onOptionsItemSelected(MenuItem)">android.app.Activity.onOptionsItemSelected(MenuItem)
	/// 	</see>
	/// and
	/// <see cref="android.app.Activity.onContextItemSelected(MenuItem)">android.app.Activity.onContextItemSelected(MenuItem)
	/// 	</see>
	/// .
	/// <p>
	/// Different menu types support different features:
	/// <ol>
	/// <li><b>Context menus</b>: Do not support item shortcuts and item icons.
	/// <li><b>Options menus</b>: The <b>icon menus</b> do not support item check
	/// marks and only show the item's
	/// <see cref="MenuItem.setTitleCondensed(java.lang.CharSequence)">condensed title</see>
	/// . The
	/// <b>expanded menus</b> (only available if six or more menu items are visible,
	/// reached via the 'More' item in the icon menu) do not show item icons, and
	/// item check marks are discouraged.
	/// <li><b>Sub menus</b>: Do not support item icons, or nested sub menus.
	/// </ol>
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For more information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public static class MenuClass
	{
		/// <summary>This is the part of an order integer that the user can provide.</summary>
		/// <remarks>This is the part of an order integer that the user can provide.</remarks>
		/// <hide></hide>
		public const int USER_MASK = unchecked((int)(0x0000ffff));

		/// <summary>Bit shift of the user portion of the order integer.</summary>
		/// <remarks>Bit shift of the user portion of the order integer.</remarks>
		/// <hide></hide>
		public const int USER_SHIFT = 0;

		/// <summary>
		/// This is the part of an order integer that supplies the category of the
		/// item.
		/// </summary>
		/// <remarks>
		/// This is the part of an order integer that supplies the category of the
		/// item.
		/// </remarks>
		/// <hide></hide>
		public const int CATEGORY_MASK = unchecked((int)(0xffff0000));

		/// <summary>Bit shift of the category portion of the order integer.</summary>
		/// <remarks>Bit shift of the category portion of the order integer.</remarks>
		/// <hide></hide>
		public const int CATEGORY_SHIFT = 16;

		/// <summary>
		/// Value to use for group and item identifier integers when you don't care
		/// about them.
		/// </summary>
		/// <remarks>
		/// Value to use for group and item identifier integers when you don't care
		/// about them.
		/// </remarks>
		public const int NONE = 0;

		/// <summary>First value for group and item identifier integers.</summary>
		/// <remarks>First value for group and item identifier integers.</remarks>
		public const int FIRST = 1;

		/// <summary>
		/// Category code for the order integer for items/groups that are part of a
		/// container -- or/add this with your base value.
		/// </summary>
		/// <remarks>
		/// Category code for the order integer for items/groups that are part of a
		/// container -- or/add this with your base value.
		/// </remarks>
		public const int CATEGORY_CONTAINER = unchecked((int)(0x00010000));

		/// <summary>
		/// Category code for the order integer for items/groups that are provided by
		/// the system -- or/add this with your base value.
		/// </summary>
		/// <remarks>
		/// Category code for the order integer for items/groups that are provided by
		/// the system -- or/add this with your base value.
		/// </remarks>
		public const int CATEGORY_SYSTEM = unchecked((int)(0x00020000));

		/// <summary>
		/// Category code for the order integer for items/groups that are
		/// user-supplied secondary (infrequently used) options -- or/add this with
		/// your base value.
		/// </summary>
		/// <remarks>
		/// Category code for the order integer for items/groups that are
		/// user-supplied secondary (infrequently used) options -- or/add this with
		/// your base value.
		/// </remarks>
		public const int CATEGORY_SECONDARY = unchecked((int)(0x00030000));

		/// <summary>
		/// Category code for the order integer for items/groups that are
		/// alternative actions on the data that is currently displayed -- or/add
		/// this with your base value.
		/// </summary>
		/// <remarks>
		/// Category code for the order integer for items/groups that are
		/// alternative actions on the data that is currently displayed -- or/add
		/// this with your base value.
		/// </remarks>
		public const int CATEGORY_ALTERNATIVE = unchecked((int)(0x00040000));

		/// <summary>
		/// Flag for
		/// <see cref="addIntentOptions(int, int, int, android.content.ComponentName, android.content.Intent[], android.content.Intent, int, MenuItem[])
		/// 	">addIntentOptions(int, int, int, android.content.ComponentName, android.content.Intent[], android.content.Intent, int, MenuItem[])
		/// 	</see>
		/// : if set, do not automatically remove
		/// any existing menu items in the same group.
		/// </summary>
		public const int FLAG_APPEND_TO_GROUP = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="performShortcut(int, KeyEvent, int)">performShortcut(int, KeyEvent, int)
		/// 	</see>
		/// : if set, do not close the menu after
		/// executing the shortcut.
		/// </summary>
		public const int FLAG_PERFORM_NO_CLOSE = unchecked((int)(0x0001));

		/// <summary>
		/// Flag for
		/// <see cref="performShortcut(int, KeyEvent, int)">performShortcut(int, KeyEvent, int)
		/// 	</see>
		/// : if set, always
		/// close the menu after executing the shortcut. Closing the menu also resets
		/// the prepared state.
		/// </summary>
		public const int FLAG_ALWAYS_PERFORM_CLOSE = unchecked((int)(0x0002));
	}
}
