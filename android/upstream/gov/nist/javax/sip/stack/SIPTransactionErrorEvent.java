/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government.
* Pursuant to title 15 Untied States Code Section 105, works of NIST
* employees are not subject to copyright protection in the United States
* and are considered to be in the public domain.  As a result, a formal
* license is not needed to use the software.
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
* of the terms of this agreement
*
* .
*
*/
package gov.nist.javax.sip.stack;


import java.util.EventObject;

/**
 * An event that indicates that a transaction has encountered an error.
 *
 *
 * @author Jeff Keyser
 * @author M. Ranganathan
 *
 *
 *
 * @version 1.2 $Revision: 1.7 $ $Date: 2009/07/17 18:58:15 $
 */
public class SIPTransactionErrorEvent extends EventObject {

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -2713188471978065031L;

    /**
     * This event ID indicates that the transaction has timed out.
     */
    public static final int TIMEOUT_ERROR = 1;

    /**
     * This event ID indicates that there was an error sending a message using
     * the underlying transport.
     */
    public static final int TRANSPORT_ERROR = 2;

    /**
     * Retransmit signal to application layer.
     */
    public static final int TIMEOUT_RETRANSMIT = 3;



    // ID of this error event
    private int errorID;

    /**
     * Creates a transaction error event.
     *
     * @param sourceTransaction Transaction which is raising the error.
     * @param transactionErrorID ID of the error that has ocurred.
     */
    SIPTransactionErrorEvent(
        SIPTransaction sourceTransaction,
        int transactionErrorID) {

        super(sourceTransaction);
        errorID = transactionErrorID;

    }

    /**
     * Returns the ID of the error.
     *
     * @return Error ID.
     */
    public int getErrorID() {
        return errorID;
    }
}
