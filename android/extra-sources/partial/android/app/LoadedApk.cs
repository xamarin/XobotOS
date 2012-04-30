using System;
using System.Reflection;
using XobotOS.Runtime;
using java.lang;

namespace android.app
{
	partial class LoadedApk
	{
		public ClassLoader getClassLoader ()
		{
			if (mClassLoader != null)
				return mClassLoader;

			ContextImpl context = mActivityThread.getSystemContext();
			XobotPackageManager pm = (XobotPackageManager)context.getPackageManager ();

			Assembly asm = pm.GetAssembly (mPackageName);
			mClassLoader = new AssemblyClassLoader (asm, mPackageName);
			return mClassLoader;
		}

		private class AssemblyClassLoader : ClassLoader
		{
			private readonly Assembly asm;
			private readonly string packageName;

			public AssemblyClassLoader(Assembly asm, string packageName)
				: base (ClassLoader.getSystemClassLoader ())
			{
				this.asm = asm;
				this.packageName = packageName;
			}

			protected internal override Type findClass (string className)
			{
				if (className.StartsWith ("."))
					className = packageName + className;
				return asm.GetType (className);
			}
		}
	}
}

