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

import java.text.ParseException;
import javax.sip.InvalidArgumentException;
import javax.sip.header.AuthorizationHeader;


/**
 *
 * Extension to Authorization header (3GPP TS 24299-5d0)
 *
 * This extension defines a new auth-param for the Authorization header used
 * in REGISTER requests.
 * For more information, see RFC 2617 [21] subclause 3.2.2.
 *
 * @author ALEXANDRE MIGUEL SILVA SANTOS
 */

public interface AuthorizationHeaderIms extends AuthorizationHeader
{

    // issued by Miguel Freitas (IT) PT-Inovacao
    public static final String YES  = "yes";
    public static final String NO   = "no";



    /**
     * @param integrityProtected
     * @throws ParseException
     */
    public void setIntegrityProtected(String integrityProtected) throws InvalidArgumentException, ParseException;


    public String getIntegrityProtected();

}
