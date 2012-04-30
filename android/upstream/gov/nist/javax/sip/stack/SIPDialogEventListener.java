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
package gov.nist.javax.sip.stack;

import java.util.EventListener;

/**
 * Interface implemented by classes that want to be notified of asynchronous
 * dialog events.
 *
 * @author jean deruelle
 * @since 2.0 
 */
public interface SIPDialogEventListener extends EventListener {

    /**
     * Invoked when an error has ocurred with a dialog.
     *
     * @param dialogErrorEvent Error event.
     */
    public void dialogErrorEvent(SIPDialogErrorEvent dialogErrorEvent);
}
