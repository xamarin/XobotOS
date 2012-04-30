using Sharpen;

namespace android.widget
{
	/// <summary>A view that displays one child at a time and lets the user pick among them.
	/// 	</summary>
	/// <remarks>
	/// A view that displays one child at a time and lets the user pick among them.
	/// The items in the Spinner come from the
	/// <see cref="Adapter">Adapter</see>
	/// associated with
	/// this view.
	/// <p>See the &lt;a href="
	/// <docRoot></docRoot>
	/// resources/tutorials/views/hello-spinner.html"&gt;Spinner
	/// tutorial</a>.</p>
	/// </remarks>
	/// <attr>ref android.R.styleable#Spinner_prompt</attr>
	[Sharpen.Sharpened]
	public class Spinner : android.widget.AbsSpinner, android.content.DialogInterfaceClass
		.OnClickListener
	{
		internal const string TAG = "Spinner";

		internal const int MAX_ITEMS_MEASURED = 15;

		/// <summary>Use a dialog window for selecting spinner options.</summary>
		/// <remarks>Use a dialog window for selecting spinner options.</remarks>
		public const int MODE_DIALOG = 0;

		/// <summary>Use a dropdown anchored to the Spinner for selecting spinner options.</summary>
		/// <remarks>Use a dropdown anchored to the Spinner for selecting spinner options.</remarks>
		public const int MODE_DROPDOWN = 1;

		/// <summary>Use the theme-supplied value to select the dropdown mode.</summary>
		/// <remarks>Use the theme-supplied value to select the dropdown mode.</remarks>
		internal const int MODE_THEME = -1;

		private android.widget.Spinner.SpinnerPopup mPopup;

		private android.widget.Spinner.DropDownAdapter mTempAdapter;

		internal int mDropDownWidth;

		private int mGravity;

		private android.graphics.Rect mTempRect = new android.graphics.Rect();

		/// <summary>Construct a new spinner with the given context's theme.</summary>
		/// <remarks>Construct a new spinner with the given context's theme.</remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		public Spinner(android.content.Context context) : this(context, null)
		{
		}

		/// <summary>
		/// Construct a new spinner with the given context's theme and the supplied
		/// mode of displaying choices.
		/// </summary>
		/// <remarks>
		/// Construct a new spinner with the given context's theme and the supplied
		/// mode of displaying choices. <code>mode</code> may be one of
		/// <see cref="MODE_DIALOG">MODE_DIALOG</see>
		/// or
		/// <see cref="MODE_DROPDOWN">MODE_DROPDOWN</see>
		/// .
		/// </remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="mode">Constant describing how the user will select choices from the spinner.
		/// 	</param>
		/// <seealso cref="MODE_DIALOG">MODE_DIALOG</seealso>
		/// <seealso cref="MODE_DROPDOWN">MODE_DROPDOWN</seealso>
		public Spinner(android.content.Context context, int mode) : this(context, null, android.@internal.R
			.attr.spinnerStyle, mode)
		{
		}

		/// <summary>Construct a new spinner with the given context's theme and the supplied attribute set.
		/// 	</summary>
		/// <remarks>Construct a new spinner with the given context's theme and the supplied attribute set.
		/// 	</remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		public Spinner(android.content.Context context, android.util.AttributeSet attrs) : 
			this(context, attrs, android.@internal.R.attr.spinnerStyle)
		{
		}

		/// <summary>
		/// Construct a new spinner with the given context's theme, the supplied attribute set,
		/// and default style.
		/// </summary>
		/// <remarks>
		/// Construct a new spinner with the given context's theme, the supplied attribute set,
		/// and default style.
		/// </remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		/// <param name="defStyle">
		/// The default style to apply to this view. If 0, no style
		/// will be applied (beyond what is included in the theme). This may
		/// either be an attribute resource, whose value will be retrieved
		/// from the current theme, or an explicit style resource.
		/// </param>
		public Spinner(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle) : this(context, attrs, defStyle, MODE_THEME)
		{
		}

		/// <summary>
		/// Construct a new spinner with the given context's theme, the supplied attribute set,
		/// and default style.
		/// </summary>
		/// <remarks>
		/// Construct a new spinner with the given context's theme, the supplied attribute set,
		/// and default style. <code>mode</code> may be one of
		/// <see cref="MODE_DIALOG">MODE_DIALOG</see>
		/// or
		/// <see cref="MODE_DROPDOWN">MODE_DROPDOWN</see>
		/// and determines how the user will select choices from the spinner.
		/// </remarks>
		/// <param name="context">
		/// The Context the view is running in, through which it can
		/// access the current theme, resources, etc.
		/// </param>
		/// <param name="attrs">The attributes of the XML tag that is inflating the view.</param>
		/// <param name="defStyle">
		/// The default style to apply to this view. If 0, no style
		/// will be applied (beyond what is included in the theme). This may
		/// either be an attribute resource, whose value will be retrieved
		/// from the current theme, or an explicit style resource.
		/// </param>
		/// <param name="mode">Constant describing how the user will select choices from the spinner.
		/// 	</param>
		/// <seealso cref="MODE_DIALOG">MODE_DIALOG</seealso>
		/// <seealso cref="MODE_DROPDOWN">MODE_DROPDOWN</seealso>
		public Spinner(android.content.Context context, android.util.AttributeSet attrs, 
			int defStyle, int mode) : base(context, attrs, defStyle)
		{
			// Only measure this many items to get a decent max width.
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.Spinner, defStyle, 0);
			if (mode == MODE_THEME)
			{
				mode = a.getInt(android.@internal.R.styleable.Spinner_spinnerMode, MODE_DIALOG);
			}
			switch (mode)
			{
				case MODE_DIALOG:
				{
					mPopup = new android.widget.Spinner.DialogPopup(this);
					break;
				}

				case MODE_DROPDOWN:
				{
					android.widget.Spinner.DropdownPopup popup = new android.widget.Spinner.DropdownPopup
						(this, context, attrs, defStyle);
					mDropDownWidth = a.getLayoutDimension(android.@internal.R.styleable.Spinner_dropDownWidth
						, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
					popup.setBackgroundDrawable(a.getDrawable(android.@internal.R.styleable.Spinner_popupBackground
						));
					int verticalOffset = a.getDimensionPixelOffset(android.@internal.R.styleable.Spinner_dropDownVerticalOffset
						, 0);
					if (verticalOffset != 0)
					{
						popup.setVerticalOffset(verticalOffset);
					}
					int horizontalOffset = a.getDimensionPixelOffset(android.@internal.R.styleable.Spinner_dropDownHorizontalOffset
						, 0);
					if (horizontalOffset != 0)
					{
						popup.setHorizontalOffset(horizontalOffset);
					}
					mPopup = popup;
					break;
				}
			}
			mGravity = a.getInt(android.@internal.R.styleable.Spinner_gravity, android.view.Gravity
				.CENTER);
			mPopup.setPromptText(java.lang.CharSequenceProxy.Wrap(a.getString(android.@internal.R
				.styleable.Spinner_prompt)));
			a.recycle();
			// Base constructor can call setAdapter before we initialize mPopup.
			// Finish setting things up if this happened.
			if (mTempAdapter != null)
			{
				mPopup.setAdapter(mTempAdapter);
				mTempAdapter = null;
			}
		}

		/// <summary>Describes how the selected item view is positioned.</summary>
		/// <remarks>
		/// Describes how the selected item view is positioned. Currently only the horizontal component
		/// is used. The default is determined by the current theme.
		/// </remarks>
		/// <param name="gravity">
		/// See
		/// <see cref="android.view.Gravity">android.view.Gravity</see>
		/// </param>
		/// <attr>ref android.R.styleable#Spinner_gravity</attr>
		public virtual void setGravity(int gravity)
		{
			if (mGravity != gravity)
			{
				if ((gravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK) == 0)
				{
					gravity |= android.view.Gravity.LEFT;
				}
				mGravity = gravity;
				requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.SpinnerAdapter adapter)
		{
			base.setAdapter(adapter);
			if (mPopup != null)
			{
				mPopup.setAdapter(new android.widget.Spinner.DropDownAdapter(adapter));
			}
			else
			{
				mTempAdapter = new android.widget.Spinner.DropDownAdapter(adapter);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override int getBaseline()
		{
			android.view.View child = null;
			if (getChildCount() > 0)
			{
				child = getChildAt(0);
			}
			else
			{
				if (mAdapter != null && mAdapter.getCount() > 0)
				{
					child = makeAndAddView(0);
					mRecycler.put(0, child);
					removeAllViewsInLayout();
				}
			}
			if (child != null)
			{
				int childBaseline = child.getBaseline();
				return childBaseline >= 0 ? child.getTop() + childBaseline : -1;
			}
			else
			{
				return -1;
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			if (mPopup != null && mPopup.isShowing())
			{
				mPopup.dismiss();
			}
		}

		/// <summary><p>A spinner does not support item click events.</summary>
		/// <remarks>
		/// <p>A spinner does not support item click events. Calling this method
		/// will raise an exception.</p>
		/// </remarks>
		/// <param name="l">this listener will be ignored</param>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setOnItemClickListener(android.widget.AdapterView.OnItemClickListener
			 l)
		{
			throw new java.lang.RuntimeException("setOnItemClickListener cannot be used with a spinner."
				);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			base.onMeasure(widthMeasureSpec, heightMeasureSpec);
			if (mPopup != null && android.view.View.MeasureSpec.getMode(widthMeasureSpec) == 
				android.view.View.MeasureSpec.AT_MOST)
			{
				int measuredWidth = getMeasuredWidth();
				setMeasuredDimension(System.Math.Min(System.Math.Max(measuredWidth, measureContentWidth
					(getAdapter(), getBackground())), android.view.View.MeasureSpec.getSize(widthMeasureSpec
					)), getMeasuredHeight());
			}
		}

		/// <seealso cref="android.view.View.onLayout(bool, int, int, int, int)">Creates and positions all views
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			base.onLayout(changed, l, t, r, b);
			mInLayout = true;
			layout(0, false);
			mInLayout = false;
		}

		/// <summary>Creates and positions all views for this Spinner.</summary>
		/// <remarks>Creates and positions all views for this Spinner.</remarks>
		/// <param name="delta">
		/// Change in the selected position. +1 moves selection is moving to the right,
		/// so views are scrolling to the left. -1 means selection is moving to the left.
		/// </param>
		[Sharpen.OverridesMethod(@"android.widget.AbsSpinner")]
		internal override void layout(int delta, bool animate_1)
		{
			int childrenLeft = mSpinnerPadding.left;
			int childrenWidth = mRight - mLeft - mSpinnerPadding.left - mSpinnerPadding.right;
			if (mDataChanged)
			{
				handleDataChanged();
			}
			// Handle the empty set by removing all views
			if (mItemCount == 0)
			{
				resetList();
				return;
			}
			if (mNextSelectedPosition >= 0)
			{
				setSelectedPositionInt(mNextSelectedPosition);
			}
			recycleAllViews();
			// Clear out old views
			removeAllViewsInLayout();
			// Make selected view and position it
			mFirstPosition = mSelectedPosition;
			android.view.View sel = makeAndAddView(mSelectedPosition);
			int width = sel.getMeasuredWidth();
			int selectedOffset = childrenLeft;
			switch (mGravity & android.view.Gravity.HORIZONTAL_GRAVITY_MASK)
			{
				case android.view.Gravity.CENTER_HORIZONTAL:
				{
					selectedOffset = childrenLeft + (childrenWidth / 2) - (width / 2);
					break;
				}

				case android.view.Gravity.RIGHT:
				{
					selectedOffset = childrenLeft + childrenWidth - width;
					break;
				}
			}
			sel.offsetLeftAndRight(selectedOffset);
			// Flush any cached views that did not get reused above
			mRecycler.clear();
			invalidate();
			checkSelectionChanged();
			mDataChanged = false;
			mNeedSync = false;
			setNextSelectedPositionInt(mSelectedPosition);
		}

		/// <summary>
		/// Obtain a view, either by pulling an existing view from the recycler or
		/// by getting a new one from the adapter.
		/// </summary>
		/// <remarks>
		/// Obtain a view, either by pulling an existing view from the recycler or
		/// by getting a new one from the adapter. If we are animating, make sure
		/// there is enough information in the view's layout parameters to animate
		/// from the old to new positions.
		/// </remarks>
		/// <param name="position">Position in the spinner for the view to obtain</param>
		/// <returns>A view that has been added to the spinner</returns>
		private android.view.View makeAndAddView(int position)
		{
			android.view.View child;
			if (!mDataChanged)
			{
				child = mRecycler.get(position);
				if (child != null)
				{
					// Position the view
					setUpChild(child);
					return child;
				}
			}
			// Nothing found in the recycler -- ask the adapter for a view
			child = mAdapter.getView(position, null, this);
			// Position the view
			setUpChild(child);
			return child;
		}

		/// <summary>
		/// Helper for makeAndAddView to set the position of a view
		/// and fill out its layout paramters.
		/// </summary>
		/// <remarks>
		/// Helper for makeAndAddView to set the position of a view
		/// and fill out its layout paramters.
		/// </remarks>
		/// <param name="child">The view to position</param>
		private void setUpChild(android.view.View child)
		{
			// Respect layout params that are already in the view. Otherwise
			// make some up...
			android.view.ViewGroup.LayoutParams lp = child.getLayoutParams();
			if (lp == null)
			{
				lp = generateDefaultLayoutParams();
			}
			addViewInLayout(child, 0, lp);
			child.setSelected(hasFocus());
			// Get measure specs
			int childHeightSpec = android.view.ViewGroup.getChildMeasureSpec(mHeightMeasureSpec
				, mSpinnerPadding.top + mSpinnerPadding.bottom, lp.height);
			int childWidthSpec = android.view.ViewGroup.getChildMeasureSpec(mWidthMeasureSpec
				, mSpinnerPadding.left + mSpinnerPadding.right, lp.width);
			// Measure child
			child.measure(childWidthSpec, childHeightSpec);
			int childLeft;
			int childRight;
			// Position vertically based on gravity setting
			int childTop = mSpinnerPadding.top + ((getMeasuredHeight() - mSpinnerPadding.bottom
				 - mSpinnerPadding.top - child.getMeasuredHeight()) / 2);
			int childBottom = childTop + child.getMeasuredHeight();
			int width = child.getMeasuredWidth();
			childLeft = 0;
			childRight = childLeft + width;
			child.layout(childLeft, childTop, childRight, childBottom);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool performClick()
		{
			bool handled = base.performClick();
			if (!handled)
			{
				handled = true;
				if (!mPopup.isShowing())
				{
					mPopup.show();
				}
			}
			return handled;
		}

		[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnClickListener")]
		public virtual void onClick(android.content.DialogInterface dialog, int which)
		{
			setSelection(which);
			dialog.dismiss();
		}

		/// <summary>Sets the prompt to display when the dialog is shown.</summary>
		/// <remarks>Sets the prompt to display when the dialog is shown.</remarks>
		/// <param name="prompt">the prompt to set</param>
		public virtual void setPrompt(java.lang.CharSequence prompt)
		{
			mPopup.setPromptText(prompt);
		}

		/// <summary>Sets the prompt to display when the dialog is shown.</summary>
		/// <remarks>Sets the prompt to display when the dialog is shown.</remarks>
		/// <param name="promptId">the resource ID of the prompt to display when the dialog is shown
		/// 	</param>
		public virtual void setPromptId(int promptId)
		{
			setPrompt(getContext().getText(promptId));
		}

		/// <returns>The prompt to display when the dialog is shown</returns>
		public virtual java.lang.CharSequence getPrompt()
		{
			return mPopup.getHintText();
		}

		internal virtual int measureContentWidth(android.widget.SpinnerAdapter adapter, android.graphics.drawable.Drawable
			 background)
		{
			if (adapter == null)
			{
				return 0;
			}
			int width = 0;
			android.view.View itemView = null;
			int itemType = 0;
			int widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			int heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
				.MeasureSpec.UNSPECIFIED);
			// Make sure the number of items we'll measure is capped. If it's a huge data set
			// with wildly varying sizes, oh well.
			int start = System.Math.Max(0, getSelectedItemPosition());
			int end = System.Math.Min(adapter.getCount(), start + MAX_ITEMS_MEASURED);
			int count = end - start;
			start = System.Math.Max(0, start - (MAX_ITEMS_MEASURED - count));
			{
				for (int i = start; i < end; i++)
				{
					int positionType = adapter.getItemViewType(i);
					if (positionType != itemType)
					{
						itemType = positionType;
						itemView = null;
					}
					itemView = adapter.getView(i, itemView, this);
					if (itemView.getLayoutParams() == null)
					{
						itemView.setLayoutParams(new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
							.LayoutParams.WRAP_CONTENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT));
					}
					itemView.measure(widthMeasureSpec, heightMeasureSpec);
					width = System.Math.Max(width, itemView.getMeasuredWidth());
				}
			}
			// Add background padding to measured width
			if (background != null)
			{
				background.getPadding(mTempRect);
				width += mTempRect.left + mTempRect.right;
			}
			return width;
		}

		/// <summary><p>Wrapper class for an Adapter.</summary>
		/// <remarks>
		/// <p>Wrapper class for an Adapter. Transforms the embedded Adapter instance
		/// into a ListAdapter.</p>
		/// </remarks>
		private class DropDownAdapter : android.widget.ListAdapter, android.widget.SpinnerAdapter
		{
			internal android.widget.SpinnerAdapter mAdapter;

			internal android.widget.ListAdapter mListAdapter;

			/// <summary><p>Creates a new ListAdapter wrapper for the specified adapter.</p></summary>
			/// <param name="adapter">the Adapter to transform into a ListAdapter</param>
			public DropDownAdapter(android.widget.SpinnerAdapter adapter)
			{
				this.mAdapter = adapter;
				if (adapter is android.widget.ListAdapter)
				{
					this.mListAdapter = (android.widget.ListAdapter)adapter;
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public virtual int getCount()
			{
				return mAdapter == null ? 0 : mAdapter.getCount();
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public virtual object getItem(int position)
			{
				return mAdapter == null ? null : mAdapter.getItem(position);
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public virtual long getItemId(int position)
			{
				return mAdapter == null ? -1 : mAdapter.getItemId(position);
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public virtual android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				return getDropDownView(position, convertView, parent);
			}

			[Sharpen.ImplementsInterface(@"android.widget.SpinnerAdapter")]
			public virtual android.view.View getDropDownView(int position, android.view.View 
				convertView, android.view.ViewGroup parent)
			{
				return mAdapter == null ? null : mAdapter.getDropDownView(position, convertView, 
					parent);
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public virtual bool hasStableIds()
			{
				return mAdapter != null && mAdapter.hasStableIds();
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

			/// <summary>If the wrapped SpinnerAdapter is also a ListAdapter, delegate this call.
			/// 	</summary>
			/// <remarks>
			/// If the wrapped SpinnerAdapter is also a ListAdapter, delegate this call.
			/// Otherwise, return true.
			/// </remarks>
			[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
			public virtual bool areAllItemsEnabled()
			{
				android.widget.ListAdapter adapter = mListAdapter;
				if (adapter != null)
				{
					return adapter.areAllItemsEnabled();
				}
				else
				{
					return true;
				}
			}

			/// <summary>If the wrapped SpinnerAdapter is also a ListAdapter, delegate this call.
			/// 	</summary>
			/// <remarks>
			/// If the wrapped SpinnerAdapter is also a ListAdapter, delegate this call.
			/// Otherwise, return true.
			/// </remarks>
			[Sharpen.ImplementsInterface(@"android.widget.ListAdapter")]
			public virtual bool isEnabled(int position)
			{
				android.widget.ListAdapter adapter = mListAdapter;
				if (adapter != null)
				{
					return adapter.isEnabled(position);
				}
				else
				{
					return true;
				}
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
		}

		/// <summary>Implements some sort of popup selection interface for selecting a spinner option.
		/// 	</summary>
		/// <remarks>
		/// Implements some sort of popup selection interface for selecting a spinner option.
		/// Allows for different spinner modes.
		/// </remarks>
		private interface SpinnerPopup
		{
			void setAdapter(android.widget.ListAdapter adapter);

			/// <summary>Show the popup</summary>
			void show();

			/// <summary>Dismiss the popup</summary>
			void dismiss();

			/// <returns>true if the popup is showing, false otherwise.</returns>
			bool isShowing();

			/// <summary>Set hint text to be displayed to the user.</summary>
			/// <remarks>
			/// Set hint text to be displayed to the user. This should provide
			/// a description of the choice being made.
			/// </remarks>
			/// <param name="hintText">Hint text to set.</param>
			void setPromptText(java.lang.CharSequence hintText);

			java.lang.CharSequence getHintText();
		}

		private class DialogPopup : android.widget.Spinner.SpinnerPopup, android.content.DialogInterfaceClass
			.OnClickListener
		{
			internal android.app.AlertDialog mPopup;

			internal android.widget.ListAdapter mListAdapter;

			internal java.lang.CharSequence mPrompt;

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual void dismiss()
			{
				this.mPopup.dismiss();
				this.mPopup = null;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual bool isShowing()
			{
				return this.mPopup != null ? this.mPopup.isShowing() : false;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual void setAdapter(android.widget.ListAdapter adapter)
			{
				this.mListAdapter = adapter;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual void setPromptText(java.lang.CharSequence hintText)
			{
				this.mPrompt = hintText;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual java.lang.CharSequence getHintText()
			{
				return this.mPrompt;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual void show()
			{
				android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(this
					._enclosing.getContext());
				if (this.mPrompt != null)
				{
					builder.setTitle(this.mPrompt);
				}
				this.mPopup = builder.setSingleChoiceItems(this.mListAdapter, this._enclosing.getSelectedItemPosition
					(), this).show();
			}

			[Sharpen.ImplementsInterface(@"android.content.DialogInterface.OnClickListener")]
			public virtual void onClick(android.content.DialogInterface dialog, int which)
			{
				this._enclosing.setSelection(which);
				this.dismiss();
			}

			internal DialogPopup(Spinner _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Spinner _enclosing;
		}

		private class DropdownPopup : android.widget.ListPopupWindow, android.widget.Spinner
			.SpinnerPopup
		{
			internal java.lang.CharSequence mHintText;

			internal android.widget.ListAdapter mAdapter;

			internal sealed class _OnItemClickListener_692 : android.widget.AdapterView.OnItemClickListener
			{
				public _OnItemClickListener_692(DropdownPopup _enclosing)
				{
					this._enclosing = _enclosing;
				}

				[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
				public void onItemClick(object parent, android.view.View v, int position, long id
					)
				{
					this._enclosing._enclosing.setSelection(position);
					this._enclosing.dismiss();
				}

				private readonly DropdownPopup _enclosing;
			}

			public DropdownPopup(Spinner _enclosing, android.content.Context context, android.util.AttributeSet
				 attrs, int defStyleRes) : base(context, attrs, 0, defStyleRes)
			{
				this._enclosing = _enclosing;
				this.setAnchorView(this._enclosing);
				this.setModal(true);
				this.setPromptPosition(android.widget.ListPopupWindow.POSITION_PROMPT_ABOVE);
				this.setOnItemClickListener(new _OnItemClickListener_692(this));
			}

			[Sharpen.OverridesMethod(@"android.widget.ListPopupWindow")]
			public override void setAdapter(android.widget.ListAdapter adapter)
			{
				base.setAdapter(adapter);
				this.mAdapter = adapter;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual java.lang.CharSequence getHintText()
			{
				return this.mHintText;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Spinner.SpinnerPopup")]
			public virtual void setPromptText(java.lang.CharSequence hintText)
			{
				// Hint text is ignored for dropdowns, but maintain it here.
				this.mHintText = hintText;
			}

			[Sharpen.OverridesMethod(@"android.widget.ListPopupWindow")]
			public override void show()
			{
				int spinnerPaddingLeft = this._enclosing.getPaddingLeft();
				if (this._enclosing.mDropDownWidth == android.widget.ListPopupWindow.WRAP_CONTENT)
				{
					int spinnerWidth = this._enclosing.getWidth();
					int spinnerPaddingRight = this._enclosing.getPaddingRight();
					this.setContentWidth(System.Math.Max(this._enclosing.measureContentWidth((android.widget.SpinnerAdapter
						)this.mAdapter, this.getBackground()), spinnerWidth - spinnerPaddingLeft - spinnerPaddingRight
						));
				}
				else
				{
					if (this._enclosing.mDropDownWidth == android.widget.ListPopupWindow.MATCH_PARENT)
					{
						int spinnerWidth = this._enclosing.getWidth();
						int spinnerPaddingRight = this._enclosing.getPaddingRight();
						this.setContentWidth(spinnerWidth - spinnerPaddingLeft - spinnerPaddingRight);
					}
					else
					{
						this.setContentWidth(this._enclosing.mDropDownWidth);
					}
				}
				android.graphics.drawable.Drawable background = this.getBackground();
				int bgOffset = 0;
				if (background != null)
				{
					background.getPadding(this._enclosing.mTempRect);
					bgOffset = -this._enclosing.mTempRect.left;
				}
				this.setHorizontalOffset(bgOffset + spinnerPaddingLeft);
				this.setInputMethodMode(android.widget.ListPopupWindow.INPUT_METHOD_NOT_NEEDED);
				base.show();
				this.getListView().setChoiceMode(android.widget.AbsListView.CHOICE_MODE_SINGLE);
				this.setSelection(this._enclosing.getSelectedItemPosition());
			}

			private readonly Spinner _enclosing;
		}
	}
}
