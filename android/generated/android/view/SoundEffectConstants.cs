using Sharpen;

namespace android.view
{
	/// <summary>
	/// Constants to be used to play sound effects via
	/// <see cref="View.playSoundEffect(int)">View.playSoundEffect(int)</see>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public class SoundEffectConstants
	{
		private SoundEffectConstants()
		{
		}

		public const int CLICK = 0;

		public const int NAVIGATION_LEFT = 1;

		public const int NAVIGATION_UP = 2;

		public const int NAVIGATION_RIGHT = 3;

		public const int NAVIGATION_DOWN = 4;

		/// <summary>Get the sonification constant for the focus directions.</summary>
		/// <remarks>Get the sonification constant for the focus directions.</remarks>
		/// <param name="direction">
		/// One of
		/// <see cref="View.FOCUS_UP">View.FOCUS_UP</see>
		/// ,
		/// <see cref="View.FOCUS_DOWN">View.FOCUS_DOWN</see>
		/// ,
		/// <see cref="View.FOCUS_LEFT">View.FOCUS_LEFT</see>
		/// ,
		/// <see cref="View.FOCUS_RIGHT">View.FOCUS_RIGHT</see>
		/// ,
		/// <see cref="View.FOCUS_FORWARD">View.FOCUS_FORWARD</see>
		/// or
		/// <see cref="View.FOCUS_BACKWARD">View.FOCUS_BACKWARD</see>
		/// </param>
		/// <returns>The appropriate sonification constant.</returns>
		public static int getContantForFocusDirection(int direction)
		{
			switch (direction)
			{
				case android.view.View.FOCUS_RIGHT:
				{
					return android.view.SoundEffectConstants.NAVIGATION_RIGHT;
				}

				case android.view.View.FOCUS_FORWARD:
				case android.view.View.FOCUS_DOWN:
				{
					return android.view.SoundEffectConstants.NAVIGATION_DOWN;
				}

				case android.view.View.FOCUS_LEFT:
				{
					return android.view.SoundEffectConstants.NAVIGATION_LEFT;
				}

				case android.view.View.FOCUS_BACKWARD:
				case android.view.View.FOCUS_UP:
				{
					return android.view.SoundEffectConstants.NAVIGATION_UP;
				}
			}
			throw new System.ArgumentException("direction must be one of " + "{FOCUS_UP, FOCUS_DOWN, FOCUS_LEFT, FOCUS_RIGHT, FOCUS_FORWARD, FOCUS_BACKWARD}."
				);
		}
	}
}
