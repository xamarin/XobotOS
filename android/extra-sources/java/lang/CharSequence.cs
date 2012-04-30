namespace java.lang
{
	public interface CharSequence
	{
		int Length {
			get;
		}

		char this [int index] {
			get;
		}
		
		CharSequence SubSequence (int start, int end);
	}
}

