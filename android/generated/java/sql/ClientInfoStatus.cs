using Sharpen;

namespace java.sql
{
	/// <summary>
	/// An enumeration to describe the reason why a property cannot be set by calling
	/// Connection.setClientInfo.
	/// </summary>
	/// <remarks>
	/// An enumeration to describe the reason why a property cannot be set by calling
	/// Connection.setClientInfo.
	/// </remarks>
	/// <since>1.6</since>
	public enum ClientInfoStatus
	{
		REASON_UNKNOWN,
		REASON_UNKNOWN_PROPERTY,
		REASON_VALUE_INVALID,
		REASON_VALUE_TRUNCATED
	}
}
