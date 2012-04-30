using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A PopupMenu displays a
	/// <see cref="android.view.Menu">android.view.Menu</see>
	/// in a modal popup window anchored to a
	/// <see cref="android.view.View">android.view.View</see>
	/// .
	/// The popup will appear below the anchor view if there is room, or above it if there is not.
	/// If the IME is visible the popup will not overlap it until it is touched. Touching outside
	/// of the popup will dismiss it.
	/// </summary>
	[Sharpen.Sharpened]
	public class PopupMenu : android.view.@internal.menu.MenuBuilder.Callback, android.view.@internal.menu.MenuPresenterClass
		.Callback
	{
		private android.content.Context mContext;

		private android.view.@internal.menu.MenuBuilder mMenu;

		private android.view.View mAnchor;

		private android.view.@internal.menu.MenuPopupHelper mPopup;

		private android.widget.PopupMenu.OnMenuItemClickListener mMenuItemClickListener;

		private android.widget.PopupMenu.OnDismissListener mDismissListener;

		/// <summary>Callback interface used to notify the application that the menu has closed.
		/// 	</summary>
		/// <remarks>Callback interface used to notify the application that the menu has closed.
		/// 	</remarks>
		public interface OnDismissListener
		{
			/// <summary>Called when the associated menu has been dismissed.</summary>
			/// <remarks>Called when the associated menu has been dismissed.</remarks>
			/// <param name="menu">The PopupMenu that was dismissed.</param>
			void onDismiss(android.widget.PopupMenu menu);
		}

		/// <summary>Construct a new PopupMenu.</summary>
		/// <remarks>Construct a new PopupMenu.</remarks>
		/// <param name="context">Context for the PopupMenu.</param>
		/// <param name="anchor">
		/// Anchor view for this popup. The popup will appear below the anchor if there
		/// is room, or above it if there is not.
		/// </param>
		public PopupMenu(android.content.Context context, android.view.View anchor)
		{
			// TODO Theme?
			mContext = context;
			mMenu = new android.view.@internal.menu.MenuBuilder(context);
			mMenu.setCallback(this);
			mAnchor = anchor;
			mPopup = new android.view.@internal.menu.MenuPopupHelper(context, mMenu, anchor);
			mPopup.setCallback(this);
		}

		/// <returns>
		/// the
		/// <see cref="android.view.Menu">android.view.Menu</see>
		/// associated with this popup. Populate the returned Menu with
		/// items before calling
		/// <see cref="show()">show()</see>
		/// .
		/// </returns>
		/// <seealso cref="show()">show()</seealso>
		/// <seealso cref="getMenuInflater()">getMenuInflater()</seealso>
		public virtual android.view.Menu getMenu()
		{
			return mMenu;
		}

		/// <returns>
		/// a
		/// <see cref="android.view.MenuInflater">android.view.MenuInflater</see>
		/// that can be used to inflate menu items from XML into the
		/// menu returned by
		/// <see cref="getMenu()">getMenu()</see>
		/// .
		/// </returns>
		/// <seealso cref="getMenu()">getMenu()</seealso>
		public virtual android.view.MenuInflater getMenuInflater()
		{
			return new android.view.MenuInflater(mContext);
		}

		/// <summary>Inflate a menu resource into this PopupMenu.</summary>
		/// <remarks>
		/// Inflate a menu resource into this PopupMenu. This is equivalent to calling
		/// popupMenu.getMenuInflater().inflate(menuRes, popupMenu.getMenu()).
		/// </remarks>
		/// <param name="menuRes">Menu resource to inflate</param>
		public virtual void inflate(int menuRes)
		{
			getMenuInflater().inflate(menuRes, mMenu);
		}

		/// <summary>Show the menu popup anchored to the view specified during construction.</summary>
		/// <remarks>Show the menu popup anchored to the view specified during construction.</remarks>
		/// <seealso cref="dismiss()">dismiss()</seealso>
		public virtual void show()
		{
			mPopup.show();
		}

		/// <summary>Dismiss the menu popup.</summary>
		/// <remarks>Dismiss the menu popup.</remarks>
		/// <seealso cref="show()">show()</seealso>
		public virtual void dismiss()
		{
			mPopup.dismiss();
		}

		/// <summary>Set a listener that will be notified when the user selects an item from the menu.
		/// 	</summary>
		/// <remarks>Set a listener that will be notified when the user selects an item from the menu.
		/// 	</remarks>
		/// <param name="listener">Listener to notify</param>
		public virtual void setOnMenuItemClickListener(android.widget.PopupMenu.OnMenuItemClickListener
			 listener)
		{
			mMenuItemClickListener = listener;
		}

		/// <summary>Set a listener that will be notified when this menu is dismissed.</summary>
		/// <remarks>Set a listener that will be notified when this menu is dismissed.</remarks>
		/// <param name="listener">Listener to notify</param>
		public virtual void setOnDismissListener(android.widget.PopupMenu.OnDismissListener
			 listener)
		{
			mDismissListener = listener;
		}

		/// <hide></hide>
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
			)]
		public virtual bool onMenuItemSelected(android.view.@internal.menu.MenuBuilder menu
			, android.view.MenuItem item)
		{
			if (mMenuItemClickListener != null)
			{
				return mMenuItemClickListener.onMenuItemClick(item);
			}
			return false;
		}

		/// <hide></hide>
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
			)]
		public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			if (mDismissListener != null)
			{
				mDismissListener.onDismiss(this);
			}
		}

		/// <hide></hide>
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
			)]
		public virtual bool onOpenSubMenu(android.view.@internal.menu.MenuBuilder subMenu
			)
		{
			if (subMenu == null)
			{
				return false;
			}
			if (!subMenu.hasVisibleItems())
			{
				return true;
			}
			// Current menu will be dismissed by the normal helper, submenu will be shown in its place.
			new android.view.@internal.menu.MenuPopupHelper(mContext, subMenu, mAnchor).show(
				);
			return true;
		}

		/// <hide></hide>
		public virtual void onCloseSubMenu(android.view.@internal.menu.SubMenuBuilder menu
			)
		{
		}

		/// <hide></hide>
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
			)]
		public virtual void onMenuModeChange(android.view.@internal.menu.MenuBuilder menu
			)
		{
		}

		/// <summary>
		/// Interface responsible for receiving menu item click events if the items themselves
		/// do not have individual item click listeners.
		/// </summary>
		/// <remarks>
		/// Interface responsible for receiving menu item click events if the items themselves
		/// do not have individual item click listeners.
		/// </remarks>
		public interface OnMenuItemClickListener
		{
			/// <summary>
			/// This method will be invoked when a menu item is clicked if the item itself did
			/// not already handle the event.
			/// </summary>
			/// <remarks>
			/// This method will be invoked when a menu item is clicked if the item itself did
			/// not already handle the event.
			/// </remarks>
			/// <param name="item">
			/// 
			/// <see cref="android.view.MenuItem">android.view.MenuItem</see>
			/// that was clicked
			/// </param>
			/// <returns><code>true</code> if the event was handled, <code>false</code> otherwise.
			/// 	</returns>
			bool onMenuItemClick(android.view.MenuItem item);
		}
	}
}
