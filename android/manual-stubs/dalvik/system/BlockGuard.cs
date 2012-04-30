using Sharpen;

namespace dalvik.system
{
	[Sharpen.NakedStub]
	public sealed class BlockGuard
	{
		[Sharpen.NakedStub]
		public interface Policy
		{
		}

		public class BlockGuardPolicyException : java.lang.RuntimeException
		{
			public BlockGuardPolicyException (int policyState, int policyViolated, string message)
				: base (message)
			{
				throw new System.NotImplementedException ();
			}
		}
	}
}
