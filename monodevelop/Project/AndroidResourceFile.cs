using System;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Templates;

namespace XobotBinding
{
	public class AndroidResourceFile : FileDescriptionTemplate
	{
		public override void Load (XmlElement filenode, FilePath baseDirectory)
		{
			;
		}

		public override bool AddToProject (SolutionItem policyParent, Project project, string language, string directory, string name)
		{
			var path = FilePath.Build (directory, project.Name + "-res.zip");
			var file = new ProjectFile (path, "EmbeddedResource");
			file.ResourceId = "XobotOS.Resources";
			file.Visible = false;
			project.AddFile (file);
			return true;
		}

		public override void Show ()
		{
			;
		}

		public override string Name {
			get {
				return "XORPT Resource File";
			}
		}
	}
}
