using Sharpen;

namespace android.widget
{
	/// <summary>An abstract base class for spinner widgets.</summary>
	/// <remarks>
	/// An abstract base class for spinner widgets. SDK users will probably not
	/// need to use this class.
	/// </remarks>
	/// <attr>ref android.R.styleable#AbsSpinner_entries</attr>
	[Sharpen.Sharpened]
	public abstract class AbsSpinner : android.widget.AdapterView<android.widget.SpinnerAdapter
		>
	{
		internal android.widget.SpinnerAdapter mAdapter;

		internal int mHeightMeasureSpec;

		internal int mWidthMeasureSpec;

		internal bool mBlockLayoutRequests;

		internal int mSelectionLeftPadding = 0;

		internal int mSelectionTopPadding = 0;

		internal int mSelectionRightPadding = 0;

		internal int mSelectionBottomPadding = 0;

		internal readonly android.graphics.Rect mSpinnerPadding = new android.graphics.Rect
			();

		internal readonly android.widget.AbsSpinner.RecycleBin mRecycler;

		private android.database.DataSetObserver mDataSetObserver;

		/// <summary>Temporary frame to hold a child View's frame rectangle</summary>
		private android.graphics.Rect mTouchFrame;

		public AbsSpinner(android.content.Context context) : base(context)
		{
			mRecycler = new android.widget.AbsSpinner.RecycleBin(this);
			initAbsSpinner();
		}

		public AbsSpinner(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, 0)
		{
			mRecycler = new android.widget.AbsSpinner.RecycleBin(this);
		}

		public AbsSpinner(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			mRecycler = new android.widget.AbsSpinner.RecycleBin(this);
			initAbsSpinner();
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.AbsSpinner, defStyle, 0);
			java.lang.CharSequence[] entries = a.getTextArray(android.@internal.R.styleable.AbsSpinner_entries
				);
			if (entries != null)
			{
				android.widget.ArrayAdapter<java.lang.CharSequence> adapter = new android.widget.ArrayAdapter
					<java.lang.CharSequence>(context, android.@internal.R.layout.simple_spinner_item
					, entries);
				adapter.setDropDownViewResource(android.@internal.R.layout.simple_spinner_dropdown_item
					);
				setAdapter(adapter);
			}
			a.recycle();
		}

		/// <summary>Common code for different constructor flavors</summary>
		private void initAbsSpinner()
		{
			setFocusable(true);
			setWillNotDraw(false);
		}

		/// <summary>The Adapter is used to provide the data which backs this Spinner.</summary>
		/// <remarks>
		/// The Adapter is used to provide the data which backs this Spinner.
		/// It also provides methods to transform spinner items based on their position
		/// relative to the selected item.
		/// </remarks>
		/// <param name="adapter">The SpinnerAdapter to use for this Spinner</param>
		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setAdapter(android.widget.SpinnerAdapter adapter)
		{
			if (null != mAdapter)
			{
				mAdapter.unregisterDataSetObserver(mDataSetObserver);
				resetList();
			}
			mAdapter = adapter;
			mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			if (mAdapter != null)
			{
				mOldItemCount = mItemCount;
				mItemCount = mAdapter.getCount();
				checkFocus();
				mDataSetObserver = new android.widget.AdapterView<android.widget.SpinnerAdapter>.
					AdapterDataSetObserver(this);
				mAdapter.registerDataSetObserver(mDataSetObserver);
				int position = mItemCount > 0 ? 0 : android.widget.AdapterView.INVALID_POSITION;
				setSelectedPositionInt(position);
				setNextSelectedPositionInt(position);
				if (mItemCount == 0)
				{
					// Nothing selected
					checkSelectionChanged();
				}
			}
			else
			{
				checkFocus();
				resetList();
				// Nothing selected
				checkSelectionChanged();
			}
			requestLayout();
		}

		/// <summary>Clear out all children from the list</summary>
		internal virtual void resetList()
		{
			mDataChanged = false;
			mNeedSync = false;
			removeAllViewsInLayout();
			mOldSelectedPosition = android.widget.AdapterView.INVALID_POSITION;
			mOldSelectedRowId = android.widget.AdapterView.INVALID_ROW_ID;
			setSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
			setNextSelectedPositionInt(android.widget.AdapterView.INVALID_POSITION);
			invalidate();
		}

		/// <seealso cref="android.view.View.measure(int, int)">
		/// Figure out the dimensions of this Spinner. The width comes from
		/// the widthMeasureSpec as Spinnners can't have their width set to
		/// UNSPECIFIED. The height is based on the height of the selected item
		/// plus padding.
		/// </seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			int widthMode = android.view.View.MeasureSpec.getMode(widthMeasureSpec);
			int widthSize;
			int heightSize;
			mSpinnerPadding.left = mPaddingLeft > mSelectionLeftPadding ? mPaddingLeft : mSelectionLeftPadding;
			mSpinnerPadding.top = mPaddingTop > mSelectionTopPadding ? mPaddingTop : mSelectionTopPadding;
			mSpinnerPadding.right = mPaddingRight > mSelectionRightPadding ? mPaddingRight : 
				mSelectionRightPadding;
			mSpinnerPadding.bottom = mPaddingBottom > mSelectionBottomPadding ? mPaddingBottom
				 : mSelectionBottomPadding;
			if (mDataChanged)
			{
				handleDataChanged();
			}
			int preferredHeight = 0;
			int preferredWidth = 0;
			bool needsMeasuring = true;
			int selectedPosition = getSelectedItemPosition();
			if (selectedPosition >= 0 && mAdapter != null && selectedPosition < mAdapter.getCount
				())
			{
				// Try looking in the recycler. (Maybe we were measured once already)
				android.view.View view = mRecycler.get(selectedPosition);
				if (view == null)
				{
					// Make a new one
					view = mAdapter.getView(selectedPosition, null, this);
				}
				if (view != null)
				{
					// Put in recycler for re-measuring and/or layout
					mRecycler.put(selectedPosition, view);
				}
				if (view != null)
				{
					if (view.getLayoutParams() == null)
					{
						mBlockLayoutRequests = true;
						view.setLayoutParams(generateDefaultLayoutParams());
						mBlockLayoutRequests = false;
					}
					measureChild(view, widthMeasureSpec, heightMeasureSpec);
					preferredHeight = getChildHeight(view) + mSpinnerPadding.top + mSpinnerPadding.bottom;
					preferredWidth = getChildWidth(view) + mSpinnerPadding.left + mSpinnerPadding.right;
					needsMeasuring = false;
				}
			}
			if (needsMeasuring)
			{
				// No views -- just use padding
				preferredHeight = mSpinnerPadding.top + mSpinnerPadding.bottom;
				if (widthMode == android.view.View.MeasureSpec.UNSPECIFIED)
				{
					preferredWidth = mSpinnerPadding.left + mSpinnerPadding.right;
				}
			}
			preferredHeight = System.Math.Max(preferredHeight, getSuggestedMinimumHeight());
			preferredWidth = System.Math.Max(preferredWidth, getSuggestedMinimumWidth());
			heightSize = resolveSizeAndState(preferredHeight, heightMeasureSpec, 0);
			widthSize = resolveSizeAndState(preferredWidth, widthMeasureSpec, 0);
			setMeasuredDimension(widthSize, heightSize);
			mHeightMeasureSpec = heightMeasureSpec;
			mWidthMeasureSpec = widthMeasureSpec;
		}

		internal virtual int getChildHeight(android.view.View child)
		{
			return child.getMeasuredHeight();
		}

		internal virtual int getChildWidth(android.view.View child)
		{
			return child.getMeasuredWidth();
		}

		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		protected internal override android.view.ViewGroup.LayoutParams generateDefaultLayoutParams
			()
		{
			return new android.view.ViewGroup.LayoutParams(android.view.ViewGroup.LayoutParams
				.MATCH_PARENT, android.view.ViewGroup.LayoutParams.WRAP_CONTENT);
		}

		internal virtual void recycleAllViews()
		{
			int childCount = getChildCount();
			android.widget.AbsSpinner.RecycleBin recycleBin = mRecycler;
			int position = mFirstPosition;
			{
				// All views go in recycler
				for (int i = 0; i < childCount; i++)
				{
					android.view.View v = getChildAt(i);
					int index = position + i;
					recycleBin.put(index, v);
				}
			}
		}

		/// <summary>Jump directly to a specific item in the adapter data.</summary>
		/// <remarks>Jump directly to a specific item in the adapter data.</remarks>
		public virtual void setSelection(int position, bool animate_1)
		{
			// Animate only if requested position is already on screen somewhere
			bool shouldAnimate = animate_1 && mFirstPosition <= position && position <= mFirstPosition
				 + getChildCount() - 1;
			setSelectionInt(position, shouldAnimate);
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override void setSelection(int position)
		{
			setNextSelectedPositionInt(position);
			requestLayout();
			invalidate();
		}

		/// <summary>Makes the item at the supplied position selected.</summary>
		/// <remarks>Makes the item at the supplied position selected.</remarks>
		/// <param name="position">Position to select</param>
		/// <param name="animate">Should the transition be animated</param>
		internal virtual void setSelectionInt(int position, bool animate_1)
		{
			if (position != mOldSelectedPosition)
			{
				mBlockLayoutRequests = true;
				int delta = position - mSelectedPosition;
				setNextSelectedPositionInt(position);
				layout(delta, animate_1);
				mBlockLayoutRequests = false;
			}
		}

		internal abstract void layout(int delta, bool animate_1);

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.view.View getSelectedView()
		{
			if (mItemCount > 0 && mSelectedPosition >= 0)
			{
				return getChildAt(mSelectedPosition - mFirstPosition);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Override to prevent spamming ourselves with layout requests
		/// as we place views
		/// </summary>
		/// <seealso cref="android.view.View.requestLayout()">android.view.View.requestLayout()
		/// 	</seealso>
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void requestLayout()
		{
			if (!mBlockLayoutRequests)
			{
				base.requestLayout();
			}
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override android.widget.SpinnerAdapter getAdapter()
		{
			return mAdapter;
		}

		[Sharpen.OverridesMethod(@"android.widget.AdapterView")]
		public override int getCount()
		{
			return mItemCount;
		}

		/// <summary>Maps a point to a position in the list.</summary>
		/// <remarks>Maps a point to a position in the list.</remarks>
		/// <param name="x">X in local coordinate</param>
		/// <param name="y">Y in local coordinate</param>
		/// <returns>
		/// The position of the item which contains the specified point, or
		/// <see cref="android.widget.AdapterView.INVALID_POSITION">android.widget.AdapterView.INVALID_POSITION
		/// 	</see>
		/// if the point does not intersect an item.
		/// </returns>
		public virtual int pointToPosition(int x, int y)
		{
			android.graphics.Rect frame = mTouchFrame;
			if (frame == null)
			{
				mTouchFrame = new android.graphics.Rect();
				frame = mTouchFrame;
			}
			int count = getChildCount();
			{
				for (int i = count - 1; i >= 0; i--)
				{
					android.view.View child = getChildAt(i);
					if (child.getVisibility() == android.view.View.VISIBLE)
					{
						child.getHitRect(frame);
						if (frame.contains(x, y))
						{
							return mFirstPosition + i;
						}
					}
				}
			}
			return android.widget.AdapterView.INVALID_POSITION;
		}

		internal class SavedState : android.view.View.BaseSavedState
		{
			internal long selectedId;

			internal int position;

			/// <summary>
			/// Constructor called from
			/// <see cref="AbsSpinner.onSaveInstanceState()">AbsSpinner.onSaveInstanceState()</see>
			/// </summary>
			internal SavedState(android.os.Parcelable superState) : base(superState)
			{
			}

			/// <summary>
			/// Constructor called from
			/// <see cref="CREATOR">CREATOR</see>
			/// </summary>
			private SavedState(android.os.Parcel @in) : base(@in)
			{
				selectedId = @in.readLong();
				position = @in.readInt();
			}

			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel @out, int flags)
			{
				base.writeToParcel(@out, flags);
				@out.writeLong(selectedId);
				@out.writeInt(position);
			}

			[Sharpen.OverridesMethod(@"java.lang.Object")]
			public override string ToString()
			{
				return "AbsSpinner.SavedState{" + Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode
					(this)) + " selectedId=" + selectedId + " position=" + position + "}";
			}

			private sealed class _Creator_395 : android.os.ParcelableClass.Creator<android.widget.AbsSpinner
				.SavedState>
			{
				public _Creator_395()
				{
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AbsSpinner.SavedState createFromParcel(android.os.Parcel @in
					)
				{
					return new android.widget.AbsSpinner.SavedState(@in);
				}

				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.AbsSpinner.SavedState[] newArray(int size)
				{
					return new android.widget.AbsSpinner.SavedState[size];
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.AbsSpinner
				.SavedState> CREATOR = new _Creator_395();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			android.os.Parcelable superState = base.onSaveInstanceState();
			android.widget.AbsSpinner.SavedState ss = new android.widget.AbsSpinner.SavedState
				(superState);
			ss.selectedId = getSelectedItemId();
			if (ss.selectedId >= 0)
			{
				ss.position = getSelectedItemPosition();
			}
			else
			{
				ss.position = android.widget.AdapterView.INVALID_POSITION;
			}
			return ss;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			android.widget.AbsSpinner.SavedState ss = (android.widget.AbsSpinner.SavedState)state;
			base.onRestoreInstanceState(ss.getSuperState());
			if (ss.selectedId >= 0)
			{
				mDataChanged = true;
				mNeedSync = true;
				mSyncRowId = ss.selectedId;
				mSyncPosition = ss.position;
				mSyncMode = android.widget.AdapterView.SYNC_SELECTED_POSITION;
				requestLayout();
			}
		}

		internal class RecycleBin
		{
			private readonly android.util.SparseArray<android.view.View> mScrapHeap;

			public virtual void put(int position, android.view.View v)
			{
				this.mScrapHeap.put(position, v);
			}

			internal virtual android.view.View get(int position)
			{
				// System.out.print("Looking for " + position);
				android.view.View result = this.mScrapHeap.get(position);
				if (result != null)
				{
					// System.out.println(" HIT");
					this.mScrapHeap.delete(position);
				}
				// System.out.println(" MISS");
				return result;
			}

			internal virtual void clear()
			{
				android.util.SparseArray<android.view.View> scrapHeap = this.mScrapHeap;
				int count = scrapHeap.size();
				{
					for (int i = 0; i < count; i++)
					{
						android.view.View view = scrapHeap.valueAt(i);
						if (view != null)
						{
							this._enclosing.removeDetachedView(view, true);
						}
					}
				}
				scrapHeap.clear();
			}

			public RecycleBin(AbsSpinner _enclosing)
			{
				this._enclosing = _enclosing;
				mScrapHeap = new android.util.SparseArray<android.view.View>();
			}

			private readonly AbsSpinner _enclosing;
		}
	}
}
