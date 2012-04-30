using System;
using java.util;
using android.app;
using android.widget;
using android.view;

namespace XobotOS.Samples.Fragments
{
	public class MonkeyList : ListFragment
	{
		Monkey.OnMonkeySelectedListener listener;

		public override void onCreate (android.os.Bundle savedInstanceState)
		{
			base.onCreate (savedInstanceState);

			var activity = (MainActivity)getActivity ();
			setListAdapter (activity.createAdapter ());
		}

		public override void onListItemClick (ListView list, View v, int pos, long id)
		{
			var item = (Map<String,Object>)list.getItemAtPosition (pos);
			var monkey = (Monkey)item.get ("monkey");

			if (listener != null)
				listener.onMonkeySelected (monkey);
		}

		public override void onAttach (Activity activity)
		{
			listener = (Monkey.OnMonkeySelectedListener)activity;
			base.onAttach (activity);
		}
	}
}

