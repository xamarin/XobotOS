using Sharpen;

namespace android.view
{
	/// <summary>Represents a contextual mode of the user interface.</summary>
	/// <remarks>
	/// Represents a contextual mode of the user interface. Action modes can be used for
	/// modal interactions with content and replace parts of the normal UI until finished.
	/// Examples of good action modes include selection modes, search, content editing, etc.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class ActionMode
	{
		private object mTag;

		/// <summary>Set a tag object associated with this ActionMode.</summary>
		/// <remarks>
		/// Set a tag object associated with this ActionMode.
		/// <p>Like the tag available to views, this allows applications to associate arbitrary
		/// data with an ActionMode for later reference.
		/// </remarks>
		/// <param name="tag">Tag to associate with this ActionMode</param>
		/// <seealso cref="getTag()">getTag()</seealso>
		public virtual void setTag(object tag)
		{
			mTag = tag;
		}

		/// <summary>Retrieve the tag object associated with this ActionMode.</summary>
		/// <remarks>
		/// Retrieve the tag object associated with this ActionMode.
		/// <p>Like the tag available to views, this allows applications to associate arbitrary
		/// data with an ActionMode for later reference.
		/// </remarks>
		/// <returns>Tag associated with this ActionMode</returns>
		/// <seealso cref="setTag(object)">setTag(object)</seealso>
		public virtual object getTag()
		{
			return mTag;
		}

		/// <summary>Set the title of the action mode.</summary>
		/// <remarks>
		/// Set the title of the action mode. This method will have no visible effect if
		/// a custom view has been set.
		/// </remarks>
		/// <param name="title">Title string to set</param>
		/// <seealso cref="setTitle(int)">setTitle(int)</seealso>
		/// <seealso cref="setCustomView(View)">setCustomView(View)</seealso>
		public abstract void setTitle(java.lang.CharSequence title);

		/// <summary>Set the title of the action mode.</summary>
		/// <remarks>
		/// Set the title of the action mode. This method will have no visible effect if
		/// a custom view has been set.
		/// </remarks>
		/// <param name="resId">Resource ID of a string to set as the title</param>
		/// <seealso cref="setTitle(java.lang.CharSequence)">setTitle(java.lang.CharSequence)
		/// 	</seealso>
		/// <seealso cref="setCustomView(View)">setCustomView(View)</seealso>
		public abstract void setTitle(int resId);

		/// <summary>Set the subtitle of the action mode.</summary>
		/// <remarks>
		/// Set the subtitle of the action mode. This method will have no visible effect if
		/// a custom view has been set.
		/// </remarks>
		/// <param name="subtitle">Subtitle string to set</param>
		/// <seealso cref="setSubtitle(int)">setSubtitle(int)</seealso>
		/// <seealso cref="setCustomView(View)">setCustomView(View)</seealso>
		public abstract void setSubtitle(java.lang.CharSequence subtitle);

		/// <summary>Set the subtitle of the action mode.</summary>
		/// <remarks>
		/// Set the subtitle of the action mode. This method will have no visible effect if
		/// a custom view has been set.
		/// </remarks>
		/// <param name="resId">Resource ID of a string to set as the subtitle</param>
		/// <seealso cref="setSubtitle(java.lang.CharSequence)">setSubtitle(java.lang.CharSequence)
		/// 	</seealso>
		/// <seealso cref="setCustomView(View)">setCustomView(View)</seealso>
		public abstract void setSubtitle(int resId);

		/// <summary>Set a custom view for this action mode.</summary>
		/// <remarks>
		/// Set a custom view for this action mode. The custom view will take the place of
		/// the title and subtitle. Useful for things like search boxes.
		/// </remarks>
		/// <param name="view">Custom view to use in place of the title/subtitle.</param>
		/// <seealso cref="setTitle(java.lang.CharSequence)">setTitle(java.lang.CharSequence)
		/// 	</seealso>
		/// <seealso cref="setSubtitle(java.lang.CharSequence)">setSubtitle(java.lang.CharSequence)
		/// 	</seealso>
		public abstract void setCustomView(android.view.View view);

		/// <summary>Invalidate the action mode and refresh menu content.</summary>
		/// <remarks>
		/// Invalidate the action mode and refresh menu content. The mode's
		/// <see cref="Callback">Callback</see>
		/// will have its
		/// <see cref="Callback.onPrepareActionMode(ActionMode, Menu)">Callback.onPrepareActionMode(ActionMode, Menu)
		/// 	</see>
		/// method called.
		/// If it returns true the menu will be scanned for updated content and any relevant changes
		/// will be reflected to the user.
		/// </remarks>
		public abstract void invalidate();

		/// <summary>Finish and close this action mode.</summary>
		/// <remarks>
		/// Finish and close this action mode. The action mode's
		/// <see cref="Callback">Callback</see>
		/// will
		/// have its
		/// <see cref="Callback.onDestroyActionMode(ActionMode)">Callback.onDestroyActionMode(ActionMode)
		/// 	</see>
		/// method called.
		/// </remarks>
		public abstract void finish();

		/// <summary>Returns the menu of actions that this action mode presents.</summary>
		/// <remarks>Returns the menu of actions that this action mode presents.</remarks>
		/// <returns>The action mode's menu.</returns>
		public abstract android.view.Menu getMenu();

		/// <summary>Returns the current title of this action mode.</summary>
		/// <remarks>Returns the current title of this action mode.</remarks>
		/// <returns>Title text</returns>
		public abstract java.lang.CharSequence getTitle();

		/// <summary>Returns the current subtitle of this action mode.</summary>
		/// <remarks>Returns the current subtitle of this action mode.</remarks>
		/// <returns>Subtitle text</returns>
		public abstract java.lang.CharSequence getSubtitle();

		/// <summary>Returns the current custom view for this action mode.</summary>
		/// <remarks>Returns the current custom view for this action mode.</remarks>
		/// <returns>The current custom view</returns>
		public abstract android.view.View getCustomView();

		/// <summary>
		/// Returns a
		/// <see cref="MenuInflater">MenuInflater</see>
		/// with the ActionMode's context.
		/// </summary>
		public abstract android.view.MenuInflater getMenuInflater();

		/// <summary>Returns whether the UI presenting this action mode can take focus or not.
		/// 	</summary>
		/// <remarks>
		/// Returns whether the UI presenting this action mode can take focus or not.
		/// This is used by internal components within the framework that would otherwise
		/// present an action mode UI that requires focus, such as an EditText as a custom view.
		/// </remarks>
		/// <returns>true if the UI used to show this action mode can take focus</returns>
		/// <hide>Internal use only</hide>
		public virtual bool isUiFocusable()
		{
			return true;
		}

		/// <summary>Callback interface for action modes.</summary>
		/// <remarks>
		/// Callback interface for action modes. Supplied to
		/// <see cref="View.startActionMode(Callback)">View.startActionMode(Callback)</see>
		/// , a Callback
		/// configures and handles events raised by a user's interaction with an action mode.
		/// <p>An action mode's lifecycle is as follows:
		/// <ul>
		/// <li>
		/// <see cref="onCreateActionMode(ActionMode, Menu)">onCreateActionMode(ActionMode, Menu)
		/// 	</see>
		/// once on initial
		/// creation</li>
		/// <li>
		/// <see cref="onPrepareActionMode(ActionMode, Menu)">onPrepareActionMode(ActionMode, Menu)
		/// 	</see>
		/// after creation
		/// and any time the
		/// <see cref="ActionMode">ActionMode</see>
		/// is invalidated</li>
		/// <li>
		/// <see cref="onActionItemClicked(ActionMode, MenuItem)">onActionItemClicked(ActionMode, MenuItem)
		/// 	</see>
		/// any time a
		/// contextual action button is clicked</li>
		/// <li>
		/// <see cref="onDestroyActionMode(ActionMode)">onDestroyActionMode(ActionMode)</see>
		/// when the action mode
		/// is closed</li>
		/// </ul>
		/// </remarks>
		public interface Callback
		{
			/// <summary>Called when action mode is first created.</summary>
			/// <remarks>
			/// Called when action mode is first created. The menu supplied will be used to
			/// generate action buttons for the action mode.
			/// </remarks>
			/// <param name="mode">ActionMode being created</param>
			/// <param name="menu">Menu used to populate action buttons</param>
			/// <returns>
			/// true if the action mode should be created, false if entering this
			/// mode should be aborted.
			/// </returns>
			bool onCreateActionMode(android.view.ActionMode mode, android.view.Menu menu);

			/// <summary>Called to refresh an action mode's action menu whenever it is invalidated.
			/// 	</summary>
			/// <remarks>Called to refresh an action mode's action menu whenever it is invalidated.
			/// 	</remarks>
			/// <param name="mode">ActionMode being prepared</param>
			/// <param name="menu">Menu used to populate action buttons</param>
			/// <returns>true if the menu or action mode was updated, false otherwise.</returns>
			bool onPrepareActionMode(android.view.ActionMode mode, android.view.Menu menu);

			/// <summary>Called to report a user click on an action button.</summary>
			/// <remarks>Called to report a user click on an action button.</remarks>
			/// <param name="mode">The current ActionMode</param>
			/// <param name="item">The item that was clicked</param>
			/// <returns>
			/// true if this callback handled the event, false if the standard MenuItem
			/// invocation should continue.
			/// </returns>
			bool onActionItemClicked(android.view.ActionMode mode, android.view.MenuItem item
				);

			/// <summary>Called when an action mode is about to be exited and destroyed.</summary>
			/// <remarks>Called when an action mode is about to be exited and destroyed.</remarks>
			/// <param name="mode">The current ActionMode being destroyed</param>
			void onDestroyActionMode(android.view.ActionMode mode);
		}
	}
}
