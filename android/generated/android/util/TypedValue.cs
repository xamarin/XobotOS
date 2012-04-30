using System.Runtime.InteropServices;
using Sharpen;

namespace android.util
{
	/// <summary>Container for a dynamically typed data value.</summary>
	/// <remarks>
	/// Container for a dynamically typed data value.  Primarily used with
	/// <see cref="android.content.res.Resources">android.content.res.Resources</see>
	/// for holding resource values.
	/// </remarks>
	[Sharpen.Sharpened]
	public partial class TypedValue
	{
		/// <summary>The value contains no data.</summary>
		/// <remarks>The value contains no data.</remarks>
		public const int TYPE_NULL = unchecked((int)(0x00));

		/// <summary>The <var>data</var> field holds a resource identifier.</summary>
		/// <remarks>The <var>data</var> field holds a resource identifier.</remarks>
		public const int TYPE_REFERENCE = unchecked((int)(0x01));

		/// <summary>
		/// The <var>data</var> field holds an attribute resource
		/// identifier (referencing an attribute in the current theme
		/// style, not a resource entry).
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds an attribute resource
		/// identifier (referencing an attribute in the current theme
		/// style, not a resource entry).
		/// </remarks>
		public const int TYPE_ATTRIBUTE = unchecked((int)(0x02));

		/// <summary>The <var>string</var> field holds string data.</summary>
		/// <remarks>
		/// The <var>string</var> field holds string data.  In addition, if
		/// <var>data</var> is non-zero then it is the string block
		/// index of the string and <var>assetCookie</var> is the set of
		/// assets the string came from.
		/// </remarks>
		public const int TYPE_STRING = unchecked((int)(0x03));

		/// <summary>The <var>data</var> field holds an IEEE 754 floating point number.</summary>
		/// <remarks>The <var>data</var> field holds an IEEE 754 floating point number.</remarks>
		public const int TYPE_FLOAT = unchecked((int)(0x04));

		/// <summary>
		/// The <var>data</var> field holds a complex number encoding a
		/// dimension value.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a complex number encoding a
		/// dimension value.
		/// </remarks>
		public const int TYPE_DIMENSION = unchecked((int)(0x05));

		/// <summary>
		/// The <var>data</var> field holds a complex number encoding a fraction
		/// of a container.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a complex number encoding a fraction
		/// of a container.
		/// </remarks>
		public const int TYPE_FRACTION = unchecked((int)(0x06));

		/// <summary>Identifies the start of plain integer values.</summary>
		/// <remarks>
		/// Identifies the start of plain integer values.  Any type value
		/// from this to
		/// <see cref="TYPE_LAST_INT">TYPE_LAST_INT</see>
		/// means the
		/// <var>data</var> field holds a generic integer value.
		/// </remarks>
		public const int TYPE_FIRST_INT = unchecked((int)(0x10));

		/// <summary>
		/// The <var>data</var> field holds a number that was
		/// originally specified in decimal.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a number that was
		/// originally specified in decimal.
		/// </remarks>
		public const int TYPE_INT_DEC = unchecked((int)(0x10));

		/// <summary>
		/// The <var>data</var> field holds a number that was
		/// originally specified in hexadecimal (0xn).
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a number that was
		/// originally specified in hexadecimal (0xn).
		/// </remarks>
		public const int TYPE_INT_HEX = unchecked((int)(0x11));

		/// <summary>
		/// The <var>data</var> field holds 0 or 1 that was originally
		/// specified as "false" or "true".
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds 0 or 1 that was originally
		/// specified as "false" or "true".
		/// </remarks>
		public const int TYPE_INT_BOOLEAN = unchecked((int)(0x12));

		/// <summary>
		/// Identifies the start of integer values that were specified as
		/// color constants (starting with '#').
		/// </summary>
		/// <remarks>
		/// Identifies the start of integer values that were specified as
		/// color constants (starting with '#').
		/// </remarks>
		public const int TYPE_FIRST_COLOR_INT = unchecked((int)(0x1c));

		/// <summary>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #aarrggbb.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #aarrggbb.
		/// </remarks>
		public const int TYPE_INT_COLOR_ARGB8 = unchecked((int)(0x1c));

		/// <summary>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #rrggbb.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #rrggbb.
		/// </remarks>
		public const int TYPE_INT_COLOR_RGB8 = unchecked((int)(0x1d));

		/// <summary>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #argb.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #argb.
		/// </remarks>
		public const int TYPE_INT_COLOR_ARGB4 = unchecked((int)(0x1e));

		/// <summary>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #rgb.
		/// </summary>
		/// <remarks>
		/// The <var>data</var> field holds a color that was originally
		/// specified as #rgb.
		/// </remarks>
		public const int TYPE_INT_COLOR_RGB4 = unchecked((int)(0x1f));

		/// <summary>
		/// Identifies the end of integer values that were specified as color
		/// constants.
		/// </summary>
		/// <remarks>
		/// Identifies the end of integer values that were specified as color
		/// constants.
		/// </remarks>
		public const int TYPE_LAST_COLOR_INT = unchecked((int)(0x1f));

		/// <summary>Identifies the end of plain integer values.</summary>
		/// <remarks>Identifies the end of plain integer values.</remarks>
		public const int TYPE_LAST_INT = unchecked((int)(0x1f));

		/// <summary>Complex data: bit location of unit information.</summary>
		/// <remarks>Complex data: bit location of unit information.</remarks>
		public const int COMPLEX_UNIT_SHIFT = 0;

		/// <summary>
		/// Complex data: mask to extract unit information (after shifting by
		/// <see cref="COMPLEX_UNIT_SHIFT">COMPLEX_UNIT_SHIFT</see>
		/// ). This gives us 16 possible types, as
		/// defined below.
		/// </summary>
		public const int COMPLEX_UNIT_MASK = unchecked((int)(0xf));

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is raw pixels.
		/// </summary>
		public const int COMPLEX_UNIT_PX = 0;

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is Device Independent
		/// Pixels.
		/// </summary>
		public const int COMPLEX_UNIT_DIP = 1;

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is a scaled pixel.
		/// </summary>
		public const int COMPLEX_UNIT_SP = 2;

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is in points.
		/// </summary>
		public const int COMPLEX_UNIT_PT = 3;

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is in inches.
		/// </summary>
		public const int COMPLEX_UNIT_IN = 4;

		/// <summary>
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// complex unit: Value is in millimeters.
		/// </summary>
		public const int COMPLEX_UNIT_MM = 5;

		/// <summary>
		/// <see cref="TYPE_FRACTION">TYPE_FRACTION</see>
		/// complex unit: A basic fraction of the overall
		/// size.
		/// </summary>
		public const int COMPLEX_UNIT_FRACTION = 0;

		/// <summary>
		/// <see cref="TYPE_FRACTION">TYPE_FRACTION</see>
		/// complex unit: A fraction of the parent size.
		/// </summary>
		public const int COMPLEX_UNIT_FRACTION_PARENT = 1;

		/// <summary>
		/// Complex data: where the radix information is, telling where the decimal
		/// place appears in the mantissa.
		/// </summary>
		/// <remarks>
		/// Complex data: where the radix information is, telling where the decimal
		/// place appears in the mantissa.
		/// </remarks>
		public const int COMPLEX_RADIX_SHIFT = 4;

		/// <summary>
		/// Complex data: mask to extract radix information (after shifting by
		/// <see cref="COMPLEX_RADIX_SHIFT">COMPLEX_RADIX_SHIFT</see>
		/// ). This give us 4 possible fixed point
		/// representations as defined below.
		/// </summary>
		public const int COMPLEX_RADIX_MASK = unchecked((int)(0x3));

		/// <summary>Complex data: the mantissa is an integral number -- i.e., 0xnnnnnn.0</summary>
		public const int COMPLEX_RADIX_23p0 = 0;

		/// <summary>Complex data: the mantissa magnitude is 16 bits -- i.e, 0xnnnn.nn</summary>
		public const int COMPLEX_RADIX_16p7 = 1;

		/// <summary>Complex data: the mantissa magnitude is 8 bits -- i.e, 0xnn.nnnn</summary>
		public const int COMPLEX_RADIX_8p15 = 2;

		/// <summary>Complex data: the mantissa magnitude is 0 bits -- i.e, 0x0.nnnnnn</summary>
		public const int COMPLEX_RADIX_0p23 = 3;

		/// <summary>Complex data: bit location of mantissa information.</summary>
		/// <remarks>Complex data: bit location of mantissa information.</remarks>
		public const int COMPLEX_MANTISSA_SHIFT = 8;

		/// <summary>
		/// Complex data: mask to extract mantissa information (after shifting by
		/// <see cref="COMPLEX_MANTISSA_SHIFT">COMPLEX_MANTISSA_SHIFT</see>
		/// ). This gives us 23 bits of precision;
		/// the top bit is the sign.
		/// </summary>
		public const int COMPLEX_MANTISSA_MASK = unchecked((int)(0xffffff));

		/// <summary>
		/// If
		/// <see cref="density">density</see>
		/// is equal to this value, then the density should be
		/// treated as the system's default density value:
		/// <see cref="DisplayMetrics.DENSITY_DEFAULT">DisplayMetrics.DENSITY_DEFAULT</see>
		/// .
		/// </summary>
		public const int DENSITY_DEFAULT = 0;

		/// <summary>
		/// If
		/// <see cref="density">density</see>
		/// is equal to this value, then there is no density
		/// associated with the resource and it should not be scaled.
		/// </summary>
		public const int DENSITY_NONE = unchecked((int)(0xffff));

		/// <summary>The type held by this value, as defined by the constants here.</summary>
		/// <remarks>
		/// The type held by this value, as defined by the constants here.
		/// This tells you how to interpret the other fields in the object.
		/// </remarks>
		public int type;

		/// <summary>If the value holds a string, this is it.</summary>
		/// <remarks>If the value holds a string, this is it.</remarks>
		public java.lang.CharSequence @string;

		/// <summary>
		/// Basic data in the value, interpreted according to
		/// <see cref="type">type</see>
		/// 
		/// </summary>
		public int data;

		/// <summary>
		/// Additional information about where the value came from; only
		/// set for strings.
		/// </summary>
		/// <remarks>
		/// Additional information about where the value came from; only
		/// set for strings.
		/// </remarks>
		public int assetCookie;

		/// <summary>If Value came from a resource, this holds the corresponding resource id.
		/// 	</summary>
		/// <remarks>If Value came from a resource, this holds the corresponding resource id.
		/// 	</remarks>
		public int resourceId;

		/// <summary>
		/// If Value came from a resource, these are the configurations for which
		/// its contents can change.
		/// </summary>
		/// <remarks>
		/// If Value came from a resource, these are the configurations for which
		/// its contents can change.
		/// </remarks>
		public int changingConfigurations = -1;

		/// <summary>If the Value came from a resource, this holds the corresponding pixel density.
		/// 	</summary>
		/// <remarks>If the Value came from a resource, this holds the corresponding pixel density.
		/// 	</remarks>
		public int density;

		/// <summary>Return the data for this value as a float.</summary>
		/// <remarks>
		/// Return the data for this value as a float.  Only use for values
		/// whose type is
		/// <see cref="TYPE_FLOAT">TYPE_FLOAT</see>
		/// .
		/// </remarks>
		public float getFloat()
		{
			return Sharpen.Util.IntBitsToFloat(data);
		}

		internal const float MANTISSA_MULT = 1.0f / (1 << android.util.TypedValue.COMPLEX_MANTISSA_SHIFT
			);

		private static readonly float[] RADIX_MULTS = new float[] { 1.0f * MANTISSA_MULT, 
			1.0f / (1 << 7) * MANTISSA_MULT, 1.0f / (1 << 15) * MANTISSA_MULT, 1.0f / (1 << 
			23) * MANTISSA_MULT };

		/// <summary>Retrieve the base value from a complex data integer.</summary>
		/// <remarks>
		/// Retrieve the base value from a complex data integer.  This uses the
		/// <see cref="COMPLEX_MANTISSA_MASK">COMPLEX_MANTISSA_MASK</see>
		/// and
		/// <see cref="COMPLEX_RADIX_MASK">COMPLEX_RADIX_MASK</see>
		/// fields of
		/// the data to compute a floating point representation of the number they
		/// describe.  The units are ignored.
		/// </remarks>
		/// <param name="complex">A complex data value.</param>
		/// <returns>A floating point value corresponding to the complex data.</returns>
		public static float complexToFloat(int complex)
		{
			return (complex & (android.util.TypedValue.COMPLEX_MANTISSA_MASK << android.util.TypedValue
				.COMPLEX_MANTISSA_SHIFT)) * RADIX_MULTS[(complex >> android.util.TypedValue.COMPLEX_RADIX_SHIFT
				) & android.util.TypedValue.COMPLEX_RADIX_MASK];
		}

		/// <summary>
		/// Converts a complex data value holding a dimension to its final floating
		/// point value.
		/// </summary>
		/// <remarks>
		/// Converts a complex data value holding a dimension to its final floating
		/// point value. The given <var>data</var> must be structured as a
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// .
		/// </remarks>
		/// <param name="data">
		/// A complex data value holding a unit, magnitude, and
		/// mantissa.
		/// </param>
		/// <param name="metrics">
		/// Current display metrics to use in the conversion --
		/// supplies display density and scaling information.
		/// </param>
		/// <returns>
		/// The complex floating point value multiplied by the appropriate
		/// metrics depending on its unit.
		/// </returns>
		public static float complexToDimension(int data, android.util.DisplayMetrics metrics
			)
		{
			return applyDimension((data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK, complexToFloat
				(data), metrics);
		}

		/// <summary>
		/// Converts a complex data value holding a dimension to its final value
		/// as an integer pixel offset.
		/// </summary>
		/// <remarks>
		/// Converts a complex data value holding a dimension to its final value
		/// as an integer pixel offset.  This is the same as
		/// <see cref="complexToDimension(int, DisplayMetrics)">complexToDimension(int, DisplayMetrics)
		/// 	</see>
		/// , except the raw floating point value is
		/// truncated to an integer (pixel) value.
		/// The given <var>data</var> must be structured as a
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// .
		/// </remarks>
		/// <param name="data">
		/// A complex data value holding a unit, magnitude, and
		/// mantissa.
		/// </param>
		/// <param name="metrics">
		/// Current display metrics to use in the conversion --
		/// supplies display density and scaling information.
		/// </param>
		/// <returns>
		/// The number of pixels specified by the data and its desired
		/// multiplier and units.
		/// </returns>
		public static int complexToDimensionPixelOffset(int data, android.util.DisplayMetrics
			 metrics)
		{
			return (int)applyDimension((data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK, complexToFloat
				(data), metrics);
		}

		/// <summary>
		/// Converts a complex data value holding a dimension to its final value
		/// as an integer pixel size.
		/// </summary>
		/// <remarks>
		/// Converts a complex data value holding a dimension to its final value
		/// as an integer pixel size.  This is the same as
		/// <see cref="complexToDimension(int, DisplayMetrics)">complexToDimension(int, DisplayMetrics)
		/// 	</see>
		/// , except the raw floating point value is
		/// converted to an integer (pixel) value for use as a size.  A size
		/// conversion involves rounding the base value, and ensuring that a
		/// non-zero base value is at least one pixel in size.
		/// The given <var>data</var> must be structured as a
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// .
		/// </remarks>
		/// <param name="data">
		/// A complex data value holding a unit, magnitude, and
		/// mantissa.
		/// </param>
		/// <param name="metrics">
		/// Current display metrics to use in the conversion --
		/// supplies display density and scaling information.
		/// </param>
		/// <returns>
		/// The number of pixels specified by the data and its desired
		/// multiplier and units.
		/// </returns>
		public static int complexToDimensionPixelSize(int data, android.util.DisplayMetrics
			 metrics)
		{
			float value = complexToFloat(data);
			float f = applyDimension((data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK, value, 
				metrics);
			int res = (int)(f + 0.5f);
			if (res != 0)
			{
				return res;
			}
			if (value == 0)
			{
				return 0;
			}
			if (value > 0)
			{
				return 1;
			}
			return -1;
		}

		public static float complexToDimensionNoisy(int data, android.util.DisplayMetrics
			 metrics)
		{
			float res = complexToDimension(data, metrics);
			java.io.Console.Out.println("Dimension (0x" + ((data >> android.util.TypedValue.COMPLEX_MANTISSA_SHIFT
				) & android.util.TypedValue.COMPLEX_MANTISSA_MASK) + "*" + (RADIX_MULTS[(data >>
				 android.util.TypedValue.COMPLEX_RADIX_SHIFT) & android.util.TypedValue.COMPLEX_RADIX_MASK
				] / MANTISSA_MULT) + ")" + DIMENSION_UNIT_STRS[(data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK
				] + " = " + res);
			return res;
		}

		/// <summary>
		/// Converts an unpacked complex data value holding a dimension to its final floating
		/// point value.
		/// </summary>
		/// <remarks>
		/// Converts an unpacked complex data value holding a dimension to its final floating
		/// point value. The two parameters <var>unit</var> and <var>value</var>
		/// are as in
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// .
		/// </remarks>
		/// <param name="unit">The unit to convert from.</param>
		/// <param name="value">The value to apply the unit to.</param>
		/// <param name="metrics">
		/// Current display metrics to use in the conversion --
		/// supplies display density and scaling information.
		/// </param>
		/// <returns>
		/// The complex floating point value multiplied by the appropriate
		/// metrics depending on its unit.
		/// </returns>
		public static float applyDimension(int unit, float value, android.util.DisplayMetrics
			 metrics)
		{
			switch (unit)
			{
				case COMPLEX_UNIT_PX:
				{
					return value;
				}

				case COMPLEX_UNIT_DIP:
				{
					return value * metrics.density;
				}

				case COMPLEX_UNIT_SP:
				{
					return value * metrics.scaledDensity;
				}

				case COMPLEX_UNIT_PT:
				{
					return value * metrics.xdpi * (1.0f / 72);
				}

				case COMPLEX_UNIT_IN:
				{
					return value * metrics.xdpi;
				}

				case COMPLEX_UNIT_MM:
				{
					return value * metrics.xdpi * (1.0f / 25.4f);
				}
			}
			return 0;
		}

		/// <summary>Return the data for this value as a dimension.</summary>
		/// <remarks>
		/// Return the data for this value as a dimension.  Only use for values
		/// whose type is
		/// <see cref="TYPE_DIMENSION">TYPE_DIMENSION</see>
		/// .
		/// </remarks>
		/// <param name="metrics">
		/// Current display metrics to use in the conversion --
		/// supplies display density and scaling information.
		/// </param>
		/// <returns>
		/// The complex floating point value multiplied by the appropriate
		/// metrics depending on its unit.
		/// </returns>
		public virtual float getDimension(android.util.DisplayMetrics metrics)
		{
			return complexToDimension(data, metrics);
		}

		/// <summary>
		/// Converts a complex data value holding a fraction to its final floating
		/// point value.
		/// </summary>
		/// <remarks>
		/// Converts a complex data value holding a fraction to its final floating
		/// point value. The given <var>data</var> must be structured as a
		/// <see cref="TYPE_FRACTION">TYPE_FRACTION</see>
		/// .
		/// </remarks>
		/// <param name="data">
		/// A complex data value holding a unit, magnitude, and
		/// mantissa.
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
		/// The complex floating point value multiplied by the appropriate
		/// base value depending on its unit.
		/// </returns>
		public static float complexToFraction(int data, float @base, float pbase)
		{
			switch ((data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK)
			{
				case COMPLEX_UNIT_FRACTION:
				{
					return complexToFloat(data) * @base;
				}

				case COMPLEX_UNIT_FRACTION_PARENT:
				{
					return complexToFloat(data) * pbase;
				}
			}
			return 0;
		}

		/// <summary>Return the data for this value as a fraction.</summary>
		/// <remarks>
		/// Return the data for this value as a fraction.  Only use for values whose
		/// type is
		/// <see cref="TYPE_FRACTION">TYPE_FRACTION</see>
		/// .
		/// </remarks>
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
		/// The complex floating point value multiplied by the appropriate
		/// base value depending on its unit.
		/// </returns>
		public virtual float getFraction(float @base, float pbase)
		{
			return complexToFraction(data, @base, pbase);
		}

		/// <summary>
		/// Regardless of the actual type of the value, try to convert it to a
		/// string value.
		/// </summary>
		/// <remarks>
		/// Regardless of the actual type of the value, try to convert it to a
		/// string value.  For example, a color type will be converted to a
		/// string of the form #aarrggbb.
		/// </remarks>
		/// <returns>
		/// CharSequence The coerced string value.  If the value is
		/// null or the type is not known, null is returned.
		/// </returns>
		public java.lang.CharSequence coerceToString()
		{
			int t = type;
			if (t == TYPE_STRING)
			{
				return @string;
			}
			return java.lang.CharSequenceProxy.Wrap(coerceToString(t, data));
		}

		private static readonly string[] DIMENSION_UNIT_STRS = new string[] { "px", "dip"
			, "sp", "pt", "in", "mm" };

		private static readonly string[] FRACTION_UNIT_STRS = new string[] { "%", "%p" };

		/// <summary>
		/// Perform type conversion as per
		/// <see cref="coerceToString()">coerceToString()</see>
		/// on an
		/// explicitly supplied type and data.
		/// </summary>
		/// <param name="type">The data type identifier.</param>
		/// <param name="data">The data value.</param>
		/// <returns>
		/// String The coerced string value.  If the value is
		/// null or the type is not known, null is returned.
		/// </returns>
		public static string coerceToString(int type, int data)
		{
			switch (type)
			{
				case TYPE_NULL:
				{
					return null;
				}

				case TYPE_REFERENCE:
				{
					return "@" + data;
				}

				case TYPE_ATTRIBUTE:
				{
					return "?" + data;
				}

				case TYPE_FLOAT:
				{
					return System.Convert.ToString(Sharpen.Util.IntBitsToFloat(data));
				}

				case TYPE_DIMENSION:
				{
					return System.Convert.ToString(complexToFloat(data)) + DIMENSION_UNIT_STRS[(data 
						>> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK];
				}

				case TYPE_FRACTION:
				{
					return System.Convert.ToString(complexToFloat(data) * 100) + FRACTION_UNIT_STRS[(
						data >> COMPLEX_UNIT_SHIFT) & COMPLEX_UNIT_MASK];
				}

				case TYPE_INT_HEX:
				{
					return "0x" + Sharpen.Util.IntToHexString(data);
				}

				case TYPE_INT_BOOLEAN:
				{
					return data != 0 ? "true" : "false";
				}
			}
			if (type >= TYPE_FIRST_COLOR_INT && type <= TYPE_LAST_COLOR_INT)
			{
				return "#" + Sharpen.Util.IntToHexString(data);
			}
			else
			{
				if (type >= TYPE_FIRST_INT && type <= TYPE_LAST_INT)
				{
					return System.Convert.ToString(data);
				}
			}
			return null;
		}

		public virtual void setTo(android.util.TypedValue other)
		{
			type = other.type;
			@string = other.@string;
			data = other.data;
			assetCookie = other.assetCookie;
			resourceId = other.resourceId;
			density = other.density;
		}

		[Sharpen.MarshalHelper(@"AssetManagerGlue::TypedValue")]
		internal static class TypedValue_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct TypedValue_Struct
			{
				public uint _owner;

				public int type;

				public int data;

				public int assetCookie;

				public int resourceId;

				public int density;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(TypedValue_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, android.util.TypedValue arg)
			{
				TypedValue_Struct obj = new TypedValue_Struct();
				obj._owner = 0x972f3813;
				obj.type = arg.type;
				obj.data = arg.data;
				obj.assetCookie = arg.assetCookie;
				obj.resourceId = arg.resourceId;
				obj.density = arg.density;
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, android.util.TypedValue arg)
			{
				TypedValue_Struct obj = (TypedValue_Struct)Marshal.PtrToStructure(ptr, typeof(TypedValue_Struct
					));
				arg.type = obj.type;
				arg.data = obj.data;
				arg.@string = null;
				arg.assetCookie = obj.assetCookie;
				arg.resourceId = obj.resourceId;
				arg.density = obj.density;
			}

			public static System.IntPtr ManagedToNative(android.util.TypedValue arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TypedValue_Struct)
					));
				android.util.TypedValue.TypedValue_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static android.util.TypedValue NativeToManaged(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				TypedValue_Struct obj = (TypedValue_Struct)Marshal.PtrToStructure(ptr, typeof(TypedValue_Struct
					));
				android.util.TypedValue arg = new android.util.TypedValue();
				arg.type = obj.type;
				arg.data = obj.data;
				arg.@string = null;
				arg.assetCookie = obj.assetCookie;
				arg.resourceId = obj.resourceId;
				arg.density = obj.density;
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_util_TypedValue_TypedValue_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_util_TypedValue_TypedValue_destructor
				(System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				TypedValue_Struct obj = (TypedValue_Struct)Marshal.PtrToStructure(ptr, typeof(TypedValue_Struct
					));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				android.util.TypedValue.TypedValue_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}
	}
}
