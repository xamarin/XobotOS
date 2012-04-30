using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public class AccessibilityRecord
	{
		internal const int UNDEFINED = -1;

		internal const int PROPERTY_CHECKED = unchecked((int)(0x00000001));

		internal const int PROPERTY_ENABLED = unchecked((int)(0x00000002));

		internal const int PROPERTY_PASSWORD = unchecked((int)(0x00000004));

		internal const int PROPERTY_FULL_SCREEN = unchecked((int)(0x00000080));

		internal const int PROPERTY_SCROLLABLE = unchecked((int)(0x00000100));

		internal const int MAX_POOL_SIZE = 10;

		private static readonly object sPoolLock = new object();

		private static android.view.accessibility.AccessibilityRecord sPool;

		private static int sPoolSize;

		private android.view.accessibility.AccessibilityRecord mNext;

		private bool mIsInPool;

		internal bool mSealed;

		internal int mBooleanProperties;

		internal int mCurrentItemIndex = UNDEFINED;

		internal int mItemCount = UNDEFINED;

		internal int mFromIndex = UNDEFINED;

		internal int mToIndex = UNDEFINED;

		internal int mScrollX = UNDEFINED;

		internal int mScrollY = UNDEFINED;

		internal int mMaxScrollX = UNDEFINED;

		internal int mMaxScrollY = UNDEFINED;

		internal int mAddedCount = UNDEFINED;

		internal int mRemovedCount = UNDEFINED;

		internal int mSourceViewId = android.view.View.NO_ID;

		internal int mSourceWindowId = android.view.View.NO_ID;

		internal java.lang.CharSequence mClassName;

		internal java.lang.CharSequence mContentDescription;

		internal java.lang.CharSequence mBeforeText;

		internal android.os.Parcelable mParcelableData;

		internal readonly java.util.List<java.lang.CharSequence> mText = new java.util.ArrayList
			<java.lang.CharSequence>();

		internal android.accessibilityservice.IAccessibilityServiceConnection mConnection;

		[Sharpen.Stub]
		internal AccessibilityRecord()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSource(android.view.View source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.accessibility.AccessibilityNodeInfo getSource()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setConnection(android.accessibilityservice.IAccessibilityServiceConnection
			 connection)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getWindowId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isChecked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setChecked(bool isChecked_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEnabled(bool isEnabled_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPassword()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPassword(bool isPassword_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isFullScreen()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFullScreen(bool isFullScreen_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isScrollable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setScrollable(bool scrollable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getItemCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setItemCount(int itemCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getCurrentItemIndex()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCurrentItemIndex(int currentItemIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getFromIndex()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFromIndex(int fromIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getToIndex()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setToIndex(int toIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getScrollX()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setScrollX(int scrollX)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getScrollY()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setScrollY(int scrollY)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMaxScrollX()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaxScrollX(int maxScrollX)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getMaxScrollY()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setMaxScrollY(int maxScrollY)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getAddedCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setAddedCount(int addedCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getRemovedCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setRemovedCount(int removedCount)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getClassName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setClassName(java.lang.CharSequence className)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<java.lang.CharSequence> getText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getBeforeText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBeforeText(java.lang.CharSequence beforeText)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.CharSequence getContentDescription()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setContentDescription(java.lang.CharSequence contentDescription
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.os.Parcelable getParcelableData()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setParcelableData(android.os.Parcelable parcelableData)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSealed(bool @sealed)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual bool isSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void enforceSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void enforceNotSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool getBooleanProperty(int property)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void setBooleanProperty(int property, bool value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityRecord obtain(android.view.accessibility.AccessibilityRecord
			 record)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityRecord obtain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void init(android.view.accessibility.AccessibilityRecord record)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
