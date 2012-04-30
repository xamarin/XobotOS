using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace XobotBinding
{
	public class XobotProject : DotNetProject
	{
		public override string ProjectType {
			get {
				return "XobotProject";
			}
		}
		
		public override bool IsLibraryBasedProjectType {
			get {
				return true;
			}
		}
		
		public XobotProject ()
		{
			Init ();
		}
		
		public XobotProject (string language)
			: base (language)
		{
			Init ();
		}
		
		public XobotProject (string language, ProjectCreateInformation info, XmlElement options)
			: base (language, info, options)
		{
			Init ();
		}
		
		void Init ()
		{ }
	}
}

