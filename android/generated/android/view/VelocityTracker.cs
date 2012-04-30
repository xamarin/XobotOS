using System.Runtime.InteropServices;
using Sharpen;

namespace android.view
{
	[Sharpen.Sharpened]
	public sealed partial class VelocityTracker : android.util.Poolable<android.view.VelocityTracker
		>, System.IDisposable
	{
		private sealed class _PoolableManager_36 : android.util.PoolableManager<android.view.VelocityTracker
			>
		{
			public _PoolableManager_36()
			{
			}

			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public android.view.VelocityTracker newInstance()
			{
				return new android.view.VelocityTracker();
			}

			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public void onAcquired(android.view.VelocityTracker element)
			{
			}

			[Sharpen.ImplementsInterface(@"android.util.PoolableManager")]
			public void onReleased(android.view.VelocityTracker element)
			{
				element.clear();
			}
		}

		private static readonly android.util.Pool<android.view.VelocityTracker> sPool = android.util.Pools
			.synchronizedPool<android.view.VelocityTracker>(android.util.Pools.finitePool<android.view.VelocityTracker
			>(new _PoolableManager_36(), 2));

		internal const int ACTIVE_POINTER_ID = -1;

		internal android.view.VelocityTracker.NativeVelocityTracker mPtr;

		private android.view.VelocityTracker mNext;

		private bool mIsPooled;

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.view.VelocityTracker.NativeVelocityTracker libxobotos_VelocityTracker_nativeInitialize
			();

		private static android.view.VelocityTracker.NativeVelocityTracker nativeInitialize
			()
		{
			return libxobotos_VelocityTracker_nativeInitialize();
		}

		private static void nativeDispose(android.view.VelocityTracker.NativeVelocityTracker
			 ptr)
		{
			ptr.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_VelocityTracker_clear(android.view.VelocityTracker.NativeVelocityTracker
			 ptr);

		private static void nativeClear(android.view.VelocityTracker.NativeVelocityTracker
			 ptr)
		{
			libxobotos_VelocityTracker_clear(ptr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_VelocityTracker_addMovement(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, android.view.MotionEvent.NativeMotionEvent @event);

		private static void nativeAddMovement(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, android.view.MotionEvent @event)
		{
			libxobotos_VelocityTracker_addMovement(ptr, @event != null ? @event.mNativePtr : 
				android.view.MotionEvent.NativeMotionEvent.Zero);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_VelocityTracker_computeCurrentVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int units, float maxVelocity);

		private static void nativeComputeCurrentVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int units, float maxVelocity)
		{
			libxobotos_VelocityTracker_computeCurrentVelocity(ptr, units, maxVelocity);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_VelocityTracker_getXVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int id);

		private static float nativeGetXVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int id)
		{
			return libxobotos_VelocityTracker_getXVelocity(ptr, id);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_VelocityTracker_getYVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int id);

		private static float nativeGetYVelocity(android.view.VelocityTracker.NativeVelocityTracker
			 ptr, int id)
		{
			return libxobotos_VelocityTracker_getYVelocity(ptr, id);
		}

		[Sharpen.Stub]
		private static bool nativeGetEstimator(int ptr, int id, int degree, int horizonMillis
			, android.view.VelocityTracker.Estimator outEstimator)
		{
			throw new System.NotImplementedException();
		}

		public static android.view.VelocityTracker obtain()
		{
			return sPool.acquire();
		}

		public void recycle()
		{
			sPool.release(this);
		}

		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public void setNextPoolable(android.view.VelocityTracker element)
		{
			mNext = element;
		}

		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public android.view.VelocityTracker getNextPoolable()
		{
			return mNext;
		}

		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public bool isPooled()
		{
			return mIsPooled;
		}

		[Sharpen.ImplementsInterface(@"android.util.Poolable")]
		public void setPooled(bool isPooled_1)
		{
			mIsPooled = isPooled_1;
		}

		private VelocityTracker()
		{
			mPtr = nativeInitialize();
		}

		~VelocityTracker()
		{
			try
			{
				if (mPtr != null)
				{
					nativeDispose(mPtr);
					mPtr = null;
				}
			}
			finally
			{
				;
			}
		}

		public void clear()
		{
			nativeClear(mPtr);
		}

		public void addMovement(android.view.MotionEvent @event)
		{
			if (@event == null)
			{
				throw new System.ArgumentException("event must not be null");
			}
			nativeAddMovement(mPtr, @event);
		}

		public void computeCurrentVelocity(int units)
		{
			nativeComputeCurrentVelocity(mPtr, units, float.MaxValue);
		}

		public void computeCurrentVelocity(int units, float maxVelocity)
		{
			nativeComputeCurrentVelocity(mPtr, units, maxVelocity);
		}

		public float getXVelocity()
		{
			return nativeGetXVelocity(mPtr, ACTIVE_POINTER_ID);
		}

		public float getYVelocity()
		{
			return nativeGetYVelocity(mPtr, ACTIVE_POINTER_ID);
		}

		public float getXVelocity(int id)
		{
			return nativeGetXVelocity(mPtr, id);
		}

		public float getYVelocity(int id)
		{
			return nativeGetYVelocity(mPtr, id);
		}

		[Sharpen.Stub]
		public bool getEstimator(int id, int degree, int horizonMillis, android.view.VelocityTracker
			.Estimator outEstimator)
		{
			throw new System.NotImplementedException();
		}

		public sealed class Estimator
		{
			internal const int MAX_DEGREE = 2;

			public readonly float[] xCoeff = new float[MAX_DEGREE + 1];

			public readonly float[] yCoeff = new float[MAX_DEGREE + 1];

			public int degree;

			public float confidence;

			public float estimateX(float time)
			{
				return estimate(time, xCoeff);
			}

			public float estimateY(float time)
			{
				return estimate(time, yCoeff);
			}

			private float estimate(float time, float[] c)
			{
				float a = 0;
				float scale = 1;
				{
					for (int i = 0; i <= degree; i++)
					{
						a += c[i] * scale;
						scale *= time;
					}
				}
				return a;
			}
		}

		public void Dispose()
		{
			mPtr.Dispose();
		}

		internal class NativeVelocityTracker : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeVelocityTracker() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeVelocityTracker(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_view_VelocityTracker_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeVelocityTracker Zero = new NativeVelocityTracker();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_view_VelocityTracker_destructor(handle);
				}
				handle = System.IntPtr.Zero;
				return true;
			}

			public override bool IsInvalid
			{
				get
				{
					return handle == System.IntPtr.Zero;
				}
			}
		}
	}
}
