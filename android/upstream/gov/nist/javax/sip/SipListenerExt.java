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

import javax.sip.Dialog;
import javax.sip.SipListener;

/**
 * This interface extends the {@link SipListener} interface and adds the following events to it :
 * <ul>
 * <li>{@link DialogTimeoutEvent}- these are timeout notifications emitted as events by the
 * SipProvider. Timeout events represent timers expiring in the underlying SipProvider dialog
 * state machine. These timeout's events notify the application that a dialog has timed out.</li>
 * </ul>
 * 
 * @author jean.deruelle@gmail.com
 * 
 */
public interface SipListenerExt extends SipListener {

    /**
     * Processes an expiration Timeout of an underlying {@link Dialog} handled by this
     * SipListener. This Event notifies the application that a dialog Timer expired in the
     * Dialog's state machine. Such a condition can occur when the application fails to send an
     * ACK after receiving an OK response or if an ACK is not received after an OK is sent. The
     * DialogTimeoutEvent encapsulates the specific timeout type and the dialog identifier. The
     * type of Timeout can by determined by:
     * <code>timeoutType = timeoutEvent.getTimeout().getValue();</code>
     * 
     * Applications implementing this method should take care of sending the BYE or terminating
     * the dialog to avoid any dialog leaks.
     * 
     * @param timeoutEvent - the timeoutEvent received indicating the dialog timed out.
     */
    public void processDialogTimeout(DialogTimeoutEvent timeoutEvent);
}
