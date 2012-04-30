using Sharpen;

namespace android.util
{
	/// <summary><p>Various utilities for debugging and logging.</p></summary>
	[Sharpen.Sharpened]
	public class DebugUtils
	{
		/// <hide></hide>
		public DebugUtils()
		{
		}

		[Sharpen.Stub]
		public static bool isObjectSelected(object @object)
		{
			throw new System.NotImplementedException();
		}

		// first selector == class name
		// check potential attributes
		/// <hide></hide>
		public static void buildShortClassTag(object cls, java.lang.StringBuilder @out)
		{
			if (cls == null)
			{
				@out.append("null");
			}
			else
			{
				string simpleName = cls.GetType().Name;
				if (simpleName == null || string.IsNullOrEmpty(simpleName))
				{
					simpleName = cls.GetType().FullName;
					int end = simpleName.LastIndexOf('.');
					if (end > 0)
					{
						simpleName = Sharpen.StringHelper.Substring(simpleName, end + 1);
					}
				}
				@out.append(simpleName);
				@out.append('{');
				@out.append(Sharpen.Util.IntToHexString(Sharpen.Util.IdentityHashCode(cls)));
			}
		}
	}
}
