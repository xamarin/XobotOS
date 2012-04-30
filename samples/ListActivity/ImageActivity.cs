using System;
using android.app;
using android.content;
using android.graphics;
using android.graphics.drawable;
using android.widget;
using android.view;

namespace XobotOS.Samples.ListActivity
{
	public class ImageActivity : Activity, View.OnClickListener
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			int pos = getIntent ().getIntExtra (MainActivity.EXTRA_POSITION, -1);
			var ta = getResources ().obtainTypedArray (R.array.lemurs);
			var sa = getResources ().getStringArray (R.array.lemur_string_array);

			getWindow ().setTitle (java.lang.CharSequenceProxy.Wrap (sa [pos]));

			var drawable = ta.getDrawable (pos);

			var view = new ImageView (this);
			view.setImageDrawable (drawable);
			view.setOnClickListener (this);

			setContentView (view);
		}

		public void onClick (View v)
		{
			finish ();
		}
	}
}

