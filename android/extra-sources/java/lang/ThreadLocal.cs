using Sharpen;
using ST = System.Threading;

namespace java.lang
{
	[Sharpen.Sharpened]
	public class ThreadLocal<T>
	{
		ST.ThreadLocal<T> local;

		private void initialize ()
		{
			local = new ST.ThreadLocal<T> (initialValue);
		}

		public ThreadLocal ()
		{
			initialize ();
		}

		public virtual T get()
		{
			return local.Value;
		}

		protected internal virtual T initialValue()
		{
			return default (T);
		}

		public virtual void set(T value)
		{
			local.Value = value;
		}

		public virtual void remove()
		{
			local.Dispose ();
			initialize ();
		}
	}
}
