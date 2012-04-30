using Sharpen;

namespace android.text.style
{
	[Sharpen.Stub]
	public interface TabStopSpan : android.text.style.ParagraphStyle
	{
		[Sharpen.Stub]
		int getTabStop();
	}

	[Sharpen.Stub]
	public static class TabStopSpanClass
	{
		[Sharpen.Stub]
		public class Standard : android.text.style.TabStopSpan
		{
			[Sharpen.Stub]
			public Standard(int where)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.text.style.TabStopSpan")]
			public virtual int getTabStop()
			{
				throw new System.NotImplementedException();
			}

			private int mTab;
		}
	}
}
