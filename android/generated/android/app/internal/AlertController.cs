using Sharpen;

namespace android.app.@internal
{
	[Sharpen.Sharpened]
	public class AlertController
	{
		private readonly android.content.Context mContext;

		private readonly android.content.DialogInterface mDialogInterface;

		private readonly android.view.Window mWindow;

		private java.lang.CharSequence mTitle;

		private java.lang.CharSequence mMessage;

		private android.widget.ListView mListView;

		private android.view.View mView;

		private int mViewSpacingLeft;

		private int mViewSpacingTop;

		private int mViewSpacingRight;

		private int mViewSpacingBottom;

		private bool mViewSpacingSpecified = false;

		private android.widget.Button mButtonPositive;

		private java.lang.CharSequence mButtonPositiveText;

		private android.os.Message mButtonPositiveMessage;

		private android.widget.Button mButtonNegative;

		private java.lang.CharSequence mButtonNegativeText;

		private android.os.Message mButtonNegativeMessage;

		private android.widget.Button mButtonNeutral;

		private java.lang.CharSequence mButtonNeutralText;

		private android.os.Message mButtonNeutralMessage;

		private android.widget.ScrollView mScrollView;

		private int mIconId = -1;

		private android.graphics.drawable.Drawable mIcon;

		private android.widget.ImageView mIconView;

		private android.widget.TextView mTitleView;

		private android.widget.TextView mMessageView;

		private android.view.View mCustomTitleView;

		private bool mForceInverseBackground;

		private android.widget.ListAdapter mAdapter;

		private int mCheckedItem = -1;

		private int mAlertDialogLayout;

		private int mListLayout;

		private int mMultiChoiceItemLayout;

		private int mSingleChoiceItemLayout;

		private int mListItemLayout;

		private android.os.Handler mHandler;

		private sealed class _OnClickListener_129 : android.view.View.OnClickListener
		{
			public _OnClickListener_129(AlertController _enclosing)
			{
				this._enclosing = _enclosing;
			}

			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				android.os.Message m = null;
				if (v == this._enclosing.mButtonPositive && this._enclosing.mButtonPositiveMessage
					 != null)
				{
					m = android.os.Message.obtain(this._enclosing.mButtonPositiveMessage);
				}
				else
				{
					if (v == this._enclosing.mButtonNegative && this._enclosing.mButtonNegativeMessage
						 != null)
					{
						m = android.os.Message.obtain(this._enclosing.mButtonNegativeMessage);
					}
					else
					{
						if (v == this._enclosing.mButtonNeutral && this._enclosing.mButtonNeutralMessage 
							!= null)
						{
							m = android.os.Message.obtain(this._enclosing.mButtonNeutralMessage);
						}
					}
				}
				if (m != null)
				{
					m.sendToTarget();
				}
				// Post a message so we dismiss after the above handlers are executed
				this._enclosing.mHandler.obtainMessage(android.app.@internal.AlertController.ButtonHandler
					.MSG_DISMISS_DIALOG, this._enclosing.mDialogInterface).sendToTarget();
			}

			private readonly AlertController _enclosing;
		}

		internal android.view.View.OnClickListener mButtonHandler;

		private sealed class ButtonHandler : android.os.Handler
		{
			internal const int MSG_DISMISS_DIALOG = 1;

			internal java.lang.@ref.WeakReference<android.content.DialogInterface> mDialog;

			public ButtonHandler(android.content.DialogInterface dialog)
			{
				// Button clicks have Message.what as the BUTTON{1,2,3} constant
				mDialog = new java.lang.@ref.WeakReference<android.content.DialogInterface>(dialog
					);
			}

			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				switch (msg.what)
				{
					case android.content.DialogInterfaceClass.BUTTON_POSITIVE:
					case android.content.DialogInterfaceClass.BUTTON_NEGATIVE:
					case android.content.DialogInterfaceClass.BUTTON_NEUTRAL:
					{
						((android.content.DialogInterfaceClass.OnClickListener)msg.obj).onClick(mDialog.get
							(), msg.what);
						break;
					}

					case MSG_DISMISS_DIALOG:
					{
						((android.content.DialogInterface)msg.obj).dismiss();
						break;
					}
				}
			}
		}

		private static bool shouldCenterSingleButton(android.content.Context context)
		{
			android.util.TypedValue outValue = new android.util.TypedValue();
			context.getTheme().resolveAttribute(android.@internal.R.attr.alertDialogCenterButtons
				, outValue, true);
			return outValue.data != 0;
		}

		public AlertController(android.content.Context context, android.content.DialogInterface
			 di, android.view.Window window)
		{
			mButtonHandler = new _OnClickListener_129(this);
			mContext = context;
			mDialogInterface = di;
			mWindow = window;
			mHandler = new android.app.@internal.AlertController.ButtonHandler(di);
			android.content.res.TypedArray a = context.obtainStyledAttributes(null, android.@internal.R
				.styleable.AlertDialog, android.@internal.R.attr.alertDialogStyle, 0);
			mAlertDialogLayout = a.getResourceId(android.@internal.R.styleable.AlertDialog_layout
				, android.@internal.R.layout.alert_dialog);
			mListLayout = a.getResourceId(android.@internal.R.styleable.AlertDialog_listLayout
				, android.@internal.R.layout.select_dialog);
			mMultiChoiceItemLayout = a.getResourceId(android.@internal.R.styleable.AlertDialog_multiChoiceItemLayout
				, android.@internal.R.layout.select_dialog_multichoice);
			mSingleChoiceItemLayout = a.getResourceId(android.@internal.R.styleable.AlertDialog_singleChoiceItemLayout
				, android.@internal.R.layout.select_dialog_singlechoice);
			mListItemLayout = a.getResourceId(android.@internal.R.styleable.AlertDialog_listItemLayout
				, android.@internal.R.layout.select_dialog_item);
			a.recycle();
		}

		internal static bool canTextInput(android.view.View v)
		{
			if (v.onCheckIsTextEditor())
			{
				return true;
			}
			if (!(v is android.view.ViewGroup))
			{
				return false;
			}
			android.view.ViewGroup vg = (android.view.ViewGroup)v;
			int i = vg.getChildCount();
			while (i > 0)
			{
				i--;
				v = vg.getChildAt(i);
				if (canTextInput(v))
				{
					return true;
				}
			}
			return false;
		}

		public virtual void installContent()
		{
			mWindow.requestFeature(android.view.Window.FEATURE_NO_TITLE);
			if (mView == null || !canTextInput(mView))
			{
				mWindow.setFlags(android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM
					, android.view.WindowManagerClass.LayoutParams.FLAG_ALT_FOCUSABLE_IM);
			}
			mWindow.setContentView(mAlertDialogLayout);
			setupView();
		}

		public virtual void setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			if (mTitleView != null)
			{
				mTitleView.setText(title);
			}
		}

		/// <seealso cref="android.app.AlertDialog.Builder.setCustomTitle(android.view.View)"
		/// 	>android.app.AlertDialog.Builder.setCustomTitle(android.view.View)</seealso>
		public virtual void setCustomTitle(android.view.View customTitleView)
		{
			mCustomTitleView = customTitleView;
		}

		public virtual void setMessage(java.lang.CharSequence message)
		{
			mMessage = message;
			if (mMessageView != null)
			{
				mMessageView.setText(message);
			}
		}

		/// <summary>Set the view to display in the dialog.</summary>
		/// <remarks>Set the view to display in the dialog.</remarks>
		public virtual void setView(android.view.View view)
		{
			mView = view;
			mViewSpacingSpecified = false;
		}

		/// <summary>Set the view to display in the dialog along with the spacing around that view
		/// 	</summary>
		public virtual void setView(android.view.View view, int viewSpacingLeft, int viewSpacingTop
			, int viewSpacingRight, int viewSpacingBottom)
		{
			mView = view;
			mViewSpacingSpecified = true;
			mViewSpacingLeft = viewSpacingLeft;
			mViewSpacingTop = viewSpacingTop;
			mViewSpacingRight = viewSpacingRight;
			mViewSpacingBottom = viewSpacingBottom;
		}

		/// <summary>Sets a click listener or a message to be sent when the button is clicked.
		/// 	</summary>
		/// <remarks>
		/// Sets a click listener or a message to be sent when the button is clicked.
		/// You only need to pass one of
		/// <code>listener</code>
		/// or
		/// <code>msg</code>
		/// .
		/// </remarks>
		/// <param name="whichButton">
		/// Which button, can be one of
		/// <see cref="android.content.DialogInterfaceClass.BUTTON_POSITIVE">android.content.DialogInterfaceClass.BUTTON_POSITIVE
		/// 	</see>
		/// ,
		/// <see cref="android.content.DialogInterfaceClass.BUTTON_NEGATIVE">android.content.DialogInterfaceClass.BUTTON_NEGATIVE
		/// 	</see>
		/// , or
		/// <see cref="android.content.DialogInterfaceClass.BUTTON_NEUTRAL">android.content.DialogInterfaceClass.BUTTON_NEUTRAL
		/// 	</see>
		/// </param>
		/// <param name="text">The text to display in positive button.</param>
		/// <param name="listener">
		/// The
		/// <see cref="android.content.DialogInterfaceClass.OnClickListener">android.content.DialogInterfaceClass.OnClickListener
		/// 	</see>
		/// to use.
		/// </param>
		/// <param name="msg">
		/// The
		/// <see cref="android.os.Message">android.os.Message</see>
		/// to be sent when clicked.
		/// </param>
		public virtual void setButton(int whichButton, java.lang.CharSequence text, android.content.DialogInterfaceClass
			.OnClickListener listener, android.os.Message msg)
		{
			if (msg == null && listener != null)
			{
				msg = mHandler.obtainMessage(whichButton, listener);
			}
			switch (whichButton)
			{
				case android.content.DialogInterfaceClass.BUTTON_POSITIVE:
				{
					mButtonPositiveText = text;
					mButtonPositiveMessage = msg;
					break;
				}

				case android.content.DialogInterfaceClass.BUTTON_NEGATIVE:
				{
					mButtonNegativeText = text;
					mButtonNegativeMessage = msg;
					break;
				}

				case android.content.DialogInterfaceClass.BUTTON_NEUTRAL:
				{
					mButtonNeutralText = text;
					mButtonNeutralMessage = msg;
					break;
				}

				default:
				{
					throw new System.ArgumentException("Button does not exist");
				}
			}
		}

		/// <summary>Set resId to 0 if you don't want an icon.</summary>
		/// <remarks>Set resId to 0 if you don't want an icon.</remarks>
		/// <param name="resId">
		/// the resourceId of the drawable to use as the icon or 0
		/// if you don't want an icon.
		/// </param>
		public virtual void setIcon(int resId)
		{
			mIconId = resId;
			if (mIconView != null)
			{
				if (resId > 0)
				{
					mIconView.setImageResource(mIconId);
				}
				else
				{
					if (resId == 0)
					{
						mIconView.setVisibility(android.view.View.GONE);
					}
				}
			}
		}

		public virtual void setIcon(android.graphics.drawable.Drawable icon)
		{
			mIcon = icon;
			if ((mIconView != null) && (mIcon != null))
			{
				mIconView.setImageDrawable(icon);
			}
		}

		public virtual void setInverseBackgroundForced(bool forceInverseBackground)
		{
			mForceInverseBackground = forceInverseBackground;
		}

		public virtual android.widget.ListView getListView()
		{
			return mListView;
		}

		public virtual android.widget.Button getButton(int whichButton)
		{
			switch (whichButton)
			{
				case android.content.DialogInterfaceClass.BUTTON_POSITIVE:
				{
					return mButtonPositive;
				}

				case android.content.DialogInterfaceClass.BUTTON_NEGATIVE:
				{
					return mButtonNegative;
				}

				case android.content.DialogInterfaceClass.BUTTON_NEUTRAL:
				{
					return mButtonNeutral;
				}

				default:
				{
					return null;
				}
			}
		}

		public virtual bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			return mScrollView != null && mScrollView.executeKeyEvent(@event);
		}

		public virtual bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			return mScrollView != null && mScrollView.executeKeyEvent(@event);
		}

		private void setupView()
		{
			android.widget.LinearLayout contentPanel = (android.widget.LinearLayout)mWindow.findViewById
				(android.@internal.R.id.contentPanel);
			setupContent(contentPanel);
			bool hasButtons = setupButtons();
			android.widget.LinearLayout topPanel = (android.widget.LinearLayout)mWindow.findViewById
				(android.@internal.R.id.topPanel);
			android.content.res.TypedArray a = mContext.obtainStyledAttributes(null, android.@internal.R
				.styleable.AlertDialog, android.@internal.R.attr.alertDialogStyle, 0);
			bool hasTitle = setupTitle(topPanel);
			android.view.View buttonPanel = mWindow.findViewById(android.@internal.R.id.buttonPanel
				);
			if (!hasButtons)
			{
				buttonPanel.setVisibility(android.view.View.GONE);
				mWindow.setCloseOnTouchOutsideIfNotSet(true);
			}
			android.widget.FrameLayout customPanel = null;
			if (mView != null)
			{
				customPanel = (android.widget.FrameLayout)mWindow.findViewById(android.@internal.R
					.id.customPanel);
				android.widget.FrameLayout custom = (android.widget.FrameLayout)mWindow.findViewById
					(android.@internal.R.id.custom);
				custom.addView(mView, new android.view.ViewGroup.LayoutParams(android.view.ViewGroup
					.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
				if (mViewSpacingSpecified)
				{
					custom.setPadding(mViewSpacingLeft, mViewSpacingTop, mViewSpacingRight, mViewSpacingBottom
						);
				}
				if (mListView != null)
				{
					((android.widget.LinearLayout.LayoutParams)customPanel.getLayoutParams()).weight 
						= 0;
				}
			}
			else
			{
				mWindow.findViewById(android.@internal.R.id.customPanel).setVisibility(android.view.View
					.GONE);
			}
			if (hasTitle)
			{
				android.view.View divider = null;
				if (mMessage != null || mView != null || mListView != null)
				{
					divider = mWindow.findViewById(android.@internal.R.id.titleDivider);
				}
				else
				{
					divider = mWindow.findViewById(android.@internal.R.id.titleDividerTop);
				}
				if (divider != null)
				{
					divider.setVisibility(android.view.View.VISIBLE);
				}
			}
			setBackground(topPanel, contentPanel, customPanel, hasButtons, a, hasTitle, buttonPanel
				);
			a.recycle();
		}

		private bool setupTitle(android.widget.LinearLayout topPanel)
		{
			bool hasTitle = true;
			if (mCustomTitleView != null)
			{
				// Add the custom title view directly to the topPanel layout
				android.widget.LinearLayout.LayoutParams lp = new android.widget.LinearLayout.LayoutParams
					(android.view.ViewGroup.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams
					.WRAP_CONTENT);
				topPanel.addView(mCustomTitleView, 0, lp);
				// Hide the title template
				android.view.View titleTemplate = mWindow.findViewById(android.@internal.R.id.title_template
					);
				titleTemplate.setVisibility(android.view.View.GONE);
			}
			else
			{
				bool hasTextTitle = !android.text.TextUtils.isEmpty(mTitle);
				mIconView = (android.widget.ImageView)mWindow.findViewById(android.@internal.R.id
					.icon);
				if (hasTextTitle)
				{
					mTitleView = (android.widget.TextView)mWindow.findViewById(android.@internal.R.id
						.alertTitle);
					mTitleView.setText(mTitle);
					if (mIconId > 0)
					{
						mIconView.setImageResource(mIconId);
					}
					else
					{
						if (mIcon != null)
						{
							mIconView.setImageDrawable(mIcon);
						}
						else
						{
							if (mIconId == 0)
							{
								mTitleView.setPadding(mIconView.getPaddingLeft(), mIconView.getPaddingTop(), mIconView
									.getPaddingRight(), mIconView.getPaddingBottom());
								mIconView.setVisibility(android.view.View.GONE);
							}
						}
					}
				}
				else
				{
					// Hide the title template
					android.view.View titleTemplate = mWindow.findViewById(android.@internal.R.id.title_template
						);
					titleTemplate.setVisibility(android.view.View.GONE);
					mIconView.setVisibility(android.view.View.GONE);
					topPanel.setVisibility(android.view.View.GONE);
					hasTitle = false;
				}
			}
			return hasTitle;
		}

		private void setupContent(android.widget.LinearLayout contentPanel)
		{
			mScrollView = (android.widget.ScrollView)mWindow.findViewById(android.@internal.R
				.id.scrollView);
			mScrollView.setFocusable(false);
			// Special case for users that only want to display a String
			mMessageView = (android.widget.TextView)mWindow.findViewById(android.@internal.R.
				id.message);
			if (mMessageView == null)
			{
				return;
			}
			if (mMessage != null)
			{
				mMessageView.setText(mMessage);
			}
			else
			{
				mMessageView.setVisibility(android.view.View.GONE);
				mScrollView.removeView(mMessageView);
				if (mListView != null)
				{
					contentPanel.removeView(mWindow.findViewById(android.@internal.R.id.scrollView));
					contentPanel.addView(mListView, new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup
						.LayoutParams.MATCH_PARENT, android.view.ViewGroup.LayoutParams.MATCH_PARENT));
					contentPanel.setLayoutParams(new android.widget.LinearLayout.LayoutParams(android.view.ViewGroup
						.LayoutParams.MATCH_PARENT, 0, 1.0f));
				}
				else
				{
					contentPanel.setVisibility(android.view.View.GONE);
				}
			}
		}

		private bool setupButtons()
		{
			int BIT_BUTTON_POSITIVE = 1;
			int BIT_BUTTON_NEGATIVE = 2;
			int BIT_BUTTON_NEUTRAL = 4;
			int whichButtons = 0;
			mButtonPositive = (android.widget.Button)mWindow.findViewById(android.@internal.R
				.id.button1);
			mButtonPositive.setOnClickListener(mButtonHandler);
			if (android.text.TextUtils.isEmpty(mButtonPositiveText))
			{
				mButtonPositive.setVisibility(android.view.View.GONE);
			}
			else
			{
				mButtonPositive.setText(mButtonPositiveText);
				mButtonPositive.setVisibility(android.view.View.VISIBLE);
				whichButtons = whichButtons | BIT_BUTTON_POSITIVE;
			}
			mButtonNegative = (android.widget.Button)mWindow.findViewById(android.@internal.R
				.id.button2);
			mButtonNegative.setOnClickListener(mButtonHandler);
			if (android.text.TextUtils.isEmpty(mButtonNegativeText))
			{
				mButtonNegative.setVisibility(android.view.View.GONE);
			}
			else
			{
				mButtonNegative.setText(mButtonNegativeText);
				mButtonNegative.setVisibility(android.view.View.VISIBLE);
				whichButtons = whichButtons | BIT_BUTTON_NEGATIVE;
			}
			mButtonNeutral = (android.widget.Button)mWindow.findViewById(android.@internal.R.
				id.button3);
			mButtonNeutral.setOnClickListener(mButtonHandler);
			if (android.text.TextUtils.isEmpty(mButtonNeutralText))
			{
				mButtonNeutral.setVisibility(android.view.View.GONE);
			}
			else
			{
				mButtonNeutral.setText(mButtonNeutralText);
				mButtonNeutral.setVisibility(android.view.View.VISIBLE);
				whichButtons = whichButtons | BIT_BUTTON_NEUTRAL;
			}
			if (shouldCenterSingleButton(mContext))
			{
				if (whichButtons == BIT_BUTTON_POSITIVE)
				{
					centerButton(mButtonPositive);
				}
				else
				{
					if (whichButtons == BIT_BUTTON_NEGATIVE)
					{
						centerButton(mButtonNeutral);
					}
					else
					{
						if (whichButtons == BIT_BUTTON_NEUTRAL)
						{
							centerButton(mButtonNeutral);
						}
					}
				}
			}
			return whichButtons != 0;
		}

		private void centerButton(android.widget.Button button)
		{
			android.widget.LinearLayout.LayoutParams @params = (android.widget.LinearLayout.LayoutParams
				)button.getLayoutParams();
			@params.gravity = android.view.Gravity.CENTER_HORIZONTAL;
			@params.weight = 0.5f;
			button.setLayoutParams(@params);
			android.view.View leftSpacer = mWindow.findViewById(android.@internal.R.id.leftSpacer
				);
			if (leftSpacer != null)
			{
				leftSpacer.setVisibility(android.view.View.VISIBLE);
			}
			android.view.View rightSpacer = mWindow.findViewById(android.@internal.R.id.rightSpacer
				);
			if (rightSpacer != null)
			{
				rightSpacer.setVisibility(android.view.View.VISIBLE);
			}
		}

		private void setBackground(android.widget.LinearLayout topPanel, android.widget.LinearLayout
			 contentPanel, android.view.View customPanel, bool hasButtons, android.content.res.TypedArray
			 a, bool hasTitle, android.view.View buttonPanel)
		{
			int fullDark = a.getResourceId(android.@internal.R.styleable.AlertDialog_fullDark
				, android.@internal.R.drawable.popup_full_dark);
			int topDark = a.getResourceId(android.@internal.R.styleable.AlertDialog_topDark, 
				android.@internal.R.drawable.popup_top_dark);
			int centerDark = a.getResourceId(android.@internal.R.styleable.AlertDialog_centerDark
				, android.@internal.R.drawable.popup_center_dark);
			int bottomDark = a.getResourceId(android.@internal.R.styleable.AlertDialog_bottomDark
				, android.@internal.R.drawable.popup_bottom_dark);
			int fullBright = a.getResourceId(android.@internal.R.styleable.AlertDialog_fullBright
				, android.@internal.R.drawable.popup_full_bright);
			int topBright = a.getResourceId(android.@internal.R.styleable.AlertDialog_topBright
				, android.@internal.R.drawable.popup_top_bright);
			int centerBright = a.getResourceId(android.@internal.R.styleable.AlertDialog_centerBright
				, android.@internal.R.drawable.popup_center_bright);
			int bottomBright = a.getResourceId(android.@internal.R.styleable.AlertDialog_bottomBright
				, android.@internal.R.drawable.popup_bottom_bright);
			int bottomMedium = a.getResourceId(android.@internal.R.styleable.AlertDialog_bottomMedium
				, android.@internal.R.drawable.popup_bottom_medium);
			android.view.View[] views = new android.view.View[4];
			bool[] light = new bool[4];
			android.view.View lastView = null;
			bool lastLight = false;
			int pos = 0;
			if (hasTitle)
			{
				views[pos] = topPanel;
				light[pos] = false;
				pos++;
			}
			views[pos] = (contentPanel.getVisibility() == android.view.View.GONE) ? null : contentPanel;
			light[pos] = mListView != null;
			pos++;
			if (customPanel != null)
			{
				views[pos] = customPanel;
				light[pos] = mForceInverseBackground;
				pos++;
			}
			if (hasButtons)
			{
				views[pos] = buttonPanel;
				light[pos] = true;
			}
			bool setView_1 = false;
			for (pos = 0; pos < views.Length; pos++)
			{
				android.view.View v = views[pos];
				if (v == null)
				{
					continue;
				}
				if (lastView != null)
				{
					if (!setView_1)
					{
						lastView.setBackgroundResource(lastLight ? topBright : topDark);
					}
					else
					{
						lastView.setBackgroundResource(lastLight ? centerBright : centerDark);
					}
					setView_1 = true;
				}
				lastView = v;
				lastLight = light[pos];
			}
			if (lastView != null)
			{
				if (setView_1)
				{
					lastView.setBackgroundResource(lastLight ? (hasButtons ? bottomMedium : bottomBright
						) : bottomDark);
				}
				else
				{
					lastView.setBackgroundResource(lastLight ? fullBright : fullDark);
				}
			}
			//        if (hasButtons && (mListView != null)) {
			//        }
			if ((mListView != null) && (mAdapter != null))
			{
				mListView.setAdapter(mAdapter);
				if (mCheckedItem > -1)
				{
					mListView.setItemChecked(mCheckedItem, true);
					mListView.setSelection(mCheckedItem);
				}
			}
		}

		public class RecycleListView : android.widget.ListView
		{
			internal bool mRecycleOnMeasure = true;

			public RecycleListView(android.content.Context context) : base(context)
			{
			}

			public RecycleListView(android.content.Context context, android.util.AttributeSet
				 attrs) : base(context, attrs)
			{
			}

			public RecycleListView(android.content.Context context, android.util.AttributeSet
				 attrs, int defStyle) : base(context, attrs, defStyle)
			{
			}

			[Sharpen.OverridesMethod(@"android.widget.ListView")]
			protected internal override bool recycleOnMeasure()
			{
				return mRecycleOnMeasure;
			}
		}

		public class AlertParams
		{
			public readonly android.content.Context mContext;

			public readonly android.view.LayoutInflater mInflater;

			public int mIconId = 0;

			public android.graphics.drawable.Drawable mIcon;

			public java.lang.CharSequence mTitle;

			public android.view.View mCustomTitleView;

			public java.lang.CharSequence mMessage;

			public java.lang.CharSequence mPositiveButtonText;

			public android.content.DialogInterfaceClass.OnClickListener mPositiveButtonListener;

			public java.lang.CharSequence mNegativeButtonText;

			public android.content.DialogInterfaceClass.OnClickListener mNegativeButtonListener;

			public java.lang.CharSequence mNeutralButtonText;

			public android.content.DialogInterfaceClass.OnClickListener mNeutralButtonListener;

			public bool mCancelable;

			public android.content.DialogInterfaceClass.OnCancelListener mOnCancelListener;

			public android.content.DialogInterfaceClass.OnKeyListener mOnKeyListener;

			public java.lang.CharSequence[] mItems;

			public android.widget.ListAdapter mAdapter;

			public android.content.DialogInterfaceClass.OnClickListener mOnClickListener;

			public android.view.View mView;

			public int mViewSpacingLeft;

			public int mViewSpacingTop;

			public int mViewSpacingRight;

			public int mViewSpacingBottom;

			public bool mViewSpacingSpecified = false;

			public bool[] mCheckedItems;

			public bool mIsMultiChoice;

			public bool mIsSingleChoice;

			public int mCheckedItem = -1;

			public android.content.DialogInterfaceClass.OnMultiChoiceClickListener mOnCheckboxClickListener;

			public android.database.Cursor mCursor;

			public string mLabelColumn;

			public string mIsCheckedColumn;

			public bool mForceInverseBackground;

			public android.widget.AdapterView.OnItemSelectedListener mOnItemSelectedListener;

			public android.app.@internal.AlertController.AlertParams.OnPrepareListViewListener
				 mOnPrepareListViewListener;

			public bool mRecycleOnMeasure = true;

			/// <summary>
			/// Interface definition for a callback to be invoked before the ListView
			/// will be bound to an adapter.
			/// </summary>
			/// <remarks>
			/// Interface definition for a callback to be invoked before the ListView
			/// will be bound to an adapter.
			/// </remarks>
			public interface OnPrepareListViewListener
			{
				/// <summary>Called before the ListView is bound to an adapter.</summary>
				/// <remarks>Called before the ListView is bound to an adapter.</remarks>
				/// <param name="listView">The ListView that will be shown in the dialog.</param>
				void onPrepareListView(android.widget.ListView listView);
			}

			public AlertParams(android.content.Context context)
			{
				mContext = context;
				mCancelable = true;
				mInflater = (android.view.LayoutInflater)context.getSystemService(android.content.Context
					.LAYOUT_INFLATER_SERVICE);
			}

			public virtual void apply(android.app.@internal.AlertController dialog)
			{
				if (mCustomTitleView != null)
				{
					dialog.setCustomTitle(mCustomTitleView);
				}
				else
				{
					if (mTitle != null)
					{
						dialog.setTitle(mTitle);
					}
					if (mIcon != null)
					{
						dialog.setIcon(mIcon);
					}
					if (mIconId >= 0)
					{
						dialog.setIcon(mIconId);
					}
				}
				if (mMessage != null)
				{
					dialog.setMessage(mMessage);
				}
				if (mPositiveButtonText != null)
				{
					dialog.setButton(android.content.DialogInterfaceClass.BUTTON_POSITIVE, mPositiveButtonText
						, mPositiveButtonListener, null);
				}
				if (mNegativeButtonText != null)
				{
					dialog.setButton(android.content.DialogInterfaceClass.BUTTON_NEGATIVE, mNegativeButtonText
						, mNegativeButtonListener, null);
				}
				if (mNeutralButtonText != null)
				{
					dialog.setButton(android.content.DialogInterfaceClass.BUTTON_NEUTRAL, mNeutralButtonText
						, mNeutralButtonListener, null);
				}
				if (mForceInverseBackground)
				{
					dialog.setInverseBackgroundForced(true);
				}
				// For a list, the client can either supply an array of items or an
				// adapter or a cursor
				if ((mItems != null) || (mCursor != null) || (mAdapter != null))
				{
					createListView(dialog);
				}
				if (mView != null)
				{
					if (mViewSpacingSpecified)
					{
						dialog.setView(mView, mViewSpacingLeft, mViewSpacingTop, mViewSpacingRight, mViewSpacingBottom
							);
					}
					else
					{
						dialog.setView(mView);
					}
				}
			}

			private sealed class _ArrayAdapter_859 : android.widget.ArrayAdapter<java.lang.CharSequence
				>
			{
				public _ArrayAdapter_859(AlertParams _enclosing, android.app.@internal.AlertController
					.RecycleListView listView, android.content.Context baseArg1, int baseArg2, int baseArg3
					, java.lang.CharSequence[] baseArg4) : base(baseArg1, baseArg2, baseArg3, baseArg4
					)
				{
					this._enclosing = _enclosing;
					this.listView = listView;
				}

				[Sharpen.ImplementsInterface(@"android.widget.Adapter")]
				public override android.view.View getView(int position, android.view.View convertView
					, android.view.ViewGroup parent)
				{
					android.view.View view = base.getView(position, convertView, parent);
					if (this._enclosing.mCheckedItems != null)
					{
						bool isItemChecked = this._enclosing.mCheckedItems[position];
						if (isItemChecked)
						{
							listView.setItemChecked(position, true);
						}
					}
					return view;
				}

				private readonly AlertParams _enclosing;

				private readonly android.app.@internal.AlertController.RecycleListView listView;
			}

			private sealed class _CursorAdapter_873 : android.widget.CursorAdapter
			{
				public _CursorAdapter_873(AlertParams _enclosing, android.app.@internal.AlertController
					.RecycleListView listView, android.app.@internal.AlertController dialog, android.content.Context
					 baseArg1, android.database.Cursor baseArg2, bool baseArg3) : base(baseArg1, baseArg2
					, baseArg3)
				{
					this._enclosing = _enclosing;
					this.listView = listView;
					this.dialog = dialog;
					{
						android.database.Cursor cursor = this.getCursor();
						this.mLabelIndex = cursor.getColumnIndexOrThrow(this._enclosing.mLabelColumn);
						this.mIsCheckedIndex = cursor.getColumnIndexOrThrow(this._enclosing.mIsCheckedColumn
							);
					}
				}

				private readonly int mLabelIndex;

				private readonly int mIsCheckedIndex;

				[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
				public override void bindView(android.view.View view, android.content.Context context
					, android.database.Cursor cursor)
				{
					android.widget.CheckedTextView text = (android.widget.CheckedTextView)view.findViewById
						(android.@internal.R.id.text1);
					text.setText(java.lang.CharSequenceProxy.Wrap(cursor.getString(this.mLabelIndex))
						);
					listView.setItemChecked(cursor.getPosition(), cursor.getInt(this.mIsCheckedIndex)
						 == 1);
				}

				[Sharpen.OverridesMethod(@"android.widget.CursorAdapter")]
				public override android.view.View newView(android.content.Context context, android.database.Cursor
					 cursor, android.view.ViewGroup parent)
				{
					return this._enclosing.mInflater.inflate(dialog.mMultiChoiceItemLayout, parent, false
						);
				}

				private readonly AlertParams _enclosing;

				private readonly android.app.@internal.AlertController.RecycleListView listView;

				private readonly android.app.@internal.AlertController dialog;
			}

			private sealed class _OnItemClickListener_922 : android.widget.AdapterView.OnItemClickListener
			{
				public _OnItemClickListener_922(AlertParams _enclosing, android.app.@internal.AlertController
					 dialog)
				{
					this._enclosing = _enclosing;
					this.dialog = dialog;
				}

				[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
				public void onItemClick(object parent, android.view.View v, int position, long id
					)
				{
					this._enclosing.mOnClickListener.onClick(dialog.mDialogInterface, position);
					if (!this._enclosing.mIsSingleChoice)
					{
						dialog.mDialogInterface.dismiss();
					}
				}

				private readonly AlertParams _enclosing;

				private readonly android.app.@internal.AlertController dialog;
			}

			private sealed class _OnItemClickListener_931 : android.widget.AdapterView.OnItemClickListener
			{
				public _OnItemClickListener_931(AlertParams _enclosing, android.app.@internal.AlertController
					.RecycleListView listView, android.app.@internal.AlertController dialog)
				{
					this._enclosing = _enclosing;
					this.listView = listView;
					this.dialog = dialog;
				}

				[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
				public void onItemClick(object parent, android.view.View v, int position, long id
					)
				{
					if (this._enclosing.mCheckedItems != null)
					{
						this._enclosing.mCheckedItems[position] = listView.isItemChecked(position);
					}
					this._enclosing.mOnCheckboxClickListener.onClick(dialog.mDialogInterface, position
						, listView.isItemChecked(position));
				}

				private readonly AlertParams _enclosing;

				private readonly android.app.@internal.AlertController.RecycleListView listView;

				private readonly android.app.@internal.AlertController dialog;
			}

			private void createListView(android.app.@internal.AlertController dialog)
			{
				android.app.@internal.AlertController.RecycleListView listView = (android.app.@internal.AlertController
					.RecycleListView)mInflater.inflate(dialog.mListLayout, null);
				android.widget.ListAdapter adapter;
				if (mIsMultiChoice)
				{
					if (mCursor == null)
					{
						adapter = new _ArrayAdapter_859(this, listView, mContext, dialog.mMultiChoiceItemLayout
							, android.@internal.R.id.text1, mItems);
					}
					else
					{
						adapter = new _CursorAdapter_873(this, listView, dialog, mContext, mCursor, false
							);
					}
				}
				else
				{
					int layout = mIsSingleChoice ? dialog.mSingleChoiceItemLayout : dialog.mListItemLayout;
					if (mCursor == null)
					{
						adapter = (mAdapter != null) ? mAdapter : new android.widget.ArrayAdapter<java.lang.CharSequence
							>(mContext, layout, android.@internal.R.id.text1, mItems);
					}
					else
					{
						adapter = new android.widget.SimpleCursorAdapter(mContext, layout, mCursor, new string
							[] { mLabelColumn }, new int[] { android.@internal.R.id.text1 });
					}
				}
				if (mOnPrepareListViewListener != null)
				{
					mOnPrepareListViewListener.onPrepareListView(listView);
				}
				dialog.mAdapter = adapter;
				dialog.mCheckedItem = mCheckedItem;
				if (mOnClickListener != null)
				{
					listView.setOnItemClickListener(new _OnItemClickListener_922(this, dialog));
				}
				else
				{
					if (mOnCheckboxClickListener != null)
					{
						listView.setOnItemClickListener(new _OnItemClickListener_931(this, listView, dialog
							));
					}
				}
				// Attach a given OnItemSelectedListener to the ListView
				if (mOnItemSelectedListener != null)
				{
					listView.setOnItemSelectedListener(mOnItemSelectedListener);
				}
				if (mIsSingleChoice)
				{
					listView.setChoiceMode(android.widget.AbsListView.CHOICE_MODE_SINGLE);
				}
				else
				{
					if (mIsMultiChoice)
					{
						listView.setChoiceMode(android.widget.AbsListView.CHOICE_MODE_MULTIPLE);
					}
				}
				listView.mRecycleOnMeasure = mRecycleOnMeasure;
				dialog.mListView = listView;
			}
		}
	}
}
