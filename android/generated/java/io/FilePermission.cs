using Sharpen;

namespace java.io
{
	/// <summary>Legacy security code; do not use.</summary>
	/// <remarks>Legacy security code; do not use.</remarks>
	[System.Serializable]
	[Sharpen.Sharpened]
	public sealed class FilePermission : java.security.Permission
	{
		public FilePermission(string path, string actions) : base(string.Empty)
		{
		}

		[Sharpen.OverridesMethod(@"java.security.Permission")]
		public override string getActions()
		{
			return null;
		}

		[Sharpen.OverridesMethod(@"java.security.Permission")]
		public override bool implies(java.security.Permission permission)
		{
			return true;
		}
	}
}
