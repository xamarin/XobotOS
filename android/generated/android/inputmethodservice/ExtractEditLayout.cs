using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public class ExtractEditLayout : android.widget.LinearLayout
	{
		private android.inputmethodservice.ExtractEditLayout.ExtractActionMode mActionMode;

		internal android.widget.Button mExtractActionButton;

		internal android.widget.Button mEditButton;

		[Sharpen.Stub]
		public ExtractEditLayout(android.content.Context context) : base(context)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ExtractEditLayout(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.ViewGroup")]
		public override android.view.ActionMode startActionModeForChild(android.view.View
			 sourceView, android.view.ActionMode.Callback cb)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isActionModeStarted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void finishActionMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onFinishInflate()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class ExtractActionMode : android.view.ActionMode, android.view.@internal.menu.MenuBuilder
			.Callback
		{
			internal android.view.ActionMode.Callback mCallback;

			internal android.view.@internal.menu.MenuBuilder mMenu;

			[Sharpen.Stub]
			public ExtractActionMode(ExtractEditLayout _enclosing, android.view.ActionMode.Callback
				 cb)
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
			public override void setTitle(int resId)
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
			public virtual bool dispatchOnCreate()
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
			[Sharpen.ImplementsInterface(@"com.android.internal.view.menu.MenuBuilder.Callback"
				)]
			public virtual void onMenuModeChange(android.view.@internal.menu.MenuBuilder menu
				)
			{
				throw new System.NotImplementedException();
			}

			private readonly ExtractEditLayout _enclosing;
		}
	}
}
