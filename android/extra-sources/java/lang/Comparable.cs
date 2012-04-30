using Sharpen;

namespace java.lang
{
	public interface Comparable : Comparable<object>
	{ }

	public interface Comparable<T>
	{
		int compareTo(T another);
	}
}
