using System;
using System.Xml;
using MonoDevelop.Projects;

namespace XobotBinding
{
	public class XobotProjectBinding : IProjectBinding
	{
		public string Name {
			get { return "XobotProject"; }
		}

		public Project CreateProject (ProjectCreateInformation info, XmlElement options)
		{
			return new XobotProject ("C#", info, options);
		}

		public Project CreateSingleFileProject (string sourceFile)
		{
			return null;
		}

		public bool CanCreateSingleFileProject (string sourceFile)
		{
			return false;
		}
	}
}

