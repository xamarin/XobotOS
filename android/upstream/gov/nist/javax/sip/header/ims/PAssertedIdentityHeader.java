/*
* Conditions Of Use
*
* This software was developed by employees of the National Institute of
* Standards and Technology (NIST), an agency of the Federal Government,
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
 * PRODUCT OF PT INOVACAO- EST DEPARTMENT *
 *******************************************/

package gov.nist.javax.sip.header.ims;

import javax.sip.header.Header;
import javax.sip.header.HeaderAddress;

/*
 * @author ALEXANDRE MIGUEL SILVA SANTOS - Nú 10045401
 */


/**
 * P-Asserted-Identity header
 * Private Header: RFC 3455.
 * Contains a URI (commonly a SIP URI) and an optional display-name
 * enable a network of trusted SIP servers to assert
 * the identity of authenticated users, and the application of existing
 * privacy mechanisms to the identity problem.
 * The use of this extension is only applicable inside an administrative
 * domain with previously agreed-upon policies for generation,
 * transport and usage of such information.
 *
 *
 */



public interface PAssertedIdentityHeader extends HeaderAddress, Header {

    /**
     * Name of AssertIdentityHeader
     */
    public final static String NAME = "P-Asserted-Identity";

}
