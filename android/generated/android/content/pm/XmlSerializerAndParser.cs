using Sharpen;

namespace android.content.pm
{
	[Sharpen.Stub]
	public interface XmlSerializerAndParser<T>
	{
		[Sharpen.Stub]
		void writeAsXml(T item, org.xmlpull.v1.XmlSerializer @out);

		[Sharpen.Stub]
		T createFromXml(org.xmlpull.v1.XmlPullParser parser);
	}
}
