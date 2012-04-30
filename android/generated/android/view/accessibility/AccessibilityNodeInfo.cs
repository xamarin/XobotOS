using Sharpen;

namespace android.view.accessibility
{
	[Sharpen.Stub]
	public class AccessibilityNodeInfo : android.os.Parcelable
	{
		internal const bool DEBUG = false;

		public const int ACTION_FOCUS = unchecked((int)(0x00000001));

		public const int ACTION_CLEAR_FOCUS = unchecked((int)(0x00000002));

		public const int ACTION_SELECT = unchecked((int)(0x00000004));

		public const int ACTION_CLEAR_SELECTION = unchecked((int)(0x00000008));

		internal const int PROPERTY_CHECKABLE = unchecked((int)(0x00000001));

		internal const int PROPERTY_CHECKED = unchecked((int)(0x00000002));

		internal const int PROPERTY_FOCUSABLE = unchecked((int)(0x00000004));

		internal const int PROPERTY_FOCUSED = unchecked((int)(0x00000008));

		internal const int PROPERTY_SELECTED = unchecked((int)(0x00000010));

		internal const int PROPERTY_CLICKABLE = unchecked((int)(0x00000020));

		internal const int PROPERTY_LONG_CLICKABLE = unchecked((int)(0x00000040));

		internal const int PROPERTY_ENABLED = unchecked((int)(0x00000080));

		internal const int PROPERTY_PASSWORD = unchecked((int)(0x00000100));

		internal const int PROPERTY_SCROLLABLE = unchecked((int)(0x00000200));

		internal const int MAX_POOL_SIZE = 50;

		private static readonly object sPoolLock = new object();

		private static android.view.accessibility.AccessibilityNodeInfo sPool;

		private static int sPoolSize;

		private android.view.accessibility.AccessibilityNodeInfo mNext;

		private bool mIsInPool;

		private bool mSealed;

		private int mAccessibilityViewId = android.view.View.NO_ID;

		private int mAccessibilityWindowId = android.view.View.NO_ID;

		private int mParentAccessibilityViewId = android.view.View.NO_ID;

		private int mBooleanProperties;

		private readonly android.graphics.Rect mBoundsInParent = new android.graphics.Rect
			();

		private readonly android.graphics.Rect mBoundsInScreen = new android.graphics.Rect
			();

		private java.lang.CharSequence mPackageName;

		private java.lang.CharSequence mClassName;

		private java.lang.CharSequence mText;

		private java.lang.CharSequence mContentDescription;

		private android.util.SparseIntArray mChildAccessibilityIds = new android.util.SparseIntArray
			();

		private int mActions;

		private android.accessibilityservice.IAccessibilityServiceConnection mConnection;

		[Sharpen.Stub]
		private AccessibilityNodeInfo()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSource(android.view.View source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getWindowId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getChildCount()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.accessibility.AccessibilityNodeInfo getChild(int index
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addChild(android.view.View child)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getActions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addAction(int action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool performAction(int action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.util.List<android.view.accessibility.AccessibilityNodeInfo> findAccessibilityNodeInfosByText
			(string text)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.view.accessibility.AccessibilityNodeInfo getParent()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setParent(android.view.View parent)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getBoundsInParent(android.graphics.Rect outBounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBoundsInParent(android.graphics.Rect bounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void getBoundsInScreen(android.graphics.Rect outBounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setBoundsInScreen(android.graphics.Rect bounds)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isCheckable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCheckable(bool checkable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isChecked()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setChecked(bool @checked)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isFocusable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFocusable(bool focusable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isFocused()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFocused(bool focused)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSelected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setSelected(bool selected)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isClickable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setClickable(bool clickable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isLongClickable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setLongClickable(bool longClickable)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPassword()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPassword(bool password)
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
		public virtual java.lang.CharSequence getPackageName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPackageName(java.lang.CharSequence packageName)
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
		public virtual java.lang.CharSequence getText()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setText(java.lang.CharSequence text)
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
		public void setConnection(android.accessibilityservice.IAccessibilityServiceConnection
			 connection)
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
		public virtual void setSealed(bool @sealed)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void enforceSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void enforceNotSealed()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityNodeInfo obtain(android.view.View
			 source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityNodeInfo obtain()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.accessibility.AccessibilityNodeInfo obtain(android.view.accessibility.AccessibilityNodeInfo
			 info)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void recycle()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public virtual void writeToParcel(android.os.Parcel parcel, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void init(android.view.accessibility.AccessibilityNodeInfo other)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initFromParcel(android.os.Parcel parcel)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void clear()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static string getActionSymbolicName(int action)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool canPerformRequestOverConnection(int accessibilityViewId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override bool Equals(object @object)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override int GetHashCode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}

		private sealed class _Creator_1144 : android.os.ParcelableClass.Creator<android.view.accessibility.AccessibilityNodeInfo
			>
		{
			public _Creator_1144()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.accessibility.AccessibilityNodeInfo createFromParcel(android.os.Parcel
				 parcel)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.accessibility.AccessibilityNodeInfo[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.accessibility.AccessibilityNodeInfo
			> CREATOR = new _Creator_1144();
	}
}
