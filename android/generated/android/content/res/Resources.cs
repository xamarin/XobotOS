using System.Runtime.InteropServices;
using Sharpen;

namespace android.content.res
{
	/// <summary>Class for accessing an application's resources.</summary>
	/// <remarks>
	/// Class for accessing an application's resources.  This sits on top of the
	/// asset manager of the application (accessible through
	/// <see cref="getAssets()">getAssets()</see>
	/// ) and
	/// provides a high-level API for getting typed data from the assets.
	/// <p>The Android resource system keeps track of all non-code assets associated with an
	/// application. You can use this class to access your application's resources. You can generally
	/// acquire the
	/// <see cref="Resources">Resources</see>
	/// instance associated with your application
	/// with
	/// <see cref="android.content.Context.getResources()">getResources()</see>
	/// .</p>
	/// <p>The Android SDK tools compile your application's resources into the application binary
	/// at build time.  To use a resource, you must install it correctly in the source tree (inside
	/// your project's
	/// <code>res/</code>
	/// directory) and build your application.  As part of the build
	/// process, the SDK tools generate symbols for each resource, which you can use in your application
	/// code to access the resources.</p>
	/// <p>Using application resources makes it easy to update various characteristics of your
	/// application without modifying code, and&mdash;by providing sets of alternative
	/// resources&mdash;enables you to optimize your application for a variety of device configurations
	/// (such as for different languages and screen sizes). This is an important aspect of developing
	/// Android applications that are compatible on different types of devices.</p>
	/// <p>For more information about using resources, see the documentation about &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/index.html"&gt;Application Resources</a>.</p>
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class Resources
	{
		internal const string TAG = "Resources";

		internal const bool DEBUG_LOAD = false;

		internal const bool DEBUG_CONFIG = false;

		internal const bool DEBUG_ATTRIBUTES_CACHE = false;

		internal const bool TRACE_FOR_PRELOAD = false;

		internal const bool TRACE_FOR_MISS_PRELOAD = false;

		internal const int ID_OTHER = unchecked((int)(0x01000004));

		private static readonly object mSync = new object();

		internal static android.content.res.Resources mSystem = null;

		private static readonly android.util.LongSparseArray<android.graphics.drawable.Drawable
			.ConstantState> sPreloadedDrawables = new android.util.LongSparseArray<android.graphics.drawable.Drawable
			.ConstantState>();

		private static readonly android.util.SparseArray<android.content.res.ColorStateList
			> mPreloadedColorStateLists = new android.util.SparseArray<android.content.res.ColorStateList
			>();

		private static readonly android.util.LongSparseArray<android.graphics.drawable.Drawable
			.ConstantState> sPreloadedColorDrawables = new android.util.LongSparseArray<android.graphics.drawable.Drawable
			.ConstantState>();

		private static bool mPreloaded;

		internal readonly android.util.TypedValue mTmpValue = new android.util.TypedValue
			();

		internal readonly android.content.res.Configuration mTmpConfig = new android.content.res.Configuration
			();

		private readonly android.util.LongSparseArray<java.lang.@ref.WeakReference<android.graphics.drawable.Drawable
			.ConstantState>> mDrawableCache = new android.util.LongSparseArray<java.lang.@ref.WeakReference
			<android.graphics.drawable.Drawable.ConstantState>>();

		private readonly android.util.SparseArray<java.lang.@ref.WeakReference<android.content.res.ColorStateList
			>> mColorStateListCache = new android.util.SparseArray<java.lang.@ref.WeakReference
			<android.content.res.ColorStateList>>();

		private readonly android.util.LongSparseArray<java.lang.@ref.WeakReference<android.graphics.drawable.Drawable
			.ConstantState>> mColorDrawableCache = new android.util.LongSparseArray<java.lang.@ref.WeakReference
			<android.graphics.drawable.Drawable.ConstantState>>();

		private bool mPreloading;

		internal android.content.res.TypedArray mCachedStyledAttributes = null;

		internal java.lang.RuntimeException mLastRetrievedAttrs = null;

		private int mLastCachedXmlBlockIndex = -1;

		private readonly int[] mCachedXmlBlockIds = new int[] { 0, 0, 0, 0 };

		private readonly android.content.res.XmlBlock[] mCachedXmlBlocks = new android.content.res.XmlBlock
			[4];

		internal readonly android.content.res.AssetManager mAssets;

		private readonly android.content.res.Configuration mConfiguration = new android.content.res.Configuration
			();

		internal readonly android.util.DisplayMetrics mMetrics = new android.util.DisplayMetrics
			();

		private libcore.icu.NativePluralRules mPluralRule;

		private android.content.res.CompatibilityInfo mCompatibilityInfo;

		// Information about preloaded resources.  Note that they are not
		// protected by a lock, because while preloading in zygote we are all
		// single-threaded, and after that these are immutable.
		// These are protected by the mTmpValue lock.
		/// <hide></hide>
		public static int selectDefaultTheme(int curTheme, int targetSdkVersion)
		{
			return selectSystemTheme(curTheme, targetSdkVersion, android.@internal.R.style.Theme
				, android.@internal.R.style.Theme_Holo, android.@internal.R.style.Theme_DeviceDefault
				);
		}

		/// <hide></hide>
		public static int selectSystemTheme(int curTheme, int targetSdkVersion, int orig, 
			int holo, int deviceDefault)
		{
			if (curTheme != 0)
			{
				return curTheme;
			}
			if (targetSdkVersion < android.os.Build.VERSION_CODES.HONEYCOMB)
			{
				return orig;
			}
			if (targetSdkVersion < android.os.Build.VERSION_CODES.ICE_CREAM_SANDWICH)
			{
				return holo;
			}
			return deviceDefault;
		}

		/// <summary>
		/// This exception is thrown by the resource APIs when a requested resource
		/// can not be found.
		/// </summary>
		/// <remarks>
		/// This exception is thrown by the resource APIs when a requested resource
		/// can not be found.
		/// </remarks>
		[System.Serializable]
		public class NotFoundException : java.lang.RuntimeException
		{
			public NotFoundException()
			{
			}

			public NotFoundException(string name) : base(name)
			{
			}
		}

		/// <summary>
		/// Create a new Resources object on top of an existing set of assets in an
		/// AssetManager.
		/// </summary>
		/// <remarks>
		/// Create a new Resources object on top of an existing set of assets in an
		/// AssetManager.
		/// </remarks>
		/// <param name="assets">Previously created AssetManager.</param>
		/// <param name="metrics">
		/// Current display metrics to consider when
		/// selecting/computing resource values.
		/// </param>
		/// <param name="config">
		/// Desired device configuration to consider when
		/// selecting/computing resource values (optional).
		/// </param>
		public Resources(android.content.res.AssetManager assets, android.util.DisplayMetrics
			 metrics, android.content.res.Configuration config) : this(assets, metrics, config
			, (android.content.res.CompatibilityInfo)null)
		{
		}

		/// <summary>Creates a new Resources object with CompatibilityInfo.</summary>
		/// <remarks>Creates a new Resources object with CompatibilityInfo.</remarks>
		/// <param name="assets">Previously created AssetManager.</param>
		/// <param name="metrics">
		/// Current display metrics to consider when
		/// selecting/computing resource values.
		/// </param>
		/// <param name="config">
		/// Desired device configuration to consider when
		/// selecting/computing resource values (optional).
		/// </param>
		/// <param name="compInfo">
		/// this resource's compatibility info. It will use the default compatibility
		/// info when it's null.
		/// </param>
		/// <hide></hide>
		public Resources(android.content.res.AssetManager assets, android.util.DisplayMetrics
			 metrics, android.content.res.Configuration config, android.content.res.CompatibilityInfo
			 compInfo)
		{
			mAssets = assets;
			mMetrics.setToDefaults();
			mCompatibilityInfo = compInfo;
			updateConfiguration(config, metrics);
			assets.ensureStringBlocks();
		}

		/// <summary>
		/// Return a global shared Resources object that provides access to only
		/// system resources (no application resources), and is not configured for
		/// the current screen (can not use dimension units, does not change based
		/// on orientation, etc).
		/// </summary>
		/// <remarks>
		/// Return a global shared Resources object that provides access to only
		/// system resources (no application resources), and is not configured for
		/// the current screen (can not use dimension units, does not change based
		/// on orientation, etc).
		/// </remarks>
		public static android.content.res.Resources getSystem()
		{
			lock (mSync)
			{
				android.content.res.Resources ret = mSystem;
				if (ret == null)
				{
					ret = new android.content.res.Resources();
					mSystem = ret;
				}
				return ret;
			}
		}

		/// <summary>Return the string value associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return the string value associated with a particular resource ID.  The
		/// returned object will be a String if this is a plain string; it will be
		/// some other type of CharSequence if it is styled.
		/// <more></more>
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// CharSequence The string data associated with the resource, plus
		/// possibly styled text information.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual java.lang.CharSequence getText(int id)
		{
			java.lang.CharSequence res = mAssets.getResourceText(id);
			if (res != null)
			{
				return res;
			}
			throw new android.content.res.Resources.NotFoundException("String resource ID #0x"
				 + Sharpen.Util.IntToHexString(id));
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getQuantityText(int id, int quantity)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Return the string value associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return the string value associated with a particular resource ID.  It
		/// will be stripped of any styled text information.
		/// <more></more>
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// String The string data associated with the resource,
		/// stripped of styled text information.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getString(int id)
		{
			java.lang.CharSequence res = getText(id);
			if (res != null)
			{
				return res.ToString();
			}
			throw new android.content.res.Resources.NotFoundException("String resource ID #0x"
				 + Sharpen.Util.IntToHexString(id));
		}

		/// <summary>
		/// Return the string value associated with a particular resource ID,
		/// substituting the format arguments as defined in
		/// <see cref="java.util.Formatter">java.util.Formatter</see>
		/// and
		/// <see cref="string.Format(string, object[])">string.Format(string, object[])</see>
		/// . It will be stripped of any styled text
		/// information.
		/// <more></more>
		/// </summary>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="formatArgs">The format arguments that will be used for substitution.
		/// 	</param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// String The string data associated with the resource,
		/// stripped of styled text information.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getString(int id, params object[] formatArgs)
		{
			string raw = getString(id);
			return string.Format(mConfiguration.locale, raw, formatArgs);
		}

		/// <summary>
		/// Return the string value associated with a particular resource ID for a particular
		/// numerical quantity, substituting the format arguments as defined in
		/// <see cref="java.util.Formatter">java.util.Formatter</see>
		/// and
		/// <see cref="string.Format(string, object[])">string.Format(string, object[])</see>
		/// . It will be
		/// stripped of any styled text information.
		/// <more></more>
		/// <p>See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/resources/string-resource.html#Plurals"&gt;String
		/// Resources</a> for more on quantity strings.
		/// </summary>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="quantity">
		/// The number used to get the correct string for the current language's
		/// plural rules.
		/// </param>
		/// <param name="formatArgs">The format arguments that will be used for substitution.
		/// 	</param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// String The string data associated with the resource,
		/// stripped of styled text information.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getQuantityString(int id, int quantity, params object[] formatArgs
			)
		{
			string raw = getQuantityText(id, quantity).ToString();
			return string.Format(mConfiguration.locale, raw, formatArgs);
		}

		/// <summary>
		/// Return the string value associated with a particular resource ID for a particular
		/// numerical quantity.
		/// </summary>
		/// <remarks>
		/// Return the string value associated with a particular resource ID for a particular
		/// numerical quantity.
		/// <p>See &lt;a href="
		/// <docRoot></docRoot>
		/// guide/topics/resources/string-resource.html#Plurals"&gt;String
		/// Resources</a> for more on quantity strings.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="quantity">
		/// The number used to get the correct string for the current language's
		/// plural rules.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// String The string data associated with the resource,
		/// stripped of styled text information.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getQuantityString(int id, int quantity)
		{
			return getQuantityText(id, quantity).ToString();
		}

		/// <summary>Return the string value associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return the string value associated with a particular resource ID.  The
		/// returned object will be a String if this is a plain string; it will be
		/// some other type of CharSequence if it is styled.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="def">The default CharSequence to return.</param>
		/// <returns>
		/// CharSequence The string data associated with the resource, plus
		/// possibly styled text information, or def if id is 0 or not found.
		/// </returns>
		public virtual java.lang.CharSequence getText(int id, java.lang.CharSequence def)
		{
			java.lang.CharSequence res = id != 0 ? mAssets.getResourceText(id) : null;
			return res != null ? res : def;
		}

		/// <summary>Return the styled text array associated with a particular resource ID.</summary>
		/// <remarks>Return the styled text array associated with a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>The styled text array associated with the resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual java.lang.CharSequence[] getTextArray(int id)
		{
			java.lang.CharSequence[] res = mAssets.getResourceTextArray(id);
			if (res != null)
			{
				return res;
			}
			throw new android.content.res.Resources.NotFoundException("Text array resource ID #0x"
				 + Sharpen.Util.IntToHexString(id));
		}

		/// <summary>Return the string array associated with a particular resource ID.</summary>
		/// <remarks>Return the string array associated with a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>The string array associated with the resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string[] getStringArray(int id)
		{
			string[] res = mAssets.getResourceStringArray(id);
			if (res != null)
			{
				return res;
			}
			throw new android.content.res.Resources.NotFoundException("String array resource ID #0x"
				 + Sharpen.Util.IntToHexString(id));
		}

		/// <summary>Return the int array associated with a particular resource ID.</summary>
		/// <remarks>Return the int array associated with a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>The int array associated with the resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual int[] getIntArray(int id)
		{
			int[] res = mAssets.getArrayIntResource(id);
			if (res != null)
			{
				return res;
			}
			throw new android.content.res.Resources.NotFoundException("Int array resource ID #0x"
				 + Sharpen.Util.IntToHexString(id));
		}

		/// <summary>Return an array of heterogeneous values.</summary>
		/// <remarks>Return an array of heterogeneous values.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// Returns a TypedArray holding an array of the array values.
		/// Be sure to call
		/// <see cref="TypedArray.recycle()">TypedArray.recycle()</see>
		/// when done with it.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.content.res.TypedArray obtainTypedArray(int id)
		{
			int len = mAssets.getArraySize(id);
			if (len < 0)
			{
				throw new android.content.res.Resources.NotFoundException("Array resource ID #0x"
					 + Sharpen.Util.IntToHexString(id));
			}
			android.content.res.TypedArray array = getCachedStyledAttributes(len);
			array.mLength = mAssets.retrieveArray(id, array.mData);
			array.mIndices[0] = 0;
			return array;
		}

		/// <summary>Retrieve a dimensional for a particular resource ID.</summary>
		/// <remarks>
		/// Retrieve a dimensional for a particular resource ID.  Unit
		/// conversions are based on the current
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// associated
		/// with the resources.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <returns>
		/// Resource dimension value multiplied by the appropriate
		/// metric.
		/// </returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getDimensionPixelOffset(int)">getDimensionPixelOffset(int)</seealso>
		/// <seealso cref="getDimensionPixelSize(int)">getDimensionPixelSize(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual float getDimension(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimension(value.data, mMetrics);
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>
		/// Retrieve a dimensional for a particular resource ID for use
		/// as an offset in raw pixels.
		/// </summary>
		/// <remarks>
		/// Retrieve a dimensional for a particular resource ID for use
		/// as an offset in raw pixels.  This is the same as
		/// <see cref="getDimension(int)">getDimension(int)</see>
		/// , except the returned value is converted to
		/// integer pixels for you.  An offset conversion involves simply
		/// truncating the base value to an integer.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <returns>
		/// Resource dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels.
		/// </returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getDimension(int)">getDimension(int)</seealso>
		/// <seealso cref="getDimensionPixelSize(int)">getDimensionPixelSize(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual int getDimensionPixelOffset(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelOffset(value.data, mMetrics
						);
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>
		/// Retrieve a dimensional for a particular resource ID for use
		/// as a size in raw pixels.
		/// </summary>
		/// <remarks>
		/// Retrieve a dimensional for a particular resource ID for use
		/// as a size in raw pixels.  This is the same as
		/// <see cref="getDimension(int)">getDimension(int)</see>
		/// , except the returned value is converted to
		/// integer pixels for use as a size.  A size conversion involves
		/// rounding the base value, and ensuring that a non-zero base value
		/// is at least one pixel in size.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <returns>
		/// Resource dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels.
		/// </returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getDimension(int)">getDimension(int)</seealso>
		/// <seealso cref="getDimensionPixelOffset(int)">getDimensionPixelOffset(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual int getDimensionPixelSize(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelSize(value.data, mMetrics);
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>Retrieve a fractional unit for a particular resource ID.</summary>
		/// <remarks>Retrieve a fractional unit for a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="base">
		/// The base value of this fraction.  In other words, a
		/// standard fraction is multiplied by this value.
		/// </param>
		/// <param name="pbase">
		/// The parent base value of this fraction.  In other
		/// words, a parent fraction (nn%p) is multiplied by this
		/// value.
		/// </param>
		/// <returns>
		/// Attribute fractional value multiplied by the appropriate
		/// base value.
		/// </returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		public virtual float getFraction(int id, int @base, int pbase)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type == android.util.TypedValue.TYPE_FRACTION)
				{
					return android.util.TypedValue.complexToFraction(value.data, @base, pbase);
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>Return a drawable object associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return a drawable object associated with a particular resource ID.
		/// Various types of objects will be returned depending on the underlying
		/// resource -- for example, a solid color, PNG image, scalable image, etc.
		/// The Drawable API hides these implementation details.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>Drawable An object that can be used to draw this resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.graphics.drawable.Drawable getDrawable(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				return loadDrawable(value, id);
			}
		}

		/// <summary>
		/// Return a drawable object associated with a particular resource ID for the
		/// given screen density in DPI.
		/// </summary>
		/// <remarks>
		/// Return a drawable object associated with a particular resource ID for the
		/// given screen density in DPI. This will set the drawable's density to be
		/// the device's density multiplied by the ratio of actual drawable density
		/// to requested density. This allows the drawable to be scaled up to the
		/// correct size if needed. Various types of objects will be returned
		/// depending on the underlying resource -- for example, a solid color, PNG
		/// image, scalable image, etc. The Drawable API hides these implementation
		/// details.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt tool.
		/// This integer encodes the package, type, and resource entry.
		/// The value 0 is an invalid identifier.
		/// </param>
		/// <param name="density">
		/// the desired screen density indicated by the resource as
		/// found in
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// .
		/// </param>
		/// <exception cref="NotFoundException">
		/// Throws NotFoundException if the given ID does
		/// not exist.
		/// </exception>
		/// <returns>Drawable An object that can be used to draw this resource.</returns>
		/// <hide></hide>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.graphics.drawable.Drawable getDrawableForDensity(int id, int
			 density)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValueForDensity(id, density, value, true);
				if (value.density > 0 && value.density != android.util.TypedValue.DENSITY_NONE)
				{
					if (value.density == density)
					{
						value.density = android.util.DisplayMetrics.DENSITY_DEVICE;
					}
					else
					{
						value.density = (value.density * android.util.DisplayMetrics.DENSITY_DEVICE) / density;
					}
				}
				return loadDrawable(value, id);
			}
		}

		/// <summary>Return a movie object associated with the particular resource ID.</summary>
		/// <remarks>Return a movie object associated with the particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.graphics.Movie getMovie(int id)
		{
			java.io.InputStream @is = openRawResource(id);
			android.graphics.Movie movie = android.graphics.Movie.decodeStream(@is);
			try
			{
				@is.close();
			}
			catch (System.IO.IOException)
			{
			}
			// don't care, since the return value is valid
			return movie;
		}

		/// <summary>Return a color integer associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return a color integer associated with a particular resource ID.
		/// If the resource holds a complex
		/// <see cref="ColorStateList">ColorStateList</see>
		/// , then the default color from
		/// the set is returned.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>Returns a single color value in the form 0xAARRGGBB.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual int getColor(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type >= android.util.TypedValue.TYPE_FIRST_INT && value.type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return value.data;
				}
				else
				{
					if (value.type == android.util.TypedValue.TYPE_STRING)
					{
						android.content.res.ColorStateList csl = loadColorStateList(mTmpValue, id);
						return csl.getDefaultColor();
					}
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>Return a color state list associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return a color state list associated with a particular resource ID.  The
		/// resource may contain either a single raw color value, or a complex
		/// <see cref="ColorStateList">ColorStateList</see>
		/// holding multiple possible colors.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier of a
		/// <see cref="ColorStateList">ColorStateList</see>
		/// ,
		/// as generated by the aapt tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// Returns a ColorStateList object containing either a single
		/// solid color or multiple colors that can be selected based on a state.
		/// </returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.content.res.ColorStateList getColorStateList(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				return loadColorStateList(value, id);
			}
		}

		/// <summary>Return a boolean associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return a boolean associated with a particular resource ID.  This can be
		/// used with any integral resource value, and will return true if it is
		/// non-zero.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>Returns the boolean value contained in the resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual bool getBoolean(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type >= android.util.TypedValue.TYPE_FIRST_INT && value.type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return value.data != 0;
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>Return an integer associated with a particular resource ID.</summary>
		/// <remarks>Return an integer associated with a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>Returns the integer value contained in the resource.</returns>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual int getInteger(int id)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type >= android.util.TypedValue.TYPE_FIRST_INT && value.type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return value.data;
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <summary>
		/// Return an XmlResourceParser through which you can read a view layout
		/// description for the given resource ID.
		/// </summary>
		/// <remarks>
		/// Return an XmlResourceParser through which you can read a view layout
		/// description for the given resource ID.  This parser has limited
		/// functionality -- in particular, you can't change its input, and only
		/// the high-level events are available.
		/// <p>This function is really a simple wrapper for calling
		/// <see cref="getXml(int)">getXml(int)</see>
		/// with a layout resource.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// A new parser object through which you can read
		/// the XML data.
		/// </returns>
		/// <seealso cref="getXml(int)">getXml(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.content.res.XmlResourceParser getLayout(int id)
		{
			return loadXmlResourceParser(id, "layout");
		}

		/// <summary>
		/// Return an XmlResourceParser through which you can read an animation
		/// description for the given resource ID.
		/// </summary>
		/// <remarks>
		/// Return an XmlResourceParser through which you can read an animation
		/// description for the given resource ID.  This parser has limited
		/// functionality -- in particular, you can't change its input, and only
		/// the high-level events are available.
		/// <p>This function is really a simple wrapper for calling
		/// <see cref="getXml(int)">getXml(int)</see>
		/// with an animation resource.
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// A new parser object through which you can read
		/// the XML data.
		/// </returns>
		/// <seealso cref="getXml(int)">getXml(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.content.res.XmlResourceParser getAnimation(int id)
		{
			return loadXmlResourceParser(id, "anim");
		}

		/// <summary>
		/// Return an XmlResourceParser through which you can read a generic XML
		/// resource for the given resource ID.
		/// </summary>
		/// <remarks>
		/// Return an XmlResourceParser through which you can read a generic XML
		/// resource for the given resource ID.
		/// <p>The XmlPullParser implementation returned here has some limited
		/// functionality.  In particular, you can't change its input, and only
		/// high-level parsing events are available (since the document was
		/// pre-parsed for you at build time, which involved merging text and
		/// stripping comments).
		/// </remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <returns>
		/// A new parser object through which you can read
		/// the XML data.
		/// </returns>
		/// <seealso cref="android.util.AttributeSet">android.util.AttributeSet</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual android.content.res.XmlResourceParser getXml(int id)
		{
			return loadXmlResourceParser(id, "xml");
		}

		[Sharpen.Stub]
		public virtual java.io.InputStream openRawResource(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.io.InputStream openRawResource(int id, android.util.TypedValue
			 value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.content.res.AssetFileDescriptor openRawResourceFd(int id)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Return the raw data associated with a particular resource ID.</summary>
		/// <remarks>Return the raw data associated with a particular resource ID.</remarks>
		/// <param name="id">
		/// The desired resource identifier, as generated by the aapt
		/// tool. This integer encodes the package, type, and resource
		/// entry. The value 0 is an invalid identifier.
		/// </param>
		/// <param name="outValue">Object in which to place the resource data.</param>
		/// <param name="resolveRefs">
		/// If true, a resource that is a reference to another
		/// resource will be followed so that you receive the
		/// actual final resource data.  If false, the TypedValue
		/// will be filled in with the reference itself.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual void getValue(int id, android.util.TypedValue outValue, bool resolveRefs
			)
		{
			bool found = mAssets.getResourceValue(id, 0, outValue, resolveRefs);
			if (found)
			{
				return;
			}
			throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
				(id));
		}

		/// <summary>Get the raw value associated with a resource with associated density.</summary>
		/// <remarks>Get the raw value associated with a resource with associated density.</remarks>
		/// <param name="id">resource identifier</param>
		/// <param name="density">density in DPI</param>
		/// <param name="resolveRefs">
		/// If true, a resource that is a reference to another
		/// resource will be followed so that you receive the actual final
		/// resource data. If false, the TypedValue will be filled in with
		/// the reference itself.
		/// </param>
		/// <exception cref="NotFoundException">
		/// Throws NotFoundException if the given ID does
		/// not exist.
		/// </exception>
		/// <seealso cref="getValue(string, android.util.TypedValue, bool)">getValue(string, android.util.TypedValue, bool)
		/// 	</seealso>
		/// <hide></hide>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual void getValueForDensity(int id, int density, android.util.TypedValue
			 outValue, bool resolveRefs)
		{
			bool found = mAssets.getResourceValue(id, density, outValue, resolveRefs);
			if (found)
			{
				return;
			}
			throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
				(id));
		}

		/// <summary>Return the raw data associated with a particular resource ID.</summary>
		/// <remarks>
		/// Return the raw data associated with a particular resource ID.
		/// See getIdentifier() for information on how names are mapped to resource
		/// IDs, and getString(int) for information on how string resources are
		/// retrieved.
		/// <p>Note: use of this function is discouraged.  It is much more
		/// efficient to retrieve resources by identifier than by name.
		/// </remarks>
		/// <param name="name">
		/// The name of the desired resource.  This is passed to
		/// getIdentifier() with a default type of "string".
		/// </param>
		/// <param name="outValue">Object in which to place the resource data.</param>
		/// <param name="resolveRefs">
		/// If true, a resource that is a reference to another
		/// resource will be followed so that you receive the
		/// actual final resource data.  If false, the TypedValue
		/// will be filled in with the reference itself.
		/// </param>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual void getValue(string name, android.util.TypedValue outValue, bool 
			resolveRefs)
		{
			int id = getIdentifier(name, "string", null);
			if (id != 0)
			{
				getValue(id, outValue, resolveRefs);
				return;
			}
			throw new android.content.res.Resources.NotFoundException("String resource name "
				 + name);
		}

		/// <summary>This class holds the current attribute values for a particular theme.</summary>
		/// <remarks>
		/// This class holds the current attribute values for a particular theme.
		/// In other words, a Theme is a set of values for resource attributes;
		/// these are used in conjunction with
		/// <see cref="TypedArray">TypedArray</see>
		/// to resolve the final value for an attribute.
		/// <p>The Theme's attributes come into play in two ways: (1) a styled
		/// attribute can explicit reference a value in the theme through the
		/// "?themeAttribute" syntax; (2) if no value has been defined for a
		/// particular styled attribute, as a last resort we will try to find that
		/// attribute's value in the Theme.
		/// <p>You will normally use the
		/// <see cref="obtainStyledAttributes(int[])">obtainStyledAttributes(int[])</see>
		/// APIs to
		/// retrieve XML attributes with style and theme information applied.
		/// </remarks>
		public sealed partial class Theme : System.IDisposable
		{
			/// <summary>Place new attribute values into the theme.</summary>
			/// <remarks>
			/// Place new attribute values into the theme.  The style resource
			/// specified by <var>resid</var> will be retrieved from this Theme's
			/// resources, its values placed into the Theme object.
			/// <p>The semantics of this function depends on the <var>force</var>
			/// argument:  If false, only values that are not already defined in
			/// the theme will be copied from the system resource; otherwise, if
			/// any of the style's attributes are already defined in the theme, the
			/// current values in the theme will be overwritten.
			/// </remarks>
			/// <param name="resid">
			/// The resource ID of a style resource from which to
			/// obtain attribute values.
			/// </param>
			/// <param name="force">
			/// If true, values in the style resource will always be
			/// used in the theme; otherwise, they will only be used
			/// if not already defined in the theme.
			/// </param>
			public void applyStyle(int resid, bool force)
			{
				android.content.res.AssetManager.applyThemeStyle(this.mTheme, resid, force);
			}

			/// <summary>
			/// Set this theme to hold the same contents as the theme
			/// <var>other</var>.
			/// </summary>
			/// <remarks>
			/// Set this theme to hold the same contents as the theme
			/// <var>other</var>.  If both of these themes are from the same
			/// Resources object, they will be identical after this function
			/// returns.  If they are from different Resources, only the resources
			/// they have in common will be set in this theme.
			/// </remarks>
			/// <param name="other">The existing Theme to copy from.</param>
			public void setTo(android.content.res.Resources.Theme other)
			{
				android.content.res.AssetManager.copyTheme(this.mTheme, other.mTheme);
			}

			/// <summary>
			/// Return a StyledAttributes holding the values defined by
			/// <var>Theme</var> which are listed in <var>attrs</var>.
			/// </summary>
			/// <remarks>
			/// Return a StyledAttributes holding the values defined by
			/// <var>Theme</var> which are listed in <var>attrs</var>.
			/// <p>Be sure to call StyledAttributes.recycle() when you are done with
			/// the array.
			/// </remarks>
			/// <param name="attrs">The desired attributes.</param>
			/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
			/// 	</exception>
			/// <returns>
			/// Returns a TypedArray holding an array of the attribute values.
			/// Be sure to call
			/// <see cref="TypedArray.recycle()">TypedArray.recycle()</see>
			/// when done with it.
			/// </returns>
			/// <seealso cref="Resources.obtainAttributes(android.util.AttributeSet, int[])">Resources.obtainAttributes(android.util.AttributeSet, int[])
			/// 	</seealso>
			/// <seealso cref="obtainStyledAttributes(int, int[])">obtainStyledAttributes(int, int[])
			/// 	</seealso>
			/// <seealso cref="obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
			/// 	">obtainStyledAttributes(android.util.AttributeSet, int[], int, int)</seealso>
			public android.content.res.TypedArray obtainStyledAttributes(int[] attrs)
			{
				int len = attrs.Length;
				android.content.res.TypedArray array = this._enclosing.getCachedStyledAttributes(
					len);
				array.mRsrcs = attrs;
				android.content.res.AssetManager.applyStyle(this.mTheme, 0, 0, null, attrs, array
					.mData, array.mIndices);
				return array;
			}

			/// <summary>
			/// Return a StyledAttributes holding the values defined by the style
			/// resource <var>resid</var> which are listed in <var>attrs</var>.
			/// </summary>
			/// <remarks>
			/// Return a StyledAttributes holding the values defined by the style
			/// resource <var>resid</var> which are listed in <var>attrs</var>.
			/// <p>Be sure to call StyledAttributes.recycle() when you are done with
			/// the array.
			/// </remarks>
			/// <param name="resid">The desired style resource.</param>
			/// <param name="attrs">The desired attributes in the style.</param>
			/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
			/// 	</exception>
			/// <returns>
			/// Returns a TypedArray holding an array of the attribute values.
			/// Be sure to call
			/// <see cref="TypedArray.recycle()">TypedArray.recycle()</see>
			/// when done with it.
			/// </returns>
			/// <seealso cref="Resources.obtainAttributes(android.util.AttributeSet, int[])">Resources.obtainAttributes(android.util.AttributeSet, int[])
			/// 	</seealso>
			/// <seealso cref="obtainStyledAttributes(int[])">obtainStyledAttributes(int[])</seealso>
			/// <seealso cref="obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
			/// 	">obtainStyledAttributes(android.util.AttributeSet, int[], int, int)</seealso>
			/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
			public android.content.res.TypedArray obtainStyledAttributes(int resid, int[] attrs
				)
			{
				int len = attrs.Length;
				android.content.res.TypedArray array = this._enclosing.getCachedStyledAttributes(
					len);
				array.mRsrcs = attrs;
				android.content.res.AssetManager.applyStyle(this.mTheme, 0, resid, null, attrs, array
					.mData, array.mIndices);
				if (false)
				{
					int[] data = array.mData;
					java.io.Console.Out.println("**********************************************************"
						);
					java.io.Console.Out.println("**********************************************************"
						);
					java.io.Console.Out.println("**********************************************************"
						);
					java.io.Console.Out.println("Attributes:");
					string s = "  Attrs:";
					int i;
					for (i = 0; i < attrs.Length; i++)
					{
						s = s + " 0x" + Sharpen.Util.IntToHexString(attrs[i]);
					}
					java.io.Console.Out.println(s);
					s = "  Found:";
					android.util.TypedValue value = new android.util.TypedValue();
					for (i = 0; i < attrs.Length; i++)
					{
						int d = i * android.content.res.AssetManager.STYLE_NUM_ENTRIES;
						value.type = data[d + android.content.res.AssetManager.STYLE_TYPE];
						value.data = data[d + android.content.res.AssetManager.STYLE_DATA];
						value.assetCookie = data[d + android.content.res.AssetManager.STYLE_ASSET_COOKIE];
						value.resourceId = data[d + android.content.res.AssetManager.STYLE_RESOURCE_ID];
						s = s + " 0x" + Sharpen.Util.IntToHexString(attrs[i]) + "=" + value;
					}
					java.io.Console.Out.println(s);
				}
				return array;
			}

			/// <summary>
			/// Return a StyledAttributes holding the attribute values in
			/// <var>set</var>
			/// that are listed in <var>attrs</var>.
			/// </summary>
			/// <remarks>
			/// Return a StyledAttributes holding the attribute values in
			/// <var>set</var>
			/// that are listed in <var>attrs</var>.  In addition, if the given
			/// AttributeSet specifies a style class (through the "style" attribute),
			/// that style will be applied on top of the base attributes it defines.
			/// <p>Be sure to call StyledAttributes.recycle() when you are done with
			/// the array.
			/// <p>When determining the final value of a particular attribute, there
			/// are four inputs that come into play:</p>
			/// <ol>
			/// <li> Any attribute values in the given AttributeSet.
			/// <li> The style resource specified in the AttributeSet (named
			/// "style").
			/// <li> The default style specified by <var>defStyleAttr</var> and
			/// <var>defStyleRes</var>
			/// <li> The base values in this theme.
			/// </ol>
			/// <p>Each of these inputs is considered in-order, with the first listed
			/// taking precedence over the following ones.  In other words, if in the
			/// AttributeSet you have supplied <code>&lt;Button
			/// textColor="#ff000000"&gt;</code>, then the button's text will
			/// <em>always</em> be black, regardless of what is specified in any of
			/// the styles.
			/// </remarks>
			/// <param name="set">The base set of attribute values.  May be null.</param>
			/// <param name="attrs">The desired attributes to be retrieved.</param>
			/// <param name="defStyleAttr">
			/// An attribute in the current theme that contains a
			/// reference to a style resource that supplies
			/// defaults values for the StyledAttributes.  Can be
			/// 0 to not look for defaults.
			/// </param>
			/// <param name="defStyleRes">
			/// A resource identifier of a style resource that
			/// supplies default values for the StyledAttributes,
			/// used only if defStyleAttr is 0 or can not be found
			/// in the theme.  Can be 0 to not look for defaults.
			/// </param>
			/// <returns>
			/// Returns a TypedArray holding an array of the attribute values.
			/// Be sure to call
			/// <see cref="TypedArray.recycle()">TypedArray.recycle()</see>
			/// when done with it.
			/// </returns>
			/// <seealso cref="Resources.obtainAttributes(android.util.AttributeSet, int[])">Resources.obtainAttributes(android.util.AttributeSet, int[])
			/// 	</seealso>
			/// <seealso cref="obtainStyledAttributes(int[])">obtainStyledAttributes(int[])</seealso>
			/// <seealso cref="obtainStyledAttributes(int, int[])">obtainStyledAttributes(int, int[])
			/// 	</seealso>
			public android.content.res.TypedArray obtainStyledAttributes(android.util.AttributeSet
				 set, int[] attrs, int defStyleAttr, int defStyleRes)
			{
				int len = attrs.Length;
				android.content.res.TypedArray array = this._enclosing.getCachedStyledAttributes(
					len);
				// XXX note that for now we only work with compiled XML files.
				// To support generic XML files we will need to manually parse
				// out the attributes from the XML file (applying type information
				// contained in the resources and such).
				android.content.res.XmlBlock.Parser parser = (android.content.res.XmlBlock.Parser
					)set;
				android.content.res.AssetManager.applyStyle(this.mTheme, defStyleAttr, defStyleRes
					, parser != null ? parser.mParseState : null, attrs, array.mData, array.mIndices
					);
				array.mRsrcs = attrs;
				array.mXml = parser;
				if (false)
				{
					int[] data = array.mData;
					java.io.Console.Out.println("Attributes:");
					string s = "  Attrs:";
					int i;
					for (i = 0; i < set.getAttributeCount(); i++)
					{
						s = s + " " + set.getAttributeName(i);
						int id = set.getAttributeNameResource(i);
						if (id != 0)
						{
							s = s + "(0x" + Sharpen.Util.IntToHexString(id) + ")";
						}
						s = s + "=" + set.getAttributeValue(i);
					}
					java.io.Console.Out.println(s);
					s = "  Found:";
					android.util.TypedValue value = new android.util.TypedValue();
					for (i = 0; i < attrs.Length; i++)
					{
						int d = i * android.content.res.AssetManager.STYLE_NUM_ENTRIES;
						value.type = data[d + android.content.res.AssetManager.STYLE_TYPE];
						value.data = data[d + android.content.res.AssetManager.STYLE_DATA];
						value.assetCookie = data[d + android.content.res.AssetManager.STYLE_ASSET_COOKIE];
						value.resourceId = data[d + android.content.res.AssetManager.STYLE_RESOURCE_ID];
						s = s + " 0x" + Sharpen.Util.IntToHexString(attrs[i]) + "=" + value;
					}
					java.io.Console.Out.println(s);
				}
				return array;
			}

			/// <summary>Retrieve the value of an attribute in the Theme.</summary>
			/// <remarks>
			/// Retrieve the value of an attribute in the Theme.  The contents of
			/// <var>outValue</var> are ultimately filled in by
			/// <see cref="Resources.getValue(int, android.util.TypedValue, bool)">Resources.getValue(int, android.util.TypedValue, bool)
			/// 	</see>
			/// .
			/// </remarks>
			/// <param name="resid">
			/// The resource identifier of the desired theme
			/// attribute.
			/// </param>
			/// <param name="outValue">
			/// Filled in with the ultimate resource value supplied
			/// by the attribute.
			/// </param>
			/// <param name="resolveRefs">
			/// If true, resource references will be walked; if
			/// false, <var>outValue</var> may be a
			/// TYPE_REFERENCE.  In either case, it will never
			/// be a TYPE_ATTRIBUTE.
			/// </param>
			/// <returns>
			/// boolean Returns true if the attribute was found and
			/// <var>outValue</var> is valid, else false.
			/// </returns>
			public bool resolveAttribute(int resid, android.util.TypedValue outValue, bool resolveRefs
				)
			{
				bool got = this.mAssets.getThemeValue(this.mTheme, resid, outValue, resolveRefs);
				if (false)
				{
					java.io.Console.Out.println("resolveAttribute #" + Sharpen.Util.IntToHexString(resid
						) + " got=" + got + ", type=0x" + Sharpen.Util.IntToHexString(outValue.type) + ", data=0x"
						 + Sharpen.Util.IntToHexString(outValue.data));
				}
				return got;
			}

			[Sharpen.Stub]
			public void dump(int priority, string tag, string prefix)
			{
				throw new System.NotImplementedException();
			}

			internal Theme(Resources _enclosing)
			{
				this._enclosing = _enclosing;
				this.mAssets = this._enclosing.mAssets;
				this.mTheme = this.mAssets.createTheme();
			}

			private readonly android.content.res.AssetManager mAssets;

			internal readonly android.content.res.Resources.Theme.NativeTheme mTheme;

			public void Dispose()
			{
				mTheme.Dispose();
			}

			internal class NativeTheme : System.Runtime.InteropServices.SafeHandle
			{
				internal NativeTheme() : base(System.IntPtr.Zero, true)
				{
				}

				internal NativeTheme(System.IntPtr handle) : base(System.IntPtr.Zero, true)
				{
					this.handle = handle;
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_content_res_Resources_Theme_destructor
					(System.IntPtr handle);

				internal System.IntPtr Handle
				{
					get
					{
						return handle;
					}
				}

				public static readonly NativeTheme Zero = new NativeTheme();

				protected override bool ReleaseHandle()
				{
					if (handle != System.IntPtr.Zero)
					{
						libxobotos_android_content_res_Resources_Theme_destructor(handle);
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

			private readonly Resources _enclosing;
		}

		/// <summary>Generate a new Theme object for this set of Resources.</summary>
		/// <remarks>
		/// Generate a new Theme object for this set of Resources.  It initially
		/// starts out empty.
		/// </remarks>
		/// <returns>Theme The newly created Theme container.</returns>
		public android.content.res.Resources.Theme newTheme()
		{
			return new android.content.res.Resources.Theme(this);
		}

		/// <summary>
		/// Retrieve a set of basic attribute values from an AttributeSet, not
		/// performing styling of them using a theme and/or style resources.
		/// </summary>
		/// <remarks>
		/// Retrieve a set of basic attribute values from an AttributeSet, not
		/// performing styling of them using a theme and/or style resources.
		/// </remarks>
		/// <param name="set">The current attribute values to retrieve.</param>
		/// <param name="attrs">The specific attributes to be retrieved.</param>
		/// <returns>
		/// Returns a TypedArray holding an array of the attribute values.
		/// Be sure to call
		/// <see cref="TypedArray.recycle()">TypedArray.recycle()</see>
		/// when done with it.
		/// </returns>
		/// <seealso cref="Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
		/// 	">Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)</seealso>
		public virtual android.content.res.TypedArray obtainAttributes(android.util.AttributeSet
			 set, int[] attrs)
		{
			int len = attrs.Length;
			android.content.res.TypedArray array = getCachedStyledAttributes(len);
			// XXX note that for now we only work with compiled XML files.
			// To support generic XML files we will need to manually parse
			// out the attributes from the XML file (applying type information
			// contained in the resources and such).
			android.content.res.XmlBlock.Parser parser = (android.content.res.XmlBlock.Parser
				)set;
			mAssets.retrieveAttributes(parser.mParseState, attrs, array.mData, array.mIndices
				);
			array.mRsrcs = attrs;
			array.mXml = parser;
			return array;
		}

		/// <summary>Store the newly updated configuration.</summary>
		/// <remarks>Store the newly updated configuration.</remarks>
		public virtual void updateConfiguration(android.content.res.Configuration config, 
			android.util.DisplayMetrics metrics)
		{
			updateConfiguration(config, metrics, null);
		}

		/// <hide></hide>
		public virtual void updateConfiguration(android.content.res.Configuration config, 
			android.util.DisplayMetrics metrics, android.content.res.CompatibilityInfo compat
			)
		{
			lock (mTmpValue)
			{
				if (false)
				{
					android.util.Slog.i(TAG, "**** Updating config of " + this + ": old config is " +
						 mConfiguration + " old compat is " + mCompatibilityInfo);
					android.util.Slog.i(TAG, "**** Updating config of " + this + ": new config is " +
						 config + " new compat is " + compat);
				}
				if (compat != null)
				{
					mCompatibilityInfo = compat;
				}
				if (metrics != null)
				{
					mMetrics.setTo(metrics);
				}
				// NOTE: We should re-arrange this code to create a Display
				// with the CompatibilityInfo that is used everywhere we deal
				// with the display in relation to this app, rather than
				// doing the conversion here.  This impl should be okay because
				// we make sure to return a compatible display in the places
				// where there are public APIs to retrieve the display...  but
				// it would be cleaner and more maintainble to just be
				// consistently dealing with a compatible display everywhere in
				// the framework.
				if (mCompatibilityInfo != null)
				{
					mCompatibilityInfo.applyToDisplayMetrics(mMetrics);
				}
				int configChanges = unchecked((int)(0xfffffff));
				if (config != null)
				{
					mTmpConfig.setTo(config);
					if (mCompatibilityInfo != null)
					{
						mCompatibilityInfo.applyToConfiguration(mTmpConfig);
					}
					if (mTmpConfig.locale == null)
					{
						mTmpConfig.locale = System.Globalization.CultureInfo.CurrentCulture;
					}
					configChanges = mConfiguration.updateFrom(mTmpConfig);
					configChanges = android.content.pm.ActivityInfo.activityInfoConfigToNative(configChanges
						);
				}
				if (mConfiguration.locale == null)
				{
					mConfiguration.locale = System.Globalization.CultureInfo.CurrentCulture;
				}
				mMetrics.scaledDensity = mMetrics.density * mConfiguration.fontScale;
				string locale = null;
				if (mConfiguration.locale != null)
				{
					locale = Sharpen.Util.GetLanguage(mConfiguration.locale);
					if (Sharpen.Util.GetCountry(mConfiguration.locale) != null)
					{
						locale += "-" + Sharpen.Util.GetCountry(mConfiguration.locale);
					}
				}
				int width;
				int height;
				if (mMetrics.widthPixels >= mMetrics.heightPixels)
				{
					width = mMetrics.widthPixels;
					height = mMetrics.heightPixels;
				}
				else
				{
					//noinspection SuspiciousNameCombination
					width = mMetrics.heightPixels;
					//noinspection SuspiciousNameCombination
					height = mMetrics.widthPixels;
				}
				int keyboardHidden = mConfiguration.keyboardHidden;
				if (keyboardHidden == android.content.res.Configuration.KEYBOARDHIDDEN_NO && mConfiguration
					.hardKeyboardHidden == android.content.res.Configuration.HARDKEYBOARDHIDDEN_YES)
				{
					keyboardHidden = android.content.res.Configuration.KEYBOARDHIDDEN_SOFT;
				}
				mAssets.setConfiguration(mConfiguration.mcc, mConfiguration.mnc, locale, mConfiguration
					.orientation, mConfiguration.touchscreen, (int)(mMetrics.density * 160), mConfiguration
					.keyboard, keyboardHidden, mConfiguration.navigation, width, height, mConfiguration
					.smallestScreenWidthDp, mConfiguration.screenWidthDp, mConfiguration.screenHeightDp
					, mConfiguration.screenLayout, mConfiguration.uiMode, android.os.Build.VERSION.RESOURCES_SDK_INT
					);
				clearDrawableCache(mDrawableCache, configChanges);
				clearDrawableCache(mColorDrawableCache, configChanges);
				mColorStateListCache.clear();
				flushLayoutCache();
			}
			lock (mSync)
			{
				if (mPluralRule != null)
				{
					mPluralRule = libcore.icu.NativePluralRules.forLocale(config.locale);
				}
			}
		}

		private void clearDrawableCache(android.util.LongSparseArray<java.lang.@ref.WeakReference
			<android.graphics.drawable.Drawable.ConstantState>> cache, int configChanges)
		{
			int N = cache.size();
			{
				for (int i = 0; i < N; i++)
				{
					java.lang.@ref.WeakReference<android.graphics.drawable.Drawable.ConstantState> @ref
						 = cache.valueAt(i);
					if (@ref != null)
					{
						android.graphics.drawable.Drawable.ConstantState cs = @ref.get();
						if (cs != null)
						{
							if (android.content.res.Configuration.needNewResources(configChanges, cs.getChangingConfigurations
								()))
							{
								cache.setValueAt(i, null);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Update the system resources configuration if they have previously
		/// been initialized.
		/// </summary>
		/// <remarks>
		/// Update the system resources configuration if they have previously
		/// been initialized.
		/// </remarks>
		/// <hide></hide>
		public static void updateSystemConfiguration(android.content.res.Configuration config
			, android.util.DisplayMetrics metrics, android.content.res.CompatibilityInfo compat
			)
		{
			if (mSystem != null)
			{
				mSystem.updateConfiguration(config, metrics, compat);
			}
		}

		//Log.i(TAG, "Updated system resources " + mSystem
		//        + ": " + mSystem.getConfiguration());
		/// <hide></hide>
		public static void updateSystemConfiguration(android.content.res.Configuration config
			, android.util.DisplayMetrics metrics)
		{
			updateSystemConfiguration(config, metrics, null);
		}

		/// <summary>
		/// Return the current display metrics that are in effect for this resource
		/// object.
		/// </summary>
		/// <remarks>
		/// Return the current display metrics that are in effect for this resource
		/// object.  The returned object should be treated as read-only.
		/// </remarks>
		/// <returns>The resource's current display metrics.</returns>
		public virtual android.util.DisplayMetrics getDisplayMetrics()
		{
			return mMetrics;
		}

		/// <summary>
		/// Return the current configuration that is in effect for this resource
		/// object.
		/// </summary>
		/// <remarks>
		/// Return the current configuration that is in effect for this resource
		/// object.  The returned object should be treated as read-only.
		/// </remarks>
		/// <returns>The resource's current configuration.</returns>
		public virtual android.content.res.Configuration getConfiguration()
		{
			return mConfiguration;
		}

		/// <summary>Return the compatibility mode information for the application.</summary>
		/// <remarks>
		/// Return the compatibility mode information for the application.
		/// The returned object should be treated as read-only.
		/// </remarks>
		/// <returns>compatibility info.</returns>
		/// <hide></hide>
		public virtual android.content.res.CompatibilityInfo getCompatibilityInfo()
		{
			return mCompatibilityInfo != null ? mCompatibilityInfo : android.content.res.CompatibilityInfo
				.DEFAULT_COMPATIBILITY_INFO;
		}

		/// <summary>This is just for testing.</summary>
		/// <remarks>This is just for testing.</remarks>
		/// <hide></hide>
		public virtual void setCompatibilityInfo(android.content.res.CompatibilityInfo ci
			)
		{
			mCompatibilityInfo = ci;
			updateConfiguration(mConfiguration, mMetrics);
		}

		/// <summary>Return a resource identifier for the given resource name.</summary>
		/// <remarks>
		/// Return a resource identifier for the given resource name.  A fully
		/// qualified resource name is of the form "package:type/entry".  The first
		/// two components (package and type) are optional if defType and
		/// defPackage, respectively, are specified here.
		/// <p>Note: use of this function is discouraged.  It is much more
		/// efficient to retrieve resources by identifier than by name.
		/// </remarks>
		/// <param name="name">The name of the desired resource.</param>
		/// <param name="defType">
		/// Optional default resource type to find, if "type/" is
		/// not included in the name.  Can be null to require an
		/// explicit type.
		/// </param>
		/// <param name="defPackage">
		/// Optional default package to find, if "package:" is
		/// not included in the name.  Can be null to require an
		/// explicit package.
		/// </param>
		/// <returns>
		/// int The associated resource identifier.  Returns 0 if no such
		/// resource was found.  (0 is not a valid resource ID.)
		/// </returns>
		public virtual int getIdentifier(string name, string defType, string defPackage)
		{
			try
			{
				return System.Convert.ToInt32(name);
			}
			catch (System.Exception)
			{
			}
			// Ignore
			return mAssets.getResourceIdentifier(name, defType, defPackage);
		}

		/// <summary>Return the full name for a given resource identifier.</summary>
		/// <remarks>
		/// Return the full name for a given resource identifier.  This name is
		/// a single string of the form "package:type/entry".
		/// </remarks>
		/// <param name="resid">The resource identifier whose name is to be retrieved.</param>
		/// <returns>A string holding the name of the resource.</returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getResourcePackageName(int)">getResourcePackageName(int)</seealso>
		/// <seealso cref="getResourceTypeName(int)">getResourceTypeName(int)</seealso>
		/// <seealso cref="getResourceEntryName(int)">getResourceEntryName(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getResourceName(int resid)
		{
			string str = mAssets.getResourceName(resid);
			if (str != null)
			{
				return str;
			}
			throw new android.content.res.Resources.NotFoundException("Unable to find resource ID #0x"
				 + Sharpen.Util.IntToHexString(resid));
		}

		/// <summary>Return the package name for a given resource identifier.</summary>
		/// <remarks>Return the package name for a given resource identifier.</remarks>
		/// <param name="resid">
		/// The resource identifier whose package name is to be
		/// retrieved.
		/// </param>
		/// <returns>A string holding the package name of the resource.</returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getResourceName(int)">getResourceName(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getResourcePackageName(int resid)
		{
			string str = mAssets.getResourcePackageName(resid);
			if (str != null)
			{
				return str;
			}
			throw new android.content.res.Resources.NotFoundException("Unable to find resource ID #0x"
				 + Sharpen.Util.IntToHexString(resid));
		}

		/// <summary>Return the type name for a given resource identifier.</summary>
		/// <remarks>Return the type name for a given resource identifier.</remarks>
		/// <param name="resid">
		/// The resource identifier whose type name is to be
		/// retrieved.
		/// </param>
		/// <returns>A string holding the type name of the resource.</returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getResourceName(int)">getResourceName(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getResourceTypeName(int resid)
		{
			string str = mAssets.getResourceTypeName(resid);
			if (str != null)
			{
				return str;
			}
			throw new android.content.res.Resources.NotFoundException("Unable to find resource ID #0x"
				 + Sharpen.Util.IntToHexString(resid));
		}

		/// <summary>Return the entry name for a given resource identifier.</summary>
		/// <remarks>Return the entry name for a given resource identifier.</remarks>
		/// <param name="resid">
		/// The resource identifier whose entry name is to be
		/// retrieved.
		/// </param>
		/// <returns>A string holding the entry name of the resource.</returns>
		/// <exception cref="NotFoundException">Throws NotFoundException if the given ID does not exist.
		/// 	</exception>
		/// <seealso cref="getResourceName(int)">getResourceName(int)</seealso>
		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		public virtual string getResourceEntryName(int resid)
		{
			string str = mAssets.getResourceEntryName(resid);
			if (str != null)
			{
				return str;
			}
			throw new android.content.res.Resources.NotFoundException("Unable to find resource ID #0x"
				 + Sharpen.Util.IntToHexString(resid));
		}

		[Sharpen.Stub]
		public virtual void parseBundleExtras(android.content.res.XmlResourceParser parser
			, android.os.Bundle outBundle)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>Parse a name/value pair out of an XML tag holding that data.</summary>
		/// <remarks>
		/// Parse a name/value pair out of an XML tag holding that data.  The
		/// AttributeSet must be holding the data defined by
		/// <see cref="android.R.styleable.Extra">android.R.styleable.Extra</see>
		/// .  The following value types are supported:
		/// <ul>
		/// <li>
		/// <see cref="android.util.TypedValue.TYPE_STRING">android.util.TypedValue.TYPE_STRING
		/// 	</see>
		/// :
		/// <see cref="android.os.Bundle.putCharSequence(string, java.lang.CharSequence)">Bundle.putCharSequence()
		/// 	</see>
		/// <li>
		/// <see cref="android.util.TypedValue.TYPE_INT_BOOLEAN">android.util.TypedValue.TYPE_INT_BOOLEAN
		/// 	</see>
		/// :
		/// <see cref="android.os.Bundle.putCharSequence(string, java.lang.CharSequence)">Bundle.putBoolean()
		/// 	</see>
		/// <li>
		/// <see cref="android.util.TypedValue.TYPE_FIRST_INT">android.util.TypedValue.TYPE_FIRST_INT
		/// 	</see>
		/// -
		/// <see cref="android.util.TypedValue.TYPE_LAST_INT">android.util.TypedValue.TYPE_LAST_INT
		/// 	</see>
		/// :
		/// <see cref="android.os.Bundle.putCharSequence(string, java.lang.CharSequence)">Bundle.putBoolean()
		/// 	</see>
		/// <li>
		/// <see cref="android.util.TypedValue.TYPE_FLOAT">android.util.TypedValue.TYPE_FLOAT
		/// 	</see>
		/// :
		/// <see cref="android.os.Bundle.putCharSequence(string, java.lang.CharSequence)">Bundle.putFloat()
		/// 	</see>
		/// </ul>
		/// </remarks>
		/// <param name="tagName">
		/// The name of the tag these attributes come from; this is
		/// only used for reporting error messages.
		/// </param>
		/// <param name="attrs">The attributes from which to retrieve the name/value pair.</param>
		/// <param name="outBundle">The Bundle in which to place the parsed value.</param>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException">If the attributes are not valid.
		/// 	</exception>
		public virtual void parseBundleExtra(string tagName, android.util.AttributeSet attrs
			, android.os.Bundle outBundle)
		{
			android.content.res.TypedArray sa = obtainAttributes(attrs, android.@internal.R.styleable
				.Extra);
			string name = sa.getString(android.@internal.R.styleable.Extra_name);
			if (name == null)
			{
				sa.recycle();
				throw new org.xmlpull.v1.XmlPullParserException("<" + tagName + "> requires an android:name attribute at "
					 + attrs.getPositionDescription());
			}
			android.util.TypedValue v = sa.peekValue(android.@internal.R.styleable.Extra_value
				);
			if (v != null)
			{
				if (v.type == android.util.TypedValue.TYPE_STRING)
				{
					java.lang.CharSequence cs = v.coerceToString();
					outBundle.putCharSequence(name, cs);
				}
				else
				{
					if (v.type == android.util.TypedValue.TYPE_INT_BOOLEAN)
					{
						outBundle.putBoolean(name, v.data != 0);
					}
					else
					{
						if (v.type >= android.util.TypedValue.TYPE_FIRST_INT && v.type <= android.util.TypedValue
							.TYPE_LAST_INT)
						{
							outBundle.putInt(name, v.data);
						}
						else
						{
							if (v.type == android.util.TypedValue.TYPE_FLOAT)
							{
								outBundle.putFloat(name, v.getFloat());
							}
							else
							{
								sa.recycle();
								throw new org.xmlpull.v1.XmlPullParserException("<" + tagName + "> only supports string, integer, float, color, and boolean at "
									 + attrs.getPositionDescription());
							}
						}
					}
				}
			}
			else
			{
				sa.recycle();
				throw new org.xmlpull.v1.XmlPullParserException("<" + tagName + "> requires an android:value or android:resource attribute at "
					 + attrs.getPositionDescription());
			}
			sa.recycle();
		}

		/// <summary>Retrieve underlying AssetManager storage for these resources.</summary>
		/// <remarks>Retrieve underlying AssetManager storage for these resources.</remarks>
		public android.content.res.AssetManager getAssets()
		{
			return mAssets;
		}

		/// <summary>
		/// Call this to remove all cached loaded layout resources from the
		/// Resources object.
		/// </summary>
		/// <remarks>
		/// Call this to remove all cached loaded layout resources from the
		/// Resources object.  Only intended for use with performance testing
		/// tools.
		/// </remarks>
		public void flushLayoutCache()
		{
			lock (mCachedXmlBlockIds)
			{
				// First see if this block is in our cache.
				int num = mCachedXmlBlockIds.Length;
				{
					for (int i = 0; i < num; i++)
					{
						mCachedXmlBlockIds[i] = -0;
						android.content.res.XmlBlock oldBlock = mCachedXmlBlocks[i];
						if (oldBlock != null)
						{
							oldBlock.close();
						}
						mCachedXmlBlocks[i] = null;
					}
				}
			}
		}

		/// <summary>Start preloading of resource data using this Resources object.</summary>
		/// <remarks>
		/// Start preloading of resource data using this Resources object.  Only
		/// for use by the zygote process for loading common system resources.
		/// <hide></hide>
		/// </remarks>
		public void startPreloading()
		{
			lock (mSync)
			{
				if (mPreloaded)
				{
					throw new System.InvalidOperationException("Resources already preloaded");
				}
				mPreloaded = true;
				mPreloading = true;
			}
		}

		/// <summary>
		/// Called by zygote when it is done preloading resources, to change back
		/// to normal Resources operation.
		/// </summary>
		/// <remarks>
		/// Called by zygote when it is done preloading resources, to change back
		/// to normal Resources operation.
		/// </remarks>
		public void finishPreloading()
		{
			if (mPreloading)
			{
				mPreloading = false;
				flushLayoutCache();
			}
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		internal virtual android.graphics.drawable.Drawable loadDrawable(android.util.TypedValue
			 value, int id)
		{
			// Log only framework resources
			long key = (((long)value.assetCookie) << 32) | value.data;
			bool isColorDrawable = false;
			if (value.type >= android.util.TypedValue.TYPE_FIRST_COLOR_INT && value.type <= android.util.TypedValue
				.TYPE_LAST_COLOR_INT)
			{
				isColorDrawable = true;
			}
			android.graphics.drawable.Drawable dr = getCachedDrawable(isColorDrawable ? mColorDrawableCache
				 : mDrawableCache, key);
			if (dr != null)
			{
				return dr;
			}
			android.graphics.drawable.Drawable.ConstantState cs = isColorDrawable ? sPreloadedColorDrawables
				.get(key) : sPreloadedDrawables.get(key);
			if (cs != null)
			{
				dr = cs.newDrawable(this);
			}
			else
			{
				if (value.type >= android.util.TypedValue.TYPE_FIRST_COLOR_INT && value.type <= android.util.TypedValue
					.TYPE_LAST_COLOR_INT)
				{
					dr = new android.graphics.drawable.ColorDrawable(value.data);
				}
				if (dr == null)
				{
					if (value.@string == null)
					{
						throw new android.content.res.Resources.NotFoundException("Resource is not a Drawable (color or path): "
							 + value);
					}
					string file = value.@string.ToString();
					// Log only framework resources
					if (file.EndsWith(".xml"))
					{
						try
						{
							android.content.res.XmlResourceParser rp = loadXmlResourceParser(file, id, value.
								assetCookie, "drawable");
							dr = android.graphics.drawable.Drawable.createFromXml(this, rp);
							rp.close();
						}
						catch (System.Exception e)
						{
							android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
								.NotFoundException("File " + file + " from drawable resource ID #0x" + Sharpen.Util.IntToHexString
								(id));
							rnf.InnerException = e;
							throw rnf;
						}
					}
					else
					{
						try
						{
							java.io.InputStream @is = mAssets.openNonAsset(value.assetCookie, file, android.content.res.AssetManager
								.ACCESS_STREAMING);
							//                System.out.println("Opened file " + file + ": " + is);
							dr = android.graphics.drawable.Drawable.createFromResourceStream(this, value, @is
								, file, null);
							@is.close();
						}
						catch (System.Exception e)
						{
							//                System.out.println("Created stream: " + dr);
							android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
								.NotFoundException("File " + file + " from drawable resource ID #0x" + Sharpen.Util.IntToHexString
								(id));
							rnf.InnerException = e;
							throw rnf;
						}
					}
				}
			}
			if (dr != null)
			{
				dr.setChangingConfigurations(value.changingConfigurations);
				cs = dr.getConstantState();
				if (cs != null)
				{
					if (mPreloading)
					{
						if (isColorDrawable)
						{
							sPreloadedColorDrawables.put(key, cs);
						}
						else
						{
							sPreloadedDrawables.put(key, cs);
						}
					}
					else
					{
						lock (mTmpValue)
						{
							//Log.i(TAG, "Saving cached drawable @ #" +
							//        Integer.toHexString(key.intValue())
							//        + " in " + this + ": " + cs);
							if (isColorDrawable)
							{
								mColorDrawableCache.put(key, new java.lang.@ref.WeakReference<android.graphics.drawable.Drawable
									.ConstantState>(cs));
							}
							else
							{
								mDrawableCache.put(key, new java.lang.@ref.WeakReference<android.graphics.drawable.Drawable
									.ConstantState>(cs));
							}
						}
					}
				}
			}
			return dr;
		}

		private android.graphics.drawable.Drawable getCachedDrawable(android.util.LongSparseArray
			<java.lang.@ref.WeakReference<android.graphics.drawable.Drawable.ConstantState>>
			 drawableCache, long key)
		{
			lock (mTmpValue)
			{
				java.lang.@ref.WeakReference<android.graphics.drawable.Drawable.ConstantState> wr
					 = drawableCache.get(key);
				if (wr != null)
				{
					// we have the key
					android.graphics.drawable.Drawable.ConstantState entry = wr.get();
					if (entry != null)
					{
						//Log.i(TAG, "Returning cached drawable @ #" +
						//        Integer.toHexString(((Integer)key).intValue())
						//        + " in " + this + ": " + entry);
						return entry.newDrawable(this);
					}
					else
					{
						// our entry has been purged
						drawableCache.delete(key);
					}
				}
			}
			return null;
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		internal virtual android.content.res.ColorStateList loadColorStateList(android.util.TypedValue
			 value, int id)
		{
			// Log only framework resources
			int key = (value.assetCookie << 24) | value.data;
			android.content.res.ColorStateList csl;
			if (value.type >= android.util.TypedValue.TYPE_FIRST_COLOR_INT && value.type <= android.util.TypedValue
				.TYPE_LAST_COLOR_INT)
			{
				csl = mPreloadedColorStateLists.get(key);
				if (csl != null)
				{
					return csl;
				}
				csl = android.content.res.ColorStateList.valueOf(value.data);
				if (mPreloading)
				{
					mPreloadedColorStateLists.put(key, csl);
				}
				return csl;
			}
			csl = getCachedColorStateList(key);
			if (csl != null)
			{
				return csl;
			}
			csl = mPreloadedColorStateLists.get(key);
			if (csl != null)
			{
				return csl;
			}
			if (value.@string == null)
			{
				throw new android.content.res.Resources.NotFoundException("Resource is not a ColorStateList (color or path): "
					 + value);
			}
			string file = value.@string.ToString();
			if (file.EndsWith(".xml"))
			{
				try
				{
					android.content.res.XmlResourceParser rp = loadXmlResourceParser(file, id, value.
						assetCookie, "colorstatelist");
					csl = android.content.res.ColorStateList.createFromXml(this, rp);
					rp.close();
				}
				catch (System.Exception e)
				{
					android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
						.NotFoundException("File " + file + " from color state list resource ID #0x" + Sharpen.Util.IntToHexString
						(id));
					rnf.InnerException = e;
					throw rnf;
				}
			}
			else
			{
				throw new android.content.res.Resources.NotFoundException("File " + file + " from drawable resource ID #0x"
					 + Sharpen.Util.IntToHexString(id) + ": .xml extension required");
			}
			if (csl != null)
			{
				if (mPreloading)
				{
					mPreloadedColorStateLists.put(key, csl);
				}
				else
				{
					lock (mTmpValue)
					{
						//Log.i(TAG, "Saving cached color state list @ #" +
						//        Integer.toHexString(key.intValue())
						//        + " in " + this + ": " + csl);
						mColorStateListCache.put(key, new java.lang.@ref.WeakReference<android.content.res.ColorStateList
							>(csl));
					}
				}
			}
			return csl;
		}

		private android.content.res.ColorStateList getCachedColorStateList(int key)
		{
			lock (mTmpValue)
			{
				java.lang.@ref.WeakReference<android.content.res.ColorStateList> wr = mColorStateListCache
					.get(key);
				if (wr != null)
				{
					// we have the key
					android.content.res.ColorStateList entry = wr.get();
					if (entry != null)
					{
						//Log.i(TAG, "Returning cached color state list @ #" +
						//        Integer.toHexString(((Integer)key).intValue())
						//        + " in " + this + ": " + entry);
						return entry;
					}
					else
					{
						// our entry has been purged
						mColorStateListCache.delete(key);
					}
				}
			}
			return null;
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		internal virtual android.content.res.XmlResourceParser loadXmlResourceParser(int 
			id, string type)
		{
			lock (mTmpValue)
			{
				android.util.TypedValue value = mTmpValue;
				getValue(id, value, true);
				if (value.type == android.util.TypedValue.TYPE_STRING)
				{
					return loadXmlResourceParser(value.@string.ToString(), id, value.assetCookie, type
						);
				}
				throw new android.content.res.Resources.NotFoundException("Resource ID #0x" + Sharpen.Util.IntToHexString
					(id) + " type #0x" + Sharpen.Util.IntToHexString(value.type) + " is not valid");
			}
		}

		/// <exception cref="android.content.res.Resources.NotFoundException"></exception>
		internal virtual android.content.res.XmlResourceParser loadXmlResourceParser(string
			 file, int id, int assetCookie, string type)
		{
			if (id != 0)
			{
				try
				{
					// These may be compiled...
					lock (mCachedXmlBlockIds)
					{
						// First see if this block is in our cache.
						int num = mCachedXmlBlockIds.Length;
						{
							for (int i = 0; i < num; i++)
							{
								if (mCachedXmlBlockIds[i] == id)
								{
									//System.out.println("**** REUSING XML BLOCK!  id="
									//                   + id + ", index=" + i);
									return mCachedXmlBlocks[i].newParser();
								}
							}
						}
						// Not in the cache, create a new block and put it at
						// the next slot in the cache.
						android.content.res.XmlBlock block = mAssets.openXmlBlockAsset(assetCookie, file);
						if (block != null)
						{
							int pos = mLastCachedXmlBlockIndex + 1;
							if (pos >= num)
							{
								pos = 0;
							}
							mLastCachedXmlBlockIndex = pos;
							android.content.res.XmlBlock oldBlock = mCachedXmlBlocks[pos];
							if (oldBlock != null)
							{
								oldBlock.close();
							}
							mCachedXmlBlockIds[pos] = id;
							mCachedXmlBlocks[pos] = block;
							//System.out.println("**** CACHING NEW XML BLOCK!  id="
							//                   + id + ", index=" + pos);
							return block.newParser();
						}
					}
				}
				catch (System.Exception e)
				{
					android.content.res.Resources.NotFoundException rnf = new android.content.res.Resources
						.NotFoundException("File " + file + " from xml type " + type + " resource ID #0x"
						 + Sharpen.Util.IntToHexString(id));
					rnf.InnerException = e;
					throw rnf;
				}
			}
			throw new android.content.res.Resources.NotFoundException("File " + file + " from xml type "
				 + type + " resource ID #0x" + Sharpen.Util.IntToHexString(id));
		}

		private android.content.res.TypedArray getCachedStyledAttributes(int len)
		{
			lock (mTmpValue)
			{
				android.content.res.TypedArray attrs = mCachedStyledAttributes;
				if (attrs != null)
				{
					mCachedStyledAttributes = null;
					attrs.mLength = len;
					int fullLen = len * android.content.res.AssetManager.STYLE_NUM_ENTRIES;
					if (attrs.mData.Length >= fullLen)
					{
						return attrs;
					}
					attrs.mData = new int[fullLen];
					attrs.mIndices = new int[1 + len];
					return attrs;
				}
				return new android.content.res.TypedArray(this, new int[len * android.content.res.AssetManager
					.STYLE_NUM_ENTRIES], new int[1 + len], len);
			}
		}

		private Resources()
		{
			mAssets = android.content.res.AssetManager.getSystem();
			// NOTE: Intentionally leaving this uninitialized (all values set
			// to zero), so that anyone who tries to do something that requires
			// metrics will get a very wrong value.
			mConfiguration.setToDefaults();
			mMetrics.setToDefaults();
			updateConfiguration(null, null);
			mAssets.ensureStringBlocks();
			mCompatibilityInfo = android.content.res.CompatibilityInfo.DEFAULT_COMPATIBILITY_INFO;
		}
	}
}
