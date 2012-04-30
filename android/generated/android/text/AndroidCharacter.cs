using Sharpen;

namespace android.text
{
	[Sharpen.Stub]
	public class AndroidCharacter
	{
		public const int EAST_ASIAN_WIDTH_NEUTRAL = 0;

		public const int EAST_ASIAN_WIDTH_AMBIGUOUS = 1;

		public const int EAST_ASIAN_WIDTH_HALF_WIDTH = 2;

		public const int EAST_ASIAN_WIDTH_FULL_WIDTH = 3;

		public const int EAST_ASIAN_WIDTH_NARROW = 4;

		public const int EAST_ASIAN_WIDTH_WIDE = 5;

		[Sharpen.Stub]
		public static void getDirectionalities(char[] src, byte[] dest, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int getEastAsianWidth(char input)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void getEastAsianWidths(char[] src, int start, int count, byte[] dest
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static bool mirror(char[] text, int start, int count)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static char getMirror(char ch)
		{
			throw new System.NotImplementedException();
		}
	}
}
