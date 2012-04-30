using Sharpen;

namespace android.widget
{
	/// <summary>
	/// ExpandableListPosition can refer to either a group's position or a child's
	/// position.
	/// </summary>
	/// <remarks>
	/// ExpandableListPosition can refer to either a group's position or a child's
	/// position. Referring to a child's position requires both a group position (the
	/// group containing the child) and a child position (the child's position within
	/// that group). To create objects, use
	/// <see cref="obtainChildPosition(int, int)">obtainChildPosition(int, int)</see>
	/// or
	/// <see cref="obtainGroupPosition(int)">obtainGroupPosition(int)</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	internal class ExpandableListPosition
	{
		internal const int MAX_POOL_SIZE = 5;

		private static java.util.ArrayList<android.widget.ExpandableListPosition> sPool = 
			new java.util.ArrayList<android.widget.ExpandableListPosition>(MAX_POOL_SIZE);

		/// <summary>This data type represents a child position</summary>
		public const int CHILD = 1;

		/// <summary>This data type represents a group position</summary>
		public const int GROUP = 2;

		/// <summary>
		/// The position of either the group being referred to, or the parent
		/// group of the child being referred to
		/// </summary>
		public int groupPos;

		/// <summary>The position of the child within its parent group</summary>
		public int childPos;

		/// <summary>
		/// The position of the item in the flat list (optional, used internally when
		/// the corresponding flat list position for the group or child is known)
		/// </summary>
		internal int flatListPos;

		/// <summary>What type of position this ExpandableListPosition represents</summary>
		public int type;

		private void resetState()
		{
			groupPos = 0;
			childPos = 0;
			flatListPos = 0;
			type = 0;
		}

		private ExpandableListPosition()
		{
		}

		internal virtual long getPackedPosition()
		{
			if (type == CHILD)
			{
				return android.widget.ExpandableListView.getPackedPositionForChild(groupPos, childPos
					);
			}
			else
			{
				return android.widget.ExpandableListView.getPackedPositionForGroup(groupPos);
			}
		}

		internal static android.widget.ExpandableListPosition obtainGroupPosition(int groupPosition
			)
		{
			return obtain(GROUP, groupPosition, 0, 0);
		}

		internal static android.widget.ExpandableListPosition obtainChildPosition(int groupPosition
			, int childPosition)
		{
			return obtain(CHILD, groupPosition, childPosition, 0);
		}

		internal static android.widget.ExpandableListPosition obtainPosition(long packedPosition
			)
		{
			if (packedPosition == android.widget.ExpandableListView.PACKED_POSITION_VALUE_NULL)
			{
				return null;
			}
			android.widget.ExpandableListPosition elp = getRecycledOrCreate();
			elp.groupPos = android.widget.ExpandableListView.getPackedPositionGroup(packedPosition
				);
			if (android.widget.ExpandableListView.getPackedPositionType(packedPosition) == android.widget.ExpandableListView
				.PACKED_POSITION_TYPE_CHILD)
			{
				elp.type = CHILD;
				elp.childPos = android.widget.ExpandableListView.getPackedPositionChild(packedPosition
					);
			}
			else
			{
				elp.type = GROUP;
			}
			return elp;
		}

		internal static android.widget.ExpandableListPosition obtain(int type, int groupPos
			, int childPos, int flatListPos)
		{
			android.widget.ExpandableListPosition elp = getRecycledOrCreate();
			elp.type = type;
			elp.groupPos = groupPos;
			elp.childPos = childPos;
			elp.flatListPos = flatListPos;
			return elp;
		}

		internal static android.widget.ExpandableListPosition getRecycledOrCreate()
		{
			android.widget.ExpandableListPosition elp;
			lock (sPool)
			{
				if (sPool.size() > 0)
				{
					elp = sPool.remove(0);
				}
				else
				{
					return new android.widget.ExpandableListPosition();
				}
			}
			elp.resetState();
			return elp;
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
	}
}
