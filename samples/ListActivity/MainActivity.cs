using System;
using System.Linq;

using android.app;
using android.content;
using android.graphics;
using android.graphics.drawable;
using android.text;
using android.view;
using android.widget;

namespace XobotOS.Samples.ListActivity
{
	public class MainActivity : android.app.ListActivity
	{
		protected override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			var res = getResources();
			var lemurs = res.getStringArray (R.array.lemur_string_array);

			var adapter = new ArrayAdapter<string> (
				this, android.R.layout.simple_list_item_1, lemurs);
			setListAdapter (adapter);
		}

		internal const string EXTRA_POSITION = "position";

                protected override void onListItemClick (ListView list, View v, int pos, long id)
		{
			Intent intent = new Intent (this, typeof (ImageActivity));
			intent.putExtra (EXTRA_POSITION, pos);
			startActivityForResult (intent, 1);
		}

	}
}
