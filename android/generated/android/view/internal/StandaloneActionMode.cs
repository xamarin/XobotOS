using Sharpen;

namespace android.view.@internal
{
	[Sharpen.Stub]
	public class StandaloneActionMode : android.view.ActionMode, android.view.@internal.menu.MenuBuilder
		.Callback
	{
		private android.content.Context mContext;

		private android.widget.@internal.ActionBarContextView mContextView;

		private android.view.ActionMode.Callback mCallback;

		private java.lang.@ref.WeakReference<android.view.View> mCustomView;

		private bool mFinished;

		private bool mFocusable;

		private android.view.@internal.menu.MenuBuilder mMenu;

		[Sharpen.Stub]
		public StandaloneActionMode(android.content.Context context, android.widget.@internal.ActionBarContextView
			 view, android.view.ActionMode.Callback callback, bool isFocusable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void setTitle(java.lang.CharSequence title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void setSubtitle(java.lang.CharSequence subtitle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void setTitle(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void setSubtitle(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void setCustomView(android.view.View view)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void invalidate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override void finish()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override android.view.Menu getMenu()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override java.lang.CharSequence getTitle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override java.lang.CharSequence getSubtitle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override android.view.View getCustomView()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override android.view.MenuInflater getMenuInflater()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
			)]
		public virtual bool onMenuItemSelected(android.view.@internal.menu.MenuBuilder menu
			, android.view.MenuItem item)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onCloseMenu(android.view.@internal.menu.MenuBuilder menu, bool
			 allMenusAreClosing)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool onSubMenuSelected(android.view.@internal.menu.SubMenuBuilder 
			subMenu)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void onCloseSubMenu(android.view.@internal.menu.SubMenuBuilder menu
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
			)]
		public virtual void onMenuModeChange(android.view.@internal.menu.MenuBuilder menu
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ActionMode")]
		public override bool isUiFocusable()
		{
			throw new System.NotImplementedException();
		}
	}
}
