using Sharpen;

namespace java.lang
{
	/// <summary>Represents a command that can be executed.</summary>
	/// <remarks>
	/// Represents a command that can be executed. Often used to run code in a
	/// different
	/// <see cref="Thread">Thread</see>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public interface Runnable
	{
		/// <summary>Starts executing the active part of the class' code.</summary>
		/// <remarks>
		/// Starts executing the active part of the class' code. This method is
		/// called when a thread is started that has been created with a class which
		/// implements
		/// <code>Runnable</code>
		/// .
		/// </remarks>
		void run();
	}
}
