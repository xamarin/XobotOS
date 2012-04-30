using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	public partial class Xml
	{
		[Sharpen.Stub]
		public Xml()
		{
			throw new System.NotImplementedException();
		}

		public static string FEATURE_RELAXED = "http://xmlpull.org/v1/doc/features.html#relaxed";

		[Sharpen.Stub]
		public static void parse(string xml, org.xml.sax.ContentHandler contentHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void parse(java.io.Reader @in, org.xml.sax.ContentHandler contentHandler
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void parse(java.io.InputStream @in, android.util.Xml.Encoding encoding
			, org.xml.sax.ContentHandler contentHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static org.xmlpull.v1.XmlPullParser newPullParser()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static org.xmlpull.v1.XmlSerializer newSerializer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class XmlSerializerFactory
		{
			internal const string TYPE = "org.kxml2.io.KXmlParser,org.kxml2.io.KXmlSerializer";

			internal static readonly org.xmlpull.v1.XmlPullParserFactory instance;

			static XmlSerializerFactory()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public static android.util.Xml.Encoding findEncodingByName(string encodingName)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Return an AttributeSet interface for use with the given XmlPullParser.</summary>
		/// <remarks>
		/// Return an AttributeSet interface for use with the given XmlPullParser.
		/// If the given parser itself implements AttributeSet, that implementation
		/// is simply returned.  Otherwise a wrapper class is
		/// instantiated on top of the XmlPullParser, as a proxy for retrieving its
		/// attributes, and returned to you.
		/// </remarks>
		/// <param name="parser">
		/// The existing parser for which you would like an
		/// AttributeSet.
		/// </param>
		/// <returns>
		/// An AttributeSet you can use to retrieve the
		/// attribute values at each of the tags as the parser moves
		/// through its XML document.
		/// </returns>
		/// <seealso cref="AttributeSet">AttributeSet</seealso>
		public static android.util.AttributeSet asAttributeSet(org.xmlpull.v1.XmlPullParser
			 parser)
		{
			return (parser is android.util.AttributeSet) ? (android.util.AttributeSet)parser : 
				new android.util.XmlPullAttributes(parser);
		}
	}
}
