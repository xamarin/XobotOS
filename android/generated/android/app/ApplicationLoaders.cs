using Sharpen;

namespace android.app
{
	[Sharpen.Stub]
	internal class ApplicationLoaders
	{
		[Sharpen.Stub]
		internal static android.app.ApplicationLoaders getDefault()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.lang.ClassLoader getClassLoader(string zip, string libPath, java.lang.ClassLoader
			 parent)
		{
			throw new System.NotImplementedException();
		}

		private readonly java.util.Map<string, java.lang.ClassLoader> mLoaders = new java.util.HashMap
			<string, java.lang.ClassLoader>();

		private static readonly android.app.ApplicationLoaders gApplicationLoaders = new 
			android.app.ApplicationLoaders();
	}
}
