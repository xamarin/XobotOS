using Sharpen;

namespace org.apache.harmony.security.x509.tsp
{
	public enum PKIStatus
	{
		GRANTED,
		GRANTED_WITH_MODS,
		REJECTION,
		WAITING,
		REVOCATION_WARNING,
		REVOCATION_NOTIFICATION
	}
}
