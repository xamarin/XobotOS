using System;
using System.Reflection;
using android.app;

namespace XobotOS.Samples.SkiaTests
{
	public class TestActivity : Activity
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			var name = getIntent().getStringExtra ("type");
			var type = Assembly.GetExecutingAssembly ().GetType (name, true);
			var view = (TestView)Activator.CreateInstance (type, new object[] { this });

			setContentView (view);
		}
	}
}

