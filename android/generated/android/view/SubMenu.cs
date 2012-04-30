using Sharpen;

namespace android.view
{
	/// <summary>
	/// Subclass of
	/// <see cref="Menu">Menu</see>
	/// for sub menus.
	/// <p>
	/// Sub menus do not support item icons, or nested sub menus.
	/// <div class="special reference">
	/// <h3>Developer Guides</h3>
	/// <p>For information about creating menus, read the
	/// &lt;a href="
	/// <docRoot></docRoot>
	/// guide/topics/ui/menus.html"&gt;Menus</a> developer guide.</p>
	/// </div>
	/// </summary>
	[Sharpen.Sharpened]
	public interface SubMenu : android.view.Menu
	{
		/// <summary>
		/// Sets the submenu header's title to the title given in <var>titleRes</var>
		/// resource identifier.
		/// </summary>
		/// <remarks>
		/// Sets the submenu header's title to the title given in <var>titleRes</var>
		/// resource identifier.
		/// </remarks>
		/// <param name="titleRes">The string resource identifier used for the title.</param>
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setHeaderTitle(int titleRes);

		/// <summary>Sets the submenu header's title to the title given in <var>title</var>.</summary>
		/// <remarks>Sets the submenu header's title to the title given in <var>title</var>.</remarks>
		/// <param name="title">The character sequence used for the title.</param>
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setHeaderTitle(java.lang.CharSequence title);

		/// <summary>
		/// Sets the submenu header's icon to the icon given in <var>iconRes</var>
		/// resource id.
		/// </summary>
		/// <remarks>
		/// Sets the submenu header's icon to the icon given in <var>iconRes</var>
		/// resource id.
		/// </remarks>
		/// <param name="iconRes">The resource identifier used for the icon.</param>
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setHeaderIcon(int iconRes);

		/// <summary>
		/// Sets the submenu header's icon to the icon given in <var>icon</var>
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
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setHeaderIcon(android.graphics.drawable.Drawable icon);

		/// <summary>
		/// Sets the header of the submenu to the
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
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setHeaderView(android.view.View view);

		/// <summary>Clears the header of the submenu.</summary>
		/// <remarks>Clears the header of the submenu.</remarks>
		void clearHeader();

		/// <summary>Change the icon associated with this submenu's item in its parent menu.</summary>
		/// <remarks>Change the icon associated with this submenu's item in its parent menu.</remarks>
		/// <seealso cref="MenuItem.setIcon(int)">MenuItem.setIcon(int)</seealso>
		/// <param name="iconRes">The new icon (as a resource ID) to be displayed.</param>
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setIcon(int iconRes);

		/// <summary>Change the icon associated with this submenu's item in its parent menu.</summary>
		/// <remarks>Change the icon associated with this submenu's item in its parent menu.</remarks>
		/// <seealso cref="MenuItem.setIcon(android.graphics.drawable.Drawable)">MenuItem.setIcon(android.graphics.drawable.Drawable)
		/// 	</seealso>
		/// <param name="icon">The new icon (as a Drawable) to be displayed.</param>
		/// <returns>This SubMenu so additional setters can be called.</returns>
		android.view.SubMenu setIcon(android.graphics.drawable.Drawable icon);

		/// <summary>
		/// Gets the
		/// <see cref="MenuItem">MenuItem</see>
		/// that represents this submenu in the parent
		/// menu.  Use this for setting additional item attributes.
		/// </summary>
		/// <returns>
		/// The
		/// <see cref="MenuItem">MenuItem</see>
		/// that launches the submenu when invoked.
		/// </returns>
		android.view.MenuItem getItem();
	}
}
