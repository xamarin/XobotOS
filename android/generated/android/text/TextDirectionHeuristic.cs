using Sharpen;

namespace android.text
{
	/// <summary>Interface for objects that guess at the paragraph direction by examining text.
	/// 	</summary>
	/// <remarks>Interface for objects that guess at the paragraph direction by examining text.
	/// 	</remarks>
	/// <hide></hide>
	[Sharpen.Sharpened]
	public interface TextDirectionHeuristic
	{
		/// <hide></hide>
		bool isRtl(char[] text, int start, int count);
	}
}
