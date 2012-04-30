using Sharpen;

namespace android.view.@internal.menu
{
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class ActionMenuItemView : android.widget.LinearLayout, android.view.@internal.menu.MenuViewClass
		.ItemView, android.view.View.OnClickListener, android.view.View.OnLongClickListener
		, android.view.@internal.menu.ActionMenuView.ActionMenuChildView
	{
		internal const string TAG = "ActionMenuItemView";

		private android.view.@internal.menu.MenuItemImpl mItemData;

		private java.lang.CharSequence mTitle;

		private android.view.@internal.menu.MenuBuilder.ItemInvoker mItemInvoker;

		private android.widget.ImageButton mImageButton;

		private android.widget.Button mTextButton;

		private bool mAllowTextWithIcon;

		private bool mShowTextAllCaps;

		private bool mExpandedFormat;

		public ActionMenuItemView(android.content.Context context) : this(context, null)
		{
		}

		public ActionMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, 0)
		{
		}

		public ActionMenuItemView(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			android.content.res.Resources res = context.getResources();
			mAllowTextWithIcon = res.getBoolean(android.@internal.R.@bool.config_allowActionMenuItemTextWithIcon
				);
			mShowTextAllCaps = res.getBoolean(android.@internal.R.@bool.config_actionMenuItemAllCaps
				);
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			mImageButton = (android.widget.ImageButton)findViewById(android.@internal.R.id.imageButton
				);
			mTextButton = (android.widget.Button)findViewById(android.@internal.R.id.textButton
				);
			mImageButton.setOnClickListener(this);
			mTextButton.setOnClickListener(this);
			mImageButton.setOnLongClickListener(this);
			setOnClickListener(this);
			setOnLongClickListener(this);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual android.view.@internal.menu.MenuItemImpl getItemData()
		{
			return mItemData;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void initialize(android.view.@internal.menu.MenuItemImpl itemData, 
			int menuType)
		{
			mItemData = itemData;
			setIcon(itemData.getIcon());
			setTitle(itemData.getTitleForItemView(this));
			// Title only takes effect if there is no icon
			setId(itemData.getItemId());
			setVisibility(itemData.isVisible() ? android.view.View.VISIBLE : android.view.View
				.GONE);
			setEnabled(itemData.isEnabled());
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void setEnabled(bool enabled)
		{
			base.setEnabled(enabled);
			mImageButton.setEnabled(enabled);
			mTextButton.setEnabled(enabled);
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			if (mItemInvoker != null)
			{
				mItemInvoker.invokeItem(mItemData);
			}
		}

		public virtual void setItemInvoker(android.view.@internal.menu.MenuBuilder.ItemInvoker
			 invoker)
		{
			mItemInvoker = invoker;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual bool prefersCondensedTitle()
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setCheckable(bool checkable)
		{
		}

		// TODO Support checkable action items
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setChecked(bool @checked)
		{
		}

		// TODO Support checkable action items
		public virtual void setExpandedFormat(bool expandedFormat)
		{
			if (mExpandedFormat != expandedFormat)
			{
				mExpandedFormat = expandedFormat;
				if (mItemData != null)
				{
					mItemData.actionFormatChanged();
				}
			}
		}

		private void updateTextButtonVisibility()
		{
			bool visible = !android.text.TextUtils.isEmpty(mTextButton.getText());
			visible &= mImageButton.getDrawable() == null || (mItemData.showsTextAsAction() &&
				 (mAllowTextWithIcon || mExpandedFormat));
			mTextButton.setVisibility(visible ? VISIBLE : GONE);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setIcon(android.graphics.drawable.Drawable icon)
		{
			mImageButton.setImageDrawable(icon);
			if (icon != null)
			{
				mImageButton.setVisibility(VISIBLE);
			}
			else
			{
				mImageButton.setVisibility(GONE);
			}
			updateTextButtonVisibility();
		}

		public virtual bool hasText()
		{
			return mTextButton.getVisibility() != GONE;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setShortcut(bool showShortcut, char shortcutKey)
		{
		}

		// Action buttons don't show text for shortcut keys.
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual void setTitle(java.lang.CharSequence title)
		{
			mTitle = title;
			mTextButton.setText(mTitle);
			setContentDescription(mTitle);
			updateTextButtonVisibility();
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool dispatchPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			onPopulateAccessibilityEvent(@event);
			return true;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		public override void onPopulateAccessibilityEvent(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			base.onPopulateAccessibilityEvent(@event);
			java.lang.CharSequence cdesc = getContentDescription();
			if (!android.text.TextUtils.isEmpty(cdesc))
			{
				@event.getText().add(cdesc);
			}
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override bool dispatchHoverEvent(android.view.MotionEvent @event
			)
		{
			// Don't allow children to hover; we want this to be treated as a single component.
			return onHoverEvent(@event);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView.ItemView")]
		public virtual bool showsIcon()
		{
			return true;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.ActionMenuView.ActionMenuChildView"
			)]
		public virtual bool needsDividerBefore()
		{
			return hasText() && mItemData.getIcon() == null;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.ActionMenuView.ActionMenuChildView"
			)]
		public virtual bool needsDividerAfter()
		{
			return hasText();
		}

		[Sharpen.ImplementsInterface(@"android.view.View.OnLongClickListener")]
		public virtual bool onLongClick(android.view.View v)
		{
			if (hasText())
			{
				// Don't show the cheat sheet for items that already show text.
				return false;
			}
			int[] screenPos = new int[2];
			android.graphics.Rect displayFrame = new android.graphics.Rect();
			getLocationOnScreen(screenPos);
			getWindowVisibleDisplayFrame(displayFrame);
			android.content.Context context = getContext();
			int width = getWidth();
			int height = getHeight();
			int midy = screenPos[1] + height / 2;
			int screenWidth = context.getResources().getDisplayMetrics().widthPixels;
			android.widget.Toast cheatSheet = android.widget.Toast.makeText(context, mItemData
				.getTitle(), android.widget.Toast.LENGTH_SHORT);
			if (midy < displayFrame.height())
			{
				// Show along the top; follow action buttons
				cheatSheet.setGravity(android.view.Gravity.TOP | android.view.Gravity.RIGHT, screenWidth
					 - screenPos[0] - width / 2, height);
			}
			else
			{
				// Show along the bottom center
				cheatSheet.setGravity(android.view.Gravity.BOTTOM | android.view.Gravity.CENTER_HORIZONTAL
					, 0, height);
			}
			cheatSheet.show();
			return true;
		}
	}
}
