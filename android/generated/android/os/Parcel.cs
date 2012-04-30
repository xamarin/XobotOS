using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public sealed class Parcel
	{
		[Sharpen.Stub]
		public static android.os.Parcel obtain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int dataSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int dataAvail()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int dataPosition()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int dataCapacity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setDataSize(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setDataPosition(int pos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setDataCapacity(int size)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool pushAllowFds(bool allowFds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void restoreAllowFds(bool lastValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte[] marshall()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void unmarshall(byte[] data, int offest, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void appendFrom(android.os.Parcel parcel, int offset, int length)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool hasFileDescriptors()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeInterfaceToken(string interfaceName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void enforceInterface(string interfaceName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeByteArray(byte[] b)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeByteArray(byte[] b, int offset, int len)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeInt(int val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeLong(long val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeFloat(float val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeDouble(double val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeString(string val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeCharSequence(java.lang.CharSequence val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeStrongBinder(android.os.IBinder val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeStrongInterface(android.os.IInterface val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeFileDescriptor(java.io.FileDescriptor val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeByte(byte val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeMap(java.util.Map<object, object> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void writeMapInternal(java.util.Map<string, object> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeBundle(android.os.Bundle val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeList(java.util.List<object> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeArray(object[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeSparseArray(android.util.SparseArray<object> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeSparseBooleanArray(android.util.SparseBooleanArray val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeBooleanArray(bool[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool[] createBooleanArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readBooleanArray(bool[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeCharArray(char[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public char[] createCharArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readCharArray(char[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeIntArray(int[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int[] createIntArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readIntArray(int[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeLongArray(long[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long[] createLongArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readLongArray(long[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeFloatArray(float[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public float[] createFloatArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readFloatArray(float[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeDoubleArray(double[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public double[] createDoubleArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readDoubleArray(double[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeStringArray(string[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string[] createStringArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readStringArray(string[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeBinderArray(android.os.IBinder[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeCharSequenceArray(java.lang.CharSequence[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.IBinder[] createBinderArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readBinderArray(android.os.IBinder[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeTypedList<T>(java.util.List<T> val) where T:android.os.Parcelable
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeStringList(java.util.List<string> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeBinderList(java.util.List<android.os.IBinder> val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeTypedArray<T>(T[] val, int parcelableFlags) where T:android.os.Parcelable
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeValue(object v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeParcelable(android.os.Parcelable p, int parcelableFlags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeSerializable(java.io.Serializable s)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeException(System.Exception e)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeNoException()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readException()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int readExceptionCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readException(int code, string msg)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int readInt()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long readLong()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public float readFloat()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public double readDouble()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string readString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence readCharSequence()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.IBinder readStrongBinder()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.ParcelFileDescriptor readFileDescriptor()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.io.FileDescriptor openFileDescriptor(string file, int mode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static java.io.FileDescriptor dupFileDescriptor(java.io.FileDescriptor orig
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void closeFileDescriptor(java.io.FileDescriptor desc)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static void clearFileDescriptor(java.io.FileDescriptor desc)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte readByte()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readMap(java.util.Map<object, object> outVal, java.lang.ClassLoader loader
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readList(java.util.List<object> outVal, java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.HashMap<object, object> readHashMap(java.lang.ClassLoader loader
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.Bundle readBundle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.Bundle readBundle(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public byte[] createByteArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readByteArray(byte[] val)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string[] readStringArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence[] readCharSequenceArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<object> readArrayList(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public object[] readArray(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.util.SparseArray<object> readSparseArray(java.lang.ClassLoader loader
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.util.SparseBooleanArray readSparseBooleanArray()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<T> createTypedArrayList<T>(android.os.ParcelableClass.Creator
			<T> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readTypedList<T>(java.util.List<T> list, android.os.ParcelableClass.Creator
			<T> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<string> createStringArrayList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.ArrayList<android.os.IBinder> createBinderArrayList()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readStringList(java.util.List<string> list)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readBinderList(java.util.List<android.os.IBinder> list)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public T[] createTypedArray<T>(android.os.ParcelableClass.Creator<T> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void readTypedArray<T>(T[] val, android.os.ParcelableClass.Creator<T> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[System.ObsoleteAttribute]
		public T[] readTypedArray<T>(android.os.ParcelableClass.Creator<T> c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void writeParcelableArray<T>(T[] value, int parcelableFlags) where T:android.os.Parcelable
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public object readValue(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public T readParcelable<T>(java.lang.ClassLoader loader) where T:android.os.Parcelable
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.Parcelable[] readParcelableArray(java.lang.ClassLoader loader)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.io.Serializable readSerializable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal static android.os.Parcel obtain(int obj)
		{
			throw new System.NotImplementedException();
		}

		~Parcel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void readMapInternal(java.util.Map<object, object> outVal, int N, java.lang.ClassLoader
			 loader)
		{
			throw new System.NotImplementedException();
		}
	}
}
