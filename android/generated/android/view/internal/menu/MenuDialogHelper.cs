using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>Helper for menus that appear as Dialogs (context and submenus).</summary>
	/// <remarks>Helper for menus that appear as Dialogs (context and submenus).</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class MenuDialogHelper : android.content.DialogInterfaceClass.OnKeyListener
		, android.content.DialogInterfaceClass.OnClickListener, android.content.DialogInterfaceClass
		.OnDismissListener, android.view.@internal.menu.MenuPresenterClass.Callback
	{
		private android.view.@internal.menu.MenuBuilder mMenu;

		private android.app.AlertDialog mDialog;

		internal android.view.@internal.menu.ListMenuPresenter mPresenter;

		private android.view.@internal.menu.MenuPresenterClass.Callback mPresenterCallback;

		public MenuDialogHelper(android.view.@internal.menu.MenuBuilder menu)
		{
			mMenu = menu;
		}

		/// <summary>Shows menu as a dialog.</summary>
		/// <remarks>Shows menu as a dialog.</remarks>
		/// <param name="windowToken">Optional token to assign to the window.</param>
		public virtual void show(android.os.IBinder windowToken)
		{
			// Many references to mMenu, create local reference
			android.view.@internal.menu.MenuBuilder menu = mMenu;
			// Get the builder for the dialog
			android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(menu
				.getContext());
			mPresenter = new android.view.@internal.menu.ListMenuPresenter(builder.getContext
				(), android.@internal.R.layout.list_menu_item_layout);
			mPresenter.setCallback(this);
			mMenu.addMenuPresenter(mPresenter);
			builder.setAdapter(mPresenter.getAdapter(), this);
			// Set the title
			android.view.View headerView = menu.getHeaderView();
			if (headerView != null)
			{
				// Menu's client has given a custom header view, use it
				builder.setCustomTitle(headerView);
			}
			else
			{
				// Otherwise use the (text) title and icon
				builder.setIcon(menu.getHeaderIcon()).setTitle(menu.getHeaderTitle());
			}
			// Set the key listener
			builder.setOnKeyListener(this);
			// Show the menu
			mDialog = builder.create();
			mDialog.setOnDismissListener(this);
			android.view.WindowManagerClass.LayoutParams lp = mDialog.getWindow().getAttributes
				();
			lp.type = android.view.WindowManagerClass.LayoutParams.TYPE_APPLICATION_ATTACHED_DIALOG;
			if (windowToken != null)
			{
				lp.token = windowToken;
			}
			lp.flags |= android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM;
			mDialog.show();
		}

		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnKeyListener")]
		public virtual bool onKey(android.content.DialogInterface dialog, int keyCode, android.view.KeyEvent
			 @event)
		{
			if (keyCode == android.view.KeyEvent.KEYCODE_MENU || keyCode == android.view.KeyEvent
				.KEYCODE_BACK)
			{
				if (@event.getAction() == android.view.KeyEvent.ACTION_DOWN && @event.getRepeatCount
					() == 0)
				{
					android.view.Window win = mDialog.getWindow();
					if (win != null)
					{
						android.view.View decor = win.getDecorView();
						if (decor != null)
						{
							android.view.KeyEvent.DispatcherState ds = decor.getKeyDispatcherState();
							if (ds != null)
							{
								ds.startTracking(@event, this);
								return true;
							}
						}
					}
				}
				else
				{
					if (@event.getAction() == android.view.KeyEvent.ACTION_UP && !@event.isCanceled())
					{
						android.view.Window win = mDialog.getWindow();
						if (win != null)
						{
							android.view.View decor = win.getDecorView();
							if (decor != null)
							{
								android.view.KeyEvent.DispatcherState ds = decor.getKeyDispatcherState();
								if (ds != null && ds.isTracking(@event))
								{
									mMenu.close(true);
									dialog.dismiss();
									return true;
								}
							}
						}
					}
				}
			}
			// Menu shortcut matching
			return mMenu.performShortcut(keyCode, @event, 0);
		}

		public virtual void setPresenterCallback(android.view.@internal.menu.MenuPresenterClass
			.Callback cb)
		{
			mPresenterCallback = cb;
		}

		/// <summary>Dismisses the menu's dialog.</summary>
		/// <remarks>Dismisses the menu's dialog.</remarks>
		/// <seealso cref="android.app.Dialog.dismiss()">android.app.Dialog.dismiss()</seealso>
		public virtual void dismiss()
		{
			if (mDialog != null)
			{
				mDialog.dismiss();
			}
		}

		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnDismissListener"
			)]
		public virtual void onDismiss(android.content.DialogInterface dialog)
		{
			mPresenter.onCloseMenu(mMenu, true);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
			)]
		public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			if (allMenusAreClosing || menu == mMenu)
			{
				dismiss();
			}
			if (mPresenterCallback != null)
			{
				mPresenterCallback.onCloseMenu(menu, allMenusAreClosing);
			}
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuPresenter.Callback"
			)]
		public virtual bool onOpenSubMenu(android.view.@internal.menu.MenuBuilder subMenu
			)
		{
			if (mPresenterCallback != null)
			{
				return mPresenterCallback.onOpenSubMenu(subMenu);
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnClickListener")]
		public virtual void onClick(android.content.DialogInterface dialog, int which)
		{
			mMenu.performItemAction((android.view.@internal.menu.MenuItemImpl)mPresenter.getAdapter
				().getItem(which), 0);
		}
	}
}
