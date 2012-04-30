using Sharpen;

namespace android.util
{
	/// <summary>Provides an implementation of AttributeSet on top of an XmlPullParser.</summary>
	/// <remarks>Provides an implementation of AttributeSet on top of an XmlPullParser.</remarks>
	[Sharpen.Sharpened]
	internal class XmlPullAttributes : android.util.AttributeSet
	{
		public XmlPullAttributes(org.xmlpull.v1.XmlPullParser parser)
		{
			mParser = parser;
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeCount()
		{
			return mParser.getAttributeCount();
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getAttributeName(int index)
		{
			return mParser.getAttributeName(index);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getAttributeValue(int index)
		{
			return mParser.getAttributeValue(index);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getAttributeValue(string @namespace, string name)
		{
			return mParser.getAttributeValue(@namespace, name);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getPositionDescription()
		{
			return mParser.getPositionDescription();
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeNameResource(int index)
		{
			return 0;
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeListValue(string @namespace, string attribute, string
			[] options, int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToList(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(@namespace, attribute)), options, defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual bool getAttributeBooleanValue(string @namespace, string attribute, 
			bool defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToBoolean(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(@namespace, attribute)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeResourceValue(string @namespace, string attribute, 
			int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToInt(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(@namespace, attribute)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeIntValue(string @namespace, string attribute, int 
			defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToInt(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(@namespace, attribute)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeUnsignedIntValue(string @namespace, string attribute
			, int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToUnsignedInt(getAttributeValue
				(@namespace, attribute), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual float getAttributeFloatValue(string @namespace, string attribute, 
			float defaultValue)
		{
			string s = getAttributeValue(@namespace, attribute);
			if (s != null)
			{
				return float.Parse(s);
			}
			return defaultValue;
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeListValue(int index, string[] options, int defaultValue
			)
		{
			return android.util.@internal.XmlUtils.convertValueToList(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(index)), options, defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual bool getAttributeBooleanValue(int index, bool defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToBoolean(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(index)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeResourceValue(int index, int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToInt(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(index)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeIntValue(int index, int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToInt(java.lang.CharSequenceProxy.Wrap
				(getAttributeValue(index)), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getAttributeUnsignedIntValue(int index, int defaultValue)
		{
			return android.util.@internal.XmlUtils.convertValueToUnsignedInt(getAttributeValue
				(index), defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual float getAttributeFloatValue(int index, float defaultValue)
		{
			string s = getAttributeValue(index);
			if (s != null)
			{
				return float.Parse(s);
			}
			return defaultValue;
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getIdAttribute()
		{
			return getAttributeValue(null, "id");
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual string getClassAttribute()
		{
			return getAttributeValue(null, "class");
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getIdAttributeResourceValue(int defaultValue)
		{
			return getAttributeResourceValue(null, "id", defaultValue);
		}

		[Sharpen.ImplementsInterface(@"android.util.AttributeSet")]
		public virtual int getStyleAttribute()
		{
			return getAttributeResourceValue(null, "style", 0);
		}

		internal org.xmlpull.v1.XmlPullParser mParser;
	}
}
