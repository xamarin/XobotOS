using Sharpen;

namespace android.view.textservice
{
	[Sharpen.Stub]
	public class SpellCheckerSession
	{
		private static readonly string TAG = typeof(android.view.textservice.SpellCheckerSession
			).Name;

		internal const bool DBG = false;

		public const string SERVICE_META_DATA = "android.view.textservice.scs";

		internal const int MSG_ON_GET_SUGGESTION_MULTIPLE = 1;

		private readonly android.view.textservice.SpellCheckerSession.InternalListener mInternalListener;

		private readonly android.view.textservice.@internal.ITextServicesManager mTextServicesManager;

		private readonly android.view.textservice.SpellCheckerInfo mSpellCheckerInfo;

		private readonly android.view.textservice.SpellCheckerSession.SpellCheckerSessionListenerImpl
			 mSpellCheckerSessionListenerImpl;

		private bool mIsUsed;

		private android.view.textservice.SpellCheckerSession.SpellCheckerSessionListener 
			mSpellCheckerSessionListener;

		private sealed class _Handler_104 : android.os.Handler
		{
			public _Handler_104()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly android.os.Handler mHandler = new _Handler_104();

		[Sharpen.Stub]
		public SpellCheckerSession(android.view.textservice.SpellCheckerInfo info, android.view.textservice.@internal.ITextServicesManager
			 tsm, android.view.textservice.SpellCheckerSession.SpellCheckerSessionListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSessionDisconnected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.textservice.SpellCheckerInfo getSpellChecker()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void close()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getSuggestions(android.view.textservice.TextInfo textInfo, int
			 suggestionsLimit)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getSuggestions(android.view.textservice.TextInfo[] textInfos, 
			int suggestionsLimit, bool sequentialWords)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleOnGetSuggestionsMultiple(android.view.textservice.SuggestionsInfo
			[] suggestionInfos)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class SpellCheckerSessionListenerImpl : android.view.textservice.@internal.ISpellCheckerSessionListenerClass
			.Stub
		{
			internal const int TASK_CANCEL = 1;

			internal const int TASK_GET_SUGGESTIONS_MULTIPLE = 2;

			internal readonly System.Collections.Generic.Queue<SpellCheckerParams> mPendingTasks
				 = new System.Collections.Generic.Queue<SpellCheckerParams> ();

			internal readonly android.os.Handler mHandler;

			internal bool mOpened;

			internal android.view.textservice.@internal.ISpellCheckerSession mISpellCheckerSession;

			[Sharpen.Stub]
			public SpellCheckerSessionListenerImpl(android.os.Handler handler)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal class SpellCheckerParams
			{
				public readonly int mWhat;

				public readonly android.view.textservice.TextInfo[] mTextInfos;

				public readonly int mSuggestionsLimit;

				public readonly bool mSequentialWords;

				[Sharpen.Stub]
				public SpellCheckerParams(int what, android.view.textservice.TextInfo[] textInfos
					, int suggestionsLimit, bool sequentialWords)
				{
					throw new System.NotImplementedException();
				}
			}

			[Sharpen.Stub]
			internal void processTask(android.view.textservice.SpellCheckerSession.SpellCheckerSessionListenerImpl
				.SpellCheckerParams scp)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void onServiceConnected(android.view.textservice.@internal.ISpellCheckerSession
				 session)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void getSuggestionsMultiple(android.view.textservice.TextInfo[] textInfos
				, int suggestionsLimit, bool sequentialWords)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isDisconnected()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool checkOpenConnection()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void processOrEnqueueTask(android.view.textservice.SpellCheckerSession.SpellCheckerSessionListenerImpl
				.SpellCheckerParams scp)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void processCancel()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void processGetSuggestionsMultiple(android.view.textservice.SpellCheckerSession.SpellCheckerSessionListenerImpl
				.SpellCheckerParams scp)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ISpellCheckerSessionListener"
				)]
			public override void onGetSuggestions(android.view.textservice.SuggestionsInfo[] 
				results)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public interface SpellCheckerSessionListener
		{
			[Sharpen.Stub]
			void onGetSuggestions(android.view.textservice.SuggestionsInfo[] results);
		}

		[Sharpen.Stub]
		private class InternalListener : android.view.textservice.@internal.ITextServicesSessionListenerClass
			.Stub
		{
			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"com.android.internal.textservice.ITextServicesSessionListener"
				)]
			public override void onServiceConnected(android.view.textservice.@internal.ISpellCheckerSession
				 session)
			{
				throw new System.NotImplementedException();
			}

			internal InternalListener(SpellCheckerSession _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly SpellCheckerSession _enclosing;
		}

		~SpellCheckerSession()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.textservice.@internal.ITextServicesSessionListener getTextServicesSessionListener
			()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.textservice.@internal.ISpellCheckerSessionListener getSpellCheckerSessionListener
			()
		{
			throw new System.NotImplementedException();
		}
	}
}
