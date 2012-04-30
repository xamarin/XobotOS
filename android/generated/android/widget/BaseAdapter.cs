using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Common base class of common implementation for an
	/// <see cref="Adapter">Adapter</see>
	/// that can be
	/// used in both
	/// <see cref="ListView">ListView</see>
	/// (by implementing the specialized
	/// <see cref="ListAdapter">ListAdapter</see>
	/// interface} and
	/// <see cref="Spinner">Spinner</see>
	/// (by implementing the
	/// specialized
	/// <see cref="SpinnerAdapter">SpinnerAdapter</see>
	/// interface.
	/// </summary>
	[Sharpen.Sharpened]
	public abstract class BaseAdapter : android.widget.ListAdapter, android.widget.SpinnerAdapter
	{
		private readonly android.database.DataSetObservable mDataSetObservable = new android.database.DataSetObservable
			();

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual bool hasStableIds()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual void registerDataSetObserver(android.database.DataSetObserver observer
			)
		{
			mDataSetObservable.registerObserver(observer);
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual void unregisterDataSetObserver(android.database.DataSetObserver observer
			)
		{
			mDataSetObservable.unregisterObserver(observer);
		}

		/// <summary>
		/// Notifies the attached observers that the underlying data has been changed
		/// and any View reflecting the data set should refresh itself.
		/// </summary>
		/// <remarks>
		/// Notifies the attached observers that the underlying data has been changed
		/// and any View reflecting the data set should refresh itself.
		/// </remarks>
		public virtual void notifyDataSetChanged()
		{
			mDataSetObservable.notifyChanged();
		}

		/// <summary>
		/// Notifies the attached observers that the underlying data is no longer valid
		/// or available.
		/// </summary>
		/// <remarks>
		/// Notifies the attached observers that the underlying data is no longer valid
		/// or available. Once invoked this adapter is no longer valid and should
		/// not report further data set changes.
		/// </remarks>
		public virtual void notifyDataSetInvalidated()
		{
			mDataSetObservable.notifyInvalidated();
		}

		[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
		public virtual bool areAllItemsEnabled()
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
		public virtual bool isEnabled(int position)
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"android.widget.SpinnerAdapter")]
		public virtual android.view.View getDropDownView(int position, android.view.View 
			convertView, android.view.ViewGroup parent)
		{
			return getView(position, convertView, parent);
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual int getItemViewType(int position)
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual int getViewTypeCount()
		{
			return 1;
		}

		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public virtual bool isEmpty()
		{
			return getCount() == 0;
		}

		public abstract int getCount();

		public abstract object getItem(int arg1);

		public abstract long getItemId(int arg1);

		public abstract android.view.View getView(int arg1, android.view.View arg2, android.view.ViewGroup
			 arg3);
	}
}
