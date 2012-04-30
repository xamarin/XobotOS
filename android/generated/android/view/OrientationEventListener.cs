using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public abstract class OrientationEventListener
	{
		internal const string TAG = "OrientationEventListener";

		internal const bool DEBUG = false;

		internal const bool localLOGV = false;

		private int mOrientation = ORIENTATION_UNKNOWN;

		private android.hardware.SensorManager mSensorManager;

		private bool mEnabled = false;

		private int mRate;

		private android.hardware.Sensor mSensor;

		private android.hardware.SensorEventListener mSensorEventListener;

		private android.view.OrientationListener mOldListener;

		public const int ORIENTATION_UNKNOWN = -1;

		[Sharpen.Stub]
		public OrientationEventListener(android.content.Context context) : this(context, 
			android.hardware.SensorManager.SENSOR_DELAY_NORMAL)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public OrientationEventListener(android.content.Context context, int rate)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual void registerListener(android.view.OrientationListener lis)
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
		internal class SensorEventListenerImpl : android.hardware.SensorEventListener
		{
			internal const int _DATA_X = 0;

			internal const int _DATA_Y = 1;

			internal const int _DATA_Z = 2;

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.hardware.SensorEventListener")]
			public virtual void onSensorChanged(android.hardware.SensorEvent @event)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.hardware.SensorEventListener")]
			public virtual void onAccuracyChanged(android.hardware.Sensor sensor, int accuracy
				)
			{
				throw new System.NotImplementedException();
			}

			internal SensorEventListenerImpl(OrientationEventListener _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly OrientationEventListener _enclosing;
		}

		[Sharpen.Stub]
		public virtual bool canDetectOrientation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract void onOrientationChanged(int orientation);
	}
}
