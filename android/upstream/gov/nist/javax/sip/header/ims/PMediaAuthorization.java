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
/*****************************************************************************
 * PRODUCT OF PT INOVACAO - EST DEPARTMENT and Aveiro University - Portugal)   *
 *****************************************************************************/


package gov.nist.javax.sip.header.ims;


import java.text.ParseException;

import gov.nist.javax.sip.header.SIPHeader;

import javax.sip.InvalidArgumentException;
import javax.sip.header.ExtensionHeader;
import javax.sip.header.HeaderAddress;
import javax.sip.header.Parameters;


/**
 * P-Media-Authorization SIP Private Header - RFC 3313.
 *
 * <p>Sintax:</p>
 * <pre>
 * P-Media-Authorization   = "P-Media-Authorization" HCOLON
 *                            P-Media-Authorization-Token
 *                            *(COMMA P-Media-Authorization-Token)
 * P-Media-Authorization-Token = 1*HEXDIG
 * </pre>
 * @author Miguel Freitas (IT) PT-Inovacao
 */

public class PMediaAuthorization
    extends SIPHeader
    implements PMediaAuthorizationHeader, SIPHeaderNamesIms, ExtensionHeader
{

    /**
     * Comment for <code>serialVersionUID</code>
     */
    private static final long serialVersionUID = -6463630258703731133L;


    /**
     *  P-Media-Authorization Token
     */
    private String token;


    /**
     * Constructor
     */
    public PMediaAuthorization()
    {
        super(P_MEDIA_AUTHORIZATION);
    }


    /**
     * Get the media authorization token.
     *
     * @return token
     */
    public String getToken()
    {
        return token;
    }


    /**
     * Set the media authorization token.
     *
     * @param token - media authorization token to set
     * @throws InvalidArgumentException - if token is null or empty
     */
    public void setMediaAuthorizationToken(String token) throws InvalidArgumentException
    {
        if (token == null || token.length() == 0)
            throw new InvalidArgumentException(" the Media-Authorization-Token parameter is null or empty");

        this.token = token;
    }

    /**
     * Encode header
     * @return the header content
     */
    protected String encodeBody()
    {
        return token;
    }


    public void setValue(String value) throws ParseException {
        throw new ParseException (value,0);

    }


    public boolean equals(Object other)
    {
        if (other instanceof PMediaAuthorizationHeader)
        {
            final PMediaAuthorizationHeader o = (PMediaAuthorizationHeader) other;
            return this.getToken().equals(o.getToken());
        }
        return false;

    }


    public Object clone() {
        PMediaAuthorization retval = (PMediaAuthorization) super.clone();
        if (this.token != null)
            retval.token = this.token;
        return retval;
    }

}
