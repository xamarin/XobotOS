using Sharpen;

namespace android.widget.@internal
{
	[Sharpen.Stub]
	public class PointerLocationView : android.view.View
	{
		internal const string TAG = "Pointer";

		[Sharpen.Stub]
		public class PointerState
		{
			private float[] mTraceX = new float[32];

			private float[] mTraceY = new float[32];

			private int mTraceCount;

			private bool mCurDown;

			private android.view.MotionEvent.PointerCoords mCoords = new android.view.MotionEvent
				.PointerCoords();

			private int mToolType;

			private float mXVelocity;

			private float mYVelocity;

			private android.view.VelocityTracker.Estimator mEstimator = new android.view.VelocityTracker
				.Estimator();

			[Sharpen.Stub]
			public virtual void clearTrace()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual void addTrace(float x, float y)
			{
				throw new System.NotImplementedException();
			}
		}

		private readonly int ESTIMATE_PAST_POINTS = 4;

		private readonly int ESTIMATE_FUTURE_POINTS = 2;

		private readonly float ESTIMATE_INTERVAL = 0.02f;

		private readonly android.view.ViewConfiguration mVC;

		private readonly android.graphics.Paint mTextPaint;

		private readonly android.graphics.Paint mTextBackgroundPaint;

		private readonly android.graphics.Paint mTextLevelPaint;

		private readonly android.graphics.Paint mPaint;

		private readonly android.graphics.Paint mTargetPaint;

		private readonly android.graphics.Paint mPathPaint;

		private readonly android.graphics.Paint.FontMetricsInt mTextMetrics = new android.graphics.Paint
			.FontMetricsInt();

		private int mHeaderBottom;

		private bool mCurDown;

		private int mCurNumPointers;

		private int mMaxNumPointers;

		private int mActivePointerId;

		private readonly java.util.ArrayList<android.widget.@internal.PointerLocationView
			.PointerState> mPointers = new java.util.ArrayList<android.widget.@internal.PointerLocationView
			.PointerState>();

		private readonly android.view.MotionEvent.PointerCoords mTempCoords = new android.view.MotionEvent
			.PointerCoords();

		private readonly android.view.VelocityTracker mVelocity;

		private readonly android.widget.@internal.PointerLocationView.FasterStringBuilder
			 mText = new android.widget.@internal.PointerLocationView.FasterStringBuilder();

		private bool mPrintCoords = true;

		[Sharpen.Stub]
		public PointerLocationView(android.content.Context c) : base(c)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void logInputDeviceCapabilities()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setPrintCoords(bool state)
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

		private android.graphics.RectF mReusableOvalRect = new android.graphics.RectF();

		[Sharpen.Stub]
		private void drawOval(android.graphics.Canvas canvas, float x, float y, float major
			, float minor, float angle, android.graphics.Paint paint)
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
		private void logMotionEvent(string type, android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void logCoords(string type, int action, int index, android.view.MotionEvent
			.PointerCoords coords, int id, int toolType, int buttonState)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void addPointerEvent(android.view.MotionEvent @event)
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
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onGenericMotionEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyDown(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onKeyUp(int keyCode, android.view.KeyEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private static bool shouldLogKey(int keyCode)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.view.View")]
		public override bool onTrackballEvent(android.view.MotionEvent @event)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class FasterStringBuilder
		{
			internal char[] mChars;

			internal int mLength;

			[Sharpen.Stub]
			public FasterStringBuilder()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.widget.@internal.PointerLocationView.FasterStringBuilder clear()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.widget.@internal.PointerLocationView.FasterStringBuilder append(string
				 value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.widget.@internal.PointerLocationView.FasterStringBuilder append(int
				 value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.widget.@internal.PointerLocationView.FasterStringBuilder append(int
				 value, int zeroPadWidth)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public android.widget.@internal.PointerLocationView.FasterStringBuilder append(float
				 value, int precision)
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
			internal int reserve(int length)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
