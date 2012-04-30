using System;
using System.Text;

namespace android.graphics
{
	partial class Region
	{
		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append ("Region[");

			bool first = true;
			using (RegionIterator iter = new RegionIterator (this)) {
				Rect r = new Rect ();
				while (iter.next (r)) {
					string text = String.Format (
						"[{0},{0},{0},{0}]", r.left, r.top, r.right, r.bottom);
					if (first)
						first = false;
					else
						sb.Append (",");
					sb.Append (text);
				}
			}
			sb.Append ("]");
			return sb.ToString ();
		}
	}
}
