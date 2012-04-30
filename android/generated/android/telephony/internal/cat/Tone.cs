using Sharpen;

namespace android.telephony.@internal.cat
{
	/// <summary>
	/// Enumeration for representing the tone values for use with PLAY TONE
	/// proactive commands.
	/// </summary>
	/// <remarks>
	/// Enumeration for representing the tone values for use with PLAY TONE
	/// proactive commands.
	/// <hide></hide>
	/// </remarks>
	public enum Tone
	{
		/// <summary>Dial tone.</summary>
		/// <remarks>Dial tone.</remarks>
		DIAL = unchecked((int)(0x01)),
		/// <summary>Called subscriber busy.</summary>
		/// <remarks>Called subscriber busy.</remarks>
		BUSY = unchecked((int)(0x02)),
		/// <summary>Congestion.</summary>
		/// <remarks>Congestion.</remarks>
		CONGESTION = unchecked((int)(0x03)),
		/// <summary>Radio path acknowledge.</summary>
		/// <remarks>Radio path acknowledge.</remarks>
		RADIO_PATH_ACK = unchecked((int)(0x04)),
		/// <summary>Radio path not available / Call dropped.</summary>
		/// <remarks>Radio path not available / Call dropped.</remarks>
		RADIO_PATH_NOT_AVAILABLE = unchecked((int)(0x05)),
		/// <summary>Error/Special information.</summary>
		/// <remarks>Error/Special information.</remarks>
		ERROR_SPECIAL_INFO = unchecked((int)(0x06)),
		/// <summary>Call waiting tone.</summary>
		/// <remarks>Call waiting tone.</remarks>
		CALL_WAITING = unchecked((int)(0x07)),
		/// <summary>Ringing tone.</summary>
		/// <remarks>Ringing tone.</remarks>
		RINGING = unchecked((int)(0x08)),
		/// <summary>General beep.</summary>
		/// <remarks>General beep.</remarks>
		GENERAL_BEEP = unchecked((int)(0x10)),
		/// <summary>Positive acknowledgement tone.</summary>
		/// <remarks>Positive acknowledgement tone.</remarks>
		POSITIVE_ACK = unchecked((int)(0x11)),
		/// <summary>Negative acknowledgement tone.</summary>
		/// <remarks>Negative acknowledgement tone.</remarks>
		NEGATIVE_ACK = unchecked((int)(0x12)),
		/// <summary>Ringing tone as selected by the user for incoming speech call.</summary>
		/// <remarks>Ringing tone as selected by the user for incoming speech call.</remarks>
		INCOMING_SPEECH_CALL = unchecked((int)(0x13)),
		/// <summary>Alert tone as selected by the user for incoming SMS.</summary>
		/// <remarks>Alert tone as selected by the user for incoming SMS.</remarks>
		INCOMING_SMS = unchecked((int)(0x14)),
		/// <summary>Critical alert.</summary>
		/// <remarks>
		/// Critical alert.
		/// This tone is to be used in critical situations. The terminal shall make
		/// every effort to alert the user when this tone is indicated independent
		/// from the volume setting in the terminal.
		/// </remarks>
		CRITICAL_ALERT = unchecked((int)(0x15)),
		/// <summary>Vibrate only, if available.</summary>
		/// <remarks>Vibrate only, if available.</remarks>
		VIBRATE_ONLY = unchecked((int)(0x20)),
		/// <summary>Happy tone.</summary>
		/// <remarks>Happy tone.</remarks>
		HAPPY = unchecked((int)(0x30)),
		/// <summary>Sad tone.</summary>
		/// <remarks>Sad tone.</remarks>
		SAD = unchecked((int)(0x31)),
		/// <summary>Urgent action tone.</summary>
		/// <remarks>Urgent action tone.</remarks>
		URGENT = unchecked((int)(0x32)),
		/// <summary>Question tone.</summary>
		/// <remarks>Question tone.</remarks>
		QUESTION = unchecked((int)(0x33)),
		/// <summary>Message received tone.</summary>
		/// <remarks>Message received tone.</remarks>
		MESSAGE_RECEIVED = unchecked((int)(0x34)),
		MELODY_1 = unchecked((int)(0x40)),
		MELODY_2 = unchecked((int)(0x41)),
		MELODY_3 = unchecked((int)(0x42)),
		MELODY_4 = unchecked((int)(0x43)),
		MELODY_5 = unchecked((int)(0x44)),
		MELODY_6 = unchecked((int)(0x45)),
		MELODY_7 = unchecked((int)(0x46)),
		MELODY_8 = unchecked((int)(0x47))
	}
}
