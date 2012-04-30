using Sharpen;

namespace android.telephony.@internal.cat
{
	/// <summary>Enumeration for the return code in TERMINAL RESPONSE.</summary>
	public enum ResultCode
	{
		/// <summary>Command performed successfully</summary>
		OK = unchecked((int)(0x00)),
		/// <summary>Command performed with partial comprehension</summary>
		PRFRMD_WITH_PARTIAL_COMPREHENSION = unchecked((int)(0x01)),
		/// <summary>Command performed, with missing information</summary>
		PRFRMD_WITH_MISSING_INFO = unchecked((int)(0x02)),
		/// <summary>REFRESH performed with additional EFs read</summary>
		PRFRMD_WITH_ADDITIONAL_EFS_READ = unchecked((int)(0x03)),
		/// <summary>
		/// Command performed successfully, but requested icon could not be
		/// displayed
		/// </summary>
		PRFRMD_ICON_NOT_DISPLAYED = unchecked((int)(0x04)),
		/// <summary>Command performed, but modified by call control by NAA</summary>
		PRFRMD_MODIFIED_BY_NAA = unchecked((int)(0x05)),
		/// <summary>Command performed successfully, limited service</summary>
		PRFRMD_LIMITED_SERVICE = unchecked((int)(0x06)),
		/// <summary>Command performed with modification</summary>
		PRFRMD_WITH_MODIFICATION = unchecked((int)(0x07)),
		/// <summary>REFRESH performed but indicated NAA was not active</summary>
		PRFRMD_NAA_NOT_ACTIVE = unchecked((int)(0x08)),
		/// <summary>Command performed successfully, tone not played</summary>
		PRFRMD_TONE_NOT_PLAYED = unchecked((int)(0x09)),
		/// <summary>Proactive UICC session terminated by the user</summary>
		UICC_SESSION_TERM_BY_USER = unchecked((int)(0x10)),
		/// <summary>Backward move in the proactive UICC session requested by the user</summary>
		BACKWARD_MOVE_BY_USER = unchecked((int)(0x11)),
		/// <summary>No response from user</summary>
		NO_RESPONSE_FROM_USER = unchecked((int)(0x12)),
		/// <summary>Help information required by the user</summary>
		HELP_INFO_REQUIRED = unchecked((int)(0x13)),
		/// <summary>USSD or SS transaction terminated by the user</summary>
		USSD_SS_SESSION_TERM_BY_USER = unchecked((int)(0x14)),
		/// <summary>Terminal currently unable to process command</summary>
		TERMINAL_CRNTLY_UNABLE_TO_PROCESS = unchecked((int)(0x20)),
		/// <summary>Network currently unable to process command</summary>
		NETWORK_CRNTLY_UNABLE_TO_PROCESS = unchecked((int)(0x21)),
		/// <summary>User did not accept the proactive command</summary>
		USER_NOT_ACCEPT = unchecked((int)(0x22)),
		/// <summary>User cleared down call before connection or network release</summary>
		USER_CLEAR_DOWN_CALL = unchecked((int)(0x23)),
		/// <summary>Action in contradiction with the current timer state</summary>
		CONTRADICTION_WITH_TIMER = unchecked((int)(0x24)),
		/// <summary>Interaction with call control by NAA, temporary problem</summary>
		NAA_CALL_CONTROL_TEMPORARY = unchecked((int)(0x25)),
		/// <summary>Launch browser generic error code</summary>
		LAUNCH_BROWSER_ERROR = unchecked((int)(0x26)),
		/// <summary>MMS temporary problem.</summary>
		/// <remarks>MMS temporary problem.</remarks>
		MMS_TEMPORARY = unchecked((int)(0x27)),
		/// <summary>Command beyond terminal's capabilities</summary>
		BEYOND_TERMINAL_CAPABILITY = unchecked((int)(0x30)),
		/// <summary>Command type not understood by terminal</summary>
		CMD_TYPE_NOT_UNDERSTOOD = unchecked((int)(0x31)),
		/// <summary>Command data not understood by terminal</summary>
		CMD_DATA_NOT_UNDERSTOOD = unchecked((int)(0x32)),
		/// <summary>Command number not known by terminal</summary>
		CMD_NUM_NOT_KNOWN = unchecked((int)(0x33)),
		/// <summary>SS Return Error</summary>
		SS_RETURN_ERROR = unchecked((int)(0x34)),
		/// <summary>SMS RP-ERROR</summary>
		SMS_RP_ERROR = unchecked((int)(0x35)),
		/// <summary>Error, required values are missing</summary>
		REQUIRED_VALUES_MISSING = unchecked((int)(0x36)),
		/// <summary>USSD Return Error</summary>
		USSD_RETURN_ERROR = unchecked((int)(0x37)),
		/// <summary>MultipleCard commands error</summary>
		MULTI_CARDS_CMD_ERROR = unchecked((int)(0x38)),
		/// <summary>
		/// Interaction with call control by USIM or MO short message control by
		/// USIM, permanent problem
		/// </summary>
		USIM_CALL_CONTROL_PERMANENT = unchecked((int)(0x39)),
		/// <summary>Bearer Independent Protocol error</summary>
		BIP_ERROR = unchecked((int)(0x3a)),
		/// <summary>Access Technology unable to process command</summary>
		ACCESS_TECH_UNABLE_TO_PROCESS = unchecked((int)(0x3b)),
		/// <summary>Frames error</summary>
		FRAMES_ERROR = unchecked((int)(0x3c)),
		/// <summary>MMS Error</summary>
		MMS_ERROR = unchecked((int)(0x3d))
	}
}
