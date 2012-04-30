using Sharpen;

namespace java.net
{
	/// <summary>
	/// A Uniform Resource Identifier that identifies an abstract or physical
	/// resource, as specified by <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC
	/// 2396</a>.
	/// </summary>
	/// <remarks>
	/// A Uniform Resource Identifier that identifies an abstract or physical
	/// resource, as specified by <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC
	/// 2396</a>.
	/// <h3>Parts of a URI</h3>
	/// A URI is composed of many parts. This class can both parse URI strings into
	/// parts and compose URI strings from parts. For example, consider the parts of
	/// this URI:
	/// <code>http://username:password@host:8080/directory/file?query#fragment</code>
	/// <table>
	/// <tr><th>Component                                            </th><th>Example value                                                      </th><th>Also known as</th></tr>
	/// <tr><td>
	/// <see cref="getScheme()">Scheme</see>
	/// </td><td>
	/// <code>http</code>
	/// </td><td>protocol</td></tr>
	/// <tr><td>
	/// <see cref="getSchemeSpecificPart()">Scheme-specific part</see>
	/// </td><td>
	/// <code>//username:password@host:8080/directory/file?query#fragment</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getAuthority()">Authority</see>
	/// </td><td>
	/// <code>username:password@host:8080</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getUserInfo()">User Info</see>
	/// </td><td>
	/// <code>username:password</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getHost()">Host</see>
	/// </td><td>
	/// <code>host</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getPort()">Port</see>
	/// </td><td>
	/// <code>8080</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getPath()">Path</see>
	/// </td><td>
	/// <code>/directory/file</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getQuery()">Query</see>
	/// </td><td>
	/// <code>query</code>
	/// </td><td></td></tr>
	/// <tr><td>
	/// <see cref="getFragment()">Fragment</see>
	/// </td><td>
	/// <code>fragment</code>
	/// </td><td>ref</td></tr>
	/// </table>
	/// <h3>Absolute vs. Relative URIs</h3>
	/// URIs are either
	/// <see cref="isAbsolute()">absolute or relative</see>
	/// .
	/// <ul>
	/// <li><strong>Absolute:</strong>
	/// <code>http://android.com/robots.txt</code>
	/// <li><strong>Relative:</strong>
	/// <code>robots.txt</code>
	/// </ul>
	/// <p>Absolute URIs always have a scheme. If its scheme is supported by
	/// <see cref="URL">URL</see>
	/// , you can use
	/// <see cref="toURL()">toURL()</see>
	/// to convert an absolute URI to a URL.
	/// <p>Relative URIs do not have a scheme and cannot be converted to URLs. If you
	/// have the absolute URI that a relative URI is relative to, you can use
	/// <see cref="resolve(URI)">resolve(URI)</see>
	/// to compute the referenced absolute URI. Symmetrically, you can use
	/// <see cref="relativize(URI)">relativize(URI)</see>
	/// to compute the relative URI from one URI to another.
	/// <pre>
	/// <code>
	/// URI absolute = new URI("http://android.com/");
	/// URI relative = new URI("robots.txt");
	/// URI resolved = new URI("http://android.com/robots.txt");
	/// // print "http://android.com/robots.txt"
	/// System.out.println(absolute.resolve(relative));
	/// // print "robots.txt"
	/// System.out.println(absolute.relativize(resolved));
	/// </code>
	/// </pre>
	/// <h3>Opaque vs. Hierarchical URIs</h3>
	/// Absolute URIs are either
	/// <see cref="isOpaque()">opaque or hierarchical</see>
	/// . Relative
	/// URIs are always hierarchical.
	/// <ul>
	/// <li><strong>Hierarchical:</strong>
	/// <code>http://android.com/robots.txt</code>
	/// <li><strong>Opaque:</strong>
	/// <code>mailto:robots@example.com</code>
	/// </ul>
	/// <p>Opaque URIs have both a scheme and a scheme-specific part that does not
	/// begin with the slash character:
	/// <code>/</code>
	/// . The contents of the
	/// scheme-specific part of an opaque URI is not parsed so an opaque URI never
	/// has an authority, user info, host, port, path or query. An opaque URIs may
	/// have a fragment, however. A typical opaque URI is
	/// <code>mailto:robots@example.com</code>
	/// .
	/// <table>
	/// <tr><th>Component           </th><th>Example value             </th></tr>
	/// <tr><td>Scheme              </td><td>
	/// <code>mailto</code>
	/// </td></tr>
	/// <tr><td>Scheme-specific part</td><td>
	/// <code>robots@example.com</code>
	/// </td></tr>
	/// <tr><td>Fragment            </td><td>                          </td></tr>
	/// </table>
	/// <p>Hierarchical URIs may have values for any URL component. They always
	/// have a non-null path, though that path may be the empty string.
	/// <h3>Encoding and Decoding URI Components</h3>
	/// Each component of a URI permits a limited set of legal characters. Other
	/// characters must first be <i>encoded</i> before they can be embedded in a URI.
	/// To recover the original characters from a URI, they may be <i>decoded</i>.
	/// <strong>Contrary to what you might expect,</strong> this class uses the
	/// term <i>raw</i> to refer to encoded strings. The non-<i>raw</i> accessors
	/// return decoded strings. For example, consider how this URI is decoded:
	/// <code>http://user:pa55w%3Frd@host:80/doc%7Csearch?q=green%20robots#over%206%22</code>
	/// <table>
	/// <tr><th>Component           </th><th>Legal Characters                                                    </th><th>Other Constraints                                  </th><th>Raw Value                                                      </th><th>Value</th></tr>
	/// <tr><td>Scheme              </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>+-.</code>
	/// </td><td>First character must be in
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// </td><td>                                                               </td><td>
	/// <code>http</code>
	/// </td></tr>
	/// <tr><td>Scheme-specific part</td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=?/[]@</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>//user:pa55w%3Frd@host:80/doc%7Csearch?q=green%20robots</code>
	/// </td><td>
	/// <code>//user:pa55w?rd@host:80/doc|search?q=green robots</code>
	/// </td></tr>
	/// <tr><td>Authority           </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=@[]</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>user:pa55w%3Frd@host:80</code>
	/// </td><td>
	/// <code>user:pa55w?rd@host:80</code>
	/// </td></tr>
	/// <tr><td>User Info           </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>user:pa55w%3Frd</code>
	/// </td><td>
	/// <code>user:pa55w?rd</code>
	/// </td></tr>
	/// <tr><td>Host                </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>-.[]</code>
	/// </td><td>Domain name, IPv4 address or [IPv6 address]        </td><td>                                                               </td><td>host</td></tr>
	/// <tr><td>Port                </td><td>
	/// <code>0-9</code>
	/// </td><td>                                                   </td><td>                                                               </td><td>
	/// <code>80</code>
	/// </td></tr>
	/// <tr><td>Path                </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=/@</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>/doc%7Csearch</code>
	/// </td><td>
	/// <code>/doc|search</code>
	/// </td></tr>
	/// <tr><td>Query               </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=?/[]@</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>q=green%20robots</code>
	/// </td><td>
	/// <code>q=green robots</code>
	/// </td></tr>
	/// <tr><td>Fragment            </td><td>
	/// <code>0-9</code>
	/// ,
	/// <code>a-z</code>
	/// ,
	/// <code>A-Z</code>
	/// ,
	/// <code>_-!.~'()*,;:$&+=?/[]@</code>
	/// </td><td>Non-ASCII characters okay                          </td><td>
	/// <code>over%206%22</code>
	/// </td><td>
	/// <code>over 6"</code>
	/// </td></tr>
	/// </table>
	/// A URI's host, port and scheme are not eligible for encoding and must not
	/// contain illegal characters.
	/// <p>To encode a URI, invoke any of the multiple-parameter constructors of this
	/// class. These constructors accept your original strings and encode them into
	/// their raw form.
	/// <p>To decode a URI, invoke the single-string constructor, and then use the
	/// appropriate accessor methods to get the decoded components.
	/// <p>The
	/// <see cref="URL">URL</see>
	/// class can be used to retrieve resources by their URI.
	/// </remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed partial class URI : java.lang.Comparable<java.net.URI>
	{
		internal const long serialVersionUID = -6052424284110960213l;

		internal const string UNRESERVED = "_-!.~\'()*";

		internal const string PUNCTUATION = ",;:$&+=";

		internal static readonly libcore.net.UriCodec USER_INFO_ENCODER = new java.net.URI
			.PartEncoder(string.Empty);

		internal static readonly libcore.net.UriCodec PATH_ENCODER = new java.net.URI.PartEncoder
			("/@");

		internal static readonly libcore.net.UriCodec AUTHORITY_ENCODER = new java.net.URI
			.PartEncoder("@[]");

		/// <summary>for java.net.URL, which foolishly combines these two parts</summary>
		internal static readonly libcore.net.UriCodec FILE_AND_QUERY_ENCODER = new java.net.URI
			.PartEncoder("/@?");

		/// <summary>for query, fragment, and scheme-specific part</summary>
		internal static readonly libcore.net.UriCodec ALL_LEGAL_ENCODER = new java.net.URI
			.PartEncoder("?/[]@");

		private sealed class _UriCodec_150 : libcore.net.UriCodec
		{
			public _UriCodec_150()
			{
			}

			[Sharpen.OverridesMethod(@"libcore.net.UriCodec")]
			protected internal override bool isRetained(char c)
			{
				return c <= 127;
			}
		}

		/// <summary>Retains all ASCII chars including delimiters.</summary>
		/// <remarks>Retains all ASCII chars including delimiters.</remarks>
		private static readonly libcore.net.UriCodec ASCII_ONLY = new _UriCodec_150();

		/// <summary>
		/// Encodes the unescaped characters of
		/// <code>s</code>
		/// that are not permitted.
		/// Permitted characters are:
		/// <ul>
		/// <li>Unreserved characters in <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC 2396</a>.
		/// <li>
		/// <code>extraOkayChars</code>
		/// ,
		/// <li>non-ASCII, non-control, non-whitespace characters
		/// </ul>
		/// </summary>
		private class PartEncoder : libcore.net.UriCodec
		{
			internal readonly string extraLegalCharacters;

			internal PartEncoder(string extraLegalCharacters)
			{
				this.extraLegalCharacters = extraLegalCharacters;
			}

			[Sharpen.OverridesMethod(@"libcore.net.UriCodec")]
			protected internal override bool isRetained(char c)
			{
				return UNRESERVED.IndexOf(c) != -1 || PUNCTUATION.IndexOf(c) != -1 || extraLegalCharacters
					.IndexOf(c) != -1 || (c > 127 && !System.Char.IsWhiteSpace(c) && !Sharpen.CharHelper.IsISOControl
					(c));
			}
		}

		private string @string;

		[System.NonSerialized]
		private string scheme;

		[System.NonSerialized]
		private string schemeSpecificPart;

		[System.NonSerialized]
		private string authority;

		[System.NonSerialized]
		private string userInfo;

		[System.NonSerialized]
		private string host;

		[System.NonSerialized]
		private int port = -1;

		[System.NonSerialized]
		private string path;

		[System.NonSerialized]
		private string query;

		[System.NonSerialized]
		private string fragment;

		[System.NonSerialized]
		private bool opaque;

		[System.NonSerialized]
		private bool absolute;

		[System.NonSerialized]
		private bool serverAuthority = false;

		[System.NonSerialized]
		private int hash = -1;

		private URI()
		{
		}

		/// <summary>
		/// Creates a new URI instance by parsing
		/// <code>spec</code>
		/// .
		/// </summary>
		/// <param name="spec">a URI whose illegal characters have all been encoded.</param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public URI(string spec)
		{
			parseURI(spec, false);
		}

		/// <summary>Creates a new URI instance of the given unencoded component parts.</summary>
		/// <remarks>Creates a new URI instance of the given unencoded component parts.</remarks>
		/// <param name="scheme">the URI scheme, or null for a non-absolute URI.</param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public URI(string scheme, string schemeSpecificPart, string fragment)
		{
			java.lang.StringBuilder uri = new java.lang.StringBuilder();
			if (scheme != null)
			{
				uri.append(scheme);
				uri.append(':');
			}
			if (schemeSpecificPart != null)
			{
				ALL_LEGAL_ENCODER.appendEncoded(uri, schemeSpecificPart);
			}
			if (fragment != null)
			{
				uri.append('#');
				ALL_LEGAL_ENCODER.appendEncoded(uri, fragment);
			}
			parseURI(uri.ToString(), false);
		}

		/// <summary>Creates a new URI instance of the given unencoded component parts.</summary>
		/// <remarks>Creates a new URI instance of the given unencoded component parts.</remarks>
		/// <param name="scheme">the URI scheme, or null for a non-absolute URI.</param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public URI(string scheme, string userInfo, string host, int port, string path, string
			 query, string fragment)
		{
			if (scheme == null && userInfo == null && host == null && path == null && query ==
				 null && fragment == null)
			{
				this.path = string.Empty;
				return;
			}
			if (scheme != null && path != null && !string.IsNullOrEmpty(path) && path[0] != '/')
			{
				throw new java.net.URISyntaxException(path, "Relative path");
			}
			java.lang.StringBuilder uri = new java.lang.StringBuilder();
			if (scheme != null)
			{
				uri.append(scheme);
				uri.append(':');
			}
			if (userInfo != null || host != null || port != -1)
			{
				uri.append("//");
			}
			if (userInfo != null)
			{
				USER_INFO_ENCODER.appendEncoded(uri, userInfo);
				uri.append('@');
			}
			if (host != null)
			{
				// check for IPv6 addresses that hasn't been enclosed in square brackets
				if (host.IndexOf(':') != -1 && host.IndexOf(']') == -1 && host.IndexOf('[') == -1)
				{
					host = "[" + host + "]";
				}
				uri.append(host);
			}
			if (port != -1)
			{
				uri.append(':');
				uri.append(port);
			}
			if (path != null)
			{
				PATH_ENCODER.appendEncoded(uri, path);
			}
			if (query != null)
			{
				uri.append('?');
				ALL_LEGAL_ENCODER.appendEncoded(uri, query);
			}
			if (fragment != null)
			{
				uri.append('#');
				ALL_LEGAL_ENCODER.appendEncoded(uri, fragment);
			}
			parseURI(uri.ToString(), true);
		}

		/// <summary>Creates a new URI instance of the given unencoded component parts.</summary>
		/// <remarks>Creates a new URI instance of the given unencoded component parts.</remarks>
		/// <param name="scheme">the URI scheme, or null for a non-absolute URI.</param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public URI(string scheme, string host, string path, string fragment) : this(scheme
			, null, host, -1, path, null, fragment)
		{
		}

		/// <summary>Creates a new URI instance of the given unencoded component parts.</summary>
		/// <remarks>Creates a new URI instance of the given unencoded component parts.</remarks>
		/// <param name="scheme">the URI scheme, or null for a non-absolute URI.</param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public URI(string scheme, string authority, string path, string query, string fragment
			)
		{
			if (scheme != null && path != null && !string.IsNullOrEmpty(path) && path[0] != '/')
			{
				throw new java.net.URISyntaxException(path, "Relative path");
			}
			java.lang.StringBuilder uri = new java.lang.StringBuilder();
			if (scheme != null)
			{
				uri.append(scheme);
				uri.append(':');
			}
			if (authority != null)
			{
				uri.append("//");
				AUTHORITY_ENCODER.appendEncoded(uri, authority);
			}
			if (path != null)
			{
				PATH_ENCODER.appendEncoded(uri, path);
			}
			if (query != null)
			{
				uri.append('?');
				ALL_LEGAL_ENCODER.appendEncoded(uri, query);
			}
			if (fragment != null)
			{
				uri.append('#');
				ALL_LEGAL_ENCODER.appendEncoded(uri, fragment);
			}
			parseURI(uri.ToString(), false);
		}

		/// <summary>Breaks uri into its component parts.</summary>
		/// <remarks>
		/// Breaks uri into its component parts. This first splits URI into scheme,
		/// scheme-specific part and fragment:
		/// [scheme:][scheme-specific part][#fragment]
		/// Then it breaks the scheme-specific part into authority, path and query:
		/// [//authority][path][?query]
		/// Finally it delegates to parseAuthority to break the authority into user
		/// info, host and port:
		/// [user-info@][host][:port]
		/// </remarks>
		/// <exception cref="java.net.URISyntaxException"></exception>
		private void parseURI(string uri, bool forceServer)
		{
			@string = uri;
			// "#fragment"
			int fragmentStart = libcore.net.url.UrlUtils.findFirstOf(uri, "#", 0, uri.Length);
			if (fragmentStart < uri.Length)
			{
				fragment = ALL_LEGAL_ENCODER.validate(uri, fragmentStart + 1, uri.Length, "fragment"
					);
			}
			// scheme:
			int start;
			int colon = libcore.net.url.UrlUtils.findFirstOf(uri, ":", 0, fragmentStart);
			if (colon < libcore.net.url.UrlUtils.findFirstOf(uri, "/?#", 0, fragmentStart))
			{
				absolute = true;
				scheme = validateScheme(uri, colon);
				start = colon + 1;
				if (start == fragmentStart)
				{
					throw new java.net.URISyntaxException(uri, "Scheme-specific part expected", start
						);
				}
				// URIs with schemes followed by a non-/ char are opaque and need no further parsing.
				if (!Sharpen.StringHelper.RegionMatches(uri, start, "/", 0, 1))
				{
					opaque = true;
					schemeSpecificPart = ALL_LEGAL_ENCODER.validate(uri, start, fragmentStart, "scheme specific part"
						);
					return;
				}
			}
			else
			{
				absolute = false;
				start = 0;
			}
			opaque = false;
			schemeSpecificPart = Sharpen.StringHelper.Substring(uri, start, fragmentStart);
			// "//authority"
			int fileStart;
			if (Sharpen.StringHelper.RegionMatches(uri, start, "//", 0, 2))
			{
				int authorityStart = start + 2;
				fileStart = libcore.net.url.UrlUtils.findFirstOf(uri, "/?", authorityStart, fragmentStart
					);
				if (authorityStart == uri.Length)
				{
					throw new java.net.URISyntaxException(uri, "Authority expected", uri.Length);
				}
				if (authorityStart < fileStart)
				{
					authority = AUTHORITY_ENCODER.validate(uri, authorityStart, fileStart, "authority"
						);
				}
			}
			else
			{
				fileStart = start;
			}
			// "path"
			int queryStart = libcore.net.url.UrlUtils.findFirstOf(uri, "?", fileStart, fragmentStart
				);
			path = PATH_ENCODER.validate(uri, fileStart, queryStart, "path");
			// "?query"
			if (queryStart < fragmentStart)
			{
				query = ALL_LEGAL_ENCODER.validate(uri, queryStart + 1, fragmentStart, "query");
			}
			parseAuthority(forceServer);
		}

		/// <exception cref="java.net.URISyntaxException"></exception>
		private string validateScheme(string uri, int end)
		{
			if (end == 0)
			{
				throw new java.net.URISyntaxException(uri, "Scheme expected", 0);
			}
			{
				for (int i = 0; i < end; i++)
				{
					if (!libcore.net.url.UrlUtils.isValidSchemeChar(i, uri[i]))
					{
						throw new java.net.URISyntaxException(uri, "Illegal character in scheme", 0);
					}
				}
			}
			return Sharpen.StringHelper.Substring(uri, 0, end);
		}

		/// <summary>Breaks this URI's authority into user info, host and port parts.</summary>
		/// <remarks>
		/// Breaks this URI's authority into user info, host and port parts.
		/// [user-info@][host][:port]
		/// If any part of this fails this method will give up and potentially leave
		/// these fields with their default values.
		/// </remarks>
		/// <param name="forceServer">
		/// true to always throw if the authority cannot be
		/// parsed. If false, this method may still throw for some kinds of
		/// errors; this unpredictable behavior is consistent with the RI.
		/// </param>
		/// <exception cref="java.net.URISyntaxException"></exception>
		private void parseAuthority(bool forceServer)
		{
			if (authority == null)
			{
				return;
			}
			string tempUserInfo = null;
			string temp = authority;
			int index = temp.IndexOf('@');
			int hostIndex = 0;
			if (index != -1)
			{
				// remove user info
				tempUserInfo = Sharpen.StringHelper.Substring(temp, 0, index);
				validateUserInfo(authority, tempUserInfo, 0);
				temp = Sharpen.StringHelper.Substring(temp, index + 1);
				// host[:port] is left
				hostIndex = index + 1;
			}
			index = temp.LastIndexOf(':');
			int endIndex = temp.IndexOf(']');
			string tempHost;
			int tempPort = -1;
			if (index != -1 && endIndex < index)
			{
				// determine port and host
				tempHost = Sharpen.StringHelper.Substring(temp, 0, index);
				if (index < (temp.Length - 1))
				{
					// port part is not empty
					try
					{
						tempPort = System.Convert.ToInt32(Sharpen.StringHelper.Substring(temp, index + 1)
							);
						if (tempPort < 0)
						{
							if (forceServer)
							{
								throw new java.net.URISyntaxException(authority, "Invalid port number", hostIndex
									 + index + 1);
							}
							return;
						}
					}
					catch (System.ArgumentException)
					{
						if (forceServer)
						{
							throw new java.net.URISyntaxException(authority, "Invalid port number", hostIndex
								 + index + 1);
						}
						return;
					}
				}
			}
			else
			{
				tempHost = temp;
			}
			if (string.IsNullOrEmpty(tempHost))
			{
				if (forceServer)
				{
					throw new java.net.URISyntaxException(authority, "Expected host", hostIndex);
				}
				return;
			}
			if (!isValidHost(forceServer, tempHost))
			{
				return;
			}
			// this is a server based uri,
			// fill in the userInfo, host and port fields
			userInfo = tempUserInfo;
			host = tempHost;
			port = tempPort;
			serverAuthority = true;
		}

		/// <exception cref="java.net.URISyntaxException"></exception>
		private void validateUserInfo(string uri, string userInfo, int index)
		{
			{
				for (int i = 0; i < userInfo.Length; i++)
				{
					char ch = userInfo[i];
					if (ch == ']' || ch == '[')
					{
						throw new java.net.URISyntaxException(uri, "Illegal character in userInfo", index
							 + i);
					}
				}
			}
		}

		// IPv6 address
		// If it's numeric, the presence of square brackets guarantees
		// that it's a numeric IPv6 address.
		// '[' and ']' can only be the first char and last char
		// of the host name
		// domain name
		// IPv4 address?
		/// <summary>
		/// Compares this URI with the given argument
		/// <code>uri</code>
		/// . This method will
		/// return a negative value if this URI instance is less than the given
		/// argument and a positive value if this URI instance is greater than the
		/// given argument. The return value
		/// <code>0</code>
		/// indicates that the two
		/// instances represent the same URI. To define the order the single parts of
		/// the URI are compared with each other. String components will be ordered
		/// in the natural case-sensitive way. A hierarchical URI is less than an
		/// opaque URI and if one part is
		/// <code>null</code>
		/// the URI with the undefined
		/// part is less than the other one.
		/// </summary>
		/// <param name="uri">the URI this instance has to compare with.</param>
		/// <returns>the value representing the order of the two instances.</returns>
		[Sharpen.ImplementsInterface(@"java.lang.Comparable")]
		public int compareTo(java.net.URI uri)
		{
			int ret;
			// compare schemes
			if (scheme == null && uri.scheme != null)
			{
				return -1;
			}
			else
			{
				if (scheme != null && uri.scheme == null)
				{
					return 1;
				}
				else
				{
					if (scheme != null && uri.scheme != null)
					{
						ret = Sharpen.StringHelper.CompareToIgnoreCase(scheme, uri.scheme);
						if (ret != 0)
						{
							return ret;
						}
					}
				}
			}
			// compare opacities
			if (!opaque && uri.opaque)
			{
				return -1;
			}
			else
			{
				if (opaque && !uri.opaque)
				{
					return 1;
				}
				else
				{
					if (opaque && uri.opaque)
					{
						ret = string.CompareOrdinal(schemeSpecificPart, uri.schemeSpecificPart);
						if (ret != 0)
						{
							return ret;
						}
					}
					else
					{
						// otherwise both must be hierarchical
						// compare authorities
						if (authority != null && uri.authority == null)
						{
							return 1;
						}
						else
						{
							if (authority == null && uri.authority != null)
							{
								return -1;
							}
							else
							{
								if (authority != null && uri.authority != null)
								{
									if (host != null && uri.host != null)
									{
										// both are server based, so compare userInfo, host, port
										if (userInfo != null && uri.userInfo == null)
										{
											return 1;
										}
										else
										{
											if (userInfo == null && uri.userInfo != null)
											{
												return -1;
											}
											else
											{
												if (userInfo != null && uri.userInfo != null)
												{
													ret = string.CompareOrdinal(userInfo, uri.userInfo);
													if (ret != 0)
													{
														return ret;
													}
												}
											}
										}
										// userInfo's are the same, compare hostname
										ret = Sharpen.StringHelper.CompareToIgnoreCase(host, uri.host);
										if (ret != 0)
										{
											return ret;
										}
										// compare port
										if (port != uri.port)
										{
											return port - uri.port;
										}
									}
									else
									{
										// one or both are registry based, compare the whole
										// authority
										ret = string.CompareOrdinal(authority, uri.authority);
										if (ret != 0)
										{
											return ret;
										}
									}
								}
							}
						}
						// authorities are the same
						// compare paths
						ret = string.CompareOrdinal(path, uri.path);
						if (ret != 0)
						{
							return ret;
						}
						// compare queries
						if (query != null && uri.query == null)
						{
							return 1;
						}
						else
						{
							if (query == null && uri.query != null)
							{
								return -1;
							}
							else
							{
								if (query != null && uri.query != null)
								{
									ret = string.CompareOrdinal(query, uri.query);
									if (ret != 0)
									{
										return ret;
									}
								}
							}
						}
					}
				}
			}
			// everything else is identical, so compare fragments
			if (fragment != null && uri.fragment == null)
			{
				return 1;
			}
			else
			{
				if (fragment == null && uri.fragment != null)
				{
					return -1;
				}
				else
				{
					if (fragment != null && uri.fragment != null)
					{
						ret = string.CompareOrdinal(fragment, uri.fragment);
						if (ret != 0)
						{
							return ret;
						}
					}
				}
			}
			// identical
			return 0;
		}

		/// <summary>
		/// Returns the URI formed by parsing
		/// <code>uri</code>
		/// . This method behaves
		/// identically to the string constructor but throws a different exception
		/// on failure. The constructor fails with a checked
		/// <see cref="URISyntaxException">URISyntaxException</see>
		/// ; this method fails with an unchecked
		/// <see cref="System.ArgumentException">System.ArgumentException</see>
		/// .
		/// </summary>
		public static java.net.URI create(string uri)
		{
			try
			{
				return new java.net.URI(uri);
			}
			catch (java.net.URISyntaxException e)
			{
				throw new System.ArgumentException(e.Message);
			}
		}

		private java.net.URI duplicate()
		{
			java.net.URI clone_1 = new java.net.URI();
			clone_1.absolute = absolute;
			clone_1.authority = authority;
			clone_1.fragment = fragment;
			clone_1.host = host;
			clone_1.opaque = opaque;
			clone_1.path = path;
			clone_1.port = port;
			clone_1.query = query;
			clone_1.scheme = scheme;
			clone_1.schemeSpecificPart = schemeSpecificPart;
			clone_1.userInfo = userInfo;
			clone_1.serverAuthority = serverAuthority;
			return clone_1;
		}

		private string convertHexToLowerCase(string s)
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder(string.Empty);
			if (s.IndexOf('%') == -1)
			{
				return s;
			}
			int index;
			int prevIndex = 0;
			while ((index = s.IndexOf('%', prevIndex)) != -1)
			{
				result.append(Sharpen.StringHelper.Substring(s, prevIndex, index + 1));
				result.append(Sharpen.StringHelper.Substring(s, index + 1, index + 3).ToLower(System.Globalization.CultureInfo.InvariantCulture
					));
				index += 3;
				prevIndex = index;
			}
			return result.ToString();
		}

		/// <summary>
		/// Returns true if
		/// <code>first</code>
		/// and
		/// <code>second</code>
		/// are equal after
		/// unescaping hex sequences like %F1 and %2b.
		/// </summary>
		private bool escapedEquals(string first, string second)
		{
			if (first.IndexOf('%') != second.IndexOf('%'))
			{
				return first.Equals(second);
			}
			int index;
			int prevIndex = 0;
			while ((index = first.IndexOf('%', prevIndex)) != -1 && second.IndexOf('%', prevIndex
				) == index)
			{
				bool match = Sharpen.StringHelper.Substring(first, prevIndex, index).Equals(Sharpen.StringHelper.Substring
					(second, prevIndex, index));
				if (!match)
				{
					return false;
				}
				match = Sharpen.StringHelper.EqualsIgnoreCase(Sharpen.StringHelper.Substring(first
					, index + 1, index + 3), Sharpen.StringHelper.Substring(second, index + 1, index
					 + 3));
				if (!match)
				{
					return false;
				}
				index += 3;
				prevIndex = index;
			}
			return Sharpen.StringHelper.Substring(first, prevIndex).Equals(Sharpen.StringHelper.Substring
				(second, prevIndex));
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object o)
		{
			if (!(o is java.net.URI))
			{
				return false;
			}
			java.net.URI uri = (java.net.URI)o;
			if (uri.fragment == null && fragment != null || uri.fragment != null && fragment 
				== null)
			{
				return false;
			}
			else
			{
				if (uri.fragment != null && fragment != null)
				{
					if (!escapedEquals(uri.fragment, fragment))
					{
						return false;
					}
				}
			}
			if (uri.scheme == null && scheme != null || uri.scheme != null && scheme == null)
			{
				return false;
			}
			else
			{
				if (uri.scheme != null && scheme != null)
				{
					if (!Sharpen.StringHelper.EqualsIgnoreCase(uri.scheme, scheme))
					{
						return false;
					}
				}
			}
			if (uri.opaque && opaque)
			{
				return escapedEquals(uri.schemeSpecificPart, schemeSpecificPart);
			}
			else
			{
				if (!uri.opaque && !opaque)
				{
					if (!escapedEquals(path, uri.path))
					{
						return false;
					}
					if (uri.query != null && query == null || uri.query == null && query != null)
					{
						return false;
					}
					else
					{
						if (uri.query != null && query != null)
						{
							if (!escapedEquals(uri.query, query))
							{
								return false;
							}
						}
					}
					if (uri.authority != null && authority == null || uri.authority == null && authority
						 != null)
					{
						return false;
					}
					else
					{
						if (uri.authority != null && authority != null)
						{
							if (uri.host != null && host == null || uri.host == null && host != null)
							{
								return false;
							}
							else
							{
								if (uri.host == null && host == null)
								{
									// both are registry based, so compare the whole authority
									return escapedEquals(uri.authority, authority);
								}
								else
								{
									// uri.host != null && host != null, so server-based
									if (!Sharpen.StringHelper.EqualsIgnoreCase(host, uri.host))
									{
										return false;
									}
									if (port != uri.port)
									{
										return false;
									}
									if (uri.userInfo != null && userInfo == null || uri.userInfo == null && userInfo 
										!= null)
									{
										return false;
									}
									else
									{
										if (uri.userInfo != null && userInfo != null)
										{
											return escapedEquals(userInfo, uri.userInfo);
										}
										else
										{
											return true;
										}
									}
								}
							}
						}
						else
						{
							// no authority
							return true;
						}
					}
				}
				else
				{
					// one is opaque, the other hierarchical
					return false;
				}
			}
		}

		/// <summary>Returns the scheme of this URI, or null if this URI has no scheme.</summary>
		/// <remarks>
		/// Returns the scheme of this URI, or null if this URI has no scheme. This
		/// is also known as the protocol.
		/// </remarks>
		public string getScheme()
		{
			return scheme;
		}

		/// <summary>
		/// Returns the decoded scheme-specific part of this URI, or null if this URI
		/// has no scheme-specific part.
		/// </summary>
		/// <remarks>
		/// Returns the decoded scheme-specific part of this URI, or null if this URI
		/// has no scheme-specific part.
		/// </remarks>
		public string getSchemeSpecificPart()
		{
			return decode(schemeSpecificPart);
		}

		/// <summary>
		/// Returns the encoded scheme-specific part of this URI, or null if this URI
		/// has no scheme-specific part.
		/// </summary>
		/// <remarks>
		/// Returns the encoded scheme-specific part of this URI, or null if this URI
		/// has no scheme-specific part.
		/// </remarks>
		public string getRawSchemeSpecificPart()
		{
			return schemeSpecificPart;
		}

		/// <summary>
		/// Returns the decoded authority part of this URI, or null if this URI has
		/// no authority.
		/// </summary>
		/// <remarks>
		/// Returns the decoded authority part of this URI, or null if this URI has
		/// no authority.
		/// </remarks>
		public string getAuthority()
		{
			return decode(authority);
		}

		/// <summary>
		/// Returns the encoded authority of this URI, or null if this URI has no
		/// authority.
		/// </summary>
		/// <remarks>
		/// Returns the encoded authority of this URI, or null if this URI has no
		/// authority.
		/// </remarks>
		public string getRawAuthority()
		{
			return authority;
		}

		/// <summary>
		/// Returns the decoded user info of this URI, or null if this URI has no
		/// user info.
		/// </summary>
		/// <remarks>
		/// Returns the decoded user info of this URI, or null if this URI has no
		/// user info.
		/// </remarks>
		public string getUserInfo()
		{
			return decode(userInfo);
		}

		/// <summary>
		/// Returns the encoded user info of this URI, or null if this URI has no
		/// user info.
		/// </summary>
		/// <remarks>
		/// Returns the encoded user info of this URI, or null if this URI has no
		/// user info.
		/// </remarks>
		public string getRawUserInfo()
		{
			return userInfo;
		}

		/// <summary>Returns the host of this URI, or null if this URI has no host.</summary>
		/// <remarks>Returns the host of this URI, or null if this URI has no host.</remarks>
		public string getHost()
		{
			return host;
		}

		/// <summary>
		/// Returns the port number of this URI, or
		/// <code>-1</code>
		/// if this URI has no
		/// explicit port.
		/// </summary>
		public int getPort()
		{
			return port;
		}

		/// <hide></hide>
		public int getEffectivePort()
		{
			return getEffectivePort(scheme, port);
		}

		/// <summary>
		/// Returns the port to use for
		/// <code>scheme</code>
		/// connections will use when
		/// <see cref="getPort()">getPort()</see>
		/// returns
		/// <code>specifiedPort</code>
		/// .
		/// </summary>
		/// <hide></hide>
		public static int getEffectivePort(string scheme, int specifiedPort)
		{
			if (specifiedPort != -1)
			{
				return specifiedPort;
			}
			if (Sharpen.StringHelper.EqualsIgnoreCase("http", scheme))
			{
				return 80;
			}
			else
			{
				if (Sharpen.StringHelper.EqualsIgnoreCase("https", scheme))
				{
					return 443;
				}
				else
				{
					return -1;
				}
			}
		}

		/// <summary>Returns the decoded path of this URI, or null if this URI has no path.</summary>
		/// <remarks>Returns the decoded path of this URI, or null if this URI has no path.</remarks>
		public string getPath()
		{
			return decode(path);
		}

		/// <summary>Returns the encoded path of this URI, or null if this URI has no path.</summary>
		/// <remarks>Returns the encoded path of this URI, or null if this URI has no path.</remarks>
		public string getRawPath()
		{
			return path;
		}

		/// <summary>Returns the decoded query of this URI, or null if this URI has no query.
		/// 	</summary>
		/// <remarks>Returns the decoded query of this URI, or null if this URI has no query.
		/// 	</remarks>
		public string getQuery()
		{
			return decode(query);
		}

		/// <summary>Returns the encoded query of this URI, or null if this URI has no query.
		/// 	</summary>
		/// <remarks>Returns the encoded query of this URI, or null if this URI has no query.
		/// 	</remarks>
		public string getRawQuery()
		{
			return query;
		}

		/// <summary>
		/// Returns the decoded fragment of this URI, or null if this URI has no
		/// fragment.
		/// </summary>
		/// <remarks>
		/// Returns the decoded fragment of this URI, or null if this URI has no
		/// fragment.
		/// </remarks>
		public string getFragment()
		{
			return decode(fragment);
		}

		/// <summary>
		/// Gets the encoded fragment of this URI, or null if this URI has no
		/// fragment.
		/// </summary>
		/// <remarks>
		/// Gets the encoded fragment of this URI, or null if this URI has no
		/// fragment.
		/// </remarks>
		public string getRawFragment()
		{
			return fragment;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			if (hash == -1)
			{
				hash = getHashString().GetHashCode();
			}
			return hash;
		}

		/// <summary>
		/// Returns true if this URI is absolute, which means that a scheme is
		/// defined.
		/// </summary>
		/// <remarks>
		/// Returns true if this URI is absolute, which means that a scheme is
		/// defined.
		/// </remarks>
		public bool isAbsolute()
		{
			// TODO: simplify to 'scheme != null' ?
			return absolute;
		}

		/// <summary>Returns true if this URI is opaque.</summary>
		/// <remarks>
		/// Returns true if this URI is opaque. Opaque URIs are absolute and have a
		/// scheme-specific part that does not start with a slash character. All
		/// parts except scheme, scheme-specific and fragment are undefined.
		/// </remarks>
		public bool isOpaque()
		{
			return opaque;
		}

		/// <summary>Returns the normalized path.</summary>
		/// <remarks>Returns the normalized path.</remarks>
		private string normalize(string path, bool discardRelativePrefix)
		{
			path = libcore.net.url.UrlUtils.canonicalizePath(path, discardRelativePrefix);
			int colon = path.IndexOf(':');
			if (colon != -1)
			{
				int slash = path.IndexOf('/');
				if (slash == -1 || colon < slash)
				{
					path = "./" + path;
				}
			}
			return path;
		}

		/// <summary>Normalizes the path part of this URI.</summary>
		/// <remarks>Normalizes the path part of this URI.</remarks>
		/// <returns>
		/// an URI object which represents this instance with a normalized
		/// path.
		/// </returns>
		public java.net.URI normalize()
		{
			if (opaque)
			{
				return this;
			}
			string normalizedPath = normalize(path, false);
			// if the path is already normalized, return this
			if (path.Equals(normalizedPath))
			{
				return this;
			}
			// get an exact copy of the URI re-calculate the scheme specific part
			// since the path of the normalized URI is different from this URI.
			java.net.URI result = duplicate();
			result.path = normalizedPath;
			result.setSchemeSpecificPart();
			return result;
		}

		/// <summary>
		/// Tries to parse the authority component of this URI to divide it into the
		/// host, port, and user-info.
		/// </summary>
		/// <remarks>
		/// Tries to parse the authority component of this URI to divide it into the
		/// host, port, and user-info. If this URI is already determined as a
		/// ServerAuthority this instance will be returned without changes.
		/// </remarks>
		/// <returns>this instance with the components of the parsed server authority.</returns>
		/// <exception cref="URISyntaxException">
		/// if the authority part could not be parsed as a server-based
		/// authority.
		/// </exception>
		/// <exception cref="java.net.URISyntaxException"></exception>
		public java.net.URI parseServerAuthority()
		{
			if (!serverAuthority)
			{
				parseAuthority(true);
			}
			return this;
		}

		/// <summary>
		/// Makes the given URI
		/// <code>relative</code>
		/// to a relative URI against the URI
		/// represented by this instance.
		/// </summary>
		/// <param name="relative">the URI which has to be relativized against this URI.</param>
		/// <returns>the relative URI.</returns>
		public java.net.URI relativize(java.net.URI relative)
		{
			if (relative.opaque || opaque)
			{
				return relative;
			}
			if (scheme == null ? relative.scheme != null : !scheme.Equals(relative.scheme))
			{
				return relative;
			}
			if (authority == null ? relative.authority != null : !authority.Equals(relative.authority
				))
			{
				return relative;
			}
			// normalize both paths
			string thisPath = normalize(path, false);
			string relativePath = normalize(relative.path, false);
			if (!thisPath.Equals(relativePath))
			{
				// drop everything after the last slash in this path
				thisPath = Sharpen.StringHelper.Substring(thisPath, 0, thisPath.LastIndexOf('/') 
					+ 1);
				if (!relativePath.StartsWith(thisPath))
				{
					return relative;
				}
			}
			java.net.URI result = new java.net.URI();
			result.fragment = relative.fragment;
			result.query = relative.query;
			// the result URI is the remainder of the relative URI's path
			result.path = Sharpen.StringHelper.Substring(relativePath, thisPath.Length);
			result.setSchemeSpecificPart();
			return result;
		}

		/// <summary>
		/// Resolves the given URI
		/// <code>relative</code>
		/// against the URI represented by
		/// this instance.
		/// </summary>
		/// <param name="relative">the URI which has to be resolved against this URI.</param>
		/// <returns>the resolved URI.</returns>
		public java.net.URI resolve(java.net.URI relative)
		{
			if (relative.absolute || opaque)
			{
				return relative;
			}
			if (relative.authority != null)
			{
				// If the relative URI has an authority, the result is the relative
				// with this URI's scheme.
				java.net.URI result = relative.duplicate();
				result.scheme = scheme;
				result.absolute = absolute;
				return result;
			}
			if (string.IsNullOrEmpty(relative.path) && relative.scheme == null && relative.query
				 == null)
			{
				// if the relative URI only consists of at most a fragment,
				java.net.URI result = duplicate();
				result.fragment = relative.fragment;
				return result;
			}
			java.net.URI result_1 = duplicate();
			result_1.fragment = relative.fragment;
			result_1.query = relative.query;
			string resolvedPath;
			if (relative.path.StartsWith("/"))
			{
				// The relative URI has an absolute path; use it.
				resolvedPath = relative.path;
			}
			else
			{
				if (string.IsNullOrEmpty(relative.path))
				{
					// The relative URI has no path; use the base path.
					resolvedPath = path;
				}
				else
				{
					// The relative URI has a relative path; combine the paths.
					int endIndex = path.LastIndexOf('/') + 1;
					resolvedPath = Sharpen.StringHelper.Substring(path, 0, endIndex) + relative.path;
				}
			}
			result_1.path = libcore.net.url.UrlUtils.authoritySafePath(result_1.authority, normalize
				(resolvedPath, true));
			result_1.setSchemeSpecificPart();
			return result_1;
		}

		/// <summary>
		/// Helper method used to re-calculate the scheme specific part of the
		/// resolved or normalized URIs
		/// </summary>
		private void setSchemeSpecificPart()
		{
			// ssp = [//authority][path][?query]
			java.lang.StringBuilder ssp = new java.lang.StringBuilder();
			if (authority != null)
			{
				ssp.append("//" + authority);
			}
			if (path != null)
			{
				ssp.append(path);
			}
			if (query != null)
			{
				ssp.append("?" + query);
			}
			schemeSpecificPart = ssp.ToString();
			// reset string, so that it can be re-calculated correctly when asked.
			@string = null;
		}

		/// <summary>
		/// Creates a new URI instance by parsing the given string
		/// <code>relative</code>
		/// and resolves the created URI against the URI represented by this
		/// instance.
		/// </summary>
		/// <param name="relative">
		/// the given string to create the new URI instance which has to
		/// be resolved later on.
		/// </param>
		/// <returns>the created and resolved URI.</returns>
		public java.net.URI resolve(string relative)
		{
			return resolve(create(relative));
		}

		private string decode(string s)
		{
			return s != null ? libcore.net.UriCodec.decode(s) : null;
		}

		/// <summary>
		/// Returns the textual string representation of this URI instance using the
		/// US-ASCII encoding.
		/// </summary>
		/// <remarks>
		/// Returns the textual string representation of this URI instance using the
		/// US-ASCII encoding.
		/// </remarks>
		/// <returns>the US-ASCII string representation of this URI.</returns>
		public string toASCIIString()
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder();
			ASCII_ONLY.appendEncoded(result, ToString());
			return result.ToString();
		}

		/// <summary>Returns the encoded URI.</summary>
		/// <remarks>Returns the encoded URI.</remarks>
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			if (@string != null)
			{
				return @string;
			}
			java.lang.StringBuilder result = new java.lang.StringBuilder();
			if (scheme != null)
			{
				result.append(scheme);
				result.append(':');
			}
			if (opaque)
			{
				result.append(schemeSpecificPart);
			}
			else
			{
				if (authority != null)
				{
					result.append("//");
					result.append(authority);
				}
				if (path != null)
				{
					result.append(path);
				}
				if (query != null)
				{
					result.append('?');
					result.append(query);
				}
			}
			if (fragment != null)
			{
				result.append('#');
				result.append(fragment);
			}
			@string = result.ToString();
			return @string;
		}

		private string getHashString()
		{
			java.lang.StringBuilder result = new java.lang.StringBuilder();
			if (scheme != null)
			{
				result.append(scheme.ToLower(System.Globalization.CultureInfo.InvariantCulture));
				result.append(':');
			}
			if (opaque)
			{
				result.append(schemeSpecificPart);
			}
			else
			{
				if (authority != null)
				{
					result.append("//");
					if (host == null)
					{
						result.append(authority);
					}
					else
					{
						if (userInfo != null)
						{
							result.append(userInfo + "@");
						}
						result.append(host.ToLower(System.Globalization.CultureInfo.InvariantCulture));
						if (port != -1)
						{
							result.append(":" + port);
						}
					}
				}
				if (path != null)
				{
					result.append(path);
				}
				if (query != null)
				{
					result.append('?');
					result.append(query);
				}
			}
			if (fragment != null)
			{
				result.append('#');
				result.append(fragment);
			}
			return convertHexToLowerCase(result.ToString());
		}

		[Sharpen.Stub]
		public java.net.URL toURL()
		{
			throw new System.NotImplementedException();
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void readObject(java.io.ObjectInputStream @in)
		{
			@in.defaultReadObject();
			try
			{
				parseURI(@string, false);
			}
			catch (java.net.URISyntaxException e)
			{
				throw new System.IO.IOException(e.ToString());
			}
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		private void writeObject(java.io.ObjectOutputStream @out)
		{
			// call toString() to ensure the value of string field is calculated
			ToString();
			@out.defaultWriteObject();
		}
	}
}
