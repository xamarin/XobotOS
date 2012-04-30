using System;

using android.app;

namespace XobotOS.Samples.ScrollView
{
	public class MyActivity : Activity
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);
			setContentView (R.layout.scroll_view);
		}
	}
}
