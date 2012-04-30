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
 * An interface for a genereic message processor for SIP Request messages.
 * This is implemented by the application. The stack calls the message
 * factory with a pointer to the parsed structure to create one of these
 * and then calls processRequest on the newly created SIPServerRequest
 * It is the applications responsibility to take care of what needs to be
 * done to actually process the request.
 *
 * @version 1.2 $Revision: 1.4 $ $Date: 2009/07/17 18:58:15 $
 *
 * @author M. Ranganathan   <br/>
 *
 *
 *
 */
public interface ServerRequestInterface {

    /**
     * Process the message.  This incorporates a feature request
     * by Salvador Rey Calatayud <salreyca@TELECO.UPV.ES>
     * @param sipRequest is the incoming SIP Request.
     * @param  incomingChannel is the incoming message channel (parameter
     * added in response to a request by Salvador Rey Calatayud.)
     */
    public void processRequest(
        SIPRequest sipRequest,
        MessageChannel incomingChannel);


}
