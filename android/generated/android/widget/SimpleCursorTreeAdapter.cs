using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An easy adapter to map columns from a cursor to TextViews or ImageViews
	/// defined in an XML file.
	/// </summary>
	/// <remarks>
	/// An easy adapter to map columns from a cursor to TextViews or ImageViews
	/// defined in an XML file. You can specify which columns you want, which views
	/// you want to display the columns, and the XML file that defines the appearance
	/// of these views. Separate XML files for child and groups are possible.
	/// Binding occurs in two phases. First, if a
	/// <see cref="ViewBinder">ViewBinder</see>
	/// is available,
	/// <see cref="ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)
	/// 	">ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)</see>
	/// is invoked. If the returned value is true, binding has occurred. If the
	/// returned value is false and the view to bind is a TextView,
	/// <see cref="setViewText(TextView, string)">setViewText(TextView, string)</see>
	/// is invoked. If the returned value
	/// is false and the view to bind is an ImageView,
	/// <see cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</see>
	/// is invoked. If no appropriate
	/// binding can be found, an
	/// <see cref="System.InvalidOperationException">System.InvalidOperationException</see>
	/// is thrown.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class SimpleCursorTreeAdapter : android.widget.ResourceCursorTreeAdapter
	{
		/// <summary>The name of the columns that contain the data to display for a group.</summary>
		/// <remarks>The name of the columns that contain the data to display for a group.</remarks>
		private string[] mGroupFromNames;

		/// <summary>The indices of columns that contain data to display for a group.</summary>
		/// <remarks>The indices of columns that contain data to display for a group.</remarks>
		private int[] mGroupFrom;

		/// <summary>
		/// The View IDs that will display a group's data fetched from the
		/// corresponding column.
		/// </summary>
		/// <remarks>
		/// The View IDs that will display a group's data fetched from the
		/// corresponding column.
		/// </remarks>
		private int[] mGroupTo;

		/// <summary>The name of the columns that contain the data to display for a child.</summary>
		/// <remarks>The name of the columns that contain the data to display for a child.</remarks>
		private string[] mChildFromNames;

		/// <summary>The indices of columns that contain data to display for a child.</summary>
		/// <remarks>The indices of columns that contain data to display for a child.</remarks>
		private int[] mChildFrom;

		/// <summary>
		/// The View IDs that will display a child's data fetched from the
		/// corresponding column.
		/// </summary>
		/// <remarks>
		/// The View IDs that will display a child's data fetched from the
		/// corresponding column.
		/// </remarks>
		private int[] mChildTo;

		/// <summary>View binder, if supplied</summary>
		private android.widget.SimpleCursorTreeAdapter.ViewBinder mViewBinder;

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the
		/// <see cref="ExpandableListView">ExpandableListView</see>
		/// associated with this
		/// <see cref="SimpleCursorTreeAdapter">SimpleCursorTreeAdapter</see>
		/// is
		/// running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="collapsedGroupLayout">
		/// The resource identifier of a layout file that
		/// defines the views for a collapsed group. The layout file
		/// should include at least those named views defined in groupTo.
		/// </param>
		/// <param name="expandedGroupLayout">
		/// The resource identifier of a layout file that
		/// defines the views for an expanded group. The layout file
		/// should include at least those named views defined in groupTo.
		/// </param>
		/// <param name="groupFrom">
		/// A list of column names that will be used to display the
		/// data for a group.
		/// </param>
		/// <param name="groupTo">
		/// The group views (from the group layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		/// <param name="childLayout">
		/// The resource identifier of a layout file that defines
		/// the views for a child (except the last). The layout file
		/// should include at least those named views defined in childTo.
		/// </param>
		/// <param name="lastChildLayout">
		/// The resource identifier of a layout file that
		/// defines the views for the last child within a group. The
		/// layout file should include at least those named views defined
		/// in childTo.
		/// </param>
		/// <param name="childFrom">
		/// A list of column names that will be used to display the
		/// data for a child.
		/// </param>
		/// <param name="childTo">
		/// The child views (from the child layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		public SimpleCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int collapsedGroupLayout, int expandedGroupLayout, string[] groupFrom, 
			int[] groupTo, int childLayout, int lastChildLayout, string[] childFrom, int[] childTo
			) : base(context, cursor, collapsedGroupLayout, expandedGroupLayout, childLayout
			, lastChildLayout)
		{
			init(groupFrom, groupTo, childFrom, childTo);
		}

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the
		/// <see cref="ExpandableListView">ExpandableListView</see>
		/// associated with this
		/// <see cref="SimpleCursorTreeAdapter">SimpleCursorTreeAdapter</see>
		/// is
		/// running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="collapsedGroupLayout">
		/// The resource identifier of a layout file that
		/// defines the views for a collapsed group. The layout file
		/// should include at least those named views defined in groupTo.
		/// </param>
		/// <param name="expandedGroupLayout">
		/// The resource identifier of a layout file that
		/// defines the views for an expanded group. The layout file
		/// should include at least those named views defined in groupTo.
		/// </param>
		/// <param name="groupFrom">
		/// A list of column names that will be used to display the
		/// data for a group.
		/// </param>
		/// <param name="groupTo">
		/// The group views (from the group layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		/// <param name="childLayout">
		/// The resource identifier of a layout file that defines
		/// the views for a child. The layout file
		/// should include at least those named views defined in childTo.
		/// </param>
		/// <param name="childFrom">
		/// A list of column names that will be used to display the
		/// data for a child.
		/// </param>
		/// <param name="childTo">
		/// The child views (from the child layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		public SimpleCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int collapsedGroupLayout, int expandedGroupLayout, string[] groupFrom, 
			int[] groupTo, int childLayout, string[] childFrom, int[] childTo) : base(context
			, cursor, collapsedGroupLayout, expandedGroupLayout, childLayout)
		{
			init(groupFrom, groupTo, childFrom, childTo);
		}

		/// <summary>Constructor.</summary>
		/// <remarks>Constructor.</remarks>
		/// <param name="context">
		/// The context where the
		/// <see cref="ExpandableListView">ExpandableListView</see>
		/// associated with this
		/// <see cref="SimpleCursorTreeAdapter">SimpleCursorTreeAdapter</see>
		/// is
		/// running
		/// </param>
		/// <param name="cursor">The database cursor</param>
		/// <param name="groupLayout">
		/// The resource identifier of a layout file that defines
		/// the views for a group. The layout file should include at least
		/// those named views defined in groupTo.
		/// </param>
		/// <param name="groupFrom">
		/// A list of column names that will be used to display the
		/// data for a group.
		/// </param>
		/// <param name="groupTo">
		/// The group views (from the group layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		/// <param name="childLayout">
		/// The resource identifier of a layout file that defines
		/// the views for a child. The layout file should include at least
		/// those named views defined in childTo.
		/// </param>
		/// <param name="childFrom">
		/// A list of column names that will be used to display the
		/// data for a child.
		/// </param>
		/// <param name="childTo">
		/// The child views (from the child layouts) that should
		/// display column in the "from" parameter. These should all be
		/// TextViews or ImageViews. The first N views in this list are
		/// given the values of the first N columns in the from parameter.
		/// </param>
		public SimpleCursorTreeAdapter(android.content.Context context, android.database.Cursor
			 cursor, int groupLayout, string[] groupFrom, int[] groupTo, int childLayout, string
			[] childFrom, int[] childTo) : base(context, cursor, groupLayout, childLayout)
		{
			init(groupFrom, groupTo, childFrom, childTo);
		}

		private void init(string[] groupFromNames, int[] groupTo, string[] childFromNames
			, int[] childTo)
		{
			mGroupFromNames = groupFromNames;
			mGroupTo = groupTo;
			mChildFromNames = childFromNames;
			mChildTo = childTo;
		}

		/// <summary>
		/// Returns the
		/// <see cref="ViewBinder">ViewBinder</see>
		/// used to bind data to views.
		/// </summary>
		/// <returns>a ViewBinder or null if the binder does not exist</returns>
		/// <seealso cref="setViewBinder(ViewBinder)">setViewBinder(ViewBinder)</seealso>
		public virtual android.widget.SimpleCursorTreeAdapter.ViewBinder getViewBinder()
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
		public virtual void setViewBinder(android.widget.SimpleCursorTreeAdapter.ViewBinder
			 viewBinder)
		{
			mViewBinder = viewBinder;
		}

		private void bindView(android.view.View view, android.content.Context context, android.database.Cursor
			 cursor, int[] from, int[] to)
		{
			android.widget.SimpleCursorTreeAdapter.ViewBinder binder = mViewBinder;
			{
				for (int i = 0; i < to.Length; i++)
				{
					android.view.View v = view.findViewById(to[i]);
					if (v != null)
					{
						bool bound = false;
						if (binder != null)
						{
							bound = binder.setViewValue(v, cursor, from[i]);
						}
						if (!bound)
						{
							string text = cursor.getString(from[i]);
							if (text == null)
							{
								text = string.Empty;
							}
							if (v is android.widget.TextView)
							{
								setViewText((android.widget.TextView)v, text);
							}
							else
							{
								if (v is android.widget.ImageView)
								{
									setViewImage((android.widget.ImageView)v, text);
								}
								else
								{
									throw new System.InvalidOperationException("SimpleCursorTreeAdapter can bind values"
										 + " only to TextView and ImageView!");
								}
							}
						}
					}
				}
			}
		}

		private void initFromColumns(android.database.Cursor cursor, string[] fromColumnNames
			, int[] fromColumns)
		{
			{
				for (int i = fromColumnNames.Length - 1; i >= 0; i--)
				{
					fromColumns[i] = cursor.getColumnIndexOrThrow(fromColumnNames[i]);
				}
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorTreeAdapter")]
		protected internal override void bindChildView(android.view.View view, android.content.Context
			 context, android.database.Cursor cursor, bool isLastChild)
		{
			if (mChildFrom == null)
			{
				mChildFrom = new int[mChildFromNames.Length];
				initFromColumns(cursor, mChildFromNames, mChildFrom);
			}
			bindView(view, context, cursor, mChildFrom, mChildTo);
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorTreeAdapter")]
		protected internal override void bindGroupView(android.view.View view, android.content.Context
			 context, android.database.Cursor cursor, bool isExpanded)
		{
			if (mGroupFrom == null)
			{
				mGroupFrom = new int[mGroupFromNames.Length];
				initFromColumns(cursor, mGroupFromNames, mGroupFrom);
			}
			bindView(view, context, cursor, mGroupFrom, mGroupTo);
		}

		/// <summary>Called by bindView() to set the image for an ImageView.</summary>
		/// <remarks>
		/// Called by bindView() to set the image for an ImageView. By default, the
		/// value will be treated as a Uri. Intended to be overridden by Adapters
		/// that need to filter strings retrieved from the database.
		/// </remarks>
		/// <param name="v">ImageView to receive an image</param>
		/// <param name="value">the value retrieved from the cursor</param>
		protected internal virtual void setViewImage(android.widget.ImageView v, string value
			)
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
		/// Intended to be overridden by Adapters that need to filter strings
		/// retrieved from the database.
		/// </remarks>
		/// <param name="v">TextView to receive text</param>
		/// <param name="text">the text to be set for the TextView</param>
		public virtual void setViewText(android.widget.TextView v, string text)
		{
			v.setText(java.lang.CharSequenceProxy.Wrap(text));
		}

		/// <summary>
		/// This class can be used by external clients of SimpleCursorTreeAdapter
		/// to bind values from the Cursor to views.
		/// </summary>
		/// <remarks>
		/// This class can be used by external clients of SimpleCursorTreeAdapter
		/// to bind values from the Cursor to views.
		/// You should use this class to bind values from the Cursor to views
		/// that are not directly supported by SimpleCursorTreeAdapter or to
		/// change the way binding occurs for views supported by
		/// SimpleCursorTreeAdapter.
		/// </remarks>
		/// <seealso cref="SimpleCursorTreeAdapter.setViewImage(ImageView, string)"></seealso>
		/// <seealso cref="SimpleCursorTreeAdapter.setViewText(TextView, string)">SimpleCursorTreeAdapter.setViewText(TextView, string)
		/// 	</seealso>
		public interface ViewBinder
		{
			/// <summary>Binds the Cursor column defined by the specified index to the specified view.
			/// 	</summary>
			/// <remarks>
			/// Binds the Cursor column defined by the specified index to the specified view.
			/// When binding is handled by this ViewBinder, this method must return true.
			/// If this method returns false, SimpleCursorTreeAdapter will attempts to handle
			/// the binding on its own.
			/// </remarks>
			/// <param name="view">the view to bind the data to</param>
			/// <param name="cursor">the cursor to get the data from</param>
			/// <param name="columnIndex">the column at which the data can be found in the cursor
			/// 	</param>
			/// <returns>true if the data was bound to the view, false otherwise</returns>
			bool setViewValue(android.view.View view, android.database.Cursor cursor, int columnIndex
				);
		}
	}
}
