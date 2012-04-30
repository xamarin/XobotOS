using System;
using java.util;
using android.app;
using android.content;
using android.graphics;
using android.graphics.drawable;
using android.widget;
using android.view;

namespace XobotOS.Samples.Fragments
{
	public class MainActivity : Activity, Monkey.OnMonkeySelectedListener
	{
		internal const string EXTRA_TITLE = "title";
		internal const string EXTRA_RESOURCE = "resource";

		internal ListAdapter createAdapter ()
		{
			return new SimpleAdapter (
				this, getData (), android.R.layout.simple_list_item_1,
				new string[] { "title" }, new int[] { android.R.id.text1 });
		}

		List<Map<String,Object>> getData ()
		{
			var list = new ArrayList<Map<String,Object>> ();

			var drawables = getResources ().obtainTypedArray (R.array.lemur_drawables);
			var strings = getResources ().getStringArray (R.array.lemur_strings);

			for (int i = 0; i < drawables.length(); i++) {
				var drawable = drawables.getDrawable (i);
				var resId = drawables.getResourceId (i, -1);
				var monkey = new Monkey (strings [i], drawable, resId);
				var map = new HashMap<String,Object> ();
				map.put ("title", monkey.Name);
				map.put ("monkey", monkey);
				list.add (Collections.unmodifiableMap (map));
			}

			return Collections.unmodifiableList (list);
		}

		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			setContentView (R.layout.main);
		}

		public void onMonkeySelected (Monkey monkey)
		{
			var image = (MonkeyImage)getFragmentManager ().findFragmentById (R.id.image_fragment);
			if (image != null)
				image.setMonkey (monkey);
			else {
				Intent intent = new Intent (this, typeof (ImageActivity));
				intent.putExtra (EXTRA_TITLE, monkey.Name);
				intent.putExtra (EXTRA_RESOURCE, monkey.ResourceId);
				startActivityForResult (intent, 1);
			}
		}
	}
}

