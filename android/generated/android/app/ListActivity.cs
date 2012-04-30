using Sharpen;

namespace android.app
{
	/// <summary>
	/// An activity that displays a list of items by binding to a data source such as
	/// an array or Cursor, and exposes event handlers when the user selects an item.
	/// </summary>
	/// <remarks>
	/// An activity that displays a list of items by binding to a data source such as
	/// an array or Cursor, and exposes event handlers when the user selects an item.
	/// <p>
	/// ListActivity hosts a
	/// <see cref="android.widget.ListView">ListView</see>
	/// object that can
	/// be bound to different data sources, typically either an array or a Cursor
	/// holding query results. Binding, screen layout, and row layout are discussed
	/// in the following sections.
	/// <p>
	/// <strong>Screen Layout</strong>
	/// </p>
	/// <p>
	/// ListActivity has a default layout that consists of a single, full-screen list
	/// in the center of the screen. However, if you desire, you can customize the
	/// screen layout by setting your own view layout with setContentView() in
	/// onCreate(). To do this, your own view MUST contain a ListView object with the
	/// id "@android:id/list" (or
	/// <see cref="android.R.id.list">android.R.id.list</see>
	/// if it's in code)
	/// <p>
	/// Optionally, your custom view can contain another view object of any type to
	/// display when the list view is empty. This "empty list" notifier must have an
	/// id "android:id/empty". Note that when an empty view is present, the list view
	/// will be hidden when there is no data to display.
	/// <p>
	/// The following code demonstrates an (ugly) custom screen layout. It has a list
	/// with a green background, and an alternate red "no data" message.
	/// </p>
	/// <pre>
	/// &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
	/// &lt;LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
	/// android:orientation=&quot;vertical&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;match_parent&quot;
	/// android:paddingLeft=&quot;8dp&quot;
	/// android:paddingRight=&quot;8dp&quot;&gt;
	/// &lt;ListView android:id=&quot;@android:id/list&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;match_parent&quot;
	/// android:background=&quot;#00FF00&quot;
	/// android:layout_weight=&quot;1&quot;
	/// android:drawSelectorOnTop=&quot;false&quot;/&gt;
	/// &lt;TextView android:id=&quot;@android:id/empty&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;match_parent&quot;
	/// android:background=&quot;#FF0000&quot;
	/// android:text=&quot;No data&quot;/&gt;
	/// &lt;/LinearLayout&gt;
	/// </pre>
	/// <p>
	/// <strong>Row Layout</strong>
	/// </p>
	/// <p>
	/// You can specify the layout of individual rows in the list. You do this by
	/// specifying a layout resource in the ListAdapter object hosted by the activity
	/// (the ListAdapter binds the ListView to the data; more on this later).
	/// <p>
	/// A ListAdapter constructor takes a parameter that specifies a layout resource
	/// for each row. It also has two additional parameters that let you specify
	/// which data field to associate with which object in the row layout resource.
	/// These two parameters are typically parallel arrays.
	/// </p>
	/// <p>
	/// Android provides some standard row layout resources. These are in the
	/// <see cref="android.R.layout">android.R.layout</see>
	/// class, and have names such as simple_list_item_1,
	/// simple_list_item_2, and two_line_list_item. The following layout XML is the
	/// source for the resource two_line_list_item, which displays two data
	/// fields,one above the other, for each list row.
	/// </p>
	/// <pre>
	/// &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
	/// &lt;LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;wrap_content&quot;
	/// android:orientation=&quot;vertical&quot;&gt;
	/// &lt;TextView android:id=&quot;@+id/text1&quot;
	/// android:textSize=&quot;16sp&quot;
	/// android:textStyle=&quot;bold&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;wrap_content&quot;/&gt;
	/// &lt;TextView android:id=&quot;@+id/text2&quot;
	/// android:textSize=&quot;16sp&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;wrap_content&quot;/&gt;
	/// &lt;/LinearLayout&gt;
	/// </pre>
	/// <p>
	/// You must identify the data bound to each TextView object in this layout. The
	/// syntax for this is discussed in the next section.
	/// </p>
	/// <p>
	/// <strong>Binding to Data</strong>
	/// </p>
	/// <p>
	/// You bind the ListActivity's ListView object to data using a class that
	/// implements the
	/// <see cref="android.widget.ListAdapter">ListAdapter</see>
	/// interface.
	/// Android provides two standard list adapters:
	/// <see cref="android.widget.SimpleAdapter">SimpleAdapter</see>
	/// for static data (Maps),
	/// and
	/// <see cref="android.widget.SimpleCursorAdapter">SimpleCursorAdapter</see>
	/// for Cursor
	/// query results.
	/// </p>
	/// <p>
	/// The following code from a custom ListActivity demonstrates querying the
	/// Contacts provider for all contacts, then binding the Name and Company fields
	/// to a two line row layout in the activity's ListView.
	/// </p>
	/// <pre>
	/// public class MyListAdapter extends ListActivity {
	/// &#064;Override
	/// protected void onCreate(Bundle savedInstanceState){
	/// super.onCreate(savedInstanceState);
	/// // We'll define a custom screen layout here (the one shown above), but
	/// // typically, you could just use the standard ListActivity layout.
	/// setContentView(R.layout.custom_list_activity_view);
	/// // Query for all people contacts using the
	/// <see cref="android.provider.Contacts.People">android.provider.Contacts.People</see>
	/// convenience class.
	/// // Put a managed wrapper around the retrieved cursor so we don't have to worry about
	/// // requerying or closing it as the activity changes state.
	/// mCursor = this.getContentResolver().query(People.CONTENT_URI, null, null, null, null);
	/// startManagingCursor(mCursor);
	/// // Now create a new list adapter bound to the cursor.
	/// // SimpleListAdapter is designed for binding to a Cursor.
	/// ListAdapter adapter = new SimpleCursorAdapter(
	/// this, // Context.
	/// android.R.layout.two_line_list_item,  // Specify the row template to use (here, two columns bound to the two retrieved cursor
	/// rows).
	/// mCursor,                                              // Pass in the cursor to bind to.
	/// new String[] {People.NAME, People.COMPANY},           // Array of cursor columns to bind to.
	/// new int[] {android.R.id.text1, android.R.id.text2});  // Parallel array of which template objects to bind to those columns.
	/// // Bind to our new adapter.
	/// setListAdapter(adapter);
	/// }
	/// }
	/// </pre>
	/// </remarks>
	/// <seealso cref="setListAdapter(android.widget.ListAdapter)">setListAdapter(android.widget.ListAdapter)
	/// 	</seealso>
	/// <seealso cref="android.widget.ListView">android.widget.ListView</seealso>
	[Sharpen.Sharpened]
	public class ListActivity : android.app.Activity
	{
		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.widget.ListAdapter mAdapter;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal android.widget.ListView mList;

		private android.os.Handler mHandler = new android.os.Handler();

		private bool mFinishedStart = false;

		private sealed class _Runnable_190 : java.lang.Runnable
		{
			public _Runnable_190(ListActivity _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mList.focusableViewAvailable(this._enclosing.mList);
			}

			private readonly ListActivity _enclosing;
		}

		private java.lang.Runnable mRequestFocus;

		/// <summary>This method will be called when an item in the list is selected.</summary>
		/// <remarks>
		/// This method will be called when an item in the list is selected.
		/// Subclasses should override. Subclasses can call
		/// getListView().getItemAtPosition(position) if they need to access the
		/// data associated with the selected item.
		/// </remarks>
		/// <param name="l">The ListView where the click happened</param>
		/// <param name="v">The view that was clicked within the ListView</param>
		/// <param name="position">The position of the view in the list</param>
		/// <param name="id">The row id of the item that was clicked</param>
		protected internal virtual void onListItemClick(android.widget.ListView l, android.view.View
			 v, int position, long id)
		{
		}

		/// <summary>
		/// Ensures the list view has been created before Activity restores all
		/// of the view states.
		/// </summary>
		/// <remarks>
		/// Ensures the list view has been created before Activity restores all
		/// of the view states.
		/// </remarks>
		/// <seealso cref="Activity.onRestoreInstanceState(android.os.Bundle)">Activity.onRestoreInstanceState(android.os.Bundle)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onRestoreInstanceState(android.os.Bundle state)
		{
			ensureList();
			base.onRestoreInstanceState(state);
		}

		/// <seealso cref="Activity.onDestroy()">Activity.onDestroy()</seealso>
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onDestroy()
		{
			mHandler.removeCallbacks(mRequestFocus);
			base.onDestroy();
		}

		/// <summary>
		/// Updates the screen state (current list and other views) when the
		/// content changes.
		/// </summary>
		/// <remarks>
		/// Updates the screen state (current list and other views) when the
		/// content changes.
		/// </remarks>
		/// <seealso cref="Activity.onContentChanged()">Activity.onContentChanged()</seealso>
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onContentChanged()
		{
			base.onContentChanged();
			android.view.View emptyView = findViewById(android.@internal.R.id.empty);
			mList = (android.widget.ListView)findViewById(android.@internal.R.id.list);
			if (mList == null)
			{
				throw new java.lang.RuntimeException("Your content must have a ListView whose id attribute is "
					 + "'android.R.id.list'");
			}
			if (emptyView != null)
			{
				mList.setEmptyView(emptyView);
			}
			mList.setOnItemClickListener(mOnClickListener);
			if (mFinishedStart)
			{
				setListAdapter(mAdapter);
			}
			mHandler.post(mRequestFocus);
			mFinishedStart = true;
		}

		/// <summary>Provide the cursor for the list view.</summary>
		/// <remarks>Provide the cursor for the list view.</remarks>
		public virtual void setListAdapter(android.widget.ListAdapter adapter)
		{
			lock (this)
			{
				ensureList();
				mAdapter = adapter;
				mList.setAdapter(adapter);
			}
		}

		/// <summary>
		/// Set the currently selected list item to the specified
		/// position with the adapter's data
		/// </summary>
		/// <param name="position"></param>
		public virtual void setSelection(int position)
		{
			mList.setSelection(position);
		}

		/// <summary>Get the position of the currently selected list item.</summary>
		/// <remarks>Get the position of the currently selected list item.</remarks>
		public virtual int getSelectedItemPosition()
		{
			return mList.getSelectedItemPosition();
		}

		/// <summary>Get the cursor row ID of the currently selected list item.</summary>
		/// <remarks>Get the cursor row ID of the currently selected list item.</remarks>
		public virtual long getSelectedItemId()
		{
			return mList.getSelectedItemId();
		}

		/// <summary>Get the activity's list view widget.</summary>
		/// <remarks>Get the activity's list view widget.</remarks>
		public virtual android.widget.ListView getListView()
		{
			ensureList();
			return mList;
		}

		/// <summary>Get the ListAdapter associated with this activity's ListView.</summary>
		/// <remarks>Get the ListAdapter associated with this activity's ListView.</remarks>
		public virtual android.widget.ListAdapter getListAdapter()
		{
			return mAdapter;
		}

		private void ensureList()
		{
			if (mList != null)
			{
				return;
			}
			setContentView(android.@internal.R.layout.list_content_simple);
		}

		private sealed class _OnItemClickListener_316 : android.widget.AdapterView.OnItemClickListener
		{
			public _OnItemClickListener_316(ListActivity _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public void onItemClick(object parent, android.view.View v, int position, long id
				)
			{
				this._enclosing.onListItemClick((android.widget.ListView)parent, v, position, id);
			}

			private readonly ListActivity _enclosing;
		}

		private android.widget.AdapterView.OnItemClickListener mOnClickListener;

		public ListActivity()
		{
			mRequestFocus = new _Runnable_190(this);
			mOnClickListener = new _OnItemClickListener_316(this);
		}
	}
}
