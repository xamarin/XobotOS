using System;
using System.Reflection;
using java.util;
using android.app;
using android.content;
using android.graphics;
using android.widget;
using android.view;

namespace XobotOS.Samples.SkiaTests
{
	public class MainActivity : ListActivity
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			setListAdapter (new SimpleAdapter (this, getData (), android.R.layout.simple_list_item_1,
			                                 new String[] { "title" }, new int[] { android.R.id.text1 }));
		}

		List<Map<String,Object>> getData ()
		{
			var list = new ArrayList<Map<String,Object>> ();
			foreach (Type type in Assembly.GetExecutingAssembly ().GetTypes ()) {
				var attrs = type.GetCustomAttributes (typeof(TestAttribute), false);
				if ((attrs == null) || (attrs.Length != 1))
					continue;

				var attr = (TestAttribute)attrs [0];
				var map = new HashMap<String,Object> ();
				map.put ("title", attr.Name);
				map.put ("type", type);
				list.add (Collections.unmodifiableMap (map));
			}
			return Collections.unmodifiableList (list);
		}

		protected override void onListItemClick (ListView l, View v, int position, long id)
		{
			var item = (Map<String,Object>)l.getItemAtPosition (position);
			var type = (Type)item.get("type");

			var intent = new Intent (this, typeof (TestActivity));
			intent.putExtra ("type", type.FullName);
			startActivity (intent);
		}
	}
}

