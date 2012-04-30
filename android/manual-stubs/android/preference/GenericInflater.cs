using Sharpen;

namespace android.preference
{
	internal abstract class GenericInflater<T, P> where P:android.preference.GenericInflater<T,P>.Parent
	{
		public interface Parent
		{ }
	}
}
