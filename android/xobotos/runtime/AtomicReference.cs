using System;
using System.Threading;

namespace XobotOS.Runtime
{
	internal abstract class AtomicReference<V>
	{
		protected V value;

		public AtomicReference(V initialValue)
		{
			value = initialValue;
		}

		public AtomicReference()
		{ }

		public V get() {
			return value;
		}

		public void set(V newValue)
		{
			value = newValue;
		}

		public void lazySet(V newValue)
		{
			value = newValue;
		}

		public abstract bool compareAndSet(V expect, V update);

		public bool weakCompareAndSet(V expect, V update)
		{
			return compareAndSet(expect, update);
		}

		public V getAndSet(V newValue)
		{
			while(true) {
				V x = get ();
				if (compareAndSet(x, newValue))
					return x;
			}
		}

		public override string ToString ()
		{
			return string.Format ("[AtomicReference: {0}]", value);
		}
	}

	internal class AtomicObjectReference<V> : AtomicReference<V> where V:class
	{
		public AtomicObjectReference(V initialValue)
			: base(initialValue)
		{ }

		public override bool compareAndSet(V expect, V update)
		{
			return Interlocked.CompareExchange (ref value, update, expect) == expect;
		}
	}

	internal static class AtomicReference
	{
		public static AtomicReference<V> create<V>(V initialValue) where V:class
		{
			return new AtomicObjectReference<V>(initialValue);
		}

		public static AtomicReference<int> create(int initalValue)
		{
			return new AtomicIntReference(initalValue);
		}

		public static AtomicReference<long> create(long initialValue)
		{
			return new AtomicLongReference(initialValue);
		}
	}

	internal class AtomicIntReference : AtomicReference<int>
	{
		public AtomicIntReference(int initialValue)
			: base(initialValue)
		{ }

		public override bool compareAndSet(int expect, int update)
		{
			return Interlocked.CompareExchange (ref value, update, expect) == expect;
		}
	}

	internal class AtomicLongReference : AtomicReference<long>
	{
		public AtomicLongReference(long initialValue)
			: base(initialValue)
		{ }

		public override bool compareAndSet(long expect, long update)
		{
			return Interlocked.CompareExchange (ref value, update, expect) == expect;
		}
	}
}
