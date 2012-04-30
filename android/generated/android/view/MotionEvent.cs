using System.Runtime.InteropServices;
using Sharpen;

namespace android.view
{
	[Sharpen.Sharpened]
	public sealed class MotionEvent : android.view.InputEvent, android.os.Parcelable, 
		System.IDisposable
	{
		internal const long NS_PER_MS = 1000000;

		internal const bool TRACK_RECYCLED_LOCATION = false;

		public const int INVALID_POINTER_ID = -1;

		public const int ACTION_MASK = unchecked((int)(0xff));

		public const int ACTION_DOWN = 0;

		public const int ACTION_UP = 1;

		public const int ACTION_MOVE = 2;

		public const int ACTION_CANCEL = 3;

		public const int ACTION_OUTSIDE = 4;

		public const int ACTION_POINTER_DOWN = 5;

		public const int ACTION_POINTER_UP = 6;

		public const int ACTION_HOVER_MOVE = 7;

		public const int ACTION_SCROLL = 8;

		public const int ACTION_HOVER_ENTER = 9;

		public const int ACTION_HOVER_EXIT = 10;

		public const int ACTION_POINTER_INDEX_MASK = unchecked((int)(0xff00));

		public const int ACTION_POINTER_INDEX_SHIFT = 8;

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_DOWN ."
			)]
		public const int ACTION_POINTER_1_DOWN = ACTION_POINTER_DOWN | unchecked((int)(0x0000
			));

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_DOWN ."
			)]
		public const int ACTION_POINTER_2_DOWN = ACTION_POINTER_DOWN | unchecked((int)(0x0100
			));

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_DOWN ."
			)]
		public const int ACTION_POINTER_3_DOWN = ACTION_POINTER_DOWN | unchecked((int)(0x0200
			));

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_UP ."
			)]
		public const int ACTION_POINTER_1_UP = ACTION_POINTER_UP | unchecked((int)(0x0000
			));

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_UP ."
			)]
		public const int ACTION_POINTER_2_UP = ACTION_POINTER_UP | unchecked((int)(0x0100
			));

		[System.ObsoleteAttribute(@"Use ACTION_POINTER_INDEX_MASK to retrieve the data index associated with ACTION_POINTER_UP ."
			)]
		public const int ACTION_POINTER_3_UP = ACTION_POINTER_UP | unchecked((int)(0x0200
			));

		[System.ObsoleteAttribute(@"Renamed to ACTION_POINTER_INDEX_MASK to match the actual data contained in these bits."
			)]
		public const int ACTION_POINTER_ID_MASK = unchecked((int)(0xff00));

		[System.ObsoleteAttribute(@"Renamed to ACTION_POINTER_INDEX_SHIFT to match the actual data contained in these bits."
			)]
		public const int ACTION_POINTER_ID_SHIFT = 8;

		public const int FLAG_WINDOW_IS_OBSCURED = unchecked((int)(0x1));

		public const int FLAG_TAINTED = unchecked((int)(0x80000000));

		public const int EDGE_TOP = unchecked((int)(0x00000001));

		public const int EDGE_BOTTOM = unchecked((int)(0x00000002));

		public const int EDGE_LEFT = unchecked((int)(0x00000004));

		public const int EDGE_RIGHT = unchecked((int)(0x00000008));

		public const int AXIS_X = 0;

		public const int AXIS_Y = 1;

		public const int AXIS_PRESSURE = 2;

		public const int AXIS_SIZE = 3;

		public const int AXIS_TOUCH_MAJOR = 4;

		public const int AXIS_TOUCH_MINOR = 5;

		public const int AXIS_TOOL_MAJOR = 6;

		public const int AXIS_TOOL_MINOR = 7;

		public const int AXIS_ORIENTATION = 8;

		public const int AXIS_VSCROLL = 9;

		public const int AXIS_HSCROLL = 10;

		public const int AXIS_Z = 11;

		public const int AXIS_RX = 12;

		public const int AXIS_RY = 13;

		public const int AXIS_RZ = 14;

		public const int AXIS_HAT_X = 15;

		public const int AXIS_HAT_Y = 16;

		public const int AXIS_LTRIGGER = 17;

		public const int AXIS_RTRIGGER = 18;

		public const int AXIS_THROTTLE = 19;

		public const int AXIS_RUDDER = 20;

		public const int AXIS_WHEEL = 21;

		public const int AXIS_GAS = 22;

		public const int AXIS_BRAKE = 23;

		public const int AXIS_DISTANCE = 24;

		public const int AXIS_TILT = 25;

		public const int AXIS_GENERIC_1 = 32;

		public const int AXIS_GENERIC_2 = 33;

		public const int AXIS_GENERIC_3 = 34;

		public const int AXIS_GENERIC_4 = 35;

		public const int AXIS_GENERIC_5 = 36;

		public const int AXIS_GENERIC_6 = 37;

		public const int AXIS_GENERIC_7 = 38;

		public const int AXIS_GENERIC_8 = 39;

		public const int AXIS_GENERIC_9 = 40;

		public const int AXIS_GENERIC_10 = 41;

		public const int AXIS_GENERIC_11 = 42;

		public const int AXIS_GENERIC_12 = 43;

		public const int AXIS_GENERIC_13 = 44;

		public const int AXIS_GENERIC_14 = 45;

		public const int AXIS_GENERIC_15 = 46;

		public const int AXIS_GENERIC_16 = 47;

		private static readonly android.util.SparseArray<string> AXIS_SYMBOLIC_NAMES = new 
			android.util.SparseArray<string>();

		static MotionEvent()
		{
			{
				android.util.SparseArray<string> names = AXIS_SYMBOLIC_NAMES;
				names.append(AXIS_X, "AXIS_X");
				names.append(AXIS_Y, "AXIS_Y");
				names.append(AXIS_PRESSURE, "AXIS_PRESSURE");
				names.append(AXIS_SIZE, "AXIS_SIZE");
				names.append(AXIS_TOUCH_MAJOR, "AXIS_TOUCH_MAJOR");
				names.append(AXIS_TOUCH_MINOR, "AXIS_TOUCH_MINOR");
				names.append(AXIS_TOOL_MAJOR, "AXIS_TOOL_MAJOR");
				names.append(AXIS_TOOL_MINOR, "AXIS_TOOL_MINOR");
				names.append(AXIS_ORIENTATION, "AXIS_ORIENTATION");
				names.append(AXIS_VSCROLL, "AXIS_VSCROLL");
				names.append(AXIS_HSCROLL, "AXIS_HSCROLL");
				names.append(AXIS_Z, "AXIS_Z");
				names.append(AXIS_RX, "AXIS_RX");
				names.append(AXIS_RY, "AXIS_RY");
				names.append(AXIS_RZ, "AXIS_RZ");
				names.append(AXIS_HAT_X, "AXIS_HAT_X");
				names.append(AXIS_HAT_Y, "AXIS_HAT_Y");
				names.append(AXIS_LTRIGGER, "AXIS_LTRIGGER");
				names.append(AXIS_RTRIGGER, "AXIS_RTRIGGER");
				names.append(AXIS_THROTTLE, "AXIS_THROTTLE");
				names.append(AXIS_RUDDER, "AXIS_RUDDER");
				names.append(AXIS_WHEEL, "AXIS_WHEEL");
				names.append(AXIS_GAS, "AXIS_GAS");
				names.append(AXIS_BRAKE, "AXIS_BRAKE");
				names.append(AXIS_DISTANCE, "AXIS_DISTANCE");
				names.append(AXIS_TILT, "AXIS_TILT");
				names.append(AXIS_GENERIC_1, "AXIS_GENERIC_1");
				names.append(AXIS_GENERIC_2, "AXIS_GENERIC_2");
				names.append(AXIS_GENERIC_3, "AXIS_GENERIC_3");
				names.append(AXIS_GENERIC_4, "AXIS_GENERIC_4");
				names.append(AXIS_GENERIC_5, "AXIS_GENERIC_5");
				names.append(AXIS_GENERIC_6, "AXIS_GENERIC_6");
				names.append(AXIS_GENERIC_7, "AXIS_GENERIC_7");
				names.append(AXIS_GENERIC_8, "AXIS_GENERIC_8");
				names.append(AXIS_GENERIC_9, "AXIS_GENERIC_9");
				names.append(AXIS_GENERIC_10, "AXIS_GENERIC_10");
				names.append(AXIS_GENERIC_11, "AXIS_GENERIC_11");
				names.append(AXIS_GENERIC_12, "AXIS_GENERIC_12");
				names.append(AXIS_GENERIC_13, "AXIS_GENERIC_13");
				names.append(AXIS_GENERIC_14, "AXIS_GENERIC_14");
				names.append(AXIS_GENERIC_15, "AXIS_GENERIC_15");
				names.append(AXIS_GENERIC_16, "AXIS_GENERIC_16");
			}
			{
				android.util.SparseArray<string> names = TOOL_TYPE_SYMBOLIC_NAMES;
				names.append(TOOL_TYPE_UNKNOWN, "TOOL_TYPE_UNKNOWN");
				names.append(TOOL_TYPE_FINGER, "TOOL_TYPE_FINGER");
				names.append(TOOL_TYPE_STYLUS, "TOOL_TYPE_STYLUS");
				names.append(TOOL_TYPE_MOUSE, "TOOL_TYPE_MOUSE");
				names.append(TOOL_TYPE_ERASER, "TOOL_TYPE_ERASER");
			}
		}

		public const int BUTTON_PRIMARY = 1 << 0;

		public const int BUTTON_SECONDARY = 1 << 1;

		public const int BUTTON_TERTIARY = 1 << 2;

		public const int BUTTON_BACK = 1 << 3;

		public const int BUTTON_FORWARD = 1 << 4;

		private static readonly string[] BUTTON_SYMBOLIC_NAMES = new string[] { "BUTTON_PRIMARY"
			, "BUTTON_SECONDARY", "BUTTON_TERTIARY", "BUTTON_BACK", "BUTTON_FORWARD", "0x00000020"
			, "0x00000040", "0x00000080", "0x00000100", "0x00000200", "0x00000400", "0x00000800"
			, "0x00001000", "0x00002000", "0x00004000", "0x00008000", "0x00010000", "0x00020000"
			, "0x00040000", "0x00080000", "0x00100000", "0x00200000", "0x00400000", "0x00800000"
			, "0x01000000", "0x02000000", "0x04000000", "0x08000000", "0x10000000", "0x20000000"
			, "0x40000000", "0x80000000" };

		public const int TOOL_TYPE_UNKNOWN = 0;

		public const int TOOL_TYPE_FINGER = 1;

		public const int TOOL_TYPE_STYLUS = 2;

		public const int TOOL_TYPE_MOUSE = 3;

		public const int TOOL_TYPE_ERASER = 4;

		private static readonly android.util.SparseArray<string> TOOL_TYPE_SYMBOLIC_NAMES
			 = new android.util.SparseArray<string>();

		internal const int HISTORY_CURRENT = unchecked(-(int)0x80000000);

		internal const int MAX_RECYCLED = 10;

		private static readonly object gRecyclerLock = new object();

		private static int gRecyclerUsed;

		private static android.view.MotionEvent gRecyclerTop;

		private static readonly object gSharedTempLock = new object();

		private static android.view.MotionEvent.PointerCoords[] gSharedTempPointerCoords;

		private static android.view.MotionEvent.PointerProperties[] gSharedTempPointerProperties;

		private static int[] gSharedTempPointerIndexMap;

		private static void ensureSharedTempPointerCapacity(int desiredCapacity)
		{
			if (gSharedTempPointerCoords == null || gSharedTempPointerCoords.Length < desiredCapacity)
			{
				int capacity = gSharedTempPointerCoords != null ? gSharedTempPointerCoords.Length
					 : 8;
				while (capacity < desiredCapacity)
				{
					capacity *= 2;
				}
				gSharedTempPointerCoords = android.view.MotionEvent.PointerCoords.createArray(capacity
					);
				gSharedTempPointerProperties = android.view.MotionEvent.PointerProperties.createArray
					(capacity);
				gSharedTempPointerIndexMap = new int[capacity];
			}
		}

		internal android.view.MotionEvent.NativeMotionEvent mNativePtr;

		private android.view.MotionEvent mNext;

		private java.lang.RuntimeException mRecycledLocation;

		private bool mRecycled;

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.view.MotionEvent.NativeMotionEvent libxobotos_MotionEvent_initialize
			(android.view.MotionEvent.NativeMotionEvent nativePtr, int deviceId, int source, 
			int action, int flags, int edgeFlags, int metaState, int buttonState, float xOffset
			, float yOffset, float xPrecision, float yPrecision, long downTimeNanos, long eventTimeNanos
			, int pointerCount, System.IntPtr pointerIds, System.IntPtr pointerCoords);

		private static android.view.MotionEvent.NativeMotionEvent nativeInitialize(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int deviceId, int source, int action, int flags, int edgeFlags, int 
			metaState, int buttonState, float xOffset, float yOffset, float xPrecision, float
			 yPrecision, long downTimeNanos, long eventTimeNanos, int pointerCount, android.view.MotionEvent.PointerProperties
			[] pointerIds, android.view.MotionEvent.PointerCoords[] pointerCoords)
		{
			System.IntPtr pointerIds_ptr = System.IntPtr.Zero;
			System.IntPtr pointerCoords_ptr = System.IntPtr.Zero;
			try
			{
				pointerIds_ptr = Array_PointerProperties_Helper.ManagedToNative(pointerIds);
				pointerCoords_ptr = Array_PointerCoords_Helper.ManagedToNative(pointerCoords);
				return libxobotos_MotionEvent_initialize(nativePtr != null ? nativePtr : android.view.MotionEvent.NativeMotionEvent
					.Zero, deviceId, source, action, flags, edgeFlags, metaState, buttonState, xOffset
					, yOffset, xPrecision, yPrecision, downTimeNanos, eventTimeNanos, pointerCount, 
					pointerIds_ptr, pointerCoords_ptr);
			}
			finally
			{
				Array_PointerProperties_Helper.FreeManagedPtr(pointerIds_ptr);
				Array_PointerCoords_Helper.FreeManagedPtr(pointerCoords_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.view.MotionEvent.NativeMotionEvent libxobotos_MotionEvent_copy
			(android.view.MotionEvent.NativeMotionEvent destNativePtr, android.view.MotionEvent.NativeMotionEvent
			 sourceNativePtr, bool keepHistory);

		private static android.view.MotionEvent.NativeMotionEvent nativeCopy(android.view.MotionEvent.NativeMotionEvent
			 destNativePtr, android.view.MotionEvent.NativeMotionEvent sourceNativePtr, bool
			 keepHistory)
		{
			return libxobotos_MotionEvent_copy(destNativePtr != null ? destNativePtr : android.view.MotionEvent.NativeMotionEvent
				.Zero, sourceNativePtr, keepHistory);
		}

		private static void nativeDispose(android.view.MotionEvent.NativeMotionEvent nativePtr
			)
		{
			nativePtr.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_addBatch(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, long eventTimeNanos, System.IntPtr pointerCoords, int metaState);

		private static void nativeAddBatch(android.view.MotionEvent.NativeMotionEvent nativePtr
			, long eventTimeNanos, android.view.MotionEvent.PointerCoords[] pointerCoords, int
			 metaState)
		{
			System.IntPtr pointerCoords_ptr = System.IntPtr.Zero;
			try
			{
				pointerCoords_ptr = Array_PointerCoords_Helper.ManagedToNative(pointerCoords);
				libxobotos_MotionEvent_addBatch(nativePtr, eventTimeNanos, pointerCoords_ptr, metaState
					);
			}
			finally
			{
				Array_PointerCoords_Helper.FreeManagedPtr(pointerCoords_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getDeviceId(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetDeviceId(android.view.MotionEvent.NativeMotionEvent nativePtr
			)
		{
			return libxobotos_MotionEvent_getDeviceId(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getSource(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetSource(android.view.MotionEvent.NativeMotionEvent nativePtr
			)
		{
			return libxobotos_MotionEvent_getSource(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_setSource(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int source);

		private static void nativeSetSource(android.view.MotionEvent.NativeMotionEvent nativePtr
			, int source)
		{
			libxobotos_MotionEvent_setSource(nativePtr, source);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getAction(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetAction(android.view.MotionEvent.NativeMotionEvent nativePtr
			)
		{
			return libxobotos_MotionEvent_getAction(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_setAction(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int action);

		private static void nativeSetAction(android.view.MotionEvent.NativeMotionEvent nativePtr
			, int action)
		{
			libxobotos_MotionEvent_setAction(nativePtr, action);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern bool libxobotos_MotionEvent_isTouchEvent(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static bool nativeIsTouchEvent(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_isTouchEvent(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getFlags(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetFlags(android.view.MotionEvent.NativeMotionEvent nativePtr
			)
		{
			return libxobotos_MotionEvent_getFlags(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_setFlags(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int flags);

		private static void nativeSetFlags(android.view.MotionEvent.NativeMotionEvent nativePtr
			, int flags)
		{
			libxobotos_MotionEvent_setFlags(nativePtr, flags);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getEdgeFlags(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetEdgeFlags(android.view.MotionEvent.NativeMotionEvent 
			nativePtr)
		{
			return libxobotos_MotionEvent_getEdgeFlags(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_setEdgeFlags(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int action);

		private static void nativeSetEdgeFlags(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int action)
		{
			libxobotos_MotionEvent_setEdgeFlags(nativePtr, action);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getMetaState(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetMetaState(android.view.MotionEvent.NativeMotionEvent 
			nativePtr)
		{
			return libxobotos_MotionEvent_getMetaState(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getButtonState(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetButtonState(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getButtonState(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_offsetLocation(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, float deltaX, float deltaY);

		private static void nativeOffsetLocation(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, float deltaX, float deltaY)
		{
			libxobotos_MotionEvent_offsetLocation(nativePtr, deltaX, deltaY);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getXOffset(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static float nativeGetXOffset(android.view.MotionEvent.NativeMotionEvent 
			nativePtr)
		{
			return libxobotos_MotionEvent_getXOffset(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getYOffset(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static float nativeGetYOffset(android.view.MotionEvent.NativeMotionEvent 
			nativePtr)
		{
			return libxobotos_MotionEvent_getYOffset(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getXPrecision(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static float nativeGetXPrecision(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getXPrecision(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getYPrecision(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static float nativeGetYPrecision(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getYPrecision(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern long libxobotos_MotionEvent_getDownTime(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static long nativeGetDownTimeNanos(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getDownTime(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_setDownTime(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, long downTime);

		private static void nativeSetDownTimeNanos(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, long downTime)
		{
			libxobotos_MotionEvent_setDownTime(nativePtr, downTime);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getPointerCount(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetPointerCount(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getPointerCount(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getPointerId(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex);

		private static int nativeGetPointerId(android.view.MotionEvent.NativeMotionEvent 
			nativePtr, int pointerIndex)
		{
			return libxobotos_MotionEvent_getPointerId(nativePtr, pointerIndex);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getToolType(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex);

		private static int nativeGetToolType(android.view.MotionEvent.NativeMotionEvent nativePtr
			, int pointerIndex)
		{
			return libxobotos_MotionEvent_getToolType(nativePtr, pointerIndex);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_findPointerIndex(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerId);

		private static int nativeFindPointerIndex(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerId)
		{
			return libxobotos_MotionEvent_findPointerIndex(nativePtr, pointerId);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_MotionEvent_getHistorySize(android.view.MotionEvent.NativeMotionEvent
			 nativePtr);

		private static int nativeGetHistorySize(android.view.MotionEvent.NativeMotionEvent
			 nativePtr)
		{
			return libxobotos_MotionEvent_getHistorySize(nativePtr);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern long libxobotos_MotionEvent_getEventTimeNanos(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int historyPos);

		private static long nativeGetEventTimeNanos(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int historyPos)
		{
			return libxobotos_MotionEvent_getEventTimeNanos(nativePtr, historyPos);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getRawAxisValue(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int axis, int pointerIndex, int historyPos);

		private static float nativeGetRawAxisValue(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int axis, int pointerIndex, int historyPos)
		{
			return libxobotos_MotionEvent_getRawAxisValue(nativePtr, axis, pointerIndex, historyPos
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern float libxobotos_MotionEvent_getAxisValue(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int axis, int pointerIndex, int historyPos);

		private static float nativeGetAxisValue(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int axis, int pointerIndex, int historyPos)
		{
			return libxobotos_MotionEvent_getAxisValue(nativePtr, axis, pointerIndex, historyPos
				);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_getPointerCoords(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex, int historyPos, out System.IntPtr outPointerCoords
			);

		private static void nativeGetPointerCoords(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex, int historyPos, android.view.MotionEvent.PointerCoords
			 outPointerCoords)
		{
			System.IntPtr outPointerCoords_ptr = System.IntPtr.Zero;
			try
			{
				libxobotos_MotionEvent_getPointerCoords(nativePtr, pointerIndex, historyPos, out 
					outPointerCoords_ptr);
				android.view.MotionEvent.PointerCoords.PointerCoords_Helper.MarshalOut(outPointerCoords_ptr
					, outPointerCoords);
			}
			finally
			{
				android.view.MotionEvent.PointerCoords.PointerCoords_Helper.FreeNativePtr(outPointerCoords_ptr
					);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_getPointerProperties(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex, out System.IntPtr outPointerProperties);

		private static void nativeGetPointerProperties(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, int pointerIndex, android.view.MotionEvent.PointerProperties outPointerProperties
			)
		{
			System.IntPtr outPointerProperties_ptr = System.IntPtr.Zero;
			try
			{
				libxobotos_MotionEvent_getPointerProperties(nativePtr, pointerIndex, out outPointerProperties_ptr
					);
				android.view.MotionEvent.PointerProperties.PointerProperties_Helper.MarshalOut(outPointerProperties_ptr
					, outPointerProperties);
			}
			finally
			{
				android.view.MotionEvent.PointerProperties.PointerProperties_Helper.FreeNativePtr
					(outPointerProperties_ptr);
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_MotionEvent_scale(android.view.MotionEvent.NativeMotionEvent
			 nativePtr, float scale_1);

		private static void nativeScale(android.view.MotionEvent.NativeMotionEvent nativePtr
			, float scale_1)
		{
			libxobotos_MotionEvent_scale(nativePtr, scale_1);
		}

		private MotionEvent()
		{
		}

		~MotionEvent()
		{
			try
			{
				if (mNativePtr != null)
				{
					nativeDispose(mNativePtr);
					mNativePtr = null;
				}
			}
			finally
			{
				;
			}
		}

		private static android.view.MotionEvent obtain()
		{
			android.view.MotionEvent ev;
			lock (gRecyclerLock)
			{
				ev = gRecyclerTop;
				if (ev == null)
				{
					return new android.view.MotionEvent();
				}
				gRecyclerTop = ev.mNext;
				gRecyclerUsed -= 1;
			}
			ev.mRecycledLocation = null;
			ev.mRecycled = false;
			ev.mNext = null;
			return ev;
		}

		public static android.view.MotionEvent obtain(long downTime, long eventTime, int 
			action, int pointerCount, android.view.MotionEvent.PointerProperties[] pointerProperties
			, android.view.MotionEvent.PointerCoords[] pointerCoords, int metaState, int buttonState
			, float xPrecision, float yPrecision, int deviceId, int edgeFlags, int source, int
			 flags)
		{
			android.view.MotionEvent ev = obtain();
			ev.mNativePtr = nativeInitialize(ev.mNativePtr, deviceId, source, action, flags, 
				edgeFlags, metaState, buttonState, 0, 0, xPrecision, yPrecision, downTime * NS_PER_MS
				, eventTime * NS_PER_MS, pointerCount, pointerProperties, pointerCoords);
			return ev;
		}

		[System.ObsoleteAttribute(@"Use obtain(long, long, int, int, PointerProperties[], PointerCoords[], int, int, float, float, int, int, int, int) instead."
			)]
		public static android.view.MotionEvent obtain(long downTime, long eventTime, int 
			action, int pointerCount, int[] pointerIds, android.view.MotionEvent.PointerCoords
			[] pointerCoords, int metaState, float xPrecision, float yPrecision, int deviceId
			, int edgeFlags, int source, int flags)
		{
			lock (gSharedTempLock)
			{
				ensureSharedTempPointerCapacity(pointerCount);
				android.view.MotionEvent.PointerProperties[] pp = gSharedTempPointerProperties;
				{
					for (int i = 0; i < pointerCount; i++)
					{
						pp[i].clear();
						pp[i].id = pointerIds[i];
					}
				}
				return obtain(downTime, eventTime, action, pointerCount, pp, pointerCoords, metaState
					, 0, xPrecision, yPrecision, deviceId, edgeFlags, source, flags);
			}
		}

		public static android.view.MotionEvent obtain(long downTime, long eventTime, int 
			action, float x, float y, float pressure, float size, int metaState, float xPrecision
			, float yPrecision, int deviceId, int edgeFlags)
		{
			android.view.MotionEvent ev = obtain();
			lock (gSharedTempLock)
			{
				ensureSharedTempPointerCapacity(1);
				android.view.MotionEvent.PointerProperties[] pp = gSharedTempPointerProperties;
				pp[0].clear();
				pp[0].id = 0;
				android.view.MotionEvent.PointerCoords[] pc = gSharedTempPointerCoords;
				pc[0].clear();
				pc[0].x = x;
				pc[0].y = y;
				pc[0].pressure = pressure;
				pc[0].size = size;
				ev.mNativePtr = nativeInitialize(ev.mNativePtr, deviceId, android.view.InputDevice
					.SOURCE_UNKNOWN, action, 0, edgeFlags, metaState, 0, 0, 0, xPrecision, yPrecision
					, downTime * NS_PER_MS, eventTime * NS_PER_MS, 1, pp, pc);
				return ev;
			}
		}

		[System.ObsoleteAttribute(@"Use obtain(long, long, int, float, float, float, float, int, float, float, int, int) instead."
			)]
		public static android.view.MotionEvent obtain(long downTime, long eventTime, int 
			action, int pointerCount, float x, float y, float pressure, float size, int metaState
			, float xPrecision, float yPrecision, int deviceId, int edgeFlags)
		{
			return obtain(downTime, eventTime, action, x, y, pressure, size, metaState, xPrecision
				, yPrecision, deviceId, edgeFlags);
		}

		public static android.view.MotionEvent obtain(long downTime, long eventTime, int 
			action, float x, float y, int metaState)
		{
			return obtain(downTime, eventTime, action, x, y, 1.0f, 1.0f, metaState, 1.0f, 1.0f
				, 0, 0);
		}

		public static android.view.MotionEvent obtain(android.view.MotionEvent other)
		{
			if (other == null)
			{
				throw new System.ArgumentException("other motion event must not be null");
			}
			android.view.MotionEvent ev = obtain();
			ev.mNativePtr = nativeCopy(ev.mNativePtr, other.mNativePtr, true);
			return ev;
		}

		public static android.view.MotionEvent obtainNoHistory(android.view.MotionEvent other
			)
		{
			if (other == null)
			{
				throw new System.ArgumentException("other motion event must not be null");
			}
			android.view.MotionEvent ev = obtain();
			ev.mNativePtr = nativeCopy(ev.mNativePtr, other.mNativePtr, false);
			return ev;
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public override android.view.InputEvent copy()
		{
			return obtain(this);
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void recycle()
		{
			if (mRecycled)
			{
				throw new java.lang.RuntimeException(ToString() + " recycled twice!");
			}
			mRecycled = true;
			lock (gRecyclerLock)
			{
				if (gRecyclerUsed < MAX_RECYCLED)
				{
					gRecyclerUsed++;
					mNext = gRecyclerTop;
					gRecyclerTop = this;
				}
			}
		}

		public void scale(float scale_1)
		{
			nativeScale(mNativePtr, scale_1);
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override int getDeviceId()
		{
			return nativeGetDeviceId(mNativePtr);
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override int getSource()
		{
			return nativeGetSource(mNativePtr);
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void setSource(int source)
		{
			nativeSetSource(mNativePtr, source);
		}

		public int getAction()
		{
			return nativeGetAction(mNativePtr);
		}

		public int getActionMasked()
		{
			return nativeGetAction(mNativePtr) & ACTION_MASK;
		}

		public int getActionIndex()
		{
			return (nativeGetAction(mNativePtr) & ACTION_POINTER_INDEX_MASK) >> ACTION_POINTER_INDEX_SHIFT;
		}

		public bool isTouchEvent()
		{
			return nativeIsTouchEvent(mNativePtr);
		}

		public int getFlags()
		{
			return nativeGetFlags(mNativePtr);
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override bool isTainted()
		{
			int flags = getFlags();
			return (flags & FLAG_TAINTED) != 0;
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override void setTainted(bool tainted)
		{
			int flags = getFlags();
			nativeSetFlags(mNativePtr, tainted ? flags | FLAG_TAINTED : flags & ~FLAG_TAINTED
				);
		}

		public long getDownTime()
		{
			return nativeGetDownTimeNanos(mNativePtr) / NS_PER_MS;
		}

		public void setDownTime(long downTime)
		{
			nativeSetDownTimeNanos(mNativePtr, downTime * NS_PER_MS);
		}

		public long getEventTime()
		{
			return nativeGetEventTimeNanos(mNativePtr, HISTORY_CURRENT) / NS_PER_MS;
		}

		[Sharpen.OverridesMethod(@"android.view.InputEvent")]
		public sealed override long getEventTimeNano()
		{
			return nativeGetEventTimeNanos(mNativePtr, HISTORY_CURRENT);
		}

		public float getX()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_X, 0, HISTORY_CURRENT);
		}

		public float getY()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_Y, 0, HISTORY_CURRENT);
		}

		public float getPressure()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_PRESSURE, 0, HISTORY_CURRENT);
		}

		public float getSize()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_SIZE, 0, HISTORY_CURRENT);
		}

		public float getTouchMajor()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MAJOR, 0, HISTORY_CURRENT);
		}

		public float getTouchMinor()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MINOR, 0, HISTORY_CURRENT);
		}

		public float getToolMajor()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MAJOR, 0, HISTORY_CURRENT);
		}

		public float getToolMinor()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MINOR, 0, HISTORY_CURRENT);
		}

		public float getOrientation()
		{
			return nativeGetAxisValue(mNativePtr, AXIS_ORIENTATION, 0, HISTORY_CURRENT);
		}

		public float getAxisValue(int axis)
		{
			return nativeGetAxisValue(mNativePtr, axis, 0, HISTORY_CURRENT);
		}

		public int getPointerCount()
		{
			return nativeGetPointerCount(mNativePtr);
		}

		public int getPointerId(int pointerIndex)
		{
			return nativeGetPointerId(mNativePtr, pointerIndex);
		}

		public int getToolType(int pointerIndex)
		{
			return nativeGetToolType(mNativePtr, pointerIndex);
		}

		public int findPointerIndex(int pointerId)
		{
			return nativeFindPointerIndex(mNativePtr, pointerId);
		}

		public float getX(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_X, pointerIndex, HISTORY_CURRENT);
		}

		public float getY(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_Y, pointerIndex, HISTORY_CURRENT);
		}

		public float getPressure(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_PRESSURE, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getSize(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_SIZE, pointerIndex, HISTORY_CURRENT);
		}

		public float getTouchMajor(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MAJOR, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getTouchMinor(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MINOR, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getToolMajor(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MAJOR, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getToolMinor(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MINOR, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getOrientation(int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_ORIENTATION, pointerIndex, HISTORY_CURRENT
				);
		}

		public float getAxisValue(int axis, int pointerIndex)
		{
			return nativeGetAxisValue(mNativePtr, axis, pointerIndex, HISTORY_CURRENT);
		}

		public void getPointerCoords(int pointerIndex, android.view.MotionEvent.PointerCoords
			 outPointerCoords)
		{
			nativeGetPointerCoords(mNativePtr, pointerIndex, HISTORY_CURRENT, outPointerCoords
				);
		}

		public void getPointerProperties(int pointerIndex, android.view.MotionEvent.PointerProperties
			 outPointerProperties)
		{
			nativeGetPointerProperties(mNativePtr, pointerIndex, outPointerProperties);
		}

		public int getMetaState()
		{
			return nativeGetMetaState(mNativePtr);
		}

		public int getButtonState()
		{
			return nativeGetButtonState(mNativePtr);
		}

		public float getRawX()
		{
			return nativeGetRawAxisValue(mNativePtr, AXIS_X, 0, HISTORY_CURRENT);
		}

		public float getRawY()
		{
			return nativeGetRawAxisValue(mNativePtr, AXIS_Y, 0, HISTORY_CURRENT);
		}

		public float getXPrecision()
		{
			return nativeGetXPrecision(mNativePtr);
		}

		public float getYPrecision()
		{
			return nativeGetYPrecision(mNativePtr);
		}

		public int getHistorySize()
		{
			return nativeGetHistorySize(mNativePtr);
		}

		public long getHistoricalEventTime(int pos)
		{
			return nativeGetEventTimeNanos(mNativePtr, pos) / NS_PER_MS;
		}

		public float getHistoricalX(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_X, 0, pos);
		}

		public float getHistoricalY(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_Y, 0, pos);
		}

		public float getHistoricalPressure(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_PRESSURE, 0, pos);
		}

		public float getHistoricalSize(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_SIZE, 0, pos);
		}

		public float getHistoricalTouchMajor(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MAJOR, 0, pos);
		}

		public float getHistoricalTouchMinor(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MINOR, 0, pos);
		}

		public float getHistoricalToolMajor(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MAJOR, 0, pos);
		}

		public float getHistoricalToolMinor(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MINOR, 0, pos);
		}

		public float getHistoricalOrientation(int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_ORIENTATION, 0, pos);
		}

		public float getHistoricalAxisValue(int axis, int pos)
		{
			return nativeGetAxisValue(mNativePtr, axis, 0, pos);
		}

		public float getHistoricalX(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_X, pointerIndex, pos);
		}

		public float getHistoricalY(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_Y, pointerIndex, pos);
		}

		public float getHistoricalPressure(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_PRESSURE, pointerIndex, pos);
		}

		public float getHistoricalSize(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_SIZE, pointerIndex, pos);
		}

		public float getHistoricalTouchMajor(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MAJOR, pointerIndex, pos);
		}

		public float getHistoricalTouchMinor(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOUCH_MINOR, pointerIndex, pos);
		}

		public float getHistoricalToolMajor(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MAJOR, pointerIndex, pos);
		}

		public float getHistoricalToolMinor(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_TOOL_MINOR, pointerIndex, pos);
		}

		public float getHistoricalOrientation(int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, AXIS_ORIENTATION, pointerIndex, pos);
		}

		public float getHistoricalAxisValue(int axis, int pointerIndex, int pos)
		{
			return nativeGetAxisValue(mNativePtr, axis, pointerIndex, pos);
		}

		public void getHistoricalPointerCoords(int pointerIndex, int pos, android.view.MotionEvent
			.PointerCoords outPointerCoords)
		{
			nativeGetPointerCoords(mNativePtr, pointerIndex, pos, outPointerCoords);
		}

		public int getEdgeFlags()
		{
			return nativeGetEdgeFlags(mNativePtr);
		}

		public void setEdgeFlags(int flags)
		{
			nativeSetEdgeFlags(mNativePtr, flags);
		}

		public void setAction(int action)
		{
			nativeSetAction(mNativePtr, action);
		}

		public void offsetLocation(float deltaX, float deltaY)
		{
			nativeOffsetLocation(mNativePtr, deltaX, deltaY);
		}

		public void setLocation(float x, float y)
		{
			float oldX = getX();
			float oldY = getY();
			nativeOffsetLocation(mNativePtr, x - oldX, y - oldY);
		}

		[Sharpen.Stub]
		public void transform(android.graphics.Matrix matrix)
		{
			throw new System.NotImplementedException();
		}

		public void addBatch(long eventTime, float x, float y, float pressure, float size
			, int metaState)
		{
			lock (gSharedTempLock)
			{
				ensureSharedTempPointerCapacity(1);
				android.view.MotionEvent.PointerCoords[] pc = gSharedTempPointerCoords;
				pc[0].clear();
				pc[0].x = x;
				pc[0].y = y;
				pc[0].pressure = pressure;
				pc[0].size = size;
				nativeAddBatch(mNativePtr, eventTime * NS_PER_MS, pc, metaState);
			}
		}

		public void addBatch(long eventTime, android.view.MotionEvent.PointerCoords[] pointerCoords
			, int metaState)
		{
			nativeAddBatch(mNativePtr, eventTime * NS_PER_MS, pointerCoords, metaState);
		}

		public bool isWithinBoundsNoHistory(float left, float top, float right, float bottom
			)
		{
			int pointerCount = nativeGetPointerCount(mNativePtr);
			{
				for (int i = 0; i < pointerCount; i++)
				{
					float x = nativeGetAxisValue(mNativePtr, AXIS_X, i, HISTORY_CURRENT);
					float y = nativeGetAxisValue(mNativePtr, AXIS_Y, i, HISTORY_CURRENT);
					if (x < left || x > right || y < top || y > bottom)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static float clamp(float value, float low, float high)
		{
			if (value < low)
			{
				return low;
			}
			else
			{
				if (value > high)
				{
					return high;
				}
			}
			return value;
		}

		public android.view.MotionEvent clampNoHistory(float left, float top, float right
			, float bottom)
		{
			android.view.MotionEvent ev = obtain();
			lock (gSharedTempLock)
			{
				int pointerCount = nativeGetPointerCount(mNativePtr);
				ensureSharedTempPointerCapacity(pointerCount);
				android.view.MotionEvent.PointerProperties[] pp = gSharedTempPointerProperties;
				android.view.MotionEvent.PointerCoords[] pc = gSharedTempPointerCoords;
				{
					for (int i = 0; i < pointerCount; i++)
					{
						nativeGetPointerProperties(mNativePtr, i, pp[i]);
						nativeGetPointerCoords(mNativePtr, i, HISTORY_CURRENT, pc[i]);
						pc[i].x = clamp(pc[i].x, left, right);
						pc[i].y = clamp(pc[i].y, top, bottom);
					}
				}
				ev.mNativePtr = nativeInitialize(ev.mNativePtr, nativeGetDeviceId(mNativePtr), nativeGetSource
					(mNativePtr), nativeGetAction(mNativePtr), nativeGetFlags(mNativePtr), nativeGetEdgeFlags
					(mNativePtr), nativeGetMetaState(mNativePtr), nativeGetButtonState(mNativePtr), 
					nativeGetXOffset(mNativePtr), nativeGetYOffset(mNativePtr), nativeGetXPrecision(
					mNativePtr), nativeGetYPrecision(mNativePtr), nativeGetDownTimeNanos(mNativePtr)
					, nativeGetEventTimeNanos(mNativePtr, HISTORY_CURRENT), pointerCount, pp, pc);
				return ev;
			}
		}

		public int getPointerIdBits()
		{
			int idBits = 0;
			int pointerCount = nativeGetPointerCount(mNativePtr);
			{
				for (int i = 0; i < pointerCount; i++)
				{
					idBits |= 1 << nativeGetPointerId(mNativePtr, i);
				}
			}
			return idBits;
		}

		public android.view.MotionEvent split(int idBits)
		{
			android.view.MotionEvent ev = obtain();
			lock (gSharedTempLock)
			{
				int oldPointerCount = nativeGetPointerCount(mNativePtr);
				ensureSharedTempPointerCapacity(oldPointerCount);
				android.view.MotionEvent.PointerProperties[] pp = gSharedTempPointerProperties;
				android.view.MotionEvent.PointerCoords[] pc = gSharedTempPointerCoords;
				int[] map = gSharedTempPointerIndexMap;
				int oldAction = nativeGetAction(mNativePtr);
				int oldActionMasked = oldAction & ACTION_MASK;
				int oldActionPointerIndex = (oldAction & ACTION_POINTER_INDEX_MASK) >> ACTION_POINTER_INDEX_SHIFT;
				int newActionPointerIndex = -1;
				int newPointerCount = 0;
				int newIdBits = 0;
				{
					for (int i = 0; i < oldPointerCount; i++)
					{
						nativeGetPointerProperties(mNativePtr, i, pp[newPointerCount]);
						int idBit = 1 << pp[newPointerCount].id;
						if ((idBit & idBits) != 0)
						{
							if (i == oldActionPointerIndex)
							{
								newActionPointerIndex = newPointerCount;
							}
							map[newPointerCount] = i;
							newPointerCount += 1;
							newIdBits |= idBit;
						}
					}
				}
				if (newPointerCount == 0)
				{
					throw new System.ArgumentException("idBits did not match any ids in the event");
				}
				int newAction;
				if (oldActionMasked == ACTION_POINTER_DOWN || oldActionMasked == ACTION_POINTER_UP)
				{
					if (newActionPointerIndex < 0)
					{
						newAction = ACTION_MOVE;
					}
					else
					{
						if (newPointerCount == 1)
						{
							newAction = oldActionMasked == ACTION_POINTER_DOWN ? ACTION_DOWN : ACTION_UP;
						}
						else
						{
							newAction = oldActionMasked | (newActionPointerIndex << ACTION_POINTER_INDEX_SHIFT
								);
						}
					}
				}
				else
				{
					newAction = oldAction;
				}
				int historySize = nativeGetHistorySize(mNativePtr);
				{
					for (int h = 0; h <= historySize; h++)
					{
						int historyPos = h == historySize ? HISTORY_CURRENT : h;
						{
							for (int i_1 = 0; i_1 < newPointerCount; i_1++)
							{
								nativeGetPointerCoords(mNativePtr, map[i_1], historyPos, pc[i_1]);
							}
						}
						long eventTimeNanos = nativeGetEventTimeNanos(mNativePtr, historyPos);
						if (h == 0)
						{
							ev.mNativePtr = nativeInitialize(ev.mNativePtr, nativeGetDeviceId(mNativePtr), nativeGetSource
								(mNativePtr), newAction, nativeGetFlags(mNativePtr), nativeGetEdgeFlags(mNativePtr
								), nativeGetMetaState(mNativePtr), nativeGetButtonState(mNativePtr), nativeGetXOffset
								(mNativePtr), nativeGetYOffset(mNativePtr), nativeGetXPrecision(mNativePtr), nativeGetYPrecision
								(mNativePtr), nativeGetDownTimeNanos(mNativePtr), eventTimeNanos, newPointerCount
								, pp, pc);
						}
						else
						{
							nativeAddBatch(ev.mNativePtr, eventTimeNanos, pc, 0);
						}
					}
				}
				return ev;
			}
		}

		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			java.lang.StringBuilder msg = new java.lang.StringBuilder();
			msg.append("MotionEvent { action=").append(actionToString(getAction()));
			int pointerCount = getPointerCount();
			{
				for (int i = 0; i < pointerCount; i++)
				{
					msg.append(", id[").append(i).append("]=").append(getPointerId(i));
					msg.append(", x[").append(i).append("]=").append(getX(i));
					msg.append(", y[").append(i).append("]=").append(getY(i));
					msg.append(", toolType[").append(i).append("]=").append(toolTypeToString(getToolType
						(i)));
				}
			}
			msg.append(", buttonState=").append(android.view.MotionEvent.buttonStateToString(
				getButtonState()));
			msg.append(", metaState=").append(android.view.KeyEvent.metaStateToString(getMetaState
				()));
			msg.append(", flags=0x").append(Sharpen.Util.IntToHexString(getFlags()));
			msg.append(", edgeFlags=0x").append(Sharpen.Util.IntToHexString(getEdgeFlags()));
			msg.append(", pointerCount=").append(pointerCount);
			msg.append(", historySize=").append(getHistorySize());
			msg.append(", eventTime=").append(getEventTime());
			msg.append(", downTime=").append(getDownTime());
			msg.append(", deviceId=").append(getDeviceId());
			msg.append(", source=0x").append(Sharpen.Util.IntToHexString(getSource()));
			msg.append(" }");
			return msg.ToString();
		}

		public static string actionToString(int action)
		{
			switch (action)
			{
				case ACTION_DOWN:
				{
					return "ACTION_DOWN";
				}

				case ACTION_UP:
				{
					return "ACTION_UP";
				}

				case ACTION_CANCEL:
				{
					return "ACTION_CANCEL";
				}

				case ACTION_OUTSIDE:
				{
					return "ACTION_OUTSIDE";
				}

				case ACTION_MOVE:
				{
					return "ACTION_MOVE";
				}

				case ACTION_HOVER_MOVE:
				{
					return "ACTION_HOVER_MOVE";
				}

				case ACTION_SCROLL:
				{
					return "ACTION_SCROLL";
				}

				case ACTION_HOVER_ENTER:
				{
					return "ACTION_HOVER_ENTER";
				}

				case ACTION_HOVER_EXIT:
				{
					return "ACTION_HOVER_EXIT";
				}
			}
			int index = (action & ACTION_POINTER_INDEX_MASK) >> ACTION_POINTER_INDEX_SHIFT;
			switch (action & ACTION_MASK)
			{
				case ACTION_POINTER_DOWN:
				{
					return "ACTION_POINTER_DOWN(" + index + ")";
				}

				case ACTION_POINTER_UP:
				{
					return "ACTION_POINTER_UP(" + index + ")";
				}

				default:
				{
					return System.Convert.ToString(action);
				}
			}
		}

		public static string axisToString(int axis)
		{
			string symbolicName = AXIS_SYMBOLIC_NAMES.get(axis);
			return symbolicName != null ? symbolicName : System.Convert.ToString(axis);
		}

		public static int axisFromString(string symbolicName)
		{
			if (symbolicName == null)
			{
				throw new System.ArgumentException("symbolicName must not be null");
			}
			int count = AXIS_SYMBOLIC_NAMES.size();
			{
				for (int i = 0; i < count; i++)
				{
					if (symbolicName.Equals(AXIS_SYMBOLIC_NAMES.valueAt(i)))
					{
						return i;
					}
				}
			}
			try
			{
				return System.Convert.ToInt32(symbolicName, 10);
			}
			catch (System.ArgumentException)
			{
				return -1;
			}
		}

		public static string buttonStateToString(int buttonState)
		{
			if (buttonState == 0)
			{
				return "0";
			}
			java.lang.StringBuilder result = null;
			int i = 0;
			while (buttonState != 0)
			{
				bool isSet = (buttonState & 1) != 0;
				(buttonState) = (int)((uint)(buttonState) >> 1);
				if (isSet)
				{
					string name = BUTTON_SYMBOLIC_NAMES[i];
					if (result == null)
					{
						if (buttonState == 0)
						{
							return name;
						}
						result = new java.lang.StringBuilder(name);
					}
					else
					{
						result.append('|');
						result.append(name);
					}
				}
				i += 1;
			}
			return result.ToString();
		}

		public static string toolTypeToString(int toolType)
		{
			string symbolicName = TOOL_TYPE_SYMBOLIC_NAMES.get(toolType);
			return symbolicName != null ? symbolicName : System.Convert.ToString(toolType);
		}

		private sealed class _Creator_3035 : android.os.ParcelableClass.Creator<android.view.MotionEvent
			>
		{
			public _Creator_3035()
			{
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.MotionEvent createFromParcel(android.os.Parcel @in)
			{
				@in.readInt();
				return android.view.MotionEvent.createFromParcelBody(@in);
			}

			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.MotionEvent[] newArray(int size)
			{
				return new android.view.MotionEvent[size];
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.MotionEvent
			> CREATOR = new _Creator_3035();

		[Sharpen.Stub]
		public static android.view.MotionEvent createFromParcelBody(android.os.Parcel @in
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public override void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		public sealed class PointerCoords
		{
			internal const int INITIAL_PACKED_AXIS_VALUES = 8;

			internal long mPackedAxisBits;

			internal float[] mPackedAxisValues;

			public PointerCoords()
			{
			}

			public PointerCoords(android.view.MotionEvent.PointerCoords other)
			{
				copyFrom(other);
			}

			public static android.view.MotionEvent.PointerCoords[] createArray(int size)
			{
				android.view.MotionEvent.PointerCoords[] array = new android.view.MotionEvent.PointerCoords
					[size];
				{
					for (int i = 0; i < size; i++)
					{
						array[i] = new android.view.MotionEvent.PointerCoords();
					}
				}
				return array;
			}

			public float x;

			public float y;

			public float pressure;

			public float size;

			public float touchMajor;

			public float touchMinor;

			public float toolMajor;

			public float toolMinor;

			public float orientation;

			public void clear()
			{
				mPackedAxisBits = 0;
				x = 0;
				y = 0;
				pressure = 0;
				size = 0;
				touchMajor = 0;
				touchMinor = 0;
				toolMajor = 0;
				toolMinor = 0;
				orientation = 0;
			}

			public void copyFrom(android.view.MotionEvent.PointerCoords other)
			{
				long bits = other.mPackedAxisBits;
				mPackedAxisBits = bits;
				if (bits != 0)
				{
					float[] otherValues = other.mPackedAxisValues;
					int count = Sharpen.Util.Long_GetBitCount(bits);
					float[] values = mPackedAxisValues;
					if (values == null || count > values.Length)
					{
						values = new float[otherValues.Length];
						mPackedAxisValues = values;
					}
					System.Array.Copy(otherValues, 0, values, 0, count);
				}
				x = other.x;
				y = other.y;
				pressure = other.pressure;
				size = other.size;
				touchMajor = other.touchMajor;
				touchMinor = other.touchMinor;
				toolMajor = other.toolMajor;
				toolMinor = other.toolMinor;
				orientation = other.orientation;
			}

			public float getAxisValue(int axis)
			{
				switch (axis)
				{
					case AXIS_X:
					{
						return x;
					}

					case AXIS_Y:
					{
						return y;
					}

					case AXIS_PRESSURE:
					{
						return pressure;
					}

					case AXIS_SIZE:
					{
						return size;
					}

					case AXIS_TOUCH_MAJOR:
					{
						return touchMajor;
					}

					case AXIS_TOUCH_MINOR:
					{
						return touchMinor;
					}

					case AXIS_TOOL_MAJOR:
					{
						return toolMajor;
					}

					case AXIS_TOOL_MINOR:
					{
						return toolMinor;
					}

					case AXIS_ORIENTATION:
					{
						return orientation;
					}

					default:
					{
						if (axis < 0 || axis > 63)
						{
							throw new System.ArgumentException("Axis out of range.");
						}
						long bits = mPackedAxisBits;
						long axisBit = 1L << axis;
						if ((bits & axisBit) == 0)
						{
							return 0;
						}
						int index = Sharpen.Util.Long_GetBitCount(bits & (axisBit - 1L));
						return mPackedAxisValues[index];
					}
				}
			}

			public void setAxisValue(int axis, float value)
			{
				switch (axis)
				{
					case AXIS_X:
					{
						x = value;
						break;
					}

					case AXIS_Y:
					{
						y = value;
						break;
					}

					case AXIS_PRESSURE:
					{
						pressure = value;
						break;
					}

					case AXIS_SIZE:
					{
						size = value;
						break;
					}

					case AXIS_TOUCH_MAJOR:
					{
						touchMajor = value;
						break;
					}

					case AXIS_TOUCH_MINOR:
					{
						touchMinor = value;
						break;
					}

					case AXIS_TOOL_MAJOR:
					{
						toolMajor = value;
						break;
					}

					case AXIS_TOOL_MINOR:
					{
						toolMinor = value;
						break;
					}

					case AXIS_ORIENTATION:
					{
						orientation = value;
						break;
					}

					default:
					{
						if (axis < 0 || axis > 63)
						{
							throw new System.ArgumentException("Axis out of range.");
						}
						long bits = mPackedAxisBits;
						long axisBit = 1L << axis;
						int index = Sharpen.Util.Long_GetBitCount(bits & (axisBit - 1L));
						float[] values = mPackedAxisValues;
						if ((bits & axisBit) == 0)
						{
							if (values == null)
							{
								values = new float[INITIAL_PACKED_AXIS_VALUES];
								mPackedAxisValues = values;
							}
							else
							{
								int count = Sharpen.Util.Long_GetBitCount(bits);
								if (count < values.Length)
								{
									if (index != count)
									{
										System.Array.Copy(values, index, values, index + 1, count - index);
									}
								}
								else
								{
									float[] newValues = new float[count * 2];
									System.Array.Copy(values, 0, newValues, 0, index);
									System.Array.Copy(values, index, newValues, index + 1, count - index);
									values = newValues;
									mPackedAxisValues = values;
								}
							}
							mPackedAxisBits = bits | axisBit;
						}
						values[index] = value;
						break;
					}
				}
			}

			[Sharpen.MarshalHelper(@"MotionEventGlue::Coords")]
			internal static class PointerCoords_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct PointerCoords_Struct
				{
					public uint _owner;

					public long mPackedAxisBits;

					public System.IntPtr mPackedAxisValues;

					public float x;

					public float y;

					public float pressure;

					public float size;

					public float touchMajor;

					public float touchMinor;

					public float toolMajor;

					public float toolMinor;

					public float orientation;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(PointerCoords_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, android.view.MotionEvent.PointerCoords
					 arg)
				{
					PointerCoords_Struct obj = new PointerCoords_Struct();
					obj._owner = 0x972f3813;
					obj.mPackedAxisBits = arg.mPackedAxisBits;
					obj.mPackedAxisValues = XobotOS.Runtime.MarshalGlue.Array_float_Helper.ManagedToNative
						(arg.mPackedAxisValues);
					obj.x = arg.x;
					obj.y = arg.y;
					obj.pressure = arg.pressure;
					obj.size = arg.size;
					obj.touchMajor = arg.touchMajor;
					obj.touchMinor = arg.touchMinor;
					obj.toolMajor = arg.toolMajor;
					obj.toolMinor = arg.toolMinor;
					obj.orientation = arg.orientation;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, android.view.MotionEvent.PointerCoords
					 arg)
				{
					PointerCoords_Struct obj = (PointerCoords_Struct)Marshal.PtrToStructure(ptr, typeof(
						PointerCoords_Struct));
					arg.mPackedAxisBits = obj.mPackedAxisBits;
					arg.mPackedAxisValues = XobotOS.Runtime.MarshalGlue.Array_float_Helper.NativeToManaged
						(obj.mPackedAxisValues);
					arg.x = obj.x;
					arg.y = obj.y;
					arg.pressure = obj.pressure;
					arg.size = obj.size;
					arg.touchMajor = obj.touchMajor;
					arg.touchMinor = obj.touchMinor;
					arg.toolMajor = obj.toolMajor;
					arg.toolMinor = obj.toolMinor;
					arg.orientation = obj.orientation;
				}

				public static System.IntPtr ManagedToNative(android.view.MotionEvent.PointerCoords
					 arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PointerCoords_Struct
						)));
					android.view.MotionEvent.PointerCoords.PointerCoords_Helper.MarshalIn(ptr, arg);
					return ptr;
				}

				public static android.view.MotionEvent.PointerCoords NativeToManaged(System.IntPtr
					 ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					PointerCoords_Struct obj = (PointerCoords_Struct)Marshal.PtrToStructure(ptr, typeof(
						PointerCoords_Struct));
					android.view.MotionEvent.PointerCoords arg = new android.view.MotionEvent.PointerCoords
						();
					arg.mPackedAxisBits = obj.mPackedAxisBits;
					arg.mPackedAxisValues = XobotOS.Runtime.MarshalGlue.Array_float_Helper.NativeToManaged
						(obj.mPackedAxisValues);
					arg.x = obj.x;
					arg.y = obj.y;
					arg.pressure = obj.pressure;
					arg.size = obj.size;
					arg.touchMajor = obj.touchMajor;
					arg.touchMinor = obj.touchMinor;
					arg.toolMajor = obj.toolMajor;
					arg.toolMinor = obj.toolMinor;
					arg.orientation = obj.orientation;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_android_view_MotionEvent_PointerCoords_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_view_MotionEvent_PointerCoords_destructor
					(System.IntPtr ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					PointerCoords_Struct obj = (PointerCoords_Struct)Marshal.PtrToStructure(ptr, typeof(
						PointerCoords_Struct));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
					XobotOS.Runtime.MarshalGlue.Array_float_Helper.FreeManagedPtr(obj.mPackedAxisValues
						);
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					android.view.MotionEvent.PointerCoords.PointerCoords_Helper.FreeManagedPtr_inner(
						ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		public sealed class PointerProperties
		{
			public PointerProperties()
			{
				clear();
			}

			public PointerProperties(android.view.MotionEvent.PointerProperties other)
			{
				copyFrom(other);
			}

			public static android.view.MotionEvent.PointerProperties[] createArray(int size)
			{
				android.view.MotionEvent.PointerProperties[] array = new android.view.MotionEvent
					.PointerProperties[size];
				{
					for (int i = 0; i < size; i++)
					{
						array[i] = new android.view.MotionEvent.PointerProperties();
					}
				}
				return array;
			}

			public int id;

			public int toolType;

			public void clear()
			{
				id = INVALID_POINTER_ID;
				toolType = TOOL_TYPE_UNKNOWN;
			}

			public void copyFrom(android.view.MotionEvent.PointerProperties other)
			{
				id = other.id;
				toolType = other.toolType;
			}

			[Sharpen.MarshalHelper(@"MotionEventGlue::Properties")]
			internal static class PointerProperties_Helper
			{
				[StructLayout(LayoutKind.Sequential)]
				private struct PointerProperties_Struct
				{
					public uint _owner;

					public int id;

					public int toolType;
				}

				internal static int NativeSize
				{
					get
					{
						return Marshal.SizeOf(typeof(PointerProperties_Struct));
					}
				}

				public static void MarshalIn(System.IntPtr ptr, android.view.MotionEvent.PointerProperties
					 arg)
				{
					PointerProperties_Struct obj = new PointerProperties_Struct();
					obj._owner = 0x972f3813;
					obj.id = arg.id;
					obj.toolType = arg.toolType;
					Marshal.StructureToPtr(obj, ptr, false);
				}

				public static void MarshalOut(System.IntPtr ptr, android.view.MotionEvent.PointerProperties
					 arg)
				{
					PointerProperties_Struct obj = (PointerProperties_Struct)Marshal.PtrToStructure(ptr
						, typeof(PointerProperties_Struct));
					arg.id = obj.id;
					arg.toolType = obj.toolType;
				}

				public static System.IntPtr ManagedToNative(android.view.MotionEvent.PointerProperties
					 arg)
				{
					if (arg == null)
					{
						return System.IntPtr.Zero;
					}
					System.IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PointerProperties_Struct
						)));
					android.view.MotionEvent.PointerProperties.PointerProperties_Helper.MarshalIn(ptr
						, arg);
					return ptr;
				}

				public static android.view.MotionEvent.PointerProperties NativeToManaged(System.IntPtr
					 ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return null;
					}
					PointerProperties_Struct obj = (PointerProperties_Struct)Marshal.PtrToStructure(ptr
						, typeof(PointerProperties_Struct));
					android.view.MotionEvent.PointerProperties arg = new android.view.MotionEvent.PointerProperties
						();
					arg.id = obj.id;
					arg.toolType = obj.toolType;
					return arg;
				}

				public static void FreeNativePtr(System.IntPtr ptr)
				{
					libxobotos_android_view_MotionEvent_PointerProperties_destructor(ptr);
				}

				[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
					Unicode)]
				private static extern void libxobotos_android_view_MotionEvent_PointerProperties_destructor
					(System.IntPtr ptr);

				public static void FreeManagedPtr_inner(System.IntPtr ptr)
				{
					PointerProperties_Struct obj = (PointerProperties_Struct)Marshal.PtrToStructure(ptr
						, typeof(PointerProperties_Struct));
					if (obj._owner != 0x972f3813)
					{
						throw new System.InvalidOperationException();
					}
				}

				public static void FreeManagedPtr(System.IntPtr ptr)
				{
					if (ptr == System.IntPtr.Zero)
					{
						return;
					}
					android.view.MotionEvent.PointerProperties.PointerProperties_Helper.FreeManagedPtr_inner
						(ptr);
					Marshal.FreeHGlobal(ptr);
				}
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<MotionEventGlue::Coords>")]
		internal static class Array_PointerCoords_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_PointerCoords_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_PointerCoords_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, android.view.MotionEvent.PointerCoords
				[] arg)
			{
				Array_PointerCoords_Struct obj = new Array_PointerCoords_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_PointerCoords_Helper.NativeSize;
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < arg.Length; i++, addr += android.view.MotionEvent.PointerCoords
						.PointerCoords_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerCoords.PointerCoords_Helper.MarshalIn(addr, arg[i
							]);
					}
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, android.view.MotionEvent.PointerCoords
				[] arg)
			{
				Array_PointerCoords_Struct obj = (Array_PointerCoords_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerCoords_Struct));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerCoords
						.PointerCoords_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerCoords.PointerCoords_Helper.MarshalOut(addr, arg[
							i]);
					}
				}
			}

			public static System.IntPtr ManagedToNative(android.view.MotionEvent.PointerCoords
				[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_PointerCoords_Helper.NativeSize + 
					android.view.MotionEvent.PointerCoords.PointerCoords_Helper.NativeSize * arg.Length
					);
				Array_PointerCoords_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static android.view.MotionEvent.PointerCoords[] NativeToManaged(System.IntPtr
				 ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_PointerCoords_Struct obj = (Array_PointerCoords_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerCoords_Struct));
				android.view.MotionEvent.PointerCoords[] arg = new android.view.MotionEvent.PointerCoords
					[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerCoords
						.PointerCoords_Helper.NativeSize)
					{
						arg[i] = android.view.MotionEvent.PointerCoords.PointerCoords_Helper.NativeToManaged
							(addr);
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_view_MotionEvent_Array_PointerCoords_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_view_MotionEvent_Array_PointerCoords_destructor
				(System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_PointerCoords_Struct obj = (Array_PointerCoords_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerCoords_Struct));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerCoords
						.PointerCoords_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerCoords.PointerCoords_Helper.FreeManagedPtr_inner(
							addr);
					}
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				Array_PointerCoords_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		[Sharpen.MarshalHelper(@"NativeArray<MotionEventGlue::Properties>")]
		internal static class Array_PointerProperties_Helper
		{
			[StructLayout(LayoutKind.Sequential)]
			private struct Array_PointerProperties_Struct
			{
				public uint _owner;

				public int length;

				public System.IntPtr ptr;
			}

			internal static int NativeSize
			{
				get
				{
					return Marshal.SizeOf(typeof(Array_PointerProperties_Struct));
				}
			}

			public static void MarshalIn(System.IntPtr ptr, android.view.MotionEvent.PointerProperties
				[] arg)
			{
				Array_PointerProperties_Struct obj = new Array_PointerProperties_Struct();
				obj._owner = 0x972f3813;
				obj.length = arg.Length;
				{
					obj.ptr = ptr + Array_PointerProperties_Helper.NativeSize;
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < arg.Length; i++, addr += android.view.MotionEvent.PointerProperties
						.PointerProperties_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerProperties.PointerProperties_Helper.MarshalIn(addr
							, arg[i]);
					}
				}
				Marshal.StructureToPtr(obj, ptr, false);
			}

			public static void MarshalOut(System.IntPtr ptr, android.view.MotionEvent.PointerProperties
				[] arg)
			{
				Array_PointerProperties_Struct obj = (Array_PointerProperties_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerProperties_Struct));
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerProperties
						.PointerProperties_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerProperties.PointerProperties_Helper.MarshalOut(addr
							, arg[i]);
					}
				}
			}

			public static System.IntPtr ManagedToNative(android.view.MotionEvent.PointerProperties
				[] arg)
			{
				if (arg == null)
				{
					return System.IntPtr.Zero;
				}
				System.IntPtr ptr = Marshal.AllocHGlobal(Array_PointerProperties_Helper.NativeSize
					 + android.view.MotionEvent.PointerProperties.PointerProperties_Helper.NativeSize
					 * arg.Length);
				Array_PointerProperties_Helper.MarshalIn(ptr, arg);
				return ptr;
			}

			public static android.view.MotionEvent.PointerProperties[] NativeToManaged(System.IntPtr
				 ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return null;
				}
				Array_PointerProperties_Struct obj = (Array_PointerProperties_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerProperties_Struct));
				android.view.MotionEvent.PointerProperties[] arg = new android.view.MotionEvent.PointerProperties
					[obj.length];
				if (obj.length != arg.Length)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerProperties
						.PointerProperties_Helper.NativeSize)
					{
						arg[i] = android.view.MotionEvent.PointerProperties.PointerProperties_Helper.NativeToManaged
							(addr);
					}
				}
				return arg;
			}

			public static void FreeNativePtr(System.IntPtr ptr)
			{
				libxobotos_android_view_MotionEvent_Array_PointerProperties_destructor(ptr);
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_view_MotionEvent_Array_PointerProperties_destructor
				(System.IntPtr ptr);

			public static void FreeManagedPtr_inner(System.IntPtr ptr)
			{
				Array_PointerProperties_Struct obj = (Array_PointerProperties_Struct)Marshal.PtrToStructure
					(ptr, typeof(Array_PointerProperties_Struct));
				if (obj._owner != 0x972f3813)
				{
					throw new System.InvalidOperationException();
				}
				{
					System.IntPtr addr = obj.ptr;
					for (int i = 0; i < obj.length; i++, addr += android.view.MotionEvent.PointerProperties
						.PointerProperties_Helper.NativeSize)
					{
						android.view.MotionEvent.PointerProperties.PointerProperties_Helper.FreeManagedPtr_inner
							(addr);
					}
				}
			}

			public static void FreeManagedPtr(System.IntPtr ptr)
			{
				if (ptr == System.IntPtr.Zero)
				{
					return;
				}
				Array_PointerProperties_Helper.FreeManagedPtr_inner(ptr);
				Marshal.FreeHGlobal(ptr);
			}
		}

		internal NativeMotionEvent nativeInstance
		{
			get
			{
				return mNativePtr;
			}
		}

		public void Dispose()
		{
			mNativePtr.Dispose();
		}

		internal class NativeMotionEvent : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeMotionEvent() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeMotionEvent(System.IntPtr handle) : base(System.IntPtr.Zero, true)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_view_MotionEvent_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeMotionEvent Zero = new NativeMotionEvent();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_view_MotionEvent_destructor(handle);
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
