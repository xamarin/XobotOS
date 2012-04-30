using Sharpen;

namespace java.security
{
	[System.Serializable]
	[Sharpen.Stub]
	public abstract class Permission : java.security.Guard
	{
		[Sharpen.Stub]
		public Permission(string name)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public string getName()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		[Sharpen.ImplementsInterface(@"java.security.Guard")]
		public virtual void checkGuard(object obj)
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public virtual java.security.PermissionCollection newPermissionCollection()
		{
			throw new System.NotImplementedException();
		}

		[Sharpen.Stub]
		public abstract string getActions();

		[Sharpen.Stub]
		public abstract bool implies(java.security.Permission permission);
	}
}
