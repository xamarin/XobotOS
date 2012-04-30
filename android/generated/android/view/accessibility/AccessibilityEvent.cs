using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public sealed class AccessibilityEvent : android.view.accessibility.AccessibilityRecord
		, android.os.Parcelable
	{
		internal const bool DEBUG = false;

		public const int INVALID_POSITION = -1;

		[System.Obsolete]
		public const int MAX_TEXT_LENGTH = 500;

		public const int TYPE_VIEW_CLICKED = unchecked((int)(0x00000001));

		public const int TYPE_VIEW_LONG_CLICKED = unchecked((int)(0x00000002));

		public const int TYPE_VIEW_SELECTED = unchecked((int)(0x00000004));

		public const int TYPE_VIEW_FOCUSED = unchecked((int)(0x00000008));

		public const int TYPE_VIEW_TEXT_CHANGED = unchecked((int)(0x00000010));

		public const int TYPE_WINDOW_STATE_CHANGED = unchecked((int)(0x00000020));

		public const int TYPE_NOTIFICATION_STATE_CHANGED = unchecked((int)(0x00000040));

		public const int TYPE_VIEW_HOVER_ENTER = unchecked((int)(0x00000080));

		public const int TYPE_VIEW_HOVER_EXIT = unchecked((int)(0x00000100));

		public const int TYPE_TOUCH_EXPLORATION_GESTURE_START = unchecked((int)(0x00000200
			));

		public const int TYPE_TOUCH_EXPLORATION_GESTURE_END = unchecked((int)(0x00000400)
			);

		public const int TYPE_WINDOW_CONTENT_CHANGED = unchecked((int)(0x00000800));

		public const int TYPE_VIEW_SCROLLED = unchecked((int)(0x00001000));

		public const int TYPE_VIEW_TEXT_SELECTION_CHANGED = unchecked((int)(0x00002000));

		public const int TYPES_ALL_MASK = unchecked((int)(0xFFFFFFFF));

		internal const int MAX_POOL_SIZE = 10;

		private static readonly object sPoolLock = new object();

		private static android.view.accessibility.AccessibilityEvent sPool;

		private static int sPoolSize;

		private android.view.accessibility.AccessibilityEvent mNext;

		private bool mIsInPool;

		private int mEventType;

		private java.lang.CharSequence mPackageName;

		private long mEventTime;

		private readonly java.util.ArrayList<android.view.accessibility.AccessibilityRecord
			> mRecords = new java.util.ArrayList<android.view.accessibility.AccessibilityRecord
			>();

		[Sharpen.Stub]
		private AccessibilityEvent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal void init(android.view.accessibility.AccessibilityEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.accessibility.AccessibilityRecord")]
		public override void setConnection(android.accessibilityservice.IAccessibilityServiceConnection
			 connection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.accessibility.AccessibilityRecord")]
		public override void setSealed(bool @sealed)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getRecordCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void appendRecord(android.view.accessibility.AccessibilityRecord record)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.accessibility.AccessibilityRecord getRecord(int index)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getEventType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setEventType(int eventType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public long getEventTime()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setEventTime(long eventTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.lang.CharSequence getPackageName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void setPackageName(java.lang.CharSequence packageName)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityEvent obtain(int eventType)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityEvent obtain(android.view.accessibility.AccessibilityEvent
			 @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		new public static android.view.accessibility.AccessibilityEvent obtain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.accessibility.AccessibilityRecord")]
		public override void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.accessibility.AccessibilityRecord")]
		internal override void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public void initFromParcel(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void readAccessibilityRecordFromParcel(android.view.accessibility.AccessibilityRecord
			 record, android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel parcel, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void writeAccessibilityRecordToParcel(android.view.accessibility.AccessibilityRecord
			 record, android.os.Parcel parcel, int flags)
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
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static string eventTypeToString(int eventType)
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_1033 : android.os.ParcelableClass.Creator<android.view.accessibility.AccessibilityEvent
			>
		{
			public _Creator_1033()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.accessibility.AccessibilityEvent createFromParcel(android.os.Parcel
				 parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.accessibility.AccessibilityEvent[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.accessibility.AccessibilityEvent
			> CREATOR = new _Creator_1033();
	}
}
