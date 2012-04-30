using Sharpen;

namespace android.util
{
	[Sharpen.Stub]
	public class LruCache<K, V>
	{
		private readonly java.util.LinkedHashMap<K, V> map;

		private int _size;

		private int _maxSize;

		private int _putCount;

		private int _createCount;

		private int _evictionCount;

		private int _hitCount;

		private int _missCount;

		[Sharpen.Stub]
		public LruCache(int maxSize_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public V get(K key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public V put(K key, V value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void trimToSize(int maxSize_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public V remove(K key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void entryRemoved(bool evicted, K key, V oldValue, V newValue
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual V create(K key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int safeSizeOf(K key, V value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual int sizeOf(K key, V value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void evictAll()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int size()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int maxSize()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int hitCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int missCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int createCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int putCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int evictionCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.Map<K, V> snapshot()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public sealed override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
