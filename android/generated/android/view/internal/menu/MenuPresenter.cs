using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>A MenuPresenter is responsible for building views for a Menu object.</summary>
	/// <remarks>
	/// A MenuPresenter is responsible for building views for a Menu object.
	/// It takes over some responsibility from the old style monolithic MenuBuilder class.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface MenuPresenter
	{
		/// <summary>Initialize this presenter for the given context and menu.</summary>
		/// <remarks>
		/// Initialize this presenter for the given context and menu.
		/// This method is called by MenuBuilder when a presenter is
		/// added. See
		/// <see cref="MenuBuilder.addMenuPresenter(MenuPresenter)">MenuBuilder.addMenuPresenter(MenuPresenter)
		/// 	</see>
		/// </remarks>
		/// <param name="context">Context for this presenter; used for view creation and resource management
		/// 	</param>
		/// <param name="menu">Menu to host</param>
		void initForMenu(android.content.Context context, android.view.@internal.menu.MenuBuilder
			 menu);

		/// <summary>
		/// Retrieve a MenuView to display the menu specified in
		/// <see cref="initForMenu(android.content.Context, MenuBuilder)">initForMenu(android.content.Context, MenuBuilder)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="root">Intended parent of the MenuView.</param>
		/// <returns>A freshly created MenuView.</returns>
		android.view.@internal.menu.MenuView getMenuView(android.view.ViewGroup root);

		/// <summary>Update the menu UI in response to a change.</summary>
		/// <remarks>
		/// Update the menu UI in response to a change. Called by
		/// MenuBuilder during the normal course of operation.
		/// </remarks>
		/// <param name="cleared">true if the menu was entirely cleared</param>
		void updateMenuView(bool cleared);

		/// <summary>
		/// Set a callback object that will be notified of menu events
		/// related to this specific presentation.
		/// </summary>
		/// <remarks>
		/// Set a callback object that will be notified of menu events
		/// related to this specific presentation.
		/// </remarks>
		/// <param name="cb">Callback that will be notified of future events</param>
		void setCallback(android.view.@internal.menu.MenuPresenterClass.Callback cb);

		/// <summary>
		/// Called by Menu implementations to indicate that a submenu item
		/// has been selected.
		/// </summary>
		/// <remarks>
		/// Called by Menu implementations to indicate that a submenu item
		/// has been selected. An active Callback should be notified, and
		/// if applicable the presenter should present the submenu.
		/// </remarks>
		/// <param name="subMenu">SubMenu being opened</param>
		/// <returns>true if the the event was handled, false otherwise.</returns>
		bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder subMenu);

		/// <summary>
		/// Called by Menu implementations to indicate that a menu or submenu is
		/// closing.
		/// </summary>
		/// <remarks>
		/// Called by Menu implementations to indicate that a menu or submenu is
		/// closing. Presenter implementations should close the representation
		/// of the menu indicated as necessary and notify a registered callback.
		/// </remarks>
		/// <param name="menu">Menu or submenu that is closing.</param>
		/// <param name="allMenusAreClosing">True if all associated menus are closing.</param>
		void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool allMenusAreClosing
			);

		/// <summary>Called by Menu implementations to flag items that will be shown as actions.
		/// 	</summary>
		/// <remarks>Called by Menu implementations to flag items that will be shown as actions.
		/// 	</remarks>
		/// <returns>true if this presenter changed the action status of any items.</returns>
		bool flagActionItems();

		/// <summary>Called when a menu item with a collapsable action view should expand its action view.
		/// 	</summary>
		/// <remarks>Called when a menu item with a collapsable action view should expand its action view.
		/// 	</remarks>
		/// <param name="menu">Menu containing the item to be expanded</param>
		/// <param name="item">Item to be expanded</param>
		/// <returns>true if this presenter expanded the action view, false otherwise.</returns>
		bool expandItemActionView(android.view.@internal.menu.MenuBuilder menu, android.view.@internal.menu.MenuItemImpl
			 item);

		/// <summary>Called when a menu item with a collapsable action view should collapse its action view.
		/// 	</summary>
		/// <remarks>Called when a menu item with a collapsable action view should collapse its action view.
		/// 	</remarks>
		/// <param name="menu">Menu containing the item to be collapsed</param>
		/// <param name="item">Item to be collapsed</param>
		/// <returns>true if this presenter collapsed the action view, false otherwise.</returns>
		bool collapseItemActionView(android.view.@internal.menu.MenuBuilder menu, android.view.@internal.menu.MenuItemImpl
			 item);

		/// <summary>Returns an ID for determining how to save/restore instance state.</summary>
		/// <remarks>Returns an ID for determining how to save/restore instance state.</remarks>
		/// <returns>a valid ID value.</returns>
		int getId();

		/// <summary>Returns a Parcelable describing the current state of the presenter.</summary>
		/// <remarks>
		/// Returns a Parcelable describing the current state of the presenter.
		/// It will be passed to the
		/// <see cref="onRestoreInstanceState(android.os.Parcelable)">onRestoreInstanceState(android.os.Parcelable)
		/// 	</see>
		/// method of the presenter sharing the same ID later.
		/// </remarks>
		/// <returns>The saved instance state</returns>
		android.os.Parcelable onSaveInstanceState();

		/// <summary>Supplies the previously saved instance state to be restored.</summary>
		/// <remarks>Supplies the previously saved instance state to be restored.</remarks>
		/// <param name="state">The previously saved instance state</param>
		void onRestoreInstanceState(android.os.Parcelable state);
	}

	/// <summary>A MenuPresenter is responsible for building views for a Menu object.</summary>
	/// <remarks>
	/// A MenuPresenter is responsible for building views for a Menu object.
	/// It takes over some responsibility from the old style monolithic MenuBuilder class.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class MenuPresenterClass
	{
		/// <summary>Called by menu implementation to notify another component of open/close events.
		/// 	</summary>
		/// <remarks>Called by menu implementation to notify another component of open/close events.
		/// 	</remarks>
		public interface Callback
		{
			/// <summary>Called when a menu is closing.</summary>
			/// <remarks>Called when a menu is closing.</remarks>
			/// <param name="menu"></param>
			/// <param name="allMenusAreClosing"></param>
			void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool allMenusAreClosing
				);

			/// <summary>Called when a submenu opens.</summary>
			/// <remarks>
			/// Called when a submenu opens. Useful for notifying the application
			/// of menu state so that it does not attempt to hide the action bar
			/// while a submenu is open or similar.
			/// </remarks>
			/// <param name="subMenu">Submenu currently being opened</param>
			/// <returns>
			/// true if the Callback will handle presenting the submenu, false if
			/// the presenter should attempt to do so.
			/// </returns>
			bool onOpenSubMenu(android.view.@internal.menu.MenuBuilder subMenu);
		}
	}
}
