using Sharpen;

namespace android.app
{
	/// <summary>
	/// A fragment that displays a list of items by binding to a data source such as
	/// an array or Cursor, and exposes event handlers when the user selects an item.
	/// </summary>
	/// <remarks>
	/// A fragment that displays a list of items by binding to a data source such as
	/// an array or Cursor, and exposes event handlers when the user selects an item.
	/// <p>
	/// ListFragment hosts a
	/// <see cref="android.widget.ListView">ListView</see>
	/// object that can
	/// be bound to different data sources, typically either an array or a Cursor
	/// holding query results. Binding, screen layout, and row layout are discussed
	/// in the following sections.
	/// <p>
	/// <strong>Screen Layout</strong>
	/// </p>
	/// <p>
	/// ListFragment has a default layout that consists of a single list view.
	/// However, if you desire, you can customize the fragment layout by returning
	/// your own view hierarchy from
	/// <see cref="onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
	/// 	">onCreateView(android.view.LayoutInflater, android.view.ViewGroup, android.os.Bundle)
	/// 	</see>
	/// .
	/// To do this, your view hierarchy <em>must</em> contain a ListView object with the
	/// id "@android:id/list" (or
	/// <see cref="android.R.id.list">android.R.id.list</see>
	/// if it's in code)
	/// <p>
	/// Optionally, your view hierarchy can contain another view object of any type to
	/// display when the list view is empty. This "empty list" notifier must have an
	/// id "android:empty". Note that when an empty view is present, the list view
	/// will be hidden when there is no data to display.
	/// <p>
	/// The following code demonstrates an (ugly) custom list layout. It has a list
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
	/// &lt;ListView android:id=&quot;@id/android:list&quot;
	/// android:layout_width=&quot;match_parent&quot;
	/// android:layout_height=&quot;match_parent&quot;
	/// android:background=&quot;#00FF00&quot;
	/// android:layout_weight=&quot;1&quot;
	/// android:drawSelectorOnTop=&quot;false&quot;/&gt;
	/// &lt;TextView android:id=&quot;@id/android:empty&quot;
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
	/// specifying a layout resource in the ListAdapter object hosted by the fragment
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
	/// You bind the ListFragment's ListView object to data using a class that
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
	/// You <b>must</b> use
	/// <see cref="setListAdapter(android.widget.ListAdapter)">ListFragment.setListAdapter()
	/// 	</see>
	/// to
	/// associate the list with an adapter.  Do not directly call
	/// <see cref="android.widget.ListView.setAdapter(android.widget.ListAdapter)">ListView.setAdapter()
	/// 	</see>
	/// or else
	/// important initialization will be skipped.
	/// </p>
	/// </remarks>
	/// <seealso cref="setListAdapter(android.widget.ListAdapter)">setListAdapter(android.widget.ListAdapter)
	/// 	</seealso>
	/// <seealso cref="android.widget.ListView">android.widget.ListView</seealso>
	[Sharpen.Sharpened]
	public class ListFragment : android.app.Fragment
	{
		private readonly android.os.Handler mHandler = new android.os.Handler();

		private sealed class _Runnable_151 : java.lang.Runnable
		{
			public _Runnable_151(ListFragment _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				this._enclosing.mList.focusableViewAvailable(this._enclosing.mList);
			}

			private readonly ListFragment _enclosing;
		}

		private readonly java.lang.Runnable mRequestFocus;

		private sealed class _OnItemClickListener_158 : android.widget.AdapterView.OnItemClickListener
		{
			public _OnItemClickListener_158(ListFragment _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public void onItemClick(object parent, android.view.View v, int position, long id
				)
			{
				this._enclosing.onListItemClick((android.widget.ListView)parent, v, position, id);
			}

			private readonly ListFragment _enclosing;
		}

		private readonly android.widget.AdapterView.OnItemClickListener mOnClickListener;

		internal android.widget.ListAdapter mAdapter;

		internal android.widget.ListView mList;

		internal android.view.View mEmptyView;

		internal android.widget.TextView mStandardEmptyView;

		internal android.view.View mProgressContainer;

		internal android.view.View mListContainer;

		internal java.lang.CharSequence mEmptyText;

		internal bool mListShown;

		public ListFragment()
		{
			mRequestFocus = new _Runnable_151(this);
			mOnClickListener = new _OnItemClickListener_158(this);
		}

		/// <summary>Provide default implementation to return a simple list view.</summary>
		/// <remarks>
		/// Provide default implementation to return a simple list view.  Subclasses
		/// can override to replace with their own layout.  If doing so, the
		/// returned view hierarchy <em>must</em> have a ListView whose id
		/// is
		/// <see cref="android.R.id.list">android.R.id.list</see>
		/// and can optionally
		/// have a sibling view id
		/// <see cref="android.R.id.empty">android.R.id.empty</see>
		/// that is to be shown when the list is empty.
		/// <p>If you are overriding this method with your own custom content,
		/// consider including the standard layout
		/// <see cref="android.R.layout.list_content">android.R.layout.list_content</see>
		/// in your layout file, so that you continue to retain all of the standard
		/// behavior of ListFragment.  In particular, this is currently the only
		/// way to have the built-in indeterminant progress state be shown.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override android.view.View onCreateView(android.view.LayoutInflater inflater
			, android.view.ViewGroup container, android.os.Bundle savedInstanceState)
		{
			return inflater.inflate(android.@internal.R.layout.list_content, container, false
				);
		}

		/// <summary>Attach to list view once the view hierarchy has been created.</summary>
		/// <remarks>Attach to list view once the view hierarchy has been created.</remarks>
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onViewCreated(android.view.View view, android.os.Bundle savedInstanceState
			)
		{
			base.onViewCreated(view, savedInstanceState);
			ensureList();
		}

		/// <summary>Detach from list view.</summary>
		/// <remarks>Detach from list view.</remarks>
		[Sharpen.OverridesMethod(@"android.app.Fragment")]
		public override void onDestroyView()
		{
			mHandler.removeCallbacks(mRequestFocus);
			mList = null;
			mListShown = false;
			mEmptyView = mProgressContainer = mListContainer = null;
			mStandardEmptyView = null;
			base.onDestroyView();
		}

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
		public virtual void onListItemClick(android.widget.ListView l, android.view.View 
			v, int position, long id)
		{
		}

		/// <summary>Provide the cursor for the list view.</summary>
		/// <remarks>Provide the cursor for the list view.</remarks>
		public virtual void setListAdapter(android.widget.ListAdapter adapter)
		{
			bool hadAdapter = mAdapter != null;
			mAdapter = adapter;
			if (mList != null)
			{
				mList.setAdapter(adapter);
				if (!mListShown && !hadAdapter)
				{
					// The list was hidden, and previously didn't have an
					// adapter.  It is now time to show it.
					setListShown(true, getView().getWindowToken() != null);
				}
			}
		}

		/// <summary>
		/// Set the currently selected list item to the specified
		/// position with the adapter's data
		/// </summary>
		/// <param name="position"></param>
		public virtual void setSelection(int position)
		{
			ensureList();
			mList.setSelection(position);
		}

		/// <summary>Get the position of the currently selected list item.</summary>
		/// <remarks>Get the position of the currently selected list item.</remarks>
		public virtual int getSelectedItemPosition()
		{
			ensureList();
			return mList.getSelectedItemPosition();
		}

		/// <summary>Get the cursor row ID of the currently selected list item.</summary>
		/// <remarks>Get the cursor row ID of the currently selected list item.</remarks>
		public virtual long getSelectedItemId()
		{
			ensureList();
			return mList.getSelectedItemId();
		}

		/// <summary>Get the activity's list view widget.</summary>
		/// <remarks>Get the activity's list view widget.</remarks>
		public virtual android.widget.ListView getListView()
		{
			ensureList();
			return mList;
		}

		/// <summary>
		/// The default content for a ListFragment has a TextView that can
		/// be shown when the list is empty.
		/// </summary>
		/// <remarks>
		/// The default content for a ListFragment has a TextView that can
		/// be shown when the list is empty.  If you would like to have it
		/// shown, call this method to supply the text it should use.
		/// </remarks>
		public virtual void setEmptyText(java.lang.CharSequence text)
		{
			ensureList();
			if (mStandardEmptyView == null)
			{
				throw new System.InvalidOperationException("Can't be used with a custom content view"
					);
			}
			mStandardEmptyView.setText(text);
			if (mEmptyText == null)
			{
				mList.setEmptyView(mStandardEmptyView);
			}
			mEmptyText = text;
		}

		/// <summary>Control whether the list is being displayed.</summary>
		/// <remarks>
		/// Control whether the list is being displayed.  You can make it not
		/// displayed if you are waiting for the initial data to show in it.  During
		/// this time an indeterminant progress indicator will be shown instead.
		/// <p>Applications do not normally need to use this themselves.  The default
		/// behavior of ListFragment is to start with the list not being shown, only
		/// showing it once an adapter is given with
		/// <see cref="setListAdapter(android.widget.ListAdapter)">setListAdapter(android.widget.ListAdapter)
		/// 	</see>
		/// .
		/// If the list at that point had not been shown, when it does get shown
		/// it will be do without the user ever seeing the hidden state.
		/// </remarks>
		/// <param name="shown">
		/// If true, the list view is shown; if false, the progress
		/// indicator.  The initial value is true.
		/// </param>
		public virtual void setListShown(bool shown)
		{
			setListShown(shown, true);
		}

		/// <summary>
		/// Like
		/// <see cref="setListShown(bool)">setListShown(bool)</see>
		/// , but no animation is used when
		/// transitioning from the previous state.
		/// </summary>
		public virtual void setListShownNoAnimation(bool shown)
		{
			setListShown(shown, false);
		}

		/// <summary>Control whether the list is being displayed.</summary>
		/// <remarks>
		/// Control whether the list is being displayed.  You can make it not
		/// displayed if you are waiting for the initial data to show in it.  During
		/// this time an indeterminant progress indicator will be shown instead.
		/// </remarks>
		/// <param name="shown">
		/// If true, the list view is shown; if false, the progress
		/// indicator.  The initial value is true.
		/// </param>
		/// <param name="animate">
		/// If true, an animation will be used to transition to the
		/// new state.
		/// </param>
		private void setListShown(bool shown, bool animate)
		{
			ensureList();
			if (mProgressContainer == null)
			{
				throw new System.InvalidOperationException("Can't be used with a custom content view"
					);
			}
			if (mListShown == shown)
			{
				return;
			}
			mListShown = shown;
			if (shown)
			{
				if (animate)
				{
					mProgressContainer.startAnimation(android.view.animation.AnimationUtils.loadAnimation
						(getActivity(), android.R.anim.fade_out));
					mListContainer.startAnimation(android.view.animation.AnimationUtils.loadAnimation
						(getActivity(), android.R.anim.fade_in));
				}
				else
				{
					mProgressContainer.clearAnimation();
					mListContainer.clearAnimation();
				}
				mProgressContainer.setVisibility(android.view.View.GONE);
				mListContainer.setVisibility(android.view.View.VISIBLE);
			}
			else
			{
				if (animate)
				{
					mProgressContainer.startAnimation(android.view.animation.AnimationUtils.loadAnimation
						(getActivity(), android.R.anim.fade_in));
					mListContainer.startAnimation(android.view.animation.AnimationUtils.loadAnimation
						(getActivity(), android.R.anim.fade_out));
				}
				else
				{
					mProgressContainer.clearAnimation();
					mListContainer.clearAnimation();
				}
				mProgressContainer.setVisibility(android.view.View.VISIBLE);
				mListContainer.setVisibility(android.view.View.GONE);
			}
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
			android.view.View root = getView();
			if (root == null)
			{
				throw new System.InvalidOperationException("Content view not yet created");
			}
			if (root is android.widget.ListView)
			{
				mList = (android.widget.ListView)root;
			}
			else
			{
				mStandardEmptyView = (android.widget.TextView)root.findViewById(android.@internal.R
					.id.internalEmpty);
				if (mStandardEmptyView == null)
				{
					mEmptyView = root.findViewById(android.R.id.empty);
				}
				else
				{
					mStandardEmptyView.setVisibility(android.view.View.GONE);
				}
				mProgressContainer = root.findViewById(android.@internal.R.id.progressContainer);
				mListContainer = root.findViewById(android.@internal.R.id.listContainer);
				android.view.View rawListView = root.findViewById(android.R.id.list);
				if (!(rawListView is android.widget.ListView))
				{
					throw new java.lang.RuntimeException("Content has view with id attribute 'android.R.id.list' "
						 + "that is not a ListView class");
				}
				mList = (android.widget.ListView)rawListView;
				if (mList == null)
				{
					throw new java.lang.RuntimeException("Your content must have a ListView whose id attribute is "
						 + "'android.R.id.list'");
				}
				if (mEmptyView != null)
				{
					mList.setEmptyView(mEmptyView);
				}
				else
				{
					if (mEmptyText != null)
					{
						mStandardEmptyView.setText(mEmptyText);
						mList.setEmptyView(mStandardEmptyView);
					}
				}
			}
			mListShown = true;
			mList.setOnItemClickListener(mOnClickListener);
			if (mAdapter != null)
			{
				android.widget.ListAdapter adapter = mAdapter;
				mAdapter = null;
				setListAdapter(adapter);
			}
			else
			{
				// We are starting without an adapter, so assume we won't
				// have our data right away and start with the progress indicator.
				if (mProgressContainer != null)
				{
					setListShown(false, false);
				}
			}
			mHandler.post(mRequestFocus);
		}
	}
}
