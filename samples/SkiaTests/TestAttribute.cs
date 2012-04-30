using System;

namespace XobotOS.Samples.SkiaTests
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class TestAttribute : Attribute
	{
		public readonly string Name;

		public TestAttribute (string name)
		{
			this.Name = name;
		}
	}
}
