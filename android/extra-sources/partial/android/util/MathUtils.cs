using System;

namespace android.util
{
	partial class MathUtils
	{
		private static System.Random sRandom = new System.Random ();

		public static void randomSeed (long seed)
		{
			sRandom = new Random (unchecked ((int)seed));
		}
	}
}

