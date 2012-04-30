using Sharpen;

namespace android.view
{
	/// <summary>A helper class that allows unit tests to access FocusFinder methods.</summary>
	/// <remarks>A helper class that allows unit tests to access FocusFinder methods.</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public class FocusFinderHelper
	{
		private android.view.FocusFinder mFocusFinder;

		/// <summary>Wrap the FocusFinder object</summary>
		public FocusFinderHelper(android.view.FocusFinder focusFinder)
		{
			mFocusFinder = focusFinder;
		}

		public virtual bool isBetterCandidate(int direction, android.graphics.Rect source
			, android.graphics.Rect rect1, android.graphics.Rect rect2)
		{
			return mFocusFinder.isBetterCandidate(direction, source, rect1, rect2);
		}

		public virtual bool beamBeats(int direction, android.graphics.Rect source, android.graphics.Rect
			 rect1, android.graphics.Rect rect2)
		{
			return mFocusFinder.beamBeats(direction, source, rect1, rect2);
		}

		public virtual bool isCandidate(android.graphics.Rect srcRect, android.graphics.Rect
			 destRect, int direction)
		{
			return mFocusFinder.isCandidate(srcRect, destRect, direction);
		}

		public virtual bool beamsOverlap(int direction, android.graphics.Rect rect1, android.graphics.Rect
			 rect2)
		{
			return mFocusFinder.beamsOverlap(direction, rect1, rect2);
		}

		public static int majorAxisDistance(int direction, android.graphics.Rect source, 
			android.graphics.Rect dest)
		{
			return android.view.FocusFinder.majorAxisDistance(direction, source, dest);
		}

		public static int majorAxisDistanceToFarEdge(int direction, android.graphics.Rect
			 source, android.graphics.Rect dest)
		{
			return android.view.FocusFinder.majorAxisDistanceToFarEdge(direction, source, dest
				);
		}
	}
}
