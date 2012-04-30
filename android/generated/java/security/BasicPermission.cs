using Sharpen;

namespace java.security
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class BasicPermission : java.security.Permission
	{
		[Sharpen.Stub]
		public BasicPermission(string name) : base(string.Empty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public BasicPermission(string name, string action) : base(string.Empty)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.security.Permission")]
		public override string getActions()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.OverridesMethod(@"java.security.Permission")]
		public override bool implies(java.security.Permission permission)
		{
			throw new System.NotImplementedException();
		}
	}
}
