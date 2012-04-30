using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public class DefaultDataHandler : android.content.ContentInsertHandler
	{
		internal const string ROW = "row";

		internal const string COL = "col";

		internal const string URI_STR = "uri";

		internal const string POSTFIX = "postfix";

		internal const string DEL = "del";

		internal const string SELECT = "select";

		internal const string ARG = "arg";

		private java.util.Stack<System.Uri> mUris = new java.util.Stack<System.Uri>();

		private android.content.ContentValues mValues;

		private android.content.ContentResolver mContentResolver;

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ContentInsertHandler")]
		public virtual void insert(android.content.ContentResolver contentResolver, java.io.InputStream
			 @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.content.ContentInsertHandler")]
		public virtual void insert(android.content.ContentResolver contentResolver, string
			 @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void parseRow(org.xml.sax.Attributes atts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private System.Uri insertRow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void startElement(string uri, string localName, string name, org.xml.sax.Attributes
			 atts)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void endElement(string uri, string localName, string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void characters(char[] ch, int start, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void endDocument()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void endPrefixMapping(string prefix)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void ignorableWhitespace(char[] ch, int start, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void processingInstruction(string target, string data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void setDocumentLocator(org.xml.sax.Locator locator)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void skippedEntity(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void startDocument()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void startPrefixMapping(string prefix, string uri)
		{
			throw new System.NotImplementedException();
		}
	}
}
