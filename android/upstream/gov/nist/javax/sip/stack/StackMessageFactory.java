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
/*******************************************************************************
* Product of NIST/ITL Advanced Networking Technologies Division (ANTD).        *
*******************************************************************************/
package gov.nist.javax.sip.stack;
import gov.nist.javax.sip.message.*;

/**
 * An interface for generating new requests and responses. This is implemented
 * by the application and called by the stack for processing requests
 * and responses. When a Request comes in off the wire, the stack calls
 * newSIPServerRequest which is then responsible for processing the request.
 * When a response comes off the wire, the stack calls newSIPServerResponse
 * to process the response.
 *
 * @version 1.2 $Revision: 1.5 $ $Date: 2009/07/17 18:58:15 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public interface StackMessageFactory {
    /**
     * Make a new SIPServerResponse given a SIPRequest and a message
     * channel.
     *
     * @param sipRequest is the incoming request.
     * @param msgChan is the message channel on which this request was
     *  received.
     */
    public ServerRequestInterface newSIPServerRequest(
        SIPRequest sipRequest,
        MessageChannel msgChan);

    /**
     * Generate a new server response for the stack.
     *
     * @param sipResponse is the incoming response.
     * @param msgChan is the message channel on which the response was
     * received.
     */
    public ServerResponseInterface newSIPServerResponse(
        SIPResponse sipResponse,
        MessageChannel msgChan);
}
