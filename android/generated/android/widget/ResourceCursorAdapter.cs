using Sharpen;

namespace android.widget
{
	/// <summary>An easy adapter that creates views defined in an XML file.</summary>
	/// <remarks>
	/// An easy adapter that creates views defined in an XML file. You can specify
	/// the XML file that defines the appearance of the views.
	/// </remarks>
	[Sharpen.Sharpened]
	public abstract class ResourceCursorAdapter : android.widget.CursorAdapter
	{
		private int mLayout;

		private int mDropDownLayout;

		private android.view.LayoutInflater mInflater;

		/// <summary>Constructor the enables auto-requery.</summary>
		/// <remarks>Constructor the enables auto-requery.</remarks>
		/// <param name="context">The context where the ListView associated with this adapter is running
		/// 	</param>
		/// <param name="layout">
		/// resource identifier of a layout file that defines the views
		/// for this list item.  Unless you override them later, this will
		/// define both the item views and the drop down views.
		/// </param>
		[System.ObsoleteAttribute(@"This option is discouraged, as it results in Cursor queries being performed on the application's UI thread and thus can cause poor responsiveness or even Application Not Responding errors.  As an alternative, use android.app.LoaderManager with a android.content.CursorLoader ."
			)]
		public ResourceCursorAdapter(android.content.Context context, int layout, android.database.Cursor
			 c) : base(context, c)
		{
			mLayout = mDropDownLayout = layout;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
		}

		/// <summary>
		/// Constructor with default behavior as per
		/// <see cref="CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, bool)
		/// 	">CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, bool)
		/// 	</see>
		/// ; it is recommended
		/// you not use this, but instead
		/// <see cref="ResourceCursorAdapter(android.content.Context, int, android.database.Cursor, int)
		/// 	">ResourceCursorAdapter(android.content.Context, int, android.database.Cursor, int)
		/// 	</see>
		/// .
		/// When using this constructor,
		/// <see cref="CursorAdapter.FLAG_REGISTER_CONTENT_OBSERVER">CursorAdapter.FLAG_REGISTER_CONTENT_OBSERVER
		/// 	</see>
		/// will always be set.
		/// </summary>
		/// <param name="context">The context where the ListView associated with this adapter is running
		/// 	</param>
		/// <param name="layout">
		/// resource identifier of a layout file that defines the views
		/// for this list item.  Unless you override them later, this will
		/// define both the item views and the drop down views.
		/// </param>
		/// <param name="c">The cursor from which to get the data.</param>
		/// <param name="autoRequery">
		/// If true the adapter will call requery() on the
		/// cursor whenever it changes so the most recent
		/// data is always displayed.  Using true here is discouraged.
		/// </param>
		public ResourceCursorAdapter(android.content.Context context, int layout, android.database.Cursor
			 c, bool autoRequery) : base(context, c, autoRequery)
		{
			mLayout = mDropDownLayout = layout;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="context">The context where the ListView associated with this adapter is running
		/// 	</param>
		/// <param name="layout">
		/// Resource identifier of a layout file that defines the views
		/// for this list item.  Unless you override them later, this will
		/// define both the item views and the drop down views.
		/// </param>
		/// <param name="c">The cursor from which to get the data.</param>
		/// <param name="flags">
		/// Flags used to determine the behavior of the adapter,
		/// as per
		/// <see cref="CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, int)
		/// 	">CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, int)
		/// 	</see>
		/// .
		/// </param>
		public ResourceCursorAdapter(android.content.Context context, int layout, android.database.Cursor
			 c, int flags) : base(context, c, flags)
		{
			mLayout = mDropDownLayout = layout;
			mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
				.LAYOUT_INFLATER_SERVICE);
		}

		/// <summary>Inflates view(s) from the specified XML file.</summary>
		/// <remarks>Inflates view(s) from the specified XML file.</remarks>
		/// <seealso cref="CursorAdapter.newView(android.content.Context, android.database.Cursor, android.view.ViewGroup)
		/// 	">CursorAdapter.newView(android.content.Context, android.database.Cursor, android.view.ViewGroup)
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override android.view.View newView(android.content.Context context, android.database.Cursor
			 cursor, android.view.ViewGroup parent)
		{
			return mInflater.inflate(mLayout, parent, false);
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override android.view.View newDropDownView(android.content.Context context
			, android.database.Cursor cursor, android.view.ViewGroup parent)
		{
			return mInflater.inflate(mDropDownLayout, parent, false);
		}

		/// <summary><p>Sets the layout resource of the item views.</p></summary>
		/// <param name="layout">the layout resources used to create item views</param>
		public virtual void setViewResource(int layout)
		{
			mLayout = layout;
		}

		/// <summary><p>Sets the layout resource of the drop down views.</p></summary>
		/// <param name="dropDownLayout">the layout resources used to create drop down views</param>
		public virtual void setDropDownViewResource(int dropDownLayout)
		{
			mDropDownLayout = dropDownLayout;
		}
	}
}
