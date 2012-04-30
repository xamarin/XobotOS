using Sharpen;

namespace android.graphics.drawable
{
	/// <summary>Interface that drawables suporting animations should implement.</summary>
	/// <remarks>Interface that drawables suporting animations should implement.</remarks>
	[Sharpen.Sharpened]
	public interface Animatable
	{
		/// <summary>Starts the drawable's animation.</summary>
		/// <remarks>Starts the drawable's animation.</remarks>
		void start();

		/// <summary>Stops the drawable's animation.</summary>
		/// <remarks>Stops the drawable's animation.</remarks>
		void stop();

		/// <summary>Indicates whether the animation is running.</summary>
		/// <remarks>Indicates whether the animation is running.</remarks>
		/// <returns>True if the animation is running, false otherwise.</returns>
		bool isRunning();
	}
}
