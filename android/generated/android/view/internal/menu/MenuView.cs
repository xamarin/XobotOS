using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>Minimal interface for a menu view.</summary>
	/// <remarks>
	/// Minimal interface for a menu view.
	/// <see cref="initialize(MenuBuilder)">initialize(MenuBuilder)</see>
	/// must be called for the
	/// menu to be functional.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface MenuView
	{
		/// <summary>Initializes the menu to the given menu.</summary>
		/// <remarks>
		/// Initializes the menu to the given menu. This should be called after the
		/// view is inflated.
		/// </remarks>
		/// <param name="menu">The menu that this MenuView should display.</param>
		void initialize(android.view.@internal.menu.MenuBuilder menu);

		/// <summary>Returns the default animations to be used for this menu when entering/exiting.
		/// 	</summary>
		/// <remarks>Returns the default animations to be used for this menu when entering/exiting.
		/// 	</remarks>
		/// <returns>A resource ID for the default animations to be used for this menu.</returns>
		int getWindowAnimations();
	}

	/// <summary>Minimal interface for a menu view.</summary>
	/// <remarks>
	/// Minimal interface for a menu view.
	/// <see cref="initialize(MenuBuilder)">initialize(MenuBuilder)</see>
	/// must be called for the
	/// menu to be functional.
	/// </remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public static class MenuViewClass
	{
		/// <summary>Minimal interface for a menu item view.</summary>
		/// <remarks>
		/// Minimal interface for a menu item view.
		/// <see cref="initialize(MenuItemImpl, int)">initialize(MenuItemImpl, int)</see>
		/// must be called
		/// for the item to be functional.
		/// </remarks>
		public interface ItemView
		{
			/// <summary>Initializes with the provided MenuItemData.</summary>
			/// <remarks>
			/// Initializes with the provided MenuItemData.  This should be called after the view is
			/// inflated.
			/// </remarks>
			/// <param name="itemData">The item that this ItemView should display.</param>
			/// <param name="menuType">
			/// The type of this menu, one of
			/// <see cref="MenuBuilder#TYPE_ICON">MenuBuilder#TYPE_ICON</see>
			/// ,
			/// <see cref="MenuBuilder#TYPE_EXPANDED">MenuBuilder#TYPE_EXPANDED</see>
			/// ,
			/// <see cref="MenuBuilder#TYPE_DIALOG">MenuBuilder#TYPE_DIALOG</see>
			/// ).
			/// </param>
			void initialize(android.view.@internal.menu.MenuItemImpl itemData, int menuType);

			/// <summary>Gets the item data that this view is displaying.</summary>
			/// <remarks>Gets the item data that this view is displaying.</remarks>
			/// <returns>the item data, or null if there is not one</returns>
			android.view.@internal.menu.MenuItemImpl getItemData();

			/// <summary>Sets the title of the item view.</summary>
			/// <remarks>Sets the title of the item view.</remarks>
			/// <param name="title">The title to set.</param>
			void setTitle(java.lang.CharSequence title);

			/// <summary>Sets the enabled state of the item view.</summary>
			/// <remarks>Sets the enabled state of the item view.</remarks>
			/// <param name="enabled">Whether the item view should be enabled.</param>
			void setEnabled(bool enabled);

			/// <summary>Displays the checkbox for the item view.</summary>
			/// <remarks>
			/// Displays the checkbox for the item view.  This does not ensure the item view will be
			/// checked, for that use
			/// <see cref="setChecked(bool)">setChecked(bool)</see>
			/// .
			/// </remarks>
			/// <param name="checkable">Whether to display the checkbox or to hide it</param>
			void setCheckable(bool checkable);

			/// <summary>Checks the checkbox for the item view.</summary>
			/// <remarks>
			/// Checks the checkbox for the item view.  If the checkbox is hidden, it will NOT be
			/// made visible, call
			/// <see cref="setCheckable(bool)">setCheckable(bool)</see>
			/// for that.
			/// </remarks>
			/// <param name="checked">Whether the checkbox should be checked</param>
			void setChecked(bool @checked);

			/// <summary>Sets the shortcut for the item.</summary>
			/// <remarks>Sets the shortcut for the item.</remarks>
			/// <param name="showShortcut">
			/// Whether a shortcut should be shown(if false, the value of
			/// shortcutKey should be ignored).
			/// </param>
			/// <param name="shortcutKey">The shortcut key that should be shown on the ItemView.</param>
			void setShortcut(bool showShortcut, char shortcutKey);

			/// <summary>Set the icon of this item view.</summary>
			/// <remarks>Set the icon of this item view.</remarks>
			/// <param name="icon">The icon of this item. null to hide the icon.</param>
			void setIcon(android.graphics.drawable.Drawable icon);

			/// <summary>
			/// Whether this item view prefers displaying the condensed title rather
			/// than the normal title.
			/// </summary>
			/// <remarks>
			/// Whether this item view prefers displaying the condensed title rather
			/// than the normal title. If a condensed title is not available, the
			/// normal title will be used.
			/// </remarks>
			/// <returns>
			/// Whether this item view prefers displaying the condensed
			/// title.
			/// </returns>
			bool prefersCondensedTitle();

			/// <summary>Whether this item view shows an icon.</summary>
			/// <remarks>Whether this item view shows an icon.</remarks>
			/// <returns>Whether this item view shows an icon.</returns>
			bool showsIcon();
		}
	}
}
