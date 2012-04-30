using Sharpen;

namespace android.os
{
	[Sharpen.Stub]
	public static class AsyncTask
	{
		public enum Status
		{
			/// <summary>Indicates that the task has not been executed yet.</summary>
			/// <remarks>Indicates that the task has not been executed yet.</remarks>
			PENDING,
			/// <summary>Indicates that the task is running.</summary>
			/// <remarks>Indicates that the task is running.</remarks>
			RUNNING,
			/// <summary>
			/// Indicates that
			/// <see cref="AsyncTask{Params, Progress, Result}.onPostExecute(object)">AsyncTask&lt;Params, Progress, Result&gt;.onPostExecute(object)
			/// 	</see>
			/// has finished.
			/// </summary>
			FINISHED
		}
	}

	[Sharpen.Stub]
	public abstract class AsyncTask<Params, Progress, Result>
	{
		[Sharpen.Stub]
		public static void init()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void setDefaultExecutor(java.util.concurrent.Executor exec)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public AsyncTask()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.AsyncTask.Status getStatus()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal abstract Result doInBackground(params Params[] @params);

		[Sharpen.Stub]
		protected internal virtual void onPreExecute()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onPostExecute(Result result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onProgressUpdate(params Progress[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onCancelled(Result result)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void onCancelled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isCancelled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool cancel(bool mayInterruptIfRunning)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Result get()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public Result get(long timeout, java.util.concurrent.TimeUnit unit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.AsyncTask<Params, Progress, Result> execute(params Params[] @params
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.AsyncTask<Params, Progress, Result> executeOnExecutor(java.util.concurrent.Executor
			 exec, params Params[] @params)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static void execute(java.lang.Runnable runnable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal void publishProgress(params Progress[] values)
		{
			throw new System.NotImplementedException();
		}
	}
}
