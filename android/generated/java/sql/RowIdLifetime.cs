using Sharpen;

namespace java.sql
{
	/// <summary>An enumeration to describe the life-time of RowID.</summary>
	/// <remarks>An enumeration to describe the life-time of RowID.</remarks>
	/// <since>1.6</since>
	public enum RowIdLifetime
	{
		ROWID_UNSUPPORTED,
		ROWID_VALID_OTHER,
		ROWID_VALID_SESSION,
		ROWID_VALID_TRANSACTION,
		ROWID_VALID_FOREVER
	}
}
