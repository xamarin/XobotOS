using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>
	/// Implementation of the
	/// <see cref="android.view.ContextMenu">android.view.ContextMenu</see>
	/// interface.
	/// <p>
	/// Most clients of the menu framework will never need to touch this
	/// class.  However, if the client has a window that
	/// is not a content view of a Dialog or Activity (for example, the
	/// view was added directly to the window manager) and needs to show
	/// context menus, it will use this class.
	/// <p>
	/// To use this class, instantiate it via
	/// <see cref="ContextMenuBuilder(android.content.Context)">ContextMenuBuilder(android.content.Context)
	/// 	</see>
	/// ,
	/// and optionally populate it with any of your custom items.  Finally,
	/// call
	/// <see cref="show(android.view.View, android.os.IBinder)">show(android.view.View, android.os.IBinder)
	/// 	</see>
	/// which will populate the menu
	/// with a view's context menu items and show the context menu.
	/// </summary>
	[Sharpen.Sharpened]
	public class ContextMenuBuilder : android.view.@internal.menu.MenuBuilder, android.view.ContextMenu
	{
		public ContextMenuBuilder(android.content.Context context) : base(context)
		{
		}

		[Sharpen.ImplementsInterface(@"android.view.ContextMenu")]
		public virtual android.view.ContextMenu setHeaderIcon(android.graphics.drawable.Drawable
			 icon)
		{
			return (android.view.ContextMenu)base.setHeaderIconInt(icon);
		}

		[Sharpen.ImplementsInterface(@"android.view.ContextMenu")]
		public virtual android.view.ContextMenu setHeaderIcon(int iconRes)
		{
			return (android.view.ContextMenu)base.setHeaderIconInt(iconRes);
		}

		[Sharpen.ImplementsInterface(@"android.view.ContextMenu")]
		public virtual android.view.ContextMenu setHeaderTitle(java.lang.CharSequence title
			)
		{
			return (android.view.ContextMenu)base.setHeaderTitleInt(title);
		}

		[Sharpen.ImplementsInterface(@"android.view.ContextMenu")]
		public virtual android.view.ContextMenu setHeaderTitle(int titleRes)
		{
			return (android.view.ContextMenu)base.setHeaderTitleInt(titleRes);
		}

		[Sharpen.ImplementsInterface(@"android.view.ContextMenu")]
		public virtual android.view.ContextMenu setHeaderView(android.view.View view)
		{
			return (android.view.ContextMenu)base.setHeaderViewInt(view);
		}

		/// <summary>
		/// Shows this context menu, allowing the optional original view (and its
		/// ancestors) to add items.
		/// </summary>
		/// <remarks>
		/// Shows this context menu, allowing the optional original view (and its
		/// ancestors) to add items.
		/// </remarks>
		/// <param name="originalView">
		/// Optional, the original view that triggered the
		/// context menu.
		/// </param>
		/// <param name="token">
		/// Optional, the window token that should be set on the context
		/// menu's window.
		/// </param>
		/// <returns>
		/// If the context menu was shown, the
		/// <see cref="MenuDialogHelper">MenuDialogHelper</see>
		/// for
		/// dismissing it. Otherwise, null.
		/// </returns>
		public virtual android.view.@internal.menu.MenuDialogHelper show(android.view.View
			 originalView, android.os.IBinder token)
		{
			if (originalView != null)
			{
				// Let relevant views and their populate context listeners populate
				// the context menu
				originalView.createContextMenu(this);
			}
			if (getVisibleItems().size() > 0)
			{
				android.util.EventLog.writeEvent(50001, 1);
				android.view.@internal.menu.MenuDialogHelper helper = new android.view.@internal.menu.MenuDialogHelper
					(this);
				helper.show(token);
				return helper;
			}
			return null;
		}
	}
}
