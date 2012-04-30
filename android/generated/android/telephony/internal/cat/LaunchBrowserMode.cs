using Sharpen;

namespace android.telephony.@internal.cat
{
	/// <summary>Browser launch mode for LAUNCH BROWSER proactive command.</summary>
	/// <remarks>
	/// Browser launch mode for LAUNCH BROWSER proactive command.
	/// <hide></hide>
	/// </remarks>
	public enum LaunchBrowserMode
	{
		/// <summary>Launch browser if not already launched.</summary>
		/// <remarks>Launch browser if not already launched.</remarks>
		LAUNCH_IF_NOT_ALREADY_LAUNCHED,
		/// <summary>
		/// Use the existing browser (the browser shall not use the active existing
		/// secured session).
		/// </summary>
		/// <remarks>
		/// Use the existing browser (the browser shall not use the active existing
		/// secured session).
		/// </remarks>
		USE_EXISTING_BROWSER,
		/// <summary>Close the existing browser session and launch new browser session.</summary>
		/// <remarks>Close the existing browser session and launch new browser session.</remarks>
		LAUNCH_NEW_BROWSER
	}
}
