using Sharpen;

namespace android.content
{
	[Sharpen.Stub]
	public abstract class BroadcastReceiver
	{
		private android.content.BroadcastReceiver.PendingResult mPendingResult;

		private bool mDebugUnregister;

		[Sharpen.Stub]
		public class PendingResult
		{
			public const int TYPE_COMPONENT = 0;

			public const int TYPE_REGISTERED = 1;

			public const int TYPE_UNREGISTERED = 2;

			internal readonly int mType;

			internal readonly bool mOrderedHint;

			internal readonly bool mInitialStickyHint;

			internal readonly android.os.IBinder mToken;

			internal int mResultCode;

			internal string mResultData;

			internal android.os.Bundle mResultExtras;

			internal bool mAbortBroadcast;

			internal bool mFinished;

			[Sharpen.Stub]
			public PendingResult(int resultCode, string resultData, android.os.Bundle resultExtras
				, int type, bool ordered, bool sticky, android.os.IBinder token)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void setResultCode(int code)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getResultCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void setResultData(string data)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public string getResultData()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void setResultExtras(android.os.Bundle extras)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.os.Bundle getResultExtras(bool makeMap)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void setResult(int code, string data, android.os.Bundle extras)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public bool getAbortBroadcast()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void abortBroadcast()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void clearAbortBroadcast()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public void finish()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void setExtrasClassLoader(java.lang.ClassLoader cl)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void sendFinished(android.app.IActivityManager am)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal virtual void checkSynchronousHint()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public BroadcastReceiver()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onReceive(android.content.Context context, android.content.Intent
			 intent);

		[Sharpen.Stub]
		public android.content.BroadcastReceiver.PendingResult goAsync()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.IBinder peekService(android.content.Context myContext, 
			android.content.Intent service)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setResultCode(int code)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getResultCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setResultData(string data)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getResultData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setResultExtras(android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.os.Bundle getResultExtras(bool makeMap)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setResult(int code, string data, android.os.Bundle extras)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getAbortBroadcast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void abortBroadcast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void clearAbortBroadcast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isOrderedBroadcast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool isInitialStickyBroadcast()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setOrderedHint(bool isOrdered)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setPendingResult(android.content.BroadcastReceiver.PendingResult result
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.BroadcastReceiver.PendingResult getPendingResult()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setDebugUnregister(bool debug)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getDebugUnregister()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void checkSynchronousHint()
		{
			throw new System.NotImplementedException();
		}
	}
}
