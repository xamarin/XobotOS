using Sharpen;

namespace libcore.util
{
	[Sharpen.Sharpened]
	public sealed class Objects
	{
		private Objects()
		{
		}

		/// <summary>Returns true if two possibly-null objects are equal.</summary>
		/// <remarks>Returns true if two possibly-null objects are equal.</remarks>
		public static bool equal(object a, object b)
		{
			return a == b || (a != null && a.Equals(b));
		}

		public static int hashCode(object o)
		{
			return (o == null) ? 0 : o.GetHashCode();
		}
	}
}
