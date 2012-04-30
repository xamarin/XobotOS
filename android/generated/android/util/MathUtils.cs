using Sharpen;

namespace android.util
{
	/// <summary>A class that contains utility methods related to numbers.</summary>
	/// <remarks>A class that contains utility methods related to numbers.</remarks>
	/// <hide>Pending API council approval</hide>
	[Sharpen.Sharpened]
	public sealed partial class MathUtils
	{
		internal const float DEG_TO_RAD = 3.1415926f / 180.0f;

		internal const float RAD_TO_DEG = 180.0f / 3.1415926f;

		private MathUtils()
		{
		}

		public static float abs(float v)
		{
			return v > 0 ? v : -v;
		}

		public static int constrain(int amount, int low, int high)
		{
			return amount < low ? low : (amount > high ? high : amount);
		}

		public static float constrain(float amount, float low, float high)
		{
			return amount < low ? low : (amount > high ? high : amount);
		}

		public static float log(float a)
		{
			return (float)System.Math.Log(a);
		}

		public static float exp(float a)
		{
			return (float)System.Math.Exp(a);
		}

		public static float pow(float a, float b)
		{
			return (float)System.Math.Pow(a, b);
		}

		public static float max(float a, float b)
		{
			return a > b ? a : b;
		}

		public static float max(int a, int b)
		{
			return a > b ? a : b;
		}

		public static float max(float a, float b, float c)
		{
			return a > b ? (a > c ? a : c) : (b > c ? b : c);
		}

		public static float max(int a, int b, int c)
		{
			return a > b ? (a > c ? a : c) : (b > c ? b : c);
		}

		public static float min(float a, float b)
		{
			return a < b ? a : b;
		}

		public static float min(int a, int b)
		{
			return a < b ? a : b;
		}

		public static float min(float a, float b, float c)
		{
			return a < b ? (a < c ? a : c) : (b < c ? b : c);
		}

		public static float min(int a, int b, int c)
		{
			return a < b ? (a < c ? a : c) : (b < c ? b : c);
		}

		public static float dist(float x1, float y1, float x2, float y2)
		{
			float x = (x2 - x1);
			float y = (y2 - y1);
			return (float)System.Math.Sqrt(x * x + y * y);
		}

		public static float dist(float x1, float y1, float z1, float x2, float y2, float 
			z2)
		{
			float x = (x2 - x1);
			float y = (y2 - y1);
			float z = (z2 - z1);
			return (float)System.Math.Sqrt(x * x + y * y + z * z);
		}

		public static float mag(float a, float b)
		{
			return (float)System.Math.Sqrt(a * a + b * b);
		}

		public static float mag(float a, float b, float c)
		{
			return (float)System.Math.Sqrt(a * a + b * b + c * c);
		}

		public static float sq(float v)
		{
			return v * v;
		}

		public static float radians(float degrees_1)
		{
			return degrees_1 * DEG_TO_RAD;
		}

		public static float degrees(float radians_1)
		{
			return radians_1 * RAD_TO_DEG;
		}

		public static float acos(float value)
		{
			return (float)System.Math.Acos(value);
		}

		public static float asin(float value)
		{
			return (float)System.Math.Asin(value);
		}

		public static float atan(float value)
		{
			return (float)System.Math.Atan(value);
		}

		public static float atan2(float a, float b)
		{
			return (float)System.Math.Atan2(a, b);
		}

		public static float tan(float angle)
		{
			return (float)System.Math.Tan(angle);
		}

		public static float lerp(float start, float stop, float amount)
		{
			return start + (stop - start) * amount;
		}

		public static float norm(float start, float stop, float value)
		{
			return (value - start) / (stop - start);
		}

		public static float map(float minStart, float minStop, float maxStart, float maxStop
			, float value)
		{
			return maxStart + (maxStart - maxStop) * ((value - minStart) / (minStop - minStart
				));
		}

		public static int random(int howbig)
		{
			return (int)(Sharpen.Util.Random_NextFloat(sRandom) * howbig);
		}

		public static int random(int howsmall, int howbig)
		{
			if (howsmall >= howbig)
			{
				return howsmall;
			}
			return (int)(Sharpen.Util.Random_NextFloat(sRandom) * (howbig - howsmall) + howsmall
				);
		}

		public static float random(float howbig)
		{
			return Sharpen.Util.Random_NextFloat(sRandom) * howbig;
		}

		public static float random(float howsmall, float howbig)
		{
			if (howsmall >= howbig)
			{
				return howsmall;
			}
			return Sharpen.Util.Random_NextFloat(sRandom) * (howbig - howsmall) + howsmall;
		}
	}
}
