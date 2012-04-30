using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class LockPatternView : android.view.View
	{
		internal const string TAG = "LockPatternView";

		internal const int ASPECT_SQUARE = 0;

		internal const int ASPECT_LOCK_WIDTH = 1;

		internal const int ASPECT_LOCK_HEIGHT = 2;

		internal const bool PROFILE_DRAWING = false;

		private bool mDrawingProfilingStarted = false;

		private android.graphics.Paint mPaint = new android.graphics.Paint();

		private android.graphics.Paint mPathPaint = new android.graphics.Paint();

		internal const int STATUS_BAR_HEIGHT = 25;

		internal const int MILLIS_PER_CIRCLE_ANIMATING = 700;

		private android.widget.@internal.LockPatternView.OnPatternListener mOnPatternListener;

		private java.util.ArrayList<android.widget.@internal.LockPatternView.Cell> mPattern
			 = new java.util.ArrayList<android.widget.@internal.LockPatternView.Cell>(9);

		private bool[][] mPatternDrawLookup = new bool[][] { new bool[3], new bool[3], new 
			bool[3] };

		private float mInProgressX = -1;

		private float mInProgressY = -1;

		private long mAnimatingPeriodStart;

		private android.widget.@internal.LockPatternView.DisplayMode mPatternDisplayMode = 
			android.widget.@internal.LockPatternView.DisplayMode.Correct;

		private bool mInputEnabled = true;

		private bool mInStealthMode = false;

		private bool mEnableHapticFeedback = true;

		private bool mPatternInProgress = false;

		private float mDiameterFactor = 0.10f;

		private readonly int mStrokeAlpha = 128;

		private float mHitFactor = 0.6f;

		private float mSquareWidth;

		private float mSquareHeight;

		private android.graphics.Bitmap mBitmapBtnDefault;

		private android.graphics.Bitmap mBitmapBtnTouched;

		private android.graphics.Bitmap mBitmapCircleDefault;

		private android.graphics.Bitmap mBitmapCircleGreen;

		private android.graphics.Bitmap mBitmapCircleRed;

		private android.graphics.Bitmap mBitmapArrowGreenUp;

		private android.graphics.Bitmap mBitmapArrowRedUp;

		private readonly android.graphics.Path mCurrentPath = new android.graphics.Path();

		private readonly android.graphics.Rect mInvalidate = new android.graphics.Rect();

		private int mBitmapWidth;

		private int mBitmapHeight;

		private int mAspect;

		private readonly android.graphics.Matrix mArrowMatrix = new android.graphics.Matrix
			();

		private readonly android.graphics.Matrix mCircleMatrix = new android.graphics.Matrix
			();

		[Sharpen.Stub]
		public class Cell
		{
			internal int row;

			internal int column;

			internal static android.widget.@internal.LockPatternView.Cell[][] sCells = new android.widget.@internal.LockPatternView
				.Cell[][] { new android.widget.@internal.LockPatternView.Cell[3], new android.widget.@internal.LockPatternView
				.Cell[3], new android.widget.@internal.LockPatternView.Cell[3] };

			static Cell()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private Cell(int row, int column)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getRow()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getColumn()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public static android.widget.@internal.LockPatternView.Cell of(int row, int column
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private static void checkRange(int row, int column)
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

		public enum DisplayMode
		{
			/// <summary>The pattern drawn is correct (i.e draw it in a friendly color)</summary>
			Correct,
			/// <summary>Animate the pattern (for demo, and help).</summary>
			/// <remarks>Animate the pattern (for demo, and help).</remarks>
			Animate,
			/// <summary>The pattern is wrong (i.e draw a foreboding color)</summary>
			Wrong
		}

		[Sharpen.Stub]
		public interface OnPatternListener
		{
			[Sharpen.Stub]
			void onPatternStart();

			[Sharpen.Stub]
			void onPatternCleared();

			[Sharpen.Stub]
			void onPatternCellAdded(java.util.List<android.widget.@internal.LockPatternView.Cell
				> pattern);

			[Sharpen.Stub]
			void onPatternDetected(java.util.List<android.widget.@internal.LockPatternView.Cell
				> pattern);
		}

		[Sharpen.Stub]
		public LockPatternView(android.content.Context context) : this(context, null)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public LockPatternView(android.content.Context context, android.util.AttributeSet
			 attrs) : base(context, attrs)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.graphics.Bitmap getBitmapFor(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isInStealthMode()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool isTactileFeedbackEnabled()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInStealthMode(bool inStealthMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setTactileFeedbackEnabled(bool tactileFeedbackEnabled)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setOnPatternListener(android.widget.@internal.LockPatternView
			.OnPatternListener onPatternListener)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPattern(android.widget.@internal.LockPatternView.DisplayMode
			 displayMode, java.util.List<android.widget.@internal.LockPatternView.Cell> pattern
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setDisplayMode(android.widget.@internal.LockPatternView.DisplayMode
			 displayMode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyCellAdded()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyPatternStarted()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyPatternDetected()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void notifyPatternCleared()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void clearPattern()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void resetPattern()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void clearPatternDrawLookup()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disableInput()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void enableInput()
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
		private int resolveMeasured(int measureSpec, int desired)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getSuggestedMinimumWidth()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override int getSuggestedMinimumHeight()
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
		private android.widget.@internal.LockPatternView.Cell detectAndAddHit(float x, float
			 y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addCellToPattern(android.widget.@internal.LockPatternView.Cell newCell
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private android.widget.@internal.LockPatternView.Cell checkForNewHit(float x, float
			 y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getRowHit(float y)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private int getColumnHit(float x)
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
		private void handleActionMove(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void sendAccessEvent(int resId)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleActionUp(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void handleActionDown(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float getCenterXForColumn(int column)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private float getCenterYForRow(int row)
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
		private void drawArrow(android.graphics.Canvas canvas, float leftX, float topY, android.widget.@internal.LockPatternView
			.Cell start, android.widget.@internal.LockPatternView.Cell end)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void drawCircle(android.graphics.Canvas canvas, int leftX, int topY, bool
			 partOfPattern)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override android.os.Parcelable onSaveInstanceState()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		protected internal override void onRestoreInstanceState(android.os.Parcelable state
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private class SavedState : android.view.View.BaseSavedState
		{
			internal readonly string mSerializedPattern;

			internal readonly int mDisplayMode;

			internal readonly bool mInputEnabled;

			internal readonly bool mInStealthMode;

			internal readonly bool mTactileFeedbackEnabled;

			[Sharpen.Stub]
			internal SavedState(android.os.Parcelable superState, string serializedPattern, int
				 displayMode, bool inputEnabled, bool inStealthMode, bool tactileFeedbackEnabled
				) : base(superState)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal SavedState(android.os.Parcel @in) : base(@in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual string getSerializedPattern()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getDisplayMode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isInputEnabled()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isInStealthMode()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual bool isTactileFeedbackEnabled()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.view.AbsSavedState")]
			public override void writeToParcel(android.os.Parcel dest, int flags)
			{
				throw new System.NotImplementedException();
			}

			internal sealed class _Creator_1173 : android.os.ParcelableClass.Creator<android.widget.@internal.LockPatternView
				.SavedState>
			{
				public _Creator_1173()
				{
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.LockPatternView.SavedState createFromParcel(android.os.Parcel
					 @in)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.Stub]
				[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
				public android.widget.@internal.LockPatternView.SavedState[] newArray(int size)
				{
					throw new System.NotImplementedException();
				}
			}

			internal static readonly android.os.ParcelableClass.Creator<android.widget.@internal.LockPatternView
				.SavedState> CREATOR = new _Creator_1173();
		}
	}
}
