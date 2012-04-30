using Sharpen;

namespace android.text
{
	[Sharpen.Stub]
	public class Html
	{
		[Sharpen.Stub]
		public interface ImageGetter
		{
			[Sharpen.Stub]
			android.graphics.drawable.Drawable getDrawable(string source);
		}

		[Sharpen.Stub]
		public interface TagHandler
		{
			[Sharpen.Stub]
			void handleTag(bool opening, string tag, android.text.Editable output, org.xml.sax.XMLReader
				 xmlReader);
		}

		[Sharpen.Stub]
		private Html()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.text.Spanned fromHtml(string source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class HtmlParser
		{
			internal static readonly org.ccil.cowan.tagsoup.HTMLSchema schema = new org.ccil.cowan.tagsoup.HTMLSchema
				();
		}

		[Sharpen.Stub]
		public static android.text.Spanned fromHtml(string source, android.text.Html.ImageGetter
			 imageGetter, android.text.Html.TagHandler tagHandler)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string toHtml(android.text.Spanned text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void withinHtml(java.lang.StringBuilder @out, android.text.Spanned
			 text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void withinDiv(java.lang.StringBuilder @out, android.text.Spanned 
			text, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void withinBlockquote(java.lang.StringBuilder @out, android.text.Spanned
			 text, int start, int end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void withinParagraph(java.lang.StringBuilder @out, android.text.Spanned
			 text, int start, int end, int nl, bool last)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void withinStyle(java.lang.StringBuilder @out, android.text.Spanned
			 text, int start, int end)
		{
			throw new System.NotImplementedException();
		}
	}

	[Sharpen.Stub]
	internal class HtmlToSpannedConverter : org.xml.sax.ContentHandler
	{
		private static readonly float[] HEADER_SIZES = new float[] { 1.5f, 1.4f, 1.3f, 1.2f
			, 1.1f, 1f };

		private string mSource;

		private org.xml.sax.XMLReader mReader;

		private android.text.SpannableStringBuilder mSpannableStringBuilder;

		private android.text.Html.ImageGetter mImageGetter;

		private android.text.Html.TagHandler mTagHandler;

		[Sharpen.Stub]
		public HtmlToSpannedConverter(string source, android.text.Html.ImageGetter imageGetter
			, android.text.Html.TagHandler tagHandler, org.ccil.cowan.tagsoup.Parser parser)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.text.Spanned convert()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleStartTag(string tag, org.xml.sax.Attributes attributes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleEndTag(string tag)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void handleP(android.text.SpannableStringBuilder text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void handleBr(android.text.SpannableStringBuilder text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static object getLast(android.text.Spanned text, System.Type kind)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void start(android.text.SpannableStringBuilder text, object mark)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void end(android.text.SpannableStringBuilder text, System.Type kind
			, object repl)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void startImg(android.text.SpannableStringBuilder text, org.xml.sax.Attributes
			 attributes, android.text.Html.ImageGetter img)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void startFont(android.text.SpannableStringBuilder text, org.xml.sax.Attributes
			 attributes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void endFont(android.text.SpannableStringBuilder text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void startA(android.text.SpannableStringBuilder text, org.xml.sax.Attributes
			 attributes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void endA(android.text.SpannableStringBuilder text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static void endHeader(android.text.SpannableStringBuilder text)
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
		public virtual void startDocument()
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
		public virtual void startPrefixMapping(string prefix, string uri)
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
		public virtual void startElement(string uri, string localName, string qName, org.xml.sax.Attributes
			 attributes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void endElement(string uri, string localName, string qName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void characters(char[] ch, int start_1, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"org.xml.sax.ContentHandler")]
		public virtual void ignorableWhitespace(char[] ch, int start_1, int length)
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
		public virtual void skippedEntity(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class Bold
		{
		}

		[Sharpen.Stub]
		private class Italic
		{
		}

		[Sharpen.Stub]
		private class Underline
		{
		}

		[Sharpen.Stub]
		private class Big
		{
		}

		[Sharpen.Stub]
		private class Small
		{
		}

		[Sharpen.Stub]
		private class Monospace
		{
		}

		[Sharpen.Stub]
		private class Blockquote
		{
		}

		[Sharpen.Stub]
		private class Super
		{
		}

		[Sharpen.Stub]
		private class Sub
		{
		}

		[Sharpen.Stub]
		private class Font
		{
			public string mColor;

			public string mFace;

			[Sharpen.Stub]
			public Font(string color, string face)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class Href
		{
			public string mHref;

			[Sharpen.Stub]
			public Href(string href)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		private class Header
		{
			internal int mLevel;

			[Sharpen.Stub]
			public Header(int level)
			{
				throw new System.NotImplementedException();
			}
		}

		private static java.util.HashMap<string, int> COLORS = buildColorMap();

		[Sharpen.Stub]
		private static java.util.HashMap<string, int> buildColorMap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static int getHtmlColor(string color)
		{
			throw new System.NotImplementedException();
		}
	}
}
