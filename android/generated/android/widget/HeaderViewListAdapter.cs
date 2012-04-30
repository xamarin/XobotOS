using Sharpen;

namespace android.widget
{
	/// <summary>ListAdapter used when a ListView has header views.</summary>
	/// <remarks>
	/// ListAdapter used when a ListView has header views. This ListAdapter
	/// wraps another one and also keeps track of the header views and their
	/// associated data objects.
	/// <p>This is intended as a base class; you will probably not need to
	/// use this class directly in your own code.
	/// </remarks>
	[Sharpen.Sharpened]
	public class HeaderViewListAdapter : android.widget.WrapperListAdapter, android.widget.Filterable
	{
		private readonly android.widget.ListAdapter mAdapter;

		internal java.util.ArrayList<android.widget.ListView.FixedViewInfo> mHeaderViewInfos;

		internal java.util.ArrayList<android.widget.ListView.FixedViewInfo> mFooterViewInfos;

		internal static readonly java.util.ArrayList<android.widget.ListView.FixedViewInfo
			> EMPTY_INFO_LIST = new java.util.ArrayList<android.widget.ListView.FixedViewInfo
			>();

		internal bool mAreAllFixedViewsSelectable;

		private readonly bool mIsFilterable;

		public HeaderViewListAdapter(java.util.ArrayList<android.widget.ListView.FixedViewInfo
			> headerViewInfos, java.util.ArrayList<android.widget.ListView.FixedViewInfo> footerViewInfos
			, android.widget.ListAdapter adapter)
		{
			// These two ArrayList are assumed to NOT be null.
			// They are indeed created when declared in ListView and then shared.
			// Used as a placeholder in case the provided info views are indeed null.
			// Currently only used by some CTS tests, which may be removed.
			mAdapter = adapter;
			mIsFilterable = adapter is android.widget.Filterable;
			if (headerViewInfos == null)
			{
				mHeaderViewInfos = EMPTY_INFO_LIST;
			}
			else
			{
				mHeaderViewInfos = headerViewInfos;
			}
			if (footerViewInfos == null)
			{
				mFooterViewInfos = EMPTY_INFO_LIST;
			}
			else
			{
				mFooterViewInfos = footerViewInfos;
			}
			mAreAllFixedViewsSelectable = areAllListInfosSelectable(mHeaderViewInfos) && areAllListInfosSelectable
				(mFooterViewInfos);
		}

		public virtual int getHeadersCount()
		{
			return mHeaderViewInfos.size();
		}

		public virtual int getFootersCount()
		{
			return mFooterViewInfos.size();
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual bool isEmpty()
		{
			return mAdapter == null || mAdapter.isEmpty();
		}

		private bool areAllListInfosSelectable(java.util.ArrayList<android.widget.ListView
			.FixedViewInfo> infos)
		{
			if (infos != null)
			{
				foreach (android.widget.ListView.FixedViewInfo info in Sharpen.IterableProxy.Create
					(infos))
				{
					if (!info.isSelectable)
					{
						return false;
					}
				}
			}
			return true;
		}

		public virtual bool removeHeader(android.view.View v)
		{
			{
				for (int i = 0; i < mHeaderViewInfos.size(); i++)
				{
					android.widget.ListView.FixedViewInfo info = mHeaderViewInfos.get(i);
					if (info.view == v)
					{
						mHeaderViewInfos.remove(i);
						mAreAllFixedViewsSelectable = areAllListInfosSelectable(mHeaderViewInfos) && areAllListInfosSelectable
							(mFooterViewInfos);
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool removeFooter(android.view.View v)
		{
			{
				for (int i = 0; i < mFooterViewInfos.size(); i++)
				{
					android.widget.ListView.FixedViewInfo info = mFooterViewInfos.get(i);
					if (info.view == v)
					{
						mFooterViewInfos.remove(i);
						mAreAllFixedViewsSelectable = areAllListInfosSelectable(mHeaderViewInfos) && areAllListInfosSelectable
							(mFooterViewInfos);
						return true;
					}
				}
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual int getCount()
		{
			if (mAdapter != null)
			{
				return getFootersCount() + getHeadersCount() + mAdapter.getCount();
			}
			else
			{
				return getFootersCount() + getHeadersCount();
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
		public virtual bool areAllItemsEnabled()
		{
			if (mAdapter != null)
			{
				return mAreAllFixedViewsSelectable && mAdapter.areAllItemsEnabled();
			}
			else
			{
				return true;
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
		public virtual bool isEnabled(int position)
		{
			// Header (negative positions will throw an ArrayIndexOutOfBoundsException)
			int numHeaders = getHeadersCount();
			if (position < numHeaders)
			{
				return mHeaderViewInfos.get(position).isSelectable;
			}
			// Adapter
			int adjPosition = position - numHeaders;
			int adapterCount = 0;
			if (mAdapter != null)
			{
				adapterCount = mAdapter.getCount();
				if (adjPosition < adapterCount)
				{
					return mAdapter.isEnabled(adjPosition);
				}
			}
			// Footer (off-limits positions will throw an ArrayIndexOutOfBoundsException)
			return mFooterViewInfos.get(adjPosition - adapterCount).isSelectable;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual object getItem(int position)
		{
			// Header (negative positions will throw an ArrayIndexOutOfBoundsException)
			int numHeaders = getHeadersCount();
			if (position < numHeaders)
			{
				return mHeaderViewInfos.get(position).data;
			}
			// Adapter
			int adjPosition = position - numHeaders;
			int adapterCount = 0;
			if (mAdapter != null)
			{
				adapterCount = mAdapter.getCount();
				if (adjPosition < adapterCount)
				{
					return mAdapter.getItem(adjPosition);
				}
			}
			// Footer (off-limits positions will throw an ArrayIndexOutOfBoundsException)
			return mFooterViewInfos.get(adjPosition - adapterCount).data;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual long getItemId(int position)
		{
			int numHeaders = getHeadersCount();
			if (mAdapter != null && position >= numHeaders)
			{
				int adjPosition = position - numHeaders;
				int adapterCount = mAdapter.getCount();
				if (adjPosition < adapterCount)
				{
					return mAdapter.getItemId(adjPosition);
				}
			}
			return -1;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual bool hasStableIds()
		{
			if (mAdapter != null)
			{
				return mAdapter.hasStableIds();
			}
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			// Header (negative positions will throw an ArrayIndexOutOfBoundsException)
			int numHeaders = getHeadersCount();
			if (position < numHeaders)
			{
				return mHeaderViewInfos.get(position).view;
			}
			// Adapter
			int adjPosition = position - numHeaders;
			int adapterCount = 0;
			if (mAdapter != null)
			{
				adapterCount = mAdapter.getCount();
				if (adjPosition < adapterCount)
				{
					return mAdapter.getView(adjPosition, convertView, parent);
				}
			}
			// Footer (off-limits positions will throw an ArrayIndexOutOfBoundsException)
			return mFooterViewInfos.get(adjPosition - adapterCount).view;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual int getItemViewType(int position)
		{
			int numHeaders = getHeadersCount();
			if (mAdapter != null && position >= numHeaders)
			{
				int adjPosition = position - numHeaders;
				int adapterCount = mAdapter.getCount();
				if (adjPosition < adapterCount)
				{
					return mAdapter.getItemViewType(adjPosition);
				}
			}
			return android.widget.AdapterView.ITEM_VIEW_TYPE_HEADER_OR_FOOTER;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual int getViewTypeCount()
		{
			if (mAdapter != null)
			{
				return mAdapter.getViewTypeCount();
			}
			return 1;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual void registerDataSetObserver(android.database.DataSetObserver observer
			)
		{
			if (mAdapter != null)
			{
				mAdapter.registerDataSetObserver(observer);
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual void unregisterDataSetObserver(android.database.DataSetObserver observer
			)
		{
			if (mAdapter != null)
			{
				mAdapter.unregisterDataSetObserver(observer);
			}
		}

		[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
		public virtual android.widget.Filter getFilter()
		{
			if (mIsFilterable)
			{
				return ((android.widget.Filterable)mAdapter).getFilter();
			}
			return null;
		}

		[Sharpen.ImplementsInterface(@"android.widget.WrapperListAdapter")]
		public virtual android.widget.ListAdapter getWrappedAdapter()
		{
			return mAdapter;
		}
	}
}
