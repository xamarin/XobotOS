using Sharpen;

namespace android.widget
{
	/// <summary>This is a provider for a share action.</summary>
	/// <remarks>
	/// This is a provider for a share action. It is responsible for creating views
	/// that enable data sharing and also to show a sub menu with sharing activities
	/// if the hosting item is placed on the overflow menu.
	/// <p>
	/// Here is how to use the action provider with custom backing file in a
	/// <see cref="android.view.MenuItem">android.view.MenuItem</see>
	/// :
	/// </p>
	/// <p>
	/// <pre>
	/// <code>
	/// // In Activity#onCreateOptionsMenu
	/// public boolean onCreateOptionsMenu(Menu menu) {
	/// // Get the menu item.
	/// MenuItem menuItem = menu.findItem(R.id.my_menu_item);
	/// // Get the provider and hold onto it to set/change the share intent.
	/// mShareActionProvider = (ShareActionProvider) menuItem.getActionProvider();
	/// // Set history different from the default before getting the action
	/// // view since a call to
	/// <see cref="android.view.MenuItem.getActionView()">MenuItem.getActionView()</see>
	/// calls
	/// //
	/// <see cref="android.view.ActionProvider.onCreateActionView()">android.view.ActionProvider.onCreateActionView()
	/// 	</see>
	/// which uses the backing file name. Omit this
	/// // line if using the default share history file is desired.
	/// mShareActionProvider.setShareHistoryFileName("custom_share_history.xml");
	/// . . .
	/// }
	/// // Somewhere in the application.
	/// public void doShare(Intent shareIntent) {
	/// // When you want to share set the share intent.
	/// mShareActionProvider.setShareIntent(shareIntent);
	/// }
	/// </pre>
	/// </code>
	/// </p>
	/// <p>
	/// <strong>Note:</strong> While the sample snippet demonstrates how to use this provider
	/// in the context of a menu item, the use of the provider is not limited to menu items.
	/// </p>
	/// </remarks>
	/// <seealso cref="android.view.ActionProvider">android.view.ActionProvider</seealso>
	[Sharpen.Sharpened]
	public class ShareActionProvider : android.view.ActionProvider
	{
		/// <summary>Listener for the event of selecting a share target.</summary>
		/// <remarks>Listener for the event of selecting a share target.</remarks>
		public interface OnShareTargetSelectedListener
		{
			/// <summary>Called when a share target has been selected.</summary>
			/// <remarks>
			/// Called when a share target has been selected. The client can
			/// decide whether to handle the intent or rely on the default
			/// behavior which is launching it.
			/// <p>
			/// <strong>Note:</strong> Modifying the intent is not permitted and
			/// any changes to the latter will be ignored.
			/// </p>
			/// </remarks>
			/// <param name="source">The source of the notification.</param>
			/// <param name="intent">The intent for launching the chosen share target.</param>
			/// <returns>Whether the client has handled the intent.</returns>
			bool onShareTargetSelected(android.widget.ShareActionProvider source, android.content.Intent
				 intent);
		}

		/// <summary>The default for the maximal number of activities shown in the sub-menu.</summary>
		/// <remarks>The default for the maximal number of activities shown in the sub-menu.</remarks>
		internal const int DEFAULT_INITIAL_ACTIVITY_COUNT = 4;

		/// <summary>The the maximum number activities shown in the sub-menu.</summary>
		/// <remarks>The the maximum number activities shown in the sub-menu.</remarks>
		private int mMaxShownActivityCount = DEFAULT_INITIAL_ACTIVITY_COUNT;

		/// <summary>Listener for handling menu item clicks.</summary>
		/// <remarks>Listener for handling menu item clicks.</remarks>
		private readonly android.widget.ShareActionProvider.ShareMenuItemOnMenuItemClickListener
			 mOnMenuItemClickListener;

		/// <summary>The default name for storing share history.</summary>
		/// <remarks>The default name for storing share history.</remarks>
		public const string DEFAULT_SHARE_HISTORY_FILE_NAME = "share_history.xml";

		/// <summary>Context for accessing resources.</summary>
		/// <remarks>Context for accessing resources.</remarks>
		private readonly android.content.Context mContext;

		/// <summary>The name of the file with share history data.</summary>
		/// <remarks>The name of the file with share history data.</remarks>
		private string mShareHistoryFileName = DEFAULT_SHARE_HISTORY_FILE_NAME;

		private android.widget.ShareActionProvider.OnShareTargetSelectedListener mOnShareTargetSelectedListener;

		private android.widget.ActivityChooserModel.OnChooseActivityListener mOnChooseActivityListener;

		/// <summary>Creates a new instance.</summary>
		/// <remarks>Creates a new instance.</remarks>
		/// <param name="context">Context for accessing resources.</param>
		public ShareActionProvider(android.content.Context context) : base(context)
		{
			mOnMenuItemClickListener = new android.widget.ShareActionProvider.ShareMenuItemOnMenuItemClickListener
				(this);
			mContext = context;
		}

		/// <summary>Sets a listener to be notified when a share target has been selected.</summary>
		/// <remarks>
		/// Sets a listener to be notified when a share target has been selected.
		/// The listener can optionally decide to handle the selection and
		/// not rely on the default behavior which is to launch the activity.
		/// <p>
		/// <strong>Note:</strong> If you choose the backing share history file
		/// you will still be notified in this callback.
		/// </p>
		/// </remarks>
		/// <param name="listener">The listener.</param>
		public virtual void setOnShareTargetSelectedListener(android.widget.ShareActionProvider
			.OnShareTargetSelectedListener listener)
		{
			mOnShareTargetSelectedListener = listener;
			setActivityChooserPolicyIfNeeded();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ActionProvider")]
		public override android.view.View onCreateActionView()
		{
			// Create the view and set its data model.
			android.widget.ActivityChooserModel dataModel = android.widget.ActivityChooserModel
				.get(mContext, mShareHistoryFileName);
			android.widget.ActivityChooserView activityChooserView = new android.widget.ActivityChooserView
				(mContext);
			activityChooserView.setActivityChooserModel(dataModel);
			// Lookup and set the expand action icon.
			android.util.TypedValue outTypedValue = new android.util.TypedValue();
			mContext.getTheme().resolveAttribute(android.@internal.R.attr.actionModeShareDrawable
				, outTypedValue, true);
			android.graphics.drawable.Drawable drawable = mContext.getResources().getDrawable
				(outTypedValue.resourceId);
			activityChooserView.setExpandActivityOverflowButtonDrawable(drawable);
			activityChooserView.setProvider(this);
			// Set content description.
			activityChooserView.setDefaultActionButtonContentDescription(android.@internal.R.
				@string.shareactionprovider_share_with_application);
			activityChooserView.setExpandActivityOverflowButtonContentDescription(android.@internal.R
				.@string.shareactionprovider_share_with);
			return activityChooserView;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ActionProvider")]
		public override bool hasSubMenu()
		{
			return true;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.view.ActionProvider")]
		public override void onPrepareSubMenu(android.view.SubMenu subMenu)
		{
			// Clear since the order of items may change.
			subMenu.clear();
			android.widget.ActivityChooserModel dataModel = android.widget.ActivityChooserModel
				.get(mContext, mShareHistoryFileName);
			android.content.pm.PackageManager packageManager = mContext.getPackageManager();
			int expandedActivityCount = dataModel.getActivityCount();
			int collapsedActivityCount = System.Math.Min(expandedActivityCount, mMaxShownActivityCount
				);
			{
				// Populate the sub-menu with a sub set of the activities.
				for (int i = 0; i < collapsedActivityCount; i++)
				{
					android.content.pm.ResolveInfo activity = dataModel.getActivity(i);
					subMenu.add(0, i, i, activity.loadLabel(packageManager)).setIcon(activity.loadIcon
						(packageManager)).setOnMenuItemClickListener(mOnMenuItemClickListener);
				}
			}
			if (collapsedActivityCount < expandedActivityCount)
			{
				// Add a sub-menu for showing all activities as a list item.
				android.view.SubMenu expandedSubMenu = subMenu.addSubMenu(android.view.MenuClass.NONE
					, collapsedActivityCount, collapsedActivityCount, java.lang.CharSequenceProxy.Wrap
					(mContext.getString(android.@internal.R.@string.activity_chooser_view_see_all)));
				{
					for (int i_1 = 0; i_1 < expandedActivityCount; i_1++)
					{
						android.content.pm.ResolveInfo activity = dataModel.getActivity(i_1);
						expandedSubMenu.add(0, i_1, i_1, activity.loadLabel(packageManager)).setIcon(activity
							.loadIcon(packageManager)).setOnMenuItemClickListener(mOnMenuItemClickListener);
					}
				}
			}
		}

		/// <summary>
		/// Sets the file name of a file for persisting the share history which
		/// history will be used for ordering share targets.
		/// </summary>
		/// <remarks>
		/// Sets the file name of a file for persisting the share history which
		/// history will be used for ordering share targets. This file will be used
		/// for all view created by
		/// <see cref="onCreateActionView()">onCreateActionView()</see>
		/// . Defaults to
		/// <see cref="DEFAULT_SHARE_HISTORY_FILE_NAME">DEFAULT_SHARE_HISTORY_FILE_NAME</see>
		/// . Set to <code>null</code>
		/// if share history should not be persisted between sessions.
		/// <p>
		/// <strong>Note:</strong> The history file name can be set any time, however
		/// only the action views created by
		/// <see cref="onCreateActionView()">onCreateActionView()</see>
		/// after setting
		/// the file name will be backed by the provided file.
		/// <p>
		/// </remarks>
		/// <param name="shareHistoryFile">The share history file name.</param>
		public virtual void setShareHistoryFileName(string shareHistoryFile)
		{
			mShareHistoryFileName = shareHistoryFile;
			setActivityChooserPolicyIfNeeded();
		}

		/// <summary>Sets an intent with information about the share action.</summary>
		/// <remarks>
		/// Sets an intent with information about the share action. Here is a
		/// sample for constructing a share intent:
		/// <p>
		/// <pre>
		/// <code>
		/// Intent shareIntent = new Intent(Intent.ACTION_SEND);
		/// shareIntent.setType("image/*");
		/// Uri uri = Uri.fromFile(new File(getFilesDir(), "foo.jpg"));
		/// shareIntent.putExtra(Intent.EXTRA_STREAM, uri.toString());
		/// </pre>
		/// </code>
		/// </p>
		/// </remarks>
		/// <param name="shareIntent">The share intent.</param>
		/// <seealso cref="android.content.Intent.ACTION_SEND">android.content.Intent.ACTION_SEND
		/// 	</seealso>
		/// <seealso cref="android.content.Intent.ACTION_SEND_MULTIPLE">android.content.Intent.ACTION_SEND_MULTIPLE
		/// 	</seealso>
		public virtual void setShareIntent(android.content.Intent shareIntent)
		{
			android.widget.ActivityChooserModel dataModel = android.widget.ActivityChooserModel
				.get(mContext, mShareHistoryFileName);
			dataModel.setIntent(shareIntent);
		}

		/// <summary>Reusable listener for handling share item clicks.</summary>
		/// <remarks>Reusable listener for handling share item clicks.</remarks>
		private class ShareMenuItemOnMenuItemClickListener : android.view.MenuItemClass.OnMenuItemClickListener
		{
			[Sharpen.ImplementsInterface(@"android.view.MenuItem.OnMenuItemClickListener")]
			public virtual bool onMenuItemClick(android.view.MenuItem item)
			{
				android.widget.ActivityChooserModel dataModel = android.widget.ActivityChooserModel
					.get(this._enclosing.mContext, this._enclosing.mShareHistoryFileName);
				int itemId = item.getItemId();
				android.content.Intent launchIntent = dataModel.chooseActivity(itemId);
				if (launchIntent != null)
				{
					this._enclosing.mContext.startActivity(launchIntent);
				}
				return true;
			}

			internal ShareMenuItemOnMenuItemClickListener(ShareActionProvider _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ShareActionProvider _enclosing;
		}

		/// <summary>
		/// Set the activity chooser policy of the model backed by the current
		/// share history file if needed which is if there is a registered callback.
		/// </summary>
		/// <remarks>
		/// Set the activity chooser policy of the model backed by the current
		/// share history file if needed which is if there is a registered callback.
		/// </remarks>
		private void setActivityChooserPolicyIfNeeded()
		{
			if (mOnShareTargetSelectedListener == null)
			{
				return;
			}
			if (mOnChooseActivityListener == null)
			{
				mOnChooseActivityListener = new android.widget.ShareActionProvider.ShareAcitivityChooserModelPolicy
					(this);
			}
			android.widget.ActivityChooserModel dataModel = android.widget.ActivityChooserModel
				.get(mContext, mShareHistoryFileName);
			dataModel.setOnChooseActivityListener(mOnChooseActivityListener);
		}

		/// <summary>
		/// Policy that delegates to the
		/// <see cref="OnShareTargetSelectedListener">OnShareTargetSelectedListener</see>
		/// , if such.
		/// </summary>
		private class ShareAcitivityChooserModelPolicy : android.widget.ActivityChooserModel
			.OnChooseActivityListener
		{
			[Sharpen.ImplementsInterface(@"android.widget.ActivityChooserModel.OnChooseActivityListener"
				)]
			public virtual bool onChooseActivity(android.widget.ActivityChooserModel host, android.content.Intent
				 intent)
			{
				if (this._enclosing.mOnShareTargetSelectedListener != null)
				{
					return this._enclosing.mOnShareTargetSelectedListener.onShareTargetSelected(this.
						_enclosing, intent);
				}
				return false;
			}

			internal ShareAcitivityChooserModelPolicy(ShareActionProvider _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ShareActionProvider _enclosing;
		}
	}
}
