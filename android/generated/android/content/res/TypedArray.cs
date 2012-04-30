using Sharpen;

namespace android.content.res
{
	/// <summary>
	/// Container for an array of values that were retrieved with
	/// <see cref="Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)
	/// 	">Theme.obtainStyledAttributes(android.util.AttributeSet, int[], int, int)</see>
	/// or
	/// <see cref="Resources.obtainAttributes(android.util.AttributeSet, int[])">Resources.obtainAttributes(android.util.AttributeSet, int[])
	/// 	</see>
	/// .  Be
	/// sure to call
	/// <see cref="recycle()">recycle()</see>
	/// when done with them.
	/// The indices used to retrieve values from this structure correspond to
	/// the positions of the attributes given to obtainStyledAttributes.
	/// </summary>
	[Sharpen.Sharpened]
	public class TypedArray
	{
		private readonly android.content.res.Resources mResources;

		internal android.content.res.XmlBlock.Parser mXml;

		internal int[] mRsrcs;

		internal int[] mData;

		internal int[] mIndices;

		internal int mLength;

		internal android.util.TypedValue mValue = new android.util.TypedValue();

		/// <summary>Return the number of values in this array.</summary>
		/// <remarks>Return the number of values in this array.</remarks>
		public virtual int length()
		{
			return mLength;
		}

		/// <summary>Return the number of indices in the array that actually have data.</summary>
		/// <remarks>Return the number of indices in the array that actually have data.</remarks>
		public virtual int getIndexCount()
		{
			return mIndices[0];
		}

		/// <summary>Return an index in the array that has data.</summary>
		/// <remarks>Return an index in the array that has data.</remarks>
		/// <param name="at">
		/// The index you would like to returned, ranging from 0 to
		/// <see cref="getIndexCount()">getIndexCount()</see>
		/// .
		/// </param>
		/// <returns>
		/// The index at the given offset, which can be used with
		/// <see cref="getValue(int, android.util.TypedValue)">getValue(int, android.util.TypedValue)
		/// 	</see>
		/// and related APIs.
		/// </returns>
		public virtual int getIndex(int at)
		{
			return mIndices[1 + at];
		}

		/// <summary>Return the Resources object this array was loaded from.</summary>
		/// <remarks>Return the Resources object this array was loaded from.</remarks>
		public virtual android.content.res.Resources getResources()
		{
			return mResources;
		}

		/// <summary>Retrieve the styled string value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the styled string value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>
		/// CharSequence holding string data.  May be styled.  Returns
		/// null if the attribute is not defined.
		/// </returns>
		public virtual java.lang.CharSequence getText(int index)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return null;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_STRING)
				{
					return loadStringValueAt(index);
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to string: " + 
					v);
				return v.coerceToString();
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getString of bad type: 0x"
				 + Sharpen.Util.IntToHexString(type));
			return null;
		}

		/// <summary>Retrieve the string value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the string value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>
		/// String holding string data.  Any styling information is
		/// removed.  Returns null if the attribute is not defined.
		/// </returns>
		public virtual string getString(int index)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return null;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_STRING)
				{
					return loadStringValueAt(index).ToString();
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to string: " + 
					v);
				java.lang.CharSequence cs = v.coerceToString();
				return cs != null ? cs.ToString() : null;
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getString of bad type: 0x"
				 + Sharpen.Util.IntToHexString(type));
			return null;
		}

		/// <summary>
		/// Retrieve the string value for the attribute at <var>index</var>, but
		/// only if that string comes from an immediate value in an XML file.
		/// </summary>
		/// <remarks>
		/// Retrieve the string value for the attribute at <var>index</var>, but
		/// only if that string comes from an immediate value in an XML file.  That
		/// is, this does not allow references to string resources, string
		/// attributes, or conversions from other types.  As such, this method
		/// will only return strings for TypedArray objects that come from
		/// attributes in an XML file.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>
		/// String holding string data.  Any styling information is
		/// removed.  Returns null if the attribute is not defined or is not
		/// an immediate string value.
		/// </returns>
		public virtual string getNonResourceString(int index)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_STRING)
			{
				int cookie = data[index + android.content.res.AssetManager.STYLE_ASSET_COOKIE];
				if (cookie < 0)
				{
					return mXml.getPooledString(data[index + android.content.res.AssetManager.STYLE_DATA
						]).ToString();
				}
			}
			return null;
		}

		/// <hide>
		/// Retrieve the string value for the attribute at <var>index</var> that is
		/// not allowed to change with the given configurations.
		/// </hide>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="allowedChangingConfigs">
		/// Bit mask of configurations from
		/// ActivityInfo that are allowed to change.
		/// </param>
		/// <returns>
		/// String holding string data.  Any styling information is
		/// removed.  Returns null if the attribute is not defined.
		/// </returns>
		public virtual string getNonConfigurationString(int index, int allowedChangingConfigs
			)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if ((data[index + android.content.res.AssetManager.STYLE_CHANGING_CONFIGURATIONS]
				 & ~allowedChangingConfigs) != 0)
			{
				return null;
			}
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return null;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_STRING)
				{
					return loadStringValueAt(index).ToString();
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to string: " + 
					v);
				java.lang.CharSequence cs = v.coerceToString();
				return cs != null ? cs.ToString() : null;
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getString of bad type: 0x"
				 + Sharpen.Util.IntToHexString(type));
			return null;
		}

		/// <summary>Retrieve the boolean value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the boolean value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">Value to return if the attribute is not defined.</param>
		/// <returns>Attribute boolean value, or defValue if not defined.</returns>
		public virtual bool getBoolean(int index, bool defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return data[index + android.content.res.AssetManager.STYLE_DATA] != 0;
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to boolean: " +
					 v);
				return android.util.@internal.XmlUtils.convertValueToBoolean(v.coerceToString(), 
					defValue);
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getBoolean of bad type: 0x"
				 + Sharpen.Util.IntToHexString(type));
			return defValue;
		}

		/// <summary>Retrieve the integer value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the integer value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">Value to return if the attribute is not defined.</param>
		/// <returns>Attribute int value, or defValue if not defined.</returns>
		public virtual int getInt(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return data[index + android.content.res.AssetManager.STYLE_DATA];
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to int: " + v);
				return android.util.@internal.XmlUtils.convertValueToInt(v.coerceToString(), defValue
					);
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getInt of bad type: 0x" + 
				Sharpen.Util.IntToHexString(type));
			return defValue;
		}

		/// <summary>Retrieve the float value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the float value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>Attribute float value, or defValue if not defined..</returns>
		public virtual float getFloat(int index, float defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_FLOAT)
				{
					return Sharpen.Util.IntBitsToFloat(data[index + android.content.res.AssetManager.
						STYLE_DATA]);
				}
				else
				{
					if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
						.TYPE_LAST_INT)
					{
						return data[index + android.content.res.AssetManager.STYLE_DATA];
					}
				}
			}
			android.util.TypedValue v = mValue;
			if (getValueAt(index, v))
			{
				android.util.Log.w(android.content.res.Resources.TAG, "Converting to float: " + v
					);
				java.lang.CharSequence str = v.coerceToString();
				if (str != null)
				{
					return float.Parse(str.ToString());
				}
			}
			android.util.Log.w(android.content.res.Resources.TAG, "getFloat of bad type: 0x" 
				+ Sharpen.Util.IntToHexString(type));
			return defValue;
		}

		/// <summary>Retrieve the color value for the attribute at <var>index</var>.</summary>
		/// <remarks>
		/// Retrieve the color value for the attribute at <var>index</var>.  If
		/// the attribute references a color resource holding a complex
		/// <see cref="ColorStateList">ColorStateList</see>
		/// , then the default color from
		/// the set is returned.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>Attribute color value, or defValue if not defined.</returns>
		public virtual int getColor(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return data[index + android.content.res.AssetManager.STYLE_DATA];
				}
				else
				{
					if (type == android.util.TypedValue.TYPE_STRING)
					{
						android.util.TypedValue value = mValue;
						if (getValueAt(index, value))
						{
							android.content.res.ColorStateList csl = mResources.loadColorStateList(value, value
								.resourceId);
							return csl.getDefaultColor();
						}
						return defValue;
					}
				}
			}
			throw new System.NotSupportedException("Can't convert to color: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>Retrieve the ColorStateList for the attribute at <var>index</var>.</summary>
		/// <remarks>
		/// Retrieve the ColorStateList for the attribute at <var>index</var>.
		/// The value may be either a single solid color or a reference to
		/// a color or complex
		/// <see cref="ColorStateList">ColorStateList</see>
		/// description.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>ColorStateList for the attribute, or null if not defined.</returns>
		public virtual android.content.res.ColorStateList getColorStateList(int index)
		{
			android.util.TypedValue value = mValue;
			if (getValueAt(index * android.content.res.AssetManager.STYLE_NUM_ENTRIES, value))
			{
				return mResources.loadColorStateList(value, value.resourceId);
			}
			return null;
		}

		/// <summary>Retrieve the integer value for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the integer value for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>Attribute integer value, or defValue if not defined.</returns>
		public virtual int getInteger(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
					.TYPE_LAST_INT)
				{
					return data[index + android.content.res.AssetManager.STYLE_DATA];
				}
			}
			throw new System.NotSupportedException("Can't convert to integer: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>Retrieve a dimensional unit attribute at <var>index</var>.</summary>
		/// <remarks>
		/// Retrieve a dimensional unit attribute at <var>index</var>.  Unit
		/// conversions are based on the current
		/// <see cref="android.util.DisplayMetrics">android.util.DisplayMetrics</see>
		/// 
		/// associated with the resources this
		/// <see cref="TypedArray">TypedArray</see>
		/// object
		/// came from.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>
		/// Attribute dimension value multiplied by the appropriate
		/// metric, or defValue if not defined.
		/// </returns>
		/// <seealso cref="getDimensionPixelOffset(int, int)">getDimensionPixelOffset(int, int)
		/// 	</seealso>
		/// <seealso cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</seealso>
		public virtual float getDimension(int index, float defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimension(data[index + android.content.res.AssetManager
						.STYLE_DATA], mResources.mMetrics);
				}
			}
			throw new System.NotSupportedException("Can't convert to dimension: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>
		/// Retrieve a dimensional unit attribute at <var>index</var> for use
		/// as an offset in raw pixels.
		/// </summary>
		/// <remarks>
		/// Retrieve a dimensional unit attribute at <var>index</var> for use
		/// as an offset in raw pixels.  This is the same as
		/// <see cref="getDimension(int, float)">getDimension(int, float)</see>
		/// , except the returned value is converted to
		/// integer pixels for you.  An offset conversion involves simply
		/// truncating the base value to an integer.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>
		/// Attribute dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels, or defValue if not defined.
		/// </returns>
		/// <seealso cref="getDimension(int, float)">getDimension(int, float)</seealso>
		/// <seealso cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</seealso>
		public virtual int getDimensionPixelOffset(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelOffset(data[index + android.content.res.AssetManager
						.STYLE_DATA], mResources.mMetrics);
				}
			}
			throw new System.NotSupportedException("Can't convert to dimension: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>
		/// Retrieve a dimensional unit attribute at <var>index</var> for use
		/// as a size in raw pixels.
		/// </summary>
		/// <remarks>
		/// Retrieve a dimensional unit attribute at <var>index</var> for use
		/// as a size in raw pixels.  This is the same as
		/// <see cref="getDimension(int, float)">getDimension(int, float)</see>
		/// , except the returned value is converted to
		/// integer pixels for use as a size.  A size conversion involves
		/// rounding the base value, and ensuring that a non-zero base value
		/// is at least one pixel in size.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>
		/// Attribute dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels, or defValue if not defined.
		/// </returns>
		/// <seealso cref="getDimension(int, float)">getDimension(int, float)</seealso>
		/// <seealso cref="getDimensionPixelOffset(int, int)">getDimensionPixelOffset(int, int)
		/// 	</seealso>
		public virtual int getDimensionPixelSize(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelSize(data[index + android.content.res.AssetManager
						.STYLE_DATA], mResources.mMetrics);
				}
			}
			throw new System.NotSupportedException("Can't convert to dimension: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>
		/// Special version of
		/// <see cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</see>
		/// for retrieving
		/// <see cref="android.view.ViewGroup">android.view.ViewGroup</see>
		/// 's layout_width and layout_height
		/// attributes.  This is only here for performance reasons; applications
		/// should use
		/// <see cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</see>
		/// .
		/// </summary>
		/// <param name="index">Index of the attribute to retrieve.</param>
		/// <param name="name">Textual name of attribute for error reporting.</param>
		/// <returns>
		/// Attribute dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels.
		/// </returns>
		public virtual int getLayoutDimension(int index, string name)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
				.TYPE_LAST_INT)
			{
				return data[index + android.content.res.AssetManager.STYLE_DATA];
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelSize(data[index + android.content.res.AssetManager
						.STYLE_DATA], mResources.mMetrics);
				}
			}
			throw new java.lang.RuntimeException(getPositionDescription() + ": You must supply a "
				 + name + " attribute.");
		}

		/// <summary>
		/// Special version of
		/// <see cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</see>
		/// for retrieving
		/// <see cref="android.view.ViewGroup">android.view.ViewGroup</see>
		/// 's layout_width and layout_height
		/// attributes.  This is only here for performance reasons; applications
		/// should use
		/// <see cref="getDimensionPixelSize(int, int)">getDimensionPixelSize(int, int)</see>
		/// .
		/// </summary>
		/// <param name="index">Index of the attribute to retrieve.</param>
		/// <param name="defValue">
		/// The default value to return if this attribute is not
		/// default or contains the wrong type of data.
		/// </param>
		/// <returns>
		/// Attribute dimension value multiplied by the appropriate
		/// metric and truncated to integer pixels.
		/// </returns>
		public virtual int getLayoutDimension(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type >= android.util.TypedValue.TYPE_FIRST_INT && type <= android.util.TypedValue
				.TYPE_LAST_INT)
			{
				return data[index + android.content.res.AssetManager.STYLE_DATA];
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_DIMENSION)
				{
					return android.util.TypedValue.complexToDimensionPixelSize(data[index + android.content.res.AssetManager
						.STYLE_DATA], mResources.mMetrics);
				}
			}
			return defValue;
		}

		/// <summary>Retrieve a fractional unit attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve a fractional unit attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="base">
		/// The base value of this fraction.  In other words, a
		/// standard fraction is multiplied by this value.
		/// </param>
		/// <param name="pbase">
		/// The parent base value of this fraction.  In other
		/// words, a parent fraction (nn%p) is multiplied by this
		/// value.
		/// </param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>
		/// Attribute fractional value multiplied by the appropriate
		/// base value, or defValue if not defined.
		/// </returns>
		public virtual float getFraction(int index, int @base, int pbase, float defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return defValue;
			}
			else
			{
				if (type == android.util.TypedValue.TYPE_FRACTION)
				{
					return android.util.TypedValue.complexToFraction(data[index + android.content.res.AssetManager
						.STYLE_DATA], @base, pbase);
				}
			}
			throw new System.NotSupportedException("Can't convert to fraction: type=0x" + Sharpen.Util.IntToHexString
				(type));
		}

		/// <summary>
		/// Retrieve the resource identifier for the attribute at
		/// <var>index</var>.
		/// </summary>
		/// <remarks>
		/// Retrieve the resource identifier for the attribute at
		/// <var>index</var>.  Note that attribute resource as resolved when
		/// the overall
		/// <see cref="TypedArray">TypedArray</see>
		/// object is retrieved.  As a
		/// result, this function will return the resource identifier of the
		/// final resource value that was found, <em>not</em> necessarily the
		/// original resource that was specified by the attribute.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="defValue">
		/// Value to return if the attribute is not defined or
		/// not a resource.
		/// </param>
		/// <returns>Attribute resource identifier, or defValue if not defined.</returns>
		public virtual int getResourceId(int index, int defValue)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			if (data[index + android.content.res.AssetManager.STYLE_TYPE] != android.util.TypedValue
				.TYPE_NULL)
			{
				int resid = data[index + android.content.res.AssetManager.STYLE_RESOURCE_ID];
				if (resid != 0)
				{
					return resid;
				}
			}
			return defValue;
		}

		/// <summary>Retrieve the Drawable for the attribute at <var>index</var>.</summary>
		/// <remarks>
		/// Retrieve the Drawable for the attribute at <var>index</var>.  This
		/// gets the resource ID of the selected attribute, and uses
		/// <see cref="Resources.getDrawable(int)">Resources.getDrawable</see>
		/// of the owning
		/// Resources object to retrieve its Drawable.
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>Drawable for the attribute, or null if not defined.</returns>
		public virtual android.graphics.drawable.Drawable getDrawable(int index)
		{
			android.util.TypedValue value = mValue;
			if (getValueAt(index * android.content.res.AssetManager.STYLE_NUM_ENTRIES, value))
			{
				if (false)
				{
					java.io.Console.Out.println("******************************************************************"
						);
					java.io.Console.Out.println("Got drawable resource: type=" + value.type + " str="
						 + value.@string + " int=0x" + Sharpen.Util.IntToHexString(value.data) + " cookie="
						 + value.assetCookie);
					java.io.Console.Out.println("******************************************************************"
						);
				}
				return mResources.loadDrawable(value, value.resourceId);
			}
			return null;
		}

		/// <summary>Retrieve the CharSequence[] for the attribute at <var>index</var>.</summary>
		/// <remarks>
		/// Retrieve the CharSequence[] for the attribute at <var>index</var>.
		/// This gets the resource ID of the selected attribute, and uses
		/// <see cref="Resources.getTextArray(int)">Resources.getTextArray</see>
		/// of the owning
		/// Resources object to retrieve its String[].
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>CharSequence[] for the attribute, or null if not defined.</returns>
		public virtual java.lang.CharSequence[] getTextArray(int index)
		{
			android.util.TypedValue value = mValue;
			if (getValueAt(index * android.content.res.AssetManager.STYLE_NUM_ENTRIES, value))
			{
				if (false)
				{
					java.io.Console.Out.println("******************************************************************"
						);
					java.io.Console.Out.println("Got drawable resource: type=" + value.type + " str="
						 + value.@string + " int=0x" + Sharpen.Util.IntToHexString(value.data) + " cookie="
						 + value.assetCookie);
					java.io.Console.Out.println("******************************************************************"
						);
				}
				return mResources.getTextArray(value.resourceId);
			}
			return null;
		}

		/// <summary>Retrieve the raw TypedValue for the attribute at <var>index</var>.</summary>
		/// <remarks>Retrieve the raw TypedValue for the attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <param name="outValue">
		/// TypedValue object in which to place the attribute's
		/// data.
		/// </param>
		/// <returns>Returns true if the value was retrieved, else false.</returns>
		public virtual bool getValue(int index, android.util.TypedValue outValue)
		{
			return getValueAt(index * android.content.res.AssetManager.STYLE_NUM_ENTRIES, outValue
				);
		}

		/// <summary>Determines whether there is an attribute at <var>index</var>.</summary>
		/// <remarks>Determines whether there is an attribute at <var>index</var>.</remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>True if the attribute has a value, false otherwise.</returns>
		public virtual bool hasValue(int index)
		{
			index *= android.content.res.AssetManager.STYLE_NUM_ENTRIES;
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			return type != android.util.TypedValue.TYPE_NULL;
		}

		/// <summary>
		/// Retrieve the raw TypedValue for the attribute at <var>index</var>
		/// and return a temporary object holding its data.
		/// </summary>
		/// <remarks>
		/// Retrieve the raw TypedValue for the attribute at <var>index</var>
		/// and return a temporary object holding its data.  This object is only
		/// valid until the next call on to
		/// <see cref="TypedArray">TypedArray</see>
		/// .
		/// </remarks>
		/// <param name="index">Index of attribute to retrieve.</param>
		/// <returns>
		/// Returns a TypedValue object if the attribute is defined,
		/// containing its data; otherwise returns null.  (You will not
		/// receive a TypedValue whose type is TYPE_NULL.)
		/// </returns>
		public virtual android.util.TypedValue peekValue(int index)
		{
			android.util.TypedValue value = mValue;
			if (getValueAt(index * android.content.res.AssetManager.STYLE_NUM_ENTRIES, value))
			{
				return value;
			}
			return null;
		}

		/// <summary>Returns a message about the parser state suitable for printing error messages.
		/// 	</summary>
		/// <remarks>Returns a message about the parser state suitable for printing error messages.
		/// 	</remarks>
		public virtual string getPositionDescription()
		{
			return mXml != null ? mXml.getPositionDescription() : "<internal>";
		}

		/// <summary>Give back a previously retrieved StyledAttributes, for later re-use.</summary>
		/// <remarks>Give back a previously retrieved StyledAttributes, for later re-use.</remarks>
		public virtual void recycle()
		{
			lock (mResources.mTmpValue)
			{
				android.content.res.TypedArray cached = mResources.mCachedStyledAttributes;
				if (cached == null || cached.mData.Length < mData.Length)
				{
					mXml = null;
					mResources.mCachedStyledAttributes = this;
				}
			}
		}

		private bool getValueAt(int index, android.util.TypedValue outValue)
		{
			int[] data = mData;
			int type = data[index + android.content.res.AssetManager.STYLE_TYPE];
			if (type == android.util.TypedValue.TYPE_NULL)
			{
				return false;
			}
			outValue.type = type;
			outValue.data = data[index + android.content.res.AssetManager.STYLE_DATA];
			outValue.assetCookie = data[index + android.content.res.AssetManager.STYLE_ASSET_COOKIE
				];
			outValue.resourceId = data[index + android.content.res.AssetManager.STYLE_RESOURCE_ID
				];
			outValue.changingConfigurations = data[index + android.content.res.AssetManager.STYLE_CHANGING_CONFIGURATIONS
				];
			outValue.density = data[index + android.content.res.AssetManager.STYLE_DENSITY];
			outValue.@string = (type == android.util.TypedValue.TYPE_STRING) ? loadStringValueAt
				(index) : null;
			return true;
		}

		private java.lang.CharSequence loadStringValueAt(int index)
		{
			int[] data = mData;
			int cookie = data[index + android.content.res.AssetManager.STYLE_ASSET_COOKIE];
			if (cookie < 0)
			{
				if (mXml != null)
				{
					return mXml.getPooledString(data[index + android.content.res.AssetManager.STYLE_DATA
						]);
				}
				return null;
			}
			//System.out.println("Getting pooled from: " + v);
			return mResources.mAssets.getPooledString(cookie, data[index + android.content.res.AssetManager
				.STYLE_DATA]);
		}

		internal TypedArray(android.content.res.Resources resources, int[] data, int[] indices
			, int len)
		{
			mResources = resources;
			mData = data;
			mIndices = indices;
			mLength = len;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return java.util.Arrays.toString(mData);
		}
	}
}
