using Sharpen;

namespace android.view
{
	/// <summary>
	/// This class is used to instantiate layout XML file into its corresponding View
	/// objects.
	/// </summary>
	/// <remarks>
	/// This class is used to instantiate layout XML file into its corresponding View
	/// objects. It is never be used directly -- use
	/// <see cref="android.app.Activity.getLayoutInflater()">android.app.Activity.getLayoutInflater()
	/// 	</see>
	/// or
	/// <see cref="android.content.Context.getSystemService(string)">android.content.Context.getSystemService(string)
	/// 	</see>
	/// to retrieve a standard LayoutInflater instance
	/// that is already hooked up to the current context and correctly configured
	/// for the device you are running on.  For example:
	/// <pre>LayoutInflater inflater = (LayoutInflater)context.getSystemService
	/// (Context.LAYOUT_INFLATER_SERVICE);</pre>
	/// <p>
	/// To create a new LayoutInflater with an additional
	/// <see cref="Factory">Factory</see>
	/// for your
	/// own views, you can use
	/// <see cref="cloneInContext(android.content.Context)">cloneInContext(android.content.Context)
	/// 	</see>
	/// to clone an existing
	/// ViewFactory, and then call
	/// <see cref="setFactory(Factory)">setFactory(Factory)</see>
	/// on it to include your
	/// Factory.
	/// <p>
	/// For performance reasons, view inflation relies heavily on pre-processing of
	/// XML files that is done at build time. Therefore, it is not currently possible
	/// to use LayoutInflater with an XmlPullParser over a plain XML file at runtime;
	/// it only works with an XmlPullParser returned from a compiled resource
	/// (R.<em>something</em> file.)
	/// </remarks>
	/// <seealso cref="android.content.Context.getSystemService(string)">android.content.Context.getSystemService(string)
	/// 	</seealso>
	[Sharpen.Sharpened]
	public abstract class LayoutInflater
	{
		private readonly bool DEBUG = false;

		/// <summary>This field should be made private, so it is hidden from the SDK.</summary>
		/// <remarks>
		/// This field should be made private, so it is hidden from the SDK.
		/// <hide></hide>
		/// </remarks>
		protected internal readonly android.content.Context mContext;

		private bool mFactorySet;

		private android.view.LayoutInflater.Factory mFactory;

		private android.view.LayoutInflater.Factory2 mFactory2;

		private android.view.LayoutInflater.Factory2 mPrivateFactory;

		private android.view.LayoutInflater.Filter mFilter;

		internal readonly object[] mConstructorArgs = new object[2];

		internal static readonly System.Type[] mConstructorSignature = new System.Type[] 
			{ typeof(android.content.Context), typeof(android.util.AttributeSet) };

		private static readonly java.util.HashMap<string, System.Reflection.ConstructorInfo
			> sConstructorMap = new java.util.HashMap<string, System.Reflection.ConstructorInfo
			>();

		private java.util.HashMap<string, bool> mFilterMap;

		internal const string TAG_MERGE = "merge";

		internal const string TAG_INCLUDE = "include";

		internal const string TAG_1995 = "blink";

		internal const string TAG_REQUEST_FOCUS = "requestFocus";

		/// <summary>
		/// Hook to allow clients of the LayoutInflater to restrict the set of Views that are allowed
		/// to be inflated.
		/// </summary>
		/// <remarks>
		/// Hook to allow clients of the LayoutInflater to restrict the set of Views that are allowed
		/// to be inflated.
		/// </remarks>
		public interface Filter
		{
			// these are optional, set by the caller
			/// <summary>
			/// Hook to allow clients of the LayoutInflater to restrict the set of Views
			/// that are allowed to be inflated.
			/// </summary>
			/// <remarks>
			/// Hook to allow clients of the LayoutInflater to restrict the set of Views
			/// that are allowed to be inflated.
			/// </remarks>
			/// <param name="clazz">The class object for the View that is about to be inflated</param>
			/// <returns>True if this class is allowed to be inflated, or false otherwise</returns>
			bool onLoadClass(System.Type clazz);
		}

		public interface Factory
		{
			/// <summary>Hook you can supply that is called when inflating from a LayoutInflater.
			/// 	</summary>
			/// <remarks>
			/// Hook you can supply that is called when inflating from a LayoutInflater.
			/// You can use this to customize the tag names available in your XML
			/// layout files.
			/// <p>
			/// Note that it is good practice to prefix these custom names with your
			/// package (i.e., com.coolcompany.apps) to avoid conflicts with system
			/// names.
			/// </remarks>
			/// <param name="name">Tag name to be inflated.</param>
			/// <param name="context">The context the view is being created in.</param>
			/// <param name="attrs">Inflation attributes as specified in XML file.</param>
			/// <returns>
			/// View Newly created view. Return null for the default
			/// behavior.
			/// </returns>
			android.view.View onCreateView(string name, android.content.Context context, android.util.AttributeSet
				 attrs);
		}

		public interface Factory2 : android.view.LayoutInflater.Factory
		{
			/// <summary>
			/// Version of
			/// <see cref="Factory.onCreateView(string, android.content.Context, android.util.AttributeSet)
			/// 	">Factory.onCreateView(string, android.content.Context, android.util.AttributeSet)
			/// 	</see>
			/// that also supplies the parent that the view created view will be
			/// placed in.
			/// </summary>
			/// <param name="parent">
			/// The parent that the created view will be placed
			/// in; <em>note that this may be null</em>.
			/// </param>
			/// <param name="name">Tag name to be inflated.</param>
			/// <param name="context">The context the view is being created in.</param>
			/// <param name="attrs">Inflation attributes as specified in XML file.</param>
			/// <returns>
			/// View Newly created view. Return null for the default
			/// behavior.
			/// </returns>
			android.view.View onCreateView(android.view.View parent, string name, android.content.Context
				 context, android.util.AttributeSet attrs);
		}

		private class FactoryMerger : android.view.LayoutInflater.Factory2
		{
			internal readonly android.view.LayoutInflater.Factory mF1;

			internal readonly android.view.LayoutInflater.Factory mF2;

			internal readonly android.view.LayoutInflater.Factory2 mF12;

			internal readonly android.view.LayoutInflater.Factory2 mF22;

			internal FactoryMerger(android.view.LayoutInflater.Factory f1, android.view.LayoutInflater
				.Factory2 f12, android.view.LayoutInflater.Factory f2, android.view.LayoutInflater
				.Factory2 f22)
			{
				mF1 = f1;
				mF2 = f2;
				mF12 = f12;
				mF22 = f22;
			}

			[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Factory")]
			public virtual android.view.View onCreateView(string name, android.content.Context
				 context, android.util.AttributeSet attrs)
			{
				android.view.View v = mF1.onCreateView(name, context, attrs);
				if (v != null)
				{
					return v;
				}
				return mF2.onCreateView(name, context, attrs);
			}

			[Sharpen.ImplementsInterface(@"android.view.LayoutInflater.Factory2")]
			public virtual android.view.View onCreateView(android.view.View parent, string name
				, android.content.Context context, android.util.AttributeSet attrs)
			{
				android.view.View v = mF12 != null ? mF12.onCreateView(parent, name, context, attrs
					) : mF1.onCreateView(name, context, attrs);
				if (v != null)
				{
					return v;
				}
				return mF22 != null ? mF22.onCreateView(parent, name, context, attrs) : mF2.onCreateView
					(name, context, attrs);
			}
		}

		/// <summary>Create a new LayoutInflater instance associated with a particular Context.
		/// 	</summary>
		/// <remarks>
		/// Create a new LayoutInflater instance associated with a particular Context.
		/// Applications will almost always want to use
		/// <see cref="android.content.Context.getSystemService(string)">Context.getSystemService()
		/// 	</see>
		/// to retrieve
		/// the standard
		/// <see cref="android.content.Context.LAYOUT_INFLATER_SERVICE">Context.INFLATER_SERVICE
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="context">
		/// The Context in which this LayoutInflater will create its
		/// Views; most importantly, this supplies the theme from which the default
		/// values for their attributes are retrieved.
		/// </param>
		protected internal LayoutInflater(android.content.Context context)
		{
			mContext = context;
		}

		/// <summary>
		/// Create a new LayoutInflater instance that is a copy of an existing
		/// LayoutInflater, optionally with its Context changed.
		/// </summary>
		/// <remarks>
		/// Create a new LayoutInflater instance that is a copy of an existing
		/// LayoutInflater, optionally with its Context changed.  For use in
		/// implementing
		/// <see cref="cloneInContext(android.content.Context)">cloneInContext(android.content.Context)
		/// 	</see>
		/// .
		/// </remarks>
		/// <param name="original">The original LayoutInflater to copy.</param>
		/// <param name="newContext">The new Context to use.</param>
		protected internal LayoutInflater(android.view.LayoutInflater original, android.content.Context
			 newContext)
		{
			mContext = newContext;
			mFactory = original.mFactory;
			mFactory2 = original.mFactory2;
			mPrivateFactory = original.mPrivateFactory;
			mFilter = original.mFilter;
		}

		/// <summary>Obtains the LayoutInflater from the given context.</summary>
		/// <remarks>Obtains the LayoutInflater from the given context.</remarks>
		public static android.view.LayoutInflater from(android.content.Context context)
		{
			android.view.LayoutInflater LayoutInflater_1 = (android.view.LayoutInflater)context
				.getSystemService(android.content.Context.LAYOUT_INFLATER_SERVICE);
			if (LayoutInflater_1 == null)
			{
				throw new java.lang.AssertionError("LayoutInflater not found.");
			}
			return LayoutInflater_1;
		}

		/// <summary>
		/// Create a copy of the existing LayoutInflater object, with the copy
		/// pointing to a different Context than the original.
		/// </summary>
		/// <remarks>
		/// Create a copy of the existing LayoutInflater object, with the copy
		/// pointing to a different Context than the original.  This is used by
		/// <see cref="ContextThemeWrapper">ContextThemeWrapper</see>
		/// to create a new LayoutInflater to go along
		/// with the new Context theme.
		/// </remarks>
		/// <param name="newContext">
		/// The new Context to associate with the new LayoutInflater.
		/// May be the same as the original Context if desired.
		/// </param>
		/// <returns>
		/// Returns a brand spanking new LayoutInflater object associated with
		/// the given Context.
		/// </returns>
		public abstract android.view.LayoutInflater cloneInContext(android.content.Context
			 newContext);

		/// <summary>
		/// Return the context we are running in, for access to resources, class
		/// loader, etc.
		/// </summary>
		/// <remarks>
		/// Return the context we are running in, for access to resources, class
		/// loader, etc.
		/// </remarks>
		public virtual android.content.Context getContext()
		{
			return mContext;
		}

		/// <summary>
		/// Return the current
		/// <see cref="Factory">Factory</see>
		/// (or null). This is called on each element
		/// name. If the factory returns a View, add that to the hierarchy. If it
		/// returns null, proceed to call onCreateView(name).
		/// </summary>
		public android.view.LayoutInflater.Factory getFactory()
		{
			return mFactory;
		}

		/// <summary>
		/// Return the current
		/// <see cref="Factory2">Factory2</see>
		/// .  Returns null if no factory is set
		/// or the set factory does not implement the
		/// <see cref="Factory2">Factory2</see>
		/// interface.
		/// This is called on each element
		/// name. If the factory returns a View, add that to the hierarchy. If it
		/// returns null, proceed to call onCreateView(name).
		/// </summary>
		public android.view.LayoutInflater.Factory2 getFactory2()
		{
			return mFactory2;
		}

		/// <summary>
		/// Attach a custom Factory interface for creating views while using
		/// this LayoutInflater.
		/// </summary>
		/// <remarks>
		/// Attach a custom Factory interface for creating views while using
		/// this LayoutInflater.  This must not be null, and can only be set once;
		/// after setting, you can not change the factory.  This is
		/// called on each element name as the xml is parsed. If the factory returns
		/// a View, that is added to the hierarchy. If it returns null, the next
		/// factory default
		/// <see cref="onCreateView(string, android.util.AttributeSet)">onCreateView(string, android.util.AttributeSet)
		/// 	</see>
		/// method is called.
		/// <p>If you have an existing
		/// LayoutInflater and want to add your own factory to it, use
		/// <see cref="cloneInContext(android.content.Context)">cloneInContext(android.content.Context)
		/// 	</see>
		/// to clone the existing instance and then you
		/// can use this function (once) on the returned new instance.  This will
		/// merge your own factory with whatever factory the original instance is
		/// using.
		/// </remarks>
		public virtual void setFactory(android.view.LayoutInflater.Factory factory)
		{
			if (mFactorySet)
			{
				throw new System.InvalidOperationException("A factory has already been set on this LayoutInflater"
					);
			}
			if (factory == null)
			{
				throw new System.ArgumentNullException("Given factory can not be null");
			}
			mFactorySet = true;
			if (mFactory == null)
			{
				mFactory = factory;
			}
			else
			{
				mFactory = new android.view.LayoutInflater.FactoryMerger(factory, null, mFactory, 
					mFactory2);
			}
		}

		/// <summary>
		/// Like
		/// <see cref="setFactory(Factory)">setFactory(Factory)</see>
		/// , but allows you to set a
		/// <see cref="Factory2">Factory2</see>
		/// interface.
		/// </summary>
		public virtual void setFactory2(android.view.LayoutInflater.Factory2 factory)
		{
			if (mFactorySet)
			{
				throw new System.InvalidOperationException("A factory has already been set on this LayoutInflater"
					);
			}
			if (factory == null)
			{
				throw new System.ArgumentNullException("Given factory can not be null");
			}
			mFactorySet = true;
			if (mFactory == null)
			{
				mFactory = mFactory2 = factory;
			}
			else
			{
				mFactory = new android.view.LayoutInflater.FactoryMerger(factory, factory, mFactory
					, mFactory2);
			}
		}

		/// <hide>for use by framework</hide>
		public virtual void setPrivateFactory(android.view.LayoutInflater.Factory2 factory
			)
		{
			mPrivateFactory = factory;
		}

		/// <returns>
		/// The
		/// <see cref="Filter">Filter</see>
		/// currently used by this LayoutInflater to restrict the set of Views
		/// that are allowed to be inflated.
		/// </returns>
		public virtual android.view.LayoutInflater.Filter getFilter()
		{
			return mFilter;
		}

		/// <summary>
		/// Sets the
		/// <see cref="Filter">Filter</see>
		/// to by this LayoutInflater. If a view is attempted to be inflated
		/// which is not allowed by the
		/// <see cref="Filter">Filter</see>
		/// , the
		/// <see cref="inflate(int, ViewGroup)">inflate(int, ViewGroup)</see>
		/// call will
		/// throw an
		/// <see cref="InflateException">InflateException</see>
		/// . This filter will replace any previous filter set on this
		/// LayoutInflater.
		/// </summary>
		/// <param name="filter">
		/// The Filter which restricts the set of Views that are allowed to be inflated.
		/// This filter will replace any previous filter set on this LayoutInflater.
		/// </param>
		public virtual void setFilter(android.view.LayoutInflater.Filter filter)
		{
			mFilter = filter;
			if (filter != null)
			{
				mFilterMap = new java.util.HashMap<string, bool>();
			}
		}

		/// <summary>Inflate a new view hierarchy from the specified xml resource.</summary>
		/// <remarks>
		/// Inflate a new view hierarchy from the specified xml resource. Throws
		/// <see cref="InflateException">InflateException</see>
		/// if there is an error.
		/// </remarks>
		/// <param name="resource">
		/// ID for an XML layout resource to load (e.g.,
		/// <code>R.layout.main_page</code>)
		/// </param>
		/// <param name="root">Optional view to be the parent of the generated hierarchy.</param>
		/// <returns>
		/// The root View of the inflated hierarchy. If root was supplied,
		/// this is the root View; otherwise it is the root of the inflated
		/// XML file.
		/// </returns>
		public virtual android.view.View inflate(int resource, android.view.ViewGroup root
			)
		{
			return inflate(resource, root, root != null);
		}

		/// <summary>Inflate a new view hierarchy from the specified xml node.</summary>
		/// <remarks>
		/// Inflate a new view hierarchy from the specified xml node. Throws
		/// <see cref="InflateException">InflateException</see>
		/// if there is an error.
		/// <p>
		/// <em><strong>Important</strong></em>&nbsp;&nbsp;&nbsp;For performance
		/// reasons, view inflation relies heavily on pre-processing of XML files
		/// that is done at build time. Therefore, it is not currently possible to
		/// use LayoutInflater with an XmlPullParser over a plain XML file at runtime.
		/// </remarks>
		/// <param name="parser">
		/// XML dom node containing the description of the view
		/// hierarchy.
		/// </param>
		/// <param name="root">Optional view to be the parent of the generated hierarchy.</param>
		/// <returns>
		/// The root View of the inflated hierarchy. If root was supplied,
		/// this is the root View; otherwise it is the root of the inflated
		/// XML file.
		/// </returns>
		public virtual android.view.View inflate(org.xmlpull.v1.XmlPullParser parser, android.view.ViewGroup
			 root)
		{
			return inflate(parser, root, root != null);
		}

		/// <summary>Inflate a new view hierarchy from the specified xml resource.</summary>
		/// <remarks>
		/// Inflate a new view hierarchy from the specified xml resource. Throws
		/// <see cref="InflateException">InflateException</see>
		/// if there is an error.
		/// </remarks>
		/// <param name="resource">
		/// ID for an XML layout resource to load (e.g.,
		/// <code>R.layout.main_page</code>)
		/// </param>
		/// <param name="root">
		/// Optional view to be the parent of the generated hierarchy (if
		/// <em>attachToRoot</em> is true), or else simply an object that
		/// provides a set of LayoutParams values for root of the returned
		/// hierarchy (if <em>attachToRoot</em> is false.)
		/// </param>
		/// <param name="attachToRoot">
		/// Whether the inflated hierarchy should be attached to
		/// the root parameter? If false, root is only used to create the
		/// correct subclass of LayoutParams for the root view in the XML.
		/// </param>
		/// <returns>
		/// The root View of the inflated hierarchy. If root was supplied and
		/// attachToRoot is true, this is root; otherwise it is the root of
		/// the inflated XML file.
		/// </returns>
		public virtual android.view.View inflate(int resource, android.view.ViewGroup root
			, bool attachToRoot)
		{
			android.content.res.XmlResourceParser parser = getContext().getResources().getLayout
				(resource);
			try
			{
				return inflate(parser, root, attachToRoot);
			}
			finally
			{
				parser.close();
			}
		}

		/// <summary>Inflate a new view hierarchy from the specified XML node.</summary>
		/// <remarks>
		/// Inflate a new view hierarchy from the specified XML node. Throws
		/// <see cref="InflateException">InflateException</see>
		/// if there is an error.
		/// <p>
		/// <em><strong>Important</strong></em>&nbsp;&nbsp;&nbsp;For performance
		/// reasons, view inflation relies heavily on pre-processing of XML files
		/// that is done at build time. Therefore, it is not currently possible to
		/// use LayoutInflater with an XmlPullParser over a plain XML file at runtime.
		/// </remarks>
		/// <param name="parser">
		/// XML dom node containing the description of the view
		/// hierarchy.
		/// </param>
		/// <param name="root">
		/// Optional view to be the parent of the generated hierarchy (if
		/// <em>attachToRoot</em> is true), or else simply an object that
		/// provides a set of LayoutParams values for root of the returned
		/// hierarchy (if <em>attachToRoot</em> is false.)
		/// </param>
		/// <param name="attachToRoot">
		/// Whether the inflated hierarchy should be attached to
		/// the root parameter? If false, root is only used to create the
		/// correct subclass of LayoutParams for the root view in the XML.
		/// </param>
		/// <returns>
		/// The root View of the inflated hierarchy. If root was supplied and
		/// attachToRoot is true, this is root; otherwise it is the root of
		/// the inflated XML file.
		/// </returns>
		public virtual android.view.View inflate(org.xmlpull.v1.XmlPullParser parser, android.view.ViewGroup
			 root, bool attachToRoot)
		{
			lock (mConstructorArgs)
			{
				android.util.AttributeSet attrs = android.util.Xml.asAttributeSet(parser);
				android.content.Context lastContext = (android.content.Context)mConstructorArgs[0
					];
				mConstructorArgs[0] = mContext;
				android.view.View result = root;
				try
				{
					// Look for the root node.
					int type;
					while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
						 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
					{
					}
					// Empty
					if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
					{
						throw new android.view.InflateException(parser.getPositionDescription() + ": No start tag found!"
							);
					}
					string name = parser.getName();
					if (TAG_MERGE.Equals(name))
					{
						if (root == null || !attachToRoot)
						{
							throw new android.view.InflateException("<merge /> can be used only with a valid "
								 + "ViewGroup root and attachToRoot=true");
						}
						rInflate(parser, root, attrs, false);
					}
					else
					{
						// Temp is the root view that was found in the xml
						android.view.View temp;
						if (TAG_1995.Equals(name))
						{
							temp = new android.view.LayoutInflater.BlinkLayout(mContext, attrs);
						}
						else
						{
							temp = createViewFromTag(root, name, attrs);
						}
						android.view.ViewGroup.LayoutParams @params = null;
						if (root != null)
						{
							// Create layout params that match root, if supplied
							@params = root.generateLayoutParams(attrs);
							if (!attachToRoot)
							{
								// Set the layout params for temp if we are not
								// attaching. (If we are, we use addView, below)
								temp.setLayoutParams(@params);
							}
						}
						// Inflate all children under temp
						rInflate(parser, temp, attrs, true);
						// We are supposed to attach all the views we found (int temp)
						// to root. Do that now.
						if (root != null && attachToRoot)
						{
							root.addView(temp, @params);
						}
						// Decide whether to return the root that was passed in or the
						// top view found in xml.
						if (root == null || !attachToRoot)
						{
							result = temp;
						}
					}
				}
				catch (org.xmlpull.v1.XmlPullParserException e)
				{
					android.view.InflateException ex = new android.view.InflateException(e.Message);
					ex.InnerException = e;
					throw ex;
				}
				catch (System.IO.IOException e)
				{
					android.view.InflateException ex = new android.view.InflateException(parser.getPositionDescription
						() + ": " + e.Message);
					ex.InnerException = e;
					throw ex;
				}
				finally
				{
					// Don't retain static reference on context.
					mConstructorArgs[0] = lastContext;
					mConstructorArgs[1] = null;
				}
				return result;
			}
		}

		/// <summary>Low-level function for instantiating a view by name.</summary>
		/// <remarks>
		/// Low-level function for instantiating a view by name. This attempts to
		/// instantiate a view class of the given <var>name</var> found in this
		/// LayoutInflater's ClassLoader.
		/// <p>
		/// There are two things that can happen in an error case: either the
		/// exception describing the error will be thrown, or a null will be
		/// returned. You must deal with both possibilities -- the former will happen
		/// the first time createView() is called for a class of a particular name,
		/// the latter every time there-after for that class name.
		/// </remarks>
		/// <param name="name">The full name of the class to be instantiated.</param>
		/// <param name="attrs">The XML attributes supplied for this instance.</param>
		/// <returns>View The newly instantiated view, or null.</returns>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		/// <exception cref="android.view.InflateException"></exception>
		public android.view.View createView(string name, string prefix, android.util.AttributeSet
			 attrs)
		{
			System.Reflection.ConstructorInfo constructor = sConstructorMap.get(name);
			System.Type clazz = null;
			try
			{
				if (constructor == null)
				{
					// Class not found in the cache, see if it's real, and try to add it
					clazz = XobotOS.Runtime.Reflection.AsSubclass(mContext.getClassLoader().loadClass
						(prefix != null ? (prefix + name) : name), typeof(android.view.View));
					if (mFilter != null && clazz != null)
					{
						bool allowed = mFilter.onLoadClass(clazz);
						if (!allowed)
						{
							failNotAllowed(name, prefix, attrs);
						}
					}
					constructor = XobotOS.Runtime.Reflection.GetConstructor(clazz, mConstructorSignature
						);
					sConstructorMap.put(name, constructor);
				}
				else
				{
					// If we have a filter, apply it to cached constructor
					if (mFilter != null)
					{
						// Have we seen this name before?
						bool allowedState = mFilterMap.get(name);
						if (allowedState == null)
						{
							// New class -- remember whether it is allowed
							clazz = XobotOS.Runtime.Reflection.AsSubclass(mContext.getClassLoader().loadClass
								(prefix != null ? (prefix + name) : name), typeof(android.view.View));
							bool allowed = clazz != null && mFilter.onLoadClass(clazz);
							mFilterMap.put(name, allowed);
							if (!allowed)
							{
								failNotAllowed(name, prefix, attrs);
							}
						}
						else
						{
							if (allowedState.Equals(false))
							{
								failNotAllowed(name, prefix, attrs);
							}
						}
					}
				}
				object[] args = mConstructorArgs;
				args[1] = attrs;
				return (android.view.View)constructor.Invoke(args);
			}
			catch (java.lang.NoSuchMethodException e)
			{
				android.view.InflateException ie = new android.view.InflateException(attrs.getPositionDescription
					() + ": Error inflating class " + (prefix != null ? (prefix + name) : name));
				ie.InnerException = e;
				throw ie;
			}
			catch (System.InvalidCastException e)
			{
				// If loaded class is not a View subclass
				android.view.InflateException ie = new android.view.InflateException(attrs.getPositionDescription
					() + ": Class is not a View " + (prefix != null ? (prefix + name) : name));
				ie.InnerException = e;
				throw ie;
			}
			catch (java.lang.ClassNotFoundException e)
			{
				// If loadClass fails, we should propagate the exception.
				throw;
			}
			catch (System.Exception e)
			{
				android.view.InflateException ie = new android.view.InflateException(attrs.getPositionDescription
					() + ": Error inflating class " + (clazz == null ? "<unknown>" : clazz.FullName)
					);
				ie.InnerException = e;
				throw ie;
			}
		}

		/// <summary>Throw an exception because the specified class is not allowed to be inflated.
		/// 	</summary>
		/// <remarks>Throw an exception because the specified class is not allowed to be inflated.
		/// 	</remarks>
		private void failNotAllowed(string name, string prefix, android.util.AttributeSet
			 attrs)
		{
			throw new android.view.InflateException(attrs.getPositionDescription() + ": Class not allowed to be inflated "
				 + (prefix != null ? (prefix + name) : name));
		}

		/// <summary>
		/// This routine is responsible for creating the correct subclass of View
		/// given the xml element name.
		/// </summary>
		/// <remarks>
		/// This routine is responsible for creating the correct subclass of View
		/// given the xml element name. Override it to handle custom view objects. If
		/// you override this in your subclass be sure to call through to
		/// super.onCreateView(name) for names you do not recognize.
		/// </remarks>
		/// <param name="name">The fully qualified class name of the View to be create.</param>
		/// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
		/// <returns>View The View created.</returns>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		protected internal virtual android.view.View onCreateView(string name, android.util.AttributeSet
			 attrs)
		{
			return createView(name, "android.view.", attrs);
		}

		/// <summary>
		/// Version of
		/// <see cref="onCreateView(string, android.util.AttributeSet)">onCreateView(string, android.util.AttributeSet)
		/// 	</see>
		/// that also
		/// takes the future parent of the view being constructure.  The default
		/// implementation simply calls
		/// <see cref="onCreateView(string, android.util.AttributeSet)">onCreateView(string, android.util.AttributeSet)
		/// 	</see>
		/// .
		/// </summary>
		/// <param name="parent">
		/// The future parent of the returned view.  <em>Note that
		/// this may be null.</em>
		/// </param>
		/// <param name="name">The fully qualified class name of the View to be create.</param>
		/// <param name="attrs">An AttributeSet of attributes to apply to the View.</param>
		/// <returns>View The View created.</returns>
		/// <exception cref="java.lang.ClassNotFoundException"></exception>
		protected internal virtual android.view.View onCreateView(android.view.View parent
			, string name, android.util.AttributeSet attrs)
		{
			return onCreateView(name, attrs);
		}

		internal virtual android.view.View createViewFromTag(android.view.View parent, string
			 name, android.util.AttributeSet attrs)
		{
			if (name.Equals("view"))
			{
				name = attrs.getAttributeValue(null, "class");
			}
			try
			{
				android.view.View view;
				if (mFactory2 != null)
				{
					view = mFactory2.onCreateView(parent, name, mContext, attrs);
				}
				else
				{
					if (mFactory != null)
					{
						view = mFactory.onCreateView(name, mContext, attrs);
					}
					else
					{
						view = null;
					}
				}
				if (view == null && mPrivateFactory != null)
				{
					view = mPrivateFactory.onCreateView(parent, name, mContext, attrs);
				}
				if (view == null)
				{
					if (-1 == name.IndexOf('.'))
					{
						view = onCreateView(parent, name, attrs);
					}
					else
					{
						view = createView(name, null, attrs);
					}
				}
				return view;
			}
			catch (android.view.InflateException e)
			{
				throw;
			}
			catch (java.lang.ClassNotFoundException e)
			{
				android.view.InflateException ie = new android.view.InflateException(attrs.getPositionDescription
					() + ": Error inflating class " + name);
				ie.InnerException = e;
				throw ie;
			}
			catch (System.Exception e)
			{
				android.view.InflateException ie = new android.view.InflateException(attrs.getPositionDescription
					() + ": Error inflating class " + name);
				ie.InnerException = e;
				throw ie;
			}
		}

		/// <summary>
		/// Recursive method used to descend down the xml hierarchy and instantiate
		/// views, instantiate their children, and then call onFinishInflate().
		/// </summary>
		/// <remarks>
		/// Recursive method used to descend down the xml hierarchy and instantiate
		/// views, instantiate their children, and then call onFinishInflate().
		/// </remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		internal virtual void rInflate(org.xmlpull.v1.XmlPullParser parser, android.view.View
			 parent, android.util.AttributeSet attrs, bool finishInflate)
		{
			int depth = parser.getDepth();
			int type;
			while (((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser
				.getDepth() > depth) && type != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				string name = parser.getName();
				if (TAG_REQUEST_FOCUS.Equals(name))
				{
					parseRequestFocus(parser, parent);
				}
				else
				{
					if (TAG_INCLUDE.Equals(name))
					{
						if (parser.getDepth() == 0)
						{
							throw new android.view.InflateException("<include /> cannot be the root element");
						}
						parseInclude(parser, parent, attrs);
					}
					else
					{
						if (TAG_MERGE.Equals(name))
						{
							throw new android.view.InflateException("<merge /> must be the root element");
						}
						else
						{
							if (TAG_1995.Equals(name))
							{
								android.view.View view = new android.view.LayoutInflater.BlinkLayout(mContext, attrs
									);
								android.view.ViewGroup viewGroup = (android.view.ViewGroup)parent;
								android.view.ViewGroup.LayoutParams @params = viewGroup.generateLayoutParams(attrs
									);
								rInflate(parser, view, attrs, true);
								viewGroup.addView(view, @params);
							}
							else
							{
								android.view.View view = createViewFromTag(parent, name, attrs);
								android.view.ViewGroup viewGroup = (android.view.ViewGroup)parent;
								android.view.ViewGroup.LayoutParams @params = viewGroup.generateLayoutParams(attrs
									);
								rInflate(parser, view, attrs, true);
								viewGroup.addView(view, @params);
							}
						}
					}
				}
			}
			if (finishInflate)
			{
				parent.onFinishInflate();
			}
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private void parseRequestFocus(org.xmlpull.v1.XmlPullParser parser, android.view.View
			 parent)
		{
			int type;
			parent.requestFocus();
			int currentDepth = parser.getDepth();
			while (((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser
				.getDepth() > currentDepth) && type != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
				)
			{
			}
		}

		// Empty
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private void parseInclude(org.xmlpull.v1.XmlPullParser parser, android.view.View 
			parent, android.util.AttributeSet attrs)
		{
			int type;
			if (parent is android.view.ViewGroup)
			{
				int layout = attrs.getAttributeResourceValue(null, "layout", 0);
				if (layout == 0)
				{
					string value = attrs.getAttributeValue(null, "layout");
					if (value == null)
					{
						throw new android.view.InflateException("You must specifiy a layout in the" + " include tag: <include layout=\"@layout/layoutID\" />"
							);
					}
					else
					{
						throw new android.view.InflateException("You must specifiy a valid layout " + "reference. The layout ID "
							 + value + " is not valid.");
					}
				}
				else
				{
					android.content.res.XmlResourceParser childParser = getContext().getResources().getLayout
						(layout);
					try
					{
						android.util.AttributeSet childAttrs = android.util.Xml.asAttributeSet(childParser
							);
						while ((type = childParser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG
							 && type != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
						{
						}
						// Empty.
						if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
						{
							throw new android.view.InflateException(childParser.getPositionDescription() + ": No start tag found!"
								);
						}
						string childName = childParser.getName();
						if (TAG_MERGE.Equals(childName))
						{
							// Inflate all children.
							rInflate(childParser, parent, childAttrs, false);
						}
						else
						{
							android.view.View view = createViewFromTag(parent, childName, childAttrs);
							android.view.ViewGroup group = (android.view.ViewGroup)parent;
							// We try to load the layout params set in the <include /> tag. If
							// they don't exist, we will rely on the layout params set in the
							// included XML file.
							// During a layoutparams generation, a runtime exception is thrown
							// if either layout_width or layout_height is missing. We catch
							// this exception and set localParams accordingly: true means we
							// successfully loaded layout params from the <include /> tag,
							// false means we need to rely on the included layout params.
							android.view.ViewGroup.LayoutParams @params = null;
							try
							{
								@params = group.generateLayoutParams(attrs);
							}
							catch (java.lang.RuntimeException)
							{
								@params = group.generateLayoutParams(childAttrs);
							}
							finally
							{
								if (@params != null)
								{
									view.setLayoutParams(@params);
								}
							}
							// Inflate all children.
							rInflate(childParser, view, childAttrs, true);
							// Attempt to override the included layout's android:id with the
							// one set on the <include /> tag itself.
							android.content.res.TypedArray a = mContext.obtainStyledAttributes(attrs, android.@internal.R
								.styleable.View, 0, 0);
							int id = a.getResourceId(android.@internal.R.styleable.View_id, android.view.View
								.NO_ID);
							// While we're at it, let's try to override android:visibility.
							int visibility = a.getInt(android.@internal.R.styleable.View_visibility, -1);
							a.recycle();
							if (id != android.view.View.NO_ID)
							{
								view.setId(id);
							}
							switch (visibility)
							{
								case 0:
								{
									view.setVisibility(android.view.View.VISIBLE);
									break;
								}

								case 1:
								{
									view.setVisibility(android.view.View.INVISIBLE);
									break;
								}

								case 2:
								{
									view.setVisibility(android.view.View.GONE);
									break;
								}
							}
							group.addView(view);
						}
					}
					finally
					{
						childParser.close();
					}
				}
			}
			else
			{
				throw new android.view.InflateException("<include /> can only be used inside of a ViewGroup"
					);
			}
			int currentDepth = parser.getDepth();
			while (((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_TAG || parser
				.getDepth() > currentDepth) && type != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT
				)
			{
			}
		}

		private class BlinkLayout : android.widget.FrameLayout
		{
			internal const int MESSAGE_BLINK = unchecked((int)(0x42));

			internal const int BLINK_DELAY = 500;

			internal bool mBlink;

			internal bool mBlinkState;

			internal readonly android.os.Handler mHandler;

			internal sealed class _Callback_877 : android.os.Handler.Callback
			{
				public _Callback_877(BlinkLayout _enclosing)
				{
					this._enclosing = _enclosing;
				}

				// Empty
				[Sharpen.ImplementsInterface(@"android.os.Handler.Callback")]
				public bool handleMessage(android.os.Message msg)
				{
					if (msg.what == android.view.LayoutInflater.BlinkLayout.MESSAGE_BLINK)
					{
						if (this._enclosing.mBlink)
						{
							this._enclosing.mBlinkState = !this._enclosing.mBlinkState;
							this._enclosing.makeBlink();
						}
						this._enclosing.invalidate();
						return true;
					}
					return false;
				}

				private readonly BlinkLayout _enclosing;
			}

			public BlinkLayout(android.content.Context context, android.util.AttributeSet attrs
				) : base(context, attrs)
			{
				mHandler = new android.os.Handler(new _Callback_877(this));
			}

			internal void makeBlink()
			{
				android.os.Message message = mHandler.obtainMessage(MESSAGE_BLINK);
				mHandler.sendMessageDelayed(message, BLINK_DELAY);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onAttachedToWindow()
			{
				base.onAttachedToWindow();
				mBlink = true;
				mBlinkState = true;
				makeBlink();
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void onDetachedFromWindow()
			{
				base.onDetachedFromWindow();
				mBlink = false;
				mBlinkState = true;
				mHandler.removeMessages(MESSAGE_BLINK);
			}

			[Sharpen.OverridesMethod(@"android.view.View")]
			protected internal override void dispatchDraw(android.graphics.Canvas canvas)
			{
				if (mBlinkState)
				{
					base.dispatchDraw(canvas);
				}
			}
		}
	}
}
