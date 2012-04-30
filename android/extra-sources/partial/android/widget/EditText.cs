using System;
using android.text;

namespace android.widget
{
	partial class EditText
	{
		new public Editable getText ()
		{
			return (Editable)base.getText ();
		}

		/// <summary>
		/// Convenience for
		/// <see cref="android.text.Selection.selectAll(android.text.Spannable)">android.text.Selection.selectAll(android.text.Spannable)
		/// 	</see>
		/// .
		/// </summary>
		new public void selectAll ()
		{
			Selection.selectAll (getText ());
		}
	}
}
