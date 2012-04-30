using Sharpen;

namespace android.content.res
{
	/// <summary>
	/// Lets you map
	/// <see cref="android.view.View">android.view.View</see>
	/// state sets to colors.
	/// <see cref="ColorStateList">ColorStateList</see>
	/// s are created from XML resource files defined in the
	/// "color" subdirectory directory of an application's resource directory.  The XML file contains
	/// a single "selector" element with a number of "item" elements inside.  For example:
	/// <pre>
	/// &lt;selector xmlns:android="http://schemas.android.com/apk/res/android"&gt;
	/// &lt;item android:state_focused="true" android:color="@color/testcolor1"/&gt;
	/// &lt;item android:state_pressed="true" android:state_enabled="false" android:color="@color/testcolor2" /&gt;
	/// &lt;item android:state_enabled="false" android:color="@color/testcolor3" /&gt;
	/// &lt;item android:color="@color/testcolor5"/&gt;
	/// &lt;/selector&gt;
	/// </pre>
	/// This defines a set of state spec / color pairs where each state spec specifies a set of
	/// states that a view must either be in or not be in and the color specifies the color associated
	/// with that spec.  The list of state specs will be processed in order of the items in the XML file.
	/// An item with no state spec is considered to match any set of states and is generally useful as
	/// a final item to be used as a default.  Note that if you have such an item before any other items
	/// in the list then any subsequent items will end up being ignored.
	/// <p>For more information, see the guide to &lt;a
	/// href="
	/// <docRoot></docRoot>
	/// guide/topics/resources/color-list-resource.html"&gt;Color State
	/// List Resource</a>.</p>
	/// </summary>
	[Sharpen.Sharpened]
	public class ColorStateList : android.os.Parcelable
	{
		private int[][] mStateSpecs;

		private int[] mColors;

		private int mDefaultColor = unchecked((int)(0xffff0000));

		private static readonly int[][] EMPTY = new int[][] { new int[0] };

		private static readonly android.util.SparseArray<java.lang.@ref.WeakReference<android.content.res.ColorStateList
			>> sCache = new android.util.SparseArray<java.lang.@ref.WeakReference<android.content.res.ColorStateList
			>>();

		private ColorStateList()
		{
		}

		/// <summary>
		/// Creates a ColorStateList that returns the specified mapping from
		/// states to colors.
		/// </summary>
		/// <remarks>
		/// Creates a ColorStateList that returns the specified mapping from
		/// states to colors.
		/// </remarks>
		public ColorStateList(int[][] states, int[] colors)
		{
			// must be parallel to mColors
			// must be parallel to mStateSpecs
			mStateSpecs = states;
			mColors = colors;
			if (states.Length > 0)
			{
				mDefaultColor = colors[0];
				{
					for (int i = 0; i < states.Length; i++)
					{
						if (states[i].Length == 0)
						{
							mDefaultColor = colors[i];
						}
					}
				}
			}
		}

		/// <summary>Creates or retrieves a ColorStateList that always returns a single color.
		/// 	</summary>
		/// <remarks>Creates or retrieves a ColorStateList that always returns a single color.
		/// 	</remarks>
		public static android.content.res.ColorStateList valueOf(int color)
		{
			// TODO: should we collect these eventually?
			lock (sCache)
			{
				java.lang.@ref.WeakReference<android.content.res.ColorStateList> @ref = sCache.get
					(color);
				android.content.res.ColorStateList csl = @ref != null ? @ref.get() : null;
				if (csl != null)
				{
					return csl;
				}
				csl = new android.content.res.ColorStateList(EMPTY, new int[] { color });
				sCache.put(color, new java.lang.@ref.WeakReference<android.content.res.ColorStateList
					>(csl));
				return csl;
			}
		}

		/// <summary>
		/// Create a ColorStateList from an XML document, given a set of
		/// <see cref="Resources">Resources</see>
		/// .
		/// </summary>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public static android.content.res.ColorStateList createFromXml(android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser)
		{
			android.util.AttributeSet attrs = android.util.Xml.asAttributeSet(parser);
			int type;
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.START_TAG && type
				 != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT)
			{
			}
			if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
			{
				throw new org.xmlpull.v1.XmlPullParserException("No start tag found");
			}
			return createFromXmlInner(r, parser, attrs);
		}

		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private static android.content.res.ColorStateList createFromXmlInner(android.content.res.Resources
			 r, org.xmlpull.v1.XmlPullParser parser, android.util.AttributeSet attrs)
		{
			android.content.res.ColorStateList colorStateList;
			string name = parser.getName();
			if (name.Equals("selector"))
			{
				colorStateList = new android.content.res.ColorStateList();
			}
			else
			{
				throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
					 ": invalid drawable tag " + name);
			}
			colorStateList.inflate(r, parser, attrs);
			return colorStateList;
		}

		/// <summary>
		/// Creates a new ColorStateList that has the same states and
		/// colors as this one but where each color has the specified alpha value
		/// (0-255).
		/// </summary>
		/// <remarks>
		/// Creates a new ColorStateList that has the same states and
		/// colors as this one but where each color has the specified alpha value
		/// (0-255).
		/// </remarks>
		public virtual android.content.res.ColorStateList withAlpha(int alpha)
		{
			int[] colors = new int[mColors.Length];
			int len = colors.Length;
			{
				for (int i = 0; i < len; i++)
				{
					colors[i] = (mColors[i] & unchecked((int)(0xFFFFFF))) | (alpha << 24);
				}
			}
			return new android.content.res.ColorStateList(mStateSpecs, colors);
		}

		/// <summary>Fill in this object based on the contents of an XML "selector" element.</summary>
		/// <remarks>Fill in this object based on the contents of an XML "selector" element.</remarks>
		/// <exception cref="org.xmlpull.v1.XmlPullParserException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		private void inflate(android.content.res.Resources r, org.xmlpull.v1.XmlPullParser
			 parser, android.util.AttributeSet attrs)
		{
			int type;
			int innerDepth = parser.getDepth() + 1;
			int depth;
			int listAllocated = 20;
			int listSize = 0;
			int[] colorList = new int[listAllocated];
			int[][] stateSpecList = new int[listAllocated][];
			while ((type = parser.next()) != org.xmlpull.v1.XmlPullParserClass.END_DOCUMENT &&
				 ((depth = parser.getDepth()) >= innerDepth || type != org.xmlpull.v1.XmlPullParserClass.END_TAG
				))
			{
				if (type != org.xmlpull.v1.XmlPullParserClass.START_TAG)
				{
					continue;
				}
				if (depth > innerDepth || !parser.getName().Equals("item"))
				{
					continue;
				}
				int colorRes = 0;
				int color = unchecked((int)(0xffff0000));
				bool haveColor = false;
				int i;
				int j = 0;
				int numAttrs = attrs.getAttributeCount();
				int[] stateSpec = new int[numAttrs];
				for (i = 0; i < numAttrs; i++)
				{
					int stateResId = attrs.getAttributeNameResource(i);
					if (stateResId == 0)
					{
						break;
					}
					if (stateResId == android.@internal.R.attr.color)
					{
						colorRes = attrs.getAttributeResourceValue(i, 0);
						if (colorRes == 0)
						{
							color = attrs.getAttributeIntValue(i, color);
							haveColor = true;
						}
					}
					else
					{
						stateSpec[j++] = attrs.getAttributeBooleanValue(i, false) ? stateResId : -stateResId;
					}
				}
				stateSpec = android.util.StateSet.trimStateSet(stateSpec, j);
				if (colorRes != 0)
				{
					color = r.getColor(colorRes);
				}
				else
				{
					if (!haveColor)
					{
						throw new org.xmlpull.v1.XmlPullParserException(parser.getPositionDescription() +
							 ": <item> tag requires a 'android:color' attribute.");
					}
				}
				if (listSize == 0 || stateSpec.Length == 0)
				{
					mDefaultColor = color;
				}
				if (listSize + 1 >= listAllocated)
				{
					listAllocated = android.util.@internal.ArrayUtils.idealIntArraySize(listSize + 1);
					int[] ncolor = new int[listAllocated];
					System.Array.Copy(colorList, 0, ncolor, 0, listSize);
					int[][] nstate = new int[listAllocated][];
					System.Array.Copy(stateSpecList, 0, nstate, 0, listSize);
					colorList = ncolor;
					stateSpecList = nstate;
				}
				colorList[listSize] = color;
				stateSpecList[listSize] = stateSpec;
				listSize++;
			}
			mColors = new int[listSize];
			mStateSpecs = new int[listSize][];
			System.Array.Copy(colorList, 0, mColors, 0, listSize);
			System.Array.Copy(stateSpecList, 0, mStateSpecs, 0, listSize);
		}

		public virtual bool isStateful()
		{
			return mStateSpecs.Length > 1;
		}

		/// <summary>
		/// Return the color associated with the given set of
		/// <see cref="android.view.View">android.view.View</see>
		/// states.
		/// </summary>
		/// <param name="stateSet">
		/// an array of
		/// <see cref="android.view.View">android.view.View</see>
		/// states
		/// </param>
		/// <param name="defaultColor">
		/// the color to return if there's not state spec in this
		/// <see cref="ColorStateList">ColorStateList</see>
		/// that matches the stateSet.
		/// </param>
		/// <returns>
		/// the color associated with that set of states in this
		/// <see cref="ColorStateList">ColorStateList</see>
		/// .
		/// </returns>
		public virtual int getColorForState(int[] stateSet, int defaultColor)
		{
			int setLength = mStateSpecs.Length;
			{
				for (int i = 0; i < setLength; i++)
				{
					int[] stateSpec = mStateSpecs[i];
					if (android.util.StateSet.stateSetMatches(stateSpec, stateSet))
					{
						return mColors[i];
					}
				}
			}
			return defaultColor;
		}

		/// <summary>
		/// Return the default color in this
		/// <see cref="ColorStateList">ColorStateList</see>
		/// .
		/// </summary>
		/// <returns>
		/// the default color in this
		/// <see cref="ColorStateList">ColorStateList</see>
		/// .
		/// </returns>
		public virtual int getDefaultColor()
		{
			return mDefaultColor;
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			return "ColorStateList{" + "mStateSpecs=" + java.util.Arrays.deepToString(mStateSpecs
				) + "mColors=" + java.util.Arrays.toString(mColors) + "mDefaultColor=" + mDefaultColor
				 + '}';
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual int describeContents()
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel dest, int flags)
		{
			int N = mStateSpecs.Length;
			dest.writeInt(N);
			{
				for (int i = 0; i < N; i++)
				{
					dest.writeIntArray(mStateSpecs[i]);
				}
			}
			dest.writeIntArray(mColors);
		}

		private sealed class _Creator_313 : android.os.ParcelableClass.Creator<android.content.res.ColorStateList
			>
		{
			public _Creator_313()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.ColorStateList[] newArray(int size)
			{
				return new android.content.res.ColorStateList[size];
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.res.ColorStateList createFromParcel(android.os.Parcel source
				)
			{
				int N = source.readInt();
				int[][] stateSpecs = new int[N][];
				{
					for (int i = 0; i < N; i++)
					{
						stateSpecs[i] = source.createIntArray();
					}
				}
				int[] colors = source.createIntArray();
				return new android.content.res.ColorStateList(stateSpecs, colors);
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.res.ColorStateList
			> CREATOR = new _Creator_313();
	}
}
