using Sharpen;

namespace android.content.res
{
	/// <summary>The XML parsing interface returned for an XML resource.</summary>
	/// <remarks>
	/// The XML parsing interface returned for an XML resource.  This is a standard
	/// XmlPullParser interface, as well as an extended AttributeSet interface and
	/// an additional close() method on this interface for the client to indicate
	/// when it is done reading the resource.
	/// </remarks>
	[Sharpen.Sharpened]
	public interface XmlResourceParser : org.xmlpull.v1.XmlPullParser, android.util.AttributeSet
	{
		/// <summary>
		/// Returns a short text describing the current parser state, including
		/// the position, a
		/// description of the current event and the data source if known.
		/// </summary>
		/// <remarks>
		/// Returns a short text describing the current parser state, including
		/// the position, a
		/// description of the current event and the data source if known.
		/// This method is especially useful to provide meaningful
		/// error messages and for debugging purposes.
		/// </remarks>
		string getPositionDescription();

		/// <summary>Close this interface to the resource.</summary>
		/// <remarks>
		/// Close this interface to the resource.  Calls on the interface are no
		/// longer value after this call.
		/// </remarks>
		void close();
	}
}
