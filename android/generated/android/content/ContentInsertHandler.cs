using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public interface ContentInsertHandler : org.xml.sax.ContentHandler
	{
		[Sharpen.Stub]
		void insert(android.content.ContentResolver contentResolver, java.io.InputStream 
			@in);

		[Sharpen.Stub]
		void insert(android.content.ContentResolver contentResolver, string @in);
	}
}
