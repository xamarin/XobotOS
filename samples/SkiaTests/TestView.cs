using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using android.view;
using android.content;
using android.graphics;
using android.graphics.drawable;

namespace XobotOS.Samples.SkiaTests
{
	public abstract class TestView : android.view.View
	{
		public TestView (Context context)
			: base (context)
		{ }

		protected Bitmap GetResourceBitmap (int resid)
		{
			var drawable = (BitmapDrawable)getResources ().getDrawable (resid);
			return drawable.getBitmap ();
		}
	}
}
