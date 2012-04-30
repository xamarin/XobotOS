using Sharpen;

namespace android.widget
{
	/// <summary>An easy adapter to map static data to views defined in an XML file.</summary>
	/// <remarks>
	/// An easy adapter to map static data to views defined in an XML file. You can specify the data
	/// backing the list as an ArrayList of Maps. Each entry in the ArrayList corresponds to one row
	/// in the list. The Maps contain the data for each row. You also specify an XML file that
	/// defines the views used to display the row, and a mapping from keys in the Map to specific
	/// views.
	/// Binding data to views occurs in two phases. First, if a
	/// <see cref="ViewBinder">ViewBinder</see>
	/// is available,
	/// <see cref="ViewBinder.setViewValue(android.view.View, object, string)">ViewBinder.setViewValue(android.view.View, object, string)
	/// 	</see>
	/// is invoked. If the returned value is true, binding has occurred.
	/// If the returned value is false, the following views are then tried in order:
	/// <ul>
	/// <li> A view that implements Checkable (e.g. CheckBox).  The expected bind value is a boolean.
	/// <li> TextView.  The expected bind value is a string and
	/// <see cref="setViewText(TextView, string)">setViewText(TextView, string)</see>
	/// 
	/// is invoked.
	/// <li> ImageView. The expected bind value is a resource id or a string and
	/// <see cref="setViewImage(ImageView, int)">setViewImage(ImageView, int)</see>
	/// or
	/// <see cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</see>
	/// is invoked.
	/// </ul>
	/// If no appropriate binding can be found, an
	/// <see cref="System.InvalidOperationException">System.InvalidOperationException</see>
	/// is thrown.
	/// </remarks>
	[Sharpen.Sharpened]
	public class SimpleAdapter : android.widget.BaseAdapter, android.widget.Filterable
	{
		private int[] mTo;

		private string[] mFrom;

		private android.widget.SimpleAdapter.ViewBinder mViewBinder;

		private java.util.List<java.util.Map<string, object>> mData;

		private int mResource;

		private int mDropDownResource;

		private android.view.LayoutInflater mInflater;

		private android.widget.SimpleAdapter.SimpleFilter mFilter;

		private java.util.ArrayList<java.util.Map<string, object>> mUnfilteredData;

		/// <summary>Constructor</summary>
		/// <param name="context">The context where the View associated with this SimpleAdapter is running
		/// 	</param>
		/// <param name="data">
		/// A List of Maps. Each entry in the List corresponds to one row in the list. The
		/// Maps contain the data for each row, and should include all the entries specified in
		/// "from"
		/// </param>
		/// <param name="resource">
		/// Resource identifier of a view layout that defines the views for this list
		/// item. The layout file should include at least those named views defined in "to"
		/// </param>
		/// <param name="from">
		/// A list of column names that will be added to the Map associated with each
		/// item.
		/// </param>
		/// <param name="to">
		/// The views that should display column in the "from" parameter. These should all be
		/// TextViews. The first N views in this list are given the values of the first N columns
		/// in the from parameter.
		/// </param>
		public SimpleAdapter(android.content.Context context, java.util.List<java.util.Map
			<string, object>> data, int resource, string[] from, int[] to)
		{
			mData = data;
			mResource = mDropDownResource = resource;
			mFrom = from;
			mTo = to;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
		}

		/// <seealso cref="Adapter.getCount()">Adapter.getCount()</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override int getCount()
		{
			return mData.size();
		}

		/// <seealso cref="Adapter.getItem(int)">Adapter.getItem(int)</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override object getItem(int position)
		{
			return mData.get(position);
		}

		/// <seealso cref="Adapter.getItemId(int)">Adapter.getItemId(int)</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override long getItemId(int position)
		{
			return position;
		}

		/// <seealso cref="Adapter.getView(int, android.view.View, android.view.ViewGroup)">Adapter.getView(int, android.view.View, android.view.ViewGroup)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			return createViewFromResource(position, convertView, parent, mResource);
		}

		private android.view.View createViewFromResource(int position, android.view.View 
			convertView, android.view.ViewGroup parent, int resource)
		{
			android.view.View v;
			if (convertView == null)
			{
				v = mInflater.inflate(resource, parent, false);
			}
			else
			{
				v = convertView;
			}
			bindView(position, v);
			return v;
		}

		/// <summary><p>Sets the layout resource to create the drop down views.</p></summary>
		/// <param name="resource">the layout resource defining the drop down views</param>
		/// <seealso cref="getDropDownView(int, android.view.View, android.view.ViewGroup)">getDropDownView(int, android.view.View, android.view.ViewGroup)
		/// 	</seealso>
		public virtual void setDropDownViewResource(int resource)
		{
			this.mDropDownResource = resource;
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override android.view.View getDropDownView(int position, android.view.View
			 convertView, android.view.ViewGroup parent)
		{
			return createViewFromResource(position, convertView, parent, mDropDownResource);
		}

		private void bindView(int position, android.view.View view)
		{
			java.util.Map<string, object> dataSet = mData.get(position);
			if (dataSet == null)
			{
				return;
			}
			android.widget.SimpleAdapter.ViewBinder binder = mViewBinder;
			string[] from = mFrom;
			int[] to = mTo;
			int count = to.Length;
			{
				for (int i = 0; i < count; i++)
				{
					android.view.View v = view.findViewById(to[i]);
					if (v != null)
					{
						object data = dataSet.get(from[i]);
						string text = data == null ? string.Empty : data.ToString();
						if (text == null)
						{
							text = string.Empty;
						}
						bool bound = false;
						if (binder != null)
						{
							bound = binder.setViewValue(v, data, text);
						}
						if (!bound)
						{
							if (v is android.widget.Checkable)
							{
								if (data is bool)
								{
									((android.widget.Checkable)v).setChecked((bool)data);
								}
								else
								{
									if (v is android.widget.TextView)
									{
										// Note: keep the instanceof TextView check at the bottom of these
										// ifs since a lot of views are TextViews (e.g. CheckBoxes).
										setViewText((android.widget.TextView)v, text);
									}
									else
									{
										throw new System.InvalidOperationException(v.GetType().FullName + " should be bound to a Boolean, not a "
											 + (data == null ? "<unknown type>" : data.GetType().ToString()));
									}
								}
							}
							else
							{
								if (v is android.widget.TextView)
								{
									// Note: keep the instanceof TextView check at the bottom of these
									// ifs since a lot of views are TextViews (e.g. CheckBoxes).
									setViewText((android.widget.TextView)v, text);
								}
								else
								{
									if (v is android.widget.ImageView)
									{
										if (data is int)
										{
											setViewImage((android.widget.ImageView)v, (int)data);
										}
										else
										{
											setViewImage((android.widget.ImageView)v, text);
										}
									}
									else
									{
										throw new System.InvalidOperationException(v.GetType().FullName + " is not a " + 
											" view that can be bounds by this SimpleAdapter");
									}
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Returns the
		/// <see cref="ViewBinder">ViewBinder</see>
		/// used to bind data to views.
		/// </summary>
		/// <returns>a ViewBinder or null if the binder does not exist</returns>
		/// <seealso cref="setViewBinder(ViewBinder)">setViewBinder(ViewBinder)</seealso>
		public virtual android.widget.SimpleAdapter.ViewBinder getViewBinder()
		{
			return mViewBinder;
		}

		/// <summary>Sets the binder used to bind data to views.</summary>
		/// <remarks>Sets the binder used to bind data to views.</remarks>
		/// <param name="viewBinder">
		/// the binder used to bind data to views, can be null to
		/// remove the existing binder
		/// </param>
		/// <seealso cref="getViewBinder()">getViewBinder()</seealso>
		public virtual void setViewBinder(android.widget.SimpleAdapter.ViewBinder viewBinder
			)
		{
			mViewBinder = viewBinder;
		}

		/// <summary>
		/// Called by bindView() to set the image for an ImageView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an ImageView.
		/// </summary>
		/// <remarks>
		/// Called by bindView() to set the image for an ImageView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an ImageView.
		/// This method is called instead of
		/// <see cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</see>
		/// if the supplied data is an int or Integer.
		/// </remarks>
		/// <param name="v">ImageView to receive an image</param>
		/// <param name="value">the value retrieved from the data set</param>
		/// <seealso cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</seealso>
		public virtual void setViewImage(android.widget.ImageView v, int value)
		{
			v.setImageResource(value);
		}

		/// <summary>
		/// Called by bindView() to set the image for an ImageView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an ImageView.
		/// </summary>
		/// <remarks>
		/// Called by bindView() to set the image for an ImageView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an ImageView.
		/// By default, the value will be treated as an image resource. If the
		/// value cannot be used as an image resource, the value is used as an
		/// image Uri.
		/// This method is called instead of
		/// <see cref="setViewImage(ImageView, int)">setViewImage(ImageView, int)</see>
		/// if the supplied data is not an int or Integer.
		/// </remarks>
		/// <param name="v">ImageView to receive an image</param>
		/// <param name="value">the value retrieved from the data set</param>
		/// <seealso cref="setViewImage(ImageView, int)"></seealso>
		public virtual void setViewImage(android.widget.ImageView v, string value)
		{
			try
			{
				v.setImageResource(System.Convert.ToInt32(value));
			}
			catch (System.ArgumentException)
			{
				v.setImageURI(Sharpen.Util.ParseUri(value));
			}
		}

		/// <summary>
		/// Called by bindView() to set the text for a TextView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an TextView.
		/// </summary>
		/// <remarks>
		/// Called by bindView() to set the text for a TextView but only if
		/// there is no existing ViewBinder or if the existing ViewBinder cannot
		/// handle binding to an TextView.
		/// </remarks>
		/// <param name="v">TextView to receive text</param>
		/// <param name="text">the text to be set for the TextView</param>
		public virtual void setViewText(android.widget.TextView v, string text)
		{
			v.setText(java.lang.CharSequenceProxy.Wrap(text));
		}

		[Sharpen.ImplementsInterface(@"android.widget.Filterable")]
		public virtual android.widget.Filter getFilter()
		{
			if (mFilter == null)
			{
				mFilter = new android.widget.SimpleAdapter.SimpleFilter(this);
			}
			return mFilter;
		}

		/// <summary>
		/// This class can be used by external clients of SimpleAdapter to bind
		/// values to views.
		/// </summary>
		/// <remarks>
		/// This class can be used by external clients of SimpleAdapter to bind
		/// values to views.
		/// You should use this class to bind values to views that are not
		/// directly supported by SimpleAdapter or to change the way binding
		/// occurs for views supported by SimpleAdapter.
		/// </remarks>
		/// <seealso cref="SimpleAdapter.setViewImage(ImageView, int)">SimpleAdapter.setViewImage(ImageView, int)
		/// 	</seealso>
		/// <seealso cref="SimpleAdapter.setViewImage(ImageView, string)">SimpleAdapter.setViewImage(ImageView, string)
		/// 	</seealso>
		/// <seealso cref="SimpleAdapter.setViewText(TextView, string)">SimpleAdapter.setViewText(TextView, string)
		/// 	</seealso>
		public interface ViewBinder
		{
			/// <summary>Binds the specified data to the specified view.</summary>
			/// <remarks>
			/// Binds the specified data to the specified view.
			/// When binding is handled by this ViewBinder, this method must return true.
			/// If this method returns false, SimpleAdapter will attempts to handle
			/// the binding on its own.
			/// </remarks>
			/// <param name="view">the view to bind the data to</param>
			/// <param name="data">the data to bind to the view</param>
			/// <param name="textRepresentation">
			/// a safe String representation of the supplied data:
			/// it is either the result of data.toString() or an empty String but it
			/// is never null
			/// </param>
			/// <returns>true if the data was bound to the view, false otherwise</returns>
			bool setViewValue(android.view.View view, object data, string textRepresentation);
		}

		/// <summary>
		/// <p>An array filters constrains the content of the array adapter with
		/// a prefix.
		/// </summary>
		/// <remarks>
		/// <p>An array filters constrains the content of the array adapter with
		/// a prefix. Each item that does not start with the supplied prefix
		/// is removed from the list.</p>
		/// </remarks>
		private class SimpleFilter : android.widget.Filter
		{
			[Sharpen.OverridesMethod(@"android.widget.Filter")]
			internal override android.widget.Filter.FilterResults performFiltering(java.lang.CharSequence
				 prefix)
			{
				android.widget.Filter.FilterResults results = new android.widget.Filter.FilterResults
					();
				if (this._enclosing.mUnfilteredData == null)
				{
					this._enclosing.mUnfilteredData = new java.util.ArrayList<java.util.Map<string, object
						>>(this._enclosing.mData);
				}
				if (prefix == null || prefix.Length == 0)
				{
					java.util.ArrayList<java.util.Map<string, object>> list = this._enclosing.mUnfilteredData;
					results.values = list;
					results.count = list.size();
				}
				else
				{
					string prefixString = prefix.ToString().ToLower();
					java.util.ArrayList<java.util.Map<string, object>> unfilteredValues = this._enclosing
						.mUnfilteredData;
					int count = unfilteredValues.size();
					java.util.ArrayList<java.util.Map<string, object>> newValues = new java.util.ArrayList
						<java.util.Map<string, object>>(count);
					{
						for (int i = 0; i < count; i++)
						{
							java.util.Map<string, object> h = unfilteredValues.get(i);
							if (h != null)
							{
								int len = this._enclosing.mTo.Length;
								{
									for (int j = 0; j < len; j++)
									{
										string str = (string)h.get(this._enclosing.mFrom[j]);
										string[] words = XobotOS.Runtime.Util.SplitStringRegex(str, " ");
										int wordCount = words.Length;
										{
											for (int k = 0; k < wordCount; k++)
											{
												string word = words[k];
												if (word.ToLower().StartsWith(prefixString))
												{
													newValues.add(h);
													break;
												}
											}
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
				this._enclosing.mData = (java.util.List<java.util.Map<string, object>>)results.values;
				if (results.count > 0)
				{
					this._enclosing.notifyDataSetChanged();
				}
				else
				{
					this._enclosing.notifyDataSetInvalidated();
				}
			}

			internal SimpleFilter(SimpleAdapter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly SimpleAdapter _enclosing;
		}
	}
}
