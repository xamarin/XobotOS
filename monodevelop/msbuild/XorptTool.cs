using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace XobotBinding
{
	public class XorptTool : ToolTask
	{
		[Required]
		public string InstallDir {
			get; set;
		}

		[Required]
		public string ProjectName {
			get; set;
		}

		[Required]
		public string ProjectDir {
			get; set;
		}
		
		internal string FrameworkApk {
			get { return Path.Combine (InstallDir, "framework-res.apk"); }
		}
		
		internal string AndroidManifest {
			get { return Path.Combine (ProjectDir, "AndroidManifest.xml"); }
		}

		public override bool Execute ()
		{
			if (!File.Exists (FrameworkApk)) {
				Log.LogError ("Cannot load {0}", FrameworkApk);
				return false;
			}
			
			if (!File.Exists (AndroidManifest)) {
				Log.LogError ("Cannot find {0}", AndroidManifest);
				return false;
			}
			
			return base.Execute ();
		}
		
		protected override string GenerateCommandLineCommands ()
		{
			var builder = new CommandLineBuilder ();
			builder.AppendSwitch("p");
			builder.AppendSwitch("-f");
			
			var resdir = Path.Combine (ProjectDir, "res");
			var reszip = Path.Combine (ProjectDir, ProjectName + "-res.zip");
			
			if (Directory.Exists (resdir)) {
				builder.AppendSwitch("-S");
				builder.AppendFileNameIfNotNull (resdir);
			}
			
			builder.AppendSwitch("-F");
			builder.AppendFileNameIfNotNull (reszip);
			
			builder.AppendSwitch("-J");
			builder.AppendFileNameIfNotNull (ProjectDir);
			
			builder.AppendSwitch ("-M");
			builder.AppendFileNameIfNotNull (AndroidManifest);
			
			builder.AppendSwitch ("-I");
			builder.AppendFileNameIfNotNull (FrameworkApk);
			
			return builder.ToString ();
		}

		protected override string GenerateFullPathToTool ()
		{
			return Path.Combine (InstallDir, ToolName);
		}

		protected override string ToolName {
			get {
				return "xorpt";
			}
		}
	}
}

