using Sharpen;

namespace android.widget
{
	/// <summary>This class contains the SecurityPermissions view implementation.</summary>
	/// <remarks>
	/// This class contains the SecurityPermissions view implementation.
	/// Initially the package's advanced or dangerous security permissions
	/// are displayed under categorized
	/// groups. Clicking on the additional permissions presents
	/// extended information consisting of all groups and permissions.
	/// To use this view define a LinearLayout or any ViewGroup and add this
	/// view by instantiating AppSecurityPermissions and invoking getPermissionsView.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	public class AppSecurityPermissions : android.view.View.OnClickListener
	{
		private enum State
		{
			NO_PERMS,
			DANGEROUS_ONLY,
			NORMAL_ONLY,
			BOTH
		}

		internal const string TAG = "AppSecurityPermissions";

		private bool localLOGV = false;

		private android.content.Context mContext;

		private android.view.LayoutInflater mInflater;

		private android.content.pm.PackageManager mPm;

		private android.widget.LinearLayout mPermsView;

		private java.util.Map<string, string> mDangerousMap;

		private java.util.Map<string, string> mNormalMap;

		private java.util.List<android.content.pm.PermissionInfo> mPermsList;

		private string mDefaultGrpLabel;

		private string mDefaultGrpName = "DefaultGrp";

		private string mPermFormat;

		private android.graphics.drawable.Drawable mNormalIcon;

		private android.graphics.drawable.Drawable mDangerousIcon;

		private bool mExpanded;

		private android.graphics.drawable.Drawable mShowMaxIcon;

		private android.graphics.drawable.Drawable mShowMinIcon;

		private android.view.View mShowMore;

		private android.widget.TextView mShowMoreText;

		private android.widget.ImageView mShowMoreIcon;

		private android.widget.AppSecurityPermissions.State mCurrentState;

		private android.widget.LinearLayout mNonDangerousList;

		private android.widget.LinearLayout mDangerousList;

		private java.util.HashMap<string, java.lang.CharSequence> mGroupLabelCache;

		private android.view.View mNoPermsView;

		public AppSecurityPermissions(android.content.Context context, java.util.List<android.content.pm.PermissionInfo
			> permList)
		{
			mContext = context;
			mPm = mContext.getPackageManager();
			mPermsList = permList;
		}

		public AppSecurityPermissions(android.content.Context context, string packageName
			)
		{
			mContext = context;
			mPm = mContext.getPackageManager();
			mPermsList = new java.util.ArrayList<android.content.pm.PermissionInfo>();
			java.util.Set<android.content.pm.PermissionInfo> permSet = new java.util.HashSet<
				android.content.pm.PermissionInfo>();
			android.content.pm.PackageInfo pkgInfo;
			try
			{
				pkgInfo = mPm.getPackageInfo(packageName, android.content.pm.PackageManager.GET_PERMISSIONS
					);
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.w(TAG, "Could'nt retrieve permissions for package:" + packageName
					);
				return;
			}
			// Extract all user permissions
			if ((pkgInfo.applicationInfo != null) && (pkgInfo.applicationInfo.uid != -1))
			{
				getAllUsedPermissions(pkgInfo.applicationInfo.uid, permSet);
			}
			foreach (android.content.pm.PermissionInfo tmpInfo in Sharpen.IterableProxy.Create
				(permSet))
			{
				mPermsList.add(tmpInfo);
			}
		}

		public AppSecurityPermissions(android.content.Context context, android.content.pm.PackageParser
			.Package pkg)
		{
			mContext = context;
			mPm = mContext.getPackageManager();
			mPermsList = new java.util.ArrayList<android.content.pm.PermissionInfo>();
			java.util.Set<android.content.pm.PermissionInfo> permSet = new java.util.HashSet<
				android.content.pm.PermissionInfo>();
			if (pkg == null)
			{
				return;
			}
			// Get requested permissions
			if (pkg.requestedPermissions != null)
			{
				java.util.ArrayList<string> strList = pkg.requestedPermissions;
				int size = strList.size();
				if (size > 0)
				{
					extractPerms(strList.toArray(new string[size]), permSet);
				}
			}
			// Get permissions related to  shared user if any
			if (pkg.mSharedUserId != null)
			{
				int sharedUid;
				try
				{
					sharedUid = mPm.getUidForSharedUser(pkg.mSharedUserId);
					getAllUsedPermissions(sharedUid, permSet);
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
					android.util.Log.w(TAG, "Could'nt retrieve shared user id for:" + pkg.packageName
						);
				}
			}
			// Retrieve list of permissions
			foreach (android.content.pm.PermissionInfo tmpInfo in Sharpen.IterableProxy.Create
				(permSet))
			{
				mPermsList.add(tmpInfo);
			}
		}

		/// <summary>Utility to retrieve a view displaying a single permission.</summary>
		/// <remarks>Utility to retrieve a view displaying a single permission.</remarks>
		public static android.view.View getPermissionItemView(android.content.Context context
			, java.lang.CharSequence grpName, java.lang.CharSequence description, bool dangerous
			)
		{
			android.view.LayoutInflater inflater = (android.view.LayoutInflater)context.getSystemService
				(android.content.Context.LAYOUT_INFLATER_SERVICE);
			android.graphics.drawable.Drawable icon = context.getResources().getDrawable(dangerous
				 ? android.@internal.R.drawable.ic_bullet_key_permission : android.@internal.R.drawable
				.ic_text_dot);
			return getPermissionItemView(context, inflater, grpName, description, dangerous, 
				icon);
		}

		private void getAllUsedPermissions(int sharedUid, java.util.Set<android.content.pm.PermissionInfo
			> permSet)
		{
			string[] sharedPkgList = mPm.getPackagesForUid(sharedUid);
			if (sharedPkgList == null || (sharedPkgList.Length == 0))
			{
				return;
			}
			foreach (string sharedPkg in sharedPkgList)
			{
				getPermissionsForPackage(sharedPkg, permSet);
			}
		}

		private void getPermissionsForPackage(string packageName, java.util.Set<android.content.pm.PermissionInfo
			> permSet)
		{
			android.content.pm.PackageInfo pkgInfo;
			try
			{
				pkgInfo = mPm.getPackageInfo(packageName, android.content.pm.PackageManager.GET_PERMISSIONS
					);
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.w(TAG, "Could'nt retrieve permissions for package:" + packageName
					);
				return;
			}
			if ((pkgInfo != null) && (pkgInfo.requestedPermissions != null))
			{
				extractPerms(pkgInfo.requestedPermissions, permSet);
			}
		}

		private void extractPerms(string[] strList, java.util.Set<android.content.pm.PermissionInfo
			> permSet)
		{
			if ((strList == null) || (strList.Length == 0))
			{
				return;
			}
			foreach (string permName in strList)
			{
				try
				{
					android.content.pm.PermissionInfo tmpPermInfo = mPm.getPermissionInfo(permName, 0
						);
					if (tmpPermInfo != null)
					{
						permSet.add(tmpPermInfo);
					}
				}
				catch (android.content.pm.PackageManager.NameNotFoundException)
				{
					android.util.Log.i(TAG, "Ignoring unknown permission:" + permName);
				}
			}
		}

		public virtual int getPermissionCount()
		{
			return mPermsList.size();
		}

		public virtual android.view.View getPermissionsView()
		{
			mInflater = (android.view.LayoutInflater)mContext.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
			mPermsView = (android.widget.LinearLayout)mInflater.inflate(android.@internal.R.layout
				.app_perms_summary, null);
			mShowMore = mPermsView.findViewById(android.@internal.R.id.show_more);
			mShowMoreIcon = (android.widget.ImageView)mShowMore.findViewById(android.@internal.R
				.id.show_more_icon);
			mShowMoreText = (android.widget.TextView)mShowMore.findViewById(android.@internal.R
				.id.show_more_text);
			mDangerousList = (android.widget.LinearLayout)mPermsView.findViewById(android.@internal.R
				.id.dangerous_perms_list);
			mNonDangerousList = (android.widget.LinearLayout)mPermsView.findViewById(android.@internal.R
				.id.non_dangerous_perms_list);
			mNoPermsView = mPermsView.findViewById(android.@internal.R.id.no_permissions);
			// Set up the LinearLayout that acts like a list item.
			mShowMore.setClickable(true);
			mShowMore.setOnClickListener(this);
			mShowMore.setFocusable(true);
			// Pick up from framework resources instead.
			mDefaultGrpLabel = mContext.getString(android.@internal.R.@string.default_permission_group
				);
			mPermFormat = mContext.getString(android.@internal.R.@string.permissions_format);
			mNormalIcon = mContext.getResources().getDrawable(android.@internal.R.drawable.ic_text_dot
				);
			mDangerousIcon = mContext.getResources().getDrawable(android.@internal.R.drawable
				.ic_bullet_key_permission);
			mShowMaxIcon = mContext.getResources().getDrawable(android.@internal.R.drawable.expander_close_holo_dark
				);
			mShowMinIcon = mContext.getResources().getDrawable(android.@internal.R.drawable.expander_open_holo_dark
				);
			// Set permissions view
			setPermissions(mPermsList);
			return mPermsView;
		}

		/// <summary>Canonicalizes the group description before it is displayed to the user.</summary>
		/// <remarks>
		/// Canonicalizes the group description before it is displayed to the user.
		/// TODO check for internationalization issues remove trailing '.' in str1
		/// </remarks>
		private string canonicalizeGroupDesc(string groupDesc)
		{
			if ((groupDesc == null) || (groupDesc.Length == 0))
			{
				return null;
			}
			// Both str1 and str2 are non-null and are non-zero in size.
			int len = groupDesc.Length;
			if (groupDesc[len - 1] == '.')
			{
				groupDesc = Sharpen.StringHelper.Substring(groupDesc, 0, len - 1);
			}
			return groupDesc;
		}

		/// <summary>Utility method that concatenates two strings defined by mPermFormat.</summary>
		/// <remarks>
		/// Utility method that concatenates two strings defined by mPermFormat.
		/// a null value is returned if both str1 and str2 are null, if one of the strings
		/// is null the other non null value is returned without formatting
		/// this is to placate initial error checks
		/// </remarks>
		private string formatPermissions(string groupDesc, java.lang.CharSequence permDesc
			)
		{
			if (groupDesc == null)
			{
				if (permDesc == null)
				{
					return null;
				}
				return permDesc.ToString();
			}
			groupDesc = canonicalizeGroupDesc(groupDesc);
			if (permDesc == null)
			{
				return groupDesc;
			}
			// groupDesc and permDesc are non null
			return string.Format(mPermFormat, groupDesc, permDesc.ToString());
		}

		private java.lang.CharSequence getGroupLabel(string grpName)
		{
			if (grpName == null)
			{
				//return default label
				return java.lang.CharSequenceProxy.Wrap(mDefaultGrpLabel);
			}
			java.lang.CharSequence cachedLabel = mGroupLabelCache.get(grpName);
			if (cachedLabel != null)
			{
				return cachedLabel;
			}
			android.content.pm.PermissionGroupInfo pgi;
			try
			{
				pgi = mPm.getPermissionGroupInfo(grpName, 0);
			}
			catch (android.content.pm.PackageManager.NameNotFoundException)
			{
				android.util.Log.i(TAG, "Invalid group name:" + grpName);
				return null;
			}
			java.lang.CharSequence label = java.lang.CharSequenceProxy.Wrap(pgi.loadLabel(mPm
				).ToString());
			mGroupLabelCache.put(grpName, label);
			return label;
		}

		/// <summary>
		/// Utility method that displays permissions from a map containing group name and
		/// list of permission descriptions.
		/// </summary>
		/// <remarks>
		/// Utility method that displays permissions from a map containing group name and
		/// list of permission descriptions.
		/// </remarks>
		private void displayPermissions(bool dangerous)
		{
			java.util.Map<string, string> permInfoMap = dangerous ? mDangerousMap : mNormalMap;
			android.widget.LinearLayout permListView = dangerous ? mDangerousList : mNonDangerousList;
			permListView.removeAllViews();
			java.util.Set<string> permInfoStrSet = permInfoMap.keySet();
			foreach (string loopPermGrpInfoStr in Sharpen.IterableProxy.Create(permInfoStrSet
				))
			{
				java.lang.CharSequence grpLabel = getGroupLabel(loopPermGrpInfoStr);
				//guaranteed that grpLabel wont be null since permissions without groups
				//will belong to the default group
				if (localLOGV)
				{
					android.util.Log.i(TAG, "Adding view group:" + grpLabel + ", desc:" + permInfoMap
						.get(loopPermGrpInfoStr));
				}
				permListView.addView(getPermissionItemView(grpLabel, java.lang.CharSequenceProxy.Wrap
					(permInfoMap.get(loopPermGrpInfoStr)), dangerous));
			}
		}

		private void displayNoPermissions()
		{
			mNoPermsView.setVisibility(android.view.View.VISIBLE);
		}

		private android.view.View getPermissionItemView(java.lang.CharSequence grpName, java.lang.CharSequence
			 permList, bool dangerous)
		{
			return getPermissionItemView(mContext, mInflater, grpName, permList, dangerous, dangerous
				 ? mDangerousIcon : mNormalIcon);
		}

		private static android.view.View getPermissionItemView(android.content.Context context
			, android.view.LayoutInflater inflater, java.lang.CharSequence grpName, java.lang.CharSequence
			 permList, bool dangerous, android.graphics.drawable.Drawable icon)
		{
			android.view.View permView = inflater.inflate(android.@internal.R.layout.app_permission_item
				, null);
			android.widget.TextView permGrpView = (android.widget.TextView)permView.findViewById
				(android.@internal.R.id.permission_group);
			android.widget.TextView permDescView = (android.widget.TextView)permView.findViewById
				(android.@internal.R.id.permission_list);
			android.widget.ImageView imgView = (android.widget.ImageView)permView.findViewById
				(android.@internal.R.id.perm_icon);
			imgView.setImageDrawable(icon);
			if (grpName != null)
			{
				permGrpView.setText(grpName);
				permDescView.setText(permList);
			}
			else
			{
				permGrpView.setText(permList);
				permDescView.setVisibility(android.view.View.GONE);
			}
			return permView;
		}

		private void showPermissions()
		{
			switch (mCurrentState)
			{
				case android.widget.AppSecurityPermissions.State.NO_PERMS:
				{
					displayNoPermissions();
					break;
				}

				case android.widget.AppSecurityPermissions.State.DANGEROUS_ONLY:
				{
					displayPermissions(true);
					break;
				}

				case android.widget.AppSecurityPermissions.State.NORMAL_ONLY:
				{
					displayPermissions(false);
					break;
				}

				case android.widget.AppSecurityPermissions.State.BOTH:
				{
					displayPermissions(true);
					if (mExpanded)
					{
						displayPermissions(false);
						mShowMoreIcon.setImageDrawable(mShowMaxIcon);
						mShowMoreText.setText(android.@internal.R.@string.perms_hide);
						mNonDangerousList.setVisibility(android.view.View.VISIBLE);
					}
					else
					{
						mShowMoreIcon.setImageDrawable(mShowMinIcon);
						mShowMoreText.setText(android.@internal.R.@string.perms_show_all);
						mNonDangerousList.setVisibility(android.view.View.GONE);
					}
					mShowMore.setVisibility(android.view.View.VISIBLE);
					break;
				}
			}
		}

		private bool isDisplayablePermission(android.content.pm.PermissionInfo pInfo)
		{
			if (pInfo.protectionLevel == android.content.pm.PermissionInfo.PROTECTION_DANGEROUS
				 || pInfo.protectionLevel == android.content.pm.PermissionInfo.PROTECTION_NORMAL)
			{
				return true;
			}
			return false;
		}

		private void aggregateGroupDescs(java.util.Map<string, java.util.List<android.content.pm.PermissionInfo
			>> map, java.util.Map<string, string> retMap)
		{
			if (map == null)
			{
				return;
			}
			if (retMap == null)
			{
				return;
			}
			java.util.Set<string> grpNames = map.keySet();
			java.util.Iterator<string> grpNamesIter = grpNames.iterator();
			while (grpNamesIter.hasNext())
			{
				string grpDesc = null;
				string grpNameKey = grpNamesIter.next();
				java.util.List<android.content.pm.PermissionInfo> grpPermsList = map.get(grpNameKey
					);
				if (grpPermsList == null)
				{
					continue;
				}
				foreach (android.content.pm.PermissionInfo permInfo in Sharpen.IterableProxy.Create
					(grpPermsList))
				{
					java.lang.CharSequence permDesc = permInfo.loadLabel(mPm);
					grpDesc = formatPermissions(grpDesc, permDesc);
				}
				// Insert grpDesc into map
				if (grpDesc != null)
				{
					if (localLOGV)
					{
						android.util.Log.i(TAG, "Group:" + grpNameKey + " description:" + grpDesc.ToString
							());
					}
					retMap.put(grpNameKey, grpDesc.ToString());
				}
			}
		}

		private class PermissionInfoComparator : java.util.Comparator<android.content.pm.PermissionInfo
			>
		{
			internal android.content.pm.PackageManager mPm;

			internal readonly java.text.Collator sCollator = java.text.Collator.getInstance();

			internal PermissionInfoComparator(android.content.pm.PackageManager pm)
			{
				mPm = pm;
			}

			[Sharpen.ImplementsInterface(@"java.util.Comparator")]
			public virtual int compare(android.content.pm.PermissionInfo a, android.content.pm.PermissionInfo
				 b)
			{
				java.lang.CharSequence sa = a.loadLabel(mPm);
				java.lang.CharSequence sb = b.loadLabel(mPm);
				return sCollator.compare(sa, sb);
			}
		}

		private void setPermissions(java.util.List<android.content.pm.PermissionInfo> permList
			)
		{
			mGroupLabelCache = new java.util.HashMap<string, java.lang.CharSequence>();
			//add the default label so that uncategorized permissions can go here
			mGroupLabelCache.put(mDefaultGrpName, java.lang.CharSequenceProxy.Wrap(mDefaultGrpLabel
				));
			// Map containing group names and a list of permissions under that group
			// categorized as dangerous
			mDangerousMap = new java.util.HashMap<string, string>();
			// Map containing group names and a list of permissions under that group
			// categorized as normal
			mNormalMap = new java.util.HashMap<string, string>();
			// Additional structures needed to ensure that permissions are unique under 
			// each group
			java.util.Map<string, java.util.List<android.content.pm.PermissionInfo>> dangerousMap
				 = new java.util.HashMap<string, java.util.List<android.content.pm.PermissionInfo
				>>();
			java.util.Map<string, java.util.List<android.content.pm.PermissionInfo>> normalMap
				 = new java.util.HashMap<string, java.util.List<android.content.pm.PermissionInfo
				>>();
			android.widget.AppSecurityPermissions.PermissionInfoComparator permComparator = new 
				android.widget.AppSecurityPermissions.PermissionInfoComparator(mPm);
			if (permList != null)
			{
				// First pass to group permissions
				foreach (android.content.pm.PermissionInfo pInfo in Sharpen.IterableProxy.Create(
					permList))
				{
					if (localLOGV)
					{
						android.util.Log.i(TAG, "Processing permission:" + pInfo.name);
					}
					if (!isDisplayablePermission(pInfo))
					{
						if (localLOGV)
						{
							android.util.Log.i(TAG, "Permission:" + pInfo.name + " is not displayable");
						}
						continue;
					}
					java.util.Map<string, java.util.List<android.content.pm.PermissionInfo>> permInfoMap
						 = (pInfo.protectionLevel == android.content.pm.PermissionInfo.PROTECTION_DANGEROUS
						) ? dangerousMap : normalMap;
					string grpName = (pInfo.group == null) ? mDefaultGrpName : pInfo.group;
					if (localLOGV)
					{
						android.util.Log.i(TAG, "Permission:" + pInfo.name + " belongs to group:" + grpName
							);
					}
					java.util.List<android.content.pm.PermissionInfo> grpPermsList = permInfoMap.get(
						grpName);
					if (grpPermsList == null)
					{
						grpPermsList = new java.util.ArrayList<android.content.pm.PermissionInfo>();
						permInfoMap.put(grpName, grpPermsList);
						grpPermsList.add(pInfo);
					}
					else
					{
						int idx = java.util.Collections.binarySearch(grpPermsList, pInfo, permComparator);
						if (localLOGV)
						{
							android.util.Log.i(TAG, "idx=" + idx + ", list.size=" + grpPermsList.size());
						}
						if (idx < 0)
						{
							idx = -idx - 1;
							grpPermsList.add(idx, pInfo);
						}
					}
				}
				// Second pass to actually form the descriptions
				// Look at dangerous permissions first
				aggregateGroupDescs(dangerousMap, mDangerousMap);
				aggregateGroupDescs(normalMap, mNormalMap);
			}
			mCurrentState = android.widget.AppSecurityPermissions.State.NO_PERMS;
			if (mDangerousMap.size() > 0)
			{
				mCurrentState = (mNormalMap.size() > 0) ? android.widget.AppSecurityPermissions.State
					.BOTH : android.widget.AppSecurityPermissions.State.DANGEROUS_ONLY;
			}
			else
			{
				if (mNormalMap.size() > 0)
				{
					mCurrentState = android.widget.AppSecurityPermissions.State.NORMAL_ONLY;
				}
			}
			if (localLOGV)
			{
				android.util.Log.i(TAG, "mCurrentState=" + mCurrentState);
			}
			showPermissions();
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			if (localLOGV)
			{
				android.util.Log.i(TAG, "mExpanded=" + mExpanded);
			}
			mExpanded = !mExpanded;
			showPermissions();
		}
	}
}
