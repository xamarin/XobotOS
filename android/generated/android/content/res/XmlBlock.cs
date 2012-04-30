using System.Runtime.InteropServices;
using Sharpen;

namespace android.content.res
{
	/// <summary>Wrapper around a compiled XML file.</summary>
	/// <remarks>
	/// Wrapper around a compiled XML file.
	/// <hide></hide>
	/// </remarks>
	[Sharpen.Sharpened]
	internal sealed partial class XmlBlock : System.IDisposable
	{
		internal const bool DEBUG = false;

		[Sharpen.Stub]
		public XmlBlock(byte[] data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public XmlBlock(byte[] data, int offset, int size)
		{
			throw new System.NotImplementedException();
		}

		public void close()
		{
			lock (this)
			{
				if (mOpen)
				{
					mOpen = false;
					decOpenCountLocked();
				}
			}
		}

		public android.content.res.XmlResourceParser newParser()
		{
			lock (this)
			{
				if (mNative != null)
				{
					return new android.content.res.XmlBlock.Parser(this, nativeCreateParseState(mNative
						), this);
				}
				return null;
			}
		}

		internal sealed partial class Parser : android.content.res.XmlResourceParser, System.IDisposable
		{
			internal Parser(XmlBlock _enclosing, android.content.res.XmlBlock.Parser.NativeXmlParser
				 parseState, android.content.res.XmlBlock block)
			{
				this._enclosing = _enclosing;
				mStarted = false;
				mDecNextDepth = false;
				mDepth = 0;
				mEventType = org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT;
				this.mParseState = parseState;
				this.mBlock = block;
				block.mOpenCount++;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void setFeature(string name, bool state)
			{
				if (org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES.Equals(name) && 
					state)
				{
					return;
				}
				if (org.xmlpull.v1.XmlPullParserClass.FEATURE_REPORT_NAMESPACE_ATTRIBUTES.Equals(
					name) && state)
				{
					return;
				}
				throw new org.xmlpull.v1.XmlPullParserException("Unsupported feature: " + name);
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public bool getFeature(string name)
			{
				if (org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES.Equals(name))
				{
					return true;
				}
				if (org.xmlpull.v1.XmlPullParserClass.FEATURE_REPORT_NAMESPACE_ATTRIBUTES.Equals(
					name))
				{
					return true;
				}
				return false;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void setProperty(string name, object value)
			{
				throw new org.xmlpull.v1.XmlPullParserException("setProperty() not supported");
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public object getProperty(string name)
			{
				return null;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void setInput(java.io.Reader @in)
			{
				throw new org.xmlpull.v1.XmlPullParserException("setInput() not supported");
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void setInput(java.io.InputStream inputStream, string inputEncoding)
			{
				throw new org.xmlpull.v1.XmlPullParserException("setInput() not supported");
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void defineEntityReplacementText(string entityName, string replacementText
				)
			{
				throw new org.xmlpull.v1.XmlPullParserException("defineEntityReplacementText() not supported"
					);
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getNamespacePrefix(int pos)
			{
				throw new org.xmlpull.v1.XmlPullParserException("getNamespacePrefix() not supported"
					);
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getInputEncoding()
			{
				return null;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getNamespace(string prefix)
			{
				throw new java.lang.RuntimeException("getNamespace() not supported");
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getNamespaceCount(int depth)
			{
				throw new org.xmlpull.v1.XmlPullParserException("getNamespaceCount() not supported"
					);
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getPositionDescription()
			{
				return "Binary XML file line #" + this.getLineNumber();
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getNamespaceUri(int pos)
			{
				throw new org.xmlpull.v1.XmlPullParserException("getNamespaceUri() not supported"
					);
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getColumnNumber()
			{
				return -1;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getDepth()
			{
				return this.mDepth;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getText()
			{
				int id = android.content.res.XmlBlock.nativeGetText(this.mParseState);
				return id >= 0 ? this._enclosing.mStrings.get(id).ToString() : null;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getLineNumber()
			{
				return android.content.res.XmlBlock.nativeGetLineNumber(this.mParseState);
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getEventType()
			{
				return this.mEventType;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public bool isWhitespace()
			{
				// whitespace was stripped by aapt.
				return false;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getPrefix()
			{
				throw new java.lang.RuntimeException("getPrefix not supported");
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public char[] getTextCharacters(int[] holderForStartAndLength)
			{
				string txt = this.getText();
				char[] chars = null;
				if (txt != null)
				{
					holderForStartAndLength[0] = 0;
					holderForStartAndLength[1] = txt.Length;
					chars = new char[txt.Length];
					Sharpen.StringHelper.GetCharsForString(txt, 0, txt.Length, chars, 0);
				}
				return chars;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getNamespace()
			{
				int id = android.content.res.XmlBlock.nativeGetNamespace(this.mParseState);
				return id >= 0 ? this._enclosing.mStrings.get(id).ToString() : string.Empty;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getName()
			{
				int id = android.content.res.XmlBlock.nativeGetName(this.mParseState);
				return id >= 0 ? this._enclosing.mStrings.get(id).ToString() : null;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributeNamespace(int index)
			{
				int id = android.content.res.XmlBlock.nativeGetAttributeNamespace(this.mParseState
					, index);
				if (id >= 0)
				{
					return this._enclosing.mStrings.get(id).ToString();
				}
				else
				{
					if (id == -1)
					{
						return string.Empty;
					}
				}
				throw new System.IndexOutOfRangeException(index.ToString());
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributeName(int index)
			{
				int id = android.content.res.XmlBlock.nativeGetAttributeName(this.mParseState, index
					);
				if (id >= 0)
				{
					return this._enclosing.mStrings.get(id).ToString();
				}
				throw new System.IndexOutOfRangeException(index.ToString());
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributePrefix(int index)
			{
				throw new java.lang.RuntimeException("getAttributePrefix not supported");
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public bool isEmptyElementTag()
			{
				// XXX Need to detect this.
				return false;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int getAttributeCount()
			{
				return this.mEventType == org.xmlpull.v1.XmlPullParserClass.START_TAG ? android.content.res.XmlBlock
					.nativeGetAttributeCount(this.mParseState) : -1;
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributeValue(int index)
			{
				int id = android.content.res.XmlBlock.nativeGetAttributeStringValue(this.mParseState
					, index);
				if (id >= 0)
				{
					return this._enclosing.mStrings.get(id).ToString();
				}
				// May be some other type...  check and try to convert if so.
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					index);
				if (t == android.util.TypedValue.TYPE_NULL)
				{
					throw new System.IndexOutOfRangeException(index.ToString());
				}
				int v = android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, index
					);
				return android.util.TypedValue.coerceToString(t, v);
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributeType(int index)
			{
				return "CDATA";
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public bool isAttributeDefault(int index)
			{
				return false;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int nextToken()
			{
				return this.next();
			}

			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string getAttributeValue(string @namespace, string name)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, name);
				if (idx >= 0)
				{
					return this.getAttributeValue(idx);
				}
				return null;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int next()
			{
				if (!this.mStarted)
				{
					this.mStarted = true;
					return org.xmlpull.v1.XmlPullParserClass.START_DOCUMENT;
				}
				if (this.mParseState == null)
				{
					return org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT;
				}
				int ev = android.content.res.XmlBlock.nativeNext(this.mParseState);
				if (this.mDecNextDepth)
				{
					this.mDepth--;
					this.mDecNextDepth = false;
				}
				switch (ev)
				{
					case org.xmlpull.v1.XmlPullParserClass.START_TAG:
					{
						this.mDepth++;
						break;
					}

					case org.xmlpull.v1.XmlPullParserClass.END_TAG:
					{
						this.mDecNextDepth = true;
						break;
					}
				}
				this.mEventType = ev;
				if (ev == org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
				{
					// Automatically close the parse when we reach the end of
					// a document, since the standard XmlPullParser interface
					// doesn't have such an API so most clients will leave us
					// dangling.
					this.close();
				}
				return ev;
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public void require(int type, string @namespace, string name)
			{
				if (type != this.getEventType() || (@namespace != null && !@namespace.Equals(this
					.getNamespace())) || (name != null && !name.Equals(this.getName())))
				{
					throw new org.xmlpull.v1.XmlPullParserException("expected " + org.xmlpull.v1.XmlPullParserClass.TYPES
						[type] + this.getPositionDescription());
				}
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public string nextText()
			{
				if (this.getEventType() != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					throw new org.xmlpull.v1.XmlPullParserException(this.getPositionDescription() + ": parser must be on START_TAG to read next text"
						, this, null);
				}
				int eventType = this.next();
				if (eventType == org.xmlpull.v1.XmlPullParserClass.TEXT)
				{
					string result = this.getText();
					eventType = this.next();
					if (eventType != org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						throw new org.xmlpull.v1.XmlPullParserException(this.getPositionDescription() + ": event TEXT it must be immediately followed by END_TAG"
							, this, null);
					}
					return result;
				}
				else
				{
					if (eventType == org.xmlpull.v1.XmlPullParserClass.END_TAG)
					{
						return string.Empty;
					}
					else
					{
						throw new org.xmlpull.v1.XmlPullParserException(this.getPositionDescription() + ": parser must be on START_TAG or TEXT to read text"
							, this, null);
					}
				}
			}

			/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
			/// <exception cref="System.IO.IOException"></exception>
			[Sharpen.ImplementsInterface(@"org.xmlpull.v1.XmlPullParser")]
			public int nextTag()
			{
				int eventType = this.next();
				if (eventType == org.xmlpull.v1.XmlPullParserClass.TEXT && this.isWhitespace())
				{
					// skip whitespace
					eventType = this.next();
				}
				if (eventType != org.xmlpull.v1.XmlPullParserClass.START_TAG && eventType != org.xmlpull.v1.XmlPullParserClass.END_TAG)
				{
					throw new org.xmlpull.v1.XmlPullParserException(this.getPositionDescription() + ": expected start or end tag"
						, this, null);
				}
				return eventType;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeNameResource(int index)
			{
				return android.content.res.XmlBlock.nativeGetAttributeResource(this.mParseState, 
					index);
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeListValue(string @namespace, string attribute, string[] options
				, int defaultValue)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeListValue(idx, options, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public bool getAttributeBooleanValue(string @namespace, string attribute, bool defaultValue
				)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeBooleanValue(idx, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeResourceValue(string @namespace, string attribute, int defaultValue
				)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeResourceValue(idx, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeIntValue(string @namespace, string attribute, int defaultValue
				)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeIntValue(idx, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeUnsignedIntValue(string @namespace, string attribute, int 
				defaultValue)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeUnsignedIntValue(idx, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public float getAttributeFloatValue(string @namespace, string attribute, float defaultValue
				)
			{
				int idx = android.content.res.XmlBlock.nativeGetAttributeIndex(this.mParseState, 
					@namespace, attribute);
				if (idx >= 0)
				{
					return this.getAttributeFloatValue(idx, defaultValue);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeListValue(int idx, string[] options, int defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				int v = android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, idx
					);
				if (t == android.util.TypedValue.TYPE_STRING)
				{
					return android.util.@internal.XmlUtils.convertValueToList(this._enclosing.mStrings
						.get(v), options, defaultValue);
				}
				return v;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public bool getAttributeBooleanValue(int idx, bool defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				// Note: don't attempt to convert any other types, because
				// we want to count on appt doing the conversion for us.
				if (t >= android.util.TypedValue.TYPE_FIRST_INT && t <= android.util.TypedValue.TYPE_LAST_INT)
				{
					return android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, idx)
						 != 0;
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeResourceValue(int idx, int defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				// Note: don't attempt to convert any other types, because
				// we want to count on appt doing the conversion for us.
				if (t == android.util.TypedValue.TYPE_REFERENCE)
				{
					return android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, idx);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeIntValue(int idx, int defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				// Note: don't attempt to convert any other types, because
				// we want to count on appt doing the conversion for us.
				if (t >= android.util.TypedValue.TYPE_FIRST_INT && t <= android.util.TypedValue.TYPE_LAST_INT)
				{
					return android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, idx);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getAttributeUnsignedIntValue(int idx, int defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				// Note: don't attempt to convert any other types, because
				// we want to count on appt doing the conversion for us.
				if (t >= android.util.TypedValue.TYPE_FIRST_INT && t <= android.util.TypedValue.TYPE_LAST_INT)
				{
					return android.content.res.XmlBlock.nativeGetAttributeData(this.mParseState, idx);
				}
				return defaultValue;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public float getAttributeFloatValue(int idx, float defaultValue)
			{
				int t = android.content.res.XmlBlock.nativeGetAttributeDataType(this.mParseState, 
					idx);
				// Note: don't attempt to convert any other types, because
				// we want to count on appt doing the conversion for us.
				if (t == android.util.TypedValue.TYPE_FLOAT)
				{
					return Sharpen.Util.IntBitsToFloat(android.content.res.XmlBlock.nativeGetAttributeData
						(this.mParseState, idx));
				}
				throw new java.lang.RuntimeException("not a float!");
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public string getIdAttribute()
			{
				int id = android.content.res.XmlBlock.nativeGetIdAttribute(this.mParseState);
				return id >= 0 ? this._enclosing.mStrings.get(id).ToString() : null;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public string getClassAttribute()
			{
				int id = android.content.res.XmlBlock.nativeGetClassAttribute(this.mParseState);
				return id >= 0 ? this._enclosing.mStrings.get(id).ToString() : null;
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getIdAttributeResourceValue(int defaultValue)
			{
				//todo: create and use native method
				return this.getAttributeResourceValue(null, "id", defaultValue);
			}

			[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
			public int getStyleAttribute()
			{
				return android.content.res.XmlBlock.nativeGetStyleAttribute(this.mParseState);
			}

			~Parser()
			{
				this.close();
			}

			internal java.lang.CharSequence getPooledString(int id)
			{
				return this._enclosing.mStrings.get(id);
			}

			internal android.content.res.XmlBlock.Parser.NativeXmlParser mParseState;

			private readonly android.content.res.XmlBlock mBlock;

			private bool mStarted;

			private bool mDecNextDepth;

			private int mDepth;

			private int mEventType;

			public void Dispose()
			{
				mParseState.Dispose();
			}

			internal class NativeXmlParser : System.Runtime.InteropServices.SafeHandle
			{
				internal NativeXmlParser() : base(System.IntPtr.Zero, true)
				{
				}

				internal NativeXmlParser(System.IntPtr handle) : base(System.IntPtr.Zero, true)
				{
					this.handle = handle;
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_content_res_XmlBlock_Parser_destructor
					(System.IntPtr handle);

				internal System.IntPtr Handle
				{
					get
					{
						return handle;
					}
				}

				public static readonly NativeXmlParser Zero = new NativeXmlParser();

				protected override bool ReleaseHandle()
				{
					if (handle != System.IntPtr.Zero)
					{
						libxobotos_android_content_res_XmlBlock_Parser_destructor(handle);
					}
					handle = System.IntPtr.Zero;
					return true;
				}

				public override bool IsInvalid
				{
					get
					{
						return handle == System.IntPtr.Zero;
					}
				}
			}

			private readonly XmlBlock _enclosing;
		}

		~XmlBlock()
		{
			close();
		}

		/// <summary>Create from an existing xml block native object.</summary>
		/// <remarks>
		/// Create from an existing xml block native object.  This is
		/// -extremely- dangerous -- only use it if you absolutely know what you
		/// are doing!  The given native object must exist for the entire lifetime
		/// of this newly creating XmlBlock.
		/// </remarks>
		internal XmlBlock(android.content.res.AssetManager assets, android.content.res.XmlBlock.NativeXmlBlock
			 xmlBlock)
		{
			mAssets = assets;
			mNative = xmlBlock;
			mStrings = new android.content.res.StringBlock(nativeGetStringBlock(xmlBlock), false
				);
		}

		private readonly android.content.res.AssetManager mAssets;

		internal readonly android.content.res.XmlBlock.NativeXmlBlock mNative;

		private readonly android.content.res.StringBlock mStrings;

		private bool mOpen = true;

		private int mOpenCount = 1;

		[Sharpen.NativeStub]
		private static int nativeCreate(byte[] data, int offset, int size)
		{
			throw new System.NotImplementedException();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.StringBlock.NativeStringBlock libxobotos_XmlBlock_nativeGetStringBlock
			(android.content.res.XmlBlock.NativeXmlBlock obj);

		private static android.content.res.StringBlock.NativeStringBlock nativeGetStringBlock
			(android.content.res.XmlBlock.NativeXmlBlock obj)
		{
			return libxobotos_XmlBlock_nativeGetStringBlock(obj);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.content.res.XmlBlock.Parser.NativeXmlParser libxobotos_XmlBlock_nativeCreateParseState
			(android.content.res.XmlBlock.NativeXmlBlock obj);

		private static android.content.res.XmlBlock.Parser.NativeXmlParser nativeCreateParseState
			(android.content.res.XmlBlock.NativeXmlBlock obj)
		{
			return libxobotos_XmlBlock_nativeCreateParseState(obj);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_nativeNext(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeNext(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_nativeNext(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getElementNamespaceID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetNamespace(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_getElementNamespaceID(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getElementNameID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetName(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_getElementNameID(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getTextID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetText(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_getTextID(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getLineNumber(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetLineNumber(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_getLineNumber(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeCount(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetAttributeCount(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_getAttributeCount(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeNamespaceID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeNamespace(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeNamespaceID(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeNameID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeName(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeNameID(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeNameResID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeResource(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeNameResID(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeDataType(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeDataType(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeDataType(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeData(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeData(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeData(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_getAttributeValueStringID(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx);

		private static int nativeGetAttributeStringValue(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, int idx)
		{
			return libxobotos_XmlBlock_getAttributeValueStringID(state, idx);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_nativeGetIdAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetIdAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_nativeGetIdAttribute(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_nativeGetClassAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetClassAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_nativeGetClassAttribute(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_nativeGetStyleAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state);

		private static int nativeGetStyleAttribute(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state)
		{
			return libxobotos_XmlBlock_nativeGetStyleAttribute(state);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_XmlBlock_nativeGetAttributeIndex(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, System.IntPtr @namespace, System.IntPtr name);

		private static int nativeGetAttributeIndex(android.content.res.XmlBlock.Parser.NativeXmlParser
			 state, string @namespace, string name)
		{
			System.IntPtr @namespace_ptr = System.IntPtr.Zero;
			System.IntPtr name_ptr = System.IntPtr.Zero;
			try
			{
				@namespace_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(@namespace
					);
				name_ptr = XobotOS.Runtime.MarshalGlue.String_Helper.ManagedToNative(name);
				return libxobotos_XmlBlock_nativeGetAttributeIndex(state, @namespace_ptr, name_ptr
					);
			}
			finally
			{
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(@namespace_ptr);
				XobotOS.Runtime.MarshalGlue.String_Helper.FreeManagedPtr(name_ptr);
			}
		}

		public void Dispose()
		{
			mNative.Dispose();
		}

		internal class NativeXmlBlock : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeXmlBlock() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeXmlBlock(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_content_res_XmlBlock_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeXmlBlock Zero = new NativeXmlBlock();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_content_res_XmlBlock_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
