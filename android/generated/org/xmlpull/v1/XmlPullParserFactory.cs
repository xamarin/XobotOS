using Sharpen;

namespace org.xmlpull.v1
{
	/// <summary>This class is used to create implementations of XML Pull Parser defined in XMPULL V1 API.
	/// 	</summary>
	/// <remarks>
	/// This class is used to create implementations of XML Pull Parser defined in XMPULL V1 API.
	/// The name of actual factory class will be determined based on several parameters.
	/// It works similar to JAXP but tailored to work in J2ME environments
	/// (no access to system properties or file system) so name of parser class factory to use
	/// and its class used for loading (no class loader - on J2ME no access to context class loaders)
	/// must be passed explicitly. If no name of parser factory was passed (or is null)
	/// it will try to find name by searching in CLASSPATH for
	/// META-INF/services/org.xmlpull.v1.XmlPullParserFactory resource that should contain
	/// a comma separated list of class names of factories or parsers to try (in order from
	/// left to the right). If none found, it will throw an exception.
	/// <br /><strong>NOTE:</strong>In J2SE or J2EE environments, you may want to use
	/// <code>newInstance(property, classLoaderCtx)</code>
	/// where first argument is
	/// <code>System.getProperty(XmlPullParserFactory.PROPERTY_NAME)</code>
	/// and second is <code>Thread.getContextClassLoader().getClass()</code> .
	/// </remarks>
	/// <seealso cref="XmlPullParser">XmlPullParser</seealso>
	/// <author><a href="http://www.extreme.indiana.edu/~aslom/">Aleksander Slominski</a>
	/// 	</author>
	/// <author>Stefan Haustein</author>
	[Sharpen.Sharpened]
	public class XmlPullParserFactory
	{
		/// <summary>used as default class to server as context class in newInstance()</summary>
		internal static readonly System.Type referenceContextClass;

		static XmlPullParserFactory()
		{
			// for license please see accompanying LICENSE.txt file (available also at http://www.xmlpull.org/)
			org.xmlpull.v1.XmlPullParserFactory f = new org.xmlpull.v1.XmlPullParserFactory();
			referenceContextClass = f.GetType();
		}

		/// <summary>
		/// Name of the system or midlet property that should be used for
		/// a system property containing a comma separated list of factory
		/// or parser class names (value:
		/// org.xmlpull.v1.XmlPullParserFactory).
		/// </summary>
		/// <remarks>
		/// Name of the system or midlet property that should be used for
		/// a system property containing a comma separated list of factory
		/// or parser class names (value:
		/// org.xmlpull.v1.XmlPullParserFactory).
		/// </remarks>
		public const string PROPERTY_NAME = "org.xmlpull.v1.XmlPullParserFactory";

		private static readonly string RESOURCE_NAME = "/META-INF/services/" + PROPERTY_NAME;

		protected internal java.util.ArrayList<object> parserClasses;

		protected internal string classNamesLocation;

		protected internal java.util.ArrayList<object> serializerClasses;

		protected internal java.util.HashMap<object, object> features = new java.util.HashMap
			<object, object>();

		/// <summary>Protected constructor to be called by factory implementations.</summary>
		/// <remarks>Protected constructor to be called by factory implementations.</remarks>
		protected internal XmlPullParserFactory()
		{
		}

		// public static final String DEFAULT_PROPERTY =
		//    "org.xmlpull.xpp3.XmlPullParser,org.kxml2.io.KXmlParser";
		// features are kept there
		/// <summary>Set the features to be set when XML Pull Parser is created by this factory.
		/// 	</summary>
		/// <remarks>
		/// Set the features to be set when XML Pull Parser is created by this factory.
		/// <p><b>NOTE:</b> factory features are not used for XML Serializer.
		/// </remarks>
		/// <param name="name">string with URI identifying feature</param>
		/// <param name="state">if true feature will be set; if false will be ignored</param>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		public virtual void setFeature(string name, bool state)
		{
			features.put(name, state);
		}

		/// <summary>Return the current value of the feature with given name.</summary>
		/// <remarks>
		/// Return the current value of the feature with given name.
		/// <p><b>NOTE:</b> factory features are not used for XML Serializer.
		/// </remarks>
		/// <param name="name">The name of feature to be retrieved.</param>
		/// <returns>
		/// The value of named feature.
		/// Unknown features are <string>always</strong> returned as false
		/// </returns>
		public virtual bool getFeature(string name)
		{
			bool value = (bool)features.get(name);
			return value != null ? value : false;
		}

		/// <summary>
		/// Specifies that the parser produced by this factory will provide
		/// support for XML namespaces.
		/// </summary>
		/// <remarks>
		/// Specifies that the parser produced by this factory will provide
		/// support for XML namespaces.
		/// By default the value of this is set to false.
		/// </remarks>
		/// <param name="awareness">
		/// true if the parser produced by this code
		/// will provide support for XML namespaces;  false otherwise.
		/// </param>
		public virtual void setNamespaceAware(bool awareness)
		{
			features.put(org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES, awareness
				);
		}

		/// <summary>
		/// Indicates whether or not the factory is configured to produce
		/// parsers which are namespace aware
		/// (it simply set feature XmlPullParser.FEATURE_PROCESS_NAMESPACES to true or false).
		/// </summary>
		/// <remarks>
		/// Indicates whether or not the factory is configured to produce
		/// parsers which are namespace aware
		/// (it simply set feature XmlPullParser.FEATURE_PROCESS_NAMESPACES to true or false).
		/// </remarks>
		/// <returns>
		/// true if the factory is configured to produce parsers
		/// which are namespace aware; false otherwise.
		/// </returns>
		public virtual bool isNamespaceAware()
		{
			return getFeature(org.xmlpull.v1.XmlPullParserClass.FEATURE_PROCESS_NAMESPACES);
		}

		/// <summary>
		/// Specifies that the parser produced by this factory will be validating
		/// (it simply set feature XmlPullParser.FEATURE_VALIDATION to true or false).
		/// </summary>
		/// <remarks>
		/// Specifies that the parser produced by this factory will be validating
		/// (it simply set feature XmlPullParser.FEATURE_VALIDATION to true or false).
		/// By default the value of this is set to false.
		/// </remarks>
		/// <param name="validating">- if true the parsers created by this factory  must be validating.
		/// 	</param>
		public virtual void setValidating(bool validating)
		{
			features.put(org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION, validating);
		}

		/// <summary>
		/// Indicates whether or not the factory is configured to produce parsers
		/// which validate the XML content during parse.
		/// </summary>
		/// <remarks>
		/// Indicates whether or not the factory is configured to produce parsers
		/// which validate the XML content during parse.
		/// </remarks>
		/// <returns>
		/// true if the factory is configured to produce parsers
		/// which validate the XML content during parse; false otherwise.
		/// </returns>
		public virtual bool isValidating()
		{
			return getFeature(org.xmlpull.v1.XmlPullParserClass.FEATURE_VALIDATION);
		}

		/// <summary>
		/// Creates a new instance of a XML Pull Parser
		/// using the currently configured factory features.
		/// </summary>
		/// <remarks>
		/// Creates a new instance of a XML Pull Parser
		/// using the currently configured factory features.
		/// </remarks>
		/// <returns>A new instance of a XML Pull Parser.</returns>
		/// <exception cref="XmlPullParserException">
		/// if a parser cannot be created which satisfies the
		/// requested configuration.
		/// </exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		public virtual org.xmlpull.v1.XmlPullParser newPullParser()
		{
			if (parserClasses == null)
			{
				throw new org.xmlpull.v1.XmlPullParserException("Factory initialization was incomplete - has not tried "
					 + classNamesLocation);
			}
			if (parserClasses.size() == 0)
			{
				throw new org.xmlpull.v1.XmlPullParserException("No valid parser classes found in "
					 + classNamesLocation);
			}
			java.lang.StringBuilder issues = new java.lang.StringBuilder();
			{
				for (int i = 0; i < parserClasses.size(); i++)
				{
					System.Type ppClass = (System.Type)parserClasses.get(i);
					try
					{
						org.xmlpull.v1.XmlPullParser pp = (org.xmlpull.v1.XmlPullParser)System.Activator.CreateInstance
							(ppClass);
						{
							for (java.util.Iterator<object> iter = features.keySet().iterator(); iter.hasNext
								(); )
							{
								string key = (string)iter.next();
								bool value = (bool)features.get(key);
								if (value != null && value)
								{
									pp.setFeature(key, true);
								}
							}
						}
						return pp;
					}
					catch (System.Exception ex)
					{
						issues.append(ppClass.FullName + ": " + ex.ToString() + "; ");
					}
				}
			}
			throw new org.xmlpull.v1.XmlPullParserException("could not create parser: " + issues
				);
		}

		/// <summary>Creates a new instance of a XML Serializer.</summary>
		/// <remarks>
		/// Creates a new instance of a XML Serializer.
		/// <p><b>NOTE:</b> factory features are not used for XML Serializer.
		/// </remarks>
		/// <returns>A new instance of a XML Serializer.</returns>
		/// <exception cref="XmlPullParserException">
		/// if a parser cannot be created which satisfies the
		/// requested configuration.
		/// </exception>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		public virtual org.xmlpull.v1.XmlSerializer newSerializer()
		{
			if (serializerClasses == null)
			{
				throw new org.xmlpull.v1.XmlPullParserException("Factory initialization incomplete - has not tried "
					 + classNamesLocation);
			}
			if (serializerClasses.size() == 0)
			{
				throw new org.xmlpull.v1.XmlPullParserException("No valid serializer classes found in "
					 + classNamesLocation);
			}
			java.lang.StringBuilder issues = new java.lang.StringBuilder();
			{
				for (int i = 0; i < serializerClasses.size(); i++)
				{
					System.Type ppClass = (System.Type)serializerClasses.get(i);
					try
					{
						org.xmlpull.v1.XmlSerializer ser = (org.xmlpull.v1.XmlSerializer)System.Activator.CreateInstance
							(ppClass);
						return ser;
					}
					catch (System.Exception ex)
					{
						issues.append(ppClass.FullName + ": " + ex.ToString() + "; ");
					}
				}
			}
			throw new org.xmlpull.v1.XmlPullParserException("could not create serializer: " +
				 issues);
		}

		/// <summary>
		/// Create a new instance of a PullParserFactory that can be used
		/// to create XML pull parsers (see class description for more
		/// details).
		/// </summary>
		/// <remarks>
		/// Create a new instance of a PullParserFactory that can be used
		/// to create XML pull parsers (see class description for more
		/// details).
		/// </remarks>
		/// <returns>a new instance of a PullParserFactory, as returned by newInstance (null, null);
		/// 	</returns>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		public static org.xmlpull.v1.XmlPullParserFactory newInstance()
		{
			return newInstance(null, null);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		public static org.xmlpull.v1.XmlPullParserFactory newInstance(string classNames, 
			System.Type context)
		{
			classNames = "org.kxml2.io.KXmlParser,org.kxml2.io.KXmlSerializer";
			org.xmlpull.v1.XmlPullParserFactory factory = null;
			java.util.ArrayList<object> parserClasses = new java.util.ArrayList<object>();
			java.util.ArrayList<object> serializerClasses = new java.util.ArrayList<object>();
			int pos = 0;
			while (pos < classNames.Length)
			{
				int cut = classNames.IndexOf(',', pos);
				if (cut == -1)
				{
					cut = classNames.Length;
				}
				string name = Sharpen.StringHelper.Substring(classNames, pos, cut);
				System.Type candidate = null;
				object instance = null;
				try
				{
					candidate = XobotOS.Runtime.Reflection.GetType(name);
					// necessary because of J2ME .class issue
					instance = System.Activator.CreateInstance(candidate);
				}
				catch (System.Exception)
				{
				}
				if (candidate != null)
				{
					bool recognized = false;
					if (instance is org.xmlpull.v1.XmlPullParser)
					{
						parserClasses.add(candidate);
						recognized = true;
					}
					if (instance is org.xmlpull.v1.XmlSerializer)
					{
						serializerClasses.add(candidate);
						recognized = true;
					}
					if (instance is org.xmlpull.v1.XmlPullParserFactory)
					{
						if (factory == null)
						{
							factory = (org.xmlpull.v1.XmlPullParserFactory)instance;
						}
						recognized = true;
					}
					if (!recognized)
					{
						throw new org.xmlpull.v1.XmlPullParserException("incompatible class: " + name);
					}
				}
				pos = cut + 1;
			}
			if (factory == null)
			{
				factory = new org.xmlpull.v1.XmlPullParserFactory();
			}
			factory.parserClasses = parserClasses;
			factory.serializerClasses = serializerClasses;
			factory.classNamesLocation = "org.kxml2.io.kXmlParser,org.kxml2.io.KXmlSerializer";
			return factory;
		}
	}
}
