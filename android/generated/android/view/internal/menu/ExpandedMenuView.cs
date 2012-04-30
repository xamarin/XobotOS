using Sharpen;

namespace android.view.@internal.menu
{
	/// <summary>The expanded menu view is a list-like menu with all of the available menu items.
	/// 	</summary>
	/// <remarks>
	/// The expanded menu view is a list-like menu with all of the available menu items.  It is opened
	/// by the user clicking no the 'More' button on the icon menu view.
	/// </remarks>
	[Sharpen.Sharpened]
	public sealed class ExpandedMenuView : android.widget.ListView, android.view.@internal.menu.MenuBuilder
		.ItemInvoker, android.view.@internal.menu.MenuView, android.widget.AdapterView.OnItemClickListener
	{
		private android.view.@internal.menu.MenuBuilder mMenu;

		/// <summary>Default animations for this menu</summary>
		private int mAnimations;

		/// <summary>Instantiates the ExpandedMenuView that is linked with the provided MenuBuilder.
		/// 	</summary>
		/// <remarks>Instantiates the ExpandedMenuView that is linked with the provided MenuBuilder.
		/// 	</remarks>
		/// <param name="menu">The model for the menu which this MenuView will display</param>
		public ExpandedMenuView(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			android.content.res.TypedArray a = context.obtainStyledAttributes(attrs, android.@internal.R
				.styleable.MenuView, 0, 0);
			mAnimations = a.getResourceId(android.@internal.R.styleable.MenuView_windowAnimationStyle
				, 0);
			a.recycle();
			setOnItemClickListener(this);
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public void initialize(android.view.@internal.menu.MenuBuilder menu)
		{
			mMenu = menu;
		}

		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			base.onDetachedFromWindow();
			// Clear the cached bitmaps of children
			setChildrenDrawingCacheEnabled(false);
		}

		[Sharpen.OverridesMethod(@"android.widget.ListView")]
		protected internal override bool recycleOnMeasure()
		{
			return false;
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.ItemInvoker"
			)]
		public bool invokeItem(android.view.@internal.menu.MenuItemImpl item)
		{
			return mMenu.performItemAction(item, 0);
		}

		[Sharpen.ImplementsInterface(@"android.widget.AdapterView.OnItemClickListener")]
		public void onItemClick(object parent, android.view.View v, int position, long id
			)
		{
			invokeItem((android.view.@internal.menu.MenuItemImpl)getAdapter().getItem(position
				));
		}

		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuView")]
		public int getWindowAnimations()
		{
			return mAnimations;
		}
	}
}
