using Sharpen;

namespace org.xmlpull.v1
{
	/// <summary>
	/// XML Pull Parser is an interface that defines parsing functionality provided
	/// in <a href="http://www.xmlpull.org/">XMLPULL V1 API</a> (visit this website to
	/// learn more about API and its implementations).
	/// </summary>
	/// <remarks>
	/// XML Pull Parser is an interface that defines parsing functionality provided
	/// in <a href="http://www.xmlpull.org/">XMLPULL V1 API</a> (visit this website to
	/// learn more about API and its implementations).
	/// <p>There are following different
	/// kinds of parser depending on which features are set:<ul>
	/// <li><b>non-validating</b> parser as defined in XML 1.0 spec when
	/// FEATURE_PROCESS_DOCDECL is set to true
	/// <li><b>validating parser</b> as defined in XML 1.0 spec when
	/// FEATURE_VALIDATION is true (and that implies that FEATURE_PROCESS_DOCDECL is true)
	/// <li>when FEATURE_PROCESS_DOCDECL is false (this is default and
	/// if different value is required necessary must be changed before parsing is started)
	/// then parser behaves like XML 1.0 compliant non-validating parser under condition that
	/// <em>no DOCDECL is present</em> in XML documents
	/// (internal entites can still be defined with defineEntityReplacementText()).
	/// This mode of operation is intended <b>for operation in constrained environments</b> such as J2ME.
	/// </ul>
	/// <p>There are two key methods: next() and nextToken(). While next() provides
	/// access to high level parsing events, nextToken() allows access to lower
	/// level tokens.
	/// <p>The current event state of the parser
	/// can be determined by calling the
	/// <a href="#getEventType()">getEventType()</a> method.
	/// Initially, the parser is in the <a href="#START_DOCUMENT">START_DOCUMENT</a>
	/// state.
	/// <p>The method <a href="#next()">next()</a> advances the parser to the
	/// next event. The int value returned from next determines the current parser
	/// state and is identical to the value returned from following calls to
	/// getEventType ().
	/// <p>Th following event types are seen by next()<dl>
	/// <dt><a href="#START_TAG">START_TAG</a><dd> An XML start tag was read.
	/// <dt><a href="#TEXT">TEXT</a><dd> Text content was read;
	/// the text content can be retrieved using the getText() method.
	/// (when in validating mode next() will not report ignorable whitespace, use nextToken() instead)
	/// <dt><a href="#END_TAG">END_TAG</a><dd> An end tag was read
	/// <dt><a href="#END_DOCUMENT">END_DOCUMENT</a><dd> No more events are available
	/// </dl>
	/// <p>after first next() or nextToken() (or any other next*() method)
	/// is called user application can obtain
	/// XML version, standalone and encoding from XML declaration
	/// in following ways:<ul>
	/// <li><b>version</b>:
	/// getProperty(&quot;<a href="http://xmlpull.org/v1/doc/properties.html#xmldecl-version">http://xmlpull.org/v1/doc/properties.html#xmldecl-version</a>&quot;)
	/// returns String ("1.0") or null if XMLDecl was not read or if property is not supported
	/// <li><b>standalone</b>:
	/// getProperty(&quot;<a href="http://xmlpull.org/v1/doc/properties.html#xmldecl-standalone">http://xmlpull.org/v1/doc/properties.html#xmldecl-standalone</a>&quot;)
	/// returns Boolean: null if there was no standalone declaration
	/// or if property is not supported
	/// otherwise returns Boolean(true) if standalone="yes" and Boolean(false) when standalone="no"
	/// <li><b>encoding</b>: obtained from getInputEncoding()
	/// null if stream had unknown encoding (not set in setInputStream)
	/// and it was not declared in XMLDecl
	/// </ul>
	/// A minimal example for using this API may look as follows:
	/// <pre>
	/// import java.io.IOException;
	/// import java.io.StringReader;
	/// import org.xmlpull.v1.XmlPullParser;
	/// import org.xmlpull.v1.<a href="XmlPullParserException.html">XmlPullParserException</a>;
	/// import org.xmlpull.v1.<a href="XmlPullParserFactory.html">XmlPullParserFactory</a>;
	/// public class SimpleXmlPullApp
	/// {
	/// public static void main (String args[])
	/// throws XmlPullParserException, IOException
	/// {
	/// XmlPullParserFactory factory = XmlPullParserFactory.newInstance();
	/// factory.setNamespaceAware(true);
	/// XmlPullParser xpp = factory.newPullParser();
	/// xpp.<a href="#setInput">setInput</a>( new StringReader ( "&lt;foo&gt;Hello World!&lt;/foo&gt;" ) );
	/// int eventType = xpp.getEventType();
	/// while (eventType != XmlPullParser.END_DOCUMENT) {
	/// if(eventType == XmlPullParser.START_DOCUMENT) {
	/// System.out.println("Start document");
	/// } else if(eventType == XmlPullParser.START_TAG) {
	/// System.out.println("Start tag "+xpp.<a href="#getName()">getName()</a>);
	/// } else if(eventType == XmlPullParser.END_TAG) {
	/// System.out.println("End tag "+xpp.getName());
	/// } else if(eventType == XmlPullParser.TEXT) {
	/// System.out.println("Text "+xpp.<a href="#getText()">getText()</a>);
	/// }
	/// eventType = xpp.next();
	/// }
	/// System.out.println("End document");
	/// }
	/// }
	/// </pre>
	/// <p>The above example will generate the following output:
	/// <pre>
	/// Start document
	/// Start tag foo
	/// Text Hello World!
	/// End tag foo
	/// </pre>
	/// <p>For more details on API usage, please refer to the
	/// quick Introduction available at <a href="http://www.xmlpull.org">http://www.xmlpull.org</a>
	/// </remarks>
	/// <seealso cref="XmlPullParserFactory">XmlPullParserFactory</seealso>
	/// <seealso cref="defineEntityReplacementText(string, string)">defineEntityReplacementText(string, string)
	/// 	</seealso>
	/// <seealso cref="getName()">getName()</seealso>
	/// <seealso cref="getNamespace()">getNamespace()</seealso>
	/// <seealso cref="getText()">getText()</seealso>
	/// <seealso cref="next()">next()</seealso>
	/// <seealso cref="nextToken()">nextToken()</seealso>
	/// <seealso cref="setInput(java.io.Reader)">setInput(java.io.Reader)</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL">org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION">org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_TAG">org.xmlpull.v1.XmlPullParserClass.START_TAG
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.TEXT">org.xmlpull.v1.XmlPullParserClass.TEXT
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_TAG">org.xmlpull.v1.XmlPullParserClass.END_TAG
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
	/// 	</seealso>
	/// <author><a href="http://www-ai.cs.uni-dortmund.de/PERSONAL/haustein.html">Stefan Haustein</a>
	/// 	</author>
	/// <author><a href="http://www.extreme.indiana.edu/~aslom/">Aleksander Slominski</a>
	/// 	</author>
	[Sharpen.Sharpened]
	public interface XmlPullParser
	{
		// for license please see accompanying LICENSE.txt file (available also at http://www.xmlpull.org/)
		// ----------------------------------------------------------------------------
		// EVENT TYPES as reported by next()
		// ----------------------------------------------------------------------------
		// additional events exposed by lower level nextToken()
		// ----------------------------------------------------------------------------
		// namespace related features
		/// <summary>
		/// Use this call to change the general behaviour of the parser,
		/// such as namespace processing or doctype declaration handling.
		/// </summary>
		/// <remarks>
		/// Use this call to change the general behaviour of the parser,
		/// such as namespace processing or doctype declaration handling.
		/// This method must be called before the first call to next or
		/// nextToken. Otherwise, an exception is thrown.
		/// <p>Example: call setFeature(FEATURE_PROCESS_NAMESPACES, true) in order
		/// to switch on namespace processing. The initial settings correspond
		/// to the properties requested from the XML Pull Parser factory.
		/// If none were requested, all features are deactivated by default.
		/// </remarks>
		/// <exception>
		/// XmlPullParserException
		/// If the feature is not supported or can not be set
		/// </exception>
		/// <exception>
		/// IllegalArgumentException
		/// If string with the feature name is null
		/// </exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		void setFeature(string name, bool state);

		/// <summary>Returns the current value of the given feature.</summary>
		/// <remarks>
		/// Returns the current value of the given feature.
		/// <p><strong>Please note:</strong> unknown features are
		/// <strong>always</strong> returned as false.
		/// </remarks>
		/// <param name="name">The name of feature to be retrieved.</param>
		/// <returns>The value of the feature.</returns>
		/// <exception>
		/// IllegalArgumentException
		/// if string the feature name is null
		/// </exception>
		bool getFeature(string name);

		/// <summary>Set the value of a property.</summary>
		/// <remarks>
		/// Set the value of a property.
		/// The property name is any fully-qualified URI.
		/// </remarks>
		/// <exception>
		/// XmlPullParserException
		/// If the property is not supported or can not be set
		/// </exception>
		/// <exception>
		/// IllegalArgumentException
		/// If string with the property name is null
		/// </exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		void setProperty(string name, object value);

		/// <summary>Look up the value of a property.</summary>
		/// <remarks>
		/// Look up the value of a property.
		/// The property name is any fully-qualified URI.
		/// <p><strong>NOTE:</strong> unknown properties are <strong>always</strong>
		/// returned as null.
		/// </remarks>
		/// <param name="name">The name of property to be retrieved.</param>
		/// <returns>The value of named property.</returns>
		object getProperty(string name);

		/// <summary>
		/// Set the input source for parser to the given reader and
		/// resets the parser.
		/// </summary>
		/// <remarks>
		/// Set the input source for parser to the given reader and
		/// resets the parser. The event type is set to the initial value
		/// START_DOCUMENT.
		/// Setting the reader to null will just stop parsing and
		/// reset parser state,
		/// allowing the parser to free internal resources
		/// such as parsing buffers.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		void setInput(java.io.Reader @in);

		/// <summary>Sets the input stream the parser is going to process.</summary>
		/// <remarks>
		/// Sets the input stream the parser is going to process.
		/// This call resets the parser state and sets the event type
		/// to the initial value START_DOCUMENT.
		/// <p><strong>NOTE:</strong> If an input encoding string is passed,
		/// it MUST be used. Otherwise,
		/// if inputEncoding is null, the parser SHOULD try to determine
		/// input encoding following XML 1.0 specification (see below).
		/// If encoding detection is supported then following feature
		/// <a href="http://xmlpull.org/v1/doc/features.html#detect-encoding">http://xmlpull.org/v1/doc/features.html#detect-encoding</a>
		/// MUST be true amd otherwise it must be false
		/// </remarks>
		/// <param name="inputStream">
		/// contains a raw byte input stream of possibly
		/// unknown encoding (when inputEncoding is null).
		/// </param>
		/// <param name="inputEncoding">if not null it MUST be used as encoding for inputStream
		/// 	</param>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		void setInput(java.io.InputStream inputStream, string inputEncoding);

		/// <summary>Returns the input encoding if known, null otherwise.</summary>
		/// <remarks>
		/// Returns the input encoding if known, null otherwise.
		/// If setInput(InputStream, inputEncoding) was called with an inputEncoding
		/// value other than null, this value must be returned
		/// from this method. Otherwise, if inputEncoding is null and
		/// the parser supports the encoding detection feature
		/// (http://xmlpull.org/v1/doc/features.html#detect-encoding),
		/// it must return the detected encoding.
		/// If setInput(Reader) was called, null is returned.
		/// After first call to next if XML declaration was present this method
		/// will return encoding declared.
		/// </remarks>
		string getInputEncoding();

		/// <summary>
		/// Set new value for entity replacement text as defined in
		/// <a href="http://www.w3.org/TR/REC-xml#intern-replacement">XML 1.0 Section 4.5
		/// Construction of Internal Entity Replacement Text</a>.
		/// </summary>
		/// <remarks>
		/// Set new value for entity replacement text as defined in
		/// <a href="http://www.w3.org/TR/REC-xml#intern-replacement">XML 1.0 Section 4.5
		/// Construction of Internal Entity Replacement Text</a>.
		/// If FEATURE_PROCESS_DOCDECL or FEATURE_VALIDATION are set, calling this
		/// function will result in an exception -- when processing of DOCDECL is
		/// enabled, there is no need to the entity replacement text manually.
		/// <p>The motivation for this function is to allow very small
		/// implementations of XMLPULL that will work in J2ME environments.
		/// Though these implementations may not be able to process the document type
		/// declaration, they still can work with known DTDs by using this function.
		/// <p><b>Please notes:</b> The given value is used literally as replacement text
		/// and it corresponds to declaring entity in DTD that has all special characters
		/// escaped: left angle bracket is replaced with &amp;lt;, ampersand with &amp;amp;
		/// and so on.
		/// <p><b>Note:</b> The given value is the literal replacement text and must not
		/// contain any other entity reference (if it contains any entity reference
		/// there will be no further replacement).
		/// <p><b>Note:</b> The list of pre-defined entity names will
		/// always contain standard XML entities such as
		/// amp (&amp;amp;), lt (&amp;lt;), gt (&amp;gt;), quot (&amp;quot;), and apos (&amp;apos;).
		/// Those cannot be redefined by this method!
		/// </remarks>
		/// <seealso cref="setInput(java.io.Reader)">setInput(java.io.Reader)</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL">org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION">org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		void defineEntityReplacementText(string entityName, string replacementText);

		/// <summary>
		/// Returns the numbers of elements in the namespace stack for the given
		/// depth.
		/// </summary>
		/// <remarks>
		/// Returns the numbers of elements in the namespace stack for the given
		/// depth.
		/// If namespaces are not enabled, 0 is returned.
		/// <p><b>NOTE:</b> when parser is on END_TAG then it is allowed to call
		/// this function with getDepth()+1 argument to retrieve position of namespace
		/// prefixes and URIs that were declared on corresponding START_TAG.
		/// <p><b>NOTE:</b> to retrieve list of namespaces declared in current element:<pre>
		/// XmlPullParser pp = ...
		/// int nsStart = pp.getNamespaceCount(pp.getDepth()-1);
		/// int nsEnd = pp.getNamespaceCount(pp.getDepth());
		/// for (int i = nsStart; i &lt; nsEnd; i++) {
		/// String prefix = pp.getNamespacePrefix(i);
		/// String ns = pp.getNamespaceUri(i);
		/// // ...
		/// }
		/// </pre>
		/// </remarks>
		/// <seealso cref="getNamespacePrefix(int)">getNamespacePrefix(int)</seealso>
		/// <seealso cref="getNamespaceUri(int)">getNamespaceUri(int)</seealso>
		/// <seealso cref="getNamespace()">getNamespace()</seealso>
		/// <seealso cref="getNamespace(string)">getNamespace(string)</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		int getNamespaceCount(int depth);

		/// <summary>
		/// Returns the namespace prefix for the given position
		/// in the namespace stack.
		/// </summary>
		/// <remarks>
		/// Returns the namespace prefix for the given position
		/// in the namespace stack.
		/// Default namespace declaration (xmlns='...') will have null as prefix.
		/// If the given index is out of range, an exception is thrown.
		/// <p><b>Please note:</b> when the parser is on an END_TAG,
		/// namespace prefixes that were declared
		/// in the corresponding START_TAG are still accessible
		/// although they are no longer in scope.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		string getNamespacePrefix(int pos);

		/// <summary>
		/// Returns the namespace URI for the given position in the
		/// namespace stack
		/// If the position is out of range, an exception is thrown.
		/// </summary>
		/// <remarks>
		/// Returns the namespace URI for the given position in the
		/// namespace stack
		/// If the position is out of range, an exception is thrown.
		/// <p><b>NOTE:</b> when parser is on END_TAG then namespace prefixes that were declared
		/// in corresponding START_TAG are still accessible even though they are not in scope
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		string getNamespaceUri(int pos);

		/// <summary>
		/// Returns the URI corresponding to the given prefix,
		/// depending on current state of the parser.
		/// </summary>
		/// <remarks>
		/// Returns the URI corresponding to the given prefix,
		/// depending on current state of the parser.
		/// <p>If the prefix was not declared in the current scope,
		/// null is returned. The default namespace is included
		/// in the namespace table and is available via
		/// getNamespace (null).
		/// <p>This method is a convenience method for
		/// <pre>
		/// for (int i = getNamespaceCount(getDepth ())-1; i &gt;= 0; i--) {
		/// if (getNamespacePrefix(i).equals( prefix )) {
		/// return getNamespaceUri(i);
		/// }
		/// }
		/// return null;
		/// </pre>
		/// <p><strong>Please note:</strong> parser implementations
		/// may provide more efficient lookup, e.g. using a Hashtable.
		/// The 'xml' prefix is bound to "http://www.w3.org/XML/1998/namespace", as
		/// defined in the
		/// <a href="http://www.w3.org/TR/REC-xml-names/#ns-using">Namespaces in XML</a>
		/// specification. Analogous, the 'xmlns' prefix is resolved to
		/// <a href="http://www.w3.org/2000/xmlns/">http://www.w3.org/2000/xmlns/</a>
		/// </remarks>
		/// <seealso cref="getNamespaceCount(int)">getNamespaceCount(int)</seealso>
		/// <seealso cref="getNamespacePrefix(int)">getNamespacePrefix(int)</seealso>
		/// <seealso cref="getNamespaceUri(int)">getNamespaceUri(int)</seealso>
		string getNamespace(string prefix);

		// --------------------------------------------------------------------------
		// miscellaneous reporting methods
		/// <summary>Returns the current depth of the element.</summary>
		/// <remarks>
		/// Returns the current depth of the element.
		/// Outside the root element, the depth is 0. The
		/// depth is incremented by 1 when a start tag is reached.
		/// The depth is decremented AFTER the end tag
		/// event was observed.
		/// <pre>
		/// &lt;!-- outside --&gt;     0
		/// &lt;root&gt;                  1
		/// sometext                 1
		/// &lt;foobar&gt;         2
		/// &lt;/foobar&gt;        2
		/// &lt;/root&gt;              1
		/// &lt;!-- outside --&gt;     0
		/// </pre>
		/// </remarks>
		int getDepth();

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

		/// <summary>Returns the current line number, starting from 1.</summary>
		/// <remarks>
		/// Returns the current line number, starting from 1.
		/// When the parser does not know the current line number
		/// or can not determine it,  -1 is returned (e.g. for WBXML).
		/// </remarks>
		/// <returns>current line number or -1 if unknown.</returns>
		int getLineNumber();

		/// <summary>Returns the current column number, starting from 0.</summary>
		/// <remarks>
		/// Returns the current column number, starting from 0.
		/// When the parser does not know the current column number
		/// or can not determine it,  -1 is returned (e.g. for WBXML).
		/// </remarks>
		/// <returns>current column number or -1 if unknown.</returns>
		int getColumnNumber();

		// --------------------------------------------------------------------------
		// TEXT related methods
		/// <summary>
		/// Checks whether the current TEXT event contains only whitespace
		/// characters.
		/// </summary>
		/// <remarks>
		/// Checks whether the current TEXT event contains only whitespace
		/// characters.
		/// For IGNORABLE_WHITESPACE, this is always true.
		/// For TEXT and CDSECT, false is returned when the current event text
		/// contains at least one non-white space character. For any other
		/// event type an exception is thrown.
		/// <p><b>Please note:</b> non-validating parsers are not
		/// able to distinguish whitespace and ignorable whitespace,
		/// except from whitespace outside the root element. Ignorable
		/// whitespace is reported as separate event, which is exposed
		/// via nextToken only.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		bool isWhitespace();

		/// <summary>Returns the text content of the current event as String.</summary>
		/// <remarks>
		/// Returns the text content of the current event as String.
		/// The value returned depends on current event type,
		/// for example for TEXT event it is element content
		/// (this is typical case when next() is used).
		/// See description of nextToken() for detailed description of
		/// possible returned values for different types of events.
		/// <p><strong>NOTE:</strong> in case of ENTITY_REF, this method returns
		/// the entity replacement text (or null if not available). This is
		/// the only case where
		/// getText() and getTextCharacters() return different values.
		/// </remarks>
		/// <seealso cref="getEventType()">getEventType()</seealso>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		string getText();

		/// <summary>
		/// Returns the buffer that contains the text of the current event,
		/// as well as the start offset and length relevant for the current
		/// event.
		/// </summary>
		/// <remarks>
		/// Returns the buffer that contains the text of the current event,
		/// as well as the start offset and length relevant for the current
		/// event. See getText(), next() and nextToken() for description of possible returned values.
		/// <p><strong>Please note:</strong> this buffer must not
		/// be modified and its content MAY change after a call to
		/// next() or nextToken(). This method will always return the
		/// same value as getText(), except for ENTITY_REF. In the case
		/// of ENTITY ref, getText() returns the replacement text and
		/// this method returns the actual input buffer containing the
		/// entity name.
		/// If getText() returns null, this method returns null as well and
		/// the values returned in the holder array MUST be -1 (both start
		/// and length).
		/// </remarks>
		/// <seealso cref="getText()">getText()</seealso>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <param name="holderForStartAndLength">
		/// Must hold an 2-element int array
		/// into which the start offset and length values will be written.
		/// </param>
		/// <returns>
		/// char buffer that contains the text of the current event
		/// (null if the current event has no text associated).
		/// </returns>
		char[] getTextCharacters(int[] holderForStartAndLength);

		// --------------------------------------------------------------------------
		// START_TAG / END_TAG shared methods
		/// <summary>Returns the namespace URI of the current element.</summary>
		/// <remarks>
		/// Returns the namespace URI of the current element.
		/// The default namespace is represented
		/// as empty string.
		/// If namespaces are not enabled, an empty String ("") is always returned.
		/// The current event must be START_TAG or END_TAG; otherwise,
		/// null is returned.
		/// </remarks>
		string getNamespace();

		/// <summary>
		/// For START_TAG or END_TAG events, the (local) name of the current
		/// element is returned when namespaces are enabled.
		/// </summary>
		/// <remarks>
		/// For START_TAG or END_TAG events, the (local) name of the current
		/// element is returned when namespaces are enabled. When namespace
		/// processing is disabled, the raw name is returned.
		/// For ENTITY_REF events, the entity name is returned.
		/// If the current event is not START_TAG, END_TAG, or ENTITY_REF,
		/// null is returned.
		/// <p><b>Please note:</b> To reconstruct the raw element name
		/// when namespaces are enabled and the prefix is not null,
		/// you will need to  add the prefix and a colon to localName..
		/// </remarks>
		string getName();

		/// <summary>Returns the prefix of the current element.</summary>
		/// <remarks>
		/// Returns the prefix of the current element.
		/// If the element is in the default namespace (has no prefix),
		/// null is returned.
		/// If namespaces are not enabled, or the current event
		/// is not  START_TAG or END_TAG, null is returned.
		/// </remarks>
		string getPrefix();

		/// <summary>
		/// Returns true if the current event is START_TAG and the tag
		/// is degenerated
		/// (e.g.
		/// </summary>
		/// <remarks>
		/// Returns true if the current event is START_TAG and the tag
		/// is degenerated
		/// (e.g. &lt;foobar/&gt;).
		/// <p><b>NOTE:</b> if the parser is not on START_TAG, an exception
		/// will be thrown.
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		bool isEmptyElementTag();

		// --------------------------------------------------------------------------
		// START_TAG Attributes retrieval methods
		/// <summary>
		/// Returns the number of attributes of the current start tag, or
		/// -1 if the current event type is not START_TAG
		/// </summary>
		/// <seealso cref="getAttributeNamespace(int)">getAttributeNamespace(int)</seealso>
		/// <seealso cref="getAttributeName(int)">getAttributeName(int)</seealso>
		/// <seealso cref="getAttributePrefix(int)">getAttributePrefix(int)</seealso>
		/// <seealso cref="getAttributeValue(int)">getAttributeValue(int)</seealso>
		int getAttributeCount();

		/// <summary>
		/// Returns the namespace URI of the attribute
		/// with the given index (starts from 0).
		/// </summary>
		/// <remarks>
		/// Returns the namespace URI of the attribute
		/// with the given index (starts from 0).
		/// Returns an empty string ("") if namespaces are not enabled
		/// or the attribute has no namespace.
		/// Throws an IndexOutOfBoundsException if the index is out of range
		/// or the current event type is not START_TAG.
		/// <p><strong>NOTE:</strong> if FEATURE_REPORT_NAMESPACE_ATTRIBUTES is set
		/// then namespace attributes (xmlns:ns='...') must be reported
		/// with namespace
		/// <a href="http://www.w3.org/2000/xmlns/">http://www.w3.org/2000/xmlns/</a>
		/// (visit this URL for description!).
		/// The default namespace attribute (xmlns="...") will be reported with empty namespace.
		/// <p><strong>NOTE:</strong>The xml prefix is bound as defined in
		/// <a href="http://www.w3.org/TR/REC-xml-names/#ns-using">Namespaces in XML</a>
		/// specification to "http://www.w3.org/XML/1998/namespace".
		/// </remarks>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>
		/// attribute namespace,
		/// empty string ("") is returned  if namespaces processing is not enabled or
		/// namespaces processing is enabled but attribute has no namespace (it has no prefix).
		/// </returns>
		string getAttributeNamespace(int index);

		/// <summary>
		/// Returns the local name of the specified attribute
		/// if namespaces are enabled or just attribute name if namespaces are disabled.
		/// </summary>
		/// <remarks>
		/// Returns the local name of the specified attribute
		/// if namespaces are enabled or just attribute name if namespaces are disabled.
		/// Throws an IndexOutOfBoundsException if the index is out of range
		/// or current event type is not START_TAG.
		/// </remarks>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>attribute name (null is never returned)</returns>
		string getAttributeName(int index);

		/// <summary>
		/// Returns the prefix of the specified attribute
		/// Returns null if the element has no prefix.
		/// </summary>
		/// <remarks>
		/// Returns the prefix of the specified attribute
		/// Returns null if the element has no prefix.
		/// If namespaces are disabled it will always return null.
		/// Throws an IndexOutOfBoundsException if the index is out of range
		/// or current event type is not START_TAG.
		/// </remarks>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>attribute prefix or null if namespaces processing is not enabled.</returns>
		string getAttributePrefix(int index);

		/// <summary>
		/// Returns the type of the specified attribute
		/// If parser is non-validating it MUST return CDATA.
		/// </summary>
		/// <remarks>
		/// Returns the type of the specified attribute
		/// If parser is non-validating it MUST return CDATA.
		/// </remarks>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>attribute type (null is never returned)</returns>
		string getAttributeType(int index);

		/// <summary>Returns if the specified attribute was not in input was declared in XML.
		/// 	</summary>
		/// <remarks>
		/// Returns if the specified attribute was not in input was declared in XML.
		/// If parser is non-validating it MUST always return false.
		/// This information is part of XML infoset:
		/// </remarks>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>false if attribute was in input</returns>
		bool isAttributeDefault(int index);

		/// <summary>Returns the given attributes value.</summary>
		/// <remarks>
		/// Returns the given attributes value.
		/// Throws an IndexOutOfBoundsException if the index is out of range
		/// or current event type is not START_TAG.
		/// <p><strong>NOTE:</strong> attribute value must be normalized
		/// (including entity replacement text if PROCESS_DOCDECL is false) as described in
		/// <a href="http://www.w3.org/TR/REC-xml#AVNormalize">XML 1.0 section
		/// 3.3.3 Attribute-Value Normalization</a>
		/// </remarks>
		/// <seealso cref="defineEntityReplacementText(string, string)">defineEntityReplacementText(string, string)
		/// 	</seealso>
		/// <param name="index">zero-based index of attribute</param>
		/// <returns>value of attribute (null is never returned)</returns>
		string getAttributeValue(int index);

		/// <summary>Returns the attributes value identified by namespace URI and namespace localName.
		/// 	</summary>
		/// <remarks>
		/// Returns the attributes value identified by namespace URI and namespace localName.
		/// If namespaces are disabled namespace must be null.
		/// If current event type is not START_TAG then IndexOutOfBoundsException will be thrown.
		/// <p><strong>NOTE:</strong> attribute value must be normalized
		/// (including entity replacement text if PROCESS_DOCDECL is false) as described in
		/// <a href="http://www.w3.org/TR/REC-xml#AVNormalize">XML 1.0 section
		/// 3.3.3 Attribute-Value Normalization</a>
		/// </remarks>
		/// <seealso cref="defineEntityReplacementText(string, string)">defineEntityReplacementText(string, string)
		/// 	</seealso>
		/// <param name="namespace">Namespace of the attribute if namespaces are enabled otherwise must be null
		/// 	</param>
		/// <param name="name">If namespaces enabled local name of attribute otherwise just attribute name
		/// 	</param>
		/// <returns>value of attribute or null if attribute with given name does not exist</returns>
		string getAttributeValue(string @namespace, string name);

		// --------------------------------------------------------------------------
		// actual parsing methods
		/// <summary>Returns the type of the current event (START_TAG, END_TAG, TEXT, etc.)</summary>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		int getEventType();

		/// <summary>
		/// Get next parsing event - element content wil be coalesced and only one
		/// TEXT event must be returned for whole element content
		/// (comments and processing instructions will be ignored and entity references
		/// must be expanded or exception mus be thrown if entity reference can not be expanded).
		/// </summary>
		/// <remarks>
		/// Get next parsing event - element content wil be coalesced and only one
		/// TEXT event must be returned for whole element content
		/// (comments and processing instructions will be ignored and entity references
		/// must be expanded or exception mus be thrown if entity reference can not be expanded).
		/// If element content is empty (content is "") then no TEXT event will be reported.
		/// <p><b>NOTE:</b> empty element (such as &lt;tag/&gt;) will be reported
		/// with  two separate events: START_TAG, END_TAG - it must be so to preserve
		/// parsing equivalency of empty element to &lt;tag&gt;&lt;/tag&gt;.
		/// (see isEmptyElementTag ())
		/// </remarks>
		/// <seealso cref="isEmptyElementTag()">isEmptyElementTag()</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_TAG">org.xmlpull.v1.XmlPullParserClass.START_TAG
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.TEXT">org.xmlpull.v1.XmlPullParserClass.TEXT
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_TAG">org.xmlpull.v1.XmlPullParserClass.END_TAG
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		int next();

		/// <summary>
		/// This method works similarly to next() but will expose
		/// additional event types (COMMENT, CDSECT, DOCDECL, ENTITY_REF, PROCESSING_INSTRUCTION, or
		/// IGNORABLE_WHITESPACE) if they are available in input.
		/// </summary>
		/// <remarks>
		/// This method works similarly to next() but will expose
		/// additional event types (COMMENT, CDSECT, DOCDECL, ENTITY_REF, PROCESSING_INSTRUCTION, or
		/// IGNORABLE_WHITESPACE) if they are available in input.
		/// <p>If special feature
		/// <a href="http://xmlpull.org/v1/doc/features.html#xml-roundtrip">FEATURE_XML_ROUNDTRIP</a>
		/// (identified by URI: http://xmlpull.org/v1/doc/features.html#xml-roundtrip)
		/// is enabled it is possible to do XML document round trip ie. reproduce
		/// exectly on output the XML input using getText():
		/// returned content is always unnormalized (exactly as in input).
		/// Otherwise returned content is end-of-line normalized as described
		/// <a href="http://www.w3.org/TR/REC-xml#sec-line-ends">XML 1.0 End-of-Line Handling</a>
		/// and. Also when this feature is enabled exact content of START_TAG, END_TAG,
		/// DOCDECL and PROCESSING_INSTRUCTION is available.
		/// <p>Here is the list of tokens that can be  returned from nextToken()
		/// and what getText() and getTextCharacters() returns:<dl>
		/// <dt>START_DOCUMENT<dd>null
		/// <dt>END_DOCUMENT<dd>null
		/// <dt>START_TAG<dd>null unless FEATURE_XML_ROUNDTRIP
		/// enabled and then returns XML tag, ex: &lt;tag attr='val'&gt;
		/// <dt>END_TAG<dd>null unless FEATURE_XML_ROUNDTRIP
		/// id enabled and then returns XML tag, ex: &lt;/tag&gt;
		/// <dt>TEXT<dd>return element content.
		/// <br />Note: that element content may be delivered in multiple consecutive TEXT events.
		/// <dt>IGNORABLE_WHITESPACE<dd>return characters that are determined to be ignorable white
		/// space. If the FEATURE_XML_ROUNDTRIP is enabled all whitespace content outside root
		/// element will always reported as IGNORABLE_WHITESPACE otherwise reporting is optional.
		/// <br />Note: that element content may be delivered in multiple consecutive IGNORABLE_WHITESPACE events.
		/// <dt>CDSECT<dd>
		/// return text <em>inside</em> CDATA
		/// (ex. 'fo&lt;o' from &lt;!CDATA[fo&lt;o]]&gt;)
		/// <dt>PROCESSING_INSTRUCTION<dd>
		/// if FEATURE_XML_ROUNDTRIP is true
		/// return exact PI content ex: 'pi foo' from &lt;?pi foo?&gt;
		/// otherwise it may be exact PI content or concatenation of PI target,
		/// space and data so for example for
		/// &lt;?target    data?&gt; string &quot;target data&quot; may
		/// be returned if FEATURE_XML_ROUNDTRIP is false.
		/// <dt>COMMENT<dd>return comment content ex. 'foo bar' from &lt;!--foo bar--&gt;
		/// <dt>ENTITY_REF<dd>getText() MUST return entity replacement text if PROCESS_DOCDECL is false
		/// otherwise getText() MAY return null,
		/// additionally getTextCharacters() MUST return entity name
		/// (for example 'entity_name' for &amp;entity_name;).
		/// <br /><b>NOTE:</b> this is the only place where value returned from getText() and
		/// getTextCharacters() <b>are different</b>
		/// <br /><b>NOTE:</b> it is user responsibility to resolve entity reference
		/// if PROCESS_DOCDECL is false and there is no entity replacement text set in
		/// defineEntityReplacementText() method (getText() will be null)
		/// <br /><b>NOTE:</b> character entities (ex. &amp;#32;) and standard entities such as
		/// &amp;amp; &amp;lt; &amp;gt; &amp;quot; &amp;apos; are reported as well
		/// and are <b>not</b> reported as TEXT tokens but as ENTITY_REF tokens!
		/// This requirement is added to allow to do roundtrip of XML documents!
		/// <dt>DOCDECL<dd>
		/// if FEATURE_XML_ROUNDTRIP is true or PROCESS_DOCDECL is false
		/// then return what is inside of DOCDECL for example it returns:<pre>
		/// &quot; titlepage SYSTEM "http://www.foo.bar/dtds/typo.dtd"
		/// [&lt;!ENTITY % active.links "INCLUDE"&gt;]&quot;</pre>
		/// <p>for input document that contained:<pre>
		/// &lt;!DOCTYPE titlepage SYSTEM "http://www.foo.bar/dtds/typo.dtd"
		/// [&lt;!ENTITY % active.links "INCLUDE"&gt;]&gt;</pre>
		/// otherwise if FEATURE_XML_ROUNDTRIP is false and PROCESS_DOCDECL is true
		/// then what is returned is undefined (it may be even null)
		/// </dd>
		/// </dl>
		/// <p><strong>NOTE:</strong> there is no guarantee that there will only one TEXT or
		/// IGNORABLE_WHITESPACE event from nextToken() as parser may chose to deliver element content in
		/// multiple tokens (dividing element content into chunks)
		/// <p><strong>NOTE:</strong> whether returned text of token is end-of-line normalized
		/// is depending on FEATURE_XML_ROUNDTRIP.
		/// <p><strong>NOTE:</strong> XMLDecl (&lt;?xml ...?&gt;) is not reported but its content
		/// is available through optional properties (see class description above).
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_TAG">org.xmlpull.v1.XmlPullParserClass.START_TAG
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.TEXT">org.xmlpull.v1.XmlPullParserClass.TEXT
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_TAG">org.xmlpull.v1.XmlPullParserClass.END_TAG
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.COMMENT">org.xmlpull.v1.XmlPullParserClass.COMMENT
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.DOCDECL">org.xmlpull.v1.XmlPullParserClass.DOCDECL
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.PROCESSING_INSTRUCTION">org.xmlpull.v1.XmlPullParserClass.PROCESSING_INSTRUCTION
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.ENTITY_REF">org.xmlpull.v1.XmlPullParserClass.ENTITY_REF
		/// 	</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.IGNORABLE_WHITESPACE">org.xmlpull.v1.XmlPullParserClass.IGNORABLE_WHITESPACE
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		int nextToken();

		//-----------------------------------------------------------------------------
		// utility methods to mak XML parsing easier ...
		/// <summary>
		/// Test if the current event is of the given type and if the
		/// namespace and name do match.
		/// </summary>
		/// <remarks>
		/// Test if the current event is of the given type and if the
		/// namespace and name do match. null will match any namespace
		/// and any name. If the test is not passed, an exception is
		/// thrown. The exception text indicates the parser position,
		/// the expected event and the current event that is not meeting the
		/// requirement.
		/// <p>Essentially it does this
		/// <pre>
		/// if (type != getEventType()
		/// || (namespace != null &amp;&amp;  !namespace.equals( getNamespace () ) )
		/// || (name != null &amp;&amp;  !name.equals( getName() ) ) )
		/// throw new XmlPullParserException( "expected "+ TYPES[ type ]+getPositionDescription());
		/// </pre>
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		void require(int type, string @namespace, string name);

		/// <summary>
		/// If current event is START_TAG then if next element is TEXT then element content is returned
		/// or if next event is END_TAG then empty string is returned, otherwise exception is thrown.
		/// </summary>
		/// <remarks>
		/// If current event is START_TAG then if next element is TEXT then element content is returned
		/// or if next event is END_TAG then empty string is returned, otherwise exception is thrown.
		/// After calling this function successfully parser will be positioned on END_TAG.
		/// <p>The motivation for this function is to allow to parse consistently both
		/// empty elements and elements that has non empty content, for example for input: <ol>
		/// <li>&lt;tag&gt;foo&lt;/tag&gt;
		/// <li>&lt;tag&gt;&lt;/tag&gt; (which is equivalent to &lt;tag/&gt;
		/// both input can be parsed with the same code:
		/// <pre>
		/// p.nextTag()
		/// p.requireEvent(p.START_TAG, "", "tag");
		/// String content = p.nextText();
		/// p.requireEvent(p.END_TAG, "", "tag");
		/// </pre>
		/// This function together with nextTag make it very easy to parse XML that has
		/// no mixed content.
		/// <p>Essentially it does this
		/// <pre>
		/// if(getEventType() != START_TAG) {
		/// throw new XmlPullParserException(
		/// "parser must be on START_TAG to read next text", this, null);
		/// }
		/// int eventType = next();
		/// if(eventType == TEXT) {
		/// String result = getText();
		/// eventType = next();
		/// if(eventType != END_TAG) {
		/// throw new XmlPullParserException(
		/// "event TEXT it must be immediately followed by END_TAG", this, null);
		/// }
		/// return result;
		/// } else if(eventType == END_TAG) {
		/// return "";
		/// } else {
		/// throw new XmlPullParserException(
		/// "parser must be on START_TAG or TEXT to read text", this, null);
		/// }
		/// </pre>
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		string nextText();

		/// <summary>
		/// Call next() and return event if it is START_TAG or END_TAG
		/// otherwise throw an exception.
		/// </summary>
		/// <remarks>
		/// Call next() and return event if it is START_TAG or END_TAG
		/// otherwise throw an exception.
		/// It will skip whitespace TEXT before actual tag if any.
		/// <p>essentially it does this
		/// <pre>
		/// int eventType = next();
		/// if(eventType == TEXT &amp;&amp;  isWhitespace()) {   // skip whitespace
		/// eventType = next();
		/// }
		/// if (eventType != START_TAG &amp;&amp;  eventType != END_TAG) {
		/// throw new XmlPullParserException("expected start or end tag", this, null);
		/// }
		/// return eventType;
		/// </pre>
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		int nextTag();
	}

	/// <summary>
	/// XML Pull Parser is an interface that defines parsing functionality provided
	/// in <a href="http://www.xmlpull.org/">XMLPULL V1 API</a> (visit this website to
	/// learn more about API and its implementations).
	/// </summary>
	/// <remarks>
	/// XML Pull Parser is an interface that defines parsing functionality provided
	/// in <a href="http://www.xmlpull.org/">XMLPULL V1 API</a> (visit this website to
	/// learn more about API and its implementations).
	/// <p>There are following different
	/// kinds of parser depending on which features are set:<ul>
	/// <li><b>non-validating</b> parser as defined in XML 1.0 spec when
	/// FEATURE_PROCESS_DOCDECL is set to true
	/// <li><b>validating parser</b> as defined in XML 1.0 spec when
	/// FEATURE_VALIDATION is true (and that implies that FEATURE_PROCESS_DOCDECL is true)
	/// <li>when FEATURE_PROCESS_DOCDECL is false (this is default and
	/// if different value is required necessary must be changed before parsing is started)
	/// then parser behaves like XML 1.0 compliant non-validating parser under condition that
	/// <em>no DOCDECL is present</em> in XML documents
	/// (internal entites can still be defined with defineEntityReplacementText()).
	/// This mode of operation is intended <b>for operation in constrained environments</b> such as J2ME.
	/// </ul>
	/// <p>There are two key methods: next() and nextToken(). While next() provides
	/// access to high level parsing events, nextToken() allows access to lower
	/// level tokens.
	/// <p>The current event state of the parser
	/// can be determined by calling the
	/// <a href="#getEventType()">getEventType()</a> method.
	/// Initially, the parser is in the <a href="#START_DOCUMENT">START_DOCUMENT</a>
	/// state.
	/// <p>The method <a href="#next()">next()</a> advances the parser to the
	/// next event. The int value returned from next determines the current parser
	/// state and is identical to the value returned from following calls to
	/// getEventType ().
	/// <p>Th following event types are seen by next()<dl>
	/// <dt><a href="#START_TAG">START_TAG</a><dd> An XML start tag was read.
	/// <dt><a href="#TEXT">TEXT</a><dd> Text content was read;
	/// the text content can be retrieved using the getText() method.
	/// (when in validating mode next() will not report ignorable whitespace, use nextToken() instead)
	/// <dt><a href="#END_TAG">END_TAG</a><dd> An end tag was read
	/// <dt><a href="#END_DOCUMENT">END_DOCUMENT</a><dd> No more events are available
	/// </dl>
	/// <p>after first next() or nextToken() (or any other next*() method)
	/// is called user application can obtain
	/// XML version, standalone and encoding from XML declaration
	/// in following ways:<ul>
	/// <li><b>version</b>:
	/// getProperty(&quot;<a href="http://xmlpull.org/v1/doc/properties.html#xmldecl-version">http://xmlpull.org/v1/doc/properties.html#xmldecl-version</a>&quot;)
	/// returns String ("1.0") or null if XMLDecl was not read or if property is not supported
	/// <li><b>standalone</b>:
	/// getProperty(&quot;<a href="http://xmlpull.org/v1/doc/properties.html#xmldecl-standalone">http://xmlpull.org/v1/doc/properties.html#xmldecl-standalone</a>&quot;)
	/// returns Boolean: null if there was no standalone declaration
	/// or if property is not supported
	/// otherwise returns Boolean(true) if standalone="yes" and Boolean(false) when standalone="no"
	/// <li><b>encoding</b>: obtained from getInputEncoding()
	/// null if stream had unknown encoding (not set in setInputStream)
	/// and it was not declared in XMLDecl
	/// </ul>
	/// A minimal example for using this API may look as follows:
	/// <pre>
	/// import java.io.IOException;
	/// import java.io.StringReader;
	/// import org.xmlpull.v1.XmlPullParser;
	/// import org.xmlpull.v1.<a href="XmlPullParserException.html">XmlPullParserException</a>;
	/// import org.xmlpull.v1.<a href="XmlPullParserFactory.html">XmlPullParserFactory</a>;
	/// public class SimpleXmlPullApp
	/// {
	/// public static void main (String args[])
	/// throws XmlPullParserException, IOException
	/// {
	/// XmlPullParserFactory factory = XmlPullParserFactory.newInstance();
	/// factory.setNamespaceAware(true);
	/// XmlPullParser xpp = factory.newPullParser();
	/// xpp.<a href="#setInput">setInput</a>( new StringReader ( "&lt;foo&gt;Hello World!&lt;/foo&gt;" ) );
	/// int eventType = xpp.getEventType();
	/// while (eventType != XmlPullParser.END_DOCUMENT) {
	/// if(eventType == XmlPullParser.START_DOCUMENT) {
	/// System.out.println("Start document");
	/// } else if(eventType == XmlPullParser.START_TAG) {
	/// System.out.println("Start tag "+xpp.<a href="#getName()">getName()</a>);
	/// } else if(eventType == XmlPullParser.END_TAG) {
	/// System.out.println("End tag "+xpp.getName());
	/// } else if(eventType == XmlPullParser.TEXT) {
	/// System.out.println("Text "+xpp.<a href="#getText()">getText()</a>);
	/// }
	/// eventType = xpp.next();
	/// }
	/// System.out.println("End document");
	/// }
	/// }
	/// </pre>
	/// <p>The above example will generate the following output:
	/// <pre>
	/// Start document
	/// Start tag foo
	/// Text Hello World!
	/// End tag foo
	/// </pre>
	/// <p>For more details on API usage, please refer to the
	/// quick Introduction available at <a href="http://www.xmlpull.org">http://www.xmlpull.org</a>
	/// </remarks>
	/// <seealso cref="XmlPullParserFactory">XmlPullParserFactory</seealso>
	/// <seealso cref="defineEntityReplacementText(string, string)">defineEntityReplacementText(string, string)
	/// 	</seealso>
	/// <seealso cref="getName()">getName()</seealso>
	/// <seealso cref="getNamespace()">getNamespace()</seealso>
	/// <seealso cref="getText()">getText()</seealso>
	/// <seealso cref="next()">next()</seealso>
	/// <seealso cref="nextToken()">nextToken()</seealso>
	/// <seealso cref="setInput(java.io.Reader)">setInput(java.io.Reader)</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL">org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_DOCDECL
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION">org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.START_TAG">org.xmlpull.v1.XmlPullParserClass.START_TAG
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.TEXT">org.xmlpull.v1.XmlPullParserClass.TEXT
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_TAG">org.xmlpull.v1.XmlPullParserClass.END_TAG
	/// 	</seealso>
	/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT">org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
	/// 	</seealso>
	/// <author><a href="http://www-ai.cs.uni-dortmund.de/PERSONAL/haustein.html">Stefan Haustein</a>
	/// 	</author>
	/// <author><a href="http://www.extreme.indiana.edu/~aslom/">Aleksander Slominski</a>
	/// 	</author>
	[Sharpen.Sharpened]
	public static class XmlPullParserClass
	{
		/// <summary>This constant represents the default namespace (empty string "")</summary>
		public static readonly string NO_NAMESPACE = string.Empty;

		/// <summary>
		/// Signalize that parser is at the very beginning of the document
		/// and nothing was read yet.
		/// </summary>
		/// <remarks>
		/// Signalize that parser is at the very beginning of the document
		/// and nothing was read yet.
		/// This event type can only be observed by calling getEvent()
		/// before the first call to next(), nextToken, or nextTag()</a>).
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		public const int START_DOCUMENT = 0;

		/// <summary>Logical end of the xml document.</summary>
		/// <remarks>
		/// Logical end of the xml document. Returned from getEventType, next()
		/// and nextToken()
		/// when the end of the input document has been reached.
		/// <p><strong>NOTE:</strong> calling again
		/// <a href="#next()">next()</a> or <a href="#nextToken()">nextToken()</a>
		/// will result in exception being thrown.
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		public const int END_DOCUMENT = 1;

		/// <summary>
		/// Returned from getEventType(),
		/// <a href="#next()">next()</a>, <a href="#nextToken()">nextToken()</a> when
		/// a start tag was read.
		/// </summary>
		/// <remarks>
		/// Returned from getEventType(),
		/// <a href="#next()">next()</a>, <a href="#nextToken()">nextToken()</a> when
		/// a start tag was read.
		/// The name of start tag is available from getName(), its namespace and prefix are
		/// available from getNamespace() and getPrefix()
		/// if <a href='#FEATURE_PROCESS_NAMESPACES'>namespaces are enabled</a>.
		/// See getAttribute* methods to retrieve element attributes.
		/// See getNamespace* methods to retrieve newly declared namespaces.
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getName()">getName()</seealso>
		/// <seealso cref="getPrefix()">getPrefix()</seealso>
		/// <seealso cref="getNamespace()">getNamespace()</seealso>
		/// <seealso cref="getAttributeCount()">getAttributeCount()</seealso>
		/// <seealso cref="getDepth()">getDepth()</seealso>
		/// <seealso cref="getNamespaceCount(int)">getNamespaceCount(int)</seealso>
		/// <seealso cref="getNamespace()">getNamespace()</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES">org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES
		/// 	</seealso>
		public const int START_TAG = 2;

		/// <summary>
		/// Returned from getEventType(), <a href="#next()">next()</a>, or
		/// <a href="#nextToken()">nextToken()</a> when an end tag was read.
		/// </summary>
		/// <remarks>
		/// Returned from getEventType(), <a href="#next()">next()</a>, or
		/// <a href="#nextToken()">nextToken()</a> when an end tag was read.
		/// The name of start tag is available from getName(), its
		/// namespace and prefix are
		/// available from getNamespace() and getPrefix().
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getName()">getName()</seealso>
		/// <seealso cref="getPrefix()">getPrefix()</seealso>
		/// <seealso cref="getNamespace()">getNamespace()</seealso>
		/// <seealso cref="org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES">org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES
		/// 	</seealso>
		public const int END_TAG = 3;

		/// <summary>Character data was read and will is available by calling getText().</summary>
		/// <remarks>
		/// Character data was read and will is available by calling getText().
		/// <p><strong>Please note:</strong> <a href="#next()">next()</a> will
		/// accumulate multiple
		/// events into one TEXT event, skipping IGNORABLE_WHITESPACE,
		/// PROCESSING_INSTRUCTION and COMMENT events,
		/// In contrast, <a href="#nextToken()">nextToken()</a> will stop reading
		/// text when any other event is observed.
		/// Also, when the state was reached by calling next(), the text value will
		/// be normalized, whereas getText() will
		/// return unnormalized content in the case of nextToken(). This allows
		/// an exact roundtrip without changing line ends when examining low
		/// level events, whereas for high level applications the text is
		/// normalized appropriately.
		/// </remarks>
		/// <seealso cref="next()">next()</seealso>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int TEXT = 4;

		/// <summary>
		/// A CDATA sections was just read;
		/// this token is available only from calls to <a href="#nextToken()">nextToken()</a>.
		/// </summary>
		/// <remarks>
		/// A CDATA sections was just read;
		/// this token is available only from calls to <a href="#nextToken()">nextToken()</a>.
		/// A call to next() will accumulate various text events into a single event
		/// of type TEXT. The text contained in the CDATA section is available
		/// by calling getText().
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int CDSECT = 5;

		/// <summary>
		/// An entity reference was just read;
		/// this token is available from <a href="#nextToken()">nextToken()</a>
		/// only.
		/// </summary>
		/// <remarks>
		/// An entity reference was just read;
		/// this token is available from <a href="#nextToken()">nextToken()</a>
		/// only. The entity name is available by calling getName(). If available,
		/// the replacement text can be obtained by calling getText(); otherwise,
		/// the user is responsible for resolving the entity reference.
		/// This event type is never returned from next(); next() will
		/// accumulate the replacement text and other text
		/// events to a single TEXT event.
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int ENTITY_REF = 6;

		/// <summary>Ignorable whitespace was just read.</summary>
		/// <remarks>
		/// Ignorable whitespace was just read.
		/// This token is available only from <a href="#nextToken()">nextToken()</a>).
		/// For non-validating
		/// parsers, this event is only reported by nextToken() when outside
		/// the root element.
		/// Validating parsers may be able to detect ignorable whitespace at
		/// other locations.
		/// The ignorable whitespace string is available by calling getText()
		/// <p><strong>NOTE:</strong> this is different from calling the
		/// isWhitespace() method, since text content
		/// may be whitespace but not ignorable.
		/// Ignorable whitespace is skipped by next() automatically; this event
		/// type is never returned from next().
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int IGNORABLE_WHITESPACE = 7;

		/// <summary>An XML processing instruction declaration was just read.</summary>
		/// <remarks>
		/// An XML processing instruction declaration was just read. This
		/// event type is available only via <a href="#nextToken()">nextToken()</a>.
		/// getText() will return text that is inside the processing instruction.
		/// Calls to next() will skip processing instructions automatically.
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int PROCESSING_INSTRUCTION = 8;

		/// <summary>An XML comment was just read.</summary>
		/// <remarks>
		/// An XML comment was just read. This event type is this token is
		/// available via <a href="#nextToken()">nextToken()</a> only;
		/// calls to next() will skip comments automatically.
		/// The content of the comment can be accessed using the getText()
		/// method.
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int COMMENT = 9;

		/// <summary>An XML document type declaration was just read.</summary>
		/// <remarks>
		/// An XML document type declaration was just read. This token is
		/// available from <a href="#nextToken()">nextToken()</a> only.
		/// The unparsed text inside the doctype is available via
		/// the getText() method.
		/// </remarks>
		/// <seealso cref="nextToken()">nextToken()</seealso>
		/// <seealso cref="getText()">getText()</seealso>
		public const int DOCDECL = 10;

		/// <summary>
		/// This array can be used to convert the event type integer constants
		/// such as START_TAG or TEXT to
		/// to a string.
		/// </summary>
		/// <remarks>
		/// This array can be used to convert the event type integer constants
		/// such as START_TAG or TEXT to
		/// to a string. For example, the value of TYPES[START_TAG] is
		/// the string "START_TAG".
		/// This array is intended for diagnostic output only. Relying
		/// on the contents of the array may be dangerous since malicious
		/// applications may alter the array, although it is final, due
		/// to limitations of the Java language.
		/// </remarks>
		public static readonly string[] TYPES = new string[] { "START_DOCUMENT", "END_DOCUMENT"
			, "START_TAG", "END_TAG", "TEXT", "CDSECT", "ENTITY_REF", "IGNORABLE_WHITESPACE"
			, "PROCESSING_INSTRUCTION", "COMMENT", "DOCDECL" };

		/// <summary>
		/// This feature determines whether the parser processes
		/// namespaces.
		/// </summary>
		/// <remarks>
		/// This feature determines whether the parser processes
		/// namespaces. As for all features, the default value is false.
		/// <p><strong>NOTE:</strong> The value can not be changed during
		/// parsing an must be set before parsing.
		/// </remarks>
		/// <seealso cref="getFeature(string)">getFeature(string)</seealso>
		/// <seealso cref="setFeature(string, bool)">setFeature(string, bool)</seealso>
		public const string FEATURE_PROCESS_NAMESPACES = "http://xmlpull.org/v1/doc/features.html#process-namespaces";

		/// <summary>
		/// This feature determines whether namespace attributes are
		/// exposed via the attribute access methods.
		/// </summary>
		/// <remarks>
		/// This feature determines whether namespace attributes are
		/// exposed via the attribute access methods. Like all features,
		/// the default value is false. This feature cannot be changed
		/// during parsing.
		/// </remarks>
		/// <seealso cref="getFeature(string)">getFeature(string)</seealso>
		/// <seealso cref="setFeature(string, bool)">setFeature(string, bool)</seealso>
		public const string FEATURE_REPORT_NAMESPACE_ATTRIBUTES = "http://xmlpull.org/v1/doc/features.html#report-namespace-prefixes";

		/// <summary>
		/// This feature determines whether the document declaration
		/// is processed.
		/// </summary>
		/// <remarks>
		/// This feature determines whether the document declaration
		/// is processed. If set to false,
		/// the DOCDECL event type is reported by nextToken()
		/// and ignored by next().
		/// If this feature is activated, then the document declaration
		/// must be processed by the parser.
		/// <p><strong>Please note:</strong> If the document type declaration
		/// was ignored, entity references may cause exceptions
		/// later in the parsing process.
		/// The default value of this feature is false. It cannot be changed
		/// during parsing.
		/// </remarks>
		/// <seealso cref="getFeature(string)">getFeature(string)</seealso>
		/// <seealso cref="setFeature(string, bool)">setFeature(string, bool)</seealso>
		public const string FEATURE_PROCESS_DOCDECL = "http://xmlpull.org/v1/doc/features.html#process-docdecl";

		/// <summary>
		/// If this feature is activated, all validation errors as
		/// defined in the XML 1.0 specification are reported.
		/// </summary>
		/// <remarks>
		/// If this feature is activated, all validation errors as
		/// defined in the XML 1.0 specification are reported.
		/// This implies that FEATURE_PROCESS_DOCDECL is true and both, the
		/// internal and external document type declaration will be processed.
		/// <p><strong>Please Note:</strong> This feature can not be changed
		/// during parsing. The default value is false.
		/// </remarks>
		/// <seealso cref="getFeature(string)">getFeature(string)</seealso>
		/// <seealso cref="setFeature(string, bool)">setFeature(string, bool)</seealso>
		public const string FEATURE_VALIDATION = "http://xmlpull.org/v1/doc/features.html#validation";
	}
}
