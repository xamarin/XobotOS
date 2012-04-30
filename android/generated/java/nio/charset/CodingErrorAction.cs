using Sharpen;

namespace java.nio.charset
{
	/// <summary>
	/// Used to indicate what kind of actions to take in case of encoding/decoding
	/// errors.
	/// </summary>
	/// <remarks>
	/// Used to indicate what kind of actions to take in case of encoding/decoding
	/// errors. Currently three actions are defined:
	/// <code>IGNORE</code>
	/// ,
	/// <code>REPLACE</code>
	/// and
	/// <code>REPORT</code>
	/// .
	/// </remarks>
	[Sharpen.Sharpened]
	public class CodingErrorAction
	{
		/// <summary>Denotes the action to ignore any errors.</summary>
		/// <remarks>Denotes the action to ignore any errors.</remarks>
		public static readonly java.nio.charset.CodingErrorAction IGNORE = new java.nio.charset.CodingErrorAction
			("IGNORE");

		/// <summary>
		/// Denotes the action to fill in the output with a replacement character
		/// when malformed input or an unmappable character is encountered.
		/// </summary>
		/// <remarks>
		/// Denotes the action to fill in the output with a replacement character
		/// when malformed input or an unmappable character is encountered.
		/// </remarks>
		public static readonly java.nio.charset.CodingErrorAction REPLACE = new java.nio.charset.CodingErrorAction
			("REPLACE");

		/// <summary>
		/// Denotes the action to report the encountered error in an appropriate
		/// manner, for example to throw an exception or return an informative
		/// result.
		/// </summary>
		/// <remarks>
		/// Denotes the action to report the encountered error in an appropriate
		/// manner, for example to throw an exception or return an informative
		/// result.
		/// </remarks>
		public static readonly java.nio.charset.CodingErrorAction REPORT = new java.nio.charset.CodingErrorAction
			("REPORT");

		private string action;

		private CodingErrorAction(string action)
		{
			// The name of this action
			this.action = action;
		}

		/// <summary>Returns a text description of this action indication.</summary>
		/// <remarks>Returns a text description of this action indication.</remarks>
		/// <returns>a text description of this action indication.</returns>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "Action: " + this.action;
		}
	}
}
