using Sharpen;

namespace android.view
{
	/// <summary>
	/// Helper class for receiving notifications from the SensorManager when
	/// the orientation of the device has changed.
	/// </summary>
	/// <remarks>
	/// Helper class for receiving notifications from the SensorManager when
	/// the orientation of the device has changed.
	/// </remarks>
	[Sharpen.Sharpened]
	[System.ObsoleteAttribute(@"use OrientationEventListener instead. This class internally uses the OrientationEventListener."
		)]
	public abstract class OrientationListener : android.hardware.SensorListener
	{
		private android.view.OrientationEventListener mOrientationEventLis;

		/// <summary>
		/// Returned from onOrientationChanged when the device orientation cannot be determined
		/// (typically when the device is in a close to flat position).
		/// </summary>
		/// <remarks>
		/// Returned from onOrientationChanged when the device orientation cannot be determined
		/// (typically when the device is in a close to flat position).
		/// </remarks>
		/// <seealso cref="onOrientationChanged(int)">onOrientationChanged(int)</seealso>
		public const int ORIENTATION_UNKNOWN = android.view.OrientationEventListener.ORIENTATION_UNKNOWN;

		/// <summary>Creates a new OrientationListener.</summary>
		/// <remarks>Creates a new OrientationListener.</remarks>
		/// <param name="context">for the OrientationListener.</param>
		public OrientationListener(android.content.Context context)
		{
			mOrientationEventLis = new android.view.OrientationListener.OrientationEventListenerInternal
				(this, context);
		}

		/// <summary>Creates a new OrientationListener.</summary>
		/// <remarks>Creates a new OrientationListener.</remarks>
		/// <param name="context">for the OrientationListener.</param>
		/// <param name="rate">
		/// at which sensor events are processed (see also
		/// <see cref="android.hardware.SensorManager">SensorManager</see>
		/// ). Use the default
		/// value of
		/// <see cref="android.hardware.SensorManager.SENSOR_DELAY_NORMAL">
		/// 
		/// SENSOR_DELAY_NORMAL
		/// </see>
		/// for simple screen orientation change detection.
		/// </param>
		public OrientationListener(android.content.Context context, int rate)
		{
			mOrientationEventLis = new android.view.OrientationListener.OrientationEventListenerInternal
				(this, context, rate);
		}

		internal class OrientationEventListenerInternal : android.view.OrientationEventListener
		{
			internal OrientationEventListenerInternal(OrientationListener _enclosing, android.content.Context
				 context) : base(context)
			{
				this._enclosing = _enclosing;
			}

			internal OrientationEventListenerInternal(OrientationListener _enclosing, android.content.Context
				 context, int rate) : base(context, rate)
			{
				this._enclosing = _enclosing;
				// register so that onSensorChanged gets invoked
				this.registerListener(this._enclosing);
			}

			[Sharpen.OverridesMethod(@"android.view.OrientationEventListener")]
			public override void onOrientationChanged(int orientation)
			{
				this._enclosing.onOrientationChanged(orientation);
			}

			private readonly OrientationListener _enclosing;
		}

		/// <summary>
		/// Enables the OrientationListener so it will monitor the sensor and call
		/// <see cref="onOrientationChanged(int)">onOrientationChanged(int)</see>
		/// when the device orientation changes.
		/// </summary>
		public virtual void enable()
		{
			mOrientationEventLis.enable();
		}

		/// <summary>Disables the OrientationListener.</summary>
		/// <remarks>Disables the OrientationListener.</remarks>
		public virtual void disable()
		{
			mOrientationEventLis.disable();
		}

		[Sharpen.ImplementsInterface(@"android.hardware.SensorListener")]
		public virtual void onAccuracyChanged(int sensor, int accuracy)
		{
		}

		[Sharpen.ImplementsInterface(@"android.hardware.SensorListener")]
		public virtual void onSensorChanged(int sensor, float[] values)
		{
		}

		// just ignore the call here onOrientationChanged is invoked anyway
		/// <summary>
		/// Look at
		/// <see cref="OrientationEventListener.onOrientationChanged(int)">OrientationEventListener.onOrientationChanged(int)
		/// 	</see>
		/// for method description and usage
		/// </summary>
		/// <param name="orientation">The new orientation of the device.</param>
		/// <seealso cref="ORIENTATION_UNKNOWN">ORIENTATION_UNKNOWN</seealso>
		public abstract void onOrientationChanged(int orientation);
	}
}
