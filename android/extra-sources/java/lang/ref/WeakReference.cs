using Sharpen;

namespace java.lang.@ref
{
	public class WeakReference<T> : System.WeakReference
	{
		public WeakReference (T r) : base (r)
		{
		}

		public virtual T get ()
		{
			object obj = Target;
			if (obj == null)
				return default (T);
			return (T)obj;
		}

		public void clear ()
		{
			Target = null;
		}
	}

	public class WeakReference : WeakReference<object>
	{
		public WeakReference (object r) : base(r)
		{
		}
	}
}
