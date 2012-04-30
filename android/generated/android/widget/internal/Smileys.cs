using Sharpen;

namespace android.widget.@internal
{
	/// <summary>Temp stupidity until we have a real emoticon API.</summary>
	/// <remarks>Temp stupidity until we have a real emoticon API.</remarks>
	[Sharpen.Sharpened]
	public class Smileys
	{
		private static readonly int[] sIconIds = new int[] { android.@internal.R.drawable
			.emo_im_happy, android.@internal.R.drawable.emo_im_sad, android.@internal.R.drawable
			.emo_im_winking, android.@internal.R.drawable.emo_im_tongue_sticking_out, android.@internal.R
			.drawable.emo_im_surprised, android.@internal.R.drawable.emo_im_kissing, android.@internal.R
			.drawable.emo_im_yelling, android.@internal.R.drawable.emo_im_cool, android.@internal.R
			.drawable.emo_im_money_mouth, android.@internal.R.drawable.emo_im_foot_in_mouth, 
			android.@internal.R.drawable.emo_im_embarrassed, android.@internal.R.drawable.emo_im_angel
			, android.@internal.R.drawable.emo_im_undecided, android.@internal.R.drawable.emo_im_crying
			, android.@internal.R.drawable.emo_im_lips_are_sealed, android.@internal.R.drawable
			.emo_im_laughing, android.@internal.R.drawable.emo_im_wtf };

		public static int HAPPY = 0;

		public static int SAD = 1;

		public static int WINKING = 2;

		public static int TONGUE_STICKING_OUT = 3;

		public static int SURPRISED = 4;

		public static int KISSING = 5;

		public static int YELLING = 6;

		public static int COOL = 7;

		public static int MONEY_MOUTH = 8;

		public static int FOOT_IN_MOUTH = 9;

		public static int EMBARRASSED = 10;

		public static int ANGEL = 11;

		public static int UNDECIDED = 12;

		public static int CRYING = 13;

		public static int LIPS_ARE_SEALED = 14;

		public static int LAUGHING = 15;

		public static int WTF = 16;

		public static int getSmileyResource(int which)
		{
			return sIconIds[which];
		}
	}
}
