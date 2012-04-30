using Sharpen;

namespace android.inputmethodservice
{
	[Sharpen.Stub]
	public class KeyboardView : android.view.View, android.view.View.OnClickListener
	{
		[Sharpen.Stub]
		public interface OnKeyboardActionListener
		{
			[Sharpen.Stub]
			void onPress(int primaryCode);

			[Sharpen.Stub]
			void onRelease(int primaryCode);

			[Sharpen.Stub]
			void onKey(int primaryCode, int[] keyCodes);

			[Sharpen.Stub]
			void onText(java.lang.CharSequence text);

			[Sharpen.Stub]
			void swipeLeft();

			[Sharpen.Stub]
			void swipeRight();

			[Sharpen.Stub]
			void swipeDown();

			[Sharpen.Stub]
			void swipeUp();
		}

		internal const bool DEBUG = false;

		internal const int NOT_A_KEY = -1;

		private static readonly int[] KEY_DELETE = new int[] { android.inputmethodservice.Keyboard
			.KEYCODE_DELETE };

		private static readonly int[] LONG_PRESSABLE_STATE_SET = new int[] { android.@internal.R
			.attr.state_long_pressable };

		private android.inputmethodservice.Keyboard mKeyboard;

		private int mCurrentKeyIndex = NOT_A_KEY;

		private int mLabelTextSize;

		private int mKeyTextSize;

		private int mKeyTextColor;

		private float mShadowRadius;

		private int mShadowColor;

		private float mBackgroundDimAmount;

		private android.widget.TextView mPreviewText;

		private android.widget.PopupWindow mPreviewPopup;

		private int mPreviewTextSizeLarge;

		private int mPreviewOffset;

		private int mPreviewHeight;

		private readonly int[] mCoordinates = new int[2];

		private android.widget.PopupWindow mPopupKeyboard;

		private android.view.View mMiniKeyboardContainer;

		private android.inputmethodservice.KeyboardView mMiniKeyboard;

		private bool mMiniKeyboardOnScreen;

		private android.view.View mPopupParent;

		private int mMiniKeyboardOffsetX;

		private int mMiniKeyboardOffsetY;

		private java.util.Map<android.inputmethodservice.Keyboard.Key, android.view.View>
			 mMiniKeyboardCache;

		private android.inputmethodservice.Keyboard.Key[] mKeys;

		private android.inputmethodservice.KeyboardView.OnKeyboardActionListener mKeyboardActionListener;

		internal const int MSG_SHOW_PREVIEW = 1;

		internal const int MSG_REMOVE_PREVIEW = 2;

		internal const int MSG_REPEAT = 3;

		internal const int MSG_LONGPRESS = 4;

		internal const int DELAY_BEFORE_PREVIEW = 0;

		internal const int DELAY_AFTER_PREVIEW = 70;

		internal const int DEBOUNCE_TIME = 70;

		private int mVerticalCorrection;

		private int mProximityThreshold;

		private bool mPreviewCentered = false;

		private bool mShowPreview = true;

		private bool mShowTouchPoints = true;

		private int mPopupPreviewX;

		private int mPopupPreviewY;

		private int mLastX;

		private int mLastY;

		private int mStartX;

		private int mStartY;

		private bool mProximityCorrectOn;

		private android.graphics.Paint mPaint;

		private android.graphics.Rect mPadding;

		private long mDownTime;

		private long mLastMoveTime;

		private int mLastKey;

		private int mLastCodeX;

		private int mLastCodeY;

		private int mCurrentKey = NOT_A_KEY;

		private int mDownKey = NOT_A_KEY;

		private long mLastKeyTime;

		private long mCurrentKeyTime;

		private int[] mKeyIndices = new int[12];

		private android.view.GestureDetector mGestureDetector;

		private int mPopupX;

		private int mPopupY;

		private int mRepeatKeyIndex = NOT_A_KEY;

		private int mPopupLayout;

		private bool mAbortKey;

		private android.inputmethodservice.Keyboard.Key mInvalidatedKey;

		private android.graphics.Rect mClipRegion = new android.graphics.Rect(0, 0, 0, 0);

		private bool mPossiblePoly;

		private android.inputmethodservice.KeyboardView.SwipeTracker mSwipeTracker = new 
			android.inputmethodservice.KeyboardView.SwipeTracker();

		private int mSwipeThreshold;

		private bool mDisambiguateSwipe;

		private int mOldPointerCount = 1;

		private float mOldPointerX;

		private float mOldPointerY;

		private android.graphics.drawable.Drawable mKeyBackground;

		internal const int REPEAT_INTERVAL = 50;

		internal const int REPEAT_START_DELAY = 400;

		private static readonly int LONGPRESS_TIMEOUT = android.view.ViewConfiguration.getLongPressTimeout
			();

		private static int MAX_NEARBY_KEYS = 12;

		private int[] mDistances = new int[MAX_NEARBY_KEYS];

		private int mLastSentIndex;

		private int mTapCount;

		private long mLastTapTime;

		private bool mInMultiTap;

		internal const int MULTITAP_INTERVAL = 800;

		private java.lang.StringBuilder mPreviewLabel = new java.lang.StringBuilder(1);

		private bool mDrawPending;

		private android.graphics.Rect mDirtyRect = new android.graphics.Rect();

		private android.graphics.Bitmap mBuffer;

		private bool mKeyboardChanged;

		private android.graphics.Canvas mCanvas;

		private android.view.accessibility.AccessibilityManager mAccessibilityManager;

		private android.media.AudioManager mAudioManager;

		private bool mHeadsetRequiredToHearPasswordsAnnounced;

		private sealed class _Handler_254 : android.os.Handler
		{
			public _Handler_254()
			{
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.os.Handler")]
			public override void handleMessage(android.os.Message msg)
			{
				throw new System.NotImplementedException();
			}
		}

		internal android.os.Handler mHandler = new _Handler_254();

		[Sharpen.Stub]
		public KeyboardView(android.content.Context context, android.util.AttributeSet attrs
			) : this(context, attrs, android.@internal.R.attr.keyboardViewStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public KeyboardView(android.content.Context context, android.util.AttributeSet attrs
			, int defStyle) : base(context, attrs, defStyle)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void initGestureDetector()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnKeyboardActionListener(android.inputmethodservice.KeyboardView
			.OnKeyboardActionListener listener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual android.inputmethodservice.KeyboardView.OnKeyboardActionListener
			 getOnKeyboardActionListener()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setKeyboard(android.inputmethodservice.Keyboard keyboard)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.inputmethodservice.Keyboard getKeyboard()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool setShifted(bool shifted)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isShifted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPreviewEnabled(bool previewEnabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isPreviewEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setVerticalCorrection(int verticalOffset)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPopupParent(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPopupOffset(int x, int y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setProximityCorrectionEnabled(bool enabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isProximityCorrectionEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.view.View.OnClickListener")]
		public virtual void onClick(android.view.View v)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.lang.CharSequence adjustCase(java.lang.CharSequence label)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onMeasure(int widthMeasureSpec, int heightMeasureSpec
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void computeProximityThreshold(android.inputmethodservice.Keyboard keyboard
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onSizeChanged(int w, int h, int oldw, int oldh)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDraw(android.graphics.Canvas canvas)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void onBufferDraw()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getKeyIndices(int x, int y, int[] allKeys)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void detectAndSendKey(int index, int x, int y, long eventTime)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private java.lang.CharSequence getPreviewText(android.inputmethodservice.Keyboard
			.Key key)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void showPreview(int keyIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void showKey(int keyIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendAccessibilityEventForUnicodeCharacter(int eventType, int code)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void invalidateAllKeys()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void invalidateKey(int keyIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool openPopupIfRequired(android.view.MotionEvent me)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual bool onLongPress(android.inputmethodservice.Keyboard.Key
			 popupKey)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onHoverEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTouchEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool onTouchEventInternal(android.view.MotionEvent me)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool onModifiedTouchEvent(android.view.MotionEvent me, bool possiblePoly)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private bool repeatKey()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void swipeRight()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void swipeLeft()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void swipeUp()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		protected internal virtual void swipeDown()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void closing()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void removeMessages()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onDetachedFromWindow()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void dismissPopupKeyboard()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool handleBack()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void resetMultiTap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void checkMultiTap(long eventTime, int keyIndex)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class SwipeTracker
		{
			internal const int NUM_PAST = 4;

			internal const int LONGEST_PAST_TIME = 200;

			internal readonly float[] mPastX = new float[NUM_PAST];

			internal readonly float[] mPastY = new float[NUM_PAST];

			internal readonly long[] mPastTime = new long[NUM_PAST];

			internal float mYVelocity;

			internal float mXVelocity;

			[Sharpen.Stub]
			public virtual void clear()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void addMovement(android.view.MotionEvent ev)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal void addPoint(float x, float y, long time)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void computeCurrentVelocity(int units)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void computeCurrentVelocity(int units, float maxVelocity)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual float getXVelocity()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual float getYVelocity()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
