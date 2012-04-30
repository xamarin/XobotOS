/*
 * This source code has been contributed to the public domain by Mobicents
 *
 * This software is provided by NIST as a service and is expressly
 * provided "AS IS."  NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED
 * OR STATUTORY, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT
 * AND DATA ACCURACY.  NIST does not warrant or make any representations
 * regarding the use of the software or the results thereof, including but
 * not limited to the correctness, accuracy, reliability or usefulness of
 * the software.
 *
 * Permission to use this software is contingent upon your acceptance
 * of the terms of this agreement.
 */
package gov.nist.javax.sip;

import java.util.EventObject;

import javax.sip.Dialog;

/**
 * 
 * DialogAckTimeoutEvent is delivered to the Listener when the
 * dialog does not receive or send an ACK. 
 *
 * 
 * @author jean deruelle
 * @since v2.0
 *
 */
public class DialogTimeoutEvent extends EventObject {
	private static final long serialVersionUID = -2514000059989311925L;
	public enum Reason {AckNotReceived, AckNotSent,ReInviteTimeout};	    
	/**
     * Constructs a DialogTerminatedEvent to indicate a dialog
     * timeout.
     *
     * @param source - the source of TimeoutEvent. 
     * @param dialog - the dialog that timed out.
     */
     public DialogTimeoutEvent(Object source, Dialog dialog, Reason reason) {
         super(source);
         m_dialog = dialog;
         m_reason = reason;
      
    }

    /**
     * Gets the Dialog associated with the event. This 
     * enables application developers to access the dialog associated to this 
     * event. 
     * 
     * @return the dialog associated with the response event or null if there is no dialog.
     * @since v1.2
     */
    public Dialog getDialog() {
        return m_dialog;
    }    
    
    /**
     * The reason for the Dialog Timeout Event being delivered to the application.
     * 
     * @return the reason for the timeout event.
     */
    public Reason getReason() {
    	return m_reason;
    }
     
    // internal variables
    private Dialog m_dialog = null;    
    private Reason m_reason = null;
}

