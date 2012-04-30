using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	internal class IntKeyframeSet : android.animation.KeyframeSet
	{
		private int firstValue;

		private int lastValue;

		private int deltaValue;

		private bool firstTime = true;

		[Sharpen.Stub]
		internal IntKeyframeSet(params android.animation.Keyframe.IntKeyframe[] keyframes
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
		public virtual int getIntValue(float fraction)
		{
			throw new System.NotImplementedException();
		}
	}
}
