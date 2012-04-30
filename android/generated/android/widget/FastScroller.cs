using Sharpen;

namespace android.widget
{
	/// <summary>Helper class for AbsListView to draw and control the Fast Scroll thumb</summary>
	[Sharpen.Sharpened]
	internal class FastScroller
	{
		internal const string TAG = "FastScroller";

		private static int MIN_PAGES = 4;

		internal const int STATE_NONE = 0;

		internal const int STATE_ENTER = 1;

		internal const int STATE_VISIBLE = 2;

		internal const int STATE_DRAGGING = 3;

		internal const int STATE_EXIT = 4;

		private static readonly int[] PRESSED_STATES = new int[] { android.R.attr.state_pressed
			 };

		private static readonly int[] DEFAULT_STATES = new int[0];

		private static readonly int[] ATTRS = new int[] { android.R.attr.fastScrollTextColor
			, android.R.attr.fastScrollThumbDrawable, android.R.attr.fastScrollTrackDrawable
			, android.R.attr.fastScrollPreviewBackgroundLeft, android.R.attr.fastScrollPreviewBackgroundRight
			, android.R.attr.fastScrollOverlayPosition };

		internal const int TEXT_COLOR = 0;

		internal const int THUMB_DRAWABLE = 1;

		internal const int TRACK_DRAWABLE = 2;

		internal const int PREVIEW_BACKGROUND_LEFT = 3;

		internal const int PREVIEW_BACKGROUND_RIGHT = 4;

		internal const int OVERLAY_POSITION = 5;

		internal const int OVERLAY_FLOATING = 0;

		internal const int OVERLAY_AT_THUMB = 1;

		private android.graphics.drawable.Drawable mThumbDrawable;

		private android.graphics.drawable.Drawable mOverlayDrawable;

		private android.graphics.drawable.Drawable mTrackDrawable;

		private android.graphics.drawable.Drawable mOverlayDrawableLeft;

		private android.graphics.drawable.Drawable mOverlayDrawableRight;

		internal int mThumbH;

		internal int mThumbW;

		internal int mThumbY;

		private android.graphics.RectF mOverlayPos;

		private int mOverlaySize;

		internal android.widget.AbsListView mList;

		internal bool mScrollCompleted;

		private int mVisibleItem;

		private android.graphics.Paint mPaint;

		private int mListOffset;

		private int mItemCount = -1;

		private bool mLongList;

		private object[] mSections;

		private string mSectionText;

		private bool mDrawOverlay;

		private android.widget.FastScroller.ScrollFade mScrollFade;

		private int mState;

		private android.os.Handler mHandler = new android.os.Handler();

		internal android.widget.BaseAdapter mListAdapter;

		private android.widget.SectionIndexer mSectionIndexer;

		private bool mChangedBounds;

		private int mPosition;

		private bool mAlwaysShow;

		private int mOverlayPosition;

		private bool mMatchDragPosition;

		internal float mInitialTouchY;

		internal bool mPendingDrag;

		private int mScaledTouchSlop;

		internal const int FADE_TIMEOUT = 1500;

		internal const int PENDING_DRAG_DELAY = 180;

		private readonly android.graphics.Rect mTmpRect = new android.graphics.Rect();

		private sealed class _Runnable_132 : java.lang.Runnable
		{
			public _Runnable_132(FastScroller _enclosing)
			{
				this._enclosing = _enclosing;
			}

			// Minimum number of pages to justify showing a fast scroll thumb
			// Scroll thumb not showing
			// Not implemented yet - fade-in transition
			// Scroll thumb visible and moving along with the scrollbar
			// Scroll thumb being dragged by user
			// Scroll thumb fading out due to inactivity timeout
			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public void run()
			{
				if (this._enclosing.mList.mIsAttached)
				{
					this._enclosing.beginDrag();
					int viewHeight = this._enclosing.mList.getHeight();
					// Jitter
					int newThumbY = (int)this._enclosing.mInitialTouchY - this._enclosing.mThumbH + 10;
					if (newThumbY < 0)
					{
						newThumbY = 0;
					}
					else
					{
						if (newThumbY + this._enclosing.mThumbH > viewHeight)
						{
							newThumbY = viewHeight - this._enclosing.mThumbH;
						}
					}
					this._enclosing.mThumbY = newThumbY;
					this._enclosing.scrollTo((float)this._enclosing.mThumbY / (viewHeight - this._enclosing
						.mThumbH));
				}
				this._enclosing.mPendingDrag = false;
			}

			private readonly FastScroller _enclosing;
		}

		private readonly java.lang.Runnable mDeferStartDrag;

		public FastScroller(android.content.Context context, android.widget.AbsListView listView
			)
		{
			mDeferStartDrag = new _Runnable_132(this);
			mList = listView;
			init(context);
		}

		public virtual void setAlwaysShow(bool alwaysShow)
		{
			mAlwaysShow = alwaysShow;
			if (alwaysShow)
			{
				mHandler.removeCallbacks(mScrollFade);
				setState(STATE_VISIBLE);
			}
			else
			{
				if (mState == STATE_VISIBLE)
				{
					mHandler.postDelayed(mScrollFade, FADE_TIMEOUT);
				}
			}
		}

		public virtual bool isAlwaysShowEnabled()
		{
			return mAlwaysShow;
		}

		private void refreshDrawableState()
		{
			int[] state = mState == STATE_DRAGGING ? PRESSED_STATES : DEFAULT_STATES;
			if (mThumbDrawable != null && mThumbDrawable.isStateful())
			{
				mThumbDrawable.setState(state);
			}
			if (mTrackDrawable != null && mTrackDrawable.isStateful())
			{
				mTrackDrawable.setState(state);
			}
		}

		public virtual void setScrollbarPosition(int position)
		{
			mPosition = position;
			switch (position)
			{
				case android.view.View.SCROLLBAR_POSITION_DEFAULT:
				case android.view.View.SCROLLBAR_POSITION_RIGHT:
				default:
				{
					mOverlayDrawable = mOverlayDrawableRight;
					break;
				}

				case android.view.View.SCROLLBAR_POSITION_LEFT:
				{
					mOverlayDrawable = mOverlayDrawableLeft;
					break;
				}
			}
		}

		public virtual int getWidth()
		{
			return mThumbW;
		}

		public virtual void setState(int state)
		{
			switch (state)
			{
				case STATE_NONE:
				{
					mHandler.removeCallbacks(mScrollFade);
					mList.invalidate();
					break;
				}

				case STATE_VISIBLE:
				{
					if (mState != STATE_VISIBLE)
					{
						// Optimization
						resetThumbPos();
					}
					goto case STATE_DRAGGING;
				}

				case STATE_DRAGGING:
				{
					// Fall through
					mHandler.removeCallbacks(mScrollFade);
					break;
				}

				case STATE_EXIT:
				{
					int viewWidth = mList.getWidth();
					mList.invalidate(viewWidth - mThumbW, mThumbY, viewWidth, mThumbY + mThumbH);
					break;
				}
			}
			mState = state;
			refreshDrawableState();
		}

		public virtual int getState()
		{
			return mState;
		}

		private void resetThumbPos()
		{
			int viewWidth = mList.getWidth();
			switch (mPosition)
			{
				case android.view.View.SCROLLBAR_POSITION_DEFAULT:
				case android.view.View.SCROLLBAR_POSITION_RIGHT:
				{
					// Bounds are always top right. Y coordinate get's translated during draw
					mThumbDrawable.setBounds(viewWidth - mThumbW, 0, viewWidth, mThumbH);
					break;
				}

				case android.view.View.SCROLLBAR_POSITION_LEFT:
				{
					mThumbDrawable.setBounds(0, 0, mThumbW, mThumbH);
					break;
				}
			}
			mThumbDrawable.setAlpha(android.widget.FastScroller.ScrollFade.ALPHA_MAX);
		}

		private void useThumbDrawable(android.content.Context context, android.graphics.drawable.Drawable
			 drawable)
		{
			mThumbDrawable = drawable;
			if (drawable is android.graphics.drawable.NinePatchDrawable)
			{
				mThumbW = context.getResources().getDimensionPixelSize(android.@internal.R.dimen.
					fastscroll_thumb_width);
				mThumbH = context.getResources().getDimensionPixelSize(android.@internal.R.dimen.
					fastscroll_thumb_height);
			}
			else
			{
				mThumbW = drawable.getIntrinsicWidth();
				mThumbH = drawable.getIntrinsicHeight();
			}
			mChangedBounds = true;
		}

		private void init(android.content.Context context)
		{
			// Get both the scrollbar states drawables
			android.content.res.TypedArray ta = context.getTheme().obtainStyledAttributes(ATTRS
				);
			useThumbDrawable(context, ta.getDrawable(THUMB_DRAWABLE));
			mTrackDrawable = ta.getDrawable(TRACK_DRAWABLE);
			mOverlayDrawableLeft = ta.getDrawable(PREVIEW_BACKGROUND_LEFT);
			mOverlayDrawableRight = ta.getDrawable(PREVIEW_BACKGROUND_RIGHT);
			mOverlayPosition = ta.getInt(OVERLAY_POSITION, OVERLAY_FLOATING);
			mScrollCompleted = true;
			getSectionsFromIndexer();
			mOverlaySize = context.getResources().getDimensionPixelSize(android.@internal.R.dimen
				.fastscroll_overlay_size);
			mOverlayPos = new android.graphics.RectF();
			mScrollFade = new android.widget.FastScroller.ScrollFade(this);
			mPaint = new android.graphics.Paint();
			mPaint.setAntiAlias(true);
			mPaint.setTextAlign(android.graphics.Paint.Align.CENTER);
			mPaint.setTextSize(mOverlaySize / 2);
			android.content.res.ColorStateList textColor = ta.getColorStateList(TEXT_COLOR);
			int textColorNormal = textColor.getDefaultColor();
			mPaint.setColor(textColorNormal);
			mPaint.setStyle(android.graphics.Paint.Style.FILL_AND_STROKE);
			// to show mOverlayDrawable properly
			if (mList.getWidth() > 0 && mList.getHeight() > 0)
			{
				onSizeChanged(mList.getWidth(), mList.getHeight(), 0, 0);
			}
			mState = STATE_NONE;
			refreshDrawableState();
			ta.recycle();
			mScaledTouchSlop = android.view.ViewConfiguration.get(context).getScaledTouchSlop
				();
			mMatchDragPosition = context.getApplicationInfo().targetSdkVersion >= android.os.Build
				.VERSION_CODES.HONEYCOMB;
			setScrollbarPosition(mList.getVerticalScrollbarPosition());
		}

		internal virtual void stop()
		{
			setState(STATE_NONE);
		}

		internal virtual bool isVisible()
		{
			return !(mState == STATE_NONE);
		}

		public virtual void draw(android.graphics.Canvas canvas)
		{
			if (mState == STATE_NONE)
			{
				// No need to draw anything
				return;
			}
			int y = mThumbY;
			int viewWidth = mList.getWidth();
			android.widget.FastScroller.ScrollFade scrollFade = mScrollFade;
			int alpha = -1;
			if (mState == STATE_EXIT)
			{
				alpha = scrollFade.getAlpha();
				if (alpha < android.widget.FastScroller.ScrollFade.ALPHA_MAX / 2)
				{
					mThumbDrawable.setAlpha(alpha * 2);
				}
				int left = 0;
				switch (mPosition)
				{
					case android.view.View.SCROLLBAR_POSITION_DEFAULT:
					case android.view.View.SCROLLBAR_POSITION_RIGHT:
					{
						left = viewWidth - (mThumbW * alpha) / android.widget.FastScroller.ScrollFade.ALPHA_MAX;
						break;
					}

					case android.view.View.SCROLLBAR_POSITION_LEFT:
					{
						left = -mThumbW + (mThumbW * alpha) / android.widget.FastScroller.ScrollFade.ALPHA_MAX;
						break;
					}
				}
				mThumbDrawable.setBounds(left, 0, left + mThumbW, mThumbH);
				mChangedBounds = true;
			}
			if (mTrackDrawable != null)
			{
				android.graphics.Rect thumbBounds = mThumbDrawable.getBounds();
				int left = thumbBounds.left;
				int halfThumbHeight = (thumbBounds.bottom - thumbBounds.top) / 2;
				int trackWidth = mTrackDrawable.getIntrinsicWidth();
				int trackLeft = (left + mThumbW / 2) - trackWidth / 2;
				mTrackDrawable.setBounds(trackLeft, halfThumbHeight, trackLeft + trackWidth, mList
					.getHeight() - halfThumbHeight);
				mTrackDrawable.draw(canvas);
			}
			canvas.translate(0, y);
			mThumbDrawable.draw(canvas);
			canvas.translate(0, -y);
			// If user is dragging the scroll bar, draw the alphabet overlay
			if (mState == STATE_DRAGGING && mDrawOverlay)
			{
				if (mOverlayPosition == OVERLAY_AT_THUMB)
				{
					int left = 0;
					switch (mPosition)
					{
						case android.view.View.SCROLLBAR_POSITION_DEFAULT:
						case android.view.View.SCROLLBAR_POSITION_RIGHT:
						default:
						{
							left = System.Math.Max(0, mThumbDrawable.getBounds().left - mThumbW - mOverlaySize
								);
							break;
						}

						case android.view.View.SCROLLBAR_POSITION_LEFT:
						{
							left = System.Math.Min(mThumbDrawable.getBounds().right + mThumbW, mList.getWidth
								() - mOverlaySize);
							break;
						}
					}
					int top = System.Math.Max(0, System.Math.Min(y + (mThumbH - mOverlaySize) / 2, mList
						.getHeight() - mOverlaySize));
					android.graphics.RectF pos = mOverlayPos;
					pos.left = left;
					pos.right = pos.left + mOverlaySize;
					pos.top = top;
					pos.bottom = pos.top + mOverlaySize;
					if (mOverlayDrawable != null)
					{
						mOverlayDrawable.setBounds((int)pos.left, (int)pos.top, (int)pos.right, (int)pos.
							bottom);
					}
				}
				mOverlayDrawable.draw(canvas);
				android.graphics.Paint paint = mPaint;
				float descent = paint.descent();
				android.graphics.RectF rectF = mOverlayPos;
				android.graphics.Rect tmpRect = mTmpRect;
				mOverlayDrawable.getPadding(tmpRect);
				int hOff = (tmpRect.right - tmpRect.left) / 2;
				int vOff = (tmpRect.bottom - tmpRect.top) / 2;
				canvas.drawText(mSectionText, (int)(rectF.left + rectF.right) / 2 - hOff, (int)(rectF
					.bottom + rectF.top) / 2 + mOverlaySize / 4 - descent - vOff, paint);
			}
			else
			{
				if (mState == STATE_EXIT)
				{
					if (alpha == 0)
					{
						// Done with exit
						setState(STATE_NONE);
					}
					else
					{
						if (mTrackDrawable != null)
						{
							mList.invalidate(viewWidth - mThumbW, 0, viewWidth, mList.getHeight());
						}
						else
						{
							mList.invalidate(viewWidth - mThumbW, y, viewWidth, y + mThumbH);
						}
					}
				}
			}
		}

		internal virtual void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			if (mThumbDrawable != null)
			{
				switch (mPosition)
				{
					case android.view.View.SCROLLBAR_POSITION_DEFAULT:
					case android.view.View.SCROLLBAR_POSITION_RIGHT:
					default:
					{
						mThumbDrawable.setBounds(w - mThumbW, 0, w, mThumbH);
						break;
					}

					case android.view.View.SCROLLBAR_POSITION_LEFT:
					{
						mThumbDrawable.setBounds(0, 0, mThumbW, mThumbH);
						break;
					}
				}
			}
			if (mOverlayPosition == OVERLAY_FLOATING)
			{
				android.graphics.RectF pos = mOverlayPos;
				pos.left = (w - mOverlaySize) / 2;
				pos.right = pos.left + mOverlaySize;
				pos.top = h / 10;
				// 10% from top
				pos.bottom = pos.top + mOverlaySize;
				if (mOverlayDrawable != null)
				{
					mOverlayDrawable.setBounds((int)pos.left, (int)pos.top, (int)pos.right, (int)pos.
						bottom);
				}
			}
		}

		internal virtual void onItemCountChanged(int oldCount, int newCount)
		{
			if (mAlwaysShow)
			{
				mLongList = true;
			}
		}

		internal virtual void onScroll(android.widget.AbsListView view, int firstVisibleItem
			, int visibleItemCount, int totalItemCount)
		{
			// Are there enough pages to require fast scroll? Recompute only if total count changes
			if (mItemCount != totalItemCount && visibleItemCount > 0)
			{
				mItemCount = totalItemCount;
				mLongList = mItemCount / visibleItemCount >= MIN_PAGES;
			}
			if (mAlwaysShow)
			{
				mLongList = true;
			}
			if (!mLongList)
			{
				if (mState != STATE_NONE)
				{
					setState(STATE_NONE);
				}
				return;
			}
			if (totalItemCount - visibleItemCount > 0 && mState != STATE_DRAGGING)
			{
				mThumbY = getThumbPositionForListPosition(firstVisibleItem, visibleItemCount, totalItemCount
					);
				if (mChangedBounds)
				{
					resetThumbPos();
					mChangedBounds = false;
				}
			}
			mScrollCompleted = true;
			if (firstVisibleItem == mVisibleItem)
			{
				return;
			}
			mVisibleItem = firstVisibleItem;
			if (mState != STATE_DRAGGING)
			{
				setState(STATE_VISIBLE);
				if (!mAlwaysShow)
				{
					mHandler.postDelayed(mScrollFade, FADE_TIMEOUT);
				}
			}
		}

		internal virtual android.widget.SectionIndexer getSectionIndexer()
		{
			return mSectionIndexer;
		}

		internal virtual object[] getSections()
		{
			if (mListAdapter == null && mList != null)
			{
				getSectionsFromIndexer();
			}
			return mSections;
		}

		internal virtual void getSectionsFromIndexer()
		{
			android.widget.Adapter adapter = mList.getAdapter();
			mSectionIndexer = null;
			if (adapter is android.widget.HeaderViewListAdapter)
			{
				mListOffset = ((android.widget.HeaderViewListAdapter)adapter).getHeadersCount();
				adapter = ((android.widget.HeaderViewListAdapter)adapter).getWrappedAdapter();
			}
			if (adapter is android.widget.ExpandableListConnector)
			{
				android.widget.ExpandableListAdapter expAdapter = ((android.widget.ExpandableListConnector
					)adapter).getAdapter();
				if (expAdapter is android.widget.SectionIndexer)
				{
					mSectionIndexer = (android.widget.SectionIndexer)expAdapter;
					mListAdapter = (android.widget.BaseAdapter)adapter;
					mSections = mSectionIndexer.getSections();
				}
			}
			else
			{
				if (adapter is android.widget.SectionIndexer)
				{
					mListAdapter = (android.widget.BaseAdapter)adapter;
					mSectionIndexer = (android.widget.SectionIndexer)adapter;
					mSections = mSectionIndexer.getSections();
					if (mSections == null)
					{
						mSections = new string[] { " " };
					}
				}
				else
				{
					mListAdapter = (android.widget.BaseAdapter)adapter;
					mSections = new string[] { " " };
				}
			}
		}

		public virtual void onSectionsChanged()
		{
			mListAdapter = null;
		}

		internal virtual void scrollTo(float position)
		{
			int count = mList.getCount();
			mScrollCompleted = false;
			float fThreshold = (1.0f / count) / 8;
			object[] sections = mSections;
			int sectionIndex;
			if (sections != null && sections.Length > 1)
			{
				int nSections = sections.Length;
				int section = (int)(position * nSections);
				if (section >= nSections)
				{
					section = nSections - 1;
				}
				int exactSection = section;
				sectionIndex = section;
				int index = mSectionIndexer.getPositionForSection(section);
				// Given the expected section and index, the following code will
				// try to account for missing sections (no names starting with..)
				// It will compute the scroll space of surrounding empty sections
				// and interpolate the currently visible letter's range across the
				// available space, so that there is always some list movement while
				// the user moves the thumb.
				int nextIndex = count;
				int prevIndex = index;
				int prevSection = section;
				int nextSection = section + 1;
				// Assume the next section is unique
				if (section < nSections - 1)
				{
					nextIndex = mSectionIndexer.getPositionForSection(section + 1);
				}
				// Find the previous index if we're slicing the previous section
				if (nextIndex == index)
				{
					// Non-existent letter
					while (section > 0)
					{
						section--;
						prevIndex = mSectionIndexer.getPositionForSection(section);
						if (prevIndex != index)
						{
							prevSection = section;
							sectionIndex = section;
							break;
						}
						else
						{
							if (section == 0)
							{
								// When section reaches 0 here, sectionIndex must follow it.
								// Assuming mSectionIndexer.getPositionForSection(0) == 0.
								sectionIndex = 0;
								break;
							}
						}
					}
				}
				// Find the next index, in case the assumed next index is not
				// unique. For instance, if there is no P, then request for P's 
				// position actually returns Q's. So we need to look ahead to make
				// sure that there is really a Q at Q's position. If not, move 
				// further down...
				int nextNextSection = nextSection + 1;
				while (nextNextSection < nSections && mSectionIndexer.getPositionForSection(nextNextSection
					) == nextIndex)
				{
					nextNextSection++;
					nextSection++;
				}
				// Compute the beginning and ending scroll range percentage of the
				// currently visible letter. This could be equal to or greater than
				// (1 / nSections). 
				float fPrev = (float)prevSection / nSections;
				float fNext = (float)nextSection / nSections;
				if (prevSection == exactSection && position - fPrev < fThreshold)
				{
					index = prevIndex;
				}
				else
				{
					index = prevIndex + (int)((nextIndex - prevIndex) * (position - fPrev) / (fNext -
						 fPrev));
				}
				// Don't overflow
				if (index > count - 1)
				{
					index = count - 1;
				}
				if (mList is android.widget.ExpandableListView)
				{
					android.widget.ExpandableListView expList = (android.widget.ExpandableListView)mList;
					expList.setSelectionFromTop(expList.getFlatListPosition(android.widget.ExpandableListView
						.getPackedPositionForGroup(index + mListOffset)), 0);
				}
				else
				{
					if (mList is android.widget.ListView)
					{
						((android.widget.ListView)mList).setSelectionFromTop(index + mListOffset, 0);
					}
					else
					{
						mList.setSelection(index + mListOffset);
					}
				}
			}
			else
			{
				int index = (int)(position * count);
				// Don't overflow
				if (index > count - 1)
				{
					index = count - 1;
				}
				if (mList is android.widget.ExpandableListView)
				{
					android.widget.ExpandableListView expList = (android.widget.ExpandableListView)mList;
					expList.setSelectionFromTop(expList.getFlatListPosition(android.widget.ExpandableListView
						.getPackedPositionForGroup(index + mListOffset)), 0);
				}
				else
				{
					if (mList is android.widget.ListView)
					{
						((android.widget.ListView)mList).setSelectionFromTop(index + mListOffset, 0);
					}
					else
					{
						mList.setSelection(index + mListOffset);
					}
				}
				sectionIndex = -1;
			}
			if (sectionIndex >= 0)
			{
				string text = mSectionText = sections[sectionIndex].ToString();
				mDrawOverlay = (text.Length != 1 || text[0] != ' ') && sectionIndex < sections.Length;
			}
			else
			{
				mDrawOverlay = false;
			}
		}

		private int getThumbPositionForListPosition(int firstVisibleItem, int visibleItemCount
			, int totalItemCount)
		{
			if (mSectionIndexer == null || mListAdapter == null)
			{
				getSectionsFromIndexer();
			}
			if (mSectionIndexer == null || !mMatchDragPosition)
			{
				return ((mList.getHeight() - mThumbH) * firstVisibleItem) / (totalItemCount - visibleItemCount
					);
			}
			firstVisibleItem -= mListOffset;
			if (firstVisibleItem < 0)
			{
				return 0;
			}
			totalItemCount -= mListOffset;
			int trackHeight = mList.getHeight() - mThumbH;
			int section = mSectionIndexer.getSectionForPosition(firstVisibleItem);
			int sectionPos = mSectionIndexer.getPositionForSection(section);
			int nextSectionPos = mSectionIndexer.getPositionForSection(section + 1);
			int sectionCount = mSections.Length;
			int positionsInSection = nextSectionPos - sectionPos;
			android.view.View child = mList.getChildAt(0);
			float incrementalPos = child == null ? 0 : firstVisibleItem + (float)(mList.getPaddingTop
				() - child.getTop()) / child.getHeight();
			float posWithinSection = (incrementalPos - sectionPos) / positionsInSection;
			int result = (int)((section + posWithinSection) / sectionCount * trackHeight);
			// Fake out the scrollbar for the last item. Since the section indexer won't
			// ever actually move the list in this end space, make scrolling across the last item
			// account for whatever space is remaining.
			if (firstVisibleItem > 0 && firstVisibleItem + visibleItemCount == totalItemCount)
			{
				android.view.View lastChild = mList.getChildAt(visibleItemCount - 1);
				float lastItemVisible = (float)(mList.getHeight() - mList.getPaddingBottom() - lastChild
					.getTop()) / lastChild.getHeight();
				result += (int)((trackHeight - result) * lastItemVisible);
			}
			return result;
		}

		private void cancelFling()
		{
			// Cancel the list fling
			android.view.MotionEvent cancelFling_1 = android.view.MotionEvent.obtain(0, 0, android.view.MotionEvent
				.ACTION_CANCEL, 0, 0, 0);
			mList.onTouchEvent(cancelFling_1);
			cancelFling_1.recycle();
		}

		internal virtual void cancelPendingDrag()
		{
			mList.removeCallbacks(mDeferStartDrag);
			mPendingDrag = false;
		}

		internal virtual void startPendingDrag()
		{
			mPendingDrag = true;
			mList.postDelayed(mDeferStartDrag, PENDING_DRAG_DELAY);
		}

		internal virtual void beginDrag()
		{
			setState(STATE_DRAGGING);
			if (mListAdapter == null && mList != null)
			{
				getSectionsFromIndexer();
			}
			if (mList != null)
			{
				mList.requestDisallowInterceptTouchEvent(true);
				mList.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
					);
			}
			cancelFling();
		}

		internal virtual bool onInterceptTouchEvent(android.view.MotionEvent ev)
		{
			switch (ev.getActionMasked())
			{
				case android.view.MotionEvent.ACTION_DOWN:
				{
					if (mState > STATE_NONE && isPointInside(ev.getX(), ev.getY()))
					{
						if (!mList.isInScrollingContainer())
						{
							beginDrag();
							return true;
						}
						mInitialTouchY = ev.getY();
						startPendingDrag();
					}
					break;
				}

				case android.view.MotionEvent.ACTION_UP:
				case android.view.MotionEvent.ACTION_CANCEL:
				{
					cancelPendingDrag();
					break;
				}
			}
			return false;
		}

		internal virtual bool onTouchEvent(android.view.MotionEvent me)
		{
			if (mState == STATE_NONE)
			{
				return false;
			}
			int action = me.getAction();
			if (action == android.view.MotionEvent.ACTION_DOWN)
			{
				if (isPointInside(me.getX(), me.getY()))
				{
					if (!mList.isInScrollingContainer())
					{
						beginDrag();
						return true;
					}
					mInitialTouchY = me.getY();
					startPendingDrag();
				}
			}
			else
			{
				if (action == android.view.MotionEvent.ACTION_UP)
				{
					// don't add ACTION_CANCEL here
					if (mPendingDrag)
					{
						// Allow a tap to scroll.
						beginDrag();
						int viewHeight = mList.getHeight();
						// Jitter
						int newThumbY = (int)me.getY() - mThumbH + 10;
						if (newThumbY < 0)
						{
							newThumbY = 0;
						}
						else
						{
							if (newThumbY + mThumbH > viewHeight)
							{
								newThumbY = viewHeight - mThumbH;
							}
						}
						mThumbY = newThumbY;
						scrollTo((float)mThumbY / (viewHeight - mThumbH));
						cancelPendingDrag();
					}
					// Will hit the STATE_DRAGGING check below
					if (mState == STATE_DRAGGING)
					{
						if (mList != null)
						{
							// ViewGroup does the right thing already, but there might
							// be other classes that don't properly reset on touch-up,
							// so do this explicitly just in case.
							mList.requestDisallowInterceptTouchEvent(false);
							mList.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_IDLE
								);
						}
						setState(STATE_VISIBLE);
						android.os.Handler handler = mHandler;
						handler.removeCallbacks(mScrollFade);
						if (!mAlwaysShow)
						{
							handler.postDelayed(mScrollFade, 1000);
						}
						mList.invalidate();
						return true;
					}
				}
				else
				{
					if (action == android.view.MotionEvent.ACTION_MOVE)
					{
						if (mPendingDrag)
						{
							float y = me.getY();
							if (System.Math.Abs(y - mInitialTouchY) > mScaledTouchSlop)
							{
								setState(STATE_DRAGGING);
								if (mListAdapter == null && mList != null)
								{
									getSectionsFromIndexer();
								}
								if (mList != null)
								{
									mList.requestDisallowInterceptTouchEvent(true);
									mList.reportScrollStateChange(android.widget.AbsListView.OnScrollListenerClass.SCROLL_STATE_TOUCH_SCROLL
										);
								}
								cancelFling();
								cancelPendingDrag();
							}
						}
						// Will hit the STATE_DRAGGING check below
						if (mState == STATE_DRAGGING)
						{
							int viewHeight = mList.getHeight();
							// Jitter
							int newThumbY = (int)me.getY() - mThumbH + 10;
							if (newThumbY < 0)
							{
								newThumbY = 0;
							}
							else
							{
								if (newThumbY + mThumbH > viewHeight)
								{
									newThumbY = viewHeight - mThumbH;
								}
							}
							if (System.Math.Abs(mThumbY - newThumbY) < 2)
							{
								return true;
							}
							mThumbY = newThumbY;
							// If the previous scrollTo is still pending
							if (mScrollCompleted)
							{
								scrollTo((float)mThumbY / (viewHeight - mThumbH));
							}
							return true;
						}
					}
					else
					{
						if (action == android.view.MotionEvent.ACTION_CANCEL)
						{
							cancelPendingDrag();
						}
					}
				}
			}
			return false;
		}

		internal virtual bool isPointInside(float x, float y)
		{
			bool inTrack = false;
			switch (mPosition)
			{
				case android.view.View.SCROLLBAR_POSITION_DEFAULT:
				case android.view.View.SCROLLBAR_POSITION_RIGHT:
				default:
				{
					inTrack = x > mList.getWidth() - mThumbW;
					break;
				}

				case android.view.View.SCROLLBAR_POSITION_LEFT:
				{
					inTrack = x < mThumbW;
					break;
				}
			}
			// Allow taps in the track to start moving.
			return inTrack && (mTrackDrawable != null || y >= mThumbY && y <= mThumbY + mThumbH
				);
		}

		public class ScrollFade : java.lang.Runnable
		{
			internal long mStartTime;

			internal long mFadeDuration;

			internal const int ALPHA_MAX = 208;

			internal const long FADE_DURATION = 200;

			internal virtual void startFade()
			{
				this.mFadeDuration = FADE_DURATION;
				this.mStartTime = android.os.SystemClock.uptimeMillis();
				this._enclosing.setState(android.widget.FastScroller.STATE_EXIT);
			}

			internal virtual int getAlpha()
			{
				if (this._enclosing.getState() != android.widget.FastScroller.STATE_EXIT)
				{
					return ALPHA_MAX;
				}
				int alpha;
				long now = android.os.SystemClock.uptimeMillis();
				if (now > this.mStartTime + this.mFadeDuration)
				{
					alpha = 0;
				}
				else
				{
					alpha = (int)(ALPHA_MAX - ((now - this.mStartTime) * ALPHA_MAX) / this.mFadeDuration
						);
				}
				return alpha;
			}

			[Sharpen.ImplementsInterface(@"java.lang.Runnable")]
			public virtual void run()
			{
				if (this._enclosing.getState() != android.widget.FastScroller.STATE_EXIT)
				{
					this.startFade();
					return;
				}
				if (this.getAlpha() > 0)
				{
					this._enclosing.mList.invalidate();
				}
				else
				{
					this._enclosing.setState(android.widget.FastScroller.STATE_NONE);
				}
			}

			internal ScrollFade(FastScroller _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly FastScroller _enclosing;
		}
	}
}
