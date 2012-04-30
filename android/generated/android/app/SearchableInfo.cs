using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	public sealed class SearchableInfo : android.os.Parcelable
	{
		internal const bool DBG = false;

		internal const string LOG_TAG = "SearchableInfo";

		internal const string MD_LABEL_SEARCHABLE = "android.app.searchable";

		internal const string MD_XML_ELEMENT_SEARCHABLE = "searchable";

		internal const string MD_XML_ELEMENT_SEARCHABLE_ACTION_KEY = "actionkey";

		internal const int SEARCH_MODE_BADGE_LABEL = unchecked((int)(0x04));

		internal const int SEARCH_MODE_BADGE_ICON = unchecked((int)(0x08));

		internal const int SEARCH_MODE_QUERY_REWRITE_FROM_DATA = unchecked((int)(0x10));

		internal const int SEARCH_MODE_QUERY_REWRITE_FROM_TEXT = unchecked((int)(0x20));

		private readonly int mLabelId;

		private readonly android.content.ComponentName mSearchActivity;

		private readonly int mHintId;

		private readonly int mSearchMode;

		private readonly int mIconId;

		private readonly int mSearchButtonText;

		private readonly int mSearchInputType;

		private readonly int mSearchImeOptions;

		private readonly bool mIncludeInGlobalSearch;

		private readonly bool mQueryAfterZeroResults;

		private readonly bool mAutoUrlDetect;

		private readonly int mSettingsDescriptionId;

		private readonly string mSuggestAuthority;

		private readonly string mSuggestPath;

		private readonly string mSuggestSelection;

		private readonly string mSuggestIntentAction;

		private readonly string mSuggestIntentData;

		private readonly int mSuggestThreshold;

		private java.util.HashMap<int, android.app.SearchableInfo.ActionKeyInfo> mActionKeys
			 = null;

		private readonly string mSuggestProviderPackage;

		internal const int VOICE_SEARCH_SHOW_BUTTON = 1;

		internal const int VOICE_SEARCH_LAUNCH_WEB_SEARCH = 2;

		internal const int VOICE_SEARCH_LAUNCH_RECOGNIZER = 4;

		private readonly int mVoiceSearchMode;

		private readonly int mVoiceLanguageModeId;

		private readonly int mVoicePromptTextId;

		private readonly int mVoiceLanguageId;

		private readonly int mVoiceMaxResults;

		[Sharpen.Stub]
		public string getSuggestAuthority()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestPackage()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.ComponentName getSearchActivity()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool useBadgeLabel()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool useBadgeIcon()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool shouldRewriteQueryFromData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool shouldRewriteQueryFromText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSettingsDescriptionId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestPath()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestSelection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestIntentAction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getSuggestIntentData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSuggestThreshold()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.Context getActivityContext(android.content.Context context
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.content.Context createActivityContext(android.content.Context
			 context, android.content.ComponentName activity)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.content.Context getProviderContext(android.content.Context context
			, android.content.Context activityContext)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private SearchableInfo(android.content.Context activityContext, android.util.AttributeSet
			 attr, android.content.ComponentName cName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public class ActionKeyInfo : android.os.Parcelable
		{
			private readonly int mKeyCode;

			private readonly string mQueryActionMsg;

			private readonly string mSuggestActionMsg;

			private readonly string mSuggestActionMsgColumn;

			[Sharpen.Stub]
			internal ActionKeyInfo(android.content.Context activityContext, android.util.AttributeSet
				 attr)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private ActionKeyInfo(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getKeyCode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getQueryActionMsg()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getSuggestActionMsg()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getSuggestActionMsgColumn()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual int describeContents()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
			public virtual void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		public android.app.SearchableInfo.ActionKeyInfo findActionKey(int keyCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addActionKey(android.app.SearchableInfo.ActionKeyInfo keyInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.app.SearchableInfo getActivityMetaData(android.content.Context
			 context, android.content.pm.ActivityInfo activityInfo)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static android.app.SearchableInfo getActivityMetaData(android.content.Context
			 context, org.xmlpull.v1.XmlPullParser xml, android.content.ComponentName cName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getLabelId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getHintId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getIconId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getVoiceSearchEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getVoiceSearchLaunchWebSearch()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool getVoiceSearchLaunchRecognizer()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getVoiceLanguageModeId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getVoicePromptTextId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getVoiceLanguageId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getVoiceMaxResults()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSearchButtonText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getInputType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getImeOptions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool shouldIncludeInGlobalSearch()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool queryAfterZeroResults()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public bool autoUrlDetect()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_778 : android.os.ParcelableClass.Creator<android.app.SearchableInfo
			>
		{
			public _Creator_778()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.SearchableInfo createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.app.SearchableInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.app.SearchableInfo
			> CREATOR = new _Creator_778();

		[Sharpen.Stub]
		internal SearchableInfo(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel dest, int flags)
		{
			throw new System.NotImplementedException();
		}
	}
}
