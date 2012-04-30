using Sharpen;

namespace android.text
{
	/// <summary>A special kind of Parcelable for objects that will serve as text spans.</summary>
	/// <remarks>
	/// A special kind of Parcelable for objects that will serve as text spans.
	/// This can only be used by code in the framework; it is not intended for
	/// applications to implement their own Parcelable spans.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface ParcelableSpan : android.os.Parcelable
	{
		/// <summary>Return a special type identifier for this span class.</summary>
		/// <remarks>Return a special type identifier for this span class.</remarks>
		int getSpanTypeId();
	}
}
