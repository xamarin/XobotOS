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
/*******************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import gov.nist.core.Token;

import javax.sip.header.Header;
import javax.sip.header.Parameters;



/**
 * P-Visited-Network-ID SIP Private Header: RFC 3455.
 *
 * <ul>
 * <li>
 * . One of the conditions for a home network to accept the registration of a UA roaming to a
 * particular visited network, is the existence of a roaming agreement between the home and
 * the visited network. There is a need to indicate to the home network which one is the visited
 * network that is providing services to the roaming UA.
 * <li>
 * . user agents always register to the home network. The REGISTER request is proxied by
 * one or more proxies located in the visited network towards the home network
 * <li>
 * . the visited network includes an identification that is known at the home network
 * <li>
 * . This identification should be globally unique, and takes the form of a quoted text string or a token
 * <li>
 * . In case a REGISTER or other request is traversing different administrative domains
 * (e.g., different visited networks), a SIP proxy MAY insert a NEW P-Visited-Network-ID header
 * if the request does not contain a P-Visited-Network-ID header with the same network
 * identifier as its own network identifier
 * </ul>
 *
 * <p>Sintax: </p>
 *
 * <pre>
 * P-Visited-Network-ID = "P-Visited-Network-ID" HCOLON
 *                         vnetwork-spec
 *                         *(COMMA vnetwork-spec)
 * vnetwork-spec        = (token / quoted-string)
 *                         *(SEMI vnetwork-param)
 * vnetwork-param       = generic-param
 *
 *
 * eg: P-Visited-Network-ID: other.net, "Visited network number 1"
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */




public interface PVisitedNetworkIDHeader extends Parameters, Header {

    /**
     * Name of VisitedNetworkIDHeader
     */
    public final static String NAME = "P-Visited-Network-ID";


    /**
     * Set the visited network ID as a string. The value will be quoted in the header.
     * @param networkID - string value
     */
    public void setVisitedNetworkID(String networkID);

    /**
     * Set the visited network ID as a token
     * @param networkID - token value
     */
    public void setVisitedNetworkID(Token networkID);

    /**
     * Get the visited network ID value of this header
     */
    public String getVisitedNetworkID();

}
