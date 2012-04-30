using System;
using System.Reflection;

namespace XobotOS.Runtime
{
	public static class Reflection
	{
		public static MethodInfo GetMethod (Type type, string name, params Type[] args)
		{
			return type.GetMethod (name, args);
		}

		public static object InvokeMethod (MethodBase method, object instance, params object[] args)
		{
			return method.Invoke (instance, args);
		}

		public static Type GetType(String name)
		{
			return Type.GetType (name);
		}

		public static String GetCanonicalName(Type type)
		{
			return type.FullName;
		}

		public static Type AsSubclass (Type klass, Type subclass)
		{
			if (subclass.IsAssignableFrom (klass))
				return klass;
			string msg = string.Format ("'{0}' cannot be cast to '{1}'.", klass.Name, subclass.Name);
			throw new InvalidCastException (msg);
		}

		public static ConstructorInfo GetConstructor (Type klass, Type[] sig)
		{
			ConstructorInfo info = klass.GetConstructor (sig);
			if (info == null)
				throw new java.lang.NoSuchMethodException (klass.Name);
			return info;
		}

		public static object NewInstance (ConstructorInfo constructor, object[] args)
		{
			return constructor.Invoke (args);
		}

		public static java.lang.ClassLoader GetClassLoader (Type type)
		{
			return java.lang.ClassLoader.getSystemClassLoader ();
		}
	}
}

