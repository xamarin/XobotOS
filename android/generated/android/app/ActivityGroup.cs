using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	[System.ObsoleteAttribute(@"Use the new Fragment and FragmentManager APIs instead; these are also available on older platforms through the Android compatibility package."
		)]
	public class ActivityGroup : android.app.Activity
	{
		internal const string STATES_KEY = "android:states";

		internal const string PARENT_NON_CONFIG_INSTANCE_KEY = "android:parent_non_config_instance";

		protected internal android.app.LocalActivityManager mLocalActivityManager;

		[Sharpen.Stub]
		public ActivityGroup() : this(true)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ActivityGroup(bool singleActivityMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onCreate(android.os.Bundle savedInstanceState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onResume()
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
		protected internal override void onPause()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onStop()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		protected internal override void onDestroy()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		internal override java.util.HashMap<string, object> onRetainNonConfigurationChildInstances
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.app.Activity getCurrentActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.app.LocalActivityManager getLocalActivityManager()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.app.Activity")]
		internal override void dispatchActivityResult(string who, int requestCode, int resultCode
			, android.content.Intent data)
		{
			throw new System.NotImplementedException();
		}
	}
}
