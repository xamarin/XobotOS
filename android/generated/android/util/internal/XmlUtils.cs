using Sharpen;

namespace android.util.@internal
{
	/// <summary>
	/// <hide></hide>
	/// 
	/// </summary>
	[Sharpen.Sharpened]
	public class XmlUtils
	{
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void skipCurrentTag(org.xmlpull.v1.XmlPullParser parser)
		{
			int outerDepth = parser.getDepth();
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 (type != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser.getDepth() > outerDepth
				))
			{
			}
		}

		public static int convertValueToList(java.lang.CharSequence value, string[] options
			, int defaultValue)
		{
			if (null != value)
			{
				{
					for (int i = 0; i < options.Length; i++)
					{
						if (value.Equals(options[i]))
						{
							return i;
						}
					}
				}
			}
			return defaultValue;
		}

		public static bool convertValueToBoolean(java.lang.CharSequence value, bool defaultValue
			)
		{
			bool result = false;
			if (null == value)
			{
				return defaultValue;
			}
			if (value.Equals("1") || value.Equals("true") || value.Equals("TRUE"))
			{
				result = true;
			}
			return result;
		}

		public static int convertValueToInt(java.lang.CharSequence charSeq, int defaultValue
			)
		{
			if (null == charSeq)
			{
				return defaultValue;
			}
			string nm = charSeq.ToString();
			// XXX This code is copied from Integer.decode() so we don't
			// have to instantiate an Integer!
			int value;
			int sign = 1;
			int index = 0;
			int len = nm.Length;
			int @base = 10;
			if ('-' == nm[0])
			{
				sign = -1;
				index++;
			}
			if ('0' == nm[index])
			{
				//  Quick check for a zero by itself
				if (index == (len - 1))
				{
					return 0;
				}
				char c = nm[index + 1];
				if ('x' == c || 'X' == c)
				{
					index += 2;
					@base = 16;
				}
				else
				{
					index++;
					@base = 8;
				}
			}
			else
			{
				if ('#' == nm[index])
				{
					index++;
					@base = 16;
				}
			}
			return System.Convert.ToInt32(Sharpen.StringHelper.Substring(nm, index), @base) *
				 sign;
		}

		public static int convertValueToUnsignedInt(string value, int defaultValue)
		{
			if (null == value)
			{
				return defaultValue;
			}
			return parseUnsignedIntAttribute(java.lang.CharSequenceProxy.Wrap(value));
		}

		public static int parseUnsignedIntAttribute(java.lang.CharSequence charSeq)
		{
			string value = charSeq.ToString();
			long bits;
			int index = 0;
			int len = value.Length;
			int @base = 10;
			if ('0' == value[index])
			{
				//  Quick check for zero by itself
				if (index == (len - 1))
				{
					return 0;
				}
				char c = value[index + 1];
				if ('x' == c || 'X' == c)
				{
					//  check for hex
					index += 2;
					@base = 16;
				}
				else
				{
					//  check for octal
					index++;
					@base = 8;
				}
			}
			else
			{
				if ('#' == value[index])
				{
					index++;
					@base = 16;
				}
			}
			return (int)Sharpen.Util.ParseLong(Sharpen.StringHelper.Substring(value, index), 
				@base);
		}

		[Sharpen.Stub]
		public static void writeMapXml(java.util.Map<object, object> val, java.io.OutputStream
			 @out)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Flatten a List into an output stream as XML.</summary>
		/// <remarks>
		/// Flatten a List into an output stream as XML.  The list can later be
		/// read back with readListXml().
		/// </remarks>
		/// <param name="val">The list to be flattened.</param>
		/// <param name="out">Where to write the XML data.</param>
		/// <seealso cref="writeListXml(java.util.List{E}, string, org.xmlpull.v1.XmlSerializer)
		/// 	">writeListXml(java.util.List&lt;E&gt;, string, org.xmlpull.v1.XmlSerializer)</seealso>
		/// <seealso cref="writeMapXml(java.util.Map{K, V}, java.io.OutputStream)">writeMapXml(java.util.Map&lt;K, V&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)">writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)
		/// 	</seealso>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeListXml(java.util.List<object> val, java.io.OutputStream 
			@out)
		{
			org.xmlpull.v1.XmlSerializer serializer = android.util.Xml.newSerializer();
			serializer.setOutput(@out, "utf-8");
			serializer.startDocument(null, true);
			serializer.setFeature("http://xmlpull.org/v1/doc/features.html#indent-output", true
				);
			writeListXml(val, null, serializer);
			serializer.endDocument();
		}

		[Sharpen.Stub]
		public static void writeMapXml(java.util.Map<object, object> val, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Flatten a List into an XmlSerializer.</summary>
		/// <remarks>
		/// Flatten a List into an XmlSerializer.  The list can later be read back
		/// with readThisListXml().
		/// </remarks>
		/// <param name="val">The list to be flattened.</param>
		/// <param name="name">
		/// Name attribute to include with this list's tag, or null for
		/// none.
		/// </param>
		/// <param name="out">XmlSerializer to write the list into.</param>
		/// <seealso cref="writeListXml(java.util.List{E}, java.io.OutputStream)">writeListXml(java.util.List&lt;E&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeMapXml(java.util.Map{K, V}, java.io.OutputStream)">writeMapXml(java.util.Map&lt;K, V&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)">writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)
		/// 	</seealso>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeListXml(java.util.List<object> val, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			if (val == null)
			{
				@out.startTag(null, "null");
				@out.endTag(null, "null");
				return;
			}
			@out.startTag(null, "list");
			if (name != null)
			{
				@out.attribute(null, "name", name);
			}
			int N = val.size();
			int i = 0;
			while (i < N)
			{
				writeValueXml(val.get(i), null, @out);
				i++;
			}
			@out.endTag(null, "list");
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeSetXml(java.util.Set<object> val, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			if (val == null)
			{
				@out.startTag(null, "null");
				@out.endTag(null, "null");
				return;
			}
			@out.startTag(null, "set");
			if (name != null)
			{
				@out.attribute(null, "name", name);
			}
			foreach (object v in Sharpen.IterableProxy.Create(val))
			{
				writeValueXml(v, null, @out);
			}
			@out.endTag(null, "set");
		}

		/// <summary>Flatten a byte[] into an XmlSerializer.</summary>
		/// <remarks>
		/// Flatten a byte[] into an XmlSerializer.  The list can later be read back
		/// with readThisByteArrayXml().
		/// </remarks>
		/// <param name="val">The byte array to be flattened.</param>
		/// <param name="name">
		/// Name attribute to include with this array's tag, or null for
		/// none.
		/// </param>
		/// <param name="out">XmlSerializer to write the array into.</param>
		/// <seealso cref="writeMapXml(java.util.Map{K, V}, java.io.OutputStream)">writeMapXml(java.util.Map&lt;K, V&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)">writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeByteArrayXml(byte[] val, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			if (val == null)
			{
				@out.startTag(null, "null");
				@out.endTag(null, "null");
				return;
			}
			@out.startTag(null, "byte-array");
			if (name != null)
			{
				@out.attribute(null, "name", name);
			}
			int N = val.Length;
			@out.attribute(null, "num", System.Convert.ToString(N));
			java.lang.StringBuilder sb = new java.lang.StringBuilder(val.Length * 2);
			{
				for (int i = 0; i < N; i++)
				{
					int b = val[i];
					int h = b >> 4;
					sb.append(h >= 10 ? ('a' + h - 10) : ('0' + h));
					h = b & unchecked((int)(0xff));
					sb.append(h >= 10 ? ('a' + h - 10) : ('0' + h));
				}
			}
			@out.text(sb.ToString());
			@out.endTag(null, "byte-array");
		}

		/// <summary>Flatten an int[] into an XmlSerializer.</summary>
		/// <remarks>
		/// Flatten an int[] into an XmlSerializer.  The list can later be read back
		/// with readThisIntArrayXml().
		/// </remarks>
		/// <param name="val">The int array to be flattened.</param>
		/// <param name="name">
		/// Name attribute to include with this array's tag, or null for
		/// none.
		/// </param>
		/// <param name="out">XmlSerializer to write the array into.</param>
		/// <seealso cref="writeMapXml(java.util.Map{K, V}, java.io.OutputStream)">writeMapXml(java.util.Map&lt;K, V&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)">writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)
		/// 	</seealso>
		/// <seealso cref="readThisIntArrayXml(org.xmlpull.v1.XmlPullParser, string, string[])
		/// 	">readThisIntArrayXml(org.xmlpull.v1.XmlPullParser, string, string[])</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeIntArrayXml(int[] val, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			if (val == null)
			{
				@out.startTag(null, "null");
				@out.endTag(null, "null");
				return;
			}
			@out.startTag(null, "int-array");
			if (name != null)
			{
				@out.attribute(null, "name", name);
			}
			int N = val.Length;
			@out.attribute(null, "num", System.Convert.ToString(N));
			{
				for (int i = 0; i < N; i++)
				{
					@out.startTag(null, "item");
					@out.attribute(null, "value", System.Convert.ToString(val[i]));
					@out.endTag(null, "item");
				}
			}
			@out.endTag(null, "int-array");
		}

		/// <summary>Flatten an object's value into an XmlSerializer.</summary>
		/// <remarks>
		/// Flatten an object's value into an XmlSerializer.  The value can later
		/// be read back with readThisValueXml().
		/// Currently supported value types are: null, String, Integer, Long,
		/// Float, Double Boolean, Map, List.
		/// </remarks>
		/// <param name="v">The object to be flattened.</param>
		/// <param name="name">
		/// Name attribute to include with this value's tag, or null
		/// for none.
		/// </param>
		/// <param name="out">XmlSerializer to write the object into.</param>
		/// <seealso cref="writeMapXml(java.util.Map{K, V}, java.io.OutputStream)">writeMapXml(java.util.Map&lt;K, V&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="writeListXml(java.util.List{E}, java.io.OutputStream)">writeListXml(java.util.List&lt;E&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <seealso cref="readValueXml(org.xmlpull.v1.XmlPullParser, string[])">readValueXml(org.xmlpull.v1.XmlPullParser, string[])
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void writeValueXml(object v, string name, org.xmlpull.v1.XmlSerializer
			 @out)
		{
			string typeStr;
			if (v == null)
			{
				@out.startTag(null, "null");
				if (name != null)
				{
					@out.attribute(null, "name", name);
				}
				@out.endTag(null, "null");
				return;
			}
			else
			{
				if (v is string)
				{
					@out.startTag(null, "string");
					if (name != null)
					{
						@out.attribute(null, "name", name);
					}
					@out.text(v.ToString());
					@out.endTag(null, "string");
					return;
				}
				else
				{
					if (v is int)
					{
						typeStr = "int";
					}
					else
					{
						if (v is long)
						{
							typeStr = "long";
						}
						else
						{
							if (v is float)
							{
								typeStr = "float";
							}
							else
							{
								if (v is double)
								{
									typeStr = "double";
								}
								else
								{
									if (v is bool)
									{
										typeStr = "boolean";
									}
									else
									{
										if (v is byte[])
										{
											writeByteArrayXml((byte[])v, name, @out);
											return;
										}
										else
										{
											if (v is int[])
											{
												writeIntArrayXml((int[])v, name, @out);
												return;
											}
											else
											{
												if (v is java.util.Map<object, object>)
												{
													writeMapXml((java.util.Map<object, object>)v, name, @out);
													return;
												}
												else
												{
													if (v is java.util.List<object>)
													{
														writeListXml((java.util.List<object>)v, name, @out);
														return;
													}
													else
													{
														if (v is java.util.Set<object>)
														{
															writeSetXml((java.util.Set<object>)v, name, @out);
															return;
														}
														else
														{
															if (v is java.lang.CharSequence)
															{
																// XXX This is to allow us to at least write something if
																// we encounter styled text...  but it means we will drop all
																// of the styling information. :(
																@out.startTag(null, "string");
																if (name != null)
																{
																	@out.attribute(null, "name", name);
																}
																@out.text(v.ToString());
																@out.endTag(null, "string");
																return;
															}
															else
															{
																throw new java.lang.RuntimeException("writeValueXml: unable to write value " + v);
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			@out.startTag(null, typeStr);
			if (name != null)
			{
				@out.attribute(null, "name", name);
			}
			@out.attribute(null, "value", v.ToString());
			@out.endTag(null, typeStr);
		}

		/// <summary>Read a HashMap from an InputStream containing XML.</summary>
		/// <remarks>
		/// Read a HashMap from an InputStream containing XML.  The stream can
		/// previously have been written by writeMapXml().
		/// </remarks>
		/// <param name="in">The InputStream from which to read.</param>
		/// <returns>HashMap The resulting map.</returns>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <seealso cref="readValueXml(org.xmlpull.v1.XmlPullParser, string[])">readValueXml(org.xmlpull.v1.XmlPullParser, string[])
		/// 	</seealso>
		/// <seealso cref="readThisMapXml(org.xmlpull.v1.XmlPullParser, string, string[])">#see #writeMapXml
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static java.util.HashMap<object, object> readMapXml(java.io.InputStream @in
			)
		{
			org.xmlpull.v1.XmlPullParser parser = android.util.Xml.newPullParser();
			parser.setInput(@in, null);
			return (java.util.HashMap<object, object>)readValueXml(parser, new string[1]);
		}

		/// <summary>Read an ArrayList from an InputStream containing XML.</summary>
		/// <remarks>
		/// Read an ArrayList from an InputStream containing XML.  The stream can
		/// previously have been written by writeListXml().
		/// </remarks>
		/// <param name="in">The InputStream from which to read.</param>
		/// <returns>ArrayList The resulting list.</returns>
		/// <seealso cref="readMapXml(java.io.InputStream)">readMapXml(java.io.InputStream)</seealso>
		/// <seealso cref="readValueXml(org.xmlpull.v1.XmlPullParser, string[])">readValueXml(org.xmlpull.v1.XmlPullParser, string[])
		/// 	</seealso>
		/// <seealso cref="readThisListXml(org.xmlpull.v1.XmlPullParser, string, string[])">readThisListXml(org.xmlpull.v1.XmlPullParser, string, string[])
		/// 	</seealso>
		/// <seealso cref="writeListXml(java.util.List{E}, java.io.OutputStream)">writeListXml(java.util.List&lt;E&gt;, java.io.OutputStream)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static java.util.ArrayList<object> readListXml(java.io.InputStream @in)
		{
			org.xmlpull.v1.XmlPullParser parser = android.util.Xml.newPullParser();
			parser.setInput(@in, null);
			return (java.util.ArrayList<object>)readValueXml(parser, new string[1]);
		}

		/// <summary>Read a HashSet from an InputStream containing XML.</summary>
		/// <remarks>
		/// Read a HashSet from an InputStream containing XML. The stream can
		/// previously have been written by writeSetXml().
		/// </remarks>
		/// <param name="in">The InputStream from which to read.</param>
		/// <returns>HashSet The resulting set.</returns>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException">org.xmlpull.v1.XmlPullParserException
		/// 	</exception>
		/// <exception cref="System.IO.IOException">System.IO.IOException</exception>
		/// <seealso cref="readValueXml(org.xmlpull.v1.XmlPullParser, string[])">readValueXml(org.xmlpull.v1.XmlPullParser, string[])
		/// 	</seealso>
		/// <seealso cref="readThisSetXml(org.xmlpull.v1.XmlPullParser, string, string[])">readThisSetXml(org.xmlpull.v1.XmlPullParser, string, string[])
		/// 	</seealso>
		/// <seealso cref="writeSetXml(java.util.Set{E}, string, org.xmlpull.v1.XmlSerializer)
		/// 	">writeSetXml(java.util.Set&lt;E&gt;, string, org.xmlpull.v1.XmlSerializer)</seealso>
		public static java.util.HashSet<object> readSetXml(java.io.InputStream @in)
		{
			org.xmlpull.v1.XmlPullParser parser = android.util.Xml.newPullParser();
			parser.setInput(@in, null);
			return (java.util.HashSet<object>)readValueXml(parser, new string[1]);
		}

		/// <summary>Read a HashMap object from an XmlPullParser.</summary>
		/// <remarks>
		/// Read a HashMap object from an XmlPullParser.  The XML data could
		/// previously have been generated by writeMapXml().  The XmlPullParser
		/// must be positioned <em>after</em> the tag that begins the map.
		/// </remarks>
		/// <param name="parser">The XmlPullParser from which to read the map data.</param>
		/// <param name="endTag">Name of the tag that will end the map, usually "map".</param>
		/// <param name="name">
		/// An array of one string, used to return the name attribute
		/// of the map's tag.
		/// </param>
		/// <returns>HashMap The newly generated map.</returns>
		/// <seealso cref="readMapXml(java.io.InputStream)">readMapXml(java.io.InputStream)</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static java.util.HashMap<object, object> readThisMapXml(org.xmlpull.v1.XmlPullParser
			 parser, string endTag, string[] name)
		{
			java.util.HashMap<object, object> map = new java.util.HashMap<object, object>();
			int eventType = parser.getEventType();
			do
			{
				if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					object val = readThisValueXml(parser, name);
					if (name[0] != null)
					{
						//System.out.println("Adding to map: " + name + " -> " + val);
						map.put(name[0], val);
					}
					else
					{
						throw new org.xmlpull.v1.XmlPullParserException("Map value without name attribute: "
							 + parser.getName());
					}
				}
				else
				{
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						if (parser.getName().Equals(endTag))
						{
							return map;
						}
						throw new org.xmlpull.v1.XmlPullParserException("Expected " + endTag + " end tag at: "
							 + parser.getName());
					}
				}
				eventType = parser.next();
			}
			while (eventType != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT);
			throw new org.xmlpull.v1.XmlPullParserException("Document ended before " + endTag
				 + " end tag");
		}

		/// <summary>Read an ArrayList object from an XmlPullParser.</summary>
		/// <remarks>
		/// Read an ArrayList object from an XmlPullParser.  The XML data could
		/// previously have been generated by writeListXml().  The XmlPullParser
		/// must be positioned <em>after</em> the tag that begins the list.
		/// </remarks>
		/// <param name="parser">The XmlPullParser from which to read the list data.</param>
		/// <param name="endTag">Name of the tag that will end the list, usually "list".</param>
		/// <param name="name">
		/// An array of one string, used to return the name attribute
		/// of the list's tag.
		/// </param>
		/// <returns>HashMap The newly generated list.</returns>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static java.util.ArrayList<object> readThisListXml(org.xmlpull.v1.XmlPullParser
			 parser, string endTag, string[] name)
		{
			java.util.ArrayList<object> list = new java.util.ArrayList<object>();
			int eventType = parser.getEventType();
			do
			{
				if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					object val = readThisValueXml(parser, name);
					list.add(val);
				}
				else
				{
					//System.out.println("Adding to list: " + val);
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						if (parser.getName().Equals(endTag))
						{
							return list;
						}
						throw new org.xmlpull.v1.XmlPullParserException("Expected " + endTag + " end tag at: "
							 + parser.getName());
					}
				}
				eventType = parser.next();
			}
			while (eventType != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT);
			throw new org.xmlpull.v1.XmlPullParserException("Document ended before " + endTag
				 + " end tag");
		}

		/// <summary>Read a HashSet object from an XmlPullParser.</summary>
		/// <remarks>
		/// Read a HashSet object from an XmlPullParser. The XML data could previously
		/// have been generated by writeSetXml(). The XmlPullParser must be positioned
		/// <em>after</em> the tag that begins the set.
		/// </remarks>
		/// <param name="parser">The XmlPullParser from which to read the set data.</param>
		/// <param name="endTag">Name of the tag that will end the set, usually "set".</param>
		/// <param name="name">
		/// An array of one string, used to return the name attribute
		/// of the set's tag.
		/// </param>
		/// <returns>HashSet The newly generated set.</returns>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException">org.xmlpull.v1.XmlPullParserException
		/// 	</exception>
		/// <exception cref="System.IO.IOException">System.IO.IOException</exception>
		/// <seealso cref="readSetXml(java.io.InputStream)">readSetXml(java.io.InputStream)</seealso>
		public static java.util.HashSet<object> readThisSetXml(org.xmlpull.v1.XmlPullParser
			 parser, string endTag, string[] name)
		{
			java.util.HashSet<object> set = new java.util.HashSet<object>();
			int eventType = parser.getEventType();
			do
			{
				if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					object val = readThisValueXml(parser, name);
					set.add(val);
				}
				else
				{
					//System.out.println("Adding to set: " + val);
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						if (parser.getName().Equals(endTag))
						{
							return set;
						}
						throw new org.xmlpull.v1.XmlPullParserException("Expected " + endTag + " end tag at: "
							 + parser.getName());
					}
				}
				eventType = parser.next();
			}
			while (eventType != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT);
			throw new org.xmlpull.v1.XmlPullParserException("Document ended before " + endTag
				 + " end tag");
		}

		/// <summary>Read an int[] object from an XmlPullParser.</summary>
		/// <remarks>
		/// Read an int[] object from an XmlPullParser.  The XML data could
		/// previously have been generated by writeIntArrayXml().  The XmlPullParser
		/// must be positioned <em>after</em> the tag that begins the list.
		/// </remarks>
		/// <param name="parser">The XmlPullParser from which to read the list data.</param>
		/// <param name="endTag">Name of the tag that will end the list, usually "list".</param>
		/// <param name="name">
		/// An array of one string, used to return the name attribute
		/// of the list's tag.
		/// </param>
		/// <returns>Returns a newly generated int[].</returns>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static int[] readThisIntArrayXml(org.xmlpull.v1.XmlPullParser parser, string
			 endTag, string[] name)
		{
			int num;
			try
			{
				num = System.Convert.ToInt32(parser.getAttributeValue(null, "num"));
			}
			catch (System.ArgumentNullException)
			{
				throw new org.xmlpull.v1.XmlPullParserException("Need num attribute in byte-array"
					);
			}
			catch (System.ArgumentException)
			{
				throw new org.xmlpull.v1.XmlPullParserException("Not a number in num attribute in byte-array"
					);
			}
			int[] array = new int[num];
			int i = 0;
			int eventType = parser.getEventType();
			do
			{
				if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					if (parser.getName().Equals("item"))
					{
						try
						{
							array[i] = System.Convert.ToInt32(parser.getAttributeValue(null, "value"));
						}
						catch (System.ArgumentNullException)
						{
							throw new org.xmlpull.v1.XmlPullParserException("Need value attribute in item");
						}
						catch (System.ArgumentException)
						{
							throw new org.xmlpull.v1.XmlPullParserException("Not a number in value attribute in item"
								);
						}
					}
					else
					{
						throw new org.xmlpull.v1.XmlPullParserException("Expected item tag at: " + parser
							.getName());
					}
				}
				else
				{
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						if (parser.getName().Equals(endTag))
						{
							return array;
						}
						else
						{
							if (parser.getName().Equals("item"))
							{
								i++;
							}
							else
							{
								throw new org.xmlpull.v1.XmlPullParserException("Expected " + endTag + " end tag at: "
									 + parser.getName());
							}
						}
					}
				}
				eventType = parser.next();
			}
			while (eventType != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT);
			throw new org.xmlpull.v1.XmlPullParserException("Document ended before " + endTag
				 + " end tag");
		}

		/// <summary>Read a flattened object from an XmlPullParser.</summary>
		/// <remarks>
		/// Read a flattened object from an XmlPullParser.  The XML data could
		/// previously have been written with writeMapXml(), writeListXml(), or
		/// writeValueXml().  The XmlPullParser must be positioned <em>at</em> the
		/// tag that defines the value.
		/// </remarks>
		/// <param name="parser">The XmlPullParser from which to read the object.</param>
		/// <param name="name">
		/// An array of one string, used to return the name attribute
		/// of the value's tag.
		/// </param>
		/// <returns>Object The newly generated value object.</returns>
		/// <seealso cref="readMapXml(java.io.InputStream)">readMapXml(java.io.InputStream)</seealso>
		/// <seealso cref="readListXml(java.io.InputStream)">readListXml(java.io.InputStream)
		/// 	</seealso>
		/// <seealso cref="writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)">writeValueXml(object, string, org.xmlpull.v1.XmlSerializer)
		/// 	</seealso>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static object readValueXml(org.xmlpull.v1.XmlPullParser parser, string[] name
			)
		{
			int eventType = parser.getEventType();
			do
			{
				if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					return readThisValueXml(parser, name);
				}
				else
				{
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						throw new org.xmlpull.v1.XmlPullParserException("Unexpected end tag at: " + parser
							.getName());
					}
					else
					{
						if (eventType == org.xmlpull.v1.XmlPullParserClass.TEXT)
						{
							throw new org.xmlpull.v1.XmlPullParserException("Unexpected text: " + parser.getText
								());
						}
					}
				}
				eventType = parser.next();
			}
			while (eventType != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT);
			throw new org.xmlpull.v1.XmlPullParserException("Unexpected end of document");
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static object readThisValueXml(org.xmlpull.v1.XmlPullParser parser, string
			[] name)
		{
			string valueName = parser.getAttributeValue(null, "name");
			string tagName = parser.getName();
			//System.out.println("Reading this value tag: " + tagName + ", name=" + valueName);
			object res;
			if (tagName.Equals("null"))
			{
				res = null;
			}
			else
			{
				if (tagName.Equals("string"))
				{
					string value = string.Empty;
					int eventType;
					while ((eventType = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
						)
					{
						if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
						{
							if (parser.getName().Equals("string"))
							{
								name[0] = valueName;
								//System.out.println("Returning value for " + valueName + ": " + value);
								return value;
							}
							throw new org.xmlpull.v1.XmlPullParserException("Unexpected end tag in <string>: "
								 + parser.getName());
						}
						else
						{
							if (eventType == org.xmlpull.v1.XmlPullParserClass.TEXT)
							{
								value += parser.getText();
							}
							else
							{
								if (eventType == org.xmlpull.v1.XmlPullParserClass.START_TAG)
								{
									throw new org.xmlpull.v1.XmlPullParserException("Unexpected start tag in <string>: "
										 + parser.getName());
								}
							}
						}
					}
					throw new org.xmlpull.v1.XmlPullParserException("Unexpected end of document in <string>"
						);
				}
				else
				{
					if (tagName.Equals("int"))
					{
						res = System.Convert.ToInt32(parser.getAttributeValue(null, "value"));
					}
					else
					{
						if (tagName.Equals("long"))
						{
							res = long.Parse(parser.getAttributeValue(null, "value"));
						}
						else
						{
							if (tagName.Equals("float"))
							{
								res = System.Convert.ToSingle(parser.getAttributeValue(null, "value"));
							}
							else
							{
								if (tagName.Equals("double"))
								{
									res = System.Convert.ToDouble(parser.getAttributeValue(null, "value"));
								}
								else
								{
									if (tagName.Equals("boolean"))
									{
										res = bool.Parse(parser.getAttributeValue(null, "value"));
									}
									else
									{
										if (tagName.Equals("int-array"))
										{
											parser.next();
											res = readThisIntArrayXml(parser, "int-array", name);
											name[0] = valueName;
											//System.out.println("Returning value for " + valueName + ": " + res);
											return res;
										}
										else
										{
											if (tagName.Equals("map"))
											{
												parser.next();
												res = readThisMapXml(parser, "map", name);
												name[0] = valueName;
												//System.out.println("Returning value for " + valueName + ": " + res);
												return res;
											}
											else
											{
												if (tagName.Equals("list"))
												{
													parser.next();
													res = readThisListXml(parser, "list", name);
													name[0] = valueName;
													//System.out.println("Returning value for " + valueName + ": " + res);
													return res;
												}
												else
												{
													if (tagName.Equals("set"))
													{
														parser.next();
														res = readThisSetXml(parser, "set", name);
														name[0] = valueName;
														//System.out.println("Returning value for " + valueName + ": " + res);
														return res;
													}
													else
													{
														throw new org.xmlpull.v1.XmlPullParserException("Unknown tag: " + tagName);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			// Skip through to end tag.
			int eventType_1;
			while ((eventType_1 = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
				)
			{
				if (eventType_1 == org.xmlpull.v1.XmlPullParserClass.END_TAG)
				{
					if (parser.getName().Equals(tagName))
					{
						name[0] = valueName;
						//System.out.println("Returning value for " + valueName + ": " + res);
						return res;
					}
					throw new org.xmlpull.v1.XmlPullParserException("Unexpected end tag in <" + tagName
						 + ">: " + parser.getName());
				}
				else
				{
					if (eventType_1 == org.xmlpull.v1.XmlPullParserClass.TEXT)
					{
						throw new org.xmlpull.v1.XmlPullParserException("Unexpected text in <" + tagName 
							+ ">: " + parser.getName());
					}
					else
					{
						if (eventType_1 == org.xmlpull.v1.XmlPullParserClass.START_TAG)
						{
							throw new org.xmlpull.v1.XmlPullParserException("Unexpected start tag in <" + tagName
								 + ">: " + parser.getName());
						}
					}
				}
			}
			throw new org.xmlpull.v1.XmlPullParserException("Unexpected end of document in <"
				 + tagName + ">");
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void beginDocument(org.xmlpull.v1.XmlPullParser parser, string firstElementName
			)
		{
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
			if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
			{
				throw new org.xmlpull.v1.XmlPullParserException("No start tag found");
			}
			if (!parser.getName().Equals(firstElementName))
			{
				throw new org.xmlpull.v1.XmlPullParserException("Unexpected start tag: found " + 
					parser.getName() + ", expected " + firstElementName);
			}
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static void nextElement(org.xmlpull.v1.XmlPullParser parser)
		{
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
		}
	}
}
