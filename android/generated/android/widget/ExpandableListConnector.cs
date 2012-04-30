using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A
	/// <see cref="BaseAdapter">BaseAdapter</see>
	/// that provides data/Views in an expandable list (offers
	/// features such as collapsing/expanding groups containing children). By
	/// itself, this adapter has no data and is a connector to a
	/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
	/// which provides the data.
	/// <p>
	/// Internally, this connector translates the flat list position that the
	/// ListAdapter expects to/from group and child positions that the ExpandableListAdapter
	/// expects.
	/// </summary>
	[Sharpen.Sharpened]
	internal class ExpandableListConnector : android.widget.BaseAdapter, android.widget.Filterable
	{
		/// <summary>The ExpandableListAdapter to fetch the data/Views for this expandable list
		/// 	</summary>
		private android.widget.ExpandableListAdapter mExpandableListAdapter;

		/// <summary>List of metadata for the currently expanded groups.</summary>
		/// <remarks>
		/// List of metadata for the currently expanded groups. The metadata consists
		/// of data essential for efficiently translating between flat list positions
		/// and group/child positions. See
		/// <see cref="GroupMetadata">GroupMetadata</see>
		/// .
		/// </remarks>
		private java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata>
			 mExpGroupMetadataList;

		/// <summary>The number of children from all currently expanded groups</summary>
		private int mTotalExpChildrenCount;

		/// <summary>The maximum number of allowable expanded groups.</summary>
		/// <remarks>The maximum number of allowable expanded groups. Defaults to 'no limit'</remarks>
		private int mMaxExpGroupCount = int.MaxValue;

		/// <summary>Change observer used to have ExpandableListAdapter changes pushed to us</summary>
		private readonly android.database.DataSetObserver mDataSetObserver;

		/// <summary>Constructs the connector</summary>
		public ExpandableListConnector(android.widget.ExpandableListAdapter expandableListAdapter
			)
		{
			mDataSetObserver = new android.widget.ExpandableListConnector.MyDataSetObserver(this
				);
			mExpGroupMetadataList = new java.util.ArrayList<android.widget.ExpandableListConnector
				.GroupMetadata>();
			setExpandableListAdapter(expandableListAdapter);
		}

		/// <summary>
		/// Point to the
		/// <see cref="ExpandableListAdapter">ExpandableListAdapter</see>
		/// that will give us data/Views
		/// </summary>
		/// <param name="expandableListAdapter">the adapter that supplies us with data/Views</param>
		public virtual void setExpandableListAdapter(android.widget.ExpandableListAdapter
			 expandableListAdapter)
		{
			if (mExpandableListAdapter != null)
			{
				mExpandableListAdapter.unregisterDataSetObserver(mDataSetObserver);
			}
			mExpandableListAdapter = expandableListAdapter;
			expandableListAdapter.registerDataSetObserver(mDataSetObserver);
		}

		/// <summary>
		/// Translates a flat list position to either a) group pos if the specified
		/// flat list position corresponds to a group, or b) child pos if it
		/// corresponds to a child.
		/// </summary>
		/// <remarks>
		/// Translates a flat list position to either a) group pos if the specified
		/// flat list position corresponds to a group, or b) child pos if it
		/// corresponds to a child.  Performs a binary search on the expanded
		/// groups list to find the flat list pos if it is an exp group, otherwise
		/// finds where the flat list pos fits in between the exp groups.
		/// </remarks>
		/// <param name="flPos">the flat list position to be translated</param>
		/// <returns>
		/// the group position or child position of the specified flat list
		/// position encompassed in a
		/// <see cref="PositionMetadata">PositionMetadata</see>
		/// object
		/// that contains additional useful info for insertion, etc.
		/// </returns>
		internal virtual android.widget.ExpandableListConnector.PositionMetadata getUnflattenedPos
			(int flPos)
		{
			java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata> egml = 
				mExpGroupMetadataList;
			int numExpGroups = egml.size();
			int leftExpGroupIndex = 0;
			int rightExpGroupIndex = numExpGroups - 1;
			int midExpGroupIndex = 0;
			android.widget.ExpandableListConnector.GroupMetadata midExpGm;
			if (numExpGroups == 0)
			{
				return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, android.widget.ExpandableListPosition
					.GROUP, flPos, -1, null, 0);
			}
			while (leftExpGroupIndex <= rightExpGroupIndex)
			{
				midExpGroupIndex = (rightExpGroupIndex - leftExpGroupIndex) / 2 + leftExpGroupIndex;
				midExpGm = egml.get(midExpGroupIndex);
				if (flPos > midExpGm.lastChildFlPos)
				{
					leftExpGroupIndex = midExpGroupIndex + 1;
				}
				else
				{
					if (flPos < midExpGm.flPos)
					{
						rightExpGroupIndex = midExpGroupIndex - 1;
					}
					else
					{
						if (flPos == midExpGm.flPos)
						{
							return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, android.widget.ExpandableListPosition
								.GROUP, midExpGm.gPos, -1, midExpGm, midExpGroupIndex);
						}
						else
						{
							if (flPos <= midExpGm.lastChildFlPos)
							{
								int childPos = flPos - (midExpGm.flPos + 1);
								return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, android.widget.ExpandableListPosition
									.CHILD, midExpGm.gPos, childPos, midExpGm, midExpGroupIndex);
							}
						}
					}
				}
			}
			int insertPosition = 0;
			int groupPos = 0;
			if (leftExpGroupIndex > midExpGroupIndex)
			{
				android.widget.ExpandableListConnector.GroupMetadata leftExpGm = egml.get(leftExpGroupIndex
					 - 1);
				insertPosition = leftExpGroupIndex;
				groupPos = (flPos - leftExpGm.lastChildFlPos) + leftExpGm.gPos;
			}
			else
			{
				if (rightExpGroupIndex < midExpGroupIndex)
				{
					android.widget.ExpandableListConnector.GroupMetadata rightExpGm = egml.get(++rightExpGroupIndex
						);
					insertPosition = rightExpGroupIndex;
					groupPos = rightExpGm.gPos - (rightExpGm.flPos - flPos);
				}
				else
				{
					// TODO: clean exit
					throw new java.lang.RuntimeException("Unknown state");
				}
			}
			return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, android.widget.ExpandableListPosition
				.GROUP, groupPos, -1, null, insertPosition);
		}

		/// <summary>
		/// Translates either a group pos or a child pos (+ group it belongs to) to a
		/// flat list position.
		/// </summary>
		/// <remarks>
		/// Translates either a group pos or a child pos (+ group it belongs to) to a
		/// flat list position.  If searching for a child and its group is not expanded, this will
		/// return null since the child isn't being shown in the ListView, and hence it has no
		/// position.
		/// </remarks>
		/// <param name="pos">
		/// a
		/// <see cref="ExpandableListPosition">ExpandableListPosition</see>
		/// representing either a group position
		/// or child position
		/// </param>
		/// <returns>
		/// the flat list position encompassed in a
		/// <see cref="PositionMetadata">PositionMetadata</see>
		/// object that contains additional useful info for insertion, etc., or null.
		/// </returns>
		internal virtual android.widget.ExpandableListConnector.PositionMetadata getFlattenedPos
			(android.widget.ExpandableListPosition pos)
		{
			java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata> egml = 
				mExpGroupMetadataList;
			int numExpGroups = egml.size();
			int leftExpGroupIndex = 0;
			int rightExpGroupIndex = numExpGroups - 1;
			int midExpGroupIndex = 0;
			android.widget.ExpandableListConnector.GroupMetadata midExpGm;
			if (numExpGroups == 0)
			{
				return android.widget.ExpandableListConnector.PositionMetadata.obtain(pos.groupPos
					, pos.type, pos.groupPos, pos.childPos, null, 0);
			}
			while (leftExpGroupIndex <= rightExpGroupIndex)
			{
				midExpGroupIndex = (rightExpGroupIndex - leftExpGroupIndex) / 2 + leftExpGroupIndex;
				midExpGm = egml.get(midExpGroupIndex);
				if (pos.groupPos > midExpGm.gPos)
				{
					leftExpGroupIndex = midExpGroupIndex + 1;
				}
				else
				{
					if (pos.groupPos < midExpGm.gPos)
					{
						rightExpGroupIndex = midExpGroupIndex - 1;
					}
					else
					{
						if (pos.groupPos == midExpGm.gPos)
						{
							if (pos.type == android.widget.ExpandableListPosition.GROUP)
							{
								return android.widget.ExpandableListConnector.PositionMetadata.obtain(midExpGm.flPos
									, pos.type, pos.groupPos, pos.childPos, midExpGm, midExpGroupIndex);
							}
							else
							{
								if (pos.type == android.widget.ExpandableListPosition.CHILD)
								{
									return android.widget.ExpandableListConnector.PositionMetadata.obtain(midExpGm.flPos
										 + pos.childPos + 1, pos.type, pos.groupPos, pos.childPos, midExpGm, midExpGroupIndex
										);
								}
								else
								{
									return null;
								}
							}
						}
					}
				}
			}
			if (pos.type != android.widget.ExpandableListPosition.GROUP)
			{
				return null;
			}
			if (leftExpGroupIndex > midExpGroupIndex)
			{
				android.widget.ExpandableListConnector.GroupMetadata leftExpGm = egml.get(leftExpGroupIndex
					 - 1);
				int flPos = leftExpGm.lastChildFlPos + (pos.groupPos - leftExpGm.gPos);
				return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, pos.
					type, pos.groupPos, pos.childPos, null, leftExpGroupIndex);
			}
			else
			{
				if (rightExpGroupIndex < midExpGroupIndex)
				{
					android.widget.ExpandableListConnector.GroupMetadata rightExpGm = egml.get(++rightExpGroupIndex
						);
					int flPos = rightExpGm.flPos - (rightExpGm.gPos - pos.groupPos);
					return android.widget.ExpandableListConnector.PositionMetadata.obtain(flPos, pos.
						type, pos.groupPos, pos.childPos, null, rightExpGroupIndex);
				}
				else
				{
					return null;
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool areAllItemsEnabled()
		{
			return mExpandableListAdapter.areAllItemsEnabled();
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool isEnabled(int flatListPos)
		{
			android.widget.ExpandableListPosition pos = getUnflattenedPos(flatListPos).position;
			bool retValue;
			if (pos.type == android.widget.ExpandableListPosition.CHILD)
			{
				retValue = mExpandableListAdapter.isChildSelectable(pos.groupPos, pos.childPos);
			}
			else
			{
				// Groups are always selectable
				retValue = true;
			}
			pos.recycle();
			return retValue;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override int getCount()
		{
			return mExpandableListAdapter.getGroupCount() + mTotalExpChildrenCount;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override object getItem(int flatListPos)
		{
			android.widget.ExpandableListConnector.PositionMetadata posMetadata = getUnflattenedPos
				(flatListPos);
			object retValue;
			if (posMetadata.position.type == android.widget.ExpandableListPosition.GROUP)
			{
				retValue = mExpandableListAdapter.getGroup(posMetadata.position.groupPos);
			}
			else
			{
				if (posMetadata.position.type == android.widget.ExpandableListPosition.CHILD)
				{
					retValue = mExpandableListAdapter.getChild(posMetadata.position.groupPos, posMetadata
						.position.childPos);
				}
				else
				{
					// TODO: clean exit
					throw new java.lang.RuntimeException("Flat list position is of unknown type");
				}
			}
			posMetadata.recycle();
			return retValue;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override long getItemId(int flatListPos)
		{
			android.widget.ExpandableListConnector.PositionMetadata posMetadata = getUnflattenedPos
				(flatListPos);
			long groupId = mExpandableListAdapter.getGroupId(posMetadata.position.groupPos);
			long retValue;
			if (posMetadata.position.type == android.widget.ExpandableListPosition.GROUP)
			{
				retValue = mExpandableListAdapter.getCombinedGroupId(groupId);
			}
			else
			{
				if (posMetadata.position.type == android.widget.ExpandableListPosition.CHILD)
				{
					long childId = mExpandableListAdapter.getChildId(posMetadata.position.groupPos, posMetadata
						.position.childPos);
					retValue = mExpandableListAdapter.getCombinedChildId(groupId, childId);
				}
				else
				{
					// TODO: clean exit
					throw new java.lang.RuntimeException("Flat list position is of unknown type");
				}
			}
			posMetadata.recycle();
			return retValue;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int flatListPos, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			android.widget.ExpandableListConnector.PositionMetadata posMetadata = getUnflattenedPos
				(flatListPos);
			android.view.View retValue;
			if (posMetadata.position.type == android.widget.ExpandableListPosition.GROUP)
			{
				retValue = mExpandableListAdapter.getGroupView(posMetadata.position.groupPos, posMetadata
					.isExpanded(), convertView, parent);
			}
			else
			{
				if (posMetadata.position.type == android.widget.ExpandableListPosition.CHILD)
				{
					bool isLastChild = posMetadata.groupMetadata.lastChildFlPos == flatListPos;
					retValue = mExpandableListAdapter.getChildView(posMetadata.position.groupPos, posMetadata
						.position.childPos, isLastChild, convertView, parent);
				}
				else
				{
					// TODO: clean exit
					throw new java.lang.RuntimeException("Flat list position is of unknown type");
				}
			}
			posMetadata.recycle();
			return retValue;
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override int getItemViewType(int flatListPos)
		{
			android.widget.ExpandableListPosition pos = getUnflattenedPos(flatListPos).position;
			int retValue;
			if (mExpandableListAdapter is android.widget.HeterogeneousExpandableList)
			{
				android.widget.HeterogeneousExpandableList adapter = (android.widget.HeterogeneousExpandableList
					)mExpandableListAdapter;
				if (pos.type == android.widget.ExpandableListPosition.GROUP)
				{
					retValue = adapter.getGroupType(pos.groupPos);
				}
				else
				{
					int childType = adapter.getChildType(pos.groupPos, pos.childPos);
					retValue = adapter.getGroupTypeCount() + childType;
				}
			}
			else
			{
				if (pos.type == android.widget.ExpandableListPosition.GROUP)
				{
					retValue = 0;
				}
				else
				{
					retValue = 1;
				}
			}
			pos.recycle();
			return retValue;
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override int getViewTypeCount()
		{
			if (mExpandableListAdapter is android.widget.HeterogeneousExpandableList)
			{
				android.widget.HeterogeneousExpandableList adapter = (android.widget.HeterogeneousExpandableList
					)mExpandableListAdapter;
				return adapter.getGroupTypeCount() + adapter.getChildTypeCount();
			}
			else
			{
				return 2;
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool hasStableIds()
		{
			return mExpandableListAdapter.hasStableIds();
		}

		/// <summary>
		/// Traverses the expanded group metadata list and fills in the flat list
		/// positions.
		/// </summary>
		/// <remarks>
		/// Traverses the expanded group metadata list and fills in the flat list
		/// positions.
		/// </remarks>
		/// <param name="forceChildrenCountRefresh">
		/// Forces refreshing of the children count
		/// for all expanded groups.
		/// </param>
		/// <param name="syncGroupPositions">
		/// Whether to search for the group positions
		/// based on the group IDs. This should only be needed when calling
		/// this from an onChanged callback.
		/// </param>
		private void refreshExpGroupMetadataList(bool forceChildrenCountRefresh, bool syncGroupPositions
			)
		{
			java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata> egml = 
				mExpGroupMetadataList;
			int egmlSize = egml.size();
			int curFlPos = 0;
			mTotalExpChildrenCount = 0;
			if (syncGroupPositions)
			{
				// We need to check whether any groups have moved positions
				bool positionsChanged = false;
				{
					for (int i = egmlSize - 1; i >= 0; i--)
					{
						android.widget.ExpandableListConnector.GroupMetadata curGm = egml.get(i);
						int newGPos = findGroupPosition(curGm.gId, curGm.gPos);
						if (newGPos != curGm.gPos)
						{
							if (newGPos == android.widget.AdapterView.INVALID_POSITION)
							{
								// Doh, just remove it from the list of expanded groups
								egml.remove(i);
								egmlSize--;
							}
							curGm.gPos = newGPos;
							if (!positionsChanged)
							{
								positionsChanged = true;
							}
						}
					}
				}
				if (positionsChanged)
				{
					// At least one group changed positions, so re-sort
					java.util.Collections.sort(egml);
				}
			}
			int gChildrenCount;
			int lastGPos = 0;
			{
				for (int i_1 = 0; i_1 < egmlSize; i_1++)
				{
					android.widget.ExpandableListConnector.GroupMetadata curGm = egml.get(i_1);
					if ((curGm.lastChildFlPos == android.widget.ExpandableListConnector.GroupMetadata
						.REFRESH) || forceChildrenCountRefresh)
					{
						gChildrenCount = mExpandableListAdapter.getChildrenCount(curGm.gPos);
					}
					else
					{
						gChildrenCount = curGm.lastChildFlPos - curGm.flPos;
					}
					mTotalExpChildrenCount += gChildrenCount;
					curFlPos += (curGm.gPos - lastGPos);
					lastGPos = curGm.gPos;
					curGm.flPos = curFlPos;
					curFlPos += gChildrenCount;
					curGm.lastChildFlPos = curFlPos;
				}
			}
		}

		/// <summary>Collapse a group in the grouped list view</summary>
		/// <param name="groupPos">position of the group to collapse</param>
		internal virtual bool collapseGroup(int groupPos)
		{
			android.widget.ExpandableListConnector.PositionMetadata pm = getFlattenedPos(android.widget.ExpandableListPosition
				.obtain(android.widget.ExpandableListPosition.GROUP, groupPos, -1, -1));
			if (pm == null)
			{
				return false;
			}
			bool retValue = collapseGroup(pm);
			pm.recycle();
			return retValue;
		}

		internal virtual bool collapseGroup(android.widget.ExpandableListConnector.PositionMetadata
			 posMetadata)
		{
			if (posMetadata.groupMetadata == null)
			{
				return false;
			}
			// Remove the group from the list of expanded groups 
			mExpGroupMetadataList.remove(posMetadata.groupMetadata);
			// Refresh the metadata
			refreshExpGroupMetadataList(false, false);
			// Notify of change
			notifyDataSetChanged();
			// Give the callback
			mExpandableListAdapter.onGroupCollapsed(posMetadata.groupMetadata.gPos);
			return true;
		}

		/// <summary>Expand a group in the grouped list view</summary>
		/// <param name="groupPos">the group to be expanded</param>
		internal virtual bool expandGroup(int groupPos)
		{
			android.widget.ExpandableListConnector.PositionMetadata pm = getFlattenedPos(android.widget.ExpandableListPosition
				.obtain(android.widget.ExpandableListPosition.GROUP, groupPos, -1, -1));
			bool retValue = expandGroup(pm);
			pm.recycle();
			return retValue;
		}

		internal virtual bool expandGroup(android.widget.ExpandableListConnector.PositionMetadata
			 posMetadata)
		{
			if (posMetadata.position.groupPos < 0)
			{
				// TODO clean exit
				throw new java.lang.RuntimeException("Need group");
			}
			if (mMaxExpGroupCount == 0)
			{
				return false;
			}
			// Check to see if it's already expanded
			if (posMetadata.groupMetadata != null)
			{
				return false;
			}
			if (mExpGroupMetadataList.size() >= mMaxExpGroupCount)
			{
				// TODO: Collapse something not on the screen instead of the first one?
				// TODO: Could write overloaded function to take GroupMetadata to collapse
				android.widget.ExpandableListConnector.GroupMetadata collapsedGm = mExpGroupMetadataList
					.get(0);
				int collapsedIndex = mExpGroupMetadataList.indexOf(collapsedGm);
				collapseGroup(collapsedGm.gPos);
				if (posMetadata.groupInsertIndex > collapsedIndex)
				{
					posMetadata.groupInsertIndex--;
				}
			}
			android.widget.ExpandableListConnector.GroupMetadata expandedGm = android.widget.ExpandableListConnector
				.GroupMetadata.obtain(android.widget.ExpandableListConnector.GroupMetadata.REFRESH
				, android.widget.ExpandableListConnector.GroupMetadata.REFRESH, posMetadata.position
				.groupPos, mExpandableListAdapter.getGroupId(posMetadata.position.groupPos));
			mExpGroupMetadataList.add(posMetadata.groupInsertIndex, expandedGm);
			// Refresh the metadata
			refreshExpGroupMetadataList(false, false);
			// Notify of change
			notifyDataSetChanged();
			// Give the callback
			mExpandableListAdapter.onGroupExpanded(expandedGm.gPos);
			return true;
		}

		/// <summary>Whether the given group is currently expanded.</summary>
		/// <remarks>Whether the given group is currently expanded.</remarks>
		/// <param name="groupPosition">The group to check.</param>
		/// <returns>Whether the group is currently expanded.</returns>
		public virtual bool isGroupExpanded(int groupPosition)
		{
			android.widget.ExpandableListConnector.GroupMetadata groupMetadata;
			{
				for (int i = mExpGroupMetadataList.size() - 1; i >= 0; i--)
				{
					groupMetadata = mExpGroupMetadataList.get(i);
					if (groupMetadata.gPos == groupPosition)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Set the maximum number of groups that can be expanded at any given time</summary>
		public virtual void setMaxExpGroupCount(int maxExpGroupCount)
		{
			mMaxExpGroupCount = maxExpGroupCount;
		}

		internal virtual android.widget.ExpandableListAdapter getAdapter()
		{
			return mExpandableListAdapter;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
		public virtual android.widget.Filter getFilter()
		{
			android.widget.ExpandableListAdapter adapter = getAdapter();
			if (adapter is android.widget.Filterable)
			{
				return ((android.widget.Filterable)adapter).getFilter();
			}
			else
			{
				return null;
			}
		}

		internal virtual java.util.ArrayList<android.widget.ExpandableListConnector.GroupMetadata
			> getExpandedGroupMetadataList()
		{
			return mExpGroupMetadataList;
		}

		internal virtual void setExpandedGroupMetadataList(java.util.ArrayList<android.widget.ExpandableListConnector
			.GroupMetadata> expandedGroupMetadataList)
		{
			if ((expandedGroupMetadataList == null) || (mExpandableListAdapter == null))
			{
				return;
			}
			// Make sure our current data set is big enough for the previously
			// expanded groups, if not, ignore this request
			int numGroups = mExpandableListAdapter.getGroupCount();
			{
				for (int i = expandedGroupMetadataList.size() - 1; i >= 0; i--)
				{
					if (expandedGroupMetadataList.get(i).gPos >= numGroups)
					{
						// Doh, for some reason the client doesn't have some of the groups
						return;
					}
				}
			}
			mExpGroupMetadataList = expandedGroupMetadataList;
			refreshExpGroupMetadataList(true, false);
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool isEmpty()
		{
			android.widget.ExpandableListAdapter adapter = getAdapter();
			return adapter != null ? adapter.isEmpty() : true;
		}

		/// <summary>
		/// Searches the expandable list adapter for a group position matching the
		/// given group ID.
		/// </summary>
		/// <remarks>
		/// Searches the expandable list adapter for a group position matching the
		/// given group ID. The search starts at the given seed position and then
		/// alternates between moving up and moving down until 1) we find the right
		/// position, or 2) we run out of time, or 3) we have looked at every
		/// position
		/// </remarks>
		/// <returns>
		/// Position of the row that matches the given row ID, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if it can't be found
		/// </returns>
		/// <seealso cref="AdapterView{T}.findSyncPosition()">AdapterView&lt;T&gt;.findSyncPosition()
		/// 	</seealso>
		internal virtual int findGroupPosition(long groupIdToMatch, int seedGroupPosition
			)
		{
			int count = mExpandableListAdapter.getGroupCount();
			if (count == 0)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			// If there isn't a selection don't hunt for it
			if (groupIdToMatch == android.widget.AdapterView.INVALID_ROW_ID)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			// Pin seed to reasonable values
			seedGroupPosition = System.Math.Max(0, seedGroupPosition);
			seedGroupPosition = System.Math.Min(count - 1, seedGroupPosition);
			long endTime = android.os.SystemClock.uptimeMillis() + android.widget.AdapterView.SYNC_MAX_DURATION_MILLIS;
			long rowId;
			// first position scanned so far
			int first = seedGroupPosition;
			// last position scanned so far
			int last = seedGroupPosition;
			// True if we should move down on the next iteration
			bool next = false;
			// True when we have looked at the first item in the data
			bool hitFirst;
			// True when we have looked at the last item in the data
			bool hitLast;
			// Get the item ID locally (instead of getItemIdAtPosition), so
			// we need the adapter
			android.widget.ExpandableListAdapter adapter = getAdapter();
			if (adapter == null)
			{
				return android.widget.AdapterView.INVALID_POSITION;
			}
			while (android.os.SystemClock.uptimeMillis() <= endTime)
			{
				rowId = adapter.getGroupId(seedGroupPosition);
				if (rowId == groupIdToMatch)
				{
					// Found it!
					return seedGroupPosition;
				}
				hitLast = last == count - 1;
				hitFirst = first == 0;
				if (hitLast && hitFirst)
				{
					// Looked at everything
					break;
				}
				if (hitFirst || (next && !hitLast))
				{
					// Either we hit the top, or we are trying to move down
					last++;
					seedGroupPosition = last;
					// Try going up next time
					next = false;
				}
				else
				{
					if (hitLast || (!next && !hitFirst))
					{
						// Either we hit the bottom, or we are trying to move up
						first--;
						seedGroupPosition = first;
						// Try going down next time
						next = true;
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		protected internal class MyDataSetObserver : android.database.DataSetObserver
		{
			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				this._enclosing.refreshExpGroupMetadataList(true, true);
				this._enclosing.notifyDataSetChanged();
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				this._enclosing.refreshExpGroupMetadataList(true, true);
				this._enclosing.notifyDataSetInvalidated();
			}

			internal MyDataSetObserver(ExpandableListConnector _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ExpandableListConnector _enclosing;
		}

		/// <summary>
		/// Metadata about an expanded group to help convert from a flat list
		/// position to either a) group position for groups, or b) child position for
		/// children
		/// </summary>
		internal class GroupMetadata : android.os.Parcelable, java.lang.Comparable<android.widget.ExpandableListConnector
			.GroupMetadata>
		{
			internal const int REFRESH = -1;

			/// <summary>This group's flat list position</summary>
			internal int flPos;

			/// <summary>
			/// This group's last child's flat list position, so basically
			/// the range of this group in the flat list
			/// </summary>
			internal int lastChildFlPos;

			/// <summary>This group's group position</summary>
			internal int gPos;

			/// <summary>This group's id</summary>
			internal long gId;

			private GroupMetadata()
			{
			}

			internal static android.widget.ExpandableListConnector.GroupMetadata obtain(int flPos
				, int lastChildFlPos, int gPos, long gId)
			{
				android.widget.ExpandableListConnector.GroupMetadata gm = new android.widget.ExpandableListConnector
					.GroupMetadata();
				gm.flPos = flPos;
				gm.lastChildFlPos = lastChildFlPos;
				gm.gPos = gPos;
				gm.gId = gId;
				return gm;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
			public virtual int compareTo(android.widget.ExpandableListConnector.GroupMetadata
				 another)
			{
				if (another == null)
				{
					throw new System.ArgumentException();
				}
				return gPos - another.gPos;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				return 0;
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				dest.writeInt(flPos);
				dest.writeInt(lastChildFlPos);
				dest.writeInt(gPos);
				dest.writeLong(gId);
			}

			private sealed class _Creator_925 : android.os.ParcelableClass.Creator<android.widget.ExpandableListConnector
				.GroupMetadata>
			{
				public _Creator_925()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ExpandableListConnector.GroupMetadata createFromParcel(android.os.Parcel
					 @in)
				{
					android.widget.ExpandableListConnector.GroupMetadata gm = android.widget.ExpandableListConnector
						.GroupMetadata.obtain(@in.readInt(), @in.readInt(), @in.readInt(), @in.readLong(
						));
					return gm;
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.ExpandableListConnector.GroupMetadata[] newArray(int size)
				{
					return new android.widget.ExpandableListConnector.GroupMetadata[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.ExpandableListConnector
				.GroupMetadata> CREATOR = new _Creator_925();
		}

		/// <summary>
		/// Data type that contains an expandable list position (can refer to either a group
		/// or child) and some extra information regarding referred item (such as
		/// where to insert into the flat list, etc.)
		/// </summary>
		public class PositionMetadata
		{
			internal const int MAX_POOL_SIZE = 5;

			private static java.util.ArrayList<android.widget.ExpandableListConnector.PositionMetadata
				> sPool = new java.util.ArrayList<android.widget.ExpandableListConnector.PositionMetadata
				>(MAX_POOL_SIZE);

			/// <summary>Data type to hold the position and its type (child/group)</summary>
			internal android.widget.ExpandableListPosition position;

			/// <summary>Link back to the expanded GroupMetadata for this group.</summary>
			/// <remarks>
			/// Link back to the expanded GroupMetadata for this group. Useful for
			/// removing the group from the list of expanded groups inside the
			/// connector when we collapse the group, and also as a check to see if
			/// the group was expanded or collapsed (this will be null if the group
			/// is collapsed since we don't keep that group's metadata)
			/// </remarks>
			internal android.widget.ExpandableListConnector.GroupMetadata groupMetadata;

			/// <summary>
			/// For groups that are collapsed, we use this as the index (in
			/// mExpGroupMetadataList) to insert this group when we are expanding
			/// this group.
			/// </summary>
			/// <remarks>
			/// For groups that are collapsed, we use this as the index (in
			/// mExpGroupMetadataList) to insert this group when we are expanding
			/// this group.
			/// </remarks>
			public int groupInsertIndex;

			private void resetState()
			{
				position = null;
				groupMetadata = null;
				groupInsertIndex = 0;
			}

			/// <summary>
			/// Use
			/// <see cref="obtain(int, int, int, int, GroupMetadata, int)">obtain(int, int, int, int, GroupMetadata, int)
			/// 	</see>
			/// </summary>
			private PositionMetadata()
			{
			}

			internal static android.widget.ExpandableListConnector.PositionMetadata obtain(int
				 flatListPos, int type, int groupPos, int childPos, android.widget.ExpandableListConnector
				.GroupMetadata groupMetadata, int groupInsertIndex)
			{
				android.widget.ExpandableListConnector.PositionMetadata pm = getRecycledOrCreate(
					);
				pm.position = android.widget.ExpandableListPosition.obtain(type, groupPos, childPos
					, flatListPos);
				pm.groupMetadata = groupMetadata;
				pm.groupInsertIndex = groupInsertIndex;
				return pm;
			}

			private static android.widget.ExpandableListConnector.PositionMetadata getRecycledOrCreate
				()
			{
				android.widget.ExpandableListConnector.PositionMetadata pm;
				lock (sPool)
				{
					if (sPool.size() > 0)
					{
						pm = sPool.remove(0);
					}
					else
					{
						return new android.widget.ExpandableListConnector.PositionMetadata();
					}
				}
				pm.resetState();
				return pm;
			}

			public virtual void recycle()
			{
				lock (sPool)
				{
					if (sPool.size() < MAX_POOL_SIZE)
					{
						sPool.add(this);
					}
				}
			}

			/// <summary>
			/// Checks whether the group referred to in this object is expanded,
			/// or not (at the time this object was created)
			/// </summary>
			/// <returns>whether the group at groupPos is expanded or not</returns>
			public virtual bool isExpanded()
			{
				return groupMetadata != null;
			}
		}
	}
}
