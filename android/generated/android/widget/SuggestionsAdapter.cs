using Sharpen;

namespace android.widget
{
	/// <summary>
	/// Provides the contents for the suggestion drop-down list.in
	/// <see cref="android.app.SearchDialog">android.app.SearchDialog</see>
	/// .
	/// </summary>
	/// <hide></hide>
	[Sharpen.Sharpened]
	internal class SuggestionsAdapter : android.widget.ResourceCursorAdapter, android.view.View
		.OnClickListener
	{
		internal const bool DBG = false;

		internal const string LOG_TAG = "SuggestionsAdapter";

		internal const int QUERY_LIMIT = 50;

		internal const int REFINE_NONE = 0;

		internal const int REFINE_BY_ENTRY = 1;

		internal const int REFINE_ALL = 2;

		private android.app.SearchManager mSearchManager;

		private android.widget.SearchView mSearchView;

		private android.app.SearchableInfo mSearchable;

		private android.content.Context mProviderContext;

		private java.util.WeakHashMap<string, android.graphics.drawable.Drawable.ConstantState
			> mOutsideDrawablesCache;

		private bool mClosed = false;

		private int mQueryRefinement = REFINE_BY_ENTRY;

		private android.content.res.ColorStateList mUrlColor;

		internal const int INVALID_INDEX = -1;

		private int mText1Col = INVALID_INDEX;

		private int mText2Col = INVALID_INDEX;

		private int mText2UrlCol = INVALID_INDEX;

		private int mIconName1Col = INVALID_INDEX;

		private int mIconName2Col = INVALID_INDEX;

		private int mFlagsCol = INVALID_INDEX;

		/// <summary>The amount of time we delay in the filter when the user presses the delete key.
		/// 	</summary>
		/// <remarks>The amount of time we delay in the filter when the user presses the delete key.
		/// 	</remarks>
		/// <seealso>Filter#setDelayer(android.widget.Filter.Delayer).</seealso>
		internal const long DELETE_KEY_POST_DELAY = 500L;

		private sealed class _Delayer_130 : android.widget.Filter.Delayer
		{
			public _Delayer_130()
			{
				this.mPreviousLength = 0;
			}

			private int mPreviousLength;

			// URL color
			// Cached column indexes, updated when the cursor changes.
			// private final Runnable mStartSpinnerRunnable;
			// private final Runnable mStopSpinnerRunnable;
			// no initial cursor
			// auto-requery
			// set up provider resources (gives us icons, etc.)
			// mStartSpinnerRunnable = new Runnable() {
			// public void run() {
			// // mSearchView.setWorking(true); // TODO:
			// }
			// };
			//
			// mStopSpinnerRunnable = new Runnable() {
			// public void run() {
			// // mSearchView.setWorking(false); // TODO:
			// }
			// };
			// delay 500ms when deleting
			[Sharpen.ImplementsInterface(@"android.widget.Filter.Delayer")]
			public long getPostingDelay(java.lang.CharSequence constraint)
			{
				if (constraint == null)
				{
					return 0;
				}
				long delay = constraint.Length < this.mPreviousLength ? android.widget.SuggestionsAdapter
					.DELETE_KEY_POST_DELAY : 0;
				this.mPreviousLength = constraint.Length;
				return delay;
			}
		}

		public SuggestionsAdapter(android.content.Context context, android.widget.SearchView
			 searchView, android.app.SearchableInfo searchable, java.util.WeakHashMap<string
			, android.graphics.drawable.Drawable.ConstantState> outsideDrawablesCache) : base
			(context, android.@internal.R.layout.search_dropdown_item_icons_2line, null, true
			)
		{
			mSearchManager = (android.app.SearchManager)mContext.getSystemService(android.content.Context
				.SEARCH_SERVICE);
			mSearchView = searchView;
			mSearchable = searchable;
			android.content.Context activityContext = mSearchable.getActivityContext(mContext
				);
			mProviderContext = mSearchable.getProviderContext(mContext, activityContext);
			mOutsideDrawablesCache = outsideDrawablesCache;
			getFilter().setDelayer(new _Delayer_130());
		}

		/// <summary>Enables query refinement for all suggestions.</summary>
		/// <remarks>
		/// Enables query refinement for all suggestions. This means that an additional icon
		/// will be shown for each entry. When clicked, the suggested text on that line will be
		/// copied to the query text field.
		/// <p>
		/// </remarks>
		/// <param name="refine">
		/// which queries to refine. Possible values are
		/// <see cref="REFINE_NONE">REFINE_NONE</see>
		/// ,
		/// <see cref="REFINE_BY_ENTRY">REFINE_BY_ENTRY</see>
		/// , and
		/// <see cref="REFINE_ALL">REFINE_ALL</see>
		/// .
		/// </param>
		public virtual void setQueryRefinement(int refineWhat)
		{
			mQueryRefinement = refineWhat;
		}

		/// <summary>Returns the current query refinement preference.</summary>
		/// <remarks>Returns the current query refinement preference.</remarks>
		/// <returns>value of query refinement preference</returns>
		public virtual int getQueryRefinement()
		{
			return mQueryRefinement;
		}

		/// <summary>
		/// Overridden to always return <code>false</code>, since we cannot be sure that
		/// suggestion sources return stable IDs.
		/// </summary>
		/// <remarks>
		/// Overridden to always return <code>false</code>, since we cannot be sure that
		/// suggestion sources return stable IDs.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override bool hasStableIds()
		{
			return false;
		}

		/// <summary>Use the search suggestions provider to obtain a live cursor.</summary>
		/// <remarks>
		/// Use the search suggestions provider to obtain a live cursor.  This will be called
		/// in a worker thread, so it's OK if the query is slow (e.g. round trip for suggestions).
		/// The results will be processed in the UI thread and changeCursor() will be called.
		/// </remarks>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override android.database.Cursor runQueryOnBackgroundThread(java.lang.CharSequence
			 constraint)
		{
			string query = (constraint == null) ? string.Empty : constraint.ToString();
			android.database.Cursor cursor = null;
			//mSearchView.getWindow().getDecorView().post(mStartSpinnerRunnable); // TODO:
			try
			{
				cursor = mSearchManager.getSuggestions(mSearchable, query, QUERY_LIMIT);
				// trigger fill window so the spinner stays up until the results are copied over and
				// closer to being ready
				if (cursor != null)
				{
					cursor.getCount();
					return cursor;
				}
			}
			catch (java.lang.RuntimeException e)
			{
				android.util.Log.w(LOG_TAG, "Search suggestions query threw an exception.", e);
			}
			// If cursor is null or an exception was thrown, stop the spinner and return null.
			// changeCursor doesn't get called if cursor is null
			// mSearchView.getWindow().getDecorView().post(mStopSpinnerRunnable); // TODO:
			return null;
		}

		public virtual void close()
		{
			changeCursor(null);
			mClosed = true;
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override void notifyDataSetChanged()
		{
			base.notifyDataSetChanged();
			// mSearchView.onDataSetChanged(); // TODO:
			updateSpinnerState(getCursor());
		}

		[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
		public override void notifyDataSetInvalidated()
		{
			base.notifyDataSetInvalidated();
			updateSpinnerState(getCursor());
		}

		private void updateSpinnerState(android.database.Cursor cursor)
		{
			android.os.Bundle extras = cursor != null ? cursor.getExtras() : null;
			// Check if the Cursor indicates that the query is not complete and show the spinner
			if (extras != null && extras.getBoolean(android.app.SearchManager.CURSOR_EXTRA_KEY_IN_PROGRESS
				))
			{
				// mSearchView.getWindow().getDecorView().post(mStartSpinnerRunnable); // TODO:
				return;
			}
		}

		// If cursor is null or is done, stop the spinner
		// mSearchView.getWindow().getDecorView().post(mStopSpinnerRunnable); // TODO:
		/// <summary>Cache columns.</summary>
		/// <remarks>Cache columns.</remarks>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override void changeCursor(android.database.Cursor c)
		{
			if (mClosed)
			{
				android.util.Log.w(LOG_TAG, "Tried to change cursor after adapter was closed.");
				if (c != null)
				{
					c.close();
				}
				return;
			}
			try
			{
				base.changeCursor(c);
				if (c != null)
				{
					mText1Col = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_TEXT_1);
					mText2Col = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_TEXT_2);
					mText2UrlCol = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_TEXT_2_URL
						);
					mIconName1Col = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_ICON_1);
					mIconName2Col = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_ICON_2);
					mFlagsCol = c.getColumnIndex(android.app.SearchManager.SUGGEST_COLUMN_FLAGS);
				}
			}
			catch (System.Exception e)
			{
				android.util.Log.e(LOG_TAG, "error changing cursor and caching columns", e);
			}
		}

		/// <summary>Tags the view with cached child view look-ups.</summary>
		/// <remarks>Tags the view with cached child view look-ups.</remarks>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override android.view.View newView(android.content.Context context, android.database.Cursor
			 cursor, android.view.ViewGroup parent)
		{
			android.view.View v = base.newView(context, cursor, parent);
			v.setTag(new android.widget.SuggestionsAdapter.ChildViewCache(v));
			return v;
		}

		/// <summary>
		/// Cache of the child views of drop-drown list items, to avoid looking up the children
		/// each time the contents of a list item are changed.
		/// </summary>
		/// <remarks>
		/// Cache of the child views of drop-drown list items, to avoid looking up the children
		/// each time the contents of a list item are changed.
		/// </remarks>
		private sealed class ChildViewCache
		{
			public readonly android.widget.TextView mText1;

			public readonly android.widget.TextView mText2;

			public readonly android.widget.ImageView mIcon1;

			public readonly android.widget.ImageView mIcon2;

			public readonly android.widget.ImageView mIconRefine;

			public ChildViewCache(android.view.View v)
			{
				mText1 = (android.widget.TextView)v.findViewById(android.@internal.R.id.text1);
				mText2 = (android.widget.TextView)v.findViewById(android.@internal.R.id.text2);
				mIcon1 = (android.widget.ImageView)v.findViewById(android.@internal.R.id.icon1);
				mIcon2 = (android.widget.ImageView)v.findViewById(android.@internal.R.id.icon2);
				mIconRefine = (android.widget.ImageView)v.findViewById(android.@internal.R.id.edit_query
					);
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override void bindView(android.view.View view, android.content.Context context
			, android.database.Cursor cursor)
		{
			android.widget.SuggestionsAdapter.ChildViewCache views = (android.widget.SuggestionsAdapter
				.ChildViewCache)view.getTag();
			int flags = 0;
			if (mFlagsCol != INVALID_INDEX)
			{
				flags = cursor.getInt(mFlagsCol);
			}
			if (views.mText1 != null)
			{
				string text1 = getStringOrNull(cursor, mText1Col);
				setViewText(views.mText1, java.lang.CharSequenceProxy.Wrap(text1));
			}
			if (views.mText2 != null)
			{
				// First check TEXT_2_URL
				java.lang.CharSequence text2 = java.lang.CharSequenceProxy.Wrap(getStringOrNull(cursor
					, mText2UrlCol));
				if (text2 != null)
				{
					text2 = formatUrl(text2);
				}
				else
				{
					text2 = java.lang.CharSequenceProxy.Wrap(getStringOrNull(cursor, mText2Col));
				}
				// If no second line of text is indicated, allow the first line of text
				// to be up to two lines if it wants to be.
				if (android.text.TextUtils.isEmpty(text2))
				{
					if (views.mText1 != null)
					{
						views.mText1.setSingleLine(false);
						views.mText1.setMaxLines(2);
					}
				}
				else
				{
					if (views.mText1 != null)
					{
						views.mText1.setSingleLine(true);
						views.mText1.setMaxLines(1);
					}
				}
				setViewText(views.mText2, text2);
			}
			if (views.mIcon1 != null)
			{
				setViewDrawable(views.mIcon1, getIcon1(cursor), android.view.View.INVISIBLE);
			}
			if (views.mIcon2 != null)
			{
				setViewDrawable(views.mIcon2, getIcon2(cursor), android.view.View.GONE);
			}
			if (mQueryRefinement == REFINE_ALL || (mQueryRefinement == REFINE_BY_ENTRY && (flags
				 & android.app.SearchManager.FLAG_QUERY_REFINEMENT) != 0))
			{
				views.mIconRefine.setVisibility(android.view.View.VISIBLE);
				views.mIconRefine.setTag(views.mText1.getText());
				views.mIconRefine.setOnClickListener(this);
			}
			else
			{
				views.mIconRefine.setVisibility(android.view.View.GONE);
			}
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			object tag = v.getTag();
			if (tag is java.lang.CharSequence)
			{
				mSearchView.onQueryRefine((java.lang.CharSequence)tag);
			}
		}

		private java.lang.CharSequence formatUrl(java.lang.CharSequence url)
		{
			if (mUrlColor == null)
			{
				// Lazily get the URL color from the current theme.
				android.util.TypedValue colorValue = new android.util.TypedValue();
				mContext.getTheme().resolveAttribute(android.@internal.R.attr.textColorSearchUrl, 
					colorValue, true);
				mUrlColor = mContext.getResources().getColorStateList(colorValue.resourceId);
			}
			android.text.SpannableString text = new android.text.SpannableString(url);
			text.setSpan(new android.text.style.TextAppearanceSpan(null, 0, 0, mUrlColor, null
				), 0, url.Length, android.text.SpannedClass.SPAN_EXCLUSIVE_EXCLUSIVE);
			return text;
		}

		private void setViewText(android.widget.TextView v, java.lang.CharSequence text)
		{
			// Set the text even if it's null, since we need to clear any previous text.
			v.setText(text);
			if (android.text.TextUtils.isEmpty(text))
			{
				v.setVisibility(android.view.View.GONE);
			}
			else
			{
				v.setVisibility(android.view.View.VISIBLE);
			}
		}

		private android.graphics.drawable.Drawable getIcon1(android.database.Cursor cursor
			)
		{
			if (mIconName1Col == INVALID_INDEX)
			{
				return null;
			}
			string value = cursor.getString(mIconName1Col);
			android.graphics.drawable.Drawable drawable = getDrawableFromResourceValue(value);
			if (drawable != null)
			{
				return drawable;
			}
			return getDefaultIcon1(cursor);
		}

		private android.graphics.drawable.Drawable getIcon2(android.database.Cursor cursor
			)
		{
			if (mIconName2Col == INVALID_INDEX)
			{
				return null;
			}
			string value = cursor.getString(mIconName2Col);
			return getDrawableFromResourceValue(value);
		}

		/// <summary>
		/// Sets the drawable in an image view, makes sure the view is only visible if there
		/// is a drawable.
		/// </summary>
		/// <remarks>
		/// Sets the drawable in an image view, makes sure the view is only visible if there
		/// is a drawable.
		/// </remarks>
		private void setViewDrawable(android.widget.ImageView v, android.graphics.drawable.Drawable
			 drawable, int nullVisibility)
		{
			// Set the icon even if the drawable is null, since we need to clear any
			// previous icon.
			v.setImageDrawable(drawable);
			if (drawable == null)
			{
				v.setVisibility(nullVisibility);
			}
			else
			{
				v.setVisibility(android.view.View.VISIBLE);
				// This is a hack to get any animated drawables (like a 'working' spinner)
				// to animate. You have to setVisible true on an AnimationDrawable to get
				// it to start animating, but it must first have been false or else the
				// call to setVisible will be ineffective. We need to clear up the story
				// about animated drawables in the future, see http://b/1878430.
				drawable.setVisible(false, false);
				drawable.setVisible(true, false);
			}
		}

		/// <summary>Gets the text to show in the query field when a suggestion is selected.</summary>
		/// <remarks>Gets the text to show in the query field when a suggestion is selected.</remarks>
		/// <param name="cursor">
		/// The Cursor to read the suggestion data from. The Cursor should already
		/// be moved to the suggestion that is to be read from.
		/// </param>
		/// <returns>
		/// The text to show, or <code>null</code> if the query should not be
		/// changed when selecting this suggestion.
		/// </returns>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override java.lang.CharSequence convertToString(android.database.Cursor cursor
			)
		{
			if (cursor == null)
			{
				return null;
			}
			string query = getColumnString(cursor, android.app.SearchManager.SUGGEST_COLUMN_QUERY
				);
			if (query != null)
			{
				return java.lang.CharSequenceProxy.Wrap(query);
			}
			if (mSearchable.shouldRewriteQueryFromData())
			{
				string data = getColumnString(cursor, android.app.SearchManager.SUGGEST_COLUMN_INTENT_DATA
					);
				if (data != null)
				{
					return java.lang.CharSequenceProxy.Wrap(data);
				}
			}
			if (mSearchable.shouldRewriteQueryFromText())
			{
				string text1 = getColumnString(cursor, android.app.SearchManager.SUGGEST_COLUMN_TEXT_1
					);
				if (text1 != null)
				{
					return java.lang.CharSequenceProxy.Wrap(text1);
				}
			}
			return null;
		}

		/// <summary>
		/// This method is overridden purely to provide a bit of protection against
		/// flaky content providers.
		/// </summary>
		/// <remarks>
		/// This method is overridden purely to provide a bit of protection against
		/// flaky content providers.
		/// </remarks>
		/// <seealso cref="Adapter.getView(int, android.view.View, android.view.ViewGroup)">Adapter.getView(int, android.view.View, android.view.ViewGroup)
		/// 	</seealso>
		[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
		public override android.view.View getView(int position, android.view.View convertView
			, android.view.ViewGroup parent)
		{
			try
			{
				return base.getView(position, convertView, parent);
			}
			catch (java.lang.RuntimeException e)
			{
				android.util.Log.w(LOG_TAG, "Search suggestions cursor threw exception.", e);
				// Put exception string in item title
				android.view.View v = newView(mContext, mCursor, parent);
				if (v != null)
				{
					android.widget.SuggestionsAdapter.ChildViewCache views = (android.widget.SuggestionsAdapter
						.ChildViewCache)v.getTag();
					android.widget.TextView tv = views.mText1;
					tv.setText(java.lang.CharSequenceProxy.Wrap(e.ToString()));
				}
				return v;
			}
		}

		/// <summary>Gets a drawable given a value provided by a suggestion provider.</summary>
		/// <remarks>
		/// Gets a drawable given a value provided by a suggestion provider.
		/// This value could be just the string value of a resource id
		/// (e.g., "2130837524"), in which case we will try to retrieve a drawable from
		/// the provider's resources. If the value is not an integer, it is
		/// treated as a Uri and opened with
		/// <see cref="android.content.ContentResolver.openOutputStream(System.Uri, string)">android.content.ContentResolver.openOutputStream(System.Uri, string)
		/// 	</see>
		/// .
		/// All resources and URIs are read using the suggestion provider's context.
		/// If the string is not formatted as expected, or no drawable can be found for
		/// the provided value, this method returns null.
		/// </remarks>
		/// <param name="drawableId">
		/// a string like "2130837524",
		/// "android.resource://com.android.alarmclock/2130837524",
		/// or "content://contacts/photos/253".
		/// </param>
		/// <returns>a Drawable, or null if none found</returns>
		private android.graphics.drawable.Drawable getDrawableFromResourceValue(string drawableId
			)
		{
			if (drawableId == null || drawableId.Length == 0 || "0".Equals(drawableId))
			{
				return null;
			}
			try
			{
				// First, see if it's just an integer
				int resourceId = System.Convert.ToInt32(drawableId);
				// It's an int, look for it in the cache
				string drawableUri = android.content.ContentResolver.SCHEME_ANDROID_RESOURCE + "://"
					 + mProviderContext.getPackageName() + "/" + resourceId;
				// Must use URI as cache key, since ints are app-specific
				android.graphics.drawable.Drawable drawable = checkIconCache(drawableUri);
				if (drawable != null)
				{
					return drawable;
				}
				// Not cached, find it by resource ID
				drawable = mProviderContext.getResources().getDrawable(resourceId);
				// Stick it in the cache, using the URI as key
				storeInIconCache(drawableUri, drawable);
				return drawable;
			}
			catch (System.ArgumentException)
			{
				// It's not an integer, use it as a URI
				android.graphics.drawable.Drawable drawable = checkIconCache(drawableId);
				if (drawable != null)
				{
					return drawable;
				}
				System.Uri uri = Sharpen.Util.ParseUri(drawableId);
				drawable = getDrawable(uri);
				storeInIconCache(drawableId, drawable);
				return drawable;
			}
			catch (android.content.res.Resources.NotFoundException)
			{
				// It was an integer, but it couldn't be found, bail out
				android.util.Log.w(LOG_TAG, "Icon resource not found: " + drawableId);
				return null;
			}
		}

		/// <summary>Gets a drawable by URI, without using the cache.</summary>
		/// <remarks>Gets a drawable by URI, without using the cache.</remarks>
		/// <returns>
		/// A drawable, or
		/// <code>null</code>
		/// if the drawable could not be loaded.
		/// </returns>
		private android.graphics.drawable.Drawable getDrawable(System.Uri uri)
		{
			try
			{
				string scheme = uri.Scheme;
				if (android.content.ContentResolver.SCHEME_ANDROID_RESOURCE.Equals(scheme))
				{
					// Load drawables through Resources, to get the source density information
					android.content.ContentResolver.OpenResourceIdResult r = mProviderContext.getContentResolver
						().getResourceId(uri);
					try
					{
						return r.r.getDrawable(r.id);
					}
					catch (android.content.res.Resources.NotFoundException)
					{
						throw new java.io.FileNotFoundException("Resource does not exist: " + uri);
					}
				}
				else
				{
					// Let the ContentResolver handle content and file URIs.
					java.io.InputStream stream = mProviderContext.getContentResolver().openInputStream
						(uri);
					if (stream == null)
					{
						throw new java.io.FileNotFoundException("Failed to open " + uri);
					}
					try
					{
						return android.graphics.drawable.Drawable.createFromStream(stream, null);
					}
					finally
					{
						try
						{
							stream.close();
						}
						catch (System.IO.IOException ex)
						{
							android.util.Log.e(LOG_TAG, "Error closing icon stream for " + uri, ex);
						}
					}
				}
			}
			catch (java.io.FileNotFoundException fnfe)
			{
				android.util.Log.w(LOG_TAG, "Icon not found: " + uri + ", " + fnfe.Message);
				return null;
			}
		}

		private android.graphics.drawable.Drawable checkIconCache(string resourceUri)
		{
			android.graphics.drawable.Drawable.ConstantState cached = mOutsideDrawablesCache.
				get(resourceUri);
			if (cached == null)
			{
				return null;
			}
			return cached.newDrawable();
		}

		private void storeInIconCache(string resourceUri, android.graphics.drawable.Drawable
			 drawable)
		{
			if (drawable != null)
			{
				mOutsideDrawablesCache.put(resourceUri, drawable.getConstantState());
			}
		}

		/// <summary>
		/// Gets the left-hand side icon that will be used for the current suggestion
		/// if the suggestion contains an icon column but no icon or a broken icon.
		/// </summary>
		/// <remarks>
		/// Gets the left-hand side icon that will be used for the current suggestion
		/// if the suggestion contains an icon column but no icon or a broken icon.
		/// </remarks>
		/// <param name="cursor">A cursor positioned at the current suggestion.</param>
		/// <returns>A non-null drawable.</returns>
		private android.graphics.drawable.Drawable getDefaultIcon1(android.database.Cursor
			 cursor)
		{
			// Check the component that gave us the suggestion
			android.graphics.drawable.Drawable drawable = getActivityIconWithCache(mSearchable
				.getSearchActivity());
			if (drawable != null)
			{
				return drawable;
			}
			// Fall back to a default icon
			return mContext.getPackageManager().getDefaultActivityIcon();
		}

		/// <summary>Gets the activity or application icon for an activity.</summary>
		/// <remarks>
		/// Gets the activity or application icon for an activity.
		/// Uses the local icon cache for fast repeated lookups.
		/// </remarks>
		/// <param name="component">Name of an activity.</param>
		/// <returns>
		/// A drawable, or
		/// <code>null</code>
		/// if neither the activity nor the application
		/// has an icon set.
		/// </returns>
		private android.graphics.drawable.Drawable getActivityIconWithCache(android.content.ComponentName
			 component)
		{
			// First check the icon cache
			string componentIconKey = component.flattenToShortString();
			// Using containsKey() since we also store null values.
			if (mOutsideDrawablesCache.containsKey(componentIconKey))
			{
				android.graphics.drawable.Drawable.ConstantState cached = mOutsideDrawablesCache.
					get(componentIconKey);
				return cached == null ? null : cached.newDrawable(mProviderContext.getResources()
					);
			}
			// Then try the activity or application icon
			android.graphics.drawable.Drawable drawable = getActivityIcon(component);
			// Stick it in the cache so we don't do this lookup again.
			android.graphics.drawable.Drawable.ConstantState toCache = drawable == null ? null
				 : drawable.getConstantState();
			mOutsideDrawablesCache.put(componentIconKey, toCache);
			return drawable;
		}

		/// <summary>Gets the activity or application icon for an activity.</summary>
		/// <remarks>Gets the activity or application icon for an activity.</remarks>
		/// <param name="component">Name of an activity.</param>
		/// <returns>
		/// A drawable, or
		/// <code>null</code>
		/// if neither the acitivy or the application
		/// have an icon set.
		/// </returns>
		private android.graphics.drawable.Drawable getActivityIcon(android.content.ComponentName
			 component)
		{
			android.content.pm.PackageManager pm = mContext.getPackageManager();
			android.content.pm.ActivityInfo activityInfo;
			try
			{
				activityInfo = pm.getActivityInfo(component, android.content.pm.PackageManager.GET_META_DATA
					);
			}
			catch (android.content.pm.PackageManager.NameNotFoundException ex)
			{
				android.util.Log.w(LOG_TAG, ex.ToString());
				return null;
			}
			int iconId = activityInfo.getIconResource();
			if (iconId == 0)
			{
				return null;
			}
			string pkg = component.getPackageName();
			android.graphics.drawable.Drawable drawable = pm.getDrawable(pkg, iconId, activityInfo
				.applicationInfo);
			if (drawable == null)
			{
				android.util.Log.w(LOG_TAG, "Invalid icon resource " + iconId + " for " + component
					.flattenToShortString());
				return null;
			}
			return drawable;
		}

		/// <summary>Gets the value of a string column by name.</summary>
		/// <remarks>Gets the value of a string column by name.</remarks>
		/// <param name="cursor">Cursor to read the value from.</param>
		/// <param name="columnName">The name of the column to read.</param>
		/// <returns>
		/// The value of the given column, or <code>null</null>
		/// if the cursor does not contain the given column.
		/// </returns>
		public static string getColumnString(android.database.Cursor cursor, string columnName
			)
		{
			int col = cursor.getColumnIndex(columnName);
			return getStringOrNull(cursor, col);
		}

		private static string getStringOrNull(android.database.Cursor cursor, int col)
		{
			if (col == INVALID_INDEX)
			{
				return null;
			}
			try
			{
				return cursor.getString(col);
			}
			catch (System.Exception e)
			{
				android.util.Log.e(LOG_TAG, "unexpected error retrieving valid column from cursor, "
					 + "did the remote process die?", e);
				return null;
			}
		}
	}
}
