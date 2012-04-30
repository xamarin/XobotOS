using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public sealed class ContentValues : android.os.Parcelable
	{
		public const string TAG = "ContentValues";

		private java.util.HashMap<string, object> mValues;

		[Sharpen.Stub]
		public ContentValues()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ContentValues(int size_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public ContentValues(android.content.ContentValues from)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private ContentValues(java.util.HashMap<string, object> values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, string value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void putAll(android.content.ContentValues other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, byte value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, short value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, long value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, double value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void put(string key, byte[] value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void putNull(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int size()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void remove(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool containsKey(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public object get(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getAsString(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getAsLong(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getAsInteger(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public short getAsShort(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte getAsByte(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public double getAsDouble(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public float getAsFloat(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getAsBoolean(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte[] getAsByteArray(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Set<java.util.MapClass.Entry<string, object>> valueSet()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Set<string> keySet()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_461 : android.os.ParcelableClass.Creator<android.content.ContentValues
			>
		{
			public _Creator_461()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentValues createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.content.ContentValues[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.content.ContentValues
			> CREATOR = new _Creator_461();

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel parcel, int flags)
		{
			throw new System.NotImplementedException();
		}

		[System.Obsolete]
		[Sharpen.Stub]
		public void putStringArrayList(string key, java.util.ArrayList<string> value)
		{
			throw new System.NotImplementedException();
		}

		[System.Obsolete]
		[Sharpen.Stub]
		public java.util.ArrayList<string> getStringArrayList(string key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
