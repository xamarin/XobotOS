using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	internal class KeyframeSet
	{
		internal int mNumKeyframes;

		internal android.animation.Keyframe mFirstKeyframe;

		internal android.animation.Keyframe mLastKeyframe;

		internal android.animation.TimeInterpolator mInterpolator;

		internal java.util.ArrayList<android.animation.Keyframe> mKeyframes;

		internal android.animation.TypeEvaluator<object> mEvaluator;

		[Sharpen.Stub]
		public KeyframeSet(params android.animation.Keyframe[] keyframes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.animation.KeyframeSet ofInt(params int[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.animation.KeyframeSet ofFloat(params float[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.animation.KeyframeSet ofKeyframe(params android.animation.Keyframe
			[] keyframes)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal static android.animation.KeyframeSet ofObject(params object[] values)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual void setEvaluator(android.animation.TypeEvaluator<object> evaluator
			)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		internal virtual android.animation.KeyframeSet clone()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual object getValue(float fraction)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.lang.Object")]
		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
