using Sharpen;

namespace android.widget
{
	/// <summary>
	/// A concrete BaseAdapter that is backed by an array of arbitrary
	/// objects.
	/// </summary>
	/// <remarks>
	/// A concrete BaseAdapter that is backed by an array of arbitrary
	/// objects.  By default this class expects that the provided resource id references
	/// a single TextView.  If you want to use a more complex layout, use the constructors that
	/// also takes a field id.  That field id should reference a TextView in the larger layout
	/// resource.
	/// <p>However the TextView is referenced, it will be filled with the toString() of each object in
	/// the array. You can add lists or arrays of custom objects. Override the toString() method
	/// of your objects to determine what text will be displayed for the item in the list.
	/// <p>To use something other than TextViews for the array display, for instance, ImageViews,
	/// or to have some of data besides toString() results fill the views,
	/// override
	/// <see cref="ArrayAdapter{T}.getView(int, android.view.View, android.view.ViewGroup)
	/// 	">ArrayAdapter&lt;T&gt;.getView(int, android.view.View, android.view.ViewGroup)</see>
	/// to return the type of view you want.
	/// </remarks>
	[Sharpen.Sharpened]
	public class ArrayAdapter<T> : android.widget.BaseAdapter, android.widget.Filterable
	{
		/// <summary>Contains the list of objects that represent the data of this ArrayAdapter.
		/// 	</summary>
		/// <remarks>
		/// Contains the list of objects that represent the data of this ArrayAdapter.
		/// The content of this list is referred to as "the array" in the documentation.
		/// </remarks>
		private java.util.List<T> mObjects;

		/// <summary>
		/// Lock used to modify the content of
		/// <see cref="ArrayAdapter{T}.mObjects">ArrayAdapter&lt;T&gt;.mObjects</see>
		/// . Any write operation
		/// performed on the array should be synchronized on this lock. This lock is also
		/// used by the filter (see
		/// <see cref="ArrayAdapter{T}.getFilter()">ArrayAdapter&lt;T&gt;.getFilter()</see>
		/// to make a synchronized copy of
		/// the original array of data.
		/// </summary>
		private readonly object mLock = new object();

		/// <summary>
		/// The resource indicating what views to inflate to display the content of this
		/// array adapter.
		/// </summary>
		/// <remarks>
		/// The resource indicating what views to inflate to display the content of this
		/// array adapter.
		/// </remarks>
		private int mResource;

		/// <summary>
		/// The resource indicating what views to inflate to display the content of this
		/// array adapter in a drop down widget.
		/// </summary>
		/// <remarks>
		/// The resource indicating what views to inflate to display the content of this
		/// array adapter in a drop down widget.
		/// </remarks>
		private int mDropDownResource;

		/// <summary>
		/// If the inflated resource is not a TextView,
		/// <see cref="ArrayAdapter{T}.mFieldId">ArrayAdapter&lt;T&gt;.mFieldId</see>
		/// is used to find
		/// a TextView inside the inflated views hierarchy. This field must contain the
		/// identifier that matches the one defined in the resource file.
		/// </summary>
		private int mFieldId = 0;

		/// <summary>
		/// Indicates whether or not
		/// <see cref="ArrayAdapter{T}.notifyDataSetChanged()">ArrayAdapter&lt;T&gt;.notifyDataSetChanged()
		/// 	</see>
		/// must be called whenever
		/// <see cref="ArrayAdapter{T}.mObjects">ArrayAdapter&lt;T&gt;.mObjects</see>
		/// is modified.
		/// </summary>
		private bool mNotifyOnChange = true;

		private android.content.Context mContext;

		private java.util.ArrayList<T> mOriginalValues;

		private android.widget.ArrayAdapter<T>.ArrayFilter mFilter;

		private android.view.LayoutInflater mInflater;

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="textViewResourceId">
		/// The resource ID for a layout file containing a TextView to use when
		/// instantiating views.
		/// </param>
		public ArrayAdapter(android.content.Context context, int textViewResourceId)
		{
			// A copy of the original mObjects array, initialized from and then used instead as soon as
			// the mFilter ArrayFilter is used. mObjects will then only contain the filtered values.
			init(context, textViewResourceId, 0, new java.util.ArrayList<T>());
		}

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="resource">
		/// The resource ID for a layout file containing a layout to use when
		/// instantiating views.
		/// </param>
		/// <param name="textViewResourceId">The id of the TextView within the layout resource to be populated
		/// 	</param>
		public ArrayAdapter(android.content.Context context, int resource, int textViewResourceId
			)
		{
			init(context, resource, textViewResourceId, new java.util.ArrayList<T>());
		}

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="textViewResourceId">
		/// The resource ID for a layout file containing a TextView to use when
		/// instantiating views.
		/// </param>
		/// <param name="objects">The objects to represent in the ListView.</param>
		public ArrayAdapter(android.content.Context context, int textViewResourceId, T[] 
			objects)
		{
			init(context, textViewResourceId, 0, java.util.Arrays.asList<T>(objects));
		}

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="resource">
		/// The resource ID for a layout file containing a layout to use when
		/// instantiating views.
		/// </param>
		/// <param name="textViewResourceId">The id of the TextView within the layout resource to be populated
		/// 	</param>
		/// <param name="objects">The objects to represent in the ListView.</param>
		public ArrayAdapter(android.content.Context context, int resource, int textViewResourceId
			, T[] objects)
		{
			init(context, resource, textViewResourceId, java.util.Arrays.asList<T>(objects));
		}

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="textViewResourceId">
		/// The resource ID for a layout file containing a TextView to use when
		/// instantiating views.
		/// </param>
		/// <param name="objects">The objects to represent in the ListView.</param>
		public ArrayAdapter(android.content.Context context, int textViewResourceId, java.util.List
			<T> objects)
		{
			init(context, textViewResourceId, 0, objects);
		}

		/// <summary>Constructor</summary>
		/// <param name="context">The current context.</param>
		/// <param name="resource">
		/// The resource ID for a layout file containing a layout to use when
		/// instantiating views.
		/// </param>
		/// <param name="textViewResourceId">The id of the TextView within the layout resource to be populated
		/// 	</param>
		/// <param name="objects">The objects to represent in the ListView.</param>
		public ArrayAdapter(android.content.Context context, int resource, int textViewResourceId
			, java.util.List<T> objects)
		{
			init(context, resource, textViewResourceId, objects);
		}

		/// <summary>Adds the specified object at the end of the array.</summary>
		/// <remarks>Adds the specified object at the end of the array.</remarks>
		/// <param name="object">The object to add at the end of the array.</param>
		public virtual void add(T @object)
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					mOriginalValues.add(@object);
				}
				else
				{
					mObjects.add(@object);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Adds the specified Collection at the end of the array.</summary>
		/// <remarks>Adds the specified Collection at the end of the array.</remarks>
		/// <param name="collection">The Collection to add at the end of the array.</param>
		public virtual void addAll<_T0>(java.util.Collection<_T0> collection) where _T0:T
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					mOriginalValues.addAll(collection);
				}
				else
				{
					mObjects.addAll(collection);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Adds the specified items at the end of the array.</summary>
		/// <remarks>Adds the specified items at the end of the array.</remarks>
		/// <param name="items">The items to add at the end of the array.</param>
		public virtual void addAll(params T[] items)
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					java.util.Collections.addAll(mOriginalValues, items);
				}
				else
				{
					java.util.Collections.addAll(mObjects, items);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Inserts the specified object at the specified index in the array.</summary>
		/// <remarks>Inserts the specified object at the specified index in the array.</remarks>
		/// <param name="object">The object to insert into the array.</param>
		/// <param name="index">The index at which the object must be inserted.</param>
		public virtual void insert(T @object, int index)
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					mOriginalValues.add(index, @object);
				}
				else
				{
					mObjects.add(index, @object);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Removes the specified object from the array.</summary>
		/// <remarks>Removes the specified object from the array.</remarks>
		/// <param name="object">The object to remove.</param>
		public virtual void remove(T @object)
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					mOriginalValues.remove(@object);
				}
				else
				{
					mObjects.remove(@object);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Remove all elements from the list.</summary>
		/// <remarks>Remove all elements from the list.</remarks>
		public virtual void clear()
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					mOriginalValues.clear();
				}
				else
				{
					mObjects.clear();
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary>Sorts the content of this adapter using the specified comparator.</summary>
		/// <remarks>Sorts the content of this adapter using the specified comparator.</remarks>
		/// <param name="comparator">
		/// The comparator used to sort the objects contained
		/// in this adapter.
		/// </param>
		public virtual void sort(java.util.Comparator<T> comparator)
		{
			lock (mLock)
			{
				if (mOriginalValues != null)
				{
					java.util.Collections.sort(mOriginalValues, comparator);
				}
				else
				{
					java.util.Collections.sort(mObjects, comparator);
				}
			}
			if (mNotifyOnChange)
			{
				notifyDataSetChanged();
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override void notifyDataSetChanged()
		{
			base.notifyDataSetChanged();
			mNotifyOnChange = true;
		}

		/// <summary>
		/// Control whether methods that change the list (
		/// <see cref="ArrayAdapter{T}.add(object)">ArrayAdapter&lt;T&gt;.add(object)</see>
		/// ,
		/// <see cref="ArrayAdapter{T}.insert(object, int)">ArrayAdapter&lt;T&gt;.insert(object, int)
		/// 	</see>
		/// ,
		/// <see cref="ArrayAdapter{T}.remove(object)">ArrayAdapter&lt;T&gt;.remove(object)</see>
		/// ,
		/// <see cref="ArrayAdapter{T}.clear()">ArrayAdapter&lt;T&gt;.clear()</see>
		/// ) automatically call
		/// <see cref="ArrayAdapter{T}.notifyDataSetChanged()">ArrayAdapter&lt;T&gt;.notifyDataSetChanged()
		/// 	</see>
		/// .  If set to false, caller must
		/// manually call notifyDataSetChanged() to have the changes
		/// reflected in the attached view.
		/// The default is true, and calling notifyDataSetChanged()
		/// resets the flag to true.
		/// </summary>
		/// <param name="notifyOnChange">
		/// if true, modifications to the list will
		/// automatically call
		/// <see cref="ArrayAdapter{T}.notifyDataSetChanged()">ArrayAdapter&lt;T&gt;.notifyDataSetChanged()
		/// 	</see>
		/// </param>
		public virtual void setNotifyOnChange(bool notifyOnChange)
		{
			mNotifyOnChange = notifyOnChange;
		}

		private void init(android.content.Context context, int resource, int textViewResourceId
			, java.util.List<T> objects)
		{
			mContext = context;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
			mResource = mDropDownResource = resource;
			mObjects = objects;
			mFieldId = textViewResourceId;
		}

		/// <summary>Returns the context associated with this array adapter.</summary>
		/// <remarks>
		/// Returns the context associated with this array adapter. The context is used
		/// to create views from the resource passed to the constructor.
		/// </remarks>
		/// <returns>The Context associated with this adapter.</returns>
		public virtual android.content.Context getContext()
		{
			return mContext;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override int getCount()
		{
			return mObjects.size();
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override object getItem(int position)
		{
			return mObjects.get(position);
		}

		/// <summary>Returns the position of the specified item in the array.</summary>
		/// <remarks>Returns the position of the specified item in the array.</remarks>
		/// <param name="item">The item to retrieve the position of.</param>
		/// <returns>The position of the specified item.</returns>
		public virtual int getPosition(T item)
		{
			return mObjects.indexOf(item);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override long getItemId(int position)
		{
			return position;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			return createViewFromResource(position, convertView, parent, mResource);
		}

		private android.view.View createViewFromResource(int position, android.view.View 
			convertView, android.view.ViewGroup parent, int resource)
		{
			android.view.View view;
			android.widget.TextView text;
			if (convertView == null)
			{
				view = mInflater.inflate(resource, parent, false);
			}
			else
			{
				view = convertView;
			}
			try
			{
				if (mFieldId == 0)
				{
					//  If no custom field is assigned, assume the whole resource is a TextView
					text = (android.widget.TextView)view;
				}
				else
				{
					//  Otherwise, find the TextView field within the layout
					text = (android.widget.TextView)view.findViewById(mFieldId);
				}
			}
			catch (System.InvalidCastException e)
			{
				android.util.Log.e("ArrayAdapter", "You must supply a resource ID for a TextView"
					);
				throw new System.InvalidOperationException("ArrayAdapter requires the resource ID to be a TextView"
					, e);
			}
			T item = ((T)getItem(position));
			if (item is java.lang.CharSequence)
			{
				text.setText((java.lang.CharSequence)item);
			}
			else
			{
				text.setText(java.lang.CharSequenceProxy.Wrap(item.ToString()));
			}
			return view;
		}

		/// <summary><p>Sets the layout resource to create the drop down views.</p></summary>
		/// <param name="resource">the layout resource defining the drop down views</param>
		/// <seealso cref="ArrayAdapter{T}.getDropDownView(int, android.view.View, android.view.ViewGroup)
		/// 	">ArrayAdapter&lt;T&gt;.getDropDownView(int, android.view.View, android.view.ViewGroup)
		/// 	</seealso>
		public virtual void setDropDownViewResource(int resource)
		{
			this.mDropDownResource = resource;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override android.view.View getDropDownView(int position, android.view.View
			 convertView, android.view.ViewGroup parent)
		{
			return createViewFromResource(position, convertView, parent, mDropDownResource);
		}

		/// <summary>Creates a new ArrayAdapter from external resources.</summary>
		/// <remarks>
		/// Creates a new ArrayAdapter from external resources. The content of the array is
		/// obtained through
		/// <see cref="android.content.res.Resources.getTextArray(int)">android.content.res.Resources.getTextArray(int)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">The application's environment.</param>
		/// <param name="textArrayResId">The identifier of the array to use as the data source.
		/// 	</param>
		/// <param name="textViewResId">The identifier of the layout used to create views.</param>
		/// <returns>An ArrayAdapter<CharSequence>.</returns>
		public static android.widget.ArrayAdapter<java.lang.CharSequence> createFromResource
			(android.content.Context context, int textArrayResId, int textViewResId)
		{
			java.lang.CharSequence[] strings = context.getResources().getTextArray(textArrayResId
				);
			return new android.widget.ArrayAdapter<java.lang.CharSequence>(context, textViewResId
				, strings);
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
		public virtual android.widget.Filter getFilter()
		{
			if (mFilter == null)
			{
				mFilter = new android.widget.ArrayAdapter<T>.ArrayFilter(this);
			}
			return mFilter;
		}

		/// <summary>
		/// <p>An array filter constrains the content of the array adapter with
		/// a prefix.
		/// </summary>
		/// <remarks>
		/// <p>An array filter constrains the content of the array adapter with
		/// a prefix. Each item that does not start with the supplied prefix
		/// is removed from the list.</p>
		/// </remarks>
		private class ArrayFilter : android.widget.Filter
		{
			[Sharpen.OverridesMethod(@"android.widget.Filter")]
			internal override android.widget.Filter.FilterResults performFiltering(java.lang.CharSequence
				 prefix)
			{
				android.widget.Filter.FilterResults results = new android.widget.Filter.FilterResults
					();
				if (this._enclosing.mOriginalValues == null)
				{
					lock (this._enclosing.mLock)
					{
						this._enclosing.mOriginalValues = new java.util.ArrayList<T>(this._enclosing.mObjects
							);
					}
				}
				if (prefix == null || prefix.Length == 0)
				{
					java.util.ArrayList<T> list;
					lock (this._enclosing.mLock)
					{
						list = new java.util.ArrayList<T>(this._enclosing.mOriginalValues);
					}
					results.values = list;
					results.count = list.size();
				}
				else
				{
					string prefixString = prefix.ToString().ToLower();
					java.util.ArrayList<T> values;
					lock (this._enclosing.mLock)
					{
						values = new java.util.ArrayList<T>(this._enclosing.mOriginalValues);
					}
					int count = values.size();
					java.util.ArrayList<T> newValues = new java.util.ArrayList<T>();
					{
						for (int i = 0; i < count; i++)
						{
							T value = values.get(i);
							string valueText = value.ToString().ToLower();
							// First match against the whole, non-splitted value
							if (valueText.StartsWith(prefixString))
							{
								newValues.add(value);
							}
							else
							{
								string[] words = XobotOS.Runtime.Util.SplitStringRegex(valueText, " ");
								int wordCount = words.Length;
								{
									// Start at index 0, in case valueText starts with space(s)
									for (int k = 0; k < wordCount; k++)
									{
										if (words[k].StartsWith(prefixString))
										{
											newValues.add(value);
											break;
										}
									}
								}
							}
						}
					}
					results.values = newValues;
					results.count = newValues.size();
				}
				return results;
			}

			[Sharpen.OverridesMethod(@"android.widget.Filter")]
			internal override void publishResults(java.lang.CharSequence constraint, android.widget.Filter
				.FilterResults results)
			{
				//noinspection unchecked
				this._enclosing.mObjects = (java.util.List<T>)results.values;
				if (results.count > 0)
				{
					this._enclosing.notifyDataSetChanged();
				}
				else
				{
					this._enclosing.notifyDataSetInvalidated();
				}
			}

			internal ArrayFilter(ArrayAdapter<T> _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ArrayAdapter<T> _enclosing;
		}
	}
}
