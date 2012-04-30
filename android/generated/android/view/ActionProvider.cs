using Sharpen;

namespace android.view
{
	/// <summary>This class is a mediator for accomplishing a given task, for example sharing a file.
	/// 	</summary>
	/// <remarks>
	/// This class is a mediator for accomplishing a given task, for example sharing a file.
	/// It is responsible for creating a view that performs an action that accomplishes the task.
	/// This class also implements other functions such a performing a default action.
	/// <p>
	/// An ActionProvider can be optionally specified for a
	/// <see cref="MenuItem">MenuItem</see>
	/// and in such a
	/// case it will be responsible for creating the action view that appears in the
	/// <see cref="android.app.ActionBar">android.app.ActionBar</see>
	/// as a substitute for the menu item when the item is
	/// displayed as an action item. Also the provider is responsible for performing a
	/// default action if a menu item placed on the overflow menu of the ActionBar is
	/// selected and none of the menu item callbacks has handled the selection. For this
	/// case the provider can also optionally provide a sub-menu for accomplishing the
	/// task at hand.
	/// </p>
	/// <p>
	/// There are two ways for using an action provider for creating and handling of action views:
	/// <ul>
	/// <li>
	/// Setting the action provider on a
	/// <see cref="MenuItem">MenuItem</see>
	/// directly by calling
	/// <see cref="MenuItem.setActionProvider(ActionProvider)">MenuItem.setActionProvider(ActionProvider)
	/// 	</see>
	/// .
	/// </li>
	/// <li>
	/// Declaring the action provider in the menu XML resource. For example:
	/// <pre>
	/// <code>
	/// &lt;item android:id="@+id/my_menu_item"
	/// android:title="Title"
	/// android:icon="@drawable/my_menu_item_icon"
	/// android:showAsAction="ifRoom"
	/// android:actionProviderClass="foo.bar.SomeActionProvider" /&gt;
	/// </code>
	/// </pre>
	/// </li>
	/// </ul>
	/// </p>
	/// </remarks>
	/// <seealso cref="MenuItem.setActionProvider(ActionProvider)">MenuItem.setActionProvider(ActionProvider)
	/// 	</seealso>
	/// <seealso cref="MenuItem.getActionProvider()">MenuItem.getActionProvider()</seealso>
	[Sharpen.Sharpened]
	public abstract class ActionProvider
	{
		private android.view.ActionProvider.SubUiVisibilityListener mSubUiVisibilityListener;

		/// <summary>Creates a new instance.</summary>
		/// <remarks>Creates a new instance.</remarks>
		/// <param name="context">Context for accessing resources.</param>
		public ActionProvider(android.content.Context context)
		{
		}

		/// <summary>Factory method for creating new action views.</summary>
		/// <remarks>Factory method for creating new action views.</remarks>
		/// <returns>A new action view.</returns>
		public abstract android.view.View onCreateActionView();

		/// <summary>Performs an optional default action.</summary>
		/// <remarks>
		/// Performs an optional default action.
		/// <p>
		/// For the case of an action provider placed in a menu item not shown as an action this
		/// method is invoked if previous callbacks for processing menu selection has handled
		/// the event.
		/// </p>
		/// <p>
		/// A menu item selection is processed in the following order:
		/// <ul>
		/// <li>
		/// Receiving a call to
		/// <see cref="OnMenuItemClickListener.onMenuItemClick(MenuItem)">MenuItem.OnMenuItemClickListener.onMenuItemClick
		/// 	</see>
		/// .
		/// </li>
		/// <li>
		/// Receiving a call to
		/// <see cref="android.app.Activity.onOptionsItemSelected(MenuItem)">Activity.onOptionsItemSelected(MenuItem)
		/// 	</see>
		/// </li>
		/// <li>
		/// Receiving a call to
		/// <see cref="android.app.Fragment.onOptionsItemSelected(MenuItem)">Fragment.onOptionsItemSelected(MenuItem)
		/// 	</see>
		/// </li>
		/// <li>
		/// Launching the
		/// <see cref="android.content.Intent">android.content.Intent</see>
		/// set via
		/// <see cref="MenuItem.setIntent(android.content.Intent)">MenuItem.setIntent(android.content.Intent)
		/// 	</see>
		/// </li>
		/// <li>
		/// Invoking this method.
		/// </li>
		/// </ul>
		/// </p>
		/// <p>
		/// The default implementation does not perform any action and returns false.
		/// </p>
		/// </remarks>
		public virtual bool onPerformDefaultAction()
		{
			return false;
		}

		/// <summary>Determines if this ActionProvider has a submenu associated with it.</summary>
		/// <remarks>
		/// Determines if this ActionProvider has a submenu associated with it.
		/// <p>Associated submenus will be shown when an action view is not. This
		/// provider instance will receive a call to
		/// <see cref="onPrepareSubMenu(SubMenu)">onPrepareSubMenu(SubMenu)</see>
		/// after the call to
		/// <see cref="onPerformDefaultAction()">onPerformDefaultAction()</see>
		/// and before a submenu is
		/// displayed to the user.
		/// </remarks>
		/// <returns>true if the item backed by this provider should have an associated submenu
		/// 	</returns>
		public virtual bool hasSubMenu()
		{
			return false;
		}

		/// <summary>Called to prepare an associated submenu for the menu item backed by this ActionProvider.
		/// 	</summary>
		/// <remarks>
		/// Called to prepare an associated submenu for the menu item backed by this ActionProvider.
		/// <p>if
		/// <see cref="hasSubMenu()">hasSubMenu()</see>
		/// returns true, this method will be called when the
		/// menu item is selected to prepare the submenu for presentation to the user. Apps
		/// may use this to create or alter submenu content right before display.
		/// </remarks>
		/// <param name="subMenu">Submenu that will be displayed</param>
		public virtual void onPrepareSubMenu(android.view.SubMenu subMenu)
		{
		}

		/// <summary>
		/// Notify the system that the visibility of an action view's sub-UI such as
		/// an anchored popup has changed.
		/// </summary>
		/// <remarks>
		/// Notify the system that the visibility of an action view's sub-UI such as
		/// an anchored popup has changed. This will affect how other system
		/// visibility notifications occur.
		/// </remarks>
		/// <hide>Pending future API approval</hide>
		public virtual void subUiVisibilityChanged(bool isVisible)
		{
			if (mSubUiVisibilityListener != null)
			{
				mSubUiVisibilityListener.onSubUiVisibilityChanged(isVisible);
			}
		}

		/// <hide>Internal use only</hide>
		public virtual void setSubUiVisibilityListener(android.view.ActionProvider.SubUiVisibilityListener
			 listener)
		{
			mSubUiVisibilityListener = listener;
		}

		/// <hide>Internal use only</hide>
		public interface SubUiVisibilityListener
		{
			void onSubUiVisibilityChanged(bool isVisible);
		}
	}
}
