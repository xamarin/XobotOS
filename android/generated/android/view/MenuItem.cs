using Sharpen;

namespace android.view
{
	/// <summary>Interface for direct access to a previously created menu item.</summary>
	/// <remarks>
	/// Interface for direct access to a previously created menu item.
	/// <p>
	/// An Item is returned by calling one of the
	/// <see cref="Menu.add(java.lang.CharSequence)">Menu.add(java.lang.CharSequence)</see>
	/// methods.
	/// <p>
	/// For a feature set of specific menu types, see
	/// <see cref="Menu">Menu</see>
	/// .
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public interface MenuItem
	{
		/// <summary>Return the identifier for this menu item.</summary>
		/// <remarks>
		/// Return the identifier for this menu item.  The identifier can not
		/// be changed after the menu is created.
		/// </remarks>
		/// <returns>The menu item's identifier.</returns>
		int getItemId();

		/// <summary>Return the group identifier that this menu item is part of.</summary>
		/// <remarks>
		/// Return the group identifier that this menu item is part of. The group
		/// identifier can not be changed after the menu is created.
		/// </remarks>
		/// <returns>The menu item's group identifier.</returns>
		int getGroupId();

		/// <summary>Return the category and order within the category of this item.</summary>
		/// <remarks>
		/// Return the category and order within the category of this item. This
		/// item will be shown before all items (within its category) that have
		/// order greater than this value.
		/// <p>
		/// An order integer contains the item's category (the upper bits of the
		/// integer; set by or/add the category with the order within the
		/// category) and the ordering of the item within that category (the
		/// lower bits). Example categories are
		/// <see cref="android.view.MenuClass.CATEGORY_SYSTEM">android.view.MenuClass.CATEGORY_SYSTEM
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuClass.CATEGORY_SECONDARY">android.view.MenuClass.CATEGORY_SECONDARY
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuClass.CATEGORY_ALTERNATIVE">android.view.MenuClass.CATEGORY_ALTERNATIVE
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuClass.CATEGORY_CONTAINER">android.view.MenuClass.CATEGORY_CONTAINER
		/// 	</see>
		/// . See
		/// <see cref="Menu">Menu</see>
		/// for a full list.
		/// </remarks>
		/// <returns>The order of this item.</returns>
		int getOrder();

		/// <summary>Change the title associated with this item.</summary>
		/// <remarks>Change the title associated with this item.</remarks>
		/// <param name="title">The new text to be displayed.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setTitle(java.lang.CharSequence title);

		/// <summary>Change the title associated with this item.</summary>
		/// <remarks>
		/// Change the title associated with this item.
		/// <p>
		/// Some menu types do not sufficient space to show the full title, and
		/// instead a condensed title is preferred. See
		/// <see cref="Menu">Menu</see>
		/// for more
		/// information.
		/// </remarks>
		/// <param name="title">The resource id of the new text to be displayed.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		/// <seealso cref="setTitleCondensed(java.lang.CharSequence)">setTitleCondensed(java.lang.CharSequence)
		/// 	</seealso>
		android.view.MenuItem setTitle(int title);

		/// <summary>Retrieve the current title of the item.</summary>
		/// <remarks>Retrieve the current title of the item.</remarks>
		/// <returns>The title.</returns>
		java.lang.CharSequence getTitle();

		/// <summary>Change the condensed title associated with this item.</summary>
		/// <remarks>
		/// Change the condensed title associated with this item. The condensed
		/// title is used in situations where the normal title may be too long to
		/// be displayed.
		/// </remarks>
		/// <param name="title">The new text to be displayed as the condensed title.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setTitleCondensed(java.lang.CharSequence title);

		/// <summary>Retrieve the current condensed title of the item.</summary>
		/// <remarks>
		/// Retrieve the current condensed title of the item. If a condensed
		/// title was never set, it will return the normal title.
		/// </remarks>
		/// <returns>
		/// The condensed title, if it exists.
		/// Otherwise the normal title.
		/// </returns>
		java.lang.CharSequence getTitleCondensed();

		/// <summary>Change the icon associated with this item.</summary>
		/// <remarks>
		/// Change the icon associated with this item. This icon will not always be
		/// shown, so the title should be sufficient in describing this item. See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support icons.
		/// </remarks>
		/// <param name="icon">The new icon (as a Drawable) to be displayed.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setIcon(android.graphics.drawable.Drawable icon);

		/// <summary>Change the icon associated with this item.</summary>
		/// <remarks>
		/// Change the icon associated with this item. This icon will not always be
		/// shown, so the title should be sufficient in describing this item. See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support icons.
		/// <p>
		/// This method will set the resource ID of the icon which will be used to
		/// lazily get the Drawable when this item is being shown.
		/// </remarks>
		/// <param name="iconRes">The new icon (as a resource ID) to be displayed.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setIcon(int iconRes);

		/// <summary>
		/// Returns the icon for this item as a Drawable (getting it from resources if it hasn't been
		/// loaded before).
		/// </summary>
		/// <remarks>
		/// Returns the icon for this item as a Drawable (getting it from resources if it hasn't been
		/// loaded before).
		/// </remarks>
		/// <returns>The icon as a Drawable.</returns>
		android.graphics.drawable.Drawable getIcon();

		/// <summary>Change the Intent associated with this item.</summary>
		/// <remarks>
		/// Change the Intent associated with this item.  By default there is no
		/// Intent associated with a menu item.  If you set one, and nothing
		/// else handles the item, then the default behavior will be to call
		/// <see cref="android.content.Context.startActivity(android.content.Intent)">android.content.Context.startActivity(android.content.Intent)
		/// 	</see>
		/// with the given Intent.
		/// <p>Note that setIntent() can not be used with the versions of
		/// <see cref="Menu.add(java.lang.CharSequence)">Menu.add(java.lang.CharSequence)</see>
		/// that take a Runnable, because
		/// <see cref="java.lang.Runnable.run()">java.lang.Runnable.run()</see>
		/// does not return a value so there is no way to tell if it handled the
		/// item.  In this case it is assumed that the Runnable always handles
		/// the item, and the intent will never be started.
		/// </remarks>
		/// <seealso cref="getIntent()">getIntent()</seealso>
		/// <param name="intent">
		/// The Intent to associated with the item.  This Intent
		/// object is <em>not</em> copied, so be careful not to
		/// modify it later.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setIntent(android.content.Intent intent);

		/// <summary>Return the Intent associated with this item.</summary>
		/// <remarks>
		/// Return the Intent associated with this item.  This returns a
		/// reference to the Intent which you can change as desired to modify
		/// what the Item is holding.
		/// </remarks>
		/// <seealso cref="setIntent(android.content.Intent)">setIntent(android.content.Intent)
		/// 	</seealso>
		/// <returns>
		/// Returns the last value supplied to
		/// <see cref="setIntent(android.content.Intent)">setIntent(android.content.Intent)</see>
		/// , or
		/// null.
		/// </returns>
		android.content.Intent getIntent();

		/// <summary>
		/// Change both the numeric and alphabetic shortcut associated with this
		/// item.
		/// </summary>
		/// <remarks>
		/// Change both the numeric and alphabetic shortcut associated with this
		/// item. Note that the shortcut will be triggered when the key that
		/// generates the given character is pressed alone or along with with the alt
		/// key. Also note that case is not significant and that alphabetic shortcut
		/// characters will be displayed in lower case.
		/// <p>
		/// See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support shortcuts.
		/// </remarks>
		/// <param name="numericChar">
		/// The numeric shortcut key. This is the shortcut when
		/// using a numeric (e.g., 12-key) keyboard.
		/// </param>
		/// <param name="alphaChar">
		/// The alphabetic shortcut key. This is the shortcut when
		/// using a keyboard with alphabetic keys.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setShortcut(char numericChar, char alphaChar);

		/// <summary>Change the numeric shortcut associated with this item.</summary>
		/// <remarks>
		/// Change the numeric shortcut associated with this item.
		/// <p>
		/// See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support shortcuts.
		/// </remarks>
		/// <param name="numericChar">
		/// The numeric shortcut key.  This is the shortcut when
		/// using a 12-key (numeric) keyboard.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setNumericShortcut(char numericChar);

		/// <summary>Return the char for this menu item's numeric (12-key) shortcut.</summary>
		/// <remarks>Return the char for this menu item's numeric (12-key) shortcut.</remarks>
		/// <returns>Numeric character to use as a shortcut.</returns>
		char getNumericShortcut();

		/// <summary>Change the alphabetic shortcut associated with this item.</summary>
		/// <remarks>
		/// Change the alphabetic shortcut associated with this item. The shortcut
		/// will be triggered when the key that generates the given character is
		/// pressed alone or along with with the alt key. Case is not significant and
		/// shortcut characters will be displayed in lower case. Note that menu items
		/// with the characters '\b' or '\n' as shortcuts will get triggered by the
		/// Delete key or Carriage Return key, respectively.
		/// <p>
		/// See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support shortcuts.
		/// </remarks>
		/// <param name="alphaChar">
		/// The alphabetic shortcut key. This is the shortcut when
		/// using a keyboard with alphabetic keys.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setAlphabeticShortcut(char alphaChar);

		/// <summary>Return the char for this menu item's alphabetic shortcut.</summary>
		/// <remarks>Return the char for this menu item's alphabetic shortcut.</remarks>
		/// <returns>Alphabetic character to use as a shortcut.</returns>
		char getAlphabeticShortcut();

		/// <summary>Control whether this item can display a check mark.</summary>
		/// <remarks>
		/// Control whether this item can display a check mark. Setting this does
		/// not actually display a check mark (see
		/// <see cref="setChecked(bool)">setChecked(bool)</see>
		/// for that);
		/// rather, it ensures there is room in the item in which to display a
		/// check mark.
		/// <p>
		/// See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support check marks.
		/// </remarks>
		/// <param name="checkable">
		/// Set to true to allow a check mark, false to
		/// disallow. The default is false.
		/// </param>
		/// <seealso cref="setChecked(bool)">setChecked(bool)</seealso>
		/// <seealso cref="isCheckable()">isCheckable()</seealso>
		/// <seealso cref="Menu.setGroupCheckable(int, bool, bool)">Menu.setGroupCheckable(int, bool, bool)
		/// 	</seealso>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setCheckable(bool checkable);

		/// <summary>Return whether the item can currently display a check mark.</summary>
		/// <remarks>Return whether the item can currently display a check mark.</remarks>
		/// <returns>If a check mark can be displayed, returns true.</returns>
		/// <seealso cref="setCheckable(bool)">setCheckable(bool)</seealso>
		bool isCheckable();

		/// <summary>Control whether this item is shown with a check mark.</summary>
		/// <remarks>
		/// Control whether this item is shown with a check mark.  Note that you
		/// must first have enabled checking with
		/// <see cref="setCheckable(bool)">setCheckable(bool)</see>
		/// or else
		/// the check mark will not appear.  If this item is a member of a group that contains
		/// mutually-exclusive items (set via
		/// <see cref="Menu.setGroupCheckable(int, bool, bool)">Menu.setGroupCheckable(int, bool, bool)
		/// 	</see>
		/// ,
		/// the other items in the group will be unchecked.
		/// <p>
		/// See
		/// <see cref="Menu">Menu</see>
		/// for the menu types that support check marks.
		/// </remarks>
		/// <seealso cref="setCheckable(bool)">setCheckable(bool)</seealso>
		/// <seealso cref="isChecked()">isChecked()</seealso>
		/// <seealso cref="Menu.setGroupCheckable(int, bool, bool)">Menu.setGroupCheckable(int, bool, bool)
		/// 	</seealso>
		/// <param name="checked">
		/// Set to true to display a check mark, false to hide
		/// it.  The default value is false.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setChecked(bool @checked);

		/// <summary>Return whether the item is currently displaying a check mark.</summary>
		/// <remarks>Return whether the item is currently displaying a check mark.</remarks>
		/// <returns>If a check mark is displayed, returns true.</returns>
		/// <seealso cref="setChecked(bool)">setChecked(bool)</seealso>
		bool isChecked();

		/// <summary>Sets the visibility of the menu item.</summary>
		/// <remarks>
		/// Sets the visibility of the menu item. Even if a menu item is not visible,
		/// it may still be invoked via its shortcut (to completely disable an item,
		/// set it to invisible and
		/// <see cref="setEnabled(bool)">disabled</see>
		/// ).
		/// </remarks>
		/// <param name="visible">
		/// If true then the item will be visible; if false it is
		/// hidden.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setVisible(bool visible);

		/// <summary>Return the visibility of the menu item.</summary>
		/// <remarks>Return the visibility of the menu item.</remarks>
		/// <returns>If true the item is visible; else it is hidden.</returns>
		bool isVisible();

		/// <summary>Sets whether the menu item is enabled.</summary>
		/// <remarks>
		/// Sets whether the menu item is enabled. Disabling a menu item will not
		/// allow it to be invoked via its shortcut. The menu item will still be
		/// visible.
		/// </remarks>
		/// <param name="enabled">
		/// If true then the item will be invokable; if false it is
		/// won't be invokable.
		/// </param>
		/// <returns>This Item so additional setters can be called.</returns>
		android.view.MenuItem setEnabled(bool enabled);

		/// <summary>Return the enabled state of the menu item.</summary>
		/// <remarks>Return the enabled state of the menu item.</remarks>
		/// <returns>If true the item is enabled and hence invokable; else it is not.</returns>
		bool isEnabled();

		/// <summary>Check whether this item has an associated sub-menu.</summary>
		/// <remarks>
		/// Check whether this item has an associated sub-menu.  I.e. it is a
		/// sub-menu of another menu.
		/// </remarks>
		/// <returns>
		/// If true this item has a menu; else it is a
		/// normal item.
		/// </returns>
		bool hasSubMenu();

		/// <summary>
		/// Get the sub-menu to be invoked when this item is selected, if it has
		/// one.
		/// </summary>
		/// <remarks>
		/// Get the sub-menu to be invoked when this item is selected, if it has
		/// one. See
		/// <see cref="hasSubMenu()">hasSubMenu()</see>
		/// .
		/// </remarks>
		/// <returns>The associated menu if there is one, else null</returns>
		android.view.SubMenu getSubMenu();

		/// <summary>Set a custom listener for invocation of this menu item.</summary>
		/// <remarks>
		/// Set a custom listener for invocation of this menu item. In most
		/// situations, it is more efficient and easier to use
		/// <see cref="android.app.Activity.onOptionsItemSelected(MenuItem)">android.app.Activity.onOptionsItemSelected(MenuItem)
		/// 	</see>
		/// or
		/// <see cref="android.app.Activity.onContextItemSelected(MenuItem)">android.app.Activity.onContextItemSelected(MenuItem)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="menuItemClickListener">The object to receive invokations.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		/// <seealso cref="android.app.Activity.onOptionsItemSelected(MenuItem)">android.app.Activity.onOptionsItemSelected(MenuItem)
		/// 	</seealso>
		/// <seealso cref="android.app.Activity.onContextItemSelected(MenuItem)">android.app.Activity.onContextItemSelected(MenuItem)
		/// 	</seealso>
		android.view.MenuItem setOnMenuItemClickListener(android.view.MenuItemClass.OnMenuItemClickListener
			 menuItemClickListener);

		/// <summary>Gets the extra information linked to this menu item.</summary>
		/// <remarks>
		/// Gets the extra information linked to this menu item.  This extra
		/// information is set by the View that added this menu item to the
		/// menu.
		/// </remarks>
		/// <seealso cref="OnCreateContextMenuListener">OnCreateContextMenuListener</seealso>
		/// <returns>
		/// The extra information linked to the View that added this
		/// menu item to the menu. This can be null.
		/// </returns>
		android.view.ContextMenuClass.ContextMenuInfo getMenuInfo();

		/// <summary>Sets how this item should display in the presence of an Action Bar.</summary>
		/// <remarks>
		/// Sets how this item should display in the presence of an Action Bar.
		/// The parameter actionEnum is a flag set. One of
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS">android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM">android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM
		/// 	</see>
		/// , or
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_NEVER">android.view.MenuItemClass.SHOW_AS_ACTION_NEVER
		/// 	</see>
		/// should
		/// be used, and you may optionally OR the value with
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT">android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT
		/// 	</see>
		/// .
		/// SHOW_AS_ACTION_WITH_TEXT requests that when the item is shown as an action,
		/// it should be shown with a text label.
		/// </remarks>
		/// <param name="actionEnum">
		/// How the item should display. One of
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS">android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM">android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM
		/// 	</see>
		/// , or
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_NEVER">android.view.MenuItemClass.SHOW_AS_ACTION_NEVER
		/// 	</see>
		/// . SHOW_AS_ACTION_NEVER is the default.
		/// </param>
		/// <seealso cref="android.app.ActionBar">android.app.ActionBar</seealso>
		/// <seealso cref="setActionView(View)">setActionView(View)</seealso>
		void setShowAsAction(int actionEnum);

		/// <summary>Sets how this item should display in the presence of an Action Bar.</summary>
		/// <remarks>
		/// Sets how this item should display in the presence of an Action Bar.
		/// The parameter actionEnum is a flag set. One of
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS">android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM">android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM
		/// 	</see>
		/// , or
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_NEVER">android.view.MenuItemClass.SHOW_AS_ACTION_NEVER
		/// 	</see>
		/// should
		/// be used, and you may optionally OR the value with
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT">android.view.MenuItemClass.SHOW_AS_ACTION_WITH_TEXT
		/// 	</see>
		/// .
		/// SHOW_AS_ACTION_WITH_TEXT requests that when the item is shown as an action,
		/// it should be shown with a text label.
		/// <p>Note: This method differs from
		/// <see cref="setShowAsAction(int)">setShowAsAction(int)</see>
		/// only in that it
		/// returns the current MenuItem instance for call chaining.
		/// </remarks>
		/// <param name="actionEnum">
		/// How the item should display. One of
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS">android.view.MenuItemClass.SHOW_AS_ACTION_ALWAYS
		/// 	</see>
		/// ,
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM">android.view.MenuItemClass.SHOW_AS_ACTION_IF_ROOM
		/// 	</see>
		/// , or
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_NEVER">android.view.MenuItemClass.SHOW_AS_ACTION_NEVER
		/// 	</see>
		/// . SHOW_AS_ACTION_NEVER is the default.
		/// </param>
		/// <seealso cref="android.app.ActionBar">android.app.ActionBar</seealso>
		/// <seealso cref="setActionView(View)">setActionView(View)</seealso>
		/// <returns>This MenuItem instance for call chaining.</returns>
		android.view.MenuItem setShowAsActionFlags(int actionEnum);

		/// <summary>Set an action view for this menu item.</summary>
		/// <remarks>
		/// Set an action view for this menu item. An action view will be displayed in place
		/// of an automatically generated menu item element in the UI when this item is shown
		/// as an action within a parent.
		/// <p>
		/// <strong>Note:</strong> Setting an action view overrides the action provider
		/// set via
		/// <see cref="setActionProvider(ActionProvider)">setActionProvider(ActionProvider)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="view">View to use for presenting this item to the user.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		/// <seealso cref="setShowAsAction(int)">setShowAsAction(int)</seealso>
		android.view.MenuItem setActionView(android.view.View view);

		/// <summary>Set an action view for this menu item.</summary>
		/// <remarks>
		/// Set an action view for this menu item. An action view will be displayed in place
		/// of an automatically generated menu item element in the UI when this item is shown
		/// as an action within a parent.
		/// <p>
		/// <strong>Note:</strong> Setting an action view overrides the action provider
		/// set via
		/// <see cref="setActionProvider(ActionProvider)">setActionProvider(ActionProvider)</see>
		/// .
		/// </p>
		/// </remarks>
		/// <param name="resId">Layout resource to use for presenting this item to the user.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		/// <seealso cref="setShowAsAction(int)">setShowAsAction(int)</seealso>
		android.view.MenuItem setActionView(int resId);

		/// <summary>Returns the currently set action view for this menu item.</summary>
		/// <remarks>Returns the currently set action view for this menu item.</remarks>
		/// <returns>This item's action view</returns>
		/// <seealso cref="setActionView(View)">setActionView(View)</seealso>
		/// <seealso cref="setShowAsAction(int)">setShowAsAction(int)</seealso>
		android.view.View getActionView();

		/// <summary>
		/// Sets the
		/// <see cref="ActionProvider">ActionProvider</see>
		/// responsible for creating an action view if
		/// the item is placed on the action bar. The provider also provides a default
		/// action invoked if the item is placed in the overflow menu.
		/// <p>
		/// <strong>Note:</strong> Setting an action provider overrides the action view
		/// set via
		/// <see cref="setActionView(int)">setActionView(int)</see>
		/// or
		/// <see cref="setActionView(View)">setActionView(View)</see>
		/// .
		/// </p>
		/// </summary>
		/// <param name="actionProvider">The action provider.</param>
		/// <returns>This Item so additional setters can be called.</returns>
		/// <seealso cref="ActionProvider">ActionProvider</seealso>
		android.view.MenuItem setActionProvider(android.view.ActionProvider actionProvider
			);

		/// <summary>
		/// Gets the
		/// <see cref="ActionProvider">ActionProvider</see>
		/// .
		/// </summary>
		/// <returns>The action provider.</returns>
		/// <seealso cref="ActionProvider">ActionProvider</seealso>
		/// <seealso cref="setActionProvider(ActionProvider)">setActionProvider(ActionProvider)
		/// 	</seealso>
		android.view.ActionProvider getActionProvider();

		/// <summary>Expand the action view associated with this menu item.</summary>
		/// <remarks>
		/// Expand the action view associated with this menu item.
		/// The menu item must have an action view set, as well as
		/// the showAsAction flag
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
		/// 	</see>
		/// .
		/// If a listener has been set using
		/// <see cref="setOnActionExpandListener(OnActionExpandListener)">setOnActionExpandListener(OnActionExpandListener)
		/// 	</see>
		/// it will have its
		/// <see cref="OnActionExpandListener.onMenuItemActionExpand(MenuItem)">OnActionExpandListener.onMenuItemActionExpand(MenuItem)
		/// 	</see>
		/// method invoked. The listener may return false from this method to prevent expanding
		/// the action view.
		/// </remarks>
		/// <returns>true if the action view was expanded, false otherwise.</returns>
		bool expandActionView();

		/// <summary>Collapse the action view associated with this menu item.</summary>
		/// <remarks>
		/// Collapse the action view associated with this menu item.
		/// The menu item must have an action view set, as well as the showAsAction flag
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
		/// 	</see>
		/// . If a listener has been set using
		/// <see cref="setOnActionExpandListener(OnActionExpandListener)">setOnActionExpandListener(OnActionExpandListener)
		/// 	</see>
		/// it will have its
		/// <see cref="OnActionExpandListener.onMenuItemActionCollapse(MenuItem)">OnActionExpandListener.onMenuItemActionCollapse(MenuItem)
		/// 	</see>
		/// method invoked.
		/// The listener may return false from this method to prevent collapsing the action view.
		/// </remarks>
		/// <returns>true if the action view was collapsed, false otherwise.</returns>
		bool collapseActionView();

		/// <summary>Returns true if this menu item's action view has been expanded.</summary>
		/// <remarks>Returns true if this menu item's action view has been expanded.</remarks>
		/// <returns>true if the item's action view is expanded, false otherwise.</returns>
		/// <seealso cref="expandActionView()">expandActionView()</seealso>
		/// <seealso cref="collapseActionView()">collapseActionView()</seealso>
		/// <seealso cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
		/// 	</seealso>
		/// <seealso cref="OnActionExpandListener">OnActionExpandListener</seealso>
		bool isActionViewExpanded();

		/// <summary>
		/// Set an
		/// <see cref="OnActionExpandListener">OnActionExpandListener</see>
		/// on this menu item to be notified when
		/// the associated action view is expanded or collapsed. The menu item must
		/// be configured to expand or collapse its action view using the flag
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="listener">Listener that will respond to expand/collapse events</param>
		/// <returns>This menu item instance for call chaining</returns>
		android.view.MenuItem setOnActionExpandListener(android.view.MenuItemClass.OnActionExpandListener
			 listener);
	}

	/// <summary>Interface for direct access to a previously created menu item.</summary>
	/// <remarks>
	/// Interface for direct access to a previously created menu item.
	/// <p>
	/// An Item is returned by calling one of the
	/// <see cref="Menu.add(java.lang.CharSequence)">Menu.add(java.lang.CharSequence)</see>
	/// methods.
	/// <p>
	/// For a feature set of specific menu types, see
	/// <see cref="Menu">Menu</see>
	/// .
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </remarks>
	[Sharpen.Sharpened]
	public static class MenuItemClass
	{
		/// <summary>Never show this item as a button in an Action Bar.</summary>
		/// <remarks>Never show this item as a button in an Action Bar.</remarks>
		public const int SHOW_AS_ACTION_NEVER = 0;

		/// <summary>Show this item as a button in an Action Bar if the system decides there is room for it.
		/// 	</summary>
		/// <remarks>Show this item as a button in an Action Bar if the system decides there is room for it.
		/// 	</remarks>
		public const int SHOW_AS_ACTION_IF_ROOM = 1;

		/// <summary>Always show this item as a button in an Action Bar.</summary>
		/// <remarks>
		/// Always show this item as a button in an Action Bar.
		/// Use sparingly! If too many items are set to always show in the Action Bar it can
		/// crowd the Action Bar and degrade the user experience on devices with smaller screens.
		/// A good rule of thumb is to have no more than 2 items set to always show at a time.
		/// </remarks>
		public const int SHOW_AS_ACTION_ALWAYS = 2;

		/// <summary>
		/// When this item is in the action bar, always show it with a text label even if
		/// it also has an icon specified.
		/// </summary>
		/// <remarks>
		/// When this item is in the action bar, always show it with a text label even if
		/// it also has an icon specified.
		/// </remarks>
		public const int SHOW_AS_ACTION_WITH_TEXT = 4;

		/// <summary>This item's action view collapses to a normal menu item.</summary>
		/// <remarks>
		/// This item's action view collapses to a normal menu item.
		/// When expanded, the action view temporarily takes over
		/// a larger segment of its container.
		/// </remarks>
		public const int SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW = 8;

		/// <summary>
		/// Interface definition for a callback to be invoked when a menu item is
		/// clicked.
		/// </summary>
		/// <remarks>
		/// Interface definition for a callback to be invoked when a menu item is
		/// clicked.
		/// </remarks>
		/// <seealso cref="android.app.Activity.onContextItemSelected(MenuItem)">android.app.Activity.onContextItemSelected(MenuItem)
		/// 	</seealso>
		/// <seealso cref="android.app.Activity.onOptionsItemSelected(MenuItem)">android.app.Activity.onOptionsItemSelected(MenuItem)
		/// 	</seealso>
		public interface OnMenuItemClickListener
		{
			/// <summary>Called when a menu item has been invoked.</summary>
			/// <remarks>
			/// Called when a menu item has been invoked.  This is the first code
			/// that is executed; if it returns true, no other callbacks will be
			/// executed.
			/// </remarks>
			/// <param name="item">The menu item that was invoked.</param>
			/// <returns>
			/// Return true to consume this click and prevent others from
			/// executing.
			/// </returns>
			bool onMenuItemClick(android.view.MenuItem item);
		}

		/// <summary>
		/// Interface definition for a callback to be invoked when a menu item
		/// marked with
		/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
		/// 	</see>
		/// is
		/// expanded or collapsed.
		/// </summary>
		/// <seealso cref="MenuItem.expandActionView()">MenuItem.expandActionView()</seealso>
		/// <seealso cref="MenuItem.collapseActionView()">MenuItem.collapseActionView()</seealso>
		/// <seealso cref="MenuItem.setShowAsActionFlags(int)">MenuItem.setShowAsActionFlags(int)
		/// 	</seealso>
		public interface OnActionExpandListener
		{
			/// <summary>
			/// Called when a menu item with
			/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
			/// 	</see>
			/// is expanded.
			/// </summary>
			/// <param name="item">Item that was expanded</param>
			/// <returns>true if the item should expand, false if expansion should be suppressed.
			/// 	</returns>
			bool onMenuItemActionExpand(android.view.MenuItem item);

			/// <summary>
			/// Called when a menu item with
			/// <see cref="android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW">android.view.MenuItemClass.SHOW_AS_ACTION_COLLAPSE_ACTION_VIEW
			/// 	</see>
			/// is collapsed.
			/// </summary>
			/// <param name="item">Item that was collapsed</param>
			/// <returns>true if the item should collapse, false if collapsing should be suppressed.
			/// 	</returns>
			bool onMenuItemActionCollapse(android.view.MenuItem item);
		}
	}
}
