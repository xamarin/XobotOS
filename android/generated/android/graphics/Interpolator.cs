using System.Runtime.InteropServices;
using Sharpen;

namespace android.graphics
{
	[Sharpen.Sharpened]
	public class Interpolator : System.IDisposable
	{
		public Interpolator(int valueCount)
		{
			mValueCount = valueCount;
			mFrameCount = 2;
			native_instance = nativeConstructor(valueCount, 2);
		}

		public Interpolator(int valueCount, int frameCount)
		{
			mValueCount = valueCount;
			mFrameCount = frameCount;
			native_instance = nativeConstructor(valueCount, frameCount);
		}

		/// <summary>
		/// Reset the Interpolator to have the specified number of values and an
		/// implicit keyFrame count of 2 (just a start and end).
		/// </summary>
		/// <remarks>
		/// Reset the Interpolator to have the specified number of values and an
		/// implicit keyFrame count of 2 (just a start and end). After this call the
		/// values for each keyFrame must be assigned using setKeyFrame().
		/// </remarks>
		public virtual void reset(int valueCount)
		{
			reset(valueCount, 2);
		}

		/// <summary>
		/// Reset the Interpolator to have the specified number of values and
		/// keyFrames.
		/// </summary>
		/// <remarks>
		/// Reset the Interpolator to have the specified number of values and
		/// keyFrames. After this call the values for each keyFrame must be assigned
		/// using setKeyFrame().
		/// </remarks>
		public virtual void reset(int valueCount, int frameCount)
		{
			mValueCount = valueCount;
			mFrameCount = frameCount;
			nativeReset(native_instance, valueCount, frameCount);
		}

		public int getKeyFrameCount()
		{
			return mFrameCount;
		}

		public int getValueCount()
		{
			return mValueCount;
		}

		/// <summary>
		/// Assign the keyFrame (specified by index) a time value and an array of key
		/// values (with an implicity blend array of [0, 0, 1, 1] giving linear
		/// transition to the next set of key values).
		/// </summary>
		/// <remarks>
		/// Assign the keyFrame (specified by index) a time value and an array of key
		/// values (with an implicity blend array of [0, 0, 1, 1] giving linear
		/// transition to the next set of key values).
		/// </remarks>
		/// <param name="index">The index of the key frame to assign</param>
		/// <param name="msec">
		/// The time (in mililiseconds) for this key frame. Based on the
		/// SystemClock.uptimeMillis() clock
		/// </param>
		/// <param name="values">Array of values associated with theis key frame</param>
		public virtual void setKeyFrame(int index, int msec, float[] values)
		{
			setKeyFrame(index, msec, values, null);
		}

		/// <summary>
		/// Assign the keyFrame (specified by index) a time value and an array of key
		/// values and blend array.
		/// </summary>
		/// <remarks>
		/// Assign the keyFrame (specified by index) a time value and an array of key
		/// values and blend array.
		/// </remarks>
		/// <param name="index">The index of the key frame to assign</param>
		/// <param name="msec">
		/// The time (in mililiseconds) for this key frame. Based on the
		/// SystemClock.uptimeMillis() clock
		/// </param>
		/// <param name="values">Array of values associated with theis key frame</param>
		/// <param name="blend">(may be null) Optional array of 4 blend values</param>
		public virtual void setKeyFrame(int index, int msec, float[] values, float[] blend
			)
		{
			if (index < 0 || index >= mFrameCount)
			{
				throw new System.IndexOutOfRangeException();
			}
			if (values.Length < mValueCount)
			{
				throw new java.lang.ArrayStoreException();
			}
			if (blend != null && blend.Length < 4)
			{
				throw new java.lang.ArrayStoreException();
			}
			nativeSetKeyFrame(native_instance, index, msec, values, blend);
		}

		/// <summary>
		/// Set a repeat count (which may be fractional) for the interpolator, and
		/// whether the interpolator should mirror its repeats.
		/// </summary>
		/// <remarks>
		/// Set a repeat count (which may be fractional) for the interpolator, and
		/// whether the interpolator should mirror its repeats. The default settings
		/// are repeatCount = 1, and mirror = false.
		/// </remarks>
		public virtual void setRepeatMirror(float repeatCount, bool mirror)
		{
			if (repeatCount >= 0)
			{
				nativeSetRepeatMirror(native_instance, repeatCount, mirror);
			}
		}

		public enum Result
		{
			NORMAL,
			FREEZE_START,
			FREEZE_END
		}

		/// <summary>
		/// Calls timeToValues(msec, values) with the msec set to now (by calling
		/// (int)SystemClock.uptimeMillis().)
		/// </summary>
		public virtual android.graphics.Interpolator.Result timeToValues(float[] values)
		{
			return timeToValues((int)android.os.SystemClock.uptimeMillis(), values);
		}

		/// <summary>
		/// Given a millisecond time value (msec), return the interpolated values and
		/// return whether the specified time was within the range of key times
		/// (NORMAL), was before the first key time (FREEZE_START) or after the last
		/// key time (FREEZE_END).
		/// </summary>
		/// <remarks>
		/// Given a millisecond time value (msec), return the interpolated values and
		/// return whether the specified time was within the range of key times
		/// (NORMAL), was before the first key time (FREEZE_START) or after the last
		/// key time (FREEZE_END). In any event, computed values are always returned.
		/// </remarks>
		/// <param name="msec">
		/// The time (in milliseconds) used to sample into the
		/// Interpolator. Based on the SystemClock.uptimeMillis() clock
		/// </param>
		/// <param name="values">Where to write the computed values (may be NULL).</param>
		/// <returns>how the values were computed (even if values == null)</returns>
		public virtual android.graphics.Interpolator.Result timeToValues(int msec, float[]
			 values)
		{
			if (values != null && values.Length < mValueCount)
			{
				throw new java.lang.ArrayStoreException();
			}
			switch (nativeTimeToValues(native_instance, msec, values))
			{
				case 0:
				{
					return android.graphics.Interpolator.Result.NORMAL;
				}

				case 1:
				{
					return android.graphics.Interpolator.Result.FREEZE_START;
				}

				default:
				{
					return android.graphics.Interpolator.Result.FREEZE_END;
				}
			}
		}

		~Interpolator()
		{
			nativeDestructor(native_instance);
		}

		private int mValueCount;

		private int mFrameCount;

		internal readonly android.graphics.Interpolator.NativeInterpolator native_instance;

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern android.graphics.Interpolator.NativeInterpolator libxobotos_Interpolator_constructor
			(int valueCount, int frameCount);

		private static android.graphics.Interpolator.NativeInterpolator nativeConstructor
			(int valueCount, int frameCount)
		{
			return libxobotos_Interpolator_constructor(valueCount, frameCount);
		}

		private static void nativeDestructor(android.graphics.Interpolator.NativeInterpolator
			 native_instance)
		{
			native_instance.Dispose();
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Interpolator_reset(android.graphics.Interpolator.NativeInterpolator
			 native_instance, int valueCount, int frameCount);

		private static void nativeReset(android.graphics.Interpolator.NativeInterpolator 
			native_instance, int valueCount, int frameCount)
		{
			libxobotos_Interpolator_reset(native_instance, valueCount, frameCount);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Interpolator_setKeyFrame(android.graphics.Interpolator.NativeInterpolator
			 native_instance, int index, int msec, System.IntPtr values, System.IntPtr blend
			);

		private static void nativeSetKeyFrame(android.graphics.Interpolator.NativeInterpolator
			 native_instance, int index, int msec, float[] values, float[] blend)
		{
			Sharpen.INativeHandle values_handle = null;
			Sharpen.INativeHandle blend_handle = null;
			try
			{
				values_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(values
					);
				blend_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(blend);
				libxobotos_Interpolator_setKeyFrame(native_instance, index, msec, values_handle.Address
					, blend_handle != null ? blend_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				if (values_handle != null)
				{
					values_handle.Free();
				}
				if (blend_handle != null)
				{
					blend_handle.Free();
				}
			}
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern void libxobotos_Interpolator_setRepeatMirror(android.graphics.Interpolator.NativeInterpolator
			 native_instance, float repeatCount, bool mirror);

		private static void nativeSetRepeatMirror(android.graphics.Interpolator.NativeInterpolator
			 native_instance, float repeatCount, bool mirror)
		{
			libxobotos_Interpolator_setRepeatMirror(native_instance, repeatCount, mirror);
		}

		[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
			Unicode)]
		private static extern int libxobotos_Interpolator_timeToValues(android.graphics.Interpolator.NativeInterpolator
			 native_instance, int msec, System.IntPtr values);

		private static int nativeTimeToValues(android.graphics.Interpolator.NativeInterpolator
			 native_instance, int msec, float[] values)
		{
			Sharpen.INativeHandle values_handle = null;
			try
			{
				values_handle = XobotOS.Runtime.MarshalGlue.Array_float_Helper.GetPinnedPtr(values
					);
				return libxobotos_Interpolator_timeToValues(native_instance, msec, values_handle 
					!= null ? values_handle.Address : System.IntPtr.Zero);
			}
			finally
			{
				if (values_handle != null)
				{
					values_handle.Free();
				}
			}
		}

		internal NativeInterpolator nativeInstance
		{
			get
			{
				return native_instance;
			}
		}

		public void Dispose()
		{
			native_instance.Dispose();
		}

		internal class NativeInterpolator : System.Runtime.InteropServices.SafeHandle
		{
			internal NativeInterpolator() : base(System.IntPtr.Zero, true)
			{
			}

			internal NativeInterpolator(System.IntPtr handle) : base(System.IntPtr.Zero, true
				)
			{
				this.handle = handle;
			}

			[DllImport("libxobotos.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.
				Unicode)]
			private static extern void libxobotos_android_graphics_Interpolator_destructor(System.IntPtr
				 handle);

			internal System.IntPtr Handle
			{
				get
				{
					return handle;
				}
			}

			public static readonly NativeInterpolator Zero = new NativeInterpolator();

			protected override bool ReleaseHandle()
			{
				if (handle != System.IntPtr.Zero)
				{
					libxobotos_android_graphics_Interpolator_destructor(handle);
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
