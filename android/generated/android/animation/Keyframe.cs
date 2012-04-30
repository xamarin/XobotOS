using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public abstract class Keyframe : System.ICloneable
	{
		internal float mFraction;

		internal System.Type mValueType;

		private android.animation.TimeInterpolator mInterpolator = null;

		internal bool mHasValue = false;

		[Sharpen.Stub]
		public static android.animation.Keyframe ofInt(float fraction, int value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.Keyframe ofInt(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.Keyframe ofFloat(float fraction, float value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.Keyframe ofFloat(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.Keyframe ofObject(float fraction, object value)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public static android.animation.Keyframe ofObject(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual bool hasValue()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract object getValue();

		[Sharpen.Stub]
		public abstract void setValue(object value);

		[Sharpen.Stub]
		public virtual float getFraction()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setFraction(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual android.animation.TimeInterpolator getInterpolator()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setInterpolator(android.animation.TimeInterpolator interpolator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual System.Type getType()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract android.animation.Keyframe clone();

		[Sharpen.Stub]
		internal class ObjectKeyframe : android.animation.Keyframe
		{
			internal object mValue;

			[Sharpen.Stub]
			internal ObjectKeyframe(float fraction, object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override object getValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override void setValue(object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override android.animation.Keyframe clone()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class IntKeyframe : android.animation.Keyframe
		{
			internal int mValue;

			[Sharpen.Stub]
			internal IntKeyframe(float fraction, int value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal IntKeyframe(float fraction)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual int getIntValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override object getValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override void setValue(object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override android.animation.Keyframe clone()
			{
				throw new System.NotImplementedException();
			}
		}

		[Sharpen.Stub]
		internal class FloatKeyframe : android.animation.Keyframe
		{
			internal float mValue;

			[Sharpen.Stub]
			internal FloatKeyframe(float fraction, float value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			internal FloatKeyframe(float fraction)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			public virtual float getFloatValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override object getValue()
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override void setValue(object value)
			{
				throw new System.NotImplementedException();
			}

			[Sharpen.Stub]
			[Sharpen.OverridesMethod(@"android.animation.Keyframe")]
			public override android.animation.Keyframe clone()
			{
				throw new System.NotImplementedException();
			}
		}

		object System.ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
