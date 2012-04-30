using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	internal class FloatKeyframeSet : android.animation.KeyframeSet
	{
		private float firstValue;

		private float lastValue;

		private float deltaValue;

		private bool firstTime = true;

		[Sharpen.Stub]
		internal FloatKeyframeSet(params android.animation.Keyframe.FloatKeyframe[] keyframes
			) : base(keyframes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.KeyframeSet")]
		public override object getValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"android.animation.KeyframeSet")]
		internal override android.animation.KeyframeSet clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual float getFloatValue(float fraction)
		{
			throw new System.NotImplementedException();
		}
	}
}
