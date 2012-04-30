using Sharpen;

namespace android.text
{
	/// <summary>
	/// This interface should be added to a span object that should not be copied
	/// into a new Spenned when performing a slice or copy operation on the original
	/// Spanned it was placed in.
	/// </summary>
	/// <remarks>
	/// This interface should be added to a span object that should not be copied
	/// into a new Spenned when performing a slice or copy operation on the original
	/// Spanned it was placed in.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface NoCopySpan
	{
	}

	/// <summary>
	/// This interface should be added to a span object that should not be copied
	/// into a new Spenned when performing a slice or copy operation on the original
	/// Spanned it was placed in.
	/// </summary>
	/// <remarks>
	/// This interface should be added to a span object that should not be copied
	/// into a new Spenned when performing a slice or copy operation on the original
	/// Spanned it was placed in.
	/// </remarks>
	[Sharpen.Sharpened]
	public static class NoCopySpanClass
	{
		/// <summary>
		/// Convenience equivalent for when you would just want a new Object() for
		/// a span but want it to be no-copy.
		/// </summary>
		/// <remarks>
		/// Convenience equivalent for when you would just want a new Object() for
		/// a span but want it to be no-copy.  Use this instead.
		/// </remarks>
		public class Concrete : android.text.NoCopySpan
		{
		}
	}
}
