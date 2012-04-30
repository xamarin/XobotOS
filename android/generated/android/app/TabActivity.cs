using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	[System.ObsoleteAttribute(@"New applications should use Fragments instead of this class; to continue to run on older devices, you can use the v4 support library which provides a version of the Fragment API that is compatible down toandroid.os.Build.VERSION_CODES.DONUT ."
		)]
	public class TabActivity : android.app.ActivityGroup
	{
		private android.widget.TabHost mTabHost;

		private string mDefaultTab = null;

		private int mDefaultTabIndex = -1;

		[Sharpen.Stub]
		public TabActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDefaultTab(string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDefaultTab(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onRestoreInstanceState(android.os.Bundle state)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onPostCreate(android.os.Bundle icicle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onSaveInstanceState(android.os.Bundle outState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		public override void onContentChanged()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void ensureTabHost()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onChildTitleChanged(android.app.Activity childActivity
			, java.lang.CharSequence title)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.TabHost getTabHost()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.widget.TabWidget getTabWidget()
		{
			throw new System.NotImplementedException();
		}
	}
}
