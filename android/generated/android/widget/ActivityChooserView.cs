using Sharpen;

namespace android.widget
{
	/// <summary>
	/// This class is a view for choosing an activity for handling a given
	/// <see cref="android.content.Intent">android.content.Intent</see>
	/// .
	/// <p>
	/// The view is composed of two adjacent buttons:
	/// <ul>
	/// <li>
	/// The left button is an immediate action and allows one click activity choosing.
	/// Tapping this button immediately executes the intent without requiring any further
	/// user input. Long press on this button shows a popup for changing the default
	/// activity.
	/// </li>
	/// <li>
	/// The right button is an overflow action and provides an optimized menu
	/// of additional activities. Tapping this button shows a popup anchored to this
	/// view, listing the most frequently used activities. This list is initially
	/// limited to a small number of items in frequency used order. The last item,
	/// "Show all..." serves as an affordance to display all available activities.
	/// </li>
	/// </ul>
	/// </p>
	/// </summary>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActivityChooserView : android.view.ViewGroup, android.widget.ActivityChooserModel
		.ActivityChooserModelClient
	{
		/// <summary>
		/// An adapter for displaying the activities in an
		/// <see cref="AdapterView{T}">AdapterView&lt;T&gt;</see>
		/// .
		/// </summary>
		private readonly android.widget.ActivityChooserView.ActivityChooserViewAdapter mAdapter;

		/// <summary>Implementation of various interfaces to avoid publishing them in the APIs.
		/// 	</summary>
		/// <remarks>Implementation of various interfaces to avoid publishing them in the APIs.
		/// 	</remarks>
		private readonly android.widget.ActivityChooserView.Callbacks mCallbacks;

		/// <summary>The content of this view.</summary>
		/// <remarks>The content of this view.</remarks>
		private readonly android.widget.LinearLayout mActivityChooserContent;

		/// <summary>Stores the background drawable to allow hiding and latter showing.</summary>
		/// <remarks>Stores the background drawable to allow hiding and latter showing.</remarks>
		private readonly android.graphics.drawable.Drawable mActivityChooserContentBackground;

		/// <summary>The expand activities action button;</summary>
		private readonly android.widget.FrameLayout mExpandActivityOverflowButton;

		/// <summary>The image for the expand activities action button;</summary>
		private readonly android.widget.ImageView mExpandActivityOverflowButtonImage;

		/// <summary>The default activities action button;</summary>
		private readonly android.widget.FrameLayout mDefaultActivityButton;

		/// <summary>The image for the default activities action button;</summary>
		private readonly android.widget.ImageView mDefaultActivityButtonImage;

		/// <summary>The maximal width of the list popup.</summary>
		/// <remarks>The maximal width of the list popup.</remarks>
		private readonly int mListPopupMaxWidth;

		/// <summary>The ActionProvider hosting this view, if applicable.</summary>
		/// <remarks>The ActionProvider hosting this view, if applicable.</remarks>
		internal android.view.ActionProvider mProvider;

		private sealed class _DataSetObserver_118 : android.database.DataSetObserver
		{
			public _DataSetObserver_118(ActivityChooserView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				base.onChanged();
				this._enclosing.mAdapter.notifyDataSetChanged();
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onInvalidated()
			{
				base.onInvalidated();
				this._enclosing.mAdapter.notifyDataSetInvalidated();
			}

			private readonly ActivityChooserView _enclosing;
		}

		/// <summary>Observer for the model data.</summary>
		/// <remarks>Observer for the model data.</remarks>
		private readonly android.database.DataSetObserver mModelDataSetOberver;

		private sealed class _OnGlobalLayoutListener_132 : android.view.ViewTreeObserver.
			OnGlobalLayoutListener
		{
			public _OnGlobalLayoutListener_132(ActivityChooserView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.ViewTreeObserver.OnGlobalLayoutListener"
				)]
			public void onGlobalLayout()
			{
				if (this._enclosing.isShowingPopup())
				{
					if (!this._enclosing.isShown())
					{
						this._enclosing.getListPopupWindow().dismiss();
					}
					else
					{
						this._enclosing.getListPopupWindow().show();
						if (this._enclosing.mProvider != null)
						{
							this._enclosing.mProvider.subUiVisibilityChanged(true);
						}
					}
				}
			}

			private readonly ActivityChooserView _enclosing;
		}

		private readonly android.view.ViewTreeObserver.OnGlobalLayoutListener mOnGlobalLayoutListener;

		/// <summary>Popup window for showing the activity overflow list.</summary>
		/// <remarks>Popup window for showing the activity overflow list.</remarks>
		private android.widget.ListPopupWindow mListPopupWindow;

		/// <summary>Listener for the dismissal of the popup/alert.</summary>
		/// <remarks>Listener for the dismissal of the popup/alert.</remarks>
		private android.widget.PopupWindow.OnDismissListener mOnDismissListener;

		/// <summary>Flag whether a default activity currently being selected.</summary>
		/// <remarks>Flag whether a default activity currently being selected.</remarks>
		private bool mIsSelectingDefaultActivity;

		/// <summary>The count of activities in the popup.</summary>
		/// <remarks>The count of activities in the popup.</remarks>
		private int mInitialActivityCount = android.widget.ActivityChooserView.ActivityChooserViewAdapter
			.MAX_ACTIVITY_COUNT_DEFAULT;

		/// <summary>Flag whether this view is attached to a window.</summary>
		/// <remarks>Flag whether this view is attached to a window.</remarks>
		private bool mIsAttachedToWindow;

		/// <summary>String resource for formatting content description of the default target.
		/// 	</summary>
		/// <remarks>String resource for formatting content description of the default target.
		/// 	</remarks>
		private int mDefaultActionButtonContentDescription;

		/// <summary>Create a new instance.</summary>
		/// <remarks>Create a new instance.</remarks>
		/// <param name="context">The application environment.</param>
		public ActivityChooserView(android.content.Context context) : this(context, null)
		{
			mModelDataSetOberver = new _DataSetObserver_118(this);
			mOnGlobalLayoutListener = new _OnGlobalLayoutListener_132(this);
		}

		/// <summary>Create a new instance.</summary>
		/// <remarks>Create a new instance.</remarks>
		/// <param name="context">The application environment.</param>
		/// <param name="attrs">A collection of attributes.</param>
		public ActivityChooserView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
			mModelDataSetOberver = new _DataSetObserver_118(this);
			mOnGlobalLayoutListener = new _OnGlobalLayoutListener_132(this);
		}

		private sealed class _DataSetObserver_239 : android.database.DataSetObserver
		{
			public _DataSetObserver_239(ActivityChooserView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.OverridesMethod(@"android.database.DataSetObserver")]
			public override void onChanged()
			{
				base.onChanged();
				this._enclosing.updateAppearance();
			}

			private readonly ActivityChooserView _enclosing;
		}

		/// <summary>Create a new instance.</summary>
		/// <remarks>Create a new instance.</remarks>
		/// <param name="context">The application environment.</param>
		/// <param name="attrs">A collection of attributes.</param>
		/// <param name="defStyle">The default style to apply to this view.</param>
		public ActivityChooserView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			mModelDataSetOberver = new _DataSetObserver_118(this);
			mOnGlobalLayoutListener = new _OnGlobalLayoutListener_132(this);
			android.content.res.TypedArray attributesArray = context.obtainStyledAttributes(attrs
				, android.@internal.R.styleable.ActivityChooserView, defStyle, 0);
			mInitialActivityCount = attributesArray.getInt(android.@internal.R.styleable.ActivityChooserView_initialActivityCount
				, android.widget.ActivityChooserView.ActivityChooserViewAdapter.MAX_ACTIVITY_COUNT_DEFAULT
				);
			android.graphics.drawable.Drawable expandActivityOverflowButtonDrawable = attributesArray
				.getDrawable(android.@internal.R.styleable.ActivityChooserView_expandActivityOverflowButtonDrawable
				);
			attributesArray.recycle();
			android.view.LayoutInflater inflater = android.view.LayoutInflater.from(mContext);
			inflater.inflate(android.@internal.R.layout.activity_chooser_view, this, true);
			mCallbacks = new android.widget.ActivityChooserView.Callbacks(this);
			mActivityChooserContent = (android.widget.LinearLayout)findViewById(android.@internal.R
				.id.activity_chooser_view_content);
			mActivityChooserContentBackground = mActivityChooserContent.getBackground();
			mDefaultActivityButton = (android.widget.FrameLayout)findViewById(android.@internal.R
				.id.default_activity_button);
			mDefaultActivityButton.setOnClickListener(mCallbacks);
			mDefaultActivityButton.setOnLongClickListener(mCallbacks);
			mDefaultActivityButtonImage = (android.widget.ImageView)mDefaultActivityButton.findViewById
				(android.@internal.R.id.image);
			mExpandActivityOverflowButton = (android.widget.FrameLayout)findViewById(android.@internal.R
				.id.expand_activities_button);
			mExpandActivityOverflowButton.setOnClickListener(mCallbacks);
			mExpandActivityOverflowButtonImage = (android.widget.ImageView)mExpandActivityOverflowButton
				.findViewById(android.@internal.R.id.image);
			mExpandActivityOverflowButtonImage.setImageDrawable(expandActivityOverflowButtonDrawable
				);
			mAdapter = new android.widget.ActivityChooserView.ActivityChooserViewAdapter(this
				);
			mAdapter.registerDataSetObserver(new _DataSetObserver_239(this));
			android.content.res.Resources resources = context.getResources();
			mListPopupMaxWidth = System.Math.Max(resources.getDisplayMetrics().widthPixels / 
				2, resources.getDimensionPixelSize(android.@internal.R.dimen.config_prefDialogWidth
				));
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		[Sharpen.ImplementsInterface(@"android.widget.ActivityChooserModel.ActivityChooserModelClient"
			)]
		public virtual void setActivityChooserModel(android.widget.ActivityChooserModel dataModel
			)
		{
			mAdapter.setDataModel(dataModel);
			if (isShowingPopup())
			{
				dismissPopup();
				showPopup();
			}
		}

		/// <summary>
		/// Sets the background for the button that expands the activity
		/// overflow list.
		/// </summary>
		/// <remarks>
		/// Sets the background for the button that expands the activity
		/// overflow list.
		/// <strong>Note:</strong> Clients would like to set this drawable
		/// as a clue about the action the chosen activity will perform. For
		/// example, if a share activity is to be chosen the drawable should
		/// give a clue that sharing is to be performed.
		/// </remarks>
		/// <param name="drawable">The drawable.</param>
		public virtual void setExpandActivityOverflowButtonDrawable(android.graphics.drawable.Drawable
			 drawable)
		{
			mExpandActivityOverflowButtonImage.setImageDrawable(drawable);
		}

		/// <summary>
		/// Sets the content description for the button that expands the activity
		/// overflow list.
		/// </summary>
		/// <remarks>
		/// Sets the content description for the button that expands the activity
		/// overflow list.
		/// description as a clue about the action performed by the button.
		/// For example, if a share activity is to be chosen the content
		/// description should be something like "Share with".
		/// </remarks>
		/// <param name="resourceId">The content description resource id.</param>
		public virtual void setExpandActivityOverflowButtonContentDescription(int resourceId
			)
		{
			java.lang.CharSequence contentDescription = java.lang.CharSequenceProxy.Wrap(mContext
				.getString(resourceId));
			mExpandActivityOverflowButtonImage.setContentDescription(contentDescription);
		}

		/// <summary>Set the provider hosting this view, if applicable.</summary>
		/// <remarks>Set the provider hosting this view, if applicable.</remarks>
		/// <hide>Internal use only</hide>
		public virtual void setProvider(android.view.ActionProvider provider)
		{
			mProvider = provider;
		}

		/// <summary>Shows the popup window with activities.</summary>
		/// <remarks>Shows the popup window with activities.</remarks>
		/// <returns>True if the popup was shown, false if already showing.</returns>
		public virtual bool showPopup()
		{
			if (isShowingPopup() || !mIsAttachedToWindow)
			{
				return false;
			}
			mIsSelectingDefaultActivity = false;
			showPopupUnchecked(mInitialActivityCount);
			return true;
		}

		/// <summary>Shows the popup no matter if it was already showing.</summary>
		/// <remarks>Shows the popup no matter if it was already showing.</remarks>
		/// <param name="maxActivityCount">The max number of activities to display.</param>
		private void showPopupUnchecked(int maxActivityCount)
		{
			if (mAdapter.getDataModel() == null)
			{
				throw new System.InvalidOperationException("No data model. Did you call #setDataModel?"
					);
			}
			getViewTreeObserver().addOnGlobalLayoutListener(mOnGlobalLayoutListener);
			bool defaultActivityButtonShown = mDefaultActivityButton.getVisibility() == VISIBLE;
			int activityCount = mAdapter.getActivityCount();
			int maxActivityCountOffset = defaultActivityButtonShown ? 1 : 0;
			if (maxActivityCount != android.widget.ActivityChooserView.ActivityChooserViewAdapter
				.MAX_ACTIVITY_COUNT_UNLIMITED && activityCount > maxActivityCount + maxActivityCountOffset)
			{
				mAdapter.setShowFooterView(true);
				mAdapter.setMaxActivityCount(maxActivityCount - 1);
			}
			else
			{
				mAdapter.setShowFooterView(false);
				mAdapter.setMaxActivityCount(maxActivityCount);
			}
			android.widget.ListPopupWindow popupWindow = getListPopupWindow();
			if (!popupWindow.isShowing())
			{
				if (mIsSelectingDefaultActivity || !defaultActivityButtonShown)
				{
					mAdapter.setShowDefaultActivity(true, defaultActivityButtonShown);
				}
				else
				{
					mAdapter.setShowDefaultActivity(false, false);
				}
				int contentWidth = System.Math.Min(mAdapter.measureContentWidth(), mListPopupMaxWidth
					);
				popupWindow.setContentWidth(contentWidth);
				popupWindow.show();
				if (mProvider != null)
				{
					mProvider.subUiVisibilityChanged(true);
				}
				popupWindow.getListView().setContentDescription(java.lang.CharSequenceProxy.Wrap(
					mContext.getString(android.@internal.R.@string.activitychooserview_choose_application
					)));
			}
		}

		/// <summary>Dismisses the popup window with activities.</summary>
		/// <remarks>Dismisses the popup window with activities.</remarks>
		/// <returns>True if dismissed, false if already dismissed.</returns>
		public virtual bool dismissPopup()
		{
			if (isShowingPopup())
			{
				getListPopupWindow().dismiss();
				android.view.ViewTreeObserver viewTreeObserver = getViewTreeObserver();
				if (viewTreeObserver.isAlive())
				{
					viewTreeObserver.removeGlobalOnLayoutListener(mOnGlobalLayoutListener);
				}
			}
			return true;
		}

		/// <summary>Gets whether the popup window with activities is shown.</summary>
		/// <remarks>Gets whether the popup window with activities is shown.</remarks>
		/// <returns>True if the popup is shown.</returns>
		public virtual bool isShowingPopup()
		{
			return getListPopupWindow().isShowing();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onAttachedToWindow()
		{
			base.onAttachedToWindow();
			android.widget.ActivityChooserModel dataModel = mAdapter.getDataModel();
			if (dataModel != null)
			{
				dataModel.registerObserver(mModelDataSetOberver);
			}
			mIsAttachedToWindow = true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			android.widget.ActivityChooserModel dataModel = mAdapter.getDataModel();
			if (dataModel != null)
			{
				dataModel.unregisterObserver(mModelDataSetOberver);
			}
			android.view.ViewTreeObserver viewTreeObserver = getViewTreeObserver();
			if (viewTreeObserver.isAlive())
			{
				viewTreeObserver.removeGlobalOnLayoutListener(mOnGlobalLayoutListener);
			}
			mIsAttachedToWindow = false;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			android.view.View child = mActivityChooserContent;
			// If the default action is not visible we want to be as tall as the
			// ActionBar so if this widget is used in the latter it will look as
			// a normal action button.
			if (mDefaultActivityButton.getVisibility() != VISIBLE)
			{
				heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(android.view.View
					.MeasureSpec.getSize(heightMeasureSpec), android.view.View.MeasureSpec.EXACTLY);
			}
			measureChild(child, widthMeasureSpec, heightMeasureSpec);
			setMeasuredDimension(child.getMeasuredWidth(), child.getMeasuredHeight());
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int left, int top, int right
			, int bottom)
		{
			mActivityChooserContent.layout(0, 0, right - left, bottom - top);
			if (getListPopupWindow().isShowing())
			{
				showPopupUnchecked(mAdapter.getMaxActivityCount());
			}
			else
			{
				dismissPopup();
			}
		}

		public virtual android.widget.ActivityChooserModel getDataModel()
		{
			return mAdapter.getDataModel();
		}

		/// <summary>Sets a listener to receive a callback when the popup is dismissed.</summary>
		/// <remarks>Sets a listener to receive a callback when the popup is dismissed.</remarks>
		/// <param name="listener">The listener to be notified.</param>
		public virtual void setOnDismissListener(android.widget.PopupWindow.OnDismissListener
			 listener)
		{
			mOnDismissListener = listener;
		}

		/// <summary>
		/// Sets the initial count of items shown in the activities popup
		/// i.e.
		/// </summary>
		/// <remarks>
		/// Sets the initial count of items shown in the activities popup
		/// i.e. the items before the popup is expanded. This is an upper
		/// bound since it is not guaranteed that such number of intent
		/// handlers exist.
		/// </remarks>
		/// <param name="itemCount">The initial popup item count.</param>
		public virtual void setInitialActivityCount(int itemCount)
		{
			mInitialActivityCount = itemCount;
		}

		/// <summary>Sets a content description of the default action button.</summary>
		/// <remarks>
		/// Sets a content description of the default action button. This
		/// resource should be a string taking one formatting argument and
		/// will be used for formatting the content description of the button
		/// dynamically as the default target changes. For example, a resource
		/// pointing to the string "share with %1$s" will result in a content
		/// description "share with Bluetooth" for the Bluetooth activity.
		/// </remarks>
		/// <param name="resourceId">The resource id.</param>
		public virtual void setDefaultActionButtonContentDescription(int resourceId)
		{
			mDefaultActionButtonContentDescription = resourceId;
		}

		/// <summary>Gets the list popup window which is lazily initialized.</summary>
		/// <remarks>Gets the list popup window which is lazily initialized.</remarks>
		/// <returns>The popup.</returns>
		private android.widget.ListPopupWindow getListPopupWindow()
		{
			if (mListPopupWindow == null)
			{
				mListPopupWindow = new android.widget.ListPopupWindow(getContext());
				mListPopupWindow.setAdapter(mAdapter);
				mListPopupWindow.setAnchorView(this);
				mListPopupWindow.setModal(true);
				mListPopupWindow.setOnItemClickListener(mCallbacks);
				mListPopupWindow.setOnDismissListener(mCallbacks);
			}
			return mListPopupWindow;
		}

		/// <summary>Updates the buttons state.</summary>
		/// <remarks>Updates the buttons state.</remarks>
		private void updateAppearance()
		{
			// Expand overflow button.
			if (mAdapter.getCount() > 0)
			{
				mExpandActivityOverflowButton.setEnabled(true);
			}
			else
			{
				mExpandActivityOverflowButton.setEnabled(false);
			}
			// Default activity button.
			int activityCount = mAdapter.getActivityCount();
			int historySize = mAdapter.getHistorySize();
			if (activityCount > 0 && historySize > 0)
			{
				mDefaultActivityButton.setVisibility(VISIBLE);
				android.content.pm.ResolveInfo activity = mAdapter.getDefaultActivity();
				android.content.pm.PackageManager packageManager = mContext.getPackageManager();
				mDefaultActivityButtonImage.setImageDrawable(activity.loadIcon(packageManager));
				if (mDefaultActionButtonContentDescription != 0)
				{
					java.lang.CharSequence label = activity.loadLabel(packageManager);
					string contentDescription = mContext.getString(mDefaultActionButtonContentDescription
						, label);
					mDefaultActivityButton.setContentDescription(java.lang.CharSequenceProxy.Wrap(contentDescription
						));
				}
			}
			else
			{
				mDefaultActivityButton.setVisibility(android.view.View.GONE);
			}
			// Activity chooser content.
			if (mDefaultActivityButton.getVisibility() == VISIBLE)
			{
				mActivityChooserContent.setBackgroundDrawable(mActivityChooserContentBackground);
			}
			else
			{
				mActivityChooserContent.setBackgroundDrawable(null);
			}
		}

		/// <summary>Interface implementation to avoid publishing them in the APIs.</summary>
		/// <remarks>Interface implementation to avoid publishing them in the APIs.</remarks>
		private class Callbacks : android.widget.AdapterView.OnItemClickListener, android.view.View
			.OnClickListener, android.view.View.OnLongClickListener, android.widget.PopupWindow
			.OnDismissListener
		{
			// AdapterView#OnItemClickListener
			[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
			public virtual void onItemClick(object parent, android.view.View view, int position
				, long id)
			{
				android.widget.ActivityChooserView.ActivityChooserViewAdapter adapter = (android.widget.ActivityChooserView
					.ActivityChooserViewAdapter)((android.widget.IAdapterView)parent).getAdapter();
				int itemViewType = adapter.getItemViewType(position);
				switch (itemViewType)
				{
					case android.widget.ActivityChooserView.ActivityChooserViewAdapter.ITEM_VIEW_TYPE_FOOTER
						:
					{
						this._enclosing.showPopupUnchecked(android.widget.ActivityChooserView.ActivityChooserViewAdapter
							.MAX_ACTIVITY_COUNT_UNLIMITED);
						break;
					}

					case android.widget.ActivityChooserView.ActivityChooserViewAdapter.ITEM_VIEW_TYPE_ACTIVITY
						:
					{
						this._enclosing.dismissPopup();
						if (this._enclosing.mIsSelectingDefaultActivity)
						{
							// The item at position zero is the default already.
							if (position > 0)
							{
								this._enclosing.mAdapter.getDataModel().setDefaultActivity(position);
							}
						}
						else
						{
							// If the default target is not shown in the list, the first
							// item in the model is default action => adjust index
							position = this._enclosing.mAdapter.getShowDefaultActivity() ? position : position
								 + 1;
							android.content.Intent launchIntent = this._enclosing.mAdapter.getDataModel().chooseActivity
								(position);
							if (launchIntent != null)
							{
								this._enclosing.mContext.startActivity(launchIntent);
							}
						}
						break;
					}

					default:
					{
						throw new System.ArgumentException();
					}
				}
			}

			// View.OnClickListener
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public virtual void onClick(android.view.View view)
			{
				if (view == this._enclosing.mDefaultActivityButton)
				{
					this._enclosing.dismissPopup();
					android.content.pm.ResolveInfo defaultActivity = this._enclosing.mAdapter.getDefaultActivity
						();
					int index = this._enclosing.mAdapter.getDataModel().getActivityIndex(defaultActivity
						);
					android.content.Intent launchIntent = this._enclosing.mAdapter.getDataModel().chooseActivity
						(index);
					if (launchIntent != null)
					{
						this._enclosing.mContext.startActivity(launchIntent);
					}
				}
				else
				{
					if (view == this._enclosing.mExpandActivityOverflowButton)
					{
						this._enclosing.mIsSelectingDefaultActivity = false;
						this._enclosing.showPopupUnchecked(this._enclosing.mInitialActivityCount);
					}
					else
					{
						throw new System.ArgumentException();
					}
				}
			}

			// OnLongClickListener#onLongClick
			[Sharpen.ImplementsInterface(@"android.view.View.OnLongClickListener")]
			public virtual bool onLongClick(android.view.View view)
			{
				if (view == this._enclosing.mDefaultActivityButton)
				{
					if (this._enclosing.mAdapter.getCount() > 0)
					{
						this._enclosing.mIsSelectingDefaultActivity = true;
						this._enclosing.showPopupUnchecked(this._enclosing.mInitialActivityCount);
					}
				}
				else
				{
					throw new System.ArgumentException();
				}
				return true;
			}

			// PopUpWindow.OnDismissListener#onDismiss
			[Sharpen.ImplementsInterface(@"android.widget.PopupWindow.OnDismissListener")]
			public virtual void onDismiss()
			{
				this.notifyOnDismissListener();
				if (this._enclosing.mProvider != null)
				{
					this._enclosing.mProvider.subUiVisibilityChanged(false);
				}
			}

			internal void notifyOnDismissListener()
			{
				if (this._enclosing.mOnDismissListener != null)
				{
					this._enclosing.mOnDismissListener.onDismiss();
				}
			}

			internal Callbacks(ActivityChooserView _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly ActivityChooserView _enclosing;
		}

		/// <summary>Adapter for backing the list of activities shown in the popup.</summary>
		/// <remarks>Adapter for backing the list of activities shown in the popup.</remarks>
		private class ActivityChooserViewAdapter : android.widget.BaseAdapter
		{
			public const int MAX_ACTIVITY_COUNT_UNLIMITED = int.MaxValue;

			public const int MAX_ACTIVITY_COUNT_DEFAULT = 4;

			internal const int ITEM_VIEW_TYPE_ACTIVITY = 0;

			internal const int ITEM_VIEW_TYPE_FOOTER = 1;

			internal const int ITEM_VIEW_TYPE_COUNT = 3;

			internal android.widget.ActivityChooserModel mDataModel;

			internal int mMaxActivityCount;

			internal bool mShowDefaultActivity;

			internal bool mHighlightDefaultActivity;

			internal bool mShowFooterView;

			public virtual void setDataModel(android.widget.ActivityChooserModel dataModel)
			{
				android.widget.ActivityChooserModel oldDataModel = this._enclosing.mAdapter.getDataModel
					();
				if (oldDataModel != null && this._enclosing.isShown())
				{
					oldDataModel.unregisterObserver(this._enclosing.mModelDataSetOberver);
				}
				this.mDataModel = dataModel;
				if (dataModel != null && this._enclosing.isShown())
				{
					dataModel.registerObserver(this._enclosing.mModelDataSetOberver);
				}
				this.notifyDataSetChanged();
			}

			[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
			public override int getItemViewType(int position)
			{
				if (this.mShowFooterView && position == this.getCount() - 1)
				{
					return ITEM_VIEW_TYPE_FOOTER;
				}
				else
				{
					return ITEM_VIEW_TYPE_ACTIVITY;
				}
			}

			[Sharpen.OverridesMethod(@"android.widget.BaseAdapter")]
			public override int getViewTypeCount()
			{
				return ITEM_VIEW_TYPE_COUNT;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override int getCount()
			{
				int count = 0;
				int activityCount = this.mDataModel.getActivityCount();
				if (!this.mShowDefaultActivity && this.mDataModel.getDefaultActivity() != null)
				{
					activityCount--;
				}
				count = System.Math.Min(activityCount, this.mMaxActivityCount);
				if (this.mShowFooterView)
				{
					count++;
				}
				return count;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override object getItem(int position)
			{
				int itemViewType = this.getItemViewType(position);
				switch (itemViewType)
				{
					case ITEM_VIEW_TYPE_FOOTER:
					{
						return null;
					}

					case ITEM_VIEW_TYPE_ACTIVITY:
					{
						if (!this.mShowDefaultActivity && this.mDataModel.getDefaultActivity() != null)
						{
							position++;
						}
						return this.mDataModel.getActivity(position);
					}

					default:
					{
						throw new System.ArgumentException();
					}
				}
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override long getItemId(int position)
			{
				return position;
			}

			[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
			public override android.view.View getView(int position, android.view.View convertView
				, android.view.ViewGroup parent)
			{
				int itemViewType = this.getItemViewType(position);
				switch (itemViewType)
				{
					case ITEM_VIEW_TYPE_FOOTER:
					{
						if (convertView == null || convertView.getId() != ITEM_VIEW_TYPE_FOOTER)
						{
							convertView = android.view.LayoutInflater.from(this._enclosing.getContext()).inflate
								(android.@internal.R.layout.activity_chooser_view_list_item, parent, false);
							convertView.setId(ITEM_VIEW_TYPE_FOOTER);
							android.widget.TextView titleView = (android.widget.TextView)convertView.findViewById
								(android.@internal.R.id.title);
							titleView.setText(java.lang.CharSequenceProxy.Wrap(this._enclosing.mContext.getString
								(android.@internal.R.@string.activity_chooser_view_see_all)));
						}
						return convertView;
					}

					case ITEM_VIEW_TYPE_ACTIVITY:
					{
						if (convertView == null || convertView.getId() != android.@internal.R.id.list_item)
						{
							convertView = android.view.LayoutInflater.from(this._enclosing.getContext()).inflate
								(android.@internal.R.layout.activity_chooser_view_list_item, parent, false);
						}
						android.content.pm.PackageManager packageManager = this._enclosing.mContext.getPackageManager
							();
						// Set the icon
						android.widget.ImageView iconView = (android.widget.ImageView)convertView.findViewById
							(android.@internal.R.id.icon);
						android.content.pm.ResolveInfo activity = (android.content.pm.ResolveInfo)this.getItem
							(position);
						iconView.setImageDrawable(activity.loadIcon(packageManager));
						// Set the title.
						android.widget.TextView titleView_1 = (android.widget.TextView)convertView.findViewById
							(android.@internal.R.id.title);
						titleView_1.setText(activity.loadLabel(packageManager));
						// Highlight the default.
						if (this.mShowDefaultActivity && position == 0 && this.mHighlightDefaultActivity)
						{
							convertView.setActivated(true);
						}
						else
						{
							convertView.setActivated(false);
						}
						return convertView;
					}

					default:
					{
						throw new System.ArgumentException();
					}
				}
			}

			public virtual int measureContentWidth()
			{
				// The user may have specified some of the target not to be shown but we
				// want to measure all of them since after expansion they should fit.
				int oldMaxActivityCount = this.mMaxActivityCount;
				this.mMaxActivityCount = MAX_ACTIVITY_COUNT_UNLIMITED;
				int contentWidth = 0;
				android.view.View itemView = null;
				int widthMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
					.MeasureSpec.UNSPECIFIED);
				int heightMeasureSpec = android.view.View.MeasureSpec.makeMeasureSpec(0, android.view.View
					.MeasureSpec.UNSPECIFIED);
				int count = this.getCount();
				{
					for (int i = 0; i < count; i++)
					{
						itemView = this.getView(i, itemView, null);
						itemView.measure(widthMeasureSpec, heightMeasureSpec);
						contentWidth = System.Math.Max(contentWidth, itemView.getMeasuredWidth());
					}
				}
				this.mMaxActivityCount = oldMaxActivityCount;
				return contentWidth;
			}

			public virtual void setMaxActivityCount(int maxActivityCount)
			{
				if (this.mMaxActivityCount != maxActivityCount)
				{
					this.mMaxActivityCount = maxActivityCount;
					this.notifyDataSetChanged();
				}
			}

			public virtual android.content.pm.ResolveInfo getDefaultActivity()
			{
				return this.mDataModel.getDefaultActivity();
			}

			public virtual void setShowFooterView(bool showFooterView)
			{
				if (this.mShowFooterView != showFooterView)
				{
					this.mShowFooterView = showFooterView;
					this.notifyDataSetChanged();
				}
			}

			public virtual int getActivityCount()
			{
				return this.mDataModel.getActivityCount();
			}

			public virtual int getHistorySize()
			{
				return this.mDataModel.getHistorySize();
			}

			public virtual int getMaxActivityCount()
			{
				return this.mMaxActivityCount;
			}

			public virtual android.widget.ActivityChooserModel getDataModel()
			{
				return this.mDataModel;
			}

			public virtual void setShowDefaultActivity(bool showDefaultActivity, bool highlightDefaultActivity
				)
			{
				if (this.mShowDefaultActivity != showDefaultActivity || this.mHighlightDefaultActivity
					 != highlightDefaultActivity)
				{
					this.mShowDefaultActivity = showDefaultActivity;
					this.mHighlightDefaultActivity = highlightDefaultActivity;
					this.notifyDataSetChanged();
				}
			}

			public virtual bool getShowDefaultActivity()
			{
				return this.mShowDefaultActivity;
			}

			public ActivityChooserViewAdapter(ActivityChooserView _enclosing)
			{
				this._enclosing = _enclosing;
				mMaxActivityCount = MAX_ACTIVITY_COUNT_DEFAULT;
			}

			private readonly ActivityChooserView _enclosing;
		}
	}
}
