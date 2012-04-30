using System;
using android.app;
using android.graphics;
using android.graphics.drawable;
using android.widget;
using android.view;

namespace XobotOS.Samples.Fragments
{
	public class MonkeyImage : Fragment
	{
		public override View onCreateView (LayoutInflater inflater, ViewGroup container, android.os.Bundle savedInstanceState)
		{
			return inflater.inflate (R.layout.monkey_image, container);
		}

		internal void setMonkey (Monkey monkey)
		{
			var label = (TextView)getView ().findViewById (R.id.monkey_name);
			var image = (ImageView)getView ().findViewById (R.id.monkey_image_view);

			label.setText (java.lang.CharSequenceProxy.Wrap (monkey.Name));
			image.setImageDrawable (monkey.Drawable);
		}

		internal void setMonkey (string name, int res)
		{
			var label = (TextView)getView ().findViewById (R.id.monkey_name);
			var image = (ImageView)getView ().findViewById (R.id.monkey_image_view);

			label.setText (java.lang.CharSequenceProxy.Wrap (name));
			image.setImageResource (res);
		}
	}
}

