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

import javax.sip.header.Header;
import javax.sip.header.HeaderAddress;

/**
 * P-Preferred-Identity header -
 * SIP Private Header: RFC 3325
 *
 * <ul>
 * <li>
 * . is used from a user agent to a trusted proxy to carry the identity the
 * user sending the SIP message wishes to be used for the P-Asserted-Header
 * field value that the trusted element will insert.
 * <li>
 * . If there are two values, one value MUST be a sip or sips URI and the other
 * MUST be a tel URI.
 * </ul>
 *
 * <p>Sintax: </p>
 * <pre>
 * PPreferredID = "P-Preferred-Identity" HCOLON PPreferredID-value
 *                 *(COMMA PPreferredID-value)
 * PPreferredID-value = name-addr / addr-spec
 * </pre>
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */


public interface PPreferredIdentityHeader extends HeaderAddress, Header {

     /**
     * Name of PreferredIdentityHeader
     */
    public final static String NAME = "P-Preferred-Identity";

}
