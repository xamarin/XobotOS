using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public abstract class WindowOrientationListener
	{
		internal const string TAG = "WindowOrientationListener";

		internal const bool DEBUG = false;

		internal const bool localLOGV = DEBUG || false;

		private android.hardware.SensorManager mSensorManager;

		private bool mEnabled;

		private int mRate;

		private android.hardware.Sensor mSensor;

		private android.view.WindowOrientationListener.SensorEventListenerImpl mSensorEventListener;

		internal bool mLogEnabled;

		internal int mCurrentRotation = -1;

		[Sharpen.Stub]
		public WindowOrientationListener(android.content.Context context) : this(context, 
			android.hardware.SensorManager.SENSOR_DELAY_UI)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private WindowOrientationListener(android.content.Context context, int rate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void enable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void disable()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setCurrentRotation(int rotation)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual int getProposedRotation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool canDetectOrientation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onProposedRotationChanged(int rotation);

		[Sharpen.Stub]
		public virtual void setLogEnabled(bool enable_1)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal sealed class SensorEventListenerImpl : android.hardware.SensorEventListener
		{
			internal const float RADIANS_TO_DEGREES = (float)(180 / System.Math.PI);

			internal const int ACCELEROMETER_DATA_X = 0;

			internal const int ACCELEROMETER_DATA_Y = 1;

			internal const int ACCELEROMETER_DATA_Z = 2;

			private readonly android.view.WindowOrientationListener mOrientationListener;

			private long mLastTimestamp = long.MaxValue;

			private float mLastFilteredX;

			private float mLastFilteredY;

			private float mLastFilteredZ;

			private int mProposalRotation;

			private long mProposalAgeMS;

			internal const int HISTORY_SIZE = 20;

			private int mHistoryIndex;

			private int mHistoryLength;

			private readonly long[] mHistoryTimestampMS = new long[HISTORY_SIZE];

			private readonly float[] mHistoryMagnitudes = new float[HISTORY_SIZE];

			private readonly int[] mHistoryTiltAngles = new int[HISTORY_SIZE];

			private readonly int[] mHistoryOrientationAngles = new int[HISTORY_SIZE];

			internal const float MAX_FILTER_DELTA_TIME_MS = 1000;

			internal const float FILTER_TIME_CONSTANT_MS = 100.0f;

			internal const float MIN_ACCELERATION_MAGNITUDE = android.hardware.SensorManager.
				STANDARD_GRAVITY * 0.5f;

			internal const float MAX_ACCELERATION_MAGNITUDE = android.hardware.SensorManager.
				STANDARD_GRAVITY * 1.5f;

			internal const int MAX_TILT = 75;

			private static readonly int[][] TILT_TOLERANCE = new int[][] { new int[] { -20, 70
				 }, new int[] { -20, 60 }, new int[] { -20, 50 }, new int[] { -20, 60 } };

			internal const int ADJACENT_ORIENTATION_ANGLE_GAP = 45;

			internal const int SETTLE_TIME_MS = 200;

			internal const float SETTLE_MAGNITUDE_MAX_DELTA = android.hardware.SensorManager.
				STANDARD_GRAVITY * 0.2f;

			internal const int SETTLE_TILT_ANGLE_MAX_DELTA = 5;

			internal const int SETTLE_ORIENTATION_ANGLE_MAX_DELTA = 5;

			[Sharpen.Stub]
			public SensorEventListenerImpl(android.view.WindowOrientationListener orientationListener
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getProposedRotation()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.hardware.SensorEventListener")]
			public void onAccuracyChanged(android.hardware.Sensor sensor, int accuracy)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.hardware.SensorEventListener")]
			public void onSensorChanged(android.hardware.SensorEvent @event)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool isTiltAngleAcceptable(int proposedRotation, int tiltAngle)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private bool isOrientationAngleAcceptable(int proposedRotation, int orientationAngle
				)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void clearProposal()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private void updateProposal(int rotation, long timestampMS, float magnitude, int 
				tiltAngle, int orientationAngle)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private static int angleAbsoluteDelta(int a, int b)
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
