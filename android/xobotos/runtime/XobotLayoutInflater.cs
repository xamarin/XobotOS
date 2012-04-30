using System;
using System.Reflection;
using android.content;
using android.view;
using android.util;

namespace XobotOS.Runtime
{
	internal class XobotLayoutInflater : LayoutInflater
	{
		public XobotLayoutInflater (Context context)
			: base (context)
		{
		}

		protected internal override View onCreateView (string name, AttributeSet attrs)
		{
			Assembly calling = Assembly.GetCallingAssembly ();
			if (calling.GetType ("android.widget." + name) != null)
				return createView (name, "android.widget.", attrs);
			return base.onCreateView (name, attrs);
		}

		#region implemented abstract members of android.view.LayoutInflater
		public override LayoutInflater cloneInContext (Context newContext)
		{
			return new XobotLayoutInflater (newContext);
		}
		#endregion
	}
}
