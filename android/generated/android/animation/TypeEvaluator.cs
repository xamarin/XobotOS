using Sharpen;

namespace android.animation
{
	[Sharpen.Stub]
	public interface TypeEvaluator<T>
	{
		[Sharpen.Stub]
		T evaluate(float fraction, T startValue, T endValue);
	}
}
