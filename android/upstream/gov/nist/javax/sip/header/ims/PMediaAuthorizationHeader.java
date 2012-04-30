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
/*****************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Aveiro University - Portugal)   *
 *****************************************************************************/


package gov.nist.javax.sip.header.ims;

import javax.sip.InvalidArgumentException;
import javax.sip.header.Header;


/**
 * The P-Media-Authorization SIP Private Header - RFC 3313.
 *
 * <p>Sintax:</p>
 * <pre>
 * P-Media-Authorization   = "P-Media-Authorization" HCOLON
 *                            P-Media-Authorization-Token
 *                            *(COMMA P-Media-Authorization-Token)
 * P-Media-Authorization-Token = 1*HEXDIG
 * </pre>
 *
 * @author Miguel Freitas (IT) PT-Inovacao
 */

public interface PMediaAuthorizationHeader extends Header
{

    /**
     * Name of PMediaAuthorizationHeader
     */
    public final static String NAME = "P-Media-Authorization";

    /**
     * Set the media authorization token.
     * @param token - media authorization token to set
     * @throws InvalidArgumentException - if token is null or empty
     */
    public void setMediaAuthorizationToken(String token) throws InvalidArgumentException;

    /**
     * Get the media authorization token.
     * @return token
     */
    public String getToken();


}
