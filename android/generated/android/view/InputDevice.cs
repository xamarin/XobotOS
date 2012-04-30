using Sharpen;

namespace android.view
{
	[Sharpen.Stub]
	public sealed class InputDevice : android.os.Parcelable
	{
		private int mId;

		private string mName;

		private int mSources;

		private int mKeyboardType;

		private readonly java.util.ArrayList<android.view.InputDevice.MotionRange> mMotionRanges
			 = new java.util.ArrayList<android.view.InputDevice.MotionRange>();

		public const int SOURCE_CLASS_MASK = unchecked((int)(0x000000ff));

		public const int SOURCE_CLASS_BUTTON = unchecked((int)(0x00000001));

		public const int SOURCE_CLASS_POINTER = unchecked((int)(0x00000002));

		public const int SOURCE_CLASS_TRACKBALL = unchecked((int)(0x00000004));

		public const int SOURCE_CLASS_POSITION = unchecked((int)(0x00000008));

		public const int SOURCE_CLASS_JOYSTICK = unchecked((int)(0x00000010));

		public const int SOURCE_UNKNOWN = unchecked((int)(0x00000000));

		public const int SOURCE_KEYBOARD = unchecked((int)(0x00000100)) | SOURCE_CLASS_BUTTON;

		public const int SOURCE_DPAD = unchecked((int)(0x00000200)) | SOURCE_CLASS_BUTTON;

		public const int SOURCE_GAMEPAD = unchecked((int)(0x00000400)) | SOURCE_CLASS_BUTTON;

		public const int SOURCE_TOUCHSCREEN = unchecked((int)(0x00001000)) | SOURCE_CLASS_POINTER;

		public const int SOURCE_MOUSE = unchecked((int)(0x00002000)) | SOURCE_CLASS_POINTER;

		public const int SOURCE_STYLUS = unchecked((int)(0x00004000)) | SOURCE_CLASS_POINTER;

		public const int SOURCE_TRACKBALL = unchecked((int)(0x00010000)) | SOURCE_CLASS_TRACKBALL;

		public const int SOURCE_TOUCHPAD = unchecked((int)(0x00100000)) | SOURCE_CLASS_POSITION;

		public const int SOURCE_JOYSTICK = unchecked((int)(0x01000000)) | SOURCE_CLASS_JOYSTICK;

		public const int SOURCE_ANY = unchecked((int)(0xffffff00));

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_X instead.")]
		public const int MOTION_RANGE_X = android.view.MotionEvent.AXIS_X;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_Y instead.")]
		public const int MOTION_RANGE_Y = android.view.MotionEvent.AXIS_Y;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_PRESSURE instead.")]
		public const int MOTION_RANGE_PRESSURE = android.view.MotionEvent.AXIS_PRESSURE;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_SIZE instead.")]
		public const int MOTION_RANGE_SIZE = android.view.MotionEvent.AXIS_SIZE;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_TOUCH_MAJOR instead.")]
		public const int MOTION_RANGE_TOUCH_MAJOR = android.view.MotionEvent.AXIS_TOUCH_MAJOR;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_TOUCH_MINOR instead.")]
		public const int MOTION_RANGE_TOUCH_MINOR = android.view.MotionEvent.AXIS_TOUCH_MINOR;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_TOOL_MAJOR instead.")]
		public const int MOTION_RANGE_TOOL_MAJOR = android.view.MotionEvent.AXIS_TOOL_MAJOR;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_TOOL_MINOR instead.")]
		public const int MOTION_RANGE_TOOL_MINOR = android.view.MotionEvent.AXIS_TOOL_MINOR;

		[System.ObsoleteAttribute(@"Use MotionEvent.AXIS_ORIENTATION instead.")]
		public const int MOTION_RANGE_ORIENTATION = android.view.MotionEvent.AXIS_ORIENTATION;

		public const int KEYBOARD_TYPE_NONE = 0;

		public const int KEYBOARD_TYPE_NON_ALPHABETIC = 1;

		public const int KEYBOARD_TYPE_ALPHABETIC = 2;

		[Sharpen.Stub]
		private InputDevice()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.view.InputDevice getDevice(int id)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static int[] getDeviceIds()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getId()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getSources()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public int getKeyboardType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.KeyCharacterMap getKeyCharacterMap()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.InputDevice.MotionRange getMotionRange(int axis)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public android.view.InputDevice.MotionRange getMotionRange(int axis, int source)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public java.util.List<android.view.InputDevice.MotionRange> getMotionRanges()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		private void addMotionRange(int axis, int source, float min, float max, float flat
			, float fuzz)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public sealed class MotionRange
		{
			private int mAxis;

			private int mSource;

			private float mMin;

			private float mMax;

			private float mFlat;

			private float mFuzz;

			[Sharpen.Stub]
			private MotionRange(int axis, int source, float min, float max, float flat, float
				 fuzz)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getAxis()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public int getSource()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public float getMin()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public float getMax()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public float getRange()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public float getFlat()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public float getFuzz()
			{
				throw new System.NotImplementedException();
			}
		}

		private sealed class _Creator_518 : android.os.ParcelableClass.Creator<android.view.InputDevice
			>
		{
			public _Creator_518()
			{
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputDevice createFromParcel(android.os.Parcel @in)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.ImplementsInterface(@"android.os.Parcelable.Creator")]
			public android.view.InputDevice[] newArray(int size)
			{
				throw new System.NotImplementedException();
			}
		}

		public static readonly android.os.ParcelableClass.Creator<android.view.InputDevice
			> CREATOR = new _Creator_518();

		[Sharpen.Stub]
		private void readFromParcel(android.os.Parcel @in)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public void writeToParcel(android.os.Parcel @out, int flags)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"android.os.Parcelable")]
		public int describeContents()
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
		private void appendSourceDescriptionIfApplicable(java.lang.StringBuilder description
			, int source, string sourceName)
		{
			throw new System.NotImplementedException();
		}
	}
}
