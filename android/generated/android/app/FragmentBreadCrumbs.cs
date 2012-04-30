using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public class FragmentBreadCrumbs : android.view.ViewGroup, android.app.FragmentManager
		.OnBackStackChangedListener
	{
		internal android.app.Activity mActivity;

		internal android.view.LayoutInflater mInflater;

		internal android.widget.LinearLayout mContainer;

		internal int mMaxVisible = -1;

		internal android.app.BackStackRecord mTopEntry;

		internal android.app.BackStackRecord mParentEntry;

		private android.view.View.OnClickListener mParentClickListener;

		private android.app.FragmentBreadCrumbs.OnBreadCrumbClickListener mOnBreadCrumbClickListener;

		[Sharpen.Stub]
		public interface OnBreadCrumbClickListener
		{
			[Sharpen.Stub]
			bool onBreadCrumbClick(android.app.FragmentManager.BackStackEntry backStack, int 
				flags);
		}

		[Sharpen.Stub]
		public FragmentBreadCrumbs(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FragmentBreadCrumbs(android.content.Context context, android.util.AttributeSet
			 attrs) : this(context, attrs, android.R.style.Widget_FragmentBreadCrumbs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public FragmentBreadCrumbs(android.content.Context context, android.util.AttributeSet
			 attrs, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setActivity(android.app.Activity a)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaxVisible(int visibleCrumbs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setParentTitle(java.lang.CharSequence title, java.lang.CharSequence
			 shortTitle, android.view.View.OnClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnBreadCrumbClickListener(android.app.FragmentBreadCrumbs.
			OnBreadCrumbClickListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal android.app.BackStackRecord createBackStackEntry(java.lang.CharSequence 
			title, java.lang.CharSequence shortTitle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTitle(java.lang.CharSequence title, java.lang.CharSequence
			 shortTitle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onLayout(bool changed, int l, int t, int r, int 
			b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.app.FragmentManager.OnBackStackChangedListener"
			)]
		public virtual void onBackStackChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getPreEntryCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.app.FragmentManager.BackStackEntry getPreEntry(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void updateCrumbs()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _OnClickListener_290 : android.view.View.OnClickListener
		{
			public _OnClickListener_290()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
			public void onClick(android.view.View v)
			{
				throw new System.NotImplementedException();
			}
		}

		private android.view.View.OnClickListener mOnClickListener = new _OnClickListener_290
			();
	}
}
