/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government
* and others.
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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import javax.sip.header.Header;
import javax.sip.header.HeaderAddress;
import javax.sip.header.Parameters;


/**
 * P-Called-Party-ID header - Private Header: RFC 3455.
 * <p>A proxy server inserts a P-Called-Party-ID header, typically in an INVITE request,
 * en-route to its destination. The header is populated with the Request-URI received
 * by the proxy in the request. </p>
 * <p>Both the business SIP URI and the personal SIP URI are registered in the SIP registrar,
 * so both URIs can receive invitations to new sessions. When the user receives an invitation
 * to join a session, he/she should be aware of which of the several registered SIP URIs this
 * session was sent to. </p>
 *
 * <pre>
 * P-Called-Party-ID    = "P-Called-Party-ID" HCOLON
 *                        called-pty-id-spec
 * called-pty-id-spec   = name-addr *(SEMI cpid-param)
 * cpid-param           = generic-param
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 *
 */


public interface PCalledPartyIDHeader extends HeaderAddress, Parameters, Header {

    /**
     * Name of CalledPartyIDHeader
     */
    public final static String NAME = "P-Called-Party-ID";

}
