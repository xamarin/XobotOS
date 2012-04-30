using System;
using android.app;
using android.widget;
using android.view;

namespace XobotOS.Samples.Fragments
{
	public class ImageActivity : Activity, View.OnClickListener
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			setContentView (R.layout.handheld);

			var title = getIntent ().getStringExtra (MainActivity.EXTRA_TITLE);
			var res = getIntent ().getIntExtra (MainActivity.EXTRA_RESOURCE, -1);

			getWindow ().setTitle (java.lang.CharSequenceProxy.Wrap (title));

			var image = (MonkeyImage)getFragmentManager ().findFragmentById (R.id.image_fragment);
			image.setMonkey (title, res);

			var list = findViewById (R.id.monkey_image_view);
			list.setOnClickListener (this);

			var back = findViewById (R.id.back_button);
			back.setOnClickListener (this);
		}

		public void onClick (View v)
		{
			finish ();
		}
	}
}

