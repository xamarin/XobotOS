using Sharpen;

namespace android.hardware
{
	[Sharpen.Stub]
	public class SensorManager
	{
		private static readonly string TAG = "SensorManager";

		private static readonly float[] mTempMatrix = new float[16];

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_ORIENTATION = 1 << 0;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_ACCELEROMETER = 1 << 1;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_TEMPERATURE = 1 << 2;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_MAGNETIC_FIELD = 1 << 3;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_LIGHT = 1 << 4;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_PROXIMITY = 1 << 5;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_TRICORDER = 1 << 6;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_ORIENTATION_RAW = 1 << 7;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_ALL = unchecked((int)(0x7F));

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_MIN = SENSOR_ORIENTATION;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int SENSOR_MAX = ((SENSOR_ALL + 1) >> 1);

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int DATA_X = 0;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int DATA_Y = 1;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int DATA_Z = 2;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int RAW_DATA_INDEX = 3;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int RAW_DATA_X = 3;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int RAW_DATA_Y = 4;

		[System.ObsoleteAttribute(@"use Sensor Sensor instead.")]
		public const int RAW_DATA_Z = 5;

		public const float STANDARD_GRAVITY = 9.80665f;

		public const float GRAVITY_SUN = 275.0f;

		public const float GRAVITY_MERCURY = 3.70f;

		public const float GRAVITY_VENUS = 8.87f;

		public const float GRAVITY_EARTH = 9.80665f;

		public const float GRAVITY_MOON = 1.6f;

		public const float GRAVITY_MARS = 3.71f;

		public const float GRAVITY_JUPITER = 23.12f;

		public const float GRAVITY_SATURN = 8.96f;

		public const float GRAVITY_URANUS = 8.69f;

		public const float GRAVITY_NEPTUNE = 11.0f;

		public const float GRAVITY_PLUTO = 0.6f;

		public const float GRAVITY_DEATH_STAR_I = 0.000000353036145f;

		public const float GRAVITY_THE_ISLAND = 4.815162342f;

		public const float MAGNETIC_FIELD_EARTH_MAX = 60.0f;

		public const float MAGNETIC_FIELD_EARTH_MIN = 30.0f;

		public const float PRESSURE_STANDARD_ATMOSPHERE = 1013.25f;

		public const float LIGHT_SUNLIGHT_MAX = 120000.0f;

		public const float LIGHT_SUNLIGHT = 110000.0f;

		public const float LIGHT_SHADE = 20000.0f;

		public const float LIGHT_OVERCAST = 10000.0f;

		public const float LIGHT_SUNRISE = 400.0f;

		public const float LIGHT_CLOUDY = 100.0f;

		public const float LIGHT_FULLMOON = 0.25f;

		public const float LIGHT_NO_MOON = 0.001f;

		public const int SENSOR_DELAY_FASTEST = 0;

		public const int SENSOR_DELAY_GAME = 1;

		public const int SENSOR_DELAY_UI = 2;

		public const int SENSOR_DELAY_NORMAL = 3;

		public const int SENSOR_STATUS_UNRELIABLE = 0;

		public const int SENSOR_STATUS_ACCURACY_LOW = 1;

		public const int SENSOR_STATUS_ACCURACY_MEDIUM = 2;

		public const int SENSOR_STATUS_ACCURACY_HIGH = 3;

		public const int AXIS_X = 1;

		public const int AXIS_Y = 2;

		public const int AXIS_Z = 3;

		public const int AXIS_MINUS_X = AXIS_X | unchecked((int)(0x80));

		public const int AXIS_MINUS_Y = AXIS_Y | unchecked((int)(0x80));

		public const int AXIS_MINUS_Z = AXIS_Z | unchecked((int)(0x80));

		internal android.os.Looper mMainLooper;

		private System.Collections.Generic.Dictionary<android.hardware.SensorListener, android.hardware.SensorManager.LegacyListener
			> mLegacyListenersMap = new System.Collections.Generic.Dictionary<android.hardware.SensorListener
			, android.hardware.SensorManager.LegacyListener>();

		private const int SENSOR_DISABLE = -1;

		private static bool sSensorModuleInitialized = false;

		private static System.Collections.Generic.List<android.hardware.Sensor> sFullSensorsList
			 = new System.Collections.Generic.List<android.hardware.Sensor>();

		private static android.util.SparseArray<System.Collections.Generic.IList<android.hardware.Sensor
			>> sSensorListByType = new android.util.SparseArray<System.Collections.Generic.IList
			<android.hardware.Sensor>>();

		private static android.view.IWindowManager sWindowManager;

		private static int sRotation = android.view.Surface.ROTATION_0;

		private static android.hardware.SensorManager.SensorThread sSensorThread;

		private static int sQueue;

		internal static android.util.SparseArray<android.hardware.Sensor> sHandleToSensor
			 = new android.util.SparseArray<android.hardware.Sensor>();

		internal static readonly System.Collections.Generic.List<android.hardware.SensorManager.ListenerDelegate
			> sListeners = new System.Collections.Generic.List<android.hardware.SensorManager.ListenerDelegate
			>();

		[Sharpen.Stub]
		private class SensorThread
		{
			internal java.lang.Thread mThread;

			internal bool mSensorsReady;

			public SensorThread()
			{
				throw new System.NotImplementedException();
			}

			internal virtual bool startLocked()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private class SensorThreadRunnable : java.lang.Runnable
			{
				public SensorThreadRunnable(SensorThread _enclosing)
				{
					throw new System.NotImplementedException();
				}

				private bool open()
				{
					throw new System.NotImplementedException();
				}

				public virtual void run()
				{
					throw new System.NotImplementedException();
				}

				private readonly SensorThread _enclosing;
			}
		}

		[Sharpen.Stub]
		internal class ListenerDelegate
		{
			internal readonly android.hardware.SensorEventListener mSensorEventListener;

			private readonly System.Collections.Generic.List<android.hardware.Sensor> mSensorList
				 = new System.Collections.Generic.List<android.hardware.Sensor>();

			private readonly android.os.Handler mHandler;

			private android.hardware.SensorEvent mValuesPool;

			public android.util.SparseBooleanArray mSensors = new android.util.SparseBooleanArray
				();

			public android.util.SparseBooleanArray mFirstEvent = new android.util.SparseBooleanArray
				();

			public android.util.SparseIntArray mSensorAccuracies = new android.util.SparseIntArray
				();

			internal ListenerDelegate(SensorManager _enclosing, android.hardware.SensorEventListener
				 listener, android.hardware.Sensor sensor, android.os.Handler handler)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			private sealed class _Handler_502 : android.os.Handler
			{
				public _Handler_502(ListenerDelegate _enclosing, android.os.Looper baseArg1) : base
					(baseArg1)
				{
					throw new System.NotImplementedException();
				}

				[Sharpen.OverridesMethod(@"android.os.Handler")]
				public override void handleMessage(android.os.Message msg)
				{
					throw new System.NotImplementedException();
				}

				private readonly ListenerDelegate _enclosing;
			}

			protected internal virtual android.hardware.SensorEvent createSensorEvent()
			{
				throw new System.NotImplementedException();
			}

			protected internal virtual android.hardware.SensorEvent getFromPool()
			{
				throw new System.NotImplementedException();
			}

			protected internal virtual void returnToPool(android.hardware.SensorEvent t)
			{
				throw new System.NotImplementedException();
			}

			internal virtual object getListener()
			{
				throw new System.NotImplementedException();
			}

			internal virtual void addSensor(android.hardware.Sensor sensor)
			{
				throw new System.NotImplementedException();
			}

			internal virtual int removeSensor(android.hardware.Sensor sensor)
			{
				throw new System.NotImplementedException();
			}

			internal virtual bool hasSensor(android.hardware.Sensor sensor)
			{
				throw new System.NotImplementedException();
			}

			internal virtual System.Collections.Generic.IList<android.hardware.Sensor> getSensors
				()
			{
				throw new System.NotImplementedException();
			}

			internal virtual void onSensorChangedLocked(android.hardware.Sensor sensor, float
				[] values, long[] timestamp, int accuracy)
			{
				throw new System.NotImplementedException();
			}

			private readonly SensorManager _enclosing;
		}

		public SensorManager(android.os.Looper mainLooper)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private sealed class _Stub_620 : android.view.IRotationWatcherClass.Stub
		{
			public _Stub_620(SensorManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.ImplementsInterface(@"android.view.IRotationWatcher")]
			public override void onRotationChanged(int rotation)
			{
				throw new System.NotImplementedException();
			}

			private readonly SensorManager _enclosing;
		}

		private int getLegacySensorType(int type)
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"This method is deprecated, usegetSensorList(int) instead"
			)]
		public virtual int getSensors()
		{
			throw new System.NotImplementedException();
		}

		public virtual System.Collections.Generic.IList<android.hardware.Sensor> getSensorList
			(int type)
		{
			throw new System.NotImplementedException();
		}

		public virtual android.hardware.Sensor getDefaultSensor(int type)
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"This method is deprecated, useregisterListener(SensorEventListener, Sensor, int) instead."
			)]
		public virtual bool registerListener(android.hardware.SensorListener listener, int
			 sensors)
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"This method is deprecated, useregisterListener(SensorEventListener, Sensor, int) instead."
			)]
		public virtual bool registerListener(android.hardware.SensorListener listener, int
			 sensors, int rate)
		{
			throw new System.NotImplementedException();
		}

		private bool registerLegacyListener(int legacyType, int type, android.hardware.SensorListener
			 listener, int sensors, int rate)
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"This method is deprecated, useunregisterListener(SensorEventListener, Sensor) instead."
			)]
		public virtual void unregisterListener(android.hardware.SensorListener listener, 
			int sensors)
		{
			throw new System.NotImplementedException();
		}

		private void unregisterLegacyListener(int legacyType, int type, android.hardware.SensorListener
			 listener, int sensors)
		{
			throw new System.NotImplementedException();
		}

		[System.ObsoleteAttribute(@"This method is deprecated, useunregisterListener(SensorEventListener) instead."
			)]
		public virtual void unregisterListener(android.hardware.SensorListener listener)
		{
			throw new System.NotImplementedException();
		}

		public virtual void unregisterListener(android.hardware.SensorEventListener listener
			, android.hardware.Sensor sensor)
		{
			throw new System.NotImplementedException();
		}

		public virtual void unregisterListener(android.hardware.SensorEventListener listener
			)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool registerListener(android.hardware.SensorEventListener listener
			, android.hardware.Sensor sensor, int rate)
		{
			throw new System.NotImplementedException();
		}

		private bool enableSensorLocked(android.hardware.Sensor sensor, int delay)
		{
			throw new System.NotImplementedException();
		}

		private bool disableSensorLocked(android.hardware.Sensor sensor)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool registerListener(android.hardware.SensorEventListener listener
			, android.hardware.Sensor sensor, int rate, android.os.Handler handler)
		{
			throw new System.NotImplementedException();
		}

		private void unregisterListener(object listener, android.hardware.Sensor sensor)
		{
			throw new System.NotImplementedException();
		}

		private void unregisterListener(object listener)
		{
			throw new System.NotImplementedException();
		}

		public static bool getRotationMatrix(float[] R, float[] I, float[] gravity, float
			[] geomagnetic)
		{
			throw new System.NotImplementedException();
		}

		public static float getInclination(float[] I)
		{
			throw new System.NotImplementedException();
		}

		public static bool remapCoordinateSystem(float[] inR, int X, int Y, float[] outR)
		{
			throw new System.NotImplementedException();
		}

		private static bool remapCoordinateSystemImpl(float[] inR, int X, int Y, float[] 
			outR)
		{
			throw new System.NotImplementedException();
		}

		public static float[] getOrientation(float[] R, float[] values)
		{
			throw new System.NotImplementedException();
		}

		public static float getAltitude(float p0, float p)
		{
			throw new System.NotImplementedException();
		}

		public virtual void onRotationChanged(int rotation)
		{
			throw new System.NotImplementedException();
		}

		internal static int getRotation()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal class LegacyListener : android.hardware.SensorEventListener
		{
			private float[] mValues = new float[6];

			private android.hardware.SensorListener mTarget;

			private int mSensors;

			private readonly android.hardware.SensorManager.LmsFilter mYawfilter;

			internal LegacyListener(SensorManager _enclosing, android.hardware.SensorListener
				 target)
			{
				throw new System.NotImplementedException();
			}

			internal virtual void registerSensor(int legacyType)
			{
				throw new System.NotImplementedException();
			}

			internal virtual bool unregisterSensor(int legacyType)
			{
				throw new System.NotImplementedException();
			}

			public virtual void onAccuracyChanged(android.hardware.Sensor sensor, int accuracy
				)
			{
				throw new System.NotImplementedException();
			}

			public virtual void onSensorChanged(android.hardware.SensorEvent @event)
			{
				throw new System.NotImplementedException();
			}

			private void mapSensorDataToWindow(int sensor, float[] values, int orientation)
			{
				throw new System.NotImplementedException();
			}

			private readonly SensorManager _enclosing;
		}

		[Sharpen.Stub]
		internal class LmsFilter
		{
			private const int SENSORS_RATE_MS = 20;

			private const int COUNT = 12;

			private const float PREDICTION_RATIO = 1.0f / 3.0f;

			private const float PREDICTION_TIME = (android.hardware.SensorManager.LmsFilter.SENSORS_RATE_MS
				 * android.hardware.SensorManager.LmsFilter.COUNT / 1000.0f) * android.hardware.SensorManager.LmsFilter
				.PREDICTION_RATIO;

			private float[] mV = new float[android.hardware.SensorManager.LmsFilter.COUNT * 2];

			private float[] mT = new float[android.hardware.SensorManager.LmsFilter.COUNT * 2];

			private int mIndex;

			public LmsFilter(SensorManager _enclosing)
			{
				throw new System.NotImplementedException();
			}

			public virtual float filter(long time, float @in)
			{
				throw new System.NotImplementedException();
			}

			private readonly SensorManager _enclosing;
		}

		public static void getAngleChange(float[] angleChange, float[] R, float[] prevR)
		{
			throw new System.NotImplementedException();
		}

		public static void getRotationMatrixFromVector(float[] R, float[] rotationVector)
		{
			throw new System.NotImplementedException();
		}

		public static void getQuaternionFromVector(float[] Q, float[] rv)
		{
			throw new System.NotImplementedException();
		}

		private static void nativeClassInit()
		{
			throw new System.NotImplementedException();
		}

		private static int sensors_module_init()
		{
			throw new System.NotImplementedException();
		}

		private static int sensors_module_get_next_sensor(android.hardware.Sensor sensor, 
			int next)
		{
			throw new System.NotImplementedException();
		}

		internal static int sensors_create_queue()
		{
			throw new System.NotImplementedException();
		}

		internal static void sensors_destroy_queue(int queue)
		{
			throw new System.NotImplementedException();
		}

		internal static bool sensors_enable_sensor(int queue, string name, int sensor, int
			 enable)
		{
			throw new System.NotImplementedException();
		}

		internal static int sensors_data_poll(int queue, float[] values, int[] status, long
			[] timestamp)
		{
			throw new System.NotImplementedException();
		}
	}
}
