using Sharpen;

namespace android.view
{
	/// <summary>
	/// Extension of
	/// <see cref="Menu">Menu</see>
	/// for context menus providing functionality to modify
	/// the header of the context menu.
	/// <p>
	/// Context menus do not support item shortcuts and item icons.
	/// <p>
	/// To show a context menu on long click, most clients will want to call
	/// <see cref="android.app.Activity.registerForContextMenu(View)">android.app.Activity.registerForContextMenu(View)
	/// 	</see>
	/// and override
	/// <see cref="android.app.Activity.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)
	/// 	">android.app.Activity.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)</see>
	/// .
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </summary>
	[Sharpen.Sharpened]
	public interface ContextMenu : android.view.Menu
	{
		/// <summary>
		/// Sets the context menu header's title to the title given in <var>titleRes</var>
		/// resource identifier.
		/// </summary>
		/// <remarks>
		/// Sets the context menu header's title to the title given in <var>titleRes</var>
		/// resource identifier.
		/// </remarks>
		/// <param name="titleRes">The string resource identifier used for the title.</param>
		/// <returns>This ContextMenu so additional setters can be called.</returns>
		android.view.ContextMenu setHeaderTitle(int titleRes);

		/// <summary>Sets the context menu header's title to the title given in <var>title</var>.
		/// 	</summary>
		/// <remarks>Sets the context menu header's title to the title given in <var>title</var>.
		/// 	</remarks>
		/// <param name="title">The character sequence used for the title.</param>
		/// <returns>This ContextMenu so additional setters can be called.</returns>
		android.view.ContextMenu setHeaderTitle(java.lang.CharSequence title);

		/// <summary>
		/// Sets the context menu header's icon to the icon given in <var>iconRes</var>
		/// resource id.
		/// </summary>
		/// <remarks>
		/// Sets the context menu header's icon to the icon given in <var>iconRes</var>
		/// resource id.
		/// </remarks>
		/// <param name="iconRes">The resource identifier used for the icon.</param>
		/// <returns>This ContextMenu so additional setters can be called.</returns>
		android.view.ContextMenu setHeaderIcon(int iconRes);

		/// <summary>
		/// Sets the context menu header's icon to the icon given in <var>icon</var>
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="icon">
		/// The
		/// <see cref="android.graphics.drawable.Drawable">android.graphics.drawable.Drawable
		/// 	</see>
		/// used for the icon.
		/// </param>
		/// <returns>This ContextMenu so additional setters can be called.</returns>
		android.view.ContextMenu setHeaderIcon(android.graphics.drawable.Drawable icon);

		/// <summary>
		/// Sets the header of the context menu to the
		/// <see cref="View">View</see>
		/// given in
		/// <var>view</var>. This replaces the header title and icon (and those
		/// replace this).
		/// </summary>
		/// <param name="view">
		/// The
		/// <see cref="View">View</see>
		/// used for the header.
		/// </param>
		/// <returns>This ContextMenu so additional setters can be called.</returns>
		android.view.ContextMenu setHeaderView(android.view.View view);

		/// <summary>Clears the header of the context menu.</summary>
		/// <remarks>Clears the header of the context menu.</remarks>
		void clearHeader();
	}

	/// <summary>
	/// Extension of
	/// <see cref="Menu">Menu</see>
	/// for context menus providing functionality to modify
	/// the header of the context menu.
	/// <p>
	/// Context menus do not support item shortcuts and item icons.
	/// <p>
	/// To show a context menu on long click, most clients will want to call
	/// <see cref="android.app.Activity.registerForContextMenu(View)">android.app.Activity.registerForContextMenu(View)
	/// 	</see>
	/// and override
	/// <see cref="android.app.Activity.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)
	/// 	">android.app.Activity.onCreateContextMenu(ContextMenu, View, ContextMenuInfo)</see>
	/// .
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </summary>
	[Sharpen.Sharpened]
	public static class ContextMenuClass
	{
		/// <summary>Additional information regarding the creation of the context menu.</summary>
		/// <remarks>
		/// Additional information regarding the creation of the context menu.  For example,
		/// <see cref="android.widget.AdapterView{T}">android.widget.AdapterView&lt;T&gt;</see>
		/// s use this to pass the exact item position within the adapter
		/// that initiated the context menu.
		/// </remarks>
		public interface ContextMenuInfo
		{
		}
	}
}
