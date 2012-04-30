using Sharpen;

namespace android.widget
{
	/// <summary>
	/// An easy adapter to map columns from a cursor to TextViews or ImageViews
	/// defined in an XML file.
	/// </summary>
	/// <remarks>
	/// An easy adapter to map columns from a cursor to TextViews or ImageViews
	/// defined in an XML file. You can specify which columns you want, which
	/// views you want to display the columns, and the XML file that defines
	/// the appearance of these views.
	/// Binding occurs in two phases. First, if a
	/// <see cref="ViewBinder">ViewBinder</see>
	/// is available,
	/// <see cref="ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)
	/// 	">ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)</see>
	/// is invoked. If the returned value is true, binding has occured. If the
	/// returned value is false and the view to bind is a TextView,
	/// <see cref="setViewText(TextView, string)">setViewText(TextView, string)</see>
	/// is invoked. If the returned value
	/// is false and the view to bind is an ImageView,
	/// <see cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</see>
	/// is invoked. If no appropriate
	/// binding can be found, an
	/// <see cref="System.InvalidOperationException">System.InvalidOperationException</see>
	/// is thrown.
	/// If this adapter is used with filtering, for instance in an
	/// <see cref="AutoCompleteTextView">AutoCompleteTextView</see>
	/// , you can use the
	/// <see cref="CursorToStringConverter">CursorToStringConverter</see>
	/// and the
	/// <see cref="FilterQueryProvider">FilterQueryProvider</see>
	/// interfaces
	/// to get control over the filtering process. You can refer to
	/// <see cref="convertToString(android.database.Cursor)">convertToString(android.database.Cursor)
	/// 	</see>
	/// and
	/// <see cref="CursorAdapter.runQueryOnBackgroundThread(java.lang.CharSequence)">CursorAdapter.runQueryOnBackgroundThread(java.lang.CharSequence)
	/// 	</see>
	/// for more information.
	/// </remarks>
	[Sharpen.Sharpened]
	public class SimpleCursorAdapter : android.widget.ResourceCursorAdapter
	{
		/// <summary>A list of columns containing the data to bind to the UI.</summary>
		/// <remarks>
		/// A list of columns containing the data to bind to the UI.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int[] mFrom;

		/// <summary>A list of View ids representing the views to which the data must be bound.
		/// 	</summary>
		/// <remarks>
		/// A list of View ids representing the views to which the data must be bound.
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal int[] mTo;

		private int mStringConversionColumn = -1;

		private android.widget.SimpleCursorAdapter.CursorToStringConverter mCursorToStringConverter;

		private android.widget.SimpleCursorAdapter.ViewBinder mViewBinder;

		internal string[] mOriginalFrom;

		/// <summary>Constructor the enables auto-requery.</summary>
		/// <remarks>Constructor the enables auto-requery.</remarks>
		[System.ObsoleteAttribute(@"This option is discouraged, as it results in Cursor queries being performed on the application's UI thread and thus can cause poor responsiveness or even Application Not Responding errors.  As an alternative, use android.app.LoaderManager with a android.content.CursorLoader ."
			)]
		public SimpleCursorAdapter(android.content.Context context, int layout, android.database.Cursor
			 c, string[] from, int[] to) : base(context, layout, c)
		{
			mTo = to;
			mOriginalFrom = from;
			findColumns(from);
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="context">
		/// The context where the ListView associated with this
		/// SimpleListItemFactory is running
		/// </param>
		/// <param name="layout">
		/// resource identifier of a layout file that defines the views
		/// for this list item. The layout file should include at least
		/// those named views defined in "to"
		/// </param>
		/// <param name="c">The database cursor.  Can be null if the cursor is not available yet.
		/// 	</param>
		/// <param name="from">
		/// A list of column names representing the data to bind to the UI.  Can be null
		/// if the cursor is not available yet.
		/// </param>
		/// <param name="to">
		/// The views that should display column in the "from" parameter.
		/// These should all be TextViews. The first N views in this list
		/// are given the values of the first N columns in the from
		/// parameter.  Can be null if the cursor is not available yet.
		/// </param>
		/// <param name="flags">
		/// Flags used to determine the behavior of the adapter,
		/// as per
		/// <see cref="CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, int)
		/// 	">CursorAdapter.CursorAdapter(android.content.Context, android.database.Cursor, int)
		/// 	</see>
		/// .
		/// </param>
		public SimpleCursorAdapter(android.content.Context context, int layout, android.database.Cursor
			 c, string[] from, int[] to, int flags) : base(context, layout, c, flags)
		{
			mTo = to;
			mOriginalFrom = from;
			findColumns(from);
		}

		/// <summary>
		/// Binds all of the field names passed into the "to" parameter of the
		/// constructor with their corresponding cursor columns as specified in the
		/// "from" parameter.
		/// </summary>
		/// <remarks>
		/// Binds all of the field names passed into the "to" parameter of the
		/// constructor with their corresponding cursor columns as specified in the
		/// "from" parameter.
		/// Binding occurs in two phases. First, if a
		/// <see cref="ViewBinder">ViewBinder</see>
		/// is available,
		/// <see cref="ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)
		/// 	">ViewBinder.setViewValue(android.view.View, android.database.Cursor, int)</see>
		/// is invoked. If the returned value is true, binding has occured. If the
		/// returned value is false and the view to bind is a TextView,
		/// <see cref="setViewText(TextView, string)">setViewText(TextView, string)</see>
		/// is invoked. If the returned value is
		/// false and the view to bind is an ImageView,
		/// <see cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</see>
		/// is invoked. If no appropriate
		/// binding can be found, an
		/// <see cref="System.InvalidOperationException">System.InvalidOperationException</see>
		/// is thrown.
		/// </remarks>
		/// <exception cref="System.InvalidOperationException">if binding cannot occur</exception>
		/// <seealso cref="CursorAdapter.bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	">CursorAdapter.bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	</seealso>
		/// <seealso cref="getViewBinder()">getViewBinder()</seealso>
		/// <seealso cref="setViewBinder(ViewBinder)">setViewBinder(ViewBinder)</seealso>
		/// <seealso cref="setViewImage(ImageView, string)">setViewImage(ImageView, string)</seealso>
		/// <seealso cref="setViewText(TextView, string)">setViewText(TextView, string)</seealso>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override void bindView(android.view.View view, android.content.Context context
			, android.database.Cursor cursor)
		{
			android.widget.SimpleCursorAdapter.ViewBinder binder = mViewBinder;
			int count = mTo.Length;
			int[] from = mFrom;
			int[] to = mTo;
			{
				for (int i = 0; i < count; i++)
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
									throw new System.InvalidOperationException(v.GetType().FullName + " is not a " + 
										" view that can be bounds by this SimpleCursorAdapter");
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
		/// <seealso cref="bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	">bindView(android.view.View, android.content.Context, android.database.Cursor)</seealso>
		/// <seealso cref="setViewBinder(ViewBinder)">setViewBinder(ViewBinder)</seealso>
		public virtual android.widget.SimpleCursorAdapter.ViewBinder getViewBinder()
		{
			return mViewBinder;
		}

		/// <summary>Sets the binder used to bind data to views.</summary>
		/// <remarks>Sets the binder used to bind data to views.</remarks>
		/// <param name="viewBinder">
		/// the binder used to bind data to views, can be null to
		/// remove the existing binder
		/// </param>
		/// <seealso cref="bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	">bindView(android.view.View, android.content.Context, android.database.Cursor)</seealso>
		/// <seealso cref="getViewBinder()">getViewBinder()</seealso>
		public virtual void setViewBinder(android.widget.SimpleCursorAdapter.ViewBinder viewBinder
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
		/// By default, the value will be treated as an image resource. If the
		/// value cannot be used as an image resource, the value is used as an
		/// image Uri.
		/// Intended to be overridden by Adapters that need to filter strings
		/// retrieved from the database.
		/// </remarks>
		/// <param name="v">ImageView to receive an image</param>
		/// <param name="value">the value retrieved from the cursor</param>
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
		/// Return the index of the column used to get a String representation
		/// of the Cursor.
		/// </summary>
		/// <remarks>
		/// Return the index of the column used to get a String representation
		/// of the Cursor.
		/// </remarks>
		/// <returns>a valid index in the current Cursor or -1</returns>
		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		/// <seealso cref="setStringConversionColumn(int)"></seealso>
		/// <seealso cref="setCursorToStringConverter(CursorToStringConverter)">setCursorToStringConverter(CursorToStringConverter)
		/// 	</seealso>
		/// <seealso cref="getCursorToStringConverter()">getCursorToStringConverter()</seealso>
		public virtual int getStringConversionColumn()
		{
			return mStringConversionColumn;
		}

		/// <summary>
		/// Defines the index of the column in the Cursor used to get a String
		/// representation of that Cursor.
		/// </summary>
		/// <remarks>
		/// Defines the index of the column in the Cursor used to get a String
		/// representation of that Cursor. The column is used to convert the
		/// Cursor to a String only when the current CursorToStringConverter
		/// is null.
		/// </remarks>
		/// <param name="stringConversionColumn">
		/// a valid index in the current Cursor or -1 to use the default
		/// conversion mechanism
		/// </param>
		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		/// <seealso cref="getStringConversionColumn()">getStringConversionColumn()</seealso>
		/// <seealso cref="setCursorToStringConverter(CursorToStringConverter)">setCursorToStringConverter(CursorToStringConverter)
		/// 	</seealso>
		/// <seealso cref="getCursorToStringConverter()">getCursorToStringConverter()</seealso>
		public virtual void setStringConversionColumn(int stringConversionColumn)
		{
			mStringConversionColumn = stringConversionColumn;
		}

		/// <summary>
		/// Returns the converter used to convert the filtering Cursor
		/// into a String.
		/// </summary>
		/// <remarks>
		/// Returns the converter used to convert the filtering Cursor
		/// into a String.
		/// </remarks>
		/// <returns>
		/// null if the converter does not exist or an instance of
		/// <see cref="CursorToStringConverter">CursorToStringConverter</see>
		/// </returns>
		/// <seealso cref="setCursorToStringConverter(CursorToStringConverter)">setCursorToStringConverter(CursorToStringConverter)
		/// 	</seealso>
		/// <seealso cref="getStringConversionColumn()">getStringConversionColumn()</seealso>
		/// <seealso cref="setStringConversionColumn(int)">setStringConversionColumn(int)</seealso>
		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		public virtual android.widget.SimpleCursorAdapter.CursorToStringConverter getCursorToStringConverter
			()
		{
			return mCursorToStringConverter;
		}

		/// <summary>
		/// Sets the converter  used to convert the filtering Cursor
		/// into a String.
		/// </summary>
		/// <remarks>
		/// Sets the converter  used to convert the filtering Cursor
		/// into a String.
		/// </remarks>
		/// <param name="cursorToStringConverter">
		/// the Cursor to String converter, or
		/// null to remove the converter
		/// </param>
		/// <seealso cref="setCursorToStringConverter(CursorToStringConverter)"></seealso>
		/// <seealso cref="getStringConversionColumn()">getStringConversionColumn()</seealso>
		/// <seealso cref="setStringConversionColumn(int)">setStringConversionColumn(int)</seealso>
		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		public virtual void setCursorToStringConverter(android.widget.SimpleCursorAdapter
			.CursorToStringConverter cursorToStringConverter)
		{
			mCursorToStringConverter = cursorToStringConverter;
		}

		/// <summary>
		/// Returns a CharSequence representation of the specified Cursor as defined
		/// by the current CursorToStringConverter.
		/// </summary>
		/// <remarks>
		/// Returns a CharSequence representation of the specified Cursor as defined
		/// by the current CursorToStringConverter. If no CursorToStringConverter
		/// has been set, the String conversion column is used instead. If the
		/// conversion column is -1, the returned String is empty if the cursor
		/// is null or Cursor.toString().
		/// </remarks>
		/// <param name="cursor">the Cursor to convert to a CharSequence</param>
		/// <returns>a non-null CharSequence representing the cursor</returns>
		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override java.lang.CharSequence convertToString(android.database.Cursor cursor
			)
		{
			if (mCursorToStringConverter != null)
			{
				return mCursorToStringConverter.convertToString(cursor);
			}
			else
			{
				if (mStringConversionColumn > -1)
				{
					return java.lang.CharSequenceProxy.Wrap(cursor.getString(mStringConversionColumn)
						);
				}
			}
			return base.convertToString(cursor);
		}

		/// <summary>Create a map from an array of strings to an array of column-id integers in mCursor.
		/// 	</summary>
		/// <remarks>
		/// Create a map from an array of strings to an array of column-id integers in mCursor.
		/// If mCursor is null, the array will be discarded.
		/// </remarks>
		/// <param name="from">the Strings naming the columns of interest</param>
		private void findColumns(string[] from)
		{
			if (mCursor != null)
			{
				int i;
				int count = from.Length;
				if (mFrom == null || mFrom.Length != count)
				{
					mFrom = new int[count];
				}
				for (i = 0; i < count; i++)
				{
					mFrom[i] = mCursor.getColumnIndexOrThrow(from[i]);
				}
			}
			else
			{
				mFrom = null;
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
		public override android.database.Cursor swapCursor(android.database.Cursor c)
		{
			// super.swapCursor() will notify observers before we have
			// a valid mapping, make sure we have a mapping before this
			// happens
			if (mFrom == null)
			{
				findColumns(mOriginalFrom);
			}
			android.database.Cursor res = base.swapCursor(c);
			// rescan columns in case cursor layout is different
			findColumns(mOriginalFrom);
			return res;
		}

		/// <summary>Change the cursor and change the column-to-view mappings at the same time.
		/// 	</summary>
		/// <remarks>Change the cursor and change the column-to-view mappings at the same time.
		/// 	</remarks>
		/// <param name="c">The database cursor.  Can be null if the cursor is not available yet.
		/// 	</param>
		/// <param name="from">
		/// A list of column names representing the data to bind to the UI.  Can be null
		/// if the cursor is not available yet.
		/// </param>
		/// <param name="to">
		/// The views that should display column in the "from" parameter.
		/// These should all be TextViews. The first N views in this list
		/// are given the values of the first N columns in the from
		/// parameter.  Can be null if the cursor is not available yet.
		/// </param>
		public virtual void changeCursorAndColumns(android.database.Cursor c, string[] from
			, int[] to)
		{
			mOriginalFrom = from;
			mTo = to;
			// super.changeCursor() will notify observers before we have
			// a valid mapping, make sure we have a mapping before this
			// happens
			if (mFrom == null)
			{
				findColumns(mOriginalFrom);
			}
			base.changeCursor(c);
			findColumns(mOriginalFrom);
		}

		/// <summary>
		/// This class can be used by external clients of SimpleCursorAdapter
		/// to bind values fom the Cursor to views.
		/// </summary>
		/// <remarks>
		/// This class can be used by external clients of SimpleCursorAdapter
		/// to bind values fom the Cursor to views.
		/// You should use this class to bind values from the Cursor to views
		/// that are not directly supported by SimpleCursorAdapter or to
		/// change the way binding occurs for views supported by
		/// SimpleCursorAdapter.
		/// </remarks>
		/// <seealso cref="SimpleCursorAdapter.bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	">SimpleCursorAdapter.bindView(android.view.View, android.content.Context, android.database.Cursor)
		/// 	</seealso>
		/// <seealso cref="SimpleCursorAdapter.setViewImage(ImageView, string)"></seealso>
		/// <seealso cref="SimpleCursorAdapter.setViewText(TextView, string)">SimpleCursorAdapter.setViewText(TextView, string)
		/// 	</seealso>
		public interface ViewBinder
		{
			/// <summary>Binds the Cursor column defined by the specified index to the specified view.
			/// 	</summary>
			/// <remarks>
			/// Binds the Cursor column defined by the specified index to the specified view.
			/// When binding is handled by this ViewBinder, this method must return true.
			/// If this method returns false, SimpleCursorAdapter will attempts to handle
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

		/// <summary>
		/// This class can be used by external clients of SimpleCursorAdapter
		/// to define how the Cursor should be converted to a String.
		/// </summary>
		/// <remarks>
		/// This class can be used by external clients of SimpleCursorAdapter
		/// to define how the Cursor should be converted to a String.
		/// </remarks>
		/// <seealso cref="CursorAdapter.convertToString(android.database.Cursor)">CursorAdapter.convertToString(android.database.Cursor)
		/// 	</seealso>
		public interface CursorToStringConverter
		{
			/// <summary>Returns a CharSequence representing the specified Cursor.</summary>
			/// <remarks>Returns a CharSequence representing the specified Cursor.</remarks>
			/// <param name="cursor">
			/// the cursor for which a CharSequence representation
			/// is requested
			/// </param>
			/// <returns>a non-null CharSequence representing the cursor</returns>
			java.lang.CharSequence convertToString(android.database.Cursor cursor);
		}
	}
}
