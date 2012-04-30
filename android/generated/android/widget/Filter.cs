using Sharpen;

namespace android.widget
{
	[Sharpen.Stub]
	public abstract class Filter
	{
		internal const string LOG_TAG = "Filter";

		internal const string THREAD_NAME = "Filter";

		internal const int FILTER_TOKEN = unchecked((int)(0xD0D0F00D));

		internal const int FINISH_TOKEN = unchecked((int)(0xDEADBEEF));

		private android.os.Handler mThreadHandler;

		private android.os.Handler mResultHandler;

		private android.widget.Filter.Delayer mDelayer;

		private readonly object mLock = new object();

		[Sharpen.Stub]
		public Filter()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDelayer(android.widget.Filter.Delayer delayer)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void filter(java.lang.CharSequence constraint)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void filter(java.lang.CharSequence constraint, android.widget.Filter.FilterListener
			 listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal abstract android.widget.Filter.FilterResults performFiltering(java.lang.CharSequence
			 constraint);

		[Sharpen.Stub]
		internal abstract void publishResults(java.lang.CharSequence constraint, android.widget.Filter
			.FilterResults results);

		[Sharpen.Stub]
		public virtual java.lang.CharSequence convertResultToString(object resultValue)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal class FilterResults
		{
			[Sharpen.Stub]
			public FilterResults()
			{
				throw new System.NotImplementedException();
			}

			public object values;

			public int count;
		}

		[Sharpen.Stub]
		public interface FilterListener
		{
			[Sharpen.Stub]
			void onFilterComplete(int count);
		}

		[Sharpen.Stub]
		private class RequestHandler : android.os.Handler
		{
			[Sharpen.Stub]
			public RequestHandler(Filter _enclosing, android.os.Looper looper) : base(looper)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			private readonly Filter _enclosing;
		}

		[Sharpen.Stub]
		private class ResultsHandler : android.os.Handler
		{
			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}

			internal ResultsHandler(Filter _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly Filter _enclosing;
		}

		[Sharpen.Stub]
		private class RequestArguments
		{
			internal java.lang.CharSequence constraint;

			internal android.widget.Filter.FilterListener listener;

			internal android.widget.Filter.FilterResults results;
		}

		[Sharpen.Stub]
		public interface Delayer
		{
			[Sharpen.Stub]
			long getPostingDelay(java.lang.CharSequence constraint);
		}
	}
}
