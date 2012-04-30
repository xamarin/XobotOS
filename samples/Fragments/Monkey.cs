using System;
using android.graphics.drawable;

namespace XobotOS.Samples.Fragments
{
	public class Monkey
	{
		public readonly string Name;
		public readonly Drawable Drawable;
		public readonly int ResourceId;

		public Monkey (string name, Drawable drawable, int res)
		{
			this.Name = name;
			this.Drawable = drawable;
			this.ResourceId = res;
		}

		public interface OnMonkeySelectedListener
		{
			void onMonkeySelected (Monkey monkey);
		}
	}
}
